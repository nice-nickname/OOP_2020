#include <vld.h>

#include "ConsoleInteractor.h"
#include "Triangle.h"

int main()
{
	
	/*ConsoleInteractor app;
	app.Run();*/

	Point* p = new Point[3];

	Triangle t(p);

	t.FindCenter();

	delete[] p;
	return 0;
}