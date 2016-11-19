//============================================================================*
// cRWUpdater.cs
//
// Copyright © 2013-2015, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

//============================================================================*
// NameSpace
//============================================================================*

namespace RWCommonLib.Updates
	{
	//============================================================================*
	// cRWUpdater Class
	//============================================================================*

	public class cRWUpdater
		{
		//============================================================================*
		// Private Constant Data Members
		//============================================================================*

		private const string cm_strURLFormat = "https://www.ReloadersWorkShop.com/RWUpdates/RWV{0}/";

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private string m_strURL = null;

		private string[] m_astrFileNames = new string[]
			{
			"ReloadersWorkShopUpdater.exe",
			"ReloadersWorkShop.exe",
			"ReloadersWorkShopLauncher.exe",
			"RWCommonLib.dll",
			"CommonLib.dll",
            "interop.WIA.dll",
			"ReleaseNotes.rtf"
			};

		//============================================================================*
		// cRWUpdater() - Constructor
		//============================================================================*

		public cRWUpdater()
			{
			string strVersion = Application.ProductVersion.Substring(0, 1);

			if (strVersion == "0")
				strVersion += Application.ProductVersion[2];

			m_strURL = String.Format(cm_strURLFormat, strVersion);
			}

		//============================================================================*
		// AcceptAllCertifications()
		//============================================================================*
		public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
			{
			return (true);
			}

		//============================================================================*
		// UpdateAvailable()
		//============================================================================*

		public bool UpdateAvailable(string strFileName, string strPath = @".\")
			{
			if (string.IsNullOrEmpty(strFileName))
				return (false);

			bool fUpdateAvailable = false;

			string strURL = m_strURL + strFileName;

			string strFilePath = Path.Combine(strPath, strFileName);

			HttpWebRequest Request = null;
			HttpWebResponse Response = null;

			try
				{
				Request = (HttpWebRequest) WebRequest.Create(strURL);
				Request.Method = "HEAD";

				Response = (HttpWebResponse) Request.GetResponse();

				string strModifiedDate = Response.Headers.Get("Last-Modified");

				DateTime NetFileDate;

				DateTime.TryParse(strModifiedDate, out NetFileDate);

				if (File.Exists(strFilePath))
					{
					DateTime LocalFileDate = File.GetLastWriteTime(strFilePath);

					if (NetFileDate > LocalFileDate)
						fUpdateAvailable = true;
					}
				else
					fUpdateAvailable = true;
				}
			catch
				{
				fUpdateAvailable = false;
				}
			finally
				{
				if (Response != null)
					Response.Close();
				}

			return (fUpdateAvailable);
			}

		//============================================================================*
		// UpdateFile()
		//============================================================================*

		public bool UpdateFile(string strFileName, string strOutputPath = @".\")
			{
			//----------------------------------------------------------------------------*
			// Verify Input Parms
			//----------------------------------------------------------------------------*

			if (string.IsNullOrEmpty(strFileName))
				return (false);

			//----------------------------------------------------------------------------*
			// Initialize variables
			//----------------------------------------------------------------------------*

			bool fSuccess = true;

			string strURL = m_strURL + strFileName;

			string strFilePath = Path.Combine(strOutputPath, strFileName);

			string strBackupFilePath = Path.ChangeExtension(strFileName, "bak");
			strBackupFilePath = Path.Combine(strOutputPath, strBackupFilePath);

			string strUpdateFilePath = Path.ChangeExtension(strFileName, "upd");
			strUpdateFilePath = Path.Combine(strOutputPath, strUpdateFilePath);

			WebClient Client = new WebClient();

			//----------------------------------------------------------------------------*
			// Begin the try block
			//----------------------------------------------------------------------------*

			try
				{
				//----------------------------------------------------------------------------*
				// Get rid of an orphaned upd file if needed
				//----------------------------------------------------------------------------*

				if (File.Exists(strUpdateFilePath))
					File.Delete(strUpdateFilePath);

				//----------------------------------------------------------------------------*
				// Download the file
				//----------------------------------------------------------------------------*

				Client.DownloadFile(strURL, strUpdateFilePath);

				//----------------------------------------------------------------------------*
				// Get rid of the old backup file
				//----------------------------------------------------------------------------*

				if (File.Exists(strBackupFilePath))
					File.Delete(strBackupFilePath);

				//----------------------------------------------------------------------------*
				// If the file isn't this executable, rename it to the requested file name
				//----------------------------------------------------------------------------*

				if (System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName != strFileName)
					{
					//----------------------------------------------------------------------------*
					// Copy the old file to the backup and rename the new file
					//----------------------------------------------------------------------------*

					if (File.Exists(strFilePath))
						File.Move(strFilePath, strBackupFilePath);

					File.Move(strUpdateFilePath, strFilePath);
					}
				}
			catch
				{
				fSuccess = false;
				}
			finally
				{
				//----------------------------------------------------------------------------*
				// Clean up after ourselves
				//----------------------------------------------------------------------------*

				if (Client != null)
					Client.Dispose();

				//----------------------------------------------------------------------------*
				// If we didn't get the requested file, rename the backup back to the file name
				//----------------------------------------------------------------------------*

				try
					{
					if (File.Exists(strBackupFilePath) && !File.Exists(strFilePath))
						File.Move(strBackupFilePath, strFilePath);
					}
				catch { }
				}

			return (fSuccess);
			}

		//============================================================================*
		// UpdateFiles()
		//============================================================================*

		public bool UpdateFiles()
			{
			bool fSuccess = true;

			foreach (string strFileName in m_astrFileNames)
				{
				//----------------------------------------------------------------------------*
				// Check if update is available
				//----------------------------------------------------------------------------*

				if (UpdateAvailable(strFileName))
					{
					fSuccess = UpdateFile(strFileName);

					if (!fSuccess)
						break;
					}
				}

			return (fSuccess);
			}

		//============================================================================*
		// UpdatesAvailable Property
		//============================================================================*

		public bool UpdatesAvailable
			{
			get
				{
				bool fUpdatesAvailable = false;

				//----------------------------------------------------------------------------*
				// Loop through the file names
				//----------------------------------------------------------------------------*

				foreach (string strFileName in m_astrFileNames)
					{
					if (UpdateAvailable(strFileName))
						{
						fUpdatesAvailable = true;

						break;
						}
					}

				return (fUpdatesAvailable);
				}
			}
/*
		//============================================================================*
		// UserID Property
		//============================================================================*

		static private string UserID
			{
			get
				{
				string strUserID = "u";

				strUserID += (char) ('7' + 1);
				strUserID += (char) ('1' + 1);
				strUserID += (char) ('8' + 1);
				strUserID += '1';
				strUserID += (char) ('7' + 1);
				strUserID += (char) ('7' + 1);
				strUserID += (char) ('4' + 1);
				strUserID += '1';

				return (strUserID);
				}
			}

		//============================================================================*
		// Password Property
		//============================================================================*

		static private string Password
			{
			get
				{
				string strPassword = "N";
				strPassword += '1';
				strPassword += (char) ('b' + 1);
				strPassword += (char) ('g' + 1);
				strPassword += (char) ('n' + 1);
				strPassword += (char) ('k' + 1);
				strPassword += 'a';
				strPassword += (char) ('r' + 1);

				return (strPassword);
				}
			}
*/		}
	}
