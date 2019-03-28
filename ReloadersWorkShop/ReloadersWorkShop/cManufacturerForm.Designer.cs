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
			this.ToolsCheckBox = new System.Windows.Forms.CheckBox();
			this.LightsCheckBox = new System.Windows.Forms.CheckBox();
			this.MagnifiersCheckBox = new System.Windows.Forms.CheckBox();
			this.LasersCheckBox = new System.Windows.Forms.CheckBox();
			this.OtherCheckBox = new System.Windows.Forms.CheckBox();
			this.PartsCheckBox = new System.Windows.Forms.CheckBox();
			this.BipodsCheckBox = new System.Windows.Forms.CheckBox();
			this.RedDotsCheckBox = new System.Windows.Forms.CheckBox();
			this.FurnitureCheckBox = new System.Windows.Forms.CheckBox();
			this.TriggersCheckBox = new System.Windows.Forms.CheckBox();
			this.ScopesCheckBox = new System.Windows.Forms.CheckBox();
			this.FormCancelButton = new CommonLib.Controls.cCancelButton();
			this.OKButton = new CommonLib.Controls.cOKButton();
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
			this.groupBox1.Size = new System.Drawing.Size(302, 96);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Supply Products";
			// 
			// BulletMoldsCheckBox
			// 
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
			this.HeadStampTextBox.ValidChars = "";
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
			this.FirearmsGroup.Location = new System.Drawing.Point(11, 191);
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
			this.WebsiteTextBox.ValidChars = "";
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
			this.NameTextBox.ValidChars = "";
			this.NameTextBox.Value = "";
			// 
			// ProductUseLabel
			// 
			this.ProductUseLabel.BackColor = System.Drawing.SystemColors.Control;
			this.ProductUseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ProductUseLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ProductUseLabel.Location = new System.Drawing.Point(8, 386);
			this.ProductUseLabel.Name = "ProductUseLabel";
			this.ProductUseLabel.Size = new System.Drawing.Size(305, 50);
			this.ProductUseLabel.TabIndex = 4;
			this.ProductUseLabel.Text = "Product Use Label";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.ToolsCheckBox);
			this.groupBox3.Controls.Add(this.LightsCheckBox);
			this.groupBox3.Controls.Add(this.MagnifiersCheckBox);
			this.groupBox3.Controls.Add(this.LasersCheckBox);
			this.groupBox3.Controls.Add(this.OtherCheckBox);
			this.groupBox3.Controls.Add(this.PartsCheckBox);
			this.groupBox3.Controls.Add(this.BipodsCheckBox);
			this.groupBox3.Controls.Add(this.RedDotsCheckBox);
			this.groupBox3.Controls.Add(this.FurnitureCheckBox);
			this.groupBox3.Controls.Add(this.TriggersCheckBox);
			this.groupBox3.Controls.Add(this.ScopesCheckBox);
			this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox3.Location = new System.Drawing.Point(11, 250);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox3.Size = new System.Drawing.Size(302, 125);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Tools, Parts && Accessories";
			// 
			// ToolsCheckBox
			// 
			this.ToolsCheckBox.AutoSize = true;
			this.ToolsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ToolsCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ToolsCheckBox.Location = new System.Drawing.Point(111, 94);
			this.ToolsCheckBox.Name = "ToolsCheckBox";
			this.ToolsCheckBox.Size = new System.Drawing.Size(165, 17);
			this.ToolsCheckBox.TabIndex = 10;
			this.ToolsCheckBox.Text = "Tools && Reloading Equipment";
			this.ToolsCheckBox.UseVisualStyleBackColor = true;
			// 
			// LightsCheckBox
			// 
			this.LightsCheckBox.AutoSize = true;
			this.LightsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LightsCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LightsCheckBox.Location = new System.Drawing.Point(111, 48);
			this.LightsCheckBox.Name = "LightsCheckBox";
			this.LightsCheckBox.Size = new System.Drawing.Size(54, 17);
			this.LightsCheckBox.TabIndex = 4;
			this.LightsCheckBox.Text = "Lights";
			this.LightsCheckBox.UseVisualStyleBackColor = true;
			// 
			// MagnifiersCheckBox
			// 
			this.MagnifiersCheckBox.AutoSize = true;
			this.MagnifiersCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MagnifiersCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MagnifiersCheckBox.Location = new System.Drawing.Point(18, 48);
			this.MagnifiersCheckBox.Name = "MagnifiersCheckBox";
			this.MagnifiersCheckBox.Size = new System.Drawing.Size(74, 17);
			this.MagnifiersCheckBox.TabIndex = 3;
			this.MagnifiersCheckBox.Text = "Magnifiers";
			this.MagnifiersCheckBox.UseVisualStyleBackColor = true;
			// 
			// LasersCheckBox
			// 
			this.LasersCheckBox.AutoSize = true;
			this.LasersCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LasersCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LasersCheckBox.Location = new System.Drawing.Point(111, 25);
			this.LasersCheckBox.Name = "LasersCheckBox";
			this.LasersCheckBox.Size = new System.Drawing.Size(57, 17);
			this.LasersCheckBox.TabIndex = 1;
			this.LasersCheckBox.Text = "Lasers";
			this.LasersCheckBox.UseVisualStyleBackColor = true;
			// 
			// OtherCheckBox
			// 
			this.OtherCheckBox.AutoSize = true;
			this.OtherCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OtherCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.OtherCheckBox.Location = new System.Drawing.Point(18, 94);
			this.OtherCheckBox.Name = "OtherCheckBox";
			this.OtherCheckBox.Size = new System.Drawing.Size(52, 17);
			this.OtherCheckBox.TabIndex = 9;
			this.OtherCheckBox.Text = "Other";
			this.OtherCheckBox.UseVisualStyleBackColor = true;
			// 
			// PartsCheckBox
			// 
			this.PartsCheckBox.AutoSize = true;
			this.PartsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PartsCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PartsCheckBox.Location = new System.Drawing.Point(184, 71);
			this.PartsCheckBox.Name = "PartsCheckBox";
			this.PartsCheckBox.Size = new System.Drawing.Size(87, 17);
			this.PartsCheckBox.TabIndex = 8;
			this.PartsCheckBox.Text = "Firearm Parts";
			this.PartsCheckBox.UseVisualStyleBackColor = true;
			// 
			// BipodsCheckBox
			// 
			this.BipodsCheckBox.AutoSize = true;
			this.BipodsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BipodsCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BipodsCheckBox.Location = new System.Drawing.Point(111, 71);
			this.BipodsCheckBox.Name = "BipodsCheckBox";
			this.BipodsCheckBox.Size = new System.Drawing.Size(58, 17);
			this.BipodsCheckBox.TabIndex = 7;
			this.BipodsCheckBox.Text = "Bipods";
			this.BipodsCheckBox.UseVisualStyleBackColor = true;
			// 
			// RedDotsCheckBox
			// 
			this.RedDotsCheckBox.AutoSize = true;
			this.RedDotsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RedDotsCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RedDotsCheckBox.Location = new System.Drawing.Point(184, 25);
			this.RedDotsCheckBox.Name = "RedDotsCheckBox";
			this.RedDotsCheckBox.Size = new System.Drawing.Size(71, 17);
			this.RedDotsCheckBox.TabIndex = 2;
			this.RedDotsCheckBox.Text = "Red Dots";
			this.RedDotsCheckBox.UseVisualStyleBackColor = true;
			// 
			// FurnitureCheckBox
			// 
			this.FurnitureCheckBox.AutoSize = true;
			this.FurnitureCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FurnitureCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FurnitureCheckBox.Location = new System.Drawing.Point(18, 71);
			this.FurnitureCheckBox.Name = "FurnitureCheckBox";
			this.FurnitureCheckBox.Size = new System.Drawing.Size(67, 17);
			this.FurnitureCheckBox.TabIndex = 6;
			this.FurnitureCheckBox.Text = "Furniture";
			this.FurnitureCheckBox.UseVisualStyleBackColor = true;
			// 
			// TriggersCheckBox
			// 
			this.TriggersCheckBox.AutoSize = true;
			this.TriggersCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TriggersCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TriggersCheckBox.Location = new System.Drawing.Point(184, 48);
			this.TriggersCheckBox.Name = "TriggersCheckBox";
			this.TriggersCheckBox.Size = new System.Drawing.Size(64, 17);
			this.TriggersCheckBox.TabIndex = 5;
			this.TriggersCheckBox.Text = "Triggers";
			this.TriggersCheckBox.UseVisualStyleBackColor = true;
			// 
			// ScopesCheckBox
			// 
			this.ScopesCheckBox.AutoSize = true;
			this.ScopesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ScopesCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ScopesCheckBox.Location = new System.Drawing.Point(18, 25);
			this.ScopesCheckBox.Name = "ScopesCheckBox";
			this.ScopesCheckBox.Size = new System.Drawing.Size(62, 17);
			this.ScopesCheckBox.TabIndex = 0;
			this.ScopesCheckBox.Text = "Scopes";
			this.ScopesCheckBox.UseVisualStyleBackColor = true;
			// 
			// FormCancelButton
			// 
			this.FormCancelButton.ButtonType = CommonLib.Controls.cCancelButton.eButtonTypes.Cancel;
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Location = new System.Drawing.Point(174, 453);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.ShowToolTips = true;
			this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
			this.FormCancelButton.TabIndex = 6;
			this.FormCancelButton.Text = "Cancel";
			this.FormCancelButton.ToolTip = "Click to cancel changes and exit.";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			// 
			// OKButton
			// 
			this.OKButton.ButtonType = CommonLib.Controls.cOKButton.eButtonTypes.OK;
			this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKButton.Location = new System.Drawing.Point(81, 453);
			this.OKButton.Name = "OKButton";
			this.OKButton.ShowToolTips = true;
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 5;
			this.OKButton.Text = "OK";
			this.OKButton.ToolTip = "Click to accept changes and exit.";
			this.OKButton.UseVisualStyleBackColor = true;
			// 
			// cManufacturerForm
			// 
			this.AcceptButton = this.OKButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.ClientSize = new System.Drawing.Size(318, 478);
			this.ControlBox = false;
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.ProductUseLabel);
			this.Controls.Add(this.groupBox1);
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
		private System.Windows.Forms.CheckBox FurnitureCheckBox;
		private System.Windows.Forms.CheckBox TriggersCheckBox;
		private System.Windows.Forms.CheckBox ScopesCheckBox;
		private System.Windows.Forms.CheckBox RedDotsCheckBox;
		private System.Windows.Forms.CheckBox BipodsCheckBox;
		private System.Windows.Forms.CheckBox PartsCheckBox;
		private System.Windows.Forms.CheckBox OtherCheckBox;
		private System.Windows.Forms.CheckBox LasersCheckBox;
		private System.Windows.Forms.CheckBox MagnifiersCheckBox;
		private System.Windows.Forms.CheckBox LightsCheckBox;
		private CommonLib.Controls.cCancelButton FormCancelButton;
		private CommonLib.Controls.cOKButton OKButton;
		private System.Windows.Forms.CheckBox ToolsCheckBox;
		}
	}