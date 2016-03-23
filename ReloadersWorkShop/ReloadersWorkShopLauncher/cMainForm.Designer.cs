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
			this.ActivateButton = new System.Windows.Forms.Button();
			this.RegistrationLabel = new System.Windows.Forms.Label();
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
			// ActivateButton
			// 
			this.ActivateButton.AutoSize = true;
			this.ActivateButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ActivateButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ActivateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ActivateButton.ForeColor = System.Drawing.Color.Yellow;
			this.ActivateButton.Location = new System.Drawing.Point(275, 380);
			this.ActivateButton.Name = "ActivateButton";
			this.ActivateButton.Size = new System.Drawing.Size(77, 28);
			this.ActivateButton.TabIndex = 2;
			this.ActivateButton.Text = "Activate";
			this.ActivateButton.UseVisualStyleBackColor = false;
			// 
			// RegistrationLabel
			// 
			this.RegistrationLabel.AutoSize = true;
			this.RegistrationLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.RegistrationLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.RegistrationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RegistrationLabel.ForeColor = System.Drawing.Color.Yellow;
			this.RegistrationLabel.Location = new System.Drawing.Point(254, 335);
			this.RegistrationLabel.Name = "RegistrationLabel";
			this.RegistrationLabel.Size = new System.Drawing.Size(53, 22);
			this.RegistrationLabel.TabIndex = 3;
			this.RegistrationLabel.Text = "label1";
			// 
			// cMainForm
			// 
			this.AcceptButton = this.ContinueButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.ExitButton;
			this.ClientSize = new System.Drawing.Size(683, 468);
			this.ControlBox = false;
			this.Controls.Add(this.RegistrationLabel);
			this.Controls.Add(this.ActivateButton);
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
		private System.Windows.Forms.Button ActivateButton;
		private System.Windows.Forms.Label RegistrationLabel;
		}
	}

