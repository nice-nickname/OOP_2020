#pragma once

#include "Shape.h"

class TriangleFactory
{
public:
	static Shape* CreateShape(const Point& a, const Point& b, const Point& c);
};

class RectFactory
{
public:
	static Shape* CreateShape(const Point& a, float width, float height);
};
