using FiguresDrawer.Model.Structures;

namespace FiguresDrawer.Model.Figures
{
	public class Rectangle : FigureBase
	{
		public Rectangle(Point[] points) : base(points)
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
			var points = GetPoints();

			for (int i = 0; i < points.Length; i++)
			{
				var angle = GeometryMath.FindAngle(
					new LineSegment(points[i], points[(i + 1) % points.Length]),
					new LineSegment(points[(i + 1) % points.Length], points[(i + 2) % points.Length])
					);
				if (GeometryMath.IsDoubleEqual(angle, System.Math.PI / 2) == false)
				{
					return false;
				}
			}
			return true;
		}

		private void FindParameters(out double height, out double width)
		{
			var pts = GetPoints();

			height = GeometryMath.FindMagnitude(new LineSegment(pts[0], pts[1]));
			width = GeometryMath.FindMagnitude(new LineSegment(pts[1], pts[2]));
		}
	}
}
