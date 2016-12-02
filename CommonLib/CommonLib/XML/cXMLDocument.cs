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

		public XmlElement CreateElement(string strName, string strData, XmlElement XMLParentElement)
			{
			if (String.IsNullOrEmpty(strName) || String.IsNullOrEmpty(strData))
				return (null);

			XmlElement XMLElement = CreateElement(strName);
			XmlText XMLTextNode = CreateTextNode(strData);
			XMLElement.AppendChild(XMLTextNode);

			XMLParentElement.AppendChild(XMLElement);

			return (XMLElement);
			}

		//============================================================================*
		// CreateElement() - bool
		//============================================================================*

		public XmlElement CreateElement(string strName, bool fData, XmlElement XMLParentElement)
			{
			return (CreateElement(strName, fData ? "Yes" : "-", XMLParentElement));
			}

		//============================================================================*
		// CreateElement() - DateTime
		//============================================================================*

		public XmlElement CreateElement(string strName, DateTime Date, XmlElement XMLParentElement)
			{
			return (CreateElement(strName, Date.ToShortDateString(), XMLParentElement));
			}

		//============================================================================*
		// CreateElement() - int
		//============================================================================*

		public XmlElement CreateElement(string strName, int nData, XmlElement XMLParentElement)
			{
			return (CreateElement(strName, nData.ToString(), XMLParentElement));
			}

		//============================================================================*
		// CreateElement() - double
		//============================================================================*

		public XmlElement CreateElement(string strName, double dData, XmlElement XMLParentElement)
			{
			return (CreateElement(strName, dData.ToString(), XMLParentElement));
			}

		//============================================================================*
		// CreateElement() - float
		//============================================================================*

		public XmlElement CreateElement(string strName, float flData, XmlElement XMLParentElement)
			{
			return (CreateElement(strName, flData.ToString(), XMLParentElement));
			}

		//============================================================================*
		// CreateElement() - SortOrder
		//============================================================================*

		public XmlElement CreateElement(string strName, SortOrder Order, XmlElement XMLParentElement)
			{
			return (CreateElement(strName, Order.ToString(), XMLParentElement));
			}

		}
	}
