//============================================================================*
// cPrimer.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Xml;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cPrimer class
	//============================================================================*

	[Serializable]
	public class cPrimer : cSupply
		{
		//============================================================================*
		// Public Enumerations
		//============================================================================*

		public enum ePrimerSize
			{
			Small = 0,
			Large,
			}

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private string m_strModel = "";
		private ePrimerSize m_eSize = ePrimerSize.Small;

		private bool m_fStandard = true;
		private bool m_fMagnum = false;

		private bool m_fBenchRest = false;
		private bool m_fMilitary = false;

		//============================================================================*
		// cPrimer() - Constructor
		//============================================================================*

		public cPrimer()
			: base(cSupply.eSupplyTypes.Primers)
			{
			}

		//============================================================================*
		// cPrimer() - Copy Constructor
		//============================================================================*

		public cPrimer(cPrimer Primer)
			: base(Primer)
			{
			Copy(Primer, false);
			}

		//============================================================================*
		// BenchRest Property
		//============================================================================*

		public bool BenchRest
			{
			get
				{
				return (m_fBenchRest);
				}
			set
				{
				m_fBenchRest = value;
				}
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cPrimer Primer1, cPrimer Primer2)
			{
			if (Primer1 == null)
				{
				if (Primer2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Primer2 == null)
					return (1);
				}

			return (Primer1.CompareTo(Primer2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public override int CompareTo(Object obj)
			{
			if (obj == null)
				return (1);

			//----------------------------------------------------------------------------*
			// Base Class
			//----------------------------------------------------------------------------*

			cSupply Supply = (cSupply) obj;

			int rc = base.CompareTo(Supply);

			//----------------------------------------------------------------------------*
			// Model
			//----------------------------------------------------------------------------*

			if (rc == 0)
				{
				cPrimer Primer = (cPrimer) Supply;

				rc = cDataFiles.ComparePartNumbers(m_strModel, Primer.m_strModel);
				}

			//----------------------------------------------------------------------------*
			// Return results
			//----------------------------------------------------------------------------*

			return (rc);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public void Copy(cPrimer Primer, bool fCopyBase = true)
			{
			if (fCopyBase)
				base.Copy(Primer);

			m_strModel = Primer.m_strModel;
			m_eSize = Primer.m_eSize;
			m_fStandard = Primer.m_fStandard;
			m_fMagnum = Primer.m_fMagnum;
			m_fMilitary = Primer.m_fMilitary;
			m_fBenchRest = Primer.m_fBenchRest;
			}

		//============================================================================*
		// CSVHeader Property
		//============================================================================*

		public static string CSVHeader
			{
			get
				{
				return ("Primers");
				}
			}

		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public string CSVLine
			{
			get
				{
				string strLine = "";

				strLine += Manufacturer.Name;
				strLine += ",";

				strLine += m_strModel;
				strLine += ",";
				strLine += cFirearm.FirearmTypeString(FirearmType);
				strLine += ",";
				strLine += CrossUse ? "Yes," : "-,";

				strLine += m_eSize == ePrimerSize.Small ? "Small" : "Large";
				strLine += ",";

				strLine += m_fStandard ? "Yes," : "-,";
				strLine += m_fMagnum ? "Yes," : "-,";
				strLine += m_fBenchRest ? "Yes," : "-,";
				strLine += m_fMilitary ? "Yes," : "-";

				return (strLine);
				}
			}

		//============================================================================*
		// CSVLineHeader Property
		//============================================================================*

		public static string CSVLineHeader
			{
			get
				{
				return ("Firearm Type,Cross Use?,Manufacturer,Model,Size,Standard,Magnum,Bench Rest,Military");
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement("Primer");
			XMLParentElement.AppendChild(XMLThisElement);

			// Manufacturer

			XmlElement XMLElement = XMLDocument.CreateElement("Manufacturer");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(Manufacturer.Name);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Model

			XMLElement = XMLDocument.CreateElement("Model");
			XMLTextElement = XMLDocument.CreateTextNode(m_strModel);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Firearm Type

			XMLElement = XMLDocument.CreateElement("FirearmType");
			XMLTextElement = XMLDocument.CreateTextNode(cFirearm.FirearmTypeString(FirearmType));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Cross  Use

			XMLElement = XMLDocument.CreateElement("CrossUse");
			XMLTextElement = XMLDocument.CreateTextNode(CrossUse ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Size

			XMLElement = XMLDocument.CreateElement("Size");
			XMLTextElement = XMLDocument.CreateTextNode(m_eSize == ePrimerSize.Small ? "Small" : "Large");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Standard

			XMLElement = XMLDocument.CreateElement("Standard");
			XMLTextElement = XMLDocument.CreateTextNode(m_fStandard ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Magnum

			XMLElement = XMLDocument.CreateElement("Magnum");
			XMLTextElement = XMLDocument.CreateTextNode(m_fMagnum ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Bench Rest

			XMLElement = XMLDocument.CreateElement("BenchRest");
			XMLTextElement = XMLDocument.CreateTextNode(m_fBenchRest ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Military

			XMLElement = XMLDocument.CreateElement("Military");
			XMLTextElement = XMLDocument.CreateTextNode(m_fMilitary ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);
			}

		//============================================================================*
		// Magnum Property
		//============================================================================*

		public bool Magnum
			{
			get
				{
				return (m_fMagnum);
				}
			set
				{
				m_fMagnum = value;
				}
			}

		//============================================================================*
		// Military Property
		//============================================================================*

		public bool Military
			{
			get
				{
				return (m_fMilitary);
				}
			set
				{
				m_fMilitary = value;
				}
			}

		//============================================================================*
		// Model Property
		//============================================================================*

		public string Model
			{
			get
				{
				return (m_strModel);
				}
			set
				{
				m_strModel = value;
				}
			}

		//============================================================================*
		// SortSizeString Property
		//============================================================================*

		public string ShortSizeString
			{
			get
				{
				string strSizeString = "";

				switch (m_eSize)
					{
					case ePrimerSize.Small:
						strSizeString = "Small";
						break;

					case ePrimerSize.Large:
						strSizeString = "Large";
						break;
					}

				return (strSizeString);
				}
			}

		//============================================================================*
		// Size Property
		//============================================================================*

		public ePrimerSize Size
			{
			get
				{
				return (m_eSize);
				}
			set
				{
				m_eSize = value;
				}
			}

		//============================================================================*
		// SizeString Property
		//============================================================================*

		public string SizeString
			{
			get
				{
				string strSizeString = ShortSizeString;

				strSizeString += " ";

				switch (FirearmType)
					{
					case cFirearm.eFireArmType.Handgun:
						strSizeString += "Pistol";
						break;

					case cFirearm.eFireArmType.Rifle:
						strSizeString += "Rifle";
						break;

					case cFirearm.eFireArmType.Shotgun:
						strSizeString += "Shotgun";
						break;
					}

				return (strSizeString);
				}
			}

		//============================================================================*
		// Standard Property
		//============================================================================*

		public bool Standard
			{
			get
				{
				return (m_fStandard);
				}
			set
				{
				m_fStandard = value;
				}
			}

		//============================================================================*
		// ToShortString()
		//============================================================================*

		public string ToShortString()
			{
			return (String.Format("{0} {1}", (Manufacturer != null ? Manufacturer.ToString() : ""), (m_strModel != null ? m_strModel : "")));
			}

		//============================================================================*
		// ToString
		//============================================================================*

		public override string ToString()
			{
			string strString = String.Format("{0} {1} - {2} {3}", Manufacturer, m_strModel, m_eSize == ePrimerSize.Small ? "Small" : "Large", FirearmType == cFirearm.eFireArmType.Handgun ? "Pistol" : "Rifle");

			if (!m_fStandard && m_fMagnum)
				strString += " Magnum";

			strString = ToCrossUseString(strString);

			return (strString);
			}

		//============================================================================*
		// XMLHeader Property
		//============================================================================*

		public static string XMLHeader
			{
			get
				{
				return ("Primers");
				}
			}

		//============================================================================*
		// XMLLine Property
		//============================================================================*

		public string XMLLine
			{
			get
				{
				string strLine = "";

				return (strLine);
				}
			}

		//============================================================================*
		// XMLLineHeader Property
		//============================================================================*

		public static string XMLLineHeader
			{
			get
				{
				string strLine = "Firearm Type,Name,Headstamp,Handgun Type,Small Primer,Large Primer,Magnum Primer,Min Bullet Dia.,Max Bullet Dia.,Min Bullet Weight,Max Bullet Weight,Case Trim Length,Max Case Length,Max COAL,Max Neck Dia";

				return (strLine);
				}
			}
		}
	}
