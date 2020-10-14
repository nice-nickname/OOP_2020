#include "Note.h"

#include <sstream>
#include <iomanip>

std::string Note::ToString() const
{
	std::ostringstream sstr;

	sstr << "| ";
	sstr << std::setw(35) << std::left << _initial.ToString() << " | "
		 << std::setw(12) << std::right <<_birthDate.ToString() << " | "
		 << std::setw(20) << std::right <<_number.ToString() << " | ";

	return sstr.str();
}

Date Note::GetBirthDate() const
{
	return _birthDate;
}

PhoneNumber Note::GetPhoneNumber() const
{
	return _number;
}

PersonInitial Note::GetInitial() const
{
	return _initial;
}

Note::Note()
	: _number(),
	_birthDate(),
	_initial()
{}

Note::Note(const PhoneNumber& number, const Date& date, const PersonInitial& initial)
	: _number(number),
	_birthDate(date),
	_initial(initial)
{}
