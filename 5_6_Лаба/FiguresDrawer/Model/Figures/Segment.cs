using FiguresDrawer.Model.Structures;

namespace FiguresDrawer.Model.Figures
{
	public class Segment : Figure
	{
		public Segment(Point[] points) : base(points, "Segment")
		{
		}

		public override double FindArea()
		{
			throw new System.InvalidOperationException("Can't calculate area of segment");
		}

		public override bool IsExisting()
		{
			GeometryOperations math = new GeometryOperations();

			Point[] points = GetPoints();

			return !math.IsPointsEqual(points[0], points[1]);
		}
	}
}
