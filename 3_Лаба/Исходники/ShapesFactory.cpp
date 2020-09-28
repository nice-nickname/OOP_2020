#include "ShapesFactory.h"

#include "ConcreteShapes.h"

Shape* TriangleFactory::CreateShape(const Point& a, const Point& b, const Point& c)
{
	return new Triangle(a, b, c);
}

Shape* RectFactory::CreateShape(const Point& a, float width, float height)
{
	return new Rect(a, height, width);
}
