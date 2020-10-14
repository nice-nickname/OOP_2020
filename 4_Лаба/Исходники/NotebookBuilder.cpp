#include "NotebookBuilder.h"

std::unique_ptr<INotesContainer> NotebookBuilder::BuildFromType(const std::string& typeName) const
{
	std::unique_ptr<INotesContainer> notebook;

	if (typeName.compare("VECTOR") == 0)
	{
		notebook = Build<VectorNotebook>();
	}
	else if (typeName.compare("MULTIMAP") == 0)
	{
		notebook = Build<MapNotebook>();
	}
	else
	{
		throw std::runtime_error("Invalid type to create notebook");
	}

	return notebook;
}
