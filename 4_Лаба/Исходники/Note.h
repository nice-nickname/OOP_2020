#pragma once

#include "Date.h"
#include "PhoneNumber.h"
#include "PersonInitial.h"

class Note : public IStringConvertable
{
public:

	Note();
	Note(const PhoneNumber& number, const Date& date, const PersonInitial& initial);

	virtual std::string ToString() const override;

	Date GetBirthDate() const;
	PhoneNumber GetPhoneNumber() const;
	PersonInitial GetInitial() const;

private:

	PhoneNumber _number;
	Date _birthDate;
	PersonInitial _initial;

};

