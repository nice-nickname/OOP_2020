using System;
using System.Windows.Forms;

namespace FiguresDrawer.View
{
	public interface IFiguresCreatorView : IView
	{
		ListBox.ObjectCollection FiguresBuffer { get; }
		ListBox.ObjectCollection PointsBuffer { get; }

		event EventHandler OnCreateFigureButton_Click;
		event EventHandler OnClearPointsButton_Click;

		event EventHandler<int> OnDeleteFigureButton_Click;

		event Action<object, string, string> OnAddPointButton_Click;
	}
}
