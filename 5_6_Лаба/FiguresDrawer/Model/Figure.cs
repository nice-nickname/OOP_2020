using FiguresDrawer.Model.Structures;

namespace FiguresDrawer.Model
{
	public abstract class Figure
	{
		private Point[] _points;

		public Figure(Point[] points)
		{
			_points = points.Clone() as Point[];
			Name = GetType().Name;
		}

		public int PointsCount { get => _points.Length; }
		public string Name { get; set; }

		public abstract double FindArea();
		public abstract bool IsExisting();

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
