﻿using FiguresDrawer.Model;
using FiguresDrawer.Presenter.FileParsing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FiguresDrawer.App
{
	public class AppDependencyContainer
	{
		private Dictionary<Type, Type> _viewPresenterDictionary;
		private IServiceCollection _services;

		private Type _startViewType;
		private Type _startPresenterType;

		private IEnumerable<Type> _originFigureTypes;

		public AppDependencyContainer()
		{
			_services = new ServiceCollection();
			_viewPresenterDictionary = new Dictionary<Type, Type>();
		}

		public ViewPresenterPair CreateForm<TReqView>(IPresenter parent)
			where TReqView : IView
		{
			var view = GetFormByView<TReqView>();
			var presenter = GetPresenterByView<TReqView>(view as IView);
			return new ViewPresenterPair(view, presenter, parent);
		}

		public ViewPresenterPair CreateStartForm()
		{
			var view = _services
				.BuildServiceProvider()
				.GetService(_startViewType)
				as Form;

			if (_originFigureTypes == null)
			{
				throw new ArgumentNullException("Список фигур не зарегистрирован");
			}

			var presenter = Activator.CreateInstance(_startPresenterType, view, _originFigureTypes) as IPresenter;

			return new ViewPresenterPair(view, presenter, null);
		}

		public IFigureSerializer CreateSerializer()
		{
			return _services
				.BuildServiceProvider()
				.GetService<IFigureSerializer>();
		}

		public void RegisterFiguresTypes(IEnumerable<Type> types)
		{
			_originFigureTypes = types ?? throw new ArgumentNullException(nameof(types));
		}

		public void RegisterForm<TView, TForm, TPresenter>()
			where TPresenter : class, IPresenter
			where TForm : class, IView
			where TView : IView
		{
			_services.AddTransient(typeof(TView), typeof(TForm));
			_viewPresenterDictionary.Add(typeof(TView), typeof(TPresenter));
		}

		public void RegisterStartForm<TView, TForm, TPresenter>()
			where TPresenter : class, IPresenter
			where TForm : class, IView
			where TView : IView
		{
			_startViewType = typeof(TView);
			_startPresenterType = typeof(TPresenter);

			_services.AddSingleton(typeof(TView), typeof(TForm));
		}

		public void RegisterFigureSerialuzer<T>()
			where T : class, IFigureSerializer
		{
			_services.AddSingleton(typeof(IFigureSerializer), typeof(T));
		}


		private Form GetFormByView<T>()
			where T : IView
		{
			return _services
				.BuildServiceProvider()
				.GetService<T>()
				as Form;
		}

		private IPresenter GetPresenterByView<T>(IView sender)
			where T : IView
		{
			Type type = _viewPresenterDictionary[typeof(T)];
			var presenter = Activator.CreateInstance(type, sender);
			return presenter as IPresenter;
		}
	}
}
