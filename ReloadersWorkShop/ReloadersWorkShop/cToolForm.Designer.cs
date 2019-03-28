﻿namespace ReloadersWorkShop
	{
	partial class cToolForm
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
			this.GeneralGroupBox = new System.Windows.Forms.GroupBox();
			this.DescriptionTextBox = new CommonLib.Controls.cTextBox();
			this.SerialNumberTextBox = new CommonLib.Controls.cTextBox();
			this.PartNumberTextBox = new CommonLib.Controls.cTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.ManufacturerCombo = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TypeCombo = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.AcquisitionGroupBox = new System.Windows.Forms.GroupBox();
			this.TotalLabel = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.ShippingTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.ShippingLabel = new System.Windows.Forms.Label();
			this.TaxTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.TaxLabel = new System.Windows.Forms.Label();
			this.SourceCombo = new System.Windows.Forms.ComboBox();
			this.PriceTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.PurchaseDatePicker = new System.Windows.Forms.DateTimePicker();
			this.PriceLabel = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.FormCancelButton = new CommonLib.Controls.cCancelButton();
			this.OKButton = new CommonLib.Controls.cOKButton();
			this.NotesTextBox = new CommonLib.Controls.cTextBox();
			this.NotesGroup = new System.Windows.Forms.GroupBox();
			this.GeneralGroupBox.SuspendLayout();
			this.AcquisitionGroupBox.SuspendLayout();
			this.NotesGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// GeneralGroupBox
			// 
			this.GeneralGroupBox.Controls.Add(this.DescriptionTextBox);
			this.GeneralGroupBox.Controls.Add(this.SerialNumberTextBox);
			this.GeneralGroupBox.Controls.Add(this.PartNumberTextBox);
			this.GeneralGroupBox.Controls.Add(this.label5);
			this.GeneralGroupBox.Controls.Add(this.label4);
			this.GeneralGroupBox.Controls.Add(this.label3);
			this.GeneralGroupBox.Controls.Add(this.ManufacturerCombo);
			this.GeneralGroupBox.Controls.Add(this.label2);
			this.GeneralGroupBox.Controls.Add(this.TypeCombo);
			this.GeneralGroupBox.Controls.Add(this.label1);
			this.GeneralGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GeneralGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.GeneralGroupBox.Location = new System.Drawing.Point(12, 12);
			this.GeneralGroupBox.Name = "GeneralGroupBox";
			this.GeneralGroupBox.Size = new System.Drawing.Size(339, 170);
			this.GeneralGroupBox.TabIndex = 1;
			this.GeneralGroupBox.TabStop = false;
			this.GeneralGroupBox.Text = "General";
			// 
			// DescriptionTextBox
			// 
			this.DescriptionTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.DescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DescriptionTextBox.Location = new System.Drawing.Point(107, 131);
			this.DescriptionTextBox.MaxLength = 35;
			this.DescriptionTextBox.Name = "DescriptionTextBox";
			this.DescriptionTextBox.Required = false;
			this.DescriptionTextBox.Size = new System.Drawing.Size(222, 20);
			this.DescriptionTextBox.TabIndex = 4;
			this.DescriptionTextBox.ToolTip = "";
			this.DescriptionTextBox.ValidChars = "";
			this.DescriptionTextBox.Value = "";
			// 
			// SerialNumberTextBox
			// 
			this.SerialNumberTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.SerialNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SerialNumberTextBox.Location = new System.Drawing.Point(107, 105);
			this.SerialNumberTextBox.MaxLength = 35;
			this.SerialNumberTextBox.Name = "SerialNumberTextBox";
			this.SerialNumberTextBox.Required = false;
			this.SerialNumberTextBox.Size = new System.Drawing.Size(174, 20);
			this.SerialNumberTextBox.TabIndex = 3;
			this.SerialNumberTextBox.ToolTip = "";
			this.SerialNumberTextBox.ValidChars = "";
			this.SerialNumberTextBox.Value = "";
			// 
			// PartNumberTextBox
			// 
			this.PartNumberTextBox.BackColor = System.Drawing.Color.LightPink;
			this.PartNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PartNumberTextBox.Location = new System.Drawing.Point(107, 79);
			this.PartNumberTextBox.MaxLength = 35;
			this.PartNumberTextBox.Name = "PartNumberTextBox";
			this.PartNumberTextBox.Required = true;
			this.PartNumberTextBox.Size = new System.Drawing.Size(174, 20);
			this.PartNumberTextBox.TabIndex = 2;
			this.PartNumberTextBox.ToolTip = "";
			this.PartNumberTextBox.ValidChars = "";
			this.PartNumberTextBox.Value = "";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(38, 134);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Description:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(55, 108);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Serial #:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(28, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Part #/Model:";
			// 
			// ManufacturerCombo
			// 
			this.ManufacturerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ManufacturerCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ManufacturerCombo.FormattingEnabled = true;
			this.ManufacturerCombo.Location = new System.Drawing.Point(107, 51);
			this.ManufacturerCombo.Name = "ManufacturerCombo";
			this.ManufacturerCombo.Size = new System.Drawing.Size(174, 21);
			this.ManufacturerCombo.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(28, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Manufacturer:";
			// 
			// TypeCombo
			// 
			this.TypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TypeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TypeCombo.FormattingEnabled = true;
			this.TypeCombo.Items.AddRange(new object[] {
            "Bipod / Monopod",
            "Firearm Parts",
            "Furniture",
            "Laser",
            "Light",
            "Magnifier",
            "Other",
            "Red Dot",
            "Scope",
            "Trigger"});
			this.TypeCombo.Location = new System.Drawing.Point(107, 24);
			this.TypeCombo.Name = "TypeCombo";
			this.TypeCombo.Size = new System.Drawing.Size(174, 21);
			this.TypeCombo.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(15, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Accessory Type:";
			// 
			// AcquisitionGroupBox
			// 
			this.AcquisitionGroupBox.Controls.Add(this.TotalLabel);
			this.AcquisitionGroupBox.Controls.Add(this.label21);
			this.AcquisitionGroupBox.Controls.Add(this.ShippingTextBox);
			this.AcquisitionGroupBox.Controls.Add(this.ShippingLabel);
			this.AcquisitionGroupBox.Controls.Add(this.TaxTextBox);
			this.AcquisitionGroupBox.Controls.Add(this.TaxLabel);
			this.AcquisitionGroupBox.Controls.Add(this.SourceCombo);
			this.AcquisitionGroupBox.Controls.Add(this.PriceTextBox);
			this.AcquisitionGroupBox.Controls.Add(this.PurchaseDatePicker);
			this.AcquisitionGroupBox.Controls.Add(this.PriceLabel);
			this.AcquisitionGroupBox.Controls.Add(this.label9);
			this.AcquisitionGroupBox.Controls.Add(this.label10);
			this.AcquisitionGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AcquisitionGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.AcquisitionGroupBox.Location = new System.Drawing.Point(12, 188);
			this.AcquisitionGroupBox.Name = "AcquisitionGroupBox";
			this.AcquisitionGroupBox.Size = new System.Drawing.Size(339, 160);
			this.AcquisitionGroupBox.TabIndex = 9;
			this.AcquisitionGroupBox.TabStop = false;
			this.AcquisitionGroupBox.Text = "Acquisition Details";
			// 
			// TotalLabel
			// 
			this.TotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TotalLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TotalLabel.Location = new System.Drawing.Point(257, 130);
			this.TotalLabel.Name = "TotalLabel";
			this.TotalLabel.Size = new System.Drawing.Size(72, 20);
			this.TotalLabel.TabIndex = 11;
			this.TotalLabel.Text = "0.00";
			this.TotalLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label21
			// 
			this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label21.Location = new System.Drawing.Point(195, 132);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(56, 13);
			this.label21.TabIndex = 10;
			this.label21.Text = "Total:";
			this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ShippingTextBox
			// 
			this.ShippingTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.ShippingTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShippingTextBox.Location = new System.Drawing.Point(281, 102);
			this.ShippingTextBox.MaxValue = 0D;
			this.ShippingTextBox.MinValue = 0D;
			this.ShippingTextBox.Name = "ShippingTextBox";
			this.ShippingTextBox.NumDecimals = 0;
			this.ShippingTextBox.Size = new System.Drawing.Size(48, 20);
			this.ShippingTextBox.TabIndex = 4;
			this.ShippingTextBox.Text = "0";
			this.ShippingTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ShippingTextBox.ToolTip = "";
			this.ShippingTextBox.Value = 0D;
			this.ShippingTextBox.ZeroAllowed = true;
			// 
			// ShippingLabel
			// 
			this.ShippingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShippingLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ShippingLabel.Location = new System.Drawing.Point(200, 105);
			this.ShippingLabel.Name = "ShippingLabel";
			this.ShippingLabel.Size = new System.Drawing.Size(75, 13);
			this.ShippingLabel.TabIndex = 9;
			this.ShippingLabel.Text = "Shipping ($):";
			this.ShippingLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// TaxTextBox
			// 
			this.TaxTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.TaxTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TaxTextBox.Location = new System.Drawing.Point(281, 76);
			this.TaxTextBox.MaxValue = 0D;
			this.TaxTextBox.MinValue = 0D;
			this.TaxTextBox.Name = "TaxTextBox";
			this.TaxTextBox.NumDecimals = 0;
			this.TaxTextBox.Size = new System.Drawing.Size(48, 20);
			this.TaxTextBox.TabIndex = 3;
			this.TaxTextBox.Text = "0";
			this.TaxTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.TaxTextBox.ToolTip = "";
			this.TaxTextBox.Value = 0D;
			this.TaxTextBox.ZeroAllowed = true;
			// 
			// TaxLabel
			// 
			this.TaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TaxLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TaxLabel.Location = new System.Drawing.Point(219, 79);
			this.TaxLabel.Name = "TaxLabel";
			this.TaxLabel.Size = new System.Drawing.Size(56, 13);
			this.TaxLabel.TabIndex = 7;
			this.TaxLabel.Text = "Tax ($):";
			this.TaxLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// SourceCombo
			// 
			this.SourceCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.SourceCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.SourceCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SourceCombo.FormattingEnabled = true;
			this.SourceCombo.Location = new System.Drawing.Point(107, 24);
			this.SourceCombo.Name = "SourceCombo";
			this.SourceCombo.Size = new System.Drawing.Size(222, 21);
			this.SourceCombo.TabIndex = 0;
			// 
			// PriceTextBox
			// 
			this.PriceTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.PriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PriceTextBox.Location = new System.Drawing.Point(281, 50);
			this.PriceTextBox.MaxValue = 0D;
			this.PriceTextBox.MinValue = 0D;
			this.PriceTextBox.Name = "PriceTextBox";
			this.PriceTextBox.NumDecimals = 0;
			this.PriceTextBox.Size = new System.Drawing.Size(48, 20);
			this.PriceTextBox.TabIndex = 2;
			this.PriceTextBox.Text = "0";
			this.PriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.PriceTextBox.ToolTip = "";
			this.PriceTextBox.Value = 0D;
			this.PriceTextBox.ZeroAllowed = true;
			// 
			// PurchaseDatePicker
			// 
			this.PurchaseDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PurchaseDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.PurchaseDatePicker.Location = new System.Drawing.Point(107, 50);
			this.PurchaseDatePicker.Name = "PurchaseDatePicker";
			this.PurchaseDatePicker.Size = new System.Drawing.Size(106, 20);
			this.PurchaseDatePicker.TabIndex = 1;
			// 
			// PriceLabel
			// 
			this.PriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PriceLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PriceLabel.Location = new System.Drawing.Point(219, 53);
			this.PriceLabel.Name = "PriceLabel";
			this.PriceLabel.Size = new System.Drawing.Size(56, 13);
			this.PriceLabel.TabIndex = 4;
			this.PriceLabel.Text = "Price ($):";
			this.PriceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label9.Location = new System.Drawing.Point(23, 53);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(81, 13);
			this.label9.TabIndex = 2;
			this.label9.Text = "Purchase Date:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label10.Location = new System.Drawing.Point(23, 27);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(78, 13);
			this.label10.TabIndex = 0;
			this.label10.Text = "Acquired From:";
			// 
			// FormCancelButton
			// 
			this.FormCancelButton.ButtonType = CommonLib.Controls.cCancelButton.eButtonTypes.Cancel;
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Location = new System.Drawing.Point(194, 460);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.ShowToolTips = true;
			this.FormCancelButton.Size = new System.Drawing.Size(82, 23);
			this.FormCancelButton.TabIndex = 14;
			this.FormCancelButton.Text = "Cancel";
			this.FormCancelButton.ToolTip = "Click to cancel changes and exit.";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			// 
			// OKButton
			// 
			this.OKButton.ButtonType = CommonLib.Controls.cOKButton.eButtonTypes.OK;
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Location = new System.Drawing.Point(84, 460);
			this.OKButton.Name = "OKButton";
			this.OKButton.ShowToolTips = true;
			this.OKButton.Size = new System.Drawing.Size(82, 23);
			this.OKButton.TabIndex = 13;
			this.OKButton.Text = "OK";
			this.OKButton.ToolTip = "Click to accept changes and exit.";
			this.OKButton.UseVisualStyleBackColor = true;
			// 
			// NotesTextBox
			// 
			this.NotesTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.NotesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NotesTextBox.Location = new System.Drawing.Point(16, 21);
			this.NotesTextBox.MaxLength = 1000;
			this.NotesTextBox.Multiline = true;
			this.NotesTextBox.Name = "NotesTextBox";
			this.NotesTextBox.Required = false;
			this.NotesTextBox.Size = new System.Drawing.Size(307, 57);
			this.NotesTextBox.TabIndex = 0;
			this.NotesTextBox.ToolTip = "";
			this.NotesTextBox.ValidChars = "";
			this.NotesTextBox.Value = "";
			// 
			// NotesGroup
			// 
			this.NotesGroup.Controls.Add(this.NotesTextBox);
			this.NotesGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NotesGroup.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.NotesGroup.Location = new System.Drawing.Point(12, 354);
			this.NotesGroup.Name = "NotesGroup";
			this.NotesGroup.Size = new System.Drawing.Size(339, 91);
			this.NotesGroup.TabIndex = 15;
			this.NotesGroup.TabStop = false;
			this.NotesGroup.Text = "Notes";
			// 
			// cToolForm
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.ClientSize = new System.Drawing.Size(360, 508);
			this.ControlBox = false;
			this.Controls.Add(this.NotesGroup);
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.AcquisitionGroupBox);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.GeneralGroupBox);
			this.Name = "cToolForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Tool";
			this.GeneralGroupBox.ResumeLayout(false);
			this.GeneralGroupBox.PerformLayout();
			this.AcquisitionGroupBox.ResumeLayout(false);
			this.AcquisitionGroupBox.PerformLayout();
			this.NotesGroup.ResumeLayout(false);
			this.NotesGroup.PerformLayout();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.GroupBox GeneralGroupBox;
		private CommonLib.Controls.cTextBox DescriptionTextBox;
		private CommonLib.Controls.cTextBox SerialNumberTextBox;
		private CommonLib.Controls.cTextBox PartNumberTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox ManufacturerCombo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox TypeCombo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox AcquisitionGroupBox;
		private System.Windows.Forms.Label TotalLabel;
		private System.Windows.Forms.Label label21;
		private CommonLib.Controls.cDoubleValueTextBox ShippingTextBox;
		private System.Windows.Forms.Label ShippingLabel;
		private CommonLib.Controls.cDoubleValueTextBox TaxTextBox;
		private System.Windows.Forms.Label TaxLabel;
		private System.Windows.Forms.ComboBox SourceCombo;
		private CommonLib.Controls.cDoubleValueTextBox PriceTextBox;
		private System.Windows.Forms.DateTimePicker PurchaseDatePicker;
		private System.Windows.Forms.Label PriceLabel;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private CommonLib.Controls.cCancelButton FormCancelButton;
		private CommonLib.Controls.cOKButton OKButton;
		private CommonLib.Controls.cTextBox NotesTextBox;
		private System.Windows.Forms.GroupBox NotesGroup;
		}
	}