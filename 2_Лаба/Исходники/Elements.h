#pragma once

#include "LogicalElement.h"

// Done

class And : public LogicalElement
{
public:
	And();
	virtual bool Execute(bool left, bool right) const override;
	virtual LogicalElement* Copy() const override;
};

class Or : public LogicalElement
{
public:
	Or();
	virtual bool Execute(bool left, bool right) const override;
	virtual LogicalElement* Copy() const override;
};

class Xor : public LogicalElement
{
public:
	Xor();
	virtual bool Execute(bool left, bool right) const override;
	virtual LogicalElement* Copy() const override;
};