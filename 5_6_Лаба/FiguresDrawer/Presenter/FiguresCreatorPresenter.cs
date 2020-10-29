using FiguresDrawer.Model;
using FiguresDrawer.Model.Factories;
using FiguresDrawer.Model.Structures;
using FiguresDrawer.Presenter.Adapter;
using FiguresDrawer.View;
using System;
using System.Windows.Forms;

namespace FiguresDrawer.Presenter
{
	public class FiguresCreatorPresenter : IPresenter
	{
		private IFiguresCreatorView _view;

		private ListBox.ObjectCollection _figuresBuffer; // Temp list of Figures,
		private ListBox.ObjectCollection _pointsBuffer;	 // Destroys on Close()

		private ListBox.ObjectCollection _outFigures;	 // List of figures from Drawer Presenter

		public FiguresCreatorPresenter(IFiguresCreatorView view, ListBox.ObjectCollection figures)
		{
			_view = view;

			_outFigures = figures;

			_figuresBuffer = _view.FiguresBuffer;
			_pointsBuffer = _view.PointsBuffer;

			_figuresBuffer.AddRange(figures);

			_view.OnCreateFigureButton_Click += View_OnCreateFigureButton_Click;
			_view.OnDeleteFigureButton_Click += View_OnDeleteFigureButton_Click;
			_view.OnClearPointsButton_Click  += View_OnClearPointsButton_Click;
			_view.OnAddPointButton_Click	 += View_OnAddPointButton_Click;

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
				Figure figure = factory.Create(points);

				_figuresBuffer.Add(figure);
				_outFigures.Add(new FigureDrawer(new FiguresDataAdapter(figure), System.Drawing.Color.Red));
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
			catch (Exception e)
			{
				_view.ShowError(e.Message);
			}
		}
	}
}
