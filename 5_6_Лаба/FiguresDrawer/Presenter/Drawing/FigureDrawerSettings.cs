using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresDrawer.Presenter.Drawing
{
	public class FigureDrawerSettings
	{
		public bool DrawVerticesNeeded { get; set; }
		public bool DrawCenterNeeded { get; set; }

		public FigureDrawerSettings(bool drawVertices, bool drawCenter)
		{
			DrawVerticesNeeded = drawVertices;
			DrawCenterNeeded = drawCenter;
		}

	}
}
