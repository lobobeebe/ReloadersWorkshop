namespace ReloadersWorkShopLauncher
	{
	partial class cActivationForm
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
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.CloseButton = new System.Windows.Forms.Button();
			this.OKButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.KeyGroup = new System.Windows.Forms.GroupBox();
			this.NameTextBox = new CommonLib.Controls.cTextBox();
			this.KeyTextBox = new CommonLib.Controls.cTextBox();
			this.EmailTextBox = new CommonLib.Controls.cTextBox();
			this.PurchaseGroup = new System.Windows.Forms.GroupBox();
			this.PurchaseButton = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.KeyGroup.SuspendLayout();
			this.PurchaseGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(85, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Email:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(82, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Name:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(42, 77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Activation Key:";
			// 
			// CloseButton
			// 
			this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CloseButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CloseButton.Location = new System.Drawing.Point(251, 167);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(75, 23);
			this.CloseButton.TabIndex = 11;
			this.CloseButton.Text = "Cancel";
			this.CloseButton.UseVisualStyleBackColor = true;
			// 
			// OKButton
			// 
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OKButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OKButton.Location = new System.Drawing.Point(135, 167);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 12;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(11, 117);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(438, 49);
			this.label4.TabIndex = 13;
			this.label4.Text = "Enter your Activation Key and other data above EXACTLY the way it appears on the " +
    "email you received. (Case Sensitive)";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// KeyGroup
			// 
			this.KeyGroup.Controls.Add(this.label1);
			this.KeyGroup.Controls.Add(this.label4);
			this.KeyGroup.Controls.Add(this.label2);
			this.KeyGroup.Controls.Add(this.OKButton);
			this.KeyGroup.Controls.Add(this.label3);
			this.KeyGroup.Controls.Add(this.CloseButton);
			this.KeyGroup.Controls.Add(this.NameTextBox);
			this.KeyGroup.Controls.Add(this.KeyTextBox);
			this.KeyGroup.Controls.Add(this.EmailTextBox);
			this.KeyGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.KeyGroup.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.KeyGroup.Location = new System.Drawing.Point(12, 12);
			this.KeyGroup.Name = "KeyGroup";
			this.KeyGroup.Size = new System.Drawing.Size(455, 210);
			this.KeyGroup.TabIndex = 14;
			this.KeyGroup.TabStop = false;
			this.KeyGroup.Text = "Enter Activation Key";
			// 
			// NameTextBox
			// 
			this.NameTextBox.BackColor = System.Drawing.Color.LightPink;
			this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NameTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.NameTextBox.Location = new System.Drawing.Point(126, 22);
			this.NameTextBox.MaxLength = 60;
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Required = true;
			this.NameTextBox.Size = new System.Drawing.Size(300, 20);
			this.NameTextBox.TabIndex = 8;
			this.NameTextBox.ToolTip = "";
			this.NameTextBox.Value = "";
			// 
			// KeyTextBox
			// 
			this.KeyTextBox.AllowDrop = true;
			this.KeyTextBox.BackColor = System.Drawing.Color.LightPink;
			this.KeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.KeyTextBox.Location = new System.Drawing.Point(126, 74);
			this.KeyTextBox.MaxLength = 60;
			this.KeyTextBox.Name = "KeyTextBox";
			this.KeyTextBox.Required = true;
			this.KeyTextBox.Size = new System.Drawing.Size(300, 20);
			this.KeyTextBox.TabIndex = 10;
			this.KeyTextBox.ToolTip = "";
			this.KeyTextBox.Value = "";
			// 
			// EmailTextBox
			// 
			this.EmailTextBox.BackColor = System.Drawing.Color.LightPink;
			this.EmailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EmailTextBox.Location = new System.Drawing.Point(126, 48);
			this.EmailTextBox.MaxLength = 255;
			this.EmailTextBox.Name = "EmailTextBox";
			this.EmailTextBox.Required = true;
			this.EmailTextBox.Size = new System.Drawing.Size(300, 20);
			this.EmailTextBox.TabIndex = 9;
			this.EmailTextBox.ToolTip = "";
			this.EmailTextBox.Value = "";
			// 
			// PurchaseGroup
			// 
			this.PurchaseGroup.Controls.Add(this.PurchaseButton);
			this.PurchaseGroup.Controls.Add(this.label5);
			this.PurchaseGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PurchaseGroup.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.PurchaseGroup.Location = new System.Drawing.Point(12, 228);
			this.PurchaseGroup.Name = "PurchaseGroup";
			this.PurchaseGroup.Size = new System.Drawing.Size(455, 110);
			this.PurchaseGroup.TabIndex = 15;
			this.PurchaseGroup.TabStop = false;
			this.PurchaseGroup.Text = "Don\'t have an Activation Key?";
			// 
			// PurchaseButton
			// 
			this.PurchaseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PurchaseButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PurchaseButton.Location = new System.Drawing.Point(143, 65);
			this.PurchaseButton.Name = "PurchaseButton";
			this.PurchaseButton.Size = new System.Drawing.Size(169, 23);
			this.PurchaseButton.TabIndex = 15;
			this.PurchaseButton.Text = "Purchase Activation Key";
			this.PurchaseButton.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(6, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(438, 30);
			this.label5.TabIndex = 14;
			this.label5.Text = "Click the Purchase Button below for instructions on how to get one.";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// cActivationForm
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CloseButton;
			this.ClientSize = new System.Drawing.Size(478, 350);
			this.ControlBox = false;
			this.Controls.Add(this.PurchaseGroup);
			this.Controls.Add(this.KeyGroup);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "cActivationForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Activation Key";
			this.KeyGroup.ResumeLayout(false);
			this.KeyGroup.PerformLayout();
			this.PurchaseGroup.ResumeLayout(false);
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private CommonLib.Controls.cTextBox NameTextBox;
		private CommonLib.Controls.cTextBox EmailTextBox;
		private CommonLib.Controls.cTextBox KeyTextBox;
		private System.Windows.Forms.Button CloseButton;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox KeyGroup;
		private System.Windows.Forms.GroupBox PurchaseGroup;
		private System.Windows.Forms.Button PurchaseButton;
		private System.Windows.Forms.Label label5;
		}
	}