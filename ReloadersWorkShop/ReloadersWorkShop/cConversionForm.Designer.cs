namespace ReloadersWorkShop
	{
	partial class cConversionForm
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
			this.CloseButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.MeasurementsGroupBox = new System.Windows.Forms.GroupBox();
			this.label22 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.KilometersTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.MilesTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.MetersTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.YardsTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.CentimetersTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.FeetTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.MillimetersTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.InchesTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.MilligramsTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.OuncesTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.GramsTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.GrainsTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.KilosTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.PoundsTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label25 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.KPHTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.MPHTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.MSTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.FPSTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.PrecisionTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.AtMetersLabel = new System.Windows.Forms.Label();
			this.AtYardsLabel = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.MilsTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.MOATextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.MeasurementsGroupBox.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(438, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "Enter a value in any field below for an immediate conversion";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// CloseButton
			// 
			this.CloseButton.AutoSize = true;
			this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CloseButton.Location = new System.Drawing.Point(205, 526);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(43, 23);
			this.CloseButton.TabIndex = 5;
			this.CloseButton.Text = "Close";
			this.CloseButton.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(30, 30);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Inches:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(213, 30);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(69, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Millimeters:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// MeasurementsGroupBox
			// 
			this.MeasurementsGroupBox.Controls.Add(this.label22);
			this.MeasurementsGroupBox.Controls.Add(this.label24);
			this.MeasurementsGroupBox.Controls.Add(this.KilometersTextBox);
			this.MeasurementsGroupBox.Controls.Add(this.MilesTextBox);
			this.MeasurementsGroupBox.Controls.Add(this.label19);
			this.MeasurementsGroupBox.Controls.Add(this.label21);
			this.MeasurementsGroupBox.Controls.Add(this.MetersTextBox);
			this.MeasurementsGroupBox.Controls.Add(this.YardsTextBox);
			this.MeasurementsGroupBox.Controls.Add(this.label16);
			this.MeasurementsGroupBox.Controls.Add(this.label18);
			this.MeasurementsGroupBox.Controls.Add(this.CentimetersTextBox);
			this.MeasurementsGroupBox.Controls.Add(this.FeetTextBox);
			this.MeasurementsGroupBox.Controls.Add(this.label4);
			this.MeasurementsGroupBox.Controls.Add(this.label5);
			this.MeasurementsGroupBox.Controls.Add(this.MillimetersTextBox);
			this.MeasurementsGroupBox.Controls.Add(this.InchesTextBox);
			this.MeasurementsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MeasurementsGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.MeasurementsGroupBox.Location = new System.Drawing.Point(12, 78);
			this.MeasurementsGroupBox.Name = "MeasurementsGroupBox";
			this.MeasurementsGroupBox.Size = new System.Drawing.Size(435, 140);
			this.MeasurementsGroupBox.TabIndex = 1;
			this.MeasurementsGroupBox.TabStop = false;
			this.MeasurementsGroupBox.Text = "Distance";
			// 
			// label22
			// 
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label22.Location = new System.Drawing.Point(27, 105);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(55, 13);
			this.label22.TabIndex = 19;
			this.label22.Text = "Miles:";
			this.label22.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label24
			// 
			this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label24.Location = new System.Drawing.Point(222, 105);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(60, 13);
			this.label24.TabIndex = 20;
			this.label24.Text = "Kilometers:";
			this.label24.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// KilometersTextBox
			// 
			this.KilometersTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.KilometersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.KilometersTextBox.Location = new System.Drawing.Point(288, 102);
			this.KilometersTextBox.MaxValue = 0D;
			this.KilometersTextBox.MinValue = 0D;
			this.KilometersTextBox.Name = "KilometersTextBox";
			this.KilometersTextBox.NumDecimals = 3;
			this.KilometersTextBox.Size = new System.Drawing.Size(73, 20);
			this.KilometersTextBox.TabIndex = 7;
			this.KilometersTextBox.Text = "0.000";
			this.KilometersTextBox.ToolTip = "";
			this.KilometersTextBox.Value = 0D;
			this.KilometersTextBox.ZeroAllowed = true;
			// 
			// MilesTextBox
			// 
			this.MilesTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.MilesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MilesTextBox.Location = new System.Drawing.Point(88, 102);
			this.MilesTextBox.MaxValue = 0D;
			this.MilesTextBox.MinValue = 0D;
			this.MilesTextBox.Name = "MilesTextBox";
			this.MilesTextBox.NumDecimals = 3;
			this.MilesTextBox.Size = new System.Drawing.Size(73, 20);
			this.MilesTextBox.TabIndex = 6;
			this.MilesTextBox.Text = "0.000";
			this.MilesTextBox.ToolTip = "";
			this.MilesTextBox.Value = 0D;
			this.MilesTextBox.ZeroAllowed = true;
			// 
			// label19
			// 
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label19.Location = new System.Drawing.Point(27, 80);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(55, 13);
			this.label19.TabIndex = 14;
			this.label19.Text = "Yards:";
			this.label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label21
			// 
			this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label21.Location = new System.Drawing.Point(219, 80);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(63, 13);
			this.label21.TabIndex = 15;
			this.label21.Text = "Meters:";
			this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// MetersTextBox
			// 
			this.MetersTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.MetersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.MetersTextBox.Location = new System.Drawing.Point(288, 77);
			this.MetersTextBox.MaxValue = 0D;
			this.MetersTextBox.MinValue = 0D;
			this.MetersTextBox.Name = "MetersTextBox";
			this.MetersTextBox.NumDecimals = 3;
			this.MetersTextBox.Size = new System.Drawing.Size(73, 20);
			this.MetersTextBox.TabIndex = 5;
			this.MetersTextBox.Text = "0.000";
			this.MetersTextBox.ToolTip = "";
			this.MetersTextBox.Value = 0D;
			this.MetersTextBox.ZeroAllowed = true;
			// 
			// YardsTextBox
			// 
			this.YardsTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.YardsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.YardsTextBox.Location = new System.Drawing.Point(88, 77);
			this.YardsTextBox.MaxValue = 0D;
			this.YardsTextBox.MinValue = 0D;
			this.YardsTextBox.Name = "YardsTextBox";
			this.YardsTextBox.NumDecimals = 3;
			this.YardsTextBox.Size = new System.Drawing.Size(73, 20);
			this.YardsTextBox.TabIndex = 4;
			this.YardsTextBox.Text = "0.000";
			this.YardsTextBox.ToolTip = "";
			this.YardsTextBox.Value = 0D;
			this.YardsTextBox.ZeroAllowed = true;
			// 
			// label16
			// 
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label16.Location = new System.Drawing.Point(27, 55);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(55, 13);
			this.label16.TabIndex = 9;
			this.label16.Text = "Feet:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label18
			// 
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label18.Location = new System.Drawing.Point(216, 55);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(66, 13);
			this.label18.TabIndex = 10;
			this.label18.Text = "Centimeters:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// CentimetersTextBox
			// 
			this.CentimetersTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.CentimetersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.CentimetersTextBox.Location = new System.Drawing.Point(288, 52);
			this.CentimetersTextBox.MaxValue = 0D;
			this.CentimetersTextBox.MinValue = 0D;
			this.CentimetersTextBox.Name = "CentimetersTextBox";
			this.CentimetersTextBox.NumDecimals = 3;
			this.CentimetersTextBox.Size = new System.Drawing.Size(73, 20);
			this.CentimetersTextBox.TabIndex = 3;
			this.CentimetersTextBox.Text = "0.000";
			this.CentimetersTextBox.ToolTip = "";
			this.CentimetersTextBox.Value = 0D;
			this.CentimetersTextBox.ZeroAllowed = true;
			// 
			// FeetTextBox
			// 
			this.FeetTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.FeetTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FeetTextBox.Location = new System.Drawing.Point(88, 52);
			this.FeetTextBox.MaxValue = 0D;
			this.FeetTextBox.MinValue = 0D;
			this.FeetTextBox.Name = "FeetTextBox";
			this.FeetTextBox.NumDecimals = 3;
			this.FeetTextBox.Size = new System.Drawing.Size(73, 20);
			this.FeetTextBox.TabIndex = 2;
			this.FeetTextBox.Text = "0.000";
			this.FeetTextBox.ToolTip = "";
			this.FeetTextBox.Value = 0D;
			this.FeetTextBox.ZeroAllowed = true;
			// 
			// MillimetersTextBox
			// 
			this.MillimetersTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.MillimetersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.MillimetersTextBox.Location = new System.Drawing.Point(288, 27);
			this.MillimetersTextBox.MaxValue = 0D;
			this.MillimetersTextBox.MinValue = 0D;
			this.MillimetersTextBox.Name = "MillimetersTextBox";
			this.MillimetersTextBox.NumDecimals = 3;
			this.MillimetersTextBox.Size = new System.Drawing.Size(73, 20);
			this.MillimetersTextBox.TabIndex = 1;
			this.MillimetersTextBox.Text = "0.000";
			this.MillimetersTextBox.ToolTip = "";
			this.MillimetersTextBox.Value = 0D;
			this.MillimetersTextBox.ZeroAllowed = true;
			// 
			// InchesTextBox
			// 
			this.InchesTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.InchesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.InchesTextBox.Location = new System.Drawing.Point(88, 27);
			this.InchesTextBox.MaxValue = 0D;
			this.InchesTextBox.MinValue = 0D;
			this.InchesTextBox.Name = "InchesTextBox";
			this.InchesTextBox.NumDecimals = 3;
			this.InchesTextBox.Size = new System.Drawing.Size(73, 20);
			this.InchesTextBox.TabIndex = 0;
			this.InchesTextBox.Text = "0.000";
			this.InchesTextBox.ToolTip = "";
			this.InchesTextBox.Value = 0D;
			this.InchesTextBox.ZeroAllowed = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.MilligramsTextBox);
			this.groupBox2.Controls.Add(this.label28);
			this.groupBox2.Controls.Add(this.OuncesTextBox);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.GramsTextBox);
			this.groupBox2.Controls.Add(this.GrainsTextBox);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.KilosTextBox);
			this.groupBox2.Controls.Add(this.PoundsTextBox);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox2.Location = new System.Drawing.Point(12, 318);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(435, 110);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Weights";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label6.Location = new System.Drawing.Point(216, 30);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(66, 13);
			this.label6.TabIndex = 18;
			this.label6.Text = "Millgrams:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// MilligramsTextBox
			// 
			this.MilligramsTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.MilligramsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.MilligramsTextBox.Location = new System.Drawing.Point(288, 27);
			this.MilligramsTextBox.MaxValue = 0D;
			this.MilligramsTextBox.MinValue = 0D;
			this.MilligramsTextBox.Name = "MilligramsTextBox";
			this.MilligramsTextBox.NumDecimals = 3;
			this.MilligramsTextBox.Size = new System.Drawing.Size(73, 20);
			this.MilligramsTextBox.TabIndex = 1;
			this.MilligramsTextBox.Text = "0.000";
			this.MilligramsTextBox.ToolTip = "";
			this.MilligramsTextBox.Value = 0D;
			this.MilligramsTextBox.ZeroAllowed = true;
			// 
			// label28
			// 
			this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label28.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label28.Location = new System.Drawing.Point(-4, 55);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(86, 13);
			this.label28.TabIndex = 16;
			this.label28.Text = "Ounces:";
			this.label28.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// OuncesTextBox
			// 
			this.OuncesTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.OuncesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OuncesTextBox.Location = new System.Drawing.Point(88, 52);
			this.OuncesTextBox.MaxValue = 0D;
			this.OuncesTextBox.MinValue = 0D;
			this.OuncesTextBox.Name = "OuncesTextBox";
			this.OuncesTextBox.NumDecimals = 3;
			this.OuncesTextBox.Size = new System.Drawing.Size(73, 20);
			this.OuncesTextBox.TabIndex = 2;
			this.OuncesTextBox.Text = "0.000";
			this.OuncesTextBox.ToolTip = "";
			this.OuncesTextBox.Value = 0D;
			this.OuncesTextBox.ZeroAllowed = true;
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label13.Location = new System.Drawing.Point(27, 30);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(55, 13);
			this.label13.TabIndex = 9;
			this.label13.Text = "Grains:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label15.Location = new System.Drawing.Point(216, 55);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(66, 13);
			this.label15.TabIndex = 10;
			this.label15.Text = "Grams:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// GramsTextBox
			// 
			this.GramsTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.GramsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.GramsTextBox.Location = new System.Drawing.Point(288, 52);
			this.GramsTextBox.MaxValue = 0D;
			this.GramsTextBox.MinValue = 0D;
			this.GramsTextBox.Name = "GramsTextBox";
			this.GramsTextBox.NumDecimals = 3;
			this.GramsTextBox.Size = new System.Drawing.Size(73, 20);
			this.GramsTextBox.TabIndex = 3;
			this.GramsTextBox.Text = "0.000";
			this.GramsTextBox.ToolTip = "";
			this.GramsTextBox.Value = 0D;
			this.GramsTextBox.ZeroAllowed = true;
			// 
			// GrainsTextBox
			// 
			this.GrainsTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.GrainsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GrainsTextBox.Location = new System.Drawing.Point(88, 27);
			this.GrainsTextBox.MaxValue = 0D;
			this.GrainsTextBox.MinValue = 0D;
			this.GrainsTextBox.Name = "GrainsTextBox";
			this.GrainsTextBox.NumDecimals = 3;
			this.GrainsTextBox.Size = new System.Drawing.Size(73, 20);
			this.GrainsTextBox.TabIndex = 0;
			this.GrainsTextBox.Text = "0.000";
			this.GrainsTextBox.ToolTip = "";
			this.GrainsTextBox.Value = 0D;
			this.GrainsTextBox.ZeroAllowed = true;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label7.Location = new System.Drawing.Point(27, 80);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(55, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "Pounds:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label9.Location = new System.Drawing.Point(216, 80);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(66, 13);
			this.label9.TabIndex = 5;
			this.label9.Text = "Kilos:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// KilosTextBox
			// 
			this.KilosTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.KilosTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.KilosTextBox.Location = new System.Drawing.Point(288, 77);
			this.KilosTextBox.MaxValue = 0D;
			this.KilosTextBox.MinValue = 0D;
			this.KilosTextBox.Name = "KilosTextBox";
			this.KilosTextBox.NumDecimals = 3;
			this.KilosTextBox.Size = new System.Drawing.Size(73, 20);
			this.KilosTextBox.TabIndex = 5;
			this.KilosTextBox.Text = "0.000";
			this.KilosTextBox.ToolTip = "";
			this.KilosTextBox.Value = 0D;
			this.KilosTextBox.ZeroAllowed = true;
			// 
			// PoundsTextBox
			// 
			this.PoundsTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.PoundsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PoundsTextBox.Location = new System.Drawing.Point(88, 77);
			this.PoundsTextBox.MaxValue = 0D;
			this.PoundsTextBox.MinValue = 0D;
			this.PoundsTextBox.Name = "PoundsTextBox";
			this.PoundsTextBox.NumDecimals = 3;
			this.PoundsTextBox.Size = new System.Drawing.Size(73, 20);
			this.PoundsTextBox.TabIndex = 4;
			this.PoundsTextBox.Text = "0.000";
			this.PoundsTextBox.ToolTip = "";
			this.PoundsTextBox.Value = 0D;
			this.PoundsTextBox.ZeroAllowed = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label25);
			this.groupBox3.Controls.Add(this.label27);
			this.groupBox3.Controls.Add(this.KPHTextBox);
			this.groupBox3.Controls.Add(this.MPHTextBox);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.MSTextBox);
			this.groupBox3.Controls.Add(this.FPSTextBox);
			this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox3.Location = new System.Drawing.Point(12, 434);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(435, 86);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Velocities";
			// 
			// label25
			// 
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label25.Location = new System.Drawing.Point(24, 55);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(52, 13);
			this.label25.TabIndex = 9;
			this.label25.Text = "MPH:";
			this.label25.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label27
			// 
			this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label27.Location = new System.Drawing.Point(216, 55);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(60, 13);
			this.label27.TabIndex = 10;
			this.label27.Text = "KPH:";
			this.label27.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// KPHTextBox
			// 
			this.KPHTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.KPHTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.KPHTextBox.Location = new System.Drawing.Point(282, 52);
			this.KPHTextBox.MaxValue = 0D;
			this.KPHTextBox.MinValue = 0D;
			this.KPHTextBox.Name = "KPHTextBox";
			this.KPHTextBox.NumDecimals = 3;
			this.KPHTextBox.Size = new System.Drawing.Size(73, 20);
			this.KPHTextBox.TabIndex = 3;
			this.KPHTextBox.Text = "0.000";
			this.KPHTextBox.ToolTip = "";
			this.KPHTextBox.Value = 0D;
			this.KPHTextBox.ZeroAllowed = true;
			// 
			// MPHTextBox
			// 
			this.MPHTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.MPHTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MPHTextBox.Location = new System.Drawing.Point(82, 52);
			this.MPHTextBox.MaxValue = 0D;
			this.MPHTextBox.MinValue = 0D;
			this.MPHTextBox.Name = "MPHTextBox";
			this.MPHTextBox.NumDecimals = 3;
			this.MPHTextBox.Size = new System.Drawing.Size(73, 20);
			this.MPHTextBox.TabIndex = 2;
			this.MPHTextBox.Text = "0.000";
			this.MPHTextBox.ToolTip = "";
			this.MPHTextBox.Value = 0D;
			this.MPHTextBox.ZeroAllowed = true;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label10.Location = new System.Drawing.Point(21, 30);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(55, 13);
			this.label10.TabIndex = 4;
			this.label10.Text = "FPS:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label12.Location = new System.Drawing.Point(213, 30);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(63, 13);
			this.label12.TabIndex = 5;
			this.label12.Text = "M/S:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// MSTextBox
			// 
			this.MSTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.MSTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.MSTextBox.Location = new System.Drawing.Point(282, 27);
			this.MSTextBox.MaxValue = 0D;
			this.MSTextBox.MinValue = 0D;
			this.MSTextBox.Name = "MSTextBox";
			this.MSTextBox.NumDecimals = 3;
			this.MSTextBox.Size = new System.Drawing.Size(73, 20);
			this.MSTextBox.TabIndex = 1;
			this.MSTextBox.Text = "0.000";
			this.MSTextBox.ToolTip = "";
			this.MSTextBox.Value = 0D;
			this.MSTextBox.ZeroAllowed = true;
			// 
			// FPSTextBox
			// 
			this.FPSTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.FPSTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FPSTextBox.Location = new System.Drawing.Point(82, 27);
			this.FPSTextBox.MaxValue = 0D;
			this.FPSTextBox.MinValue = 0D;
			this.FPSTextBox.Name = "FPSTextBox";
			this.FPSTextBox.NumDecimals = 3;
			this.FPSTextBox.Size = new System.Drawing.Size(73, 20);
			this.FPSTextBox.TabIndex = 0;
			this.FPSTextBox.Text = "0.000";
			this.FPSTextBox.ToolTip = "";
			this.FPSTextBox.Value = 0D;
			this.FPSTextBox.ZeroAllowed = true;
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(139, 55);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(53, 13);
			this.label31.TabIndex = 5;
			this.label31.Text = "Precision:";
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(233, 55);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(80, 13);
			this.label32.TabIndex = 7;
			this.label32.Text = "Decimal Places";
			// 
			// PrecisionTextBox
			// 
			this.PrecisionTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.PrecisionTextBox.Location = new System.Drawing.Point(198, 52);
			this.PrecisionTextBox.MaxLength = 1;
			this.PrecisionTextBox.MaxValue = 6;
			this.PrecisionTextBox.MinValue = 1;
			this.PrecisionTextBox.Name = "PrecisionTextBox";
			this.PrecisionTextBox.Required = false;
			this.PrecisionTextBox.Size = new System.Drawing.Size(29, 20);
			this.PrecisionTextBox.TabIndex = 0;
			this.PrecisionTextBox.Text = "3";
			this.PrecisionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.PrecisionTextBox.ToolTip = "";
			this.PrecisionTextBox.Value = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.AtMetersLabel);
			this.groupBox1.Controls.Add(this.AtYardsLabel);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.MilsTextBox);
			this.groupBox1.Controls.Add(this.MOATextBox);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox1.Location = new System.Drawing.Point(12, 224);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(435, 88);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Angle";
			// 
			// AtMetersLabel
			// 
			this.AtMetersLabel.AutoEllipsis = true;
			this.AtMetersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AtMetersLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AtMetersLabel.Location = new System.Drawing.Point(222, 59);
			this.AtMetersLabel.Name = "AtMetersLabel";
			this.AtMetersLabel.Size = new System.Drawing.Size(207, 13);
			this.AtMetersLabel.TabIndex = 7;
			this.AtMetersLabel.Text = "0.000 cm  at 0.000 Meters";
			this.AtMetersLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// AtYardsLabel
			// 
			this.AtYardsLabel.AutoEllipsis = true;
			this.AtYardsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AtYardsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AtYardsLabel.Location = new System.Drawing.Point(6, 59);
			this.AtYardsLabel.Name = "AtYardsLabel";
			this.AtYardsLabel.Size = new System.Drawing.Size(207, 13);
			this.AtYardsLabel.TabIndex = 6;
			this.AtYardsLabel.Text = "0.000 in at 0.000 Yards";
			this.AtYardsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label14.Location = new System.Drawing.Point(27, 30);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(55, 13);
			this.label14.TabIndex = 4;
			this.label14.Text = "MOA:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label17
			// 
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label17.Location = new System.Drawing.Point(222, 30);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(63, 13);
			this.label17.TabIndex = 5;
			this.label17.Text = "Mils:";
			this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// MilsTextBox
			// 
			this.MilsTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.MilsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.MilsTextBox.Location = new System.Drawing.Point(288, 27);
			this.MilsTextBox.MaxValue = 0D;
			this.MilsTextBox.MinValue = 0D;
			this.MilsTextBox.Name = "MilsTextBox";
			this.MilsTextBox.NumDecimals = 3;
			this.MilsTextBox.Size = new System.Drawing.Size(73, 20);
			this.MilsTextBox.TabIndex = 1;
			this.MilsTextBox.Text = "0.000";
			this.MilsTextBox.ToolTip = "";
			this.MilsTextBox.Value = 0D;
			this.MilsTextBox.ZeroAllowed = true;
			// 
			// MOATextBox
			// 
			this.MOATextBox.BackColor = System.Drawing.SystemColors.Window;
			this.MOATextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MOATextBox.Location = new System.Drawing.Point(88, 27);
			this.MOATextBox.MaxValue = 0D;
			this.MOATextBox.MinValue = 0D;
			this.MOATextBox.Name = "MOATextBox";
			this.MOATextBox.NumDecimals = 3;
			this.MOATextBox.Size = new System.Drawing.Size(73, 20);
			this.MOATextBox.TabIndex = 0;
			this.MOATextBox.Text = "0.000";
			this.MOATextBox.ToolTip = "";
			this.MOATextBox.Value = 0D;
			this.MOATextBox.ZeroAllowed = true;
			// 
			// cConversionForm
			// 
			this.AcceptButton = this.CloseButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CloseButton;
			this.ClientSize = new System.Drawing.Size(449, 558);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label32);
			this.Controls.Add(this.PrecisionTextBox);
			this.Controls.Add(this.label31);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.MeasurementsGroupBox);
			this.Controls.Add(this.CloseButton);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cConversionForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Conversion Calculator";
			this.MeasurementsGroupBox.ResumeLayout(false);
			this.MeasurementsGroupBox.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button CloseButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private CommonLib.Controls.cDoubleValueTextBox InchesTextBox;
		private CommonLib.Controls.cDoubleValueTextBox MillimetersTextBox;
		private System.Windows.Forms.GroupBox MeasurementsGroupBox;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label24;
		private CommonLib.Controls.cDoubleValueTextBox KilometersTextBox;
		private CommonLib.Controls.cDoubleValueTextBox MilesTextBox;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label21;
		private CommonLib.Controls.cDoubleValueTextBox MetersTextBox;
		private CommonLib.Controls.cDoubleValueTextBox YardsTextBox;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label18;
		private CommonLib.Controls.cDoubleValueTextBox CentimetersTextBox;
		private CommonLib.Controls.cDoubleValueTextBox FeetTextBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private CommonLib.Controls.cDoubleValueTextBox GramsTextBox;
		private CommonLib.Controls.cDoubleValueTextBox GrainsTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private CommonLib.Controls.cDoubleValueTextBox KilosTextBox;
		private CommonLib.Controls.cDoubleValueTextBox PoundsTextBox;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label27;
		private CommonLib.Controls.cDoubleValueTextBox KPHTextBox;
		private CommonLib.Controls.cDoubleValueTextBox MPHTextBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private CommonLib.Controls.cDoubleValueTextBox MSTextBox;
		private CommonLib.Controls.cDoubleValueTextBox FPSTextBox;
		private System.Windows.Forms.Label label28;
		private CommonLib.Controls.cDoubleValueTextBox OuncesTextBox;
		private System.Windows.Forms.Label label31;
		private CommonLib.Controls.cIntegerValueTextBox PrecisionTextBox;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label6;
		private CommonLib.Controls.cDoubleValueTextBox MilligramsTextBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label17;
		private CommonLib.Controls.cDoubleValueTextBox MilsTextBox;
		private CommonLib.Controls.cDoubleValueTextBox MOATextBox;
		private System.Windows.Forms.Label AtMetersLabel;
		private System.Windows.Forms.Label AtYardsLabel;
		}
	}