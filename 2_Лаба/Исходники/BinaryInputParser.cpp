#include "BinaryInputParser.h"

#include <stdexcept>
#include <algorithm>

bool BinaryInputParser::ValidateString(const std::string& str)
{
	for (auto& letter : str)
	{
		if (letter < '0' || letter > '1')
		{
			return false;
		}
	}
	return true;
}

BinaryData BinaryInputParser::Parse(const std::string& str, int size)
{
	if (size <= 0)
	{
		throw new std::invalid_argument("Invalid size in Parse method");
	}

	bool* buf = new bool[size];
	std::fill(buf, buf + size, false);

	int index = 0;
	for (auto l = str.begin(); l != str.end() && index < size; l++, index++)
	{
		buf[index] = _ConvertToBool(*l);
	}

	return BinaryData(buf, size);
}

bool BinaryInputParser::_ConvertToBool(char letter)
{
	if (letter == '1')
	{
		return true;
	}
	return false;
}
