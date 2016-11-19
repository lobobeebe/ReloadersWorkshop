//============================================================================*
// cChargeTest.cs
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
	// cChargeTest class
	//============================================================================*

	[Serializable]
	public class cChargeTest
		{
		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private cCharge m_Charge = null;
		private DateTime m_TestDate = DateTime.Today;
		private string m_strSource = "";
		private cFirearm m_Firearm = null;
		private double m_dBarrelLength = 0.0;
		private double m_dTwist = 0.0;
		private int m_nMuzzleVelocity = 0;
		private int m_nPressure = 0;
		private double m_dBestGroup = 0.0;
		private int m_nBestGroupRange = 0;
		private string m_strNotes = "";
		private bool m_fBatchTest = false;
		private int m_nBatchID = 0;
		private double m_dPowderWeight = 0.0;

		//============================================================================*
		// cChargeTest() - Constructor
		//============================================================================*

		public cChargeTest()
			{
			}

		//============================================================================*
		// cChargeTest() - Copy Constructor
		//============================================================================*

		public cChargeTest(cChargeTest ChargeTest)
			{
			Copy(ChargeTest);
			}

		//============================================================================*
		// BarrelLength Property
		//============================================================================*

		public double BarrelLength
			{
			get
				{
				if (m_Firearm != null)
					return (m_Firearm.BarrelLength);

				return (m_dBarrelLength);
				}

			set
				{
				if (m_Firearm == null)
					m_dBarrelLength = value;
				}
			}

		//============================================================================*
		// BatchID Property
		//============================================================================*

		public int BatchID
			{
			get
				{
				return (m_nBatchID);
				}
			set
				{
				m_nBatchID = value;
				}
			}

		//============================================================================*
		// BatchTest Property
		//============================================================================*

		public bool BatchTest
			{
			get
				{
				return (m_fBatchTest);
				}
			set
				{
				m_fBatchTest = value;
				}
			}

		//============================================================================*
		// BestGroup Property
		//============================================================================*

		public double BestGroup
			{
			get
				{
				return (m_dBestGroup);
				}
			set
				{
				m_dBestGroup = value;
				}
			}

		//============================================================================*
		// BestGroupRange Property
		//============================================================================*

		public int BestGroupRange
			{
			get
				{
				return (m_nBestGroupRange);
				}
			set
				{
				m_nBestGroupRange = value;
				}
			}

		//============================================================================*
		// Charge Property
		//============================================================================*

		public cCharge Charge
			{
			get
				{
				return (m_Charge);
				}
			set
				{
				m_Charge = value;
				}
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cChargeTest Test1, cChargeTest Test2)
			{
			if (Test1 == null)
				{
				if (Test2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Test2 == null)
					return (1);
				}

			return (Test1.CompareTo(Test2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(cChargeTest ChargeTest)
			{
			if (ChargeTest == null)
				return (1);

			//----------------------------------------------------------------------------*
			// Date
			//----------------------------------------------------------------------------*

			int rc = m_TestDate.CompareTo(ChargeTest.m_TestDate);

			// Sort Latest to Oldest

			if (rc != 0)
				{
				return (rc < 0 ? 1 : -1);
				}

			//----------------------------------------------------------------------------*
			// Source
			//----------------------------------------------------------------------------*

			if (rc == 0)
				{
				rc = m_strSource.ToUpper().CompareTo(ChargeTest.m_strSource.ToUpper());

				//----------------------------------------------------------------------------*
				// Firearm
				//----------------------------------------------------------------------------*

				if (rc == 0)
					{
					if (m_Firearm != null)
						rc = m_Firearm.CompareTo(ChargeTest.m_Firearm);

					//----------------------------------------------------------------------------*
					// Barrel Length
					//----------------------------------------------------------------------------*

					if (rc == 0)
						{
						rc = m_dBarrelLength.CompareTo(ChargeTest.m_dBarrelLength);

						//----------------------------------------------------------------------------*
						// Twist
						//----------------------------------------------------------------------------*

						if (rc == 0)
							{
							rc = m_dTwist.CompareTo(ChargeTest.m_dTwist);

							//----------------------------------------------------------------------------*
							// Muzzle Velocity
							//----------------------------------------------------------------------------*

							if (rc == 0)
								{
								rc = m_nMuzzleVelocity.CompareTo(ChargeTest.m_nMuzzleVelocity);

								//----------------------------------------------------------------------------*
								// Pressure
								//----------------------------------------------------------------------------*

								if (rc == 0)
									{
									rc = m_nPressure.CompareTo(ChargeTest.m_nPressure);
									}
								}
							}
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Return results
			//----------------------------------------------------------------------------*

			return (rc);
			}

		//============================================================================*
		// Copy() - BatchTest
		//============================================================================*

		public void Copy(cBatchTest BatchTest)
			{
			if (BatchTest != null)
				return;

			m_Charge = null;

			foreach (cCharge Charge in BatchTest.Batch.Load.ChargeList)
				{
				if (Charge.PowderWeight == BatchTest.Batch.PowderWeight)
					{
					m_Charge = Charge;

					break;
					}
				}

			m_dBarrelLength = BatchTest.Firearm.BarrelLength;
			m_dBestGroup = BatchTest.BestGroup;
			m_nBestGroupRange = BatchTest.BestGroupRange;
			m_Firearm = BatchTest.Firearm;
			m_nMuzzleVelocity = BatchTest.MuzzleVelocity;
			m_strNotes = BatchTest.Notes;
			m_nPressure = BatchTest.Pressure;
			m_TestDate = BatchTest.TestDate;
			m_dTwist = BatchTest.Firearm.Twist;
			m_dPowderWeight = BatchTest.Batch.PowderWeight;

			m_fBatchTest = true;

			if (BatchTest.Batch != null)
				{
				m_nBatchID = BatchTest.Batch.BatchID;

				m_strSource = String.Format("Batch #{0:G0} Testing", BatchTest.Batch.BatchID);
				}
			}

		//============================================================================*
		// Copy() - ChargeTest
		//============================================================================*

		public void Copy(cChargeTest ChargeTest)
			{
			m_Charge = ChargeTest.m_Charge;

			m_TestDate = ChargeTest.m_TestDate;
			m_strSource = ChargeTest.m_strSource;

			m_Firearm = ChargeTest.m_Firearm;
			m_dBarrelLength = ChargeTest.m_dBarrelLength;
			m_dTwist = ChargeTest.m_dTwist;

			m_nMuzzleVelocity = ChargeTest.m_nMuzzleVelocity;
			m_nPressure = ChargeTest.m_nPressure;

			m_dBestGroup = ChargeTest.m_dBestGroup;
			m_nBestGroupRange = ChargeTest.m_nBestGroupRange;
			m_strNotes = ChargeTest.m_strNotes;

			m_fBatchTest = ChargeTest.m_fBatchTest;
			m_nBatchID = ChargeTest.m_nBatchID;

			m_dPowderWeight = ChargeTest.m_dPowderWeight;
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement("ChargeTest");
			XMLParentElement.AppendChild(XMLThisElement);

			// Test Date

			XmlElement XMLElement = XMLDocument.CreateElement("TestDate");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(m_TestDate.ToShortDateString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Source

			XMLElement = XMLDocument.CreateElement("Source");
			XMLTextElement = XMLDocument.CreateTextNode(m_strSource);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Firearm

			if (m_Firearm != null)
				{
				XMLElement = XMLDocument.CreateElement("Firearm");
				XMLTextElement = XMLDocument.CreateTextNode(m_Firearm.ToString());
				XMLElement.AppendChild(XMLTextElement);

				XMLThisElement.AppendChild(XMLElement);
				}

			// Barrel Length

			XMLElement = XMLDocument.CreateElement("BarrelLength");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dBarrelLength));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Twist

			XMLElement = XMLDocument.CreateElement("Twist");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dTwist));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Muzzle Velocity

			XMLElement = XMLDocument.CreateElement("MuzzleVelocity");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_nMuzzleVelocity));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Pressure

			XMLElement = XMLDocument.CreateElement("Pressure");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_nPressure));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Best Group

			XMLElement = XMLDocument.CreateElement("BestGroup");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dBestGroup));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Best Group Range

			XMLElement = XMLDocument.CreateElement("BestGroupRange");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_nBestGroupRange));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Notes

			XMLElement = XMLDocument.CreateElement("Notes");
			XMLTextElement = XMLDocument.CreateTextNode(m_strNotes);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Batch Test

			XMLElement = XMLDocument.CreateElement("BatchTest");
			XMLTextElement = XMLDocument.CreateTextNode(m_fBatchTest ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Batch ID

			XMLElement = XMLDocument.CreateElement("BatchID");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_nBatchID));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);
			}

		//============================================================================*
		// Firearm Property
		//============================================================================*

		public cFirearm Firearm
			{
			get
				{
				return (m_Firearm);
				}

			set
				{
				m_Firearm = value;

				if (m_Firearm != null)
					{
					m_dBarrelLength = Firearm.BarrelLength;
					m_dTwist = Firearm.Twist;
					}
				}
			}

		//============================================================================*
		// MuzzleVelocity Property
		//============================================================================*

		public int MuzzleVelocity
			{
			get
				{
				return (m_nMuzzleVelocity);
				}
			set
				{
				m_nMuzzleVelocity = value;
				}
			}

		//============================================================================*
		// Notes Property
		//============================================================================*

		public string Notes
			{
			get
				{
				return (m_strNotes);
				}
			set
				{
				m_strNotes = value;
				}
			}

		//============================================================================*
		// PowderWeight Property
		//============================================================================*

		public double PowderWeight
			{
			get
				{
				return (m_dPowderWeight);
				}
			set
				{
				m_dPowderWeight = value;
				}
			}

		//============================================================================*
		// Pressure Property
		//============================================================================*

		public int Pressure
			{
			get
				{
				return (m_nPressure);
				}
			set
				{
				m_nPressure = value;
				}
			}

		//============================================================================*
		// Source Property
		//============================================================================*

		public string Source
			{
			get
				{
				return (m_strSource);
				}
			set
				{
				m_strSource = value;
				}
			}

		//============================================================================*
		// Synch() - Firearm
		//============================================================================*

		public bool Synch(cFirearm Firearm)
			{
			if (m_Firearm != null && m_Firearm.CompareTo(Firearm) == 0)
				{
				m_Firearm = Firearm;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// TestDate Property
		//============================================================================*

		public DateTime TestDate
			{
			get
				{
				return (m_TestDate);
				}
			set
				{
				m_TestDate = value;
				}
			}

		//============================================================================*
		// ToString
		//============================================================================*

		public override string ToString()
			{
			string strString = m_strSource;

			if (m_Firearm != null)
				strString += String.Format(", Bbl: {0:f1} Twist: {1:f1}", m_Firearm.BarrelLength, m_Firearm.Twist);
			else
				strString += String.Format(", Bbl: {0:f1} Twist: {1:f1}", m_dBarrelLength, m_dTwist);

			if (m_nMuzzleVelocity > 0)
				strString += String.Format(", Muzzle Vel.: {0:N0}", m_nMuzzleVelocity);

			if (m_nPressure > 0)
				strString += String.Format(", Pressure: {0:N0}", m_nPressure);

			return (strString);
			}

		//============================================================================*
		// Twist Property
		//============================================================================*

		public double Twist
			{
			get
				{
				if (m_Firearm != null)
					return (m_Firearm.Twist);

				return (m_dTwist);
				}

			set
				{
				if (m_Firearm == null)
					m_dTwist = value;
				}
			}
		}
	}
