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

		//============================================================================*
		// cCaliber() - Constructor
		//============================================================================*

		public cCaliber()
			{
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
			}

		//============================================================================*
		// Checked Property
		//============================================================================*

		public bool Checked
			{
			get { return (m_fChecked); }
			set { m_fChecked = value; }
			}

		//============================================================================*
		// CaseTrimLength Property
		//============================================================================*

		public double CaseTrimLength
			{
			get { return (m_dCaseTrimLength); }
			set { m_dCaseTrimLength = value; }
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
					return(1);
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

			XMLElement = XMLDocument.CreateElement("HandgunType");

			string strHandgunType = "N/A";

			if (m_eFirearmType == cFirearm.eFireArmType.Handgun)
				strHandgunType = m_fPistol ? "Pistol" : "Revolver";

			XMLTextElement = XMLDocument.CreateTextNode(strHandgunType);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

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
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dMinBulletDiameter));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Max Bullet Diameter

			XMLElement = XMLDocument.CreateElement("MaxBulletDiameter");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dMaxBulletDiameter));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Min  Bullet Weight

			XMLElement = XMLDocument.CreateElement("MinBulletWeight");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dMinBulletWeight));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Max  Bullet Weight

			XMLElement = XMLDocument.CreateElement("MaxBulletWeight");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dMaxBulletWeight));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Case Trim Length

			XMLElement = XMLDocument.CreateElement("CaseTrimLength");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dCaseTrimLength));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Max Case Length

			XMLElement = XMLDocument.CreateElement("MaxCaseLength");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dMaxCaseLength));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Max COAL

			XMLElement = XMLDocument.CreateElement("MaxCOAL");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dMaxCOL));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Max Neck Diameter

			XMLElement = XMLDocument.CreateElement("MaxNeckDiameter");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dMaxNeckDiameter));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);
			}

		//============================================================================*
		// FirearmType Property
		//============================================================================*

		public cFirearm.eFireArmType FirearmType
			{
			get { return (m_eFirearmType); }
			set { m_eFirearmType = value; }
			}

		//============================================================================*
		// FirearmTypeString Property
		//============================================================================*

		public string FirearmTypeString
			{
			get
				{
				switch (m_eFirearmType)
					{
					case cFirearm.eFireArmType.Handgun:
						if (m_fPistol)
							return ("Pistol");

						return ("Revolver");

					case cFirearm.eFireArmType.Rifle:
						return ("Rifle");

					case cFirearm.eFireArmType.Shotgun:
						return ("Shotgun");
					}

				return ("Unknown");
				}
			}

		//============================================================================*
		// HeadStamp Property
		//============================================================================*

		public string HeadStamp
			{
			get { return (m_strHeadStamp); }
			set { m_strHeadStamp = value; }
			}

		//============================================================================*
		// LargePrimer Property
		//============================================================================*

		public bool LargePrimer
			{
			get { return (m_fLargePrimer); }
			set { m_fLargePrimer = value; }
			}

		//============================================================================*
		// MagnumPrimer Property
		//============================================================================*

		public bool MagnumPrimer
			{
			get { return (m_fMagnumPrimer); }
			set { m_fMagnumPrimer = value; }
			}

		//============================================================================*
		// MaxBulletDiameter Property
		//============================================================================*

		public double MaxBulletDiameter
			{
			get { return (m_dMaxBulletDiameter); }
			set { m_dMaxBulletDiameter = value; }
			}

		//============================================================================*
		// MaxBulletWeight Property
		//============================================================================*

		public double MaxBulletWeight
			{
			get { return (m_dMaxBulletWeight); }
			set { m_dMaxBulletWeight = value; }
			}

		//============================================================================*
		// MaxCaseLength Property
		//============================================================================*

		public double MaxCaseLength
			{
			get { return (m_dMaxCaseLength); }
			set { m_dMaxCaseLength = value; }
			}

		//============================================================================*
		// MaxCOL Property
		//============================================================================*

		public double MaxCOL
			{
			get { return (m_dMaxCOL); }
			set { m_dMaxCOL = value; }
			}

		//============================================================================*
		// MaxNeckDiameter Property
		//============================================================================*

		public double MaxNeckDiameter
			{
			get { return (m_dMaxNeckDiameter); }
			set { m_dMaxNeckDiameter = value; }
			}

		//============================================================================*
		// MinBulletDiameter Property
		//============================================================================*

		public double MinBulletDiameter
			{
			get { return (m_dMinBulletDiameter); }
			set { m_dMinBulletDiameter = value; }
			}

		//============================================================================*
		// MinBulletWeight Property
		//============================================================================*

		public double MinBulletWeight
			{
			get { return (m_dMinBulletWeight); }
			set { m_dMinBulletWeight = value; }
			}

		//============================================================================*
		// Name Property
		//============================================================================*

		public string Name
			{
			get { return (m_strName); }
			set { m_strName = value; }
			}

		//============================================================================*
		// Pistol Property
		//============================================================================*

		public bool Pistol
			{
			get { return (m_fPistol); }
			set { m_fPistol = value; }
			}

		//============================================================================*
		// SAAMIPDF Property
		//============================================================================*

		public string SAAMIPDF
			{
			get { return (m_strSAAMIPDF); }
			set { m_strSAAMIPDF = value; }
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

			return(cMainForm.DownloadSAAMIDoc(DataFiles, strDocPath));
			}

		//============================================================================*
		// SmallPrimer Property
		//============================================================================*

		public bool SmallPrimer
			{
			get { return (m_fSmallPrimer); }
			set { m_fSmallPrimer = value; }
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
		// XMLHeader Property
		//============================================================================*

		public static string XMLHeader
			{
			get
				{
				return ("Calibers");
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

				switch (m_eFirearmType)
					{
					case cFirearm.eFireArmType.Handgun:
						strLine += "Handgun,";
						break;
					case cFirearm.eFireArmType.Rifle:
						strLine += "Rifle,";
						break;
					case cFirearm.eFireArmType.Shotgun:
						strLine += "Shotgun,";
						break;
					default:
						strLine += ",";
						break;
					}

				strLine += m_strName;
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
