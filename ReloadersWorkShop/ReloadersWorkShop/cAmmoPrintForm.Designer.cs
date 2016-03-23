namespace ReloadersWorkShop
	{
	partial class cAmmoPrintForm
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
			this.LabelImage = new System.Windows.Forms.PictureBox();
			this.LabelFormatGroup = new System.Windows.Forms.GroupBox();
			this.NumLabelsTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.PaperComboBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TestDataRadioButton = new System.Windows.Forms.RadioButton();
			this.PageImageBox = new System.Windows.Forms.PictureBox();
			this.TestShotBlanksRadioButton = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.CancelPrintButton = new System.Windows.Forms.Button();
			this.PrintButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.LabelImage)).BeginInit();
			this.LabelFormatGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PageImageBox)).BeginInit();
			this.SuspendLayout();
			// 
			// LabelImage
			// 
			this.LabelImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LabelImage.Location = new System.Drawing.Point(10, 16);
			this.LabelImage.Name = "LabelImage";
			this.LabelImage.Size = new System.Drawing.Size(482, 263);
			this.LabelImage.TabIndex = 17;
			this.LabelImage.TabStop = false;
			// 
			// LabelFormatGroup
			// 
			this.LabelFormatGroup.Controls.Add(this.NumLabelsTextBox);
			this.LabelFormatGroup.Controls.Add(this.PaperComboBox);
			this.LabelFormatGroup.Controls.Add(this.label2);
			this.LabelFormatGroup.Controls.Add(this.TestDataRadioButton);
			this.LabelFormatGroup.Controls.Add(this.PageImageBox);
			this.LabelFormatGroup.Controls.Add(this.TestShotBlanksRadioButton);
			this.LabelFormatGroup.Controls.Add(this.label1);
			this.LabelFormatGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelFormatGroup.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.LabelFormatGroup.Location = new System.Drawing.Point(10, 285);
			this.LabelFormatGroup.Name = "LabelFormatGroup";
			this.LabelFormatGroup.Size = new System.Drawing.Size(482, 186);
			this.LabelFormatGroup.TabIndex = 0;
			this.LabelFormatGroup.TabStop = false;
			this.LabelFormatGroup.Text = "Label Format";
			// 
			// NumLabelsTextBox
			// 
			this.NumLabelsTextBox.BackColor = System.Drawing.Color.LightPink;
			this.NumLabelsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NumLabelsTextBox.Location = new System.Drawing.Point(107, 46);
			this.NumLabelsTextBox.MaxLength = 2;
			this.NumLabelsTextBox.MaxValue = 99;
			this.NumLabelsTextBox.MinValue = 1;
			this.NumLabelsTextBox.Name = "NumLabelsTextBox";
			this.NumLabelsTextBox.Size = new System.Drawing.Size(38, 20);
			this.NumLabelsTextBox.TabIndex = 1;
			this.NumLabelsTextBox.Text = "0";
			this.NumLabelsTextBox.Value = 0;
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
            "Avery 6482 (Six 4\" x 3.33\" labels per sheet)"});
			this.PaperComboBox.Location = new System.Drawing.Point(107, 21);
			this.PaperComboBox.Name = "PaperComboBox";
			this.PaperComboBox.Size = new System.Drawing.Size(256, 21);
			this.PaperComboBox.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(63, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Paper:";
			// 
			// TestDataRadioButton
			// 
			this.TestDataRadioButton.AutoCheck = false;
			this.TestDataRadioButton.AutoSize = true;
			this.TestDataRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.TestDataRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TestDataRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TestDataRadioButton.Location = new System.Drawing.Point(41, 97);
			this.TestDataRadioButton.Name = "TestDataRadioButton";
			this.TestDataRadioButton.Size = new System.Drawing.Size(75, 17);
			this.TestDataRadioButton.TabIndex = 3;
			this.TestDataRadioButton.TabStop = true;
			this.TestDataRadioButton.Text = "Test Data:";
			this.TestDataRadioButton.UseVisualStyleBackColor = true;
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
			// CancelPrintButton
			// 
			this.CancelPrintButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelPrintButton.Location = new System.Drawing.Point(271, 490);
			this.CancelPrintButton.Name = "CancelPrintButton";
			this.CancelPrintButton.Size = new System.Drawing.Size(75, 23);
			this.CancelPrintButton.TabIndex = 2;
			this.CancelPrintButton.Text = "Cancel";
			this.CancelPrintButton.UseVisualStyleBackColor = true;
			// 
			// PrintButton
			// 
			this.PrintButton.Location = new System.Drawing.Point(160, 490);
			this.PrintButton.Name = "PrintButton";
			this.PrintButton.Size = new System.Drawing.Size(75, 23);
			this.PrintButton.TabIndex = 1;
			this.PrintButton.Text = "Print";
			this.PrintButton.UseVisualStyleBackColor = true;
			// 
			// cAmmoPrintForm
			// 
			this.AcceptButton = this.PrintButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelPrintButton;
			this.ClientSize = new System.Drawing.Size(506, 528);
			this.ControlBox = false;
			this.Controls.Add(this.LabelImage);
			this.Controls.Add(this.LabelFormatGroup);
			this.Controls.Add(this.CancelPrintButton);
			this.Controls.Add(this.PrintButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cAmmoPrintForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Print Ammo Label";
			((System.ComponentModel.ISupportInitialize)(this.LabelImage)).EndInit();
			this.LabelFormatGroup.ResumeLayout(false);
			this.LabelFormatGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PageImageBox)).EndInit();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.PictureBox LabelImage;
		private System.Windows.Forms.GroupBox LabelFormatGroup;
		private System.Windows.Forms.ComboBox PaperComboBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox PageImageBox;
		private System.Windows.Forms.RadioButton TestShotBlanksRadioButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button CancelPrintButton;
		private System.Windows.Forms.Button PrintButton;
		private System.Windows.Forms.RadioButton TestDataRadioButton;
		private CommonLib.Controls.cIntegerValueTextBox NumLabelsTextBox;
		}
	}