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
				return ("FirearmBullets");
				}
			}
		}
	}
