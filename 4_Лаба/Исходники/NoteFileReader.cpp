#include "NoteFileReader.h"

#include <vector>
#include <string>
#include <iostream>

std::vector<std::string> NoteFileReader::Read(const char* fileName)
{
	std::fstream _file;

	_file.open(fileName, std::ios_base::in);

	if (!_file.good())
	{
		throw std::runtime_error("Error when opening file");
	}

	std::vector<std::string> lines;

	std::string line;
	while (std::getline(_file, line))
	{
		lines.push_back(std::move(line));
	}

	lines.shrink_to_fit();

	return lines;
}