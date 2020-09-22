#pragma once

#include "LogicalElement.h"

class ElementPattern
{
public:
	ElementPattern();
	ElementPattern(int _size, LogicalElement** pattern);
	ElementPattern(const ElementPattern& other);
	~ElementPattern();

	ElementPattern& operator=(const ElementPattern& other);

	LogicalElement* FindByName(const std::string& name) const;

private:

	void _DeleteElements();
	void _CopyElements(int _size, LogicalElement** _elements);

	int size;
	LogicalElement** table;
};

