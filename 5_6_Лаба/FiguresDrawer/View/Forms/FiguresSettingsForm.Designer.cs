namespace FiguresDrawer.View.Forms
{
	partial class FiguresSettingsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.drawingGroup = new System.Windows.Forms.GroupBox();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.drawingGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// drawingGroup
			// 
			this.drawingGroup.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.drawingGroup.Controls.Add(this.checkedListBox1);
			this.drawingGroup.Location = new System.Drawing.Point(12, 12);
			this.drawingGroup.Name = "drawingGroup";
			this.drawingGroup.Size = new System.Drawing.Size(212, 260);
			this.drawingGroup.TabIndex = 0;
			this.drawingGroup.TabStop = false;
			this.drawingGroup.Text = "Координатная плоскость";
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(6, 19);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(120, 94);
			this.checkedListBox1.TabIndex = 0;
			// 
			// FiguresSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 405);
			this.Controls.Add(this.drawingGroup);
			this.Name = "FiguresSettingsForm";
			this.Text = "SettingsForm";
			this.drawingGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox drawingGroup;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
	}
}