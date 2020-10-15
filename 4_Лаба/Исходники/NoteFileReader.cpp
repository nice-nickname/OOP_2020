#include "NoteFileReader.h"

#include <vector>
#include <string>
#include <iostream>

std::vector<std::string> NoteFileReader::Read(const char* fileName)
{
	std::fstream file;

	file.open(fileName, std::ios_base::in);

	if (!file.good())
	{
		throw std::runtime_error("Error when opening file");
	}

	std::vector<std::string> lines;

	std::string line;
	while (std::getline(file, line))
	{
		lines.push_back(std::move(line));
	}

	lines.shrink_to_fit();

	return lines;
}