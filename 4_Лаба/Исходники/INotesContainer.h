#pragma once

#include "Note.h"
#include "IStringConvertable.h"

#include <vector>
#include <functional>

class INotesContainer : public IStringConvertable
{
public:

	virtual void Add(const Note& value) = 0;

	virtual std::vector<Note> Find(std::function<bool(const Note&)> predicate) const = 0;

	virtual std::vector<Note> FindByKey(const Date& key) const = 0;

	virtual std::string ToString() const = 0;

	virtual ~INotesContainer()
	{}

};

