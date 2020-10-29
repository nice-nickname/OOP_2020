using FiguresDrawer.Presenter.Adapter;
using FiguresDrawer.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FiguresDrawer.Presenter
{
	public class FiguresDrawerPresenter : IPresenter
	{
		private float _scale = 1f;      // Current scale of coordinates plane
		
		private Size _size;             // Size of canvas

		private bool _pressed;          // Move on coordinate plane only while mouse key pressed

		private float _beginX;          // start points to calculate offset when moving
		private float _beginY;          //

		private float _dx;              // end points to calculate offset when moving
		private float _dy;              //

		private IFiguresDrawerView _view;

		public FiguresDrawerPresenter(IFiguresDrawerView view)
		{
			_view = view;

			_size = _view.GetSize();

			_view.ModificateListButton_Click += View_ModificateListButton_Click;
			_view.ScaleCanvas_ValueChenged	 += View_ScaleCanvas_ValueChanged;
			_view.SettingsButton_Click		 += View_SettingsButton_Click;
			_view.HelpMeButton_Click		 += View_HelpMeButton_Click;
			_view.CanvasPaint				 += Paint;

			_view.Mouse_Moving	 += View_OnMouseMoving;
			_view.Mouse_KeyUp	 += View_Mouse_KeyUp;
			_view.Mouse_KeyDown	 += View_Mouse_KeyDown;

			_view.FiguresList_IndexChanged += View_FiguresList_IndexChanged;

			_dx = _size.Width / 2;
			_dy = _size.Height / 2;
			_beginX = 0;
			_beginY = 0;
			_pressed = false;

		}

		private void Paint(object sender, PaintEventArgs args)
		{
			Graphics G = args.Graphics;

			Scale(G);
			TranslateOnMove(G);
			DrawAxis(G);
			RedrawCanvas(G);
		}

		private void Scale(Graphics G)
		{
			G.ScaleTransform(_scale, _scale);
		}

		private void TranslateOnMove(Graphics G)
		{
			G.TranslateTransform(_dx, _dy, System.Drawing.Drawing2D.MatrixOrder.Append);
		}

		private void RedrawCanvas(Graphics G)
		{
			foreach (var item in _view.Figures)
			{
				(item as FigureDrawer).Draw(G, 1 / _scale);
			}
		}

		private void DrawAxis(Graphics G)
		{
			G.DrawLine(new Pen(Color.Black, 1 / _scale), 0, _size.Height, 0, -_size.Height);
			G.DrawLine(new Pen(Color.Black, 1 / _scale), _size.Width, 0, -_size.Width, 0);
		}

		// ----------------------------------
		//		Methods-subscribers below
		// ----------------------------------

		private void View_OnMouseMoving(object sender, MouseEventArgs e)
		{
			if (_pressed)
			{
				_dx += (e.X - _beginX);
				_dy += (e.Y - _beginY);
				_beginX = e.X;
				_beginY = e.Y;

				_view.InvokePaintEvent();
			}
		}

		private void View_Mouse_KeyDown(object sender, MouseEventArgs e)
		{
			_pressed = true;
			_beginX = e.X;
			_beginY = e.Y;
		}

		private void View_Mouse_KeyUp(object sender, MouseEventArgs e)
		{
			_pressed = false;
		}

		private void View_FiguresList_IndexChanged(object sender, int index)
		{
			if (index >= 0)
			{
				var figureView = _view.Figures[index] as FigureDrawer;

				try
				{
					double area = figureView.figure.GetArea();
					double perimeter = figureView.figure.GetPerimeter();

					_view.PerimeterTextLabel.Text = "P = " + perimeter.ToString();
					_view.AreaTextLabel.Text = "S = " + area.ToString();
				}
				catch (Exception)
				{
					_view.PerimeterTextLabel.Text = "S = NaN";
					_view.AreaTextLabel.Text = "P = NaN";
				}
			}
			else
			{
				_view.PerimeterTextLabel.Text = string.Empty;
				_view.AreaTextLabel.Text = string.Empty;
			}
		}

		private void View_ScaleCanvas_ValueChanged(object sender, decimal scale)
		{
			_scale = (float)scale;
			_view.InvokePaintEvent();
		}

		private void View_ModificateListButton_Click(object sender, EventArgs e)
		{
			var form = App.FormFactory.Create<IFiguresCreatorView>(_view);
			form.View.ShowDialog();
			_view.InvokePaintEvent();
		}

		private void View_SettingsButton_Click(object sender, EventArgs e)
		{
			var form = App.FormFactory.Create<IFiguresAppSettingsView>(_view);
			form.View.ShowDialog();
			_view.InvokePaintEvent();
		}

		private void View_HelpMeButton_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

	}
}
