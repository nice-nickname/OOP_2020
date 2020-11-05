using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiguresDrawer.View.Forms
{
	public partial class FiguresSettingsForm : Form, IFiguresSettingsView
	{
		public FiguresSettingsForm()
		{
			InitializeComponent();
		}

		public event EventHandler SaveAndExitButton_Click;

		public CheckedListBox GetCheckedList()
		{
			return figiresToDrawCheckBox;
		}

		public void ShowError(string message)
		{
			MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void ShowMessage(string message)
		{
			MessageBox.Show(message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void saveAndExitVutton_Click(object sender, EventArgs e)
		{
			SaveAndExitButton_Click?.Invoke(sender, e);
			Close();
		}
	}
}
