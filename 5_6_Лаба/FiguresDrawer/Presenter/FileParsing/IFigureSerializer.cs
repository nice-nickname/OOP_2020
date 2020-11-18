using FiguresDrawer.Presenter.Drawing;
using System.Collections.Generic;

namespace FiguresDrawer.Presenter.FileParsing
{
	public interface IFigureSerializer
	{
		IEnumerable<FigureDrawer> Deserialize(string fileName);
		void Serialize(IEnumerable<FigureDrawer> data, string fileName);
	}
}
