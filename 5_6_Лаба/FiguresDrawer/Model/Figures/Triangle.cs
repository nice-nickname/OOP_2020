using FiguresDrawer.Model.Structures;

namespace FiguresDrawer.Model.Figures
{
	public class Triangle : FigureBase
	{
		public Triangle(Point[] points) : base(points)
		{
		}

		public override double FindArea()
		{
			var lines = GetLines();

			var p = FindPerimeter() / 2;
			var a = GeometryMath.FindMagnitude(lines[0]);
			var b = GeometryMath.FindMagnitude(lines[1]);
			var c = GeometryMath.FindMagnitude(lines[2]);

			return System.Math.Sqrt(p * (p - a) * (p - b) * (p - c));
		}

		public override bool IsExisting()
		{
			var lines = GetLines();

			var a = GeometryMath.FindMagnitude(lines[0]);
			var b = GeometryMath.FindMagnitude(lines[1]);
			var c = GeometryMath.FindMagnitude(lines[2]);

			return a + b > c && a + c > b && b + c > a;
		}

		private LineSegment[] GetLines()
		{
			var lines = new LineSegment[3];
			var points = GetPoints();

			for (int i = 0; i < lines.Length; i++)
			{
				lines[i] = new LineSegment(points[i], points[(i + 1) % lines.Length]);
			}

			return lines;
		}
	}
}
