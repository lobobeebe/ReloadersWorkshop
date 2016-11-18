namespace ReloadersWorkShop
	{
	partial class cFirearmBulletForm
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
			System.Windows.Forms.Label label5;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label6;
			this.COLMeasurementLabel = new System.Windows.Forms.Label();
			this.CBTOMeasurementLabel = new System.Windows.Forms.Label();
			this.FirearmLabel = new System.Windows.Forms.Label();
			this.BulletDataGroupBox = new System.Windows.Forms.GroupBox();
			this.CBTOTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.COALTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.MaxCOALLabel = new System.Windows.Forms.Label();
			this.BulletImage = new System.Windows.Forms.PictureBox();
			this.BulletCombo = new System.Windows.Forms.ComboBox();
			this.FirearmBulletOKButton = new System.Windows.Forms.Button();
			this.FirearmBulletCancelButton = new System.Windows.Forms.Button();
			this.JumpMeasurementLabel = new System.Windows.Forms.Label();
			this.JumpTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			label1 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			this.BulletDataGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BulletImage)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label1.ForeColor = System.Drawing.SystemColors.ControlText;
			label1.Location = new System.Drawing.Point(20, 50);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(61, 13);
			label1.TabIndex = 7;
			label1.Text = "Max COAL:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label5.ForeColor = System.Drawing.SystemColors.ControlText;
			label5.Location = new System.Drawing.Point(163, 75);
			label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(39, 13);
			label5.TabIndex = 4;
			label5.Text = "CBTO:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label4.ForeColor = System.Drawing.SystemColors.ControlText;
			label4.Location = new System.Drawing.Point(42, 75);
			label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(38, 13);
			label4.TabIndex = 3;
			label4.Text = "COAL:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label3.ForeColor = System.Drawing.SystemColors.ControlText;
			label3.Location = new System.Drawing.Point(45, 25);
			label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(36, 13);
			label3.TabIndex = 0;
			label3.Text = "Bullet:";
			// 
			// COLMeasurementLabel
			// 
			this.COLMeasurementLabel.AutoSize = true;
			this.COLMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.COLMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.COLMeasurementLabel.Location = new System.Drawing.Point(128, 75);
			this.COLMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.COLMeasurementLabel.Name = "COLMeasurementLabel";
			this.COLMeasurementLabel.Size = new System.Drawing.Size(15, 13);
			this.COLMeasurementLabel.TabIndex = 51;
			this.COLMeasurementLabel.Text = "in";
			// 
			// CBTOMeasurementLabel
			// 
			this.CBTOMeasurementLabel.AutoSize = true;
			this.CBTOMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CBTOMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CBTOMeasurementLabel.Location = new System.Drawing.Point(250, 75);
			this.CBTOMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.CBTOMeasurementLabel.Name = "CBTOMeasurementLabel";
			this.CBTOMeasurementLabel.Size = new System.Drawing.Size(15, 13);
			this.CBTOMeasurementLabel.TabIndex = 52;
			this.CBTOMeasurementLabel.Text = "in";
			// 
			// FirearmLabel
			// 
			this.FirearmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FirearmLabel.Location = new System.Drawing.Point(9, 15);
			this.FirearmLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.FirearmLabel.Name = "FirearmLabel";
			this.FirearmLabel.Size = new System.Drawing.Size(503, 19);
			this.FirearmLabel.TabIndex = 1;
			this.FirearmLabel.Text = "Firearm";
			this.FirearmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BulletDataGroupBox
			// 
			this.BulletDataGroupBox.BackColor = System.Drawing.SystemColors.Control;
			this.BulletDataGroupBox.Controls.Add(this.JumpMeasurementLabel);
			this.BulletDataGroupBox.Controls.Add(this.JumpTextBox);
			this.BulletDataGroupBox.Controls.Add(label6);
			this.BulletDataGroupBox.Controls.Add(this.CBTOMeasurementLabel);
			this.BulletDataGroupBox.Controls.Add(this.COLMeasurementLabel);
			this.BulletDataGroupBox.Controls.Add(this.CBTOTextBox);
			this.BulletDataGroupBox.Controls.Add(this.COALTextBox);
			this.BulletDataGroupBox.Controls.Add(this.MaxCOALLabel);
			this.BulletDataGroupBox.Controls.Add(label1);
			this.BulletDataGroupBox.Controls.Add(this.BulletImage);
			this.BulletDataGroupBox.Controls.Add(label5);
			this.BulletDataGroupBox.Controls.Add(label4);
			this.BulletDataGroupBox.Controls.Add(this.BulletCombo);
			this.BulletDataGroupBox.Controls.Add(label3);
			this.BulletDataGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletDataGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.BulletDataGroupBox.Location = new System.Drawing.Point(10, 46);
			this.BulletDataGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.BulletDataGroupBox.Name = "BulletDataGroupBox";
			this.BulletDataGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.BulletDataGroupBox.Size = new System.Drawing.Size(502, 131);
			this.BulletDataGroupBox.TabIndex = 0;
			this.BulletDataGroupBox.TabStop = false;
			this.BulletDataGroupBox.Text = "Bullet Data";
			// 
			// CBTOTextBox
			// 
			this.CBTOTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.CBTOTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CBTOTextBox.Location = new System.Drawing.Point(207, 72);
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
			// COALTextBox
			// 
			this.COALTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.COALTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.COALTextBox.Location = new System.Drawing.Point(85, 72);
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
			// MaxCOALLabel
			// 
			this.MaxCOALLabel.AutoSize = true;
			this.MaxCOALLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxCOALLabel.Location = new System.Drawing.Point(86, 47);
			this.MaxCOALLabel.Name = "MaxCOALLabel";
			this.MaxCOALLabel.Size = new System.Drawing.Size(49, 17);
			this.MaxCOALLabel.TabIndex = 8;
			this.MaxCOALLabel.Text = "0.000";
			// 
			// BulletImage
			// 
			this.BulletImage.Location = new System.Drawing.Point(413, 20);
			this.BulletImage.Margin = new System.Windows.Forms.Padding(2);
			this.BulletImage.Name = "BulletImage";
			this.BulletImage.Size = new System.Drawing.Size(75, 100);
			this.BulletImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.BulletImage.TabIndex = 6;
			this.BulletImage.TabStop = false;
			// 
			// BulletCombo
			// 
			this.BulletCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BulletCombo.DropDownWidth = 300;
			this.BulletCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletCombo.FormattingEnabled = true;
			this.BulletCombo.Location = new System.Drawing.Point(89, 22);
			this.BulletCombo.Margin = new System.Windows.Forms.Padding(2);
			this.BulletCombo.Name = "BulletCombo";
			this.BulletCombo.Size = new System.Drawing.Size(250, 21);
			this.BulletCombo.TabIndex = 0;
			// 
			// FirearmBulletOKButton
			// 
			this.FirearmBulletOKButton.BackColor = System.Drawing.SystemColors.Control;
			this.FirearmBulletOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.FirearmBulletOKButton.Location = new System.Drawing.Point(189, 192);
			this.FirearmBulletOKButton.Margin = new System.Windows.Forms.Padding(2);
			this.FirearmBulletOKButton.Name = "FirearmBulletOKButton";
			this.FirearmBulletOKButton.Size = new System.Drawing.Size(56, 19);
			this.FirearmBulletOKButton.TabIndex = 1;
			this.FirearmBulletOKButton.Text = "Add";
			this.FirearmBulletOKButton.UseVisualStyleBackColor = false;
			// 
			// FirearmBulletCancelButton
			// 
			this.FirearmBulletCancelButton.BackColor = System.Drawing.SystemColors.Control;
			this.FirearmBulletCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FirearmBulletCancelButton.Location = new System.Drawing.Point(278, 192);
			this.FirearmBulletCancelButton.Margin = new System.Windows.Forms.Padding(2);
			this.FirearmBulletCancelButton.Name = "FirearmBulletCancelButton";
			this.FirearmBulletCancelButton.Size = new System.Drawing.Size(56, 19);
			this.FirearmBulletCancelButton.TabIndex = 2;
			this.FirearmBulletCancelButton.Text = "Cancel";
			this.FirearmBulletCancelButton.UseVisualStyleBackColor = false;
			// 
			// JumpMeasurementLabel
			// 
			this.JumpMeasurementLabel.AutoSize = true;
			this.JumpMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.JumpMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.JumpMeasurementLabel.Location = new System.Drawing.Point(368, 75);
			this.JumpMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.JumpMeasurementLabel.Name = "JumpMeasurementLabel";
			this.JumpMeasurementLabel.Size = new System.Drawing.Size(15, 13);
			this.JumpMeasurementLabel.TabIndex = 55;
			this.JumpMeasurementLabel.Text = "in";
			// 
			// JumpTextBox
			// 
			this.JumpTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.JumpTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.JumpTextBox.Location = new System.Drawing.Point(325, 72);
			this.JumpTextBox.MaxLength = 5;
			this.JumpTextBox.MaxValue = 0D;
			this.JumpTextBox.MinValue = 0D;
			this.JumpTextBox.Name = "JumpTextBox";
			this.JumpTextBox.NumDecimals = 3;
			this.JumpTextBox.Size = new System.Drawing.Size(38, 20);
			this.JumpTextBox.TabIndex = 53;
			this.JumpTextBox.Text = "0.000";
			this.JumpTextBox.ToolTip = "";
			this.JumpTextBox.Value = 0D;
			this.JumpTextBox.ZeroAllowed = true;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label6.ForeColor = System.Drawing.SystemColors.ControlText;
			label6.Location = new System.Drawing.Point(285, 75);
			label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(35, 13);
			label6.TabIndex = 54;
			label6.Text = "Jump:";
			// 
			// cFirearmBulletForm
			// 
			this.AcceptButton = this.FirearmBulletOKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton = this.FirearmBulletCancelButton;
			this.ClientSize = new System.Drawing.Size(518, 212);
			this.ControlBox = false;
			this.Controls.Add(this.FirearmBulletCancelButton);
			this.Controls.Add(this.FirearmBulletOKButton);
			this.Controls.Add(this.BulletDataGroupBox);
			this.Controls.Add(this.FirearmLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cFirearmBulletForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Firearm Specific Bullet Data";
			this.BulletDataGroupBox.ResumeLayout(false);
			this.BulletDataGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.BulletImage)).EndInit();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.Label FirearmLabel;
		private System.Windows.Forms.GroupBox BulletDataGroupBox;
		private System.Windows.Forms.ComboBox BulletCombo;
		private System.Windows.Forms.Button FirearmBulletOKButton;
		private System.Windows.Forms.Button FirearmBulletCancelButton;
        private System.Windows.Forms.PictureBox BulletImage;
		private System.Windows.Forms.Label MaxCOALLabel;
		private CommonLib.Controls.cDoubleValueTextBox CBTOTextBox;
		private CommonLib.Controls.cDoubleValueTextBox COALTextBox;
		private System.Windows.Forms.Label COLMeasurementLabel;
		private System.Windows.Forms.Label CBTOMeasurementLabel;
		private System.Windows.Forms.Label JumpMeasurementLabel;
		private CommonLib.Controls.cDoubleValueTextBox JumpTextBox;
		}
	}