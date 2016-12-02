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

		public XmlElement CreateElement(string strName, cFirearm.eFireArmType eType, XmlElement XMLParentElement)
			{
			return (CreateElement(strName, cFirearm.FirearmTypeString(eType), XMLParentElement));
			}

		//============================================================================*
		// CreateElement() - TurretType
		//============================================================================*

		public XmlElement CreateElement(string strName, cFirearm.eTurretType eType, XmlElement XMLParentElement)
			{
			return (CreateElement(strName, cFirearm.TurretTypeString(eType), XMLParentElement));
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

			if (fComplete || m_fIncludeFirearms)
				m_DataFiles.FirearmList.Export(this, MainElement);

			if (fComplete || m_fIncludeAmmo)
				m_DataFiles.AmmoList.Export(this, MainElement);

			if (fComplete || m_fIncludeBullets)
				m_DataFiles.BulletList.Export(this, MainElement);

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
		}
	}
