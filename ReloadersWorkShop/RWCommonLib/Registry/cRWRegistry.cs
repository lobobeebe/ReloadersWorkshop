//============================================================================*
// cRWRegistry.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Windows.Forms;

using CommonLib.Registry;

//============================================================================*
// Namespace
//============================================================================*

namespace RWCommonLib.Registry
	{
	//============================================================================*
	// cRWRegistry Class
	//============================================================================*

	public class cRWRegistry : cRegistry
		{
		//============================================================================*
		// Private Constant Data Members
		//============================================================================*

		private const string cm_strGUID = @"TPGUXBSF\Njdsptpgu\XSTDmjfou";
		private const string cm_strApplication = "Reloader's WorkShop";

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fTrial = true;
		private bool m_fTrialExpired = false;

		private bool m_fInvalidRegistry = false;

		private string m_strActivationKey = "";
		private string m_strUserName = "";
		private string m_strUserEmail = "";
		private string m_strVersion = "";

		private TimeSpan m_TimeLeft = new TimeSpan(0, 0, 0, 0);

		private TimeSpan m_TrialPeriod = new TimeSpan(30, 0, 0, 0, 0);

		private static string[] m_astrDomains =
			{
			"gmail.com",
			"yahoo.com",
			"hotmail.com",
			"verizon.net",
			"windstream.net",
			"att.net",
			"bell.net",
			"aol.com",
			"pcisys.net",
			".rr.com",
			".com",
			".edu",
			".net",
			".org",
			".mil",
			".co.uk"
			};

		//============================================================================*
		// cRWRegistry() - Constructor
		//============================================================================*

		public cRWRegistry()
			: base(@"SOFTWARE\" + cm_strApplication)
			{
			ApplicationKey = FixGUID();

			if (!FreshInstall)
				{
				ApplicationKey = @"SOFTWARE\" + cm_strApplication;

				if (!CheckTrial())
					m_fInvalidRegistry = true;
				}
			}

		//============================================================================*
		// ActivationKey Property
		//============================================================================*

		public string ActivationKey
			{
			get
				{
				return (m_strActivationKey);
				}
			}

		//============================================================================*
		// Activate()
		//============================================================================*

		public void Activate(string strKey, string strName, string strEmail, string strVersion)
			{
			strKey = strKey.Trim();
			strName = strName.Trim();
			strEmail = strEmail.Trim();

			//----------------------------------------------------------------------------*
			// Check input parms
			//----------------------------------------------------------------------------*

			if (!ValidateKey(strKey, strName, strEmail, strVersion))
				{
				string strText = String.Format("({0}) ({1}) ({2}) ({3})", strKey, strName, strEmail, strVersion);

				MessageBox.Show(strText);

				return;
				}

			//----------------------------------------------------------------------------*
			// If this is a fresh install, setup the registry first
			//----------------------------------------------------------------------------*

			if (FreshInstall)
				SetupRegistry();

			//----------------------------------------------------------------------------*
			// Write the registry entries
			//----------------------------------------------------------------------------*

			ApplicationKey = @"SOFTWARE\" + cm_strApplication;

			WriteKey("User Name", strName);
			WriteKey("User Email", strEmail);
			WriteKey("Activation Key", strKey);
			WriteKey("ClientVersion", strVersion);
			}

		//============================================================================*
		// ActivationStatusString Property
		//============================================================================*

		public string ActivationStatusString
			{
			get
				{
				string strString = "";

				if (m_fTrial)
					{
					if (m_fTrialExpired)
						strString = "This Trial Version Has Expired!  Enter or Purchase an Activation Key to Continue.";
					else
						strString = String.Format("Trial Version - Expires in {0:G0} day{1}", m_TimeLeft.Days, m_TimeLeft.Days != 1 ? "s" : "");
					}
				else
					strString = String.Format("Registered to {0} ({1})", m_strUserName, m_strUserEmail);

				return (strString);
				}
			}

		//============================================================================*
		// CheckParms()
		//============================================================================*

		public static bool CheckParms(string strUserName, string strUserEmail, string strVersion)
			{
			bool fOK = true;
			int nAtLocation = 0;

			//----------------------------------------------------------------------------*
			// Check User Name
			//----------------------------------------------------------------------------*

			if (string.IsNullOrEmpty(strUserName) || strUserName.Length < 3 || strUserName.IndexOf(' ') < 1)
				fOK = false;

			if (fOK)
				{
				foreach (char chChar in strUserName)
					{
					if (!Char.IsLetter(chChar) && chChar != ' ' && chChar !='\'' && chChar != '&' && chChar != '-' && chChar != ',')
						{
						fOK = false;

						break;
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Check User Email
			//----------------------------------------------------------------------------*

			if (fOK)
				{
				if (strUserEmail == null || strUserEmail.Length < 5)
					fOK = false;

				if (fOK)
					{
					nAtLocation = strUserEmail.IndexOf("@");

					if (nAtLocation < 1 || nAtLocation == strUserEmail.Length - 1)
						fOK = false;

					if (fOK)
						{
						int nLastDot = strUserEmail.LastIndexOf('.');

						if (nLastDot < nAtLocation)
							fOK = false;
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Check Version
			//----------------------------------------------------------------------------*

			if (fOK)
				{
				if (strVersion == null || strVersion.Length < 3)
					fOK = false;

				if (fOK)
					{
					if (!Char.IsNumber(strVersion[0]))
						fOK = false;

					if (fOK)
						{
						if (strVersion.IndexOf('.') < 0)
							fOK = false;

						if (fOK)
							{
							foreach (char chChar in strVersion)
								{
								if (!Char.IsNumber(chChar) && chChar != '.')
									{
									fOK = false;

									break;
									}
								}
							}
						}
					}
				}

			return (fOK);
			}

		//============================================================================*
		// CheckTrial
		//============================================================================*

		public bool CheckTrial()
			{
			bool fOK = true;
			m_fTrial = false;

			//----------------------------------------------------------------------------*
			// Check for "special" entries
			//----------------------------------------------------------------------------*

			ApplicationKey = FixGUID();

			long lTicks = 0;

			if (!ReadKey("ClientFlags", ref lTicks))
				fOK = false;

			if (fOK && !m_fTrial)
				{
				if (lTicks == 0)
					m_fTrial = true;
				}

			if (fOK && !m_fTrial)
				{
				if (!ReadKey("ClientVersion", ref m_strVersion))
					fOK = false;

				if (m_strVersion == null || m_strVersion.Length < 7)
					fOK = false;
				}

			//----------------------------------------------------------------------------*
			// Check "normal" entries
			//----------------------------------------------------------------------------*

			ApplicationKey = @"SOFTWARE\" + cm_strApplication;

			//----------------------------------------------------------------------------*
			// Check Activation Key
			//----------------------------------------------------------------------------*

			if (fOK && !m_fTrial)
				{
				if (!ReadKey("Activation Key", ref m_strActivationKey))
					fOK = false;

				if (fOK)
					{
					if (String.IsNullOrEmpty(m_strActivationKey))
						m_fTrial = true;
					}
				}

			//----------------------------------------------------------------------------*
			// Check User Name
			//----------------------------------------------------------------------------*

			if (fOK && !m_fTrial)
				{
				if (!ReadKey("User Name", ref m_strUserName))
					fOK = false;

				if (fOK)
					{
					if (m_strUserName == "Trial")
						m_fTrial = true;
					}
				}

			//----------------------------------------------------------------------------*
			// Check User Email
			//----------------------------------------------------------------------------*

			if (fOK && !m_fTrial)
				{
				if (!ReadKey("User Email", ref m_strUserEmail))
					fOK = false;

				if (fOK)
					{
					if (m_strUserEmail == "Trial")
						m_fTrial = true;
					}
				}

			//----------------------------------------------------------------------------*
			// If it's a trial version, check to see if the trial period has expired
			//----------------------------------------------------------------------------*

			if (fOK && m_fTrial && lTicks > 0)
				{
				m_fTrialExpired = false;

				DateTime InstallDate = new DateTime(lTicks);

				if (DateTime.Today > InstallDate + m_TrialPeriod)
					m_fTrialExpired = true;

				if (!m_fTrialExpired)
					m_TimeLeft = new TimeSpan(InstallDate.Ticks + m_TrialPeriod.Ticks - DateTime.Today.Ticks);
				}

			return (fOK);
			}

		//============================================================================*
		// CreateKey() - Static with input parms
		//============================================================================*

		public static string CreateKey(string strUserName, string strUserEmail, string strVersion)
			{
			string strKey = "";
			bool fOK = true;
			int nAtLocation = strUserEmail.IndexOf('@');

			//----------------------------------------------------------------------------*
			// Check Input parms
			//----------------------------------------------------------------------------*

			fOK = CheckParms(strUserName, strUserEmail, strVersion);

			//----------------------------------------------------------------------------*
			// If the parms are ok, build the key
			//----------------------------------------------------------------------------*

			if (fOK)
				{
				//----------------------------------------------------------------------------*
				// Key digits 0-1 - Location of @ in email
				//----------------------------------------------------------------------------*

				strUserEmail = strUserEmail.ToLower();

				if (nAtLocation > 51)
					{
					strKey += "ZZ";
					}
				else
					{
					if (nAtLocation > 25)
						{
						strKey += (char) ('A' + nAtLocation - 25);
						strKey += 'Z';
						}

					else
						{
						strKey += (char) ('A' + nAtLocation);
						strKey += 'A';
						}
					}

				//----------------------------------------------------------------------------*
				// Key digit 2 - Major Version
				//----------------------------------------------------------------------------*

				strKey += (char) ('a' + (strVersion[0] - '1'));

				//----------------------------------------------------------------------------*
				// Key digit 3-4 - domain type
				//----------------------------------------------------------------------------*

				for (int i = 0; i < m_astrDomains.Length; i++)
					{
					if (strUserEmail.LastIndexOf(m_astrDomains[i]) >= 0)
						{
						strKey += String.Format("{0:X2}", i + 1);

						break;
						}
					}

				if (strKey.Length < 4)
					strKey += "00";

				//----------------------------------------------------------------------------*
				// Key digit 4-5 - chars in name
				//----------------------------------------------------------------------------*

				strKey += String.Format("{0:X2}", strUserName.Length);

				//----------------------------------------------------------------------------*
				// Key digit 6-7 - location of space in name
				//----------------------------------------------------------------------------*

				strKey += String.Format("{0:X2}", strUserName.IndexOf(' '));

				//----------------------------------------------------------------------------*
				// Key digit 8-9 - ASCII value of digit 2
				//----------------------------------------------------------------------------*

				strKey += String.Format("{0:X2}", (int) Char.ToUpper(strKey[2]));

				//----------------------------------------------------------------------------*
				// Key digit 10-11 - Number of chars in email name
				//----------------------------------------------------------------------------*

				strKey += String.Format("{0:X2}", strUserEmail.IndexOf('@') + 1);

				//----------------------------------------------------------------------------*
				// Key digit 12-13 - Number of chars in email domain
				//----------------------------------------------------------------------------*

				strKey += String.Format("{0:X2}", strUserEmail.Length - strUserEmail.IndexOf('@'));

				//----------------------------------------------------------------------------*
				// Key digit 12 - Dash
				//----------------------------------------------------------------------------*

				strKey += '-';

				//----------------------------------------------------------------------------*
				// Key digit 13 - Number of name check values
				//----------------------------------------------------------------------------*

				int nNumchars = strUserName.Length / 2;

				if (nNumchars > 5)
					nNumchars = 5;

				strKey += String.Format("{0:X2}", nNumchars);

				//----------------------------------------------------------------------------*
				// Key digit 15 - 14 + nNumChars * 2 - Name check values
				//----------------------------------------------------------------------------*

				for (int i = 0; i < nNumchars; i++)
					{
					string strHex = String.Format("{0:X2}", (int) (i % 2 == 0 ? Char.ToUpper(strUserName[i * 2]) : Char.ToLower(strUserName[i * 2])));

					string strCode = "";

					for (int j = 0; j < 2; j++)
						{
						if (Char.IsLetter(strHex[j]))
							strCode += (char) ((int) strHex[j] + (int) 0x0F);
						else
							strCode += strHex[j];
						}

					strKey += strCode;
					}

				//----------------------------------------------------------------------------*
				// Key digit 15 + 2 + nNumChars * 2 - Dash
				//----------------------------------------------------------------------------*

				strKey += '-';

				//----------------------------------------------------------------------------*
				// Key digit 18 + 2 + nNumChars * 2 - Number of email check values
				//----------------------------------------------------------------------------*

				nNumchars = strUserEmail.Length / 2;

				if (nNumchars > 5)
					nNumchars = 5;

				strKey += String.Format("{0:X2}", nNumchars);

				//----------------------------------------------------------------------------*
				// Key digit 17 - 14 + nNumChars * 2 - Name check values
				//----------------------------------------------------------------------------*

				for (int i = 0; i < nNumchars; i++)
					{
					string strHex = String.Format("{0:X2}", (int) (i % 2 == 0 ? Char.ToUpper(strUserEmail[i * 2]) : Char.ToLower(strUserEmail[i * 2])));

					string strCode = "";

					for (int j = 0; j < 2; j++)
						{
						if (Char.IsNumber(strHex[j]))
							{
							char chChar = strHex[j];
							chChar += (char) 0x0F;

							strCode += chChar;
							}
						else
							strCode += strHex[j];
						}

					strKey += strCode;
					}
				}

			//----------------------------------------------------------------------------*
			// Return strKey if fOK is true, null if not
			//----------------------------------------------------------------------------*

			if (strKey != null)
				{
				string strNewKey = "";

				for (int i = 0; i < strKey.Length; i++)
					{
					if (strKey[i] >= 32)
						strNewKey += strKey[i];
					}

				strKey = strNewKey;
				}

			return (fOK ? strKey : null);
			}

		//============================================================================*
		// Email Property
		//============================================================================*

		public string Email
			{
			get
				{
				return (m_strUserEmail);
				}
			}

		//============================================================================*
		// FixGUID()
		//============================================================================*

		private string FixGUID()
			{
			string strGUID = "";

			foreach (char chChar in cm_strGUID)
				{
				if (Char.IsLetter(chChar))
					strGUID += (char) (chChar - 1);
				else
					strGUID += chChar;
				}

			return (strGUID);
			}

		//============================================================================*
		// FreshInstall Property
		//============================================================================*

		public bool FreshInstall
			{
			get
				{
				ApplicationKey = FixGUID();

				long lTicks = 0;

				if (!ReadKey("ClientFlags", ref lTicks))
					return (true);

				if (lTicks == 0)
					return (true);

				return (false);
				}
			}

		//============================================================================*
		// InvalidRegistry Property
		//============================================================================*

		public bool InvalidRegistry
			{
			get
				{
				return (m_fInvalidRegistry);
				}
			}

		//============================================================================*
		// SetupRegistry()
		//============================================================================*

		public void SetupRegistry(bool fInstall = false)
			{
			long lTicks = 0;

			ApplicationKey = FixGUID();

			if (!ReadKey("ClientFlags", ref lTicks))
				{
				lTicks = DateTime.Today.Ticks;

				WriteKey("ClientFlags", lTicks);
				}

			WriteKey("ClientVersion", Application.ProductVersion);

			ApplicationKey = @"SOFTWARE\" + cm_strApplication;

			if (lTicks == 0 || fInstall)
				{
				WriteKey("Install Date", DateTime.Today.Ticks);
				WriteKey("User Name", "Trial");
				WriteKey("User Email", "Trial");
				WriteKey("Activation Key", "");
				}

			WriteKey("ClientVersion", Application.ProductVersion);
			}

		//============================================================================*
		// Trial Property
		//============================================================================*

		public bool Trial
			{
			get
				{
				return (m_fTrial);
				}
			}

		//============================================================================*
		// TrialExpired Property
		//============================================================================*

		public bool TrialExpired
			{
			get
				{
				return (m_fTrialExpired);
				}
			}

		//============================================================================*
		// UpdateVersion()
		//============================================================================*

		public void UpdateVersion()
			{
			ApplicationKey = FixGUID();

			WriteKey("ClientVersion", Application.ProductVersion);

			ApplicationKey = @"SOFTWARE\" + cm_strApplication;

			WriteKey("ClientVersion", Application.ProductVersion);
			}

		//============================================================================*
		// UserName Property
		//============================================================================*

		public string UserName
			{
			get
				{
				return (m_strUserName);
				}
			}

		//============================================================================*
		// ValidateKey() - From Registry
		//============================================================================*

		public bool ValidateKey()
			{
			bool fOK = !m_fInvalidRegistry;

			if (fOK && !m_fTrial)
				{
				ApplicationKey = @"SOFTWARE\" + cm_strApplication;

				long lTicks = 0;
				string strUserName = "";
				string strUserEmail = "";
				string strKey = "";
				string strVersion = "";

				fOK = ReadKey("Install Date", ref lTicks);

				if (lTicks == 0)
					fOK = false;

				if (fOK)
					fOK = ReadKey("User Name", ref strUserName);

				if (fOK)
					fOK = ReadKey("User Email", ref strUserEmail);

				if (fOK)
					fOK = ReadKey("Activation Key", ref strKey);

				if (fOK)
					fOK = ReadKey("ClientVersion", ref strVersion);

				if (fOK)
					fOK = ValidateKey(strKey, strUserName, strUserEmail, strVersion);
				}

			return (fOK);
			}

		//============================================================================*
		// ValidateKey() - Static with input parms
		//============================================================================*

		public static bool ValidateKey(string strKey, string strUserName, string strUserEmail, string strVersion)
			{
			bool fOK = true;

			if (strKey == null || strKey.Length < 30)
				return (false);

			string strNewKey = "";

			for (int i = 0; i < strKey.Length; i++)
				{
				if (strKey[i] >= 32)
					strNewKey += strKey[i];
				}

			strKey = strNewKey;

			int nAtLocation = -1;

			//----------------------------------------------------------------------------*
			// Check Input parms
			//----------------------------------------------------------------------------*

			strUserEmail = strUserEmail.ToLower();

			fOK = CheckParms(strUserName, strUserEmail, strVersion);

			if (fOK)
				{
				if (strKey == null || strKey.Length < 10)
					fOK = false;
				}

			if (fOK)
				{
				nAtLocation = strUserEmail.IndexOf('@');

				if (nAtLocation < 0)
					fOK = false;
				}

			//----------------------------------------------------------------------------*
			// Match Key to parms
			//----------------------------------------------------------------------------*

			if (fOK)
				{
				//----------------------------------------------------------------------------*
				// Key digits 0-1 - Location of @ in email
				//----------------------------------------------------------------------------*

				if (nAtLocation > 51)
					{
					if (strKey.Substring(0, 2) != "ZZ")
						fOK = false;
					}
				else
					{
					if (nAtLocation > 25)
						{
						if (strKey[0] != (char) ('A' + nAtLocation - 25) || strKey[1] != 'Z')
							fOK = false;
						}
					else
						{
						if (strKey[0] != (char) ('A' + nAtLocation) || strKey[1] != 'A')
							fOK = false;
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Key digit 2 - Major Version
			//----------------------------------------------------------------------------*

			if (fOK)
				{
				if (strKey[2] != (char) ('a' + (strVersion[0] - '1')) && strVersion[0] != '0')
					fOK = false;
				}

			//----------------------------------------------------------------------------*
			// Key digit 3-4 - domain type
			//----------------------------------------------------------------------------*

			if (fOK)
				{
				string strDomain = "00";

				for (int i = 0; i < m_astrDomains.Length; i++)
					{
					if (strUserEmail.LastIndexOf(m_astrDomains[i]) >= 0)
						{
						strDomain = String.Format("{0:X2}", i + 1);

						break;
						}
					}

				if (strKey.Substring(3, 2) != strDomain)
					fOK = false;
				}


			//----------------------------------------------------------------------------*
			// Key digit 5-6 - chars in name
			//----------------------------------------------------------------------------*

			if (fOK)
				{
				if (strKey.Substring(5, 2) != String.Format("{0:X2}", strUserName.Length))
					fOK = false;
				}

			//----------------------------------------------------------------------------*
			// Key digit 7-8 - location of space in name
			//----------------------------------------------------------------------------*

			if (fOK)
				{
				if (strKey.Substring(7, 2) != String.Format("{0:X2}", strUserName.IndexOf(' ')))
					fOK = false;
				}

			//----------------------------------------------------------------------------*
			// Key digit 9-10 - ASCII value of digit 2
			//----------------------------------------------------------------------------*

			if (fOK)
				{
				if (strKey.Length < 11)
					fOK = false;
				else
					{
					if (strKey.Substring(9, 2) != String.Format("{0:X2}", (int) Char.ToUpper(strKey[2])))
						fOK = false;
					}
				}

			//----------------------------------------------------------------------------*
			// Key digit 11-12 - Number of chars in email name
			//----------------------------------------------------------------------------*

			if (fOK)
				{
				if (strKey.Length < 13)
					fOK = false;
				else
					{
					if (strKey.Substring(11, 2) != String.Format("{0:X2}", strUserEmail.IndexOf('@') + 1))
						fOK = false;
					}
				}

			//----------------------------------------------------------------------------*
			// Key digit 13-14 - Number of chars in email domain
			//----------------------------------------------------------------------------*

			if (fOK)
				{
				if (strKey.Length < 15)
					fOK = false;
				else
					{
					if (strKey.Substring(13, 2) != String.Format("{0:X2}", strUserEmail.Length - strUserEmail.IndexOf('@')))
						fOK = false;
					}
				}

			//----------------------------------------------------------------------------*
			// Key digit 15 - Dash
			//----------------------------------------------------------------------------*

			if (fOK)
				{
				if (strKey.Length < 16)
					fOK = false;
				else
					{
					if (strKey[15] != '-')
						fOK = false;
					}
				}

			//----------------------------------------------------------------------------*
			// Key digit 16-17 - Number of name check values
			//----------------------------------------------------------------------------*

			int nNumChars = strUserName.Length / 2;

			if (nNumChars > 5)
				nNumChars = 5;

			if (fOK)
				{
				if (strKey.Length < 18)
					fOK = false;
				else
					{
					if (strKey.Substring(16, 2) != String.Format("{0:X2}", nNumChars))
						fOK = false;
					}
				}

			//----------------------------------------------------------------------------*
			// Key digit 18 - 18 + nNumChars * 2 - Name check values
			//----------------------------------------------------------------------------*

			int nChar = 18;

			if (strKey.Length < nChar + (nNumChars * 2))
				fOK = false;

			if (fOK)
				{
				for (int i = 0; i < nNumChars; i++)
					{
					string strHex = String.Format("{0:X2}", (int) (i % 2 == 0 ? Char.ToUpper(strUserName[i * 2]) : Char.ToLower(strUserName[i * 2])));

					string strCode = "";

					for (int j = 0; j < 2; j++)
						{
						if (Char.IsLetter(strHex[j]))
							strCode += (char) ((int) strHex[j] + (int) 0x0F);
						else
							strCode += strHex[j];
						}

					if (strKey.Substring(nChar, 2) != strCode)
						{
						fOK = false;

						break;
						}

					nChar += 2;
					}
				}

			//----------------------------------------------------------------------------*
			// Key digit 18 + nNumChars * 2 - Dash
			//----------------------------------------------------------------------------*

			if (strKey.Length < nChar + 1)
				fOK = false;

			if (fOK)
				{
				if (strKey[nChar] != '-')
					fOK = false;
				}

			nChar++;

			//----------------------------------------------------------------------------*
			// Key digit 18 + 2 + nNumChars * 2 - Number of email check values
			//----------------------------------------------------------------------------*

			nNumChars = strUserEmail.Length / 2;

			if (nNumChars > 5)
				nNumChars = 5;

			if (strKey.Length < nChar + (nNumChars * 2))
				fOK = false;

			if (fOK)
				{
				string strKeyChars = "";
				strKeyChars += strKey[nChar++];
				strKeyChars += strKey[nChar++];

				string strNumChars = String.Format("{0:X2}", nNumChars);

				if (strKeyChars != strNumChars)
					fOK = false;
				}

			//			nChar += 2;

			//----------------------------------------------------------------------------*
			// Key digit 17 - 14 + nNumChars * 2 - Email check values
			//----------------------------------------------------------------------------*

			if (strKey.Length < nChar + (nNumChars * 2))
				fOK = false;

			if (fOK)
				{
				for (int i = 0; i < nNumChars; i++)
					{
					string strHex = String.Format("{0:X2}", (int) (i % 2 == 0 ? Char.ToUpper(strUserEmail[i * 2]) : Char.ToLower(strUserEmail[i * 2])));

					string strCode = "";

					for (int j = 0; j < 2; j++)
						{
						if (Char.IsNumber(strHex[j]))
							strCode += (char) ((int) strHex[j] + 0x0F);
						else
							strCode += strHex[j];
						}

					if (strKey.Substring(nChar, 2) != strCode)
						{
						fOK = false;

						break;
						}

					nChar += 2;
					}
				}

			return (fOK);
			}

		//============================================================================*
		// ValidRegistry Property
		//============================================================================*

		public bool ValidRegistry
			{
			get
				{
				return (!m_fInvalidRegistry);
				}
			}

		//============================================================================*
		// Version Property
		//============================================================================*

		public string Version
			{
			get
				{
				return (m_strVersion);
				}
			}
		}
	}
