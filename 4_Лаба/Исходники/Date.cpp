#include "Date.h"

#include <sstream>
#include <stdexcept>

#include <iomanip>

Date::Date(int day, int month, int year)
	: _day(day),
	_month(month),
	_year(year)
{}

std::string Date::ToString() const
{
	std::ostringstream sstr;

	sstr << std::setfill('0') << std::setw(2) <<_day << '.'
		 << std::setfill('0') << std::setw(2) << _month << '.'
		 << std::setw(4) << _year;

	return sstr.str();
}



bool Date::operator==(const Date& other) const
{
	if (_day == other._day
		&& _month == other._month
		&& _year == other._year)
	{
		return true;
	}
	return false;
}

bool Date::operator<(const Date& other) const
{
	int date1 = PresentAsNumber();
	int date2 = other.PresentAsNumber();

	if (date1 < date2)
	{
		return true;
	}
	return false;
}

int Date::GetDay() const
{
	return _day;
}

int Date::GetMonth() const
{
	return _month;
}

int Date::GetYear() const
{
	return _year;
}

int Date::PresentAsNumber() const
{
	return _year * 10000 + _month * 100 + _day;
}

Date::Date()
	: _day(1),
	_month(1),
	_year(2000)
{}
