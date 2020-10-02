#include "ConsoleInteractor.h"

#include "ShapeFactory.h"
#include "GeometryMath.h"

#include <string>
#include <stdexcept>
#include <sstream>
#include <iostream>

using namespace std;

ConsoleInteractor::ConsoleInteractor()
	: totalCount(0),
	figuresCount(0),
	figures(nullptr)
{}

ConsoleInteractor::~ConsoleInteractor()
{
	for (int i = 0; i < figuresCount; i++)
	{
		if (figures[i] != nullptr)
		{
			delete figures[i];
		}
	}
	delete[] figures;
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
				if (totalCount == figuresCount)
				{
					cout << "failed. array of figures is full\n";
					break;
				}
				int _ptsAmount, _index;

				cout << "enter index (starts from 0) of new figure: ";
				_ReadVar(_index);

				if (_index < 0 || _index >= figuresCount)
				{
					cout << "failed. invalid index\n";
					break;
				}

				if (figures[_index] != nullptr)
				{
					cout << "failed. index is already contain a figure\n";
					break;
				}

				cout << "enter amount of points: ";
				_ReadVar(_ptsAmount);

				auto _points = make_unique<Point[]>(_ptsAmount);

				if (_ptsAmount <= 0)
				{
					cout << "invalid amount number\n";
					break;
				}

				double x, y;
				for (int i = 0; i < _ptsAmount; i++)
				{
					cout << "point " << i + 1 << ": \n";
					cout << "x : "; _ReadVar(x);
					cout << "y : "; _ReadVar(y);
					_points[i] = Point(x, y);
				}

				figures[_index] = ShapeFactory::CreateShape(_points.get(), _ptsAmount);

				if (figures[_index] == nullptr)
				{
					cout << "failed. factory can't create figure from enteret points\n";
					break;
				}

				totalCount++;
				cout << figures[_index]->GetName() << " was created\n";
			}
			break;

			case 2:
			{
				if (totalCount == 0)
				{
					cout << "nothing to delete\n";
				}

				int _index;
				if (!_ReadIndex(_index))
				{
					break;
				}

				delete figures[_index];
				figures[_index] = nullptr;
				totalCount--;
				cout << "success\n";
			}
			break;

			case 3:
			{
				int _index;
				if (!_ReadIndex(_index))
				{
					break;
				}

				cout << "Shape : " << figures[_index]->GetName() << "\n";
				const Point* _vertices = figures[_index]->GetVertices();
				for (int i = 0; i < figures[_index]->GetVerticesCount(); i++)
				{
					Point p = _vertices[i];
					cout << "Point " << i + 1 << ": " << "x - " << p.x << ", y - " << p.y << "\n";
				}
			}
			break;

			case 4:
			{
				int _index;
				if (!_ReadIndex(_index))
				{
					break;
				}
				Point c = figures[_index]->FindCenter();
				cout << "Center: x - " << c.x << ", y - " << c.y << "\n";
			}
			break;

			case 5:
			{
				int _index;
				if (!_ReadIndex(_index))
				{
					break;
				}

				double _area = figures[_index]->FindArea();
				cout << "area = " << _area << "\n";
			}
			break;

			case 6:
			{
				int _index;
				if (!_ReadIndex(_index))
				{
					break;
				}

				int _degrees;
				_ReadVar(_degrees);
				figures[_index]->Rotate(_degrees);
				cout << "success\n";
			}
			break;

			case 7:
			{
				cout << "index of first figure: ";
				int _firstInd;
				if (!_ReadIndex(_firstInd))
				{
					break;
				}
				cout << "index of second figure: ";
				int _secondInd;
				if (!_ReadIndex(_secondInd))
				{
					break;
				}
				GeometryMath math;
				bool ans = math.IsIntersected(*figures[_firstInd], *figures[_secondInd]);
				cout << "is figures intersected? " << (ans ? "yes" : "no") << "\n";
			}
			break;

			case 8:
			{
				cout << "index of first figure: ";
				int _firstInd;
				if (!_ReadIndex(_firstInd))
				{
					break;
				}
				cout << "index of second figure: ";
				int _secondInd;
				if (!_ReadIndex(_secondInd))
				{
					break;
				}
				GeometryMath math;
				bool ans = math.IsIncluded(*figures[_firstInd], *figures[_secondInd]);
				cout << "is first figure includes second? " << (ans ? "yes" : "no") << "\n";
			}
			break;

			case 9:
			{
				cout << "index of figure: ";
				int _index;
				if (!_ReadIndex(_index))
				{
					break;
				}
				double _x, _y;

				cout << "offset by x: ";
				_ReadVar(_x);
				cout << "offset by t: ";
				_ReadVar(_y);
				figures[_index]->Move(_x, _y);
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
				figuresCount = _count;
				figures = new Shape * [figuresCount];
				std::fill(figures, figures + figuresCount, nullptr);
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
	cout << "  Maximum amount of figures = " << figuresCount << "\n";
}

bool ConsoleInteractor::_ReadIndex(int& _index)
{
	cout << "enter index (starts from 0) of figure: ";
	_ReadVar(_index);

	if (_index < 0 || _index >= figuresCount)
	{
		cout << "failed. invalid index\n";
		return false;
	}

	if (figures[_index] == nullptr)
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
