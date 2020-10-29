using FiguresDrawer.Model.Structures;

namespace FiguresDrawer.Model
{
	public class Figure
	{
		private readonly Point[] _points;
		private readonly string _name;

		public Figure(Point[] points, string name = "Figure")
		{
			_points = points.Clone() as Point[];
			_name = name;
		}

		public int PointsCount { get => _points.Length; }
		public string Name { get => _name; }
		public Point this[int i] { get => new Point(_points[i].X, _points[i].Y); }

		virtual public double FindArea()
		{
			throw new System.InvalidOperationException("Cant calculate area of [" + ToString() + "]");
		}

		virtual public double FindPerimeter()
		{
			GeometryOperations math = new GeometryOperations();

			double perimeter = 0;

			for (int i = 0; i < _points.Length; i++)
			{
				perimeter += math.FindMagnitude(_points[i], _points[(i + 1) % _points.Length]);
			}

			return perimeter;
		}

		virtual public Point FindCenter()
		{
			double x = 0, y = 0;

			foreach (var point in _points)
			{
				x += point.X;
				y += point.Y;
			}

			return new Point(x / _points.Length, y / _points.Length);
		}

		public virtual bool IsExisting()
		{
			return _points.Length > 2;
		}

		protected Point[] GetPoints() => _points;

		public override string ToString()
		{
			return "Name: " + _name + "; Points count: " + _points.Length.ToString();
		}
	}
}
