//============================================================================*
// cTurretTypeCombo.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Windows.Forms;

//============================================================================*
// CommonLib Using Statements
//============================================================================*

using CommonLib.Controls;

//============================================================================*
// Applivcation Apecific Using Statements
//============================================================================*

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop.Controls
	{
	//============================================================================*
	// cTurretTypeCombo Class
	//============================================================================*

	public class cTurretTypeCombo : cComboBox
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cFirearm.eTurretType m_eValue = cFirearm.eTurretType.MOA;

		private bool m_fPopulating = false;

		//============================================================================*
		// cTurretTypeCombo() - Default Constructor
		//============================================================================*

		public cTurretTypeCombo()
			{
			Initialize();
			}

		//============================================================================*
		// cTurretTypeCombo() - Constructor
		//============================================================================*

		public cTurretTypeCombo(bool fIncludeShotgun = false, bool fIncludeAny = false)
			{
			Initialize();
			}

		//============================================================================*
		// Initialize()
		//============================================================================*

		private void Initialize()
			{
			DropDownStyle = ComboBoxStyle.DropDownList;
			DropDownWidth = 100;

			ShowToolTips = cPreferences.StaticPreferences.ToolTips;

			ToolTip = "Select the adjustment type for the specified scope.";
			}

		//============================================================================*
		// OnDropDown()
		//============================================================================*

		protected override void OnDropDown(EventArgs e)
			{
			while (Items.Count > 2)
				Items.RemoveAt(2);

			base.OnDropDown(e);
			}

		//============================================================================*
		// OnSelectedIndexChanged()
		//============================================================================*

		protected override void OnSelectedIndexChanged(EventArgs e)
			{
			if (m_fPopulating)
				return;

			if (SelectedIndex >= 0)
				m_eValue = (cFirearm.eTurretType) SelectedIndex;

			base.OnSelectedIndexChanged(e);
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		private void Populate()
			{
			m_fPopulating = true;

			Items.Clear();

			Items.Add("MOA");
			Items.Add("MilDot");

			m_fPopulating = false;
			}

		//============================================================================*
		// Value Property
		//============================================================================*

		public cFirearm.eTurretType Value
			{
			get
				{
				return (m_eValue);
				}

			set
				{
				if (Items.Count != 2)
					Populate();

				m_eValue = value;

				SelectedIndex = (int) m_eValue;
				}
			}
		}
	}
