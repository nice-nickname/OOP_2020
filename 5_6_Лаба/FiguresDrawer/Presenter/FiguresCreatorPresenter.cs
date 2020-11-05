using FiguresDrawer.App.Core;
using FiguresDrawer.Model.Factories;
using FiguresDrawer.Model.Structures;
using FiguresDrawer.Presenter.Adapter;
using FiguresDrawer.Presenter.Drawing;
using FiguresDrawer.Presenter.Events;
using FiguresDrawer.View;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FiguresDrawer.Presenter
{
	public class FiguresCreatorPresenter : IPresenter
	{
		private IFiguresCreatorView _view;

		private ListBox.ObjectCollection _outFigures;

		private ListBox.ObjectCollection _figuresBuffer;
		private ListBox.ObjectCollection _pointsBuffer;

		public event Action<IPresenter, EventArgs> SendData;

		public FiguresCreatorPresenter(IFiguresCreatorView view)
		{
			_view = view;
			
			_figuresBuffer = _view.FiguresBuffer;
			_pointsBuffer = _view.PointsBuffer;

			_view.ReadFromFileButton_Click	+= View_OnReadFromFileButton_Click;
			_view.CreateFigureButton_Click	+= View_OnCreateFigureButton_Click;
			_view.DeleteFigureButton_Click	+= View_OnDeleteFigureButton_Click;
			_view.ClearPointsButton_Click	+= View_OnClearPointsButton_Click;
			_view.FigureList_IndexChanged	+= View_FigureList_IndexChanged;
			_view.AddPointButton_Click		+= View_OnAddPointButton_Click;
		}


		// ----------------------------------
		//		Methods-subscribers below
		// ----------------------------------


		private void View_FigureList_IndexChanged(object sender, int index)
		{
			if (index >= 0)
			{
				var points = (_figuresBuffer[index] as FigureDrawer).figure.GetRawPoints();

				object[] pts = new object[points.Length];

				points.CopyTo(pts, 0);

				_pointsBuffer.Clear();
				_pointsBuffer.AddRange(pts);

			}
		}

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
				_outFigures.RemoveAt(index);
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
				_outFigures.Add(figureDrawer);
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

		public void ReceiveData(IPresenter sender, EventArgs args)
		{
			if (args is DrawingEventArgs)
			{
				_outFigures = (args as DrawingEventArgs).Figures;
				_figuresBuffer.AddRange(_outFigures);
			}
			else
			{
				throw new ArgumentException("invalid event args '" + nameof(args) + "' sended");
			}
		}
	}
}
