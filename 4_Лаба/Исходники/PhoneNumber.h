#pragma once

#include "IStringConvertable.h"

class PhoneNumber : public IStringConvertable
{

	using string_arg = const std::string&;

public:

	PhoneNumber();
	PhoneNumber(string_arg counryCode, string_arg abonentCode, string_arg number);

	virtual std::string ToString() const override;

	std::string GetCountyCode() const;
	std::string GetAbonentCode() const;
	std::string GetNumber() const;

private:

	std::string _counryCode;
	std::string _abonentCode;
	std::string _number;

};

