using FiguresDrawer.App;
using FiguresDrawer.App.Core;
using FiguresDrawer.Model.Figures;
using FiguresDrawer.Presenter;
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

			List<Type> types = new List<Type>
			{
				typeof(Rectangle),
				typeof(Triangle),
				typeof(Segment),
				typeof(Polygon)
			};

			AppDependencyContainer app = new AppDependencyContainer(types);

			app.RegisterStartForm<IFiguresDrawerView, Index, FiguresDrawerPresenter>();

			app.RegisterForm<IFiguresCreatorView, FiguresCreatorForm, FiguresCreatorPresenter>();
			app.RegisterForm<IFiguresSettingsView, FiguresSettingsForm, FiguresSettingsPresenter>();
			app.RegisterForm<IFigureInfoPresenterView, FigureInfoPresenterForm, FigureInfoPresenter>();

			FormsFactory.Initialize(app);

			var form = FormsFactory.CreateStartForm();
			
			Application.Run(form.View);
		}
	}
}
