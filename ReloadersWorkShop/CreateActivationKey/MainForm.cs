//============================================================================*
// cMainForm.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Media;
using System.Net.Mail;
using System.Windows.Forms;

using RWCommonLib.License;
using RWCommonLib.Registry;

//============================================================================*
// Namespace
//============================================================================*

namespace CreateActivationKey
	{
	//============================================================================*
	// MainForm Class
	//============================================================================*

	public partial class MainForm : Form
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cRWRegistry m_RWRegistry = null;

		private  cRWLicenseList m_RWLicenseList = null;

		private bool m_fGetKey = false;
		private bool m_fAddKey = false;

		//============================================================================*
		// MainForm() - Constructor
		//============================================================================*

		public MainForm(cRWRegistry RWRegistry)
			{
			InitializeComponent();

			m_RWRegistry = RWRegistry;

			NameTextBox.TextChanged += OnNameChanged;
			EmailTextBox.TextChanged += OnEmailChanged;
			VersionTextBox.TextChanged += OnVersionChanged;

			GetKeyButton.Click += OnGetKeyClicked;
			SendButton.Click += OnSendClicked;
			AddLicenseButton.Click += OnAddClicked;
			CloseButton.Click += OnCloseClicked;

			VersionTextBox.Value = RWRegistry.Version;
			NameTextBox.Value = "Cody Beebe";
			EmailTextBox.Value = "Cody@TeamBeebe.com";

			UpdateButtons();
			}

		//============================================================================*
		// OnAddClicked()
		//============================================================================*

		protected void OnAddClicked(Object sender, EventArgs e)
			{
			cRWLicenseCommands RWLicenseCommands = new cRWLicenseCommands();

			string strKey = KeyLabel.Text;

			cKeyCommand.eErrorCodes eErrorCode = RWLicenseCommands.AddLicense(NameTextBox.Value, EmailTextBox.Value, strKey);

			if (eErrorCode == cKeyCommand.eErrorCodes.None)
				{
				LicenseCountLabel.Text = "License Added Successfully!";

				m_fAddKey = true;

				m_RWLicenseList = null;

				eErrorCode = RWLicenseCommands.GetLicenseList(NameTextBox.Value, EmailTextBox.Value, strKey, out m_RWLicenseList);

				if (eErrorCode == cKeyCommand.eErrorCodes.None)
					{
					LicenseCountLabel.Text = String.Format("{0:G0} current licenses", m_RWLicenseList.Count);

					AdditionalLicenseCheckBox.Checked = m_RWLicenseList.Count > 1;
					}
				else
					{
					LicenseCountLabel.Text = String.Format("Error {0} encountered during GetLicenseList() operation.", cKeyCommand.ErrorString(eErrorCode));
					}
				}
			else
				LicenseCountLabel.Text = String.Format("Error {0} Adding License!", eErrorCode);

			if (m_RWLicenseList.Count > 1)
				AdditionalLicenseCheckBox.Checked = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnCloseClicked()
		//============================================================================*

		protected void OnCloseClicked(Object sender, EventArgs e)
			{
			Close();
			}

		//============================================================================*
		// OnEmailChanged()
		//============================================================================*

		protected void OnEmailChanged(Object sender, EventArgs e)
			{
			KeyLabel.Text = "";
			ValidatedLabel.Text = "";

			LicenseCountLabel.Text = "";

			m_fGetKey = false;
			m_fAddKey = false;

			UpdateButtons();
			}

		//============================================================================*
		// OnGetKeyClicked()
		//============================================================================*

		protected void OnGetKeyClicked(Object sender, EventArgs e)
			{
			bool fValidKey = true;

			string strKey = cRWRegistry.CreateKey(NameTextBox.Value, EmailTextBox.Value, VersionTextBox.Value);

			if (string.IsNullOrEmpty(strKey))
				KeyLabel.Text = "Invalid Parms!";
			else
				{
				KeyLabel.Text = strKey;

				if (cRWRegistry.ValidateKey(strKey, NameTextBox.Value, EmailTextBox.Value, VersionTextBox.Value))
					ValidatedLabel.Text = " (Validated)";
				else
					{
					ValidatedLabel.Text = " (NOT VALID!!)";

					fValidKey = false;
					}
				}

			if (fValidKey)
				{
				cRWLicenseCommands RWLicenseCommands = new cRWLicenseCommands();

				m_RWLicenseList = null;

				cKeyCommand.eErrorCodes eErrorCode = RWLicenseCommands.GetLicenseList(NameTextBox.Value, EmailTextBox.Value, strKey, out m_RWLicenseList);

				if (eErrorCode == cKeyCommand.eErrorCodes.None)
					{
					LicenseCountLabel.Text = String.Format("{0:G0} current licenses", m_RWLicenseList.Count);

					if (m_RWLicenseList.Count > 0)
						AdditionalLicenseCheckBox.Checked = true;

					m_fGetKey = true;
					}
				else
					{
					LicenseCountLabel.Text = String.Format("Error {0} encountered during GetLicenseList() operation.", cKeyCommand.ErrorString(eErrorCode));
					}
				}

			UpdateButtons();
			}

		//============================================================================*
		// OnNameChanged()
		//============================================================================*

		protected void OnNameChanged(Object sender, EventArgs e)
			{
			KeyLabel.Text = "";
			ValidatedLabel.Text = "";

			LicenseCountLabel.Text = "";

			m_fGetKey = false;
			m_fAddKey = false;

			UpdateButtons();
			}

		//============================================================================*
		// OnSendClicked()
		//============================================================================*

		protected void OnSendClicked(Object sender, EventArgs args)
			{
			try
				{
				MailMessage Email = new MailMessage();
				Email.From = new MailAddress("Sales@ReloadersWorkShop.com");

				Email.To.Add(EmailTextBox.Value);
				Email.Bcc.Add("Sales@ReloadersWorkShop.com");

				Email.Subject = "Reloader's WorkShop Activation Key";

				Email.Body = String.Format("Hello {0},\n\n", NameTextBox.Value);

				Email.Body += "Thank you for purchasing ";

				if (AdditionalLicenseCheckBox.Checked)
					Email.Body += "an additional license to use Reloader's WorkShop! ";
				else
					Email.Body += "a license to use Reloader's WorkShop! ";

				Email.Body += "We appreciate your business. ";

				Email.Body += String.Format("You now have a license to run Reloader's WorkShop on {0:G0} computer{1}.\n\n", m_RWLicenseList.Count, m_RWLicenseList.Count > 1 ? "s" : "");

				Email.Body += "Your Activation Key and other needed information is listed below.\n\n";

				Email.Body += String.Format("Name: {0}\n", NameTextBox.Value);
				Email.Body += String.Format("Email: {0}\n", EmailTextBox.Value);
				Email.Body += String.Format("Activation Key: {0}\n\n", KeyLabel.Text);

				Email.Body += "To enter your Activation Key, click on the \"Activate\" button on the Reloader's WorkShop splash screen (with the image of my WorkBench).  This will display the Activation Key dialog.  ";
				Email.Body += "Enter your name, email, and Activation Key in the appropriate text boxes EXACTLY as they appear above (they are case sensitive) and click \"OK\".  This will begin the activation process and when it is finished, it will restart Reloader's WorkShop.\n\n";

				Email.Body += "You might find it easier to copy the information from this email and paste it into the appropriate text boxes on the Activation Key dialog.\n\n";

				Email.Body += "You should now see your name and email address displayed on the splash screen instead of the Trial Version information.  That's all there is to it!\n\n";

				Email.Body += "Retain this email and print it for your records in case you need to reinstall Reloader's WorkShop.\n\n";

				Email.Body += "By using this Activation Key you agree to be bound by the terms of the End User License Agreement that you accepted during the installation of Reloader's WorkShop.\n\n";

				Email.Body += "Thanks again! \n\nReloader's WorkShop Sales Team";

				SmtpClient SMTPServer = new SmtpClient("smtp.1and1.com");

				SMTPServer.Port = 25;
				SMTPServer.Credentials = new System.Net.NetworkCredential("Sales@ReloadersWorkShop.com", "C0dyScott");
				SMTPServer.Send(Email);

				MessageBox.Show("Mail Sent Successfully", "Mail Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

				Close();
				}
			catch (Exception e)
				{
				MessageBox.Show(e.ToString(), "Error Sending Mail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}

		//============================================================================*
		// OnVersionChanged()
		//============================================================================*

		protected void OnVersionChanged(Object sender, EventArgs e)
			{
			KeyLabel.Text = "";
			ValidatedLabel.Text = "";

			UpdateButtons();
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			bool fEnableOK = true;

			if (!VersionTextBox.ValueOK)
				fEnableOK = true;

			if (fEnableOK)
				{
				if (!NameTextBox.ValueOK)
					fEnableOK = false;
				}

			if (fEnableOK)
				{
				if (!EmailTextBox.ValueOK)
					fEnableOK = false;
				}

			if (fEnableOK)
				{
				fEnableOK = cRWRegistry.CheckParms(NameTextBox.Value, EmailTextBox.Value, VersionTextBox.Value);
				}

			if (!fEnableOK)
				{
				m_fGetKey = false;
				m_fAddKey = false;
				}

			bool fEnableSend = m_fGetKey && fEnableOK;
			bool fEnableAdd = m_fGetKey && fEnableOK;

			if (!m_fGetKey || !cRWRegistry.ValidateKey(KeyLabel.Text, NameTextBox.Value, EmailTextBox.Value, VersionTextBox.Value))
				{
				fEnableSend = false;
				fEnableAdd = false;
				}

			GetKeyButton.Enabled = !m_fGetKey;
			SendButton.Enabled = m_fGetKey && fEnableSend && m_fAddKey;
			AddLicenseButton.Enabled = !m_fAddKey && fEnableAdd;
			}
		}
	}