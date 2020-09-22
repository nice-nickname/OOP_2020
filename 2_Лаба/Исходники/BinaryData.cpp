#include "BinaryData.h"

#include <algorithm>

BinaryData::BinaryData() : buffer(nullptr), size(0)
{}

BinaryData::BinaryData(bool* _buffer, int _size)
	: buffer(_buffer), size(_size)
{}

BinaryData::BinaryData(const BinaryData& other)
{
	_DeleteData();
	_CopyData(other.size, other.buffer);
}

BinaryData::~BinaryData()
{
	_DeleteData();
}

BinaryData& BinaryData::operator=(const BinaryData& other)
{
	if (this == &other)
	{
		return *this;
	}

	_DeleteData();
	_CopyData(other.size, other.buffer);
	return *this;
}

bool* BinaryData::GetBuffer() const
{
	return buffer;
}

int BinaryData::GetSize() const
{
	return size;
}

bool BinaryData::operator[](int index) const
{
	if (index >= 0 && index < size)
	{
		return buffer[index];
	}
	return false;
}

void BinaryData::_CopyData(int _size, bool* _buf)
{
	std::copy(_buf, _buf + _size, buffer);
	size = _size;
}

void BinaryData::_DeleteData()
{
	if (buffer == nullptr)
	{
		return;
	}

	delete[] buffer;
	size = 0;
	buffer = nullptr;
}
