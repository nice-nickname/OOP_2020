#pragma once

#include <exception>

#include "Triangle.h"


class TriangleExistingException : public std::exception
{
public:
	TriangleExistingException(const Triangle _triangle);

	const char* what() const noexcept;

private:

	std::string what_string;

	Triangle triangle;

};

