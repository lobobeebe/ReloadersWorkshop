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
using System.Xml;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cPowder class
	//============================================================================*

	[Serializable]
	public partial class cPowder : cSupply
		{
		//----------------------------------------------------------------------------*
		// Public Enumerations
		//----------------------------------------------------------------------------*

		public enum ePowderShapes
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
		private ePowderShapes m_eShape = ePowderShapes.Other;

		//============================================================================*
		// cPowder() - Constructor
		//============================================================================*

		public cPowder(bool fIdentity = false)
			: base(cSupply.eSupplyTypes.Powder, fIdentity)
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
					return (1);
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
			// Type
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
			m_eShape = Powder.m_eShape;
			}

		//============================================================================*
		// Model Property
		//============================================================================*

		public string Model
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
		// ResolveIdentities()
		//============================================================================*

		public override bool ResolveIdentities(cDataFiles DataFiles)
			{
			return (base.ResolveIdentities(DataFiles));
			}

		//============================================================================*
		// Shape Property
		//============================================================================*

		public ePowderShapes Shape
			{
			get
				{
				return (m_eShape);
				}
			set
				{
				m_eShape = value;
				}
			}


		//============================================================================*
		// ShapeFromString()
		//============================================================================*

		public static ePowderShapes ShapeFromString(string strString)
			{
			switch (strString)
				{
				case "Spherical":
					return (ePowderShapes.Spherical);

				case "Extruded":
					return (ePowderShapes.Extruded);

				case "Flake":
					return (ePowderShapes.Flake);
				}

			return (ePowderShapes.Other);
			}

		//============================================================================*
		// ShapeString Property
		//============================================================================*

		public static string ShapeString(cPowder.ePowderShapes eShape)
			{
			switch (eShape)
				{
				case ePowderShapes.Spherical:
					return ("Spherical");

				case ePowderShapes.Extruded:
					return ("Extruded");

				case ePowderShapes.Flake:
					return ("Flake");
				}

			return ("Other");
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

		public override bool Validate(bool fIdentityOK = false)
			{
			if (!base.Validate(fIdentityOK))
				return (false);

			if (String.IsNullOrEmpty(m_strType))
				return (false);

			return (true);
			}
		}
	}
