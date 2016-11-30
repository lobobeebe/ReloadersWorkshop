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

		public bool AddFirearmBullet(cFirearmBullet FirearmBullet)
			{
			foreach (cFirearmBullet CheckFirearmBullet in this)
				{
				if (CheckFirearmBullet.CompareTo(FirearmBullet) == 0)
					return (false);
				}

			Add(FirearmBullet);

			return (true);
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement(ExportName);
				XMLParentElement.AppendChild(XMLElement);

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

		public void Import(XmlDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
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
		}
	}
