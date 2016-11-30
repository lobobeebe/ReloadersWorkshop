//============================================================================*
// cScope.cs
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
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cScope Class
	//============================================================================*

	[Serializable]
	public class cScope : cGear
		{
		//============================================================================*
		// Public Enumerations
		//============================================================================*

		public enum eTurretTypes
			{
			MOA = 0,
			Mils
			}

		public enum eTurretTubeSizes
			{
			Small = 0,
			Large
			}

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private string m_strPower = "";
		private string m_strObjective = "";

		private eTurretTubeSizes m_eTubeSize = eTurretTubeSizes.Small;
		private eTurretTypes m_eTurretType = eTurretTypes.MOA;

		private double m_dTurretClick = 0.0;

		//============================================================================*
		// cScope() - Constructor
		//============================================================================*

		public cScope()
			: base(cGear.eGearTypes.Scope)
			{
			}

		//============================================================================*
		// cScope() - Copy Constructor
		//============================================================================*

		public cScope(cScope Scope)
			: base(Scope)
			{
			Copy(Scope);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public override void Copy(cGear Gear)
			{
			if (Gear.GearType != eGearTypes.Scope)
				return;

			base.Copy(Gear);

			cScope Scope = (cScope) Gear;

			m_strPower = Scope.m_strPower;
			m_strObjective = Scope.m_strObjective;

			m_eTubeSize = Scope.m_eTubeSize;
			m_eTurretType = Scope.m_eTurretType;

			m_dTurretClick = Scope.m_dTurretClick;
			}

		//============================================================================*
		// CSVHeaderExtension Property
		//============================================================================*

		public override string CSVLineHeaderExtension
			{
			get
				{
				return (",Power,Objective,Tube Size,Turret Click,Turret Type");
				}
			}

		//============================================================================*
		// CSVLineExtension Property
		//============================================================================*

		public override string CSVLineExtension
			{
			get
				{
				string strLine = ",";
				strLine += (this as cScope).Power;
				strLine += ",";
				strLine += (this as cScope).Objective;
				strLine += ",";
				strLine += cScope.TubeSizeString((this as cScope).TubeSize);
				strLine += ",";
				strLine += (this as cScope).TurretClick;
				strLine += ",";
				strLine += cScope.TurretTypeString((this as cScope).TurretType);

				return (strLine);
				}
			}

		//============================================================================*
		// ExportDetails() - XML Document
		//============================================================================*

		public override void ExportDetails(XmlDocument XMLDocument, XmlNode XMLThisElement)
			{
			//----------------------------------------------------------------------------*
			// Power
			//----------------------------------------------------------------------------*

			XmlElement XMLElement = XMLDocument.CreateElement("Power");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(m_strPower);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			//----------------------------------------------------------------------------*
			// Objective
			//----------------------------------------------------------------------------*

			XMLElement = XMLDocument.CreateElement("Objective");
			XMLTextElement = XMLDocument.CreateTextNode(m_strObjective);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			//----------------------------------------------------------------------------*
			// Tube Size
			//----------------------------------------------------------------------------*

			XMLElement = XMLDocument.CreateElement("TubeSize");
			XMLTextElement = XMLDocument.CreateTextNode(cScope.TubeSizeString(m_eTubeSize));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			//----------------------------------------------------------------------------*
			// Turret Click
			//----------------------------------------------------------------------------*

			XMLElement = XMLDocument.CreateElement("TurretClick");
			XMLTextElement = XMLDocument.CreateTextNode(m_dTurretClick.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			//----------------------------------------------------------------------------*
			// Turret Type
			//----------------------------------------------------------------------------*

			XMLElement = XMLDocument.CreateElement("TurretType");
			XMLTextElement = XMLDocument.CreateTextNode(cScope.TurretTypeString(m_eTurretType));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);
			}

		//============================================================================*
		// Objective Property
		//============================================================================*

		public string Objective
			{
			get
				{
				return (m_strObjective);
				}

			set
				{
				m_strObjective = value;
				}
			}

		//============================================================================*
		// Power Property
		//============================================================================*

		public string Power
			{
			get
				{
				return (m_strPower);
				}

			set
				{
				m_strPower = value;
				}
			}

		//============================================================================*
		// ToString()
		//============================================================================*

		public override string ToString()
			{
			string strString = String.Format("{0} {1} {2}x{3}mm Scope", Manufacturer.Name, PartNumber, m_strPower, m_strObjective);

			if (!String.IsNullOrEmpty(SerialNumber))
				strString += String.Format(" {0}", SerialNumber);

			return (strString);
			}

		//============================================================================*
		// TubeSize Property
		//============================================================================*

		public eTurretTubeSizes TubeSize
			{
			get
				{
				return (m_eTubeSize);
				}

			set
				{
				m_eTubeSize = value;
				}
			}

		//============================================================================*
		// TubeSizeString()
		//============================================================================*

		public static string TubeSizeString(eTurretTubeSizes eTubeSize)
			{
			switch (eTubeSize)
				{
				case eTurretTubeSizes.Small:
					return ("1 in");
				case eTurretTubeSizes.Large:
					return ("30 mm");
				}

			return ("");
			}

		//============================================================================*
		// TurretClick Property
		//============================================================================*

		public double TurretClick
			{
			get
				{
				return (m_dTurretClick);
				}

			set
				{
				m_dTurretClick = value;
				}
			}

		//============================================================================*
		// TurretType Property
		//============================================================================*

		public eTurretTypes TurretType
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
		// TurretTypeString()
		//============================================================================*

		public static string TurretTypeString(eTurretTypes eTurretType)
			{
			switch (eTurretType)
				{
				case eTurretTypes.MOA:
					return ("MOA");
				case eTurretTypes.Mils:
					return ("Mils");
				}

			return ("");
			}
		}
	}
