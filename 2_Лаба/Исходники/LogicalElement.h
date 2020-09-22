#pragma once

#include <string>

// Done

class LogicalElement
{
public:
	LogicalElement() = delete;
	LogicalElement(const std::string& _name);

	virtual bool Execute(bool left, bool right) const = 0;
	virtual LogicalElement* Copy() const = 0;

	std::string GetName() const;

protected:

	std::string name;

};

