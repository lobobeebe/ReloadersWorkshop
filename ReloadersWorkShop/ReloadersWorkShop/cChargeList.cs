//============================================================================*
// cChargeList.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
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
					return (CheckCharge);
				}

			Add(Charge);

			Sort(new cChargeComparer());

			return (Charge);
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLElement = XMLDocument.CreateElement(ExportName, XMLParentElement);

			foreach (cCharge Charge in this)
				Charge.Export(XMLDocument, XMLElement);
			}

		//============================================================================*
		// ExportName()
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("ChargeList");
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
					case "Charge":
						cCharge Charge = new cCharge();

						if (Charge.Import(XMLDocument, XMLNode, DataFiles))
							{
							if (Charge.Validate())
								AddCharge(Charge);
							else
								Console.WriteLine("Invalid Charge!");
							}

						break;
					}

				XMLNode = XMLNode.NextSibling;
				}
			}

		//============================================================================*
		// MinCharge Property
		//============================================================================*

		public cCharge MinCharge
			{
			get
				{
				cCharge Charge = null;

				foreach (cCharge CheckCharge in this)
					{
					if (Charge == null || CheckCharge.PowderWeight < Charge.PowderWeight)
						Charge = CheckCharge;
					}

				return (Charge);
				}
			}

		//============================================================================*
		// MaxCharge Property
		//============================================================================*

		public cCharge MaxCharge
			{
			get
				{
				cCharge Charge = null;

				foreach (cCharge CheckCharge in this)
					{
					if (Charge == null || CheckCharge.PowderWeight > Charge.PowderWeight)
						Charge = CheckCharge;
					}

				return (Charge);
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
