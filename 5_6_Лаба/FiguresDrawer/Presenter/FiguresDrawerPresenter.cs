using FiguresDrawer.Presenter.Drawing;
using FiguresDrawer.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FiguresDrawer.Presenter
{
	public class FiguresDrawerPresenter : IPresenter
	{
		private bool _mouseButtonPressed;          // Move on coordinate plane only while mouse key pressed

		private float _beginX;          // start points to calculate offset when moving
		private float _beginY;          //

		private float _dx;              // end points to calculate offset when moving
		private float _dy;              //

		private IFiguresDrawerView _view;
		private FigureDrawerContainer _model;
		private CoordinatesPlane _plane;

		public FiguresDrawerPresenter(IFiguresDrawerView view)
		{
			_view = view;
			_model = new FigureDrawerContainer(_view.FiguresListBox);

			Size size = _view.GetSize();

			_view.ModificateListButton_Click += View_ModificateListButton_Click;
			_view.ScaleCanvas_ValueChenged	 += View_ScaleCanvas_ValueChanged;
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

			_plane = new CoordinatesPlane(_view.GetSize());
		}

		private void Paint(object sender, PaintEventArgs args)
		{
			_plane.Draw(args.Graphics, _model.GetEnumerable());
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
			var app = App.FormFactory.Create<IFiguresCreatorView>();
			app.View.ShowDialog();
			_view.InvokePaintEvent();
		}

		private void View_SettingsButton_Click(object sender, EventArgs e)
		{
			var app = App.FormFactory.Create<IFiguresAppSettingsView>();
			app.View.ShowDialog();
			_view.InvokePaintEvent();
		}

		private void View_HelpMeButton_Click(object sender, EventArgs e)
		{
			// TODO: TODOs
		}
	}
}
