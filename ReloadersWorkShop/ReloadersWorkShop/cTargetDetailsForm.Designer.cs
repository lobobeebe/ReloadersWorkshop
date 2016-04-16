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
			this.label4 = new System.Windows.Forms.Label();
			this.FirearmCombo = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.DatePicker = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.FormCancelButton = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.LocationTextBox = new CommonLib.Controls.cTextBox();
			this.ShooterTextBox = new CommonLib.Controls.cTextBox();
			this.ShotListView = new ReloadersWorkShop.cListView();
			this.ShotHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.OffsetHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.GeneralGroupBox.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKButton
			// 
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Location = new System.Drawing.Point(173, 345);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 0;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			// 
			// GeneralGroupBox
			// 
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
			this.GeneralGroupBox.Size = new System.Drawing.Size(520, 141);
			this.GeneralGroupBox.TabIndex = 1;
			this.GeneralGroupBox.TabStop = false;
			this.GeneralGroupBox.Text = "General";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(27, 105);
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
			this.FirearmCombo.Location = new System.Drawing.Point(77, 102);
			this.FirearmCombo.Name = "FirearmCombo";
			this.FirearmCombo.Size = new System.Drawing.Size(221, 21);
			this.FirearmCombo.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(20, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Location:";
			// 
			// DatePicker
			// 
			this.DatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.DatePicker.Location = new System.Drawing.Point(77, 26);
			this.DatePicker.Name = "DatePicker";
			this.DatePicker.Size = new System.Drawing.Size(107, 20);
			this.DatePicker.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(24, 55);
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
			this.label1.Location = new System.Drawing.Point(38, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Date:";
			// 
			// FormCancelButton
			// 
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Location = new System.Drawing.Point(301, 345);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
			this.FormCancelButton.TabIndex = 2;
			this.FormCancelButton.Text = "Cancel";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ShotListView);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox2.Location = new System.Drawing.Point(12, 159);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(520, 145);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Shot Data";
			// 
			// LocationTextBox
			// 
			this.LocationTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.LocationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LocationTextBox.Location = new System.Drawing.Point(77, 77);
			this.LocationTextBox.Name = "LocationTextBox";
			this.LocationTextBox.Required = false;
			this.LocationTextBox.Size = new System.Drawing.Size(221, 20);
			this.LocationTextBox.TabIndex = 6;
			this.LocationTextBox.ToolTip = "";
			this.LocationTextBox.Value = "";
			// 
			// ShooterTextBox
			// 
			this.ShooterTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.ShooterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShooterTextBox.Location = new System.Drawing.Point(77, 52);
			this.ShooterTextBox.Name = "ShooterTextBox";
			this.ShooterTextBox.Required = false;
			this.ShooterTextBox.Size = new System.Drawing.Size(186, 20);
			this.ShooterTextBox.TabIndex = 4;
			this.ShooterTextBox.ToolTip = "";
			this.ShooterTextBox.Value = "";
			// 
			// ShotListView
			// 
			this.ShotListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ShotHeader,
            this.OffsetHeader});
			this.ShotListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShotListView.Location = new System.Drawing.Point(6, 19);
			this.ShotListView.Name = "ShotListView";
			this.ShotListView.Size = new System.Drawing.Size(508, 110);
			this.ShotListView.SortingColumn = 0;
			this.ShotListView.SortingOrder = System.Windows.Forms.SortOrder.Ascending;
			this.ShotListView.TabIndex = 3;
			this.ShotListView.UseCompatibleStateImageBehavior = false;
			this.ShotListView.View = System.Windows.Forms.View.Details;
			// 
			// ShotHeader
			// 
			this.ShotHeader.Text = "Shot #";
			// 
			// OffsetHeader
			// 
			this.OffsetHeader.Text = "Offset";
			this.OffsetHeader.Width = 200;
			// 
			// cTargetDetailsForm
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.ClientSize = new System.Drawing.Size(548, 382);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.GeneralGroupBox);
			this.Controls.Add(this.OKButton);
			this.Name = "cTargetDetailsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Target Details";
			this.GeneralGroupBox.ResumeLayout(false);
			this.GeneralGroupBox.PerformLayout();
			this.groupBox2.ResumeLayout(false);
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
		private cListView ShotListView;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ColumnHeader ShotHeader;
		private System.Windows.Forms.ColumnHeader OffsetHeader;
		}
	}