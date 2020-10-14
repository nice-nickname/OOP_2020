#include "PhoneNumber.h"

#include <sstream>

PhoneNumber::PhoneNumber()
	: _counryCode("8"),
	_abonentCode("900"),
	_number("0000000")
{}

PhoneNumber::PhoneNumber(string_arg counryCode, string_arg abonentCode, string_arg number)
	: _counryCode(counryCode),
	_abonentCode(abonentCode),
	_number(number)
{}

std::string PhoneNumber::ToString() const
{
	std::ostringstream sstr;

	sstr << '+' << _counryCode << '-' << _abonentCode << '-' << _number;

	return sstr.str();
}

std::string PhoneNumber::GetCountyCode() const
{
	return _counryCode;
}

std::string PhoneNumber::GetAbonentCode() const
{
	return _abonentCode;
}

std::string PhoneNumber::GetNumber() const
{
	return _number;
}
