#pragma once

#include "IStringConvertable.h"

class Date : public IStringConvertable
{
public:

	Date();
	Date(int day, int month, int year);

	virtual std::string ToString() const override;

	bool operator==(const Date& other) const;
	bool operator<(const Date& other) const;

	int GetDay() const;
	int GetMonth() const;
	int GetYear() const;
	
	int GetDaysCount() const;

	static int GetDaysCountInMonth(int month, int year);
	static int GetDaysCountInYear(int year);

private:

	int _day;
	int _month;
	int _year;

};

