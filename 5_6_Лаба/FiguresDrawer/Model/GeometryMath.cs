using FiguresDrawer.Model.Structures;
using System;

namespace FiguresDrawer.Model
{
	public static class GeometryMath
	{
		public const double Epsilon = 1e-9;
		public static double FindMagnitude(Point from, Point to)
		{
			double x = to.X - from.X;
			double y = to.Y - from.Y;

			return Math.Sqrt(x * x + y * y);
		}

		public static bool IsDoubleEqual(double left, double right)
		{
			return Math.Abs(left - right) <= Epsilon;
		}

		public static double FindMagnitude(LineSegment line)
		{
			return FindMagnitude(line.Begin, line.End);
		}

		public static bool IsPointsEqual(Point left, Point right)
		{
			return Math.Abs(left.X - right.X) <= Epsilon
				&& Math.Abs(left.Y - right.Y) <= Epsilon;
		}

		public static double FindAngle(LineSegment fLine, LineSegment sLine)
		{
			var v1 = fLine.ConvertToVector();
			var v2 = sLine.ConvertToVector();

			double scalar = v1.X * v2.X + v1.Y * v2.Y;

			double m1 = FindMagnitude(fLine);
			double m2 = FindMagnitude(sLine);

			return Math.Acos(scalar / m1 * m2);
		}

		public static bool IsIntersected(LineSegment fLine, LineSegment sLine)
		{
			var p1 = fLine.Begin;
			var p2 = fLine.End;
			var p3 = sLine.Begin;
			var p4 = sLine.End;

			double v1 = (p4.X - p3.X) * (p1.Y - p3.Y) - (p4.Y - p3.Y) * (p1.X - p3.X);
			double v2 = (p4.Y - p3.Y) * (p2.X - p1.X) - (p4.X - p3.X) * (p2.Y - p1.Y);
			double v3 = (p2.X - p1.X) * (p1.Y - p3.Y) - (p2.Y - p1.Y) * (p1.X - p3.X);
			double v4 = (p4.Y - p3.Y) * (p2.X - p1.X) - (p4.X - p3.X) * (p2.Y - p1.Y);

			double u1 = v1 / v2, u2 = v3 / v4;

			return u1 > 0 && u1 < 1 && u2 > 0 && u2 < 1;
		}
	}
}
