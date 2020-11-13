using System;
using System.Drawing;

namespace FiguresDrawer.Presenter.Adapter
{
	public interface IFigureAdapter
	{
		Model.Structures.Point[] GetRawPoints();
		Model.Structures.Point GetRawCenter();
		PointF[] GetPoints();
		PointF GetCenter();
		double GetArea();
		double GetPerimeter();
		Type FigureType { get; } 
	}
}
