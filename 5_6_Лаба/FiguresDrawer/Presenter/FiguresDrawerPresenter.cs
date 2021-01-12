using FiguresDrawer.App.Core;
using FiguresDrawer.Presenter.Drawing;
using FiguresDrawer.Presenter.Events;
using FiguresDrawer.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FiguresDrawer.Presenter
{
	public class FiguresDrawerPresenter : IPresenter
	{
		private bool _mouseButtonPressed;

		private float _beginX;          // start points to calculate offset when moving
		private float _beginY;          //

		private float _dx;              // current offset
		private float _dy;              //

		private IFiguresDrawerView _view;
		private ListBox.ObjectCollection _model;

		private PlaneSettings _planeSettings;
		private CoordinatesPlane _plane;

		public event Action<IPresenter, EventArgs> SendData;

		public FiguresDrawerPresenter(IFiguresDrawerView view, IEnumerable<Type> originFigureTypes)
		{
			_view = view;
			_model = new ListBox.ObjectCollection(_view.FiguresListBox);

			Size size = _view.GetSize();

			_view.ModificateListButton_Click += View_ModificateListButton_Click;
			_view.ScaleCanvas_ValueChenged	 += View_ScaleCanvas_ValueChanged;
			_view.ShowAboutFigure_Invoked	 += View_ShowAboutFigure_Invoked;
			_view.SettingsButton_Click		 += View_SettingsButton_Click;
			_view.HelpMeButton_Click		 += View_HelpMeButton_Click;
			_view.CanvasPaint				 += Paint;

			_view.Mouse_Moving	 += View_OnMouseMoving;
			_view.Mouse_KeyUp	 += View_Mouse_KeyUp;
			_view.Mouse_KeyDown	 += View_Mouse_KeyDown;

			_dx = size.Width / 2;
			_dy = size.Height / 2;
			_beginX = 0;
			_beginY = 0;

			_mouseButtonPressed = false;

			_planeSettings = new PlaneSettings(originFigureTypes, new FigureDrawerSettings(true,true));
			_plane = new CoordinatesPlane(_view.GetSize());
		}

		private void Paint(object sender, PaintEventArgs args)
		{
			_plane.Draw(args.Graphics, _model.Cast<FigureDrawer>(), _planeSettings);
		}


		// ----------------------------------
		//		Methods-subscribers below
		// ----------------------------------


		private void View_OnMouseMoving(object sender, MouseEventArgs e)
		{
			if (_mouseButtonPressed)
			{
				_dx += (e.X - _beginX);
				_dy += (e.Y - _beginY);
				_beginX = e.X;
				_beginY = e.Y;

				_plane.MoveOnDeltaFactor = new PointF(_dx, _dy);
				_view.InvokePaintEvent();
			}
		}

		private void View_Mouse_KeyDown(object sender, MouseEventArgs e)
		{
			_mouseButtonPressed = true;
			_beginX = e.X;
			_beginY = e.Y;
		}

		private void View_Mouse_KeyUp(object sender, MouseEventArgs e)
		{
			_mouseButtonPressed = false;
		}

		private void View_ScaleCanvas_ValueChanged(object sender, decimal scale)
		{
			_plane.ScaleFactor = (float)scale;
			_view.InvokePaintEvent();
		}

		private void View_ModificateListButton_Click(object sender, EventArgs e)
		{
			try
			{
				var form = AppDependencies.CreateForm<IFiguresCreatorView>(this);

				SendData?.Invoke(this, new FigureDrawnEventArgs(_model, _planeSettings, null));
				SendData = null;

				form.View.ShowDialog();
				_view.InvokePaintEvent();
			}
			catch (Exception err)
			{
				_view.ShowError(err);
			}
		}

		private void View_SettingsButton_Click(object sender, EventArgs e)
		{
			try
			{
				var form = AppDependencies.CreateForm<IFiguresSettingsView>(this);

				SendData?.Invoke(this, new FigureDrawnEventArgs(_model, _planeSettings, null));
				SendData = null;

				form.View.ShowDialog();
				_view.InvokePaintEvent();
			}
			catch (Exception err)
			{
				_view.ShowError(err);
			}
		}

		private void View_ShowAboutFigure_Invoked(object sender, int index)
		{	
			if (index >= 0)
			{
				try
				{
					var form = AppDependencies.CreateForm<IFigureInfoPresenterView>(this);

					SendData?.Invoke(this, new FigureDrawnEventArgs(null, null, _model[index] as FigureDrawer));
					SendData = null;

					form.View.Show();
					_view.InvokePaintEvent();
				}
				catch (Exception err)
				{
					_view.ShowError(err);
				}
			}
		}

		private void View_HelpMeButton_Click(object sender, EventArgs e)
		{
			_view.ShowMessage(
				"Приложение состоит из нескольких форм. На данной форме есть координатная плоскость"
				+ " по которой можно перемещаться, нажав кнопку мыши и потянув в сторону."
				+ " С помощью колесика мыши можно регулировать масштаб."
				+ " Справа от плоскости есть список фигур. По двойному нажатию на фигуру откроется окно с информацией о ней"
				+ " Кнопка 'Создать фигуру' открывает форму создания фигуры, где из точек строится фигура."
				+ " Есть возможность сереализовать и десереализовать фигуру из определенного формата (Пока что XML)"
				+ " Кнопка настройки отвечает за разные настройки плоскости и формы."
				);
		}

		public void ReceiveData(IPresenter sender, EventArgs args)
		{
			throw new NotImplementedException();
		}
	}
}
