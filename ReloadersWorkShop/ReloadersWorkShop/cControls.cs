//============================================================================*
// cControls.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
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
		// InternalErrorMessageBox()
		//============================================================================*

		public static void InternalErrorMessageBox(Exception e)
			{
			string strMessage = "An internal error has occurred!\n\nSystem Message:\n\n";
			strMessage += e.ToString();
			strMessage += String.Format("\n\nPlease report the above message to the {0} Support Team.\n\nThe program will continue normally.", Application.ProductName);

			MessageBox.Show(strMessage, "Internal Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		//============================================================================*
		// OnColumnWidthChanged()
		//============================================================================*

		public static void OnColumnWidthChanged(object sender, ColumnWidthChangedEventArgs args, cDataFiles DataFiles, cPreferences.eApplicationListView eListView)
			{
			DataFiles.Preferences.SetColumnWidth(eListView, (sender as ListView).Columns[args.ColumnIndex].Text, (sender as ListView).Columns[args.ColumnIndex].Width);
			}

		//============================================================================*
		// OnTextBoxGotFocus()
		//============================================================================*

		public static void OnTextBoxGotFocus(object sender, EventArgs e)
			{
			(sender as TextBox).Select(0, (sender as TextBox).Text.Length);
			}

		//============================================================================*
		// PopulateBulletCombo()
		//============================================================================*

		public static void PopulateBulletCombo(ComboBox BulletCombo, cDataFiles DataFiles, cBullet Bullet = null, cCaliber Caliber = null, int nFirearmType = -1, bool fAnyBullet = false)
			{
			BulletCombo.Items.Clear();

			cBullet SelectBullet = null;

			if (fAnyBullet)
				BulletCombo.Items.Add("Any Bullet");

			foreach (cBullet CheckBullet in DataFiles.BulletList)
				{
				if ((!DataFiles.Preferences.HideUncheckedCalibers || Caliber == null || Caliber.Checked) &&
					(!DataFiles.Preferences.HideUncheckedSupplies || CheckBullet.Checked) &&
					(Caliber == null || CheckBullet.HasCaliber(Caliber)) &&
					(nFirearmType == -1 || CheckBullet.FirearmType == (cFirearm.eFireArmType)nFirearmType))
					{
					BulletCombo.Items.Add(CheckBullet);

					if (CheckBullet.CompareTo(Bullet) == 0)
						SelectBullet = CheckBullet;
					}
				}

			if (SelectBullet != null)
				BulletCombo.SelectedItem = SelectBullet;
			else
				{
				if (BulletCombo.Items.Count > 0)
					{
					BulletCombo.SelectedIndex = 0;
					}
				}
			}

		//============================================================================*
		// PopulateCaliberCombo()
		//============================================================================*

		public static void PopulateCaliberCombo(ComboBox CaliberCombo, cDataFiles DataFiles, int nFirearmType = -1, bool fAnyCaliber = false)
			{
			CaliberCombo.Items.Clear();

			cCaliber SelectCaliber = null;

			if (fAnyCaliber)
				CaliberCombo.Items.Add("Any Caliber");

			foreach (cCaliber Caliber in DataFiles.CaliberList)
				{
				if (!DataFiles.Preferences.HideUncheckedCalibers || Caliber.Checked)
					{
					if (nFirearmType == -1 || Caliber.FirearmType == (cFirearm.eFireArmType)nFirearmType)
						{
						CaliberCombo.Items.Add(Caliber);
						}
					}


				if (SelectCaliber != null)
					{
					CaliberCombo.SelectedIndex = CaliberCombo.Items.IndexOf(SelectCaliber);

					if (CaliberCombo.SelectedIndex < 0 && CaliberCombo.Items.Count > 0)
						CaliberCombo.SelectedIndex = 0;
					}
				else
					{
					if (CaliberCombo.Items.Count > 0)
						CaliberCombo.SelectedIndex = 0;
					}
				}
			}

		//============================================================================*
		// PopulateCaliberCombo() - Batch
		//============================================================================*

		public static void PopulateCaliberCombo(ComboBox CaliberCombo, cDataFiles DataFiles, cBatch Batch)
			{
			CaliberCombo.Items.Clear();

			cCaliber SelectCaliber = null;

			foreach (cCaliber CheckCaliber in DataFiles.CaliberList)
				{
				if (!DataFiles.Preferences.HideUncheckedCalibers || CheckCaliber.Checked)
					{
					if (CheckCaliber.FirearmType == Batch.Load.FirearmType)
						{
						CaliberCombo.Items.Add(CheckCaliber);

						if (SelectCaliber == null && Batch.Load.Caliber != null && Batch.Load.Caliber.CompareTo(CheckCaliber) == 0)
							SelectCaliber = CheckCaliber;
						}
					}
				}

			if (SelectCaliber != null)
				{
				CaliberCombo.SelectedIndex = CaliberCombo.Items.IndexOf(SelectCaliber);

				if (CaliberCombo.SelectedIndex < 0 && CaliberCombo.Items.Count > 0)
					CaliberCombo.SelectedIndex = 0;
				}
			else
				{
				if (CaliberCombo.Items.Count > 0)
					CaliberCombo.SelectedIndex = 0;
				}
			}

		//============================================================================*
		// PopulateCaliberCombo() - Bullet
		//============================================================================*

		public static void PopulateCaliberCombo(ComboBox CaliberCombo, cDataFiles DataFiles, cBullet Bullet, int nFirearmType = -1)
			{
			CaliberCombo.Items.Clear();

			cCaliber SelectCaliber = null;

			foreach (cCaliber CheckCaliber in DataFiles.CaliberList)
				{
				if (!DataFiles.Preferences.HideUncheckedCalibers || CheckCaliber.Checked)
					{
					if (nFirearmType == -1 || CheckCaliber.FirearmType == (cFirearm.eFireArmType)nFirearmType)
						{
						if (Bullet == null || Bullet.CanBeCaliber(CheckCaliber))
							{
							if (Bullet == null || !Bullet.HasCaliber(CheckCaliber))
								{
								CaliberCombo.Items.Add(CheckCaliber);

								if (SelectCaliber == null && Bullet != null && Bullet.CanBeCaliber(CheckCaliber))
									SelectCaliber = CheckCaliber;
								}
							}
						}
					}
				}

			if (SelectCaliber != null)
				{
				CaliberCombo.SelectedIndex = CaliberCombo.Items.IndexOf(SelectCaliber);

				if (CaliberCombo.SelectedIndex < 0 && CaliberCombo.Items.Count > 0)
					CaliberCombo.SelectedIndex = 0;
				}
			else
				{
				if (CaliberCombo.Items.Count > 0)
					CaliberCombo.SelectedIndex = 0;
				}
			}

		//============================================================================*
		// PopulateCaliberCombo() - Caliber
		//============================================================================*

		public static void PopulateCaliberCombo(ComboBox CaliberCombo, cDataFiles DataFiles, cCaliber Caliber, int nFirearmType = -1)
			{
			CaliberCombo.Items.Clear();

			cCaliber SelectCaliber = null;

			foreach (cCaliber CheckCaliber in DataFiles.CaliberList)
				{
				if (!DataFiles.Preferences.HideUncheckedCalibers || CheckCaliber.Checked)
					{
					if (nFirearmType == -1 || CheckCaliber.FirearmType == (cFirearm.eFireArmType)nFirearmType)
						{
						CaliberCombo.Items.Add(CheckCaliber);

						if (SelectCaliber == null && Caliber != null && Caliber.CompareTo(CheckCaliber) == 0)
							SelectCaliber = CheckCaliber;
						}

					}
				}

			if (SelectCaliber != null)
				{
				CaliberCombo.SelectedIndex = CaliberCombo.Items.IndexOf(SelectCaliber);

				if (CaliberCombo.SelectedIndex < 0 && CaliberCombo.Items.Count > 0)
					CaliberCombo.SelectedIndex = 0;
				}
			else
				{
				if (CaliberCombo.Items.Count > 0)
					CaliberCombo.SelectedIndex = 0;
				}
			}

		//============================================================================*
		// PopulateCaliberCombo() - Case
		//============================================================================*

		public static void PopulateCaliberCombo(ComboBox CaliberCombo, cDataFiles DataFiles, cCase Case, cFirearm.eFireArmType eFirearmType = cFirearm.eFireArmType.None)
			{
			CaliberCombo.Items.Clear();

			cCaliber SelectCaliber = null;

			foreach (cCaliber CheckCaliber in DataFiles.CaliberList)
				{
				if (!DataFiles.Preferences.HideUncheckedCalibers || CheckCaliber.Checked)
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
		// PopulateCaliberCombo() - Firearm
		//============================================================================*

		public static void PopulateCaliberCombo(ComboBox CaliberCombo, cDataFiles DataFiles, cFirearm Firearm, int nFirearmType = -1)
			{
			CaliberCombo.Items.Clear();

			cCaliber SelectCaliber = null;

			foreach (cCaliber Caliber in DataFiles.CaliberList)
				{
				if (!DataFiles.Preferences.HideUncheckedCalibers || Caliber.Checked)
					{
					if (nFirearmType == -1 || Caliber.FirearmType == (cFirearm.eFireArmType)nFirearmType)
						{
						CaliberCombo.Items.Add(Caliber);

						if (Firearm != null && Firearm.HasCaliber(Caliber))
							SelectCaliber = Caliber;
						}

					}
				}

			if (SelectCaliber != null)
				{
				CaliberCombo.SelectedIndex = CaliberCombo.Items.IndexOf(SelectCaliber);

				if (CaliberCombo.SelectedIndex < 0 && CaliberCombo.Items.Count > 0)
					CaliberCombo.SelectedIndex = 0;
				}
			else
				{
				if (CaliberCombo.Items.Count > 0)
					CaliberCombo.SelectedIndex = 0;
				}
			}

		//============================================================================*
		// PopulateCaliberCombo() - Load
		//============================================================================*

		public static void PopulateCaliberCombo(ComboBox CaliberCombo, cDataFiles DataFiles, cLoad Load)
			{
			CaliberCombo.Items.Clear();

			cCaliber SelectCaliber = null;

			foreach (cCaliber CheckCaliber in DataFiles.CaliberList)
				{
				if (!DataFiles.Preferences.HideUncheckedCalibers || CheckCaliber.Checked)
					{
					if (Load == null || CheckCaliber.FirearmType == Load.FirearmType)
						{
						CaliberCombo.Items.Add(CheckCaliber);

						if (Load != null && CheckCaliber.CompareTo(Load.Caliber) == 0)
							SelectCaliber = Load.Caliber;
						}
					}
				}

			if (SelectCaliber != null)
				{
				CaliberCombo.SelectedIndex = CaliberCombo.Items.IndexOf(SelectCaliber);

				if (CaliberCombo.SelectedIndex < 0 && CaliberCombo.Items.Count > 0)
					CaliberCombo.SelectedIndex = 0;
				}
			else
				{
				if (CaliberCombo.Items.Count > 0)
					CaliberCombo.SelectedIndex = 0;
				}
			}

		//============================================================================*
		// PopulateCaseCombo()
		//============================================================================*

		public static void PopulateCaseCombo(ComboBox CaseCombo, cDataFiles DataFiles, cCase Case = null, cCaliber Caliber = null, int nFirearmType = -1)
			{
			CaseCombo.Items.Clear();

			cCase SelectCase = null;

			foreach (cCase CheckCase in DataFiles.CaseList)
				{
				if ((!DataFiles.Preferences.HideUncheckedSupplies || CheckCase.Checked) &&
					(nFirearmType == -1 || CheckCase.FirearmType == (cFirearm.eFireArmType)nFirearmType) &&
					(Caliber == null || CheckCase.Caliber.CompareTo(Caliber) == 0))
					{
					CaseCombo.Items.Add(CheckCase);

					if (CheckCase.CompareTo(Case) == 0)
						SelectCase = CheckCase;
					}
				}

			if (SelectCase != null)
				CaseCombo.SelectedItem = SelectCase;
			else
				{
				if (CaseCombo.Items.Count > 0)
					CaseCombo.SelectedIndex = 0;
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

		//============================================================================*
		// PopulatePowderCombo()
		//============================================================================*

		public static void PopulatePowderCombo(ComboBox PowderCombo, cDataFiles DataFiles, cPowder Powder = null, int nFirearmType = -1, bool fAnyPowder = false)
			{
			PowderCombo.Items.Clear();

			cPowder SelectPowder = null;

			if (fAnyPowder)
				PowderCombo.Items.Add("Any Powder");

			foreach (cPowder CheckPowder in DataFiles.PowderList)
				{
				if ((nFirearmType == -1 || CheckPowder.FirearmType == (cFirearm.eFireArmType)nFirearmType) &&
					(!DataFiles.Preferences.HideUncheckedSupplies || CheckPowder.Checked))
					{
					PowderCombo.Items.Add(CheckPowder);

					if (CheckPowder.CompareTo(Powder) == 0)
						SelectPowder = CheckPowder;
					}
				}

			if (SelectPowder != null)
				PowderCombo.SelectedItem = SelectPowder;
			else
				{
				if (PowderCombo.Items.Count > 0)
					PowderCombo.SelectedIndex = 0;
				}
			}

		//============================================================================*
		// PopulatePowderCombo()
		//============================================================================*

		public static void PopulatePowderCombo(ComboBox PowderCombo, cDataFiles DataFiles, cBullet Bullet, cPowder Powder, bool fAnyPowder = false)
			{
			PowderCombo.Items.Clear();

			cPowder SelectPowder = null;

			if (fAnyPowder)
				PowderCombo.Items.Add("Any Powder");

			foreach (cPowder CheckPowder in DataFiles.PowderList)
				{
				if ((Bullet == null || CheckPowder.FirearmType == Bullet.FirearmType) &&
					(!DataFiles.Preferences.HideUncheckedSupplies || CheckPowder.Checked))
					{
					bool fPowderFound = false;

					if (Bullet == null)
						fPowderFound = true;
					else
						{
						foreach(cLoad Load in DataFiles.LoadList)
							{
							if (Load.Bullet.CompareTo(Bullet) == 0)
								{
								if (CheckPowder.CompareTo(Load.Powder) == 0)
									{
									fPowderFound = true;
									}
								}
							}
						}

					if (fPowderFound)
						{
						PowderCombo.Items.Add(CheckPowder);

						if (CheckPowder.CompareTo(Powder) == 0)
							SelectPowder = CheckPowder;
						}
					}
				}

			if (SelectPowder != null)
				PowderCombo.SelectedItem = SelectPowder;
			else
				{
				if (PowderCombo.Items.Count > 0)
					PowderCombo.SelectedIndex = 0;
				}
			}

		//============================================================================*
		// PopulatePrimerCombo()
		//============================================================================*

		public static void PopulatePrimerCombo(ComboBox PrimerCombo, cDataFiles DataFiles, cPrimer Primer = null, cCaliber Caliber = null, int nFirearmType = -1)
			{
			PrimerCombo.Items.Clear();

			cPrimer SelectPrimer = null;

			foreach (cPrimer CheckPrimer in DataFiles.PrimerList)
				{
				if ((nFirearmType == -1 || CheckPrimer.FirearmType == (cFirearm.eFireArmType)nFirearmType) &&
					(!DataFiles.Preferences.HideUncheckedSupplies || CheckPrimer.Checked) &&
					(Caliber == null || ((!Caliber.MagnumPrimer && CheckPrimer.Standard) || (Caliber.MagnumPrimer && CheckPrimer.Magnum))) &&
					(Caliber == null || ((Caliber.SmallPrimer && CheckPrimer.Size == cPrimer.ePrimerSize.Small) || Caliber.LargePrimer && CheckPrimer.Size == cPrimer.ePrimerSize.Large)))
					{
					PrimerCombo.Items.Add(CheckPrimer);

					if (CheckPrimer.CompareTo(Primer) == 0)
						SelectPrimer = CheckPrimer;
					}
				}

			if (SelectPrimer != null)
				PrimerCombo.SelectedItem = SelectPrimer;
			else
				{
				if (PrimerCombo.Items.Count > 0)
					PrimerCombo.SelectedIndex = 0;
				}
			}

		//============================================================================*
		// PopulatePrimerSizeCombo()
		//============================================================================*

		public static void PopulatePrimerSizeCombo(ComboBox SizeCombo, cPrimer Primer)
			{
			SizeCombo.Items.Clear();

			SizeCombo.Items.Add("Small");
			SizeCombo.Items.Add("Large");

			SizeCombo.SelectedIndex = (int)Primer.Size;
			}
		}
	}
