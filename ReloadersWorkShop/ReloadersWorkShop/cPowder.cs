//============================================================================*
// cPowder.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
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
	// cPowder class
	//============================================================================*

	[Serializable]
	public class cPowder : cSupply
		{
		//----------------------------------------------------------------------------*
		// Public Enumerations
		//----------------------------------------------------------------------------*

		public enum ePowderType
			{
			Spherical = 0,
			Extruded,
			Flake,
			Other
			}

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private string m_strType = "";
		private ePowderType m_ePowderType = ePowderType.Other;

		//============================================================================*
		// cPowder() - Constructor
		//============================================================================*

		public cPowder()
			: base(cSupply.eSupplyTypes.Powder)
			{
			}

		//============================================================================*
		// cPowder() - Copy Constructor
		//============================================================================*

		public cPowder(cPowder Powder)
			: base(Powder)
			{
			Copy(Powder, false);
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cPowder Powder1, cPowder Powder2)
			{
			if (Powder1 == null)
				{
				if (Powder2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Powder2 == null)
					return(1);
				}

			return (Powder1.CompareTo(Powder2));
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
				cPowder Powder = (cPowder) Supply;

				rc = cDataFiles.ComparePartNumbers(m_strType, Powder.m_strType);
				}

			return (rc);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public void Copy(cPowder Powder, bool fCopyBase = true)
			{
			if (fCopyBase)
				base.Copy(Powder);

			m_strType = Powder.m_strType;
			m_ePowderType = Powder.m_ePowderType;
			}

		//============================================================================*
		// CSVHeader Property
		//============================================================================*

		public static string CSVHeader
			{
			get
				{
				return ("Powders");
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

				strLine += cFirearm.FirearmTypeString(FirearmType);
				strLine += ",";
				strLine += CrossUse ? "Yes," : "-,";

				strLine += Manufacturer.Name;
				strLine += ",";

				strLine += m_strType;
				strLine += ",";
				strLine += TypeString;

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
				return ("Firearm Type,Cross Use?,Manufacturer,Type,Shape");
				}
			}

		//============================================================================*
		// Model Property
		//============================================================================*

		public string Model
			{
			get { return (m_strType); }
			set { m_strType = value; }
			}

		//============================================================================*
		// PowderType Property
		//============================================================================*

		public ePowderType PowderType
			{
			get { return (m_ePowderType); }
			set { m_ePowderType = value; }
			}

		//============================================================================*
		// ToString
		//============================================================================*

		public override string ToString()
			{
			string strString = "";
			
			if (Manufacturer != null && m_strType != null)
				strString = String.Format("{0} {1}", Manufacturer.Name, m_strType);

			strString = ToCrossUseString(strString);

			return (strString);
			}

		//============================================================================*
		// Type Property
		//============================================================================*

		public string Type
			{
			get { return(m_strType); }
			set { m_strType = value; }
			}

		//============================================================================*
		// TypeString Property
		//============================================================================*

		public string TypeString
			{
			get
				{
				switch(m_ePowderType)
					{
					case ePowderType.Spherical:
						return("Spherical");

					case ePowderType.Extruded:
						return ("Extruded");

					case ePowderType.Flake:
						return ("Flake");
					}

				return ("Other");
				}	
			}

		//============================================================================*
		// XMLHeader Property
		//============================================================================*

		public static string XMLHeader
			{
			get
				{
				return ("Powders");
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
