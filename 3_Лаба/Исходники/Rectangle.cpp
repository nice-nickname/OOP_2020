#include "Rectangle.h"

#include "Line.h"
#include "GeometryMath.h"

Rectangle::Rectangle(const Point* points)
	: Shape(points, 4, "Rectangle")
{}

double Rectangle::FindArea() const
{
	GeometryMath math;

	const Point* vertices = GetVertices();

	double w = math.FindMagnitude({ vertices[0], vertices[1] });
	double h = math.FindMagnitude({ vertices[1], vertices[2] });

	return h * w;
}

bool Rectangle::IsExisting() const
{
	GeometryMath math;

	const Point* vertices = GetVertices();
	int vCount = 4;
	int eCount = vCount + 1;
	const Line* originLines = FindEdges();
	Line* lines = new Line[eCount];

	// Getting all edges in Rectangle + copy of first
	std::copy(originLines, originLines + vCount, lines);
	lines[eCount - 1] = lines[0];

	bool answ = true;

	// for all angles in Rectangle
	for (int i = 0; i < eCount - 1; i++)
	{
		double _angle = math.FindAngle(lines[i], lines[i + 1]);

		if (abs(_angle - math.pi / 2) > math.epsilon) // if angle not equals 90 degrees
		{
			answ = false;
			break;
		}
	}

	Point p1, p2;

	for (int i = 0; i < vCount - 1; i++)
	{
		p1 = vertices[i];
		p2 = vertices[i + 1];
		if (p1 == p2)
		{
			answ = false;
			break;
		}
	}

	delete[] originLines;
	delete[] lines;
	return answ;
}
