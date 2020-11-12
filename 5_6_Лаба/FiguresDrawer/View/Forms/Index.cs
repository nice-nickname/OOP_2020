using FiguresDrawer.Presenter.Events;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FiguresDrawer.View.Forms
{
	public partial class Index : Form, IFiguresDrawerView
	{
		public ListBox FiguresListBox => figuresList;
		public decimal MouseWheelDelta { get; set; } = 0.2m;

		public event EventHandler<decimal> ScaleCanvas_ValueChenged;

		public event PaintEventHandler CanvasPaint;

		public event MouseEventHandler Mouse_Moving;
		public event MouseEventHandler Mouse_KeyUp;
		public event MouseEventHandler Mouse_KeyDown;

		public event EventHandler ModificateListButton_Click;
		public event EventHandler SettingsButton_Click;
		public event EventHandler HelpMeButton_Click;
		public event EventHandler<int> FiguresList_IndexChanged;
		public event EventHandler<int> ShowAboutFigure_Invoked;

		public Index()
		{
			InitializeComponent();

			canvasScaler.ValueChanged += Numeric_ValueChanged;
			canvas.MouseWheel += Canvas_MouseWheel;
		}

		public Size GetSize()
		{
			return canvas.Size;
		}

		public void InvokePaintEvent()
		{
			canvas.Refresh();
		}

		//----------------------------------------
		//	  Invokation events methods below
		// ---------------------------------------

		private void figuresList_SelectedIndexChanged(object sender, EventArgs e)
		{
			FiguresList_IndexChanged?.Invoke(sender, figuresList.SelectedIndex);
		}

		private void figuresList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ShowAboutFigure_Invoked?.Invoke(sender, figuresList.SelectedIndex);
		}

		private void toFactoryButton_Click(object sender, EventArgs e)
		{
			ModificateListButton_Click?.Invoke(sender, e);
		}

		private void toSettingsButton_Click(object sender, EventArgs e)
		{
			SettingsButton_Click?.Invoke(sender, e);
		}

		private void helpMeButton_Click(object sender, EventArgs e)
		{
			HelpMeButton_Click?.Invoke(sender, e);
		}

		private void Numeric_ValueChanged(object sender, EventArgs args)
		{
			ScaleCanvas_ValueChenged?.Invoke(sender, canvasScaler.Value);
		}

		private void Canvas_MouseWheel(object sender, MouseEventArgs e)
		{
			try
			{
				canvasScaler.Value += MouseWheelDelta * Math.Sign(e.Delta);
			}
			catch (Exception)
			{
				// Do nothing
			}
		}


		private void canvas_MouseHover(object sender, EventArgs e)
		{
			// Set focus on canvas for MouseWheel event invokation 
			canvas.Focus();
		}

		private void canvas_Paint(object sender, PaintEventArgs e)
		{
			CanvasPaint?.Invoke(sender, e);
		}

		private void canvas_MouseMove(object sender, MouseEventArgs e)
		{
			Mouse_Moving?.Invoke(sender, e);
		}

		private void canvas_MouseDown(object sender, MouseEventArgs e)
		{
			Mouse_KeyDown?.Invoke(sender, e);
		}

		private void canvas_MouseUp(object sender, MouseEventArgs e)
		{
			Mouse_KeyUp?.Invoke(sender, e);
		}

		// ---------------------------

		public void ShowError(Exception e)
		{
			MessageBox.Show(e.Message + "\n" + e.TargetSite,
				"Ошибка FiguresDrawerForm",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void ShowMessage(string message)
		{
			MessageBox.Show(message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
