#pragma once

#include "ConcreteShapes.h"

class ConsoleInteractor
{
public:
	ConsoleInteractor();
	~ConsoleInteractor();
	void Start();

private:
	void _PrintCommands() const;
	void _ReadFloat(float& x) const;

	Shape* figures[10];
	int index;
	int count;
};
