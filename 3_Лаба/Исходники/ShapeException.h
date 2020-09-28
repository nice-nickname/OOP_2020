#pragma once

#include "Shape.h"

#include <exception>

class ShapeException : public std::exception
{
public:
	ShapeException() = delete;
	ShapeException(const Shape& shape);

	const char* what() const noexcept;

private:
	std::string what_arg;
};

