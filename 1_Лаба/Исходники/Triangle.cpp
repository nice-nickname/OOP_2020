#include <exception>
#include <sstream>
#include <cmath>

#include "TriangleExistingException.h"
#include "Triangle.h"

using namespace std;

Triangle::Triangle(const Point& p1, const Point& p2, const Point& p3)
	: points{ p1, p2, p3 }
{}

Triangle::Triangle(float x1, float y1, float x2, float y2, float x3, float y3)
	: Triangle({ x1, y1 }, { x2, y2 }, { x3, y3 })
{}

Point Triangle::FindCenter() const
{
	if (!IsExisting())
	{
		throw TriangleExistingException(*this);
	}

	float centerX = (points[0].x + points[1].x + points[2].x) / 3;
	float centerY = (points[0].y + points[1].y + points[2].y) / 3;

	return Point(centerX, centerY);
}

float Triangle::FindArea() const
{
	if (!IsExisting())
	{
		throw TriangleExistingException(*this);
	}

	float a, b, c;
	_CalculateMagnitudes(a, b, c);
	float p = (a + b + c) / 2;

	return sqrt(p * (p - a) * (p - b) * (p - c));
}

float Triangle::FindPerimeter() const
{
	if (!IsExisting())
	{
		throw TriangleExistingException(*this);
	}

	float a, b, c;
	_CalculateMagnitudes(a, b, c);

	return a + b + c;
}

void Triangle::Move(Point offset)
{
	points[0].Add(offset);
	points[1].Add(offset);
	points[2].Add(offset);
}

Point Triangle::GetFirstPoint() const
{
	return points[0];
}

Point Triangle::GetSecondPoint() const
{
	return points[1];
}

Point Triangle::GetThirdPoint() const
{
	return points[2];
}

void Triangle::SetFirstPoint(const Point& other)
{
	points[0] = other;
}

void Triangle::SetSecondPoint(const Point& other)
{
	points[1] = other;
}

void Triangle::SetThirdPoint(const Point& other)
{
	points[2] = other;
}

bool Triangle::IsAreasEqual(const Triangle& other) const
{
	if (this->_CompareArea(other) == 0)
	{
		return true;
	}
	return false;
}

bool Triangle::IsExisting() const
{
	float a, b, c;
	_CalculateMagnitudes(a, b, c);

	if ((a + b > c) && (b + c > a) && (a + c > b))
	{
		return true;
	}
	return false;
}

void Triangle::_CalculateMagnitudes(float& a, float& b, float& c) const
{
	a = Point::FindMagnitude(points[0], points[1]);
	b = Point::FindMagnitude(points[1], points[2]);
	c = Point::FindMagnitude(points[2], points[0]);
}

int Triangle::_CompareArea(const Triangle& other) const
{
	float S1 = this->FindArea();
	float S2 = other.FindArea();

	if (S1 > S2)
	{
		return 1;
	}
	else if (S1 == S2)
	{
		return 0;
	}
	else
	{
		return -1;
	}
}

bool operator>(const Triangle& left, const Triangle& right)
{
	if (left._CompareArea(right) > 0)
	{
		return true;
	}
	return false;
}

bool operator<(const Triangle& left, const Triangle& right)
{
	if (left._CompareArea(right) < 0)
	{
		return true;
	}
	return false;
}

bool operator>=(const Triangle& left, const Triangle& right)
{
	if (left._CompareArea(right) >= 0)
	{
		return true;
	}
	return false;
}

bool operator<=(const Triangle& left, const Triangle& right)
{
	if (left._CompareArea(right) <= 0)
	{
		return true;
	}
	return false;
}
