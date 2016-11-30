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

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
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
		// ResolveIdentities()
		//============================================================================*

		public bool ResolveIdentities(cDataFiles Datafiles,  cCharge Charge)
			{
			bool fChanged = false;

			foreach (cChargeTest ChargeTest in this)
				{
				ChargeTest.Charge = Charge;

				fChanged = ChargeTest.ResolveIdentities(Datafiles) ? true : fChanged;
				}

			return (fChanged);
			}
		}
	}
