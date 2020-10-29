using FiguresDrawer.Model.Structures;

namespace FiguresDrawer.Model.Figures
{
	public class Rectangle : Figure
	{
		public Rectangle(Point[] points) : base(points, "Rectangle")
		{
		}

		public override double FindArea()
		{
			double h, w;

			FindParameters(out h, out w);

			return h * w;
		}

		public override bool IsExisting()
		{
			GeometryOperations math = new GeometryOperations();
			Point[] points = GetPoints();

			for (int i = 0; i < points.Length; i++)
			{
				double angle = math.FindAngle(
					new LineSegment(points[i], points[(i + 1) % points.Length]),
					new LineSegment(points[(i + 1) % points.Length], points[(i + 2) % points.Length])
					);
				if (math.IsDoubleEqual(angle, System.Math.PI / 2) == false)
				{
					return false;
				}
			}
			return true;
		}

		private void FindParameters(out double height, out double width)
		{
			GeometryOperations math = new GeometryOperations();

			Point[] pts = GetPoints();

			height = math.FindMagnitude(new LineSegment(pts[0], pts[1]));
			width = math.FindMagnitude(new LineSegment(pts[1], pts[2]));
		}
	}
}
