using FiguresDrawer.Model.Structures;
using System;

namespace FiguresDrawer.Model.Figures
{
	public class Polygon : FigureBase
	{
		public Polygon(Point[] points) : base(points)
		{
		}

		public override double FindArea()
		{
			double area = 0;

			var points = GetPoints();

			int j = points.Length - 1;
			for (int i = 0; i < points.Length; i++)
			{
				var prev = points[j];
				var curr = points[i];

				area += (prev.X + curr.X) * (prev.Y - curr.Y);
				j = i;
			}

			return Math.Abs(area / 2);
		}

		public override bool IsExisting()
		{
			var points = GetPoints();

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
					var a = new LineSegment(points[i], points[(i + 1) % points.Length]);
					var b = new LineSegment(points[j], points[(j + 1) % points.Length]);

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
