#pragma once

#include "Point.h"

struct Line
{
	Point begin;
	Point end;
	
	Line();
	Line(Point _begin, Point _end);
};

