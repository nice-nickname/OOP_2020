#pragma once

#include "Shape.h"
#include "Rectangle.h"
#include "Triangle.h"

class ShapeFactory
{
public:

	static Shape* CreateShape(const Point* points, int length);

};

