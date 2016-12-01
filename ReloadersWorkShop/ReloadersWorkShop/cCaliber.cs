//============================================================================*
// cCaliber.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.IO;
using System.Xml;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cCaliber class
	//============================================================================*

	[Serializable]
	public class cCaliber : IComparable
		{
		//============================================================================*
		// Public Static Data Members
		//============================================================================*

		public static cFirearm.eFireArmType sm_eCurrentFirearmType = cFirearm.eFireArmType.Handgun;

		//============================================================================*
		// Private Data Members
		//============================================================================*

		//----------------------------------------------------------------------------*
		// General
		//----------------------------------------------------------------------------*

		private cFirearm.eFireArmType m_eFirearmType = cFirearm.eFireArmType.Handgun;
		private string m_strName = "";
		private string m_strHeadStamp = "";

		private bool m_fPistol = true;

		//----------------------------------------------------------------------------*
		// Primer
		//----------------------------------------------------------------------------*

		private bool m_fSmallPrimer = false;
		private bool m_fLargePrimer = true;
		private bool m_fMagnumPrimer = false;

		//----------------------------------------------------------------------------*
		// Dimensions
		//----------------------------------------------------------------------------*

		private double m_dMinBulletDiameter = 0.0;
		private double m_dMaxBulletDiameter = 0.0;

		private double m_dMinBulletWeight = 0.0;
		private double m_dMaxBulletWeight = 0.0;

		private double m_dCaseTrimLength = 0.0;
		private double m_dMaxCaseLength = 0.0;

		private double m_dMaxCOL = 0.0;

		private double m_dMaxNeckDiameter = 0.0;

		//----------------------------------------------------------------------------*
		// Miscellaneous
		//----------------------------------------------------------------------------*

		private string m_strSAAMIPDF = "";

		private bool m_fChecked = false;

		//----------------------------------------------------------------------------*
		// Temporary - No need to save
		//----------------------------------------------------------------------------*

		private bool m_fIdentity = false;

		//============================================================================*
		// cCaliber() - Constructor
		//============================================================================*

		public cCaliber(bool fidentity = false)
			{
			m_fIdentity = fidentity;
			}

		//============================================================================*
		// cCaliber() - Copy Constructor
		//============================================================================*

		public cCaliber(cCaliber Caliber)
			{
			m_eFirearmType = Caliber.m_eFirearmType;
			m_strName = Caliber.m_strName;
			m_strHeadStamp = Caliber.m_strHeadStamp;
			m_fPistol = Caliber.m_fPistol;
			m_fSmallPrimer = Caliber.m_fSmallPrimer;
			m_fLargePrimer = Caliber.m_fLargePrimer;
			m_fMagnumPrimer = Caliber.m_fMagnumPrimer;
			m_dMinBulletDiameter = Caliber.m_dMinBulletDiameter;
			m_dMaxBulletDiameter = Caliber.m_dMaxBulletDiameter;
			m_dMinBulletWeight = Caliber.m_dMinBulletWeight;
			m_dMaxBulletWeight = Caliber.m_dMaxBulletWeight;
			m_dCaseTrimLength = Caliber.m_dCaseTrimLength;
			m_dMaxCaseLength = Caliber.m_dMaxCaseLength;
			m_dMaxCOL = Caliber.m_dMaxCOL;
			m_dMaxNeckDiameter = Caliber.m_dMaxNeckDiameter;
			m_strSAAMIPDF = Caliber.m_strSAAMIPDF;

			m_fChecked = Caliber.m_fChecked;

			m_fIdentity = Caliber.m_fIdentity;
			}

		//============================================================================*
		// Checked Property
		//============================================================================*

		public bool Checked
			{
			get
				{
				return (m_fChecked);
				}
			set
				{
				m_fChecked = value;
				}
			}

		//============================================================================*
		// CaseTrimLength Property
		//============================================================================*

		public double CaseTrimLength
			{
			get
				{
				return (m_dCaseTrimLength);
				}
			set
				{
				m_dCaseTrimLength = value;
				}
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cCaliber Caliber1, cCaliber Caliber2)
			{
			if (Caliber1 == null)
				{
				if (Caliber2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Caliber2 == null)
					return (1);
				}

			return (Caliber1.CompareTo(Caliber2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(Object obj)
			{
			if (obj == null)
				return (1);

			cCaliber Caliber = (cCaliber) obj;

			cCaliber.CurrentFirearmType = FirearmType;

			int rc = FirearmType.CompareTo(Caliber.FirearmType);

			if (rc == 0)
				rc = Name.ToUpper().CompareTo(Caliber.Name.ToUpper());

			return (rc);
			}

		//============================================================================*
		// CSVHeader Property
		//============================================================================*

		public static string CSVHeader
			{
			get
				{
				return ("Calibers");
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

				strLine += m_strName;
				strLine += ",";

				strLine += cFirearm.FirearmTypeString(m_eFirearmType);
				strLine += ",";

				strLine += m_strHeadStamp;

				if (m_eFirearmType == cFirearm.eFireArmType.Handgun)
					strLine += m_fPistol ? ",Pistol" : ",Revolver";
				else
					strLine += ",N/A";

				strLine += m_fSmallPrimer ? ",Yes" : ",-";
				strLine += m_fLargePrimer ? ",Yes" : ",-";
				strLine += m_fMagnumPrimer ? ",Yes" : ",-";

				//----------------------------------------------------------------------------*
				// Dimensions
				//----------------------------------------------------------------------------*

				strLine += ",";
				strLine += m_dMinBulletDiameter;
				strLine += ",";
				strLine += m_dMaxBulletDiameter;

				strLine += ",";
				strLine += m_dMinBulletWeight;
				strLine += ",";
				strLine += m_dMaxBulletWeight;

				strLine += ",";
				strLine += m_dCaseTrimLength;
				strLine += ",";
				strLine += m_dMaxCaseLength;

				strLine += ",";
				strLine += m_dMaxCOL;

				strLine += ",";
				strLine += m_dMaxNeckDiameter;

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
				string strLine = "Name,Firearm Type,Headstamp,Handgun Type,Small Primer,Large Primer,Magnum Primer,Min Bullet Dia.,Max Bullet Dia.,Min Bullet Weight,Max Bullet Weight,Case Trim Length,Max Case Length,Max COAL,Max Neck Dia";

				return (strLine);
				}
			}

		//============================================================================*
		// CurrentFirearmType Property
		//============================================================================*

		public static cFirearm.eFireArmType CurrentFirearmType
			{
			get
				{
				return (sm_eCurrentFirearmType);
				}
			set
				{
				sm_eCurrentFirearmType = value;
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement("Caliber");
			XMLParentElement.AppendChild(XMLThisElement);

			// Name

			XmlElement XMLElement = XMLDocument.CreateElement("Name");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(m_strName);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Firearm Type

			XMLElement = XMLDocument.CreateElement("FirearmType");
			XMLTextElement = XMLDocument.CreateTextNode(cFirearm.FirearmTypeString(m_eFirearmType));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Head Stamp

			XMLElement = XMLDocument.CreateElement("HeadStamp");
			XMLTextElement = XMLDocument.CreateTextNode(m_strHeadStamp);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Handgun Type

			if (m_eFirearmType == cFirearm.eFireArmType.Handgun)
				{
				XMLElement = XMLDocument.CreateElement("HandgunType");

				string strHandgunType = "N/A";

				if (m_eFirearmType == cFirearm.eFireArmType.Handgun)
					strHandgunType = m_fPistol ? "Pistol" : "Revolver";

				XMLTextElement = XMLDocument.CreateTextNode(strHandgunType);
				XMLElement.AppendChild(XMLTextElement);

				XMLThisElement.AppendChild(XMLElement);
				}

			// SAAMI PDF

			if (!String.IsNullOrEmpty(m_strSAAMIPDF))
				{
				XMLElement = XMLDocument.CreateElement("SAAMIPDF");
				XMLTextElement = XMLDocument.CreateTextNode(m_strSAAMIPDF);
				XMLElement.AppendChild(XMLTextElement);

				XMLThisElement.AppendChild(XMLElement);
				}

			// Small Primer

			XMLElement = XMLDocument.CreateElement("SmallPrimer");
			XMLTextElement = XMLDocument.CreateTextNode(m_fSmallPrimer ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Large Primer

			XMLElement = XMLDocument.CreateElement("LargePrimer");
			XMLTextElement = XMLDocument.CreateTextNode(m_fLargePrimer ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Magnum Primer

			XMLElement = XMLDocument.CreateElement("MagnumPrimer");
			XMLTextElement = XMLDocument.CreateTextNode(m_fMagnumPrimer ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			//----------------------------------------------------------------------------*
			// Dimensions
			//----------------------------------------------------------------------------*

			// Min Bullet Diameter

			XMLElement = XMLDocument.CreateElement("MinBulletDiameter");
			XMLTextElement = XMLDocument.CreateTextNode(m_dMinBulletDiameter.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Max Bullet Diameter

			XMLElement = XMLDocument.CreateElement("MaxBulletDiameter");
			XMLTextElement = XMLDocument.CreateTextNode(m_dMaxBulletDiameter.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Min  Bullet Weight

			XMLElement = XMLDocument.CreateElement("MinBulletWeight");
			XMLTextElement = XMLDocument.CreateTextNode(m_dMinBulletWeight.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Max  Bullet Weight

			XMLElement = XMLDocument.CreateElement("MaxBulletWeight");
			XMLTextElement = XMLDocument.CreateTextNode(m_dMaxBulletWeight.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Case Trim Length

			XMLElement = XMLDocument.CreateElement("CaseTrimLength");
			XMLTextElement = XMLDocument.CreateTextNode(m_dCaseTrimLength.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Max Case Length

			XMLElement = XMLDocument.CreateElement("MaxCaseLength");
			XMLTextElement = XMLDocument.CreateTextNode(m_dMaxCaseLength.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Max COAL

			XMLElement = XMLDocument.CreateElement("MaxCOAL");
			XMLTextElement = XMLDocument.CreateTextNode(m_dMaxCOL.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Max Neck Diameter

			XMLElement = XMLDocument.CreateElement("MaxNeckDiameter");
			XMLTextElement = XMLDocument.CreateTextNode(m_dMaxNeckDiameter.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Checked

			XMLElement = XMLDocument.CreateElement("Checked");
			XMLTextElement = XMLDocument.CreateTextNode(m_fChecked ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);
			}

		//============================================================================*
		// ExportIdentity() - XML Document
		//============================================================================*

		public void ExportIdentity(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement("CaliberIdentity");
			XMLParentElement.AppendChild(XMLThisElement);

			// Firearm Type

			XmlElement XMLElement = XMLDocument.CreateElement("FirearmType");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(cFirearm.FirearmTypeString(m_eFirearmType));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Name

			XMLElement = XMLDocument.CreateElement("Name");
			XMLTextElement = XMLDocument.CreateTextNode(m_strName);
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
				return ("Caliber");
				}
			}

		//============================================================================*
		// FirearmType Property
		//============================================================================*

		public cFirearm.eFireArmType FirearmType
			{
			get
				{
				return (m_eFirearmType);
				}
			set
				{
				m_eFirearmType = value;
				}
			}

		//============================================================================*
		// HeadStamp Property
		//============================================================================*

		public string HeadStamp
			{
			get
				{
				return (m_strHeadStamp);
				}
			set
				{
				m_strHeadStamp = value;
				}
			}

		//============================================================================*
		// Identity Property
		//============================================================================*

		public bool Identity
			{
			get
				{
				return (m_fIdentity);
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public bool Import(XmlDocument XMLDocument, XmlNode XMLThisNode)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "FirearmType":
						m_eFirearmType = cFirearm.FirearmTypeFromString(XMLNode.FirstChild.Value);
						break;
					case "Name":
						m_strName = XMLNode.FirstChild.Value;
						break;
					case "Headstamp":
						m_strHeadStamp = XMLNode.FirstChild.Value;
						break;
					case "HandgunType":
						m_fPistol = XMLNode.FirstChild.Value == "Pistol";
						break;
					case "SmallPrimer":
						m_fSmallPrimer = XMLNode.FirstChild.Value == "Yes";
						break;
					case "LargePrimer":
						m_fLargePrimer = XMLNode.FirstChild.Value == "Yes";
						break;
					case "MagnumPrimer":
						m_fMagnumPrimer = XMLNode.FirstChild.Value == "Yes";
						break;
					case "MinBulletDiameter":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dMinBulletDiameter);
						break;
					case "MaxBulletDiameter":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dMaxBulletDiameter);
						break;
					case "MinBulletWeight":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dMinBulletWeight);
						break;
					case "MaxBulletWeight":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dMaxBulletWeight);
						break;
					case "CaseTrimLength":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dCaseTrimLength);
						break;
					case "MaxCaseLength":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dMaxCaseLength);
						break;
					case "MaxCOAL":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dMaxCOL);
						break;
					case "MaxNeckDiameter":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dMaxNeckDiameter);
						break;
					case "SAAMIPDF":
						m_strSAAMIPDF = XMLNode.FirstChild.Value;
						break;
					case "Checked":
						m_fChecked = XMLNode.FirstChild.Value == "Yes";
						break;
					default:
						break;
					}

				XMLNode = XMLNode.NextSibling;
				}

			return (Validate());
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
				}
			}

		//============================================================================*
		// MagnumPrimer Property
		//============================================================================*

		public bool MagnumPrimer
			{
			get
				{
				return (m_fMagnumPrimer);
				}
			set
				{
				m_fMagnumPrimer = value;
				}
			}

		//============================================================================*
		// MaxBulletDiameter Property
		//============================================================================*

		public double MaxBulletDiameter
			{
			get
				{
				return (m_dMaxBulletDiameter);
				}
			set
				{
				m_dMaxBulletDiameter = value;
				}
			}

		//============================================================================*
		// MaxBulletWeight Property
		//============================================================================*

		public double MaxBulletWeight
			{
			get
				{
				return (m_dMaxBulletWeight);
				}
			set
				{
				m_dMaxBulletWeight = value;
				}
			}

		//============================================================================*
		// MaxCaseLength Property
		//============================================================================*

		public double MaxCaseLength
			{
			get
				{
				return (m_dMaxCaseLength);
				}
			set
				{
				m_dMaxCaseLength = value;
				}
			}

		//============================================================================*
		// MaxCOL Property
		//============================================================================*

		public double MaxCOL
			{
			get
				{
				return (m_dMaxCOL);
				}
			set
				{
				m_dMaxCOL = value;
				}
			}

		//============================================================================*
		// MaxNeckDiameter Property
		//============================================================================*

		public double MaxNeckDiameter
			{
			get
				{
				return (m_dMaxNeckDiameter);
				}
			set
				{
				m_dMaxNeckDiameter = value;
				}
			}

		//============================================================================*
		// MinBulletDiameter Property
		//============================================================================*

		public double MinBulletDiameter
			{
			get
				{
				return (m_dMinBulletDiameter);
				}
			set
				{
				m_dMinBulletDiameter = value;
				}
			}

		//============================================================================*
		// MinBulletWeight Property
		//============================================================================*

		public double MinBulletWeight
			{
			get
				{
				return (m_dMinBulletWeight);
				}
			set
				{
				m_dMinBulletWeight = value;
				}
			}

		//============================================================================*
		// Name Property
		//============================================================================*

		public string Name
			{
			get
				{
				return (m_strName);
				}
			set
				{
				m_strName = value;
				}
			}

		//============================================================================*
		// Pistol Property
		//============================================================================*

		public bool Pistol
			{
			get
				{
				return (m_fPistol);
				}
			set
				{
				m_fPistol = value;
				}
			}

		//============================================================================*
		// ResolveIdentities()
		//============================================================================*

		public bool ResolveIdentities(cDataFiles Datafiles)
			{
			return (false);
			}

		//============================================================================*
		// SAAMIPDF Property
		//============================================================================*

		public string SAAMIPDF
			{
			get
				{
				return (m_strSAAMIPDF);
				}
			set
				{
				m_strSAAMIPDF = value;
				}
			}

		//============================================================================*
		// ShowSAAMIPDF()
		//============================================================================*

		public static bool ShowSAAMIPDF(cDataFiles DataFiles, cCaliber Caliber)
			{
			string strDocPath = "http://www.saami.org/PubResources/CC_Drawings/";

			switch (Caliber.FirearmType)
				{
				case cFirearm.eFireArmType.Handgun:
					strDocPath += "Pistol/";
					break;

				case cFirearm.eFireArmType.Rifle:
					strDocPath += "Rifle/";
					break;

				case cFirearm.eFireArmType.Shotgun:
					strDocPath += "Shotgun/";
					break;
				}

			strDocPath += Caliber.SAAMIPDF;

			strDocPath = Path.ChangeExtension(strDocPath, ".pdf");

			return (cMainForm.DownloadSAAMIDoc(DataFiles, strDocPath));
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
				}
			}

		//============================================================================*
		// SmallPrimer Property
		//============================================================================*

		public void Synch(cBullet Bullet)
			{
			}

		//============================================================================*
		// ToString()
		//============================================================================*

		public override string ToString()
			{
			string strString = m_strName;

			if (sm_eCurrentFirearmType != m_eFirearmType)
				{
				switch (m_eFirearmType)
					{
					case cFirearm.eFireArmType.Handgun:
						strString += " (Handgun)";
						break;
					case cFirearm.eFireArmType.Rifle:
						strString += " (Rifle)";
						break;
					case cFirearm.eFireArmType.Shotgun:
						strString += " (Shotgun)";
						break;
					}
				}

			return (strString);
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public bool Validate()
			{
			bool fOK = !String.IsNullOrEmpty(m_strName) && !String.IsNullOrEmpty(m_strHeadStamp = "");

			if (fOK)
				fOK = m_fSmallPrimer || m_fLargePrimer || m_fMagnumPrimer;

			if  (fOK)
				fOK = m_dMinBulletDiameter <= m_dMaxBulletDiameter;

			if (fOK)
				fOK = m_dMinBulletWeight <= m_dMaxBulletWeight;

			if (fOK)
				fOK  = m_dCaseTrimLength <= m_dMaxCaseLength;

			if (fOK)
				fOK = m_dMaxCOL >= m_dCaseTrimLength;

			return (fOK);
			}
		}
	}
