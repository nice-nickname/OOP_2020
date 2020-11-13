using FiguresDrawer.App.Core;
using FiguresDrawer.Model.Figures;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;
using FiguresDrawer.Presenter.FileParsing;
using FiguresDrawer.App;
using FiguresDrawer.Presenter.Adapter;
using FiguresDrawer.View.Forms;
using FiguresDrawer.View;
using FiguresDrawer.Presenter;

namespace FiguresDrawer
{
	// TODO: Возможно поправить grid

	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			List<Type> types = new List<Type>
			{
				typeof(Rectangle),
				typeof(Triangle),
				typeof(Segment),
				typeof(Polygon)
			};

			AppManager app = new AppManager();
			app.RegisterStartForm<IFiguresDrawerView, Index, FiguresDrawerPresenter>();

			app.RegisterForm<IFiguresCreatorView, FiguresCreatorForm, FiguresCreatorPresenter>();
			app.RegisterForm<IFiguresSettingsView, FiguresSettingsForm, FiguresSettingsPresenter>();
			app.RegisterForm<IFigureInfoPresenterView, FigureInfoPresenterForm, FigureInfoPresenter>();

			FormsFactory.CreateApp(types, app);

			var form = FormsFactory.CreateStartForm();
			
			Application.Run(form.View);
		}
	}
}
