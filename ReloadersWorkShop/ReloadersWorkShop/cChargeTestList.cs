//============================================================================*
// cChargeTestList.cs
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
	// cChargeTestList Class
	//============================================================================*

	[Serializable]
	public class cChargeTestList : List<cChargeTest>
		{
		//============================================================================*
		// cChargeTestList() - Constructor
		//============================================================================*

		public cChargeTestList()
			{
			}

		//============================================================================*
		// cChargeTestList() - Copy Constructor
		//============================================================================*

		public cChargeTestList(cChargeTestList ChargeTestList)
			{
			foreach (cChargeTest ChargeTest in ChargeTestList)
				{
				cChargeTest NewChargeTest = new cChargeTest(ChargeTest);

				Add(NewChargeTest);
				}

			Sort(cChargeTest.Comparer);
			}

		//============================================================================*
		// Add()
		//============================================================================*

		new public void Add(cChargeTest ChargeTest)
			{
			foreach (cChargeTest CheckTest in this)
				{
				if (CheckTest.CompareTo(ChargeTest) == 0)
					return;
				}

			base.Add(ChargeTest);

			Sort(cChargeTest.Comparer);
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement("ChargeTests");
				XMLParentElement.AppendChild(XMLElement);

				foreach (cChargeTest ChargeTest in this)
					ChargeTest.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public void Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "ChargeTest":
						cChargeTest ChargeTest = new cChargeTest();

						if (ChargeTest.Import(XMLDocument, XMLNode, DataFiles))
							{
							if (ChargeTest.Validate())
								Add(ChargeTest);
							else
								Console.WriteLine("Invalid ChargeTest!");
							}

						break;
					}

				XMLNode = XMLNode.NextSibling;
				}
			}

		//============================================================================*
		// ResolveIdentities()
		//============================================================================*

		public bool ResolveIdentities(cDataFiles Datafiles,  cCharge Charge)
			{
			bool fChanged = false;

			foreach (cChargeTest ChargeTest in this)
				fChanged = ChargeTest.ResolveIdentities(Datafiles) ? true : fChanged;

			return (fChanged);
			}
		}
	}
