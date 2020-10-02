#include "GeometryMath.h"

#include "ShapeException.h"

#include <cmath>
#include <algorithm>

GeometryMath::GeometryMath()
	: pi(2 * acos(0)),
	epsilon(DBL_EPSILON)
{}

double GeometryMath::DegreesToRadian(int degrees) const
{
	return (degrees % 360) * pi / 180;
}

double GeometryMath::FindMagnitude(const Line& line) const
{
	double _x = line.end.x - line.begin.x;
	double _y = line.end.y - line.begin.y;
	return sqrt(_x * _x + _y * _y);
}

double GeometryMath::FindAngle(const Line& first, const Line& second) const
{
	Point _v1(first.end.x - first.begin.x, first.end.y - first.begin.y);
	Point _v2(second.end.x - second.begin.x, second.end.y - second.begin.y);

	double _scalar = _v1.x * _v2.x + _v1.y * _v2.y;

	double _v1Magnitude = FindMagnitude(first);
	double _v2Magnitude = FindMagnitude(second);

	return acos(_scalar / (_v1Magnitude * _v2Magnitude));
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

	Line* _firstEdgs = fFirst.FindEdges();
	Line* _secondEdgs = fSecond.FindEdges();

	int _firstCnt = fFirst.GetVerticesCount();
	int _secondCnt = fSecond.GetVerticesCount();

	bool ans = false;

	Line l1, l2;

	for (int i = 0; i < _firstCnt && !ans; i++)
	{
		l1 = _firstEdgs[i];
		for (int j = 0; j < _secondCnt; j++)
		{
			l2 = _secondEdgs[j];
			if (IsIntersected(l1, l2))
			{
				ans = true;
				break;
			}
		}
	}


	delete[] _firstEdgs;
	delete[] _secondEdgs;
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

	bool ans = true;
	const Point* _vertices = incl.GetVertices();

	for (int i = 0; i < incl.GetVerticesCount() && !ans; i++)
	{
		if (_IsIncludedDontValidate(_vertices[i], dest) == false)
		{
			ans = false;
			break;
		}
	}

	return ans;
}

bool GeometryMath::_IsIncludedDontValidate(Point p, const Shape& figure)
{
	const Point* _vertices = figure.GetVertices();

	for (int i = 0; i < figure.GetVerticesCount(); i++)
	{
		Point figureP = _vertices[i];
		if (figureP == p)
		{
			return true;
		}
	}

	int _checkingCount = figure.GetVerticesCount() + 1;
	Line* _checkingLines = new Line[_checkingCount];

	for (int i = 0; i < _checkingCount - 1; i++)
	{
		_checkingLines[i] = Line(p, _vertices[i]);
	}
	_checkingLines[_checkingCount - 1] = _checkingLines[0];

	double angle = 0;
	for (int i = 0; i < _checkingCount - 1; i++)
	{
		angle += FindAngle(_checkingLines[i], _checkingLines[i + 1]);
	}

	bool ans = false;

	if (abs(angle - 2 * pi) <= epsilon)
	{
		ans = true;
	}

	delete[] _checkingLines;
	return ans;
}

void GeometryMath::_ValidateShape(const Shape& shape) const
{
	if (!shape.IsExisting() || shape.GetVerticesCount() == 0)
	{
		throw ShapeException(shape);
	}
}
