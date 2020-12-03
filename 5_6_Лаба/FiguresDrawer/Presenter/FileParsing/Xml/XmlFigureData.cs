using System;

namespace FiguresDrawer.Presenter.FileParsing.Xml
{
	[Serializable]
	public class XmlFigureData
	{
		public Model.Structures.Point[] Points { get; set; }
		public string PenColorName { get; set; }
		public string VertexColorName { get; set; }
		public string CenterColorName { get; set; }

		public XmlFigureData(Model.Structures.Point[] points,
							string penColorName, string vertexColorName, string centerColorName)
		{
			Points = points;
			PenColorName = penColorName;
			VertexColorName = vertexColorName;
			CenterColorName = centerColorName;
		}
	}
}
