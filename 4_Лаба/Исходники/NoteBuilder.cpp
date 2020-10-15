#include "NoteBuilder.h"

#include <istream>
#include <sstream>
#include <stdexcept>

template<>
inline Date NoteBuilder::ParseFromStream<Date>(std::istream& sin) const
{
	int date[3]; // day, month, year
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

	if (date[1] <= 0 || date[1] > 12
		|| date[2] <= 1900 || date[2] > 3000)
	{
		throw std::invalid_argument("Invalid data from stream");
	}

	int lowerBound = 1, upperBound;
	int month = date[1];

	if (month == 4 || month == 6 || month == 9 || month == 11)
	{
		upperBound = 30;
	}
	else if (month == 2)
	{
		int year = date[2];

		if (year % 4 != 0 || year % 100 == 0 && year % 400 != 0)
		{
			upperBound = 28;
		}
		else
		{
			upperBound = 29;
		}
	}
	else
	{
		upperBound = 31;
	}

	if (date[0] < lowerBound || date[0] > upperBound)
	{
		throw std::invalid_argument("Invalid data from stream");
	}

	return Date(date[0], date[1], date[2]);
}

template<>
inline PhoneNumber NoteBuilder::ParseFromStream<PhoneNumber>(std::istream& sin) const
{
	std::string numbers[3];

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


	for (int i = 0; i < 3; i++)
	{
		for (auto& letter : names[i])
		{
			letter = tolower(letter);
		}
		names[i][0] = toupper(names[i][0]);
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
