using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FiguresDrawer.View.Forms
{
	public partial class FiguresCreatorForm : Form, IFiguresCreatorView
	{
		public FiguresCreatorForm()
		{
			InitializeComponent();
			colorChooseComboBox.DataSource = 
										typeof(Color)
										.GetProperties()
										.Where(x => x.PropertyType == typeof(Color))
										.Select(x => x.GetValue(null))
										.ToList()
										;

			colorChooseComboBox.SelectedItem = Color.Red;

			MinimumSize = MaximumSize = Size;
		}

		public ListBox.ObjectCollection PointsBuffer => pointsList.Items;
		public ListBox.ObjectCollection FiguresBuffer => figuresList.Items;

		public event EventHandler ReadFromFileButton_Click;
		public event EventHandler CreateFigureButton_Click;
		public event EventHandler WriteToFileButton_Click;
		public event EventHandler ClearPointsButton_Click;

		public event EventHandler<int> DeleteFigureButton_Click;
		public event EventHandler<int> FigureList_IndexChanged;

		public event Action<object, int, string, string> EditPointButton_Click;
		public event Action<object, string, string> AddPointButton_Click;

		public Color GetSelectedColor()
		{
			return (Color)colorChooseComboBox.SelectedItem;
		}
		
		
		//----------------------------------------
		//	  Invokation events methods below
		// ---------------------------------------


		private void readFromFileButton_Click(object sender, EventArgs e)
		{
			ReadFromFileButton_Click?.Invoke(sender, e);
		}

		private void writeToFileButton_Click(object sender, EventArgs e)
		{
			WriteToFileButton_Click?.Invoke(sender, e);
		}

		private void addPointButton_Click(object sender, EventArgs e)
		{
			AddPointButton_Click?.Invoke(this, inputTextBoxX.Text, inputTextBoxY.Text);
		}

		private void clearDotsListButton_Click(object sender, EventArgs e)
		{
			ClearPointsButton_Click?.Invoke(sender, e);
		}

		private void addFigureButton_Click(object sender, EventArgs e)
		{
			CreateFigureButton_Click?.Invoke(sender, e);
		}

		private void deleteFigure_Click(object sender, EventArgs e)
		{
			DeleteFigureButton_Click?.Invoke(sender, figuresList.SelectedIndex);
		}

		private void figuresList_SelectedIndexChanged(object sender, EventArgs e)
		{
			FigureList_IndexChanged?.Invoke(sender, figuresList.SelectedIndex);
		}

		private void exitButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		public void ShowError(Exception e)
		{
			MessageBox.Show(e.Message + "\n" + e.TargetSite,
				"Ошибка FiguresSettingsForm",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void ShowMessage(string message)
		{
			MessageBox.Show(message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void editSelectedButton_Click(object sender, EventArgs e)
		{
			EditPointButton_Click?.Invoke(
				sender,
				pointsList.SelectedIndex,
				inputTextBoxX.Text,
				inputTextBoxY.Text);
		}
	}
}
