#include "ConsoleInteractor.h"

#include <Windows.h>
#include <iostream>
#include <string>
#include <sstream>

using namespace std;

#include "MapNotebook.h"
#include "VectorNotebook.h"
#include "NoteFileReader.h"
#include "NoteBuilder.h"

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
	cout << "\nenter command: ";

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

	std::vector<Note> finded;

	switch (predIndex)
	{
	case 0:
	{
		cout << "Enter day: ";
		int day;
		ReadVar(day);
		if (day <= 0 || day > 31)
		{
			throw std::runtime_error("Invalid day readed");
		}

		finded = notebook->Find([day](const Note& note) -> bool
			{
				if (note.GetBirthDate().GetDay() == day)
				{
					return true;
				}
				return false;
			});
	}
		break;
	
	case 1:
	{
		cout << "Enter month: ";
		int month;
		ReadVar(month);
		if (month <= 0 || month > 12)
		{
			throw std::runtime_error("Invalid day readed");
		}

		finded = notebook->Find([month](const Note& note) -> bool
			{
				if (note.GetBirthDate().GetMonth() == month)
				{
					return true;
				}
				return false;
			});
	}
		break;
	
	case 2:
	{
		cout << "Enter date in format dd.mm.yyyy : ";

		NoteBuilder builder;

		string data;
		cin >> data;

		stringstream sstr(data);

		Date date = builder.ParseFromStream<Date>(sstr);

		finded = notebook->FindByKey(date);

	}
		break;
	
	case 3:
	{
		cout << "Enter name: ";
		string name;

		cin >> name;

		for (auto& letter : name)
		{
			if (!isalpha(letter))
			{
				throw std::runtime_error("Invalid name");
			}
			letter = tolower(letter);
		}
		name[0] = toupper(name[0]);

		finded = notebook->Find([name](const Note& note) -> bool
			{
				if (note.GetInitial().GetName() == name)
				{
					return true;
				}
				return false;
			});
	}
		break;
	
	case 4:
	{
		cout << "Enter county code: ";
		
		string code;
		cin >> code;

		for (auto& letter : code)
		{
			if (!isdigit(letter))
			{
				throw std::runtime_error("Invalid county code");
			}
		}

		finded = notebook->Find([code](const Note& note) -> bool
			{
				if (note.GetPhoneNumber().GetCountyCode() == code)
				{
					return true;
				}
				return false;
			});
	}
		break;

	default:
		throw std::runtime_error("Invalid predicate index");
		break;
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
	cout << "Predicates to test:\n";
	cout << "0: find notes with inputed day\n";
	cout << "1: find notes with inputed month\n";
	cout << "2: find notes with inputed Date\n";
	cout << "3: find notes with inputed Name\n";
	cout << "4: find notes with inputed phone number's county code\n";
}

void ConsoleInteractor::PrintCommands() const
{
	system("cls");
	cout << "Commands: 0 - exit\n";
	cout << "          1 - read from file and add to container\n";
	cout << "          2 - test predicates\n";
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