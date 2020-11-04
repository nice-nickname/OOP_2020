using FiguresDrawer.App;
using FiguresDrawer.View;
using System;
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

			var app = FormFactory.Create<IFiguresDrawerView>();

			Application.Run(app.View);
		}
	}
}
