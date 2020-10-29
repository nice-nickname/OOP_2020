namespace FiguresDrawer.Model.Structures
{
	public struct Point
	{
		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}

		public double X;
		public double Y;

		public override string ToString()
		{
			return string.Format("[x={0}, y={1}]", X, Y);
		}
	}
}
