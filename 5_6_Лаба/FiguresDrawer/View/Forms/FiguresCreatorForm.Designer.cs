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
			this.readFromFileButton = new System.Windows.Forms.Button();
			this.colorChooseComboBox = new System.Windows.Forms.ComboBox();
			this.labelColor = new System.Windows.Forms.Label();
			this.writeToFileButton = new System.Windows.Forms.Button();
			this.editSelectedButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pointsList
			// 
			this.pointsList.FormattingEnabled = true;
			this.pointsList.Location = new System.Drawing.Point(14, 31);
			this.pointsList.Name = "pointsList";
			this.pointsList.Size = new System.Drawing.Size(130, 160);
			this.pointsList.TabIndex = 0;
			// 
			// dotsLabel
			// 
			this.dotsLabel.AutoSize = true;
			this.dotsLabel.Location = new System.Drawing.Point(15, 15);
			this.dotsLabel.Name = "dotsLabel";
			this.dotsLabel.Size = new System.Drawing.Size(75, 13);
			this.dotsLabel.TabIndex = 1;
			this.dotsLabel.Text = "Список точек";
			// 
			// figuresList
			// 
			this.figuresList.FormattingEnabled = true;
			this.figuresList.Location = new System.Drawing.Point(164, 31);
			this.figuresList.Name = "figuresList";
			this.figuresList.Size = new System.Drawing.Size(253, 160);
			this.figuresList.TabIndex = 2;
			this.figuresList.SelectedIndexChanged += new System.EventHandler(this.figuresList_SelectedIndexChanged);
			// 
			// figuresLabel
			// 
			this.figuresLabel.AutoSize = true;
			this.figuresLabel.Location = new System.Drawing.Point(164, 15);
			this.figuresLabel.Name = "figuresLabel";
			this.figuresLabel.Size = new System.Drawing.Size(77, 13);
			this.figuresLabel.TabIndex = 3;
			this.figuresLabel.Text = "Список фигур";
			// 
			// addPointButton
			// 
			this.addPointButton.Location = new System.Drawing.Point(18, 281);
			this.addPointButton.Name = "addPointButton";
			this.addPointButton.Size = new System.Drawing.Size(116, 23);
			this.addPointButton.TabIndex = 4;
			this.addPointButton.Text = "Добавить точку";
			this.addPointButton.UseVisualStyleBackColor = true;
			this.addPointButton.Click += new System.EventHandler(this.addPointButton_Click);
			// 
			// clearDotsListButton
			// 
			this.clearDotsListButton.Location = new System.Drawing.Point(18, 339);
			this.clearDotsListButton.Name = "clearDotsListButton";
			this.clearDotsListButton.Size = new System.Drawing.Size(116, 23);
			this.clearDotsListButton.TabIndex = 5;
			this.clearDotsListButton.Text = "Очистить";
			this.clearDotsListButton.UseVisualStyleBackColor = true;
			this.clearDotsListButton.Click += new System.EventHandler(this.clearDotsListButton_Click);
			// 
			// addFigureButton
			// 
			this.addFigureButton.Location = new System.Drawing.Point(164, 230);
			this.addFigureButton.Name = "addFigureButton";
			this.addFigureButton.Size = new System.Drawing.Size(112, 27);
			this.addFigureButton.TabIndex = 6;
			this.addFigureButton.Text = "Создать фигуру";
			this.addFigureButton.UseVisualStyleBackColor = true;
			this.addFigureButton.Click += new System.EventHandler(this.addFigureButton_Click);
			// 
			// deleteFigure
			// 
			this.deleteFigure.Location = new System.Drawing.Point(164, 197);
			this.deleteFigure.Name = "deleteFigure";
			this.deleteFigure.Size = new System.Drawing.Size(112, 27);
			this.deleteFigure.TabIndex = 7;
			this.deleteFigure.Text = "Удалить фигуру";
			this.deleteFigure.UseVisualStyleBackColor = true;
			this.deleteFigure.Click += new System.EventHandler(this.deleteFigure_Click);
			// 
			// inputTextBoxX
			// 
			this.inputTextBoxX.Location = new System.Drawing.Point(38, 201);
			this.inputTextBoxX.Name = "inputTextBoxX";
			this.inputTextBoxX.Size = new System.Drawing.Size(96, 20);
			this.inputTextBoxX.TabIndex = 8;
			// 
			// inputTextBoxY
			// 
			this.inputTextBoxY.Location = new System.Drawing.Point(38, 226);
			this.inputTextBoxY.Name = "inputTextBoxY";
			this.inputTextBoxY.Size = new System.Drawing.Size(96, 20);
			this.inputTextBoxY.TabIndex = 9;
			// 
			// labelX
			// 
			this.labelX.AutoSize = true;
			this.labelX.Location = new System.Drawing.Point(15, 204);
			this.labelX.Name = "labelX";
			this.labelX.Size = new System.Drawing.Size(17, 13);
			this.labelX.TabIndex = 10;
			this.labelX.Text = "X:";
			// 
			// labelY
			// 
			this.labelY.AutoSize = true;
			this.labelY.Location = new System.Drawing.Point(15, 229);
			this.labelY.Name = "labelY";
			this.labelY.Size = new System.Drawing.Size(17, 13);
			this.labelY.TabIndex = 11;
			this.labelY.Text = "Y:";
			// 
			// exitButton
			// 
			this.exitButton.Location = new System.Drawing.Point(307, 291);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(110, 60);
			this.exitButton.TabIndex = 12;
			this.exitButton.Text = "Добавить и выйти";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
			// 
			// readFromFileButton
			// 
			this.readFromFileButton.Location = new System.Drawing.Point(305, 197);
			this.readFromFileButton.Name = "readFromFileButton";
			this.readFromFileButton.Size = new System.Drawing.Size(112, 36);
			this.readFromFileButton.TabIndex = 13;
			this.readFromFileButton.Text = "Прочитать фигуры из файла";
			this.readFromFileButton.UseVisualStyleBackColor = true;
			this.readFromFileButton.Click += new System.EventHandler(this.readFromFileButton_Click);
			// 
			// colorChooseComboBox
			// 
			this.colorChooseComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.colorChooseComboBox.FormattingEnabled = true;
			this.colorChooseComboBox.Location = new System.Drawing.Point(50, 252);
			this.colorChooseComboBox.Name = "colorChooseComboBox";
			this.colorChooseComboBox.Size = new System.Drawing.Size(84, 21);
			this.colorChooseComboBox.TabIndex = 14;
			// 
			// labelColor
			// 
			this.labelColor.AutoSize = true;
			this.labelColor.Location = new System.Drawing.Point(15, 255);
			this.labelColor.Name = "labelColor";
			this.labelColor.Size = new System.Drawing.Size(34, 13);
			this.labelColor.TabIndex = 15;
			this.labelColor.Text = "Color:";
			// 
			// writeToFileButton
			// 
			this.writeToFileButton.Location = new System.Drawing.Point(305, 239);
			this.writeToFileButton.Name = "writeToFileButton";
			this.writeToFileButton.Size = new System.Drawing.Size(112, 36);
			this.writeToFileButton.TabIndex = 16;
			this.writeToFileButton.Text = "Записать фигуры в файл";
			this.writeToFileButton.UseVisualStyleBackColor = true;
			this.writeToFileButton.Click += new System.EventHandler(this.writeToFileButton_Click);
			// 
			// editSelectedButton
			// 
			this.editSelectedButton.Location = new System.Drawing.Point(18, 310);
			this.editSelectedButton.Name = "editSelectedButton";
			this.editSelectedButton.Size = new System.Drawing.Size(116, 23);
			this.editSelectedButton.TabIndex = 17;
			this.editSelectedButton.Text = "Изменить выделенную точку";
			this.editSelectedButton.UseVisualStyleBackColor = true;
			this.editSelectedButton.Click += new System.EventHandler(this.editSelectedButton_Click);
			// 
			// FiguresCreatorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(431, 371);
			this.Controls.Add(this.editSelectedButton);
			this.Controls.Add(this.writeToFileButton);
			this.Controls.Add(this.labelColor);
			this.Controls.Add(this.colorChooseComboBox);
			this.Controls.Add(this.readFromFileButton);
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
		private System.Windows.Forms.Button readFromFileButton;
		private System.Windows.Forms.ComboBox colorChooseComboBox;
		private System.Windows.Forms.Label labelColor;
		private System.Windows.Forms.Button writeToFileButton;
		private System.Windows.Forms.Button editSelectedButton;
	}
}