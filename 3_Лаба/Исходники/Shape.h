#pragma once

#include "Point.h"
#include "Line.h"

#include <string>

class Shape
{
public:

	Shape();
	Shape(const Shape& other);
	Shape(const Point* points, int length, std::string _name);

	virtual ~Shape();

	Shape& operator=(const Shape& other);

	virtual double FindArea() const = 0;
	virtual bool IsExisting() const = 0;

	virtual Point FindCenter() const;

	void Move(double xOffset, double yOffset);
	void Rotate(int degrees);

	std::string GetName() const;
	int GetVerticesCount() const;
	const Point* GetVertices() const;
	Line* FindEdges() const;


private:

	std::string name;

	int verticesCount;
	Point* vertices;

protected:

	void _CheckExisting();

};