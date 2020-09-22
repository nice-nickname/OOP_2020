#include "LogicalElement.h"

LogicalElement::LogicalElement(const std::string& _name) : name(_name)
{}

std::string LogicalElement::GetName() const
{
	return name;
}
