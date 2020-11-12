using FiguresDrawer.App.Core;
using FiguresDrawer.Model.Figures;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FiguresDrawer
{
	// TODO: Возможно поправить grid

	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			List<Type> types = new List<Type>
			{
				typeof(Rectangle),
				typeof(Triangle),
				typeof(Segment),
				typeof(Polygon)
			};

			var app = FormsFactory.CreateApp(types);

			Application.Run(app.View);
		}
	}
}
