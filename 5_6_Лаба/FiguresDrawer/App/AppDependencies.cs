using FiguresDrawer.Presenter.FileParsing;
using System;

namespace FiguresDrawer.App.Core
{
	// Needs to encapsulate creating View(From) and Presenter
	public static class AppDependencies
	{
		private static AppDependencyContainer _manager;

		static public ViewPresenterPair CreateForm<TCreated>(IPresenter sender) 
			where TCreated : IView
		{
			return _manager.CreateForm<TCreated>(sender);
		}

		static public ViewPresenterPair CreateStartForm()
		{
			return _manager.CreateStartForm();
		}

		static public IFigureSerializer CreateSerializer()
		{
			return _manager.CreateSerializer();
		}

		static public void Initialize(AppDependencyContainer manager)
		{
			_manager = manager ?? throw new ArgumentNullException(nameof(manager));
		}
	}
}
