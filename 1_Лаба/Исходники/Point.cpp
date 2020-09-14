#include <cmath>

#include "Point.h"


void Point::Add(const Point& other)
{
	x += other.x;
	y += other.y;
}

float Point::FindMagnitude(const Point& from, const Point& to)
{
	float subX = to.x - from.x;
	float subY = to.y - from.y;

	return sqrt(subX * subX + subY * subY);
}

Point operator+(const Point& left, const Point& right)
{
	return Point(left.x + right.x, left.y + right.y);
}

Point operator-(const Point& left, const Point& right)
{
	return Point(left.x - right.x, left.y - right.y);
}
