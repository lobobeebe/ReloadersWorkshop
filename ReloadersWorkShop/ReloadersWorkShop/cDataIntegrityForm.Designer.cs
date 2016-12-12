namespace ReloadersWorkShop
	{
	partial class cDataIntegrityForm
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
			this.SummaryGroupBox = new System.Windows.Forms.GroupBox();
			this.SummaryTextBox = new CommonLib.Controls.cTextBox();
			this.SummaryGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKButton
			// 
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.OKButton.Location = new System.Drawing.Point(226, 455);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 0;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			// 
			// SummaryGroupBox
			// 
			this.SummaryGroupBox.Controls.Add(this.SummaryTextBox);
			this.SummaryGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SummaryGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.SummaryGroupBox.Location = new System.Drawing.Point(12, 12);
			this.SummaryGroupBox.Name = "SummaryGroupBox";
			this.SummaryGroupBox.Size = new System.Drawing.Size(502, 423);
			this.SummaryGroupBox.TabIndex = 1;
			this.SummaryGroupBox.TabStop = false;
			this.SummaryGroupBox.Text = "Summary";
			// 
			// SummaryTextBox
			// 
			this.SummaryTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.SummaryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SummaryTextBox.Location = new System.Drawing.Point(6, 21);
			this.SummaryTextBox.Multiline = true;
			this.SummaryTextBox.Name = "SummaryTextBox";
			this.SummaryTextBox.Required = false;
			this.SummaryTextBox.Size = new System.Drawing.Size(490, 396);
			this.SummaryTextBox.TabIndex = 0;
			this.SummaryTextBox.ToolTip = "";
			this.SummaryTextBox.ValidChars = "";
			this.SummaryTextBox.Value = "";
			// 
			// cDataIntegrityForm
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.OKButton;
			this.ClientSize = new System.Drawing.Size(526, 512);
			this.ControlBox = false;
			this.Controls.Add(this.SummaryGroupBox);
			this.Controls.Add(this.OKButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cDataIntegrityForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Data Integrity Test Results";
			this.SummaryGroupBox.ResumeLayout(false);
			this.SummaryGroupBox.PerformLayout();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.GroupBox SummaryGroupBox;
		private CommonLib.Controls.cTextBox SummaryTextBox;
		}
	}