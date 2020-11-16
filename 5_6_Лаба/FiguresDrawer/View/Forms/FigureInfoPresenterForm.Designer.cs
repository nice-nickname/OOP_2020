namespace FiguresDrawer.View.Forms
{
	partial class FigureInfoPresenterForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.areaLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.perimeterLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.centerLabel = new System.Windows.Forms.Label();
			this.pointsList = new System.Windows.Forms.ListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Площадь:";
			// 
			// areaLabel
			// 
			this.areaLabel.AutoSize = true;
			this.areaLabel.Location = new System.Drawing.Point(87, 10);
			this.areaLabel.Name = "areaLabel";
			this.areaLabel.Size = new System.Drawing.Size(35, 13);
			this.areaLabel.TabIndex = 1;
			this.areaLabel.Text = "label2";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 27);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Периметр:";
			// 
			// perimeterLabel
			// 
			this.perimeterLabel.AutoSize = true;
			this.perimeterLabel.Location = new System.Drawing.Point(87, 27);
			this.perimeterLabel.Name = "perimeterLabel";
			this.perimeterLabel.Size = new System.Drawing.Size(35, 13);
			this.perimeterLabel.TabIndex = 3;
			this.perimeterLabel.Text = "label4";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Координаты центра:";
			// 
			// centerLabel
			// 
			this.centerLabel.AutoSize = true;
			this.centerLabel.Location = new System.Drawing.Point(118, 59);
			this.centerLabel.Name = "centerLabel";
			this.centerLabel.Size = new System.Drawing.Size(35, 13);
			this.centerLabel.TabIndex = 5;
			this.centerLabel.Text = "label4";
			// 
			// pointsList
			// 
			this.pointsList.FormattingEnabled = true;
			this.pointsList.Location = new System.Drawing.Point(12, 108);
			this.pointsList.Name = "pointsList";
			this.pointsList.Size = new System.Drawing.Size(130, 95);
			this.pointsList.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 92);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(105, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Координаты фигур:";
			// 
			// FigureInfoPresenterForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(367, 243);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.pointsList);
			this.Controls.Add(this.centerLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.perimeterLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.areaLabel);
			this.Controls.Add(this.label1);
			this.Name = "FigureInfoPresenterForm";
			this.Text = "FigureInfoPresenterView";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label areaLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label perimeterLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label centerLabel;
		private System.Windows.Forms.ListBox pointsList;
		private System.Windows.Forms.Label label4;
	}
}