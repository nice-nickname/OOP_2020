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
			colorChooseComboBox.DataSource = typeof(Color).GetProperties()
										.Where(x => x.PropertyType == typeof(Color))
										.Select(x => x.GetValue(null)).ToList();
			colorChooseComboBox.SelectedItem = Color.Red;
		}

		public ListBox.ObjectCollection PointsBuffer => pointsList.Items;
		public ListBox.ObjectCollection FiguresBuffer => figuresList.Items;


		public event EventHandler OnReadFromFileButton_Click;
		public event EventHandler OnCreateFigureButton_Click;
		public event EventHandler OnClearPointsButton_Click;

		public event EventHandler<int> OnDeleteFigureButton_Click;

		public event Action<object, string, string> OnAddPointButton_Click;

		public Color GetSelectedColor()
		{
			return (Color)colorChooseComboBox.SelectedItem;
		}
		
		
		//----------------------------------------
		//	  Invokation events methods below
		// ---------------------------------------


		private void readFromFileButton_Click(object sender, EventArgs e)
		{
			OnReadFromFileButton_Click?.Invoke(sender, e);
		}

		private void addPointButton_Click(object sender, EventArgs e)
		{
			OnAddPointButton_Click?.Invoke(this, inputTextBoxX.Text, inputTextBoxY.Text);
		}

		private void clearDotsListButton_Click(object sender, EventArgs e)
		{
			OnClearPointsButton_Click?.Invoke(sender, e);
		}

		private void addFigureButton_Click(object sender, EventArgs e)
		{
			OnCreateFigureButton_Click?.Invoke(sender, e);
		}

		private void deleteFigure_Click(object sender, EventArgs e)
		{
			OnDeleteFigureButton_Click?.Invoke(sender, figuresList.SelectedIndex);
		}

		private void exitButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		public void ShowError(string message)
		{
			MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void ShowMessage(string message)
		{
			MessageBox.Show(message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

	}
}
