using FiguresDrawer.Presenter;
using FiguresDrawer.View;
using FiguresDrawer.View.Forms;
using System;
using System.Collections.Generic;

namespace FiguresDrawer.App.Core
{
	// Needs to encapsulate creating View(From) and Presenter
	public static class FormFactory
	{
		static public ViewPresenterPair Create<T>(IPresenter sender) where T : IView
		{
			var type = typeof(T);

			if (type == typeof(IFiguresSettingsView))
			{
				var form = new FiguresSettingsForm();
				return new ViewPresenterPair(form, new FiguresSettingsPresenter(form), sender);
			}
			else if (type == typeof(IFiguresCreatorView))
			{
				var form = new FiguresCreatorForm();
				return new ViewPresenterPair(form, new FiguresCreatorPresenter(form), sender);
			}

			throw new System.ArgumentException("View type '" + nameof(T) + "' not implemented.");
		}

		static public ViewPresenterPair CreateStartForm(IEnumerable<Type> originFigureTypes)
		{
			var form = new Index();
			return new ViewPresenterPair(form, new FiguresDrawerPresenter(form, originFigureTypes));
		}
	}
}
