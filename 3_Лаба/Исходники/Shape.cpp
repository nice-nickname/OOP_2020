#include "Shape.h"

#include "GeometryMath.h"
#include "ShapeException.h"

#include <algorithm>
#include <cmath>

Shape::Shape()
	: _vertices(nullptr),
	_verticesCount(0),
	_name("Abstract shape")
{
}

Shape::Shape(const Shape& other)
	: Shape(other._vertices, other._verticesCount, other._name)
{}

Shape::Shape(const Point* points, int length, std::string name)
	: _verticesCount(length),
	_vertices(new Point[_verticesCount]),
	_name(name)
{
	std::copy(points, points + _verticesCount, _vertices);
}

Shape::~Shape()
{
	if (_vertices != nullptr)
	{
		delete[] _vertices;
	}
}

Shape& Shape::operator=(const Shape& other)
{
	if (this == &other)
	{
		return *this;
	}

	if (_vertices != nullptr)
	{
		delete[] _vertices;
	}

	_verticesCount = other._verticesCount;
	_vertices = new Point[_verticesCount];
	std::copy(other._vertices, other._vertices + _verticesCount, _vertices);
	return *this;
}

Point Shape::FindCenter() const
{
	double x = 0, y = 0;
	for (int i = 0; i < _verticesCount; i++)
	{
		x += _vertices[i].x;
		y += _vertices[i].y;
	}
	return Point(x / _verticesCount, y / _verticesCount);
}

void Shape::Move(double xOffset, double yOffset)
{
	Point offset(xOffset, yOffset);
	for (int i = 0; i < _verticesCount; i++)
	{
		_vertices[i] += offset;
	}
}

void Shape::Rotate(int degrees)
{
	GeometryMath math;

	double angle = math.DegreesToRadian(degrees);

	Point oldPoint;
	for (int i = 0; i < _verticesCount; i++)
	{
		oldPoint = _vertices[i];

		_vertices[i] = Point(
			oldPoint.x * cos(angle) - oldPoint.y * sin(angle),
			oldPoint.x * sin(angle) + oldPoint.y * cos(angle)
		);
	}
}

std::string Shape::GetName() const
{
	return _name;
}

int Shape::GetVerticesCount() const
{
	return _verticesCount;
}

const Point* Shape::GetVertices() const
{
	return _vertices;
}

Line* Shape::FindEdges() const
{
	int count = GetVerticesCount();
	Line* lines = new Line[count];
	for (int i = 0; i < count - 1; i++)
	{
		lines[i] = Line(_vertices[i], _vertices[i + 1]);
	}
	lines[count - 1] = Line(_vertices[count - 1], _vertices[0]);

	return lines;
}

void Shape::_CheckExisting()
{
	if (!IsExisting())
	{
		throw ShapeException(*this);
	}
}
