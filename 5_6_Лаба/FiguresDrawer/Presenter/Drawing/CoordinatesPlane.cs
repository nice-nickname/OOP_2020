using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FiguresDrawer.Presenter.Drawing
{
	public class CoordinatesPlane
	{
		private Size _size;

		private PlaneSettings _settings;
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


		public void Draw(Graphics G, IEnumerable<FigureDrawer> figures, PlaneSettings settings)
		{
			_G = G;
			_settings = settings;
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
			// Calculating left and right border's coordinates on X axis
			float from = (-_size.Width - MoveOnDeltaFactor.X) / ScaleFactor;
			float to = (_size.Width - MoveOnDeltaFactor.X) / ScaleFactor;

			float start, end;

			// TODO: Сделать по-человечески
			start = 0 - _size.Height / 2 - __drawingBorder;
			end = 0 + _size.Height / 2 + __drawingBorder;

			//Draw horizontal lines
			for (float i = start; i <= end; i += GridStep)
			{
				_G.DrawLine(_linesPen, from, i, to, i);
			}

			// Calculating top and botton border's coordinates on Y axis
			from = (-_size.Height + MoveOnDeltaFactor.Y) / ScaleFactor;
			to = (_size.Height + MoveOnDeltaFactor.Y) / ScaleFactor;

			start = 0 - _size.Width / 2 - __drawingBorder;
			end = 0 + _size.Width / 2 + __drawingBorder;

			// Draw vertival lines
			for (float i = start; i < end; i += GridStep)
			{
				_G.DrawLine(_linesPen, i, from, i, to);
			}
		}

		private void DrawFigures(IEnumerable<FigureDrawer> figures)
		{
			var outFigures = figures
				.Where(x => _settings.TypesToDraw.Contains(x.Adapter.FigureType));

			float width = 1 / ScaleFactor;

			foreach (var figure in outFigures)
			{
				figure.Draw(_G, width, _settings.DrawerSettings);
			}
		}
	}
}
