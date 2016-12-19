namespace ReloadersWorkShop
	{
	partial class cAmmoForm
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
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.Label label16;
			this.BulletWeightFieldLabel = new System.Windows.Forms.Label();
			this.BallisticCoefficientFieldLabel = new System.Windows.Forms.Label();
			this.BulletDiameterFieldLabel = new System.Windows.Forms.Label();
			this.SectionalDensityFieldLabel = new System.Windows.Forms.Label();
			this.BulletWeightMeasurementLabel = new System.Windows.Forms.Label();
			this.BulletDiameterMeasurementLabel = new System.Windows.Forms.Label();
			this.InventoryGroupBox = new System.Windows.Forms.GroupBox();
			this.InventoryButton = new System.Windows.Forms.Button();
			this.CostTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.QuantityTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.CostEachLabel = new System.Windows.Forms.Label();
			this.CostLabel = new System.Windows.Forms.Label();
			this.QuantityLabel = new System.Windows.Forms.Label();
			this.GeneralGroupBox = new System.Windows.Forms.GroupBox();
			this.ReloadCheckBox = new System.Windows.Forms.CheckBox();
			this.DuplicateLabel = new System.Windows.Forms.Label();
			this.TypeTextBox = new CommonLib.Controls.cTextBox();
			this.PartNumberTextBox = new CommonLib.Controls.cTextBox();
			this.CaliberCombo = new System.Windows.Forms.ComboBox();
			this.ManufacturerCombo = new System.Windows.Forms.ComboBox();
			this.TestDataGroupBox = new System.Windows.Forms.GroupBox();
			this.RemoveTestButton = new CommonLib.Controls.cButton();
			this.EditTestButton = new CommonLib.Controls.cButton();
			this.AddTestButton = new CommonLib.Controls.cButton();
			this.BulletDataGroupBox = new System.Windows.Forms.GroupBox();
			this.ShellLengthMeasurementLabel = new System.Windows.Forms.Label();
			this.SectionalDensityLabel = new System.Windows.Forms.Label();
			this.BulletWeightTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.BallisticCoefficientTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.BulletDiameterTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.FormCancelButton = new CommonLib.Controls.cCancelButton();
			this.OKButton = new CommonLib.Controls.cOKButton();
			this.PrintButton = new CommonLib.Controls.cButton();
			this.FirearmTypeCombo = new ReloadersWorkShop.Controls.cFirearmTypeCombo();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			this.InventoryGroupBox.SuspendLayout();
			this.GeneralGroupBox.SuspendLayout();
			this.TestDataGroupBox.SuspendLayout();
			this.BulletDataGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label1.ForeColor = System.Drawing.SystemColors.ControlText;
			label1.Location = new System.Drawing.Point(6, 79);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(73, 13);
			label1.TabIndex = 0;
			label1.Text = "Manufacturer:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label2.ForeColor = System.Drawing.SystemColors.ControlText;
			label2.Location = new System.Drawing.Point(8, 25);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(71, 13);
			label2.TabIndex = 3;
			label2.Text = "Firearm Type:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label3.ForeColor = System.Drawing.SystemColors.ControlText;
			label3.Location = new System.Drawing.Point(10, 106);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(69, 13);
			label3.TabIndex = 4;
			label3.Text = "Part Number:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label4.ForeColor = System.Drawing.SystemColors.ControlText;
			label4.Location = new System.Drawing.Point(37, 52);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(42, 13);
			label4.TabIndex = 6;
			label4.Text = "Caliber:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label5.ForeColor = System.Drawing.SystemColors.ControlText;
			label5.Location = new System.Drawing.Point(45, 132);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(34, 13);
			label5.TabIndex = 8;
			label5.Text = "Type:";
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
			// BulletWeightFieldLabel
			// 
			this.BulletWeightFieldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletWeightFieldLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BulletWeightFieldLabel.Location = new System.Drawing.Point(20, 30);
			this.BulletWeightFieldLabel.Name = "BulletWeightFieldLabel";
			this.BulletWeightFieldLabel.Size = new System.Drawing.Size(74, 13);
			this.BulletWeightFieldLabel.TabIndex = 10;
			this.BulletWeightFieldLabel.Text = "Bullet Weight:";
			this.BulletWeightFieldLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// BallisticCoefficientFieldLabel
			// 
			this.BallisticCoefficientFieldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticCoefficientFieldLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BallisticCoefficientFieldLabel.Location = new System.Drawing.Point(197, 30);
			this.BallisticCoefficientFieldLabel.Name = "BallisticCoefficientFieldLabel";
			this.BallisticCoefficientFieldLabel.Size = new System.Drawing.Size(98, 13);
			this.BallisticCoefficientFieldLabel.TabIndex = 12;
			this.BallisticCoefficientFieldLabel.Text = "Ballistic Coefficient:";
			this.BallisticCoefficientFieldLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// BulletDiameterFieldLabel
			// 
			this.BulletDiameterFieldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletDiameterFieldLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BulletDiameterFieldLabel.Location = new System.Drawing.Point(13, 56);
			this.BulletDiameterFieldLabel.Name = "BulletDiameterFieldLabel";
			this.BulletDiameterFieldLabel.Size = new System.Drawing.Size(81, 13);
			this.BulletDiameterFieldLabel.TabIndex = 16;
			this.BulletDiameterFieldLabel.Text = "Bullet Diameter:";
			this.BulletDiameterFieldLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// SectionalDensityFieldLabel
			// 
			this.SectionalDensityFieldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SectionalDensityFieldLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SectionalDensityFieldLabel.Location = new System.Drawing.Point(203, 56);
			this.SectionalDensityFieldLabel.Name = "SectionalDensityFieldLabel";
			this.SectionalDensityFieldLabel.Size = new System.Drawing.Size(92, 13);
			this.SectionalDensityFieldLabel.TabIndex = 18;
			this.SectionalDensityFieldLabel.Text = "Sectional Density:";
			this.SectionalDensityFieldLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// BulletWeightMeasurementLabel
			// 
			this.BulletWeightMeasurementLabel.AutoSize = true;
			this.BulletWeightMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletWeightMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BulletWeightMeasurementLabel.Location = new System.Drawing.Point(144, 30);
			this.BulletWeightMeasurementLabel.Name = "BulletWeightMeasurementLabel";
			this.BulletWeightMeasurementLabel.Size = new System.Drawing.Size(19, 13);
			this.BulletWeightMeasurementLabel.TabIndex = 14;
			this.BulletWeightMeasurementLabel.Text = "gr.";
			// 
			// BulletDiameterMeasurementLabel
			// 
			this.BulletDiameterMeasurementLabel.AutoSize = true;
			this.BulletDiameterMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletDiameterMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BulletDiameterMeasurementLabel.Location = new System.Drawing.Point(144, 56);
			this.BulletDiameterMeasurementLabel.Name = "BulletDiameterMeasurementLabel";
			this.BulletDiameterMeasurementLabel.Size = new System.Drawing.Size(18, 13);
			this.BulletDiameterMeasurementLabel.TabIndex = 17;
			this.BulletDiameterMeasurementLabel.Text = "in.";
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
			this.InventoryGroupBox.Location = new System.Drawing.Point(11, 444);
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
			// GeneralGroupBox
			// 
			this.GeneralGroupBox.Controls.Add(this.ReloadCheckBox);
			this.GeneralGroupBox.Controls.Add(this.DuplicateLabel);
			this.GeneralGroupBox.Controls.Add(this.TypeTextBox);
			this.GeneralGroupBox.Controls.Add(this.PartNumberTextBox);
			this.GeneralGroupBox.Controls.Add(this.FirearmTypeCombo);
			this.GeneralGroupBox.Controls.Add(label5);
			this.GeneralGroupBox.Controls.Add(this.CaliberCombo);
			this.GeneralGroupBox.Controls.Add(label4);
			this.GeneralGroupBox.Controls.Add(label3);
			this.GeneralGroupBox.Controls.Add(label2);
			this.GeneralGroupBox.Controls.Add(this.ManufacturerCombo);
			this.GeneralGroupBox.Controls.Add(label1);
			this.GeneralGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GeneralGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.GeneralGroupBox.Location = new System.Drawing.Point(12, 12);
			this.GeneralGroupBox.Name = "GeneralGroupBox";
			this.GeneralGroupBox.Size = new System.Drawing.Size(515, 164);
			this.GeneralGroupBox.TabIndex = 0;
			this.GeneralGroupBox.TabStop = false;
			this.GeneralGroupBox.Text = "General";
			// 
			// ReloadCheckBox
			// 
			this.ReloadCheckBox.AutoSize = true;
			this.ReloadCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ReloadCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ReloadCheckBox.Location = new System.Drawing.Point(195, 105);
			this.ReloadCheckBox.Name = "ReloadCheckBox";
			this.ReloadCheckBox.Size = new System.Drawing.Size(71, 17);
			this.ReloadCheckBox.TabIndex = 4;
			this.ReloadCheckBox.Text = "Reloads?";
			this.ReloadCheckBox.UseVisualStyleBackColor = true;
			// 
			// DuplicateLabel
			// 
			this.DuplicateLabel.AutoSize = true;
			this.DuplicateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DuplicateLabel.ForeColor = System.Drawing.Color.Red;
			this.DuplicateLabel.Location = new System.Drawing.Point(250, 79);
			this.DuplicateLabel.Name = "DuplicateLabel";
			this.DuplicateLabel.Size = new System.Drawing.Size(185, 13);
			this.DuplicateLabel.TabIndex = 9;
			this.DuplicateLabel.Text = "Duplicate Manufacturer/Part Number!";
			this.DuplicateLabel.Visible = false;
			// 
			// TypeTextBox
			// 
			this.TypeTextBox.BackColor = System.Drawing.Color.LightPink;
			this.TypeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TypeTextBox.Location = new System.Drawing.Point(85, 129);
			this.TypeTextBox.Name = "TypeTextBox";
			this.TypeTextBox.Required = true;
			this.TypeTextBox.Size = new System.Drawing.Size(350, 20);
			this.TypeTextBox.TabIndex = 5;
			this.TypeTextBox.ToolTip = "";
			this.TypeTextBox.ValidChars = "";
			this.TypeTextBox.Value = "";
			// 
			// PartNumberTextBox
			// 
			this.PartNumberTextBox.BackColor = System.Drawing.Color.LightPink;
			this.PartNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PartNumberTextBox.Location = new System.Drawing.Point(85, 103);
			this.PartNumberTextBox.MaxLength = 50;
			this.PartNumberTextBox.Name = "PartNumberTextBox";
			this.PartNumberTextBox.Required = true;
			this.PartNumberTextBox.Size = new System.Drawing.Size(100, 20);
			this.PartNumberTextBox.TabIndex = 3;
			this.PartNumberTextBox.ToolTip = "";
			this.PartNumberTextBox.ValidChars = "";
			this.PartNumberTextBox.Value = "";
			// 
			// CaliberCombo
			// 
			this.CaliberCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CaliberCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CaliberCombo.FormattingEnabled = true;
			this.CaliberCombo.Location = new System.Drawing.Point(85, 49);
			this.CaliberCombo.Name = "CaliberCombo";
			this.CaliberCombo.Size = new System.Drawing.Size(200, 21);
			this.CaliberCombo.TabIndex = 1;
			// 
			// ManufacturerCombo
			// 
			this.ManufacturerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ManufacturerCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ManufacturerCombo.FormattingEnabled = true;
			this.ManufacturerCombo.Location = new System.Drawing.Point(85, 76);
			this.ManufacturerCombo.Name = "ManufacturerCombo";
			this.ManufacturerCombo.Size = new System.Drawing.Size(150, 21);
			this.ManufacturerCombo.TabIndex = 2;
			// 
			// TestDataGroupBox
			// 
			this.TestDataGroupBox.Controls.Add(this.RemoveTestButton);
			this.TestDataGroupBox.Controls.Add(this.EditTestButton);
			this.TestDataGroupBox.Controls.Add(this.AddTestButton);
			this.TestDataGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TestDataGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.TestDataGroupBox.Location = new System.Drawing.Point(12, 271);
			this.TestDataGroupBox.Name = "TestDataGroupBox";
			this.TestDataGroupBox.Size = new System.Drawing.Size(515, 168);
			this.TestDataGroupBox.TabIndex = 2;
			this.TestDataGroupBox.TabStop = false;
			this.TestDataGroupBox.Text = "Test Data";
			// 
			// RemoveTestButton
			// 
			this.RemoveTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RemoveTestButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RemoveTestButton.Location = new System.Drawing.Point(307, 137);
			this.RemoveTestButton.Name = "RemoveTestButton";
			this.RemoveTestButton.ShowToolTips = true;
			this.RemoveTestButton.Size = new System.Drawing.Size(75, 23);
			this.RemoveTestButton.TabIndex = 2;
			this.RemoveTestButton.Text = "Remove";
			this.RemoveTestButton.ToolTip = "";
			this.RemoveTestButton.UseVisualStyleBackColor = true;
			// 
			// EditTestButton
			// 
			this.EditTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EditTestButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.EditTestButton.Location = new System.Drawing.Point(220, 137);
			this.EditTestButton.Name = "EditTestButton";
			this.EditTestButton.ShowToolTips = true;
			this.EditTestButton.Size = new System.Drawing.Size(75, 23);
			this.EditTestButton.TabIndex = 1;
			this.EditTestButton.Text = "Edit";
			this.EditTestButton.ToolTip = "";
			this.EditTestButton.UseVisualStyleBackColor = true;
			// 
			// AddTestButton
			// 
			this.AddTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AddTestButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AddTestButton.Location = new System.Drawing.Point(133, 137);
			this.AddTestButton.Name = "AddTestButton";
			this.AddTestButton.ShowToolTips = true;
			this.AddTestButton.Size = new System.Drawing.Size(75, 23);
			this.AddTestButton.TabIndex = 0;
			this.AddTestButton.Text = "Add";
			this.AddTestButton.ToolTip = "";
			this.AddTestButton.UseVisualStyleBackColor = true;
			// 
			// BulletDataGroupBox
			// 
			this.BulletDataGroupBox.Controls.Add(this.ShellLengthMeasurementLabel);
			this.BulletDataGroupBox.Controls.Add(this.SectionalDensityLabel);
			this.BulletDataGroupBox.Controls.Add(this.SectionalDensityFieldLabel);
			this.BulletDataGroupBox.Controls.Add(this.BulletWeightTextBox);
			this.BulletDataGroupBox.Controls.Add(this.BulletDiameterMeasurementLabel);
			this.BulletDataGroupBox.Controls.Add(this.BallisticCoefficientTextBox);
			this.BulletDataGroupBox.Controls.Add(this.BallisticCoefficientFieldLabel);
			this.BulletDataGroupBox.Controls.Add(this.BulletDiameterTextBox);
			this.BulletDataGroupBox.Controls.Add(this.BulletWeightFieldLabel);
			this.BulletDataGroupBox.Controls.Add(this.BulletWeightMeasurementLabel);
			this.BulletDataGroupBox.Controls.Add(this.BulletDiameterFieldLabel);
			this.BulletDataGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletDataGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.BulletDataGroupBox.Location = new System.Drawing.Point(12, 182);
			this.BulletDataGroupBox.Name = "BulletDataGroupBox";
			this.BulletDataGroupBox.Size = new System.Drawing.Size(515, 83);
			this.BulletDataGroupBox.TabIndex = 1;
			this.BulletDataGroupBox.TabStop = false;
			this.BulletDataGroupBox.Text = "Bullet Data";
			// 
			// ShellLengthMeasurementLabel
			// 
			this.ShellLengthMeasurementLabel.AutoSize = true;
			this.ShellLengthMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShellLengthMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ShellLengthMeasurementLabel.Location = new System.Drawing.Point(345, 30);
			this.ShellLengthMeasurementLabel.Name = "ShellLengthMeasurementLabel";
			this.ShellLengthMeasurementLabel.Size = new System.Drawing.Size(18, 13);
			this.ShellLengthMeasurementLabel.TabIndex = 20;
			this.ShellLengthMeasurementLabel.Text = "in.";
			this.ShellLengthMeasurementLabel.Visible = false;
			// 
			// SectionalDensityLabel
			// 
			this.SectionalDensityLabel.AutoSize = true;
			this.SectionalDensityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SectionalDensityLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SectionalDensityLabel.Location = new System.Drawing.Point(301, 56);
			this.SectionalDensityLabel.Name = "SectionalDensityLabel";
			this.SectionalDensityLabel.Size = new System.Drawing.Size(39, 13);
			this.SectionalDensityLabel.TabIndex = 19;
			this.SectionalDensityLabel.Text = "0.225";
			// 
			// BulletWeightTextBox
			// 
			this.BulletWeightTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BulletWeightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletWeightTextBox.Location = new System.Drawing.Point(100, 27);
			this.BulletWeightTextBox.MaxLength = 5;
			this.BulletWeightTextBox.MaxValue = 0D;
			this.BulletWeightTextBox.MinValue = 0D;
			this.BulletWeightTextBox.Name = "BulletWeightTextBox";
			this.BulletWeightTextBox.NumDecimals = 1;
			this.BulletWeightTextBox.Size = new System.Drawing.Size(38, 20);
			this.BulletWeightTextBox.TabIndex = 0;
			this.BulletWeightTextBox.Text = "0.0";
			this.BulletWeightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.BulletWeightTextBox.ToolTip = "";
			this.BulletWeightTextBox.Value = 0D;
			this.BulletWeightTextBox.ZeroAllowed = true;
			// 
			// BallisticCoefficientTextBox
			// 
			this.BallisticCoefficientTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticCoefficientTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticCoefficientTextBox.Location = new System.Drawing.Point(301, 27);
			this.BallisticCoefficientTextBox.MaxLength = 5;
			this.BallisticCoefficientTextBox.MaxValue = 0D;
			this.BallisticCoefficientTextBox.MinValue = 0D;
			this.BallisticCoefficientTextBox.Name = "BallisticCoefficientTextBox";
			this.BallisticCoefficientTextBox.NumDecimals = 3;
			this.BallisticCoefficientTextBox.Size = new System.Drawing.Size(38, 20);
			this.BallisticCoefficientTextBox.TabIndex = 2;
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
			this.BulletDiameterTextBox.Location = new System.Drawing.Point(100, 53);
			this.BulletDiameterTextBox.MaxLength = 5;
			this.BulletDiameterTextBox.MaxValue = 0D;
			this.BulletDiameterTextBox.MinValue = 0D;
			this.BulletDiameterTextBox.Name = "BulletDiameterTextBox";
			this.BulletDiameterTextBox.NumDecimals = 3;
			this.BulletDiameterTextBox.Size = new System.Drawing.Size(38, 20);
			this.BulletDiameterTextBox.TabIndex = 1;
			this.BulletDiameterTextBox.Text = "0.000";
			this.BulletDiameterTextBox.ToolTip = "";
			this.BulletDiameterTextBox.Value = 0D;
			this.BulletDiameterTextBox.ZeroAllowed = true;
			// 
			// FormCancelButton
			// 
			this.FormCancelButton.ButtonType = CommonLib.Controls.cCancelButton.eButtonTypes.Cancel;
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Location = new System.Drawing.Point(315, 560);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.ShowToolTips = true;
			this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
			this.FormCancelButton.TabIndex = 6;
			this.FormCancelButton.Text = "Cancel";
			this.FormCancelButton.ToolTip = "Click to cancel changes and exit.";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			// 
			// OKButton
			// 
			this.OKButton.ButtonType = CommonLib.Controls.cOKButton.eButtonTypes.OK;
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Location = new System.Drawing.Point(145, 560);
			this.OKButton.Name = "OKButton";
			this.OKButton.ShowToolTips = true;
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 4;
			this.OKButton.Text = "OK";
			this.OKButton.ToolTip = "Click to accept changes and exit.";
			this.OKButton.UseVisualStyleBackColor = true;
			// 
			// PrintButton
			// 
			this.PrintButton.Location = new System.Drawing.Point(231, 560);
			this.PrintButton.Name = "PrintButton";
			this.PrintButton.ShowToolTips = true;
			this.PrintButton.Size = new System.Drawing.Size(75, 23);
			this.PrintButton.TabIndex = 5;
			this.PrintButton.Text = "Print";
			this.PrintButton.ToolTip = "";
			this.PrintButton.UseVisualStyleBackColor = true;
			// 
			// FirearmTypeCombo
			// 
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
            "Shotgun"});
			this.FirearmTypeCombo.Location = new System.Drawing.Point(85, 22);
			this.FirearmTypeCombo.Name = "FirearmTypeCombo";
			this.FirearmTypeCombo.ShowToolTips = true;
			this.FirearmTypeCombo.Size = new System.Drawing.Size(100, 21);
			this.FirearmTypeCombo.TabIndex = 0;
			this.FirearmTypeCombo.ToolTip = "Select a Firearm Type";
			this.FirearmTypeCombo.Value = ReloadersWorkShop.cFirearm.eFireArmType.Handgun;
			// 
			// cAmmoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.ClientSize = new System.Drawing.Size(535, 611);
			this.ControlBox = false;
			this.Controls.Add(this.PrintButton);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.BulletDataGroupBox);
			this.Controls.Add(this.InventoryGroupBox);
			this.Controls.Add(this.TestDataGroupBox);
			this.Controls.Add(this.GeneralGroupBox);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cAmmoForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Ammo";
			this.InventoryGroupBox.ResumeLayout(false);
			this.InventoryGroupBox.PerformLayout();
			this.GeneralGroupBox.ResumeLayout(false);
			this.GeneralGroupBox.PerformLayout();
			this.TestDataGroupBox.ResumeLayout(false);
			this.BulletDataGroupBox.ResumeLayout(false);
			this.BulletDataGroupBox.PerformLayout();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.ComboBox ManufacturerCombo;
		private System.Windows.Forms.ComboBox CaliberCombo;
		private System.Windows.Forms.GroupBox TestDataGroupBox;
		private Controls.cFirearmTypeCombo FirearmTypeCombo;
		private CommonLib.Controls.cDoubleValueTextBox BallisticCoefficientTextBox;
		private CommonLib.Controls.cDoubleValueTextBox BulletDiameterTextBox;
		private System.Windows.Forms.GroupBox BulletDataGroupBox;
		private CommonLib.Controls.cTextBox TypeTextBox;
		private CommonLib.Controls.cTextBox PartNumberTextBox;
		private System.Windows.Forms.GroupBox GeneralGroupBox;
		private CommonLib.Controls.cDoubleValueTextBox BulletWeightTextBox;
		private System.Windows.Forms.Button InventoryButton;
		private CommonLib.Controls.cDoubleValueTextBox CostTextBox;
		private CommonLib.Controls.cIntegerValueTextBox QuantityTextBox;
		private System.Windows.Forms.Label CostEachLabel;
		private System.Windows.Forms.Label CostLabel;
		private System.Windows.Forms.Label QuantityLabel;
		private System.Windows.Forms.GroupBox InventoryGroupBox;
		private System.Windows.Forms.Label DuplicateLabel;
		private System.Windows.Forms.Label SectionalDensityLabel;
		private System.Windows.Forms.Label BulletWeightMeasurementLabel;
		private System.Windows.Forms.Label BulletDiameterMeasurementLabel;
		private System.Windows.Forms.CheckBox ReloadCheckBox;
		private CommonLib.Controls.cCancelButton FormCancelButton;
		private System.Windows.Forms.Label BulletWeightFieldLabel;
		private System.Windows.Forms.Label BallisticCoefficientFieldLabel;
		private System.Windows.Forms.Label BulletDiameterFieldLabel;
		private System.Windows.Forms.Label SectionalDensityFieldLabel;
		private System.Windows.Forms.Label ShellLengthMeasurementLabel;
		private CommonLib.Controls.cOKButton OKButton;
		private CommonLib.Controls.cButton PrintButton;
		private CommonLib.Controls.cButton RemoveTestButton;
		private CommonLib.Controls.cButton EditTestButton;
		private CommonLib.Controls.cButton AddTestButton;
		}
	}