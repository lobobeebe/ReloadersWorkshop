//============================================================================*
// cFirearmBullet.cs
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
	// cFirearmBullet class
	//============================================================================*

	[Serializable]
	public class cFirearmBullet
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cCaliber m_Caliber = new cCaliber();

		private cBullet m_Bullet = null;

		private double m_dCOL = 0.0;
		private double m_dCBTO = 0.0;
		private double m_dJump = 0.0;

		//============================================================================*
		// cFirearmBullet() - Constructor
		//============================================================================*

		public cFirearmBullet()
			{
			}

		//============================================================================*
		// cFirearmBullet() - Copy Constructor
		//============================================================================*

		public cFirearmBullet(cFirearmBullet FirearmBullet)
			{
			Copy(FirearmBullet);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public void Copy(cFirearmBullet FirearmBullet)
			{
			m_Caliber = FirearmBullet.m_Caliber;

			m_Bullet = new cBullet(FirearmBullet.m_Bullet);
			m_dCOL = FirearmBullet.m_dCOL;
			m_dCBTO = FirearmBullet.m_dCBTO;
			m_dJump = FirearmBullet.m_dJump;
			}

		//============================================================================*
		// Bullet Property
		//============================================================================*

		public cBullet Bullet
			{
			get { return (m_Bullet); }
			set { m_Bullet = value; }
			}

		//============================================================================*
		// Caliber Property
		//============================================================================*

		public cCaliber Caliber
			{
			get { return (m_Caliber); }
			set {m_Caliber = value; }
			}

		//============================================================================*
		// COL Property
		//============================================================================*

		public double COL
			{
			get { return (m_dCOL); }
			set { m_dCOL = value; }
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cFirearmBullet FirearmBullet1, cFirearmBullet FirearmBullet2)
			{
			if (FirearmBullet1 == null)
				{
				if (FirearmBullet2 != null)
					return (-1);
				else
					return (0);
				}

			return (FirearmBullet1.CompareTo(FirearmBullet2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(cFirearmBullet FirearmBullet)
			{
			if (FirearmBullet == null)
				return (1);

			//----------------------------------------------------------------------------*
			// Compare Caliber
			//----------------------------------------------------------------------------*

			int rc = m_Caliber.CompareTo(FirearmBullet.m_Caliber);

			//----------------------------------------------------------------------------*
			// Compare Bullet
			//----------------------------------------------------------------------------*

			if (rc == 0)
				rc = m_Bullet.CompareTo(FirearmBullet.m_Bullet);

            return(rc);
			}

		//============================================================================*
		// CBTO Property
		//============================================================================*

		public double CBTO
			{
			get { return (m_dCBTO); }
			set { m_dCBTO = value; }
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement(ExportName);
			XMLParentElement.AppendChild(XMLThisElement);

			// Caliber

			m_Caliber.ExportIdentity(XMLDocument, XMLThisElement);

			// Bullet

			m_Bullet.ExportIdentity(XMLDocument, XMLThisElement);

			// COAL

			XmlElement XMLElement = XMLDocument.CreateElement("COAL");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(m_dCOL.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// CBTO

			XMLElement = XMLDocument.CreateElement("CBTO");
			XMLTextElement = XMLDocument.CreateTextNode(m_dCBTO.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Jump

			XMLElement = XMLDocument.CreateElement("Jump");
			XMLTextElement = XMLDocument.CreateTextNode(m_dJump.ToString());
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
				return ("FirearmBullet");
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public bool Import(XmlDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "CaliberIdentity":
						m_Caliber = cDataFiles.GetCaliberByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "BulletIdentity":
						m_Bullet = cDataFiles.GetBulletByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "COAL":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dCOL);
						break;
					case "CBTO":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dCBTO);
						break;
					case "Jump":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dJump);
						break;
					default:
						break;
					}

				XMLNode = XMLNode.NextSibling;
				}

			return (Validate());
			}

		//============================================================================*
		// Jump Property
		//============================================================================*

		public double Jump
			{
			get
				{
				return (m_dJump);
				}
			set
				{
				m_dJump = value;
				}
			}

		//============================================================================*
		// Synch() - Bullet
		//============================================================================*

		public bool Synch(cBullet Bullet)
			{
			if (m_Bullet != null && m_Bullet.CompareTo(Bullet) == 0)
				{
				m_Bullet = Bullet;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// ToString
		//============================================================================*

		public override string ToString()
			{
			string strString = String.Format("{0}", m_Bullet.ToWeightString());

			return (strString);
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public bool Validate()
			{
			bool fOK = m_Caliber != null && m_Bullet !=  null;

			if (fOK)
				fOK = m_dCBTO != 0.0 || m_dCOL != 0.0 || m_dJump != 0.0;

			return (fOK);
			}
		}
	}
