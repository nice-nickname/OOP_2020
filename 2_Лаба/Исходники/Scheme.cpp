#include "Scheme.h"

#include <algorithm>

Scheme::Scheme() : elements(nullptr), size(0)
{}

Scheme::Scheme(const Scheme& other)
	: Scheme()
{
	_DeleteElements();
	_CopyElements(other.size, other.elements);
}

Scheme::~Scheme()
{
	_DeleteElements();
}

Scheme& Scheme::operator=(const Scheme& other)
{
	if (this == &other)
	{
		return *this;
	}

	_DeleteElements();
	_CopyElements(other.size, other.elements);
	return *this;
}

BinaryData Scheme::Execute(const BinaryData& data) const
{
	// Длина массива даты должна быть вдвое больше длины массива элементов, а длина результата равна ему.
	int res_size = size;
	bool* res_data = new bool[res_size];
	std::fill(res_data, res_data + res_size, false);

	for (int i = 0; i < res_size; i++)
	{
		bool r = data[i * 2], l = data[i * 2 + 1];
		res_data[i] = elements[i]->Execute(l, r);
	}

	return BinaryData(res_data, res_size);
}

int Scheme::CountOfElements() const
{
	return size;
}


void Scheme::_DeleteElements()
{
	if (elements == nullptr)
	{
		return;
	}

	for (int i = 0; i < size; i++)
	{
		delete elements[i];
	}
	delete[] elements;
	elements = nullptr;
	size = 0;
}

void Scheme::_CopyElements(int _size, LogicalElement** _elements)
{
	if (elements != nullptr)
	{
		return;
	}

	size = _size;

	elements = new LogicalElement * [size];
	for (int i = 0; i < size; i++)
	{
		elements[i] = _elements[i]->Copy();
	}

}
