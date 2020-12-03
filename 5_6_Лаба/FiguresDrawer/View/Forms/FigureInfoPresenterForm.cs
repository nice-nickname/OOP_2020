using FiguresDrawer.Model.Structures;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FiguresDrawer.View.Forms
{
	public partial class FigureInfoPresenterForm : Form, IFigureInfoPresenterView
	{
		public FigureInfoPresenterForm()
		{
			InitializeComponent();

			MinimumSize = MaximumSize = Size;
		}

		public void SetAreaInfo(double area)
		{
			areaLabel.Text = area.ToString();
		}

		public void SetPerimeterInfo(double perimeter)
		{
			perimeterLabel.Text = perimeter.ToString();
		}

		public void SetCenterInfo(Model.Structures.Point point)
		{
			centerLabel.Text = point.ToString();
		}

		public void ShowError(Exception e)
		{
			MessageBox.Show(e.Message + "\n" + e.TargetSite,
				"Ошибка FiguresInfoPresenterForm",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void ShowMessage(string message)
		{
			MessageBox.Show(message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		
		public void SetPoints(IEnumerable<Point> points)
		{
			pointsList.DataSource = points;
		}
	}
}
