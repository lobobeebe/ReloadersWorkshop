//============================================================================*
// Program.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Diagnostics;
using System.Windows.Forms;

//============================================================================*
// Application Specific Using Statements
//============================================================================*

using RWCommonLib.Registry;
using RWCommonLib.Updates;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShopUpdater
	{
	//============================================================================*
	// Program Class
	//============================================================================*

	static class Program
		{
		//============================================================================*
		// Main() - Entry Point for app
		//============================================================================*

		[STAThread]
		static void Main(string[] args)
			{
			bool fInstall = false;
			bool fActivate = false;

			string strName = "";
			string strEmail = "";
			string strKey = "";
			string strVersion = "";

			foreach (string strArg in args)
				{
				if (strArg.ToUpper() == "/INSTALL")
					fInstall = true;

				if (strArg.ToUpper() == "/ACTIVATE")
					fActivate = true;

				if (strArg.Length > 6 && strArg.Substring(0, 6).ToUpper() == "/NAME=")
					strName = strArg.Substring(6);

				if (strArg.Length > 7 && strArg.Substring(0, 7).ToUpper() == "/EMAIL=")
					strEmail = strArg.Substring(7);

				if (strArg.Length > 5 && strArg.Substring(0, 5).ToUpper() == "/KEY=")
					strKey = strArg.Substring(5);

				if (strArg.Length > 9 && strArg.Substring(0, 9).ToUpper() == "/VERSION=")
					strVersion = strArg.Substring(9);
				}

			//----------------------------------------------------------------------------*
			// Create the RWRegistry object
			//----------------------------------------------------------------------------*

			cRWRegistry RWRegistry = new cRWRegistry();

			RWRegistry.UpdateVersion();

			//----------------------------------------------------------------------------*
			// If this is just an install operation, setup the registry if needed
			//----------------------------------------------------------------------------*

			if (fInstall || RWRegistry.FreshInstall)
				{
				//----------------------------------------------------------------------------*
				// Setup the initial Registry entries
				//----------------------------------------------------------------------------*

				RWRegistry.SetupRegistry(fInstall);

				//----------------------------------------------------------------------------*
				// Start the launcher and exit
				//----------------------------------------------------------------------------*

				Process.Start("ReloadersWorkShopLauncher.exe");

				return;
				}

			//----------------------------------------------------------------------------*
			// If this is an activate operation, setup the activation entries
			//----------------------------------------------------------------------------*

			if (fActivate)
				{
				//----------------------------------------------------------------------------*
				// Set the registry entries
				//----------------------------------------------------------------------------*

				RWRegistry.Activate(strKey, strName, strEmail, strVersion);

				//----------------------------------------------------------------------------*
				// Start the launcher and exit
				//----------------------------------------------------------------------------*

				Process.Start("ReloadersWorkShopLauncher.exe");

				return;
				}

			//----------------------------------------------------------------------------*
			// Check to see if it's a trial version and if it is, check to see if it's expired
			//----------------------------------------------------------------------------*
/*
			if (RWRegistry.Trial && RWRegistry.TrialExpired)
				{
				Process.Start("ReloadersWorkShopLauncher.exe");

				return;
				}
*/
			//----------------------------------------------------------------------------*
			// Check for updates
			//----------------------------------------------------------------------------*

			cRWUpdater RWUpdater = new cRWUpdater();

			if (!RWUpdater.UpdateFiles())
				Process.Start("ReloadersWorkShopLauncher.exe");

			//----------------------------------------------------------------------------*
			// If updates were successful, show the release notes
			//----------------------------------------------------------------------------*

			else
				{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
				}
			}
		}
	}
