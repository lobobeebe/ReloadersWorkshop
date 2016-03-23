namespace ReloadersWorkShop
	{
	partial class cLoadForm
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
			if (disposing)
				{
				if (components != null)
					components.Dispose();

				if (m_BulletBitmap != null)
					m_BulletBitmap.Dispose();

				if (m_CartridgeBitmap != null)
					m_CartridgeBitmap.Dispose();

				if (m_CartridgeDimensionsBitmap != null)
					m_CartridgeDimensionsBitmap.Dispose();
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
			System.Windows.Forms.Label label7;
			System.Windows.Forms.Label label8;
			System.Windows.Forms.Label label14;
			System.Windows.Forms.Label label6;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label9;
			System.Windows.Forms.Label label10;
			System.Windows.Forms.Label label11;
			System.Windows.Forms.Label label12;
			this.CaliberCombo = new System.Windows.Forms.ComboBox();
			this.GeneralGroupBox = new System.Windows.Forms.GroupBox();
			this.FirearmTypeCombo = new ReloadersWorkShop.Controls.cFirearmTypeCombo();
			this.ErrorMessageLabel = new System.Windows.Forms.Label();
			this.BulletCOLLabel = new System.Windows.Forms.Label();
			this.MaxCOLLabel = new System.Windows.Forms.Label();
			this.MaxCaseLengthLabel = new System.Windows.Forms.Label();
			this.CaseLengthLabel = new System.Windows.Forms.Label();
			this.COLLabel = new System.Windows.Forms.Label();
			this.CartridgeDimensionsImage = new System.Windows.Forms.PictureBox();
			this.CartridgeImage = new System.Windows.Forms.PictureBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.CasesLoadedTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.CartridgeCostLabel = new System.Windows.Forms.Label();
			this.PrimerCostLabel = new System.Windows.Forms.Label();
			this.CaseCostLabel = new System.Windows.Forms.Label();
			this.PowderCostLabel = new System.Windows.Forms.Label();
			this.BulletCostLabel = new System.Windows.Forms.Label();
			this.BulletImage = new System.Windows.Forms.PictureBox();
			this.label22 = new System.Windows.Forms.Label();
			this.BulletCombo = new System.Windows.Forms.ComboBox();
			this.PowderCombo = new System.Windows.Forms.ComboBox();
			this.CaseCombo = new System.Windows.Forms.ComboBox();
			this.PrimerCombo = new System.Windows.Forms.ComboBox();
			this.LoadOKButton = new System.Windows.Forms.Button();
			this.LoadCancelButton = new System.Windows.Forms.Button();
			this.PowderChargeGroup = new System.Windows.Forms.GroupBox();
			this.ViewChargeButton = new System.Windows.Forms.Button();
			this.CopyChargeListButton = new System.Windows.Forms.Button();
			this.RemoveChargeButton = new System.Windows.Forms.Button();
			this.EditChargeButton = new System.Windows.Forms.Button();
			this.AddChargeButton = new System.Windows.Forms.Button();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			this.GeneralGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CartridgeDimensionsImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CartridgeImage)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BulletImage)).BeginInit();
			this.PowderChargeGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label7.ForeColor = System.Drawing.SystemColors.ControlText;
			label7.Location = new System.Drawing.Point(52, 49);
			label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(42, 13);
			label7.TabIndex = 11;
			label7.Text = "Caliber:";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label8.ForeColor = System.Drawing.SystemColors.ControlText;
			label8.Location = new System.Drawing.Point(22, 24);
			label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(71, 13);
			label8.TabIndex = 13;
			label8.Text = "Firearm Type:";
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label14.ForeColor = System.Drawing.SystemColors.ControlText;
			label14.Location = new System.Drawing.Point(454, 98);
			label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(108, 13);
			label14.TabIndex = 27;
			label14.Text = "COAL with this Bullet:";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label6.ForeColor = System.Drawing.SystemColors.ControlText;
			label6.Location = new System.Drawing.Point(501, 73);
			label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(61, 13);
			label6.TabIndex = 21;
			label6.Text = "Max COAL:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label4.ForeColor = System.Drawing.SystemColors.ControlText;
			label4.Location = new System.Drawing.Point(469, 49);
			label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(93, 13);
			label4.TabIndex = 18;
			label4.Text = "Max Case Length:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label1.ForeColor = System.Drawing.SystemColors.ControlText;
			label1.Location = new System.Drawing.Point(469, 24);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(93, 13);
			label1.TabIndex = 15;
			label1.Text = "Case Trim Length:";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label9.ForeColor = System.Drawing.SystemColors.ControlText;
			label9.Location = new System.Drawing.Point(18, 24);
			label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(36, 13);
			label9.TabIndex = 0;
			label9.Text = "Bullet:";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label10.ForeColor = System.Drawing.SystemColors.ControlText;
			label10.Location = new System.Drawing.Point(9, 49);
			label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(46, 13);
			label10.TabIndex = 2;
			label10.Text = "Powder:";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label11.ForeColor = System.Drawing.SystemColors.ControlText;
			label11.Location = new System.Drawing.Point(20, 73);
			label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(34, 13);
			label11.TabIndex = 4;
			label11.Text = "Case:";
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label12.ForeColor = System.Drawing.SystemColors.ControlText;
			label12.Location = new System.Drawing.Point(14, 98);
			label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(39, 13);
			label12.TabIndex = 6;
			label12.Text = "Primer:";
			// 
			// CaliberCombo
			// 
			this.CaliberCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CaliberCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CaliberCombo.FormattingEnabled = true;
			this.CaliberCombo.Location = new System.Drawing.Point(96, 46);
			this.CaliberCombo.Margin = new System.Windows.Forms.Padding(2);
			this.CaliberCombo.Name = "CaliberCombo";
			this.CaliberCombo.Size = new System.Drawing.Size(200, 21);
			this.CaliberCombo.Sorted = true;
			this.CaliberCombo.TabIndex = 1;
			// 
			// GeneralGroupBox
			// 
			this.GeneralGroupBox.Controls.Add(this.FirearmTypeCombo);
			this.GeneralGroupBox.Controls.Add(this.ErrorMessageLabel);
			this.GeneralGroupBox.Controls.Add(this.BulletCOLLabel);
			this.GeneralGroupBox.Controls.Add(this.MaxCOLLabel);
			this.GeneralGroupBox.Controls.Add(this.MaxCaseLengthLabel);
			this.GeneralGroupBox.Controls.Add(this.CaseLengthLabel);
			this.GeneralGroupBox.Controls.Add(label14);
			this.GeneralGroupBox.Controls.Add(this.COLLabel);
			this.GeneralGroupBox.Controls.Add(this.CartridgeDimensionsImage);
			this.GeneralGroupBox.Controls.Add(this.CartridgeImage);
			this.GeneralGroupBox.Controls.Add(label6);
			this.GeneralGroupBox.Controls.Add(label4);
			this.GeneralGroupBox.Controls.Add(label1);
			this.GeneralGroupBox.Controls.Add(label7);
			this.GeneralGroupBox.Controls.Add(this.CaliberCombo);
			this.GeneralGroupBox.Controls.Add(label8);
			this.GeneralGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GeneralGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.GeneralGroupBox.Location = new System.Drawing.Point(10, 10);
			this.GeneralGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.GeneralGroupBox.Name = "GeneralGroupBox";
			this.GeneralGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.GeneralGroupBox.Size = new System.Drawing.Size(697, 140);
			this.GeneralGroupBox.TabIndex = 0;
			this.GeneralGroupBox.TabStop = false;
			this.GeneralGroupBox.Text = "General";
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
            "Rifle"});
			this.FirearmTypeCombo.Location = new System.Drawing.Point(96, 22);
			this.FirearmTypeCombo.Name = "FirearmTypeCombo";
			this.FirearmTypeCombo.Size = new System.Drawing.Size(100, 21);
			this.FirearmTypeCombo.TabIndex = 0;
			this.FirearmTypeCombo.ToolTip = "";
			this.FirearmTypeCombo.Value = ReloadersWorkShop.cFirearm.eFireArmType.Handgun;
			// 
			// ErrorMessageLabel
			// 
			this.ErrorMessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ErrorMessageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.ErrorMessageLabel.Location = new System.Drawing.Point(9, 82);
			this.ErrorMessageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.ErrorMessageLabel.Name = "ErrorMessageLabel";
			this.ErrorMessageLabel.Size = new System.Drawing.Size(256, 44);
			this.ErrorMessageLabel.TabIndex = 32;
			// 
			// BulletCOLLabel
			// 
			this.BulletCOLLabel.AutoSize = true;
			this.BulletCOLLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletCOLLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BulletCOLLabel.Location = new System.Drawing.Point(566, 98);
			this.BulletCOLLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.BulletCOLLabel.Name = "BulletCOLLabel";
			this.BulletCOLLabel.Size = new System.Drawing.Size(67, 13);
			this.BulletCOLLabel.TabIndex = 31;
			this.BulletCOLLabel.Text = "Bullet COL";
			// 
			// MaxCOLLabel
			// 
			this.MaxCOLLabel.AutoSize = true;
			this.MaxCOLLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxCOLLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxCOLLabel.Location = new System.Drawing.Point(566, 73);
			this.MaxCOLLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MaxCOLLabel.Name = "MaxCOLLabel";
			this.MaxCOLLabel.Size = new System.Drawing.Size(58, 13);
			this.MaxCOLLabel.TabIndex = 30;
			this.MaxCOLLabel.Text = "Max COL";
			// 
			// MaxCaseLengthLabel
			// 
			this.MaxCaseLengthLabel.AutoSize = true;
			this.MaxCaseLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxCaseLengthLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxCaseLengthLabel.Location = new System.Drawing.Point(566, 49);
			this.MaxCaseLengthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MaxCaseLengthLabel.Name = "MaxCaseLengthLabel";
			this.MaxCaseLengthLabel.Size = new System.Drawing.Size(105, 13);
			this.MaxCaseLengthLabel.TabIndex = 29;
			this.MaxCaseLengthLabel.Text = "Max Case Length";
			// 
			// CaseLengthLabel
			// 
			this.CaseLengthLabel.AutoSize = true;
			this.CaseLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CaseLengthLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CaseLengthLabel.Location = new System.Drawing.Point(566, 24);
			this.CaseLengthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.CaseLengthLabel.Name = "CaseLengthLabel";
			this.CaseLengthLabel.Size = new System.Drawing.Size(78, 13);
			this.CaseLengthLabel.TabIndex = 28;
			this.CaseLengthLabel.Text = "Case Length";
			// 
			// COLLabel
			// 
			this.COLLabel.BackColor = System.Drawing.Color.White;
			this.COLLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.COLLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.COLLabel.Location = new System.Drawing.Point(376, 72);
			this.COLLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.COLLabel.Name = "COLLabel";
			this.COLLabel.Size = new System.Drawing.Size(74, 14);
			this.COLLabel.TabIndex = 26;
			this.COLLabel.Text = "0.000\"";
			this.COLLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// CartridgeDimensionsImage
			// 
			this.CartridgeDimensionsImage.BackColor = System.Drawing.SystemColors.Control;
			this.CartridgeDimensionsImage.BackgroundImage = global::ReloadersWorkShop.Properties.Resources.CartridgeDimensions;
			this.CartridgeDimensionsImage.ImageLocation = "";
			this.CartridgeDimensionsImage.Location = new System.Drawing.Point(375, 26);
			this.CartridgeDimensionsImage.Margin = new System.Windows.Forms.Padding(2);
			this.CartridgeDimensionsImage.Name = "CartridgeDimensionsImage";
			this.CartridgeDimensionsImage.Size = new System.Drawing.Size(75, 100);
			this.CartridgeDimensionsImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.CartridgeDimensionsImage.TabIndex = 25;
			this.CartridgeDimensionsImage.TabStop = false;
			// 
			// CartridgeImage
			// 
			this.CartridgeImage.BackColor = System.Drawing.SystemColors.Control;
			this.CartridgeImage.Location = new System.Drawing.Point(325, 26);
			this.CartridgeImage.Margin = new System.Windows.Forms.Padding(2);
			this.CartridgeImage.Name = "CartridgeImage";
			this.CartridgeImage.Size = new System.Drawing.Size(50, 100);
			this.CartridgeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.CartridgeImage.TabIndex = 24;
			this.CartridgeImage.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.CasesLoadedTextBox);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.CartridgeCostLabel);
			this.groupBox3.Controls.Add(this.PrimerCostLabel);
			this.groupBox3.Controls.Add(this.CaseCostLabel);
			this.groupBox3.Controls.Add(this.PowderCostLabel);
			this.groupBox3.Controls.Add(this.BulletCostLabel);
			this.groupBox3.Controls.Add(this.BulletImage);
			this.groupBox3.Controls.Add(this.label22);
			this.groupBox3.Controls.Add(this.BulletCombo);
			this.groupBox3.Controls.Add(label9);
			this.groupBox3.Controls.Add(label10);
			this.groupBox3.Controls.Add(this.PowderCombo);
			this.groupBox3.Controls.Add(label11);
			this.groupBox3.Controls.Add(this.CaseCombo);
			this.groupBox3.Controls.Add(label12);
			this.groupBox3.Controls.Add(this.PrimerCombo);
			this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox3.Location = new System.Drawing.Point(10, 154);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox3.Size = new System.Drawing.Size(697, 128);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Load";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(610, 101);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 24;
			this.label3.Text = "times)";
			// 
			// CasesLoadedTextBox
			// 
			this.CasesLoadedTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.CasesLoadedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CasesLoadedTextBox.Location = new System.Drawing.Point(580, 98);
			this.CasesLoadedTextBox.MaxLength = 2;
			this.CasesLoadedTextBox.MaxValue = 0;
			this.CasesLoadedTextBox.MinValue = 0;
			this.CasesLoadedTextBox.Name = "CasesLoadedTextBox";
			this.CasesLoadedTextBox.Required = false;
			this.CasesLoadedTextBox.Size = new System.Drawing.Size(24, 20);
			this.CasesLoadedTextBox.TabIndex = 4;
			this.CasesLoadedTextBox.Text = "0";
			this.CasesLoadedTextBox.ToolTip = "";
			this.CasesLoadedTextBox.Value = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(577, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 13);
			this.label2.TabIndex = 22;
			this.label2.Text = "(Cases loaded";
			// 
			// CartridgeCostLabel
			// 
			this.CartridgeCostLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CartridgeCostLabel.Location = new System.Drawing.Point(565, 49);
			this.CartridgeCostLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.CartridgeCostLabel.Name = "CartridgeCostLabel";
			this.CartridgeCostLabel.Size = new System.Drawing.Size(99, 14);
			this.CartridgeCostLabel.TabIndex = 21;
			this.CartridgeCostLabel.Text = "0.00";
			this.CartridgeCostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// PrimerCostLabel
			// 
			this.PrimerCostLabel.AutoSize = true;
			this.PrimerCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PrimerCostLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PrimerCostLabel.Location = new System.Drawing.Point(322, 98);
			this.PrimerCostLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.PrimerCostLabel.Name = "PrimerCostLabel";
			this.PrimerCostLabel.Size = new System.Drawing.Size(71, 13);
			this.PrimerCostLabel.TabIndex = 20;
			this.PrimerCostLabel.Text = "Primer Cost";
			// 
			// CaseCostLabel
			// 
			this.CaseCostLabel.AutoSize = true;
			this.CaseCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CaseCostLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CaseCostLabel.Location = new System.Drawing.Point(322, 73);
			this.CaseCostLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.CaseCostLabel.Name = "CaseCostLabel";
			this.CaseCostLabel.Size = new System.Drawing.Size(64, 13);
			this.CaseCostLabel.TabIndex = 19;
			this.CaseCostLabel.Text = "Case Cost";
			// 
			// PowderCostLabel
			// 
			this.PowderCostLabel.AutoSize = true;
			this.PowderCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PowderCostLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PowderCostLabel.Location = new System.Drawing.Point(323, 49);
			this.PowderCostLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.PowderCostLabel.Name = "PowderCostLabel";
			this.PowderCostLabel.Size = new System.Drawing.Size(78, 13);
			this.PowderCostLabel.TabIndex = 18;
			this.PowderCostLabel.Text = "Powder Cost";
			// 
			// BulletCostLabel
			// 
			this.BulletCostLabel.AutoSize = true;
			this.BulletCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletCostLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BulletCostLabel.Location = new System.Drawing.Point(323, 24);
			this.BulletCostLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.BulletCostLabel.Name = "BulletCostLabel";
			this.BulletCostLabel.Size = new System.Drawing.Size(68, 13);
			this.BulletCostLabel.TabIndex = 17;
			this.BulletCostLabel.Text = "Bullet Cost";
			// 
			// BulletImage
			// 
			this.BulletImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BulletImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.BulletImage.Location = new System.Drawing.Point(427, 17);
			this.BulletImage.Margin = new System.Windows.Forms.Padding(2);
			this.BulletImage.Name = "BulletImage";
			this.BulletImage.Size = new System.Drawing.Size(100, 100);
			this.BulletImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.BulletImage.TabIndex = 16;
			this.BulletImage.TabStop = false;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label22.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label22.Location = new System.Drawing.Point(561, 24);
			this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(117, 17);
			this.label22.TabIndex = 14;
			this.label22.Text = "Cartridge Cost:";
			// 
			// BulletCombo
			// 
			this.BulletCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BulletCombo.DropDownWidth = 300;
			this.BulletCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletCombo.FormattingEnabled = true;
			this.BulletCombo.Location = new System.Drawing.Point(58, 22);
			this.BulletCombo.Margin = new System.Windows.Forms.Padding(2);
			this.BulletCombo.Name = "BulletCombo";
			this.BulletCombo.Size = new System.Drawing.Size(250, 21);
			this.BulletCombo.TabIndex = 0;
			// 
			// PowderCombo
			// 
			this.PowderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PowderCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PowderCombo.FormattingEnabled = true;
			this.PowderCombo.Location = new System.Drawing.Point(58, 46);
			this.PowderCombo.Margin = new System.Windows.Forms.Padding(2);
			this.PowderCombo.Name = "PowderCombo";
			this.PowderCombo.Size = new System.Drawing.Size(250, 21);
			this.PowderCombo.Sorted = true;
			this.PowderCombo.TabIndex = 1;
			// 
			// CaseCombo
			// 
			this.CaseCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CaseCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CaseCombo.FormattingEnabled = true;
			this.CaseCombo.Location = new System.Drawing.Point(58, 71);
			this.CaseCombo.Margin = new System.Windows.Forms.Padding(2);
			this.CaseCombo.Name = "CaseCombo";
			this.CaseCombo.Size = new System.Drawing.Size(250, 21);
			this.CaseCombo.Sorted = true;
			this.CaseCombo.TabIndex = 2;
			// 
			// PrimerCombo
			// 
			this.PrimerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PrimerCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PrimerCombo.FormattingEnabled = true;
			this.PrimerCombo.Location = new System.Drawing.Point(58, 95);
			this.PrimerCombo.Margin = new System.Windows.Forms.Padding(2);
			this.PrimerCombo.Name = "PrimerCombo";
			this.PrimerCombo.Size = new System.Drawing.Size(250, 21);
			this.PrimerCombo.Sorted = true;
			this.PrimerCombo.TabIndex = 3;
			// 
			// LoadOKButton
			// 
			this.LoadOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.LoadOKButton.Location = new System.Drawing.Point(289, 552);
			this.LoadOKButton.Margin = new System.Windows.Forms.Padding(2);
			this.LoadOKButton.Name = "LoadOKButton";
			this.LoadOKButton.Size = new System.Drawing.Size(56, 19);
			this.LoadOKButton.TabIndex = 3;
			this.LoadOKButton.Text = "OK";
			this.LoadOKButton.UseVisualStyleBackColor = true;
			// 
			// LoadCancelButton
			// 
			this.LoadCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.LoadCancelButton.Location = new System.Drawing.Point(374, 552);
			this.LoadCancelButton.Margin = new System.Windows.Forms.Padding(2);
			this.LoadCancelButton.Name = "LoadCancelButton";
			this.LoadCancelButton.Size = new System.Drawing.Size(56, 19);
			this.LoadCancelButton.TabIndex = 4;
			this.LoadCancelButton.Text = "Cancel";
			this.LoadCancelButton.UseVisualStyleBackColor = true;
			// 
			// PowderChargeGroup
			// 
			this.PowderChargeGroup.Controls.Add(this.ViewChargeButton);
			this.PowderChargeGroup.Controls.Add(this.CopyChargeListButton);
			this.PowderChargeGroup.Controls.Add(this.RemoveChargeButton);
			this.PowderChargeGroup.Controls.Add(this.EditChargeButton);
			this.PowderChargeGroup.Controls.Add(this.AddChargeButton);
			this.PowderChargeGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PowderChargeGroup.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.PowderChargeGroup.Location = new System.Drawing.Point(10, 288);
			this.PowderChargeGroup.Margin = new System.Windows.Forms.Padding(2);
			this.PowderChargeGroup.Name = "PowderChargeGroup";
			this.PowderChargeGroup.Padding = new System.Windows.Forms.Padding(2);
			this.PowderChargeGroup.Size = new System.Drawing.Size(697, 249);
			this.PowderChargeGroup.TabIndex = 2;
			this.PowderChargeGroup.TabStop = false;
			this.PowderChargeGroup.Text = "Powder Charge Data";
			// 
			// ViewChargeButton
			// 
			this.ViewChargeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ViewChargeButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ViewChargeButton.Location = new System.Drawing.Point(298, 216);
			this.ViewChargeButton.Margin = new System.Windows.Forms.Padding(2);
			this.ViewChargeButton.Name = "ViewChargeButton";
			this.ViewChargeButton.Size = new System.Drawing.Size(100, 19);
			this.ViewChargeButton.TabIndex = 2;
			this.ViewChargeButton.Text = "View Charge";
			this.ViewChargeButton.UseVisualStyleBackColor = true;
			// 
			// CopyChargeListButton
			// 
			this.CopyChargeListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CopyChargeListButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CopyChargeListButton.Location = new System.Drawing.Point(536, 216);
			this.CopyChargeListButton.Margin = new System.Windows.Forms.Padding(2);
			this.CopyChargeListButton.Name = "CopyChargeListButton";
			this.CopyChargeListButton.Size = new System.Drawing.Size(100, 19);
			this.CopyChargeListButton.TabIndex = 4;
			this.CopyChargeListButton.Text = "Copy Charge List";
			this.CopyChargeListButton.UseVisualStyleBackColor = true;
			// 
			// RemoveChargeButton
			// 
			this.RemoveChargeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RemoveChargeButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RemoveChargeButton.Location = new System.Drawing.Point(417, 216);
			this.RemoveChargeButton.Margin = new System.Windows.Forms.Padding(2);
			this.RemoveChargeButton.Name = "RemoveChargeButton";
			this.RemoveChargeButton.Size = new System.Drawing.Size(100, 19);
			this.RemoveChargeButton.TabIndex = 3;
			this.RemoveChargeButton.Text = "Remove Charge";
			this.RemoveChargeButton.UseVisualStyleBackColor = true;
			// 
			// EditChargeButton
			// 
			this.EditChargeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EditChargeButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.EditChargeButton.Location = new System.Drawing.Point(179, 216);
			this.EditChargeButton.Margin = new System.Windows.Forms.Padding(2);
			this.EditChargeButton.Name = "EditChargeButton";
			this.EditChargeButton.Size = new System.Drawing.Size(100, 19);
			this.EditChargeButton.TabIndex = 1;
			this.EditChargeButton.Text = "Edit Charge";
			this.EditChargeButton.UseVisualStyleBackColor = true;
			// 
			// AddChargeButton
			// 
			this.AddChargeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AddChargeButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AddChargeButton.Location = new System.Drawing.Point(60, 216);
			this.AddChargeButton.Margin = new System.Windows.Forms.Padding(2);
			this.AddChargeButton.Name = "AddChargeButton";
			this.AddChargeButton.Size = new System.Drawing.Size(100, 19);
			this.AddChargeButton.TabIndex = 0;
			this.AddChargeButton.Text = "Add Charge";
			this.AddChargeButton.UseVisualStyleBackColor = true;
			// 
			// cLoadForm
			// 
			this.AcceptButton = this.LoadOKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.LoadCancelButton;
			this.ClientSize = new System.Drawing.Size(714, 568);
			this.ControlBox = false;
			this.Controls.Add(this.PowderChargeGroup);
			this.Controls.Add(this.LoadCancelButton);
			this.Controls.Add(this.LoadOKButton);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.GeneralGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cLoadForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Load";
			this.GeneralGroupBox.ResumeLayout(false);
			this.GeneralGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CartridgeDimensionsImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CartridgeImage)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.BulletImage)).EndInit();
			this.PowderChargeGroup.ResumeLayout(false);
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.ComboBox CaliberCombo;
		private System.Windows.Forms.GroupBox GeneralGroupBox;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox BulletCombo;
		private System.Windows.Forms.ComboBox PowderCombo;
		private System.Windows.Forms.ComboBox CaseCombo;
		private System.Windows.Forms.ComboBox PrimerCombo;
		private System.Windows.Forms.Button LoadOKButton;
		private System.Windows.Forms.Button LoadCancelButton;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.PictureBox CartridgeImage;
		private System.Windows.Forms.PictureBox CartridgeDimensionsImage;
		private System.Windows.Forms.Label COLLabel;
		private System.Windows.Forms.PictureBox BulletImage;
		private System.Windows.Forms.GroupBox PowderChargeGroup;
		private System.Windows.Forms.Button RemoveChargeButton;
		private System.Windows.Forms.Button EditChargeButton;
		private System.Windows.Forms.Button AddChargeButton;
		private System.Windows.Forms.Label BulletCOLLabel;
		private System.Windows.Forms.Label MaxCOLLabel;
		private System.Windows.Forms.Label MaxCaseLengthLabel;
		private System.Windows.Forms.Label CaseLengthLabel;
		private System.Windows.Forms.Label PrimerCostLabel;
		private System.Windows.Forms.Label CaseCostLabel;
		private System.Windows.Forms.Label PowderCostLabel;
		private System.Windows.Forms.Label BulletCostLabel;
		private System.Windows.Forms.Label ErrorMessageLabel;
		private System.Windows.Forms.Label CartridgeCostLabel;
		private System.Windows.Forms.Button CopyChargeListButton;
		private System.Windows.Forms.Button ViewChargeButton;
		private Controls.cFirearmTypeCombo FirearmTypeCombo;
		private System.Windows.Forms.Label label3;
		private CommonLib.Controls.cIntegerValueTextBox CasesLoadedTextBox;
		private System.Windows.Forms.Label label2;
		}
	}