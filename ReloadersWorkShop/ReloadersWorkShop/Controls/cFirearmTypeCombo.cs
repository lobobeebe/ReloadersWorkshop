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
using System.Drawing;
using System.Windows.Forms;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop.Controls
	{
	//============================================================================*
	// cFirearmTypeCombo Class
	//============================================================================*

	public class cFirearmTypeCombo : ComboBox
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cFirearm.eFireArmType m_eValue = cFirearm.eFireArmType.Handgun;

		private bool m_fIncludeAny = false;
		private bool m_fIncludeShotgun = false;

		private string m_strToolTip = "";

		private bool m_fPopulating = false;

		//============================================================================*
		// cFirearmTypeCombo() - DefaultConstructor
		//============================================================================*

		public cFirearmTypeCombo()
			{
			DropDownStyle = ComboBoxStyle.DropDownList;
			DropDownWidth = 100;

			Populate();
			}

		//============================================================================*
		// cFirearmTypeCombo() - Constructor
		//============================================================================*

		public cFirearmTypeCombo(bool fIncludeShotgun = false, bool  fIncludeAny = false)
			{
			DropDownStyle = ComboBoxStyle.DropDownList;
			DropDownWidth = 100;

			m_fIncludeShotgun = fIncludeShotgun;
			m_fIncludeAny = fIncludeAny;

			Populate();
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
		// ToolTip Property
		//============================================================================*

		public string ToolTip
			{
			get
				{
				return (m_strToolTip);
				}
			set
				{
				m_strToolTip = value;
				}
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
