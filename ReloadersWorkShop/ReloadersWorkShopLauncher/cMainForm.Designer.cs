namespace ReloadersWorkShopLauncher
	{
	partial class cMainForm
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
			this.ContinueButton = new System.Windows.Forms.Button();
			this.ExitButton = new System.Windows.Forms.Button();
			this.CopyrightLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ContinueButton
			// 
			this.ContinueButton.AutoSize = true;
			this.ContinueButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ContinueButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ContinueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ContinueButton.ForeColor = System.Drawing.Color.Yellow;
			this.ContinueButton.Location = new System.Drawing.Point(128, 380);
			this.ContinueButton.Name = "ContinueButton";
			this.ContinueButton.Size = new System.Drawing.Size(85, 28);
			this.ContinueButton.TabIndex = 0;
			this.ContinueButton.Text = "Continue";
			this.ContinueButton.UseVisualStyleBackColor = false;
			// 
			// ExitButton
			// 
			this.ExitButton.AutoSize = true;
			this.ExitButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ExitButton.ForeColor = System.Drawing.Color.Yellow;
			this.ExitButton.Location = new System.Drawing.Point(425, 380);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.Size = new System.Drawing.Size(75, 28);
			this.ExitButton.TabIndex = 1;
			this.ExitButton.Text = "Exit";
			this.ExitButton.UseVisualStyleBackColor = false;
			// 
			// CopyrightLabel
			// 
			this.CopyrightLabel.AutoSize = true;
			this.CopyrightLabel.BackColor = System.Drawing.Color.Transparent;
			this.CopyrightLabel.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CopyrightLabel.ForeColor = System.Drawing.Color.White;
			this.CopyrightLabel.Location = new System.Drawing.Point(218, 220);
			this.CopyrightLabel.Name = "CopyrightLabel";
			this.CopyrightLabel.Size = new System.Drawing.Size(321, 19);
			this.CopyrightLabel.TabIndex = 4;
			this.CopyrightLabel.Text = "Copyright © 2013-2018, Kevin S. Beebe";
			// 
			// cMainForm
			// 
			this.AcceptButton = this.ContinueButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.ExitButton;
			this.ClientSize = new System.Drawing.Size(683, 468);
			this.ControlBox = false;
			this.Controls.Add(this.CopyrightLabel);
			this.Controls.Add(this.ExitButton);
			this.Controls.Add(this.ContinueButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cMainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Reloader\'s WorkShop Launcher";
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.Button ContinueButton;
		private System.Windows.Forms.Button ExitButton;
		private System.Windows.Forms.Label CopyrightLabel;
		}
	}

