using FiguresDrawer.Model.Factories;
using FiguresDrawer.Model.Structures;
using FiguresDrawer.Presenter.Adapter;
using FiguresDrawer.Presenter.Drawing;
using FiguresDrawer.View;
using System;
using System.Windows.Forms;

namespace FiguresDrawer.Presenter
{
	public class FiguresCreatorPresenter : IPresenter
	{
		private IFiguresCreatorView _view;

		private ListBox.ObjectCollection _figuresBuffer;
		private ListBox.ObjectCollection _pointsBuffer;

		public FiguresCreatorPresenter(IFiguresCreatorView view)
		{
			_view = view;

			_figuresBuffer = _view.FiguresBuffer;
			_pointsBuffer = _view.PointsBuffer;

			FigureDrawerContainer.Instance.CopyValuesToCollection(_figuresBuffer);

			_view.OnCreateFigureButton_Click += View_OnCreateFigureButton_Click;
			_view.OnDeleteFigureButton_Click += View_OnDeleteFigureButton_Click;
			_view.OnClearPointsButton_Click	 += View_OnClearPointsButton_Click;
			_view.OnAddPointButton_Click	 += View_OnAddPointButton_Click;
			_view.OnReadFromFileButton_Click += View_OnReadFromFileButton_Click;
		}


		// ----------------------------------
		//		Methods-subscribers below
		// ----------------------------------


		private void View_OnReadFromFileButton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog dialog = new OpenFileDialog())
			{
				dialog.Filter = "Text files(*.txt)|*.txt";

				if (dialog.ShowDialog() == DialogResult.OK)
				{
					// TODO: ...
				}
			}
		}

		private void View_OnDeleteFigureButton_Click(object sender, int index)
		{
			if (index >= 0)
			{
				_figuresBuffer.RemoveAt(index);
				FigureDrawerContainer.Instance.Remove(index);
			}
		}

		private void View_OnCreateFigureButton_Click(object sender, EventArgs e)
		{
			if (_pointsBuffer.Count == 0)
			{
				return;
			}

			FigurePointsFactory factory = new FigurePointsFactory();

			Point[] points = new Point[_pointsBuffer.Count];

			for (int i = 0; i < points.Length; i++)
			{
				points[i] = (Point)_pointsBuffer[i];
			}

			try
			{
				var figure = factory.Create(points);
				var color = _view.GetSelectedColor();
				var figureDrawer = new FigureDrawer(new FiguresDataAdapter(figure), color);

				_figuresBuffer.Add(figureDrawer);
				FigureDrawerContainer.Instance.Add(figureDrawer);
			}
			catch (Exception excp)
			{
				_view.ShowError(excp.Message);
			}
		}

		private void View_OnClearPointsButton_Click(object sender, EventArgs e)
		{
			_pointsBuffer.Clear();
		}

		private void View_OnAddPointButton_Click(object sender, string stringX, string stringY)
		{
			try
			{
				double x = Double.Parse(stringX);
				double y = Double.Parse(stringY);

				_pointsBuffer.Add(new Point(x, y));
			}
			catch (Exception excp)
			{
				_view.ShowError(excp.Message);
			}
		}
	}
}
