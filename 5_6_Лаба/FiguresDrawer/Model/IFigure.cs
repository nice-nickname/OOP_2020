using FiguresDrawer.Model.Structures;

namespace FiguresDrawer.Model
{
	public interface IFigure
	{
		double FindArea();
		double FindPerimeter();
		Point FindCenter();
		bool IsExisting();
	}
}
