#pragma once

#include "Line.h"
#include "Shape.h"

class GeometryMath
{
public:

	GeometryMath();

	const double pi;
	const double epsilon;

	double DegreesToRadian(int degrees) const;

	double FindMagnitude(const Line& line) const;

	double FindAngle(const Line& first, const Line& second) const;

	bool IsIntersected(const Line& lFirst, const Line& lSecond) const;
	bool IsIntersected(const Shape& lFirst, const Shape& lSecond) const;

	// Not-strict inclusion
	bool IsIncluded(Point p, const Shape& figure);
	bool IsIncluded(const Shape& dest, const Shape& incl);

private:

	bool _IsIncludedDontValidate(Point p, const Shape& figure);
	void _ValidateShape(const Shape& shape) const;
};