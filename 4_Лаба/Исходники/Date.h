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
	

private:

	int PresentAsNumber() const;

	int _day;
	int _month;
	int _year;


};

