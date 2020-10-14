#include "VectorNotebook.h"

#include <algorithm>
#include <sstream>

void VectorNotebook::Add(const Note& value)
{
	_container.push_back(value);
}

std::vector<Note> VectorNotebook::Find(std::function<bool(const Note&)> predicate) const
{
	std::vector<Note> finded;

	for (auto& note : _container)
	{
		if (predicate(note))
		{
			finded.push_back(note);
		}
	}

	finded.shrink_to_fit();

	return finded;
}

std::vector<Note> VectorNotebook::FindByKey(const Date& key) const
{
	auto predicate = [key](const Note& note) -> bool
	{
		if (note.GetBirthDate() == key)
		{
			return true;
		}
		return false;
	};

	return Find(predicate);
}

std::string VectorNotebook::ToString() const
{
	std::ostringstream sstr;

	for (auto& item : _container)
	{
		sstr << item.ToString() << "\n";
	}

	return sstr.str();
}
