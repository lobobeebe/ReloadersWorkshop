namespace ReloadersWorkShop
	{
	partial class cPrimerForm
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
			System.Windows.Forms.Label label8;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label16;
			this.PrimerCancelButton = new System.Windows.Forms.Button();
			this.PrimerOKButton = new System.Windows.Forms.Button();
			this.SizeCombo = new System.Windows.Forms.ComboBox();
			this.ManufacturerCombo = new System.Windows.Forms.ComboBox();
			this.GeneralGroupBox = new System.Windows.Forms.GroupBox();
			this.ModelTextBox = new CommonLib.Controls.cTextBox();
			this.FirearmTypeCombo = new ReloadersWorkShop.Controls.cFirearmTypeCombo();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.BenchRestCheckBox = new System.Windows.Forms.CheckBox();
			this.MilitaryCheckBox = new System.Windows.Forms.CheckBox();
			this.MagnumCheckBox = new System.Windows.Forms.CheckBox();
			this.StandardCheckBox = new System.Windows.Forms.CheckBox();
			this.InventoryGroupBox = new System.Windows.Forms.GroupBox();
			this.InventoryButton = new System.Windows.Forms.Button();
			this.CostTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.QuantityTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.CostEachLabel = new System.Windows.Forms.Label();
			this.CostLabel = new System.Windows.Forms.Label();
			this.QuantityLabel = new System.Windows.Forms.Label();
			this.CrossUseCheckBox = new System.Windows.Forms.CheckBox();
			label8 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			this.GeneralGroupBox.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.InventoryGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label8.ForeColor = System.Drawing.SystemColors.ControlText;
			label8.Location = new System.Drawing.Point(16, 24);
			label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(71, 13);
			label8.TabIndex = 36;
			label8.Text = "Firearm Type:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label3.ForeColor = System.Drawing.SystemColors.ControlText;
			label3.Location = new System.Drawing.Point(38, 24);
			label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(30, 13);
			label3.TabIndex = 35;
			label3.Text = "Size:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label1.ForeColor = System.Drawing.SystemColors.ControlText;
			label1.Location = new System.Drawing.Point(14, 49);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(73, 13);
			label1.TabIndex = 34;
			label1.Text = "Manufacturer:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label4.ForeColor = System.Drawing.SystemColors.ControlText;
			label4.Location = new System.Drawing.Point(19, 76);
			label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(68, 13);
			label4.TabIndex = 42;
			label4.Text = "Type/Model:";
			// 
			// label16
			// 
			label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label16.ForeColor = System.Drawing.SystemColors.ControlText;
			label16.Location = new System.Drawing.Point(359, 32);
			label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(67, 13);
			label16.TabIndex = 19;
			label16.Text = "Cost Each:";
			label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// PrimerCancelButton
			// 
			this.PrimerCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.PrimerCancelButton.Location = new System.Drawing.Point(281, 328);
			this.PrimerCancelButton.Margin = new System.Windows.Forms.Padding(2);
			this.PrimerCancelButton.Name = "PrimerCancelButton";
			this.PrimerCancelButton.Size = new System.Drawing.Size(56, 19);
			this.PrimerCancelButton.TabIndex = 4;
			this.PrimerCancelButton.Text = "Cancel";
			this.PrimerCancelButton.UseVisualStyleBackColor = true;
			// 
			// PrimerOKButton
			// 
			this.PrimerOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.PrimerOKButton.Location = new System.Drawing.Point(208, 328);
			this.PrimerOKButton.Margin = new System.Windows.Forms.Padding(2);
			this.PrimerOKButton.Name = "PrimerOKButton";
			this.PrimerOKButton.Size = new System.Drawing.Size(56, 19);
			this.PrimerOKButton.TabIndex = 3;
			this.PrimerOKButton.Text = "OK";
			this.PrimerOKButton.UseVisualStyleBackColor = true;
			// 
			// SizeCombo
			// 
			this.SizeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SizeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SizeCombo.FormattingEnabled = true;
			this.SizeCombo.Items.AddRange(new object[] {
            "Small",
            "Large"});
			this.SizeCombo.Location = new System.Drawing.Point(72, 21);
			this.SizeCombo.Margin = new System.Windows.Forms.Padding(2);
			this.SizeCombo.Name = "SizeCombo";
			this.SizeCombo.Size = new System.Drawing.Size(80, 21);
			this.SizeCombo.TabIndex = 0;
			// 
			// ManufacturerCombo
			// 
			this.ManufacturerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ManufacturerCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ManufacturerCombo.FormattingEnabled = true;
			this.ManufacturerCombo.Location = new System.Drawing.Point(91, 46);
			this.ManufacturerCombo.Margin = new System.Windows.Forms.Padding(2);
			this.ManufacturerCombo.Name = "ManufacturerCombo";
			this.ManufacturerCombo.Size = new System.Drawing.Size(150, 21);
			this.ManufacturerCombo.Sorted = true;
			this.ManufacturerCombo.TabIndex = 1;
			// 
			// GeneralGroupBox
			// 
			this.GeneralGroupBox.Controls.Add(this.CrossUseCheckBox);
			this.GeneralGroupBox.Controls.Add(this.ModelTextBox);
			this.GeneralGroupBox.Controls.Add(this.FirearmTypeCombo);
			this.GeneralGroupBox.Controls.Add(label4);
			this.GeneralGroupBox.Controls.Add(this.ManufacturerCombo);
			this.GeneralGroupBox.Controls.Add(label1);
			this.GeneralGroupBox.Controls.Add(label8);
			this.GeneralGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GeneralGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.GeneralGroupBox.Location = new System.Drawing.Point(11, 11);
			this.GeneralGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.GeneralGroupBox.Name = "GeneralGroupBox";
			this.GeneralGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.GeneralGroupBox.Size = new System.Drawing.Size(515, 110);
			this.GeneralGroupBox.TabIndex = 0;
			this.GeneralGroupBox.TabStop = false;
			this.GeneralGroupBox.Text = "General";
			// 
			// ModelTextBox
			// 
			this.ModelTextBox.BackColor = System.Drawing.Color.LightPink;
			this.ModelTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ModelTextBox.Location = new System.Drawing.Point(91, 73);
			this.ModelTextBox.MaxLength = 35;
			this.ModelTextBox.Name = "ModelTextBox";
			this.ModelTextBox.Required = true;
			this.ModelTextBox.Size = new System.Drawing.Size(187, 20);
			this.ModelTextBox.TabIndex = 2;
			this.ModelTextBox.ToolTip = "";
			this.ModelTextBox.Value = "";
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
            "Rifle"});
			this.FirearmTypeCombo.Location = new System.Drawing.Point(91, 22);
			this.FirearmTypeCombo.Name = "FirearmTypeCombo";
			this.FirearmTypeCombo.Size = new System.Drawing.Size(100, 21);
			this.FirearmTypeCombo.TabIndex = 0;
			this.FirearmTypeCombo.ToolTip = "";
			this.FirearmTypeCombo.Value = ReloadersWorkShop.cFirearm.eFireArmType.Handgun;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.BenchRestCheckBox);
			this.groupBox2.Controls.Add(this.MilitaryCheckBox);
			this.groupBox2.Controls.Add(this.MagnumCheckBox);
			this.groupBox2.Controls.Add(this.StandardCheckBox);
			this.groupBox2.Controls.Add(this.SizeCombo);
			this.groupBox2.Controls.Add(label3);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox2.Location = new System.Drawing.Point(11, 128);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox2.Size = new System.Drawing.Size(515, 78);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Type";
			// 
			// BenchRestCheckBox
			// 
			this.BenchRestCheckBox.AutoCheck = false;
			this.BenchRestCheckBox.AutoSize = true;
			this.BenchRestCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BenchRestCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BenchRestCheckBox.Location = new System.Drawing.Point(284, 46);
			this.BenchRestCheckBox.Name = "BenchRestCheckBox";
			this.BenchRestCheckBox.Size = new System.Drawing.Size(82, 17);
			this.BenchRestCheckBox.TabIndex = 4;
			this.BenchRestCheckBox.Text = "Bench Rest";
			this.BenchRestCheckBox.UseVisualStyleBackColor = true;
			// 
			// MilitaryCheckBox
			// 
			this.MilitaryCheckBox.AutoCheck = false;
			this.MilitaryCheckBox.AutoSize = true;
			this.MilitaryCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MilitaryCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MilitaryCheckBox.Location = new System.Drawing.Point(209, 46);
			this.MilitaryCheckBox.Name = "MilitaryCheckBox";
			this.MilitaryCheckBox.Size = new System.Drawing.Size(58, 17);
			this.MilitaryCheckBox.TabIndex = 3;
			this.MilitaryCheckBox.Text = "Military";
			this.MilitaryCheckBox.UseVisualStyleBackColor = true;
			// 
			// MagnumCheckBox
			// 
			this.MagnumCheckBox.AutoCheck = false;
			this.MagnumCheckBox.AutoSize = true;
			this.MagnumCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MagnumCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MagnumCheckBox.Location = new System.Drawing.Point(284, 23);
			this.MagnumCheckBox.Name = "MagnumCheckBox";
			this.MagnumCheckBox.Size = new System.Drawing.Size(67, 17);
			this.MagnumCheckBox.TabIndex = 2;
			this.MagnumCheckBox.Text = "Magnum";
			this.MagnumCheckBox.UseVisualStyleBackColor = true;
			// 
			// StandardCheckBox
			// 
			this.StandardCheckBox.AutoCheck = false;
			this.StandardCheckBox.AutoSize = true;
			this.StandardCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StandardCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.StandardCheckBox.Location = new System.Drawing.Point(209, 23);
			this.StandardCheckBox.Name = "StandardCheckBox";
			this.StandardCheckBox.Size = new System.Drawing.Size(69, 17);
			this.StandardCheckBox.TabIndex = 1;
			this.StandardCheckBox.Text = "Standard";
			this.StandardCheckBox.UseVisualStyleBackColor = true;
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
			this.InventoryGroupBox.Location = new System.Drawing.Point(11, 210);
			this.InventoryGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.InventoryGroupBox.Name = "InventoryGroupBox";
			this.InventoryGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.InventoryGroupBox.Size = new System.Drawing.Size(515, 99);
			this.InventoryGroupBox.TabIndex = 2;
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
			this.CostEachLabel.TabIndex = 16;
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
			this.CostLabel.TabIndex = 18;
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
			this.QuantityLabel.TabIndex = 17;
			this.QuantityLabel.Text = "Box of:";
			this.QuantityLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// CrossUseCheckBox
			// 
			this.CrossUseCheckBox.AutoSize = true;
			this.CrossUseCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CrossUseCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CrossUseCheckBox.Location = new System.Drawing.Point(197, 24);
			this.CrossUseCheckBox.Name = "CrossUseCheckBox";
			this.CrossUseCheckBox.Size = new System.Drawing.Size(80, 17);
			this.CrossUseCheckBox.TabIndex = 43;
			this.CrossUseCheckBox.Text = "Cross Use?";
			this.CrossUseCheckBox.UseVisualStyleBackColor = true;
			// 
			// cPrimerForm
			// 
			this.AcceptButton = this.PrimerOKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.PrimerCancelButton;
			this.ClientSize = new System.Drawing.Size(536, 361);
			this.ControlBox = false;
			this.Controls.Add(this.InventoryGroupBox);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.PrimerCancelButton);
			this.Controls.Add(this.PrimerOKButton);
			this.Controls.Add(this.GeneralGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cPrimerForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "cPrimerForm";
			this.GeneralGroupBox.ResumeLayout(false);
			this.GeneralGroupBox.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.InventoryGroupBox.ResumeLayout(false);
			this.InventoryGroupBox.PerformLayout();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.Button PrimerCancelButton;
		private System.Windows.Forms.Button PrimerOKButton;
		private System.Windows.Forms.ComboBox SizeCombo;
		private System.Windows.Forms.ComboBox ManufacturerCombo;
		private System.Windows.Forms.GroupBox GeneralGroupBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox InventoryGroupBox;
		private Controls.cFirearmTypeCombo FirearmTypeCombo;
		private System.Windows.Forms.CheckBox BenchRestCheckBox;
		private System.Windows.Forms.CheckBox MilitaryCheckBox;
		private System.Windows.Forms.CheckBox MagnumCheckBox;
		private System.Windows.Forms.CheckBox StandardCheckBox;
		private System.Windows.Forms.Button InventoryButton;
		private CommonLib.Controls.cDoubleValueTextBox CostTextBox;
		private CommonLib.Controls.cIntegerValueTextBox QuantityTextBox;
		private System.Windows.Forms.Label CostEachLabel;
		private System.Windows.Forms.Label CostLabel;
		private System.Windows.Forms.Label QuantityLabel;
		private CommonLib.Controls.cTextBox ModelTextBox;
		private System.Windows.Forms.CheckBox CrossUseCheckBox;
		}
	}