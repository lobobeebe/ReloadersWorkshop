//============================================================================*
// cActivationForm.cs
//
// Copyright © 2015-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Diagnostics;
using System.Windows.Forms;

using RWCommonLib.Registry;
using RWCommonLib.Forms;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShopLauncher
	{
	//============================================================================*
	// cActivationForm Class
	//============================================================================*

	public partial class cActivationForm : Form
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		cRWRegistry m_RWRegistry = null;

		//============================================================================*
		// cActivationForm() - Constructor
		//============================================================================*

		public cActivationForm(cRWRegistry RWRegistry)
			{
			InitializeComponent();

			m_RWRegistry = RWRegistry;

			SetClientSizeCore(KeyGroup.Location.X + KeyGroup.Width + 10, PurchaseGroup.Location.Y + PurchaseGroup.Height + 20);

			NameTextBox.TextChanged += OnDataChanged;
			EmailTextBox.TextChanged += OnDataChanged;
			KeyTextBox.TextChanged += OnDataChanged;

			OKButton.Click += OnOKClicked;
			PurchaseButton.Click += OnPurchaseClicked;

			UpdateButtons();
			}

		//============================================================================*
		// OnDataChanged()
		//============================================================================*

		private void OnDataChanged(Object sender, EventArgs e)
			{
			UpdateButtons();
			}

		//============================================================================*
		// OnOKClicked()
		//============================================================================*

		private void OnOKClicked(Object sender, EventArgs e)
			{
			string strArgs = String.Format("/ACTIVATE /NAME=\"{0}\" /EMAIL={1} /KEY={2} /VERSION={3}", NameTextBox.Value, EmailTextBox.Value, KeyTextBox.Value, Application.ProductVersion);

			Process.Start(@"ReloadersWorkShopUpdater.exe", strArgs);

			Close();
			}

		//============================================================================*
		// OnPurchaseClicked()
		//============================================================================*

		private void OnPurchaseClicked(Object sender, EventArgs e)
			{
			cPurchaseKeyForm PurchaseForm = new cPurchaseKeyForm(m_RWRegistry);

			PurchaseForm.ShowDialog();
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			bool fEnableOK = true;

			//----------------------------------------------------------------------------*
			// Get entered data
			//----------------------------------------------------------------------------*

			string strKey = KeyTextBox.Value;
			string strName = NameTextBox.Value;
			string strEmail = EmailTextBox.Value;

			//----------------------------------------------------------------------------*
			// Check the Name
			//----------------------------------------------------------------------------*

			if (strName.Length == 0)
				{
				ErrorLabel.Text = "Name must not be left blank";

				fEnableOK = false;
				}

			if (fEnableOK)
				{
				bool fUpper = false;
				bool fLower = false;
				bool fNonChar = false;

				foreach (char chChar in strName)
					{
					if (!Char.IsLetter(chChar) && chChar != ' ' && chChar != '\'' && chChar != '&' && chChar != '-' && chChar != ',')
						fNonChar = true;

					if (Char.IsLower(chChar))
						fLower = true;

					if (Char.IsUpper(chChar))
						fUpper = true;
					}

				if (fNonChar)
					{
					ErrorLabel.Text = "Invalid character in Name.";

					fEnableOK = false;
					}

				if (fEnableOK && ((fUpper && !fLower) || (!fUpper && fLower) || (!fUpper && !fLower)))
					{
					ErrorLabel.Text = "Name must be upper/lower case as it appears on the email you received.";

					fEnableOK = false;
					}
				}

			//----------------------------------------------------------------------------*
			// Check the Email
			//----------------------------------------------------------------------------*

			if (fEnableOK)
				{
				if (strEmail.Length == 0)
					{
					ErrorLabel.Text = "Email must not be left blank";

					fEnableOK = false;
					}

				if (strEmail.IndexOf('@') < 0 || strEmail.IndexOf('.') < 0)
					{
					ErrorLabel.Text = "Invalid Email Address";

					fEnableOK = false;
					}
				}

			//----------------------------------------------------------------------------*
			// Check the Key
			//----------------------------------------------------------------------------*

			if (fEnableOK)
				{
				fEnableOK = cRWRegistry.ValidateKey(KeyTextBox.Value, NameTextBox.Value, EmailTextBox.Value, Application.ProductVersion);

				if (!fEnableOK)
					{
					ErrorLabel.Text = "This name, email, and key combination is not valid.";

					fEnableOK = false;
					}
				}

			ErrorLabel.Visible = !fEnableOK;

			OKButton.Enabled = fEnableOK;
			}
		}
	}
