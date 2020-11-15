using System;
using System.Windows.Forms;

namespace FiguresDrawer.View.Forms
{
	public partial class FiguresSettingsForm : Form, IFiguresSettingsView
	{
		public event EventHandler SaveAndExitButton_Click;


		public FiguresSettingsForm()
		{
			InitializeComponent();

			MinimumSize = MaximumSize = Size;
		}


		public CheckBox DrawCenterCheckBox()
		{
			return drawCenterCheckBox;
		}

		public CheckBox DrawVerticesCheckBox()
		{
			return drawVertexCheckBox;
		}

		public CheckedListBox GetCheckedList()
		{
			return figiresToDrawCheckBox;
		}

		private void saveAndExitVutton_Click(object sender, EventArgs e)
		{
			SaveAndExitButton_Click?.Invoke(sender, e);
			Close();
		}
		public void ShowError(Exception e)
		{
			MessageBox.Show(e.Message + "\n" + e.TargetSite,
				"Ошибка FiguresSettingsrForm",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void ShowMessage(string message)
		{
			MessageBox.Show(message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
