#pragma once

#include <string>

class IStringConvertable
{
public:

	virtual std::string ToString() const = 0;

	virtual ~IStringConvertable() {}

};