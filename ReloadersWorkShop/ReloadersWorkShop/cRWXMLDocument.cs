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

		private string m_strFilePath = null;

		private cDataFiles m_DataFiles = null;

		private bool m_fFullDataDump = true;
		private bool m_fContainsPreferences = false;
		private bool m_fTrackInventory = false;

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
		private bool m_fIncludeParts = true;

		// Counters

		private int m_nAccessoryCount = 0;
		private int m_nAccessoryNewCount = 0;
		private int m_nAccessoryUpdateCount = 0;

		private int m_nAmmoCount = 0;
		private int m_nAmmoNewCount = 0;
		private int m_nAmmoUpdateCount = 0;

		private int m_nAmmoTestCount = 0;
		private int m_nAmmoTestNewCount = 0;
		private int m_nAmmoTestUpdateCount = 0;

		private int m_nBulletCount = 0;
		private int m_nBulletNewCount = 0;
		private int m_nBulletUpdateCount = 0;

		private int m_nBulletCaliberCount = 0;
		private int m_nBulletCaliberNewCount = 0;
		private int m_nBulletCaliberUpdateCount = 0;

		private int m_nCaliberCount = 0;
		private int m_nCaliberNewCount = 0;
		private int m_nCaliberUpdateCount = 0;

		private int m_nCaseCount = 0;
		private int m_nCaseNewCount = 0;
		private int m_nCaseUpdateCount = 0;

		private int m_nFirearmCount = 0;
		private int m_nFirearmNewCount = 0;
		private int m_nFirearmUpdateCount = 0;

		private int m_nFirearmCaliberCount = 0;
		private int m_nFirearmCaliberNewCount = 0;
		private int m_nFirearmCaliberUpdateCount = 0;

		private int m_nFirearmBulletCount = 0;
		private int m_nFirearmBulletNewCount = 0;
		private int m_nFirearmBulletUpdateCount = 0;

		private int m_nManufacturerCount = 0;
		private int m_nManufacturerNewCount = 0;
		private int m_nManufacturerUpdateCount = 0;

		private int m_nPowderCount = 0;
		private int m_nPowderNewCount = 0;
		private int m_nPowderUpdateCount = 0;

		private int m_nPrimerCount = 0;
		private int m_nPrimerNewCount = 0;
		private int m_nPrimerUpdateCount = 0;

		//============================================================================*
		// cRWXMLDocument() - Constructor
		//============================================================================*

		public cRWXMLDocument(cDataFiles DataFiles)
			{
			m_DataFiles = DataFiles;
			}

		//============================================================================*
		// AccessoryCount Property
		//============================================================================*

		public int AccessoryCount
			{
			get
				{
				return (m_nAccessoryCount);
				}
			}

		//============================================================================*
		// AccessoryNewCount Property
		//============================================================================*

		public int AccessoryNewCount
			{
			get
				{
				return (m_nAccessoryNewCount);
				}
			}

		//============================================================================*
		// AccessoryUpdateCount Property
		//============================================================================*

		public int AccessoryUpdateCount
			{
			get
				{
				return (m_nAccessoryUpdateCount);
				}
			}

		//============================================================================*
		// AmmoCount Property
		//============================================================================*

		public int AmmoCount
			{
			get
				{
				return (m_nAmmoCount);
				}
			}

		//============================================================================*
		// AmmoNewCount Property
		//============================================================================*

		public int AmmoNewCount
			{
			get
				{
				return (m_nAmmoNewCount);
				}
			}

		//============================================================================*
		// AmmoTestCount Property
		//============================================================================*

		public int AmmoTestCount
			{
			get
				{
				return (m_nAmmoTestCount);
				}
			}

		//============================================================================*
		// AmmoTestNewCount Property
		//============================================================================*

		public int AmmoTestNewCount
			{
			get
				{
				return (m_nAmmoTestNewCount);
				}
			}

		//============================================================================*
		// AmmoTestUpdateCount Property
		//============================================================================*

		public int AmmoTestUpdateCount
			{
			get
				{
				return (m_nAmmoTestUpdateCount);
				}
			}

		//============================================================================*
		// AmmoUpdateCount Property
		//============================================================================*

		public int AmmoUpdateCount
			{
			get
				{
				return (m_nAmmoUpdateCount);
				}
			}

		//============================================================================*
		// BulletCount Property
		//============================================================================*

		public int BulletCount
			{
			get
				{
				return (m_nBulletCount);
				}
			}

		//============================================================================*
		// BulletNewCount Property
		//============================================================================*

		public int BulletNewCount
			{
			get
				{
				return (m_nBulletNewCount);
				}
			}

		//============================================================================*
		// BulletUpdateCount Property
		//============================================================================*

		public int BulletUpdateCount
			{
			get
				{
				return (m_nBulletUpdateCount);
				}
			}

		//============================================================================*
		// BulletCaliberCount Property
		//============================================================================*

		public int BulletCaliberCount
			{
			get
				{
				return (m_nBulletCaliberCount);
				}
			}

		//============================================================================*
		// BulletCaliberNewCount Property
		//============================================================================*

		public int BulletCaliberNewCount
			{
			get
				{
				return (m_nBulletCaliberNewCount);
				}
			}

		//============================================================================*
		// BulletCaliberUpdateCount Property
		//============================================================================*

		public int BulletCaliberUpdateCount
			{
			get
				{
				return (m_nBulletCaliberUpdateCount);
				}
			}

		//============================================================================*
		// CaliberCount Property
		//============================================================================*

		public int CaliberCount
			{
			get
				{
				return (m_nCaliberCount);
				}
			}

		//============================================================================*
		// CaliberNewCount Property
		//============================================================================*

		public int CaliberNewCount
			{
			get
				{
				return (m_nCaliberNewCount);
				}
			}

		//============================================================================*
		// CaliberUpdateCount Property
		//============================================================================*

		public int CaliberUpdateCount
			{
			get
				{
				return (m_nCaliberUpdateCount);
				}
			}

		//============================================================================*
		// CaseCount Property
		//============================================================================*

		public int CaseCount
			{
			get
				{
				return (m_nCaseCount);
				}
			}

		//============================================================================*
		// CaseNewCount Property
		//============================================================================*

		public int CaseNewCount
			{
			get
				{
				return (m_nCaseNewCount);
				}
			}

		//============================================================================*
		// CaseUpdateCount Property
		//============================================================================*

		public int CaseUpdateCount
			{
			get
				{
				return (m_nCaseUpdateCount);
				}
			}

		//============================================================================*
		// ContainsPreferences Property
		//============================================================================*

		public bool ContainsPreferences
			{
			get
				{
				return (m_fContainsPreferences);
				}
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
		// CreateElement() - TubeSize
		//============================================================================*

		public XmlElement CreateElement(string strName, cScope.eTurretTubeSizes eSize, XmlNode XMLParentNode)
			{
			return (CreateElement(strName, cScope.TubeSizeString(eSize), XMLParentNode));
			}

		//============================================================================*
		// CreateElement() - Firearm TurretType
		//============================================================================*

		public XmlElement CreateElement(string strName, cFirearm.eTurretType eType, XmlNode XMLParentNode)
			{
			return (CreateElement(strName, cFirearm.TurretTypeString(eType), XMLParentNode));
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(bool fComplete = true, bool fDataUpdate = false)
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

			string strExportType = fComplete ? "Complete Data" : "Partial Data";

			if (fDataUpdate)
				strExportType = "Database Update";

			XmlText XMLTextElement = CreateTextNode(String.Format("{0} {1} Export File", Application.ProductName, strExportType));
			MainElement.AppendChild(XMLTextElement);

			if (fComplete || m_fIncludeManufacturers)
				m_DataFiles.ManufacturerList.Export(this, MainElement);

			if (fComplete || m_fIncludeCalibers)
				m_DataFiles.CaliberList.Export(this, MainElement);

			if (fComplete || m_fIncludeBullets)
				m_DataFiles.BulletList.Export(this, MainElement);

			if (fComplete || m_fIncludeFirearms)
				m_DataFiles.FirearmList.Export(this, MainElement);

			if (fComplete || m_fIncludeParts)
				m_DataFiles.GearList.Export(this, MainElement);

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
		// FileDescription Property
		//============================================================================*

		public string FileDescription
			{
			get
				{
				XmlNode XMLNode = FirstChild;

				string strDescription = "";

				while (XMLNode != null)
					{
					if (XMLNode.Name == "Body")
						{
						XMLNode = XMLNode.FirstChild;

						if (XMLNode != null)
							strDescription = XMLNode.Value;

						break;
						}

					XMLNode = XMLNode.NextSibling;
					}

				return (strDescription);
				}
			}

		//============================================================================*
		// FilePath Property
		//============================================================================*

		public string FilePath
			{
			get
				{
				return (m_strFilePath);
				}
			}

		//============================================================================*
		// FirearmCount Property
		//============================================================================*

		public int FirearmCount
			{
			get
				{
				return (m_nFirearmCount);
				}
			}

		//============================================================================*
		// FirearmNewCount Property
		//============================================================================*

		public int FirearmNewCount
			{
			get
				{
				return (m_nFirearmNewCount);
				}
			}

		//============================================================================*
		// FirearmUpdateCount Property
		//============================================================================*

		public int FirearmUpdateCount
			{
			get
				{
				return (m_nFirearmUpdateCount);
				}
			}

		//============================================================================*
		// FirearmBulletCount Property
		//============================================================================*

		public int FirearmBulletCount
			{
			get
				{
				return (m_nFirearmBulletCount);
				}
			}

		//============================================================================*
		// FirearmBulletNewCount Property
		//============================================================================*

		public int FirearmBulletNewCount
			{
			get
				{
				return (m_nFirearmBulletNewCount);
				}
			}

		//============================================================================*
		// FirearmBulletUpdateCount Property
		//============================================================================*

		public int FirearmBulletUpdateCount
			{
			get
				{
				return (m_nFirearmBulletUpdateCount);
				}
			}

		//============================================================================*
		// FirearmCaliberCount Property
		//============================================================================*

		public int FirearmCaliberCount
			{
			get
				{
				return (m_nFirearmCaliberCount);
				}
			}

		//============================================================================*
		// FirearmCaliberNewCount Property
		//============================================================================*

		public int FirearmCaliberNewCount
			{
			get
				{
				return (m_nFirearmCaliberNewCount);
				}
			}

		//============================================================================*
		// FirearmCaliberUpdateCount Property
		//============================================================================*

		public int FirearmCaliberUpdateCount
			{
			get
				{
				return (m_nFirearmCaliberUpdateCount);
				}
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
			// OK, if we get to here, go for it...
			//----------------------------------------------------------------------------*

			bool fOK = true;

			try
				{
				Import();
				}
			catch
				{
				fOK = false;
				}

			//----------------------------------------------------------------------------*
			// Return success!
			//----------------------------------------------------------------------------*

			return (fOK);
			}

		//============================================================================*
		// Import() - XML Document
		//============================================================================*

		public bool Import(bool fMerge = true, bool fCountOnly = false)
			{
			ResetCounts();

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
						m_DataFiles.AmmoList.Import(this, XMLNode, m_DataFiles, fCountOnly);

						m_nAmmoCount += m_DataFiles.AmmoList.ImportCount;
						m_nAmmoNewCount += m_DataFiles.AmmoList.NewCount;
						m_nAmmoUpdateCount += m_DataFiles.AmmoList.UpdateCount;

						break;

					case "Preferences":
						if (!fMerge)
							m_DataFiles.Preferences.Import(this, XMLNode, fCountOnly);

						m_fContainsPreferences = true;

						break;

					case "Manufacturers":
					case "ManufacturerList":
						m_DataFiles.ManufacturerList.Import(this, XMLNode);

						m_nManufacturerCount += m_DataFiles.ManufacturerList.ImportCount;
						m_nManufacturerNewCount += m_DataFiles.ManufacturerList.NewCount;
						m_nManufacturerUpdateCount += m_DataFiles.ManufacturerList.UpdateCount;

						break;

					case "Calibers":
					case "CaliberList":
						m_DataFiles.CaliberList.Import(this, XMLNode, fCountOnly);

						m_nCaliberCount += m_DataFiles.CaliberList.ImportCount;
						m_nCaliberNewCount += m_DataFiles.CaliberList.NewCount;
						m_nCaliberUpdateCount += m_DataFiles.CaliberList.UpdateCount;

						break;

					case "Bullets":
					case "BulletList":
						m_DataFiles.BulletList.Import(this, XMLNode, m_DataFiles, fCountOnly);

						m_nBulletCount += m_DataFiles.BulletList.ImportCount;
						m_nBulletNewCount += m_DataFiles.BulletList.NewCount;
						m_nBulletUpdateCount += m_DataFiles.BulletList.UpdateCount;

						m_nBulletCaliberCount += m_DataFiles.BulletList.BulletCaliberImportCount;
						m_nBulletCaliberNewCount += m_DataFiles.BulletList.BulletCaliberNewCount;
						m_nBulletCaliberUpdateCount += m_DataFiles.BulletList.BulletCaliberUpdateCount;

						break;

					case "Firearms":
					case "FirearmList":
						m_DataFiles.FirearmList.Import(this, XMLNode, m_DataFiles, fCountOnly);

						m_nFirearmCount += m_DataFiles.FirearmList.ImportCount;
						m_nFirearmNewCount += m_DataFiles.FirearmList.NewCount;
						m_nFirearmUpdateCount += m_DataFiles.FirearmList.UpdateCount;

						m_nFirearmCaliberCount += m_DataFiles.FirearmList.FirearmCaliberImportCount;
						m_nFirearmCaliberNewCount += m_DataFiles.FirearmList.FirearmCaliberNewCount;
						m_nFirearmCaliberUpdateCount += m_DataFiles.FirearmList.FirearmCaliberUpdateCount;

						m_nFirearmBulletCount += m_DataFiles.FirearmList.FirearmBulletImportCount;
						m_nFirearmBulletNewCount += m_DataFiles.FirearmList.FirearmBulletNewCount;
						m_nFirearmBulletUpdateCount += m_DataFiles.FirearmList.FirearmBulletUpdateCount;

						break;

					case "Cases":
					case "CaseList":
						m_DataFiles.CaseList.Import(this, XMLNode, m_DataFiles, fCountOnly);

						m_nCaseCount += m_DataFiles.CaseList.ImportCount;
						m_nCaseNewCount += m_DataFiles.CaseList.NewCount;
						m_nCaseUpdateCount += m_DataFiles.CaseList.UpdateCount;

						break;

					case "Powders":
					case "PowderList":
						m_DataFiles.PowderList.Import(this, XMLNode, m_DataFiles, fCountOnly);

						m_nPowderCount += m_DataFiles.PowderList.ImportCount;
						m_nPowderNewCount += m_DataFiles.PowderList.NewCount;
						m_nPowderUpdateCount += m_DataFiles.PowderList.UpdateCount;

						break;

					case "Primers":
					case "PrimerList":
						m_DataFiles.PrimerList.Import(this, XMLNode, m_DataFiles, fCountOnly);

						m_nPrimerCount += m_DataFiles.PrimerList.ImportCount;
						m_nPrimerNewCount += m_DataFiles.PrimerList.NewCount;
						m_nPrimerUpdateCount += m_DataFiles.PrimerList.UpdateCount;

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
						m_DataFiles.GearList.Import(this, XMLNode, m_DataFiles, fCountOnly);

						m_nAccessoryCount += m_DataFiles.GearList.ImportCount;
						m_nAccessoryNewCount += m_DataFiles.GearList.NewCount;
						m_nAccessoryUpdateCount += m_DataFiles.GearList.UpdateCount;

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
		// Import() - PrimerSize
		//============================================================================*

		public void Import(XmlNode XMLThisNode, out cPrimer.ePrimerSize eSize)
			{
			eSize = cPrimer.ePrimerSize.Small;

			if (XMLThisNode != null && XMLThisNode.FirstChild != null && XMLThisNode.FirstChild.Value != null)
				eSize = cPrimer.PrimerSizeFromString(XMLThisNode.FirstChild.Value);
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
		// Import() - TransactionType
		//============================================================================*

		public void Import(XmlNode XMLThisNode, out cTransaction.eTransactionType eType)
			{
			eType = cTransaction.eTransactionType.SetStockLevel;

			if (XMLThisNode != null && XMLThisNode.FirstChild != null && XMLThisNode.FirstChild.Value != null)
				eType = cTransaction.TransactionTypeFromString(XMLThisNode.FirstChild.Value);
			}

		//============================================================================*
		// Import() - Turret Size
		//============================================================================*

		public void Import(XmlNode XMLThisNode, out cScope.eTurretTubeSizes eSize)
			{
			eSize = cScope.eTurretTubeSizes.Small;

			if (XMLThisNode != null && XMLThisNode.FirstChild != null && XMLThisNode.FirstChild.Value != null)
				eSize = cScope.TubeSizeFromString(XMLThisNode.FirstChild.Value);
			}

		//============================================================================*
		// Import() - TurretType
		//============================================================================*

		public void Import(XmlNode XMLThisNode, out cFirearm.eTurretType eType)
			{
			eType = cFirearm.eTurretType.MOA;

			if (XMLThisNode != null && XMLThisNode.FirstChild != null && XMLThisNode.FirstChild.Value != null)
				eType = cFirearm.TurretTypeFromString(XMLThisNode.FirstChild.Value);
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
		// IncludeParts Property
		//============================================================================*

		public bool IncludeParts
			{
			get
				{
				return (m_fIncludeParts);
				}
			set
				{
				m_fIncludeParts = value;
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
		// Load()
		//============================================================================*

		public override void Load(string strFilePath)
			{
			m_strFilePath = strFilePath;

			base.Load(strFilePath);

			if (!Validate())
				throw (new Exception(String.Format("{0} is not a valid {1} XML Data File!", strFilePath, Application.ProductName)));
			}

		//============================================================================*
		// ManufacturerCount Property
		//============================================================================*

		public int ManufacturerCount
			{
			get
				{
				return (m_nManufacturerCount);
				}
			}

		//============================================================================*
		// ManufacturerNewCount Property
		//============================================================================*

		public int ManufacturerNewCount
			{
			get
				{
				return (m_nManufacturerNewCount);
				}
			}

		//============================================================================*
		// ManufacturerUpdateCount Property
		//============================================================================*

		public int ManufacturerUpdateCount
			{
			get
				{
				return (m_nManufacturerUpdateCount);
				}
			}

		//============================================================================*
		// PowderCount Property
		//============================================================================*

		public int PowderCount
			{
			get
				{
				return (m_nPowderCount);
				}
			}

		//============================================================================*
		// PowderNewCount Property
		//============================================================================*

		public int PowderNewCount
			{
			get
				{
				return (m_nPowderNewCount);
				}
			}

		//============================================================================*
		// PowderUpdateCount Property
		//============================================================================*

		public int PowderUpdateCount
			{
			get
				{
				return (m_nPowderUpdateCount);
				}
			}

		//============================================================================*
		// PrimerCount Property
		//============================================================================*

		public int PrimerCount
			{
			get
				{
				return (m_nPrimerCount);
				}
			}

		//============================================================================*
		// PrimerNewCount Property
		//============================================================================*

		public int PrimerNewCount
			{
			get
				{
				return (m_nPrimerNewCount);
				}
			}

		//============================================================================*
		// PrimerUpdateCount Property
		//============================================================================*

		public int PrimerUpdateCount
			{
			get
				{
				return (m_nPrimerUpdateCount);
				}
			}

		//============================================================================*
		// ResetCounts()
		//============================================================================*

		public void ResetCounts()
			{
			m_nAmmoCount = 0;
			m_nAmmoNewCount = 0;
			m_nAmmoUpdateCount = 0;

			m_nAmmoTestCount = 0;
			m_nAmmoTestNewCount = 0;
			m_nAmmoTestUpdateCount = 0;

			m_nManufacturerCount = 0;
			m_nManufacturerNewCount = 0;
			m_nManufacturerUpdateCount = 0;

			m_nCaliberCount = 0;
			m_nCaliberNewCount = 0;
			m_nCaliberUpdateCount = 0;
			}

		//============================================================================*
		// TrackInventory Property
		//============================================================================*

		public bool TrackInventory
			{
			get
				{
				return (m_fTrackInventory);
				}
			set
				{
				m_fTrackInventory = value;
				}
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public bool Validate()
			{
			XmlNode XMLNode = FirstChild;

			while (XMLNode != null)
				{
				if (XMLNode.Name == "Body")
					{
					XMLNode = XMLNode.FirstChild;

					if (XMLNode != null && XMLNode.InnerText.Contains(Application.ProductName))
						return (true);
					}

				XMLNode = XMLNode.NextSibling;
				}

			return (false);
			}
		}
	}
