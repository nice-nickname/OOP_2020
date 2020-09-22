#include <iostream>
#include <vld.h>

#include "ConsoleInteractor.h"

// TODO: SchemeFileBuilder::Build когда вместо ошибочного типа будет nullptr нужно будет выкинуть исключение наверное??

int main()
{
	std::cout << "\n";

	ConsoleInteractor i;
	i.Start();

	std::cout << "\n";

	return 0;
}