#pragma once

#include <exception>

#include "Shape.h"

class ShapeException : public std::exception
{
public:
	
	ShapeException(const Shape& figure);

	const char* what() const noexcept;

private:

	std::string _aboutString;

};

