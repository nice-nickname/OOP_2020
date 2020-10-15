#pragma once

#include <fstream>
#include <vector>

#include "Note.h"

class NoteFileReader
{
public:

	std::vector<std::string> Read(const char* fileName);

};

