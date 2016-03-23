namespace ReloadersWorkShop
	{
	partial class cTransactionForm
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
			this.TransactionGroupBox = new System.Windows.Forms.GroupBox();
			this.StartDateLabel = new System.Windows.Forms.Label();
			this.SourceCombo = new System.Windows.Forms.ComboBox();
			this.SourceLabel = new System.Windows.Forms.Label();
			this.TransactionTypeCombo = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.DatePicker = new System.Windows.Forms.DateTimePicker();
			this.DateLabel = new System.Windows.Forms.Label();
			this.CostsGroup = new System.Windows.Forms.GroupBox();
			this.QuantityTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.PowderWeightLabel = new System.Windows.Forms.Label();
			this.ShippingTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.ShippingLabel = new System.Windows.Forms.Label();
			this.TotalTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.TaxTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.CostTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.AvgCostLabel = new System.Windows.Forms.Label();
			this.AvgCostEachLabel = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.TaxLabel = new System.Windows.Forms.Label();
			this.CostLabel = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.TransactionOKButton = new System.Windows.Forms.Button();
			this.TransactionCancelButton = new System.Windows.Forms.Button();
			this.ComponentLabel = new System.Windows.Forms.Label();
			this.TransactionGroupBox.SuspendLayout();
			this.CostsGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// TransactionGroupBox
			// 
			this.TransactionGroupBox.Controls.Add(this.StartDateLabel);
			this.TransactionGroupBox.Controls.Add(this.SourceCombo);
			this.TransactionGroupBox.Controls.Add(this.SourceLabel);
			this.TransactionGroupBox.Controls.Add(this.TransactionTypeCombo);
			this.TransactionGroupBox.Controls.Add(this.label2);
			this.TransactionGroupBox.Controls.Add(this.DatePicker);
			this.TransactionGroupBox.Controls.Add(this.DateLabel);
			this.TransactionGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TransactionGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.TransactionGroupBox.Location = new System.Drawing.Point(12, 52);
			this.TransactionGroupBox.Name = "TransactionGroupBox";
			this.TransactionGroupBox.Size = new System.Drawing.Size(511, 115);
			this.TransactionGroupBox.TabIndex = 1;
			this.TransactionGroupBox.TabStop = false;
			this.TransactionGroupBox.Text = "Activity Details";
			// 
			// StartDateLabel
			// 
			this.StartDateLabel.AutoSize = true;
			this.StartDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StartDateLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.StartDateLabel.Location = new System.Drawing.Point(201, 84);
			this.StartDateLabel.Name = "StartDateLabel";
			this.StartDateLabel.Size = new System.Drawing.Size(69, 13);
			this.StartDateLabel.TabIndex = 5;
			this.StartDateLabel.Text = "Starting Date";
			this.StartDateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// SourceCombo
			// 
			this.SourceCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.SourceCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.SourceCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SourceCombo.FormattingEnabled = true;
			this.SourceCombo.Location = new System.Drawing.Point(103, 54);
			this.SourceCombo.MaxDropDownItems = 15;
			this.SourceCombo.Name = "SourceCombo";
			this.SourceCombo.Size = new System.Drawing.Size(252, 21);
			this.SourceCombo.TabIndex = 1;
			// 
			// SourceLabel
			// 
			this.SourceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SourceLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SourceLabel.Location = new System.Drawing.Point(11, 57);
			this.SourceLabel.Name = "SourceLabel";
			this.SourceLabel.Size = new System.Drawing.Size(87, 13);
			this.SourceLabel.TabIndex = 4;
			this.SourceLabel.Text = "Purchased From:";
			this.SourceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// TransactionTypeCombo
			// 
			this.TransactionTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TransactionTypeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TransactionTypeCombo.FormattingEnabled = true;
			this.TransactionTypeCombo.Items.AddRange(new object[] {
            "Purchase",
            "Adjustment",
            "Batch",
            "Damage",
            "Set Stock Level",
            "Spillage"});
			this.TransactionTypeCombo.Location = new System.Drawing.Point(104, 27);
			this.TransactionTypeCombo.Name = "TransactionTypeCombo";
			this.TransactionTypeCombo.Size = new System.Drawing.Size(169, 21);
			this.TransactionTypeCombo.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(27, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Activity Type:";
			// 
			// DatePicker
			// 
			this.DatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.DatePicker.Location = new System.Drawing.Point(103, 81);
			this.DatePicker.Name = "DatePicker";
			this.DatePicker.Size = new System.Drawing.Size(92, 20);
			this.DatePicker.TabIndex = 2;
			// 
			// DateLabel
			// 
			this.DateLabel.AutoSize = true;
			this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DateLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.DateLabel.Location = new System.Drawing.Point(65, 84);
			this.DateLabel.Name = "DateLabel";
			this.DateLabel.Size = new System.Drawing.Size(33, 13);
			this.DateLabel.TabIndex = 0;
			this.DateLabel.Text = "Date:";
			// 
			// CostsGroup
			// 
			this.CostsGroup.Controls.Add(this.QuantityTextBox);
			this.CostsGroup.Controls.Add(this.PowderWeightLabel);
			this.CostsGroup.Controls.Add(this.ShippingTextBox);
			this.CostsGroup.Controls.Add(this.ShippingLabel);
			this.CostsGroup.Controls.Add(this.TotalTextBox);
			this.CostsGroup.Controls.Add(this.TaxTextBox);
			this.CostsGroup.Controls.Add(this.CostTextBox);
			this.CostsGroup.Controls.Add(this.AvgCostLabel);
			this.CostsGroup.Controls.Add(this.AvgCostEachLabel);
			this.CostsGroup.Controls.Add(this.label10);
			this.CostsGroup.Controls.Add(this.TaxLabel);
			this.CostsGroup.Controls.Add(this.CostLabel);
			this.CostsGroup.Controls.Add(this.label7);
			this.CostsGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CostsGroup.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.CostsGroup.Location = new System.Drawing.Point(12, 173);
			this.CostsGroup.Name = "CostsGroup";
			this.CostsGroup.Size = new System.Drawing.Size(511, 140);
			this.CostsGroup.TabIndex = 2;
			this.CostsGroup.TabStop = false;
			this.CostsGroup.Text = "Costs";
			// 
			// QuantityTextBox
			// 
			this.QuantityTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.QuantityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.QuantityTextBox.Location = new System.Drawing.Point(69, 27);
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
			this.QuantityTextBox.ZeroAllowed = false;
			// 
			// PowderWeightLabel
			// 
			this.PowderWeightLabel.AutoSize = true;
			this.PowderWeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PowderWeightLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PowderWeightLabel.Location = new System.Drawing.Point(133, 30);
			this.PowderWeightLabel.Name = "PowderWeightLabel";
			this.PowderWeightLabel.Size = new System.Drawing.Size(41, 13);
			this.PowderWeightLabel.TabIndex = 15;
			this.PowderWeightLabel.Text = "Weight";
			// 
			// ShippingTextBox
			// 
			this.ShippingTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.ShippingTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShippingTextBox.Location = new System.Drawing.Point(271, 77);
			this.ShippingTextBox.MaxLength = 7;
			this.ShippingTextBox.MaxValue = 0D;
			this.ShippingTextBox.MinValue = 0D;
			this.ShippingTextBox.Name = "ShippingTextBox";
			this.ShippingTextBox.NumDecimals = 2;
			this.ShippingTextBox.Size = new System.Drawing.Size(56, 20);
			this.ShippingTextBox.TabIndex = 3;
			this.ShippingTextBox.Text = "0.00";
			this.ShippingTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ShippingTextBox.ToolTip = "";
			this.ShippingTextBox.Value = 0D;
			this.ShippingTextBox.ZeroAllowed = true;
			// 
			// ShippingLabel
			// 
			this.ShippingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShippingLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ShippingLabel.Location = new System.Drawing.Point(180, 80);
			this.ShippingLabel.Name = "ShippingLabel";
			this.ShippingLabel.Size = new System.Drawing.Size(87, 13);
			this.ShippingLabel.TabIndex = 14;
			this.ShippingLabel.Text = "Est. Shipping:";
			this.ShippingLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// TotalTextBox
			// 
			this.TotalTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.TotalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TotalTextBox.Location = new System.Drawing.Point(271, 102);
			this.TotalTextBox.MaxLength = 7;
			this.TotalTextBox.MaxValue = 0D;
			this.TotalTextBox.MinValue = 0D;
			this.TotalTextBox.Name = "TotalTextBox";
			this.TotalTextBox.NumDecimals = 2;
			this.TotalTextBox.ReadOnly = true;
			this.TotalTextBox.Size = new System.Drawing.Size(56, 20);
			this.TotalTextBox.TabIndex = 4;
			this.TotalTextBox.TabStop = false;
			this.TotalTextBox.Text = "0.00";
			this.TotalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.TotalTextBox.ToolTip = "";
			this.TotalTextBox.Value = 0D;
			this.TotalTextBox.ZeroAllowed = true;
			// 
			// TaxTextBox
			// 
			this.TaxTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.TaxTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TaxTextBox.Location = new System.Drawing.Point(271, 52);
			this.TaxTextBox.MaxLength = 7;
			this.TaxTextBox.MaxValue = 0D;
			this.TaxTextBox.MinValue = 0D;
			this.TaxTextBox.Name = "TaxTextBox";
			this.TaxTextBox.NumDecimals = 2;
			this.TaxTextBox.Size = new System.Drawing.Size(56, 20);
			this.TaxTextBox.TabIndex = 2;
			this.TaxTextBox.Text = "0.00";
			this.TaxTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.TaxTextBox.ToolTip = "";
			this.TaxTextBox.Value = 0D;
			this.TaxTextBox.ZeroAllowed = true;
			// 
			// CostTextBox
			// 
			this.CostTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.CostTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CostTextBox.Location = new System.Drawing.Point(271, 27);
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
			// AvgCostLabel
			// 
			this.AvgCostLabel.AutoSize = true;
			this.AvgCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AvgCostLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AvgCostLabel.Location = new System.Drawing.Point(442, 30);
			this.AvgCostLabel.Name = "AvgCostLabel";
			this.AvgCostLabel.Size = new System.Drawing.Size(32, 13);
			this.AvgCostLabel.TabIndex = 12;
			this.AvgCostLabel.Text = "0.00";
			// 
			// AvgCostEachLabel
			// 
			this.AvgCostEachLabel.AutoSize = true;
			this.AvgCostEachLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AvgCostEachLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AvgCostEachLabel.Location = new System.Drawing.Point(352, 30);
			this.AvgCostEachLabel.Name = "AvgCostEachLabel";
			this.AvgCostEachLabel.Size = new System.Drawing.Size(84, 13);
			this.AvgCostEachLabel.TabIndex = 11;
			this.AvgCostEachLabel.Text = "Avg. Cost Each:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label10.Location = new System.Drawing.Point(231, 105);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(34, 13);
			this.label10.TabIndex = 10;
			this.label10.Text = "Total:";
			// 
			// TaxLabel
			// 
			this.TaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TaxLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TaxLabel.Location = new System.Drawing.Point(213, 55);
			this.TaxLabel.Name = "TaxLabel";
			this.TaxLabel.Size = new System.Drawing.Size(52, 13);
			this.TaxLabel.TabIndex = 8;
			this.TaxLabel.Text = "Est. Tax:";
			this.TaxLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// CostLabel
			// 
			this.CostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CostLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CostLabel.Location = new System.Drawing.Point(210, 30);
			this.CostLabel.Name = "CostLabel";
			this.CostLabel.Size = new System.Drawing.Size(55, 13);
			this.CostLabel.TabIndex = 6;
			this.CostLabel.Text = "Est. Cost:";
			this.CostLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label7.Location = new System.Drawing.Point(16, 30);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(49, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "Quantity:";
			// 
			// TransactionOKButton
			// 
			this.TransactionOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.TransactionOKButton.Location = new System.Drawing.Point(176, 327);
			this.TransactionOKButton.Name = "TransactionOKButton";
			this.TransactionOKButton.Size = new System.Drawing.Size(75, 23);
			this.TransactionOKButton.TabIndex = 3;
			this.TransactionOKButton.Text = "OK";
			this.TransactionOKButton.UseVisualStyleBackColor = true;
			// 
			// TransactionCancelButton
			// 
			this.TransactionCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.TransactionCancelButton.Location = new System.Drawing.Point(271, 327);
			this.TransactionCancelButton.Name = "TransactionCancelButton";
			this.TransactionCancelButton.Size = new System.Drawing.Size(75, 23);
			this.TransactionCancelButton.TabIndex = 4;
			this.TransactionCancelButton.Text = "Cancel";
			this.TransactionCancelButton.UseVisualStyleBackColor = true;
			// 
			// ComponentLabel
			// 
			this.ComponentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ComponentLabel.Location = new System.Drawing.Point(12, 26);
			this.ComponentLabel.Name = "ComponentLabel";
			this.ComponentLabel.Size = new System.Drawing.Size(511, 23);
			this.ComponentLabel.TabIndex = 5;
			this.ComponentLabel.Text = "Component Description";
			this.ComponentLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// cTransactionForm
			// 
			this.AcceptButton = this.TransactionOKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.TransactionCancelButton;
			this.ClientSize = new System.Drawing.Size(523, 376);
			this.ControlBox = false;
			this.Controls.Add(this.ComponentLabel);
			this.Controls.Add(this.TransactionCancelButton);
			this.Controls.Add(this.TransactionOKButton);
			this.Controls.Add(this.CostsGroup);
			this.Controls.Add(this.TransactionGroupBox);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cTransactionForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Activity";
			this.TransactionGroupBox.ResumeLayout(false);
			this.TransactionGroupBox.PerformLayout();
			this.CostsGroup.ResumeLayout(false);
			this.CostsGroup.PerformLayout();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.GroupBox TransactionGroupBox;
		private System.Windows.Forms.ComboBox TransactionTypeCombo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker DatePicker;
		private System.Windows.Forms.Label DateLabel;
		private System.Windows.Forms.Label SourceLabel;
		private System.Windows.Forms.GroupBox CostsGroup;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label TaxLabel;
		private System.Windows.Forms.Label CostLabel;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button TransactionOKButton;
		private System.Windows.Forms.Button TransactionCancelButton;
		private System.Windows.Forms.Label AvgCostLabel;
		private System.Windows.Forms.Label AvgCostEachLabel;
		private CommonLib.Controls.cDoubleValueTextBox TotalTextBox;
		private CommonLib.Controls.cDoubleValueTextBox TaxTextBox;
		private CommonLib.Controls.cDoubleValueTextBox CostTextBox;
		private CommonLib.Controls.cDoubleValueTextBox ShippingTextBox;
		private System.Windows.Forms.Label ShippingLabel;
		private System.Windows.Forms.ComboBox SourceCombo;
		private System.Windows.Forms.Label PowderWeightLabel;
		private CommonLib.Controls.cDoubleValueTextBox QuantityTextBox;
		private System.Windows.Forms.Label ComponentLabel;
		private System.Windows.Forms.Label StartDateLabel;
		}
	}