#pragma once

#include "Shape.h"

class ConsoleInteractor
{
public:
	ConsoleInteractor();
	~ConsoleInteractor();

	void Run();

private:

	bool _Init();
	void _PrintCommands() const;
	
	template<class T>
	void _ReadVar(T& var) const;

	bool _ReadIndex(int& _index);

	int totalCount;
	int figuresCount;
	Shape** figures;

};

