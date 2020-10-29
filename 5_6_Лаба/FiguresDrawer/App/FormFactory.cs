using FiguresDrawer.Presenter;
using FiguresDrawer.View;
using FiguresDrawer.View.Forms;

namespace FiguresDrawer.App
{
	// Needs to encapsulate creating View(From) and Presenter
	public static class FormFactory
	{
		public static ViewPresenterPair Create<TReqView>(IView sender)
		{
			var type = typeof(TReqView);

			if (type == typeof(IFiguresDrawerView))
			{
				var form = new Index();
				return new ViewPresenterPair(form, new FiguresDrawerPresenter(form));
			}
			else if (type == typeof(IFiguresAppSettingsView))
			{
				var form = new FiguresSettingsForm();
				return new ViewPresenterPair(form, new FiguresSettingsPresenter(form));
			}
			else if (type == typeof(IFiguresCreatorView))
			{
				var form = new FiguresCreatorForm();

				if (sender is IFiguresDrawerView)
				{
					return new ViewPresenterPair(form, new FiguresCreatorPresenter(form, (sender as IFiguresDrawerView).Figures));
				}
			}

			return null;
		}
	}
}
