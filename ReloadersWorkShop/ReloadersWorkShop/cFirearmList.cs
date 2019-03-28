//============================================================================*
// cFirearmList.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFirearmList Class
	//============================================================================*

	[Serializable]
	public class cFirearmList : List<cFirearm>
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nImportCount = 0;
		private int m_nNewCount = 0;
		private int m_nUpdateCount = 0;

		//============================================================================*
		// AddFirearm()
		//============================================================================*

		public bool AddFirearm(cFirearm Firearm, bool fCountOnly = false)
			{
			m_nImportCount++;

			foreach (cFirearm CheckFirearm in this)
				{
				if (CheckFirearm.CompareTo(Firearm) == 0)
					{
					m_nUpdateCount += CheckFirearm.Append(Firearm, fCountOnly);

					return (false);
					}
				}


			if (!fCountOnly)
				Add(Firearm);

			m_nNewCount++;

			return (true);
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(StreamWriter Writer)
			{
			if (Count <= 0)
				return;

			string strLine = "";

			Writer.WriteLine(ExportName);
			Writer.WriteLine();

			Writer.WriteLine(cFirearm.CSVLineHeader);
			Writer.WriteLine();

			foreach (cFirearm Firearm in this)
				{
				strLine = Firearm.CSVLine;

				Writer.WriteLine(strLine);
				}

			Writer.WriteLine();
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement(ExportName);
				XMLParentElement.AppendChild(XMLElement);

				foreach (cFirearm Firearm in this)
					{
					if (Firearm.Validate())	
						Firearm.Export(XMLDocument, XMLElement);
					}
				}
			}

		//============================================================================*
		// ExportName()
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("FirearmList");
				}
			}

		//============================================================================*
		// FirearmBulletImportCount Property
		//============================================================================*

		public int FirearmBulletImportCount
			{
			get
				{
				int nFireBulletImportCount = 0;

				foreach (cFirearm Firearm in this)
					nFireBulletImportCount += Firearm.FirearmBulletList.ImportCount;

				return (nFireBulletImportCount);
				}
			}

		//============================================================================*
		// FirearmBulletNewCount Property
		//============================================================================*

		public int FirearmBulletNewCount
			{
			get
				{
				int nFirearmBulletNewCount = 0;

				foreach (cFirearm Firearm in this)
					nFirearmBulletNewCount += Firearm.FirearmBulletList.NewCount;

				return (nFirearmBulletNewCount);
				}
			}

		//============================================================================*
		// FirearmBulletUpdateCount Property
		//============================================================================*

		public int FirearmBulletUpdateCount
			{
			get
				{
				int nFireBulletUpdateCount = 0;

				foreach (cFirearm Firearm in this)
					nFireBulletUpdateCount += Firearm.FirearmBulletList.UpdateCount;

				return (nFireBulletUpdateCount);
				}
			}

		//============================================================================*
		// FirearmCaliberImportCount Property
		//============================================================================*

		public int FirearmCaliberImportCount
			{
			get
				{
				int nFirearmCaliberImportCount = 0;

				foreach (cFirearm Firearm in this)
					nFirearmCaliberImportCount += Firearm.CaliberList.ImportCount;

				return (nFirearmCaliberImportCount);
				}
			}

		//============================================================================*
		// FirearmCaliberNewCount Property
		//============================================================================*

		public int FirearmCaliberNewCount
			{
			get
				{
				int nFireCalibertNewCount = 0;

				foreach (cFirearm Firearm in this)
					nFireCalibertNewCount += Firearm.CaliberList.NewCount;

				return (nFireCalibertNewCount);
				}
			}

		//============================================================================*
		// FirearmCaliberUpdateCount Property
		//============================================================================*

		public int FirearmCaliberUpdateCount
			{
			get
				{
				int nFirearmCaliberUpdateCount = 0;

				foreach (cFirearm Firearm in this)
					nFirearmCaliberUpdateCount += Firearm.CaliberList.UpdateCount;

				return (nFirearmCaliberUpdateCount);
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public void Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles, bool fCountOnly = false)
			{
			m_nImportCount = 0;
			m_nNewCount = 0;
			m_nUpdateCount = 0;

			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "Firearm":
						cFirearm Firearm = new cFirearm();

						if (Firearm.Import(XMLDocument, XMLNode, DataFiles))
							AddFirearm(Firearm, fCountOnly);

						break;
					}

				XMLNode = XMLNode.NextSibling;
				}
			}

		//============================================================================*
		// ImportCount Property
		//============================================================================*

		public int ImportCount
			{
			get
				{
				return (m_nImportCount);
				}
			}

		//============================================================================*
		// NewCount Property
		//============================================================================*

		public int NewCount
			{
			get
				{
				return (m_nNewCount);
				}
			}

		//============================================================================*
		// ResolveIdentities()
		//============================================================================*

		public bool ResolveIdentities(cDataFiles Datafiles)
			{
			bool fChanged = false;

			foreach (cFirearm Firearm in this)
				fChanged = Firearm.ResolveIdentities(Datafiles) ? true : fChanged;

			return (fChanged);
			}

		//============================================================================*
		// UpdateCount Property
		//============================================================================*

		public int UpdateCount
			{
			get
				{
				return (m_nUpdateCount);
				}
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public bool Validate()
			{
			bool fOK = true;

			while (true)
				{
				bool fDeleted = false;

				foreach (cFirearm Firearm in this)
					{
					if (!Firearm.Validate())
						{
						fOK = false;

						Remove(Firearm);

						fDeleted = true;

						break;
						}
					}

				if (!fDeleted)
					break;
				}

			return (fOK);
			}
		}
	}
