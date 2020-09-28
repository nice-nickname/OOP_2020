#include "GeometryMath.h"

#include <cmath>
#include <iostream>

#include "ShapeException.h"

float GeometryMath::FindMagnitude(const Line& line)
{
	float Vx = line.end.x - line.begin.x;
	float Vy = line.end.y - line.begin.y;
	return sqrt(Vx * Vx + Vy * Vy);

}

float GeometryMath::CalculateScalar(const Line& v1, const Line& v2)
{
	float v1_x = v1.end.x - v1.begin.x;
	float v1_y = v1.end.y - v1.begin.y;

	float v2_x = v2.end.x - v2.begin.x;
	float v2_y = v2.end.y - v2.begin.y;
	
	return v1_x * v2_x + v1_y * v2_y;
}

// O(n*n) ;(
bool GeometryMath::IsIntersected(const Shape& first, const Shape& second)
{
	_ValidateShape(first);
	_ValidateShape(second);
	if (first.GetCount() == 0 || second.GetCount() == 0)
	{
		return false;
	}

	bool ans = false;

	Point* first_vert = first.GetVerticesCopy();
	Point* second_vert = second.GetVerticesCopy();

	// Filling to arrays with lines
	int lines_c = first.GetCount();
	Line* lines = new Line[lines_c];

	int check_c = second.GetCount();
	Line* check = new Line[check_c];

	for (int i = 0; i < lines_c - 1; i++)
	{
		lines[i] = Line(first_vert[i], first_vert[i + 1]);
	}
	lines[lines_c - 1] = Line(first_vert[lines_c - 1], first_vert[0]);

	for (int i = 0; i < check_c - 1; i++)
	{
		check[i] = Line(second_vert[i], second_vert[i + 1]);
	}
	check[check_c - 1] = Line(second_vert[check_c - 1], second_vert[0]);


	// checking intersection of lines array with check array
	for (int i = 0; i < lines_c && !ans; i++)
	{
		for (int j = 0; j < check_c; j++)
		{
			if (GeometryMath::IsIntersected(lines[i], check[j]))
			{
				ans = true;
				break;
			}
		}
	}

	delete[] check;
	delete[] lines;
	delete[] first_vert;
	delete[] second_vert;
	return ans;
}

bool GeometryMath::IsIntersected(const Line& first, const Line& second)
{
	Point p1 = first.begin;
	Point p2 = first.end;
	Point p3 = second.begin;
	Point p4 = second.end;

	if (p1 == p3 || p2 == p4)
	{
		return true;
	}

	float v1 = (p4.x - p3.x) * (p1.y - p3.y) - (p4.y - p3.y) * (p1.x - p3.x);
	float v2 = (p4.y - p3.y) * (p2.x - p1.x) - (p4.x - p3.x) * (p2.y - p1.y);
	float v3 = (p2.x - p1.x) * (p1.y - p3.y) - (p2.y - p1.y) * (p1.x - p3.x);
	float v4 = (p4.y - p3.y) * (p2.x - p1.x) - (p4.x - p3.x) * (p2.y - p1.y);

	float u1 = v1 / v2, u2 = v3 / v4;

	return u1 >= 0 && u1 <= 1 && u2 >= 0 && u2 <= 1;
}

bool GeometryMath::IsIncluding(const Shape& dest, const Shape& incl)
{
	_ValidateShape(dest);
	_ValidateShape(incl);

	bool ans = true;
	Point* pts = incl.GetVerticesCopy();

	for (int i = 0; i < incl.GetCount(); i++)
	{
		if (_IsIncludingDontValidate(pts[i], dest) == false)
		{
			ans = false;
			break;
		}
	}

	delete[] pts;
	return ans;
}

bool GeometryMath::IsIncluding(const Point& p, const Shape& figure)
{
	_ValidateShape(figure);
	return _IsIncludingDontValidate(p, figure);
}

float GeometryMath::DegreeToRadian(int degree)
{
	return degree * pi / 180;
}

void GeometryMath::_ValidateShape(const Shape& shape)
{
	if (shape.IsExisting() == false)
	{
		throw ShapeException(shape);
	}
}

bool GeometryMath::_IsIncludingDontValidate(const Point& p, const Shape& figure)
{
	bool ans = false;
	int count = figure.GetCount() + 1;
	Line* lines = new Line[count];

	Point* figure_points = figure.GetVerticesCopy();

	for (int i = 0; i < count - 1; i++)
	{
		lines[i] = Line(p, figure_points[i]);
	}
	lines[count - 1] = Line(lines[0]);

	float cos_angle = 0.f;
	float scalar, v1, v2;
	for (int i = 0; i < count - 1; i++)
	{
		scalar = CalculateScalar(lines[i], lines[i + 1]);
		v1 = FindMagnitude(lines[i]);
		v2 = FindMagnitude(lines[i + 1]);
		cos_angle += acos(scalar / (v1 * v2));
	}

	// Sum of angles must be equal 2*pi
	if (abs(cos_angle - 2 * pi) <= epsilon)
	{
		ans = true;
	}

	delete[] lines;
	delete[] figure_points;
	return ans;
}
