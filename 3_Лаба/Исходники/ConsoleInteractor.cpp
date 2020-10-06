#include "ConsoleInteractor.h"

#include "ShapeFactory.h"
#include "GeometryMath.h"

#include <string>
#include <stdexcept>
#include <sstream>
#include <iostream>

using namespace std;

ConsoleInteractor::ConsoleInteractor()
	: _totalCount(0),
	_figuresCount(0),
	_figures(nullptr)
{}

ConsoleInteractor::~ConsoleInteractor()
{
	for (int i = 0; i < _figuresCount; i++)
	{
		if (_figures[i] != nullptr)
		{
			delete _figures[i];
		}
	}
	delete[] _figures;
}

void ConsoleInteractor::Run()
{
	if (!_Init())
	{
		return;
	}

	int _switch;

	_PrintCommands();
	while (true)
	{
		try
		{
			cout << "\n  enter command: ";
			_ReadVar(_switch);

			switch (_switch)
			{
			case 0:

				return;

			case 1:
			{
				if (_totalCount == _figuresCount)
				{
					cout << "failed. array of figures is full\n";
					break;
				}
				int pointsAmount, index;

				cout << "enter index (starts from 0) of new figure: ";
				_ReadVar(index);

				if (index < 0 || index >= _figuresCount)
				{
					cout << "failed. invalid index\n";
					break;
				}

				if (_figures[index] != nullptr)
				{
					cout << "failed. index is already contain a figure\n";
					break;
				}

				cout << "enter amount of points: ";
				_ReadVar(pointsAmount);

				auto points = make_unique<Point[]>(pointsAmount);

				if (pointsAmount <= 0)
				{
					cout << "invalid amount number\n";
					break;
				}

				double x, y;
				for (int i = 0; i < pointsAmount; i++)
				{
					cout << "point " << i + 1 << ": \n";
					cout << "x : "; _ReadVar(x);
					cout << "y : "; _ReadVar(y);
					points[i] = Point(x, y);
				}

				_figures[index] = ShapeFactory::CreateShape(points.get(), pointsAmount);

				if (_figures[index] == nullptr)
				{
					cout << "failed. factory can't create figure from enteret points\n";
					break;
				}

				_totalCount++;
				cout << _figures[index]->GetName() << " was created\n";
			}
			break;

			case 2:
			{
				if (_totalCount == 0)
				{
					cout << "nothing to delete\n";
				}

				int index;
				if (!_ReadIndex(index))
				{
					break;
				}

				delete _figures[index];
				_figures[index] = nullptr;
				_totalCount--;
				cout << "success\n";
			}
			break;

			case 3:
			{
				int index;
				if (!_ReadIndex(index))
				{
					break;
				}

				cout << "Shape : " << _figures[index]->GetName() << "\n";
				const Point* vertices = _figures[index]->GetVertices();
				for (int i = 0; i < _figures[index]->GetVerticesCount(); i++)
				{
					Point p = vertices[i];
					cout << "Point " << i + 1 << ": " << "x - " << p.x << ", y - " << p.y << "\n";
				}
			}
			break;

			case 4:
			{
				int index;
				if (!_ReadIndex(index))
				{
					break;
				}
				Point c = _figures[index]->FindCenter();
				cout << "Center: x - " << c.x << ", y - " << c.y << "\n";
			}
			break;

			case 5:
			{
				int index;
				if (!_ReadIndex(index))
				{
					break;
				}

				double area = _figures[index]->FindArea();
				cout << "area = " << area << "\n";
			}
			break;

			case 6:
			{
				int index;
				if (!_ReadIndex(index))
				{
					break;
				}

				int _degrees;
				cout << "enter angle in degrees: ";
				_ReadVar(_degrees);
				_figures[index]->Rotate(_degrees);
				cout << "success\n";
			}
			break;

			case 7:
			{
				GeometryMath math;

				cout << "index of first figure: ";
				int firstIndex;
				if (!_ReadIndex(firstIndex))
				{
					break;
				}

				cout << "index of second figure: ";
				int secondIndex;
				if (!_ReadIndex(secondIndex))
				{
					break;
				}

				bool ans = math.IsIntersected(*_figures[firstIndex], *_figures[secondIndex]);
				cout << "is figures intersected? " << (ans ? "yes" : "no") << "\n";
			}
			break;

			case 8:
			{
				cout << "index of first figure: ";
				int firstIndex;
				if (!_ReadIndex(firstIndex))
				{
					break;
				}
				cout << "index of second figure: ";
				int secondIndex;
				if (!_ReadIndex(secondIndex))
				{
					break;
				}
				GeometryMath math;

				bool ans = math.IsIncluded(*_figures[firstIndex], *_figures[secondIndex]);
				cout << "is first figure includes second? " << (ans ? "yes" : "no") << "\n";

				ans = math.IsIncluded(*_figures[secondIndex], *_figures[firstIndex]);
				cout << "is second figure includes first? " << (ans ? "yes" : "no") << "\n";
			}
			break;

			case 9:
			{
				cout << "index of figure: ";
				int index;
				if (!_ReadIndex(index))
				{
					break;
				}
				double x, y;

				cout << "offset by x: ";
				_ReadVar(x);
				cout << "offset by t: ";
				_ReadVar(y);
				_figures[index]->Move(x, y);
			}
			break;

			case 10:
				_PrintCommands();
				break;

			default:
				cout << "invalid command\n";
				break;
			}
		}
		catch (const std::exception & e)
		{
			cout << e.what() << "\n";
		}
	}
}

bool ConsoleInteractor::_Init()
{
	int _count;
	cout << "Enter a maximum amount of figures or enter 0 to quit\n";
	while (true)
	{
		try
		{
			_ReadVar(_count);
			if (_count == 0)
			{
				return false;
			}
			else if (_count < 0)
			{
				cout << "Invalid count\n";
			}
			else
			{
				cout << "Success\n";
				_figuresCount = _count;
				_figures = new Shape * [_figuresCount];
				std::fill(_figures, _figures + _figuresCount, nullptr);
				return true;
			}
		}
		catch (const std::exception & e)
		{
			cout << e.what() << "\n";
		}
	}
}

void ConsoleInteractor::_PrintCommands() const
{
	system("cls");
	cout << "Commands: \n";
	cout << "  1: create shape, 2: delete shape, 3: print shape\n";
	cout << "  4: find center, 5: find area, 6 rotate shape\n";
	cout << "  7: is figures intersected, 8: is figures included\n";
	cout << "  9: move shape, 10: clear the console, 0: exit\n\n";
	cout << "  Maximum amount of figures = " << _figuresCount << "\n";
}

bool ConsoleInteractor::_ReadIndex(int& _index) const
{
	cout << "enter index (starts from 0) of figure: ";
	_ReadVar(_index);

	if (_index < 0 || _index >= _figuresCount)
	{
		cout << "failed. invalid index\n";
		return false;
	}

	if (_figures[_index] == nullptr)
	{
		cout << "failed. index is empty\n";
		return false;
	}
	return true;
}

template void ConsoleInteractor::_ReadVar(int& var) const;
template void ConsoleInteractor::_ReadVar(double& var) const;

template<class T>
void ConsoleInteractor::_ReadVar(T& var) const
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
