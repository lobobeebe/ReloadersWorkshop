//============================================================================*
// ReloadersWorkShopLauncher.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShopUpdater
	{
	//============================================================================*
	// Mainform Class
	//============================================================================*

	public partial class MainForm : Form
		{
		//============================================================================*
		// MainForm() - Constructor
		//============================================================================*

		public MainForm()
			{
			InitializeComponent();

			SetClientSizeCore(ReleaseNotesTextBox.Location.X + ReleaseNotesTextBox.Width + 12, ContinueButton.Location.Y + ContinueButton.Height + 20);

			ContinueButton.Click += OnContinueClicked;

			try
				{
				ReleaseNotesTextBox.LoadFile("ReleaseNotes.rtf");

				ReleaseNotesTextBox.Select(0, 0);
				}
			catch
				{
				ReleaseNotesTextBox.Text = "NO RELEASE NOTES AVAILABLE!";
				}
			}

		//============================================================================*
		// OnContinueClicked()
		//============================================================================*

		private void OnContinueClicked(Object sender, EventArgs args)
			{
			Process.Start(@"ReloadersWorkShopLauncher.exe", "/UPDATE");

			Close();
			}
		}
	}
