//============================================================================*
// cLoadForm.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
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
	// cLoadForm Class
	//============================================================================*

	public partial class cLoadForm : Form
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

		private const string cm_strAddChargeToolTip = "Add a new powder charge for this load.";
		private const string cm_strEditChargeToolTip = "Edit the selected powder charge.";
		private const string cm_strRemoveChargeToolTip = "Remove the selected powder charge.";
		private const string cm_strCopyChargeListToolTip = "Copy Charge Data from an existing Load.";

		private const string cm_strLoadOKButtonToolTip = "Click to add or update the load with the above data.";
		private const string cm_strLoadCancelButtonToolTip = "Click to cancel changes and return to the main window.";

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private cChargeListView m_ChargeListView = null;

		private bool m_fInitialized = false;
		private bool m_fPopulating = false;

		private cLoad m_Load = null;
		private cLoad m_OriginalLoad = null;

		private cDataFiles m_DataFiles;

		private bool m_fUserViewOnly = false;
		private bool m_fViewOnly = false;

		private Image m_CartridgeBitmap = null;
		private Image m_CartridgeDimensionsBitmap = null;

		private bool m_fChanged = false;
		private bool m_fAdd = false;

		private Bitmap m_BulletBitmap = null;

		private ToolTip m_FirearmTypeToolTip = new ToolTip();
		private ToolTip m_CaliberToolTip = new ToolTip();
		private ToolTip m_BulletToolTip = new ToolTip();
		private ToolTip m_PowderToolTip = new ToolTip();
		private ToolTip m_PrimerToolTip = new ToolTip();
		private ToolTip m_CaseToolTip = new ToolTip();

		private ToolTip m_ChargeListToolTip = new ToolTip();

		private ToolTip m_AddChargeToolTip = new ToolTip();
		private ToolTip m_EditChargeToolTip = new ToolTip();
		private ToolTip m_RemoveChargeToolTip = new ToolTip();
		private ToolTip m_CopyChargeListToolTip = new ToolTip();

		private ToolTip m_LoadOKButtonToolTip = new ToolTip();
		private ToolTip m_LoadCancelButtonToolTip = new ToolTip();

		//============================================================================*
		// cLoadForm() - Constructor
		//============================================================================*

		public cLoadForm(cLoad Load, cDataFiles DataFiles, bool fViewOnly = false)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;
			m_fUserViewOnly = fViewOnly;
			m_fViewOnly = fViewOnly;

			//----------------------------------------------------------------------------*
			// Get starting load info
			//----------------------------------------------------------------------------*

			if (Load == null)
				{
				m_fAdd = true;

				if (m_fViewOnly)
					return;

				if (m_DataFiles.Preferences.LastLoad == null)
					m_Load = new cLoad();
				else
					{
					m_Load = new cLoad(m_DataFiles.Preferences.LastLoad);

					m_Load.Checked = false;
					m_Load.Bullet = null;
					m_Load.Powder = null;
					m_Load.Case = null;
					m_Load.Primer = null;

					m_Load.ChargeList.Clear();
					}

				Text = "Add Load";

				LoadOKButton.Text = "Add";
				}
			else
				{
				m_Load = new cLoad(Load);
				m_OriginalLoad = new cLoad(Load);

				//----------------------------------------------------------------------------*
				// Setup Update and Cancel Buttons
				//----------------------------------------------------------------------------*

				if (!m_fViewOnly)
					{
					Text = "Edit Load";

					LoadOKButton.Text = "Update";
					}
				else
					{
					Text = "View Load";

					LoadOKButton.Visible = false;

					int nButtonX = (this.Size.Width / 2) - (LoadCancelButton.Width / 2);

					LoadCancelButton.Location = new Point(nButtonX, LoadCancelButton.Location.Y);

					LoadCancelButton.Text = "Close";
					}
				}

			SetClientSizeCore(GeneralGroupBox.Location.X + GeneralGroupBox.Width + 10, LoadCancelButton.Location.Y + LoadCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Create Powder Charge List View
			//----------------------------------------------------------------------------*

			m_ChargeListView = new cChargeListView(m_DataFiles, m_Load);

			m_ChargeListView.Location = new Point(6, 20);
			m_ChargeListView.Size = new Size(PowderChargeGroup.Width - 12, AddChargeButton.Location.Y - m_ChargeListView.Location.Y - 6);
			m_ChargeListView.ListViewItemSorter = new cListViewChargeComparer(m_DataFiles.Preferences.ChargeSortColumn, m_DataFiles.Preferences.ChargeSortOrder);

			m_ChargeListView.Populate(m_Load, null);

			PowderChargeGroup.Controls.Add(m_ChargeListView);

			//----------------------------------------------------------------------------*
			// Load CartridgeDimensions Bitmap
			//----------------------------------------------------------------------------*

			try
				{
				m_CartridgeDimensionsBitmap = Properties.Resources.CartridgeDimensions; // new Bitmap(@"Images\CartridgeDimensions.jpg");

				CartridgeDimensionsImage.Image = m_CartridgeDimensionsBitmap;
				}
			catch
				{
				// No need to do anything here
				}

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			m_ChargeListView.SelectedIndexChanged += OnChargeTestSelected;

			ViewChargeButton.Click += OnViewCharge;

			CasesLoadedTextBox.TextChanged += OnCasesLoadedChanged;

			if (!m_fUserViewOnly)
				{
				AddChargeButton.Click += OnAddCharge;
				EditChargeButton.Click += OnEditCharge;
				RemoveChargeButton.Click += OnRemoveCharge;
				CopyChargeListButton.Click += OnCopyChargeList;

				FirearmTypeCombo.SelectedIndexChanged += OnFirearmTypeSelected;
				CaliberCombo.SelectedIndexChanged += OnCaliberSelected;
				BulletCombo.SelectedIndexChanged += OnBulletSelected;
				PowderCombo.SelectedIndexChanged += OnPowderSelected;
				PrimerCombo.SelectedIndexChanged += OnPrimerSelected;
				CaseCombo.SelectedIndexChanged += OnCaseSelected;

				LoadOKButton.Click += OnOKClicked;
				}
			else
				{
				LoadOKButton.Visible = false;
				}

			//----------------------------------------------------------------------------*
			// Select firearm type
			//----------------------------------------------------------------------------*

			cCaliber.CurrentFirearmType = m_Load.FirearmType;
			FirearmTypeCombo.Value = m_Load.FirearmType;

			//----------------------------------------------------------------------------*
			// Fill in load data
			//----------------------------------------------------------------------------*

			PopulateCaliberCombo();

			SetBulletImage();

			SetCartridgeCost();
			SetCartridgeDimensions();
			SetCaseDimensions();
			SetCartridgeImage();

			m_fChanged = false;

			m_fInitialized = true;

			UpdateButtons();

			if (!m_fUserViewOnly)
				{
				FirearmTypeCombo.Focus();
				}
			else
				LoadCancelButton.Focus();
			}

		//============================================================================*
		// Load Property
		//============================================================================*

		new public cLoad Load
			{
			get
				{
				return (m_Load);
				}
			}

		//============================================================================*
		// OnAddCharge()
		//============================================================================*

		private void OnAddCharge(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Issue a warning if this is the first charge
			//----------------------------------------------------------------------------*

			if (m_Load.ChargeList.Count == 0)
				{
				DialogResult rc = MessageBox.Show("Warning: Adding charge data to this load will lock the firearm type, caliber, and components for this load.  Make sure these are correct before adding charges.\n\nDo you wish to continue?", "Load Data Lock Verification", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

				if (rc != DialogResult.Yes)
					return;
				}

			//----------------------------------------------------------------------------*
			// Get the current load info
			//----------------------------------------------------------------------------*

			cLoad Load = new cLoad();

			Load.Bullet = (cBullet) BulletCombo.SelectedItem;
			Load.Caliber = (cCaliber) CaliberCombo.SelectedItem;
			Load.Case = (cCase) CaseCombo.SelectedItem;
			Load.ChargeList = new cChargeList(m_Load.ChargeList);
			Load.FirearmType = (cFirearm.eFireArmType) FirearmTypeCombo.SelectedIndex;
			Load.Powder = (cPowder) PowderCombo.SelectedItem;
			Load.Primer = (cPrimer) PrimerCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cChargeForm ChargeForm = new cChargeForm(null, Load, m_DataFiles, false);

			if (ChargeForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Charge Data
				//----------------------------------------------------------------------------*

				cCharge Charge = new cCharge(ChargeForm.Charge);

				m_Load.AddCharge(Charge);

				m_DataFiles.Preferences.LastCharge = new cCharge(Charge);

				m_ChargeListView.Populate(m_Load, Charge);

				m_fChanged = true;

				UpdateButtons();
				}
			}

		//============================================================================*
		// OnBulletSelected()
		//============================================================================*

		private void OnBulletSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			cBullet Bullet = (cBullet) BulletCombo.SelectedItem;

			if (m_Load.Bullet != null && m_Load.Bullet.CompareTo(Bullet) == 0)
				return;

			m_fChanged = true;

			m_Load.Bullet = Bullet;

			SetBulletImage();

			SetCartridgeCost();
			SetCartridgeDimensions();
			SetCaseDimensions();

			PopulatePowderCombo();

			UpdateButtons();
			}

		//============================================================================*
		// OnCaliberSelected()
		//============================================================================*

		private void OnCaliberSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			cCaliber Caliber = (cCaliber) CaliberCombo.SelectedItem;

			if (m_Load.Caliber != null && m_Load.Caliber.Equals(Caliber))
				return;

			m_fChanged = true;

			m_Load.Caliber = Caliber;
			m_Load.Bullet = null;
			m_Load.Case = null;
			m_Load.Primer = null;

			COLLabel.Text = String.Format("{0:F3}\"", m_Load.Caliber.MaxCOL);

			PopulateBulletCombo();

			SetCaseDimensions();

			SetCartridgeImage();
			SetCartridgeDimensions();

			UpdateButtons();
			}

		//============================================================================*
		// OnCaseSelected()
		//============================================================================*

		private void OnCaseSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			cCase Case = (cCase) CaseCombo.SelectedItem;

			if (m_Load.Case != null && m_Load.Case.Equals(Case))
				return;

			m_fChanged = true;

			m_Load.Case = Case;

			m_ChargeListView.Populate(m_Load, null);

			SetCartridgeCost();

			UpdateButtons();
			}

		//============================================================================*
		// OnCasesLoadedChanged()
		//============================================================================*

		private void OnCasesLoadedChanged(object sender, EventArgs e)
			{
			SetCartridgeCost();
			}

		//============================================================================*
		// OnChargeTestSelected()
		//============================================================================*

		private void OnChargeTestSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				{
				UpdateButtons();

				return;
				}

			if (m_ChargeListView.SelectedItems.Count > 0)
				m_DataFiles.Preferences.LastChargeSelected = (cCharge) m_ChargeListView.SelectedItems[0].Tag;

			SetCartridgeCost();

			UpdateButtons();
			}

		//============================================================================*
		// OnCopyChargeList()
		//============================================================================*

		protected void OnCopyChargeList(object sender, EventArgs args)
			{
			cLoad Load = new cLoad();

			Load.FirearmType = (cFirearm.eFireArmType) FirearmTypeCombo.SelectedIndex;
			Load.Caliber = (cCaliber) CaliberCombo.SelectedItem;
			Load.Bullet = (cBullet) BulletCombo.SelectedItem;
			Load.Powder = (cPowder) PowderCombo.SelectedItem;
			Load.Primer = (cPrimer) PrimerCombo.SelectedItem;
			Load.Case = (cCase) CaseCombo.SelectedItem;

			cCopyChargeListForm CopyChargeListForm = new cCopyChargeListForm(Load, m_DataFiles);

			if (CopyChargeListForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
				cLoad CopyLoad = CopyChargeListForm.Load;

				m_Load.ChargeList = new cChargeList(CopyLoad.ChargeList);

				m_ChargeListView.Populate(m_Load, null);

				m_fChanged = true;

				UpdateButtons();
				}
			}

		//============================================================================*
		// OnEditCharge()
		//============================================================================*

		private void OnEditCharge(object sender, EventArgs e)
			{
			//----------------------------------------------------------------------------*
			// Get the selected charge
			//----------------------------------------------------------------------------*

			cCharge OldCharge = null;

			if (m_ChargeListView.SelectedItems.Count > 0)
				OldCharge = (cCharge) m_ChargeListView.SelectedItems[0].Tag;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			if (OldCharge != null)
				{
				cChargeForm ChargeForm = new cChargeForm(OldCharge, m_Load, m_DataFiles);

				if (ChargeForm.ShowDialog() == DialogResult.OK)
					{
					//----------------------------------------------------------------------------*
					// Get the new charge data
					//----------------------------------------------------------------------------*

					cCharge Charge = new cCharge(ChargeForm.Charge);

					//----------------------------------------------------------------------------*
					// Remove the old charge test and insert the new
					//----------------------------------------------------------------------------*

					m_Load.ChargeList.Remove(OldCharge);

					m_Load.ChargeList.Add(Charge);

					m_fChanged = true;

					m_ChargeListView.Populate(m_Load, Charge);
					}
				}
			}

		//============================================================================*
		// OnFirearmTypeSelected()
		//============================================================================*

		private void OnFirearmTypeSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			cFirearm.eFireArmType FirearmType = (cFirearm.eFireArmType) FirearmTypeCombo.SelectedIndex;

			if (m_Load.FirearmType != FirearmType)
				{
				cCaliber.CurrentFirearmType = FirearmType;

				m_Load.FirearmType = FirearmType;

				m_Load.Caliber = null;
				m_Load.Bullet = null;
				m_Load.Powder = null;
				m_Load.Primer = null;
				m_Load.Case = null;

				PopulateCaliberCombo();
				}
			else
				m_Load.FirearmType = FirearmType;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnOKClicked()
		//============================================================================*

		private void OnOKClicked(object sender, EventArgs e)
			{
			if (!m_fViewOnly)
				m_Load.FirearmType = (cFirearm.eFireArmType) FirearmTypeCombo.SelectedIndex;

			m_Load.Caliber = (cCaliber) CaliberCombo.SelectedItem;
			m_Load.Bullet = (cBullet) BulletCombo.SelectedItem;
			m_Load.Powder = (cPowder) PowderCombo.SelectedItem;
			m_Load.Case = (cCase) CaseCombo.SelectedItem;
			m_Load.Primer = (cPrimer) PrimerCombo.SelectedItem;
			}

		//============================================================================*
		// OnPowderSelected()
		//============================================================================*

		private void OnPowderSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			cPowder Powder = (cPowder) PowderCombo.SelectedItem;

			if (m_Load.Powder != null && m_Load.Powder.Equals(Powder))
				return;

			m_fChanged = true;

			m_Load.Powder = Powder;

			PopulateCaseCombo();

			SetCartridgeCost();

			UpdateButtons();
			}

		//============================================================================*
		// OnPrimerSelected()
		//============================================================================*

		private void OnPrimerSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			cPrimer Primer = (cPrimer) PrimerCombo.SelectedItem;

			if (m_Load.Primer != null && m_Load.Primer.Equals(Primer))
				return;

			m_fChanged = true;

			m_Load.Primer = Primer;

			SetCartridgeCost();

			UpdateButtons();
			}

		//============================================================================*
		// OnRemoveCharge()
		//============================================================================*

		private void OnRemoveCharge(object sender, EventArgs e)
			{
			if (m_ChargeListView.SelectedItems.Count == 0)
				return;

			ListViewItem Item = m_ChargeListView.SelectedItems[0];

			//----------------------------------------------------------------------------*
			// Get the selected charge
			//----------------------------------------------------------------------------*

			cCharge Charge = (cCharge) Item.Tag;

			cChargeTest ChargeTest = null;

			if (Charge != null)
				{
				if (MessageBox.Show(this, "Are you sure you wish to delete the selected charge data?", "Deletion verification", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
					return;

				m_ChargeListView.Items.Remove(Item);
				m_Load.ChargeList.Remove(Charge);

				foreach (cChargeTest CheckChargeTest in Charge.TestList)
					{
					if (CheckChargeTest.Source == Item.SubItems[1].Text)
						{
						ChargeTest = CheckChargeTest;

						break;
						}
					}

				if (ChargeTest != null)
					Charge.TestList.Remove(ChargeTest);

				m_fChanged = true;

				UpdateButtons();
				}
			}

		//============================================================================*
		// OnViewCharge()
		//============================================================================*

		private void OnViewCharge(object sender, EventArgs e)
			{
			//----------------------------------------------------------------------------*
			// Get the selected charge
			//----------------------------------------------------------------------------*

			cCharge Charge = null;

			if (m_ChargeListView.SelectedItems.Count > 0)
				Charge = (cCharge) m_ChargeListView.SelectedItems[0].Tag;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			if (Charge != null)
				{
				cChargeForm ChargeForm = new cChargeForm(Charge, m_Load, m_DataFiles, true);

				ChargeForm.ShowDialog();
				}
			}

		//============================================================================*
		// PopulateBulletCombo()
		//============================================================================*

		private void PopulateBulletCombo()
			{
			m_fPopulating = true;

			BulletCombo.Items.Clear();

			if (!m_fViewOnly)
				{
				cBullet SelectBullet = null;

				foreach (cBullet Bullet in m_DataFiles.BulletList)
					{
					if ((m_Load.Bullet != null && m_Load.Bullet.Equals(Bullet)) ||
						(Bullet.CrossUse || Bullet.FirearmType == (cFirearm.eFireArmType) FirearmTypeCombo.SelectedIndex) &&
						(!m_DataFiles.Preferences.HideUncheckedSupplies || Bullet.Checked) &&
						(CaliberCombo.SelectedIndex >= 0 && Bullet.HasCaliber((cCaliber) CaliberCombo.SelectedItem)))
						{
						BulletCombo.Items.Add(Bullet);

						if (m_Load.Bullet != null && m_Load.Bullet.CompareTo(Bullet) == 0)
							SelectBullet = Bullet;
						}
					}

				if (SelectBullet == null)
					{
					if (BulletCombo.Items.Count > 0)
						BulletCombo.SelectedIndex = 0;
					else
						BulletCombo.SelectedIndex = -1;
					}
				else
					BulletCombo.SelectedItem = SelectBullet;

				if (m_Load.Bullet == null && BulletCombo.SelectedIndex >= 0)
					m_Load.Bullet = (cBullet) BulletCombo.SelectedItem;
				}
			else
				{
				BulletCombo.Items.Clear();

				BulletCombo.Items.Add(Load.Bullet);

				BulletCombo.SelectedIndex = 0;
				}

			SetCartridgeDimensions();

			SetBulletImage();

			m_fPopulating = false;

			PopulatePowderCombo();
			}

		//============================================================================*
		// PopulateCaliberCombo()
		//============================================================================*

		private void PopulateCaliberCombo()
			{
			m_fPopulating = true;

			cCaliber.CurrentFirearmType = m_Load.FirearmType;

			CaliberCombo.Items.Clear();

			if (!m_fViewOnly)
				{
				cCaliber SelectCaliber = null;

				foreach (cCaliber Caliber in m_DataFiles.CaliberList)
					{
					if ((m_Load.Caliber != null && m_Load.Caliber.Equals(Caliber)) ||
						((Caliber.FirearmType == (cFirearm.eFireArmType) FirearmTypeCombo.SelectedIndex) &&
						(!m_DataFiles.Preferences.HideUncheckedCalibers || Caliber.Checked)))
						{
						CaliberCombo.Items.Add(Caliber);

						if (m_Load.Caliber != null && m_Load.Caliber.Equals(Caliber))
							SelectCaliber = Caliber;
						}
					}

				if (SelectCaliber == null)
					{
					if (CaliberCombo.Items.Count > 0)
						CaliberCombo.SelectedIndex = 0;
					else
						CaliberCombo.SelectedIndex = -1;
					}
				else
					CaliberCombo.SelectedItem = SelectCaliber;

				if (m_Load.Caliber == null && CaliberCombo.SelectedIndex >= 0)
					m_Load.Caliber = (cCaliber) CaliberCombo.SelectedItem;
				}
			else
				{
				CaliberCombo.Items.Clear();

				CaliberCombo.Items.Add(Load.Caliber);

				CaliberCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			SetCartridgeImage();

			PopulateBulletCombo();
			}

		//============================================================================*
		// PopulateCaseCombo()
		//============================================================================*

		private void PopulateCaseCombo()
			{
			m_fPopulating = true;

			CaseCombo.Items.Clear();

			if (!m_fViewOnly)
				{
				cCase SelectCase = null;

				foreach (cCase Case in m_DataFiles.CaseList)
					{
					if ((m_Load.Case != null && m_Load.Case.Equals(Case)) ||
						((CaliberCombo.SelectedIndex >= 0 && Case.Caliber.Equals((cCaliber) CaliberCombo.SelectedItem)) &&
						(!m_DataFiles.Preferences.HideUncheckedSupplies || Case.Checked)))
						{
						CaseCombo.Items.Add(Case);

						if (m_Load.Case != null && m_Load.Case.Equals(Case))
							SelectCase = Case;
						}
					}

				if (SelectCase == null)
					{
					if (CaseCombo.Items.Count > 0)
						CaseCombo.SelectedIndex = 0;
					else
						CaseCombo.SelectedIndex = -1;
					}
				else
					CaseCombo.SelectedItem = SelectCase;

				if (m_Load.Case == null && CaseCombo.SelectedIndex >= 0)
					m_Load.Case = (cCase) CaseCombo.SelectedItem;
				}
			else
				{
				CaseCombo.Items.Clear();

				CaseCombo.Items.Add(Load.Case);

				CaseCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			PopulatePrimerCombo();
			}

		//============================================================================*
		// PopulatePowderCombo()
		//============================================================================*

		private void PopulatePowderCombo()
			{
			m_fPopulating = true;

			PowderCombo.Items.Clear();

			if (!m_fViewOnly)
				{
				cPowder SelectPowder = null;

				foreach (cPowder Powder in m_DataFiles.PowderList)
					{
					if ((m_Load.Powder != null && m_Load.Powder.Equals(Powder)) ||
						(Powder.CrossUse || (FirearmTypeCombo.SelectedIndex >= 0 && Powder.FirearmType == (cFirearm.eFireArmType) FirearmTypeCombo.SelectedIndex)) &&
						(!m_DataFiles.Preferences.HideUncheckedSupplies || Powder.Checked))
						{
						PowderCombo.Items.Add(Powder);

						if (m_Load.Powder != null && m_Load.Powder.Equals(Powder))
							SelectPowder = Powder;
						}
					}

				if (SelectPowder == null)
					{
					if (PowderCombo.Items.Count > 0)
						PowderCombo.SelectedIndex = 0;
					else
						PowderCombo.SelectedIndex = -1;
					}
				else
					PowderCombo.SelectedItem = SelectPowder;

				if (m_Load.Powder == null && PowderCombo.SelectedIndex >= 0)
					m_Load.Powder = (cPowder) PowderCombo.SelectedItem;
				}
			else
				{
				PowderCombo.Items.Clear();

				PowderCombo.Items.Add(m_Load.Powder);

				PowderCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			PopulateCaseCombo();
			}

		//============================================================================*
		// PopulatePrimerCombo()
		//============================================================================*

		private void PopulatePrimerCombo()
			{
			m_fPopulating = true;

			PrimerCombo.Items.Clear();

			if (!m_fViewOnly)
				{
				cPrimer SelectPrimer = null;

				cCaliber Caliber = null;

				if (CaliberCombo.SelectedIndex >= 0)
					Caliber = (cCaliber) CaliberCombo.SelectedItem;

				if (Caliber != null)
					{
					cCaliber.CurrentFirearmType = Caliber.FirearmType;

					foreach (cPrimer Primer in m_DataFiles.PrimerList)
						{
						if ((m_Load.Primer != null && m_Load.Primer.Equals(Primer)) ||

							((Primer.CrossUse || Primer.FirearmType == (cFirearm.eFireArmType) FirearmTypeCombo.SelectedIndex) &&

							(((Primer.Size == cPrimer.ePrimerSize.Small && Caliber.SmallPrimer) || (Primer.Size == cPrimer.ePrimerSize.Large && Caliber.LargePrimer))) &&

							((Caliber.MagnumPrimer && Primer.Magnum) || (!Caliber.MagnumPrimer && Primer.Standard)) &&

							(!m_DataFiles.Preferences.HideUncheckedSupplies || Primer.Checked)))
							{
							PrimerCombo.Items.Add(Primer);

							if (m_Load.Primer != null && m_Load.Primer.Equals(Primer))
								SelectPrimer = Primer;
							}
						}
					}

				if (SelectPrimer == null)
					{
					if (PrimerCombo.Items.Count > 0)
						PrimerCombo.SelectedIndex = 0;
					else
						PrimerCombo.SelectedIndex = -1;
					}
				else
					PrimerCombo.SelectedItem = SelectPrimer;

				if (m_Load.Primer == null && PrimerCombo.SelectedIndex >= 0)
					m_Load.Primer = (cPrimer) PrimerCombo.SelectedItem;
				}
			else
				{
				PrimerCombo.Items.Clear();

				PrimerCombo.Items.Add(Load.Primer);

				PrimerCombo.SelectedIndex = 0;
				}

			m_ChargeListView.Populate(m_Load, null);

			m_fPopulating = false;

			UpdateButtons();
			}

		//============================================================================*
		// SetBulletImage()
		//============================================================================*

		private void SetBulletImage()
			{
			if (m_Load.Bullet == null)
				{
				BulletImage.Image = null;

				return;
				}

			try
				{
				string strFileName = String.Format(@"Images\{0} {1} Bullet.jpg", m_Load.Bullet.Manufacturer, m_Load.Bullet.PartNumber);

				m_BulletBitmap = new Bitmap(strFileName);

				m_BulletBitmap.MakeTransparent(Color.White);
				}
			catch
				{
				m_BulletBitmap = null;
				}

			BulletImage.Image = m_BulletBitmap;
			}

		//============================================================================*
		// SetCartridgeCost()
		//============================================================================*

		private void SetCartridgeCost()
			{
			//----------------------------------------------------------------------------*
			// Bullet Cost
			//----------------------------------------------------------------------------*

			double dBulletCost = m_DataFiles.SupplyCostEach((cSupply) BulletCombo.SelectedItem);

			BulletCostLabel.Text = String.Format("{0}{1:F3} ea.", m_DataFiles.Preferences.Currency, dBulletCost);

			//----------------------------------------------------------------------------*
			// Powder Cost
			//----------------------------------------------------------------------------*

			double dPowderCost = m_DataFiles.SupplyCostEach((cSupply) PowderCombo.SelectedItem);

			cCharge Charge = null;

			if (m_ChargeListView.SelectedItems.Count > 0)
				Charge = (cCharge) m_ChargeListView.SelectedItems[0].Tag;

			double dPowderWeight = 0.0;

			if (Charge != null)
				{
				dPowderWeight = Charge.PowderWeight;

				dPowderCost *= dPowderWeight;
				}
			else
				dPowderCost = 0.0;

			PowderCostLabel.Text = String.Format("{0}{1:F3} ea.", m_DataFiles.Preferences.Currency, dPowderCost);

			//----------------------------------------------------------------------------*
			// Primer Cost
			//----------------------------------------------------------------------------*

			double dPrimerCost = m_DataFiles.SupplyCostEach((cSupply) PrimerCombo.SelectedItem);

			PrimerCostLabel.Text = String.Format("{0}{1:F3} ea.", m_DataFiles.Preferences.Currency, dPrimerCost);

			//----------------------------------------------------------------------------*
			// Case Cost
			//----------------------------------------------------------------------------*

			double dCaseCost = m_DataFiles.SupplyCostEach((cSupply) CaseCombo.SelectedItem);

			dCaseCost /= (double) CasesLoadedTextBox.Value + 1;

			CaseCostLabel.Text = String.Format("{0}{1:F3} ea.", m_DataFiles.Preferences.Currency, dCaseCost);

			CartridgeCostLabel.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, dBulletCost + dPowderCost + dCaseCost + dPrimerCost);
			}

		//============================================================================*
		// SetCartridgeDimensions()
		//============================================================================*

		private void SetCartridgeDimensions()
			{
			if (m_Load.Bullet != null && m_Load.Caliber != null)
				{
				cBulletCaliber BulletCaliber = m_Load.Bullet.BulletCaliber(m_Load.Caliber);

				if (BulletCaliber != null)
					COLLabel.Text = String.Format("{0:F3}\"", m_Load.Bullet.BulletCaliber(m_Load.Caliber).COL);
				else
					COLLabel.Text = String.Format("{0:F3}\" (Max)", m_Load.Caliber.MaxCOL);
				}
			else
				{
				if (m_Load.Caliber != null)
					COLLabel.Text = String.Format("{0:F3}\" (Max)", m_Load.Caliber.MaxCOL);
				else
					COLLabel.Text = "?.???\"";
				}
			}

		//============================================================================*
		// SetCartridgeImage()
		//============================================================================*

		private void SetCartridgeImage()
			{
			cCaliber Caliber = (cCaliber) CaliberCombo.SelectedItem;

			string strFileName = "";

			if (Caliber != null)
				{
				try
					{
					strFileName = String.Format("Images/{0} Cartridge.jpg", Caliber.Name);

					m_CartridgeBitmap = new Bitmap(strFileName);
					}
				catch
					{
					try
						{
						if (Caliber.FirearmType == cFirearm.eFireArmType.Rifle)
							strFileName = "Images/Rifle Cartridge.jpg";
						else
							{
							if (Caliber.Pistol)
								strFileName = "Images/Pistol Cartridge.jpg";
							else
								strFileName = "Images/Revolver Cartridge.jpg";
							}

						m_CartridgeBitmap = new Bitmap(strFileName);
						}
					catch
						{
						m_CartridgeBitmap = null;
						}
					}
				}
			else
				m_CartridgeBitmap = null;


			CartridgeImage.Image = m_CartridgeBitmap;
			}

		//============================================================================*
		// SetCaseDimensions()
		//============================================================================*

		private void SetCaseDimensions()
			{
			string strDimensionFormat = "{0:F";
			strDimensionFormat += String.Format("{0:G0}", m_DataFiles.Preferences.DimensionDecimals);
			strDimensionFormat += "} {1}";

			cCaliber Caliber = (cCaliber) CaliberCombo.SelectedItem;

			if (m_Load.Caliber != null)
				{
				CaseLengthLabel.Text = String.Format(strDimensionFormat, cDataFiles.StandardToMetric(m_Load.Caliber.CaseTrimLength, cDataFiles.eDataType.Dimension), cDataFiles.MetricString(cDataFiles.eDataType.Dimension));
				MaxCaseLengthLabel.Text = String.Format(strDimensionFormat, cDataFiles.StandardToMetric(m_Load.Caliber.MaxCaseLength, cDataFiles.eDataType.Dimension), cDataFiles.MetricString(cDataFiles.eDataType.Dimension));
				MaxCOLLabel.Text = String.Format(strDimensionFormat, cDataFiles.StandardToMetric(m_Load.Caliber.MaxCOL, cDataFiles.eDataType.Dimension), cDataFiles.MetricString(cDataFiles.eDataType.Dimension));
				}
			else
				{
				if (Caliber != null)
					{
					CaseLengthLabel.Text = String.Format(strDimensionFormat, cDataFiles.StandardToMetric(Caliber.CaseTrimLength, cDataFiles.eDataType.Dimension), cDataFiles.MetricString(cDataFiles.eDataType.Dimension));
					MaxCaseLengthLabel.Text = String.Format(strDimensionFormat, cDataFiles.StandardToMetric(Caliber.MaxCaseLength, cDataFiles.eDataType.Dimension), cDataFiles.MetricString(cDataFiles.eDataType.Dimension));
					MaxCOLLabel.Text = String.Format(strDimensionFormat, cDataFiles.StandardToMetric(Caliber.MaxCOL, cDataFiles.eDataType.Dimension), cDataFiles.MetricString(cDataFiles.eDataType.Dimension));
					}
				}

			double dBulletCOL = 0.0;

			if (m_Load.Bullet != null && m_Load.Caliber != null)
				{
				cBulletCaliber BulletCaliber = m_Load.Bullet.BulletCaliber(m_Load.Caliber);

				if (BulletCaliber != null)
					dBulletCOL = BulletCaliber.COL;
				else
					dBulletCOL = 0.0;
				}

			BulletCOLLabel.Text = (dBulletCOL != 0.0) ? String.Format(strDimensionFormat, cDataFiles.StandardToMetric(dBulletCOL, cDataFiles.eDataType.Dimension), cDataFiles.MetricString(cDataFiles.eDataType.Dimension)) : "?.???";

			if (dBulletCOL != 0.0)
				COLLabel.Text = String.Format(strDimensionFormat, cDataFiles.StandardToMetric(dBulletCOL, cDataFiles.eDataType.Dimension), cDataFiles.MetricString(cDataFiles.eDataType.Dimension));
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
			m_FirearmTypeToolTip.SetToolTip(FirearmTypeCombo, cm_strFirearmTypeToolTip);

			m_CaliberToolTip.ShowAlways = true;
			m_CaliberToolTip.RemoveAll();
			m_CaliberToolTip.SetToolTip(CaliberCombo, cm_strCaliberToolTip);

			m_BulletToolTip.ShowAlways = true;
			m_BulletToolTip.RemoveAll();
			m_BulletToolTip.SetToolTip(BulletCombo, cm_strBulletToolTip);

			m_CaseToolTip.ShowAlways = true;
			m_CaseToolTip.RemoveAll();
			m_CaseToolTip.SetToolTip(CaseCombo, cm_strCaseToolTip);

			m_PowderToolTip.ShowAlways = true;
			m_PowderToolTip.RemoveAll();
			m_PowderToolTip.SetToolTip(PowderCombo, cm_strPowderToolTip);

			m_PrimerToolTip.ShowAlways = true;
			m_PrimerToolTip.RemoveAll();
			m_PrimerToolTip.SetToolTip(PowderCombo, cm_strPowderToolTip);

			m_LoadOKButtonToolTip.ShowAlways = true;
			m_LoadOKButtonToolTip.RemoveAll();
			m_LoadOKButtonToolTip.SetToolTip(LoadOKButton, cm_strLoadOKButtonToolTip);

			m_LoadCancelButtonToolTip.ShowAlways = true;
			m_LoadCancelButtonToolTip.RemoveAll();
			m_LoadCancelButtonToolTip.SetToolTip(LoadCancelButton, cm_strLoadCancelButtonToolTip);

			m_AddChargeToolTip.ShowAlways = true;
			m_AddChargeToolTip.RemoveAll();
			m_AddChargeToolTip.SetToolTip(AddChargeButton, cm_strAddChargeToolTip);

			m_EditChargeToolTip.ShowAlways = true;
			m_EditChargeToolTip.RemoveAll();
			m_EditChargeToolTip.SetToolTip(EditChargeButton, cm_strEditChargeToolTip);

			m_RemoveChargeToolTip.ShowAlways = true;
			m_RemoveChargeToolTip.RemoveAll();
			m_RemoveChargeToolTip.SetToolTip(RemoveChargeButton, cm_strRemoveChargeToolTip);
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			if (!m_fInitialized)
				return;

			bool fEnableOK = m_fChanged;
			string strToolTip = "";

			bool fLoadChanged = false;
			bool fAddCharge = true;

			//----------------------------------------------------------------------------*
			// Check Bullet
			//----------------------------------------------------------------------------*

			strToolTip = cm_strBulletToolTip;

			if (BulletCombo.SelectedIndex < 0)
				{
				fEnableOK = false;

				fAddCharge = false;

				strToolTip += "\n\nYou must select a bullet for this load.";
				}
			else
				{
				if (m_OriginalLoad != null)
					{
					if (m_OriginalLoad.Bullet != (cBullet) BulletCombo.SelectedItem)
						fLoadChanged = true;
					}
				}

			if (m_DataFiles.Preferences.ToolTips)
				m_BulletToolTip.SetToolTip(BulletCombo, strToolTip);

			//----------------------------------------------------------------------------*
			// Check Powder
			//----------------------------------------------------------------------------*

			strToolTip = cm_strPowderToolTip;

			if (PowderCombo.SelectedIndex < 0)
				{
				fEnableOK = false;

				fAddCharge = false;

				strToolTip += "\n\nYou must select a powder for this load.";
				}
			else
				{
				if (m_OriginalLoad != null)
					{
					if (m_OriginalLoad.Powder != (cPowder) PowderCombo.SelectedItem)
						fLoadChanged = true;
					}
				}

			if (m_DataFiles.Preferences.ToolTips)
				m_PowderToolTip.SetToolTip(PowderCombo, strToolTip);

			//----------------------------------------------------------------------------*
			// Check Case
			//----------------------------------------------------------------------------*

			strToolTip = cm_strCaseToolTip;

			if (CaseCombo.SelectedIndex < 0)
				{
				fEnableOK = false;

				fAddCharge = false;

				strToolTip += "\n\nYou must select a case for this load.";
				}
			else
				{
				if (m_OriginalLoad != null)
					{
					if (m_OriginalLoad.Case != (cCase) CaseCombo.SelectedItem)
						fLoadChanged = true;
					}
				}

			if (m_DataFiles.Preferences.ToolTips)
				m_CaseToolTip.SetToolTip(CaseCombo, strToolTip);

			//----------------------------------------------------------------------------*
			// Check Primer
			//----------------------------------------------------------------------------*

			strToolTip = cm_strPrimerToolTip;

			if (PrimerCombo.SelectedIndex < 0)
				{
				fEnableOK = false;

				fAddCharge = false;

				strToolTip += "\n\nYou must select a primer for this load.";
				}
			else
				{
				if (m_OriginalLoad != null)
					{
					if (m_OriginalLoad.Primer != (cPrimer) PrimerCombo.SelectedItem)
						fLoadChanged = true;
					}
				}

			if (m_DataFiles.Preferences.ToolTips)
				m_PrimerToolTip.SetToolTip(PrimerCombo, strToolTip);

			//----------------------------------------------------------------------------*
			// Check for duplicates
			//----------------------------------------------------------------------------*

			bool fDuplicate = false;

			if (m_fAdd || fLoadChanged)
				{
				if (FirearmTypeCombo.SelectedIndex >= 0 &&
					CaliberCombo.SelectedIndex >= 0 &&
					BulletCombo.SelectedIndex >= 0 &&
					CaseCombo.SelectedIndex >= 0 &&
					PowderCombo.SelectedIndex >= 0 &&
					PrimerCombo.SelectedIndex >= 0)
					{
					foreach (cLoad CheckLoad in m_DataFiles.LoadList)
						{
						if ((cFirearm.eFireArmType) FirearmTypeCombo.SelectedIndex == CheckLoad.FirearmType &&
							(CaliberCombo.SelectedItem as cCaliber).CompareTo(CheckLoad.Caliber) == 0 &&
							(BulletCombo.SelectedItem as cBullet).CompareTo(CheckLoad.Bullet) == 0 &&
							(PowderCombo.SelectedItem as cPowder).CompareTo(CheckLoad.Powder) == 0 &&
							(CaseCombo.SelectedItem as cCase).CompareTo(CheckLoad.Case) == 0 &&
							(PrimerCombo.SelectedItem as cPrimer).CompareTo(CheckLoad.Primer) == 0)
							{
							fDuplicate = true;

							fEnableOK = false;

							strToolTip = "\n\nDuplicate loads are not allowed.";

							break;
							}
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Check ChargeList
			//----------------------------------------------------------------------------*

			strToolTip = cm_strChargeListToolTip;

			if (m_ChargeListView.Items.Count == 0)
				{
				fEnableOK = false;

				m_ChargeListView.BackColor = Color.LightPink;

				strToolTip += "\n\nYou must add at least one powder charge for this load.";
				}
			else
				{
				m_ChargeListView.BackColor = SystemColors.Window;
				}

			if (m_DataFiles.Preferences.ToolTips)
				m_ChargeListToolTip.SetToolTip(m_ChargeListView, strToolTip);

			//----------------------------------------------------------------------------*
			// Copy Charge Buttons
			//----------------------------------------------------------------------------*

			if (fDuplicate)
				{
				AddChargeButton.Enabled = false;
				RemoveChargeButton.Enabled = false;

				ErrorMessageLabel.Text = "This load already exists in the database.  Duplicate loads are not allowed";
				}
			else
				{
				AddChargeButton.Enabled = fAddCharge;

				//----------------------------------------------------------------------------*
				// See if this load is used in a batch already
				//----------------------------------------------------------------------------*

				if (!m_fUserViewOnly)
					{
					int nNumBatches = 0;

					foreach (cBatch CheckBatch in m_DataFiles.BatchList)
						{
						if (CheckBatch.Load.CompareTo(m_Load) == 0)
							nNumBatches++;
						}

					if (nNumBatches > 0)
						{
						ErrorMessageLabel.Text = String.Format("This load is used in {0:N0} batch{1}.  Load components may not be modified.", nNumBatches, nNumBatches != 1 ? "es" : "");

						m_fViewOnly = true;

						FirearmTypeCombo.Enabled = false;
						CaliberCombo.Enabled = false;
						BulletCombo.Enabled = false;
						PowderCombo.Enabled = false;
						PrimerCombo.Enabled = false;
						CaseCombo.Enabled = false;
						}
					else
						{
						FirearmTypeCombo.Enabled = m_Load.ChargeList.Count == 0;
						CaliberCombo.Enabled = m_Load.ChargeList.Count == 0;
						BulletCombo.Enabled = m_Load.ChargeList.Count == 0;
						PowderCombo.Enabled = m_Load.ChargeList.Count == 0;
						PrimerCombo.Enabled = m_Load.ChargeList.Count == 0;
						CaseCombo.Enabled = m_Load.ChargeList.Count == 0;

						ErrorMessageLabel.Text = "";
						}
					}
				}

			//----------------------------------------------------------------------------*
			// See if this load has been used in any batches
			//----------------------------------------------------------------------------*

			bool fCopyOK = false;

			if (!fDuplicate && !m_fViewOnly)
				{
				if (m_ChargeListView.Items.Count == 0)
					{
					foreach (cLoad CheckLoad in m_DataFiles.LoadList)
						{
						if (CheckLoad.ChargeList.Count > 0 &&
							CheckLoad.Powder.CompareTo((cPowder) PowderCombo.SelectedItem) == 0)
							{
							fCopyOK = true;

							break;
							}
						}
					}

				if (FirearmTypeCombo.SelectedIndex == -1 ||
					CaliberCombo.SelectedIndex == -1 ||
					BulletCombo.SelectedIndex == -1 ||
					PowderCombo.SelectedIndex == -1 ||
					CaseCombo.SelectedIndex == -1 ||
					PrimerCombo.SelectedIndex == -1)
					fCopyOK = false;
				}

			CopyChargeListButton.Enabled = fCopyOK;

			//----------------------------------------------------------------------------*
			// Edit, View, Remove Charge Buttons
			//----------------------------------------------------------------------------*

			ViewChargeButton.Enabled = true;

			if (m_fUserViewOnly)
				{
				AddChargeButton.Enabled = false;
				EditChargeButton.Enabled = false;
				RemoveChargeButton.Enabled = false;

				if (m_ChargeListView.SelectedItems.Count == 0)
					ViewChargeButton.Enabled = false;
				}
			else
				{
				if (m_ChargeListView.SelectedItems.Count == 0)
					{
					EditChargeButton.Enabled = false;
					ViewChargeButton.Enabled = false;
					RemoveChargeButton.Enabled = false;
					}
				else
					{
					cCharge Charge = (cCharge) m_ChargeListView.SelectedItems[0].Tag;

					if (Charge != null)
						{
						EditChargeButton.Enabled = true;
						ViewChargeButton.Enabled = true;
						RemoveChargeButton.Enabled = true;

						foreach (cBatch CheckBatch in m_DataFiles.BatchList)
							{
							if (CheckBatch.Load.CompareTo(m_Load) == 0 && Charge.PowderWeight == CheckBatch.PowderWeight)
								{
								RemoveChargeButton.Enabled = false;

								break;
								}
							}
						}
					}
				}

			LoadOKButton.Enabled = fEnableOK;
			}
		}
	}
