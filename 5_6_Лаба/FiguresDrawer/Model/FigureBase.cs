using FiguresDrawer.Model.Structures;

namespace FiguresDrawer.Model
{
	public class FigureBase : IFigure
	{
		private Point[] _points;

		public FigureBase(Point[] points)
		{
			_points = points.Clone() as Point[];
			Name = GetType().Name;
		}

		public int PointsCount { get => _points.Length; }
		public string Name { get; set; }

		public virtual double FindArea()
		{
			throw new System.NotImplementedException("Method FindArea not implemented");
		}

		public virtual bool IsExisting()
		{
			throw new System.NotImplementedException("Method area not implemented");
		}

		public virtual double FindPerimeter()
		{
			double perimeter = 0f;

			for (int i = 0; i < _points.Length; i++)
			{
				perimeter += GeometryMath.FindMagnitude(_points[i], _points[(i + 1) % _points.Length]);
			}

			return perimeter;
		}

		public virtual Point FindCenter()
		{
			double x = 0, y = 0;

			foreach (var point in _points)
			{
				x += point.X;
				y += point.Y;
			}

			return new Point(x / _points.Length, y / _points.Length);
		}


		public Point[] GetPoints() => _points;

		public override string ToString()
		{
			return "Name: " + Name + "; Points count: " + _points.Length.ToString();
		}
	}
}
