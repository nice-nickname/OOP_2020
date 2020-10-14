#include "PersonInitial.h"

#include <sstream>

PersonInitial::PersonInitial()
	: _name("Ivan"),
	_surname("Ivanov"),
	_patronyimc("Ivanovich")
{}

PersonInitial::PersonInitial(string_arg name, string_arg surname, string_arg patronyimc)
	: _name(name),
	_surname(surname),
	_patronyimc(patronyimc)
{}

std::string PersonInitial::ToString() const
{
	std::ostringstream sstr;

	sstr << _surname << ' ' << _name << ' ' << _patronyimc;

	return sstr.str();
}

std::string PersonInitial::GetName() const
{
	return _name;
}

std::string PersonInitial::GetSurname() const
{
	return _surname;
}

std::string PersonInitial::GetPatronymic() const
{
	return _patronyimc;
}
