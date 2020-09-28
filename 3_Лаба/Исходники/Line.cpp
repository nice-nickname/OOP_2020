#include "Line.h"

Line::Line()
	: begin(), end()
{}

Line::Line(Point from, Point to)
	: begin(from), end(to)
{}
