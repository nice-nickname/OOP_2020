#include "ShapeException.h"

#include <sstream>

ShapeException::ShapeException(const Shape& figure)
{
	std::ostringstream sstr;

	sstr << "Shape [" << figure.GetName() << "] with " << figure.GetVerticesCount() << " can't be used";

	_aboutString = sstr.str();
}

const char* ShapeException::what() const noexcept
{
	return _aboutString.c_str();
}
