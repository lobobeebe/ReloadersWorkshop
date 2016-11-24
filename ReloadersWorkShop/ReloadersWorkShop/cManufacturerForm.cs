//============================================================================*
// cManuacturerForm.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.Windows.Forms;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cManufacturerForm Class
	//============================================================================*

	public partial class cManufacturerForm : Form
		{
		//============================================================================*
		// Private Constant Data Members
		//============================================================================*

		private const string cm_strNameToolTip = "Name of Manufacturer.";
		private const string cm_strWebsiteToolTip = "Manufacturer's Website (optional).";
		private const string cm_strHeadStampToolTip = "Manufacturer's name as found on case heads.";
		private const string cm_strProductsToolTip = "Check if this manufacturer supplies this product.";

		private const string cm_strManufacturerOKButtonToolTip = "Click to add or update the manufacturer with the above data.";
		private const string cm_strManufacturerCancelButtonToolTip = "Click to cancel changes and return to the main window.";

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fAdd = false;
		private bool m_fViewOnly = false;

		private bool m_fChanged = false;

		private cManufacturer m_Manufacturer;
		private cManufacturer m_OriginalManufacturer = null;

		private bool m_fInitialized = false;

		private ToolTip m_NameToolTip = new ToolTip();
		private ToolTip m_WebsiteToolTip = new ToolTip();
		private ToolTip m_HeadStampToolTip = new ToolTip();
		private ToolTip m_ProductsToolTip = new ToolTip();

		private ToolTip m_ManufacturerOKButtonToolTip = new ToolTip();
		private ToolTip m_ManufacturerCancelButtonToolTip = new ToolTip();

		private cDataFiles m_DataFiles = null;

		//============================================================================*
		// cManufacturerForm() - Constructor
		//============================================================================*

		public cManufacturerForm(cManufacturer Manufacturer, ref cDataFiles DataFiles, bool fViewOnly = false)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;
			m_fViewOnly = fViewOnly;

			if (Manufacturer == null)
				{
				if (m_fViewOnly)
					return;

				m_Manufacturer = new cManufacturer();

				m_fAdd = true;

				ManufacturerOKButton.Text = "Add";
				}
			else
				{
				m_Manufacturer = new cManufacturer(Manufacturer);
				m_OriginalManufacturer = Manufacturer;

				if (m_fViewOnly)
					{
					ManufacturerOKButton.Visible = false;
					ManufacturerCancelButton.Text = "Close";

					int nButtonX = (this.Size.Width / 2) - (ManufacturerCancelButton.Width / 2);

					ManufacturerCancelButton.Location = new Point(nButtonX, ManufacturerCancelButton.Location.Y);
					}
				else
					ManufacturerOKButton.Text = "Update";
				}

			SetClientSizeCore(FirearmsGroup.Location.X + FirearmsGroup.Width + 10, ManufacturerCancelButton.Location.Y + ManufacturerCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			if (!m_fViewOnly)
				{
				NameTextBox.TextChanged += OnNameChanged;
				WebsiteTextBox.TextChanged += OnWebsiteChanged;
				HeadStampTextBox.TextChanged += OnHeadStampChanged;

				AmmoCheckBox.Click += OnCheckBoxClicked;
				BulletsCheckBox.Click += OnCheckBoxClicked;
				CasesCheckBox.Click += OnCheckBoxClicked;
				PowderCheckBox.Click += OnCheckBoxClicked;
				PrimersCheckBox.Click += OnCheckBoxClicked;
				BulletMoldsCheckBox.Click += OnCheckBoxClicked;

				HandgunsCheckBox.Click += OnCheckBoxClicked;
				RiflesCheckBox.Click += OnCheckBoxClicked;
				ShotgunsCheckBox.Click += OnCheckBoxClicked;

				ScopesCheckBox.Click += OnCheckBoxClicked;
				RedDotsCheckBox.Click += OnCheckBoxClicked;
				LightsCheckBox.Click += OnCheckBoxClicked;
				TriggersCheckBox.Click += OnCheckBoxClicked;
				FurnitureCheckBox.Click += OnCheckBoxClicked;
				BipodsCheckBox.Click += OnCheckBoxClicked;
				PartsCheckBox.Click += OnCheckBoxClicked;
				OtherCheckBox.Click += OnCheckBoxClicked;
				}

			ManufacturerOKButton.Click += OnOKClicked;

			//----------------------------------------------------------------------------*
			// Populate the data fields
			//----------------------------------------------------------------------------*

			NameTextBox.Value = m_Manufacturer.Name;

			WebsiteTextBox.Value = m_Manufacturer.Website;

			AmmoCheckBox.Checked = m_Manufacturer.Ammo;
			BulletsCheckBox.Checked = m_Manufacturer.Bullets;
			BulletMoldsCheckBox.Checked = m_Manufacturer.BulletMolds;
			CasesCheckBox.Checked = m_Manufacturer.Cases;
			PowderCheckBox.Checked = m_Manufacturer.Powder;
			PrimersCheckBox.Checked = m_Manufacturer.Primers;

			if (fViewOnly || CasesCheckBox.Checked)
				{
				HeadStampTextBox.Enabled = true;

				HeadStampTextBox.Value = m_Manufacturer.HeadStamp;
				}
			else
				{
				HeadStampTextBox.Enabled = false;

				HeadStampTextBox.Value = "";
				}

			HandgunsCheckBox.Checked = m_Manufacturer.Handguns;
			RiflesCheckBox.Checked = m_Manufacturer.Rifles;
			ShotgunsCheckBox.Checked = m_Manufacturer.Shotguns;

			ScopesCheckBox.Checked = m_Manufacturer.Scopes;
			RedDotsCheckBox.Checked = m_Manufacturer.RedDots;
			LightsCheckBox.Checked = m_Manufacturer.Lights;
			TriggersCheckBox.Checked = m_Manufacturer.Triggers;
			FurnitureCheckBox.Checked = m_Manufacturer.Furniture;
			BipodsCheckBox.Checked = m_Manufacturer.Bipods;
			PartsCheckBox.Checked = m_Manufacturer.Parts;
			OtherCheckBox.Checked = m_Manufacturer.Misc;

			//----------------------------------------------------------------------------*
			// Build Title String
			//----------------------------------------------------------------------------*

			string strTitle;

			if (Manufacturer == null)
				{
				strTitle = "Add";
				}
			else
				{
				if (!m_fViewOnly)
					{
					strTitle = "Edit";
					}
				else
					{
					strTitle = "View";

					NameTextBox.ReadOnly = true;
					NameTextBox.Select(0, 0);
					WebsiteTextBox.ReadOnly = true;
					HeadStampTextBox.ReadOnly = true;
					}
				}

			strTitle += " Manufacturer";

			Text = strTitle;

			SetStaticToolTips();

			CheckProductUse();

			UpdateButtons();

			m_fInitialized = true;
			}

		//============================================================================*
		// AddManufacturer()
		//============================================================================*

		private void AddManufacturer()
			{
			//----------------------------------------------------------------------------*
			// If the manufacturer already exists, update the existing one and exit
			//----------------------------------------------------------------------------*

			foreach (cManufacturer CheckManufacturer in m_DataFiles.ManufacturerList)
				{
				if (CheckManufacturer.CompareTo(Manufacturer) == 0)
					{
					UpdateManufacturer();

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// Add the new manufacturer to the list
			//----------------------------------------------------------------------------*

			m_DataFiles.ManufacturerList.Add(Manufacturer);
			}

		//============================================================================*
		// CheckProductUse()
		//============================================================================*

		private void CheckProductUse()
			{
			string strProducts = "";

			if (m_OriginalManufacturer == null)
				return;

			int nLastCommaIndex = -1;
			int nProductCount = 0;

			//----------------------------------------------------------------------------*
			// Firearms
			//----------------------------------------------------------------------------*

			int nFirearmCount = 0;
			int nScopeCount = 0;
			int nTriggerCount = 0;
			int nStockCount = 0;

			if (m_OriginalManufacturer.Handguns || m_OriginalManufacturer.Rifles || m_OriginalManufacturer.Shotguns ||
				m_OriginalManufacturer.Scopes || m_OriginalManufacturer.RedDots || m_OriginalManufacturer.Lights ||
				m_OriginalManufacturer.Triggers || m_OriginalManufacturer.Furniture || m_OriginalManufacturer.Bipods ||
				m_OriginalManufacturer.Parts || m_OriginalManufacturer.Misc ||
				m_OriginalManufacturer.Bullets || m_OriginalManufacturer.BulletMolds || m_OriginalManufacturer.Cases || m_OriginalManufacturer.Powder || m_OriginalManufacturer.Primers || m_OriginalManufacturer.Ammo)
				{
				foreach (cFirearm Firearm in m_DataFiles.FirearmList)
					{
					if (Firearm.Manufacturer.CompareTo(m_OriginalManufacturer) == 0)
						{
						nFirearmCount++;

						switch (Firearm.FirearmType)
							{
							case cFirearm.eFireArmType.Handgun:
								HandgunsCheckBox.Enabled = false;
								break;

							case cFirearm.eFireArmType.Rifle:
								RiflesCheckBox.Enabled = false;
								break;

							case cFirearm.eFireArmType.Shotgun:
								ShotgunsCheckBox.Enabled = false;
								break;
							}
						}
					}

				if (nFirearmCount > 0)
					{
					strProducts += String.Format("{0:N0} firearm{1}", nFirearmCount, nFirearmCount > 1 ? "s" : "");

					nProductCount++;
					}

				if (nStockCount > 0)
					{
					if (strProducts.Length > 0)
						{
						strProducts += ", ";

						nLastCommaIndex = strProducts.IndexOf(',', nLastCommaIndex > 0 ? nLastCommaIndex + 1 : 0);
						}

					strProducts += String.Format("{0:N0} firearm stock{1}", nStockCount, nStockCount > 1 ? "s" : "");

					nProductCount++;
					}

				if (nScopeCount > 0)
					{
					if (strProducts.Length > 0)
						{
						strProducts += ", ";

						nLastCommaIndex = strProducts.IndexOf(',', nLastCommaIndex > 0 ? nLastCommaIndex + 1 : 0);
						}

					strProducts += String.Format("{0:N0} firearm scope{1}", nScopeCount, nScopeCount > 1 ? "s" : "");

					nProductCount++;
					}

				if (nTriggerCount > 0)
					{
					if (strProducts.Length > 0)
						{
						strProducts += ", ";

						nLastCommaIndex = strProducts.IndexOf(',', nLastCommaIndex > 0 ? nLastCommaIndex + 1 : 0);
						}

					strProducts += String.Format("{0:N0} firearm trigger{1}", nTriggerCount, nTriggerCount > 1 ? "s" : "");

					nProductCount++;
					}

				//----------------------------------------------------------------------------*
				// Bullets & Molds
				//----------------------------------------------------------------------------*

				int nBulletCount = 0;
				int nBulletMoldCount = 0;

				if (m_OriginalManufacturer.Bullets || m_Manufacturer.BulletMolds)
					{
					foreach (cBullet Bullet in m_DataFiles.BulletList)
						{
						if (Bullet.Manufacturer.CompareTo(m_OriginalManufacturer) == 0)
							{
							if (Bullet.SelfCast)
								nBulletMoldCount++;
							else
								nBulletCount++;
							}
						}

					if (nBulletCount > 0)
						{
						BulletsCheckBox.Enabled = false;

						if (strProducts.Length > 0)
							{
							strProducts += ", ";

							nLastCommaIndex = strProducts.IndexOf(',', nLastCommaIndex > 0 ? nLastCommaIndex + 1 : 0);
							}

						strProducts += String.Format("{0:N0} bullet{1}", nBulletCount, nBulletCount > 1 ? "s" : "");

						nProductCount++;
						}

					if (nBulletMoldCount > 0)
						{
						BulletMoldsCheckBox.Enabled = false;

						if (strProducts.Length > 0)
							{
							strProducts += ", ";

							nLastCommaIndex = strProducts.IndexOf(',', nLastCommaIndex > 0 ? nLastCommaIndex + 1 : 0);
							}

						strProducts += String.Format("{0:N0} bullet mold{1}", nBulletMoldCount, nBulletMoldCount > 1 ? "s" : "");

						nProductCount++;
						}
					}

				//----------------------------------------------------------------------------*
				// Cases
				//----------------------------------------------------------------------------*

				int nCaseCount = 0;

				if (m_OriginalManufacturer.Cases)
					{
					foreach (cCase Case in m_DataFiles.CaseList)
						{
						if (Case.Manufacturer.CompareTo(m_OriginalManufacturer) == 0)
							nCaseCount++;
						}

					if (nCaseCount > 0)
						{
						CasesCheckBox.Enabled = false;

						if (strProducts.Length > 0)
							{
							strProducts += ", ";

							nLastCommaIndex = strProducts.IndexOf(',', nLastCommaIndex > 0 ? nLastCommaIndex + 1 : 0);
							}

						strProducts += String.Format("{0:N0} case{1}", nCaseCount, nCaseCount > 1 ? "s" : "");

						nProductCount++;
						}
					}

				//----------------------------------------------------------------------------*
				// Powders
				//----------------------------------------------------------------------------*

				int nPowderCount = 0;

				if (m_Manufacturer.Powder)
					{
					foreach (cPowder Powder in m_DataFiles.PowderList)
						{
						if (Powder.Manufacturer.CompareTo(m_OriginalManufacturer) == 0)
							nPowderCount++;
						}

					if (nPowderCount > 0)
						{
						PowderCheckBox.Enabled = false;

						if (strProducts.Length > 0)
							{
							strProducts += ", ";

							nLastCommaIndex = strProducts.IndexOf(',', nLastCommaIndex > 0 ? nLastCommaIndex + 1 : 0);
							}

						strProducts += String.Format("{0:N0} powder{1}", nPowderCount, nPowderCount > 1 ? "s" : "");

						nProductCount++;
						}
					}

				//----------------------------------------------------------------------------*
				// Primers
				//----------------------------------------------------------------------------*

				int nPrimerCount = 0;

				if (m_Manufacturer.Primers)
					{
					foreach (cPrimer Primer in m_DataFiles.PrimerList)
						{
						if (Primer.Manufacturer.CompareTo(m_OriginalManufacturer) == 0)
							nPrimerCount++;
						}

					if (nPrimerCount > 0)
						{
						PrimersCheckBox.Enabled = false;

						if (strProducts.Length > 0)
							{
							strProducts += ", ";

							nLastCommaIndex = strProducts.IndexOf(',', nLastCommaIndex > 0 ? nLastCommaIndex + 1 : 0);
							}

						strProducts += String.Format("{0:N0} primer{1}", nPrimerCount, nPrimerCount > 1 ? "s" : "");

						nProductCount++;
						}
					}

				if (strProducts.Length > 0)
					{
					if (nLastCommaIndex > 0)
						{
						strProducts = strProducts.Substring(0, nLastCommaIndex) + " and" + strProducts.Substring(nLastCommaIndex + 1);
						}

					strProducts = "This manufacturer has been used in " + strProducts + ".";

					if (nProductCount > 1)
						strProducts += "  Those product selections may not be changed.";
					else
						strProducts += "  That product selection may not be changed.";

					ProductUseLabel.ForeColor = Color.Maroon;
					ProductUseLabel.TextAlign = ContentAlignment.TopLeft;

					ProductUseLabel.Text = strProducts;
					}
				else
					{
					ProductUseLabel.ForeColor = SystemColors.ControlText;
					ProductUseLabel.TextAlign = ContentAlignment.MiddleCenter;

					ProductUseLabel.Text = "This manufacturer's products have not yet been used.";
					}
				}
			else
				ProductUseLabel.Text = "";
			}

		//============================================================================*
		// Manufacturer Property
		//============================================================================*

		public cManufacturer Manufacturer
			{
			get
				{
				return (m_Manufacturer);
				}
			}

		//============================================================================*
		// OnCheckBoxClicked()
		//============================================================================*

		private void OnCheckBoxClicked(object sender, EventArgs e)
			{
			CheckBox CheckBox = (CheckBox) sender;

			switch (CheckBox.Name)
				{
				case "AmmoCheckBox":
					m_Manufacturer.Ammo = CheckBox.Checked;
					break;

				case "BulletsCheckBox":
					m_Manufacturer.Bullets = CheckBox.Checked;
					break;

				case "CasesCheckBox":
					m_Manufacturer.Cases = CheckBox.Checked;
					break;

				case "PowderCheckBox":
					m_Manufacturer.Powder = CheckBox.Checked;
					break;

				case "PrimersCheckBox":
					m_Manufacturer.Primers = CheckBox.Checked;
					break;

				case "BulletMoldsCheckBox":
					m_Manufacturer.BulletMolds = CheckBox.Checked;
					break;

				case "HandgunsCheckBox":
					m_Manufacturer.Handguns = CheckBox.Checked;
					break;

				case "RiflesCheckBox":
					m_Manufacturer.Rifles = CheckBox.Checked;
					break;

				case "ShotgunsCheckBox":
					m_Manufacturer.Shotguns = CheckBox.Checked;
					break;

				case "ScopesCheckBox":
					m_Manufacturer.Scopes = CheckBox.Checked;
					break;

				case "RedDotsCheckBox":
					m_Manufacturer.RedDots = CheckBox.Checked;
					break;

				case "LightsCheckBox":
					m_Manufacturer.Lights = CheckBox.Checked;
					break;

				case "TriggersCheckBox":
					m_Manufacturer.Triggers = CheckBox.Checked;
					break;

				case "FurnitureCheckBox":
					m_Manufacturer.Furniture = CheckBox.Checked;
					break;

				case "BipodsCheckBox":
					m_Manufacturer.Bipods = CheckBox.Checked;
					break;

				case "PartsCheckBox":
					m_Manufacturer.Parts = CheckBox.Checked;
					break;

				case "OtherCheckBox":
					m_Manufacturer.Misc = CheckBox.Checked;
					break;
				}

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnHeadStampChanged()
		//============================================================================*

		private void OnHeadStampChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Manufacturer.HeadStamp = HeadStampTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnNameChanged()
		//============================================================================*

		private void OnNameChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Manufacturer.Name = NameTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnOKClicked()
		//============================================================================*

		private void OnOKClicked(object sender, EventArgs e)
			{
			if (!m_fViewOnly)
				{
				if (m_fAdd)
					AddManufacturer();
				else
					UpdateManufacturer();
				}
			}

		//============================================================================*
		// OnWebsiteChanged()
		//============================================================================*

		private void OnWebsiteChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Manufacturer.Website = WebsiteTextBox.Value;

			m_Manufacturer.WebSiteVisited = false;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;

			NameTextBox.ToolTip = cm_strNameToolTip;

			WebsiteTextBox.ToolTip = cm_strWebsiteToolTip;

			HeadStampTextBox.ToolTip = cm_strHeadStampToolTip;

			m_ProductsToolTip.ShowAlways = true;
			m_ProductsToolTip.RemoveAll();
			m_ProductsToolTip.SetToolTip(AmmoCheckBox, cm_strProductsToolTip);
			m_ProductsToolTip.SetToolTip(BulletsCheckBox, cm_strProductsToolTip);
			m_ProductsToolTip.SetToolTip(CasesCheckBox, cm_strProductsToolTip);
			m_ProductsToolTip.SetToolTip(PowderCheckBox, cm_strProductsToolTip);
			m_ProductsToolTip.SetToolTip(PrimersCheckBox, cm_strProductsToolTip);
			m_ProductsToolTip.SetToolTip(BulletMoldsCheckBox, cm_strProductsToolTip);

			m_ProductsToolTip.SetToolTip(HandgunsCheckBox, cm_strProductsToolTip);
			m_ProductsToolTip.SetToolTip(RiflesCheckBox, cm_strProductsToolTip);
			m_ProductsToolTip.SetToolTip(ShotgunsCheckBox, cm_strProductsToolTip);

			m_ProductsToolTip.SetToolTip(ScopesCheckBox, cm_strProductsToolTip);
			m_ProductsToolTip.SetToolTip(RedDotsCheckBox, cm_strProductsToolTip);
			m_ProductsToolTip.SetToolTip(LightsCheckBox, cm_strProductsToolTip);
			m_ProductsToolTip.SetToolTip(TriggersCheckBox, cm_strProductsToolTip);
			m_ProductsToolTip.SetToolTip(FurnitureCheckBox, cm_strProductsToolTip);
			m_ProductsToolTip.SetToolTip(BipodsCheckBox, cm_strProductsToolTip);
			m_ProductsToolTip.SetToolTip(PartsCheckBox, cm_strProductsToolTip);
			m_ProductsToolTip.SetToolTip(OtherCheckBox, cm_strProductsToolTip);

			m_ManufacturerOKButtonToolTip.ShowAlways = true;
			m_ManufacturerOKButtonToolTip.RemoveAll();
			m_ManufacturerOKButtonToolTip.SetToolTip(ManufacturerOKButton, cm_strManufacturerOKButtonToolTip);

			m_ManufacturerCancelButtonToolTip.ShowAlways = true;
			m_ManufacturerCancelButtonToolTip.RemoveAll();
			m_ManufacturerCancelButtonToolTip.SetToolTip(ManufacturerCancelButton, cm_strManufacturerCancelButtonToolTip);
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			bool fEnableOK = m_fChanged;
			string strToolTip = "";

			//----------------------------------------------------------------------------*
			// Check Name
			//----------------------------------------------------------------------------*

			strToolTip = cm_strNameToolTip;

			if (!NameTextBox.ValueOK)
				{
				fEnableOK = false;
				}
			else
				{
				//----------------------------------------------------------------------------*
				// Check for duplicate
				//----------------------------------------------------------------------------*

				bool fDuplicate = false;

				if (m_fAdd || (m_OriginalManufacturer != null &&  m_OriginalManufacturer.Name.ToUpper() != m_Manufacturer.Name.ToUpper()))
					{
					foreach (cManufacturer CheckManufacturer in m_DataFiles.ManufacturerList)
						{
						if (m_fAdd || (CheckManufacturer.Name.ToUpper() != m_OriginalManufacturer.Name.ToUpper()))
							{
							if (m_Manufacturer.Name.ToUpper() == CheckManufacturer.Name.ToUpper())
								{
								fDuplicate = true;

								fEnableOK = false;

								NameTextBox.BackColor = Color.LightPink;

								strToolTip += String.Format("\n\nThis manufacturer, \"{0}\", already exists.  Duplicate names are not allowed.", NameTextBox.Value);

								break;
								}
							}
						}
					}

				//----------------------------------------------------------------------------*
				// OK, it's not a duplicate, see if the name is "Batch Editor"
				//----------------------------------------------------------------------------*

				if (!fDuplicate)
					{
					if (m_Manufacturer.Name.ToUpper() != "BATCH EDITOR")
						NameTextBox.BackColor = SystemColors.Window;
					else
						{
						fEnableOK = false;

						NameTextBox.BackColor = Color.LightPink;

						strToolTip += "\n\nThe name \"Batch Editor\" is reserved for the inventory system.";
						}
					}
				}

			if (m_DataFiles.Preferences.ToolTips)
				NameTextBox.ToolTip = strToolTip;

			//----------------------------------------------------------------------------*
			// Check Website
			//----------------------------------------------------------------------------*

			if (!WebsiteTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check product radio buttons
			//----------------------------------------------------------------------------*

			strToolTip = cm_strProductsToolTip;

			if (!AmmoCheckBox.Checked &&
				!BulletsCheckBox.Checked &&
				!CasesCheckBox.Checked &&
				!PowderCheckBox.Checked &&
				!PrimersCheckBox.Checked &&
				!BulletMoldsCheckBox.Checked &&
				!HandgunsCheckBox.Checked &&
				!RiflesCheckBox.Checked &&
				!ShotgunsCheckBox.Checked &&
				!ScopesCheckBox.Checked &&
				!RedDotsCheckBox.Checked &&
				!LightsCheckBox.Checked &&
				!TriggersCheckBox.Checked &&
				!FurnitureCheckBox.Checked &&
				!BipodsCheckBox.Checked &&
				!PartsCheckBox.Checked &&
				!OtherCheckBox.Checked)
				{
				fEnableOK = false;

				AmmoCheckBox.BackColor = Color.LightPink;
				BulletsCheckBox.BackColor = Color.LightPink;
				CasesCheckBox.BackColor = Color.LightPink;
				PowderCheckBox.BackColor = Color.LightPink;
				PrimersCheckBox.BackColor = Color.LightPink;
				BulletMoldsCheckBox.BackColor = Color.LightPink;
				HandgunsCheckBox.BackColor = Color.LightPink;
				RiflesCheckBox.BackColor = Color.LightPink;
				ShotgunsCheckBox.BackColor = Color.LightPink;

				ScopesCheckBox.BackColor = Color.LightPink;
				RedDotsCheckBox.BackColor = Color.LightPink;
				LightsCheckBox.BackColor = Color.LightPink;
				TriggersCheckBox.BackColor = Color.LightPink;
				FurnitureCheckBox.BackColor = Color.LightPink;
				BipodsCheckBox.BackColor = Color.LightPink;
				PartsCheckBox.BackColor = Color.LightPink;
				OtherCheckBox.BackColor = Color.LightPink;

				strToolTip += "\n\nYou must select at least one product type.";
				}
			else
				{
				AmmoCheckBox.BackColor = SystemColors.Control;
				BulletsCheckBox.BackColor = SystemColors.Control;
				CasesCheckBox.BackColor = SystemColors.Control;
				PowderCheckBox.BackColor = SystemColors.Control;
				PrimersCheckBox.BackColor = SystemColors.Control;
				BulletMoldsCheckBox.BackColor = SystemColors.Control;
				HandgunsCheckBox.BackColor = SystemColors.Control;
				RiflesCheckBox.BackColor = SystemColors.Control;
				ShotgunsCheckBox.BackColor = SystemColors.Control;

				ScopesCheckBox.BackColor = SystemColors.Control;
				RedDotsCheckBox.BackColor = SystemColors.Control;
				LightsCheckBox.BackColor = SystemColors.Control;
				TriggersCheckBox.BackColor = SystemColors.Control;
				FurnitureCheckBox.BackColor = SystemColors.Control;
				BipodsCheckBox.BackColor = SystemColors.Control;
				PartsCheckBox.BackColor = SystemColors.Control;
				OtherCheckBox.BackColor = SystemColors.Control;
				}

			if (m_DataFiles.Preferences.ToolTips)
				{
				m_ProductsToolTip.SetToolTip(AmmoCheckBox, strToolTip);
				m_ProductsToolTip.SetToolTip(BulletsCheckBox, strToolTip);
				m_ProductsToolTip.SetToolTip(BulletMoldsCheckBox, strToolTip);
				m_ProductsToolTip.SetToolTip(CasesCheckBox, strToolTip);
				m_ProductsToolTip.SetToolTip(PowderCheckBox, strToolTip);
				m_ProductsToolTip.SetToolTip(PrimersCheckBox, strToolTip);

				m_ProductsToolTip.SetToolTip(HandgunsCheckBox, strToolTip);
				m_ProductsToolTip.SetToolTip(RiflesCheckBox, strToolTip);
				m_ProductsToolTip.SetToolTip(ShotgunsCheckBox, strToolTip);

				m_ProductsToolTip.SetToolTip(ScopesCheckBox, strToolTip);
				m_ProductsToolTip.SetToolTip(RedDotsCheckBox, strToolTip);
				m_ProductsToolTip.SetToolTip(LightsCheckBox, strToolTip);
				m_ProductsToolTip.SetToolTip(TriggersCheckBox, strToolTip);
				m_ProductsToolTip.SetToolTip(FurnitureCheckBox, strToolTip);
				m_ProductsToolTip.SetToolTip(BipodsCheckBox, strToolTip);
				m_ProductsToolTip.SetToolTip(PartsCheckBox, strToolTip);
				m_ProductsToolTip.SetToolTip(OtherCheckBox, strToolTip);
				}

			//----------------------------------------------------------------------------*
			// Check HeadStamp
			//----------------------------------------------------------------------------*

			HeadStampTextBox.Enabled = CasesCheckBox.Checked;

			if (!HeadStampTextBox.Enabled)
				HeadStampTextBox.Value = "";

			if (!HeadStampTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Enable or disable the Ok button
			//----------------------------------------------------------------------------*

			ManufacturerOKButton.Enabled = fEnableOK;
			}

		//============================================================================*
		// UpdateManufacturer()
		//============================================================================*

		private void UpdateManufacturer()
			{
			//----------------------------------------------------------------------------*
			// Find the manufacturer
			//----------------------------------------------------------------------------*

			foreach (cManufacturer CheckManufacturer in m_DataFiles.ManufacturerList)
				{
				//----------------------------------------------------------------------------*
				// If this is the same manufacturer, copy the new data
				//----------------------------------------------------------------------------*

				if (CheckManufacturer.CompareTo(m_OriginalManufacturer) == 0)
					{
					CheckManufacturer.Copy(m_Manufacturer);

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// If the manufacturer was not found, add it
			//----------------------------------------------------------------------------*

			AddManufacturer();
			}
		}
	}
