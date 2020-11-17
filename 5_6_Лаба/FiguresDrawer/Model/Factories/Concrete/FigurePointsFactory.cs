using FiguresDrawer.Model.Structures;
using FiguresDrawer.Model.Figures;

namespace FiguresDrawer.Model.Factories
{
	public class FigurePointsFactory : IFigureFactory
	{
		public FigureBase Create(Point[] points)
		{
			int length = points.Length;
			if (length == 1)
			{
				throw new System.ArgumentException("Слишком мало точек для создания фигуры.");
			}
			else if (length == 2)
			{
				var segment = new Segment(points);
				if (segment.IsExisting())
				{
					return segment;
				}
			}
			else if (length == 3)
			{
				var triangle = new Triangle(points);
				if (triangle.IsExisting())
				{
					return triangle;
				}
			}
			else if (length == 4)
			{
				var rect = new Rectangle(points);
				if (rect.IsExisting())
				{
					return rect;
				}
				else
				{
					var polygon = new Polygon(points);
					if (polygon.IsExisting())
					{
						return polygon;
					}
				}
			}
			else
			{
				var polygon = new Polygon(points);
				if (polygon.IsExisting())
				{
					return polygon;
				}
			}

			throw new System.ArgumentException("Неудачная попытка создать фигуру, неправильные точки");
		}
	}
}
