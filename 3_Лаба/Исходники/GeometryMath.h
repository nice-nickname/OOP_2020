#pragma once

#include "Shape.h"

#include "Line.h"

#include <cmath>

// class with only static methods
class GeometryMath
{
public:
	GeometryMath() = delete;
	GeometryMath(const GeometryMath& other) = delete;
	GeometryMath(GeometryMath&& rvalue) = delete;

	static constexpr float pi = 3.1415926535897932385f;
	static constexpr float epsilon = 0.00001f;

	static float FindMagnitude(const Line& line);
	static float CalculateScalar(const Line& v1, const Line& v2);

	static bool IsIntersected(const Shape& first, const Shape& second);
	static bool IsIntersected(const Line& first, const Line& second);

	static bool IsIncluding(const Shape& dest, const Shape& incl);
	static bool IsIncluding(const Point& p, const Shape& figure);

	static float DegreeToRadian(int degree);

private:

	static void _ValidateShape(const Shape& shape);
	static bool _IsIncludingDontValidate(const Point& p, const Shape& figure);

};

