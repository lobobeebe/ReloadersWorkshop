//============================================================================*
// cRWLicense.cs
//============================================================================*

//============================================================================*
// Using Statements
//============================================================================*

using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

using RWCommonLib.License;
using RWCommonLib.Registry;

//============================================================================*
// Namespace
//============================================================================*

namespace RWCommonLib.License
	{
	//============================================================================*
	// cRWLicense Class
	//============================================================================*

	public class cRWLicenseCommands
		{
		//============================================================================*
		// Private Static Data Members
		//============================================================================*

		private static string sm_strURL = "https://www.reloadersworkshop.com/keys/default.aspx";

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private string m_strMachineName = Environment.MachineName;
		private string m_strNIC = string.Empty;

		cRWRegistry m_RWRegistry = new cRWRegistry();

		//============================================================================*
		// cRWLicense() - Default Constructor
		//============================================================================*

		public cRWLicenseCommands()
			{
			foreach (NetworkInterface Interface in NetworkInterface.GetAllNetworkInterfaces())
				{
				if (Interface.OperationalStatus == OperationalStatus.Up && Interface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
					{
					m_strNIC = Interface.Id;

					break;
					}
				}
			}

		//============================================================================*
		// AddLicense()
		//============================================================================*

		public cKeyCommand.eErrorCodes AddLicense(string strName, string strEmail, string strKey)
			{
			cKeyCommand.eErrorCodes eErrorCode = cKeyCommand.eErrorCodes.None;

			string strCommand = sm_strURL + String.Format("?Command=AddLicense&Name={0}&Email={1}&Key={2}", strName, strEmail, strKey);

			eErrorCode = SendCommand(strCommand);

			return (eErrorCode);
			}

		//============================================================================*
		// GetLicenseList()
		//============================================================================*

		public cKeyCommand.eErrorCodes GetLicenseList(string strName, string strEmail, string strKey, out cRWLicenseList RWLicenseList)
			{
			RWLicenseList = new cRWLicenseList();

			string strCommand = sm_strURL + String.Format("?Command=GetLicenses&Name={0}&Email={1}&Key={2}", strName, strEmail, strKey);

			string strResponse = "GetLicenses:";

			//----------------------------------------------------------------------------*
			// Initialize the Request
			//----------------------------------------------------------------------------*

			WebRequest Request = WebRequest.Create(strCommand);

			HttpWebResponse Response = null;
			Stream KeyStream = null;
			StreamReader KeyReader = null;
			cKeyCommand.eErrorCodes eErrorCode = cKeyCommand.eErrorCodes.None;

			try
				{
				//----------------------------------------------------------------------------*
				// Send the request
				//----------------------------------------------------------------------------*

				Response = (HttpWebResponse) Request.GetResponse();

				//----------------------------------------------------------------------------*
				// Get the response
				//----------------------------------------------------------------------------*

				KeyStream = Response.GetResponseStream();

				KeyReader = new StreamReader(KeyStream);

				//----------------------------------------------------------------------------*
				// Check each line of the response for the command string
				//----------------------------------------------------------------------------*

				bool fResponseFound = false;

				while (!fResponseFound && !KeyReader.EndOfStream)
					{
					string strLine = KeyReader.ReadLine();

					//----------------------------------------------------------------------------*
					// If response is found, record the error code
					//----------------------------------------------------------------------------*

					if (strLine.Length > strResponse.Length && strLine.Substring(0, strResponse.Length) == strResponse)
						{
						fResponseFound = true;

						int nError = 0;

						int.TryParse(strLine.Substring(strResponse.Length + 1), out nError);

						eErrorCode = (cKeyCommand.eErrorCodes) nError;

						break;
						}
					}

				if (!fResponseFound)
					eErrorCode = cKeyCommand.eErrorCodes.InvalidResponse;

				//----------------------------------------------------------------------------*
				// Get the list of licenses
				//----------------------------------------------------------------------------*

				if (eErrorCode == cKeyCommand.eErrorCodes.None)
					{
					cRWLicense RWLicense = null;

					while (!KeyReader.EndOfStream)
						{
						string strLine = KeyReader.ReadLine();

						//----------------------------------------------------------------------------*
						// If a license start is found, create a new license
						//----------------------------------------------------------------------------*

						if (strLine.Length > "License:".Length && strLine.Substring(0, "License:".Length) == "License:")
							{
							if (RWLicense != null)
								RWLicenseList.Add(RWLicense);

							RWLicense = new cRWLicense();

							continue;
							}

						//----------------------------------------------------------------------------*
						// If a license name is found, add it to the current license
						//----------------------------------------------------------------------------*

						if (strLine.Length > "Name:".Length && strLine.Substring(0, "Name:".Length) == "Name:")
							{
							if (RWLicense != null)
								RWLicense.Name = strLine.Substring("Name:".Length + 1, strLine.IndexOf("<br />") - "Name:".Length - 1);

							continue;
							}

						//----------------------------------------------------------------------------*
						// If a license email is found, add it to the current license
						//----------------------------------------------------------------------------*

						if (strLine.Length > "Email:".Length && strLine.Substring(0, "Email:".Length) == "Email:")
							{
							if (RWLicense != null)
								RWLicense.Email = strLine.Substring("Email:".Length + 1, strLine.IndexOf("<br />") - "Email:".Length - 1);

							continue;
							}

						//----------------------------------------------------------------------------*
						// If a license key is found, add it to the current license
						//----------------------------------------------------------------------------*

						if (strLine.Length > "Key:".Length && strLine.Substring(0, "Key:".Length) == "Key:")
							{
							if (RWLicense != null)
								RWLicense.Key = strLine.Substring("Key:".Length + 1, strLine.IndexOf("<br />") - "Key:".Length - 1);

							continue;
							}

						//----------------------------------------------------------------------------*
						// If a license computer name is found, add it to the current license
						//----------------------------------------------------------------------------*

						if (strLine.Length > "Computer Name:".Length && strLine.Substring(0, "Computer Name:".Length) == "Computer Name:")
							{
							if (RWLicense != null)
								RWLicense.ComputerName = strLine.Substring("Computer Name:".Length + 1, strLine.IndexOf("<br />") - "Computer Name:".Length - 1);

							continue;
							}

						//----------------------------------------------------------------------------*
						// If a license NIC is found, add it to the current license
						//----------------------------------------------------------------------------*

						if (strLine.Length > "NIC:".Length && strLine.Substring(0, "NIC:".Length) == "NIC:")
							{
							if (RWLicense != null)
								RWLicense.NIC = strLine.Substring("NIC:".Length + 1, strLine.IndexOf("<br />") - "NIC:".Length - 1);

							continue;
							}
						}

					if (RWLicense != null)
						RWLicenseList.Add(RWLicense);
					}
				}

			//----------------------------------------------------------------------------*
			// If there's an error sending or receiving, just continue
			//----------------------------------------------------------------------------*

			catch
				{
				}

			//----------------------------------------------------------------------------*
			// Clean up and exit
			//----------------------------------------------------------------------------*

			finally
				{
				if (KeyReader != null)
					KeyReader.Close();

				if (KeyStream != null)
					KeyStream.Close();

				if (Response != null)
					Response.Close();
				}

			return (eErrorCode);
			}

		//============================================================================*
		// SendCommand()
		//============================================================================*

		public cKeyCommand.eErrorCodes SendCommand(string strCommand)
			{
			cKeyCommand.eErrorCodes eError = cKeyCommand.eErrorCodes.None;

			//----------------------------------------------------------------------------*
			// Get the command to look for in the response
			//----------------------------------------------------------------------------*

			int nCommandStart = strCommand.IndexOf("Command=") + 8;
			int nCommandlength = strCommand.IndexOf("&", nCommandStart) - nCommandStart;

			string strResponse = strCommand.Substring(nCommandStart, nCommandlength) + ":";

			//----------------------------------------------------------------------------*
			// Initialize the Request
			//----------------------------------------------------------------------------*

			WebRequest Request = WebRequest.Create(strCommand);

			HttpWebResponse Response = null;
			Stream KeyStream = null;
			StreamReader KeyReader = null;

			try
				{
				//----------------------------------------------------------------------------*
				// Send the request
				//----------------------------------------------------------------------------*

				Response = (HttpWebResponse) Request.GetResponse();

				//----------------------------------------------------------------------------*
				// Get the response
				//----------------------------------------------------------------------------*

				KeyStream = Response.GetResponseStream();

				KeyReader = new StreamReader(KeyStream);

				//----------------------------------------------------------------------------*
				// Check each line of the response for the command string
				//----------------------------------------------------------------------------*

				bool fResponseFound = false;

				while (!fResponseFound && !KeyReader.EndOfStream)
					{
					string strLine = KeyReader.ReadLine();

					//----------------------------------------------------------------------------*
					// If response is found, record the error code
					//----------------------------------------------------------------------------*

					if (strLine.Length > strResponse.Length && strLine.Substring(0, strResponse.Length) == strResponse)
						{
						fResponseFound = true;

						int nError = 0;

						int.TryParse(strLine.Substring(strResponse.Length + 1), out nError);

						eError = (cKeyCommand.eErrorCodes) nError;

						break;
						}
					}

				if (!fResponseFound)
					eError = cKeyCommand.eErrorCodes.InvalidResponse;
				}

			//----------------------------------------------------------------------------*
			// If there's an error sending or receiving, just continue
			//----------------------------------------------------------------------------*

			catch
				{
				eError = cKeyCommand.eErrorCodes.NotConnected;
				}

			//----------------------------------------------------------------------------*
			// Clean up and exit
			//----------------------------------------------------------------------------*

			finally
				{
				if (KeyReader != null)
					KeyReader.Close();

				if (KeyStream != null)
					KeyStream.Close();

				if (Response != null)
					Response.Close();
				}

			return (eError);
			}

		//============================================================================*
		// ValidateLicense()
		//============================================================================*

		public bool ValidateLicense()
			{
			bool fOK = true;

			if (string.IsNullOrEmpty(m_strNIC))
				return (true);

			//----------------------------------------------------------------------------*
			// Create and send the command
			//----------------------------------------------------------------------------*

			string strCommand = sm_strURL + String.Format("?Command=ValidateLicense&ActivationKey={0}&UserName={1}&Email={2}&MachineName={3}&NIC={4}", m_RWRegistry.ActivationKey, m_RWRegistry.UserName, m_RWRegistry.Email, m_strMachineName, m_strNIC);

			cKeyCommand.eErrorCodes eError = SendCommand(strCommand);

			//----------------------------------------------------------------------------*
			// If there's an error, see if we can resolve it
			//----------------------------------------------------------------------------*

			if (eError != cKeyCommand.eErrorCodes.None)
				{
				switch (eError)
					{
					case cKeyCommand.eErrorCodes.InvalidKey:
						MessageBox.Show("Your Activation Key could not be validated.", "Invalid Activation Key", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

						break;

					default:
						fOK = false;
						break;
					}
				}

			return (fOK);
			}
		}
	}
