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
	int date1 = GetDaysCount();
	int date2 = other.GetDaysCount();

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

int Date::GetDaysCount() const
{
	int res = _day;

	for (int i = 1; i < _month; i++)
	{
		res += GetDaysCountInMonth(_month, _year);
	}

	int leapYearsCount = _year / 4;
	int yearsCount = _year - leapYearsCount;

	res += leapYearsCount * 366 + yearsCount * 365;

	return res;
}

int Date::GetDaysCountInMonth(int month, int year)
{
	if (month == 4 || month == 6 || month == 9 || month == 11)
	{
		return 30;
	}
	else if (month == 2)
	{
		if (GetDaysCountInYear(year) == 365)
		{
			return 28;
		}
		else
		{
			return 29;
		}
	}
	else
	{
		return 31;
	}
}

int Date::GetDaysCountInYear(int year)
{
	if (year % 4 != 0 || year % 100 == 0 && year % 400 != 0)
	{
		return 365;
	}
	
	return 366;
}

Date::Date()
	: _day(1),
	_month(1),
	_year(2000)
{}
