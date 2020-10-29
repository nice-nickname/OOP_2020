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
			return new Point(End.X - Begin.X, End.Y - End.Y);
		}

		public Point Begin;
		public Point End;
	}
}
