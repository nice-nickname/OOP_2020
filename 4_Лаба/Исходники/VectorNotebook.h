#pragma once

#include "INotesContainer.h"

class VectorNotebook : public INotesContainer
{
public:

	virtual void Add(const Note& value) override;

	virtual std::vector<Note> Find(std::function<bool(const Note&)> predicate) const override;

	virtual std::vector<Note> FindByKey(const Date& key) const override;

	virtual std::string ToString() const override;

private:

	std::vector<Note> _container;

};

