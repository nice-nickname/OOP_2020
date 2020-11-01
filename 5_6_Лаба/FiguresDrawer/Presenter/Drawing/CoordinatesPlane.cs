using FiguresDrawer.Model;
using FiguresDrawer.Model.Figures;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FiguresDrawer.Presenter.Drawing
{
	public class CoordinatesPlane
	{
		private Size _size;
		private Graphics _G;

		public float ScaleFactor { get; set; }
		public int GridStep { get; set; }

		public PointF MoveOnDeltaFactor { get; set; }

		private Pen _axisPen;
		private Pen _linesPen;

		private float __drawingBorder; // Костыль

		public CoordinatesPlane(Size size)
		{
			_size = size;
			ScaleFactor = 1f;

			MoveOnDeltaFactor = new PointF(_size.Width / 2, _size.Height / 2);
			GridStep = 100;
			__drawingBorder = 2500;

			_axisPen = new Pen(Color.Black, 1 / ScaleFactor);
			_linesPen = new Pen(Color.LightGray, 1 / ScaleFactor);
		}


		public void Draw(Graphics G, IEnumerable figures)
		{
			_G = G;
			Scale();
			MovePlane();
			DrawGrid();
			DrawAxis();
			DrawFigures(figures);
		}

		private void Scale()
		{
			_G.ScaleTransform(ScaleFactor, -ScaleFactor);
			_axisPen.Width = 1 / ScaleFactor;
			_linesPen.Width = 1 / ScaleFactor;
		}

		private void MovePlane()
		{
			_G.TranslateTransform(MoveOnDeltaFactor.X,
								  MoveOnDeltaFactor.Y,
								  System.Drawing.Drawing2D.MatrixOrder.Append);
		}

		private void DrawAxis()
		{
			_G.DrawLine(_axisPen, 0, _size.Height - __drawingBorder, 0, -_size.Height + __drawingBorder);
			_G.DrawLine(_axisPen, _size.Width - __drawingBorder, 0, -_size.Width + __drawingBorder, 0);
		}

		private void DrawGrid()
		{
			float from = -_size.Width - MoveOnDeltaFactor.X;
			float to = _size.Width - MoveOnDeltaFactor.X;

			float start, end;

			start = 0 - _size.Height / 2 - __drawingBorder;
			end = 0 + _size.Height / 2 + __drawingBorder;

			for (float i = start; i <= end; i += GridStep)
			{
				_G.DrawLine(_linesPen, from, i, to, i);
			}

			from = -_size.Height - MoveOnDeltaFactor.Y;
			to = _size.Height - -MoveOnDeltaFactor.Y;

			start = 0 - _size.Width / 2 - 2500;
			end = 0 + _size.Width / 2 + 2500;

			for (float i = start; i < end; i += GridStep)
			{
				_G.DrawLine(_linesPen, i, from, i, to);
			}

		}

		private void DrawFigures(IEnumerable figures)
		{
			foreach (var figure in figures)
			{
				var drawer = (figure as FigureDrawer);
				var width = 1 / ScaleFactor;

				drawer.Draw(_G, width);
			}
		}
	}
}
