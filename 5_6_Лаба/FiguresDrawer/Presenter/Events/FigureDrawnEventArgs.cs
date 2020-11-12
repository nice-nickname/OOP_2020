using FiguresDrawer.Presenter.Drawing;
using System;
using System.Windows.Forms;

namespace FiguresDrawer.Presenter.Events
{
	public class FigureDrawnEventArgs : EventArgs
	{
		public ListBox.ObjectCollection Figures { get; }
		public PlaneSettings Settings { get; }
		public FigureDrawer CurrentFigure { get; }

		public FigureDrawnEventArgs(ListBox.ObjectCollection figures, PlaneSettings settings, FigureDrawer current)
		{
			Figures = figures;
			Settings = settings;
			CurrentFigure = current;
		}
	}
}
