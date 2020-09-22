#include <stdexcept>
#include <sstream>

#include "SchemeFileBuilder.h"

SchemeFileBuilder::SchemeFileBuilder(const char* filename, ElementPattern _pattern)
	: file(filename, std::ios::in), pattern(_pattern)
{
	if (file.fail() || file.bad())
	{
		throw std::invalid_argument("File with entered name doesn't exist");
	}
}

SchemeFileBuilder::~SchemeFileBuilder()
{
	file.close();
}

Scheme SchemeFileBuilder::Build()
{
	Scheme result;

	int size;
	LogicalElement** elements = nullptr;

	file >> size;

	_ValidateSize(size);
	elements = _ReadSchemeFromFile(size);

	if (!_IsArrayOkay(size, elements))
	{
		throw new std::runtime_error("builded scheme is not okay, check file");
	}

	result.elements = elements;
	result.size = size;

	file.seekg(0); // Восстановить указатель в файле

	return result;
}

bool SchemeFileBuilder::IsOkay()
{
	return file.good();
}

void SchemeFileBuilder::_ValidateSize(int size) const
{
	if (size <= 0 && size % 2 == 1)
	{
		std::stringstream err;

		err << "Invalid argument [" << size << "] in input file";

		throw new std::invalid_argument(err.str());
	}
}

LogicalElement** SchemeFileBuilder::_ReadSchemeFromFile(int size)
{
	LogicalElement** elements = new LogicalElement * [size];

	std::string type;

	for (int i = 0; i < size; i++)
	{
		file >> type;
		_ToUniqueFormat(type);
		elements[i] = pattern.FindByName(type);
	}

	return elements;
}

void SchemeFileBuilder::_ToUniqueFormat(std::string& str) const
{
	for (auto& i : str)
	{
		i = toupper(i);
	}
}

bool SchemeFileBuilder::_IsArrayOkay(int size, LogicalElement** _array) const
{
	for (int i = 0; i < size; i++)
	{
		if (_array[i] == nullptr)
		{
			return false;
		}
	}
	return true;
}
