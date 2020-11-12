
using System;

namespace FiguresDrawer
{
	// Base interface for all views
	public interface IView
	{
		void ShowError(Exception e);
		void ShowMessage(string message);
	}
}
