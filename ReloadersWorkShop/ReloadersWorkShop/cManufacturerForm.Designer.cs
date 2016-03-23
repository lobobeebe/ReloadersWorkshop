//============================================================================*
// cManufacturerForm.cs
//
// Copyright (c) 2013, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Windows;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cManufacturerForm Class
	//============================================================================*

	partial class cManufacturerForm
		{
		private System.ComponentModel.IContainer components = null;

		//============================================================================*
		// Dispose()
		//============================================================================*

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
			this.ManufacturerCancelButton = new System.Windows.Forms.Button();
			this.ManufacturerOKButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.BulletMoldsCheckBox = new System.Windows.Forms.CheckBox();
			this.PrimersCheckBox = new System.Windows.Forms.CheckBox();
			this.PowderCheckBox = new System.Windows.Forms.CheckBox();
			this.CasesCheckBox = new System.Windows.Forms.CheckBox();
			this.BulletsCheckBox = new System.Windows.Forms.CheckBox();
			this.AmmoCheckBox = new System.Windows.Forms.CheckBox();
			this.HeadStampTextBox = new CommonLib.Controls.cTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.FirearmsGroup = new System.Windows.Forms.GroupBox();
			this.ShotgunsCheckBox = new System.Windows.Forms.CheckBox();
			this.RiflesCheckBox = new System.Windows.Forms.CheckBox();
			this.HandgunsCheckBox = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.WebsiteTextBox = new CommonLib.Controls.cURLTextBox();
			this.NameTextBox = new CommonLib.Controls.cTextBox();
			this.ProductUseLabel = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.StocksCheckBox = new System.Windows.Forms.CheckBox();
			this.TriggersCheckBox = new System.Windows.Forms.CheckBox();
			this.ScopesCheckBox = new System.Windows.Forms.CheckBox();
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.FirearmsGroup.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label1.ForeColor = System.Drawing.SystemColors.ControlText;
			label1.Location = new System.Drawing.Point(36, 24);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(38, 13);
			label1.TabIndex = 4;
			label1.Text = "Name:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label3.ForeColor = System.Drawing.SystemColors.ControlText;
			label3.Location = new System.Drawing.Point(26, 49);
			label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(49, 13);
			label3.TabIndex = 7;
			label3.Text = "Website:";
			// 
			// ManufacturerCancelButton
			// 
			this.ManufacturerCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ManufacturerCancelButton.Location = new System.Drawing.Point(170, 387);
			this.ManufacturerCancelButton.Margin = new System.Windows.Forms.Padding(2);
			this.ManufacturerCancelButton.Name = "ManufacturerCancelButton";
			this.ManufacturerCancelButton.Size = new System.Drawing.Size(56, 19);
			this.ManufacturerCancelButton.TabIndex = 5;
			this.ManufacturerCancelButton.Text = "Cancel";
			this.ManufacturerCancelButton.UseVisualStyleBackColor = true;
			// 
			// ManufacturerOKButton
			// 
			this.ManufacturerOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ManufacturerOKButton.Location = new System.Drawing.Point(96, 387);
			this.ManufacturerOKButton.Margin = new System.Windows.Forms.Padding(2);
			this.ManufacturerOKButton.Name = "ManufacturerOKButton";
			this.ManufacturerOKButton.Size = new System.Drawing.Size(56, 19);
			this.ManufacturerOKButton.TabIndex = 4;
			this.ManufacturerOKButton.Text = "OK";
			this.ManufacturerOKButton.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.BulletMoldsCheckBox);
			this.groupBox1.Controls.Add(this.PrimersCheckBox);
			this.groupBox1.Controls.Add(this.PowderCheckBox);
			this.groupBox1.Controls.Add(this.CasesCheckBox);
			this.groupBox1.Controls.Add(this.BulletsCheckBox);
			this.groupBox1.Controls.Add(this.AmmoCheckBox);
			this.groupBox1.Controls.Add(this.HeadStampTextBox);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox1.Location = new System.Drawing.Point(11, 91);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox1.Size = new System.Drawing.Size(302, 105);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Supply Products";
			// 
			// BulletMoldsCheckBox
			// 
			this.BulletMoldsCheckBox.AutoCheck = false;
			this.BulletMoldsCheckBox.AutoSize = true;
			this.BulletMoldsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletMoldsCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BulletMoldsCheckBox.Location = new System.Drawing.Point(97, 46);
			this.BulletMoldsCheckBox.Name = "BulletMoldsCheckBox";
			this.BulletMoldsCheckBox.Size = new System.Drawing.Size(83, 17);
			this.BulletMoldsCheckBox.TabIndex = 5;
			this.BulletMoldsCheckBox.Text = "Bullet Molds";
			this.BulletMoldsCheckBox.UseVisualStyleBackColor = true;
			// 
			// PrimersCheckBox
			// 
			this.PrimersCheckBox.AutoCheck = false;
			this.PrimersCheckBox.AutoSize = true;
			this.PrimersCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PrimersCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PrimersCheckBox.Location = new System.Drawing.Point(31, 46);
			this.PrimersCheckBox.Name = "PrimersCheckBox";
			this.PrimersCheckBox.Size = new System.Drawing.Size(60, 17);
			this.PrimersCheckBox.TabIndex = 4;
			this.PrimersCheckBox.Text = "Primers";
			this.PrimersCheckBox.UseVisualStyleBackColor = true;
			// 
			// PowderCheckBox
			// 
			this.PowderCheckBox.AutoCheck = false;
			this.PowderCheckBox.AutoSize = true;
			this.PowderCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PowderCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PowderCheckBox.Location = new System.Drawing.Point(221, 25);
			this.PowderCheckBox.Name = "PowderCheckBox";
			this.PowderCheckBox.Size = new System.Drawing.Size(62, 17);
			this.PowderCheckBox.TabIndex = 3;
			this.PowderCheckBox.Text = "Powder";
			this.PowderCheckBox.UseVisualStyleBackColor = true;
			// 
			// CasesCheckBox
			// 
			this.CasesCheckBox.AutoCheck = false;
			this.CasesCheckBox.AutoSize = true;
			this.CasesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CasesCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CasesCheckBox.Location = new System.Drawing.Point(160, 25);
			this.CasesCheckBox.Name = "CasesCheckBox";
			this.CasesCheckBox.Size = new System.Drawing.Size(55, 17);
			this.CasesCheckBox.TabIndex = 2;
			this.CasesCheckBox.Text = "Cases";
			this.CasesCheckBox.UseVisualStyleBackColor = true;
			// 
			// BulletsCheckBox
			// 
			this.BulletsCheckBox.AutoCheck = false;
			this.BulletsCheckBox.AutoSize = true;
			this.BulletsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletsCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BulletsCheckBox.Location = new System.Drawing.Point(97, 25);
			this.BulletsCheckBox.Name = "BulletsCheckBox";
			this.BulletsCheckBox.Size = new System.Drawing.Size(57, 17);
			this.BulletsCheckBox.TabIndex = 1;
			this.BulletsCheckBox.Text = "Bullets";
			this.BulletsCheckBox.UseVisualStyleBackColor = true;
			// 
			// AmmoCheckBox
			// 
			this.AmmoCheckBox.AutoCheck = false;
			this.AmmoCheckBox.AutoSize = true;
			this.AmmoCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AmmoCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AmmoCheckBox.Location = new System.Drawing.Point(31, 25);
			this.AmmoCheckBox.Name = "AmmoCheckBox";
			this.AmmoCheckBox.Size = new System.Drawing.Size(55, 17);
			this.AmmoCheckBox.TabIndex = 0;
			this.AmmoCheckBox.Text = "Ammo";
			this.AmmoCheckBox.UseVisualStyleBackColor = true;
			// 
			// HeadStampTextBox
			// 
			this.HeadStampTextBox.BackColor = System.Drawing.Color.LightPink;
			this.HeadStampTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.HeadStampTextBox.Location = new System.Drawing.Point(128, 65);
			this.HeadStampTextBox.MaxLength = 20;
			this.HeadStampTextBox.Name = "HeadStampTextBox";
			this.HeadStampTextBox.Required = true;
			this.HeadStampTextBox.Size = new System.Drawing.Size(100, 20);
			this.HeadStampTextBox.TabIndex = 6;
			this.HeadStampTextBox.ToolTip = "";
			this.HeadStampTextBox.Value = "";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(57, 68);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "HeadStamp:";
			// 
			// FirearmsGroup
			// 
			this.FirearmsGroup.Controls.Add(this.ShotgunsCheckBox);
			this.FirearmsGroup.Controls.Add(this.RiflesCheckBox);
			this.FirearmsGroup.Controls.Add(this.HandgunsCheckBox);
			this.FirearmsGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FirearmsGroup.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.FirearmsGroup.Location = new System.Drawing.Point(11, 200);
			this.FirearmsGroup.Margin = new System.Windows.Forms.Padding(2);
			this.FirearmsGroup.Name = "FirearmsGroup";
			this.FirearmsGroup.Padding = new System.Windows.Forms.Padding(2);
			this.FirearmsGroup.Size = new System.Drawing.Size(302, 55);
			this.FirearmsGroup.TabIndex = 2;
			this.FirearmsGroup.TabStop = false;
			this.FirearmsGroup.Text = "Firearms";
			// 
			// ShotgunsCheckBox
			// 
			this.ShotgunsCheckBox.AutoCheck = false;
			this.ShotgunsCheckBox.AutoSize = true;
			this.ShotgunsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShotgunsCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ShotgunsCheckBox.Location = new System.Drawing.Point(202, 25);
			this.ShotgunsCheckBox.Name = "ShotgunsCheckBox";
			this.ShotgunsCheckBox.Size = new System.Drawing.Size(71, 17);
			this.ShotgunsCheckBox.TabIndex = 2;
			this.ShotgunsCheckBox.Text = "Shotguns";
			this.ShotgunsCheckBox.UseVisualStyleBackColor = true;
			// 
			// RiflesCheckBox
			// 
			this.RiflesCheckBox.AutoCheck = false;
			this.RiflesCheckBox.AutoSize = true;
			this.RiflesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RiflesCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RiflesCheckBox.Location = new System.Drawing.Point(128, 25);
			this.RiflesCheckBox.Name = "RiflesCheckBox";
			this.RiflesCheckBox.Size = new System.Drawing.Size(52, 17);
			this.RiflesCheckBox.TabIndex = 1;
			this.RiflesCheckBox.Text = "Rifles";
			this.RiflesCheckBox.UseVisualStyleBackColor = true;
			// 
			// HandgunsCheckBox
			// 
			this.HandgunsCheckBox.AutoCheck = false;
			this.HandgunsCheckBox.AutoSize = true;
			this.HandgunsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.HandgunsCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.HandgunsCheckBox.Location = new System.Drawing.Point(31, 25);
			this.HandgunsCheckBox.Name = "HandgunsCheckBox";
			this.HandgunsCheckBox.Size = new System.Drawing.Size(75, 17);
			this.HandgunsCheckBox.TabIndex = 0;
			this.HandgunsCheckBox.Text = "Handguns";
			this.HandgunsCheckBox.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.WebsiteTextBox);
			this.groupBox2.Controls.Add(this.NameTextBox);
			this.groupBox2.Controls.Add(label3);
			this.groupBox2.Controls.Add(label1);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox2.Location = new System.Drawing.Point(11, 10);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox2.Size = new System.Drawing.Size(302, 76);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Company Info";
			// 
			// WebsiteTextBox
			// 
			this.WebsiteTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.WebsiteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WebsiteTextBox.Location = new System.Drawing.Point(77, 46);
			this.WebsiteTextBox.MaxLength = 254;
			this.WebsiteTextBox.Name = "WebsiteTextBox";
			this.WebsiteTextBox.Required = false;
			this.WebsiteTextBox.Size = new System.Drawing.Size(215, 20);
			this.WebsiteTextBox.TabIndex = 1;
			this.WebsiteTextBox.ToolTip = "";
			this.WebsiteTextBox.Value = "";
			// 
			// NameTextBox
			// 
			this.NameTextBox.BackColor = System.Drawing.Color.LightPink;
			this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NameTextBox.Location = new System.Drawing.Point(77, 21);
			this.NameTextBox.MaxLength = 35;
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Required = true;
			this.NameTextBox.Size = new System.Drawing.Size(215, 20);
			this.NameTextBox.TabIndex = 0;
			this.NameTextBox.ToolTip = "";
			this.NameTextBox.Value = "";
			// 
			// ProductUseLabel
			// 
			this.ProductUseLabel.BackColor = System.Drawing.SystemColors.Control;
			this.ProductUseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ProductUseLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ProductUseLabel.Location = new System.Drawing.Point(8, 321);
			this.ProductUseLabel.Name = "ProductUseLabel";
			this.ProductUseLabel.Size = new System.Drawing.Size(305, 50);
			this.ProductUseLabel.TabIndex = 4;
			this.ProductUseLabel.Text = "Product Use Label";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.StocksCheckBox);
			this.groupBox3.Controls.Add(this.TriggersCheckBox);
			this.groupBox3.Controls.Add(this.ScopesCheckBox);
			this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox3.Location = new System.Drawing.Point(11, 259);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox3.Size = new System.Drawing.Size(302, 55);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Firearm Parts";
			// 
			// StocksCheckBox
			// 
			this.StocksCheckBox.AutoCheck = false;
			this.StocksCheckBox.AutoSize = true;
			this.StocksCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StocksCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.StocksCheckBox.Location = new System.Drawing.Point(204, 25);
			this.StocksCheckBox.Name = "StocksCheckBox";
			this.StocksCheckBox.Size = new System.Drawing.Size(88, 17);
			this.StocksCheckBox.TabIndex = 2;
			this.StocksCheckBox.Text = "Grips/Stocks";
			this.StocksCheckBox.UseVisualStyleBackColor = true;
			// 
			// TriggersCheckBox
			// 
			this.TriggersCheckBox.AutoCheck = false;
			this.TriggersCheckBox.AutoSize = true;
			this.TriggersCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TriggersCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TriggersCheckBox.Location = new System.Drawing.Point(128, 25);
			this.TriggersCheckBox.Name = "TriggersCheckBox";
			this.TriggersCheckBox.Size = new System.Drawing.Size(64, 17);
			this.TriggersCheckBox.TabIndex = 1;
			this.TriggersCheckBox.Text = "Triggers";
			this.TriggersCheckBox.UseVisualStyleBackColor = true;
			// 
			// ScopesCheckBox
			// 
			this.ScopesCheckBox.AutoCheck = false;
			this.ScopesCheckBox.AutoSize = true;
			this.ScopesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ScopesCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ScopesCheckBox.Location = new System.Drawing.Point(31, 25);
			this.ScopesCheckBox.Name = "ScopesCheckBox";
			this.ScopesCheckBox.Size = new System.Drawing.Size(62, 17);
			this.ScopesCheckBox.TabIndex = 0;
			this.ScopesCheckBox.Text = "Scopes";
			this.ScopesCheckBox.UseVisualStyleBackColor = true;
			// 
			// cManufacturerForm
			// 
			this.AcceptButton = this.ManufacturerOKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.ManufacturerCancelButton;
			this.ClientSize = new System.Drawing.Size(325, 417);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.ProductUseLabel);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.ManufacturerCancelButton);
			this.Controls.Add(this.ManufacturerOKButton);
			this.Controls.Add(this.FirearmsGroup);
			this.Controls.Add(this.groupBox2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "cManufacturerForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Manufacturer";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.FirearmsGroup.ResumeLayout(false);
			this.FirearmsGroup.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.Button ManufacturerCancelButton;
		private System.Windows.Forms.Button ManufacturerOKButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox FirearmsGroup;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private CommonLib.Controls.cTextBox HeadStampTextBox;
		private CommonLib.Controls.cTextBox NameTextBox;
		private CommonLib.Controls.cURLTextBox WebsiteTextBox;
		private System.Windows.Forms.Label ProductUseLabel;
		private System.Windows.Forms.CheckBox AmmoCheckBox;
		private System.Windows.Forms.CheckBox BulletMoldsCheckBox;
		private System.Windows.Forms.CheckBox PrimersCheckBox;
		private System.Windows.Forms.CheckBox PowderCheckBox;
		private System.Windows.Forms.CheckBox CasesCheckBox;
		private System.Windows.Forms.CheckBox BulletsCheckBox;
		private System.Windows.Forms.CheckBox ShotgunsCheckBox;
		private System.Windows.Forms.CheckBox RiflesCheckBox;
		private System.Windows.Forms.CheckBox HandgunsCheckBox;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox StocksCheckBox;
		private System.Windows.Forms.CheckBox TriggersCheckBox;
		private System.Windows.Forms.CheckBox ScopesCheckBox;
		}
	}