using System;
using System.Collections.Generic;

namespace FiguresDrawer.App.Core
{
	// Needs to encapsulate creating View(From) and Presenter
	public static class FormsFactory
	{
		private static AppDependencyContainer _manager;

		static public ViewPresenterPair Create<TCreated>(IPresenter sender) 
			where TCreated : IView
		{
			EnsureFactoryInited();
			return _manager.CreateForm<TCreated>(sender);
		}

		static public ViewPresenterPair CreateStartForm()
		{
			EnsureFactoryInited();
			return _manager.CreateStartForm();
		}

		static public void Initialize(AppDependencyContainer manager)
		{
			_manager = manager;
		}

		static private void EnsureFactoryInited()
		{
			if(_manager == null)
			{
				throw new ArgumentNullException("Factory not inited. Please, invoke FormsFactory.Initialize() method.");
			}
		}
	}
}
