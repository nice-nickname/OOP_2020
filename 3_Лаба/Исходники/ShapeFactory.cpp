#include "ShapeFactory.h"

Shape* ShapeFactory::CreateShape(const Point* points, int length)
{
	Shape* res = nullptr;
	if (length == 3)
	{
		Triangle t(points);
		if (t.IsExisting())
		{
			res = new Triangle(points);
		}
	}
	else if (length == 4)
	{
		Rectangle r(points);
		if (r.IsExisting())
		{
			res = new Rectangle(points);
		}
	}
	return res;
}
