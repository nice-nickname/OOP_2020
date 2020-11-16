using FiguresDrawer.Presenter.Adapter;
using System.Drawing;

namespace FiguresDrawer.Presenter.Drawing
{
	public class FigureDrawer
	{
		public IFigureAdapter Adapter { get; set; }
		public Color PenColor { get; set; }
		public Color VertexColor { get; set; }
		public Color CenterColor { get; set; }

		public FigureDrawer(IFigureAdapter figure, Color penColor, Color vertexColor, Color centerColor)
		{
			Adapter = figure;
			PenColor = penColor;
			VertexColor = vertexColor;
			CenterColor = centerColor;
		}

		public void Draw(Graphics G, float width, FigureDrawerSettings settings)
		{
			G.DrawPolygon(new Pen(PenColor, width), Adapter.GetPoints());


			if (settings.DrawCenterNeeded || settings.DrawVerticesNeeded)
			{
				width *= 2f;
				float pointWidth = width * 1f;
				float offset = pointWidth / 2;

				if (settings.DrawVerticesNeeded)
				{
					foreach (var point in Adapter.GetPoints())
					{
						DrawPoint(G, point, width, pointWidth, offset);
					}
				}

				if (settings.DrawCenterNeeded)
				{
					DrawPoint(G, Adapter.GetCenter(), width, pointWidth, offset);
				}
			}
		}

		public void DrawPoint(Graphics G, PointF p, float width, float pointWidth, float offset)
		{
			G.DrawRectangle(new Pen(VertexColor, width), p.X - offset, p.Y - offset, pointWidth, pointWidth);
		}

		public override string ToString()
		{
			return Adapter.ToString() + " " + PenColor.ToString();
		}
	}
}
