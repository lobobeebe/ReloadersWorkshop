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
using System.Drawing;
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
		// CreateElement() - Parent Element
		//============================================================================*

		public XmlElement CreateElement(string strName, XmlNode XMLParentNode)
			{
			XmlElement XMLElement = CreateElement(strName);
			XMLParentNode.AppendChild(XMLElement);

			return (XMLElement);
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
		// CreateElement() - Color
		//============================================================================*

		public XmlElement CreateElement(string strName, Color ElementColor, XmlNode XMLParentNode)
			{
			XmlElement XMLThisElement = CreateElement(strName, XMLParentNode);

			CreateElement("A", ElementColor.A, XMLThisElement);
			CreateElement("R", ElementColor.R, XMLThisElement);
			CreateElement("G", ElementColor.G, XMLThisElement);
			CreateElement("B", ElementColor.B, XMLThisElement);

			return (XMLThisElement);
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
		// CreateElement() - Point
		//============================================================================*

		public XmlElement CreateElement(string strName, Point ElementPoint, XmlNode XMLParentNode)
			{
			XmlElement XMLThisElement = CreateElement(strName, XMLParentNode);

			CreateElement("X", ElementPoint.X, XMLThisElement);
			CreateElement("Y", ElementPoint.Y, XMLThisElement);

			return (XMLThisElement);
			}

		//============================================================================*
		// CreateElement() - Size
		//============================================================================*

		public XmlElement CreateElement(string strName, Size ElementSize, XmlNode XMLParentNode)
			{
			XmlElement XMLThisElement = CreateElement(strName, XMLParentNode);

			CreateElement("Width", ElementSize.Width, XMLThisElement);
			CreateElement("Height", ElementSize.Height, XMLThisElement);

			return (XMLThisElement);
			}

		//============================================================================*
		// CreateElement() - SortOrder
		//============================================================================*

		public XmlElement CreateElement(string strName, SortOrder Order, XmlNode XMLParentNode)
			{
			return (CreateElement(strName, Order.ToString(), XMLParentNode));
			}

		//============================================================================*
		// Import() - bool
		//============================================================================*

		public void Import(XmlNode XMLThisNode, out bool fBool)
			{
			if (XMLThisNode != null && XMLThisNode.FirstChild != null && XMLThisNode.FirstChild.Value != null)
				fBool = XMLThisNode.FirstChild.Value == "Yes";
			else
				fBool = false;
			}

		//============================================================================*
		// Import() - Color
		//============================================================================*

		public void Import(XmlNode XMLThisNode, out Color ElementColor)
			{
			int nA = 255;
			int nR = 0;
			int nG = 0;
			int nB = 0;

			if (XMLThisNode != null && XMLThisNode.FirstChild != null)
				{
				XmlNode XMLNode = XMLThisNode.FirstChild;

				while (XMLNode != null)
					{
					switch (XMLNode.Name)
						{
						case "A":
							Int32.TryParse(XMLNode.FirstChild.Value, out nA);
							break;
						case "R":
							Int32.TryParse(XMLNode.FirstChild.Value, out nR);
							break;
						case "G":
							Int32.TryParse(XMLNode.FirstChild.Value, out nG);
							break;
						case "B":
							Int32.TryParse(XMLNode.FirstChild.Value, out nB);
							break;
						}

					XMLNode = XMLNode.NextSibling;
					}
				}

			ElementColor = Color.FromArgb(nA, nR, nG, nB);
			}

		//============================================================================*
		// Import() - double
		//============================================================================*

		public void Import(XmlNode XMLThisNode, out double dDouble)
			{
			dDouble = 0.0;

			if (XMLThisNode != null && XMLThisNode.FirstChild != null && XMLThisNode.FirstChild.Value != null)
				Double.TryParse(XMLThisNode.FirstChild.Value, out dDouble);
			}

		//============================================================================*
		// Import() - float
		//============================================================================*

		public void Import(XmlNode XMLThisNode, out float flFloat)
			{
			flFloat = 0.0f;

			if (XMLThisNode != null && XMLThisNode.FirstChild != null && XMLThisNode.FirstChild.Value != null)
				float.TryParse(XMLThisNode.FirstChild.Value, out flFloat);
			}

		//============================================================================*
		// Import() - int
		//============================================================================*

		public void Import(XmlNode XMLThisNode, out int nInt)
			{
			nInt = 0;

			if (XMLThisNode != null && XMLThisNode.FirstChild != null && XMLThisNode.FirstChild.Value != null)
				Int32.TryParse(XMLThisNode.FirstChild.Value, out nInt);
			}

		//============================================================================*
		// Import() - Point
		//============================================================================*

		public void Import(XmlNode XMLThisNode, out Point ElementPoint)
			{
			int nX = 0;
			int nY = 0;

			if (XMLThisNode != null && XMLThisNode.FirstChild != null)
				{
				XmlNode XMLNode = XMLThisNode.FirstChild;

				while (XMLNode != null)
					{
					switch (XMLNode.Name)
						{
						case "X":
							Import(XMLNode, out nX);
							break;
						case "Y":
							Import(XMLNode, out nY);
							break;
						}

					XMLNode = XMLNode.NextSibling;
					}
				}

			ElementPoint = new Point(nX, nY);
			}

		//============================================================================*
		// Import() - Size
		//============================================================================*

		public void Import(XmlNode XMLThisNode, out Size ElementSize)
			{
			int nWidth = 0;
			int nHeight = 0;

			if (XMLThisNode != null && XMLThisNode.FirstChild != null)
				{
				XmlNode XMLNode = XMLThisNode.FirstChild;

				while (XMLNode != null)
					{
					switch (XMLNode.Name)
						{
						case "Width":
							Int32.TryParse(XMLNode.FirstChild.Value, out nWidth);
							break;
						case "Height":
							Int32.TryParse(XMLNode.FirstChild.Value, out nHeight);
							break;
						}

					XMLNode = XMLNode.NextSibling;
					}
				}

			ElementSize = new Size(nWidth, nHeight);
			}

		//============================================================================*
		// Import() - SortOrder
		//============================================================================*

		public void Import(XmlNode XMLThisNode, out SortOrder ElementSortOrder)
			{
			ElementSortOrder = SortOrder.Ascending;

			if (XMLThisNode != null && XMLThisNode.FirstChild != null && XMLThisNode.FirstChild.Value != null)
				SortOrder.TryParse(XMLThisNode.FirstChild.Value, out ElementSortOrder);
			}

		//============================================================================*
		// Import() - string
		//============================================================================*

		public void Import(XmlNode XMLThisNode, out string strString)
			{
			if (XMLThisNode != null && XMLThisNode.FirstChild != null && XMLThisNode.FirstChild.Value != null)
				strString = XMLThisNode.FirstChild.Value;
			else
				strString = "";
			}
		}
	}
