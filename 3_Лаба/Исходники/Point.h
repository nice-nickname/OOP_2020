#pragma once
struct Point
{
	double x;
	double y;

	Point();

	Point(double _x, double _y);

	bool operator==(Point other);
	Point& operator+=(Point other);
};

