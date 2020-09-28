#include "Shape.h"

#include <stdexcept>
#include <cmath>

#include "ShapeException.h"
#include "GeometryMath.h"


void Shape::Rotate(int degrees)
{
	if (!IsExisting())
	{
		throw new ShapeException(*this);
	}

	float a = GeometryMath::DegreeToRadian(degrees % 360);

	for (int i = 0; i < count; i++)
	{
		float x = vertices[i].x;;
		float y = vertices[i].y;
		vertices[i] = Point(x * cos(a) - y * sin(a), x * sin(a) + y * cos(a));
	}
}

void Shape::Move(const Point& offset)
{
	if (!IsExisting())
	{
		throw new ShapeException(*this);
	}

	for (int i = 0; i < count; i++)
	{
		vertices[i] += offset;
	}
}

Point* Shape::GetVerticesCopy() const
{
	if (count == 0)
	{
		return nullptr;
	}
	Point* arr = new Point[count];
	std::copy(vertices, vertices + count, arr);
	return arr;
}

std::string Shape::GetName() const
{
	return name;
}

int Shape::GetCount() const
{
	return count;
}

void Shape::_CopyArray(Point* points, int length)
{
	vertices = new Point[length];

	if (points != nullptr)
	{
		std::copy(points, points + length, vertices);
	}
}

void Shape::_ConstructShape(Point* points, int length, const std::string& _name)
{
	name = _name;
	count = length;
	_CopyArray(points, count);
}

Shape::Shape()
	: count(0), vertices(nullptr), name("Shape")
{}

Shape::Shape(Point* points, int length, const std::string& _name)
	: vertices(nullptr), count(length), name(_name)
{
	if (count <= 0)
	{
		throw new std::invalid_argument("Invalid array length");
	}

	_CopyArray(points, count);
}

Shape::Shape(const Shape& other)
	: count(other.count), name(other.name)
{
	_CopyArray(other.vertices, count);
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
	count = other.count;
	_CopyArray(other.vertices, count);
	return *this;
}

Point& Shape::operator[](int index)
{
	if (index >= count || index < 0)
	{
		throw new std::out_of_range("invalid index uses in Shape::operator[]");
	}
	return vertices[index];
}

Shape::~Shape()
{
	if (vertices != nullptr)
	{
		delete[] vertices;
	}
}
