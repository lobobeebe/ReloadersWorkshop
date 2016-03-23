//============================================================================*
// cReleaseNotesForm.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.IO;
using System.Windows.Forms;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// Mainform Class
	//============================================================================*

	public partial class cReleaseNotesForm : Form
		{
		//============================================================================*
		// MainForm() - Constructor
		//============================================================================*

		public cReleaseNotesForm()
			{
			InitializeComponent();

			SetClientSizeCore(ReleaseNotesTextBox.Location.X + ReleaseNotesTextBox.Width + 10, ContinueButton.Location.Y + ContinueButton.Height + 20);

			GetReleaseNotes();
			}

		//============================================================================*
		// GetReleaseNotes()
		//============================================================================*

		private void GetReleaseNotes()
			{
			try
				{
				ReleaseNotesTextBox.LoadFile("ReleaseNotes.rtf");

				ReleaseNotesTextBox.Select(0,0);
				}
			catch
				{
				ReleaseNotesTextBox.Text = "NO RELEASE NOTES AVAILABLE!";
				}
			}
		}
	}
