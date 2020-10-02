#include "Line.h"

#include <cmath>

Line::Line()
	: begin(), end()
{}

Line::Line(Point _begin, Point _end)
	: begin(_begin), end(_end)
{}