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

		private cDataFiles m_DataFiles = null;
		private cTarget m_Target = null;

		private cTargetShotListView m_ShotListView = null;

		//============================================================================*
		// cTargetDetailsForm() - Constructor
		//============================================================================*

		public cTargetDetailsForm(cDataFiles DataFiles, cTarget Target)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;
			m_Target = new cTarget(Target);

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			DatePicker.ValueChanged += OnDateChanged;
			ShooterTextBox.TextChanged += OnShooterChanged;
			LocationTextBox.TextChanged += OnLocationChanged;

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
			}

		//============================================================================*
		// OnDateChanged()
		//============================================================================*

		private void OnDateChanged(Object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Target.Date = DatePicker.Value;
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
			}

		//============================================================================*
		// OnLocationChanged()
		//============================================================================*

		private void OnLocationChanged(Object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Target.Location = LocationTextBox.Value;
			}

		//============================================================================*
		// OnShooterChanged()
		//============================================================================*

		private void OnShooterChanged(Object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Target.Shooter = ShooterTextBox.Value;
			}

		//============================================================================*
		// PopulateDetailData()
		//============================================================================*

		private void PopulateDetailData()
			{
			DatePicker.Value = m_Target.Date;
			LocationTextBox.Value = m_Target.Location;
			ShooterTextBox.Value = m_Target.Shooter;
			}

		//============================================================================*
		// PopulateFirearmCombo()
		//============================================================================*

		private void PopulateFirearmCombo()
			{
			FirearmCombo.Items.Clear();

			FirearmCombo.Items.Add("No Specific Firearm");

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
		}
	}
