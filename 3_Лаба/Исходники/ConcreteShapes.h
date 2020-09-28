#pragma once

#include "Shape.h"

class Triangle : public Shape
{
public:

	Triangle() = delete;
	Triangle(const Point& a, const Point& b, const Point& c);

	float FindArea() const override;
	Point FindCenter() const override;
	bool IsExisting() const override;
	
private:

	static bool _IsTriangleExisting(float A, float B, float C);

};

class Rect : public Shape
{
public:

	Rect() = delete;
	Rect(const Point& point, float _height, float _width);

	float FindArea() const override;
	Point FindCenter() const override;
	bool IsExisting() const override;

	float GetHeight() const;
	float GetWidth() const;

	void SetHeight(float value);
	void SetWidth(float value);

private: 
	
	float height;
	float width;

	static bool _IsRectExisting(float width, float height);
};