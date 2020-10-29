using System.Drawing;

namespace FiguresDrawer.Presenter.Adapter
{
	public interface IFigureAdapter
	{
		PointF[] GetPoints();
		PointF GetCenter();
		double GetArea();
		double GetPerimeter();
	}
}
