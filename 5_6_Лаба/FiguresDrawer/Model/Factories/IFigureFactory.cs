using FiguresDrawer.Model.Structures;

namespace FiguresDrawer.Model.Factories
{
	public interface IFigureFactory
	{
		Figure Create(Point[] points);
	}
}
