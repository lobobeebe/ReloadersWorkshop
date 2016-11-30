//============================================================================*
// cCase.cs
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
	// cCase class
	//============================================================================*

	[Serializable]
	public class cCase : cSupply
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private string m_strPartNumber = "";
		private cCaliber m_Caliber = null;
		private bool m_fMatch = false;
		private bool m_fMilitary = false;
		private bool m_fLargePrimer = false;
		private bool m_fSmallPrimer = false;

		//============================================================================*
		// cCase() - Constructor
		//============================================================================*

		public cCase()
			: base(cSupply.eSupplyTypes.Cases)
			{
			}

		//============================================================================*
		// cCase() - Copy Constructor
		//============================================================================*

		public cCase(cCase Case)
			: base(Case)
			{
			Copy(Case, false);
			}

		//============================================================================*
		// Caliber Property
		//============================================================================*

		public cCaliber Caliber
			{
			get
				{
				return (m_Caliber);
				}
			set
				{
				m_Caliber = value;
				}
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cCase Case1, cCase Case2)
			{
			if (Case1 == null)
				{
				if (Case2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Case2 == null)
					return (1);
				}

			return (Case1.CompareTo(Case2));
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
			// Part Number
			//----------------------------------------------------------------------------*

			if (rc == 0)
				{
				cCase Case = (cCase) Supply;

				rc = cDataFiles.ComparePartNumbers(m_strPartNumber, Case.m_strPartNumber);

				//----------------------------------------------------------------------------*
				// Caliber
				//----------------------------------------------------------------------------*

				if (rc == 0)
					{
					rc = m_Caliber.CompareTo(Case.m_Caliber);

					//----------------------------------------------------------------------------*
					// Large Primer
					//----------------------------------------------------------------------------*

					if (rc == 0)
						{
						rc = m_fLargePrimer.CompareTo(Case.m_fLargePrimer);

						//----------------------------------------------------------------------------*
						// Small Primer
						//----------------------------------------------------------------------------*

						if (rc == 0)
							{
							rc = m_fSmallPrimer.CompareTo(Case.m_fSmallPrimer);

							//----------------------------------------------------------------------------*
							// Match
							//----------------------------------------------------------------------------*

							if (rc == 0)
								{
								rc = m_fMatch.CompareTo(Case.m_fMatch);
								}
							}
						}
					}
				}

			return (rc);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public void Copy(cCase Case, bool fCopyBase = true)
			{
			if (fCopyBase)
				base.Copy(Case);

			m_strPartNumber = Case.m_strPartNumber;
			m_Caliber = Case.m_Caliber;
			m_fMatch = Case.m_fMatch;
			m_fMilitary = Case.m_fMilitary;
			m_fLargePrimer = Case.m_fLargePrimer;
			m_fSmallPrimer = Case.m_fSmallPrimer;
			}

		//============================================================================*
		// CSVHeader Property
		//============================================================================*

		public static string CSVHeader
			{
			get
				{
				return ("Cases");
				}
			}

		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public override string CSVLine
			{
			get
				{
				string strLine = base.CSVLine;

				strLine += m_strPartNumber;
				strLine += ",";
				strLine += m_Caliber.Name;
				strLine += ",";
				strLine += m_fMatch ? "Yes," : "-,";
				strLine += ",";
				strLine += m_fMilitary ? "Yes," : "-,";
				strLine += ",";
				strLine += m_fLargePrimer ? "Yes," : "-,";
				strLine += ",";
				strLine += m_fSmallPrimer ? "Yes," : "-,";

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
				string strLine = cSupply.CSVSupplyLineHeader;

				strLine += "Part Number,Caliber,Match,Military,Large Primer,Small Primer";

				return (strLine);
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public override void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement(ExportName);
			XMLParentElement.AppendChild(XMLThisElement);

			base.Export(XMLDocument, XMLThisElement);

			XmlElement XMLElement = null;
			XmlText XMLTextElement = null;

			// Part Number

			XMLElement = XMLDocument.CreateElement("PartNumber");
			XMLTextElement = XMLDocument.CreateTextNode(m_strPartNumber);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Caliber

			m_Caliber.ExportIdentity(XMLDocument, XMLThisElement);

			// Match

			XMLElement = XMLDocument.CreateElement("Match");
			XMLTextElement = XMLDocument.CreateTextNode(m_fMatch ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Military

			XMLElement = XMLDocument.CreateElement("Military");
			XMLTextElement = XMLDocument.CreateTextNode(m_fMilitary ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Large Primer

			XMLElement = XMLDocument.CreateElement("LargePrimer");
			XMLTextElement = XMLDocument.CreateTextNode(m_fLargePrimer ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Small Primer

			XMLElement = XMLDocument.CreateElement("SmallPrimer");
			XMLTextElement = XMLDocument.CreateTextNode(m_fSmallPrimer ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public string ExportName
			{
			get
				{
				return ("Case");
				}
			}

		//============================================================================*
		// HeadStamp Property
		//============================================================================*

		public string HeadStamp
			{
			get
				{
				string strHeadStamp = "";

				if (Manufacturer != null && Manufacturer.HeadStamp != null && Manufacturer.HeadStamp.Length > 0)
					strHeadStamp += Manufacturer.HeadStamp;

				if (m_fMatch)
					strHeadStamp += " Match";

				if (m_Caliber != null)
					{
					strHeadStamp += " - ";
					strHeadStamp += m_Caliber.HeadStamp;
					}

				return (strHeadStamp);
				}
			}

		//============================================================================*
		// LargePrimer Property
		//============================================================================*

		public bool LargePrimer
			{
			get
				{
				return (m_fLargePrimer);
				}
			set
				{
				m_fLargePrimer = value;

				m_fSmallPrimer = !m_fLargePrimer;
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
		// PartNumber Property
		//============================================================================*

		public string PartNumber
			{
			get
				{
				return (m_strPartNumber);
				}
			set
				{
				m_strPartNumber = value;
				}
			}

		//============================================================================*
		// SmallPrimer Property
		//============================================================================*

		public bool SmallPrimer
			{
			get
				{
				return (m_fSmallPrimer);
				}
			set
				{
				m_fSmallPrimer = value;

				m_fLargePrimer = !m_fSmallPrimer;
				}
			}

		//============================================================================*
		// Synch() - Caliber
		//============================================================================*

		public bool Synch(cCaliber Caliber)
			{
			if (m_Caliber.CompareTo(Caliber) == 0)
				{
				m_Caliber = Caliber;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// Match Property
		//============================================================================*

		public bool Match
			{
			get
				{
				return (m_fMatch);
				}
			set
				{
				m_fMatch = value;
				}
			}

		//============================================================================*
		// ToShortString
		//============================================================================*

		public string ToShortString()
			{
			string strString = String.Format("{0}", Manufacturer.Name);

			if (!string.IsNullOrEmpty(Manufacturer.HeadStamp) && Manufacturer.HeadStamp != Manufacturer.Name)
				strString += String.Format(" ({0})", Manufacturer.HeadStamp);

			if (m_fMatch)
				strString += " Match";

			return (strString);
			}

		//============================================================================*
		// ToString
		//============================================================================*

		public override string ToString()
			{
			string strString = "";

			if (Manufacturer != null)
				strString = Manufacturer.Name;

			string strHeadStamp = "";

			if (!String.IsNullOrEmpty(Manufacturer.HeadStamp) && Manufacturer.HeadStamp != Manufacturer.Name)
				strHeadStamp += String.Format("({0}", (Manufacturer != null) ? Manufacturer.HeadStamp : "");

			if (m_fMatch)
				strString += " Match";

			if (m_Caliber != null && !String.IsNullOrEmpty(m_Caliber.HeadStamp))
				{
				if (strHeadStamp.Length == 0)
					strHeadStamp = "(";
				else
					strHeadStamp += " - ";

				strHeadStamp += String.Format("{0})", m_Caliber.HeadStamp);
				}
			else
				{
				if (strHeadStamp.Length != 0)
					strHeadStamp += ")";
				}

			strString += (" " + strHeadStamp);

			strString = ToCrossUseString(strString);

			return (strString);
			}
		}
	}
