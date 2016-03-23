//============================================================================*
// cKeyCommand.cs
//
// Copyright 2015m Kevin S, Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// Using Statements
//============================================================================*

using System;
using System.Data.SqlClient;

using CommonLib.Data;

//============================================================================*
// Namespace
//============================================================================*

namespace RWCommonLib.License
	{
	//============================================================================*
	// cKeyCommand Class
	//============================================================================*

	public class cKeyCommand
		{
		//============================================================================*
		// Public Enumerations
		//============================================================================*

		public enum eCommands
			{
			AddLicense = 0,
			Activate,
			GetLicenses,
			ValidateLicense,
			Unknown
			}

		public enum eErrorCodes
			{
			None = 0,
			NotConnected,
			InvalidCommand,
			MissingParameter,
			InvalidResponse,
			InvalidKey
			}

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private System.Web.UI.Page m_Page = null;

		private string m_strCommand = null;
		private string m_strKey = null;
		private string m_strName = null;
		private string m_strEmail = null;
		private string m_strNIC = null;
		private string m_strComputerName = null;

		private string m_strServer = null;
		private string m_strDatabase = null;
		private string m_strUserID = null;
		private string m_strPassword = null;

		private eErrorCodes m_eErrorCode = eErrorCodes.None;

		//============================================================================*
		// cKeyCommand() - Default Constructor
		//============================================================================*

		public cKeyCommand()
			{
			}

		//============================================================================*
		// cKeyCommand() - Constructor
		//============================================================================*

		public cKeyCommand(System.Web.UI.Page Page)
			{
			m_Page = Page;
			}

		//============================================================================*
		// Execute()
		//============================================================================*

		public void Execute()
			{
			//----------------------------------------------------------------------------*
			// Get and verify the input data
			//----------------------------------------------------------------------------*

			if (!string.IsNullOrEmpty(m_Page.Request.QueryString["Command"]))
				m_strCommand = m_Page.Request.QueryString["Command"];

			if (!string.IsNullOrEmpty(m_Page.Request.QueryString["Key"]))
				m_strKey = m_Page.Request.QueryString["Key"];

			if (!string.IsNullOrEmpty(m_Page.Request.QueryString["Name"]))
				m_strName = m_Page.Request.QueryString["Name"];

			if (!string.IsNullOrEmpty(m_Page.Request.QueryString["Email"]))
				m_strEmail = m_Page.Request.QueryString["Email"];

			if (!string.IsNullOrEmpty(m_Page.Request.QueryString["ComputerName"]))
				m_strComputerName = m_Page.Request.QueryString["ComputerName"];

			if (!string.IsNullOrEmpty(m_Page.Request.QueryString["NIC"]))
				m_strNIC = m_Page.Request.QueryString["NIC"];

			//----------------------------------------------------------------------------*
			// If any data is missing, set the error code
			//----------------------------------------------------------------------------*

			m_eErrorCode = eErrorCodes.None;

			if (string.IsNullOrEmpty(m_strKey) ||
				string.IsNullOrEmpty(m_strName) ||
				string.IsNullOrEmpty(m_strEmail) ||
				string.IsNullOrEmpty(m_strCommand))
				{
				m_eErrorCode = eErrorCodes.MissingParameter;

				return;
				}

			//----------------------------------------------------------------------------*
			// Execute the Command
			//----------------------------------------------------------------------------*

			switch (Command)
				{
				case eCommands.Activate:
					ActivateKey();
					break;

				case eCommands.AddLicense:
					AddLicense();
					break;

				case eCommands.GetLicenses:
					GetLicenses();
					break;

				case eCommands.ValidateLicense:
					ValidateLicense();
					break;

				default:
					m_eErrorCode = eErrorCodes.InvalidCommand;
					break;
				}
			}

		//============================================================================*
		// ActivateKey()
		//============================================================================*

		protected void ActivateKey()
			{
			//----------------------------------------------------------------------------*
			// Get and verify the input data
			//----------------------------------------------------------------------------*

			if (!string.IsNullOrEmpty(m_Page.Request.QueryString["ActivationKey"]))
				m_strKey = m_Page.Request.QueryString["ActivationKey"];

			if (!string.IsNullOrEmpty(m_Page.Request.QueryString["UserName"]))
				m_strName = m_Page.Request.QueryString["UserName"];

			if (!string.IsNullOrEmpty(m_Page.Request.QueryString["Email"]))
				m_strEmail = m_Page.Request.QueryString["Email"];

			//----------------------------------------------------------------------------*
			// If any data is missing, set the error code
			//----------------------------------------------------------------------------*

			if (string.IsNullOrEmpty(m_strKey) ||
				string.IsNullOrEmpty(m_strName) ||
				string.IsNullOrEmpty(m_strEmail))
				{
				m_eErrorCode = eErrorCodes.MissingParameter;

				return;
				}
			}

		//============================================================================*
		// ActivationKey Property
		//============================================================================*

		public string ActivationKey
			{
			get
				{
				return (m_strKey);
				}
			set
				{
				m_strKey = value;
				}
			}

		//============================================================================*
		// AddLicense()
		//============================================================================*

		protected void AddLicense()
			{
			m_eErrorCode = eErrorCodes.None;

			cSQL SQL = new cSQL(Server, Database, UserID, Password);

			string strCommand = String.Format("INSERT INTO Licenses (ActivationKey, Name, Email) VALUES ('{0}', '{1}', '{2}')", m_strKey, m_strName, m_strEmail);

			int nCount = SQL.ExecuteCommand(strCommand);

			m_Page.Response.Write(String.Format("AddLicense: {0:G}\n", SQL.ErrorCode));
			}

		//============================================================================*
		// Command Property
		//============================================================================*

		public eCommands Command
			{
			get
				{
				switch (m_strCommand)
					{
					case "AddLicense":
						return (eCommands.AddLicense);

					case "GetLicenses":
						return (eCommands.GetLicenses);

					case "ValidateLicense":
						return (eCommands.ValidateLicense);

					default:
						return (eCommands.Unknown);
					}
				}
			}

		//============================================================================*
		// Database Property
		//============================================================================*

		public string Database
			{
			get
				{
				return (m_strDatabase);
				}
			set
				{
				m_strDatabase = value;
				}
			}

		//============================================================================*
		// Email Property
		//============================================================================*

		public string Email
			{
			get
				{
				return (m_strEmail);
				}
			set
				{
				m_strEmail = value;
				}
			}

		//============================================================================*
		// Error Property
		//============================================================================*

		public bool Error
			{
			get
				{
				if (m_eErrorCode != eErrorCodes.None)
					return (true);

				return (false);
				}
			}

		//============================================================================*
		// ErrorCode Property
		//============================================================================*

		public eErrorCodes ErrorCode
			{
			get
				{
				return (m_eErrorCode);
				}
			set
				{
				m_eErrorCode = value;
				}
			}

		//============================================================================*
		// ErrorString Property
		//============================================================================*

		public static string ErrorString(eErrorCodes eErrorCode)
			{
			switch (eErrorCode)
				{
				case eErrorCodes.None:
					return ("Success");

				case eErrorCodes.NotConnected:
					return ("Not Connected");

				case eErrorCodes.InvalidCommand:
					return ("Invalid Command");

				case eErrorCodes.InvalidKey:
					return ("Invalid Key");

				case eErrorCodes.InvalidResponse:
					return ("Invalid Response");

				case eErrorCodes.MissingParameter:
					return ("Missing Parameter");
				}

			return ("Unknown Error");
			}

		//============================================================================*
		// GetLicenses()
		//============================================================================*

		protected void GetLicenses()
			{
			m_eErrorCode = eErrorCodes.None;

			cSQL SQL = new cSQL(Server, Database, UserID, Password);

			string strCommand = String.Format("SELECT * FROM Licenses WHERE ActivationKey = '{0}' AND Name = '{1}' AND Email = '{2}'", m_strKey, m_strName, m_strEmail);

			SqlDataReader Reader = SQL.ExecuteQuery(strCommand);

			if (Reader != null)
				{
				m_Page.Response.Write(String.Format("GetLicenses: {0:G}<br />\n", (int) cKeyCommand.eErrorCodes.None));

				while (Reader.Read())
					{
					m_Page.Response.Write("License:<br />\n");
					m_Page.Response.Write(String.Format("Key: {0}<br />\n", Reader["ActivationKey"].ToString()));
					m_Page.Response.Write(String.Format("Name: {0}<br />\n", Reader["Name"].ToString()));
					m_Page.Response.Write(String.Format("Email: {0}<br />\n", Reader["Email"].ToString()));
					m_Page.Response.Write(String.Format("Computer: {0}<br />\n", Reader["Computer"].ToString()));
					m_Page.Response.Write(String.Format("NIC: {0}<br />\n", Reader["NIC"].ToString()));
					}
				}
			else
				m_Page.Response.Write(String.Format("AddLicense: Error {0:G} - {1}", SQL.ErrorCode, SQL.ErrorMessage));

			SQL.Close();
			}

		//============================================================================*
		// NIC Property
		//============================================================================*

		public string NIC
			{
			get
				{
				return (m_strNIC);
				}
			set
				{
				m_strNIC = value;
				}
			}

		//============================================================================*
		// Password Property
		//============================================================================*

		public string Password
			{
			get
				{
				return (m_strPassword);
				}
			set
				{
				m_strPassword = value;
				}
			}

		//============================================================================*
		// Server Property
		//============================================================================*

		public string Server
			{
			get
				{
				return (m_strServer);
				}
			set
				{
				m_strServer = value;
				}
			}

		//============================================================================*
		// UserID Property
		//============================================================================*

		public string UserID
			{
			get
				{
				return (m_strUserID);
				}
			set
				{
				m_strUserID = value;
				}
			}

		//============================================================================*
		// Name Property
		//============================================================================*

		protected string Name
			{
			get
				{
				return (m_strName);
				}
			set
				{
				m_strName = value;
				}
			}

		//============================================================================*
		// ValidateLicense()
		//============================================================================*

		protected void ValidateLicense()
			{
			m_eErrorCode = eErrorCodes.InvalidKey;
			}
		}
	}
