#pragma once

#include "Triangle.h"

class ConsoleInteractor
{
public:
	void Run();

private:
	void _UpdateConsole(const Triangle& t1, const Triangle& t2);
	Point _ReadPointFromConsole();

};

