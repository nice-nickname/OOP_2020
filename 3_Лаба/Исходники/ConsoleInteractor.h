#pragma once

#include "ConcreteShapes.h"

class ConsoleInteractor
{
public:
	void Start() const;

private:
	void _PrintCommands() const;
	void _ReadFloat(float& x) const;
};
