//============================================================================*
// ReloadersWorkShopProgram.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// ReloadersWorkShopProgram Class
	//============================================================================*

	class ReloadersWorkShopProgram
		{
		//============================================================================*
		// Main()
		//============================================================================*

		[STAThread]
		static void Main(string[] args)
			{
			//----------------------------------------------------------------------------*
			// Set Application Properties
			//----------------------------------------------------------------------------*

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			//----------------------------------------------------------------------------*
			// Get the command line arguments
			//----------------------------------------------------------------------------*

			bool fDev = false;
			string strGUID = "";

			foreach (string strArg in args)
				{
				if (strArg.ToUpper() == "/DEV")
					fDev = true;

				if (strArg.Length > 6 && strArg.ToUpper().Substring(0, 6) == "/GUID=")
					strGUID = strArg.Substring(6);
				}

			//----------------------------------------------------------------------------*
			// Make sure the correct GUID has been sent
			//----------------------------------------------------------------------------*

			if (strGUID == null || strGUID != "1aa3257d-fa44-4f49-9546-076b2385cd35")
				{
				MessageBox.Show(String.Format("You must use the launcher to start {0}.  You can not execute it directly.", Application.ProductName), "Execution Out of Order", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				return;
				}
				
			//----------------------------------------------------------------------------*
			// See if we're already running
			//----------------------------------------------------------------------------*

			bool fCreateNew = true;

			using (Mutex mutex = new Mutex(true, "ReloadersWorkShop", out fCreateNew))
				{
				//----------------------------------------------------------------------------*
				// Not running, continue normally
				//----------------------------------------------------------------------------*

				if (fCreateNew)
					{
					//----------------------------------------------------------------------------*
					// Start the Application
					//----------------------------------------------------------------------------*

					try
						{
						Application.Run(new cMainForm(fDev));
						}
					catch (Exception e)
						{
						MessageBox.Show(e.Message, "Exception in Reloader's Work Shop!", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}

				//----------------------------------------------------------------------------*
				// Already running, bring the currently running version to the foreground
				//----------------------------------------------------------------------------*

				else
					{
					Process CurrentProcess = Process.GetCurrentProcess();

					Process[] aProcesses = Process.GetProcessesByName(CurrentProcess.ProcessName);

					foreach (Process CheckProcess in aProcesses)
						{
						if (CheckProcess.Id != CurrentProcess.Id)
							{
							NativeMethods.SetForegroundWindow(CheckProcess.MainWindowHandle);

							break;
							}
						}
					}
				}
			}
		}
	}

