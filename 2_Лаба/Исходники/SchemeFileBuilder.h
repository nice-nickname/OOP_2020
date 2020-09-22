#pragma once

#include <fstream>

#include "Scheme.h"
#include "ElementPattern.h"

class SchemeFileBuilder
{
public:
	SchemeFileBuilder() = delete;
	SchemeFileBuilder(const char* filename, ElementPattern _pattern);
	~SchemeFileBuilder();

	Scheme Build();

	bool IsOkay();

private:

	std::fstream file;
	ElementPattern pattern;

	void _ValidateSize(int size) const;
	LogicalElement** _ReadSchemeFromFile(int size);
	void _ToUniqueFormat(std::string& str) const;
	bool _IsArrayOkay(int size, LogicalElement** _array) const;
};