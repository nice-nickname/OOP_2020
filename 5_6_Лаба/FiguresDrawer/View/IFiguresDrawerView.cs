using System;
using System.Drawing;
using System.Windows.Forms;

namespace FiguresDrawer.View
{
	public interface IFiguresDrawerView : IView
	{
		Size GetSize();
		ListBox.ObjectCollection Figures { get; }
		Label AreaTextLabel { get; }
		Label PerimeterTextLabel { get; }

		void InvokePaintEvent();

		event EventHandler SettingsButton_Click;		
		event EventHandler HelpMeButton_Click;		
		event EventHandler ModificateListButton_Click;

		event PaintEventHandler CanvasPaint;

		event MouseEventHandler Mouse_Moving;
		event MouseEventHandler Mouse_KeyUp;
		event MouseEventHandler Mouse_KeyDown;
		
		event EventHandler<decimal> ScaleCanvas_ValueChenged;
		event EventHandler<int> FiguresList_IndexChanged;
	}

}
