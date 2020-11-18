using FiguresDrawer.App;
using FiguresDrawer.App.Core;
using FiguresDrawer.Model.Figures;
using FiguresDrawer.Presenter;
using FiguresDrawer.Presenter.FileParsing;
using FiguresDrawer.View;
using FiguresDrawer.View.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

			var types = new List<Type>
			{
				typeof(Rectangle),
				typeof(Triangle),
				typeof(Segment),
				typeof(Polygon)
			};

			var app = new AppDependencyContainer();

			app.RegisterStartForm<IFiguresDrawerView, Index, FiguresDrawerPresenter>();
			app.RegisterFiguresTypes(types);

			app.RegisterFigureSerialuzer<XmlFigureSerializer>();

			app.RegisterForm<IFiguresCreatorView, FiguresCreatorForm, FiguresCreatorPresenter>();
			app.RegisterForm<IFiguresSettingsView, FiguresSettingsForm, FiguresSettingsPresenter>();
			app.RegisterForm<IFigureInfoPresenterView, FigureInfoPresenterForm, FigureInfoPresenter>();

			AppDependencies.Initialize(app);

			var form = AppDependencies.CreateStartForm();
			
			Application.Run(form.View);
		}
	}
}
