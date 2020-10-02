#include "Triangle.h"

#include "Line.h"
#include "GeometryMath.h"

Triangle::Triangle(const Point* points)
	: Shape(points, 3, "Triangle")
{}

double Triangle::FindArea() const
{
	GeometryMath math;
	
	Line* _lines = FindEdges();

	double A = math.FindMagnitude(_lines[0]);
	double B = math.FindMagnitude(_lines[1]);
	double C = math.FindMagnitude(_lines[2]);
	double p = (A + B + C) / 2;

	delete[] _lines;
	return sqrt(p * (p - A) * (p - B) * (p - C));
}

bool Triangle::IsExisting() const
{
	GeometryMath math;

	Line* _lines = FindEdges();

	double A = math.FindMagnitude(_lines[0]);
	double B = math.FindMagnitude(_lines[1]);
	double C = math.FindMagnitude(_lines[2]);

	delete[] _lines;

	if (A + B > C && A + C > B && B + C > A)
	{
		return true;
	}
	return false;
}
