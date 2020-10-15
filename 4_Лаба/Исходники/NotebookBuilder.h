#pragma once

#include "INotesContainer.h"

#include <type_traits>
#include <utility>
#include <memory>

class NotebookBuilder
{
public:

	template<typename TContainer>
	std::unique_ptr<INotesContainer> Build() const;

	std::unique_ptr<INotesContainer> BuildFromType(const std::string& typeName) const;

};

template<typename TContainer>
inline std::unique_ptr<INotesContainer> NotebookBuilder::Build() const
{
	if (!std::is_base_of<INotesContainer, TContainer>::value)
	{
		throw std::exception("Invalid type to build");
	}

	return std::make_unique<TContainer>(TContainer());
}
