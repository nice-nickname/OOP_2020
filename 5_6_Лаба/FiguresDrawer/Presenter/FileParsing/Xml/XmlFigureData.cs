using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace FiguresDrawer.Presenter.FileParsing.Xml
{
	[Serializable]
	public class XmlFigureData
	{
		public XmlFigureData()
		{
			Points = null;
			PenColorName = "Red";
			VertexColorName = "Black";
			CenterColorName = "Black";
		}

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
