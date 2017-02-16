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
using System.IO;
using System.Threading;
using System.Windows.Forms;

using RWCommonLib.Registry;
using RWCommonLib.Updates;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShopLauncher
	{
	//============================================================================*
	// Program Class
	//============================================================================*

	class Program
		{
		//============================================================================*
		// Main()
		//============================================================================*

		[STAThread]
		static void Main(string[] args)
			{
			bool fUpdate = false;

			foreach (string strArg in args)
				{
				if (strArg.ToUpper() == "/UPDATE")
					fUpdate = true;
				}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			//----------------------------------------------------------------------------*
			// See if the ReloadersWorkShopLauncher is already running
			//----------------------------------------------------------------------------*

			bool fMutexCreated = true;

			using (Mutex ThisMutex = new Mutex(true, "ReloadersWorkShopLauncher", out fMutexCreated))
				{
				//----------------------------------------------------------------------------*
				// Not running, continue
				//----------------------------------------------------------------------------*

				if (fMutexCreated)
					{
					//----------------------------------------------------------------------------*
					// See if ReloadersWorkShop is already running
					//----------------------------------------------------------------------------*

					using (Mutex RWMutex = new Mutex(true, "ReloadersWorkShop", out fMutexCreated))
						{
						//----------------------------------------------------------------------------*
						// If it is, bring the current instance to the foreground
						//----------------------------------------------------------------------------*

						if (!fMutexCreated)
							{
							Process[] aProcesses = Process.GetProcessesByName("ReloadersWorkShop");

							if (aProcesses.Length > 0)
								NativeMethods.SetForegroundWindow(aProcesses[0].MainWindowHandle);
							}

						//----------------------------------------------------------------------------*
						// Otherwise, it's ok to run the launcher
						//----------------------------------------------------------------------------*

						else
							{
							//----------------------------------------------------------------------------*
							// Update ReloadersWorkShopUpdater.exe if needed
							//----------------------------------------------------------------------------*

							if (fUpdate)
								{
								if (File.Exists("ReloadersWorkShopUpdater.upd"))
									{
									try
										{
										if (File.Exists("ReloadersWorkShopUpdater.exe"))
											File.Delete("ReloadersWorkShopUpdater.exe");

										File.Move("ReloadersWorkShopUpdater.upd", "ReloadersWorkShopUpdater.exe");
										}

									catch
										{
										}
									}
								}

							//----------------------------------------------------------------------------*
							// Check for updates
							//----------------------------------------------------------------------------*

							cRWRegistry RWRegistry = new cRWRegistry();

							bool fUpdating = false;

							if (!RWRegistry.Trial || !RWRegistry.TrialExpired)
								fUpdating = CheckForUpdates();

							//----------------------------------------------------------------------------*
							// If we're not updating, check the registry
							//----------------------------------------------------------------------------*

							if (!fUpdating)
								{
								//----------------------------------------------------------------------------*
								// See if this is a fresh install
								//----------------------------------------------------------------------------*

								if (RWRegistry.FreshInstall)
									{
									Process.Start("ReloadersWorkShopUpdater.exe", "/INSTALL");

									return;
									}

								//----------------------------------------------------------------------------*
								// Make sure the registry has not been tampered with
								//----------------------------------------------------------------------------*

								if (RWRegistry.InvalidRegistry)
									{
									MessageBox.Show("The registry entries for Reloader's WorkShop are either corrupted or have been tampered with and needs to be repaired.  You will need to reenter your Activation Key and other info.", "Corrupted Registry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

									Process.Start("ReloadersWorkShopUpdater.exe", "/INSTALL");

									return;
									}

								//----------------------------------------------------------------------------*
								// See if this is a Trial Version and check the date if it is
								//----------------------------------------------------------------------------*

								if (!RWRegistry.Trial && !RWRegistry.ValidateKey())
									{
									MessageBox.Show("Your Activation Key is not valid.  You will need to reenter your Activation Key and other info.", "Invalid Activation Key", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

									Process.Start("ReloadersWorkShopUpdater.exe", "/INSTALL");

									return;
									}

								//----------------------------------------------------------------------------*
								// Check the license info
								//----------------------------------------------------------------------------*
/*
								cRWLicense RWLicense = new cRWLicense();

								if (!RWLicense.ValidateLicense())
									return;
*/
								//----------------------------------------------------------------------------*
								// If we get to here, everything is good to go, start the Main Form
								//----------------------------------------------------------------------------*

								Application.Run(new cMainForm(RWRegistry));
								}
							}
						}
					}

				//----------------------------------------------------------------------------*
				// Launcher already running, bring the currently running window to the foreground
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

		//============================================================================*
		// CheckForUpdates()
		//============================================================================*

		static bool CheckForUpdates()
			{
			bool fUpdating = false;

			try
				{
				//----------------------------------------------------------------------------*
				// Check for updates
				//----------------------------------------------------------------------------*

				cRWUpdater RWUpdater = new cRWUpdater();

				if (RWUpdater.UpdatesAvailable)
					{
					DialogResult rc = MessageBox.Show("A newer version of Reloader's WorkShop is available.\n\nUpdate now?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

					if (rc == DialogResult.Yes)
						{
						Process.Start(@"ReloadersWorkShopUpdater.exe");

						fUpdating = true;
						}
					}
				}

			catch
				{
				fUpdating = false;
				}

			return (fUpdating);
			}
		}
	}
