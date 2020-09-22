#include "ElementPattern.h"

ElementPattern::ElementPattern() : table(nullptr), size(0)
{}

ElementPattern::ElementPattern(int _size, LogicalElement** pattern)
	: size(_size), table(pattern)
{}

ElementPattern::ElementPattern(const ElementPattern& other)
{
	_DeleteElements();
	_CopyElements(other.size, other.table);
}

ElementPattern::~ElementPattern()
{
	_DeleteElements();
}

ElementPattern& ElementPattern::operator=(const ElementPattern& other)
{
	if (this == &other)
	{
		return *this;
	}

	_DeleteElements();
	_CopyElements(other.size, other.table);
	return *this;
}

LogicalElement* ElementPattern::FindByName(const std::string& name) const
{
	for (int i = 0; i < size; i++)
	{
		std::string type = table[i]->GetName();
		if (name.compare(type) == 0)
		{
			return table[i]->Copy();
		}
	}
	return nullptr;
}

void ElementPattern::_DeleteElements()
{
	if (table == nullptr)
	{
		return;
	}

	for (int i = 0; i < size; i++)
	{
		delete table[i];
	}
	delete[] table;
	table = nullptr;
	size = 0;
}

void ElementPattern::_CopyElements(int _size, LogicalElement** _elements)
{
	if (table != nullptr)
	{
		return;
	}

	size = _size;

	table = new LogicalElement * [size];
	for (int i = 0; i < size; i++)
	{
		table[i] = _elements[i]->Copy();
	}

}
