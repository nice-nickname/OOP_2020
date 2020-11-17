namespace FiguresDrawer.Model.Structures
{
	public struct LineSegment
	{
		public LineSegment(Point begin, Point end)
		{
			Begin = begin;
			End = end;
		}

		public Point ConvertToVector()
		{
			return new Point(End.X - Begin.X, End.Y - Begin.Y);
		}

		public Point Begin { get; set; }
		public Point End { get; set; }
	}
}
