#include "ConcreteShapes.h"

#include "ShapeException.h"
#include "GeometryMath.h"

#include <cmath>

Triangle::Triangle(const Point& a, const Point& b, const Point& c)
{
	int count = 3;
	Point* pts = new Point[count];
	pts[0] = a;
	pts[1] = b;
	pts[2] = c;
	_ConstructShape(pts, count, "Triangle");
	delete[] pts;
}

float Triangle::FindArea() const
{
	Point a = vertices[0], b = vertices[1], c = vertices[2];

	float A = GeometryMath::FindMagnitude({ a, b });
	float B = GeometryMath::FindMagnitude({ b, c });
	float C = GeometryMath::FindMagnitude({ b, c });

	if (!_IsTriangleExisting(A, B, C))
	{
		throw ShapeException(*this);
	}

	float p = (A + B + C) / 2;

	return sqrt(p * (p - A) * (p - B) * (p - C));
}

Point Triangle::FindCenter() const
{
	Point a = vertices[0], b = vertices[1], c = vertices[2];

	float A = GeometryMath::FindMagnitude({ a, b });
	float B = GeometryMath::FindMagnitude({ b, c });
	float C = GeometryMath::FindMagnitude({ b, c });

	if (!_IsTriangleExisting(A, B, C))
	{
		throw ShapeException(*this);
	}

	float Ox = 0, Oy = 0;

	for (int i = 0; i < count; i++)
	{
		Ox += vertices[i].x;
		Oy += vertices[i].y;
	}
	return Point(Ox / count, Oy / count);

	return Point(Ox / count, Oy / count);
}

bool Triangle::IsExisting() const
{
	Point a = vertices[0], b = vertices[1], c = vertices[2];

	float A = GeometryMath::FindMagnitude({ a, b });
	float B = GeometryMath::FindMagnitude({ b, c });
	float C = GeometryMath::FindMagnitude({ b, c });

	return _IsTriangleExisting(A, B, C);
}

bool Triangle::_IsTriangleExisting(float A, float B, float C)
{
	if (A + B > C&& A + C > B&& B + C > A)
	{
		return true;
	}
	return false;
}

Rect::Rect(const Point& point, float _height, float _width)
	: width(_width), height(_height)
{
	int count = 4;
	Point* pts = new Point[count];
	pts[0] = point;
	pts[1] = Point(point.x, point.y + height);
	pts[2] = Point(point.x + width, point.y + height);
	pts[3] = Point(point.x + width, point.y);
	_ConstructShape(pts, count, "Rect");
	delete[] pts;
}

float Rect::FindArea() const
{
	if (!_IsRectExisting(width, height))
	{
		throw ShapeException(*this);
	}

	return height * width;
}

Point Rect::FindCenter() const
{
	if (!_IsRectExisting(width, height))
	{
		throw ShapeException(*this);
	}

	float Ox = 0, Oy = 0;

	for (int i = 0; i < count; i++)
	{
		Ox += vertices[i].x;
		Oy += vertices[i].y;

	}

	return Point(Ox / count, Oy / count);
}

bool Rect::IsExisting() const
{
	return _IsRectExisting(width, height);
}

float Rect::GetHeight() const
{
	return width;
}

float Rect::GetWidth() const
{
	return height;
}

void Rect::SetHeight(float value)
{
	height = value;
	Point p = vertices[0];
	vertices[1] = Point(p.x, p.y + height);
	vertices[2] = Point(p.x + width, p.y + height);
	vertices[3] = Point(p.x + width, p.y);
}

void Rect::SetWidth(float value)
{
	width = value;
	Point p = vertices[0];
	vertices[1] = Point(p.x, p.y + height);
	vertices[2] = Point(p.x + width, p.y + height);
	vertices[3] = Point(p.x + width, p.y);
}

bool Rect::_IsRectExisting(float width, float height)
{
	return height != 0 && width != 0;
}
