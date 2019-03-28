//============================================================================*
// cTool.cs
//
// Copyright © 2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cTool class
	//============================================================================*

	[Serializable]
	public partial class cTool : cPrintObject, IComparable
		{
		//============================================================================*
		// Private Constants
		//============================================================================*

		private const string cm_strPress = "Press";
		private const string cm_strPressAccessory = "Press Accessory";
		private const string cm_strDie = "Die";
		private const string cm_strDieAccessory = "Die Accessory";
		private const string cm_strPowderTool= "Powder Tool";
		private const string cm_strCasePrepTool = "Case Prep Tool";
		private const string cm_strMeasurementTool = "Measurement Tool";
		private const string cm_strBulletCasting = "Bullet Casting";
		private const string cm_strGunsmithing = "Gunsmithing";
		private const string cm_strBook = "Book";
		private const string cm_strMisc = "Other";

		//============================================================================*
		// Public Enumerations
		//============================================================================*

		public enum eToolTypes
			{
			Press = 0,
			PressAccessory,
			Die,
			DieAccessory,
			PowderTool,
			CasePrepTool,
			MeasurementTool,
			BulletCasting,
			Gunsmithing,
			Book,
			Other,
			NumToolTypes
			};

		//============================================================================*
		// Private Static Data Members
		//============================================================================*

		private static bool sm_fSortByType = true;

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private eToolTypes m_eType = eToolTypes.Other;

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

		//============================================================================*
		// cTool() - Constructor
		//============================================================================*

		public cTool(eToolTypes eType)
			{
			m_eType = eType;
			}

		//============================================================================*
		// cTool() - Copy Constructor
		//============================================================================*

		public cTool(cTool Gear)
			{
			Copy(Gear);
			}

		//============================================================================*
		// Append()
		//============================================================================*

		public int Append(cTool Tool, bool fCountOnly = false)
			{
			int nUpdateCount = 0;

			if (String.IsNullOrEmpty(m_strDescription) && !String.IsNullOrEmpty(Tool.m_strDescription))
				{
				if (!fCountOnly)
					m_strDescription = Tool.m_strDescription;

				nUpdateCount++;
				}

			if (String.IsNullOrEmpty(m_strSerialNumber) && !String.IsNullOrEmpty(Tool.m_strSerialNumber))
				{
				if (!fCountOnly)
					m_strSerialNumber = Tool.m_strSerialNumber;

				nUpdateCount++;
				}

			if (String.IsNullOrEmpty(m_strNotes) && !String.IsNullOrEmpty(Tool.m_strNotes))
				{
				if (!fCountOnly)
					m_strNotes = Tool.m_strNotes;

				nUpdateCount++;
				}

			if (String.IsNullOrEmpty(m_strSource) && !String.IsNullOrEmpty(Tool.m_strSource))
				{
				if (!fCountOnly)
					m_strSource = Tool.m_strSource;

				nUpdateCount++;
				}

			if (m_dPrice == 0.0 && Tool.m_dPrice != 0.0)
				{
				if (!fCountOnly)
					m_dPrice = Tool.m_dPrice;

				nUpdateCount++;
				}

			if (m_dTax == 0.0 && Tool.m_dTax != 0.0)
				{
				if (!fCountOnly)
					m_dTax = Tool.m_dTax;

				nUpdateCount++;
				}

			if (m_dShipping == 0.0 && Tool.m_dShipping != 0.0)
				{
				if (!fCountOnly)
					m_dShipping = Tool.m_dShipping;

				nUpdateCount++;
				}

			return (nUpdateCount);
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cTool Tool1, cTool Tool2)
			{
			if (Tool1 == null)
				{
				if (Tool2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Tool2 == null)
					return (1);
				}

			return (Tool1.CompareTo(Tool2));
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
			// Tool Type
			//----------------------------------------------------------------------------*

			cTool Tool = (cTool)obj;

			if (sm_fSortByType)
				rc = m_eType.CompareTo(Tool.m_eType);

			//----------------------------------------------------------------------------*
			// Manufacturer
			//----------------------------------------------------------------------------*

			if (rc == 0)
				{
				if (m_Manufacturer != null)
					{
					rc = m_Manufacturer.CompareTo(Tool.m_Manufacturer);
					}
				else
					{
					if (Tool.m_Manufacturer != null)
						rc = -1;
					else
						rc = 0;
					}

				//----------------------------------------------------------------------------*
				// Part Number
				//----------------------------------------------------------------------------*

				if (rc == 0)
					{
					rc = cDataFiles.ComparePartNumbers(m_strPartNumber, Tool.PartNumber);

					//----------------------------------------------------------------------------*
					// Serial Number
					//----------------------------------------------------------------------------*

					if (rc == 0)
						{
						rc = cDataFiles.ComparePartNumbers(m_strSerialNumber, Tool.SerialNumber);
						}
					}
				}

			return (rc);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public virtual void Copy(cTool Tool)
			{
			m_eType = Tool.m_eType;
			m_Manufacturer = Tool.m_Manufacturer;

			m_strPartNumber = Tool.m_strPartNumber;
			m_strSerialNumber = Tool.m_strSerialNumber;
			m_strDescription = Tool.m_strDescription;
			m_strNotes = Tool.m_strNotes;
			m_strSource = Tool.m_strSource;
			m_Date = Tool.PurchaseDate;
			m_dPrice = Tool.m_dPrice;
			m_dTax = Tool.m_dTax;
			m_dShipping = Tool.m_dShipping;
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
		// ToolType Property
		//============================================================================*

		public eToolTypes ToolType
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
		// ToolType() - From String
		//============================================================================*

		public static eToolTypes ToolTypeFromString(string strType)
			{
			switch (strType)
				{
				case cm_strPress:
					return (cTool.eToolTypes.Press);
				case cm_strPressAccessory:
					return (cTool.eToolTypes.PressAccessory);
				case cm_strDie:
					return (cTool.eToolTypes.Die);
				case cm_strDieAccessory:
					return (cTool.eToolTypes.DieAccessory);
				case cm_strPowderTool:
					return (cTool.eToolTypes.PowderTool);
				case cm_strCasePrepTool:
					return (cTool.eToolTypes.CasePrepTool);
				case cm_strMeasurementTool:
					return (cTool.eToolTypes.MeasurementTool);
				case cm_strBulletCasting:
					return (cTool.eToolTypes.BulletCasting);
				case cm_strGunsmithing:
					return (cTool.eToolTypes.Gunsmithing);
				case cm_strBook:
					return (cTool.eToolTypes.Book);
				}

			return (eToolTypes.Other);
			}

		//============================================================================*
		// ToolTypeString() - cTool
		//============================================================================*

		public static string ToolTypeString(cTool Tool)
			{
			return (ToolTypeString(Tool.ToolType));
			}

		//============================================================================*
		// ToolTypeString() - eGearType
		//============================================================================*

		public static string ToolTypeString(eToolTypes eToolType)
			{
			switch (eToolType)
				{
				case cTool.eToolTypes.Press:
					return (cm_strPress);

				case cTool.eToolTypes.PressAccessory:
					return (cm_strPressAccessory);

				case cTool.eToolTypes.Die:
					return (cm_strDie);

				case cTool.eToolTypes.DieAccessory:
					return (cm_strDieAccessory);

				case cTool.eToolTypes.PowderTool:
					return (cm_strPowderTool);

				case cTool.eToolTypes.CasePrepTool:
					return (cm_strCasePrepTool);

				case cTool.eToolTypes.MeasurementTool:
					return (cm_strMeasurementTool);

				case cTool.eToolTypes.BulletCasting:
					return (cm_strBulletCasting);

				case cTool.eToolTypes.Gunsmithing:
					return (cm_strGunsmithing);

				case cTool.eToolTypes.Book:
					return (cm_strBook);
				}

			return (cm_strMisc);
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
		// ResolveIdentities()
		//============================================================================*

		public virtual bool ResolveIdentities(cDataFiles Datafiles)
			{
			return (false);
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

		//============================================================================*
		// Validate()
		//============================================================================*

		public virtual bool Validate(bool fIdentityOK = false)
			{
			if (Manufacturer == null)
				return (false);

			if (String.IsNullOrEmpty(m_strPartNumber))
				return (false);

			if (String.IsNullOrEmpty(m_strDescription))
				return (false);

			return (true);
			}
		}
	}
