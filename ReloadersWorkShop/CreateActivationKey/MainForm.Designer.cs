namespace CreateActivationKey
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
			this.label1 = new System.Windows.Forms.Label();
			this.CloseButton = new System.Windows.Forms.Button();
			this.GetKeyButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.KeyLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.ValidatedLabel = new System.Windows.Forms.Label();
			this.SendButton = new System.Windows.Forms.Button();
			this.AddLicenseButton = new System.Windows.Forms.Button();
			this.LicenseCountLabel = new System.Windows.Forms.Label();
			this.VersionTextBox = new CommonLib.Controls.cTextBox();
			this.EmailTextBox = new CommonLib.Controls.cTextBox();
			this.NameTextBox = new CommonLib.Controls.cTextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(37, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "User Name";
			// 
			// CloseButton
			// 
			this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CloseButton.Location = new System.Drawing.Point(382, 165);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(75, 23);
			this.CloseButton.TabIndex = 4;
			this.CloseButton.Text = "Close";
			this.CloseButton.UseVisualStyleBackColor = true;
			// 
			// GetKeyButton
			// 
			this.GetKeyButton.Location = new System.Drawing.Point(67, 165);
			this.GetKeyButton.Name = "GetKeyButton";
			this.GetKeyButton.Size = new System.Drawing.Size(75, 23);
			this.GetKeyButton.TabIndex = 3;
			this.GetKeyButton.Text = "GetKey";
			this.GetKeyButton.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(40, 65);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "User Email";
			// 
			// KeyLabel
			// 
			this.KeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.KeyLabel.Location = new System.Drawing.Point(12, 101);
			this.KeyLabel.Name = "KeyLabel";
			this.KeyLabel.Size = new System.Drawing.Size(389, 23);
			this.KeyLabel.TabIndex = 6;
			this.KeyLabel.Text = "Key goes here";
			this.KeyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(55, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Version";
			// 
			// ValidatedLabel
			// 
			this.ValidatedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ValidatedLabel.Location = new System.Drawing.Point(12, 133);
			this.ValidatedLabel.Name = "ValidatedLabel";
			this.ValidatedLabel.Size = new System.Drawing.Size(389, 23);
			this.ValidatedLabel.TabIndex = 8;
			this.ValidatedLabel.Text = "Validation goes here";
			this.ValidatedLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// SendButton
			// 
			this.SendButton.Location = new System.Drawing.Point(169, 165);
			this.SendButton.Name = "SendButton";
			this.SendButton.Size = new System.Drawing.Size(75, 23);
			this.SendButton.TabIndex = 9;
			this.SendButton.Text = "Send";
			this.SendButton.UseVisualStyleBackColor = true;
			// 
			// AddLicenseButton
			// 
			this.AddLicenseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.AddLicenseButton.Location = new System.Drawing.Point(279, 165);
			this.AddLicenseButton.Name = "AddLicenseButton";
			this.AddLicenseButton.Size = new System.Drawing.Size(75, 23);
			this.AddLicenseButton.TabIndex = 10;
			this.AddLicenseButton.Text = "Add License";
			this.AddLicenseButton.UseVisualStyleBackColor = true;
			// 
			// LicenseCountLabel
			// 
			this.LicenseCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LicenseCountLabel.Location = new System.Drawing.Point(407, 12);
			this.LicenseCountLabel.Name = "LicenseCountLabel";
			this.LicenseCountLabel.Size = new System.Drawing.Size(327, 73);
			this.LicenseCountLabel.TabIndex = 11;
			this.LicenseCountLabel.Text = "Num Licenses Here";
			this.LicenseCountLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// VersionTextBox
			// 
			this.VersionTextBox.BackColor = System.Drawing.Color.LightPink;
			this.VersionTextBox.Location = new System.Drawing.Point(103, 12);
			this.VersionTextBox.MaxLength = 60;
			this.VersionTextBox.Name = "VersionTextBox";
			this.VersionTextBox.Required = true;
			this.VersionTextBox.Size = new System.Drawing.Size(298, 20);
			this.VersionTextBox.TabIndex = 0;
			this.VersionTextBox.ToolTip = "";
			this.VersionTextBox.Value = "";
			// 
			// EmailTextBox
			// 
			this.EmailTextBox.BackColor = System.Drawing.Color.LightPink;
			this.EmailTextBox.Location = new System.Drawing.Point(103, 62);
			this.EmailTextBox.MaxLength = 60;
			this.EmailTextBox.Name = "EmailTextBox";
			this.EmailTextBox.Required = true;
			this.EmailTextBox.Size = new System.Drawing.Size(298, 20);
			this.EmailTextBox.TabIndex = 2;
			this.EmailTextBox.ToolTip = "";
			this.EmailTextBox.Value = "";
			// 
			// NameTextBox
			// 
			this.NameTextBox.BackColor = System.Drawing.Color.LightPink;
			this.NameTextBox.Location = new System.Drawing.Point(103, 37);
			this.NameTextBox.MaxLength = 60;
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Required = true;
			this.NameTextBox.Size = new System.Drawing.Size(298, 20);
			this.NameTextBox.TabIndex = 1;
			this.NameTextBox.ToolTip = "";
			this.NameTextBox.Value = "";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CloseButton;
			this.ClientSize = new System.Drawing.Size(760, 210);
			this.Controls.Add(this.LicenseCountLabel);
			this.Controls.Add(this.AddLicenseButton);
			this.Controls.Add(this.SendButton);
			this.Controls.Add(this.ValidatedLabel);
			this.Controls.Add(this.VersionTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.KeyLabel);
			this.Controls.Add(this.EmailTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.GetKeyButton);
			this.Controls.Add(this.CloseButton);
			this.Controls.Add(this.NameTextBox);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Create Activation Key";
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.Label label1;
		private CommonLib.Controls.cTextBox NameTextBox;
		private System.Windows.Forms.Button CloseButton;
		private System.Windows.Forms.Button GetKeyButton;
		private CommonLib.Controls.cTextBox EmailTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label KeyLabel;
		private CommonLib.Controls.cTextBox VersionTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label ValidatedLabel;
		private System.Windows.Forms.Button SendButton;
		private System.Windows.Forms.Button AddLicenseButton;
		private System.Windows.Forms.Label LicenseCountLabel;
		}
	}

