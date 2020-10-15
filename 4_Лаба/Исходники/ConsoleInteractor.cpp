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
				TaskReadFileAndBuild();
				cout << "success\n";
				break;

			case 2:
				TaskSwitchPredicateAndRun();
				break;

			case 3:
				TaskPrintNotebook();
				break;

			case 4:
				PrintCommands();
				break;

			default:
				cout << "Invalid command\n";
				break;
			}
		}
		catch (const std::exception & e)
		{
			std::cout << e.what() << "\n";
		}
	}
}

bool ConsoleInteractor::Init()
{
	std::string type;

	cout << "Enter name of base type for notebook. for example: VECTOR, MAP, ... or type EXIT to\n";

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

void ConsoleInteractor::TaskReadFileAndBuild()
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

void ConsoleInteractor::TaskPrintNotebook() const
{
	cout << notebook->ToString() << "\n";
}

void ConsoleInteractor::TaskSwitchPredicateAndRun() const
{
	TaskPrintPredicates();
	int predIndex;
	cout << "Enter predicate index (starts from zero): ";
	ReadVar(predIndex);

	if (predIndex < 0 || predIndex > 1)
	{
		throw std::runtime_error("Invalid predicate index");
	}

	std::vector<Note> finded;

	if (predIndex == 0)
	{
		cout << "enter name: ";
		std::string name;
		cin >> name;

		for (auto& letter : name)
		{
			if (!isalpha(letter))
			{
				throw std::runtime_error("Invalid name");
			}
		}


		auto predicate = [this, name](const Note& note) -> bool
		{
			std::string name1 = note.GetInitial().GetName();
			std::string name2 = name;

			ToUniqueFormat(name1);
			ToUniqueFormat(name2);

			if (name1.compare(name2) == 0)
			{
				return true;
			}
			return false;
		};

		finded = notebook->Find(predicate);
	}
	else
	{
		NoteBuilder builder;
		std::string strData;
		cout << "Enter date in format: dd.mm.yyyy : ";
		cin >> strData;
		std::stringstream sstr(strData);
		Date date = builder.ParseFromStream<Date>(sstr);

		auto predicate = [date](const Note& note) -> bool
		{
			return false;
		};

		finded = notebook->Find(predicate);
	}

	cout << "finded vector contains " << finded.size() << " elements:\n";

	for (auto& item : finded)
	{
		cout << item.ToString() << "\n";
	}
	cout << "\n";
}

void ConsoleInteractor::TaskPrintPredicates() const
{
	cout << "two predicates to choise\n";
	cout << "0: -> search for Note's contains name == inputed name\n";
	cout << "1: -> search for Note's Date of birth and inputed date differ by 3 days\n";
}

void ConsoleInteractor::PrintCommands() const
{
	system("cls");
	cout << "Commands: 0 - exit\n";
	cout << "          1 - read from file and add to container\n";
	cout << "          2 - find by Date of birth\n";
	cout << "          3 - print notebook\n";
	cout << "          4 - clear console\n";
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