#include <iostream>
#include <iomanip>

#include "ConsoleInteractor.h"
#include "Triangle.h"

using namespace std;

void ConsoleInteractor::Run()
{
	float x1, y1, x2, y2, x3, y3;
	cout << "Enter a coords of first triangle vertexes in format: \nx1 y1\nx2 y2\nx3 y3\n\n";
	cin >> x1 >> y1 >> x2 >> y2 >> x3 >> y3;
	Triangle t1(x1, y1, x2, y2, x3, y3);
	cout << "Enter a coords of second triangle vertexes in format: \nx1 y1\nx2 y2\nx3 y3\n\n";
	cin >> x1 >> y1 >> x2 >> y2 >> x3 >> y3;
	Triangle t2(x1, y1, x2, y2, x3, y3);

	_UpdateConsole(t1, t2);


	int switch_on;
	Point C1(0.f, 0.f);
	Point C2(0.f, 0.f);



	while (true)
	{
		cout << ">>> ";
		cin >> switch_on;
		try
		{
			switch (switch_on)
			{
			case 0:
				return;
				break;

			case 1:
				cout << "-------------------------------------\n";
				cout << "Perimeter of first triangle = " << t1.FindPerimeter() << "\n";
				cout << "Perimeter of second triangle = " << t2.FindPerimeter() << "\n";
				cout << "-------------------------------------\n\n";
				break;

			case 2:
				cout << "-------------------------------------\n";
				cout << "Area of first Triangle = " << t1.FindArea() << "\n";
				cout << "Area of second Triangle = " << t2.FindArea() << "\n";
				cout << "-------------------------------------\n\n";
				break;

			case 3:
				cout << "-------------------------------------\n";
				C1 = t1.FindCenter();
				C2 = t2.FindCenter();
				cout << "Coords of first triangle's center = x: " << C1.x << " y: " << C1.y << "\n";
				cout << "Coords of second triangle's center = x: " << C2.x << " y: " << C2.y << "\n";
				cout << "-------------------------------------\n\n";
				break;

			case 4:
				cout << "-------------------------------------\n";
				t1.Move(_ReadPointFromConsole());
				cout << "-------------------------------------\n\n";
				_UpdateConsole(t1, t2);
				break;

			case 5:
				cout << "-------------------------------------\n";
				t2.Move(_ReadPointFromConsole());
				cout << "-------------------------------------\n\n";
				_UpdateConsole(t1, t2);
				break;

			case 6:
				cout << "-------------------------------------\n";
				cout << "Result of 'First Triagnle > Second Triangle' is " << ((t1 > t2) ? "true\n" : "false\n");
				cout << "-------------------------------------\n\n";
				break;

			case 7:
				cout << "-------------------------------------\n";
				cout << "Result of 'First Triagnle < Second Triangle' is " << ((t1 < t2) ? "true\n" : "false\n");
				cout << "-------------------------------------\n\n";
				break;

			case 8:
				cout << "-------------------------------------\n";
				cout << "Result of 'First Triagnle >= Second Triangle' is " << ((t1 >= t2) ? "true\n" : "false\n");
				cout << "-------------------------------------\n\n";
				break;

			case 9:
				cout << "-------------------------------------\n";
				cout << "Result of 'First Triagnle <= Second Triangle' is " << ((t1 <= t2) ? "true\n" : "false\n");
				cout << "-------------------------------------\n\n";
				break;

			case 10:
				cout << "-------------------------------------\n";
				cout << "Result of 'Is areas Equal?' is " << (t1.IsAreasEqual(t2) ? "true\n" : "false\n");
				cout << "-------------------------------------\n\n";
				break;

			case 11:
				cout << "-------------------------------------\n";
				t1.SetFirstPoint(_ReadPointFromConsole());
				cout << "-------------------------------------\n\n";
				_UpdateConsole(t1, t2);
				break;

			case 12:
				cout << "-------------------------------------\n";
				t1.SetSecondPoint(_ReadPointFromConsole());
				cout << "-------------------------------------\n\n";
				_UpdateConsole(t1, t2);
				break;

			case 13:
				cout << "-------------------------------------\n";
				t1.SetThirdPoint(_ReadPointFromConsole());
				cout << "-------------------------------------\n\n";
				_UpdateConsole(t1, t2);
				break;

			case 14:
				cout << "-------------------------------------\n";
				t2.SetFirstPoint(_ReadPointFromConsole());
				cout << "-------------------------------------\n\n";
				_UpdateConsole(t1, t2);
				break;

			case 15:
				cout << "-------------------------------------\n";
				t2.SetSecondPoint(_ReadPointFromConsole());
				cout << "-------------------------------------\n\n";
				_UpdateConsole(t1, t2);
				break;

			case 16:
				cout << "-------------------------------------\n";
				t2.SetThirdPoint(_ReadPointFromConsole());
				cout << "-------------------------------------\n\n";
				_UpdateConsole(t1, t2);
				break;

			case 17:
				_UpdateConsole(t1, t2);
				break;

			default:
				cout << "Invalid command. Try again\n";
				break;
			}
		}
		catch (const std::exception & e)
		{
			cerr << e.what() << "\n";
		}
	}
}

void ConsoleInteractor::_UpdateConsole(const Triangle& t1, const Triangle& t2)
{
	system("cls");
	cout << "COMMANDS: 1 - Find Perpimeter. 2 - Find Area. 3 - Find Center of Mass.\n";
	cout << "          4 - Move first Triangle. 5 - Move second Triangle.\n";
	cout << "          6 - Compare with operator >. 7 - Compare with operator <.\n";
	cout << "          8 - Compare with operator >=. 9 - Compare with operator <=.\n";
	cout << "          10 - Is areas equal? 0 - to Exit\n";
	cout << "          11 - Set first point of first triangle. 12 - Set second point of first triangle\n";
	cout << "          13 - Set third point of first triangle.\n";
	cout << "          14 - Set first point of second triangle. 15 - Set second point of second triangle\n";
	cout << "          16 - Set third point of second triangle.\n";
	cout << "          17 - To refresh console.\n";

	Point p1 = t1.GetFirstPoint();
	Point p2 = t1.GetSecondPoint();
	Point p3 = t1.GetThirdPoint();

	cout << "\nCurrent Triangles: \n";
	cout << setw(10) << left << "First: " << "|";
	cout << "x1: " << p1.x << " y1: " << p1.y << "|"; 
	cout << "x2: " << p2.x << " y2: " << p2.y << "|"; 
	cout << "x3: " << p3.x << " y3: " << p3.y << " | \n\n";

	p1 = t2.GetFirstPoint();
	p2 = t2.GetSecondPoint();
	p3 = t2.GetThirdPoint();

	cout << setw(10) << left << "Second: " << "|";
	cout << "x1: " << p1.x << " y1: " << p1.y << "|";
	cout << "x2: " << p2.x << " y2: " << p2.y << "|";
	cout << "x3: " << p3.x << " y3: " << p3.y << " | \n\n";
}

Point ConsoleInteractor::_ReadPointFromConsole()
{
	float x1, y1;
	cout << "Enter a point if format: x y\n";
	cin >> x1 >> y1;
	return Point(x1, y1);
}
