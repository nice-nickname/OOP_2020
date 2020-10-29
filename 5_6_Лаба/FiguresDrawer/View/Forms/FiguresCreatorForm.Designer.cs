namespace FiguresDrawer.View.Forms
{
	partial class FiguresCreatorForm
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
			this.pointsList = new System.Windows.Forms.ListBox();
			this.dotsLabel = new System.Windows.Forms.Label();
			this.figuresList = new System.Windows.Forms.ListBox();
			this.figuresLabel = new System.Windows.Forms.Label();
			this.addPointButton = new System.Windows.Forms.Button();
			this.clearDotsListButton = new System.Windows.Forms.Button();
			this.addFigureButton = new System.Windows.Forms.Button();
			this.deleteFigure = new System.Windows.Forms.Button();
			this.inputTextBoxX = new System.Windows.Forms.TextBox();
			this.inputTextBoxY = new System.Windows.Forms.TextBox();
			this.labelX = new System.Windows.Forms.Label();
			this.labelY = new System.Windows.Forms.Label();
			this.exitButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pointsList
			// 
			this.pointsList.FormattingEnabled = true;
			this.pointsList.Location = new System.Drawing.Point(12, 27);
			this.pointsList.Name = "pointsList";
			this.pointsList.Size = new System.Drawing.Size(130, 160);
			this.pointsList.TabIndex = 0;
			// 
			// dotsLabel
			// 
			this.dotsLabel.AutoSize = true;
			this.dotsLabel.Location = new System.Drawing.Point(13, 11);
			this.dotsLabel.Name = "dotsLabel";
			this.dotsLabel.Size = new System.Drawing.Size(75, 13);
			this.dotsLabel.TabIndex = 1;
			this.dotsLabel.Text = "Список точек";
			// 
			// figuresList
			// 
			this.figuresList.FormattingEnabled = true;
			this.figuresList.Location = new System.Drawing.Point(160, 27);
			this.figuresList.Name = "figuresList";
			this.figuresList.Size = new System.Drawing.Size(215, 186);
			this.figuresList.TabIndex = 2;
			// 
			// figuresLabel
			// 
			this.figuresLabel.AutoSize = true;
			this.figuresLabel.Location = new System.Drawing.Point(157, 11);
			this.figuresLabel.Name = "figuresLabel";
			this.figuresLabel.Size = new System.Drawing.Size(77, 13);
			this.figuresLabel.TabIndex = 3;
			this.figuresLabel.Text = "Список фигур";
			// 
			// addPointButton
			// 
			this.addPointButton.Location = new System.Drawing.Point(16, 248);
			this.addPointButton.Name = "addPointButton";
			this.addPointButton.Size = new System.Drawing.Size(116, 23);
			this.addPointButton.TabIndex = 4;
			this.addPointButton.Text = "Добавить точку";
			this.addPointButton.UseVisualStyleBackColor = true;
			this.addPointButton.Click += new System.EventHandler(this.addPointButton_Click);
			// 
			// clearDotsListButton
			// 
			this.clearDotsListButton.Location = new System.Drawing.Point(16, 277);
			this.clearDotsListButton.Name = "clearDotsListButton";
			this.clearDotsListButton.Size = new System.Drawing.Size(116, 23);
			this.clearDotsListButton.TabIndex = 5;
			this.clearDotsListButton.Text = "Очистить";
			this.clearDotsListButton.UseVisualStyleBackColor = true;
			this.clearDotsListButton.Click += new System.EventHandler(this.clearDotsListButton_Click);
			// 
			// addFigureButton
			// 
			this.addFigureButton.Location = new System.Drawing.Point(276, 219);
			this.addFigureButton.Name = "addFigureButton";
			this.addFigureButton.Size = new System.Drawing.Size(99, 27);
			this.addFigureButton.TabIndex = 6;
			this.addFigureButton.Text = "Создать фигуру";
			this.addFigureButton.UseVisualStyleBackColor = true;
			this.addFigureButton.Click += new System.EventHandler(this.addFigureButton_Click);
			// 
			// deleteFigure
			// 
			this.deleteFigure.Location = new System.Drawing.Point(160, 219);
			this.deleteFigure.Name = "deleteFigure";
			this.deleteFigure.Size = new System.Drawing.Size(99, 27);
			this.deleteFigure.TabIndex = 7;
			this.deleteFigure.Text = "Удалить фигуру";
			this.deleteFigure.UseVisualStyleBackColor = true;
			this.deleteFigure.Click += new System.EventHandler(this.deleteFigure_Click);
			// 
			// inputTextBoxX
			// 
			this.inputTextBoxX.Location = new System.Drawing.Point(36, 197);
			this.inputTextBoxX.Name = "inputTextBoxX";
			this.inputTextBoxX.Size = new System.Drawing.Size(96, 20);
			this.inputTextBoxX.TabIndex = 8;
			// 
			// inputTextBoxY
			// 
			this.inputTextBoxY.Location = new System.Drawing.Point(36, 222);
			this.inputTextBoxY.Name = "inputTextBoxY";
			this.inputTextBoxY.Size = new System.Drawing.Size(96, 20);
			this.inputTextBoxY.TabIndex = 9;
			// 
			// labelX
			// 
			this.labelX.AutoSize = true;
			this.labelX.Location = new System.Drawing.Point(13, 200);
			this.labelX.Name = "labelX";
			this.labelX.Size = new System.Drawing.Size(17, 13);
			this.labelX.TabIndex = 10;
			this.labelX.Text = "X:";
			// 
			// labelY
			// 
			this.labelY.AutoSize = true;
			this.labelY.Location = new System.Drawing.Point(13, 225);
			this.labelY.Name = "labelY";
			this.labelY.Size = new System.Drawing.Size(17, 13);
			this.labelY.TabIndex = 11;
			this.labelY.Text = "Y:";
			// 
			// exitButton
			// 
			this.exitButton.Location = new System.Drawing.Point(202, 252);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(120, 23);
			this.exitButton.TabIndex = 12;
			this.exitButton.Text = "Добавить и выйти";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
			// 
			// FiguresCreatorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(387, 315);
			this.Controls.Add(this.exitButton);
			this.Controls.Add(this.labelY);
			this.Controls.Add(this.labelX);
			this.Controls.Add(this.inputTextBoxY);
			this.Controls.Add(this.inputTextBoxX);
			this.Controls.Add(this.deleteFigure);
			this.Controls.Add(this.addFigureButton);
			this.Controls.Add(this.clearDotsListButton);
			this.Controls.Add(this.addPointButton);
			this.Controls.Add(this.figuresLabel);
			this.Controls.Add(this.figuresList);
			this.Controls.Add(this.dotsLabel);
			this.Controls.Add(this.pointsList);
			this.Name = "FiguresCreatorForm";
			this.Text = "FiguresCreatorForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox pointsList;
		private System.Windows.Forms.Label dotsLabel;
		private System.Windows.Forms.ListBox figuresList;
		private System.Windows.Forms.Label figuresLabel;
		private System.Windows.Forms.Button addPointButton;
		private System.Windows.Forms.Button clearDotsListButton;
		private System.Windows.Forms.Button addFigureButton;
		private System.Windows.Forms.Button deleteFigure;
		private System.Windows.Forms.TextBox inputTextBoxX;
		private System.Windows.Forms.TextBox inputTextBoxY;
		private System.Windows.Forms.Label labelX;
		private System.Windows.Forms.Label labelY;
		private System.Windows.Forms.Button exitButton;
	}
}