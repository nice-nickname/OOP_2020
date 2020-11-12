namespace FiguresDrawer.View.Forms
{
	partial class Index
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
			this.canvas = new System.Windows.Forms.PictureBox();
			this.figuresList = new System.Windows.Forms.ListBox();
			this.toSettingsButton = new System.Windows.Forms.Button();
			this.toFactoryButton = new System.Windows.Forms.Button();
			this.helpMeButton = new System.Windows.Forms.Button();
			this.canvasScaler = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.canvasScaler)).BeginInit();
			this.SuspendLayout();
			// 
			// canvas
			// 
			this.canvas.BackColor = System.Drawing.Color.White;
			this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.canvas.Cursor = System.Windows.Forms.Cursors.SizeAll;
			this.canvas.Location = new System.Drawing.Point(12, 12);
			this.canvas.Name = "canvas";
			this.canvas.Size = new System.Drawing.Size(400, 400);
			this.canvas.TabIndex = 0;
			this.canvas.TabStop = false;
			this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
			this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
			this.canvas.MouseHover += new System.EventHandler(this.canvas_MouseHover);
			this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
			this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
			// 
			// figuresList
			// 
			this.figuresList.FormattingEnabled = true;
			this.figuresList.Location = new System.Drawing.Point(418, 12);
			this.figuresList.Name = "figuresList";
			this.figuresList.Size = new System.Drawing.Size(231, 264);
			this.figuresList.TabIndex = 1;
			this.figuresList.SelectedIndexChanged += new System.EventHandler(this.figuresList_SelectedIndexChanged);
			this.figuresList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.figuresList_MouseDoubleClick);
			// 
			// toSettingsButton
			// 
			this.toSettingsButton.Location = new System.Drawing.Point(162, 418);
			this.toSettingsButton.Name = "toSettingsButton";
			this.toSettingsButton.Size = new System.Drawing.Size(109, 23);
			this.toSettingsButton.TabIndex = 3;
			this.toSettingsButton.Text = "Настройки";
			this.toSettingsButton.UseVisualStyleBackColor = true;
			this.toSettingsButton.Click += new System.EventHandler(this.toSettingsButton_Click);
			// 
			// toFactoryButton
			// 
			this.toFactoryButton.Location = new System.Drawing.Point(482, 282);
			this.toFactoryButton.Name = "toFactoryButton";
			this.toFactoryButton.Size = new System.Drawing.Size(109, 34);
			this.toFactoryButton.TabIndex = 4;
			this.toFactoryButton.Text = "Добавление фигур";
			this.toFactoryButton.UseVisualStyleBackColor = true;
			this.toFactoryButton.Click += new System.EventHandler(this.toFactoryButton_Click);
			// 
			// helpMeButton
			// 
			this.helpMeButton.Location = new System.Drawing.Point(303, 418);
			this.helpMeButton.Name = "helpMeButton";
			this.helpMeButton.Size = new System.Drawing.Size(109, 23);
			this.helpMeButton.TabIndex = 5;
			this.helpMeButton.Text = "Как работать";
			this.helpMeButton.UseVisualStyleBackColor = true;
			this.helpMeButton.Click += new System.EventHandler(this.helpMeButton_Click);
			// 
			// canvasScaler
			// 
			this.canvasScaler.DecimalPlaces = 2;
			this.canvasScaler.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
			this.canvasScaler.Location = new System.Drawing.Point(12, 418);
			this.canvasScaler.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.canvasScaler.Name = "canvasScaler";
			this.canvasScaler.Size = new System.Drawing.Size(120, 20);
			this.canvasScaler.TabIndex = 6;
			this.canvasScaler.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// Index
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(664, 453);
			this.Controls.Add(this.canvasScaler);
			this.Controls.Add(this.helpMeButton);
			this.Controls.Add(this.toFactoryButton);
			this.Controls.Add(this.toSettingsButton);
			this.Controls.Add(this.figuresList);
			this.Controls.Add(this.canvas);
			this.Name = "Index";
			this.Text = "Index";
			((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.canvasScaler)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox canvas;
		private System.Windows.Forms.ListBox figuresList;
		private System.Windows.Forms.Button toSettingsButton;
		private System.Windows.Forms.Button toFactoryButton;
		private System.Windows.Forms.Button helpMeButton;
		private System.Windows.Forms.NumericUpDown canvasScaler;
	}
}