using System;
using System.Drawing;
using System.Windows.Forms;

namespace FiguresDrawer.View
{
	public interface IFiguresCreatorView : IView
	{
		ListBox.ObjectCollection FiguresBuffer { get; }
		ListBox.ObjectCollection PointsBuffer { get; }

		event EventHandler ReadFromFileButton_Click;
		event EventHandler WriteToFileButton_Click;

		event EventHandler CreateFigureButton_Click;
		event EventHandler ClearPointsButton_Click;

		event EventHandler<int> FigureList_IndexChanged;
		event EventHandler<int> DeleteFigureButton_Click;

		event Action<object, int, string, string> EditPointButton_Click;
		event Action<object, string, string> AddPointButton_Click;

		Color GetSelectedColor();
	}
}
