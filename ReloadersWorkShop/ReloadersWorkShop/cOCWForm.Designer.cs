namespace ReloadersWorkShop
	{
	partial class cOCWForm
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
			this.OKButton = new CommonLib.Controls.cOKButton();
			this.FormCancelButton = new CommonLib.Controls.cCancelButton();
			this.label1 = new System.Windows.Forms.Label();
			this.SettingsGroupBox = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.MaxNumBatchesTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.NumRoundsTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.StartingWeightTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.IncrementTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.StartingWeightMeasurementLabel = new System.Windows.Forms.Label();
			this.IncrementMeasurementLabel = new System.Windows.Forms.Label();
			this.OCWLabel = new System.Windows.Forms.Label();
			this.SettingsGroupBox.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKButton
			// 
			this.OKButton.ButtonType = CommonLib.Controls.cOKButton.eButtonTypes.OK;
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Location = new System.Drawing.Point(50, 294);
			this.OKButton.Name = "OKButton";
			this.OKButton.ShowToolTips = true;
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 1;
			this.OKButton.Text = "OK";
			this.OKButton.ToolTip = "Click to accept changes and exit.";
			this.OKButton.UseVisualStyleBackColor = true;
			// 
			// FormCancelButton
			// 
			this.FormCancelButton.ButtonType = CommonLib.Controls.cCancelButton.eButtonTypes.Cancel;
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Location = new System.Drawing.Point(148, 294);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.ShowToolTips = true;
			this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
			this.FormCancelButton.TabIndex = 2;
			this.FormCancelButton.Text = "Cancel";
			this.FormCancelButton.ToolTip = "Click to cancel changes and exit.";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(27, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(121, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Max number of batches:";
			// 
			// SettingsGroupBox
			// 
			this.SettingsGroupBox.Controls.Add(this.IncrementMeasurementLabel);
			this.SettingsGroupBox.Controls.Add(this.StartingWeightMeasurementLabel);
			this.SettingsGroupBox.Controls.Add(this.IncrementTextBox);
			this.SettingsGroupBox.Controls.Add(this.StartingWeightTextBox);
			this.SettingsGroupBox.Controls.Add(this.NumRoundsTextBox);
			this.SettingsGroupBox.Controls.Add(this.MaxNumBatchesTextBox);
			this.SettingsGroupBox.Controls.Add(this.label4);
			this.SettingsGroupBox.Controls.Add(this.label3);
			this.SettingsGroupBox.Controls.Add(this.label2);
			this.SettingsGroupBox.Controls.Add(this.label1);
			this.SettingsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SettingsGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.SettingsGroupBox.Location = new System.Drawing.Point(12, 12);
			this.SettingsGroupBox.Name = "SettingsGroupBox";
			this.SettingsGroupBox.Size = new System.Drawing.Size(246, 133);
			this.SettingsGroupBox.TabIndex = 0;
			this.SettingsGroupBox.TabStop = false;
			this.SettingsGroupBox.Text = "Settings";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(26, 75);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(122, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Starting Powder Weight:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(6, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(142, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Number of rounds per batch:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.OCWLabel);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox2.Location = new System.Drawing.Point(12, 151);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(246, 122);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Results";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(15, 100);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(133, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Powder Weight Increment:";
			// 
			// MaxNumBatchesTextBox
			// 
			this.MaxNumBatchesTextBox.BackColor = System.Drawing.Color.LightPink;
			this.MaxNumBatchesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxNumBatchesTextBox.Location = new System.Drawing.Point(154, 22);
			this.MaxNumBatchesTextBox.MaxValue = 20;
			this.MaxNumBatchesTextBox.MinValue = 3;
			this.MaxNumBatchesTextBox.Name = "MaxNumBatchesTextBox";
			this.MaxNumBatchesTextBox.Required = true;
			this.MaxNumBatchesTextBox.Size = new System.Drawing.Size(49, 20);
			this.MaxNumBatchesTextBox.TabIndex = 0;
			this.MaxNumBatchesTextBox.Text = "0";
			this.MaxNumBatchesTextBox.ToolTip = "";
			this.MaxNumBatchesTextBox.Value = 0;
			// 
			// NumRoundsTextBox
			// 
			this.NumRoundsTextBox.BackColor = System.Drawing.Color.LightPink;
			this.NumRoundsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NumRoundsTextBox.Location = new System.Drawing.Point(154, 47);
			this.NumRoundsTextBox.MaxValue = 100;
			this.NumRoundsTextBox.MinValue = 3;
			this.NumRoundsTextBox.Name = "NumRoundsTextBox";
			this.NumRoundsTextBox.Required = true;
			this.NumRoundsTextBox.Size = new System.Drawing.Size(49, 20);
			this.NumRoundsTextBox.TabIndex = 1;
			this.NumRoundsTextBox.Text = "0";
			this.NumRoundsTextBox.ToolTip = "";
			this.NumRoundsTextBox.Value = 0;
			// 
			// StartingWeightTextBox
			// 
			this.StartingWeightTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.StartingWeightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StartingWeightTextBox.Location = new System.Drawing.Point(154, 72);
			this.StartingWeightTextBox.MaxValue = 100D;
			this.StartingWeightTextBox.MinValue = 0D;
			this.StartingWeightTextBox.Name = "StartingWeightTextBox";
			this.StartingWeightTextBox.NumDecimals = 0;
			this.StartingWeightTextBox.Size = new System.Drawing.Size(49, 20);
			this.StartingWeightTextBox.TabIndex = 2;
			this.StartingWeightTextBox.Text = "0";
			this.StartingWeightTextBox.ToolTip = "";
			this.StartingWeightTextBox.Value = 0D;
			this.StartingWeightTextBox.ZeroAllowed = true;
			// 
			// IncrementTextBox
			// 
			this.IncrementTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.IncrementTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IncrementTextBox.Location = new System.Drawing.Point(154, 97);
			this.IncrementTextBox.MaxValue = 100D;
			this.IncrementTextBox.MinValue = 0D;
			this.IncrementTextBox.Name = "IncrementTextBox";
			this.IncrementTextBox.NumDecimals = 0;
			this.IncrementTextBox.Size = new System.Drawing.Size(49, 20);
			this.IncrementTextBox.TabIndex = 3;
			this.IncrementTextBox.Text = "0";
			this.IncrementTextBox.ToolTip = "";
			this.IncrementTextBox.Value = 0D;
			this.IncrementTextBox.ZeroAllowed = true;
			// 
			// StartingWeightMeasurementLabel
			// 
			this.StartingWeightMeasurementLabel.AutoSize = true;
			this.StartingWeightMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StartingWeightMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.StartingWeightMeasurementLabel.Location = new System.Drawing.Point(209, 75);
			this.StartingWeightMeasurementLabel.Name = "StartingWeightMeasurementLabel";
			this.StartingWeightMeasurementLabel.Size = new System.Drawing.Size(16, 13);
			this.StartingWeightMeasurementLabel.TabIndex = 10;
			this.StartingWeightMeasurementLabel.Text = "gr";
			// 
			// IncrementMeasurementLabel
			// 
			this.IncrementMeasurementLabel.AutoSize = true;
			this.IncrementMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IncrementMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IncrementMeasurementLabel.Location = new System.Drawing.Point(209, 100);
			this.IncrementMeasurementLabel.Name = "IncrementMeasurementLabel";
			this.IncrementMeasurementLabel.Size = new System.Drawing.Size(16, 13);
			this.IncrementMeasurementLabel.TabIndex = 11;
			this.IncrementMeasurementLabel.Text = "gr";
			// 
			// OCWLabel
			// 
			this.OCWLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OCWLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OCWLabel.Location = new System.Drawing.Point(9, 18);
			this.OCWLabel.Name = "OCWLabel";
			this.OCWLabel.Size = new System.Drawing.Size(231, 87);
			this.OCWLabel.TabIndex = 0;
			this.OCWLabel.Text = "Create 5 batches with 5 rounds per batch.";
			// 
			// cOCWForm
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.ClientSize = new System.Drawing.Size(272, 329);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.SettingsGroupBox);
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.OKButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cOCWForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "OCW Batch Settings";
			this.SettingsGroupBox.ResumeLayout(false);
			this.SettingsGroupBox.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

			}

		#endregion

		private CommonLib.Controls.cOKButton OKButton;
		private CommonLib.Controls.cCancelButton FormCancelButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox SettingsGroupBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label IncrementMeasurementLabel;
		private System.Windows.Forms.Label StartingWeightMeasurementLabel;
		private CommonLib.Controls.cDoubleValueTextBox IncrementTextBox;
		private CommonLib.Controls.cDoubleValueTextBox StartingWeightTextBox;
		private CommonLib.Controls.cIntegerValueTextBox NumRoundsTextBox;
		private CommonLib.Controls.cIntegerValueTextBox MaxNumBatchesTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label OCWLabel;
		}
	}