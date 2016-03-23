//============================================================================*
// cActivationForm.cs
//
// Copyright © 20115, Kevin S. Beebe
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
			bool fEnableOK = cRWRegistry.ValidateKey(KeyTextBox.Value, NameTextBox.Value, EmailTextBox.Value,  Application.ProductVersion);

			OKButton.Enabled = fEnableOK;
			}
		}
	}
