#include "NoteBuilder.h"

#include <istream>
#include <sstream>
#include <stdexcept>

template<>
inline Date NoteBuilder::ParseFromStream<Date>(std::istream& sin) const
{
	int date[3];
	char dot;

	for (int i = 0; i < 2; i++)
	{
		if (!(sin >> date[i]) || !(sin >> dot))
		{
			throw std::runtime_error("Parsing data from stream error");
		}
	}

	if (!(sin >> date[2]))
	{
		throw std::runtime_error("Parsing data from stream error");
	}

	if (date[0] <= 0 || date[0] > 31
		|| date[1] <= 0 || date[1] > 12
		|| date[2] <= 1900 || date[2] > 3000)
	{
		throw std::invalid_argument("Invalid data from stream");
	}
	return Date(date[0], date[1], date[2]);
}

template<>
inline PhoneNumber NoteBuilder::ParseFromStream<PhoneNumber>(std::istream& sin) const
{
	std::string numbers[3];
	char dash;

	for (int i = 0; i < 3; i++)
	{
		if (!(sin >> numbers[i]))
		{
			throw std::runtime_error("Parsing data from stream error");
		}
	}

	for (int i = 0; i < 3; i++)
	{
		for (auto& letter : numbers[i])
		{
			if (!isdigit(letter))
			{
				throw std::invalid_argument("Invalid data from stream");
			}
		}
	}

	return PhoneNumber(numbers[0], numbers[1], numbers[2]);
}

template<>
inline PersonInitial NoteBuilder::ParseFromStream<PersonInitial>(std::istream& sin) const
{
	std::string names[3];

	for (int i = 0; i < 3; i++)
	{
		if (!(sin >> names[i]))
		{
			throw std::runtime_error("Parsing data from stream error");
		}
	}

	for (int i = 0; i < 3; i++)
	{
		for (auto& letter : names[i])
		{
			if (!isalpha(letter))
			{
				throw std::invalid_argument("Invalid data from stream");
			}
		}
	}

	return PersonInitial(names[0], names[1], names[2]);
}

Note NoteBuilder::Build(const std::string& data) const
{
	std::istringstream sin(data);

	auto date = ParseFromStream<Date>(sin);
	auto number = ParseFromStream<PhoneNumber>(sin);
	auto initial = ParseFromStream<PersonInitial>(sin);

	return Note(number, date, initial);
}

std::vector<Note> NoteBuilder::Build(const std::vector<std::string>& data) const
{
	std::vector<Note> notes;

	for (auto& item : data)
	{
		try
		{
			notes.push_back(Build(item));
		}
		catch (...)
		{

		}
	}

	notes.shrink_to_fit();

	return notes;
}
