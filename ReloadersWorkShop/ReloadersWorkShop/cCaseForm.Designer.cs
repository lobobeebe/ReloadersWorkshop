namespace ReloadersWorkShop
	{
	partial class cCaseForm
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

				m_CaseBitmap.Dispose();
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
			System.Windows.Forms.Label label8;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label9;
			System.Windows.Forms.Label label16;
			this.CaliberCombo = new System.Windows.Forms.ComboBox();
			this.ManufacturerCombo = new System.Windows.Forms.ComboBox();
			this.CaseCancelButton = new System.Windows.Forms.Button();
			this.CaseOKButton = new System.Windows.Forms.Button();
			this.GeneralGroupBox = new System.Windows.Forms.GroupBox();
			this.MilitaryCheckBox = new System.Windows.Forms.CheckBox();
			this.MatchCheckBox = new System.Windows.Forms.CheckBox();
			this.CaliberScopeLabel = new System.Windows.Forms.Label();
			this.PartNumberTextBox = new System.Windows.Forms.TextBox();
			this.HeadStampLabel = new System.Windows.Forms.Label();
			this.CaseImage = new System.Windows.Forms.PictureBox();
			this.InventoryGroupBox = new System.Windows.Forms.GroupBox();
			this.CostTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.QuantityTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.CostEachLabel = new System.Windows.Forms.Label();
			this.CostLabel = new System.Windows.Forms.Label();
			this.QuantityLabel = new System.Windows.Forms.Label();
			this.InventoryButton = new System.Windows.Forms.Button();
			this.SmallPrimerRadioButton = new System.Windows.Forms.RadioButton();
			this.LargePrimerRadioButton = new System.Windows.Forms.RadioButton();
			this.FirearmTypeCombo = new ReloadersWorkShop.Controls.cFirearmTypeCombo();
			this.DuplicateCaseLabel = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			this.GeneralGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CaseImage)).BeginInit();
			this.InventoryGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label8.ForeColor = System.Drawing.SystemColors.ControlText;
			label8.Location = new System.Drawing.Point(18, 86);
			label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(71, 13);
			label8.TabIndex = 22;
			label8.Text = "Firearm Type:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label3.ForeColor = System.Drawing.SystemColors.ControlText;
			label3.Location = new System.Drawing.Point(46, 114);
			label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(42, 13);
			label3.TabIndex = 21;
			label3.Text = "Caliber:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label1.ForeColor = System.Drawing.SystemColors.ControlText;
			label1.Location = new System.Drawing.Point(16, 30);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(73, 13);
			label1.TabIndex = 17;
			label1.Text = "Manufacturer:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label4.ForeColor = System.Drawing.SystemColors.ControlText;
			label4.Location = new System.Drawing.Point(19, 142);
			label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(69, 13);
			label4.TabIndex = 24;
			label4.Text = "Head Stamp:";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label9.ForeColor = System.Drawing.SystemColors.ControlText;
			label9.Location = new System.Drawing.Point(20, 58);
			label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(69, 13);
			label9.TabIndex = 27;
			label9.Text = "Part Number:";
			label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label16
			// 
			label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label16.ForeColor = System.Drawing.SystemColors.ControlText;
			label16.Location = new System.Drawing.Point(359, 32);
			label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(67, 13);
			label16.TabIndex = 35;
			label16.Text = "Cost Each:";
			label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// CaliberCombo
			// 
			this.CaliberCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CaliberCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CaliberCombo.FormattingEnabled = true;
			this.CaliberCombo.Location = new System.Drawing.Point(92, 111);
			this.CaliberCombo.Margin = new System.Windows.Forms.Padding(2);
			this.CaliberCombo.Name = "CaliberCombo";
			this.CaliberCombo.Size = new System.Drawing.Size(200, 21);
			this.CaliberCombo.Sorted = true;
			this.CaliberCombo.TabIndex = 3;
			// 
			// ManufacturerCombo
			// 
			this.ManufacturerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ManufacturerCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ManufacturerCombo.FormattingEnabled = true;
			this.ManufacturerCombo.Location = new System.Drawing.Point(92, 27);
			this.ManufacturerCombo.Margin = new System.Windows.Forms.Padding(2);
			this.ManufacturerCombo.Name = "ManufacturerCombo";
			this.ManufacturerCombo.Size = new System.Drawing.Size(150, 21);
			this.ManufacturerCombo.Sorted = true;
			this.ManufacturerCombo.TabIndex = 0;
			// 
			// CaseCancelButton
			// 
			this.CaseCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CaseCancelButton.Location = new System.Drawing.Point(277, 355);
			this.CaseCancelButton.Margin = new System.Windows.Forms.Padding(2);
			this.CaseCancelButton.Name = "CaseCancelButton";
			this.CaseCancelButton.Size = new System.Drawing.Size(56, 19);
			this.CaseCancelButton.TabIndex = 3;
			this.CaseCancelButton.Text = "Cancel";
			this.CaseCancelButton.UseVisualStyleBackColor = true;
			// 
			// CaseOKButton
			// 
			this.CaseOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CaseOKButton.Location = new System.Drawing.Point(204, 355);
			this.CaseOKButton.Margin = new System.Windows.Forms.Padding(2);
			this.CaseOKButton.Name = "CaseOKButton";
			this.CaseOKButton.Size = new System.Drawing.Size(56, 19);
			this.CaseOKButton.TabIndex = 2;
			this.CaseOKButton.Text = "OK";
			this.CaseOKButton.UseVisualStyleBackColor = true;
			// 
			// GeneralGroupBox
			// 
			this.GeneralGroupBox.Controls.Add(this.DuplicateCaseLabel);
			this.GeneralGroupBox.Controls.Add(this.LargePrimerRadioButton);
			this.GeneralGroupBox.Controls.Add(this.SmallPrimerRadioButton);
			this.GeneralGroupBox.Controls.Add(this.MatchCheckBox);
			this.GeneralGroupBox.Controls.Add(this.CaliberScopeLabel);
			this.GeneralGroupBox.Controls.Add(this.FirearmTypeCombo);
			this.GeneralGroupBox.Controls.Add(this.PartNumberTextBox);
			this.GeneralGroupBox.Controls.Add(label9);
			this.GeneralGroupBox.Controls.Add(this.HeadStampLabel);
			this.GeneralGroupBox.Controls.Add(label4);
			this.GeneralGroupBox.Controls.Add(this.CaseImage);
			this.GeneralGroupBox.Controls.Add(this.ManufacturerCombo);
			this.GeneralGroupBox.Controls.Add(label1);
			this.GeneralGroupBox.Controls.Add(label3);
			this.GeneralGroupBox.Controls.Add(this.CaliberCombo);
			this.GeneralGroupBox.Controls.Add(label8);
			this.GeneralGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GeneralGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.GeneralGroupBox.Location = new System.Drawing.Point(10, 10);
			this.GeneralGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.GeneralGroupBox.Name = "GeneralGroupBox";
			this.GeneralGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.GeneralGroupBox.Size = new System.Drawing.Size(515, 224);
			this.GeneralGroupBox.TabIndex = 0;
			this.GeneralGroupBox.TabStop = false;
			this.GeneralGroupBox.Text = "General";
			// 
			// MilitaryCheckBox
			// 
			this.MilitaryCheckBox.AutoCheck = false;
			this.MilitaryCheckBox.AutoSize = true;
			this.MilitaryCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MilitaryCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MilitaryCheckBox.Location = new System.Drawing.Point(372, 178);
			this.MilitaryCheckBox.Name = "MilitaryCheckBox";
			this.MilitaryCheckBox.Size = new System.Drawing.Size(87, 17);
			this.MilitaryCheckBox.TabIndex = 0;
			this.MilitaryCheckBox.Text = "Military Crimp";
			this.MilitaryCheckBox.UseVisualStyleBackColor = true;
			// 
			// MatchCheckBox
			// 
			this.MatchCheckBox.AutoCheck = false;
			this.MatchCheckBox.AutoSize = true;
			this.MatchCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MatchCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MatchCheckBox.Location = new System.Drawing.Point(291, 168);
			this.MatchCheckBox.Name = "MatchCheckBox";
			this.MatchCheckBox.Size = new System.Drawing.Size(56, 17);
			this.MatchCheckBox.TabIndex = 7;
			this.MatchCheckBox.Text = "Match";
			this.MatchCheckBox.UseVisualStyleBackColor = true;
			// 
			// CaliberScopeLabel
			// 
			this.CaliberScopeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CaliberScopeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CaliberScopeLabel.Location = new System.Drawing.Point(297, 114);
			this.CaliberScopeLabel.Name = "CaliberScopeLabel";
			this.CaliberScopeLabel.Size = new System.Drawing.Size(158, 13);
			this.CaliberScopeLabel.TabIndex = 28;
			this.CaliberScopeLabel.Text = "label10";
			this.CaliberScopeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PartNumberTextBox
			// 
			this.PartNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PartNumberTextBox.Location = new System.Drawing.Point(92, 55);
			this.PartNumberTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.PartNumberTextBox.MaxLength = 25;
			this.PartNumberTextBox.Name = "PartNumberTextBox";
			this.PartNumberTextBox.Size = new System.Drawing.Size(150, 19);
			this.PartNumberTextBox.TabIndex = 1;
			// 
			// HeadStampLabel
			// 
			this.HeadStampLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.HeadStampLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.HeadStampLabel.Location = new System.Drawing.Point(89, 142);
			this.HeadStampLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.HeadStampLabel.Name = "HeadStampLabel";
			this.HeadStampLabel.Size = new System.Drawing.Size(316, 14);
			this.HeadStampLabel.TabIndex = 4;
			this.HeadStampLabel.UseMnemonic = false;
			// 
			// CaseImage
			// 
			this.CaseImage.BackColor = System.Drawing.SystemColors.Control;
			this.CaseImage.Location = new System.Drawing.Point(347, 18);
			this.CaseImage.Margin = new System.Windows.Forms.Padding(2);
			this.CaseImage.Name = "CaseImage";
			this.CaseImage.Size = new System.Drawing.Size(71, 86);
			this.CaseImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.CaseImage.TabIndex = 23;
			this.CaseImage.TabStop = false;
			// 
			// InventoryGroupBox
			// 
			this.InventoryGroupBox.Controls.Add(this.CostTextBox);
			this.InventoryGroupBox.Controls.Add(this.QuantityTextBox);
			this.InventoryGroupBox.Controls.Add(this.CostEachLabel);
			this.InventoryGroupBox.Controls.Add(label16);
			this.InventoryGroupBox.Controls.Add(this.CostLabel);
			this.InventoryGroupBox.Controls.Add(this.QuantityLabel);
			this.InventoryGroupBox.Controls.Add(this.InventoryButton);
			this.InventoryGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.InventoryGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.InventoryGroupBox.Location = new System.Drawing.Point(10, 238);
			this.InventoryGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.InventoryGroupBox.Name = "InventoryGroupBox";
			this.InventoryGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.InventoryGroupBox.Size = new System.Drawing.Size(515, 99);
			this.InventoryGroupBox.TabIndex = 1;
			this.InventoryGroupBox.TabStop = false;
			this.InventoryGroupBox.Text = "Costs && Pricing";
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
			this.QuantityTextBox.Size = new System.Drawing.Size(45, 20);
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
			this.CostEachLabel.TabIndex = 32;
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
			this.CostLabel.Size = new System.Drawing.Size(46, 13);
			this.CostLabel.TabIndex = 34;
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
			this.QuantityLabel.TabIndex = 33;
			this.QuantityLabel.Text = "Box of:";
			this.QuantityLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
			// SmallPrimerRadioButton
			// 
			this.SmallPrimerRadioButton.AutoCheck = false;
			this.SmallPrimerRadioButton.AutoSize = true;
			this.SmallPrimerRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SmallPrimerRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SmallPrimerRadioButton.Location = new System.Drawing.Point(60, 167);
			this.SmallPrimerRadioButton.Name = "SmallPrimerRadioButton";
			this.SmallPrimerRadioButton.Size = new System.Drawing.Size(82, 17);
			this.SmallPrimerRadioButton.TabIndex = 5;
			this.SmallPrimerRadioButton.TabStop = true;
			this.SmallPrimerRadioButton.Text = "Small Primer";
			this.SmallPrimerRadioButton.UseVisualStyleBackColor = true;
			// 
			// LargePrimerRadioButton
			// 
			this.LargePrimerRadioButton.AutoCheck = false;
			this.LargePrimerRadioButton.AutoSize = true;
			this.LargePrimerRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LargePrimerRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LargePrimerRadioButton.Location = new System.Drawing.Point(160, 167);
			this.LargePrimerRadioButton.Name = "LargePrimerRadioButton";
			this.LargePrimerRadioButton.Size = new System.Drawing.Size(84, 17);
			this.LargePrimerRadioButton.TabIndex = 6;
			this.LargePrimerRadioButton.TabStop = true;
			this.LargePrimerRadioButton.Text = "Large Primer";
			this.LargePrimerRadioButton.UseVisualStyleBackColor = true;
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
            "Rifle"});
			this.FirearmTypeCombo.Location = new System.Drawing.Point(92, 83);
			this.FirearmTypeCombo.Name = "FirearmTypeCombo";
			this.FirearmTypeCombo.Size = new System.Drawing.Size(100, 21);
			this.FirearmTypeCombo.TabIndex = 2;
			this.FirearmTypeCombo.ToolTip = "";
			this.FirearmTypeCombo.Value = ReloadersWorkShop.cFirearm.eFireArmType.Handgun;
			// 
			// DuplicateCaseLabel
			// 
			this.DuplicateCaseLabel.AutoSize = true;
			this.DuplicateCaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DuplicateCaseLabel.ForeColor = System.Drawing.Color.Red;
			this.DuplicateCaseLabel.Location = new System.Drawing.Point(216, 200);
			this.DuplicateCaseLabel.Name = "DuplicateCaseLabel";
			this.DuplicateCaseLabel.Size = new System.Drawing.Size(82, 13);
			this.DuplicateCaseLabel.TabIndex = 29;
			this.DuplicateCaseLabel.Text = "Duplicate Case!";
			// 
			// cCaseForm
			// 
			this.AcceptButton = this.CaseOKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CaseCancelButton;
			this.ClientSize = new System.Drawing.Size(537, 385);
			this.ControlBox = false;
			this.Controls.Add(this.MilitaryCheckBox);
			this.Controls.Add(this.InventoryGroupBox);
			this.Controls.Add(this.CaseCancelButton);
			this.Controls.Add(this.CaseOKButton);
			this.Controls.Add(this.GeneralGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cCaseForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Case";
			this.GeneralGroupBox.ResumeLayout(false);
			this.GeneralGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CaseImage)).EndInit();
			this.InventoryGroupBox.ResumeLayout(false);
			this.InventoryGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.ComboBox CaliberCombo;
		private System.Windows.Forms.ComboBox ManufacturerCombo;
		private System.Windows.Forms.Button CaseCancelButton;
		private System.Windows.Forms.Button CaseOKButton;
		private System.Windows.Forms.GroupBox GeneralGroupBox;
		private System.Windows.Forms.PictureBox CaseImage;
		private System.Windows.Forms.GroupBox InventoryGroupBox;
		private System.Windows.Forms.Label HeadStampLabel;
		private System.Windows.Forms.TextBox PartNumberTextBox;
		private Controls.cFirearmTypeCombo FirearmTypeCombo;
		private System.Windows.Forms.Label CaliberScopeLabel;
		private System.Windows.Forms.CheckBox MilitaryCheckBox;
		private System.Windows.Forms.CheckBox MatchCheckBox;
		private System.Windows.Forms.Button InventoryButton;
		private CommonLib.Controls.cDoubleValueTextBox CostTextBox;
		private CommonLib.Controls.cIntegerValueTextBox QuantityTextBox;
		private System.Windows.Forms.Label CostEachLabel;
		private System.Windows.Forms.Label CostLabel;
		private System.Windows.Forms.Label QuantityLabel;
		private System.Windows.Forms.RadioButton LargePrimerRadioButton;
		private System.Windows.Forms.RadioButton SmallPrimerRadioButton;
		private System.Windows.Forms.Label DuplicateCaseLabel;
		}
	}