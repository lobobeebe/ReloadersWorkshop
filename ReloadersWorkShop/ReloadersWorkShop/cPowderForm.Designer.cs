namespace ReloadersWorkShop
	{
	partial class cPowderForm
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
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			this.CostLbLabel = new System.Windows.Forms.Label();
			this.ManufacturerCombo = new System.Windows.Forms.ComboBox();
			this.PowderCancelButton = new System.Windows.Forms.Button();
			this.PowderOKButton = new System.Windows.Forms.Button();
			this.GeneralGroupBox = new System.Windows.Forms.GroupBox();
			this.ModelTextBox = new CommonLib.Controls.cTextBox();
			this.FirearmTypeCombo = new ReloadersWorkShop.Controls.cFirearmTypeCombo();
			this.ShapeCombo = new System.Windows.Forms.ComboBox();
			this.InventoryGroupBox = new System.Windows.Forms.GroupBox();
			this.CanWeightLabel = new System.Windows.Forms.Label();
			this.QuantityTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.InventoryButton = new System.Windows.Forms.Button();
			this.CostTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.CostEachLabel = new System.Windows.Forms.Label();
			this.CostLabel = new System.Windows.Forms.Label();
			this.QuantityLabel = new System.Windows.Forms.Label();
			this.CrossUseCheckBox = new System.Windows.Forms.CheckBox();
			label8 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			this.GeneralGroupBox.SuspendLayout();
			this.InventoryGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// label8
			// 
			label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label8.ForeColor = System.Drawing.SystemColors.ControlText;
			label8.Location = new System.Drawing.Point(6, 30);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(90, 13);
			label8.TabIndex = 32;
			label8.Text = "Firearm Type:";
			label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label1
			// 
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label1.ForeColor = System.Drawing.SystemColors.ControlText;
			label1.Location = new System.Drawing.Point(9, 60);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(89, 13);
			label1.TabIndex = 31;
			label1.Text = "Manufacturer:";
			label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label2
			// 
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label2.ForeColor = System.Drawing.SystemColors.ControlText;
			label2.Location = new System.Drawing.Point(12, 112);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(84, 17);
			label2.TabIndex = 35;
			label2.Text = "Shape:";
			label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label3
			// 
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label3.ForeColor = System.Drawing.SystemColors.ControlText;
			label3.Location = new System.Drawing.Point(15, 87);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(81, 17);
			label3.TabIndex = 37;
			label3.Text = "Model/ID:";
			label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// CostLbLabel
			// 
			this.CostLbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CostLbLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CostLbLabel.Location = new System.Drawing.Point(359, 32);
			this.CostLbLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.CostLbLabel.Name = "CostLbLabel";
			this.CostLbLabel.Size = new System.Drawing.Size(67, 17);
			this.CostLbLabel.TabIndex = 18;
			this.CostLbLabel.Text = "Cost/Kilo:";
			this.CostLbLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ManufacturerCombo
			// 
			this.ManufacturerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ManufacturerCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ManufacturerCombo.FormattingEnabled = true;
			this.ManufacturerCombo.Location = new System.Drawing.Point(102, 57);
			this.ManufacturerCombo.Name = "ManufacturerCombo";
			this.ManufacturerCombo.Size = new System.Drawing.Size(150, 21);
			this.ManufacturerCombo.Sorted = true;
			this.ManufacturerCombo.TabIndex = 1;
			// 
			// PowderCancelButton
			// 
			this.PowderCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.PowderCancelButton.Location = new System.Drawing.Point(279, 277);
			this.PowderCancelButton.Name = "PowderCancelButton";
			this.PowderCancelButton.Size = new System.Drawing.Size(75, 24);
			this.PowderCancelButton.TabIndex = 3;
			this.PowderCancelButton.Text = "Cancel";
			this.PowderCancelButton.UseVisualStyleBackColor = true;
			// 
			// PowderOKButton
			// 
			this.PowderOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.PowderOKButton.Location = new System.Drawing.Point(182, 277);
			this.PowderOKButton.Name = "PowderOKButton";
			this.PowderOKButton.Size = new System.Drawing.Size(75, 24);
			this.PowderOKButton.TabIndex = 2;
			this.PowderOKButton.Text = "OK";
			this.PowderOKButton.UseVisualStyleBackColor = true;
			// 
			// GeneralGroupBox
			// 
			this.GeneralGroupBox.Controls.Add(this.CrossUseCheckBox);
			this.GeneralGroupBox.Controls.Add(this.ModelTextBox);
			this.GeneralGroupBox.Controls.Add(this.FirearmTypeCombo);
			this.GeneralGroupBox.Controls.Add(this.ShapeCombo);
			this.GeneralGroupBox.Controls.Add(label3);
			this.GeneralGroupBox.Controls.Add(label8);
			this.GeneralGroupBox.Controls.Add(label1);
			this.GeneralGroupBox.Controls.Add(this.ManufacturerCombo);
			this.GeneralGroupBox.Controls.Add(label2);
			this.GeneralGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GeneralGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.GeneralGroupBox.Location = new System.Drawing.Point(10, 12);
			this.GeneralGroupBox.Name = "GeneralGroupBox";
			this.GeneralGroupBox.Size = new System.Drawing.Size(515, 149);
			this.GeneralGroupBox.TabIndex = 0;
			this.GeneralGroupBox.TabStop = false;
			this.GeneralGroupBox.Text = "General";
			// 
			// ModelTextBox
			// 
			this.ModelTextBox.BackColor = System.Drawing.Color.LightPink;
			this.ModelTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ModelTextBox.Location = new System.Drawing.Point(102, 84);
			this.ModelTextBox.Name = "ModelTextBox";
			this.ModelTextBox.Required = true;
			this.ModelTextBox.Size = new System.Drawing.Size(150, 20);
			this.ModelTextBox.TabIndex = 38;
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
			this.FirearmTypeCombo.Location = new System.Drawing.Point(102, 27);
			this.FirearmTypeCombo.Name = "FirearmTypeCombo";
			this.FirearmTypeCombo.Size = new System.Drawing.Size(100, 21);
			this.FirearmTypeCombo.TabIndex = 0;
			this.FirearmTypeCombo.ToolTip = "";
			this.FirearmTypeCombo.Value = ReloadersWorkShop.cFirearm.eFireArmType.Handgun;
			// 
			// ShapeCombo
			// 
			this.ShapeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ShapeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShapeCombo.FormattingEnabled = true;
			this.ShapeCombo.Items.AddRange(new object[] {
            "Spherical",
            "Extruded",
            "Flake",
            "Other"});
			this.ShapeCombo.Location = new System.Drawing.Point(102, 109);
			this.ShapeCombo.Name = "ShapeCombo";
			this.ShapeCombo.Size = new System.Drawing.Size(120, 21);
			this.ShapeCombo.TabIndex = 3;
			// 
			// InventoryGroupBox
			// 
			this.InventoryGroupBox.Controls.Add(this.CanWeightLabel);
			this.InventoryGroupBox.Controls.Add(this.QuantityTextBox);
			this.InventoryGroupBox.Controls.Add(this.InventoryButton);
			this.InventoryGroupBox.Controls.Add(this.CostTextBox);
			this.InventoryGroupBox.Controls.Add(this.CostEachLabel);
			this.InventoryGroupBox.Controls.Add(this.CostLbLabel);
			this.InventoryGroupBox.Controls.Add(this.CostLabel);
			this.InventoryGroupBox.Controls.Add(this.QuantityLabel);
			this.InventoryGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.InventoryGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.InventoryGroupBox.Location = new System.Drawing.Point(10, 167);
			this.InventoryGroupBox.Name = "InventoryGroupBox";
			this.InventoryGroupBox.Size = new System.Drawing.Size(515, 99);
			this.InventoryGroupBox.TabIndex = 1;
			this.InventoryGroupBox.TabStop = false;
			this.InventoryGroupBox.Text = "Costs && Pricing";
			// 
			// CanWeightLabel
			// 
			this.CanWeightLabel.AutoSize = true;
			this.CanWeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CanWeightLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CanWeightLabel.Location = new System.Drawing.Point(191, 32);
			this.CanWeightLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.CanWeightLabel.Name = "CanWeightLabel";
			this.CanWeightLabel.Size = new System.Drawing.Size(29, 13);
			this.CanWeightLabel.TabIndex = 21;
			this.CanWeightLabel.Text = "Kilos";
			this.CanWeightLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// QuantityTextBox
			// 
			this.QuantityTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.QuantityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.QuantityTextBox.Location = new System.Drawing.Point(130, 29);
			this.QuantityTextBox.MaxLength = 7;
			this.QuantityTextBox.MaxValue = 0D;
			this.QuantityTextBox.MinValue = 0D;
			this.QuantityTextBox.Name = "QuantityTextBox";
			this.QuantityTextBox.NumDecimals = 2;
			this.QuantityTextBox.Size = new System.Drawing.Size(56, 20);
			this.QuantityTextBox.TabIndex = 0;
			this.QuantityTextBox.Text = "0.00";
			this.QuantityTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.QuantityTextBox.ToolTip = "";
			this.QuantityTextBox.Value = 0D;
			this.QuantityTextBox.ZeroAllowed = true;
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
			this.CostTextBox.Location = new System.Drawing.Point(307, 29);
			this.CostTextBox.MaxLength = 7;
			this.CostTextBox.MaxValue = 0D;
			this.CostTextBox.MinValue = 0D;
			this.CostTextBox.Name = "CostTextBox";
			this.CostTextBox.NumDecimals = 2;
			this.CostTextBox.Size = new System.Drawing.Size(48, 20);
			this.CostTextBox.TabIndex = 1;
			this.CostTextBox.Text = "0.00";
			this.CostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.CostTextBox.ToolTip = "";
			this.CostTextBox.Value = 0D;
			this.CostTextBox.ZeroAllowed = true;
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
			this.CostEachLabel.TabIndex = 15;
			this.CostEachLabel.Text = "$0.00";
			this.CostEachLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// CostLabel
			// 
			this.CostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CostLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CostLabel.Location = new System.Drawing.Point(253, 32);
			this.CostLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.CostLabel.Name = "CostLabel";
			this.CostLabel.Size = new System.Drawing.Size(49, 17);
			this.CostLabel.TabIndex = 17;
			this.CostLabel.Text = "Cost:";
			this.CostLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// QuantityLabel
			// 
			this.QuantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.QuantityLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.QuantityLabel.Location = new System.Drawing.Point(18, 32);
			this.QuantityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.QuantityLabel.Name = "QuantityLabel";
			this.QuantityLabel.Size = new System.Drawing.Size(107, 17);
			this.QuantityLabel.TabIndex = 16;
			this.QuantityLabel.Text = "Can of:";
			this.QuantityLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// CrossUseCheckBox
			// 
			this.CrossUseCheckBox.AutoSize = true;
			this.CrossUseCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CrossUseCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CrossUseCheckBox.Location = new System.Drawing.Point(208, 31);
			this.CrossUseCheckBox.Name = "CrossUseCheckBox";
			this.CrossUseCheckBox.Size = new System.Drawing.Size(80, 17);
			this.CrossUseCheckBox.TabIndex = 39;
			this.CrossUseCheckBox.Text = "Cross Use?";
			this.CrossUseCheckBox.UseVisualStyleBackColor = true;
			// 
			// cPowderForm
			// 
			this.AcceptButton = this.PowderOKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.PowderCancelButton;
			this.ClientSize = new System.Drawing.Size(522, 311);
			this.ControlBox = false;
			this.Controls.Add(this.InventoryGroupBox);
			this.Controls.Add(this.PowderCancelButton);
			this.Controls.Add(this.PowderOKButton);
			this.Controls.Add(this.GeneralGroupBox);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cPowderForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Powder";
			this.GeneralGroupBox.ResumeLayout(false);
			this.GeneralGroupBox.PerformLayout();
			this.InventoryGroupBox.ResumeLayout(false);
			this.InventoryGroupBox.PerformLayout();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.ComboBox ManufacturerCombo;
		private System.Windows.Forms.Button PowderCancelButton;
		private System.Windows.Forms.Button PowderOKButton;
		private System.Windows.Forms.GroupBox GeneralGroupBox;
		private System.Windows.Forms.GroupBox InventoryGroupBox;
		private System.Windows.Forms.ComboBox ShapeCombo;
		private Controls.cFirearmTypeCombo FirearmTypeCombo;
		private CommonLib.Controls.cDoubleValueTextBox CostTextBox;
		private System.Windows.Forms.Label CostEachLabel;
		private System.Windows.Forms.Label CostLabel;
		private System.Windows.Forms.Label QuantityLabel;
		private System.Windows.Forms.Button InventoryButton;
		private CommonLib.Controls.cDoubleValueTextBox QuantityTextBox;
		private System.Windows.Forms.Label CanWeightLabel;
		private System.Windows.Forms.Label CostLbLabel;
		private CommonLib.Controls.cTextBox ModelTextBox;
		private System.Windows.Forms.CheckBox CrossUseCheckBox;
		}
	}