#pragma once

#include "Note.h"

#include <vector>

class NoteBuilder
{
public:

	Note Build(const std::string& data) const;

	std::vector<Note> Build(const std::vector<std::string>& data) const;

	template<typename T>
	T ParseFromStream(std::istream& sin) const;

private:

};

