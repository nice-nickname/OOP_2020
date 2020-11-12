using FiguresDrawer.Presenter.Drawing;
using System.Collections.Generic;

namespace FiguresDrawer.Presenter.FileParsing
{
	interface IFigureSerializer
	{
		IEnumerable<FigureDrawer> Deserialize();
		void Serialize(IEnumerable<FigureDrawer> data);
	}
}
