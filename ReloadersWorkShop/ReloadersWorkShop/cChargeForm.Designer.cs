namespace ReloadersWorkShop
	{
	partial class cChargeForm
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
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label13;
			System.Windows.Forms.Label label11;
			System.Windows.Forms.Label label9;
			System.Windows.Forms.Label label7;
			System.Windows.Forms.Label label5;
			this.ChargeMeasurementLabel = new System.Windows.Forms.Label();
			this.FirearmTypeLabel = new System.Windows.Forms.Label();
			this.LoadDataGroupBox = new System.Windows.Forms.GroupBox();
			this.FillRatioTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.PowderWeightTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.RejectRadioButton = new System.Windows.Forms.RadioButton();
			this.FavoriteRadioButton = new System.Windows.Forms.RadioButton();
			this.ErrorMessageLabel = new System.Windows.Forms.Label();
			this.CaseLabel = new System.Windows.Forms.Label();
			this.PrimerLabel = new System.Windows.Forms.Label();
			this.PowderLabel = new System.Windows.Forms.Label();
			this.BulletLabel = new System.Windows.Forms.Label();
			this.CaliberLabel = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.RemoveChargeTestButton = new System.Windows.Forms.Button();
			this.EditChargeTestButton = new System.Windows.Forms.Button();
			this.AddChargeTestButton = new System.Windows.Forms.Button();
			this.ChargeTestListView = new System.Windows.Forms.ListView();
			this.SourceHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.BarrelLengthHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.TwistHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.MuzzleVelocityHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.PressureHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.BestGroupHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.RangeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ChargeOKButton = new System.Windows.Forms.Button();
			this.ChargeCancelButton = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			this.LoadDataGroupBox.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label1.ForeColor = System.Drawing.SystemColors.ControlText;
			label1.Location = new System.Drawing.Point(21, 24);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(71, 13);
			label1.TabIndex = 0;
			label1.Text = "Firearm Type:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label3.ForeColor = System.Drawing.SystemColors.ControlText;
			label3.Location = new System.Drawing.Point(51, 49);
			label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(42, 13);
			label3.TabIndex = 2;
			label3.Text = "Caliber:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label4.ForeColor = System.Drawing.SystemColors.ControlText;
			label4.Location = new System.Drawing.Point(362, 130);
			label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(15, 13);
			label4.TabIndex = 16;
			label4.Text = "%";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label2.ForeColor = System.Drawing.SystemColors.ControlText;
			label2.Location = new System.Drawing.Point(264, 130);
			label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(50, 13);
			label2.TabIndex = 1;
			label2.Text = "Fill Ratio:";
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label13.ForeColor = System.Drawing.SystemColors.ControlText;
			label13.Location = new System.Drawing.Point(101, 130);
			label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(83, 13);
			label13.TabIndex = 12;
			label13.Text = "Powder Weight:";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label11.ForeColor = System.Drawing.SystemColors.ControlText;
			label11.Location = new System.Drawing.Point(310, 98);
			label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(34, 13);
			label11.TabIndex = 10;
			label11.Text = "Case:";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label9.ForeColor = System.Drawing.SystemColors.ControlText;
			label9.Location = new System.Drawing.Point(303, 73);
			label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(39, 13);
			label9.TabIndex = 8;
			label9.Text = "Primer:";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label7.ForeColor = System.Drawing.SystemColors.ControlText;
			label7.Location = new System.Drawing.Point(49, 98);
			label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(46, 13);
			label7.TabIndex = 6;
			label7.Text = "Powder:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label5.ForeColor = System.Drawing.SystemColors.ControlText;
			label5.Location = new System.Drawing.Point(58, 73);
			label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(36, 13);
			label5.TabIndex = 4;
			label5.Text = "Bullet:";
			// 
			// ChargeMeasurementLabel
			// 
			this.ChargeMeasurementLabel.AutoSize = true;
			this.ChargeMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ChargeMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ChargeMeasurementLabel.Location = new System.Drawing.Point(244, 130);
			this.ChargeMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.ChargeMeasurementLabel.Name = "ChargeMeasurementLabel";
			this.ChargeMeasurementLabel.Size = new System.Drawing.Size(16, 13);
			this.ChargeMeasurementLabel.TabIndex = 20;
			this.ChargeMeasurementLabel.Text = "gr";
			// 
			// FirearmTypeLabel
			// 
			this.FirearmTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FirearmTypeLabel.ForeColor = System.Drawing.SystemColors.WindowText;
			this.FirearmTypeLabel.Location = new System.Drawing.Point(98, 24);
			this.FirearmTypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.FirearmTypeLabel.Name = "FirearmTypeLabel";
			this.FirearmTypeLabel.Size = new System.Drawing.Size(101, 19);
			this.FirearmTypeLabel.TabIndex = 1;
			this.FirearmTypeLabel.Text = "eFirearmType";
			// 
			// LoadDataGroupBox
			// 
			this.LoadDataGroupBox.Controls.Add(this.FillRatioTextBox);
			this.LoadDataGroupBox.Controls.Add(this.ChargeMeasurementLabel);
			this.LoadDataGroupBox.Controls.Add(this.PowderWeightTextBox);
			this.LoadDataGroupBox.Controls.Add(this.RejectRadioButton);
			this.LoadDataGroupBox.Controls.Add(this.FavoriteRadioButton);
			this.LoadDataGroupBox.Controls.Add(this.ErrorMessageLabel);
			this.LoadDataGroupBox.Controls.Add(label4);
			this.LoadDataGroupBox.Controls.Add(label2);
			this.LoadDataGroupBox.Controls.Add(label13);
			this.LoadDataGroupBox.Controls.Add(this.CaseLabel);
			this.LoadDataGroupBox.Controls.Add(label11);
			this.LoadDataGroupBox.Controls.Add(this.PrimerLabel);
			this.LoadDataGroupBox.Controls.Add(label9);
			this.LoadDataGroupBox.Controls.Add(this.PowderLabel);
			this.LoadDataGroupBox.Controls.Add(label7);
			this.LoadDataGroupBox.Controls.Add(this.BulletLabel);
			this.LoadDataGroupBox.Controls.Add(label5);
			this.LoadDataGroupBox.Controls.Add(this.CaliberLabel);
			this.LoadDataGroupBox.Controls.Add(label1);
			this.LoadDataGroupBox.Controls.Add(label3);
			this.LoadDataGroupBox.Controls.Add(this.FirearmTypeLabel);
			this.LoadDataGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoadDataGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.LoadDataGroupBox.Location = new System.Drawing.Point(10, 10);
			this.LoadDataGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.LoadDataGroupBox.Name = "LoadDataGroupBox";
			this.LoadDataGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.LoadDataGroupBox.Size = new System.Drawing.Size(561, 240);
			this.LoadDataGroupBox.TabIndex = 0;
			this.LoadDataGroupBox.TabStop = false;
			this.LoadDataGroupBox.Text = "Load";
			// 
			// FillRatioTextBox
			// 
			this.FillRatioTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.FillRatioTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FillRatioTextBox.Location = new System.Drawing.Point(319, 127);
			this.FillRatioTextBox.MaxLength = 5;
			this.FillRatioTextBox.MaxValue = 150D;
			this.FillRatioTextBox.MinValue = 0D;
			this.FillRatioTextBox.Name = "FillRatioTextBox";
			this.FillRatioTextBox.NumDecimals = 1;
			this.FillRatioTextBox.Size = new System.Drawing.Size(42, 20);
			this.FillRatioTextBox.TabIndex = 1;
			this.FillRatioTextBox.Text = "0.0";
			this.FillRatioTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.FillRatioTextBox.ToolTip = "";
			this.FillRatioTextBox.Value = 0D;
			this.FillRatioTextBox.ZeroAllowed = true;
			// 
			// PowderWeightTextBox
			// 
			this.PowderWeightTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.PowderWeightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PowderWeightTextBox.Location = new System.Drawing.Point(189, 127);
			this.PowderWeightTextBox.MaxLength = 4;
			this.PowderWeightTextBox.MaxValue = 0D;
			this.PowderWeightTextBox.MinValue = 0D;
			this.PowderWeightTextBox.Name = "PowderWeightTextBox";
			this.PowderWeightTextBox.NumDecimals = 1;
			this.PowderWeightTextBox.Size = new System.Drawing.Size(50, 20);
			this.PowderWeightTextBox.TabIndex = 0;
			this.PowderWeightTextBox.Text = "0.0";
			this.PowderWeightTextBox.ToolTip = "";
			this.PowderWeightTextBox.Value = 0D;
			this.PowderWeightTextBox.ZeroAllowed = true;
			// 
			// RejectRadioButton
			// 
			this.RejectRadioButton.AutoCheck = false;
			this.RejectRadioButton.AutoSize = true;
			this.RejectRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.RejectRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RejectRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RejectRadioButton.Location = new System.Drawing.Point(405, 150);
			this.RejectRadioButton.Margin = new System.Windows.Forms.Padding(2);
			this.RejectRadioButton.Name = "RejectRadioButton";
			this.RejectRadioButton.Size = new System.Drawing.Size(59, 17);
			this.RejectRadioButton.TabIndex = 3;
			this.RejectRadioButton.TabStop = true;
			this.RejectRadioButton.Text = "Reject:";
			this.RejectRadioButton.UseVisualStyleBackColor = true;
			// 
			// FavoriteRadioButton
			// 
			this.FavoriteRadioButton.AutoCheck = false;
			this.FavoriteRadioButton.AutoSize = true;
			this.FavoriteRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.FavoriteRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FavoriteRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FavoriteRadioButton.Location = new System.Drawing.Point(397, 128);
			this.FavoriteRadioButton.Margin = new System.Windows.Forms.Padding(2);
			this.FavoriteRadioButton.Name = "FavoriteRadioButton";
			this.FavoriteRadioButton.Size = new System.Drawing.Size(66, 17);
			this.FavoriteRadioButton.TabIndex = 2;
			this.FavoriteRadioButton.TabStop = true;
			this.FavoriteRadioButton.Text = "Favorite:";
			this.FavoriteRadioButton.UseVisualStyleBackColor = true;
			// 
			// ErrorMessageLabel
			// 
			this.ErrorMessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ErrorMessageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.ErrorMessageLabel.Location = new System.Drawing.Point(14, 181);
			this.ErrorMessageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.ErrorMessageLabel.Name = "ErrorMessageLabel";
			this.ErrorMessageLabel.Size = new System.Drawing.Size(536, 44);
			this.ErrorMessageLabel.TabIndex = 17;
			// 
			// CaseLabel
			// 
			this.CaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CaseLabel.ForeColor = System.Drawing.SystemColors.WindowText;
			this.CaseLabel.Location = new System.Drawing.Point(347, 98);
			this.CaseLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.CaseLabel.Name = "CaseLabel";
			this.CaseLabel.Size = new System.Drawing.Size(194, 19);
			this.CaseLabel.TabIndex = 11;
			this.CaseLabel.Text = "cCase";
			// 
			// PrimerLabel
			// 
			this.PrimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PrimerLabel.ForeColor = System.Drawing.SystemColors.WindowText;
			this.PrimerLabel.Location = new System.Drawing.Point(347, 73);
			this.PrimerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.PrimerLabel.Name = "PrimerLabel";
			this.PrimerLabel.Size = new System.Drawing.Size(194, 19);
			this.PrimerLabel.TabIndex = 9;
			this.PrimerLabel.Text = "cPrimer";
			// 
			// PowderLabel
			// 
			this.PowderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PowderLabel.ForeColor = System.Drawing.SystemColors.WindowText;
			this.PowderLabel.Location = new System.Drawing.Point(98, 98);
			this.PowderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.PowderLabel.Name = "PowderLabel";
			this.PowderLabel.Size = new System.Drawing.Size(194, 19);
			this.PowderLabel.TabIndex = 7;
			this.PowderLabel.Text = "cPowder";
			// 
			// BulletLabel
			// 
			this.BulletLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletLabel.ForeColor = System.Drawing.SystemColors.WindowText;
			this.BulletLabel.Location = new System.Drawing.Point(98, 73);
			this.BulletLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.BulletLabel.Name = "BulletLabel";
			this.BulletLabel.Size = new System.Drawing.Size(194, 19);
			this.BulletLabel.TabIndex = 5;
			this.BulletLabel.Text = "cBullet";
			// 
			// CaliberLabel
			// 
			this.CaliberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CaliberLabel.ForeColor = System.Drawing.SystemColors.WindowText;
			this.CaliberLabel.Location = new System.Drawing.Point(98, 49);
			this.CaliberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.CaliberLabel.Name = "CaliberLabel";
			this.CaliberLabel.Size = new System.Drawing.Size(169, 19);
			this.CaliberLabel.TabIndex = 3;
			this.CaliberLabel.Text = "Caliber";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.RemoveChargeTestButton);
			this.groupBox2.Controls.Add(this.EditChargeTestButton);
			this.groupBox2.Controls.Add(this.AddChargeTestButton);
			this.groupBox2.Controls.Add(this.ChargeTestListView);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox2.Location = new System.Drawing.Point(10, 254);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox2.Size = new System.Drawing.Size(561, 261);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Test Data";
			// 
			// RemoveChargeTestButton
			// 
			this.RemoveChargeTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RemoveChargeTestButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RemoveChargeTestButton.Location = new System.Drawing.Point(333, 223);
			this.RemoveChargeTestButton.Margin = new System.Windows.Forms.Padding(2);
			this.RemoveChargeTestButton.Name = "RemoveChargeTestButton";
			this.RemoveChargeTestButton.Size = new System.Drawing.Size(80, 19);
			this.RemoveChargeTestButton.TabIndex = 3;
			this.RemoveChargeTestButton.Text = "Remove Test";
			this.RemoveChargeTestButton.UseVisualStyleBackColor = true;
			// 
			// EditChargeTestButton
			// 
			this.EditChargeTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EditChargeTestButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.EditChargeTestButton.Location = new System.Drawing.Point(240, 223);
			this.EditChargeTestButton.Margin = new System.Windows.Forms.Padding(2);
			this.EditChargeTestButton.Name = "EditChargeTestButton";
			this.EditChargeTestButton.Size = new System.Drawing.Size(80, 19);
			this.EditChargeTestButton.TabIndex = 2;
			this.EditChargeTestButton.Text = "Edit Test";
			this.EditChargeTestButton.UseVisualStyleBackColor = true;
			// 
			// AddChargeTestButton
			// 
			this.AddChargeTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AddChargeTestButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AddChargeTestButton.Location = new System.Drawing.Point(147, 223);
			this.AddChargeTestButton.Margin = new System.Windows.Forms.Padding(2);
			this.AddChargeTestButton.Name = "AddChargeTestButton";
			this.AddChargeTestButton.Size = new System.Drawing.Size(80, 19);
			this.AddChargeTestButton.TabIndex = 1;
			this.AddChargeTestButton.Text = "Add Test";
			this.AddChargeTestButton.UseVisualStyleBackColor = true;
			// 
			// ChargeTestListView
			// 
			this.ChargeTestListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SourceHeader,
            this.BarrelLengthHeader,
            this.TwistHeader,
            this.MuzzleVelocityHeader,
            this.PressureHeader,
            this.BestGroupHeader,
            this.RangeHeader});
			this.ChargeTestListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.ChargeTestListView.FullRowSelect = true;
			this.ChargeTestListView.HideSelection = false;
			this.ChargeTestListView.Location = new System.Drawing.Point(11, 21);
			this.ChargeTestListView.Margin = new System.Windows.Forms.Padding(2);
			this.ChargeTestListView.Name = "ChargeTestListView";
			this.ChargeTestListView.Size = new System.Drawing.Size(539, 186);
			this.ChargeTestListView.TabIndex = 0;
			this.ChargeTestListView.UseCompatibleStateImageBehavior = false;
			this.ChargeTestListView.View = System.Windows.Forms.View.Details;
			// 
			// SourceHeader
			// 
			this.SourceHeader.Text = "Source";
			this.SourceHeader.Width = 180;
			// 
			// BarrelLengthHeader
			// 
			this.BarrelLengthHeader.Text = "Barrel Length";
			this.BarrelLengthHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.BarrelLengthHeader.Width = 100;
			// 
			// TwistHeader
			// 
			this.TwistHeader.Text = "Twist";
			this.TwistHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TwistHeader.Width = 90;
			// 
			// MuzzleVelocityHeader
			// 
			this.MuzzleVelocityHeader.Text = "Muzzle Velocity";
			this.MuzzleVelocityHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.MuzzleVelocityHeader.Width = 120;
			// 
			// PressureHeader
			// 
			this.PressureHeader.Text = "Pressure";
			this.PressureHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.PressureHeader.Width = 120;
			// 
			// BestGroupHeader
			// 
			this.BestGroupHeader.Text = "Best Group";
			this.BestGroupHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.BestGroupHeader.Width = 100;
			// 
			// RangeHeader
			// 
			this.RangeHeader.Text = "Range";
			this.RangeHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.RangeHeader.Width = 100;
			// 
			// ChargeOKButton
			// 
			this.ChargeOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ChargeOKButton.Location = new System.Drawing.Point(223, 538);
			this.ChargeOKButton.Margin = new System.Windows.Forms.Padding(2);
			this.ChargeOKButton.Name = "ChargeOKButton";
			this.ChargeOKButton.Size = new System.Drawing.Size(56, 19);
			this.ChargeOKButton.TabIndex = 2;
			this.ChargeOKButton.Text = "Add";
			this.ChargeOKButton.UseVisualStyleBackColor = true;
			// 
			// ChargeCancelButton
			// 
			this.ChargeCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ChargeCancelButton.Location = new System.Drawing.Point(299, 538);
			this.ChargeCancelButton.Margin = new System.Windows.Forms.Padding(2);
			this.ChargeCancelButton.Name = "ChargeCancelButton";
			this.ChargeCancelButton.Size = new System.Drawing.Size(56, 19);
			this.ChargeCancelButton.TabIndex = 3;
			this.ChargeCancelButton.Text = "Cancel";
			this.ChargeCancelButton.UseVisualStyleBackColor = true;
			// 
			// cChargeForm
			// 
			this.AcceptButton = this.ChargeOKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.ChargeCancelButton;
			this.ClientSize = new System.Drawing.Size(561, 559);
			this.ControlBox = false;
			this.Controls.Add(this.ChargeCancelButton);
			this.Controls.Add(this.ChargeOKButton);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.LoadDataGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cChargeForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Powder Charge";
			this.LoadDataGroupBox.ResumeLayout(false);
			this.LoadDataGroupBox.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.Label FirearmTypeLabel;
		private System.Windows.Forms.GroupBox LoadDataGroupBox;
		private System.Windows.Forms.Label PowderLabel;
		private System.Windows.Forms.Label BulletLabel;
		private System.Windows.Forms.Label CaliberLabel;
		private System.Windows.Forms.Label CaseLabel;
		private System.Windows.Forms.Label PrimerLabel;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button RemoveChargeTestButton;
		private System.Windows.Forms.Button EditChargeTestButton;
		private System.Windows.Forms.Button AddChargeTestButton;
		private System.Windows.Forms.ListView ChargeTestListView;
		private System.Windows.Forms.ColumnHeader SourceHeader;
		private System.Windows.Forms.ColumnHeader BarrelLengthHeader;
		private System.Windows.Forms.ColumnHeader TwistHeader;
		private System.Windows.Forms.ColumnHeader MuzzleVelocityHeader;
		private System.Windows.Forms.ColumnHeader PressureHeader;
		private System.Windows.Forms.Button ChargeOKButton;
		private System.Windows.Forms.Button ChargeCancelButton;
		private System.Windows.Forms.ColumnHeader BestGroupHeader;
		private System.Windows.Forms.Label ErrorMessageLabel;
		private System.Windows.Forms.RadioButton FavoriteRadioButton;
		private System.Windows.Forms.RadioButton RejectRadioButton;
		private CommonLib.Controls.cDoubleValueTextBox PowderWeightTextBox;
		private System.Windows.Forms.ColumnHeader RangeHeader;
		private System.Windows.Forms.Label ChargeMeasurementLabel;
		private CommonLib.Controls.cDoubleValueTextBox FillRatioTextBox;
		}
	}