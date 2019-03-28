namespace ReloadersWorkShop
	{
	partial class cBulletCaliberForm
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
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label7;
			this.COALMeasurementLabel = new System.Windows.Forms.Label();
			this.CBTOMeasurementLabel = new System.Windows.Forms.Label();
			this.SelectedCaliberLabel = new System.Windows.Forms.Label();
			this.BulletLabel = new System.Windows.Forms.Label();
			this.CaliberCombo = new System.Windows.Forms.ComboBox();
			this.BulletCaliberOKButton = new System.Windows.Forms.Button();
			this.BulletCaliberCancelButton = new System.Windows.Forms.Button();
			this.MaxCOLLabel = new System.Windows.Forms.Label();
			this.COALTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.CBTOTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(16, 24);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(36, 13);
			label1.TabIndex = 0;
			label1.Text = "Bullet:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(9, 49);
			label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(42, 13);
			label3.TabIndex = 3;
			label3.Text = "Caliber:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(33, 79);
			label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(38, 13);
			label4.TabIndex = 4;
			label4.Text = "COAL:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(158, 79);
			label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(61, 13);
			label2.TabIndex = 9;
			label2.Text = "Max COAL:";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(32, 104);
			label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(39, 13);
			label7.TabIndex = 13;
			label7.Text = "CBTO:";
			// 
			// COALMeasurementLabel
			// 
			this.COALMeasurementLabel.AutoSize = true;
			this.COALMeasurementLabel.Location = new System.Drawing.Point(119, 79);
			this.COALMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.COALMeasurementLabel.Name = "COALMeasurementLabel";
			this.COALMeasurementLabel.Size = new System.Drawing.Size(15, 13);
			this.COALMeasurementLabel.TabIndex = 6;
			this.COALMeasurementLabel.Text = "in";
			// 
			// CBTOMeasurementLabel
			// 
			this.CBTOMeasurementLabel.AutoSize = true;
			this.CBTOMeasurementLabel.Location = new System.Drawing.Point(119, 104);
			this.CBTOMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.CBTOMeasurementLabel.Name = "CBTOMeasurementLabel";
			this.CBTOMeasurementLabel.Size = new System.Drawing.Size(15, 13);
			this.CBTOMeasurementLabel.TabIndex = 14;
			this.CBTOMeasurementLabel.Text = "in";
			// 
			// SelectedCaliberLabel
			// 
			this.SelectedCaliberLabel.AutoSize = true;
			this.SelectedCaliberLabel.Location = new System.Drawing.Point(223, 98);
			this.SelectedCaliberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.SelectedCaliberLabel.Name = "SelectedCaliberLabel";
			this.SelectedCaliberLabel.Size = new System.Drawing.Size(120, 13);
			this.SelectedCaliberLabel.TabIndex = 11;
			this.SelectedCaliberLabel.Text = "(for the selected caliber)";
			// 
			// BulletLabel
			// 
			this.BulletLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletLabel.Location = new System.Drawing.Point(56, 24);
			this.BulletLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.BulletLabel.Name = "BulletLabel";
			this.BulletLabel.Size = new System.Drawing.Size(349, 19);
			this.BulletLabel.TabIndex = 1;
			this.BulletLabel.Text = "Bullet Description";
			// 
			// CaliberCombo
			// 
			this.CaliberCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CaliberCombo.FormattingEnabled = true;
			this.CaliberCombo.Location = new System.Drawing.Point(56, 46);
			this.CaliberCombo.Margin = new System.Windows.Forms.Padding(2);
			this.CaliberCombo.Name = "CaliberCombo";
			this.CaliberCombo.Size = new System.Drawing.Size(200, 21);
			this.CaliberCombo.TabIndex = 0;
			// 
			// BulletCaliberOKButton
			// 
			this.BulletCaliberOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.BulletCaliberOKButton.Location = new System.Drawing.Point(114, 166);
			this.BulletCaliberOKButton.Margin = new System.Windows.Forms.Padding(2);
			this.BulletCaliberOKButton.Name = "BulletCaliberOKButton";
			this.BulletCaliberOKButton.Size = new System.Drawing.Size(56, 19);
			this.BulletCaliberOKButton.TabIndex = 3;
			this.BulletCaliberOKButton.Text = "OK";
			this.BulletCaliberOKButton.UseVisualStyleBackColor = true;
			// 
			// BulletCaliberCancelButton
			// 
			this.BulletCaliberCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BulletCaliberCancelButton.Location = new System.Drawing.Point(184, 166);
			this.BulletCaliberCancelButton.Margin = new System.Windows.Forms.Padding(2);
			this.BulletCaliberCancelButton.Name = "BulletCaliberCancelButton";
			this.BulletCaliberCancelButton.Size = new System.Drawing.Size(56, 19);
			this.BulletCaliberCancelButton.TabIndex = 4;
			this.BulletCaliberCancelButton.Text = "Cancel";
			this.BulletCaliberCancelButton.UseVisualStyleBackColor = true;
			// 
			// MaxCOLLabel
			// 
			this.MaxCOLLabel.AutoSize = true;
			this.MaxCOLLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxCOLLabel.Location = new System.Drawing.Point(223, 79);
			this.MaxCOLLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MaxCOLLabel.Name = "MaxCOLLabel";
			this.MaxCOLLabel.Size = new System.Drawing.Size(66, 13);
			this.MaxCOLLabel.TabIndex = 10;
			this.MaxCOLLabel.Text = "Max COAL";
			// 
			// COALTextBox
			// 
			this.COALTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.COALTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.COALTextBox.Location = new System.Drawing.Point(76, 76);
			this.COALTextBox.MaxLength = 5;
			this.COALTextBox.MaxValue = 0D;
			this.COALTextBox.MinValue = 0D;
			this.COALTextBox.Name = "COALTextBox";
			this.COALTextBox.NumDecimals = 3;
			this.COALTextBox.Size = new System.Drawing.Size(38, 20);
			this.COALTextBox.TabIndex = 1;
			this.COALTextBox.Text = "0.000";
			this.COALTextBox.ToolTip = "";
			this.COALTextBox.Value = 0D;
			this.COALTextBox.ZeroAllowed = true;
			// 
			// CBTOTextBox
			// 
			this.CBTOTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.CBTOTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CBTOTextBox.Location = new System.Drawing.Point(76, 101);
			this.CBTOTextBox.MaxLength = 5;
			this.CBTOTextBox.MaxValue = 0D;
			this.CBTOTextBox.MinValue = 0D;
			this.CBTOTextBox.Name = "CBTOTextBox";
			this.CBTOTextBox.NumDecimals = 3;
			this.CBTOTextBox.Size = new System.Drawing.Size(38, 20);
			this.CBTOTextBox.TabIndex = 2;
			this.CBTOTextBox.Text = "0.000";
			this.CBTOTextBox.ToolTip = "";
			this.CBTOTextBox.Value = 0D;
			this.CBTOTextBox.ZeroAllowed = true;
			// 
			// cBulletCaliberForm
			// 
			this.AcceptButton = this.BulletCaliberOKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.BulletCaliberCancelButton;
			this.ClientSize = new System.Drawing.Size(355, 196);
			this.ControlBox = false;
			this.Controls.Add(this.CBTOMeasurementLabel);
			this.Controls.Add(this.CBTOTextBox);
			this.Controls.Add(this.COALTextBox);
			this.Controls.Add(label7);
			this.Controls.Add(this.SelectedCaliberLabel);
			this.Controls.Add(this.MaxCOLLabel);
			this.Controls.Add(label2);
			this.Controls.Add(this.BulletCaliberCancelButton);
			this.Controls.Add(this.BulletCaliberOKButton);
			this.Controls.Add(this.COALMeasurementLabel);
			this.Controls.Add(label4);
			this.Controls.Add(label3);
			this.Controls.Add(this.CaliberCombo);
			this.Controls.Add(this.BulletLabel);
			this.Controls.Add(label1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cBulletCaliberForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Bullet Caliber";
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.Label BulletLabel;
		private System.Windows.Forms.ComboBox CaliberCombo;
		private System.Windows.Forms.Button BulletCaliberOKButton;
		private System.Windows.Forms.Button BulletCaliberCancelButton;
		private System.Windows.Forms.Label MaxCOLLabel;
		private CommonLib.Controls.cDoubleValueTextBox COALTextBox;
		private CommonLib.Controls.cDoubleValueTextBox CBTOTextBox;
		private System.Windows.Forms.Label SelectedCaliberLabel;
		private System.Windows.Forms.Label COALMeasurementLabel;
		private System.Windows.Forms.Label CBTOMeasurementLabel;
		}
	}