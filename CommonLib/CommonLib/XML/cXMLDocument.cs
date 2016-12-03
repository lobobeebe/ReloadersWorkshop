//============================================================================*
// cXMLDocument.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Windows.Forms;
using System.Xml;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cXMLDocument Class
	//============================================================================*

	public class cXMLDocument : XmlDocument
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		XmlDocument m_XMLDocument = new XmlDocument();

		//============================================================================*
		// cXMLDocument() - Constructor
		//============================================================================*

		public cXMLDocument()
			{
			}


		//============================================================================*
		// CreateDeclaration()
		//============================================================================*

		protected void CreateXMLDeclaration()
			{
			XmlDeclaration xmlDeclaration = CreateXmlDeclaration("1.0", "UTF-8", null);
			XmlElement RootElement = DocumentElement;

			InsertBefore(xmlDeclaration, RootElement);
			}

		//============================================================================*
		// CreateElement() - String - All other CreateElement() overloads lead here
		//============================================================================*

		public XmlElement CreateElement(string strName, string strData, XmlNode XMLParentMode)
			{
			if (String.IsNullOrEmpty(strName) || String.IsNullOrEmpty(strData))
				return (null);

			XmlElement XMLElement = CreateElement(strName);
			XmlText XMLTextNode = CreateTextNode(strData);
			XMLElement.AppendChild(XMLTextNode);

			XMLParentMode.AppendChild(XMLElement);

			return (XMLElement);
			}

		//============================================================================*
		// CreateElement() - bool
		//============================================================================*

		public XmlElement CreateElement(string strName, bool fData, XmlNode XMLParentNode)
			{
			return (CreateElement(strName, fData ? "Yes" : "-", XMLParentNode));
			}

		//============================================================================*
		// CreateElement() - DateTime
		//============================================================================*

		public XmlElement CreateElement(string strName, DateTime Date, XmlNode XMLParentNode)
			{
			return (CreateElement(strName, Date.ToShortDateString(), XMLParentNode));
			}

		//============================================================================*
		// CreateElement() - int
		//============================================================================*

		public XmlElement CreateElement(string strName, int nData, XmlNode XMLParentNode)
			{
			return (CreateElement(strName, nData.ToString(), XMLParentNode));
			}

		//============================================================================*
		// CreateElement() - double
		//============================================================================*

		public XmlElement CreateElement(string strName, double dData, XmlNode XMLParentNode)
			{
			return (CreateElement(strName, dData.ToString(), XMLParentNode));
			}

		//============================================================================*
		// CreateElement() - float
		//============================================================================*

		public XmlElement CreateElement(string strName, float flData, XmlNode XMLParentNode)
			{
			return (CreateElement(strName, flData.ToString(), XMLParentNode));
			}

		//============================================================================*
		// CreateElement() - SortOrder
		//============================================================================*

		public XmlElement CreateElement(string strName, SortOrder Order, XmlNode XMLParentNode)
			{
			return (CreateElement(strName, Order.ToString(), XMLParentNode));
			}

		}
	}
