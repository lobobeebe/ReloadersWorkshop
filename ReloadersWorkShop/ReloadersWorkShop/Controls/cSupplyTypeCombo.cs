//============================================================================*
// cSupplyTypeCombo.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Windows.Forms;

using CommonLib.Controls;

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop.Controls
	{
	//============================================================================*
	// cSupplyTypeCombo Class
	//============================================================================*

	public class cSupplyTypeCombo : cComboBox
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cSupply.eSupplyTypes m_eValue = cSupply.eSupplyTypes.Bullets;

		private bool m_fIncludeAny = false;
		private bool m_fIncludeAmmo = false;

		private bool m_fPopulating = false;

		//============================================================================*
		// cSupplyTypeCombo() - Default Constructor
		//============================================================================*

		public cSupplyTypeCombo()
			{
			Initialize();

			AutoCompleteMode = AutoCompleteMode.Suggest;
			AutoCompleteSource = AutoCompleteSource.ListItems;
			DropDownStyle = ComboBoxStyle.DropDownList;

			Size = new System.Drawing.Size(128, 23);

			m_fIncludeAmmo = false;
			m_fIncludeAny = false;
			}

		//============================================================================*
		// cSupplyTypeCombo() - Constructor
		//============================================================================*

		public cSupplyTypeCombo(bool fIncludeAmmo = false, bool fIncludeAny = false)
			{
			Initialize();

			AutoCompleteMode = AutoCompleteMode.Suggest;
			AutoCompleteSource = AutoCompleteSource.ListItems;
			DropDownStyle = ComboBoxStyle.DropDownList;

			m_fIncludeAmmo = fIncludeAmmo;
			m_fIncludeAny = fIncludeAny;
			}

		//============================================================================*
		// IncludeAny Property
		//============================================================================*

		public bool IncludeAny
			{
			get
				{
				return (m_fIncludeAny);
				}

			set
				{
				m_fIncludeAny = value;

				Populate();
				}
			}

		//============================================================================*
		// IncludeAmmo Property
		//============================================================================*

		public bool IncludeAmmo
			{
			get
				{
				return (m_fIncludeAmmo);
				}

			set
				{
				m_fIncludeAmmo = value;

				Populate();
				}
			}


		//============================================================================*
		// Initialize()
		//============================================================================*

		private void Initialize()
			{
			DropDownStyle = ComboBoxStyle.DropDownList;
			DropDownWidth = 100;

			ShowToolTips = cPreferences.StaticPreferences.ToolTips;

			ToolTip = "Select a supply type.";
			}

		//============================================================================*
		// OnDropDown()
		//============================================================================*

		protected override void OnDropDown(EventArgs e)
			{
			int nCount = 4 + (m_fIncludeAny ? 1 : 0) + (m_fIncludeAmmo ? 1 : 0);

			while (Items.Count > nCount)
				Items.RemoveAt(nCount);

			base.OnDropDown(e);
			}

		//============================================================================*
		// OnSelectedIndexChanged()
		//============================================================================*

		protected override void OnSelectedIndexChanged(EventArgs e)
			{
			if (m_fPopulating)
				return;

			m_eValue = (cSupply.eSupplyTypes) SelectedIndex;

			base.OnSelectedIndexChanged(e);
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		private void Populate()
			{
			m_fPopulating = true;

			Items.Clear();

			if (m_fIncludeAny)
				Items.Add("Any Supply Type");

			Items.Add("Bullets");
			Items.Add("Cases");
			Items.Add("Powder");
			Items.Add("Primers");

			if (m_fIncludeAmmo)
				Items.Add("Ammo");

			m_eValue = (cSupply.eSupplyTypes) 0;

			SelectedIndex = 0;

			m_fPopulating = false;
			}

		//============================================================================*
		// Value Property
		//============================================================================*

		public cSupply.eSupplyTypes Value
			{
			get
				{
				return (m_eValue - (m_fIncludeAny ? 1 : 0));
				}

			set
				{
				m_eValue = value;

				SelectedIndex = (int) m_eValue;
				}
			}
		}
	}
