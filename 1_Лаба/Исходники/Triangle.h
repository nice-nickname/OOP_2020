#pragma once

#include "Point.h"

class Triangle
{
public:
	Triangle() = delete;
	Triangle(const Point& p1, const Point& p2, const Point& p3);
	Triangle(float x1, float y1, float x2, float y2, float x3, float y3);

	Point FindCenter() const;
	float FindArea() const;
	float FindPerimeter() const;

	void Move(const Point& offset);

	Point GetFirstPoint() const;
	Point GetSecondPoint() const;
	Point GetThirdPoint() const;

	void SetFirstPoint(const Point& other);
	void SetSecondPoint(const Point& other);
	void SetThirdPoint(const Point& other);

	bool IsAreasEqual(const Triangle& other) const;

	bool IsExisting() const;

	friend bool operator>(const Triangle& left, const Triangle& right);
	friend bool operator<(const Triangle& left, const Triangle& right);
	friend bool operator>=(const Triangle& left, const Triangle& right);
	friend bool operator<=(const Triangle& left, const Triangle& right);

private:
	Point points[3];

	bool _IsExistingOptimized(float a, float b, float c) const;
	void _CalculateMagnitudes(float& a, float& b, float& c) const;
	int _CompareArea(const Triangle& other) const;
};