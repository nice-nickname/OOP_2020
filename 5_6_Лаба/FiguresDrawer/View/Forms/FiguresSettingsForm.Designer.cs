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
			this.drawCenterCheckBox = new System.Windows.Forms.CheckBox();
			this.drawVertexCheckBox = new System.Windows.Forms.CheckBox();
			this.figiresToDrawCheckBox = new System.Windows.Forms.CheckedListBox();
			this.saveAndExitVutton = new System.Windows.Forms.Button();
			this.drawingGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// drawingGroup
			// 
			this.drawingGroup.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.drawingGroup.Controls.Add(this.drawCenterCheckBox);
			this.drawingGroup.Controls.Add(this.drawVertexCheckBox);
			this.drawingGroup.Controls.Add(this.figiresToDrawCheckBox);
			this.drawingGroup.Location = new System.Drawing.Point(12, 12);
			this.drawingGroup.Name = "drawingGroup";
			this.drawingGroup.Size = new System.Drawing.Size(266, 286);
			this.drawingGroup.TabIndex = 0;
			this.drawingGroup.TabStop = false;
			this.drawingGroup.Text = "Настройки";
			// 
			// drawCenterCheckBox
			// 
			this.drawCenterCheckBox.AutoSize = true;
			this.drawCenterCheckBox.Location = new System.Drawing.Point(6, 139);
			this.drawCenterCheckBox.Name = "drawCenterCheckBox";
			this.drawCenterCheckBox.Size = new System.Drawing.Size(139, 17);
			this.drawCenterCheckBox.TabIndex = 3;
			this.drawCenterCheckBox.Text = "Рисовать центр фигур";
			this.drawCenterCheckBox.UseVisualStyleBackColor = true;
			// 
			// drawVertexCheckBox
			// 
			this.drawVertexCheckBox.AutoSize = true;
			this.drawVertexCheckBox.Location = new System.Drawing.Point(6, 116);
			this.drawVertexCheckBox.Name = "drawVertexCheckBox";
			this.drawVertexCheckBox.Size = new System.Drawing.Size(154, 17);
			this.drawVertexCheckBox.TabIndex = 2;
			this.drawVertexCheckBox.Text = "Рисовать точки-вершины";
			this.drawVertexCheckBox.UseVisualStyleBackColor = true;
			// 
			// figiresToDrawCheckBox
			// 
			this.figiresToDrawCheckBox.CheckOnClick = true;
			this.figiresToDrawCheckBox.FormattingEnabled = true;
			this.figiresToDrawCheckBox.Location = new System.Drawing.Point(6, 30);
			this.figiresToDrawCheckBox.Name = "figiresToDrawCheckBox";
			this.figiresToDrawCheckBox.Size = new System.Drawing.Size(254, 79);
			this.figiresToDrawCheckBox.TabIndex = 1;
			// 
			// saveAndExitVutton
			// 
			this.saveAndExitVutton.Location = new System.Drawing.Point(75, 304);
			this.saveAndExitVutton.Name = "saveAndExitVutton";
			this.saveAndExitVutton.Size = new System.Drawing.Size(122, 23);
			this.saveAndExitVutton.TabIndex = 1;
			this.saveAndExitVutton.Text = "Сохранить и выйти";
			this.saveAndExitVutton.UseVisualStyleBackColor = true;
			this.saveAndExitVutton.Click += new System.EventHandler(this.saveAndExitVutton_Click);
			// 
			// FiguresSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(299, 334);
			this.Controls.Add(this.saveAndExitVutton);
			this.Controls.Add(this.drawingGroup);
			this.Name = "FiguresSettingsForm";
			this.Text = "SettingsForm";
			this.drawingGroup.ResumeLayout(false);
			this.drawingGroup.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox drawingGroup;
		private System.Windows.Forms.CheckedListBox figiresToDrawCheckBox;
		private System.Windows.Forms.Button saveAndExitVutton;
		private System.Windows.Forms.CheckBox drawCenterCheckBox;
		private System.Windows.Forms.CheckBox drawVertexCheckBox;
	}
}