//============================================================================*
// cFirearmTypeCombo.cs
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

		public cFirearmTypeCombo(bool fIncludeShotgun = false)
			{
			DropDownStyle = ComboBoxStyle.DropDownList;
			DropDownWidth = 100;

			m_fIncludeShotgun = fIncludeShotgun;

			Populate();
			}

		//============================================================================*
		// IncludeShotgun Property
		//============================================================================*

		public bool IncludeShotgun
			{
			get {  return(m_fIncludeShotgun); }
			
			set
				{
				m_fIncludeShotgun = value;

				Populate();
				}
			}

		//============================================================================*
		// OnDropDown()
		//============================================================================*

		protected override void OnDropDown(EventArgs e)
			{
			while (Items.Count > (m_fIncludeShotgun ? 3 : 2))
				Items.RemoveAt(m_fIncludeShotgun ? 3 : 2);

			base.OnDropDown(e);
			}

		//============================================================================*
		// OnSelectedIndexChanged()
		//============================================================================*

		protected override void OnSelectedIndexChanged(EventArgs e)
			{
			if (m_fPopulating)
				return;

			m_eValue = (cFirearm.eFireArmType)SelectedIndex;

			base.OnSelectedIndexChanged(e);
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		private void Populate()
			{
			m_fPopulating = true;

			Items.Clear();

			Items.Add("Handgun");
			Items.Add("Rifle");

			if (m_fIncludeShotgun)
				Items.Add("Shotgun");

			SelectedIndex = (int)m_eValue;

			m_fPopulating = false;
			}

		//============================================================================*
		// ToolTip Property
		//============================================================================*

		public string ToolTip
			{
			get { return (m_strToolTip); }
			set { m_strToolTip = value; }
			}

		//============================================================================*
		// Value Property
		//============================================================================*

		public cFirearm.eFireArmType Value
			{
			get { return (m_eValue); }

			set
				{
				m_eValue = value;

				SelectedIndex = (int)m_eValue;
				}
			}
		}
	}
