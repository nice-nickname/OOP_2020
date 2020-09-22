#include "Elements.h"

And::And() : LogicalElement("AND")
{}

bool And::Execute(bool left, bool right) const
{
	return left & right;
}

LogicalElement* And::Copy() const
{
	return new And();
}

Or::Or() : LogicalElement("OR")
{}

bool Or::Execute(bool left, bool right) const
{
	return left | right;
}

LogicalElement* Or::Copy() const
{
	return new Or();
}

Xor::Xor() : LogicalElement("XOR")
{}

bool Xor::Execute(bool left, bool right) const
{
	return left xor right;
}

LogicalElement* Xor::Copy() const
{
	return new Xor();
}
