#include "MapNotebook.h"

#include <sstream>

void MapNotebook::Add(const Note& value)
{
	_container.insert(std::make_pair(value.GetBirthDate(), value));
}

std::vector<Note> MapNotebook::Find(std::function<bool(const Note&)> predicate) const
{
	std::vector<Note> finded;

	for (auto& note : _container)
	{
		if (predicate(note.second))
		{
			finded.push_back(note.second);
		}
	}

	finded.shrink_to_fit();

	return finded;
}

std::vector<Note> MapNotebook::FindByKey(const Date& key) const
{
	auto range = _container.equal_range(key);

	std::vector<Note> finded;

	for (auto i = range.first; i != range.second; ++i)
	{
		finded.push_back(i->second);
	}

	finded.shrink_to_fit();

	return finded;
}

std::string MapNotebook::ToString() const
{
	std::ostringstream sstr;

	for (auto& item : _container)
	{
		sstr << item.second.ToString() << "\n";
	}

	return sstr.str();
}
