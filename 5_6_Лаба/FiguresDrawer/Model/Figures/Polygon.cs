using FiguresDrawer.Model.Structures;
using System;

namespace FiguresDrawer.Model.Figures
{
	public class Polygon : Figure
	{
		public Polygon(Point[] points) : base(points)
		{
		}

		public override double FindArea()
		{
			double area = 0;

			Point[] points = GetPoints();

			int j = points.Length - 1;
			for (int i = 0; i < points.Length; i++)
			{
				Point prev = points[j];
				Point curr = points[i];

				area += (prev.X + curr.X) * (prev.Y - curr.Y);
				j = i;
			}

			return Math.Abs(area / 2);
		}

		public override bool IsExisting()
		{
			Point[] points = GetPoints();

			// Checking for repeating points
			for (int i = 0; i < points.Length; i++)
			{
				for (int j = 0; j < points.Length; j++)
				{
					if (i != j && GeometryMath.IsPointsEqual(points[i], points[j]))
					{
						return false;
					}
				}
			}

			// Checking for self-intersections;
			for (int i = 0; i < points.Length; i++)
			{
				for (int j = 0; j < points.Length; j++)
				{
					LineSegment a = new LineSegment(points[i], points[(i + 1) % points.Length]);
					LineSegment b = new LineSegment(points[j], points[(j + 1) % points.Length]);

					if (i != j && GeometryMath.IsIntersected(a, b))
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}
