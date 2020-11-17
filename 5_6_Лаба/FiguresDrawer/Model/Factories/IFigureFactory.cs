using FiguresDrawer.Model.Structures;

namespace FiguresDrawer.Model.Factories
{
	public interface IFigureFactory
	{
		FigureBase Create(Point[] points);
	}
}
