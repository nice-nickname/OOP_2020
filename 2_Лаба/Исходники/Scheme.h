#pragma once

#include "Elements.h"
#include "BinaryData.h"

class Scheme
{
	friend class SchemeFileBuilder;

public:
	Scheme();
	Scheme(const Scheme& other);
	~Scheme();

	Scheme& operator=(const Scheme& other);

	BinaryData Execute(const BinaryData& data) const;

	int CountOfElements() const;

private:

	void _DeleteElements();
	void _CopyElements(int _size, LogicalElement** _elements);

	LogicalElement** elements;
	int size;
};

