namespace ReloadersWorkShopUpdater
	{
	partial class MainForm
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
			this.ReleaseNotesTextBox = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// ContinueButton
			// 
			this.ContinueButton.Location = new System.Drawing.Point(290, 568);
			this.ContinueButton.Name = "ContinueButton";
			this.ContinueButton.Size = new System.Drawing.Size(75, 23);
			this.ContinueButton.TabIndex = 0;
			this.ContinueButton.Text = "Continue";
			this.ContinueButton.UseVisualStyleBackColor = true;
			// 
			// ReleaseNotesTextBox
			// 
			this.ReleaseNotesTextBox.Location = new System.Drawing.Point(12, 12);
			this.ReleaseNotesTextBox.Name = "ReleaseNotesTextBox";
			this.ReleaseNotesTextBox.Size = new System.Drawing.Size(630, 550);
			this.ReleaseNotesTextBox.TabIndex = 1;
			this.ReleaseNotesTextBox.Text = "";
			// 
			// MainForm
			// 
			this.AcceptButton = this.ContinueButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(654, 609);
			this.ControlBox = false;
			this.Controls.Add(this.ReleaseNotesTextBox);
			this.Controls.Add(this.ContinueButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Release Notes";
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.Button ContinueButton;
		private System.Windows.Forms.RichTextBox ReleaseNotesTextBox;
		}
	}

