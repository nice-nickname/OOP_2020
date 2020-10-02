#include "Shape.h"

#include "GeometryMath.h"
#include "ShapeException.h"

#include <algorithm>
#include <cmath>

Shape::Shape()
	: vertices(nullptr),
	verticesCount(0),
	name("Abstract shape")
{
}

Shape::Shape(const Shape& other)
	: Shape(other.vertices, other.verticesCount, other.name)
{}

Shape::Shape(const Point* points, int length, std::string _name)
	: verticesCount(length),
	vertices(new Point[verticesCount]),
	name(_name)
{
	std::copy(points, points + verticesCount, vertices);
}

Shape::~Shape()
{
	if (vertices != nullptr)
	{
		delete[] vertices;
	}
}

Shape& Shape::operator=(const Shape& other)
{
	if (this == &other)
	{
		return *this;
	}

	if (vertices != nullptr)
	{
		delete[] vertices;
	}

	verticesCount = other.verticesCount;
	vertices = new Point[verticesCount];
	std::copy(other.vertices, other.vertices + verticesCount, vertices);
	return *this;
}

Point Shape::FindCenter() const
{
	double _x = 0, _y = 0;
	for (int i = 0; i < verticesCount; i++)
	{
		_x += vertices[i].x;
		_y += vertices[i].y;
	}
	return Point(_x / verticesCount, _y / verticesCount);
}

void Shape::Move(double xOffset, double yOffset)
{
	Point _offset(xOffset, yOffset);
	for (int i = 0; i < verticesCount; i++)
	{
		vertices[i] += _offset;
	}
}

void Shape::Rotate(int degrees)
{
	GeometryMath math;

	double _angle = math.DegreesToRadian(degrees);

	Point _old;
	for (int i = 0; i < verticesCount; i++)
	{
		_old = vertices[i];

		vertices[i] = Point(
			_old.x * cos(_angle) - _old.y * sin(_angle),
			_old.y * sin(_angle) + _old.y * cos(_angle)
		);
	}
}

std::string Shape::GetName() const
{
	return name;
}

int Shape::GetVerticesCount() const
{
	return verticesCount;
}

const Point* Shape::GetVertices() const
{
	return vertices;
}

Line* Shape::FindEdges() const
{
	int _count = GetVerticesCount();
	Line* _lines = new Line[_count];
	for (int i = 0; i < _count - 1; i++)
	{
		_lines[i] = Line(vertices[i], vertices[i + 1]);
	}
	_lines[_count - 1] = Line(vertices[_count - 1], vertices[0]);

	return _lines;
}

void Shape::_CheckExisting()
{
	if (!IsExisting())
	{
		throw ShapeException(*this);
	}
}
