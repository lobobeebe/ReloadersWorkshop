namespace ReloadersWorkShop
	{
	partial class cTargetCalculatorForm
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
			this.TargetCalculatorCancelButton = new System.Windows.Forms.Button();
			this.OKButton = new System.Windows.Forms.Button();
			this.TargetCalculatorMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileSaveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileCloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.FileOpenTargetImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NumShotsLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.TotalShotsLabel = new System.Windows.Forms.Label();
			this.OutputGroupBox = new System.Windows.Forms.GroupBox();
			this.MOALabel = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.GroupSizeLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.RangeMeasurementLabel = new System.Windows.Forms.Label();
			this.ModeLabel = new System.Windows.Forms.Label();
			this.RangeTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.CaliberCombo = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.TargetImageBox = new System.Windows.Forms.PictureBox();
			this.BulletDiameterLabel = new System.Windows.Forms.Label();
			this.MilsLabel = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.OffsetLabel = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.ShowCalibrationCheckBox = new System.Windows.Forms.CheckBox();
			this.TargetCalculatorMenuStrip.SuspendLayout();
			this.OutputGroupBox.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TargetImageBox)).BeginInit();
			this.SuspendLayout();
			// 
			// TargetCalculatorCancelButton
			// 
			this.TargetCalculatorCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.TargetCalculatorCancelButton.Location = new System.Drawing.Point(583, 694);
			this.TargetCalculatorCancelButton.Name = "TargetCalculatorCancelButton";
			this.TargetCalculatorCancelButton.Size = new System.Drawing.Size(75, 23);
			this.TargetCalculatorCancelButton.TabIndex = 0;
			this.TargetCalculatorCancelButton.Text = "Cancel";
			this.TargetCalculatorCancelButton.UseVisualStyleBackColor = true;
			// 
			// OKButton
			// 
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Location = new System.Drawing.Point(411, 694);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 1;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			// 
			// TargetCalculatorMenuStrip
			// 
			this.TargetCalculatorMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.TargetCalculatorMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.TargetCalculatorMenuStrip.Name = "TargetCalculatorMenuStrip";
			this.TargetCalculatorMenuStrip.Size = new System.Drawing.Size(1068, 24);
			this.TargetCalculatorMenuStrip.TabIndex = 4;
			this.TargetCalculatorMenuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNewMenuItem,
            this.FileOpenMenuItem,
            this.FileSaveMenuItem,
            this.FileSaveAsMenuItem,
            this.FileCloseMenuItem,
            this.toolStripSeparator1,
            this.FileOpenTargetImageMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// FileNewMenuItem
			// 
			this.FileNewMenuItem.Name = "FileNewMenuItem";
			this.FileNewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.FileNewMenuItem.Size = new System.Drawing.Size(186, 22);
			this.FileNewMenuItem.Text = "&New";
			// 
			// FileOpenMenuItem
			// 
			this.FileOpenMenuItem.Name = "FileOpenMenuItem";
			this.FileOpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.FileOpenMenuItem.Size = new System.Drawing.Size(186, 22);
			this.FileOpenMenuItem.Text = "&Open";
			// 
			// FileSaveMenuItem
			// 
			this.FileSaveMenuItem.Name = "FileSaveMenuItem";
			this.FileSaveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.FileSaveMenuItem.Size = new System.Drawing.Size(186, 22);
			this.FileSaveMenuItem.Text = "&Save";
			// 
			// FileSaveAsMenuItem
			// 
			this.FileSaveAsMenuItem.Name = "FileSaveAsMenuItem";
			this.FileSaveAsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
			this.FileSaveAsMenuItem.Size = new System.Drawing.Size(186, 22);
			this.FileSaveAsMenuItem.Text = "Save &As";
			// 
			// FileCloseMenuItem
			// 
			this.FileCloseMenuItem.Name = "FileCloseMenuItem";
			this.FileCloseMenuItem.Size = new System.Drawing.Size(186, 22);
			this.FileCloseMenuItem.Text = "&Close";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
			// 
			// FileOpenTargetImageMenuItem
			// 
			this.FileOpenTargetImageMenuItem.Name = "FileOpenTargetImageMenuItem";
			this.FileOpenTargetImageMenuItem.Size = new System.Drawing.Size(186, 22);
			this.FileOpenTargetImageMenuItem.Text = "Open &Target Image";
			// 
			// NumShotsLabel
			// 
			this.NumShotsLabel.AutoSize = true;
			this.NumShotsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NumShotsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.NumShotsLabel.Location = new System.Drawing.Point(7, 56);
			this.NumShotsLabel.Name = "NumShotsLabel";
			this.NumShotsLabel.Size = new System.Drawing.Size(62, 13);
			this.NumShotsLabel.TabIndex = 5;
			this.NumShotsLabel.Text = "Num Shots:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(27, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Range:";
			// 
			// TotalShotsLabel
			// 
			this.TotalShotsLabel.AutoSize = true;
			this.TotalShotsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TotalShotsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TotalShotsLabel.Location = new System.Drawing.Point(75, 56);
			this.TotalShotsLabel.Name = "TotalShotsLabel";
			this.TotalShotsLabel.Size = new System.Drawing.Size(25, 13);
			this.TotalShotsLabel.TabIndex = 8;
			this.TotalShotsLabel.Text = "999";
			// 
			// OutputGroupBox
			// 
			this.OutputGroupBox.Controls.Add(this.OffsetLabel);
			this.OutputGroupBox.Controls.Add(this.label8);
			this.OutputGroupBox.Controls.Add(this.MilsLabel);
			this.OutputGroupBox.Controls.Add(this.label7);
			this.OutputGroupBox.Controls.Add(this.MOALabel);
			this.OutputGroupBox.Controls.Add(this.label5);
			this.OutputGroupBox.Controls.Add(this.GroupSizeLabel);
			this.OutputGroupBox.Controls.Add(this.label2);
			this.OutputGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OutputGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.OutputGroupBox.Location = new System.Drawing.Point(537, 27);
			this.OutputGroupBox.Name = "OutputGroupBox";
			this.OutputGroupBox.Size = new System.Drawing.Size(519, 77);
			this.OutputGroupBox.TabIndex = 9;
			this.OutputGroupBox.TabStop = false;
			this.OutputGroupBox.Text = "Output Data";
			// 
			// MOALabel
			// 
			this.MOALabel.AutoSize = true;
			this.MOALabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MOALabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MOALabel.Location = new System.Drawing.Point(197, 31);
			this.MOALabel.Name = "MOALabel";
			this.MOALabel.Size = new System.Drawing.Size(39, 13);
			this.MOALabel.TabIndex = 3;
			this.MOALabel.Text = "0.000";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(156, 31);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "MOA:";
			// 
			// GroupSizeLabel
			// 
			this.GroupSizeLabel.AutoSize = true;
			this.GroupSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GroupSizeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.GroupSizeLabel.Location = new System.Drawing.Point(84, 31);
			this.GroupSizeLabel.Name = "GroupSizeLabel";
			this.GroupSizeLabel.Size = new System.Drawing.Size(54, 13);
			this.GroupSizeLabel.TabIndex = 1;
			this.GroupSizeLabel.Text = "0.000 In";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(16, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Group Size:";
			// 
			// RangeMeasurementLabel
			// 
			this.RangeMeasurementLabel.AutoSize = true;
			this.RangeMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RangeMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RangeMeasurementLabel.Location = new System.Drawing.Point(116, 31);
			this.RangeMeasurementLabel.Name = "RangeMeasurementLabel";
			this.RangeMeasurementLabel.Size = new System.Drawing.Size(34, 13);
			this.RangeMeasurementLabel.TabIndex = 10;
			this.RangeMeasurementLabel.Text = "Yards";
			// 
			// ModeLabel
			// 
			this.ModeLabel.AutoSize = true;
			this.ModeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ModeLabel.Location = new System.Drawing.Point(26, 118);
			this.ModeLabel.Name = "ModeLabel";
			this.ModeLabel.Size = new System.Drawing.Size(55, 16);
			this.ModeLabel.TabIndex = 11;
			this.ModeLabel.Text = "Mode: ";
			// 
			// RangeTextBox
			// 
			this.RangeTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.RangeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RangeTextBox.Location = new System.Drawing.Point(75, 28);
			this.RangeTextBox.MaxLength = 4;
			this.RangeTextBox.MaxValue = 0;
			this.RangeTextBox.MinValue = 25;
			this.RangeTextBox.Name = "RangeTextBox";
			this.RangeTextBox.Required = false;
			this.RangeTextBox.Size = new System.Drawing.Size(35, 20);
			this.RangeTextBox.TabIndex = 7;
			this.RangeTextBox.Text = "9999";
			this.RangeTextBox.ToolTip = "";
			this.RangeTextBox.Value = 9999;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(211, 31);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Caliber:";
			// 
			// CaliberCombo
			// 
			this.CaliberCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CaliberCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CaliberCombo.FormattingEnabled = true;
			this.CaliberCombo.Location = new System.Drawing.Point(259, 28);
			this.CaliberCombo.Name = "CaliberCombo";
			this.CaliberCombo.Size = new System.Drawing.Size(251, 21);
			this.CaliberCombo.TabIndex = 14;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(172, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(81, 13);
			this.label4.TabIndex = 15;
			this.label4.Text = "Bullet Diameter:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.BulletDiameterLabel);
			this.groupBox1.Controls.Add(this.NumShotsLabel);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.RangeTextBox);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.TotalShotsLabel);
			this.groupBox1.Controls.Add(this.CaliberCombo);
			this.groupBox1.Controls.Add(this.RangeMeasurementLabel);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox1.Location = new System.Drawing.Point(12, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(519, 77);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input Data";
			// 
			// TargetImageBox
			// 
			this.TargetImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TargetImageBox.Location = new System.Drawing.Point(42, 148);
			this.TargetImageBox.Name = "TargetImageBox";
			this.TargetImageBox.Size = new System.Drawing.Size(984, 519);
			this.TargetImageBox.TabIndex = 12;
			this.TargetImageBox.TabStop = false;
			// 
			// BulletDiameterLabel
			// 
			this.BulletDiameterLabel.AutoSize = true;
			this.BulletDiameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletDiameterLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BulletDiameterLabel.Location = new System.Drawing.Point(259, 56);
			this.BulletDiameterLabel.Name = "BulletDiameterLabel";
			this.BulletDiameterLabel.Size = new System.Drawing.Size(28, 13);
			this.BulletDiameterLabel.TabIndex = 16;
			this.BulletDiameterLabel.Text = "999";
			// 
			// MilsLabel
			// 
			this.MilsLabel.AutoSize = true;
			this.MilsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MilsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MilsLabel.Location = new System.Drawing.Point(296, 31);
			this.MilsLabel.Name = "MilsLabel";
			this.MilsLabel.Size = new System.Drawing.Size(39, 13);
			this.MilsLabel.TabIndex = 5;
			this.MilsLabel.Text = "0.000";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label7.Location = new System.Drawing.Point(262, 31);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(28, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "Mils:";
			// 
			// OffsetLabel
			// 
			this.OffsetLabel.AutoSize = true;
			this.OffsetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OffsetLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OffsetLabel.Location = new System.Drawing.Point(173, 56);
			this.OffsetLabel.Name = "OffsetLabel";
			this.OffsetLabel.Size = new System.Drawing.Size(54, 13);
			this.OffsetLabel.TabIndex = 7;
			this.OffsetLabel.Text = "0.000 In";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label8.Location = new System.Drawing.Point(52, 56);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(115, 13);
			this.label8.TabIndex = 6;
			this.label8.Text = "Mean Aim Point Offset:";
			// 
			// ShowCalibrationCheckBox
			// 
			this.ShowCalibrationCheckBox.AutoSize = true;
			this.ShowCalibrationCheckBox.Checked = true;
			this.ShowCalibrationCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ShowCalibrationCheckBox.Location = new System.Drawing.Point(329, 119);
			this.ShowCalibrationCheckBox.Name = "ShowCalibrationCheckBox";
			this.ShowCalibrationCheckBox.Size = new System.Drawing.Size(105, 17);
			this.ShowCalibrationCheckBox.TabIndex = 13;
			this.ShowCalibrationCheckBox.Text = "Show Calibration";
			this.ShowCalibrationCheckBox.UseVisualStyleBackColor = true;
			// 
			// cTargetCalculatorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.TargetCalculatorCancelButton;
			this.ClientSize = new System.Drawing.Size(1068, 752);
			this.ControlBox = false;
			this.Controls.Add(this.ShowCalibrationCheckBox);
			this.Controls.Add(this.TargetImageBox);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.ModeLabel);
			this.Controls.Add(this.OutputGroupBox);
			this.Controls.Add(this.TargetCalculatorMenuStrip);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.TargetCalculatorCancelButton);
			this.MainMenuStrip = this.TargetCalculatorMenuStrip;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(1084, 768);
			this.Name = "cTargetCalculatorForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Target Calculator";
			this.TargetCalculatorMenuStrip.ResumeLayout(false);
			this.TargetCalculatorMenuStrip.PerformLayout();
			this.OutputGroupBox.ResumeLayout(false);
			this.OutputGroupBox.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.TargetImageBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.Button TargetCalculatorCancelButton;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.MenuStrip TargetCalculatorMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileNewMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileOpenMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileSaveMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileSaveAsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileCloseMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem FileOpenTargetImageMenuItem;
		private System.Windows.Forms.Label NumShotsLabel;
		private System.Windows.Forms.Label label1;
		private CommonLib.Controls.cIntegerValueTextBox RangeTextBox;
		private System.Windows.Forms.Label TotalShotsLabel;
		private System.Windows.Forms.GroupBox OutputGroupBox;
		private System.Windows.Forms.Label RangeMeasurementLabel;
		private System.Windows.Forms.Label MOALabel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label GroupSizeLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label ModeLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox CaliberCombo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox TargetImageBox;
		private System.Windows.Forms.Label BulletDiameterLabel;
		private System.Windows.Forms.Label MilsLabel;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label OffsetLabel;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox ShowCalibrationCheckBox;
		}
	}