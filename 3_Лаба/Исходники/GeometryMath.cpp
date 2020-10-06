#include "GeometryMath.h"

#include "ShapeException.h"

#include <cmath>
#include <algorithm>

GeometryMath::GeometryMath()
	: pi(2*acos(0)),
	epsilon(1e-9)
{}

double GeometryMath::DegreesToRadian(int degrees) const
{
	return (degrees % 360) * pi / 180;
}

double GeometryMath::FindMagnitude(const Line& line) const
{
	double x = line.end.x - line.begin.x;
	double y = line.end.y - line.begin.y;
	return sqrt(x * x + y * y);
}

double GeometryMath::FindAngle(const Line& first, const Line& second) const
{
	Point vector1(first.end.x - first.begin.x, first.end.y - first.begin.y);
	Point vector2(second.end.x - second.begin.x, second.end.y - second.begin.y);

	double scalar = vector1.x * vector2.x + vector1.y * vector2.y;

	double v1Magnitude = FindMagnitude(first);
	double v2Magnitude = FindMagnitude(second);

	return acos(scalar / (v1Magnitude * v2Magnitude));
}

bool GeometryMath::IsIntersected(const Line& lFirst, const Line& lSecond) const
{
	Point p1 = lFirst.begin;
	Point p2 = lFirst.end;
	Point p3 = lSecond.begin;
	Point p4 = lSecond.end;

	if (p1 == p3 || p2 == p4)
	{
		return true;
	}

	double v1 = (p4.x - p3.x) * (p1.y - p3.y) - (p4.y - p3.y) * (p1.x - p3.x);
	double v2 = (p4.y - p3.y) * (p2.x - p1.x) - (p4.x - p3.x) * (p2.y - p1.y);
	double v3 = (p2.x - p1.x) * (p1.y - p3.y) - (p2.y - p1.y) * (p1.x - p3.x);
	double v4 = (p4.y - p3.y) * (p2.x - p1.x) - (p4.x - p3.x) * (p2.y - p1.y);

	double u1 = v1 / v2, u2 = v3 / v4;

	return u1 >= 0 && u1 <= 1 && u2 >= 0 && u2 <= 1;
}

bool GeometryMath::IsIntersected(const Shape& fFirst, const Shape& fSecond) const
{
	_ValidateShape(fFirst);
	_ValidateShape(fSecond);

	Line* firsrEdges = fFirst.FindEdges();
	Line* secondEdges = fSecond.FindEdges();

	int firstEdgesCount = fFirst.GetVerticesCount();
	int secondEdgesCount = fSecond.GetVerticesCount();

	bool ans = false;

	Line l1, l2;

	for (int i = 0; i < firstEdgesCount && !ans; i++)
	{
		l1 = firsrEdges[i];
		for (int j = 0; j < secondEdgesCount; j++)
		{
			l2 = secondEdges[j];
			if (IsIntersected(l1, l2))
			{
				ans = true;
				break;
			}
		}
	}


	delete[] firsrEdges;
	delete[] secondEdges;
	return ans;
}

bool GeometryMath::IsIncluded(Point p, const Shape& figure)
{
	_ValidateShape(figure);

	return _IsIncludedDontValidate(p, figure);
}

bool GeometryMath::IsIncluded(const Shape& dest, const Shape& incl)
{
	_ValidateShape(dest);
	_ValidateShape(incl);

	const Point* vertices = incl.GetVertices();
	
	for (int i = 0; i < incl.GetVerticesCount(); i++)
	{
		if (_IsIncludedDontValidate(vertices[i], dest) == false)
		{
			return false;
		}
	}

	return true;
}

bool GeometryMath::_IsIncludedDontValidate(Point p, const Shape& figure)
{
	const Point* vertices = figure.GetVertices();

	for (int i = 0; i < figure.GetVerticesCount(); i++)
	{
		Point figureP = vertices[i];
		if (figureP == p)
		{
			return true;
		}
	}

	int checkLinesCount = figure.GetVerticesCount() + 1;
	Line* checkLines = new Line[checkLinesCount];

	for (int i = 0; i < checkLinesCount - 1; i++)
	{
		checkLines[i] = Line(p, vertices[i]);
	}
	checkLines[checkLinesCount - 1] = checkLines[0];

	double angle = 0;
	for (int i = 0; i < checkLinesCount - 1; i++)
	{
		angle += FindAngle(checkLines[i], checkLines[i + 1]);;
	}

	bool ans = false;

	if (abs(angle - 2 * pi) <= epsilon)
	{
		ans = true;
	}
	delete[] checkLines;
	return ans;
}

void GeometryMath::_ValidateShape(const Shape& shape) const
{
	if (!shape.IsExisting() || shape.GetVerticesCount() == 0)
	{
		throw ShapeException(shape);
	}
}
