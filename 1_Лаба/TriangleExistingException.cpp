#include <string>
#include <sstream>

#include "TriangleExistingException.h"


TriangleExistingException::TriangleExistingException(const Triangle _triangle)
	: triangle(_triangle)
{
	std::stringstream sstream;

	Point p1 = triangle.GetFirstPoint();
	Point p2 = triangle.GetSecondPoint();
	Point p3 = triangle.GetThirdPoint();

	sstream << "Triangle doesn't exist with points: \n"
			<< "x1: " << p1.x << " y1: " << p1.y << "\n"
			<< "x2: " << p2.x << " y2: " << p2.y << "\n"
			<< "x3: " << p3.x << " y3: " << p3.y;

	what_string = sstream.str();
}

const char* TriangleExistingException::what() const noexcept
{
	return what_string.c_str();
}
