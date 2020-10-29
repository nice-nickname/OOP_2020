using FiguresDrawer.Model.Structures;

namespace FiguresDrawer.Model.Figures
{
	public class Triangle : Figure
	{
		public Triangle(Point[] points) : base(points, "Triangle")
		{
		}

		public override double FindArea()
		{
			GeometryOperations math = new GeometryOperations();

			var lines = GetLines();

			double p = FindPerimeter() / 2;
			double a = math.FindMagnitude(lines[0]);
			double b = math.FindMagnitude(lines[1]);
			double c = math.FindMagnitude(lines[2]);

			return System.Math.Sqrt(p * (p - a) * (p - b) * (p - c));
		}

		public override bool IsExisting()
		{
			GeometryOperations math = new GeometryOperations();

			var lines = GetLines();

			double a = math.FindMagnitude(lines[0]);
			double b = math.FindMagnitude(lines[1]);
			double c = math.FindMagnitude(lines[2]);

			return a + b > c && a + c > b && b + c > a;
		}

		private LineSegment[] GetLines()
		{
			LineSegment[] lines = new LineSegment[3];
			Point[] points = GetPoints();

			for (int i = 0; i < lines.Length; i++)
			{
				lines[i] = new LineSegment(points[i], points[(i + 1) % lines.Length]);
			}

			return lines;
		}
	}
}
