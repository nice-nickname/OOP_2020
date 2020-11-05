using FiguresDrawer.Model;
using System;
using System.Drawing;

namespace FiguresDrawer.Presenter.Adapter
{
	public class FiguresDataAdapter : IFigureAdapter
	{
		private Figure _figure;

		public Type BaseType => _figure.GetType();

		public FiguresDataAdapter(Figure figure)
		{
			_figure = figure;
		}

		public PointF[] GetPoints()
		{
			PointF[] points = new PointF[_figure.PointsCount];

			Model.Structures.Point[] pts = _figure.GetPoints();

			for (int i = 0; i < points.Length; i++)
			{
				points[i] = Convert(pts[i]);
			}

			return points;
		}

		public double GetArea()
		{
			return _figure.FindArea();
		}

		public PointF GetCenter()
		{
			return Convert(_figure.FindCenter());
		}

		public double GetPerimeter()
		{
			return _figure.FindPerimeter();
		}

		private PointF Convert(Model.Structures.Point point)
		{
			float x = (float)point.X;
			float y = (float)point.Y;

			return new PointF(x, y);
		}

		public override string ToString()
		{
			return _figure.Name + ". Points count: " + _figure.PointsCount;
		}

		public Model.Structures.Point[] GetRawPoints()
		{
			return _figure.GetPoints();
		}
	}
}
