using FiguresDrawer.App.Core;
using FiguresDrawer.Model.Figures;
using FiguresDrawer.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FiguresDrawer
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			List<Type> types = new List<Type>();

			types.Add(typeof(Rectangle));
			types.Add(typeof(Triangle));
			types.Add(typeof(Segment));
			types.Add(typeof(Polygon));


			var app = FormFactory.CreateStartForm(types);

			Application.Run(app.View);
		}
	}
}
