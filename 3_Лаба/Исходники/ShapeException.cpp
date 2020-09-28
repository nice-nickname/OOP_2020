#include "ShapeException.h"

#include <sstream>

ShapeException::ShapeException(const Shape& shape)
{
	std::ostringstream sstr;

	sstr << "Shape " << shape.GetName() << " with " << shape.GetCount() << " vertices doesn't exist";
	
	what_arg = sstr.str();
}

const char* ShapeException::what() const noexcept
{
	return what_arg.c_str();
}
