namespace ReloadersWorkShop
	{
	partial class cTargetDetailsForm
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
            this.GeneralGroupBox = new System.Windows.Forms.GroupBox();
            this.NotesTextBox = new CommonLib.Controls.cTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.EventTextBox = new CommonLib.Controls.cTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FirearmCombo = new System.Windows.Forms.ComboBox();
            this.LocationTextBox = new CommonLib.Controls.cTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ShooterTextBox = new CommonLib.Controls.cTextBox();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FormCancelButton = new System.Windows.Forms.Button();
            this.ShotDataGroupBox = new System.Windows.Forms.GroupBox();
            this.GeneralGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(211, 404);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // GeneralGroupBox
            // 
            this.GeneralGroupBox.Controls.Add(this.NotesTextBox);
            this.GeneralGroupBox.Controls.Add(this.label6);
            this.GeneralGroupBox.Controls.Add(this.EventTextBox);
            this.GeneralGroupBox.Controls.Add(this.label5);
            this.GeneralGroupBox.Controls.Add(this.label4);
            this.GeneralGroupBox.Controls.Add(this.FirearmCombo);
            this.GeneralGroupBox.Controls.Add(this.LocationTextBox);
            this.GeneralGroupBox.Controls.Add(this.label3);
            this.GeneralGroupBox.Controls.Add(this.ShooterTextBox);
            this.GeneralGroupBox.Controls.Add(this.DatePicker);
            this.GeneralGroupBox.Controls.Add(this.label2);
            this.GeneralGroupBox.Controls.Add(this.label1);
            this.GeneralGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneralGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.GeneralGroupBox.Location = new System.Drawing.Point(12, 12);
            this.GeneralGroupBox.Name = "GeneralGroupBox";
            this.GeneralGroupBox.Size = new System.Drawing.Size(598, 180);
            this.GeneralGroupBox.TabIndex = 0;
            this.GeneralGroupBox.TabStop = false;
            this.GeneralGroupBox.Text = "General";
            // 
            // NotesTextBox
            // 
            this.NotesTextBox.AcceptsReturn = true;
            this.NotesTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.NotesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotesTextBox.Location = new System.Drawing.Point(64, 105);
            this.NotesTextBox.MaxLength = 1000;
            this.NotesTextBox.Multiline = true;
            this.NotesTextBox.Name = "NotesTextBox";
            this.NotesTextBox.Required = false;
            this.NotesTextBox.Size = new System.Drawing.Size(511, 69);
            this.NotesTextBox.TabIndex = 5;
            this.NotesTextBox.ToolTip = "";
            this.NotesTextBox.Value = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(20, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Notes:";
            // 
            // EventTextBox
            // 
            this.EventTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.EventTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventTextBox.Location = new System.Drawing.Point(354, 78);
            this.EventTextBox.MaxLength = 35;
            this.EventTextBox.Name = "EventTextBox";
            this.EventTextBox.Required = false;
            this.EventTextBox.Size = new System.Drawing.Size(221, 20);
            this.EventTextBox.TabIndex = 4;
            this.EventTextBox.ToolTip = "";
            this.EventTextBox.Value = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(310, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Event:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(14, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Firearm:";
            // 
            // FirearmCombo
            // 
            this.FirearmCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FirearmCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirearmCombo.FormattingEnabled = true;
            this.FirearmCombo.Location = new System.Drawing.Point(64, 78);
            this.FirearmCombo.Name = "FirearmCombo";
            this.FirearmCombo.Size = new System.Drawing.Size(221, 21);
            this.FirearmCombo.TabIndex = 2;
            // 
            // LocationTextBox
            // 
            this.LocationTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.LocationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocationTextBox.Location = new System.Drawing.Point(354, 52);
            this.LocationTextBox.MaxLength = 35;
            this.LocationTextBox.Name = "LocationTextBox";
            this.LocationTextBox.Required = false;
            this.LocationTextBox.Size = new System.Drawing.Size(221, 20);
            this.LocationTextBox.TabIndex = 3;
            this.LocationTextBox.ToolTip = "";
            this.LocationTextBox.Value = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(297, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Location:";
            // 
            // ShooterTextBox
            // 
            this.ShooterTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.ShooterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShooterTextBox.Location = new System.Drawing.Point(64, 52);
            this.ShooterTextBox.MaxLength = 35;
            this.ShooterTextBox.Name = "ShooterTextBox";
            this.ShooterTextBox.Required = false;
            this.ShooterTextBox.Size = new System.Drawing.Size(186, 20);
            this.ShooterTextBox.TabIndex = 1;
            this.ShooterTextBox.ToolTip = "";
            this.ShooterTextBox.Value = "";
            // 
            // DatePicker
            // 
            this.DatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatePicker.Location = new System.Drawing.Point(64, 26);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(107, 20);
            this.DatePicker.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(11, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Shooter:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date:";
            // 
            // FormCancelButton
            // 
            this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.FormCancelButton.Location = new System.Drawing.Point(339, 404);
            this.FormCancelButton.Name = "FormCancelButton";
            this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
            this.FormCancelButton.TabIndex = 3;
            this.FormCancelButton.Text = "Cancel";
            this.FormCancelButton.UseVisualStyleBackColor = true;
            // 
            // ShotDataGroupBox
            // 
            this.ShotDataGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShotDataGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ShotDataGroupBox.Location = new System.Drawing.Point(12, 198);
            this.ShotDataGroupBox.Name = "ShotDataGroupBox";
            this.ShotDataGroupBox.Size = new System.Drawing.Size(598, 189);
            this.ShotDataGroupBox.TabIndex = 1;
            this.ShotDataGroupBox.TabStop = false;
            this.ShotDataGroupBox.Text = "Shot Data";
            // 
            // cTargetDetailsForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.FormCancelButton;
            this.ClientSize = new System.Drawing.Size(625, 439);
            this.ControlBox = false;
            this.Controls.Add(this.ShotDataGroupBox);
            this.Controls.Add(this.FormCancelButton);
            this.Controls.Add(this.GeneralGroupBox);
            this.Controls.Add(this.OKButton);
            this.Name = "cTargetDetailsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Target Details";
            this.GeneralGroupBox.ResumeLayout(false);
            this.GeneralGroupBox.PerformLayout();
            this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.GroupBox GeneralGroupBox;
		private CommonLib.Controls.cTextBox ShooterTextBox;
		private System.Windows.Forms.DateTimePicker DatePicker;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox FirearmCombo;
		private CommonLib.Controls.cTextBox LocationTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button FormCancelButton;
		private System.Windows.Forms.GroupBox ShotDataGroupBox;
		private CommonLib.Controls.cTextBox NotesTextBox;
		private System.Windows.Forms.Label label6;
		private CommonLib.Controls.cTextBox EventTextBox;
		private System.Windows.Forms.Label label5;
		}
	}