using FiguresDrawer.Presenter.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiguresDrawer.Presenter.Events
{
	public class DrawingEventArgs : EventArgs
	{
		public ListBox.ObjectCollection Figures { get; private set; }
		public PlaneSettings Settings { get; private set; }

		public DrawingEventArgs(ListBox.ObjectCollection figures, PlaneSettings settings)
		{
			Figures = figures;
			Settings = settings;
		}
	}
}
