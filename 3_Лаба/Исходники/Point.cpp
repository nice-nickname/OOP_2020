#include "Point.h"

bool Point::operator==(const Point& other)
{
	return x == other.x && y == other.y;
}

Point& Point::operator+=(const Point& offset)
{
	x += offset.x;
	y += offset.y;
	return *this;
}
