using FiguresDrawer.Model.Factories;
using FiguresDrawer.Presenter.Adapter;
using FiguresDrawer.Presenter.Drawing;
using FiguresDrawer.Presenter.FileParsing.Xml;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace FiguresDrawer.Presenter.FileParsing
{
	internal class XmlFigureSerializer : IFigureSerializer
	{

		private static HashSet<string> ColorNames;

		public XmlFigureSerializer()
		{
			if (ColorNames == null)
			{
				ColorNames = typeof(Color)
					.GetProperties()
					.Where(x => x.PropertyType == typeof(Color))
					.Select(x => x.Name)
					.ToHashSet();
			}
		}

		public IEnumerable<FigureDrawer> Deserialize(string fileName)
		{
			StreamReader stream = new StreamReader(fileName);
			XmlSerializer xml = new XmlSerializer(typeof(List<XmlFigureData>));

			FigurePointsFactory factory = new FigurePointsFactory();
			List<FigureDrawer> figures = new List<FigureDrawer>();

			var data = xml.Deserialize(stream);

			foreach (var item in data as List<XmlFigureData>)
			{
				var figure = factory.Create(item.Points);
				var adapter = new FiguresDataAdapter(figure);

				Color vertexColor = Color.FromName(ValidateColorName(item.VertexColorName));
				Color centerColor = Color.FromName(ValidateColorName(item.CenterColorName));
				Color penColor	  = Color.FromName(ValidateColorName(item.PenColorName));

				var drawer = new FigureDrawer(adapter, penColor, vertexColor, centerColor);

				figures.Add(drawer);
			}

			return figures;
		}

		public void Serialize(IEnumerable<FigureDrawer> figures, string fileName)
		{
			StreamWriter stream = new StreamWriter(fileName);
			XmlSerializer xml = new XmlSerializer(typeof(List<XmlFigureData>));

			List<XmlFigureData> data = new List<XmlFigureData>();

			foreach (var figure in figures)
			{
				data.Add(new XmlFigureData(
					figure.Adapter.GetRawPoints(),
					figure.PenColor.Name,
					figure.VertexColor.Name,
					figure.CenterColor.Name));
			}

			xml.Serialize(stream, data);
		}

		private string ValidateColorName(string name)
		{
			if (ColorNames.Contains(name))
			{
				return name;
			}
			else
			{
				throw new System.Exception("Invalid colorName " + name);
			}
		}
	}
}
