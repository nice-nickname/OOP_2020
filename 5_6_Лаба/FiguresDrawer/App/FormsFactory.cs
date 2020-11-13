using System;
using System.Collections.Generic;

namespace FiguresDrawer.App.Core
{
	// Needs to encapsulate creating View(From) and Presenter
	public static class FormsFactory
	{
		private static AppManager _manager;
		private static IEnumerable<Type> _originFigureTypes;

		static public ViewPresenterPair Create<TCreated>(IPresenter sender) 
			where TCreated : IView
		{
			return _manager.CreateForm<TCreated>(sender);
		}

		static public ViewPresenterPair CreateStartForm()
		{
			return _manager.CreateStartForm(_originFigureTypes);
		}


		static public void CreateApp(IEnumerable<Type> originFigureTypes, AppManager manager)
		{
			_originFigureTypes = originFigureTypes;
			_manager = manager;
		}
	}
}
