using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiguresDrawer.Presenter.Drawing
{
	public class PlaneSettings
	{
		public Type[] Types { get; private set; }

		public HashSet<Type> TypesToDraw { get; private set; }

		public PlaneSettings(IEnumerable<Type> originFigureTypes)
		{
			Types = new Type[originFigureTypes.Count()];

			for (int i = 0; i < originFigureTypes.Count(); i++)
			{
				Types[i] = originFigureTypes.ElementAt(i);
			}

			TypesToDraw = new HashSet<Type>(originFigureTypes);
		}
	}
}
