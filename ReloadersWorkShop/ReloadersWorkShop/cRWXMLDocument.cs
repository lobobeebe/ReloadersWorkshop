//============================================================================*
// cRWXMLDocument.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cRWXMLDocument Class
	//============================================================================*

	public class cRWXMLDocument : cXMLDocument
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		private bool m_fFullDataDump = true;

		private bool m_fIncludeManufacturers = true;
		private bool m_fIncludeCalibers = true;
		private bool m_fIncludeFirearms = true;
		private bool m_fIncludeAmmo = true;
		private bool m_fIncludeBullets = true;
		private bool m_fIncludeCases = true;
		private bool m_fIncludePowders = true;
		private bool m_fIncludePrimers = true;
		private bool m_fIncludeLoads = true;
		private bool m_fIncludeBatches = true;

		//============================================================================*
		// cRWXMLDocument() - Constructor
		//============================================================================*

		public cRWXMLDocument(cDataFiles DataFiles)
			{
			m_DataFiles = DataFiles;
			}

		//============================================================================*
		// CreateElement() - FirearmType
		//============================================================================*

		public XmlElement CreateElement(string strName, cFirearm.eFireArmType eType, XmlNode XMLParentNode)
			{
			return (CreateElement(strName, cFirearm.FirearmTypeString(eType), XMLParentNode));
			}

		//============================================================================*
		// CreateElement() - PowderShape
		//============================================================================*

		public XmlElement CreateElement(string strName, cPowder.ePowderShapes eShape, XmlNode XMLParentNode)
			{
			return (CreateElement(strName, cPowder.ShapeString(eShape), XMLParentNode));
			}

		//============================================================================*
		// CreateElement() - PrimerSize
		//============================================================================*

		public XmlElement CreateElement(string strName, cPrimer.ePrimerSize eSize, XmlNode XMLParentNode)
			{
			return (CreateElement(strName, cPrimer.ToShortSizeString(eSize), XMLParentNode));
			}

		//============================================================================*
		// CreateElement() - SupplyType
		//============================================================================*

		public XmlElement CreateElement(string strName, cSupply.eSupplyTypes eType, XmlNode XMLParentNode)
			{
			return (CreateElement(strName, cSupply.SupplyTypeString(eType), XMLParentNode));
			}

		//============================================================================*
		// CreateElement() - TransactionType
		//============================================================================*

		public XmlElement CreateElement(string strName, cTransaction.eTransactionType eType, XmlNode XMLParentNode)
			{
			return (CreateElement(strName, cTransaction.TransactionTypeString(eType), XMLParentNode));
			}

		//============================================================================*
		// CreateElement() - TurretType
		//============================================================================*

		public XmlElement CreateElement(string strName, cFirearm.eTurretType eType, XmlNode XMLParentNode)
			{
			return (CreateElement(strName, cFirearm.TurretTypeString(eType), XMLParentNode));
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(bool fComplete = true)
			{
			//----------------------------------------------------------------------------*
			// Create Declaration
			//----------------------------------------------------------------------------*

			CreateXMLDeclaration();

			//----------------------------------------------------------------------------*
			// Create the Main Element
			//----------------------------------------------------------------------------*

			XmlElement MainElement = CreateElement("Body");
			AppendChild(MainElement);

			XmlText XMLTextElement = CreateTextNode(String.Format("{0} {1} Data File Export", Application.ProductName, fComplete ? "Complete" : "Partial"));
			MainElement.AppendChild(XMLTextElement);

			if (fComplete || m_fIncludeManufacturers)
				m_DataFiles.ManufacturerList.Export(this, MainElement);

			if (fComplete || m_fIncludeCalibers)
				m_DataFiles.CaliberList.Export(this, MainElement);

			if (fComplete || m_fIncludeBullets)
				m_DataFiles.BulletList.Export(this, MainElement);

			if (fComplete || m_fIncludeFirearms)
				m_DataFiles.FirearmList.Export(this, MainElement);

			if (fComplete || m_fIncludeAmmo)
				m_DataFiles.AmmoList.Export(this, MainElement);

			if (fComplete || m_fIncludePowders)
				m_DataFiles.PowderList.Export(this, MainElement);

			if (fComplete || m_fIncludePrimers)
				m_DataFiles.PrimerList.Export(this, MainElement);

			if (fComplete || m_fIncludeCases)
				m_DataFiles.CaseList.Export(this, MainElement);

			if (fComplete || m_fIncludeLoads)
				m_DataFiles.LoadList.Export(this, MainElement);

			if (fComplete || m_fIncludeBatches)
				m_DataFiles.BatchList.Export(this, MainElement);

			if (fComplete)
				m_DataFiles.Preferences.Export(this, MainElement);
			}

		//============================================================================*
		// FullDataDump Property
		//============================================================================*

		public bool FullDataDump
			{
			get
				{
				return (m_fFullDataDump);
				}
			set
				{
				m_fFullDataDump = value;
				}
			}

		//============================================================================*
		// GetAmmoByIdentity()
		//============================================================================*

		public static cAmmo GetAmmoByIdentity(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			cAmmo AmmoIdentity = new cAmmo(true);

			if (AmmoIdentity.Import(XMLDocument, XMLThisNode, DataFiles))
				return (GetAmmoByIdentity(AmmoIdentity, DataFiles));

			return (AmmoIdentity);
			}

		//============================================================================*
		// GetAmmoByIdentity()
		//============================================================================*

		public static cAmmo GetAmmoByIdentity(cAmmo AmmoIdentity, cDataFiles DataFiles)
			{
			if (!AmmoIdentity.Identity || !AmmoIdentity.Validate(true))
				return (AmmoIdentity);

			foreach (cAmmo Ammo in DataFiles.AmmoList)
				{
				if (AmmoIdentity.CompareTo(Ammo) == 0)
					return (Ammo);
				}

			return (AmmoIdentity);
			}

		//============================================================================*
		// GetBulletByIdentity()
		//============================================================================*

		public static cBullet GetBulletByIdentity(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			cBullet BulletIdentity = new cBullet(true);

			if (BulletIdentity.Import(XMLDocument, XMLThisNode, DataFiles))
				return (GetBulletByIdentity(BulletIdentity, DataFiles));

			return (BulletIdentity);
			}

		//============================================================================*
		// GetBulletByIdentity()
		//============================================================================*

		public static cBullet GetBulletByIdentity(cBullet BulletIdentity, cDataFiles DataFiles)
			{
			if (!BulletIdentity.Identity || !BulletIdentity.Validate(true))
				return (BulletIdentity);

			foreach (cBullet Bullet in DataFiles.BulletList)
				{
				if (BulletIdentity.CompareTo(Bullet) == 0)
					return (Bullet);
				}

			return (BulletIdentity);
			}

		//============================================================================*
		// GetCaliberByIdentity()
		//============================================================================*

		public static cCaliber GetCaliberByIdentity(cCaliber CaliberIdentity, cDataFiles DataFiles)
			{
			if (!CaliberIdentity.Identity || !CaliberIdentity.Validate(true))
				return (CaliberIdentity);

			foreach (cCaliber Caliber in DataFiles.CaliberList)
				{
				if (CaliberIdentity.CompareTo(Caliber) == 0)
					return (Caliber);
				}

			return (CaliberIdentity);
			}

		//============================================================================*
		// GetCaliberByIdentity()
		//============================================================================*

		public static cCaliber GetCaliberByIdentity(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			cCaliber CaliberIdentity = new cCaliber(true);

			if (CaliberIdentity.Import(XMLDocument, XMLThisNode))
				return (GetCaliberByIdentity(CaliberIdentity, DataFiles));

			return (CaliberIdentity);
			}

		//============================================================================*
		// GetCaseByIdentity()
		//============================================================================*

		public static cCase GetCaseByIdentity(cCase CaseIdentity, cDataFiles DataFiles)
			{
			if (!CaseIdentity.Identity || !CaseIdentity.Validate())
				return (CaseIdentity);

			foreach (cCase Case in DataFiles.CaseList)
				{
				if (CaseIdentity.CompareTo(Case) == 0)
					return (Case);
				}

			return (CaseIdentity);
			}

		//============================================================================*
		// GetCaseByIdentity()
		//============================================================================*

		public static cCase GetCaseByIdentity(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			cCase CaseIdentity = new cCase(true);

			if (CaseIdentity.Import(XMLDocument, XMLThisNode, DataFiles))
				return (GetCaseByIdentity(CaseIdentity, DataFiles));

			return (CaseIdentity);
			}

		//============================================================================*
		// GetFirearmByIdentity()
		//============================================================================*

		public static cFirearm GetFirearmByIdentity(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			cFirearm FirearmIdentity = new cFirearm(true);

			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "Manufacturer":
						FirearmIdentity.Manufacturer = DataFiles.GetManufacturerByName(XMLNode.FirstChild.Value);
						break;
					case "FirearmType":
						FirearmIdentity.FirearmType = cFirearm.FirearmTypeFromString(XMLNode.FirstChild.Value);
						break;
					case "Model":
						FirearmIdentity.PartNumber = XMLNode.FirstChild.Value;
						break;
					case "SerialNumber":
						FirearmIdentity.SerialNumber = XMLNode.FirstChild.Value;
						break;
					default:
						break;
					}

				XMLNode = XMLNode.NextSibling;
				}

			foreach (cFirearm Firearm in DataFiles.FirearmList)
				{
				if (FirearmIdentity.CompareTo(Firearm) == 0)
					return (Firearm);
				}

			return (null);
			}

		//============================================================================*
		// GetLoadByIdentity()
		//============================================================================*

		public static cLoad GetLoadByIdentity(cLoad LoadIdentity, cDataFiles DataFiles)
			{
			if (!LoadIdentity.Identity || !LoadIdentity.Validate(true))
				return (LoadIdentity);

			foreach (cLoad Load in DataFiles.LoadList)
				{
				if (LoadIdentity.CompareTo(Load) == 0)
					return (Load);
				}

			return (LoadIdentity);
			}

		//============================================================================*
		// GetLoadByIdentity()
		//============================================================================*

		public static cLoad GetLoadByIdentity(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			cLoad LoadIdentity = new cLoad(true);

			LoadIdentity.Import(XMLDocument, XMLThisNode, DataFiles);

			return (GetLoadByIdentity(LoadIdentity, DataFiles));
			}

		//============================================================================*
		// GetPowderByIdentity()
		//============================================================================*

		public static cPowder GetPowderByIdentity(cPowder PowderIdentity, cDataFiles DataFiles)
			{
			if (!PowderIdentity.Identity || !PowderIdentity.Validate())
				return (PowderIdentity);

			foreach (cPowder Powder in DataFiles.PowderList)
				{
				if (PowderIdentity.CompareTo(Powder) == 0)
					return (Powder);
				}

			return (PowderIdentity);
			}

		//============================================================================*
		// GetPowderByIdentity()
		//============================================================================*

		public static cPowder GetPowderByIdentity(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			cPowder PowderIdentity = new cPowder(true);

			PowderIdentity.Import(XMLDocument, XMLThisNode, DataFiles);

			return (GetPowderByIdentity(PowderIdentity, DataFiles));
			}

		//============================================================================*
		// GetPrimerByIdentity()
		//============================================================================*

		public static cPrimer GetPrimerByIdentity(cPrimer PrimerIdentity, cDataFiles DataFiles)
			{
			if (!PrimerIdentity.Identity || !PrimerIdentity.Validate(true))
				return (PrimerIdentity);

			foreach (cPrimer Primer in DataFiles.PrimerList)
				{
				if (PrimerIdentity.CompareTo(Primer) == 0)
					return (Primer);
				}

			return (PrimerIdentity);
			}

		//============================================================================*
		// GetPrimerByIdentity()
		//============================================================================*

		public static cPrimer GetPrimerByIdentity(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			cPrimer PrimerIdentity = new cPrimer(true);

			PrimerIdentity.Import(XMLDocument, XMLThisNode, DataFiles);

			return (GetPrimerByIdentity(PrimerIdentity, DataFiles));
			}

		//============================================================================*
		// GetSupplyByIdentity()
		//============================================================================*

		public static cSupply GetSupplyByIdentity(cSupply SupplyIdentity, cDataFiles DataFiles)
			{
			if (SupplyIdentity == null || !SupplyIdentity.Identity || !SupplyIdentity.Validate(true))
				return (SupplyIdentity);

			switch (SupplyIdentity.SupplyType)
				{
				case cSupply.eSupplyTypes.Ammo:
					foreach (cSupply Supply in DataFiles.AmmoList)
						{
						if (SupplyIdentity.CompareTo(Supply) == 0)
							return (Supply);
						}

					break;

				case cSupply.eSupplyTypes.Bullets:
					foreach (cSupply Supply in DataFiles.BulletList)
						{
						if (SupplyIdentity.CompareTo(Supply) == 0)
							return (Supply);
						}

					break;

				case cSupply.eSupplyTypes.Cases:
					foreach (cSupply Supply in DataFiles.CaseList)
						{
						if (SupplyIdentity.CompareTo(Supply) == 0)
							return (Supply);
						}

					break;

				case cSupply.eSupplyTypes.Powder:
					foreach (cSupply Supply in DataFiles.PowderList)
						{
						if (SupplyIdentity.CompareTo(Supply) == 0)
							return (Supply);
						}

					break;

				case cSupply.eSupplyTypes.Primers:
					foreach (cSupply Supply in DataFiles.PrimerList)
						{
						if (SupplyIdentity.CompareTo(Supply) == 0)
							return (Supply);
						}

					break;
				}

			return (SupplyIdentity);
			}

		//============================================================================*
		// GetSupplyByIdentity()
		//============================================================================*

		public static cSupply GetSupplyByIdentity(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles, cSupply.eSupplyTypes eType)
			{
			switch (eType)
				{
				case cSupply.eSupplyTypes.Ammo:
					cAmmo AmmoIdentity = new cAmmo(true);

					if (AmmoIdentity.Import(XMLDocument, XMLThisNode, DataFiles))
						return (GetAmmoByIdentity(AmmoIdentity, DataFiles));

					return (AmmoIdentity);

				case cSupply.eSupplyTypes.Bullets:
					cBullet BulletIdentity = new cBullet(true);

					if (BulletIdentity.Import(XMLDocument, XMLThisNode, DataFiles))
						return (GetBulletByIdentity(BulletIdentity, DataFiles));

					return (BulletIdentity);

				case cSupply.eSupplyTypes.Cases:
					cCase CaseIdentity = new cCase(true);

					if (CaseIdentity.Import(XMLDocument, XMLThisNode, DataFiles))
						return (GetCaseByIdentity(CaseIdentity, DataFiles));

					return (CaseIdentity);

				case cSupply.eSupplyTypes.Powder:
					cPowder PowderIdentity = new cPowder(true);

					if (PowderIdentity.Import(XMLDocument, XMLThisNode, DataFiles))
						return (GetPowderByIdentity(PowderIdentity, DataFiles));

					return (PowderIdentity);

				case cSupply.eSupplyTypes.Primers:
					cPrimer PrimerIdentity = new cPrimer(true);

					if (PrimerIdentity.Import(XMLDocument, XMLThisNode, DataFiles))
						return (GetPrimerByIdentity(PrimerIdentity, DataFiles));

					return (PrimerIdentity);
				}

			return (null);
			}

		//============================================================================*
		// IncludeAmmo Property
		//============================================================================*

		public bool IncludeAmmo
			{
			get
				{
				return (m_fIncludeAmmo);
				}
			set
				{
				m_fIncludeAmmo = value;
				}
			}

		//============================================================================*
		// Import() - XML
		//============================================================================*

		public bool Import(string strFilePath, bool fMerge = true)
			{
			//----------------------------------------------------------------------------*
			// Make sure the file exists
			//----------------------------------------------------------------------------*

			if (!File.Exists(strFilePath))
				return (false);

			//----------------------------------------------------------------------------*
			// Reset the data if not merging
			//----------------------------------------------------------------------------*

			if (!fMerge)
				m_DataFiles.Reset();

			//----------------------------------------------------------------------------*
			// Create and Load the XML document
			//----------------------------------------------------------------------------*

			try
				{
				Load(strFilePath);
				}
			catch
				{
				string strMessage = String.Format("Unable to load {0}!\n\nThis may not be a valid XML file!", strFilePath);

				MessageBox.Show(strMessage, "XML Load Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				return (false);
				}

			//----------------------------------------------------------------------------*
			// Make sure it's an RW XML file
			//----------------------------------------------------------------------------*

			XmlElement XMLRoot = DocumentElement;

			if (XMLRoot.FirstChild == null || !(XMLRoot.FirstChild is XmlText) || (XMLRoot.FirstChild as XmlText).Value.IndexOf(Application.ProductName) < 0)
				{
				string strMessage = String.Format("{0} does not appear to contain {1} data!", strFilePath, Application.ProductName);

				MessageBox.Show(strMessage, "XML Data Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				return (false);
				}

			//----------------------------------------------------------------------------*
			// OK, if we get to here, go for it...
			//----------------------------------------------------------------------------*

			Import();

			//----------------------------------------------------------------------------*
			// Return success!
			//----------------------------------------------------------------------------*

			return (true);
			}

		//============================================================================*
		// Import() - XML Document
		//============================================================================*

		public bool Import(bool fMerge = true)
			{
			XmlElement XMLRoot = DocumentElement;

			//----------------------------------------------------------------------------*
			// Start looping through the child elements
			//----------------------------------------------------------------------------*

			XmlNode XMLNode = XMLRoot.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "Ammunition":
					case "AmmoList":
						m_DataFiles.AmmoList.Import(this, XMLNode, m_DataFiles);

						break;

					case "Preferences":
						m_DataFiles.Preferences.Import(this, XMLNode);

						break;

					case "Manufacturers":
					case "ManufacturerList":
						m_DataFiles.ManufacturerList.Import(this, XMLNode);

						break;

					case "Calibers":
					case "CaliberList":
						m_DataFiles.CaliberList.Import(this, XMLNode);

						break;

					case "Bullets":
					case "BulletList":
						m_DataFiles.BulletList.Import(this, XMLNode, m_DataFiles);

						break;

					case "Firearms":
					case "FirearmList":
						m_DataFiles.FirearmList.Import(this, XMLNode, m_DataFiles);

						break;

					case "Cases":
					case "CaseList":
						m_DataFiles.CaseList.Import(this, XMLNode, m_DataFiles);

						break;

					case "Powders":
					case "PowderList":
						m_DataFiles.PowderList.Import(this, XMLNode, m_DataFiles);

						break;

					case "Primers":
					case "PrimerList":
						m_DataFiles.PrimerList.Import(this, XMLNode, m_DataFiles);

						break;

					case "Loads":
					case "LoadList":
						m_DataFiles.LoadList.Import(this, XMLNode, m_DataFiles);

						break;

					case "Batches":
					case "BatchList":
						m_DataFiles.BatchList.Import(this, XMLNode, m_DataFiles);

						break;

					case "GearList":
						m_DataFiles.GearList.Import(this, XMLNode, m_DataFiles);

						break;

					default:
						break;
					}

				XMLNode = XMLNode.NextSibling;
				}

			return (true);
			}

		//============================================================================*
		// Import() - FirearmType
		//============================================================================*

		public void Import(XmlNode XMLThisNode, out cFirearm.eFireArmType eType)
			{
			eType = cFirearm.eFireArmType.None;

			if (XMLThisNode != null && XMLThisNode.FirstChild != null && XMLThisNode.FirstChild.Value != null)
				eType = cFirearm.FirearmTypeFromString(XMLThisNode.FirstChild.Value);
			}

		//============================================================================*
		// Import() - SupplyType
		//============================================================================*

		public void Import(XmlNode XMLThisNode, out cSupply.eSupplyTypes eType)
			{
			eType = cSupply.eSupplyTypes.Unknown;

			if (XMLThisNode != null && XMLThisNode.FirstChild != null && XMLThisNode.FirstChild.Value != null)
				eType = cSupply.SupplyTypeFromString(XMLThisNode.FirstChild.Value);
			}

		//============================================================================*
		// IncludeBatches Property
		//============================================================================*

		public bool IncludeBatches
			{
			get
				{
				return (m_fIncludeBatches);
				}
			set
				{
				m_fIncludeBatches = value;
				}
			}

		//============================================================================*
		// IncludeBullets Property
		//============================================================================*

		public bool IncludeBullets
			{
			get
				{
				return (m_fIncludeBullets);
				}
			set
				{
				m_fIncludeBullets = value;
				}
			}

		//============================================================================*
		// IncludeCalibers Property
		//============================================================================*

		public bool IncludeCalibers
			{
			get
				{
				return (m_fIncludeCalibers);
				}
			set
				{
				m_fIncludeCalibers = value;
				}
			}

		//============================================================================*
		// IncludeCases Property
		//============================================================================*

		public bool IncludeCases
			{
			get
				{
				return (m_fIncludeCases);
				}
			set
				{
				m_fIncludeCases = value;
				}
			}

		//============================================================================*
		// IncludeFirearms Property
		//============================================================================*

		public bool IncludeFirearms
			{
			get
				{
				return (m_fIncludeFirearms);
				}
			set
				{
				m_fIncludeFirearms = value;
				}
			}

		//============================================================================*
		// IncludeLoads Property
		//============================================================================*

		public bool IncludeLoads
			{
			get
				{
				return (m_fIncludeLoads);
				}
			set
				{
				m_fIncludeLoads = value;
				}
			}

		//============================================================================*
		// IncludeManufacturers Property
		//============================================================================*

		public bool IncludeManufacturers
			{
			get
				{
				return (m_fIncludeManufacturers);
				}
			set
				{
				m_fIncludeManufacturers = value;
				}
			}

		//============================================================================*
		// IncludePowders Property
		//============================================================================*

		public bool IncludePowders
			{
			get
				{
				return (m_fIncludePowders);
				}
			set
				{
				m_fIncludePowders = value;
				}
			}

		//============================================================================*
		// IncludePrimers Property
		//============================================================================*

		public bool IncludePrimers
			{
			get
				{
				return (m_fIncludePrimers);
				}
			set
				{
				m_fIncludePrimers = value;
				}
			}

		//============================================================================*
		// ResolveIdentities()
		//============================================================================*
		/*
				public bool ResolveIdentities()
					{
					bool fChanged = true;
					int nCount = 0;

					while (fChanged && nCount < 5)
						{
						fChanged = false;

						fChanged = m_DataFiles.CaliberList.ResolveIdentities() ? true : fChanged;
						fChanged = m_DataFiles.AmmoList.ResolveIdentities() ? true : fChanged;
						fChanged = m_DataFiles.BulletList.ResolveIdentities() ? true : fChanged;
						fChanged = m_DataFiles.CaseList.ResolveIdentities() ? true : fChanged;
						fChanged = m_DataFiles.PowderList.ResolveIdentities() ? true : fChanged;
						fChanged = m_DataFiles.PrimerList.ResolveIdentities() ? true : fChanged;
						fChanged = m_DataFiles.FirearmList.ResolveIdentities() ? true : fChanged;
						fChanged = m_DataFiles.LoadList.ResolveIdentities() ? true : fChanged;
						fChanged = m_DataFiles.BatchList.ResolveIdentities() ? true : fChanged;
						fChanged = m_DataFiles.GearList.ResolveIdentities() ? true : fChanged;

						//				fChanged = Preferences.ResolveIdentities(this) ? true : fChanged;

						if (fChanged)
							nCount = 0;
						else
							nCount++;
						}

					return (fChanged);
					}
		*/
		}
	}
