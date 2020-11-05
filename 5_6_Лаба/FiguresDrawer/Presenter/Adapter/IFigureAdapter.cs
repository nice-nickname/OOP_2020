using System;
using System.Drawing;

namespace FiguresDrawer.Presenter.Adapter
{
	public interface IFigureAdapter
	{
		FiguresDrawer.Model.Structures.Point[] GetRawPoints();
		PointF[] GetPoints();
		PointF GetCenter();
		double GetArea();
		double GetPerimeter();
		Type BaseType { get; } 
	}
}
