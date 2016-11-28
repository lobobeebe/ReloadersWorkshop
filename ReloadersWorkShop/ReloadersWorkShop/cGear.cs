//============================================================================*
// cGear.cs
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
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cGear class
	//============================================================================*

	[Serializable]
	public class cGear : cPrintObject, IComparable
		{
		//============================================================================*
		// Public Enumerations
		//============================================================================*

		public enum eGearTypes
			{
			Scope = 0,
			Laser,
			RedDot,
			Magnifier,
			Light,
			Trigger,
			Furniture,
			Bipod,
			Parts,
			Misc,
			NumGearTypes,
			Firearm = 99,
			};

		//============================================================================*
		// Private Static Data Members
		//============================================================================*

		private static bool sm_fSortByType = true;

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private eGearTypes m_eType;

		private cManufacturer m_Manufacturer = null;
		private string m_strPartNumber = "";
		private string m_strSerialNumber = "";
		private string m_strDescription = "";
		private string m_strNotes = "";

		private string m_strSource = "";
		private DateTime m_Date = DateTime.Today;
		private double m_dPrice = 0.0;
		private double m_dTax = 0.0;
		private double m_dShipping = 0.0;

		private cGear m_Parent = null;

		//============================================================================*
		// cGear() - Constructor
		//============================================================================*

		public cGear(eGearTypes eType)
			{
			m_eType = eType;

			SetDefaultDescription();
			}

		//============================================================================*
		// cGear() - Copy Constructor
		//============================================================================*

		public cGear(cGear Gear)
			{
			Copy(Gear);

			if (String.IsNullOrEmpty(m_strDescription))
				SetDefaultDescription();
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cGear Gear1, cGear Gear2)
			{
			if (Gear1 == null)
				{
				if (Gear2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Gear2 == null)
					return (1);
				}

			return (Gear1.CompareTo(Gear2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public virtual int CompareTo(Object obj)
			{
			if (obj == null)
				return (1);

			int rc = 0;

			//----------------------------------------------------------------------------*
			// Gear Type
			//----------------------------------------------------------------------------*

			cGear Gear = (cGear) obj;

			if (sm_fSortByType)
				rc = m_eType.CompareTo(Gear.m_eType);

			//----------------------------------------------------------------------------*
			// Manufacturer
			//----------------------------------------------------------------------------*

			if (rc == 0)
				{
				if (m_Manufacturer != null)
					{
					rc = m_Manufacturer.CompareTo(Gear.m_Manufacturer);
					}
				else
					{
					if (Gear.m_Manufacturer != null)
						rc = -1;
					else
						rc = 0;
					}

				//----------------------------------------------------------------------------*
				// Part Number
				//----------------------------------------------------------------------------*

				if (rc == 0)
					{
					rc = cDataFiles.ComparePartNumbers(m_strPartNumber, Gear.PartNumber);

					//----------------------------------------------------------------------------*
					// Serial Number
					//----------------------------------------------------------------------------*

					if (rc == 0)
						{
						rc = cDataFiles.ComparePartNumbers(m_strSerialNumber, Gear.SerialNumber);
						}
					}
				}

			return (rc);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public virtual void Copy(cGear Gear)
			{
			base.Copy(Gear);

			m_eType = Gear.m_eType;
			m_Manufacturer = Gear.m_Manufacturer;

			m_strPartNumber = Gear.m_strPartNumber;
			m_strSerialNumber = Gear.m_strSerialNumber;
			m_strDescription = Gear.m_strDescription;
			m_strNotes = Gear.m_strNotes;

			m_strSource = Gear.m_strSource;
			m_Date = Gear.PurchaseDate;
			m_dPrice = Gear.m_dPrice;
			m_dTax = Gear.m_dTax;
			m_dShipping = Gear.m_dShipping;
			}

		//============================================================================*
		// CSVHeader Property
		//============================================================================*

		public static string CSVHeader(cGear.eGearTypes eType)
			{
			return (cGear.GearTypeString(eType));
			}

		//============================================================================*
		// CSVLineHeaderExtension Property
		//============================================================================*

		public virtual string CSVLineHeaderExtension
			{
			get
				{
				return ("");
				}
			}

		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public virtual string CSVLine
			{
			get
				{
				string strLine = cGear.GearTypeString(m_eType);
				strLine += ",";
				strLine += m_Manufacturer.ToString();
				strLine += ",";
				strLine += m_strPartNumber;
				strLine += ",";
				strLine += m_strSerialNumber;
				strLine += ",";
				strLine += m_strDescription;
				strLine += ",";
				strLine += m_strSource;
				strLine += ",";
				strLine += m_Date.ToShortDateString();
				strLine += ",";
				strLine += m_dPrice;
				strLine += ",";
				strLine += m_dTax;
				strLine += ",";
				strLine += m_dShipping;

				switch (m_eType)
					{
					case eGearTypes.Scope:
						strLine += (this as cScope).CSVLineExtension;
						break;
					}

				strLine += ",";
				strLine += m_strNotes;

				return (strLine);
				}
			}

		//============================================================================*
		// CSVLineExtension Property
		//============================================================================*

		public virtual string CSVLineExtension
			{
			get
				{
				return ("");
				}
			}

		//============================================================================*
		// CSVGearLineHeader Property
		//============================================================================*

		public virtual string CSVGearLineHeader
			{
			get
				{
				string strLine = "Gear Type,Manufacturer,Part Number,Serial Number,Description,Acquired From,Purchase Date,Purchase Price,Tax,Shipping";

				switch (m_eType)
					{
					case eGearTypes.Scope:
						strLine += (this as cScope).CSVLineHeaderExtension;
						break;
					}

				strLine += ",Notes";

				return (strLine);
				}
			}

		//============================================================================*
		// Description Property
		//============================================================================*

		public string Description
			{
			get
				{
				return (m_strDescription);
				}
			set
				{
				m_strDescription = value;
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public virtual void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement(cGear.GearTypeString(m_eType));
			XMLParentElement.AppendChild(XMLThisElement);

			//----------------------------------------------------------------------------*
			// Manufacturer
			//----------------------------------------------------------------------------*

			XmlElement XMLElement = XMLDocument.CreateElement("Manufacturer");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(Manufacturer.Name);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			//----------------------------------------------------------------------------*
			// Part Number
			//----------------------------------------------------------------------------*

			XMLElement = XMLDocument.CreateElement("PartNumber");
			XMLTextElement = XMLDocument.CreateTextNode(m_strPartNumber);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			//----------------------------------------------------------------------------*
			// Serial Number
			//----------------------------------------------------------------------------*

			XMLElement = XMLDocument.CreateElement("SerialNumber");
			XMLTextElement = XMLDocument.CreateTextNode(m_strSerialNumber);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			//----------------------------------------------------------------------------*
			// Description
			//----------------------------------------------------------------------------*

			XMLElement = XMLDocument.CreateElement("Description");
			XMLTextElement = XMLDocument.CreateTextNode(m_strDescription);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			//----------------------------------------------------------------------------*
			// Source
			//----------------------------------------------------------------------------*

			XMLElement = XMLDocument.CreateElement("AcquiredFrom");
			XMLTextElement = XMLDocument.CreateTextNode(m_strSource);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			//----------------------------------------------------------------------------*
			// Purchase Date
			//----------------------------------------------------------------------------*

			XMLElement = XMLDocument.CreateElement("PurchaseDate");
			XMLTextElement = XMLDocument.CreateTextNode(m_Date.ToShortDateString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			//----------------------------------------------------------------------------*
			// Purchase Price
			//----------------------------------------------------------------------------*

			XMLElement = XMLDocument.CreateElement("PurchasePrice");
			XMLTextElement = XMLDocument.CreateTextNode(m_dPrice.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			//----------------------------------------------------------------------------*
			//  Export Details if needed
			//----------------------------------------------------------------------------*

			ExportDetails(XMLDocument, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Notes
			//----------------------------------------------------------------------------*

			XMLElement = XMLDocument.CreateElement("Notes");
			XMLTextElement = XMLDocument.CreateTextNode(m_strNotes);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);
			}

		//============================================================================*
		// ExportDetails() - XML Document
		//============================================================================*

		public virtual void ExportDetails(XmlDocument XMLDocument, XmlElement XMLThisElement)
			{
			}

		//============================================================================*
		// GearType Property
		//============================================================================*

		public eGearTypes GearType
			{
			get
				{
				return (m_eType);
				}
			set
				{
				m_eType = value;
				}
			}

		//============================================================================*
		// GearType() - From String
		//============================================================================*

		public static eGearTypes GearTypeFromString(string strType)
			{
			switch (strType)
				{
				case "Firearm":
					return (cGear.eGearTypes.Firearm);
				case "Scope":
					return (cGear.eGearTypes.Scope);
				case "Laser":
					return (cGear.eGearTypes.Laser);
				case "Red Dot":
					return (cGear.eGearTypes.RedDot);
				case "Magnifier":
					return (cGear.eGearTypes.Magnifier);
				case "Light":
					return (cGear.eGearTypes.Light);
				case "Trigger":
					return (cGear.eGearTypes.Trigger);
				case "Furniture":
					return (cGear.eGearTypes.Furniture);
				case "Bipod/Monopod":
					return (cGear.eGearTypes.Bipod);
				case "Firearm Parts":
					return (cGear.eGearTypes.Parts);
				}

			return (eGearTypes.Misc);
			}

		//============================================================================*
		// GearTypeString() - cGear
		//============================================================================*

		public static string GearTypeString(cGear Gear)
			{
			return (GearTypeString(Gear.GearType));
			}

		//============================================================================*
		// GearTypeString() - eGearType
		//============================================================================*

		public static string GearTypeString(eGearTypes eGearType)
			{
			switch (eGearType)
				{
				case cGear.eGearTypes.Firearm:
					return("Firearm");

				case cGear.eGearTypes.Scope:
					return ("Scope");

				case cGear.eGearTypes.Laser:
					return ("Laser");

				case cGear.eGearTypes.RedDot:
					return ("Red Dot");

				case cGear.eGearTypes.Magnifier:
					return ("Magnifier");

				case cGear.eGearTypes.Light:
					return("Light");

				case cGear.eGearTypes.Trigger:
					return ("Trigger");

				case cGear.eGearTypes.Furniture:
					return ("Furniture");

				case cGear.eGearTypes.Bipod:
					return("Bipod/Monopod");

				case cGear.eGearTypes.Parts:
					return ("Firearm Parts");
				}

			return ("Other");
			}

		//============================================================================*
		// Manufacturer Property
		//============================================================================*

		public cManufacturer Manufacturer
			{
			get
				{
				return (m_Manufacturer);
				}
			set
				{
				m_Manufacturer = value;
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
		// Parent Property
		//============================================================================*

		public cGear Parent
			{
			get
				{
				return (m_Parent);
				}
			set
				{
				m_Parent = value;
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
		// PurchaseDate Property
		//============================================================================*

		public DateTime PurchaseDate
			{
			get
				{
				return (m_Date);
				}
			set
				{
				m_Date = value;
				}
			}

		//============================================================================*
		// PurchasePrice Property
		//============================================================================*

		public double PurchasePrice
			{
			get
				{
				return (m_dPrice);
				}
			set
				{
				m_dPrice = value;
				}
			}

		//============================================================================*
		// SerialNumber Property
		//============================================================================*

		public string SerialNumber
			{
			get
				{
				return (m_strSerialNumber);
				}
			set
				{
				m_strSerialNumber = value;
				}
			}

		//============================================================================*
		// SetDefaultDescription()
		//============================================================================*

		public virtual void SetDefaultDescription()
			{
			m_strDescription = cGear.GearTypeString(m_eType);
			}

		//============================================================================*
		// Shipping Property
		//============================================================================*

		public double Shipping
			{
			get
				{
				return (m_dShipping);
				}
			set
				{
				m_dShipping = value;
				}
			}

		//============================================================================*
		// SortByType Property
		//============================================================================*

		public static bool SortByType
			{
			get
				{
				return (sm_fSortByType);
				}
			set
				{
				sm_fSortByType = value;
				}
			}

		//============================================================================*
		// Source Property
		//============================================================================*

		public string Source
			{
			get
				{
				return (m_strSource);
				}
			set
				{
				m_strSource = value;
				}
			}

		//============================================================================*
		// Synch() - Firearm
		//============================================================================*

		public virtual bool Firearm(cFirearm Firearm)
			{
			if (Firearm == null || Parent == null)
				return (false);

			if (CompareTo(Firearm) == 0)
				{
				m_Parent = Firearm;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// Synch() - Gear
		//============================================================================*

		public virtual bool Synch(cGear Gear)
			{
			if (Gear == null || Parent == null)
				return (false);

			if (CompareTo(Gear) == 0)
				{
				m_Parent = Gear;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// Synch() - Manufacturer
		//============================================================================*

		public virtual bool Synch(cManufacturer Manufacturer)
			{
			if (Manufacturer == null)
				return (false);

			if (m_Manufacturer.CompareTo(Manufacturer) == 0)
				{
				m_Manufacturer = Manufacturer;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// Tax Property
		//============================================================================*

		public double Tax
			{
			get
				{
				return (m_dTax);
				}
			set
				{
				m_dTax = value;
				}
			}
		}
	}
