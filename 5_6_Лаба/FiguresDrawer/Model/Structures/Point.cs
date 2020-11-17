namespace FiguresDrawer.Model.Structures
{
	public struct Point
	{
		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}

		public double X { get; set; }
		public double Y { get; set; }

		public override string ToString()
		{
			return $"[x={X}, y={Y}]";
		}
	}
}
