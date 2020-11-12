using System;
using System.Windows.Forms;

namespace FiguresDrawer.View
{
	public interface IFiguresSettingsView : IView
	{
		CheckedListBox GetCheckedList();

		event EventHandler SaveAndExitButton_Click;

		CheckBox DrawVerticesCheckBox();
		CheckBox DrawCenterCheckBox();
	}
}
