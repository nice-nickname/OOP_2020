using FiguresDrawer.Presenter;
using FiguresDrawer.View;
using FiguresDrawer.View.Forms;
using System;
using System.Collections.Generic;

namespace FiguresDrawer.App.Core
{
	// Needs to encapsulate creating View(From) and Presenter
	public static class FormsFactory
	{
		static public ViewPresenterPair Create<TCreated>(IPresenter sender) where TCreated : IView
		{
			var type = typeof(TCreated);

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
			else if (type == typeof(IFigureInfoPresenterView))
			{
				var form = new FigureInfoPresenterForm();
				return new ViewPresenterPair(form, new FigureInfoPresenter(form), sender);
			}

			throw new ArgumentException("View type '" + nameof(TCreated) + "' not implemented.");
		}

		static public ViewPresenterPair CreateApp(IEnumerable<Type> originFigureTypes)
		{
			var form = new Index();
			return new ViewPresenterPair(form, new FiguresDrawerPresenter(form, originFigureTypes), null);
		}
	}
}
