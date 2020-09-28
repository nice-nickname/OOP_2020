#pragma once

#include "Point.h"

#include <string>

class Shape
{
public:

	Shape();
	Shape(Point* points, int length, const std::string& _name);
	Shape(const Shape& other);

	Shape& operator=(const Shape& other);
	Point& operator[](int index);

	virtual ~Shape();

	virtual float FindArea() const = 0;
	virtual Point FindCenter() const = 0;
	virtual bool IsExisting() const = 0;

	void Rotate(int degrees);

	void Move(const Point& offset);

	Point* GetVerticesCopy() const;
	std::string GetName() const;
	int GetCount() const;

private:

	std::string name;
	void _CopyArray(Point* points, int length);

protected:

	Point* vertices;
	int count;

	void _ConstructShape(Point* points, int length, const std::string& _name);

};

