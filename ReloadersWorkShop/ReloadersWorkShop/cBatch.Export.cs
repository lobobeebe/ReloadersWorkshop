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
			XmlElement XMLThisElement = XMLDocument.CreateElement(ExportName, XMLParentElement);

			XMLDocument.CreateElement("BatchID", m_nBatchID, XMLThisElement);

			if (!String.IsNullOrEmpty(m_strUserID))
				XMLDocument.CreateElement("UserBatchID", m_strUserID, XMLThisElement);

			XMLDocument.CreateElement("DateLoaded", m_DateLoaded, XMLThisElement);

			m_Load.Export(XMLDocument, XMLThisElement, true);

			if (m_Firearm != null)
				m_Firearm.Export(XMLDocument, XMLThisElement, true);

			XMLDocument.CreateElement("PowderWeight", m_dPowderWeight, XMLThisElement);
			XMLDocument.CreateElement("NumRounds", m_nNumRounds, XMLThisElement);
			XMLDocument.CreateElement("CasesFired", m_nTimesFired, XMLThisElement);
			XMLDocument.CreateElement("COAL", m_dCOL, XMLThisElement);
			XMLDocument.CreateElement("HeadSpace", m_dHeadSpace, XMLThisElement);
			XMLDocument.CreateElement("NeckSize", m_dNeckSize, XMLThisElement);
			XMLDocument.CreateElement("NeckWall", m_dNeckWall, XMLThisElement);
			XMLDocument.CreateElement("CaseTrimLength", m_dCaseTrimLength, XMLThisElement);
			XMLDocument.CreateElement("BulletDiameter", m_dBulletDiameter, XMLThisElement);
			XMLDocument.CreateElement("FullLengthSized", m_fFullLengthSized, XMLThisElement);
			XMLDocument.CreateElement("NeckSized", m_fNeckSized, XMLThisElement);
			XMLDocument.CreateElement("ExpandedNeck", m_fExpandedNeck, XMLThisElement);
			XMLDocument.CreateElement("NeckTurned", m_fNeckTurned, XMLThisElement);
			XMLDocument.CreateElement("Annealed", m_fAnnealed, XMLThisElement);
			XMLDocument.CreateElement("ModifiedBullet", m_fModifiedBullet, XMLThisElement);
			XMLDocument.CreateElement("JumpSet", m_fJumpSet, XMLThisElement);
			XMLDocument.CreateElement("Jump", m_dJump, XMLThisElement);
			XMLDocument.CreateElement("Archived", m_fArchive, XMLThisElement);
			XMLDocument.CreateElement("TrackInventory", m_fTrackInventory, XMLThisElement);
			XMLDocument.CreateElement("Checked", m_fChecked, XMLThisElement);

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
						XMLDocument.Import(XMLNode, out m_nBatchID);
						break;
					case "UserBatchID":
						XMLDocument.Import(XMLNode, out m_strUserID);
						break;
					case "DateLoaded":
						XMLDocument.Import(XMLNode, out m_DateLoaded);
						break;
					case "LoadIdentity":
						m_Load = cRWXMLDocument.GetLoadByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "FirearmIdentity":
						m_Firearm = cRWXMLDocument.GetFirearmByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "PowderWeight":
						XMLDocument.Import(XMLNode, out m_dPowderWeight);
						break;
					case "NumRounds":
						XMLDocument.Import(XMLNode, out m_nNumRounds);
						break;
					case "CasesFired":
						XMLDocument.Import(XMLNode, out m_nTimesFired);
						break;
					case "COAL":
						XMLDocument.Import(XMLNode, out m_dCOL);
						break;
					case "CBTO":
						XMLDocument.Import(XMLNode, out m_dCBTO);
						break;
					case "HeadSpace":
					case "Headspace":
						XMLDocument.Import(XMLNode, out m_dHeadSpace);
						break;
					case "NeckSize":
						XMLDocument.Import(XMLNode, out m_dNeckSize);
						break;
					case "NeckWall":
						XMLDocument.Import(XMLNode, out m_dNeckWall);
						break;
					case "CaseTrimLength":
						XMLDocument.Import(XMLNode, out m_dCaseTrimLength);
						break;
					case "BulletDiameter":
						XMLDocument.Import(XMLNode, out m_dBulletDiameter);
						break;
					case "FullLengthSized":
						XMLDocument.Import(XMLNode, out m_fFullLengthSized);
						break;
					case "NeckSized":
						XMLDocument.Import(XMLNode, out m_fNeckSized);
						break;
					case "ExpandedNeck":
						XMLDocument.Import(XMLNode, out m_fExpandedNeck);
						break;
					case "NeckTurned":
						XMLDocument.Import(XMLNode, out m_fExpandedNeck);
						break;
					case "Annealed":
						XMLDocument.Import(XMLNode, out m_fAnnealed);
						break;
					case "ModifiedBullet":
						XMLDocument.Import(XMLNode, out m_fModifiedBullet);
						break;
					case "JumpSet":
						XMLDocument.Import(XMLNode, out m_fJumpSet);
						break;
					case "Jump":
						XMLDocument.Import(XMLNode, out m_dJump);
						break;
					case "Archived":
						XMLDocument.Import(XMLNode, out m_fArchive);
						break;
					case "TrackInventory":
						XMLDocument.Import(XMLNode, out m_fTrackInventory);
						break;
					case "Checked":
						XMLDocument.Import(XMLNode, out m_fTrackInventory);
						break;
					case "BatchTests":
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
