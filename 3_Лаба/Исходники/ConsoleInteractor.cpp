#include "ConsoleInteractor.h"

#include "ConcreteShapes.h"
#include "ShapeException.h"
#include "GeometryMath.h"
#include "ShapesFactory.h"

#include <iostream>
#include <exception>
#include <sstream>
#include <algorithm>

using namespace std;

void ConsoleInteractor::Start() const
{
	Shape** figures;
	int index = 0;
	int count = 10;

	figures = new Shape * [count];

	_PrintCommands();
	
	int var1, var2, switch_on;
	std::string name;
	while (true)
	{
		cout << ">>> ";
		cin >> switch_on;
		try
		{
			switch (switch_on)
			{
			case 0:
				goto end;
				break;

			case 1:
				if (index == 9)
				{
					cout << "Out of place for figures (max is " << count << ")\n";
				}
				cout << "Enter shape's name\n>>> ";
				cin >> name;
				for (auto& i : name)
				{
					i = toupper(i);
				}
				if (name == "TRIANGLE")
				{
					float x, y;
					Point p[3];
					for (int i = 0; i < 3; i++)
					{
						cout << "Enter a point in format [x y]\n>>> ";
						_ReadFloat(x);
						_ReadFloat(y);
						p[i] = Point(x, y);
					}
					cout << "\n";
					figures[index++] = TriangleFactory::CreateShape(p[0], p[1], p[2]);
				}
				else if (name == "RECT")
				{
					float x, y;
					cout << "Enter a point in format [x y]\n>>> ";
					_ReadFloat(x);
					_ReadFloat(y);
					Point p(x, y);
					cout << "Enter a width and height in format [w h]\n>>> ";
					_ReadFloat(x);
					_ReadFloat(y);
					figures[index++] = RectFactory::CreateShape(p, x, y);
				}
				else
				{
					cout << "Invalid name\n";
				}
				break;

			case 2:
				if (index != 0)
				{
					delete figures[index - 1];
					index--;
				}
				break;

			case 3:
				cout << "Enter index\n>>> ";
				cin >> var1;
				if (var1 < 0 || var1 >= index)
				{
					cout << "Invalid index\n";
					break;
				}
				else
				{
					Shape* s = figures[var1];
					cout << "\nShape's name: " << s->GetName() << "\n";
					for (int i = 0; i < s->GetCount(); i++)
					{
						cout << i << " vertex: x = " << (*s)[i].x << " y = " << (*s)[i].y << "\n";
					}
					cout << "\n";
				}
				break;

			case 4:
				cout << "Enter index\n>>> ";
				cin >> var1;
				if (var1 < 0 || var1 >= index)
				{
					cout << "Invalid index\n";
					break;
				}
				else
				{
					Point c = figures[var1]->FindCenter();;
					cout << "Center: x - " << c.x << " y - " << c.y << "\n";
				}
				break;

			case 5:
				cout << "Enter index\n>>> ";
				cin >> var1;
				if (var1 < 0 || var1 >= index)
				{
					cout << "Invalid index\n";
					break;
				}
				else
				{
					cout << "Area = " << figures[var1]->FindArea() << "\n";
				}
				break;

			case 6:
				cout << "Enter index\n>>> ";
				cin >> var1;
				if (var1 < 0 || var1 >= index)
				{
					cout << "Invalid index\n";
					break;
				}
				else
				{
					cout << "Enter a degrees\n>>> ";
					cin >> var2;
					figures[var1]->Rotate(var2);
				}
				break;

			case 7:
				cout << "Enter indexes\n>>> ";
				cin >> var1 >> var2;
				if (var1 < 0 || var1 >= index || var2 < 0 || var2 >= index)
				{
					cout << "Invalid index\n";
					break;
				}
				else
				{
					cout << "answer is: " << (GeometryMath::IsIntersected(*figures[var1], *figures[var2]) ? "true\n" : "false\n");
				}
				break;

			case 8:
				cout << "Enter indexes\n>>> ";
				cin >> var1 >> var2;
				if (var1 < 0 || var1 >= index || var2 < 0 || var2 >= index)
				{
					cout << "Invalid index\n";
					break;
				}
				else
				{
					cout << "first figure including second?  " << (GeometryMath::IsIncluding(*figures[var1], *figures[var2]) ? "true\n" : "false\n");
				}
				break;

			case 9:
				cout << "Enter index\n>>> ";
				cin >> var1;
				if (var1 < 0 || var1 >= index)
				{
					cout << "Invalid index\n";
					break;
				}
				else
				{
					float x, y;
					cout << "Enter point in format [x y]\n>>> ";
					_ReadFloat(x);
					_ReadFloat(y);
					figures[var1]->Move({ x, y });
				}
				break;

			case 10:
				_PrintCommands();
				break;

			default:
				cout << "Try again\n";
				break;
			}
		}
		catch (const std::exception & e)
		{
			cout << e.what() << "\n";
		}

	}

end:
	for (int i = 0; i < index; i++)
	{
		delete figures[i];
	}
	delete[] figures;

}


void ConsoleInteractor::_PrintCommands() const
{
	system("cls");
	cout << "Commands: \n";
	cout << "  1: create shape, 2: delete last shape, 3: print shape by index\n";
	cout << "  4: find center, 5: find area, 6 rotate shape\n";
	cout << "  7: is shapes intersected, 8: is shapes included\n";
	cout << "  9: move shape, 10: clear the console, 0: exit\n\n";
}

void ConsoleInteractor::_ReadFloat(float& x) const
{
	std::string s;
	cin >> s;
	std::stringstream sin(s);
	if (!(sin >> x))
	{
		throw std::runtime_error("Float input error");
	}

	char c;
	if (sin >> c)
	{
		throw std::runtime_error("Float input error");
	}
}
