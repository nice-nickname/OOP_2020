#pragma once

#include "INotesContainer.h"
#include <memory>

class ConsoleInteractor
{
public:

	void Run();

private:
	
	std::unique_ptr<INotesContainer> notebook;

	template<typename T> 
	void ReadVar(T& var) const;

	bool Init();
	int ReadCommand() const;

	void TaskReadFileAndBuild();
	void TaskPrintNotebook() const;
	void TaskSwitchPredicateAndRun() const;
	void TaskPrintPredicates() const;

	void PrintCommands() const;
	void ToUniqueFormat(std::string& destString) const;


};

