namespace ReloadersWorkShop
	{
	partial class cReleaseNotesForm
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
			this.ContinueButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ContinueButton.Location = new System.Drawing.Point(292, 563);
			this.ContinueButton.Name = "ContinueButton";
			this.ContinueButton.Size = new System.Drawing.Size(75, 23);
			this.ContinueButton.TabIndex = 1;
			this.ContinueButton.Text = "Close";
			this.ContinueButton.UseVisualStyleBackColor = true;
			// 
			// ReleaseNotesTextBox
			// 
			this.ReleaseNotesTextBox.Location = new System.Drawing.Point(12, 12);
			this.ReleaseNotesTextBox.Name = "ReleaseNotesTextBox";
			this.ReleaseNotesTextBox.Size = new System.Drawing.Size(634, 545);
			this.ReleaseNotesTextBox.TabIndex = 2;
			this.ReleaseNotesTextBox.Text = "";
			// 
			// cReleaseNotesForm
			// 
			this.AcceptButton = this.ContinueButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.ContinueButton;
			this.ClientSize = new System.Drawing.Size(658, 601);
			this.ControlBox = false;
			this.Controls.Add(this.ReleaseNotesTextBox);
			this.Controls.Add(this.ContinueButton);
			this.Name = "cReleaseNotesForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Release Notes";
			this.ResumeLayout(false);

			}

		#endregion
		private System.Windows.Forms.Button ContinueButton;
		private System.Windows.Forms.RichTextBox ReleaseNotesTextBox;
		}
	}