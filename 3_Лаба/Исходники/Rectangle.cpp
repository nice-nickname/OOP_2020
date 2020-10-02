#include "Rectangle.h"

#include "Line.h"
#include "GeometryMath.h"

Rectangle::Rectangle(const Point* points)
	: Shape(points, 4, "Rectangle")
{}

double Rectangle::FindArea() const
{
	GeometryMath math;

	const Point* _vertices = GetVertices();

	double w = math.FindMagnitude({ _vertices[0], _vertices[1] });
	double h = math.FindMagnitude({ _vertices[1], _vertices[2] });

	return h * w;
}

bool Rectangle::IsExisting() const
{
	GeometryMath math;

	const Point* _vertices = GetVertices();
	int vCount = 4;
	int eCount = vCount + 1;
	const Line* _originLines = FindEdges();
	Line* _lines = new Line[eCount];

	// Getting all edges in Rectangle + copy of first
	std::copy(_originLines, _originLines + vCount, _lines);
	_lines[eCount - 1] = _lines[0];

	bool _ans = true;

	// for all angles in Rectangle
	for (int i = 0; i < eCount - 1; i++)
	{
		double _angle = math.FindAngle(_lines[i], _lines[i + 1]);

		if (abs(_angle - math.pi / 2) > DBL_EPSILON) // if angle not equals 90 degrees
		{
			_ans = false;
			break;
		}
	}

	Point p1, p2;

	for (int i = 0; i < vCount - 1; i++)
	{
		p1 = _vertices[i];
		p2 = _vertices[i + 1];
		if (p1 == p2)
		{
			_ans = false;
			break;
		}
	}

	delete[] _originLines;
	delete[] _lines;
	return _ans;
}
