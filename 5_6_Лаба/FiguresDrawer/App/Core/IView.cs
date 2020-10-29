
namespace FiguresDrawer
{
	// Base interface for all views
	public interface IView
	{
		void ShowError(string message);
		void ShowMessage(string message);
	}
}
