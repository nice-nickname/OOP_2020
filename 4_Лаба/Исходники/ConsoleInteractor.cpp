#include "ConsoleInteractor.h"

#include <Windows.h>
#include <iostream>
#include <string>
#include <sstream>

using namespace std;

#include "MapNotebook.h"
#include "VectorNotebook.h"

#include "NotebookBuilder.h"

void ConsoleInteractor::Run()
{
	if (!Init())
	{
		return;
	}
	

	PrintCommands();

	int command;
	while (true)
	{
		try
		{
			command = ReadCommand();

			switch (command)
			{
			case 0:
				return;

			case 1:
				ProcessReadFileAndBuild();
				cout << "success\n";
				break;

			case 2:
				// ...
				break;

			case 3:
				ProcessPrintNotebook();
				break;

			default:
				cout << "Invalid command\n";
				break;
			}
		}
		catch (const std::exception& e)
		{
			std::cout << e.what() << "\n";
		}
	}
}

bool ConsoleInteractor::Init()
{
	std::string type;

	cout << "Enter name of base type for notebook. for example: VECTOR, MULTIMAP, ... or type EXIT to\n";

	NotebookBuilder builder;

	while (true)
	{
		try
		{
			cout << ">>> ";
			cin >> type;

			ToUniqueFormat(type);

			if (type.compare("EXIT") == 0)
			{
				return false;
			}

			notebook = builder.BuildFromType(type);
			return true;
		}
		catch (const std::exception & err)
		{
			cout << err.what() << '\n';
			cout << "Try again\n";
		}
	}
}

int ConsoleInteractor::ReadCommand() const
{
	int command;
	cout << "enter command: ";
	
	ReadVar(command);
	
	return command;
}

void ConsoleInteractor::ProcessReadFileAndBuild()
{
	std::string fileName;
	cout << "Enter File Name:  ";
	cin >> fileName;

	NoteFileReader reader;
	NoteBuilder builder;

	auto readedFile = reader.Read(fileName.c_str());
	auto buildedNotes = builder.Build(readedFile);

	for (auto& note : buildedNotes)
	{
		notebook->Add(note);
	}
}

void ConsoleInteractor::ProcessPrintNotebook() const
{
	cout << notebook->ToString() << "\n";
}

void ConsoleInteractor::PrintCommands() const
{
	system("cls");
	cout << "Commands: 0 - exit\n";
	cout << "          1 - read from file and add to container\n";
	cout << "          2 - find by Date of birth\n";
	cout << "          3 - print notebook\n";
}

void ConsoleInteractor::ToUniqueFormat(std::string& destString) const
{
	for (auto& letter : destString)
	{
		letter = toupper(letter);
	}
}

template  void ConsoleInteractor::ReadVar<int>(int& var) const;

template<typename T>
void ConsoleInteractor::ReadVar(T& var) const
{
	string input;
	cin >> input;
	istringstream sin(input);

	char c;

	if (!(sin >> var) || (sin >> c))
	{
		throw std::runtime_error("Input error. Failed to enter a variable");
	}
}