namespace ReloadersWorkShop
	{
	partial class cTargetCalibrationForm
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
			this.OKButton = new System.Windows.Forms.Button();
			this.FormCancelButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.CalibrationLengthTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.DPILabel = new System.Windows.Forms.Label();
			this.LengthMeasurementLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// OKButton
			// 
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Location = new System.Drawing.Point(129, 91);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 1;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			// 
			// FormCancelButton
			// 
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Location = new System.Drawing.Point(226, 91);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
			this.FormCancelButton.TabIndex = 2;
			this.FormCancelButton.Text = "Cancel";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(125, 57);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(108, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Length of Scale Line:";
			// 
			// CalibrationLengthTextBox
			// 
			this.CalibrationLengthTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.CalibrationLengthTextBox.Location = new System.Drawing.Point(239, 54);
			this.CalibrationLengthTextBox.MaxLength = 6;
			this.CalibrationLengthTextBox.MaxValue = 0D;
			this.CalibrationLengthTextBox.MinValue = 0D;
			this.CalibrationLengthTextBox.Name = "CalibrationLengthTextBox";
			this.CalibrationLengthTextBox.NumDecimals = 0;
			this.CalibrationLengthTextBox.Size = new System.Drawing.Size(46, 20);
			this.CalibrationLengthTextBox.TabIndex = 0;
			this.CalibrationLengthTextBox.Text = "3";
			this.CalibrationLengthTextBox.ToolTip = "";
			this.CalibrationLengthTextBox.Value = 3D;
			this.CalibrationLengthTextBox.ZeroAllowed = true;
			// 
			// DPILabel
			// 
			this.DPILabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DPILabel.Location = new System.Drawing.Point(12, 18);
			this.DPILabel.Name = "DPILabel";
			this.DPILabel.Size = new System.Drawing.Size(406, 13);
			this.DPILabel.TabIndex = 4;
			this.DPILabel.Text = "999 Scale Pixels = 50 DPI";
			this.DPILabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// LengthMeasurementLabel
			// 
			this.LengthMeasurementLabel.AutoSize = true;
			this.LengthMeasurementLabel.Location = new System.Drawing.Point(291, 57);
			this.LengthMeasurementLabel.Name = "LengthMeasurementLabel";
			this.LengthMeasurementLabel.Size = new System.Drawing.Size(15, 13);
			this.LengthMeasurementLabel.TabIndex = 5;
			this.LengthMeasurementLabel.Text = "in";
			// 
			// cTargetCalibrationForm
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.ClientSize = new System.Drawing.Size(430, 133);
			this.ControlBox = false;
			this.Controls.Add(this.LengthMeasurementLabel);
			this.Controls.Add(this.DPILabel);
			this.Controls.Add(this.CalibrationLengthTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.OKButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "cTargetCalibrationForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Scale Line Length";
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button FormCancelButton;
		private System.Windows.Forms.Label label1;
		private CommonLib.Controls.cDoubleValueTextBox CalibrationLengthTextBox;
		private System.Windows.Forms.Label DPILabel;
		private System.Windows.Forms.Label LengthMeasurementLabel;
		}
	}