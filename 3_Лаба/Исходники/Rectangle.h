#pragma once

#include "Shape.h"

class Rectangle : public Shape
{
public:

	Rectangle() = delete;
	Rectangle(const Point* points);

	double FindArea() const override;
	bool IsExisting() const override;

};

