//============================================================================*
// cFirearmTypeCombo.cs
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
	// cFirearmTypeCombo Class
	//============================================================================*

	public class cFirearmTypeCombo : cComboBox
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cFirearm.eFireArmType m_eValue = cFirearm.eFireArmType.Handgun;

		private bool m_fIncludeAny = false;
		private bool m_fIncludeShotgun = false;

		private bool m_fPopulating = false;

		//============================================================================*
		// cFirearmTypeCombo() - Default Constructor
		//============================================================================*

		public cFirearmTypeCombo()
			{
			Initialize();
			}

		//============================================================================*
		// cFirearmTypeCombo() - Constructor
		//============================================================================*

		public cFirearmTypeCombo(bool fIncludeShotgun = false, bool  fIncludeAny = false)
			{
			Initialize();

			m_fIncludeShotgun = fIncludeShotgun;
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
		// IncludeShotgun Property
		//============================================================================*

		public bool IncludeShotgun
			{
			get
				{
				return (m_fIncludeShotgun);
				}

			set
				{
				m_fIncludeShotgun = value;

				Populate();
				}
			}


		//============================================================================*
		// Initialize()
		//============================================================================*

		private  void Initialize()
			{
			DropDownStyle = ComboBoxStyle.DropDownList;
			DropDownWidth = 100;

			ShowToolTips = cPreferences.StaticPreferences.ToolTips;

			ToolTip = "Select a firearm type.";
			}

		//============================================================================*
		// OnDropDown()
		//============================================================================*

		protected override void OnDropDown(EventArgs e)
			{
			int nCount = 2 + (m_fIncludeAny ? 1 : 0) + (m_fIncludeShotgun ? 1 : 0);

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

			m_eValue = (cFirearm.eFireArmType) SelectedIndex;

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
				Items.Add("Any Firearm Type");

			Items.Add("Handgun");
			Items.Add("Rifle");

			if (m_fIncludeShotgun)
				Items.Add("Shotgun");

			m_eValue = (cFirearm.eFireArmType) 0;

			SelectedIndex = 0;

			m_fPopulating = false;
			}

		//============================================================================*
		// Value Property
		//============================================================================*

		public cFirearm.eFireArmType Value
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
