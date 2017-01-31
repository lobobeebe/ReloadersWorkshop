namespace ReloadersWorkShop
	{
	partial class cExportForm
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
			this.FileTypeCombo = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.FileNameTextBox = new CommonLib.Controls.cTextBox();
			this.ExportFileGroupBox = new System.Windows.Forms.GroupBox();
			this.BrowseButton = new System.Windows.Forms.Button();
			this.FileNameLabel = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.XMLPreferencesLabel = new System.Windows.Forms.Label();
			this.FullDataDumpCheckBox = new System.Windows.Forms.CheckBox();
			this.PartsCheckBox = new System.Windows.Forms.CheckBox();
			this.AmmoCheckBox = new System.Windows.Forms.CheckBox();
			this.BatchesCheckBox = new System.Windows.Forms.CheckBox();
			this.LoadsCheckBox = new System.Windows.Forms.CheckBox();
			this.PowdersCheckBox = new System.Windows.Forms.CheckBox();
			this.PrimersCheckBox = new System.Windows.Forms.CheckBox();
			this.CasesCheckBox = new System.Windows.Forms.CheckBox();
			this.BulletsCheckBox = new System.Windows.Forms.CheckBox();
			this.FirearmsCheckBox = new System.Windows.Forms.CheckBox();
			this.CalibersCheckBox = new System.Windows.Forms.CheckBox();
			this.ManufacturersCheckBox = new System.Windows.Forms.CheckBox();
			this.CancelFormButton = new System.Windows.Forms.Button();
			this.ExportButton = new CommonLib.Controls.cButton();
			this.DatabaseUpdateCheckBox = new System.Windows.Forms.CheckBox();
			this.ExportFileGroupBox.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// FileTypeCombo
			// 
			this.FileTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FileTypeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FileTypeCombo.FormattingEnabled = true;
			this.FileTypeCombo.Items.AddRange(new object[] {
            "Comma Delimited Text File (*.csv)",
            "XML File (*.xml)"});
			this.FileTypeCombo.Location = new System.Drawing.Point(78, 19);
			this.FileTypeCombo.Name = "FileTypeCombo";
			this.FileTypeCombo.Size = new System.Drawing.Size(193, 21);
			this.FileTypeCombo.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(19, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "File Type:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(21, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "File Path:";
			// 
			// FileNameTextBox
			// 
			this.FileNameTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.FileNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FileNameTextBox.Location = new System.Drawing.Point(78, 46);
			this.FileNameTextBox.Name = "FileNameTextBox";
			this.FileNameTextBox.ReadOnly = true;
			this.FileNameTextBox.Required = false;
			this.FileNameTextBox.Size = new System.Drawing.Size(402, 20);
			this.FileNameTextBox.TabIndex = 3;
			this.FileNameTextBox.ToolTip = "";
			this.FileNameTextBox.ValidChars = "";
			this.FileNameTextBox.Value = "";
			// 
			// ExportFileGroupBox
			// 
			this.ExportFileGroupBox.Controls.Add(this.BrowseButton);
			this.ExportFileGroupBox.Controls.Add(this.FileNameLabel);
			this.ExportFileGroupBox.Controls.Add(this.FileTypeCombo);
			this.ExportFileGroupBox.Controls.Add(this.FileNameTextBox);
			this.ExportFileGroupBox.Controls.Add(this.label1);
			this.ExportFileGroupBox.Controls.Add(this.label2);
			this.ExportFileGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ExportFileGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.ExportFileGroupBox.Location = new System.Drawing.Point(12, 12);
			this.ExportFileGroupBox.Name = "ExportFileGroupBox";
			this.ExportFileGroupBox.Size = new System.Drawing.Size(529, 85);
			this.ExportFileGroupBox.TabIndex = 4;
			this.ExportFileGroupBox.TabStop = false;
			this.ExportFileGroupBox.Text = "Export File";
			// 
			// BrowseButton
			// 
			this.BrowseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BrowseButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BrowseButton.Location = new System.Drawing.Point(486, 46);
			this.BrowseButton.Name = "BrowseButton";
			this.BrowseButton.Size = new System.Drawing.Size(37, 23);
			this.BrowseButton.TabIndex = 13;
			this.BrowseButton.Text = "...";
			this.BrowseButton.UseVisualStyleBackColor = true;
			// 
			// FileNameLabel
			// 
			this.FileNameLabel.AutoSize = true;
			this.FileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FileNameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FileNameLabel.Location = new System.Drawing.Point(290, 22);
			this.FileNameLabel.Name = "FileNameLabel";
			this.FileNameLabel.Size = new System.Drawing.Size(82, 15);
			this.FileNameLabel.TabIndex = 4;
			this.FileNameLabel.Text = "filename.txt";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.DatabaseUpdateCheckBox);
			this.groupBox2.Controls.Add(this.XMLPreferencesLabel);
			this.groupBox2.Controls.Add(this.FullDataDumpCheckBox);
			this.groupBox2.Controls.Add(this.PartsCheckBox);
			this.groupBox2.Controls.Add(this.AmmoCheckBox);
			this.groupBox2.Controls.Add(this.BatchesCheckBox);
			this.groupBox2.Controls.Add(this.LoadsCheckBox);
			this.groupBox2.Controls.Add(this.PowdersCheckBox);
			this.groupBox2.Controls.Add(this.PrimersCheckBox);
			this.groupBox2.Controls.Add(this.CasesCheckBox);
			this.groupBox2.Controls.Add(this.BulletsCheckBox);
			this.groupBox2.Controls.Add(this.FirearmsCheckBox);
			this.groupBox2.Controls.Add(this.CalibersCheckBox);
			this.groupBox2.Controls.Add(this.ManufacturersCheckBox);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox2.Location = new System.Drawing.Point(12, 103);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(529, 122);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Filters";
			// 
			// XMLPreferencesLabel
			// 
			this.XMLPreferencesLabel.AutoSize = true;
			this.XMLPreferencesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.XMLPreferencesLabel.ForeColor = System.Drawing.Color.Blue;
			this.XMLPreferencesLabel.Location = new System.Drawing.Point(26, 65);
			this.XMLPreferencesLabel.Name = "XMLPreferencesLabel";
			this.XMLPreferencesLabel.Size = new System.Drawing.Size(162, 13);
			this.XMLPreferencesLabel.TabIndex = 14;
			this.XMLPreferencesLabel.Text = "Includes Preferences (XML Only)";
			// 
			// FullDataDumpCheckBox
			// 
			this.FullDataDumpCheckBox.AutoSize = true;
			this.FullDataDumpCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FullDataDumpCheckBox.ForeColor = System.Drawing.Color.Blue;
			this.FullDataDumpCheckBox.Location = new System.Drawing.Point(10, 42);
			this.FullDataDumpCheckBox.Name = "FullDataDumpCheckBox";
			this.FullDataDumpCheckBox.Size = new System.Drawing.Size(178, 20);
			this.FullDataDumpCheckBox.TabIndex = 13;
			this.FullDataDumpCheckBox.Text = "Complete Data Export";
			this.FullDataDumpCheckBox.UseVisualStyleBackColor = true;
			// 
			// PartsCheckBox
			// 
			this.PartsCheckBox.AutoSize = true;
			this.PartsCheckBox.Checked = true;
			this.PartsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.PartsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PartsCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PartsCheckBox.Location = new System.Drawing.Point(219, 90);
			this.PartsCheckBox.Name = "PartsCheckBox";
			this.PartsCheckBox.Size = new System.Drawing.Size(119, 17);
			this.PartsCheckBox.TabIndex = 12;
			this.PartsCheckBox.Text = "Parts && Accessories";
			this.PartsCheckBox.UseVisualStyleBackColor = true;
			// 
			// AmmoCheckBox
			// 
			this.AmmoCheckBox.AutoSize = true;
			this.AmmoCheckBox.Checked = true;
			this.AmmoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.AmmoCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AmmoCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AmmoCheckBox.Location = new System.Drawing.Point(427, 21);
			this.AmmoCheckBox.Name = "AmmoCheckBox";
			this.AmmoCheckBox.Size = new System.Drawing.Size(80, 17);
			this.AmmoCheckBox.TabIndex = 11;
			this.AmmoCheckBox.Text = "Ammunition";
			this.AmmoCheckBox.UseVisualStyleBackColor = true;
			// 
			// BatchesCheckBox
			// 
			this.BatchesCheckBox.AutoSize = true;
			this.BatchesCheckBox.Checked = true;
			this.BatchesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.BatchesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BatchesCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BatchesCheckBox.Location = new System.Drawing.Point(427, 90);
			this.BatchesCheckBox.Name = "BatchesCheckBox";
			this.BatchesCheckBox.Size = new System.Drawing.Size(65, 17);
			this.BatchesCheckBox.TabIndex = 9;
			this.BatchesCheckBox.Text = "Batches";
			this.BatchesCheckBox.UseVisualStyleBackColor = true;
			// 
			// LoadsCheckBox
			// 
			this.LoadsCheckBox.AutoSize = true;
			this.LoadsCheckBox.Checked = true;
			this.LoadsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.LoadsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoadsCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LoadsCheckBox.Location = new System.Drawing.Point(427, 67);
			this.LoadsCheckBox.Name = "LoadsCheckBox";
			this.LoadsCheckBox.Size = new System.Drawing.Size(55, 17);
			this.LoadsCheckBox.TabIndex = 7;
			this.LoadsCheckBox.Text = "Loads";
			this.LoadsCheckBox.UseVisualStyleBackColor = true;
			// 
			// PowdersCheckBox
			// 
			this.PowdersCheckBox.AutoSize = true;
			this.PowdersCheckBox.Checked = true;
			this.PowdersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.PowdersCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PowdersCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PowdersCheckBox.Location = new System.Drawing.Point(350, 44);
			this.PowdersCheckBox.Name = "PowdersCheckBox";
			this.PowdersCheckBox.Size = new System.Drawing.Size(67, 17);
			this.PowdersCheckBox.TabIndex = 6;
			this.PowdersCheckBox.Text = "Powders";
			this.PowdersCheckBox.UseVisualStyleBackColor = true;
			// 
			// PrimersCheckBox
			// 
			this.PrimersCheckBox.AutoSize = true;
			this.PrimersCheckBox.Checked = true;
			this.PrimersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.PrimersCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PrimersCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PrimersCheckBox.Location = new System.Drawing.Point(350, 67);
			this.PrimersCheckBox.Name = "PrimersCheckBox";
			this.PrimersCheckBox.Size = new System.Drawing.Size(60, 17);
			this.PrimersCheckBox.TabIndex = 5;
			this.PrimersCheckBox.Text = "Primers";
			this.PrimersCheckBox.UseVisualStyleBackColor = true;
			// 
			// CasesCheckBox
			// 
			this.CasesCheckBox.AutoSize = true;
			this.CasesCheckBox.Checked = true;
			this.CasesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CasesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CasesCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CasesCheckBox.Location = new System.Drawing.Point(350, 90);
			this.CasesCheckBox.Name = "CasesCheckBox";
			this.CasesCheckBox.Size = new System.Drawing.Size(55, 17);
			this.CasesCheckBox.TabIndex = 4;
			this.CasesCheckBox.Text = "Cases";
			this.CasesCheckBox.UseVisualStyleBackColor = true;
			// 
			// BulletsCheckBox
			// 
			this.BulletsCheckBox.AutoSize = true;
			this.BulletsCheckBox.Checked = true;
			this.BulletsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.BulletsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletsCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BulletsCheckBox.Location = new System.Drawing.Point(350, 21);
			this.BulletsCheckBox.Name = "BulletsCheckBox";
			this.BulletsCheckBox.Size = new System.Drawing.Size(57, 17);
			this.BulletsCheckBox.TabIndex = 3;
			this.BulletsCheckBox.Text = "Bullets";
			this.BulletsCheckBox.UseVisualStyleBackColor = true;
			// 
			// FirearmsCheckBox
			// 
			this.FirearmsCheckBox.AutoSize = true;
			this.FirearmsCheckBox.Checked = true;
			this.FirearmsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.FirearmsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FirearmsCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FirearmsCheckBox.Location = new System.Drawing.Point(219, 67);
			this.FirearmsCheckBox.Name = "FirearmsCheckBox";
			this.FirearmsCheckBox.Size = new System.Drawing.Size(65, 17);
			this.FirearmsCheckBox.TabIndex = 2;
			this.FirearmsCheckBox.Text = "Firearms";
			this.FirearmsCheckBox.UseVisualStyleBackColor = true;
			// 
			// CalibersCheckBox
			// 
			this.CalibersCheckBox.AutoSize = true;
			this.CalibersCheckBox.Checked = true;
			this.CalibersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CalibersCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CalibersCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CalibersCheckBox.Location = new System.Drawing.Point(219, 44);
			this.CalibersCheckBox.Name = "CalibersCheckBox";
			this.CalibersCheckBox.Size = new System.Drawing.Size(63, 17);
			this.CalibersCheckBox.TabIndex = 1;
			this.CalibersCheckBox.Text = "Calibers";
			this.CalibersCheckBox.UseVisualStyleBackColor = true;
			// 
			// ManufacturersCheckBox
			// 
			this.ManufacturersCheckBox.AutoSize = true;
			this.ManufacturersCheckBox.Checked = true;
			this.ManufacturersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ManufacturersCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ManufacturersCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ManufacturersCheckBox.Location = new System.Drawing.Point(219, 21);
			this.ManufacturersCheckBox.Name = "ManufacturersCheckBox";
			this.ManufacturersCheckBox.Size = new System.Drawing.Size(94, 17);
			this.ManufacturersCheckBox.TabIndex = 0;
			this.ManufacturersCheckBox.Text = "Manufacturers";
			this.ManufacturersCheckBox.UseVisualStyleBackColor = true;
			// 
			// CancelFormButton
			// 
			this.CancelFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelFormButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CancelFormButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CancelFormButton.Location = new System.Drawing.Point(291, 241);
			this.CancelFormButton.Name = "CancelFormButton";
			this.CancelFormButton.Size = new System.Drawing.Size(75, 23);
			this.CancelFormButton.TabIndex = 13;
			this.CancelFormButton.Text = "Done";
			this.CancelFormButton.UseVisualStyleBackColor = true;
			// 
			// ExportButton
			// 
			this.ExportButton.Location = new System.Drawing.Point(182, 241);
			this.ExportButton.Name = "ExportButton";
			this.ExportButton.ShowToolTips = true;
			this.ExportButton.Size = new System.Drawing.Size(75, 23);
			this.ExportButton.TabIndex = 14;
			this.ExportButton.Text = "Export";
			this.ExportButton.ToolTip = "";
			this.ExportButton.UseVisualStyleBackColor = true;
			// 
			// DatabaseUpdateCheckBox
			// 
			this.DatabaseUpdateCheckBox.AutoSize = true;
			this.DatabaseUpdateCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DatabaseUpdateCheckBox.ForeColor = System.Drawing.Color.Blue;
			this.DatabaseUpdateCheckBox.Location = new System.Drawing.Point(10, 88);
			this.DatabaseUpdateCheckBox.Name = "DatabaseUpdateCheckBox";
			this.DatabaseUpdateCheckBox.Size = new System.Drawing.Size(185, 20);
			this.DatabaseUpdateCheckBox.TabIndex = 15;
			this.DatabaseUpdateCheckBox.Text = "Data Base Update File";
			this.DatabaseUpdateCheckBox.UseVisualStyleBackColor = true;
			// 
			// cExportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelFormButton;
			this.ClientSize = new System.Drawing.Size(545, 267);
			this.ControlBox = false;
			this.Controls.Add(this.ExportButton);
			this.Controls.Add(this.CancelFormButton);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.ExportFileGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cExportForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Export Data Files";
			this.ExportFileGroupBox.ResumeLayout(false);
			this.ExportFileGroupBox.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.ComboBox FileTypeCombo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private CommonLib.Controls.cTextBox FileNameTextBox;
		private System.Windows.Forms.GroupBox ExportFileGroupBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox ManufacturersCheckBox;
		private System.Windows.Forms.CheckBox AmmoCheckBox;
		private System.Windows.Forms.CheckBox BatchesCheckBox;
		private System.Windows.Forms.CheckBox LoadsCheckBox;
		private System.Windows.Forms.CheckBox PowdersCheckBox;
		private System.Windows.Forms.CheckBox PrimersCheckBox;
		private System.Windows.Forms.CheckBox CasesCheckBox;
		private System.Windows.Forms.CheckBox BulletsCheckBox;
		private System.Windows.Forms.CheckBox FirearmsCheckBox;
		private System.Windows.Forms.CheckBox CalibersCheckBox;
		private System.Windows.Forms.Label FileNameLabel;
		private System.Windows.Forms.Button CancelFormButton;
		private System.Windows.Forms.Button BrowseButton;
		private System.Windows.Forms.CheckBox PartsCheckBox;
		private System.Windows.Forms.CheckBox FullDataDumpCheckBox;
		private System.Windows.Forms.Label XMLPreferencesLabel;
		private CommonLib.Controls.cButton ExportButton;
		private System.Windows.Forms.CheckBox DatabaseUpdateCheckBox;
		}
	}