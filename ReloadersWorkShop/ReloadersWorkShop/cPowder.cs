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
	public class cPowder : cSupply
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
		private ePowderShapes m_ePowderType = ePowderShapes.Other;

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
			m_ePowderType = Powder.m_ePowderType;
			}

		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public override string CSVLine
			{
			get
				{
				string strLine = base.CSVLine;

				strLine += m_strType;
				strLine += ",";
				strLine += ShapeString;

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

				strLine += "Type,Shape";

				return (strLine);
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public override void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement("Powder");
			XMLParentElement.AppendChild(XMLThisElement);

			base.Export(XMLDocument, XMLThisElement);

			// Type

			XmlElement XMLElement = XMLDocument.CreateElement("Type");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(m_strType);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Shape

			XMLElement = XMLDocument.CreateElement("Shape");
			XMLTextElement = XMLDocument.CreateTextNode(ShapeString);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);
			}

		//============================================================================*
		// ExportIdentity() - XML Document
		//============================================================================*

		public override void ExportIdentity(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			base.Export(XMLDocument, XMLParentElement);

			// Type

			XmlElement XMLElement = XMLDocument.CreateElement("Type");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(m_strType);
			XMLElement.AppendChild(XMLTextElement);

			XMLParentElement.AppendChild(XMLElement);
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public string ExportName
			{
			get
				{
				return ("Powder");
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
		// Shape Property
		//============================================================================*

		public ePowderShapes Shape
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
		// ShapeString Property
		//============================================================================*

		public string ShapeString
			{
			get
				{
				switch(m_ePowderType)
					{
					case ePowderShapes.Spherical:
						return("Spherical");

					case ePowderShapes.Extruded:
						return ("Extruded");

					case ePowderShapes.Flake:
						return ("Flake");
					}

				return ("Other");
				}	
			}
		}
	}
