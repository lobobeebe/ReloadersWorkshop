//============================================================================*
// cCaliberForm.Designer.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cCaliberForm Class
	//============================================================================*

	partial class cCaliberForm
		{
		private System.ComponentModel.IContainer components = null;

		//============================================================================*
		// Dispose()
		//============================================================================*

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
			System.Windows.Forms.Label label9;
			System.Windows.Forms.Label label13;
			System.Windows.Forms.Label label10;
			System.Windows.Forms.Label label2;
			this.MinCaseLengthLabel = new System.Windows.Forms.Label();
			this.MinCaseLengthMeasurementLabel = new System.Windows.Forms.Label();
			this.MaxCaseLengthMeasurementLabel = new System.Windows.Forms.Label();
			this.MaxCaseLengthLabel = new System.Windows.Forms.Label();
			this.MinBulletDiameterMeasurementLabel = new System.Windows.Forms.Label();
			this.MinBulletDiameterLabel = new System.Windows.Forms.Label();
			this.MaxCOLMeasurementLabel = new System.Windows.Forms.Label();
			this.MaxCOLLabel = new System.Windows.Forms.Label();
			this.MaxBulletDiameterMeasurementLabel = new System.Windows.Forms.Label();
			this.MaxBulletDiameterLabel = new System.Windows.Forms.Label();
			this.MaxBulletWeightMeasurementLabel = new System.Windows.Forms.Label();
			this.MaxBulletWeightLabel = new System.Windows.Forms.Label();
			this.MinBulletWeightMeasurementLabel = new System.Windows.Forms.Label();
			this.MinBulletWeightLabel = new System.Windows.Forms.Label();
			this.GeneralGroupBox = new System.Windows.Forms.GroupBox();
			this.SAAMIPDFTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.CrossUseCheckBox = new System.Windows.Forms.CheckBox();
			this.TestSAAMIPDFButton = new System.Windows.Forms.Button();
			this.HeadStampTextBox = new CommonLib.Controls.cTextBox();
			this.NameTextBox = new CommonLib.Controls.cTextBox();
			this.FirearmTypeCombo = new ReloadersWorkShop.Controls.cFirearmTypeCombo();
			this.RevolverRadioButton = new System.Windows.Forms.RadioButton();
			this.PistolRadioButton = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.RimfireCheckBox = new System.Windows.Forms.CheckBox();
			this.MaxNeckDiameterTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.MaxNeckDiameterMeasurementLabel = new System.Windows.Forms.Label();
			this.MaxNeckDiameterLabel = new System.Windows.Forms.Label();
			this.MagnumPrimerCheckBox = new System.Windows.Forms.CheckBox();
			this.LargePrimerCheckBox = new System.Windows.Forms.CheckBox();
			this.SmallPrimerCheckBox = new System.Windows.Forms.CheckBox();
			this.MaxBulletWeightTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.MinBulletWeightTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.MaxCOLTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.MaxCaseLengthTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.CaseTrimLengthTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.MaxBulletDiameterTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.MinBulletDiameterTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.FormCancelButton = new CommonLib.Controls.cCancelButton();
			this.OKButton = new CommonLib.Controls.cOKButton();
			label1 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			this.GeneralGroupBox.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label1.ForeColor = System.Drawing.SystemColors.ControlText;
			label1.Location = new System.Drawing.Point(78, 61);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(49, 17);
			label1.TabIndex = 0;
			label1.Text = "Name:";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label9.ForeColor = System.Drawing.SystemColors.ControlText;
			label9.Location = new System.Drawing.Point(31, 32);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(96, 17);
			label9.TabIndex = 16;
			label9.Text = "Firearm Type:";
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label13.ForeColor = System.Drawing.SystemColors.ControlText;
			label13.Location = new System.Drawing.Point(36, 90);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(90, 17);
			label13.TabIndex = 17;
			label13.Text = "Head Stamp:";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label10.ForeColor = System.Drawing.SystemColors.ControlText;
			label10.Location = new System.Drawing.Point(43, 30);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(84, 17);
			label10.TabIndex = 16;
			label10.Text = "Primer Size:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label2.ForeColor = System.Drawing.SystemColors.ControlText;
			label2.Location = new System.Drawing.Point(5, 128);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(121, 17);
			label2.TabIndex = 19;
			label2.Text = "SAAMI PDF Page:";
			// 
			// MinCaseLengthLabel
			// 
			this.MinCaseLengthLabel.AutoSize = true;
			this.MinCaseLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinCaseLengthLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MinCaseLengthLabel.Location = new System.Drawing.Point(16, 121);
			this.MinCaseLengthLabel.Name = "MinCaseLengthLabel";
			this.MinCaseLengthLabel.Size = new System.Drawing.Size(124, 17);
			this.MinCaseLengthLabel.TabIndex = 4;
			this.MinCaseLengthLabel.Text = "Case Trim Length:";
			// 
			// MinCaseLengthMeasurementLabel
			// 
			this.MinCaseLengthMeasurementLabel.AutoSize = true;
			this.MinCaseLengthMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinCaseLengthMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MinCaseLengthMeasurementLabel.Location = new System.Drawing.Point(217, 121);
			this.MinCaseLengthMeasurementLabel.Name = "MinCaseLengthMeasurementLabel";
			this.MinCaseLengthMeasurementLabel.Size = new System.Drawing.Size(23, 17);
			this.MinCaseLengthMeasurementLabel.TabIndex = 6;
			this.MinCaseLengthMeasurementLabel.Text = "in.";
			// 
			// MaxCaseLengthMeasurementLabel
			// 
			this.MaxCaseLengthMeasurementLabel.AutoSize = true;
			this.MaxCaseLengthMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxCaseLengthMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxCaseLengthMeasurementLabel.Location = new System.Drawing.Point(475, 121);
			this.MaxCaseLengthMeasurementLabel.Name = "MaxCaseLengthMeasurementLabel";
			this.MaxCaseLengthMeasurementLabel.Size = new System.Drawing.Size(23, 17);
			this.MaxCaseLengthMeasurementLabel.TabIndex = 9;
			this.MaxCaseLengthMeasurementLabel.Text = "in.";
			// 
			// MaxCaseLengthLabel
			// 
			this.MaxCaseLengthLabel.AutoSize = true;
			this.MaxCaseLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxCaseLengthLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxCaseLengthLabel.Location = new System.Drawing.Point(276, 121);
			this.MaxCaseLengthLabel.Name = "MaxCaseLengthLabel";
			this.MaxCaseLengthLabel.Size = new System.Drawing.Size(121, 17);
			this.MaxCaseLengthLabel.TabIndex = 7;
			this.MaxCaseLengthLabel.Text = "Max Case Length:";
			// 
			// MinBulletDiameterMeasurementLabel
			// 
			this.MinBulletDiameterMeasurementLabel.AutoSize = true;
			this.MinBulletDiameterMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinBulletDiameterMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MinBulletDiameterMeasurementLabel.Location = new System.Drawing.Point(217, 60);
			this.MinBulletDiameterMeasurementLabel.Name = "MinBulletDiameterMeasurementLabel";
			this.MinBulletDiameterMeasurementLabel.Size = new System.Drawing.Size(23, 17);
			this.MinBulletDiameterMeasurementLabel.TabIndex = 12;
			this.MinBulletDiameterMeasurementLabel.Text = "in.";
			// 
			// MinBulletDiameterLabel
			// 
			this.MinBulletDiameterLabel.AutoSize = true;
			this.MinBulletDiameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinBulletDiameterLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MinBulletDiameterLabel.Location = new System.Drawing.Point(5, 60);
			this.MinBulletDiameterLabel.Name = "MinBulletDiameterLabel";
			this.MinBulletDiameterLabel.Size = new System.Drawing.Size(134, 17);
			this.MinBulletDiameterLabel.TabIndex = 10;
			this.MinBulletDiameterLabel.Text = "Min Bullet Diameter:";
			// 
			// MaxCOLMeasurementLabel
			// 
			this.MaxCOLMeasurementLabel.AutoSize = true;
			this.MaxCOLMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxCOLMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxCOLMeasurementLabel.Location = new System.Drawing.Point(217, 150);
			this.MaxCOLMeasurementLabel.Name = "MaxCOLMeasurementLabel";
			this.MaxCOLMeasurementLabel.Size = new System.Drawing.Size(23, 17);
			this.MaxCOLMeasurementLabel.TabIndex = 15;
			this.MaxCOLMeasurementLabel.Text = "in.";
			// 
			// MaxCOLLabel
			// 
			this.MaxCOLLabel.AutoSize = true;
			this.MaxCOLLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxCOLLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxCOLLabel.Location = new System.Drawing.Point(59, 150);
			this.MaxCOLLabel.Name = "MaxCOLLabel";
			this.MaxCOLLabel.Size = new System.Drawing.Size(78, 17);
			this.MaxCOLLabel.TabIndex = 13;
			this.MaxCOLLabel.Text = "Max COAL:";
			// 
			// MaxBulletDiameterMeasurementLabel
			// 
			this.MaxBulletDiameterMeasurementLabel.AutoSize = true;
			this.MaxBulletDiameterMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxBulletDiameterMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxBulletDiameterMeasurementLabel.Location = new System.Drawing.Point(475, 62);
			this.MaxBulletDiameterMeasurementLabel.Name = "MaxBulletDiameterMeasurementLabel";
			this.MaxBulletDiameterMeasurementLabel.Size = new System.Drawing.Size(23, 17);
			this.MaxBulletDiameterMeasurementLabel.TabIndex = 19;
			this.MaxBulletDiameterMeasurementLabel.Text = "in.";
			// 
			// MaxBulletDiameterLabel
			// 
			this.MaxBulletDiameterLabel.AutoSize = true;
			this.MaxBulletDiameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxBulletDiameterLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxBulletDiameterLabel.Location = new System.Drawing.Point(261, 60);
			this.MaxBulletDiameterLabel.Name = "MaxBulletDiameterLabel";
			this.MaxBulletDiameterLabel.Size = new System.Drawing.Size(137, 17);
			this.MaxBulletDiameterLabel.TabIndex = 18;
			this.MaxBulletDiameterLabel.Text = "Max Bullet Diameter:";
			// 
			// MaxBulletWeightMeasurementLabel
			// 
			this.MaxBulletWeightMeasurementLabel.AutoSize = true;
			this.MaxBulletWeightMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxBulletWeightMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxBulletWeightMeasurementLabel.Location = new System.Drawing.Point(475, 90);
			this.MaxBulletWeightMeasurementLabel.Name = "MaxBulletWeightMeasurementLabel";
			this.MaxBulletWeightMeasurementLabel.Size = new System.Drawing.Size(21, 17);
			this.MaxBulletWeightMeasurementLabel.TabIndex = 25;
			this.MaxBulletWeightMeasurementLabel.Text = "gr";
			// 
			// MaxBulletWeightLabel
			// 
			this.MaxBulletWeightLabel.AutoSize = true;
			this.MaxBulletWeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxBulletWeightLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxBulletWeightLabel.Location = new System.Drawing.Point(272, 90);
			this.MaxBulletWeightLabel.Name = "MaxBulletWeightLabel";
			this.MaxBulletWeightLabel.Size = new System.Drawing.Size(124, 17);
			this.MaxBulletWeightLabel.TabIndex = 24;
			this.MaxBulletWeightLabel.Text = "Max Bullet Weight:";
			// 
			// MinBulletWeightMeasurementLabel
			// 
			this.MinBulletWeightMeasurementLabel.AutoSize = true;
			this.MinBulletWeightMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinBulletWeightMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MinBulletWeightMeasurementLabel.Location = new System.Drawing.Point(217, 90);
			this.MinBulletWeightMeasurementLabel.Name = "MinBulletWeightMeasurementLabel";
			this.MinBulletWeightMeasurementLabel.Size = new System.Drawing.Size(21, 17);
			this.MinBulletWeightMeasurementLabel.TabIndex = 23;
			this.MinBulletWeightMeasurementLabel.Text = "gr";
			// 
			// MinBulletWeightLabel
			// 
			this.MinBulletWeightLabel.AutoSize = true;
			this.MinBulletWeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinBulletWeightLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MinBulletWeightLabel.Location = new System.Drawing.Point(16, 90);
			this.MinBulletWeightLabel.Name = "MinBulletWeightLabel";
			this.MinBulletWeightLabel.Size = new System.Drawing.Size(121, 17);
			this.MinBulletWeightLabel.TabIndex = 22;
			this.MinBulletWeightLabel.Text = "Min Bullet Weight:";
			// 
			// GeneralGroupBox
			// 
			this.GeneralGroupBox.Controls.Add(this.SAAMIPDFTextBox);
			this.GeneralGroupBox.Controls.Add(this.CrossUseCheckBox);
			this.GeneralGroupBox.Controls.Add(this.TestSAAMIPDFButton);
			this.GeneralGroupBox.Controls.Add(label2);
			this.GeneralGroupBox.Controls.Add(this.HeadStampTextBox);
			this.GeneralGroupBox.Controls.Add(this.NameTextBox);
			this.GeneralGroupBox.Controls.Add(this.FirearmTypeCombo);
			this.GeneralGroupBox.Controls.Add(this.RevolverRadioButton);
			this.GeneralGroupBox.Controls.Add(this.PistolRadioButton);
			this.GeneralGroupBox.Controls.Add(label13);
			this.GeneralGroupBox.Controls.Add(label9);
			this.GeneralGroupBox.Controls.Add(label1);
			this.GeneralGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GeneralGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.GeneralGroupBox.Location = new System.Drawing.Point(13, 11);
			this.GeneralGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.GeneralGroupBox.Name = "GeneralGroupBox";
			this.GeneralGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.GeneralGroupBox.Size = new System.Drawing.Size(523, 160);
			this.GeneralGroupBox.TabIndex = 0;
			this.GeneralGroupBox.TabStop = false;
			this.GeneralGroupBox.Text = "General";
			// 
			// SAAMIPDFTextBox
			// 
			this.SAAMIPDFTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.SAAMIPDFTextBox.Location = new System.Drawing.Point(124, 122);
			this.SAAMIPDFTextBox.MaxValue = 0;
			this.SAAMIPDFTextBox.MinValue = 0;
			this.SAAMIPDFTextBox.Name = "SAAMIPDFTextBox";
			this.SAAMIPDFTextBox.Required = false;
			this.SAAMIPDFTextBox.Size = new System.Drawing.Size(58, 27);
			this.SAAMIPDFTextBox.TabIndex = 22;
			this.SAAMIPDFTextBox.Text = "0";
			this.SAAMIPDFTextBox.ToolTip = "";
			this.SAAMIPDFTextBox.Value = 0;
			// 
			// CrossUseCheckBox
			// 
			this.CrossUseCheckBox.AutoCheck = false;
			this.CrossUseCheckBox.AutoSize = true;
			this.CrossUseCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CrossUseCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CrossUseCheckBox.Location = new System.Drawing.Point(265, 28);
			this.CrossUseCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.CrossUseCheckBox.Name = "CrossUseCheckBox";
			this.CrossUseCheckBox.Size = new System.Drawing.Size(95, 21);
			this.CrossUseCheckBox.TabIndex = 21;
			this.CrossUseCheckBox.Text = "Cross Use";
			this.CrossUseCheckBox.UseVisualStyleBackColor = true;
			// 
			// TestSAAMIPDFButton
			// 
			this.TestSAAMIPDFButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TestSAAMIPDFButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TestSAAMIPDFButton.Location = new System.Drawing.Point(188, 124);
			this.TestSAAMIPDFButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TestSAAMIPDFButton.Name = "TestSAAMIPDFButton";
			this.TestSAAMIPDFButton.Size = new System.Drawing.Size(59, 23);
			this.TestSAAMIPDFButton.TabIndex = 6;
			this.TestSAAMIPDFButton.Text = "View";
			this.TestSAAMIPDFButton.UseVisualStyleBackColor = true;
			// 
			// HeadStampTextBox
			// 
			this.HeadStampTextBox.BackColor = System.Drawing.Color.LightPink;
			this.HeadStampTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.HeadStampTextBox.Location = new System.Drawing.Point(124, 86);
			this.HeadStampTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.HeadStampTextBox.MaxLength = 20;
			this.HeadStampTextBox.Name = "HeadStampTextBox";
			this.HeadStampTextBox.Required = true;
			this.HeadStampTextBox.Size = new System.Drawing.Size(247, 23);
			this.HeadStampTextBox.TabIndex = 2;
			this.HeadStampTextBox.ToolTip = "";
			this.HeadStampTextBox.ValidChars = "";
			this.HeadStampTextBox.Value = "";
			// 
			// NameTextBox
			// 
			this.NameTextBox.BackColor = System.Drawing.Color.LightPink;
			this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NameTextBox.Location = new System.Drawing.Point(124, 57);
			this.NameTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.NameTextBox.MaxLength = 45;
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Required = true;
			this.NameTextBox.Size = new System.Drawing.Size(247, 23);
			this.NameTextBox.TabIndex = 1;
			this.NameTextBox.ToolTip = "";
			this.NameTextBox.ValidChars = "";
			this.NameTextBox.Value = "";
			// 
			// FirearmTypeCombo
			// 
			this.FirearmTypeCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.FirearmTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FirearmTypeCombo.DropDownWidth = 115;
			this.FirearmTypeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FirearmTypeCombo.FormattingEnabled = true;
			this.FirearmTypeCombo.IncludeAny = false;
			this.FirearmTypeCombo.IncludeShotgun = true;
			this.FirearmTypeCombo.Items.AddRange(new object[] {
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun",
            "Handgun",
            "Rifle",
            "Shotgun"});
			this.FirearmTypeCombo.Location = new System.Drawing.Point(124, 26);
			this.FirearmTypeCombo.Margin = new System.Windows.Forms.Padding(4);
			this.FirearmTypeCombo.Name = "FirearmTypeCombo";
			this.FirearmTypeCombo.ShowToolTips = true;
			this.FirearmTypeCombo.Size = new System.Drawing.Size(132, 25);
			this.FirearmTypeCombo.TabIndex = 0;
			this.FirearmTypeCombo.ToolTip = "";
			this.FirearmTypeCombo.Value = ReloadersWorkShop.cFirearm.eFireArmType.Handgun;
			// 
			// RevolverRadioButton
			// 
			this.RevolverRadioButton.AutoCheck = false;
			this.RevolverRadioButton.AutoSize = true;
			this.RevolverRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RevolverRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RevolverRadioButton.Location = new System.Drawing.Point(408, 90);
			this.RevolverRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.RevolverRadioButton.Name = "RevolverRadioButton";
			this.RevolverRadioButton.Size = new System.Drawing.Size(89, 21);
			this.RevolverRadioButton.TabIndex = 4;
			this.RevolverRadioButton.TabStop = true;
			this.RevolverRadioButton.Text = "Revolver:";
			this.RevolverRadioButton.UseVisualStyleBackColor = true;
			// 
			// PistolRadioButton
			// 
			this.PistolRadioButton.AutoCheck = false;
			this.PistolRadioButton.AutoSize = true;
			this.PistolRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PistolRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PistolRadioButton.Location = new System.Drawing.Point(408, 60);
			this.PistolRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PistolRadioButton.Name = "PistolRadioButton";
			this.PistolRadioButton.Size = new System.Drawing.Size(67, 21);
			this.PistolRadioButton.TabIndex = 3;
			this.PistolRadioButton.TabStop = true;
			this.PistolRadioButton.Text = "Pistol:";
			this.PistolRadioButton.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.RimfireCheckBox);
			this.groupBox2.Controls.Add(this.MaxNeckDiameterTextBox);
			this.groupBox2.Controls.Add(this.MaxNeckDiameterMeasurementLabel);
			this.groupBox2.Controls.Add(this.MaxNeckDiameterLabel);
			this.groupBox2.Controls.Add(this.MagnumPrimerCheckBox);
			this.groupBox2.Controls.Add(this.LargePrimerCheckBox);
			this.groupBox2.Controls.Add(this.SmallPrimerCheckBox);
			this.groupBox2.Controls.Add(this.MaxBulletWeightTextBox);
			this.groupBox2.Controls.Add(this.MinBulletWeightTextBox);
			this.groupBox2.Controls.Add(this.MaxCOLTextBox);
			this.groupBox2.Controls.Add(this.MaxCaseLengthTextBox);
			this.groupBox2.Controls.Add(this.CaseTrimLengthTextBox);
			this.groupBox2.Controls.Add(this.MaxBulletDiameterTextBox);
			this.groupBox2.Controls.Add(this.MinBulletDiameterTextBox);
			this.groupBox2.Controls.Add(this.MaxBulletWeightMeasurementLabel);
			this.groupBox2.Controls.Add(this.MaxBulletWeightLabel);
			this.groupBox2.Controls.Add(this.MinBulletWeightMeasurementLabel);
			this.groupBox2.Controls.Add(this.MinBulletWeightLabel);
			this.groupBox2.Controls.Add(this.MaxBulletDiameterMeasurementLabel);
			this.groupBox2.Controls.Add(this.MaxBulletDiameterLabel);
			this.groupBox2.Controls.Add(label10);
			this.groupBox2.Controls.Add(this.MaxCOLMeasurementLabel);
			this.groupBox2.Controls.Add(this.MaxCOLLabel);
			this.groupBox2.Controls.Add(this.MinBulletDiameterMeasurementLabel);
			this.groupBox2.Controls.Add(this.MinBulletDiameterLabel);
			this.groupBox2.Controls.Add(this.MaxCaseLengthMeasurementLabel);
			this.groupBox2.Controls.Add(this.MaxCaseLengthLabel);
			this.groupBox2.Controls.Add(this.MinCaseLengthMeasurementLabel);
			this.groupBox2.Controls.Add(this.MinCaseLengthLabel);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox2.Location = new System.Drawing.Point(13, 176);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox2.Size = new System.Drawing.Size(523, 183);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Sizing";
			// 
			// RimfireCheckBox
			// 
			this.RimfireCheckBox.AutoCheck = false;
			this.RimfireCheckBox.AutoSize = true;
			this.RimfireCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RimfireCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RimfireCheckBox.Location = new System.Drawing.Point(379, 28);
			this.RimfireCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.RimfireCheckBox.Name = "RimfireCheckBox";
			this.RimfireCheckBox.Size = new System.Drawing.Size(74, 21);
			this.RimfireCheckBox.TabIndex = 32;
			this.RimfireCheckBox.Text = "Rimfire";
			this.RimfireCheckBox.UseVisualStyleBackColor = true;
			// 
			// MaxNeckDiameterTextBox
			// 
			this.MaxNeckDiameterTextBox.BackColor = System.Drawing.Color.LightPink;
			this.MaxNeckDiameterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxNeckDiameterTextBox.Location = new System.Drawing.Point(404, 146);
			this.MaxNeckDiameterTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.MaxNeckDiameterTextBox.MaxLength = 5;
			this.MaxNeckDiameterTextBox.MaxValue = 4D;
			this.MaxNeckDiameterTextBox.MinValue = 1D;
			this.MaxNeckDiameterTextBox.Name = "MaxNeckDiameterTextBox";
			this.MaxNeckDiameterTextBox.NumDecimals = 3;
			this.MaxNeckDiameterTextBox.Size = new System.Drawing.Size(63, 23);
			this.MaxNeckDiameterTextBox.TabIndex = 10;
			this.MaxNeckDiameterTextBox.Text = "0.000";
			this.MaxNeckDiameterTextBox.ToolTip = "";
			this.MaxNeckDiameterTextBox.Value = 0D;
			this.MaxNeckDiameterTextBox.ZeroAllowed = true;
			// 
			// MaxNeckDiameterMeasurementLabel
			// 
			this.MaxNeckDiameterMeasurementLabel.AutoSize = true;
			this.MaxNeckDiameterMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxNeckDiameterMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxNeckDiameterMeasurementLabel.Location = new System.Drawing.Point(475, 150);
			this.MaxNeckDiameterMeasurementLabel.Name = "MaxNeckDiameterMeasurementLabel";
			this.MaxNeckDiameterMeasurementLabel.Size = new System.Drawing.Size(23, 17);
			this.MaxNeckDiameterMeasurementLabel.TabIndex = 31;
			this.MaxNeckDiameterMeasurementLabel.Text = "in.";
			// 
			// MaxNeckDiameterLabel
			// 
			this.MaxNeckDiameterLabel.AutoSize = true;
			this.MaxNeckDiameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxNeckDiameterLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxNeckDiameterLabel.Location = new System.Drawing.Point(259, 150);
			this.MaxNeckDiameterLabel.Name = "MaxNeckDiameterLabel";
			this.MaxNeckDiameterLabel.Size = new System.Drawing.Size(134, 17);
			this.MaxNeckDiameterLabel.TabIndex = 29;
			this.MaxNeckDiameterLabel.Text = "Max Neck Diameter:";
			// 
			// MagnumPrimerCheckBox
			// 
			this.MagnumPrimerCheckBox.AutoCheck = false;
			this.MagnumPrimerCheckBox.AutoSize = true;
			this.MagnumPrimerCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MagnumPrimerCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MagnumPrimerCheckBox.Location = new System.Drawing.Point(287, 28);
			this.MagnumPrimerCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.MagnumPrimerCheckBox.Name = "MagnumPrimerCheckBox";
			this.MagnumPrimerCheckBox.Size = new System.Drawing.Size(84, 21);
			this.MagnumPrimerCheckBox.TabIndex = 2;
			this.MagnumPrimerCheckBox.Text = "Magnum";
			this.MagnumPrimerCheckBox.UseVisualStyleBackColor = true;
			// 
			// LargePrimerCheckBox
			// 
			this.LargePrimerCheckBox.AutoCheck = false;
			this.LargePrimerCheckBox.AutoSize = true;
			this.LargePrimerCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LargePrimerCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LargePrimerCheckBox.Location = new System.Drawing.Point(208, 28);
			this.LargePrimerCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.LargePrimerCheckBox.Name = "LargePrimerCheckBox";
			this.LargePrimerCheckBox.Size = new System.Drawing.Size(67, 21);
			this.LargePrimerCheckBox.TabIndex = 1;
			this.LargePrimerCheckBox.Text = "Large";
			this.LargePrimerCheckBox.UseVisualStyleBackColor = true;
			// 
			// SmallPrimerCheckBox
			// 
			this.SmallPrimerCheckBox.AutoCheck = false;
			this.SmallPrimerCheckBox.AutoSize = true;
			this.SmallPrimerCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SmallPrimerCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SmallPrimerCheckBox.Location = new System.Drawing.Point(132, 28);
			this.SmallPrimerCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.SmallPrimerCheckBox.Name = "SmallPrimerCheckBox";
			this.SmallPrimerCheckBox.Size = new System.Drawing.Size(64, 21);
			this.SmallPrimerCheckBox.TabIndex = 0;
			this.SmallPrimerCheckBox.Text = "Small";
			this.SmallPrimerCheckBox.UseVisualStyleBackColor = true;
			// 
			// MaxBulletWeightTextBox
			// 
			this.MaxBulletWeightTextBox.BackColor = System.Drawing.Color.LightPink;
			this.MaxBulletWeightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxBulletWeightTextBox.Location = new System.Drawing.Point(404, 86);
			this.MaxBulletWeightTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.MaxBulletWeightTextBox.MaxLength = 5;
			this.MaxBulletWeightTextBox.MaxValue = 750D;
			this.MaxBulletWeightTextBox.MinValue = 5D;
			this.MaxBulletWeightTextBox.Name = "MaxBulletWeightTextBox";
			this.MaxBulletWeightTextBox.NumDecimals = 1;
			this.MaxBulletWeightTextBox.Size = new System.Drawing.Size(63, 23);
			this.MaxBulletWeightTextBox.TabIndex = 6;
			this.MaxBulletWeightTextBox.Text = "0.0";
			this.MaxBulletWeightTextBox.ToolTip = "";
			this.MaxBulletWeightTextBox.Value = 0D;
			this.MaxBulletWeightTextBox.ZeroAllowed = true;
			// 
			// MinBulletWeightTextBox
			// 
			this.MinBulletWeightTextBox.BackColor = System.Drawing.Color.LightPink;
			this.MinBulletWeightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinBulletWeightTextBox.Location = new System.Drawing.Point(147, 86);
			this.MinBulletWeightTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.MinBulletWeightTextBox.MaxLength = 5;
			this.MinBulletWeightTextBox.MaxValue = 750D;
			this.MinBulletWeightTextBox.MinValue = 5D;
			this.MinBulletWeightTextBox.Name = "MinBulletWeightTextBox";
			this.MinBulletWeightTextBox.NumDecimals = 1;
			this.MinBulletWeightTextBox.Size = new System.Drawing.Size(63, 23);
			this.MinBulletWeightTextBox.TabIndex = 5;
			this.MinBulletWeightTextBox.Text = "0.0";
			this.MinBulletWeightTextBox.ToolTip = "";
			this.MinBulletWeightTextBox.Value = 0D;
			this.MinBulletWeightTextBox.ZeroAllowed = true;
			// 
			// MaxCOLTextBox
			// 
			this.MaxCOLTextBox.BackColor = System.Drawing.Color.LightPink;
			this.MaxCOLTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxCOLTextBox.Location = new System.Drawing.Point(147, 146);
			this.MaxCOLTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.MaxCOLTextBox.MaxLength = 5;
			this.MaxCOLTextBox.MaxValue = 6D;
			this.MaxCOLTextBox.MinValue = 1D;
			this.MaxCOLTextBox.Name = "MaxCOLTextBox";
			this.MaxCOLTextBox.NumDecimals = 3;
			this.MaxCOLTextBox.Size = new System.Drawing.Size(63, 23);
			this.MaxCOLTextBox.TabIndex = 9;
			this.MaxCOLTextBox.Text = "0.000";
			this.MaxCOLTextBox.ToolTip = "";
			this.MaxCOLTextBox.Value = 0D;
			this.MaxCOLTextBox.ZeroAllowed = true;
			// 
			// MaxCaseLengthTextBox
			// 
			this.MaxCaseLengthTextBox.BackColor = System.Drawing.Color.LightPink;
			this.MaxCaseLengthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxCaseLengthTextBox.Location = new System.Drawing.Point(404, 117);
			this.MaxCaseLengthTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.MaxCaseLengthTextBox.MaxLength = 5;
			this.MaxCaseLengthTextBox.MaxValue = 4D;
			this.MaxCaseLengthTextBox.MinValue = 1D;
			this.MaxCaseLengthTextBox.Name = "MaxCaseLengthTextBox";
			this.MaxCaseLengthTextBox.NumDecimals = 3;
			this.MaxCaseLengthTextBox.Size = new System.Drawing.Size(63, 23);
			this.MaxCaseLengthTextBox.TabIndex = 8;
			this.MaxCaseLengthTextBox.Text = "0.000";
			this.MaxCaseLengthTextBox.ToolTip = "";
			this.MaxCaseLengthTextBox.Value = 0D;
			this.MaxCaseLengthTextBox.ZeroAllowed = true;
			// 
			// CaseTrimLengthTextBox
			// 
			this.CaseTrimLengthTextBox.BackColor = System.Drawing.Color.LightPink;
			this.CaseTrimLengthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CaseTrimLengthTextBox.Location = new System.Drawing.Point(147, 117);
			this.CaseTrimLengthTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.CaseTrimLengthTextBox.MaxLength = 5;
			this.CaseTrimLengthTextBox.MaxValue = 4D;
			this.CaseTrimLengthTextBox.MinValue = 1D;
			this.CaseTrimLengthTextBox.Name = "CaseTrimLengthTextBox";
			this.CaseTrimLengthTextBox.NumDecimals = 3;
			this.CaseTrimLengthTextBox.Size = new System.Drawing.Size(63, 23);
			this.CaseTrimLengthTextBox.TabIndex = 7;
			this.CaseTrimLengthTextBox.Text = "0.000";
			this.CaseTrimLengthTextBox.ToolTip = "";
			this.CaseTrimLengthTextBox.Value = 0D;
			this.CaseTrimLengthTextBox.ZeroAllowed = true;
			// 
			// MaxBulletDiameterTextBox
			// 
			this.MaxBulletDiameterTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.MaxBulletDiameterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxBulletDiameterTextBox.Location = new System.Drawing.Point(404, 57);
			this.MaxBulletDiameterTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.MaxBulletDiameterTextBox.MaxLength = 5;
			this.MaxBulletDiameterTextBox.MaxValue = 1D;
			this.MaxBulletDiameterTextBox.MinValue = 0D;
			this.MaxBulletDiameterTextBox.Name = "MaxBulletDiameterTextBox";
			this.MaxBulletDiameterTextBox.NumDecimals = 3;
			this.MaxBulletDiameterTextBox.Size = new System.Drawing.Size(63, 23);
			this.MaxBulletDiameterTextBox.TabIndex = 4;
			this.MaxBulletDiameterTextBox.Text = "0.000";
			this.MaxBulletDiameterTextBox.ToolTip = "";
			this.MaxBulletDiameterTextBox.Value = 0D;
			this.MaxBulletDiameterTextBox.ZeroAllowed = true;
			// 
			// MinBulletDiameterTextBox
			// 
			this.MinBulletDiameterTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.MinBulletDiameterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinBulletDiameterTextBox.Location = new System.Drawing.Point(147, 58);
			this.MinBulletDiameterTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.MinBulletDiameterTextBox.MaxLength = 5;
			this.MinBulletDiameterTextBox.MaxValue = 1D;
			this.MinBulletDiameterTextBox.MinValue = 0D;
			this.MinBulletDiameterTextBox.Name = "MinBulletDiameterTextBox";
			this.MinBulletDiameterTextBox.NumDecimals = 3;
			this.MinBulletDiameterTextBox.Size = new System.Drawing.Size(63, 23);
			this.MinBulletDiameterTextBox.TabIndex = 3;
			this.MinBulletDiameterTextBox.Text = "0.000";
			this.MinBulletDiameterTextBox.ToolTip = "";
			this.MinBulletDiameterTextBox.Value = 0D;
			this.MinBulletDiameterTextBox.ZeroAllowed = true;
			// 
			// FormCancelButton
			// 
			this.FormCancelButton.ButtonType = CommonLib.Controls.cCancelButton.eButtonTypes.Cancel;
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Location = new System.Drawing.Point(281, 372);
			this.FormCancelButton.Margin = new System.Windows.Forms.Padding(4);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.ShowToolTips = true;
			this.FormCancelButton.Size = new System.Drawing.Size(100, 28);
			this.FormCancelButton.TabIndex = 2;
			this.FormCancelButton.Text = "Cancel";
			this.FormCancelButton.ToolTip = "Click to cancel changes and exit.";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			// 
			// OKButton
			// 
			this.OKButton.ButtonType = CommonLib.Controls.cOKButton.eButtonTypes.OK;
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Location = new System.Drawing.Point(127, 372);
			this.OKButton.Margin = new System.Windows.Forms.Padding(4);
			this.OKButton.Name = "OKButton";
			this.OKButton.ShowToolTips = true;
			this.OKButton.Size = new System.Drawing.Size(100, 28);
			this.OKButton.TabIndex = 3;
			this.OKButton.Text = "OK";
			this.OKButton.ToolTip = "Click to accept changes and exit.";
			this.OKButton.UseVisualStyleBackColor = true;
			// 
			// cCaliberForm
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.ClientSize = new System.Drawing.Size(528, 386);
			this.ControlBox = false;
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.GeneralGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cCaliberForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Caliber";
			this.GeneralGroupBox.ResumeLayout(false);
			this.GeneralGroupBox.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

			}

		#endregion
		private System.Windows.Forms.GroupBox GeneralGroupBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton RevolverRadioButton;
		private System.Windows.Forms.RadioButton PistolRadioButton;
		private CommonLib.Controls.cDoubleValueTextBox MinBulletDiameterTextBox;
		private CommonLib.Controls.cDoubleValueTextBox MaxBulletDiameterTextBox;
		private CommonLib.Controls.cDoubleValueTextBox MaxCaseLengthTextBox;
		private CommonLib.Controls.cDoubleValueTextBox CaseTrimLengthTextBox;
		private CommonLib.Controls.cDoubleValueTextBox MaxCOLTextBox;
		private Controls.cFirearmTypeCombo FirearmTypeCombo;
		private System.Windows.Forms.Label MaxBulletWeightMeasurementLabel;
		private System.Windows.Forms.Label MaxBulletWeightLabel;
		private System.Windows.Forms.Label MinBulletWeightMeasurementLabel;
		private System.Windows.Forms.Label MinBulletWeightLabel;
		private CommonLib.Controls.cDoubleValueTextBox MaxBulletWeightTextBox;
		private CommonLib.Controls.cDoubleValueTextBox MinBulletWeightTextBox;
		private System.Windows.Forms.Label MinCaseLengthLabel;
		private System.Windows.Forms.Label MinCaseLengthMeasurementLabel;
		private System.Windows.Forms.Label MaxCaseLengthMeasurementLabel;
		private System.Windows.Forms.Label MaxCaseLengthLabel;
		private System.Windows.Forms.Label MinBulletDiameterLabel;
		private System.Windows.Forms.Label MaxBulletDiameterLabel;
		private System.Windows.Forms.Label MaxBulletDiameterMeasurementLabel;
		private System.Windows.Forms.Label MinBulletDiameterMeasurementLabel;
		private System.Windows.Forms.Label MaxCOLLabel;
		private System.Windows.Forms.Label MaxCOLMeasurementLabel;
		private CommonLib.Controls.cTextBox NameTextBox;
		private CommonLib.Controls.cTextBox HeadStampTextBox;
		private System.Windows.Forms.CheckBox MagnumPrimerCheckBox;
		private System.Windows.Forms.CheckBox LargePrimerCheckBox;
		private System.Windows.Forms.CheckBox SmallPrimerCheckBox;
		private CommonLib.Controls.cDoubleValueTextBox MaxNeckDiameterTextBox;
		private System.Windows.Forms.Label MaxNeckDiameterMeasurementLabel;
		private System.Windows.Forms.Label MaxNeckDiameterLabel;
		private System.Windows.Forms.Button TestSAAMIPDFButton;
		private CommonLib.Controls.cCancelButton FormCancelButton;
		private CommonLib.Controls.cOKButton OKButton;
		private System.Windows.Forms.CheckBox RimfireCheckBox;
		private System.Windows.Forms.CheckBox CrossUseCheckBox;
		private CommonLib.Controls.cIntegerValueTextBox SAAMIPDFTextBox;
		}
	}