#pragma once

#include "Point.h"

struct Line
{
	Point begin;
	Point end;

	Line();
	Line(Point from, Point to);
};
