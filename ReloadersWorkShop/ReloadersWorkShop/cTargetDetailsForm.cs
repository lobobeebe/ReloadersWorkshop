//============================================================================*
// cTargetDetailsForm.cs
//
// Copyright © 2016, Kevin S. Beebe
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
	// cTargetDetailsForm Class
	//============================================================================*

	public partial class cTargetDetailsForm : Form
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fInitialized = false;
		private bool m_fChanged = false;

		private cDataFiles m_DataFiles = null;
		private cTarget m_Target = null;

		private cTargetShotListView m_ShotListView = null;

		private cBatch m_Batch = null;

		//============================================================================*
		// cTargetDetailsForm() - Constructor
		//============================================================================*

		public cTargetDetailsForm(cDataFiles DataFiles, cTarget Target)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;
			m_Target = new cTarget(Target);

			if (m_Target.BatchID != 0)
				m_Batch = m_DataFiles.GetBatchByID(m_Target.BatchID);

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			DatePicker.ValueChanged += OnDateChanged;
			ShooterTextBox.TextChanged += OnShooterChanged;
			LocationTextBox.TextChanged += OnLocationChanged;
			EventTextBox.TextChanged += OnEventChanged;
			NotesTextBox.TextChanged += OnNotesChanged;

			FirearmCombo.SelectedIndexChanged += OnFirearmChanged;

			//----------------------------------------------------------------------------*
			// Size Dialog and create Sho tList View
			//----------------------------------------------------------------------------*

			SetClientSizeCore(GeneralGroupBox.Location.X + GeneralGroupBox.Width + 10, OKButton.Location.Y + OKButton.Height + 20);

			m_ShotListView = new cTargetShotListView(m_DataFiles, m_Target);

			m_ShotListView.Location = new Point(6, 25);
			m_ShotListView.Size = new Size(ShotDataGroupBox.Width - 12, ShotDataGroupBox.Height - 31);

			m_ShotListView.TabIndex = 0;

			ShotDataGroupBox.Controls.Add(m_ShotListView);

			//----------------------------------------------------------------------------*
			// Populate Data
			//----------------------------------------------------------------------------*

			PopulateFirearmCombo();

			PopulateDetailData();

			//----------------------------------------------------------------------------*
			// Finish up and exit
			//----------------------------------------------------------------------------*

			m_fInitialized = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnDateChanged()
		//============================================================================*

		private void OnDateChanged(Object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Target.Date = DatePicker.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnEventChanged()
		//============================================================================*

		private void OnEventChanged(Object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Target.Event = EventTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnFirearmChanged()
		//============================================================================*

		private void OnFirearmChanged(Object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			if (FirearmCombo.SelectedIndex > 0)
				m_Target.Firearm = (cFirearm) FirearmCombo.SelectedItem;
			else
				m_Target.Firearm = null;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnLocationChanged()
		//============================================================================*

		private void OnLocationChanged(Object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Target.Location = LocationTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnNotesChanged()
		//============================================================================*

		private void OnNotesChanged(Object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Target.Notes = NotesTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnShooterChanged()
		//============================================================================*

		private void OnShooterChanged(Object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Target.Shooter = ShooterTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// PopulateDetailData()
		//============================================================================*

		private void PopulateDetailData()
			{
			DatePicker.Value = m_Target.Date;
			ShooterTextBox.Value = m_Target.Shooter;

			if (m_Target.BatchID != 0)
				{
				m_Target.Event = String.Format("Batch {0:G0} Testing", m_Target.BatchID);

				EventTextBox.Enabled = false;
				}

			LocationTextBox.Value = m_Target.Location;
			EventTextBox.Value = m_Target.Event;
			NotesTextBox.Value = m_Target.Notes;
			}

		//============================================================================*
		// PopulateFirearmCombo()
		//============================================================================*

		private void PopulateFirearmCombo()
			{
			FirearmCombo.Items.Clear();

			FirearmCombo.Items.Add("No Specific Firearm");

			if (m_Target.BatchID == 0)
				{
				cFirearm SelectFirearm = null;

				foreach (cFirearm Firearm in m_DataFiles.FirearmList)
					{
					if (Firearm.HasCaliber(m_Target.Caliber))
						{
						FirearmCombo.Items.Add(Firearm);

						if (m_Target.Firearm != null && Firearm.CompareTo(m_Target.Firearm) == 0)
							SelectFirearm = Firearm;
						}
					}

				if (SelectFirearm != null)
					FirearmCombo.SelectedItem = SelectFirearm;
				}
			else
				{
				if (m_Target.Firearm != null)
					{
					FirearmCombo.Items.Clear();

					FirearmCombo.Items.Add(m_Target.Firearm);

					FirearmCombo.SelectedItem = m_Target.Firearm;
					}
				}

			if (FirearmCombo.SelectedIndex < 0 && FirearmCombo.Items.Count > 0)
				FirearmCombo.SelectedIndex = 0;
			}

		//============================================================================*
		// Target Property
		//============================================================================*

		public cTarget Target
			{
			get
				{
				return (m_Target);
				}
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			bool fEnableOK = m_fChanged;

			OKButton.Enabled = fEnableOK;
			}
		}
	}
