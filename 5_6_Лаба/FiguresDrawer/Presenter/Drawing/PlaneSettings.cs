using System;
using System.Collections.Generic;
using System.Linq;

namespace FiguresDrawer.Presenter.Drawing
{
	public class PlaneSettings
	{
		public Type[] Types { get; }
		public HashSet<Type> TypesToDraw { get; }

		public FigureDrawerSettings DrawerSettings { get; set; }

		public PlaneSettings(IEnumerable<Type> originFigureTypes, FigureDrawerSettings drawerSettings)
		{
			Types = new Type[originFigureTypes.Count()];

			for (int i = 0; i < originFigureTypes.Count(); i++)
			{
				Types[i] = originFigureTypes.ElementAt(i);
			}

			TypesToDraw = new HashSet<Type>(originFigureTypes);
			DrawerSettings = drawerSettings;
		}
	}
}
