#pragma once

class BinaryData
{
public:
	BinaryData();
	BinaryData(bool* _buffer, int _size);
	BinaryData(const BinaryData& other);
	~BinaryData();

	BinaryData& operator=(const BinaryData& other);

	bool* GetBuffer() const;
	int GetSize() const;

	bool operator[](int index) const;

private:

	void _CopyData(int _size, bool* _buf);
	void _DeleteData();

	bool* buffer;
	int size;
};

