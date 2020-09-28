#pragma once

struct Point
{
	float x;
	float y;

	Point() 
		: x(0), y(0)
	{}

	Point(float _x, float _y)
		: x(_x), y(_y)
	{}

	bool operator==(const Point& other);
	Point& operator+=(const Point& offset);
};