namespace ReloadersWorkShop
	{
	partial class cBatchPrintForm
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
			System.Windows.Forms.Label label2;
			this.BatchPrintButton = new System.Windows.Forms.Button();
			this.BatchPrintCancelButton = new System.Windows.Forms.Button();
			this.PaperComboBox = new System.Windows.Forms.ComboBox();
			this.PageImageBox = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.TestShotBlanksRadioButton = new System.Windows.Forms.RadioButton();
			this.LoadDataTestRadioButton = new System.Windows.Forms.RadioButton();
			this.BatchTestRadioButton = new System.Windows.Forms.RadioButton();
			this.LabelFormatGroupBox = new System.Windows.Forms.GroupBox();
			this.PerBatchLabel = new System.Windows.Forms.Label();
			this.NumLabelsTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.LabelImage = new System.Windows.Forms.PictureBox();
			label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.PageImageBox)).BeginInit();
			this.LabelFormatGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LabelImage)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label2.ForeColor = System.Drawing.SystemColors.ControlText;
			label2.Location = new System.Drawing.Point(63, 24);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(38, 13);
			label2.TabIndex = 4;
			label2.Text = "Paper:";
			// 
			// BatchPrintButton
			// 
			this.BatchPrintButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.BatchPrintButton.Location = new System.Drawing.Point(160, 486);
			this.BatchPrintButton.Name = "BatchPrintButton";
			this.BatchPrintButton.Size = new System.Drawing.Size(75, 23);
			this.BatchPrintButton.TabIndex = 1;
			this.BatchPrintButton.Text = "Print";
			this.BatchPrintButton.UseVisualStyleBackColor = true;
			// 
			// BatchPrintCancelButton
			// 
			this.BatchPrintCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BatchPrintCancelButton.Location = new System.Drawing.Point(271, 486);
			this.BatchPrintCancelButton.Name = "BatchPrintCancelButton";
			this.BatchPrintCancelButton.Size = new System.Drawing.Size(75, 23);
			this.BatchPrintCancelButton.TabIndex = 2;
			this.BatchPrintCancelButton.Text = "Cancel";
			this.BatchPrintCancelButton.UseVisualStyleBackColor = true;
			// 
			// PaperComboBox
			// 
			this.PaperComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PaperComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PaperComboBox.FormattingEnabled = true;
			this.PaperComboBox.Items.AddRange(new object[] {
            "8.5\" x 11\" Letter (Six 4\" x 3.33\" labels per sheet)",
            "Avery 5444 (Two 4\" x 2\" labels per sheet)",
            "Avery 5453 (Two 4\" x 3\" labels per sheet)",
            "Avery 6464 (Six 4\" x 3.33\" labels per sheet)",
            "Avery 6482 (Six 4\" x 3.33\" labels per sheet)"});
			this.PaperComboBox.Location = new System.Drawing.Point(107, 21);
			this.PaperComboBox.Name = "PaperComboBox";
			this.PaperComboBox.Size = new System.Drawing.Size(256, 21);
			this.PaperComboBox.TabIndex = 0;
			// 
			// PageImageBox
			// 
			this.PageImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PageImageBox.Location = new System.Drawing.Point(373, 21);
			this.PageImageBox.Name = "PageImageBox";
			this.PageImageBox.Size = new System.Drawing.Size(100, 150);
			this.PageImageBox.TabIndex = 6;
			this.PageImageBox.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(35, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Num Labels:";
			// 
			// TestShotBlanksRadioButton
			// 
			this.TestShotBlanksRadioButton.AutoCheck = false;
			this.TestShotBlanksRadioButton.AutoSize = true;
			this.TestShotBlanksRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.TestShotBlanksRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TestShotBlanksRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TestShotBlanksRadioButton.Location = new System.Drawing.Point(7, 74);
			this.TestShotBlanksRadioButton.Name = "TestShotBlanksRadioButton";
			this.TestShotBlanksRadioButton.Size = new System.Drawing.Size(109, 17);
			this.TestShotBlanksRadioButton.TabIndex = 2;
			this.TestShotBlanksRadioButton.TabStop = true;
			this.TestShotBlanksRadioButton.Text = "Test Shot Blanks:";
			this.TestShotBlanksRadioButton.UseVisualStyleBackColor = true;
			// 
			// LoadDataTestRadioButton
			// 
			this.LoadDataTestRadioButton.AutoCheck = false;
			this.LoadDataTestRadioButton.AutoSize = true;
			this.LoadDataTestRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.LoadDataTestRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoadDataTestRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LoadDataTestRadioButton.Location = new System.Drawing.Point(14, 99);
			this.LoadDataTestRadioButton.Name = "LoadDataTestRadioButton";
			this.LoadDataTestRadioButton.Size = new System.Drawing.Size(102, 17);
			this.LoadDataTestRadioButton.TabIndex = 3;
			this.LoadDataTestRadioButton.TabStop = true;
			this.LoadDataTestRadioButton.Text = "Load Test Data:";
			this.LoadDataTestRadioButton.UseVisualStyleBackColor = true;
			// 
			// BatchTestRadioButton
			// 
			this.BatchTestRadioButton.AutoCheck = false;
			this.BatchTestRadioButton.AutoSize = true;
			this.BatchTestRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.BatchTestRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BatchTestRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BatchTestRadioButton.Location = new System.Drawing.Point(10, 123);
			this.BatchTestRadioButton.Name = "BatchTestRadioButton";
			this.BatchTestRadioButton.Size = new System.Drawing.Size(106, 17);
			this.BatchTestRadioButton.TabIndex = 4;
			this.BatchTestRadioButton.TabStop = true;
			this.BatchTestRadioButton.Text = "Batch Test Data:";
			this.BatchTestRadioButton.UseVisualStyleBackColor = true;
			// 
			// LabelFormatGroupBox
			// 
			this.LabelFormatGroupBox.Controls.Add(this.PerBatchLabel);
			this.LabelFormatGroupBox.Controls.Add(this.NumLabelsTextBox);
			this.LabelFormatGroupBox.Controls.Add(this.PaperComboBox);
			this.LabelFormatGroupBox.Controls.Add(this.BatchTestRadioButton);
			this.LabelFormatGroupBox.Controls.Add(label2);
			this.LabelFormatGroupBox.Controls.Add(this.LoadDataTestRadioButton);
			this.LabelFormatGroupBox.Controls.Add(this.PageImageBox);
			this.LabelFormatGroupBox.Controls.Add(this.TestShotBlanksRadioButton);
			this.LabelFormatGroupBox.Controls.Add(this.label1);
			this.LabelFormatGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelFormatGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.LabelFormatGroupBox.Location = new System.Drawing.Point(10, 281);
			this.LabelFormatGroupBox.Name = "LabelFormatGroupBox";
			this.LabelFormatGroupBox.Size = new System.Drawing.Size(482, 186);
			this.LabelFormatGroupBox.TabIndex = 0;
			this.LabelFormatGroupBox.TabStop = false;
			this.LabelFormatGroupBox.Text = "Label Format";
			// 
			// PerBatchLabel
			// 
			this.PerBatchLabel.AutoSize = true;
			this.PerBatchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PerBatchLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PerBatchLabel.Location = new System.Drawing.Point(151, 51);
			this.PerBatchLabel.Name = "PerBatchLabel";
			this.PerBatchLabel.Size = new System.Drawing.Size(64, 13);
			this.PerBatchLabel.TabIndex = 8;
			this.PerBatchLabel.Text = "( per batch )";
			// 
			// NumLabelsTextBox
			// 
			this.NumLabelsTextBox.BackColor = System.Drawing.Color.LightPink;
			this.NumLabelsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NumLabelsTextBox.Location = new System.Drawing.Point(107, 48);
			this.NumLabelsTextBox.MaxLength = 2;
			this.NumLabelsTextBox.MaxValue = 99;
			this.NumLabelsTextBox.MinValue = 1;
			this.NumLabelsTextBox.Name = "NumLabelsTextBox";
			this.NumLabelsTextBox.Required = false;
			this.NumLabelsTextBox.Size = new System.Drawing.Size(38, 20);
			this.NumLabelsTextBox.TabIndex = 1;
			this.NumLabelsTextBox.Text = "0";
			this.NumLabelsTextBox.ToolTip = "";
			this.NumLabelsTextBox.Value = 0;
			// 
			// LabelImage
			// 
			this.LabelImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LabelImage.Location = new System.Drawing.Point(10, 12);
			this.LabelImage.Name = "LabelImage";
			this.LabelImage.Size = new System.Drawing.Size(482, 263);
			this.LabelImage.TabIndex = 13;
			this.LabelImage.TabStop = false;
			// 
			// cBatchPrintForm
			// 
			this.AcceptButton = this.BatchPrintButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.BatchPrintCancelButton;
			this.ClientSize = new System.Drawing.Size(506, 528);
			this.ControlBox = false;
			this.Controls.Add(this.LabelImage);
			this.Controls.Add(this.LabelFormatGroupBox);
			this.Controls.Add(this.BatchPrintCancelButton);
			this.Controls.Add(this.BatchPrintButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cBatchPrintForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Print Batch Label";
			((System.ComponentModel.ISupportInitialize)(this.PageImageBox)).EndInit();
			this.LabelFormatGroupBox.ResumeLayout(false);
			this.LabelFormatGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LabelImage)).EndInit();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.Button BatchPrintButton;
		private System.Windows.Forms.Button BatchPrintCancelButton;
		private System.Windows.Forms.ComboBox PaperComboBox;
		private System.Windows.Forms.PictureBox PageImageBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton TestShotBlanksRadioButton;
		private System.Windows.Forms.RadioButton LoadDataTestRadioButton;
		private System.Windows.Forms.RadioButton BatchTestRadioButton;
		private System.Windows.Forms.GroupBox LabelFormatGroupBox;
		private System.Windows.Forms.PictureBox LabelImage;
		private CommonLib.Controls.cIntegerValueTextBox NumLabelsTextBox;
		private System.Windows.Forms.Label PerBatchLabel;
		}
	}