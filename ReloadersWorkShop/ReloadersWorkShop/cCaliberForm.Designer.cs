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
			this.SAAMIOKImage = new System.Windows.Forms.PictureBox();
			this.TestSAAMIPDFButton = new System.Windows.Forms.Button();
			this.SAAMIPDFTextBox = new CommonLib.Controls.cTextBox();
			this.HeadStampTextBox = new CommonLib.Controls.cTextBox();
			this.NameTextBox = new CommonLib.Controls.cTextBox();
			this.FirearmTypeCombo = new ReloadersWorkShop.Controls.cFirearmTypeCombo();
			this.RevolverRadioButton = new System.Windows.Forms.RadioButton();
			this.PistolRadioButton = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
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
			((System.ComponentModel.ISupportInitialize)(this.SAAMIOKImage)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label1.ForeColor = System.Drawing.SystemColors.ControlText;
			label1.Location = new System.Drawing.Point(52, 49);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(38, 13);
			label1.TabIndex = 0;
			label1.Text = "Name:";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label9.ForeColor = System.Drawing.SystemColors.ControlText;
			label9.Location = new System.Drawing.Point(16, 24);
			label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(71, 13);
			label9.TabIndex = 16;
			label9.Text = "Firearm Type:";
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label13.ForeColor = System.Drawing.SystemColors.ControlText;
			label13.Location = new System.Drawing.Point(21, 73);
			label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(69, 13);
			label13.TabIndex = 17;
			label13.Text = "Head Stamp:";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label10.ForeColor = System.Drawing.SystemColors.ControlText;
			label10.Location = new System.Drawing.Point(32, 24);
			label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(62, 13);
			label10.TabIndex = 16;
			label10.Text = "Primer Size:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label2.ForeColor = System.Drawing.SystemColors.ControlText;
			label2.Location = new System.Drawing.Point(23, 104);
			label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(67, 13);
			label2.TabIndex = 19;
			label2.Text = "SAAMI PDF:";
			// 
			// MinCaseLengthLabel
			// 
			this.MinCaseLengthLabel.AutoSize = true;
			this.MinCaseLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinCaseLengthLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MinCaseLengthLabel.Location = new System.Drawing.Point(12, 98);
			this.MinCaseLengthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MinCaseLengthLabel.Name = "MinCaseLengthLabel";
			this.MinCaseLengthLabel.Size = new System.Drawing.Size(93, 13);
			this.MinCaseLengthLabel.TabIndex = 4;
			this.MinCaseLengthLabel.Text = "Case Trim Length:";
			// 
			// MinCaseLengthMeasurementLabel
			// 
			this.MinCaseLengthMeasurementLabel.AutoSize = true;
			this.MinCaseLengthMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinCaseLengthMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MinCaseLengthMeasurementLabel.Location = new System.Drawing.Point(163, 98);
			this.MinCaseLengthMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MinCaseLengthMeasurementLabel.Name = "MinCaseLengthMeasurementLabel";
			this.MinCaseLengthMeasurementLabel.Size = new System.Drawing.Size(18, 13);
			this.MinCaseLengthMeasurementLabel.TabIndex = 6;
			this.MinCaseLengthMeasurementLabel.Text = "in.";
			// 
			// MaxCaseLengthMeasurementLabel
			// 
			this.MaxCaseLengthMeasurementLabel.AutoSize = true;
			this.MaxCaseLengthMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxCaseLengthMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxCaseLengthMeasurementLabel.Location = new System.Drawing.Point(356, 98);
			this.MaxCaseLengthMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MaxCaseLengthMeasurementLabel.Name = "MaxCaseLengthMeasurementLabel";
			this.MaxCaseLengthMeasurementLabel.Size = new System.Drawing.Size(18, 13);
			this.MaxCaseLengthMeasurementLabel.TabIndex = 9;
			this.MaxCaseLengthMeasurementLabel.Text = "in.";
			// 
			// MaxCaseLengthLabel
			// 
			this.MaxCaseLengthLabel.AutoSize = true;
			this.MaxCaseLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxCaseLengthLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxCaseLengthLabel.Location = new System.Drawing.Point(207, 98);
			this.MaxCaseLengthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MaxCaseLengthLabel.Name = "MaxCaseLengthLabel";
			this.MaxCaseLengthLabel.Size = new System.Drawing.Size(93, 13);
			this.MaxCaseLengthLabel.TabIndex = 7;
			this.MaxCaseLengthLabel.Text = "Max Case Length:";
			// 
			// MinBulletDiameterMeasurementLabel
			// 
			this.MinBulletDiameterMeasurementLabel.AutoSize = true;
			this.MinBulletDiameterMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinBulletDiameterMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MinBulletDiameterMeasurementLabel.Location = new System.Drawing.Point(163, 49);
			this.MinBulletDiameterMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MinBulletDiameterMeasurementLabel.Name = "MinBulletDiameterMeasurementLabel";
			this.MinBulletDiameterMeasurementLabel.Size = new System.Drawing.Size(18, 13);
			this.MinBulletDiameterMeasurementLabel.TabIndex = 12;
			this.MinBulletDiameterMeasurementLabel.Text = "in.";
			// 
			// MinBulletDiameterLabel
			// 
			this.MinBulletDiameterLabel.AutoSize = true;
			this.MinBulletDiameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinBulletDiameterLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MinBulletDiameterLabel.Location = new System.Drawing.Point(4, 49);
			this.MinBulletDiameterLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MinBulletDiameterLabel.Name = "MinBulletDiameterLabel";
			this.MinBulletDiameterLabel.Size = new System.Drawing.Size(101, 13);
			this.MinBulletDiameterLabel.TabIndex = 10;
			this.MinBulletDiameterLabel.Text = "Min Bullet Diameter:";
			// 
			// MaxCOLMeasurementLabel
			// 
			this.MaxCOLMeasurementLabel.AutoSize = true;
			this.MaxCOLMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxCOLMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxCOLMeasurementLabel.Location = new System.Drawing.Point(163, 122);
			this.MaxCOLMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MaxCOLMeasurementLabel.Name = "MaxCOLMeasurementLabel";
			this.MaxCOLMeasurementLabel.Size = new System.Drawing.Size(18, 13);
			this.MaxCOLMeasurementLabel.TabIndex = 15;
			this.MaxCOLMeasurementLabel.Text = "in.";
			// 
			// MaxCOLLabel
			// 
			this.MaxCOLLabel.AutoSize = true;
			this.MaxCOLLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxCOLLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxCOLLabel.Location = new System.Drawing.Point(44, 122);
			this.MaxCOLLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MaxCOLLabel.Name = "MaxCOLLabel";
			this.MaxCOLLabel.Size = new System.Drawing.Size(61, 13);
			this.MaxCOLLabel.TabIndex = 13;
			this.MaxCOLLabel.Text = "Max COAL:";
			// 
			// MaxBulletDiameterMeasurementLabel
			// 
			this.MaxBulletDiameterMeasurementLabel.AutoSize = true;
			this.MaxBulletDiameterMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxBulletDiameterMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxBulletDiameterMeasurementLabel.Location = new System.Drawing.Point(356, 50);
			this.MaxBulletDiameterMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MaxBulletDiameterMeasurementLabel.Name = "MaxBulletDiameterMeasurementLabel";
			this.MaxBulletDiameterMeasurementLabel.Size = new System.Drawing.Size(18, 13);
			this.MaxBulletDiameterMeasurementLabel.TabIndex = 19;
			this.MaxBulletDiameterMeasurementLabel.Text = "in.";
			// 
			// MaxBulletDiameterLabel
			// 
			this.MaxBulletDiameterLabel.AutoSize = true;
			this.MaxBulletDiameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxBulletDiameterLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxBulletDiameterLabel.Location = new System.Drawing.Point(196, 49);
			this.MaxBulletDiameterLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MaxBulletDiameterLabel.Name = "MaxBulletDiameterLabel";
			this.MaxBulletDiameterLabel.Size = new System.Drawing.Size(104, 13);
			this.MaxBulletDiameterLabel.TabIndex = 18;
			this.MaxBulletDiameterLabel.Text = "Max Bullet Diameter:";
			// 
			// MaxBulletWeightMeasurementLabel
			// 
			this.MaxBulletWeightMeasurementLabel.AutoSize = true;
			this.MaxBulletWeightMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxBulletWeightMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxBulletWeightMeasurementLabel.Location = new System.Drawing.Point(356, 73);
			this.MaxBulletWeightMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MaxBulletWeightMeasurementLabel.Name = "MaxBulletWeightMeasurementLabel";
			this.MaxBulletWeightMeasurementLabel.Size = new System.Drawing.Size(16, 13);
			this.MaxBulletWeightMeasurementLabel.TabIndex = 25;
			this.MaxBulletWeightMeasurementLabel.Text = "gr";
			// 
			// MaxBulletWeightLabel
			// 
			this.MaxBulletWeightLabel.AutoSize = true;
			this.MaxBulletWeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxBulletWeightLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxBulletWeightLabel.Location = new System.Drawing.Point(204, 73);
			this.MaxBulletWeightLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MaxBulletWeightLabel.Name = "MaxBulletWeightLabel";
			this.MaxBulletWeightLabel.Size = new System.Drawing.Size(96, 13);
			this.MaxBulletWeightLabel.TabIndex = 24;
			this.MaxBulletWeightLabel.Text = "Max Bullet Weight:";
			// 
			// MinBulletWeightMeasurementLabel
			// 
			this.MinBulletWeightMeasurementLabel.AutoSize = true;
			this.MinBulletWeightMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinBulletWeightMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MinBulletWeightMeasurementLabel.Location = new System.Drawing.Point(163, 73);
			this.MinBulletWeightMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MinBulletWeightMeasurementLabel.Name = "MinBulletWeightMeasurementLabel";
			this.MinBulletWeightMeasurementLabel.Size = new System.Drawing.Size(16, 13);
			this.MinBulletWeightMeasurementLabel.TabIndex = 23;
			this.MinBulletWeightMeasurementLabel.Text = "gr";
			// 
			// MinBulletWeightLabel
			// 
			this.MinBulletWeightLabel.AutoSize = true;
			this.MinBulletWeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinBulletWeightLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MinBulletWeightLabel.Location = new System.Drawing.Point(12, 73);
			this.MinBulletWeightLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MinBulletWeightLabel.Name = "MinBulletWeightLabel";
			this.MinBulletWeightLabel.Size = new System.Drawing.Size(93, 13);
			this.MinBulletWeightLabel.TabIndex = 22;
			this.MinBulletWeightLabel.Text = "Min Bullet Weight:";
			// 
			// GeneralGroupBox
			// 
			this.GeneralGroupBox.Controls.Add(this.SAAMIOKImage);
			this.GeneralGroupBox.Controls.Add(this.TestSAAMIPDFButton);
			this.GeneralGroupBox.Controls.Add(this.SAAMIPDFTextBox);
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
			this.GeneralGroupBox.Location = new System.Drawing.Point(10, 9);
			this.GeneralGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.GeneralGroupBox.Name = "GeneralGroupBox";
			this.GeneralGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.GeneralGroupBox.Size = new System.Drawing.Size(392, 130);
			this.GeneralGroupBox.TabIndex = 0;
			this.GeneralGroupBox.TabStop = false;
			this.GeneralGroupBox.Text = "General";
			// 
			// SAAMIOKImage
			// 
			this.SAAMIOKImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SAAMIOKImage.Location = new System.Drawing.Point(324, 104);
			this.SAAMIOKImage.Name = "SAAMIOKImage";
			this.SAAMIOKImage.Size = new System.Drawing.Size(18, 18);
			this.SAAMIOKImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.SAAMIOKImage.TabIndex = 20;
			this.SAAMIOKImage.TabStop = false;
			// 
			// TestSAAMIPDFButton
			// 
			this.TestSAAMIPDFButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TestSAAMIPDFButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TestSAAMIPDFButton.Location = new System.Drawing.Point(275, 101);
			this.TestSAAMIPDFButton.Margin = new System.Windows.Forms.Padding(2);
			this.TestSAAMIPDFButton.Name = "TestSAAMIPDFButton";
			this.TestSAAMIPDFButton.Size = new System.Drawing.Size(44, 19);
			this.TestSAAMIPDFButton.TabIndex = 6;
			this.TestSAAMIPDFButton.Text = "Test";
			this.TestSAAMIPDFButton.UseVisualStyleBackColor = true;
			// 
			// SAAMIPDFTextBox
			// 
			this.SAAMIPDFTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.SAAMIPDFTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SAAMIPDFTextBox.Location = new System.Drawing.Point(93, 101);
			this.SAAMIPDFTextBox.MaxLength = 60;
			this.SAAMIPDFTextBox.Name = "SAAMIPDFTextBox";
			this.SAAMIPDFTextBox.Required = false;
			this.SAAMIPDFTextBox.Size = new System.Drawing.Size(177, 20);
			this.SAAMIPDFTextBox.TabIndex = 5;
			this.SAAMIPDFTextBox.ToolTip = "";
			this.SAAMIPDFTextBox.ValidChars = "";
			this.SAAMIPDFTextBox.Value = "";
			// 
			// HeadStampTextBox
			// 
			this.HeadStampTextBox.BackColor = System.Drawing.Color.LightPink;
			this.HeadStampTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.HeadStampTextBox.Location = new System.Drawing.Point(93, 70);
			this.HeadStampTextBox.MaxLength = 20;
			this.HeadStampTextBox.Name = "HeadStampTextBox";
			this.HeadStampTextBox.Required = true;
			this.HeadStampTextBox.Size = new System.Drawing.Size(177, 20);
			this.HeadStampTextBox.TabIndex = 2;
			this.HeadStampTextBox.ToolTip = "";
			this.HeadStampTextBox.ValidChars = "";
			this.HeadStampTextBox.Value = "";
			// 
			// NameTextBox
			// 
			this.NameTextBox.BackColor = System.Drawing.Color.LightPink;
			this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NameTextBox.Location = new System.Drawing.Point(93, 46);
			this.NameTextBox.MaxLength = 45;
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Required = true;
			this.NameTextBox.Size = new System.Drawing.Size(177, 20);
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
            "Shotgun"});
			this.FirearmTypeCombo.Location = new System.Drawing.Point(93, 21);
			this.FirearmTypeCombo.Name = "FirearmTypeCombo";
			this.FirearmTypeCombo.Size = new System.Drawing.Size(100, 21);
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
			this.RevolverRadioButton.Location = new System.Drawing.Point(306, 73);
			this.RevolverRadioButton.Margin = new System.Windows.Forms.Padding(2);
			this.RevolverRadioButton.Name = "RevolverRadioButton";
			this.RevolverRadioButton.Size = new System.Drawing.Size(71, 17);
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
			this.PistolRadioButton.Location = new System.Drawing.Point(306, 49);
			this.PistolRadioButton.Margin = new System.Windows.Forms.Padding(2);
			this.PistolRadioButton.Name = "PistolRadioButton";
			this.PistolRadioButton.Size = new System.Drawing.Size(53, 17);
			this.PistolRadioButton.TabIndex = 3;
			this.PistolRadioButton.TabStop = true;
			this.PistolRadioButton.Text = "Pistol:";
			this.PistolRadioButton.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
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
			this.groupBox2.Location = new System.Drawing.Point(10, 143);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox2.Size = new System.Drawing.Size(392, 149);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Sizing";
			// 
			// MaxNeckDiameterTextBox
			// 
			this.MaxNeckDiameterTextBox.BackColor = System.Drawing.Color.LightPink;
			this.MaxNeckDiameterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxNeckDiameterTextBox.Location = new System.Drawing.Point(303, 119);
			this.MaxNeckDiameterTextBox.MaxLength = 5;
			this.MaxNeckDiameterTextBox.MaxValue = 4D;
			this.MaxNeckDiameterTextBox.MinValue = 1D;
			this.MaxNeckDiameterTextBox.Name = "MaxNeckDiameterTextBox";
			this.MaxNeckDiameterTextBox.NumDecimals = 3;
			this.MaxNeckDiameterTextBox.Size = new System.Drawing.Size(48, 20);
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
			this.MaxNeckDiameterMeasurementLabel.Location = new System.Drawing.Point(356, 122);
			this.MaxNeckDiameterMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MaxNeckDiameterMeasurementLabel.Name = "MaxNeckDiameterMeasurementLabel";
			this.MaxNeckDiameterMeasurementLabel.Size = new System.Drawing.Size(18, 13);
			this.MaxNeckDiameterMeasurementLabel.TabIndex = 31;
			this.MaxNeckDiameterMeasurementLabel.Text = "in.";
			// 
			// MaxNeckDiameterLabel
			// 
			this.MaxNeckDiameterLabel.AutoSize = true;
			this.MaxNeckDiameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxNeckDiameterLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxNeckDiameterLabel.Location = new System.Drawing.Point(194, 122);
			this.MaxNeckDiameterLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MaxNeckDiameterLabel.Name = "MaxNeckDiameterLabel";
			this.MaxNeckDiameterLabel.Size = new System.Drawing.Size(104, 13);
			this.MaxNeckDiameterLabel.TabIndex = 29;
			this.MaxNeckDiameterLabel.Text = "Max Neck Diameter:";
			// 
			// MagnumPrimerCheckBox
			// 
			this.MagnumPrimerCheckBox.AutoCheck = false;
			this.MagnumPrimerCheckBox.AutoSize = true;
			this.MagnumPrimerCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MagnumPrimerCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MagnumPrimerCheckBox.Location = new System.Drawing.Point(215, 23);
			this.MagnumPrimerCheckBox.Name = "MagnumPrimerCheckBox";
			this.MagnumPrimerCheckBox.Size = new System.Drawing.Size(67, 17);
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
			this.LargePrimerCheckBox.Location = new System.Drawing.Point(156, 23);
			this.LargePrimerCheckBox.Name = "LargePrimerCheckBox";
			this.LargePrimerCheckBox.Size = new System.Drawing.Size(53, 17);
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
			this.SmallPrimerCheckBox.Location = new System.Drawing.Point(99, 23);
			this.SmallPrimerCheckBox.Name = "SmallPrimerCheckBox";
			this.SmallPrimerCheckBox.Size = new System.Drawing.Size(51, 17);
			this.SmallPrimerCheckBox.TabIndex = 0;
			this.SmallPrimerCheckBox.Text = "Small";
			this.SmallPrimerCheckBox.UseVisualStyleBackColor = true;
			// 
			// MaxBulletWeightTextBox
			// 
			this.MaxBulletWeightTextBox.BackColor = System.Drawing.Color.LightPink;
			this.MaxBulletWeightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxBulletWeightTextBox.Location = new System.Drawing.Point(303, 70);
			this.MaxBulletWeightTextBox.MaxLength = 5;
			this.MaxBulletWeightTextBox.MaxValue = 750D;
			this.MaxBulletWeightTextBox.MinValue = 5D;
			this.MaxBulletWeightTextBox.Name = "MaxBulletWeightTextBox";
			this.MaxBulletWeightTextBox.NumDecimals = 1;
			this.MaxBulletWeightTextBox.Size = new System.Drawing.Size(48, 20);
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
			this.MinBulletWeightTextBox.Location = new System.Drawing.Point(110, 70);
			this.MinBulletWeightTextBox.MaxLength = 5;
			this.MinBulletWeightTextBox.MaxValue = 750D;
			this.MinBulletWeightTextBox.MinValue = 5D;
			this.MinBulletWeightTextBox.Name = "MinBulletWeightTextBox";
			this.MinBulletWeightTextBox.NumDecimals = 1;
			this.MinBulletWeightTextBox.Size = new System.Drawing.Size(48, 20);
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
			this.MaxCOLTextBox.Location = new System.Drawing.Point(110, 119);
			this.MaxCOLTextBox.MaxLength = 5;
			this.MaxCOLTextBox.MaxValue = 6D;
			this.MaxCOLTextBox.MinValue = 1D;
			this.MaxCOLTextBox.Name = "MaxCOLTextBox";
			this.MaxCOLTextBox.NumDecimals = 3;
			this.MaxCOLTextBox.Size = new System.Drawing.Size(48, 20);
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
			this.MaxCaseLengthTextBox.Location = new System.Drawing.Point(303, 95);
			this.MaxCaseLengthTextBox.MaxLength = 5;
			this.MaxCaseLengthTextBox.MaxValue = 4D;
			this.MaxCaseLengthTextBox.MinValue = 1D;
			this.MaxCaseLengthTextBox.Name = "MaxCaseLengthTextBox";
			this.MaxCaseLengthTextBox.NumDecimals = 3;
			this.MaxCaseLengthTextBox.Size = new System.Drawing.Size(48, 20);
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
			this.CaseTrimLengthTextBox.Location = new System.Drawing.Point(110, 95);
			this.CaseTrimLengthTextBox.MaxLength = 5;
			this.CaseTrimLengthTextBox.MaxValue = 4D;
			this.CaseTrimLengthTextBox.MinValue = 1D;
			this.CaseTrimLengthTextBox.Name = "CaseTrimLengthTextBox";
			this.CaseTrimLengthTextBox.NumDecimals = 3;
			this.CaseTrimLengthTextBox.Size = new System.Drawing.Size(48, 20);
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
			this.MaxBulletDiameterTextBox.Location = new System.Drawing.Point(303, 46);
			this.MaxBulletDiameterTextBox.MaxLength = 5;
			this.MaxBulletDiameterTextBox.MaxValue = 1D;
			this.MaxBulletDiameterTextBox.MinValue = 0D;
			this.MaxBulletDiameterTextBox.Name = "MaxBulletDiameterTextBox";
			this.MaxBulletDiameterTextBox.NumDecimals = 3;
			this.MaxBulletDiameterTextBox.Size = new System.Drawing.Size(48, 20);
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
			this.MinBulletDiameterTextBox.Location = new System.Drawing.Point(110, 47);
			this.MinBulletDiameterTextBox.MaxLength = 5;
			this.MinBulletDiameterTextBox.MaxValue = 1D;
			this.MinBulletDiameterTextBox.MinValue = 0D;
			this.MinBulletDiameterTextBox.Name = "MinBulletDiameterTextBox";
			this.MinBulletDiameterTextBox.NumDecimals = 3;
			this.MinBulletDiameterTextBox.Size = new System.Drawing.Size(48, 20);
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
			this.FormCancelButton.Location = new System.Drawing.Point(211, 302);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.ShowToolTips = true;
			this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
			this.FormCancelButton.TabIndex = 2;
			this.FormCancelButton.Text = "Cancel";
			this.FormCancelButton.ToolTip = "Click to cancel changes and exit.";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			// 
			// OKButton
			// 
			this.OKButton.ButtonType = CommonLib.Controls.cOKButton.eButtonTypes.OK;
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Location = new System.Drawing.Point(95, 302);
			this.OKButton.Name = "OKButton";
			this.OKButton.ShowToolTips = true;
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 3;
			this.OKButton.Text = "OK";
			this.OKButton.ToolTip = "Click to accept changes and exit.";
			this.OKButton.UseVisualStyleBackColor = true;
			// 
			// cCaliberForm
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.ClientSize = new System.Drawing.Size(411, 329);
			this.ControlBox = false;
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.GeneralGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cCaliberForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Caliber";
			this.GeneralGroupBox.ResumeLayout(false);
			this.GeneralGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SAAMIOKImage)).EndInit();
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
		private CommonLib.Controls.cTextBox SAAMIPDFTextBox;
		private System.Windows.Forms.PictureBox SAAMIOKImage;
		private CommonLib.Controls.cCancelButton FormCancelButton;
		private CommonLib.Controls.cOKButton OKButton;
		}
	}