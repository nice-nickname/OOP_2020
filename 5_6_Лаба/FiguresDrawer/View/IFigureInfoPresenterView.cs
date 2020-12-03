using FiguresDrawer.Model.Structures;
using System.Collections.Generic;

namespace FiguresDrawer.View
{
	public interface IFigureInfoPresenterView : IView
	{
		void SetAreaInfo(double area);
		void SetPerimeterInfo(double perimeter);
		void SetCenterInfo(Point point);
		void SetPoints(IEnumerable<Point> points);
	}
}
