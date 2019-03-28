//============================================================================*
// cRedDot.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Xml;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cred Class
	//============================================================================*

	[Serializable]
	public class cRedDot : cGear
		{
		//============================================================================*
		// Public Enumerations
		//============================================================================*


		//============================================================================*
		// Private Data Members
		//============================================================================*

		private double m_dDotMOA = 0.0;
		private double m_dCowitnessHeight = 0.0;
		private double m_dTubeDiameter = 0.0;

		private string m_strBattery = "";

		//============================================================================*
		// cRedDot() - Constructor
		//============================================================================*

		public cRedDot()
			: base(cGear.eGearTypes.RedDot)
			{
			}

		//============================================================================*
		// cRedDot() - Copy Constructor
		//============================================================================*

		public cRedDot(cRedDot RedDot)
			: base(RedDot)
			{
			Copy(RedDot);
			}

		//============================================================================*
		// Battery Property
		//============================================================================*

		public string Battery
			{
			get
				{
				return (m_strBattery);
				}

			set
				{
				m_strBattery = value;
				}
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public override void Copy(cGear Gear)
			{
			if (Gear.GearType != eGearTypes.RedDot)
				return;

			base.Copy(Gear);

			cRedDot RedDot = (cRedDot) Gear;

			m_dDotMOA = RedDot.m_dDotMOA;
			m_dCowitnessHeight = RedDot.m_dCowitnessHeight;
			m_dTubeDiameter = RedDot.m_dTubeDiameter;

			m_strBattery = RedDot.m_strBattery;
			}

		//============================================================================*
		// CowitnessHeight Property
		//============================================================================*

		public double CowitnessHeight
			{
			get
				{
				return (m_dCowitnessHeight);
				}

			set
				{
				m_dCowitnessHeight = value;
				}
			}

		//============================================================================*
		// CSVHeaderExtension Property
		//============================================================================*

		public override string CSVLineHeaderExtension
			{
			get
				{
				return (",Dot MOA,Co-witness Height,Tube Diameter,Battery");
				}
			}

		//============================================================================*
		// CSVLineExtension Property
		//============================================================================*

		public override string CSVLineExtension
			{
			get
				{
				string strLine = ",";
				strLine += (this as cRedDot).m_dDotMOA;
				strLine += ",";
				strLine += (this as cRedDot).m_dCowitnessHeight;
				strLine += ",";
				strLine += (this as cRedDot).m_dTubeDiameter;
				strLine += ",";
				strLine += (this as cRedDot).m_strBattery;

				return (strLine);
				}
			}

		//============================================================================*
		// DotMOA Property
		//============================================================================*

		public double DotMOA
			{
			get
				{
				return (m_dDotMOA);
				}

			set
				{
				m_dDotMOA = value;
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public override void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement, bool fIdentityOnly = false)
			{
			string strName = ExportName;

			if (fIdentityOnly)
				strName += "Identity";

			XmlElement XMLThisElement = XMLDocument.CreateElement(ExportName, XMLParentElement);

			base.Export(XMLDocument, XMLThisElement, fIdentityOnly);

			if (fIdentityOnly)
				return;

			XMLDocument.CreateElement("DotMOA", m_dDotMOA, XMLThisElement);
			XMLDocument.CreateElement("CowitnessHeight", m_dCowitnessHeight, XMLThisElement);
			XMLDocument.CreateElement("TubeDiameter", m_dTubeDiameter, XMLThisElement);
			XMLDocument.CreateElement("Battery", m_strBattery, XMLThisElement);
			}

		//============================================================================*
		// ExportName()
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("RedDot");
				}
			}

		//============================================================================*
		// ToString()
		//============================================================================*

		public override string ToString()
			{
			string strString = String.Format("{0} {1} {2}", Manufacturer.Name, PartNumber, Description);

			if (!String.IsNullOrEmpty(SerialNumber))
				strString += String.Format(" {0}", SerialNumber);

			return (strString);
			}

		//============================================================================*
		// TubeDiameter Property
		//============================================================================*

		public double TubeDiameter
			{
			get
				{
				return (m_dTubeDiameter);
				}

			set
				{
				m_dTubeDiameter = value;
				}
			}
		}
	}
