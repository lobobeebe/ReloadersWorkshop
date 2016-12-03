using System;
using System.Xml;

namespace ReloadersWorkShop
	{
	public partial class cBatch
		{
		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement(ExportName);
			XMLParentElement.AppendChild(XMLThisElement);

			// Batch ID

			XmlElement XMLElement = XMLDocument.CreateElement("BatchID");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_nBatchID));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// User Batch ID

			if (!String.IsNullOrEmpty(m_strUserID))
				{
				XMLElement = XMLDocument.CreateElement("UserBatchID");
				XMLTextElement = XMLDocument.CreateTextNode(m_strUserID);
				XMLElement.AppendChild(XMLTextElement);

				XMLThisElement.AppendChild(XMLElement);
				}

			// Date Loaded

			XMLElement = XMLDocument.CreateElement("DateLoaded");
			XMLTextElement = XMLDocument.CreateTextNode(m_DateLoaded.ToShortDateString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Load

			m_Load.ExportIdentity(XMLDocument, XMLThisElement);

			// Firearm

			if (m_Firearm != null)
				m_Firearm.Export(XMLDocument, XMLThisElement, true);

			// Powder Weight

			XMLElement = XMLDocument.CreateElement("PowderWeight");
			XMLTextElement = XMLDocument.CreateTextNode(m_dPowderWeight.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Num Rounds

			XMLElement = XMLDocument.CreateElement("NumRounds");
			XMLTextElement = XMLDocument.CreateTextNode(m_nNumRounds.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Cases Fired

			XMLElement = XMLDocument.CreateElement("CasesFired");
			XMLTextElement = XMLDocument.CreateTextNode(m_nTimesFired.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// COAL

			XMLElement = XMLDocument.CreateElement("COAL");
			XMLTextElement = XMLDocument.CreateTextNode(m_dCOL.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// CBTO

			XMLElement = XMLDocument.CreateElement("CBTO");
			XMLTextElement = XMLDocument.CreateTextNode(m_dCBTO.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Headspace

			XMLElement = XMLDocument.CreateElement("Headspace");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dHeadSpace));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Neck Size

			XMLElement = XMLDocument.CreateElement("NeckSize");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dNeckSize));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Neck Wall

			XMLElement = XMLDocument.CreateElement("NeckWall");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dNeckWall));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Case Trim Length

			XMLElement = XMLDocument.CreateElement("CaseTrimLength");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dCaseTrimLength));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Bullet Diameter

			XMLElement = XMLDocument.CreateElement("BulletDiameter");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dBulletDiameter));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Full Length Sized

			XMLElement = XMLDocument.CreateElement("FullLengthSized");
			XMLTextElement = XMLDocument.CreateTextNode(m_fFullLengthSized ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Neck Sized

			XMLElement = XMLDocument.CreateElement("NeckSized");
			XMLTextElement = XMLDocument.CreateTextNode(m_fNeckSized ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Expanded Neck

			XMLElement = XMLDocument.CreateElement("ExpandedNeck");
			XMLTextElement = XMLDocument.CreateTextNode(m_fExpandedNeck ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Neck Turned

			XMLElement = XMLDocument.CreateElement("NeckTurned");
			XMLTextElement = XMLDocument.CreateTextNode(m_fNeckTurned ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Annealed

			XMLElement = XMLDocument.CreateElement("Annealed");
			XMLTextElement = XMLDocument.CreateTextNode(m_fAnnealed ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Modified Bullet

			XMLElement = XMLDocument.CreateElement("ModifiedBullet");
			XMLTextElement = XMLDocument.CreateTextNode(m_fModifiedBullet ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Jump Set

			XMLElement = XMLDocument.CreateElement("JumpSet");
			XMLTextElement = XMLDocument.CreateTextNode(m_fJumpSet ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Jump

			XMLElement = XMLDocument.CreateElement("Jump");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dJump));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Archived

			XMLElement = XMLDocument.CreateElement("Archived");
			XMLTextElement = XMLDocument.CreateTextNode(m_fArchive ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Track Inventory

			XMLElement = XMLDocument.CreateElement("TrackInventory");
			XMLTextElement = XMLDocument.CreateTextNode(m_fTrackInventory ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Checked

			XMLElement = XMLDocument.CreateElement("Checked");
			XMLTextElement = XMLDocument.CreateTextNode(m_fChecked ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Batch Tests

			if (BatchTestList.Count > 0)
				m_BatchTestList.Export(XMLDocument, XMLThisElement);
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("Batch");
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public bool Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "BatchID":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nBatchID);
						break;
					case "UserBatchID":
						m_strUserID = XMLNode.FirstChild.Value;
						break;
					case "DateLoaded":
						DateTime.TryParse(XMLNode.FirstChild.Value, out m_DateLoaded);
						break;
					case "LoadIdentity":
						m_Load = cRWXMLDocument.GetLoadByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "FirearmIdentity":
						m_Firearm = cRWXMLDocument.GetFirearmByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "PowderWeight":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dPowderWeight);
						break;
					case "NumRounds":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nNumRounds);
						break;
					case "CasesFired":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nTimesFired);
						break;
					case "COAL":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dCOL);
						break;
					case "CBTO":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dCBTO);
						break;
					case "Headspace":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dHeadSpace);
						break;
					case "NeckSize":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dNeckSize);
						break;
					case "NeckWall":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dNeckWall);
						break;
					case "CaseTrimLength":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dCaseTrimLength);
						break;
					case "BulletDiameter":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dBulletDiameter);
						break;
					case "FullLengthSized":
						m_fFullLengthSized = XMLNode.FirstChild.Value == "Yes";
						break;
					case "NeckSized":
						m_fNeckSized = XMLNode.FirstChild.Value == "Yes";
						break;
					case "ExpandedNeck":
						m_fExpandedNeck = XMLNode.FirstChild.Value == "Yes";
						break;
					case "NeckTurned":
						m_fExpandedNeck = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Annealed":
						m_fAnnealed = XMLNode.FirstChild.Value == "Yes";
						break;
					case "ModifiedBullet":
						m_fModifiedBullet = XMLNode.FirstChild.Value == "Yes";
						break;
					case "JumpSet":
						m_fJumpSet = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Jump":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dJump);
						break;
					case "Archived":
						m_fArchive = XMLNode.FirstChild.Value == "Yes";
						break;
					case "TrackInventory":
						m_fTrackInventory = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Checked":
						m_fTrackInventory = XMLNode.FirstChild.Value == "Yes";
						break;
					case "BatchTestList":
						m_BatchTestList.Import(XMLDocument, XMLNode, DataFiles);
						break;
					default:
						break;
					}

				XMLNode = XMLNode.NextSibling;
				}

			return (true);
			}
		}
	}
