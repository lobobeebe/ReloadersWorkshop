//============================================================================*
// cPurchaseKeyForm.cs
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

//============================================================================*
// Namespace
//============================================================================*

namespace RWCommonLib.Forms
	{
	//============================================================================*
	// cPurchaseKeyForm Class
	//============================================================================*

	public partial class cPurchaseKeyForm : Form
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cRWRegistry m_RWRegistry = null;

		//============================================================================*
		// cPurchaseKeyForm() - Constructor
		//============================================================================*

		public cPurchaseKeyForm(cRWRegistry RWRegistry)
			{
			InitializeComponent();

			m_RWRegistry = RWRegistry;

			SetClientSizeCore(BuyItNowGroup.Location.X + BuyItNowGroup.Width + 10, BuyItNowGroup.Location.Y + BuyItNowGroup.Height + 20);

			BuyNowButton.Click += OnBuyClicked;
			}

		//============================================================================*
		// OnBuyClicked()
		//============================================================================*

		private void OnBuyClicked(Object sender, EventArgs e)
			{
			if (!m_RWRegistry.Trial && m_RWRegistry.ValidateKey())
				Process.Start(@"https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=4WEFAN2YP56AA");
			else
				Process.Start(@"https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=QN48YFMCYZLR8");
			}
		}
	}
