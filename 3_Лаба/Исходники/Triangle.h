#pragma once

#include "Shape.h"

class Triangle : public Shape
{
public:

	Triangle() = delete;
	Triangle(const Point* points);

	double FindArea() const override;
	bool IsExisting() const override;

};

