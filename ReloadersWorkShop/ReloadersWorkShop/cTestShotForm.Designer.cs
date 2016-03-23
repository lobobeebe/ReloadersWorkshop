namespace ReloadersWorkShop
	{
	partial class cTestShotForm
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
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.GroupBox groupBox2;
			System.Windows.Forms.Label label9;
			System.Windows.Forms.Label MaxHeaderLabel;
			System.Windows.Forms.Label MinHeaderLabel;
			System.Windows.Forms.Label label6;
			System.Windows.Forms.Label label4;
			this.VelocityMeasurementLabel = new System.Windows.Forms.Label();
			this.StdDevLabel = new System.Windows.Forms.Label();
			this.MaxLabel = new System.Windows.Forms.Label();
			this.MinLabel = new System.Windows.Forms.Label();
			this.DeviationLabel = new System.Windows.Forms.Label();
			this.AvgLabel = new System.Windows.Forms.Label();
			this.ShotDataGroupBox = new System.Windows.Forms.GroupBox();
			this.PressureTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.MuzzleVelocityTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.ShotNumLabel = new System.Windows.Forms.Label();
			this.SquibRadioButton = new System.Windows.Forms.RadioButton();
			this.PreviousShotButton = new System.Windows.Forms.Button();
			this.MisfireRadioButton = new System.Windows.Forms.RadioButton();
			this.NextShotButton = new System.Windows.Forms.Button();
			this.TestShotOKButton = new System.Windows.Forms.Button();
			this.TestShotCancelButton = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			label9 = new System.Windows.Forms.Label();
			MaxHeaderLabel = new System.Windows.Forms.Label();
			MinHeaderLabel = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			groupBox2.SuspendLayout();
			this.ShotDataGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label1.ForeColor = System.Drawing.SystemColors.ControlText;
			label1.Location = new System.Drawing.Point(18, 49);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(83, 13);
			label1.TabIndex = 5;
			label1.Text = "Muzzle Velocity:";
			label1.UseMnemonic = false;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label2.ForeColor = System.Drawing.SystemColors.ControlText;
			label2.Location = new System.Drawing.Point(48, 73);
			label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(51, 13);
			label2.TabIndex = 7;
			label2.Text = "Pressure:";
			// 
			// VelocityMeasurementLabel
			// 
			this.VelocityMeasurementLabel.AutoSize = true;
			this.VelocityMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.VelocityMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.VelocityMeasurementLabel.Location = new System.Drawing.Point(153, 49);
			this.VelocityMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.VelocityMeasurementLabel.Name = "VelocityMeasurementLabel";
			this.VelocityMeasurementLabel.Size = new System.Drawing.Size(21, 13);
			this.VelocityMeasurementLabel.TabIndex = 8;
			this.VelocityMeasurementLabel.Text = "fps";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(this.StdDevLabel);
			groupBox2.Controls.Add(label9);
			groupBox2.Controls.Add(this.MaxLabel);
			groupBox2.Controls.Add(MaxHeaderLabel);
			groupBox2.Controls.Add(this.MinLabel);
			groupBox2.Controls.Add(MinHeaderLabel);
			groupBox2.Controls.Add(this.DeviationLabel);
			groupBox2.Controls.Add(label6);
			groupBox2.Controls.Add(this.AvgLabel);
			groupBox2.Controls.Add(label4);
			groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
			groupBox2.Location = new System.Drawing.Point(10, 209);
			groupBox2.Margin = new System.Windows.Forms.Padding(2);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new System.Windows.Forms.Padding(2);
			groupBox2.Size = new System.Drawing.Size(239, 101);
			groupBox2.TabIndex = 0;
			groupBox2.TabStop = false;
			groupBox2.Text = "Statistics";
			// 
			// StdDevLabel
			// 
			this.StdDevLabel.AutoSize = true;
			this.StdDevLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StdDevLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.StdDevLabel.Location = new System.Drawing.Point(158, 73);
			this.StdDevLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.StdDevLabel.Name = "StdDevLabel";
			this.StdDevLabel.Size = new System.Drawing.Size(61, 13);
			this.StdDevLabel.TabIndex = 18;
			this.StdDevLabel.Text = "Std. Dev.";
			this.StdDevLabel.UseMnemonic = false;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label9.ForeColor = System.Drawing.SystemColors.ControlText;
			label9.Location = new System.Drawing.Point(104, 73);
			label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(52, 13);
			label9.TabIndex = 17;
			label9.Text = "Std. Dev:";
			label9.UseMnemonic = false;
			// 
			// MaxLabel
			// 
			this.MaxLabel.AutoSize = true;
			this.MaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxLabel.Location = new System.Drawing.Point(42, 73);
			this.MaxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MaxLabel.Name = "MaxLabel";
			this.MaxLabel.Size = new System.Drawing.Size(30, 13);
			this.MaxLabel.TabIndex = 16;
			this.MaxLabel.Text = "Max";
			this.MaxLabel.UseMnemonic = false;
			// 
			// MaxHeaderLabel
			// 
			MaxHeaderLabel.AutoSize = true;
			MaxHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			MaxHeaderLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			MaxHeaderLabel.Location = new System.Drawing.Point(10, 73);
			MaxHeaderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			MaxHeaderLabel.Name = "MaxHeaderLabel";
			MaxHeaderLabel.Size = new System.Drawing.Size(30, 13);
			MaxHeaderLabel.TabIndex = 15;
			MaxHeaderLabel.Text = "Max:";
			MaxHeaderLabel.UseMnemonic = false;
			// 
			// MinLabel
			// 
			this.MinLabel.AutoSize = true;
			this.MinLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MinLabel.Location = new System.Drawing.Point(42, 49);
			this.MinLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MinLabel.Name = "MinLabel";
			this.MinLabel.Size = new System.Drawing.Size(27, 13);
			this.MinLabel.TabIndex = 14;
			this.MinLabel.Text = "Min";
			this.MinLabel.UseMnemonic = false;
			// 
			// MinHeaderLabel
			// 
			MinHeaderLabel.AutoSize = true;
			MinHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			MinHeaderLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			MinHeaderLabel.Location = new System.Drawing.Point(12, 49);
			MinHeaderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			MinHeaderLabel.Name = "MinHeaderLabel";
			MinHeaderLabel.Size = new System.Drawing.Size(27, 13);
			MinHeaderLabel.TabIndex = 13;
			MinHeaderLabel.Text = "Min:";
			MinHeaderLabel.UseMnemonic = false;
			// 
			// DeviationLabel
			// 
			this.DeviationLabel.AutoSize = true;
			this.DeviationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DeviationLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.DeviationLabel.Location = new System.Drawing.Point(158, 49);
			this.DeviationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.DeviationLabel.Name = "DeviationLabel";
			this.DeviationLabel.Size = new System.Drawing.Size(61, 13);
			this.DeviationLabel.TabIndex = 12;
			this.DeviationLabel.Text = "Deviation";
			this.DeviationLabel.UseMnemonic = false;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label6.ForeColor = System.Drawing.SystemColors.ControlText;
			label6.Location = new System.Drawing.Point(100, 49);
			label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(55, 13);
			label6.TabIndex = 11;
			label6.Text = "Deviation:";
			label6.UseMnemonic = false;
			// 
			// AvgLabel
			// 
			this.AvgLabel.AutoSize = true;
			this.AvgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AvgLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AvgLabel.Location = new System.Drawing.Point(42, 24);
			this.AvgLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.AvgLabel.Name = "AvgLabel";
			this.AvgLabel.Size = new System.Drawing.Size(32, 13);
			this.AvgLabel.TabIndex = 10;
			this.AvgLabel.Text = "AVG";
			this.AvgLabel.UseMnemonic = false;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label4.ForeColor = System.Drawing.SystemColors.ControlText;
			label4.Location = new System.Drawing.Point(10, 24);
			label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(29, 13);
			label4.TabIndex = 9;
			label4.Text = "Avg:";
			label4.UseMnemonic = false;
			// 
			// ShotDataGroupBox
			// 
			this.ShotDataGroupBox.Controls.Add(this.PressureTextBox);
			this.ShotDataGroupBox.Controls.Add(this.MuzzleVelocityTextBox);
			this.ShotDataGroupBox.Controls.Add(this.VelocityMeasurementLabel);
			this.ShotDataGroupBox.Controls.Add(label1);
			this.ShotDataGroupBox.Controls.Add(this.ShotNumLabel);
			this.ShotDataGroupBox.Controls.Add(this.SquibRadioButton);
			this.ShotDataGroupBox.Controls.Add(this.PreviousShotButton);
			this.ShotDataGroupBox.Controls.Add(this.MisfireRadioButton);
			this.ShotDataGroupBox.Controls.Add(this.NextShotButton);
			this.ShotDataGroupBox.Controls.Add(label2);
			this.ShotDataGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShotDataGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.ShotDataGroupBox.Location = new System.Drawing.Point(10, 13);
			this.ShotDataGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.ShotDataGroupBox.Name = "ShotDataGroupBox";
			this.ShotDataGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.ShotDataGroupBox.Size = new System.Drawing.Size(239, 183);
			this.ShotDataGroupBox.TabIndex = 0;
			this.ShotDataGroupBox.TabStop = false;
			this.ShotDataGroupBox.Text = "Shot Detail";
			// 
			// PressureTextBox
			// 
			this.PressureTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.PressureTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PressureTextBox.Location = new System.Drawing.Point(106, 70);
			this.PressureTextBox.MaxLength = 6;
			this.PressureTextBox.MaxValue = 500000;
			this.PressureTextBox.MinValue = 0;
			this.PressureTextBox.Name = "PressureTextBox";
			this.PressureTextBox.Required = false;
			this.PressureTextBox.Size = new System.Drawing.Size(56, 20);
			this.PressureTextBox.TabIndex = 1;
			this.PressureTextBox.Text = "0";
			this.PressureTextBox.ToolTip = "";
			this.PressureTextBox.Value = 0;
			// 
			// MuzzleVelocityTextBox
			// 
			this.MuzzleVelocityTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.MuzzleVelocityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MuzzleVelocityTextBox.Location = new System.Drawing.Point(106, 46);
			this.MuzzleVelocityTextBox.MaxLength = 4;
			this.MuzzleVelocityTextBox.MaxValue = 5000;
			this.MuzzleVelocityTextBox.MinValue = 100;
			this.MuzzleVelocityTextBox.Name = "MuzzleVelocityTextBox";
			this.MuzzleVelocityTextBox.Required = true;
			this.MuzzleVelocityTextBox.Size = new System.Drawing.Size(42, 20);
			this.MuzzleVelocityTextBox.TabIndex = 0;
			this.MuzzleVelocityTextBox.Text = "100";
			this.MuzzleVelocityTextBox.ToolTip = "";
			this.MuzzleVelocityTextBox.Value = 100;
			// 
			// ShotNumLabel
			// 
			this.ShotNumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShotNumLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ShotNumLabel.Location = new System.Drawing.Point(14, 24);
			this.ShotNumLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.ShotNumLabel.Name = "ShotNumLabel";
			this.ShotNumLabel.Size = new System.Drawing.Size(184, 19);
			this.ShotNumLabel.TabIndex = 4;
			this.ShotNumLabel.Text = "ShotNumLabel";
			this.ShotNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SquibRadioButton
			// 
			this.SquibRadioButton.AutoCheck = false;
			this.SquibRadioButton.AutoSize = true;
			this.SquibRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.SquibRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SquibRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SquibRadioButton.Location = new System.Drawing.Point(61, 119);
			this.SquibRadioButton.Margin = new System.Windows.Forms.Padding(2);
			this.SquibRadioButton.Name = "SquibRadioButton";
			this.SquibRadioButton.Size = new System.Drawing.Size(55, 17);
			this.SquibRadioButton.TabIndex = 3;
			this.SquibRadioButton.Text = "&Squib:";
			this.SquibRadioButton.UseVisualStyleBackColor = true;
			// 
			// PreviousShotButton
			// 
			this.PreviousShotButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PreviousShotButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PreviousShotButton.Location = new System.Drawing.Point(27, 154);
			this.PreviousShotButton.Margin = new System.Windows.Forms.Padding(2);
			this.PreviousShotButton.Name = "PreviousShotButton";
			this.PreviousShotButton.Size = new System.Drawing.Size(80, 19);
			this.PreviousShotButton.TabIndex = 4;
			this.PreviousShotButton.Text = "<<- &Previous";
			this.PreviousShotButton.UseVisualStyleBackColor = true;
			// 
			// MisfireRadioButton
			// 
			this.MisfireRadioButton.AutoCheck = false;
			this.MisfireRadioButton.AutoSize = true;
			this.MisfireRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.MisfireRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MisfireRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MisfireRadioButton.Location = new System.Drawing.Point(58, 98);
			this.MisfireRadioButton.Margin = new System.Windows.Forms.Padding(2);
			this.MisfireRadioButton.Name = "MisfireRadioButton";
			this.MisfireRadioButton.Size = new System.Drawing.Size(58, 17);
			this.MisfireRadioButton.TabIndex = 2;
			this.MisfireRadioButton.TabStop = true;
			this.MisfireRadioButton.Text = "&Misfire:";
			this.MisfireRadioButton.UseVisualStyleBackColor = true;
			// 
			// NextShotButton
			// 
			this.NextShotButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NextShotButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.NextShotButton.Location = new System.Drawing.Point(131, 154);
			this.NextShotButton.Margin = new System.Windows.Forms.Padding(2);
			this.NextShotButton.Name = "NextShotButton";
			this.NextShotButton.Size = new System.Drawing.Size(80, 19);
			this.NextShotButton.TabIndex = 5;
			this.NextShotButton.Text = "&Next ->>";
			this.NextShotButton.UseVisualStyleBackColor = true;
			// 
			// TestShotOKButton
			// 
			this.TestShotOKButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.TestShotOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.TestShotOKButton.Location = new System.Drawing.Point(65, 323);
			this.TestShotOKButton.Margin = new System.Windows.Forms.Padding(2);
			this.TestShotOKButton.Name = "TestShotOKButton";
			this.TestShotOKButton.Size = new System.Drawing.Size(56, 19);
			this.TestShotOKButton.TabIndex = 1;
			this.TestShotOKButton.Text = "OK";
			this.TestShotOKButton.UseVisualStyleBackColor = true;
			// 
			// TestShotCancelButton
			// 
			this.TestShotCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.TestShotCancelButton.Location = new System.Drawing.Point(142, 323);
			this.TestShotCancelButton.Margin = new System.Windows.Forms.Padding(2);
			this.TestShotCancelButton.Name = "TestShotCancelButton";
			this.TestShotCancelButton.Size = new System.Drawing.Size(56, 19);
			this.TestShotCancelButton.TabIndex = 2;
			this.TestShotCancelButton.Text = "Cancel";
			this.TestShotCancelButton.UseVisualStyleBackColor = true;
			// 
			// cTestShotForm
			// 
			this.AcceptButton = this.TestShotOKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.TestShotCancelButton;
			this.ClientSize = new System.Drawing.Size(239, 349);
			this.ControlBox = false;
			this.Controls.Add(groupBox2);
			this.Controls.Add(this.ShotDataGroupBox);
			this.Controls.Add(this.TestShotCancelButton);
			this.Controls.Add(this.TestShotOKButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cTestShotForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Test Shots";
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			this.ShotDataGroupBox.ResumeLayout(false);
			this.ShotDataGroupBox.PerformLayout();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.Button TestShotOKButton;
		private System.Windows.Forms.Button TestShotCancelButton;
		private System.Windows.Forms.Button PreviousShotButton;
		private System.Windows.Forms.Button NextShotButton;
		private System.Windows.Forms.Label ShotNumLabel;
		private System.Windows.Forms.RadioButton MisfireRadioButton;
		private System.Windows.Forms.RadioButton SquibRadioButton;
		private System.Windows.Forms.Label StdDevLabel;
		private System.Windows.Forms.Label MaxLabel;
		private System.Windows.Forms.Label MinLabel;
		private System.Windows.Forms.Label DeviationLabel;
		private System.Windows.Forms.Label AvgLabel;
		private System.Windows.Forms.GroupBox ShotDataGroupBox;
		private CommonLib.Controls.cIntegerValueTextBox PressureTextBox;
		private CommonLib.Controls.cIntegerValueTextBox MuzzleVelocityTextBox;
		private System.Windows.Forms.Label VelocityMeasurementLabel;
		}
	}