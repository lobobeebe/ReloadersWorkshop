//============================================================================*
// cMainForm.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using RWCommonLib.Registry;

//============================================================================*
// Application Specific Using Statements
//============================================================================*

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShopLauncher
	{
	//============================================================================*
	// cMainForm Class
	//============================================================================*

	public partial class cMainForm : Form
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		string m_strGUID = "1aa3257d-fa44-4f49-9546-076b2385cd35";

		cRWRegistry m_RWRegistry = null;

		//============================================================================*
		// cMainForm() - Constructor
		//============================================================================*

		public cMainForm(cRWRegistry RWRegistry)
			{
			InitializeComponent();

			m_RWRegistry = RWRegistry;

			//----------------------------------------------------------------------------*
			// Make sure we're not minimized
			//----------------------------------------------------------------------------*

			if (WindowState == FormWindowState.Minimized)
				WindowState = FormWindowState.Normal;

			NativeMethods.SetForegroundWindow(this.Handle);

			//----------------------------------------------------------------------------*
			// Position the buttons
			//----------------------------------------------------------------------------*

			SetClientSizeCore(800, 450);

			int nLeft = ContinueButton.Location.X;
			int nRight = ExitButton.Location.X + ExitButton.Size.Width;
			int nWidth = nRight - nLeft;
			int nCenterLeft = 400 - (nWidth / 2);

			ContinueButton.Location = new Point(nCenterLeft, 384);
			ActivateButton.Location = new Point(400 - (ActivateButton.Width / 2), 384);
			ExitButton.Location = new Point(400 + (400 - nCenterLeft) - ExitButton.Size.Width, 384);

			SetRegistrationInfo();

			Bitmap WorkShop = Properties.Resources.WorkShop;

			BackgroundImageLayout = ImageLayout.Stretch;
			BackgroundImage = WorkShop;

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			ActivateButton.Click += OnActivateClicked;
			ContinueButton.Click += OnContinueClicked;
			ExitButton.Click += OnExitClicked;
			}

		//============================================================================*
		// OnActivateClicked()
		//============================================================================*

		protected void OnActivateClicked(object Sender, EventArgs Args)
			{
			cActivationForm ActivateForm = new cActivationForm(m_RWRegistry);

			if (ActivateForm.ShowDialog() == DialogResult.OK)
				Close();
			}

		//============================================================================*
		// OnPaint()
		//============================================================================*

		protected override void OnPaint(PaintEventArgs e)
			{
			base.OnPaint(e);

			Bitmap Title = Properties.Resources.Title;

			e.Graphics.DrawImage(Title, new Rectangle((ClientSize.Width / 2) - 450, 50, 900, 150));
			}

		//============================================================================*
		// OnContinueClicked()
		//============================================================================*

		protected void OnContinueClicked(object Sender, EventArgs Args)
			{
			string strArgs = "/GUID=" + m_strGUID;

			Process.Start(@"ReloadersWorkShop.exe", strArgs);

			Close();
			}

		//============================================================================*
		// OnExitClicked()
		//============================================================================*

		protected void OnExitClicked(Object Sender, EventArgs Args)
			{
			Close();
			}

		//============================================================================*
		// SetRegistrationInfo()
		//============================================================================*

		private void SetRegistrationInfo()
			{
			RegistrationLabel.Text = m_RWRegistry.ActivationStatusString;

			RegistrationLabel.BackColor = (m_RWRegistry.Trial ? Color.Red : Color.LightBlue);
			RegistrationLabel.ForeColor = (m_RWRegistry.Trial ? Color.Yellow : Color.Blue);

			RegistrationLabel.Location = new Point(400 - (RegistrationLabel.Width / 2), 350);

			CopyrightLabel.Location = new Point(400 - (CopyrightLabel.Width / 2), 150);

			//----------------------------------------------------------------------------*
			// If it's not a trial version, hide the Activate button
			//----------------------------------------------------------------------------*

			if (!m_RWRegistry.Trial)
				ActivateButton.Visible = false;
			else
				{
				if (m_RWRegistry.TrialExpired)
					ContinueButton.Visible = false;
				}

			//----------------------------------------------------------------------------*
			// Set the title text
			//----------------------------------------------------------------------------*

			Text = String.Format("{0} - v{1}", Application.ProductName, Application.ProductVersion);

			if (m_RWRegistry.Trial)
				Text += " - Trial";
			}
		}
	}
