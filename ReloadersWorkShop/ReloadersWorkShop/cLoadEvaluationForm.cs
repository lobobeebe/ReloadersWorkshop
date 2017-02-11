//============================================================================*
// cLoadEvaluationForm.cs
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

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cLoadEvaluationForm Class
	//============================================================================*

	public partial class cLoadEvaluationForm : Form
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fInitialized = false;

		private cDataFiles m_DataFiles = null;
		private cLoadList m_LoadList = null;

		private cEvaluationListView m_EvaluationListView = null;

		//============================================================================*
		// cLoadEvaluationForm() - Constructor
		//============================================================================*

		public cLoadEvaluationForm(cDataFiles DataFiles, cLoadList LoadList)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;
			m_LoadList = LoadList;

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			FactoryTestRadioButton.Click += OnFactoryTestClicked;

			CaliberCombo.SelectedIndexChanged += OnCaliberSelected;

			BulletCombo.SelectedIndexChanged += OnBulletSelected;
			CaseCombo.SelectedIndexChanged += OnCaseSelected;
			PowderCombo.SelectedIndexChanged += OnPowderSelected;
			PrimerCombo.SelectedIndexChanged += OnPrimerSelected;

			SetClientSizeCore(FiltersGroupBox.Location.X + FiltersGroupBox.Width + 10, CloseButton.Location.Y + CloseButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Populate Combo Boxes
			//----------------------------------------------------------------------------*

			PopulateComboBoxes();

			//----------------------------------------------------------------------------*
			// Create and Populate Evaluation List
			//----------------------------------------------------------------------------*

			m_EvaluationListView = new cEvaluationListView(m_DataFiles, m_LoadList);

			Controls.Add(m_EvaluationListView);

			m_EvaluationListView.Populate();

			//----------------------------------------------------------------------------*
			// Update Buttons and Exit
			//----------------------------------------------------------------------------*

			m_fInitialized = true;

			if (m_DataFiles.Preferences.EvaluationListSize.Width != 0 && m_DataFiles.Preferences.EvaluationListSize.Height != 0)
				Size = m_DataFiles.Preferences.EvaluationListSize;

			if (m_DataFiles.Preferences.EvaluationListLocation.X != 0 && m_DataFiles.Preferences.EvaluationListLocation.Y != 0)
				Location = m_DataFiles.Preferences.EvaluationListLocation;

			SetControlPositions();

			UpdateButtons();
			}

		//============================================================================*
		// OnBulletSelected()
		//============================================================================*

		protected void OnBulletSelected(Object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_EvaluationListView.Bullet = (cBullet)(BulletCombo.SelectedIndex > 0 ? BulletCombo.SelectedItem : null);
			}

		//============================================================================*
		// OnCaliberSelected()
		//============================================================================*

		protected void OnCaliberSelected(Object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_EvaluationListView.Caliber = (cCaliber)(CaliberCombo.SelectedIndex > 0 ? CaliberCombo.SelectedItem : null);
			}

		//============================================================================*
		// OnCaseSelected()
		//============================================================================*

		protected void OnCaseSelected(Object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_EvaluationListView.Case = (cCase)(CaseCombo.SelectedIndex > 0 ? CaseCombo.SelectedItem : null);
			}

		//============================================================================*
		// OnFactoryTestClicked()
		//============================================================================*

		protected void OnFactoryTestClicked(Object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			FactoryTestRadioButton.Checked = !FactoryTestRadioButton.Checked;

			m_EvaluationListView.FactoryTest = FactoryTestRadioButton.Checked;

			PopulateComboBoxes();
			}

		//============================================================================*
		// OnMove()
		//============================================================================*

		protected override void OnMove(EventArgs e)
			{
			if (!m_fInitialized)
				return;

			base.OnMove(e);

			m_DataFiles.Preferences.EvaluationListLocation = Location;
			}

		//============================================================================*
		// OnPowderSelected()
		//============================================================================*

		protected void OnPowderSelected(Object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_EvaluationListView.Powder = (cPowder)(PowderCombo.SelectedIndex > 0 ? PowderCombo.SelectedItem : null);
			}

		//============================================================================*
		// OnPrimerSelected()
		//============================================================================*

		protected void OnPrimerSelected(Object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_EvaluationListView.Primer = (cPrimer)(PrimerCombo.SelectedIndex > 0 ? PrimerCombo.SelectedItem : null);
			}

		//============================================================================*
		// OnResize()
		//============================================================================*

		protected override void OnResize(EventArgs e)
			{
			if (!m_fInitialized)
				return;

			base.OnResize(e);

			SetControlPositions();

			m_DataFiles.Preferences.EvaluationListSize = Size;
			}

		//============================================================================*
		// PopulateComboBoxes()
		//============================================================================*

		private void PopulateComboBoxes()
			{
			CaliberCombo.Items.Clear();
			BulletCombo.Items.Clear();
			PowderCombo.Items.Clear();
			PrimerCombo.Items.Clear();
			CaseCombo.Items.Clear();

			CaliberCombo.Items.Add("Any Caliber");
			BulletCombo.Items.Add("Any Bullet");
			PowderCombo.Items.Add("Any Powder");
			PrimerCombo.Items.Add("Any Primer");
			CaseCombo.Items.Add("Any Case");

			foreach (cLoad Load in m_LoadList)
				{
				//----------------------------------------------------------------------------*
				// Check Filters
				//----------------------------------------------------------------------------*

				//----------------------------------------------------------------------------*
				// Loop through the charges
				//----------------------------------------------------------------------------*

				bool fOK = FactoryTestRadioButton.Checked;

				if (!fOK)
					{
					foreach (cCharge Charge in Load.ChargeList)
						{
						//----------------------------------------------------------------------------*
						// Loop through the charge tests
						//----------------------------------------------------------------------------*

						foreach (cChargeTest ChargeTest in Charge.TestList)
							{
							if (ChargeTest.BatchID != 0)
								fOK = true;
							}
						}
					}

				if (!fOK)
					continue;

				//----------------------------------------------------------------------------*
				// Caliber Combo
				//----------------------------------------------------------------------------*

				if (!CaliberCombo.Items.Contains(Load.Caliber))
					{
					CaliberCombo.Items.Add(Load.Caliber);
					}

				//----------------------------------------------------------------------------*
				// Bullet Combo
				//----------------------------------------------------------------------------*

				if (!BulletCombo.Items.Contains(Load.Bullet))
					{
					BulletCombo.Items.Add(Load.Bullet);
					}

				//----------------------------------------------------------------------------*
				// Powder Combo
				//----------------------------------------------------------------------------*

				if (!PowderCombo.Items.Contains(Load.Powder))
					{
					PowderCombo.Items.Add(Load.Powder);
					}

				//----------------------------------------------------------------------------*
				// Primer Combo
				//----------------------------------------------------------------------------*

				if (!PrimerCombo.Items.Contains(Load.Primer))
					{
					PrimerCombo.Items.Add(Load.Primer);
					}

				//----------------------------------------------------------------------------*
				// Case Combo
				//----------------------------------------------------------------------------*

				if (!CaseCombo.Items.Contains(Load.Case))
					{
					CaseCombo.Items.Add(Load.Case);
					}
				}

			CaliberCombo.SelectedIndex = 0;
			BulletCombo.SelectedIndex = 0;
			PowderCombo.SelectedIndex = 0;
			PrimerCombo.SelectedIndex = 0;
			CaseCombo.SelectedIndex = 0;
			}

		//============================================================================*
		// SetControlPositions()
		//============================================================================*

		private void SetControlPositions()
			{
			int nButtonY = ClientRectangle.Height - 20 - CloseButton.Height;

			int nButtonX = (ClientRectangle.Width / 2) - (CloseButton.Width / 2);

			CloseButton.Location = new Point(nButtonX, nButtonY);

			m_EvaluationListView.Location = new Point(10, FiltersGroupBox.Location.Y + FiltersGroupBox.Height + 20);
			m_EvaluationListView.Size = new Size(ClientRectangle.Width - 30, nButtonY - m_EvaluationListView.Location.Y - 20);
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			}
		}
	}
