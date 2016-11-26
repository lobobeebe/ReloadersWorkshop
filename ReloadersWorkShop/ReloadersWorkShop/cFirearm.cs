//============================================================================*
// cFirearm.cs
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
	// cFirearm class
	//============================================================================*

	[Serializable]
	public class cFirearm : cGear, IComparable
		{
		//============================================================================*
		// Public Enumerations
		//============================================================================*

		public enum eFireArmType
			{
			None = -1,
			Handgun = 0,
			Rifle,
			Shotgun
			}

		public enum eTurretType
			{
			MOA = 0,
			MilDot
			}

		//============================================================================*
		// Private Data Members
		//============================================================================*

		//----------------------------------------------------------------------------*
		// General
		//----------------------------------------------------------------------------*

		private eFireArmType m_eFirearmType = eFireArmType.Handgun;

		//----------------------------------------------------------------------------*
		// Specs
		//----------------------------------------------------------------------------*

		private int m_nZeroRange = 25;
		private double m_dBarrelLength = 0.0;
		private double m_dTwist = 1.0;
		private double m_dSightHeight = 0.8;

		private bool m_fScoped = false;
		private double m_dScopeClick = 0.25;
		private eTurretType m_eTurretType = eTurretType.MOA;

		private double m_dHeadSpace = 0.0;
		private double m_dNeck = 0.0;

		private cFirearmCaliberList m_FirearmCaliberList = new cFirearmCaliberList();

		private cFirearmBulletList m_FirearmBulletList = new cFirearmBulletList();

		//----------------------------------------------------------------------------*
		// Details
		//----------------------------------------------------------------------------*

		private string m_strImageFile = "";

		private string m_strReceiverFinish = "";
		private String m_strBarrelFinish = "";

		private string m_strType = "";
		private string m_strAction = "";
		private string m_strHammer = "";

		private string m_strMagazine = "";
		private int m_nCapacity = 1;

		private string m_strNotes = "";

		//----------------------------------------------------------------------------*
		// Miscellaneous
		//----------------------------------------------------------------------------*

		private bool m_fChecked = false;

		//============================================================================*
		// cFirearm() - Constructor
		//============================================================================*

		public cFirearm()
			: base(cGear.eGearTypes.Firearm)
			{
			}

		//============================================================================*
		// cFirearm() - Copy Constructor
		//============================================================================*

		public cFirearm(cFirearm Firearm)
			: base(Firearm)
			{
			Copy(Firearm);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public void Copy(cFirearm Firearm)
			{
			base.Copy(Firearm);

			//----------------------------------------------------------------------------*
			// General
			//----------------------------------------------------------------------------*

			m_eFirearmType = Firearm.m_eFirearmType;

			//----------------------------------------------------------------------------*
			// Specs
			//----------------------------------------------------------------------------*

			m_dBarrelLength = Firearm.m_dBarrelLength;

			m_fScoped = Firearm.m_fScoped;
			m_dTwist = Firearm.m_dTwist;
			m_eTurretType = Firearm.m_eTurretType;

			m_dSightHeight = Firearm.m_dSightHeight;
			m_dScopeClick = Firearm.m_dScopeClick;

			m_nZeroRange = Firearm.m_nZeroRange;

			m_dHeadSpace = Firearm.m_dHeadSpace;
			m_dNeck = Firearm.m_dNeck;

			m_FirearmCaliberList = new cFirearmCaliberList(Firearm.m_FirearmCaliberList);

			m_FirearmBulletList = new cFirearmBulletList(Firearm.m_FirearmBulletList);

			//----------------------------------------------------------------------------*
			// Details
			//----------------------------------------------------------------------------*

			m_strImageFile = Firearm.m_strImageFile;

			m_strReceiverFinish = Firearm.m_strReceiverFinish;
			m_strBarrelFinish = Firearm.m_strBarrelFinish;

			m_strType = Firearm.m_strType;
			m_strAction = Firearm.m_strAction;
			m_strHammer = Firearm.m_strHammer;

			m_strMagazine = Firearm.m_strMagazine;
			m_nCapacity = Firearm.m_nCapacity;

			m_strNotes = Firearm.m_strNotes;
			}

		//============================================================================*
		// Action Property
		//============================================================================*

		public string Action
			{
			get
				{
				return (m_strAction);
				}
			set
				{
				m_strAction = value;
				}
			}

		//============================================================================*
		// AddCaliber()
		//============================================================================*

		public bool AddCaliber(cCaliber Caliber)
			{
			if (Caliber == null)
				return (false);

			bool fFound = false;

			foreach (cFirearmCaliber FirearmCaliber in m_FirearmCaliberList)
				{
				if (FirearmCaliber.Caliber.CompareTo(Caliber) == 0)
					{
					fFound = true;

					break;
					}
				}

			if (!fFound)
				{
				cFirearmCaliber FirearmCaliber = new cFirearmCaliber();

				FirearmCaliber.Caliber = Caliber;

				if (m_FirearmCaliberList.Count == 0)
					FirearmCaliber.Primary = true;

				m_FirearmCaliberList.Add(FirearmCaliber);

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// BarrelFinish Property
		//============================================================================*

		public string BarrelFinish
			{
			get
				{
				return (m_strBarrelFinish);
				}
			set
				{
				m_strBarrelFinish = value;
				}
			}

		//============================================================================*
		// BarrelLength Property
		//============================================================================*

		public double BarrelLength
			{
			get
				{
				return (m_dBarrelLength);
				}
			set
				{
				m_dBarrelLength = value;
				}
			}

		//============================================================================*
		// CaliberList Property
		//============================================================================*

		public cFirearmCaliberList CaliberList
			{
			get
				{
				return (m_FirearmCaliberList);
				}

			set
				{
				m_FirearmCaliberList = value;
				}
			}

		//============================================================================*
		// CanUseBullet()
		//============================================================================*

		public bool CanUseBullet(cBullet Bullet)
			{
			if (Bullet != null)
				{
				foreach (cFirearmCaliber FirearmCaliber in m_FirearmCaliberList)
					{
					if (Bullet.HasCaliber(FirearmCaliber.Caliber))
						return (true);
					}
				}

			return (false);
			}

		//============================================================================*
		// Capacity Property
		//============================================================================*

		public int Capacity
			{
			get
				{
				return (m_nCapacity);
				}
			set
				{
				m_nCapacity = value;
				}
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
		// Comparer()
		//============================================================================*

		public static int Comparer(cFirearm Firearm1, cFirearm Firearm2)
			{
			if (Firearm1 == null)
				{
				if (Firearm2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Firearm2 == null)
					return (1);
				}

			return (Firearm1.CompareTo(Firearm2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public override int CompareTo(Object obj)
			{
			if (obj == null)
				return (1);

			cFirearm Firearm = (cFirearm) obj;

			int rc = base.CompareTo(Firearm);

			//----------------------------------------------------------------------------*
			// Firearm Type
			//----------------------------------------------------------------------------*

			if (rc == 0)
				rc = m_eFirearmType.CompareTo(Firearm.m_eFirearmType);

			return (rc);
			}

		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public override string CSVLine
			{
			get
				{
				string strLine = "";

				//----------------------------------------------------------------------------*
				// General
				//----------------------------------------------------------------------------*

				strLine += Manufacturer.Name;
				strLine += ",";
				strLine += PartNumber;
				strLine += ",";
				strLine += SerialNumber;
				strLine += ",";
				strLine += cFirearm.FirearmTypeString(m_eFirearmType);
				strLine += ",";

				strLine += m_dBarrelLength;
				strLine += ",";
				strLine += m_dTwist;
				strLine += ",";
				strLine += m_dSightHeight;

				strLine += m_fScoped ? ",Yes," : ",-,";
				strLine += m_dScopeClick;
				strLine += ",";
				strLine += m_eTurretType == eTurretType.MOA ? "MOA," : "Mils,";

				strLine += m_nZeroRange;
				strLine += ",";
				strLine += m_dHeadSpace;
				strLine += ",";
				strLine += m_dNeck;
				strLine += ",";

				strLine += Source;
				strLine += ",";
				strLine += PurchaseDate;
				strLine += ",";
				strLine += PurchasePrice;
				strLine += ",";

				strLine += m_strReceiverFinish;
				strLine += ",";
				strLine += m_strBarrelFinish;
				strLine += ",";

				strLine += m_strType;
				strLine += ",";
				strLine += m_strAction;
				strLine += ",";
				strLine += m_strHammer;
				strLine += ",";
				strLine += m_strMagazine;
				strLine += ",";
				strLine += m_nCapacity;

				strLine += m_strNotes;

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
				return("Manufacturer,Model,Serial Number,Firearm Type,Barrel Length,Twist,Sight Height,Scoped,Scope Click, Turret Type,Zero Range,HeadSpace,Neck,Source,Purchase Date,Price,Receiver Finish,Barrel Finish,Type,Action,Hammer,Magazine,Capacity,Notes");
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public override void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement("Firearm");
			XMLParentElement.AppendChild(XMLThisElement);

			// Manufacturer

			XmlElement XMLElement = XMLDocument.CreateElement("Manufacturer");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(Manufacturer.Name);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Model

			XMLElement = XMLDocument.CreateElement("Model");
			XMLTextElement = XMLDocument.CreateTextNode(PartNumber);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Serial Number

			XMLElement = XMLDocument.CreateElement("SerialNumber");
			XMLTextElement = XMLDocument.CreateTextNode(SerialNumber);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Firearm Type

			XMLElement = XMLDocument.CreateElement("FirearmType");
			XMLTextElement = XMLDocument.CreateTextNode(cFirearm.FirearmTypeString(m_eFirearmType));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Barrel Length

			XMLElement = XMLDocument.CreateElement("BarrelLength");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dBarrelLength));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Twist

			XMLElement = XMLDocument.CreateElement("Twist");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dTwist));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Sight Height

			XMLElement = XMLDocument.CreateElement("SightHeight");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dSightHeight));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Scoped?

			XMLElement = XMLDocument.CreateElement("Scoped");
			XMLTextElement = XMLDocument.CreateTextNode(m_fScoped ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Scope Click

			XMLElement = XMLDocument.CreateElement("ScopeClick");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dScopeClick));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Turret Type

			XMLElement = XMLDocument.CreateElement("TurretType");
			XMLTextElement = XMLDocument.CreateTextNode(m_eTurretType == eTurretType.MOA ? "MOA," : "Mils,");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Zero Range

			XMLElement = XMLDocument.CreateElement("ZeroRange");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_nZeroRange));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Headspace

			XMLElement = XMLDocument.CreateElement("Headspace");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dHeadSpace));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Neck Diameter

			XMLElement = XMLDocument.CreateElement("NeckSize");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dNeck));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Source

			XMLElement = XMLDocument.CreateElement("Source");
			XMLTextElement = XMLDocument.CreateTextNode(Source);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Date Purchased

			XMLElement = XMLDocument.CreateElement("DatePurchased");
			XMLTextElement = XMLDocument.CreateTextNode(PurchaseDate.ToShortDateString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Price

			XMLElement = XMLDocument.CreateElement("Price");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", PurchasePrice));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Receiver Finish

			XMLElement = XMLDocument.CreateElement("ReceiverFinish");
			XMLTextElement = XMLDocument.CreateTextNode(m_strReceiverFinish);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Barrel Finish

			XMLElement = XMLDocument.CreateElement("BarrelFinish");
			XMLTextElement = XMLDocument.CreateTextNode(m_strBarrelFinish);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Type

			XMLElement = XMLDocument.CreateElement("Type");
			XMLTextElement = XMLDocument.CreateTextNode(m_strType);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Action

			XMLElement = XMLDocument.CreateElement("Action");
			XMLTextElement = XMLDocument.CreateTextNode(m_strAction);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Hammer

			XMLElement = XMLDocument.CreateElement("Hammer");
			XMLTextElement = XMLDocument.CreateTextNode(m_strHammer);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Magazine

			XMLElement = XMLDocument.CreateElement("Magazine");
			XMLTextElement = XMLDocument.CreateTextNode(m_strMagazine);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Capacity

			XMLElement = XMLDocument.CreateElement("Capacity");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_nCapacity));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Notes

			XMLElement = XMLDocument.CreateElement("Notes");
			XMLTextElement = XMLDocument.CreateTextNode(m_strNotes);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);
			}

		//============================================================================*
		// FirearmBulletList Property
		//============================================================================*

		public cFirearmBulletList FirearmBulletList
			{
			get
				{
				return (m_FirearmBulletList);
				}
			set
				{
				m_FirearmBulletList = value;
				}
			}

		//============================================================================*
		// FirearmType Property
		//============================================================================*

		public eFireArmType FirearmType
			{
			get
				{
				return (m_eFirearmType);
				}
			set
				{
				m_eFirearmType = value;

				SetDefaultDescription();
				}
			}

		//============================================================================*
		// FirearmTypeString()
		//============================================================================*

		public static string FirearmTypeString(cFirearm.eFireArmType eFirearmType)
			{
			switch (eFirearmType)
				{
				case cFirearm.eFireArmType.Handgun:
					return ("Handgun");

				case cFirearm.eFireArmType.Rifle:
					return ("Rifle");

				case cFirearm.eFireArmType.Shotgun:
					return ("Shotgun");
				}

			return ("Unknown");
			}

		//============================================================================*
		// Hammer Property
		//============================================================================*

		public string Hammer
			{
			get
				{
				return (m_strHammer);
				}
			set
				{
				m_strHammer = value;
				}
			}

		//============================================================================*
		// HasBullet()
		//============================================================================*

		public bool HasBullet(cBullet Bullet, cCaliber Caliber)
			{
			if (Bullet == null || Caliber == null)
				return (false);

			foreach (cFirearmBullet CheckBullet in m_FirearmBulletList)
				{
				if (CheckBullet.Bullet.CompareTo(Bullet) == 0 && CheckBullet.Caliber.CompareTo(Caliber) == 0)
					return (true);
				}

			return (false);
			}

		//============================================================================*
		// HasCaliber()
		//============================================================================*

		public bool HasCaliber(cCaliber Caliber)
			{
			if (Caliber == null)
				return (false);

			if (m_FirearmCaliberList == null)
				m_FirearmCaliberList = new cFirearmCaliberList();

			foreach (cFirearmCaliber CheckFirearmCaliber in m_FirearmCaliberList)
				{
				if (CheckFirearmCaliber.Caliber.CompareTo(Caliber) == 0)
					return (true);
				}

			return (false);
			}

		//============================================================================*
		// HeadSpace Property
		//============================================================================*

		public double HeadSpace
			{
			get
				{
				return (m_dHeadSpace);
				}

			set
				{
				if (value >= 0.00)
					m_dHeadSpace = value;
				}
			}

		//============================================================================*
		// ImageFile Property
		//============================================================================*

		public string ImageFile
			{
			get
				{
				return (m_strImageFile);
				}
			set
				{
				m_strImageFile = value;
				}
			}

		//============================================================================*
		// ImageFilename Property
		//============================================================================*

		public string ImageFileName
			{
			get
				{
				if (Manufacturer == null || String.IsNullOrEmpty(PartNumber) || String.IsNullOrEmpty(SerialNumber))
					return ("");

				string strFileName = String.Format("{0} {1} ({2})", Manufacturer.ToString(), PartNumber, SerialNumber);

				strFileName = strFileName.Replace('/', '-');
				strFileName = strFileName.Replace('\\', '-');
				strFileName = strFileName.Replace(':', '-');
				strFileName = strFileName.Replace('*', '-');
				strFileName = strFileName.Replace('?', '-');
				strFileName = strFileName.Replace('\"', '-');
				strFileName = strFileName.Replace('<', '-');
				strFileName = strFileName.Replace('>', '-');
				strFileName = strFileName.Replace('|', '-');
				strFileName = strFileName.Replace('.', ' ');

				return (strFileName);
				}
			}

		//============================================================================*
		// Magazine Property
		//============================================================================*

		public string Magazine
			{
			get
				{
				return (m_strMagazine);
				}
			set
				{
				m_strMagazine = value;
				}
			}

		//============================================================================*
		// MagazineCapacity Property
		//============================================================================*

		public int MagazineCapacity
			{
			get
				{
				return (m_nCapacity);
				}
			set
				{
				m_nCapacity = value;
				}
			}

		//============================================================================*
		// Neck Property
		//============================================================================*

		public double Neck
			{
			get
				{
				return (m_dNeck);
				}

			set
				{
				if (value >= 0.00)
					m_dNeck = value;
				}
			}

		//============================================================================*
		// Notes Property
		//============================================================================*

		public string Notes
			{
			get
				{
				return (m_strNotes);
				}
			set
				{
				m_strNotes = value;
				}
			}

		//============================================================================*
		// PrimaryCaliber Property
		//============================================================================*

		public cCaliber PrimaryCaliber
			{
			get
				{
				cCaliber Caliber = null;

				if (m_FirearmCaliberList == null)
					m_FirearmCaliberList = new cFirearmCaliberList();

				foreach (cFirearmCaliber FirearmCaliber in m_FirearmCaliberList)
					{
					if (FirearmCaliber.Primary)
						{
						Caliber = FirearmCaliber.Caliber;

						break;
						}
					}

				return (Caliber);
				}

			set
				{
				cCaliber Caliber = value;

				foreach (cFirearmCaliber FirearmCaliber in m_FirearmCaliberList)
					{
					if (FirearmCaliber.Caliber.CompareTo(Caliber) == 0)
						FirearmCaliber.Primary = true;
					else
						FirearmCaliber.Primary = false;
					}
				}
			}

		//============================================================================*
		// ReceiverFinish Property
		//============================================================================*

		public string ReceiverFinish
			{
			get
				{
				return (m_strReceiverFinish);
				}
			set
				{
				m_strReceiverFinish = value;
				}
			}

		//============================================================================*
		// RemoveCaliber()
		//============================================================================*

		public void RemoveCaliber(cFirearmCaliber FirearmCaliber)
			{
			if (FirearmCaliber == null)
				return;

			cCaliber Caliber = FirearmCaliber.Caliber;

			//----------------------------------------------------------------------------*
			// Remove the caliber
			//----------------------------------------------------------------------------*

			m_FirearmCaliberList.Remove(FirearmCaliber);

			//----------------------------------------------------------------------------*
			// If it was the primary, pick a new one
			//----------------------------------------------------------------------------*

			bool fPrimaryFound = false;

			foreach (cFirearmCaliber CheckCaliber in m_FirearmCaliberList)
				{
				if (CheckCaliber.Primary)
					{
					fPrimaryFound = true;

					break;
					}
				}

			if (!fPrimaryFound)
				{
				if (m_FirearmCaliberList.Count > 0)
					m_FirearmCaliberList[0].Primary = true;
				}

			//----------------------------------------------------------------------------*
			// Remove firearm bullets that match the removed caliber
			//----------------------------------------------------------------------------*

			while (true)
				{
				bool fRemoved = false;

				foreach (cFirearmBullet CheckBullet in m_FirearmBulletList)
					{
					if (CheckBullet.Caliber.CompareTo(Caliber) == 0)
						{
						m_FirearmBulletList.Remove(CheckBullet);

						fRemoved = true;

						break;
						}
					}

				if (!fRemoved)
					break;
				}
			}

		//============================================================================*
		// ScopeClick Property
		//============================================================================*

		public double ScopeClick
			{
			get
				{
				return (m_dScopeClick);
				}
			set
				{
				m_dScopeClick = value;
				}
			}

		//============================================================================*
		// Scoped Property
		//============================================================================*

		public bool Scoped
			{
			get
				{
				return (m_fScoped);
				}
			set
				{
				m_fScoped = value;
				}
			}

		//============================================================================*
		// SetDefaultDescription()
		//============================================================================*

		public override void SetDefaultDescription()
			{
			switch (m_eFirearmType)
				{
				case eFireArmType.Handgun:
					Description = "Handgun";

					if (PrimaryCaliber != null)
						Description = PrimaryCaliber.Pistol ? "Pistol" : "Revolver";

					break;

				case eFireArmType.Rifle:
					Description = "Rifle";
					break;

				case eFireArmType.Shotgun:
					Description = "Shotgun";
					break;

				default:
					Description = "Other Firearm Type";
					break;
				}
			}

		//============================================================================*
		// SightHeight Property
		//============================================================================*

		public double SightHeight
			{
			get
				{
				return (m_dSightHeight);
				}
			set
				{
				m_dSightHeight = value;
				}
			}

		//============================================================================*
		// Synch() - Bullet
		//============================================================================*

		public bool Synch(cBullet Bullet)
			{
			bool fFound = false;

			foreach (cFirearmBullet CheckFirearmBullet in m_FirearmBulletList)
				fFound = CheckFirearmBullet.Synch(Bullet);

			return (fFound);
			}

		//============================================================================*
		// Synch() - Caliber
		//============================================================================*

		public bool Synch(cCaliber Caliber)
			{
			if (m_FirearmCaliberList == null)
				m_FirearmCaliberList = new cFirearmCaliberList();

			foreach (cFirearmCaliber FirearmCaliber in m_FirearmCaliberList)
				{
				if (FirearmCaliber.Caliber != null && FirearmCaliber.Caliber.CompareTo(Caliber) == 0)
					{
					FirearmCaliber.Caliber = Caliber;

					return (true);
					}
				}

			return (false);
			}

		//============================================================================*
		// ToShortString()
		//============================================================================*

		public string ToShortString()
			{
			return (String.Format("{0} {1}", (Manufacturer != null) ? Manufacturer.Name : "", PartNumber));
			}

		//============================================================================*
		// ToString()
		//============================================================================*

		public override string ToString()
			{
			return (String.Format("{0} {1} ({2})", (Manufacturer != null) ? Manufacturer.Name : "", PartNumber, SerialNumber));
			}

		//============================================================================*
		// ToLongString()
		//============================================================================*

		public string ToLongString()
			{
			return (ToString() + String.Format(" - {0}", PrimaryCaliber.ToString()));
			}

		//============================================================================*
		// TurretClickString Property
		//============================================================================*

		public string TurretClickString
			{
			get
				{
				if (m_fScoped)
					{
					switch (m_eTurretType)
						{
						case eTurretType.MOA:
							return (String.Format("{0:F3} MOA", m_dScopeClick));

						case eTurretType.MilDot:
							return (String.Format("{0:F3} Mil", m_dScopeClick));
						}
					}

				return ("-");
				}
			}

		//============================================================================*
		// TurretType Property
		//============================================================================*

		public eTurretType TurretType
			{
			get
				{
				return (m_eTurretType);
				}
			set
				{
				m_eTurretType = value;
				}
			}

		//============================================================================*
		// TurretTypeString Property
		//============================================================================*

		public string TurretTypeString
			{
			get
				{
				if (m_fScoped)
					{
					switch (m_eTurretType)
						{
						case eTurretType.MOA:
							return ("MOA");

						case eTurretType.MilDot:
							return ("Mil");
						}
					}

				return ("-");
				}
			}

		//============================================================================*
		// Twist Property
		//============================================================================*

		public double Twist
			{
			get
				{
				return (m_dTwist);
				}
			set
				{
				m_dTwist = value;
				}
			}

		//============================================================================*
		// Type Property
		//============================================================================*

		public string Type
			{
			get
				{
				return (m_strType);
				}
			set
				{
				m_strType = value;
				}
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public bool Validate()
			{
			bool fOK = Manufacturer != null;

			if (fOK)
				fOK = !String.IsNullOrEmpty(PartNumber);

			return (fOK);
			}

		//============================================================================*
		// XMLHeader Property
		//============================================================================*

		public static string XMLHeader
			{
			get
				{
				return ("Firearms");
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
				string strLine = "";

				return (strLine);
				}
			}

		//============================================================================*
		// ZeroRange Property
		//============================================================================*

		public int ZeroRange
			{
			get
				{
				return (m_nZeroRange);
				}
			set
				{
				m_nZeroRange = value;
				}
			}
		}
	}
