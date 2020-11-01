using FiguresDrawer.Presenter.Adapter;
using System.Drawing;

namespace FiguresDrawer.Presenter.Drawing
{
	public class FigureDrawer
	{
		public IFigureAdapter figure;
		public Color PenColor { get; set; }

		public FigureDrawer(IFigureAdapter figure, Color penColor)
		{
			this.figure = figure;
			PenColor = penColor;
		}

		public void Draw(Graphics G, float width)
		{
			G.DrawPolygon(new Pen(PenColor, width), figure.GetPoints());
		}

		public override string ToString()
		{
			return figure.ToString() + " " + PenColor.ToString();
		}
	}
}
