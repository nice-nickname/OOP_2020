#include "Point.h"

Point::Point()
	: x(0), y(0)
{}

Point::Point(double _x, double _y)
	: x(_x), y(_y)
{}

bool Point::operator==(Point other)
{
	if (x == other.x && y == other.y)
	{
		return true;
	}
	return false;
}

Point& Point::operator+=(Point other)
{
	x += other.x;
	y += other.y;
	return *this;
}
