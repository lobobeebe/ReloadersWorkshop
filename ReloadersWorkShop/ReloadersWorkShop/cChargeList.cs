//============================================================================*
// cChargeList.cs
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
	// cChargeList Class
	//============================================================================*

	[Serializable]
	public class cChargeList : List<cCharge>
		{
		//============================================================================*
		// cChargeList() - Constructor
		//============================================================================*

		public cChargeList()
			{
			}

		//============================================================================*
		// cChargeList() - Copy Constructor
		//============================================================================*

		public cChargeList(cChargeList ChargeList)
			{
			foreach (cCharge Charge in ChargeList)
				{
				cCharge NewCharge = new cCharge(Charge);

				Add(NewCharge);
				}

			Sort(new cChargeComparer());
			}

		//============================================================================*
		// AddCharge()
		//============================================================================*

		public cCharge AddCharge(cCharge Charge)
			{
			foreach (cCharge CheckCharge in this)
				{
				if (Charge.CompareTo(CheckCharge) == 0)
					return(CheckCharge);
				}

			Add(Charge);

			Sort(new cChargeComparer());

			return (Charge);
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLElement = XMLDocument.CreateElement("Charges");
			XMLParentElement.AppendChild(XMLElement);

			foreach (cCharge Charge in this)
				{
				Charge.Export(XMLDocument, XMLElement);
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
					case "Charge":
						cCharge Charge = new cCharge();

						if (Charge.Import(XMLDocument, XMLNode, DataFiles))
							AddCharge(Charge);

						break;
					}

				XMLNode = XMLNode.NextSibling;
				}
			}
		//============================================================================*
		// ResolveIdentities()
		//============================================================================*

		public bool ResolveIdentities(cDataFiles Datafiles)
			{
			bool fChanged = false;

			foreach (cCharge Charge in this)
				fChanged = Charge.ResolveIdentities(Datafiles) ? true : fChanged;

			return (fChanged);
			}
		}
	}
