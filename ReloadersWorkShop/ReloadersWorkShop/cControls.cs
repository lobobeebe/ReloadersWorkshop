//============================================================================*
// cControls.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Windows.Forms;

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	public static class cControls
		{
		//============================================================================*
		// OnColumnWidthChanged()
		//============================================================================*

		public static void OnColumnWidthChanged(object sender, ColumnWidthChangedEventArgs args, cDataFiles DataFiles, cPreferences.eApplicationListView eListView)
			{
			DataFiles.Preferences.SetColumnWidth(eListView, (sender as ListView).Columns[args.ColumnIndex].Text, (sender as ListView).Columns[args.ColumnIndex].Width);
			}

		//============================================================================*
		// PopulateCaliberCombo() - Case
		//============================================================================*

		public static void PopulateCaliberCombo(ComboBox CaliberCombo, cDataFiles DataFiles, cCase Case, cFirearm.eFireArmType eFirearmType = cFirearm.eFireArmType.None)
			{
			CaliberCombo.Items.Clear();

			cCaliber.CurrentFirearmType = eFirearmType;

			cCaliber SelectCaliber = null;

			foreach (cCaliber CheckCaliber in DataFiles.CaliberList)
				{
				if ((!DataFiles.Preferences.HideUncheckedCalibers || CheckCaliber.Checked) && !CheckCaliber.Rimfire)
					{
					if (eFirearmType == cFirearm.eFireArmType.None || CheckCaliber.FirearmType == eFirearmType)
						{
						CaliberCombo.Items.Add(CheckCaliber);

						if (Case != null && SelectCaliber == null && Case.Caliber != null && Case.Caliber.CompareTo(CheckCaliber) == 0)
							SelectCaliber = CheckCaliber;
						}
					}
				}

			if (SelectCaliber != null)
				{
				CaliberCombo.SelectedItem = SelectCaliber;

				if (CaliberCombo.SelectedIndex < 0 && CaliberCombo.Items.Count > 0)
					CaliberCombo.SelectedIndex = 0;
				}
			else
				{
				if (Case != null && Case.Caliber != null)
					{
					if (!CaliberCombo.Items.Contains(Case.Caliber))
						CaliberCombo.Items.Add(Case.Caliber);

					CaliberCombo.SelectedItem = Case.Caliber;
					}

				if (CaliberCombo.SelectedIndex == -1 && CaliberCombo.Items.Count > 0)
					CaliberCombo.SelectedIndex = 0;
				}
			}

		//============================================================================*
		// PopulateFirearmCombo()
		//============================================================================*

		public static void PopulateFirearmCombo(ComboBox FirearmCombo, cDataFiles DataFiles, cFirearm Firearm = null, cCaliber Caliber = null, cFirearm.eFireArmType eFirearmType = cFirearm.eFireArmType.None, bool fAddFactory = false)
			{
			//----------------------------------------------------------------------------*
			// Validate Input
			//----------------------------------------------------------------------------*

			if (DataFiles == null || FirearmCombo == null)
				return;

			//----------------------------------------------------------------------------*
			// Populate Combo
			//----------------------------------------------------------------------------*

			FirearmCombo.Items.Clear();

			if (fAddFactory)
				FirearmCombo.Items.Add("Factory");

			cCaliber.CurrentFirearmType = eFirearmType;

			cFirearm SelectedFirearm = null;

			foreach (cFirearm CheckFirearm in DataFiles.FirearmList)
				{
				if (Caliber == null || CheckFirearm.HasCaliber(Caliber))
					{
					if ((eFirearmType == cFirearm.eFireArmType.None || CheckFirearm.FirearmType == eFirearmType))
						{
						FirearmCombo.Items.Add(CheckFirearm);

						if (Firearm != null && CheckFirearm.CompareTo(Firearm) == 0)
							SelectedFirearm = CheckFirearm;
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Select a firearm in the combo
			//----------------------------------------------------------------------------*

			if (SelectedFirearm != null)
				FirearmCombo.SelectedItem = SelectedFirearm;
			else
				{
				if (FirearmCombo.Items.Count > 0)
					FirearmCombo.SelectedIndex = 0;
				else
					{
					FirearmCombo.SelectedIndex = -1;
					}
				}
			}

		//============================================================================*
		// PopulateManufacturerCombo()
		//============================================================================*

		public static void PopulateManufacturerCombo(ComboBox ManufacturerCombo, cDataFiles DataFiles, cManufacturer Manufacturer = null, cFirearm.eFireArmType eFirearmType = cFirearm.eFireArmType.None, int nSupplyType = -1)
			{
			ManufacturerCombo.Items.Clear();

			//----------------------------------------------------------------------------*
			// Loop through the manufacturers
			//----------------------------------------------------------------------------*

			cManufacturer SelectManufacturer = null;

			foreach (cManufacturer CheckManufacturer in DataFiles.ManufacturerList)
				{
				//----------------------------------------------------------------------------*
				// Check that this manufacturer provides the specfied firearm type, if any
				//----------------------------------------------------------------------------*

				switch (eFirearmType)
					{
					case cFirearm.eFireArmType.None:
						break;

					case cFirearm.eFireArmType.Handgun:
						if (!CheckManufacturer.Handguns)
							continue;

						break;

					case cFirearm.eFireArmType.Rifle:
						if (!CheckManufacturer.Rifles)
							continue;

						break;

					case cFirearm.eFireArmType.Shotgun:
						if (!CheckManufacturer.Shotguns)
							continue;

						break;
					}

				//----------------------------------------------------------------------------*
				// Check that this manufacturer provides the specfied supply type, if any
				//----------------------------------------------------------------------------*

				switch (nSupplyType)
					{
					case -1:
						break;

					case (int)cSupply.eSupplyTypes.Bullets:
						if (!CheckManufacturer.Bullets && !CheckManufacturer.BulletMolds)
							continue;

						break;

					case (int)cSupply.eSupplyTypes.Cases:
						if (!CheckManufacturer.Cases)
							continue;

						break;

					case (int)cSupply.eSupplyTypes.Powder:
						if (!CheckManufacturer.Powder)
							continue;

						break;

					case (int)cSupply.eSupplyTypes.Primers:
						if (!CheckManufacturer.Primers)
							continue;

						break;
					}

				//----------------------------------------------------------------------------*
				// If we get to here, the manufacturer is ok to be added to the combo
				//----------------------------------------------------------------------------*

				if (Manufacturer != null && CheckManufacturer.CompareTo(Manufacturer) == 0)
					SelectManufacturer = CheckManufacturer;

				ManufacturerCombo.Items.Add(CheckManufacturer);

				}

			if (SelectManufacturer != null)
				{
				ManufacturerCombo.SelectedIndex = ManufacturerCombo.Items.IndexOf(SelectManufacturer);

				if (ManufacturerCombo.SelectedIndex < 0 && ManufacturerCombo.Items.Count > 0)
					ManufacturerCombo.SelectedIndex = 0;
				}
			else
				{
				if (ManufacturerCombo.Items.Count > 0)
					ManufacturerCombo.SelectedIndex = 0;
				}
			}
		}
	}
