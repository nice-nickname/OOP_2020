#pragma once

#include "IStringConvertable.h"

class PersonInitial : public IStringConvertable
{

	using string_arg = const std::string&;

public:

	PersonInitial();
	PersonInitial(string_arg name, string_arg surname, string_arg patronyimc);

	virtual std::string ToString() const override;

	std::string GetName() const;
	std::string GetSurname() const;
	std::string GetPatronymic() const;

private:

	std::string _name;
	std::string _surname;
	std::string _patronyimc;

};

