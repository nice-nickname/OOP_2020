#include "ConsoleInteractor.h"
#include "BinaryInputParser.h"

#include <iostream>

using namespace std;

void ConsoleInteractor::Start() const
{
	try
	{
		cout << "Enter a file name with scheme to build [default = \"scheme.txt\"]\n";
		std::string str;
		cout << ">>> ";
		cin >> str;

		SchemeFileBuilder builder(str.c_str(), _GetDefaultPapptern());

		Scheme scheme = builder.Build();

		system("cls");

		cout << "\nSuccess!\n\n";

		int size_d = scheme.CountOfElements() * 2;

		cout << "Now it's turn to enter a input signal for scheme\n";
		cout << "Signal have to be in format: " << size_d << " numbers or less. Unwanted symbols will be ignored.\n";
		cout << "Signal contains only symbols '1' and '0'\n\n";

		cout << ">>> ";
		cin >> str;

		if (BinaryInputParser::ValidateString(str))
		{
			BinaryData input = BinaryInputParser::Parse(str, size_d);
			BinaryData output = scheme.Execute(input);

			cout << "\bDestination: \n\t";
			for (int i = 0; i < input.GetSize(); i++)
			{
				cout << input[i] << " ";
			}
			cout << "\n\n";
			
			cout << "\nResult: \n\t";
			for (int i = 0; i < output.GetSize(); i++)
			{
				cout << output[i] << " ";
			}
			cout << "\n";
		}
		else
		{
			cout << "Input error\n";
		}
	}
	catch (const std::exception & e)
	{
		cerr << e.what() << "\n";
	}
}

ElementPattern ConsoleInteractor::_GetDefaultPapptern() const
{
	int size = 3;
	LogicalElement** el = new LogicalElement * [size];

	el[0] = new And();
	el[1] = new Or();
	el[2] = new Xor();

	return ElementPattern(size, el);
}
