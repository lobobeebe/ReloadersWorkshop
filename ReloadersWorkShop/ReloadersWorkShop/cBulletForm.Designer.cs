namespace ReloadersWorkShop
	{
	partial class cBulletForm
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

				m_BulletBitmap.Dispose();
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label20;
            this.BulletWeightMeasurementLabel = new System.Windows.Forms.Label();
            this.DiameterMeasurementLabel = new System.Windows.Forms.Label();
            this.LengthMeasurementLabel = new System.Windows.Forms.Label();
            this.TopPunchLabel = new System.Windows.Forms.Label();
            this.ManufacturerCombo = new System.Windows.Forms.ComboBox();
            this.BulletOKButton = new System.Windows.Forms.Button();
            this.BulletCancelButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TypeWizardButton = new System.Windows.Forms.Button();
            this.PartNumberLabel = new System.Windows.Forms.Label();
            this.GeneralGroupBox = new System.Windows.Forms.GroupBox();
            this.PartNumberTextBox = new CommonLib.Controls.cTextBox();
            this.TopPunchTextBox = new CommonLib.Controls.cIntegerValueTextBox();
            this.FirearmTypeCombo = new ReloadersWorkShop.Controls.cFirearmTypeCombo();
            this.DuplicateLabel = new System.Windows.Forms.Label();
            this.SelfCastRadioButton = new System.Windows.Forms.RadioButton();
            this.BulletImage = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LengthTextBox = new CommonLib.Controls.cDoubleValueTextBox();
            this.BulletWeightTextBox = new CommonLib.Controls.cDoubleValueTextBox();
            this.TypeTextBox = new CommonLib.Controls.cTextBox();
            this.BallisticCoefficientTextBox = new CommonLib.Controls.cDoubleValueTextBox();
            this.BulletDiameterTextBox = new CommonLib.Controls.cDoubleValueTextBox();
            this.SectionalDensityLabel = new System.Windows.Forms.Label();
            this.InventoryGroupBox = new System.Windows.Forms.GroupBox();
            this.InventoryButton = new System.Windows.Forms.Button();
            this.CostTextBox = new CommonLib.Controls.cDoubleValueTextBox();
            this.QuantityTextBox = new CommonLib.Controls.cIntegerValueTextBox();
            this.CostEachLabel = new System.Windows.Forms.Label();
            this.CostLabel = new System.Windows.Forms.Label();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.CaliberDataGroupBox = new System.Windows.Forms.GroupBox();
            this.RemoveCaliberButton = new System.Windows.Forms.Button();
            this.EditCaliberButton = new System.Windows.Forms.Button();
            this.AddCaliberButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            this.GeneralGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BulletImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.InventoryGroupBox.SuspendLayout();
            this.CaliberDataGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.SystemColors.ControlText;
            label1.Location = new System.Drawing.Point(8, 50);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 13);
            label1.TabIndex = 0;
            label1.Text = "Manufacturer:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ForeColor = System.Drawing.SystemColors.ControlText;
            label2.Location = new System.Drawing.Point(27, 27);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 13);
            label2.TabIndex = 2;
            label2.Text = "Type:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.ForeColor = System.Drawing.SystemColors.ControlText;
            label4.Location = new System.Drawing.Point(145, 50);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(44, 13);
            label4.TabIndex = 6;
            label4.Text = "Weight:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.ForeColor = System.Drawing.SystemColors.ControlText;
            label8.Location = new System.Drawing.Point(11, 25);
            label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(71, 13);
            label8.TabIndex = 16;
            label8.Text = "Firearm Type:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.ForeColor = System.Drawing.SystemColors.ControlText;
            label9.Location = new System.Drawing.Point(9, 50);
            label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(52, 13);
            label9.TabIndex = 17;
            label9.Text = "Diameter:";
            // 
            // label16
            // 
            label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label16.ForeColor = System.Drawing.SystemColors.ControlText;
            label16.Location = new System.Drawing.Point(359, 32);
            label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(67, 13);
            label16.TabIndex = 12;
            label16.Text = "Cost Each:";
            label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label20.ForeColor = System.Drawing.SystemColors.ControlText;
            label20.Location = new System.Drawing.Point(18, 73);
            label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(43, 13);
            label20.TabIndex = 24;
            label20.Text = "Length:";
            // 
            // BulletWeightMeasurementLabel
            // 
            this.BulletWeightMeasurementLabel.AutoSize = true;
            this.BulletWeightMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BulletWeightMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BulletWeightMeasurementLabel.Location = new System.Drawing.Point(233, 50);
            this.BulletWeightMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BulletWeightMeasurementLabel.Name = "BulletWeightMeasurementLabel";
            this.BulletWeightMeasurementLabel.Size = new System.Drawing.Size(16, 13);
            this.BulletWeightMeasurementLabel.TabIndex = 13;
            this.BulletWeightMeasurementLabel.Text = "gr";
            // 
            // DiameterMeasurementLabel
            // 
            this.DiameterMeasurementLabel.AutoSize = true;
            this.DiameterMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiameterMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DiameterMeasurementLabel.Location = new System.Drawing.Point(119, 50);
            this.DiameterMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DiameterMeasurementLabel.Name = "DiameterMeasurementLabel";
            this.DiameterMeasurementLabel.Size = new System.Drawing.Size(18, 13);
            this.DiameterMeasurementLabel.TabIndex = 19;
            this.DiameterMeasurementLabel.Text = "in.";
            // 
            // LengthMeasurementLabel
            // 
            this.LengthMeasurementLabel.AutoSize = true;
            this.LengthMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LengthMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LengthMeasurementLabel.Location = new System.Drawing.Point(119, 73);
            this.LengthMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LengthMeasurementLabel.Name = "LengthMeasurementLabel";
            this.LengthMeasurementLabel.Size = new System.Drawing.Size(18, 13);
            this.LengthMeasurementLabel.TabIndex = 25;
            this.LengthMeasurementLabel.Text = "in.";
            // 
            // TopPunchLabel
            // 
            this.TopPunchLabel.AutoSize = true;
            this.TopPunchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopPunchLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TopPunchLabel.Location = new System.Drawing.Point(115, 102);
            this.TopPunchLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TopPunchLabel.Name = "TopPunchLabel";
            this.TopPunchLabel.Size = new System.Drawing.Size(63, 13);
            this.TopPunchLabel.TabIndex = 4;
            this.TopPunchLabel.Text = "Top Punch:";
            // 
            // ManufacturerCombo
            // 
            this.ManufacturerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ManufacturerCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManufacturerCombo.FormattingEnabled = true;
            this.ManufacturerCombo.Location = new System.Drawing.Point(85, 47);
            this.ManufacturerCombo.Margin = new System.Windows.Forms.Padding(2);
            this.ManufacturerCombo.Name = "ManufacturerCombo";
            this.ManufacturerCombo.Size = new System.Drawing.Size(150, 21);
            this.ManufacturerCombo.Sorted = true;
            this.ManufacturerCombo.TabIndex = 1;
            // 
            // BulletOKButton
            // 
            this.BulletOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BulletOKButton.Location = new System.Drawing.Point(208, 526);
            this.BulletOKButton.Margin = new System.Windows.Forms.Padding(2);
            this.BulletOKButton.Name = "BulletOKButton";
            this.BulletOKButton.Size = new System.Drawing.Size(56, 19);
            this.BulletOKButton.TabIndex = 4;
            this.BulletOKButton.Text = "OK";
            this.BulletOKButton.UseVisualStyleBackColor = true;
            // 
            // BulletCancelButton
            // 
            this.BulletCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BulletCancelButton.Location = new System.Drawing.Point(281, 526);
            this.BulletCancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.BulletCancelButton.Name = "BulletCancelButton";
            this.BulletCancelButton.Size = new System.Drawing.Size(56, 19);
            this.BulletCancelButton.TabIndex = 5;
            this.BulletCancelButton.Text = "Cancel";
            this.BulletCancelButton.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(273, 49);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Ballistic Coefficient:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(279, 73);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Sectional Density:";
            // 
            // TypeWizardButton
            // 
            this.TypeWizardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeWizardButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TypeWizardButton.Location = new System.Drawing.Point(271, 20);
            this.TypeWizardButton.Margin = new System.Windows.Forms.Padding(2);
            this.TypeWizardButton.Name = "TypeWizardButton";
            this.TypeWizardButton.Size = new System.Drawing.Size(56, 19);
            this.TypeWizardButton.TabIndex = 1;
            this.TypeWizardButton.Text = "Wizard";
            this.TypeWizardButton.UseVisualStyleBackColor = true;
            // 
            // PartNumberLabel
            // 
            this.PartNumberLabel.AutoSize = true;
            this.PartNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartNumberLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PartNumberLabel.Location = new System.Drawing.Point(43, 75);
            this.PartNumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PartNumberLabel.Name = "PartNumberLabel";
            this.PartNumberLabel.Size = new System.Drawing.Size(39, 13);
            this.PartNumberLabel.TabIndex = 27;
            this.PartNumberLabel.Text = "Part #:";
            // 
            // GeneralGroupBox
            // 
            this.GeneralGroupBox.Controls.Add(this.PartNumberTextBox);
            this.GeneralGroupBox.Controls.Add(this.TopPunchTextBox);
            this.GeneralGroupBox.Controls.Add(this.FirearmTypeCombo);
            this.GeneralGroupBox.Controls.Add(this.DuplicateLabel);
            this.GeneralGroupBox.Controls.Add(this.TopPunchLabel);
            this.GeneralGroupBox.Controls.Add(this.SelfCastRadioButton);
            this.GeneralGroupBox.Controls.Add(this.BulletImage);
            this.GeneralGroupBox.Controls.Add(this.PartNumberLabel);
            this.GeneralGroupBox.Controls.Add(label1);
            this.GeneralGroupBox.Controls.Add(this.ManufacturerCombo);
            this.GeneralGroupBox.Controls.Add(label8);
            this.GeneralGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneralGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.GeneralGroupBox.Location = new System.Drawing.Point(10, 10);
            this.GeneralGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.GeneralGroupBox.Name = "GeneralGroupBox";
            this.GeneralGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.GeneralGroupBox.Size = new System.Drawing.Size(515, 124);
            this.GeneralGroupBox.TabIndex = 0;
            this.GeneralGroupBox.TabStop = false;
            this.GeneralGroupBox.Text = "General";
            // 
            // PartNumberTextBox
            // 
            this.PartNumberTextBox.BackColor = System.Drawing.Color.LightPink;
            this.PartNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartNumberTextBox.Location = new System.Drawing.Point(85, 72);
            this.PartNumberTextBox.MaxLength = 25;
            this.PartNumberTextBox.Name = "PartNumberTextBox";
            this.PartNumberTextBox.Required = true;
            this.PartNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.PartNumberTextBox.TabIndex = 2;
            this.PartNumberTextBox.ToolTip = "";
            this.PartNumberTextBox.Value = "";
            // 
            // TopPunchTextBox
            // 
            this.TopPunchTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.TopPunchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopPunchTextBox.Location = new System.Drawing.Point(183, 99);
            this.TopPunchTextBox.MaxLength = 5;
            this.TopPunchTextBox.MaxValue = 0;
            this.TopPunchTextBox.MinValue = 0;
            this.TopPunchTextBox.Name = "TopPunchTextBox";
            this.TopPunchTextBox.Required = false;
            this.TopPunchTextBox.Size = new System.Drawing.Size(47, 20);
            this.TopPunchTextBox.TabIndex = 4;
            this.TopPunchTextBox.Text = "0";
            this.TopPunchTextBox.ToolTip = "";
            this.TopPunchTextBox.Value = 0;
            // 
            // FirearmTypeCombo
            // 
            this.FirearmTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FirearmTypeCombo.DropDownWidth = 115;
            this.FirearmTypeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirearmTypeCombo.FormattingEnabled = true;
            this.FirearmTypeCombo.IncludeShotgun = false;
            this.FirearmTypeCombo.Items.AddRange(new object[] {
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle"});
            this.FirearmTypeCombo.Location = new System.Drawing.Point(85, 22);
            this.FirearmTypeCombo.Name = "FirearmTypeCombo";
            this.FirearmTypeCombo.Size = new System.Drawing.Size(100, 21);
            this.FirearmTypeCombo.TabIndex = 0;
            this.FirearmTypeCombo.ToolTip = "";
            this.FirearmTypeCombo.Value = ReloadersWorkShop.cFirearm.eFireArmType.Handgun;
            // 
            // DuplicateLabel
            // 
            this.DuplicateLabel.AutoSize = true;
            this.DuplicateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DuplicateLabel.ForeColor = System.Drawing.Color.Red;
            this.DuplicateLabel.Location = new System.Drawing.Point(198, 75);
            this.DuplicateLabel.Name = "DuplicateLabel";
            this.DuplicateLabel.Size = new System.Drawing.Size(0, 13);
            this.DuplicateLabel.TabIndex = 28;
            // 
            // SelfCastRadioButton
            // 
            this.SelfCastRadioButton.AutoCheck = false;
            this.SelfCastRadioButton.AutoSize = true;
            this.SelfCastRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SelfCastRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelfCastRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SelfCastRadioButton.Location = new System.Drawing.Point(28, 100);
            this.SelfCastRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelfCastRadioButton.Name = "SelfCastRadioButton";
            this.SelfCastRadioButton.Size = new System.Drawing.Size(70, 17);
            this.SelfCastRadioButton.TabIndex = 3;
            this.SelfCastRadioButton.TabStop = true;
            this.SelfCastRadioButton.Text = "Self Cast:";
            this.SelfCastRadioButton.UseVisualStyleBackColor = true;
            // 
            // BulletImage
            // 
            this.BulletImage.Location = new System.Drawing.Point(349, 17);
            this.BulletImage.Margin = new System.Windows.Forms.Padding(2);
            this.BulletImage.Name = "BulletImage";
            this.BulletImage.Size = new System.Drawing.Size(75, 100);
            this.BulletImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BulletImage.TabIndex = 0;
            this.BulletImage.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LengthTextBox);
            this.groupBox2.Controls.Add(this.BulletWeightTextBox);
            this.groupBox2.Controls.Add(this.TypeTextBox);
            this.groupBox2.Controls.Add(this.BallisticCoefficientTextBox);
            this.groupBox2.Controls.Add(this.BulletDiameterTextBox);
            this.groupBox2.Controls.Add(this.LengthMeasurementLabel);
            this.groupBox2.Controls.Add(label20);
            this.groupBox2.Controls.Add(this.SectionalDensityLabel);
            this.groupBox2.Controls.Add(this.TypeWizardButton);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.DiameterMeasurementLabel);
            this.groupBox2.Controls.Add(label9);
            this.groupBox2.Controls.Add(this.BulletWeightMeasurementLabel);
            this.groupBox2.Controls.Add(label4);
            this.groupBox2.Controls.Add(label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(10, 138);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(515, 102);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Description";
            // 
            // LengthTextBox
            // 
            this.LengthTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.LengthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LengthTextBox.Location = new System.Drawing.Point(65, 70);
            this.LengthTextBox.MaxLength = 5;
            this.LengthTextBox.MaxValue = 0D;
            this.LengthTextBox.MinValue = 0D;
            this.LengthTextBox.Name = "LengthTextBox";
            this.LengthTextBox.NumDecimals = 3;
            this.LengthTextBox.Size = new System.Drawing.Size(49, 20);
            this.LengthTextBox.TabIndex = 5;
            this.LengthTextBox.Text = "0.000";
            this.LengthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LengthTextBox.ToolTip = "";
            this.LengthTextBox.Value = 0D;
            this.LengthTextBox.ZeroAllowed = true;
            // 
            // BulletWeightTextBox
            // 
            this.BulletWeightTextBox.BackColor = System.Drawing.Color.LightPink;
            this.BulletWeightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BulletWeightTextBox.Location = new System.Drawing.Point(190, 47);
            this.BulletWeightTextBox.MaxLength = 5;
            this.BulletWeightTextBox.MaxValue = 750D;
            this.BulletWeightTextBox.MinValue = 5D;
            this.BulletWeightTextBox.Name = "BulletWeightTextBox";
            this.BulletWeightTextBox.NumDecimals = 1;
            this.BulletWeightTextBox.Size = new System.Drawing.Size(38, 20);
            this.BulletWeightTextBox.TabIndex = 3;
            this.BulletWeightTextBox.Text = "0.0";
            this.BulletWeightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BulletWeightTextBox.ToolTip = "";
            this.BulletWeightTextBox.Value = 0D;
            this.BulletWeightTextBox.ZeroAllowed = true;
            // 
            // TypeTextBox
            // 
            this.TypeTextBox.BackColor = System.Drawing.Color.LightPink;
            this.TypeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeTextBox.Location = new System.Drawing.Point(64, 21);
            this.TypeTextBox.MaxLength = 100;
            this.TypeTextBox.Name = "TypeTextBox";
            this.TypeTextBox.Required = true;
            this.TypeTextBox.Size = new System.Drawing.Size(175, 20);
            this.TypeTextBox.TabIndex = 0;
            this.TypeTextBox.ToolTip = "";
            this.TypeTextBox.Value = "";
            // 
            // BallisticCoefficientTextBox
            // 
            this.BallisticCoefficientTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.BallisticCoefficientTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BallisticCoefficientTextBox.Location = new System.Drawing.Point(376, 46);
            this.BallisticCoefficientTextBox.MaxLength = 5;
            this.BallisticCoefficientTextBox.MaxValue = 0D;
            this.BallisticCoefficientTextBox.MinValue = 0D;
            this.BallisticCoefficientTextBox.Name = "BallisticCoefficientTextBox";
            this.BallisticCoefficientTextBox.NumDecimals = 3;
            this.BallisticCoefficientTextBox.Size = new System.Drawing.Size(38, 20);
            this.BallisticCoefficientTextBox.TabIndex = 4;
            this.BallisticCoefficientTextBox.Text = "0.000";
            this.BallisticCoefficientTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BallisticCoefficientTextBox.ToolTip = "";
            this.BallisticCoefficientTextBox.Value = 0D;
            this.BallisticCoefficientTextBox.ZeroAllowed = true;
            // 
            // BulletDiameterTextBox
            // 
            this.BulletDiameterTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.BulletDiameterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BulletDiameterTextBox.Location = new System.Drawing.Point(65, 47);
            this.BulletDiameterTextBox.MaxLength = 5;
            this.BulletDiameterTextBox.MaxValue = 0D;
            this.BulletDiameterTextBox.MinValue = 0D;
            this.BulletDiameterTextBox.Name = "BulletDiameterTextBox";
            this.BulletDiameterTextBox.NumDecimals = 3;
            this.BulletDiameterTextBox.Size = new System.Drawing.Size(49, 20);
            this.BulletDiameterTextBox.TabIndex = 2;
            this.BulletDiameterTextBox.Text = "0.000";
            this.BulletDiameterTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BulletDiameterTextBox.ToolTip = "";
            this.BulletDiameterTextBox.Value = 0D;
            this.BulletDiameterTextBox.ZeroAllowed = true;
            // 
            // SectionalDensityLabel
            // 
            this.SectionalDensityLabel.AutoSize = true;
            this.SectionalDensityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionalDensityLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SectionalDensityLabel.Location = new System.Drawing.Point(372, 73);
            this.SectionalDensityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SectionalDensityLabel.Name = "SectionalDensityLabel";
            this.SectionalDensityLabel.Size = new System.Drawing.Size(39, 13);
            this.SectionalDensityLabel.TabIndex = 5;
            this.SectionalDensityLabel.Text = "0.000";
            // 
            // InventoryGroupBox
            // 
            this.InventoryGroupBox.Controls.Add(this.InventoryButton);
            this.InventoryGroupBox.Controls.Add(this.CostTextBox);
            this.InventoryGroupBox.Controls.Add(this.QuantityTextBox);
            this.InventoryGroupBox.Controls.Add(this.CostEachLabel);
            this.InventoryGroupBox.Controls.Add(label16);
            this.InventoryGroupBox.Controls.Add(this.CostLabel);
            this.InventoryGroupBox.Controls.Add(this.QuantityLabel);
            this.InventoryGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.InventoryGroupBox.Location = new System.Drawing.Point(10, 414);
            this.InventoryGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.InventoryGroupBox.Name = "InventoryGroupBox";
            this.InventoryGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.InventoryGroupBox.Size = new System.Drawing.Size(515, 99);
            this.InventoryGroupBox.TabIndex = 3;
            this.InventoryGroupBox.TabStop = false;
            this.InventoryGroupBox.Text = "Pricing";
            // 
            // InventoryButton
            // 
            this.InventoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.InventoryButton.Location = new System.Drawing.Point(168, 58);
            this.InventoryButton.Margin = new System.Windows.Forms.Padding(2);
            this.InventoryButton.Name = "InventoryButton";
            this.InventoryButton.Size = new System.Drawing.Size(179, 32);
            this.InventoryButton.TabIndex = 2;
            this.InventoryButton.Text = "Inventory Totals && Activity";
            this.InventoryButton.UseVisualStyleBackColor = true;
            // 
            // CostTextBox
            // 
            this.CostTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.CostTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CostTextBox.Location = new System.Drawing.Point(271, 29);
            this.CostTextBox.MaxLength = 7;
            this.CostTextBox.MaxValue = 0D;
            this.CostTextBox.MinValue = 0D;
            this.CostTextBox.Name = "CostTextBox";
            this.CostTextBox.NumDecimals = 2;
            this.CostTextBox.Size = new System.Drawing.Size(56, 20);
            this.CostTextBox.TabIndex = 1;
            this.CostTextBox.Text = "0.00";
            this.CostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CostTextBox.ToolTip = "";
            this.CostTextBox.Value = 0D;
            this.CostTextBox.ZeroAllowed = true;
            // 
            // QuantityTextBox
            // 
            this.QuantityTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.QuantityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantityTextBox.Location = new System.Drawing.Point(130, 29);
            this.QuantityTextBox.MaxLength = 5;
            this.QuantityTextBox.MaxValue = 0;
            this.QuantityTextBox.MinValue = 0;
            this.QuantityTextBox.Name = "QuantityTextBox";
            this.QuantityTextBox.Required = false;
            this.QuantityTextBox.Size = new System.Drawing.Size(56, 20);
            this.QuantityTextBox.TabIndex = 0;
            this.QuantityTextBox.Text = "0";
            this.QuantityTextBox.ToolTip = "";
            this.QuantityTextBox.Value = 0;
            // 
            // CostEachLabel
            // 
            this.CostEachLabel.AutoSize = true;
            this.CostEachLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CostEachLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CostEachLabel.Location = new System.Drawing.Point(430, 32);
            this.CostEachLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CostEachLabel.Name = "CostEachLabel";
            this.CostEachLabel.Size = new System.Drawing.Size(39, 13);
            this.CostEachLabel.TabIndex = 6;
            this.CostEachLabel.Text = "$0.00";
            this.CostEachLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CostLabel
            // 
            this.CostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CostLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CostLabel.Location = new System.Drawing.Point(202, 32);
            this.CostLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CostLabel.Name = "CostLabel";
            this.CostLabel.Size = new System.Drawing.Size(64, 13);
            this.CostLabel.TabIndex = 11;
            this.CostLabel.Text = "Cost:";
            this.CostLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantityLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.QuantityLabel.Location = new System.Drawing.Point(28, 32);
            this.QuantityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(97, 13);
            this.QuantityLabel.TabIndex = 9;
            this.QuantityLabel.Text = "Box of:";
            this.QuantityLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CaliberDataGroupBox
            // 
            this.CaliberDataGroupBox.Controls.Add(this.RemoveCaliberButton);
            this.CaliberDataGroupBox.Controls.Add(this.EditCaliberButton);
            this.CaliberDataGroupBox.Controls.Add(this.AddCaliberButton);
            this.CaliberDataGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaliberDataGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.CaliberDataGroupBox.Location = new System.Drawing.Point(10, 245);
            this.CaliberDataGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.CaliberDataGroupBox.Name = "CaliberDataGroupBox";
            this.CaliberDataGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.CaliberDataGroupBox.Size = new System.Drawing.Size(515, 163);
            this.CaliberDataGroupBox.TabIndex = 2;
            this.CaliberDataGroupBox.TabStop = false;
            this.CaliberDataGroupBox.Text = "Cartridge Specific Data";
            // 
            // RemoveCaliberButton
            // 
            this.RemoveCaliberButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveCaliberButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RemoveCaliberButton.Location = new System.Drawing.Point(260, 135);
            this.RemoveCaliberButton.Margin = new System.Windows.Forms.Padding(2);
            this.RemoveCaliberButton.Name = "RemoveCaliberButton";
            this.RemoveCaliberButton.Size = new System.Drawing.Size(56, 19);
            this.RemoveCaliberButton.TabIndex = 2;
            this.RemoveCaliberButton.Text = "Remove";
            this.RemoveCaliberButton.UseVisualStyleBackColor = true;
            // 
            // EditCaliberButton
            // 
            this.EditCaliberButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCaliberButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EditCaliberButton.Location = new System.Drawing.Point(190, 135);
            this.EditCaliberButton.Margin = new System.Windows.Forms.Padding(2);
            this.EditCaliberButton.Name = "EditCaliberButton";
            this.EditCaliberButton.Size = new System.Drawing.Size(56, 19);
            this.EditCaliberButton.TabIndex = 1;
            this.EditCaliberButton.Text = "Edit";
            this.EditCaliberButton.UseVisualStyleBackColor = true;
            // 
            // AddCaliberButton
            // 
            this.AddCaliberButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCaliberButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AddCaliberButton.Location = new System.Drawing.Point(122, 135);
            this.AddCaliberButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddCaliberButton.Name = "AddCaliberButton";
            this.AddCaliberButton.Size = new System.Drawing.Size(56, 19);
            this.AddCaliberButton.TabIndex = 0;
            this.AddCaliberButton.Text = "Add";
            this.AddCaliberButton.UseVisualStyleBackColor = true;
            // 
            // cBulletForm
            // 
            this.AcceptButton = this.BulletOKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BulletCancelButton;
            this.ClientSize = new System.Drawing.Size(533, 559);
            this.ControlBox = false;
            this.Controls.Add(this.CaliberDataGroupBox);
            this.Controls.Add(this.InventoryGroupBox);
            this.Controls.Add(this.BulletCancelButton);
            this.Controls.Add(this.BulletOKButton);
            this.Controls.Add(this.GeneralGroupBox);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cBulletForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Bullet";
            this.GeneralGroupBox.ResumeLayout(false);
            this.GeneralGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BulletImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.InventoryGroupBox.ResumeLayout(false);
            this.InventoryGroupBox.PerformLayout();
            this.CaliberDataGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.ComboBox ManufacturerCombo;
		private System.Windows.Forms.Button BulletOKButton;
		private System.Windows.Forms.Button BulletCancelButton;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button TypeWizardButton;
		private System.Windows.Forms.Label PartNumberLabel;
		private System.Windows.Forms.GroupBox GeneralGroupBox;
		private System.Windows.Forms.PictureBox BulletImage;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox InventoryGroupBox;
		private System.Windows.Forms.GroupBox CaliberDataGroupBox;
		private System.Windows.Forms.Button RemoveCaliberButton;
		private System.Windows.Forms.Button EditCaliberButton;
		private System.Windows.Forms.Button AddCaliberButton;
		private System.Windows.Forms.RadioButton SelfCastRadioButton;
		private System.Windows.Forms.Label CostEachLabel;
		private System.Windows.Forms.Label SectionalDensityLabel;
		private System.Windows.Forms.Label DuplicateLabel;
		private System.Windows.Forms.Label CostLabel;
		private System.Windows.Forms.Label QuantityLabel;
		private Controls.cFirearmTypeCombo FirearmTypeCombo;
		private CommonLib.Controls.cDoubleValueTextBox BulletDiameterTextBox;
		private CommonLib.Controls.cDoubleValueTextBox BallisticCoefficientTextBox;
		private CommonLib.Controls.cIntegerValueTextBox QuantityTextBox;
		private CommonLib.Controls.cIntegerValueTextBox TopPunchTextBox;
		private CommonLib.Controls.cTextBox PartNumberTextBox;
		private CommonLib.Controls.cTextBox TypeTextBox;
		private CommonLib.Controls.cDoubleValueTextBox CostTextBox;
		private System.Windows.Forms.Label TopPunchLabel;
		private CommonLib.Controls.cDoubleValueTextBox BulletWeightTextBox;
		private CommonLib.Controls.cDoubleValueTextBox LengthTextBox;
		private System.Windows.Forms.Label BulletWeightMeasurementLabel;
		private System.Windows.Forms.Label DiameterMeasurementLabel;
		private System.Windows.Forms.Label LengthMeasurementLabel;
		private System.Windows.Forms.Button InventoryButton;
		}
	}