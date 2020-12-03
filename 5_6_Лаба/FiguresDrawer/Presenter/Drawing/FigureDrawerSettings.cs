namespace FiguresDrawer.Presenter.Drawing
{
	public class FigureDrawerSettings
	{
		public bool DrawVerticesNeeded { get; set; }
		public bool DrawCenterNeeded { get; set; }

		public FigureDrawerSettings(bool drawVertices, bool drawCenter)
		{
			DrawVerticesNeeded = drawVertices;
			DrawCenterNeeded = drawCenter;
		}

	}
}
