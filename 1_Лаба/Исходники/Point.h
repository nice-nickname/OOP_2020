#pragma once

struct Point
{
	float x;
	float y;

	Point(float _x, float _y) : x(_x), y(_y)
	{}

	void Add(const Point& other);

	friend Point operator+(const Point& left, const Point& right);
	friend Point operator-(const Point& left, const Point& right);

	static float FindMagnitude(const Point& from, const Point& to);
};
