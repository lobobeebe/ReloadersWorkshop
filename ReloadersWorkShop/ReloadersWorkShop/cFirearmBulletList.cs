//============================================================================*
// cFirearmBulletList.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Collections.Generic;
using System.Xml;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFirearmBulletList Class
	//============================================================================*

	[Serializable]
	public class cFirearmBulletList : List<cFirearmBullet>
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nImportCount = 0;
		private int m_nNewCount = 0;
		private int m_nUpdateCount = 0;

		//============================================================================*
		// cFirearmBulletList() - Constructor
		//============================================================================*

		public cFirearmBulletList()
			{
			}

		//============================================================================*
		// cFirearmBulletList() - Copy Constructor
		//============================================================================*

		public cFirearmBulletList(cFirearmBulletList FirearmBulletList)
			{
			Clear();

			if (FirearmBulletList == null)
				return;

			foreach (cFirearmBullet CheckFirearmBullet in FirearmBulletList)
				{
				cFirearmBullet FirearmBullet = new cFirearmBullet(CheckFirearmBullet);

				Add(FirearmBullet);
				}
			}

		//============================================================================*
		// AddFirearmBullet()
		//============================================================================*

		public bool AddFirearmBullet(cFirearmBullet FirearmBullet, bool fCountOnly = false)
			{
			m_nImportCount++;

			foreach (cFirearmBullet CheckFirearmBullet in this)
				{
				if (CheckFirearmBullet.CompareTo(FirearmBullet) == 0)
					{
					m_nUpdateCount += CheckFirearmBullet.Append(FirearmBullet, fCountOnly);

					return (false);
					}
				}

			if (!fCountOnly)
				Add(FirearmBullet);

			m_nNewCount++;

			return (true);
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement(ExportName, XMLParentElement);

				foreach (cFirearmBullet FirearmBullet in this)
					FirearmBullet.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public string ExportName
			{
			get
				{
				return ("FirearmBulletList");
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public void Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			m_nImportCount = 0;
			m_nNewCount = 0;
			m_nUpdateCount = 0;

			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "FirearmBullet":
						cFirearmBullet FirearmBullet = new cFirearmBullet();

						if (FirearmBullet.Import(XMLDocument, XMLNode, DataFiles))
							AddFirearmBullet(FirearmBullet);

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
		// UpdateCount Property
		//============================================================================*

		public int UpdateCount
			{
			get
				{
				return (m_nUpdateCount);
				}
			}
		}
	}
