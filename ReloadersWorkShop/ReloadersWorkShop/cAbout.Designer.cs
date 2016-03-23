namespace ReloadersWorkShop
	{
	partial class AboutDialog
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
			this.VersionLabel = new System.Windows.Forms.Label();
			this.CopyrightLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.CloseButton = new System.Windows.Forms.Button();
			this.RegistrationLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// VersionLabel
			// 
			this.VersionLabel.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.VersionLabel.ForeColor = System.Drawing.Color.RoyalBlue;
			this.VersionLabel.Location = new System.Drawing.Point(6, 24);
			this.VersionLabel.Name = "VersionLabel";
			this.VersionLabel.Size = new System.Drawing.Size(440, 23);
			this.VersionLabel.TabIndex = 0;
			this.VersionLabel.Text = "Version";
			this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// CopyrightLabel
			// 
			this.CopyrightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CopyrightLabel.Location = new System.Drawing.Point(12, 66);
			this.CopyrightLabel.Name = "CopyrightLabel";
			this.CopyrightLabel.Size = new System.Drawing.Size(440, 23);
			this.CopyrightLabel.TabIndex = 1;
			this.CopyrightLabel.Text = "Copyright © 2015, Kevin S. Beebe";
			this.CopyrightLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 94);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(440, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "All Rights Reserved";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// CloseButton
			// 
			this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CloseButton.Location = new System.Drawing.Point(195, 235);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(75, 23);
			this.CloseButton.TabIndex = 3;
			this.CloseButton.Text = "Close";
			this.CloseButton.UseVisualStyleBackColor = true;
			// 
			// RegistrationLabel
			// 
			this.RegistrationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RegistrationLabel.Location = new System.Drawing.Point(12, 163);
			this.RegistrationLabel.Name = "RegistrationLabel";
			this.RegistrationLabel.Size = new System.Drawing.Size(440, 23);
			this.RegistrationLabel.TabIndex = 4;
			this.RegistrationLabel.Text = "Registered to:";
			this.RegistrationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// AboutDialog
			// 
			this.AcceptButton = this.CloseButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
			this.CancelButton = this.CloseButton;
			this.ClientSize = new System.Drawing.Size(452, 274);
			this.ControlBox = false;
			this.Controls.Add(this.RegistrationLabel);
			this.Controls.Add(this.CloseButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.CopyrightLabel);
			this.Controls.Add(this.VersionLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About Reloader\'s WorkShop";
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.Label VersionLabel;
		private System.Windows.Forms.Label CopyrightLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button CloseButton;
		private System.Windows.Forms.Label RegistrationLabel;
		}
	}