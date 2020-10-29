using FiguresDrawer.View;

namespace FiguresDrawer.Presenter
{
	class FiguresSettingsPresenter : IPresenter
	{
		private IFiguresAppSettingsView _view;

		public FiguresSettingsPresenter(IFiguresAppSettingsView view)
		{
			_view = view;
		}
	}
}
