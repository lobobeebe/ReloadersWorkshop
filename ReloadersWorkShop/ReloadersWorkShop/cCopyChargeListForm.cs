//============================================================================*
// cCopyChargeListForm.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.Windows.Forms;

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cCopyChargeListForm Class
	//============================================================================*

	public partial class cCopyChargeListForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Constant Data Members
		//----------------------------------------------------------------------------*

		private const string cm_strFirearmTypeToolTip = "Type of firearm for which this load is designed.";
		private const string cm_strCaliberToolTip = "Caliber for which thisload is designed.";

		private const string cm_strBulletToolTip = "Bullet to be used for this load.";
		private const string cm_strCaseToolTip = "Case to be used for this load.";
		private const string cm_strPowderToolTip = "Powder to be used for this load.";
		private const string cm_strPrimerToolTip = "Primer to be used for this load.";

		private const string cm_strChargeListToolTip = "List of powder charges usable with the above components.";

		private const string cm_strLoadOKButtonToolTip = "Click to copy the above charge list.";
		private const string cm_strLoadCancelButtonToolTip = "Click to cancel copying the charge list.";

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private cLoad m_Load = null;

		private cDataFiles m_DataFiles;

		private cCopyChargeListView m_ChargeListView = null;

		private ToolTip m_FirearmTypeToolTip = new ToolTip();
		private ToolTip m_CaliberToolTip = new ToolTip();
		private ToolTip m_BulletToolTip = new ToolTip();
		private ToolTip m_PowderToolTip = new ToolTip();
		private ToolTip m_PrimerToolTip = new ToolTip();
		private ToolTip m_CaseToolTip = new ToolTip();

		private ToolTip m_ChargeListToolTip = new ToolTip();

		private ToolTip m_LoadOKButtonToolTip = new ToolTip();
		private ToolTip m_LoadCancelButtonToolTip = new ToolTip();

		//============================================================================*
		// cCopyChargeListForm() - Constructor
		//============================================================================*

		public cCopyChargeListForm(cLoad Load, cDataFiles DataFiles)
			{
			InitializeComponent();

			if (Load == null)
				throw (new Exception("Inavlid Load."));

			m_DataFiles = DataFiles;

			//----------------------------------------------------------------------------*
			// Get starting load info
			//----------------------------------------------------------------------------*

			m_Load = new cLoad(Load);

			FirearmTypeLabel.Text = m_Load.FirearmType == 0 ? "Handgun" : "Rifle";

			CaliberLabel.Text = m_Load.Caliber.ToString();
			BulletLabel.Text = m_Load.Bullet.ToString();
			PowderLabel.Text = m_Load.Powder.ToString();
			CaseLabel.Text = m_Load.Case.ToString();
			PrimerLabel.Text = m_Load.Primer.ToString();

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			CopyChargeListOKButton.Click += OnOKClicked;

			MatchBulletRadioButton.Click += OnMatchBulletClicked;
			MatchPrimerRadioButton.Click += OnMatchPrimerClicked;
			MatchCaseRadioButton.Click += OnMatchCaseClicked;

			//----------------------------------------------------------------------------*
			// Create Charge List View
			//----------------------------------------------------------------------------*

			m_ChargeListView = new cCopyChargeListView(m_DataFiles);

			m_ChargeListView.Location = new Point(6, FiltersGroupBox.Location.Y + FiltersGroupBox.Height + 6);
			m_ChargeListView.Size = new Size(ClientSize.Width - 12, CopyChargeListOKButton.Location.Y - FiltersGroupBox.Location.Y - FiltersGroupBox.Height - 16);

			Controls.Add(m_ChargeListView);

			m_ChargeListView.SelectedIndexChanged += OnChargeListSelected;

			SetClientSizeCore(FiltersGroupBox.Location.X + FiltersGroupBox.Width + 10, CopyChargeListCancelButton.Location.Y + CopyChargeListCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Populate Charge List view
			//----------------------------------------------------------------------------*

			PopulateChargeListView();

			UpdateButtons();
			}

		//============================================================================*
		// Load Property
		//============================================================================*

		new public cLoad Load
			{
			get { return (m_Load); }
			}

		//============================================================================*
		// OnChargeListSelected()
		//============================================================================*

		protected void OnChargeListSelected(object sender, EventArgs args)
			{
			UpdateButtons();
			}

		//============================================================================*
		// OnChargeListViewColumnWidthChanged()
		//============================================================================*

		protected void OnChargeListViewColumnWidthChanged(object sender, ColumnWidthChangedEventArgs args)
			{
			m_DataFiles.Preferences.SetColumnWidth(cPreferences.eApplicationListView.CopyChargeListView, (sender as ListView).Columns[args.ColumnIndex].Text, (sender as ListView).Columns[args.ColumnIndex].Width);
			}

		//============================================================================*
		// OnMatchBulletClicked()
		//============================================================================*

		protected void OnMatchBulletClicked(object sender, EventArgs args)
			{
			MatchBulletRadioButton.Checked = MatchBulletRadioButton.Checked ? false : true;

			PopulateChargeListView();
			}

		//============================================================================*
		// OnMatchCaseClicked()
		//============================================================================*

		protected void OnMatchCaseClicked(object sender, EventArgs args)
			{
			MatchCaseRadioButton.Checked = MatchCaseRadioButton.Checked ? false : true;

			PopulateChargeListView();
			}

		//============================================================================*
		// OnMatchPrimerClicked()
		//============================================================================*

		protected void OnMatchPrimerClicked(object sender, EventArgs args)
			{
			MatchPrimerRadioButton.Checked = MatchPrimerRadioButton.Checked ? false : true;

			PopulateChargeListView();
			}

		//============================================================================*
		// OnOKClicked()
		//============================================================================*

		private void OnOKClicked(object sender, EventArgs e)
			{
			cLoad Load = (cLoad) m_ChargeListView.SelectedItems[0].Tag;

			m_Load.ChargeList = new cChargeList(Load.ChargeList);

			foreach(cCharge Charge in m_Load.ChargeList)
				{
				while(true)
					{
					bool fTestRemoved = false;

					foreach(cChargeTest ChargeTest in Charge.TestList)
						{
						if (ChargeTest.BatchTest)
							{
							Charge.TestList.Remove(ChargeTest);

							fTestRemoved = true;

							break;
							}
						}

					if (!fTestRemoved)
						break;
					}
				}
			}

		//============================================================================*
		// PopulateChargeListView()
		//============================================================================*

		private void PopulateChargeListView()
			{
			//----------------------------------------------------------------------------*
			// ChargeListView Data
			//----------------------------------------------------------------------------*

			cFirearm.eFireArmType FirearmType = m_Load.FirearmType;
			cCaliber Caliber = m_Load.Caliber;
			cPowder Powder = m_Load.Powder;

			cBullet Bullet = MatchBulletRadioButton.Checked ? m_Load.Bullet : null;
			cPrimer Primer = MatchPrimerRadioButton.Checked ? m_Load.Primer : null;
			cCase Case = MatchCaseRadioButton.Checked ? m_Load.Case : null;

			m_ChargeListView.Populate(FirearmType, Caliber, Bullet, m_Load.Bullet.Weight, Powder, Primer, Case);

			UpdateButtons();
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;
					
			m_FirearmTypeToolTip.ShowAlways = true;
			m_FirearmTypeToolTip.RemoveAll();
			m_FirearmTypeToolTip.SetToolTip(FirearmTypeLabel, cm_strFirearmTypeToolTip);

			m_CaliberToolTip.ShowAlways = true;
			m_CaliberToolTip.RemoveAll();
			m_CaliberToolTip.SetToolTip(CaliberLabel, cm_strCaliberToolTip);

			m_BulletToolTip.ShowAlways = true;
			m_BulletToolTip.RemoveAll();
			m_BulletToolTip.SetToolTip(BulletLabel, cm_strBulletToolTip);

			m_CaseToolTip.ShowAlways = true;
			m_CaseToolTip.RemoveAll();
			m_CaseToolTip.SetToolTip(CaseLabel, cm_strCaseToolTip);

			m_PowderToolTip.ShowAlways = true;
			m_PowderToolTip.RemoveAll();
			m_PowderToolTip.SetToolTip(PowderLabel, cm_strPowderToolTip);

			m_PrimerToolTip.ShowAlways = true;
			m_PrimerToolTip.RemoveAll();
			m_PrimerToolTip.SetToolTip(PowderLabel, cm_strPowderToolTip);

			m_LoadOKButtonToolTip.ShowAlways = true;
			m_LoadOKButtonToolTip.RemoveAll();
			m_LoadOKButtonToolTip.SetToolTip(CopyChargeListOKButton, cm_strLoadOKButtonToolTip);

			m_LoadCancelButtonToolTip.ShowAlways = true;
			m_LoadCancelButtonToolTip.RemoveAll();
			m_LoadCancelButtonToolTip.SetToolTip(CopyChargeListCancelButton, cm_strLoadCancelButtonToolTip);
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			bool fEnableOK = true;

			if (m_ChargeListView.SelectedItems.Count == 0)
				fEnableOK = false;

			CopyChargeListOKButton.Enabled = fEnableOK;
			}
		}
	}
