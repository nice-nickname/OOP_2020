#pragma once

#include "BinaryData.h"

#include <string>

class BinaryInputParser
{
public:
	static bool ValidateString(const std::string& str);
	static BinaryData Parse(const std::string& str, int size);

private:
	static bool _ConvertToBool(char letter);
};

