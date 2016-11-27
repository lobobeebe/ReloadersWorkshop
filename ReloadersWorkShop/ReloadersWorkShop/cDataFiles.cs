//============================================================================*
// cDataFiles.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

//============================================================================*
// CommonLib Using Statements
//============================================================================*

using CommonLib.Controls;
using CommonLib.Conversions;

//============================================================================*
// Application Specific Using Statements
//============================================================================*

using ReloadersWorkShop.Ballistics;
using ReloadersWorkShop.Preferences;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cDataFiles Class
	//============================================================================*

	public class cDataFiles
		{
		//============================================================================*
		// Public Enumerations
		//============================================================================*

		public enum eDataType
			{
			Altitude,
			BulletWeight,
			CanWeight,
			Dimension,
			Firearm,
			GroupSize,
			PowderWeight,
			Pressure,
			Range,
			ShotWeight,
			Speed,
			Temperature,
			Velocity,
			Quantity,
			Cost
			}

		public enum eExportType
			{
			CSV = 0,
			XML,
			}

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private Form m_MainForm = null;

		private cBatchList m_BatchList = null;
		private cBulletList m_BulletList = null;
		private cCaliberList m_CaliberList = null;
		private cCaseList m_CaseList = null;
		private cFirearmList m_FirearmList = null;
		private cLoadList m_LoadList = null;
		private cManufacturerList m_ManufacturerList = null;
		private cPowderList m_PowderList = null;
		private cPrimerList m_PrimerList = null;
		private cAmmoList m_AmmoList = null;
		private cGearList m_GearList = null;

		private cManufacturer m_BatchManufacturer = null;

		//============================================================================*
		// cDataFiles() - Default Constructor
		//============================================================================*

		public cDataFiles()
			{
			}

		//============================================================================*
		// cDataFiles() - Constructor
		//============================================================================*

		public cDataFiles(Form MainForm)
			{
			m_MainForm = MainForm;

			Load();
			}

		//============================================================================*
		// ActivityCount Property
		//============================================================================*

		public int ActivityCount
			{
			get
				{
				int nCount = 0;

				foreach (cSupply Supply in m_AmmoList)
					nCount += Supply.TransactionList.Count;

				foreach (cSupply Supply in m_BulletList)
					nCount += Supply.TransactionList.Count;

				foreach (cSupply Supply in m_CaseList)
					nCount += Supply.TransactionList.Count;

				foreach (cSupply Supply in m_PowderList)
					nCount += Supply.TransactionList.Count;

				foreach (cSupply Supply in m_PrimerList)
					nCount += Supply.TransactionList.Count;

				return (nCount);
				}
			}

		//============================================================================*
		// AddToSourceList()
		//============================================================================*

		public void AddToSourceList(ref List<string> SourceList, string strSource)
			{
			bool fFound = false;

			for (int i = 0; i < SourceList.Count; i++)
				{
				if (SourceList[i].ToUpper() == strSource.ToUpper())
					{
					fFound = true;

					break;
					}
				}

			if (!fFound)
				SourceList.Add(strSource);
			}

		//============================================================================*
		// AmmoList Property
		//============================================================================*

		public cAmmoList AmmoList
			{
			get
				{
				return (m_AmmoList);
				}
			}

		//============================================================================*
		// BatchBulletCost() - Batch ID
		//============================================================================*

		public double BatchBulletCost(int nBatchID)
			{
			cBatch Batch = null;

			foreach (cBatch CheckBatch in m_BatchList)
				{
				if (CheckBatch.BatchID == nBatchID)
					{
					Batch = CheckBatch;

					break;
					}
				}

			return (BatchBulletCost(Batch));
			}

		//============================================================================*
		// BatchBulletCost() - Batch
		//============================================================================*

		public double BatchBulletCost(cBatch Batch)
			{
			if (Batch == null)
				return (0.0);

			double dCost = 0.0;

			if (Batch.Load != null && Batch.Load.Bullet != null)
				dCost = SupplyCostEach(Batch.Load.Bullet) * Batch.NumRounds;

			return (dCost);
			}

		//============================================================================*
		// BatchCartridgeCost() - Batch ID
		//============================================================================*

		public double BatchCartridgeCost(int nBatchID)
			{
			cBatch Batch = null;

			foreach (cBatch CheckBatch in m_BatchList)
				{
				if (CheckBatch.BatchID == nBatchID)
					{
					Batch = CheckBatch;

					break;
					}
				}

			return (BatchCartridgeCost(Batch));
			}

		//============================================================================*
		// BatchCartridgeCost() - Batch
		//============================================================================*

		public double BatchCartridgeCost(cBatch Batch)
			{
			if (Batch == null)
				return (0.0);

			double dCost = 0.0;

			if (Batch.Load != null)
				{
				if (Batch.Load.Bullet != null)
					dCost += SupplyCostEach(Batch.Load.Bullet);

				if (Batch.Load.Powder != null)
					dCost += SupplyCostEach(Batch.Load.Powder) * Batch.PowderWeight;

				if (Batch.Load.Case != null)
					dCost += (SupplyCostEach(Batch.Load.Case) / (Batch.TimesFired + 1));

				if (Batch.Load.Primer != null)
					dCost += SupplyCostEach(Batch.Load.Primer);
				}

			return (dCost);
			}

		//============================================================================*
		// BatchCaseCost() - Batch ID
		//============================================================================*

		public double BatchCaseCost(int nBatchID)
			{
			cBatch Batch = null;

			foreach (cBatch CheckBatch in m_BatchList)
				{
				if (CheckBatch.BatchID == nBatchID)
					{
					Batch = CheckBatch;

					break;
					}
				}

			return (BatchCaseCost(Batch));
			}

		//============================================================================*
		// BatchCaseCost() - Batch
		//============================================================================*

		public double BatchCaseCost(cBatch Batch)
			{
			if (Batch == null)
				return (0.0);

			double dCost = 0.0;

			if (Batch.Load != null && Batch.Load.Case != null)
				dCost = SupplyCostEach(Batch.Load.Case) * Batch.NumRounds;

			return (dCost);
			}

		//============================================================================*
		// BatchCost() - Batch ID
		//============================================================================*

		public double BatchCost(int nBatchID)
			{
			cBatch Batch = null;

			foreach (cBatch CheckBatch in m_BatchList)
				{
				if (CheckBatch.BatchID == nBatchID)
					{
					Batch = CheckBatch;

					break;
					}
				}

			return (BatchCost(Batch));
			}

		//============================================================================*
		// BatchCost()
		//============================================================================*

		public double BatchCost(cBatch Batch)
			{
			if (Batch == null)
				return (0.0);

			return (BatchCartridgeCost(Batch) * Batch.NumRounds);
			}

		//============================================================================*
		// BatchList Property
		//============================================================================*

		public cBatchList BatchList
			{
			get
				{
				return (m_BatchList);
				}
			}

		//============================================================================*
		// BulletList Property
		//============================================================================*

		public cBulletList BulletList
			{
			get
				{
				return (m_BulletList);
				}
			}

		//============================================================================*
		// BatchManufacturer Property
		//============================================================================*

		public cManufacturer BatchManufacturer
			{
			get
				{
				return (m_BatchManufacturer);
				}
			}

		//============================================================================*
		// BatchPowderCost() - Batch ID
		//============================================================================*

		public double BatchPowderCost(int nBatchID)
			{
			cBatch Batch = null;

			foreach (cBatch CheckBatch in m_BatchList)
				{
				if (CheckBatch.BatchID == nBatchID)
					{
					Batch = CheckBatch;

					break;
					}
				}

			return (BatchPowderCost(Batch));
			}

		//============================================================================*
		// BatchPowderCost() - Batch
		//============================================================================*

		public double BatchPowderCost(cBatch Batch)
			{
			if (Batch == null)
				return (0.0);

			double dCost = 0.0;

			if (Batch.Load != null && Batch.Load.Powder != null)
				dCost = SupplyCostEach(Batch.Load.Powder) * (Batch.NumRounds * Batch.PowderWeight);

			return (dCost);
			}

		//============================================================================*
		// BatchPrimerCost() - Batch ID
		//============================================================================*

		public double BatchPrimerCost(int nBatchID)
			{
			cBatch Batch = null;

			foreach (cBatch CheckBatch in m_BatchList)
				{
				if (CheckBatch.BatchID == nBatchID)
					{
					Batch = CheckBatch;

					break;
					}
				}

			return (BatchPrimerCost(Batch));
			}

		//============================================================================*
		// BatchPrimerCost() - Batch
		//============================================================================*

		public double BatchPrimerCost(cBatch Batch)
			{
			if (Batch == null)
				return (0.0);

			double dCost = 0.0;

			if (Batch.Load != null && Batch.Load.Primer != null)
				dCost = SupplyCostEach(Batch.Load.Primer) * Batch.NumRounds;

			return (dCost);
			}

		//============================================================================*
		// CaliberList Property
		//============================================================================*

		public cCaliberList CaliberList
			{
			get
				{
				return (m_CaliberList);
				}
			}

		//============================================================================*
		// CaliberList Property
		//============================================================================*

		public cCaseList CaseList
			{
			get
				{
				return (m_CaseList);
				}
			}

		//============================================================================*
		// CheckNonZero()
		//============================================================================*

		public void CheckNonZero()
			{
			if (!cPreferences.StaticPreferences.AutoCheckNonZero)
				return;

			foreach (cSupply Supply in m_BulletList)
				Supply.Checked = SupplyQuantity(Supply) != 0.0;

			foreach (cSupply Supply in m_CaseList)
				Supply.Checked = SupplyQuantity(Supply) != 0.0;

			foreach (cSupply Supply in m_PrimerList)
				Supply.Checked = SupplyQuantity(Supply) != 0.0;

			foreach (cSupply Supply in m_PowderList)
				Supply.Checked = SupplyQuantity(Supply) != 0.0;

			foreach (cSupply Supply in m_AmmoList)
				Supply.Checked = SupplyQuantity(Supply) != 0.0;
			}

		//============================================================================*
		// CleanBackups()
		//============================================================================*

		public void CleanBackups()
			{
			if (!Preferences.BackupOK)
				return;

			DirectoryInfo FolderInfo = new DirectoryInfo(Preferences.BackupFolder);

			if (!FolderInfo.Exists)
				return;

			DateTime Today = DateTime.Today;

			FileInfo[] Files = FolderInfo.GetFiles();

			foreach (FileInfo Backupfile in Files)
				{
				if (Path.GetExtension(Backupfile.Name) != ".rwb")
					continue;

				DateTime BackupDate = Backupfile.LastWriteTime;

				TimeSpan BackupAge = Today - BackupDate;

				if (BackupAge.Days > Preferences.BackupKeepDays)
					Backupfile.Delete();
				}
			}

		//============================================================================*
		// ComparePartNumbers()
		//============================================================================*

		public static int ComparePartNumbers(string strPart1, string strPart2)
			{
			//----------------------------------------------------------------------------*
			// Check Nulls
			//----------------------------------------------------------------------------*

			if (strPart1 == null)
				{
				if (strPart2 == null)
					return (0);
				else
					return (-1);
				}
			else
				{
				if (strPart2 == null)
					return (1);
				}

			//----------------------------------------------------------------------------*
			// Pad part numbers
			//----------------------------------------------------------------------------*

			if (strPart1.Length != strPart2.Length)
				{
				string strPad = "";

				if (strPart1.Length > strPart2.Length)
					{
					while (strPart1.Length > strPart2.Length + strPad.Length)
						strPad += " ";

					strPart2 = strPad + strPart2;
					}
				else
					{
					while (strPart2.Length > strPart1.Length + strPad.Length)
						strPad += " ";

					strPart1 = strPad + strPart1;
					}
				}

			//----------------------------------------------------------------------------*
			// Do the compare and exit
			//----------------------------------------------------------------------------*

			int rc = strPart1.ToUpper().CompareTo(strPart2.ToUpper());

			return (rc);
			}

		//============================================================================*
		// CostText Property
		//============================================================================*

		public string CostText
			{
			get
				{
				string strText = "(Costs and values based on ";

				if (cPreferences.StaticPreferences.AverageCosts)
					strText += "average of all purchases,";
				else
					strText += "last purchase only,";

				if (!cPreferences.StaticPreferences.IncludeTaxShipping)
					strText += " not";

				strText += " including tax & shipping)";

				return (strText);
				}
			}

		//============================================================================*
		// DeleteBatch()
		//============================================================================*

		public void DeleteBatch(cBatch Batch)
			{
			m_BatchList.Remove(Batch);

			foreach (cLoad Load in m_LoadList)
				{
				foreach (cCharge Charge in Load.ChargeList)
					{
					while (true)
						{
						bool fTestRemoved = false;

						foreach (cChargeTest ChargeTest in Charge.TestList)
							{
							if (ChargeTest.BatchID == Batch.BatchID)
								{
								Charge.TestList.Remove(ChargeTest);

								fTestRemoved = true;

								break;
								}
							}

						if (!fTestRemoved)
							break;
						}
					}
				}
			}

		//============================================================================*
		// DeleteBullet()
		//============================================================================*

		public string DeleteBullet(cBullet Bullet, bool fCountOnly = false)
			{
			string strCount = "";

			int nLoadCount = 0;
			int nFirearmBulletCount = 0;

			//----------------------------------------------------------------------------*
			// Count all loads containing this bullet
			//----------------------------------------------------------------------------*

			if (fCountOnly)
				{
				foreach (cLoad Load in m_LoadList)
					{
					if (Load.Bullet.CompareTo(Bullet) == 0)
						nLoadCount++;
					}

				if (nLoadCount > 0)
					strCount += String.Format("{0:N0} Load{1}\n", nLoadCount, nLoadCount > 1 ? "s" : "");

				//----------------------------------------------------------------------------*
				// Count all firearm bullet records using this bullet
				//----------------------------------------------------------------------------*

				foreach (cFirearm CheckFirearm in m_FirearmList)
					{
					foreach (cFirearmBullet CheckFirearmBullet in CheckFirearm.FirearmBulletList)
						{
						if (CheckFirearmBullet.Bullet.CompareTo(Bullet) == 0)
							nFirearmBulletCount++;
						}
					}

				if (nFirearmBulletCount > 0)
					strCount += String.Format("{0:N0} Firearm Bullet{1}\n", nFirearmBulletCount, nFirearmBulletCount > 1 ? "s" : "");

				return (strCount);
				}

			//----------------------------------------------------------------------------*
			// Now delete the bullet
			//----------------------------------------------------------------------------*

			if (!fCountOnly)
				m_BulletList.Remove(Bullet);

			return (strCount);
			}

		//============================================================================*
		// DeleteBulletCaliber()
		//============================================================================*

		public string DeleteBulletCaliber(cBullet Bullet, cBulletCaliber BulletCaliber, bool fCountOnly = false)
			{
			string strCount = "";
			int nLoadCount = 0;

			//----------------------------------------------------------------------------*
			// Count all loads that contain this bullet/caliber combination
			//----------------------------------------------------------------------------*

			if (fCountOnly)
				{
				foreach (cLoad CheckLoad in m_LoadList)
					{
					if (CheckLoad.Bullet.CompareTo(Bullet) == 0 && CheckLoad.Caliber.CompareTo(BulletCaliber.Caliber) == 0)
						nLoadCount++;
					}

				if (nLoadCount > 0)
					strCount += String.Format("{0:N0} Load{1}\n", nLoadCount, nLoadCount > 1 ? "s" : "");
				}

			//----------------------------------------------------------------------------*
			// Now delete the bullet/caliber record
			//----------------------------------------------------------------------------*

			if (!fCountOnly)
				Bullet.CaliberList.Remove(BulletCaliber);

			return (strCount);
			}

		//============================================================================*
		// DeleteCaliber()
		//============================================================================*

		public string DeleteCaliber(cCaliber Caliber, bool fCountOnly = false)
			{
			string strCount = "";

			if (fCountOnly)
				{
				int nFirearmCount = 0;

				//----------------------------------------------------------------------------*
				// Count all Firearms that contain this caliber
				//----------------------------------------------------------------------------*

				foreach (cFirearm CheckFirearm in m_FirearmList)
					{
					if (CheckFirearm.HasCaliber(Caliber))
						nFirearmCount++;
					}

				if (nFirearmCount > 0)
					strCount += String.Format("{0:N0} Firearm{1}\n", nFirearmCount, nFirearmCount > 1 ? "s" : "");

				//----------------------------------------------------------------------------*
				// Count all Bullet Calibers that contain this caliber
				//----------------------------------------------------------------------------*

				int nBulletCount = 0;
				int nBulletCaliberCount = 0;

				foreach (cBullet CheckBullet in m_BulletList)
					{
					bool fBulletFound = false;

					foreach (cBulletCaliber CheckBulletCaliber in CheckBullet.CaliberList)
						{
						if (CheckBulletCaliber.Caliber.CompareTo(Caliber) == 0)
							{
							nBulletCaliberCount++;

							fBulletFound = true;
							}
						}

					if (fBulletFound)
						nBulletCount++;
					}

				if (nBulletCaliberCount > 0)
					strCount += String.Format("{0:N0} Cartridge Specific Data Record{1} for {2:N0} Bullet{3}\n", nBulletCaliberCount, nBulletCaliberCount > 1 ? "s" : "", nBulletCount, nBulletCount > 1 ? "s" : "");
				}

			//----------------------------------------------------------------------------*
			// Now delete the caliber if we're not just counting
			//----------------------------------------------------------------------------*

			if (!fCountOnly)
				m_CaliberList.Remove(Caliber);

			return (strCount);
			}

		//============================================================================*
		// DeleteCase()
		//============================================================================*

		public string DeleteCase(cCase Case, bool fCountOnly = false)
			{
			string strCount = "";
			int nLoadCount = 0;

			//----------------------------------------------------------------------------*
			// Count all loads containing this case
			//----------------------------------------------------------------------------*

			if (fCountOnly)
				{
				foreach (cLoad Load in m_LoadList)
					{
					if (Load.Case.CompareTo(Case) == 0)
						nLoadCount++;
					}

				if (nLoadCount > 0)
					strCount += String.Format("{0:N0} Load{1}\n", nLoadCount, nLoadCount > 1 ? "s" : "");
				}

			//----------------------------------------------------------------------------*
			// Now delete the case
			//----------------------------------------------------------------------------*

			if (!fCountOnly)
				m_CaseList.Remove(Case);

			return (strCount);
			}

		//============================================================================*
		// DeleteAmmo()
		//============================================================================*

		public void DeleteAmmo(cAmmo Ammo)
			{
			m_AmmoList.Remove(Ammo);
			}

		//============================================================================*
		// DeleteFirearm()
		//============================================================================*

		public string DeleteFirearm(cFirearm Firearm, bool fCountOnly = false)
			{
			string strCount = "";

			if (fCountOnly)
				{
				int nBatchCount = 0;
				int nBatchTestCount = 0;

				//----------------------------------------------------------------------------*
				// Count all Batches made for this firearm
				//----------------------------------------------------------------------------*

				foreach (cBatch CheckBatch in m_BatchList)
					{
					if (CheckBatch.Firearm != null && CheckBatch.Firearm.CompareTo(Firearm) == 0)
						nBatchCount++;

					if (CheckBatch.BatchTest != null && CheckBatch.BatchTest.Firearm != null && CheckBatch.BatchTest.Firearm.CompareTo(Firearm) == 0)
						nBatchTestCount++;
					}

				if (nBatchCount > 0)
					strCount += String.Format("{0:N0} Batcht{1}\n", nBatchCount, nBatchCount > 1 ? "es" : "");

				if (nBatchTestCount > 0)
					strCount += String.Format("{0:N0} Batch Test{1}\n", nBatchTestCount, nBatchTestCount > 1 ? "s" : "");
				}

			//----------------------------------------------------------------------------*
			// Now delete the firearm
			//----------------------------------------------------------------------------*

			if (!fCountOnly)
				m_FirearmList.Remove(Firearm);

			return (strCount);
			}

		//============================================================================*
		// DeleteFirearmAccessory()
		//============================================================================*

		public void DeleteFirearmAccessory(cGear Gear)
			{
			if (Gear == null)
				return;

			m_GearList.Remove(Gear);
			}

		//============================================================================*
		// DeleteLoad()
		//============================================================================*

		public string DeleteLoad(cLoad Load, bool fCountOnly = false)
			{
			string strCount = "";
			int nBatchCount = 0;

			//----------------------------------------------------------------------------*
			// Count all batches made with this load
			//----------------------------------------------------------------------------*

			if (fCountOnly)
				{
				foreach (cBatch CheckBatch in m_BatchList)
					{
					if (CheckBatch.Load.CompareTo(Load) == 0)
						nBatchCount++;
					}

				if (nBatchCount > 0)
					strCount += String.Format("{0:N0} Batch{1}\n", nBatchCount, nBatchCount > 1 ? "es" : "");
				}

			//----------------------------------------------------------------------------*
			// Now delete the load
			//----------------------------------------------------------------------------*

			if (!fCountOnly)
				m_LoadList.Remove(Load);

			return (strCount);
			}

		//============================================================================*
		// DeleteManufacturer()
		//============================================================================*

		public string DeleteManufacturer(cManufacturer Manufacturer, bool fCountOnly = false)
			{
			string strCount = "";

			if (fCountOnly)
				{
				int nBulletCount = 0;
				int nCaseCount = 0;
				int nPowderCount = 0;
				int nPrimerCount = 0;
				int nFirearmCount = 0;
				int nFirearmAccessoryCount = 0;

				//----------------------------------------------------------------------------*
				// Count all firearms made by this manufacturer
				//----------------------------------------------------------------------------*

				foreach (cFirearm CheckFirearm in m_FirearmList)
					{
					if (CheckFirearm.Manufacturer.CompareTo(Manufacturer) == 0)
						nFirearmCount++;
					}

				//----------------------------------------------------------------------------*
				// Count all firearm Accessories made by this manufacturer
				//----------------------------------------------------------------------------*

				foreach (cGear CheckGear in m_GearList)
					{
					if (CheckGear.Manufacturer.CompareTo(Manufacturer) == 0)
						nFirearmAccessoryCount++;
					}

				//----------------------------------------------------------------------------*
				// Count all bullets made by this manufacturer
				//----------------------------------------------------------------------------*

				foreach (cBullet CheckBullet in m_BulletList)
					{
					if (CheckBullet.Manufacturer.CompareTo(Manufacturer) == 0)
						nBulletCount++;
					}

				//----------------------------------------------------------------------------*
				// Count all cases made by this manufacturer
				//----------------------------------------------------------------------------*

				foreach (cCase CheckCase in m_CaseList)
					{
					if (CheckCase.Manufacturer.CompareTo(Manufacturer) == 0)
						nCaseCount++;
					}

				//----------------------------------------------------------------------------*
				// Count all powders made by this manufacturer
				//----------------------------------------------------------------------------*

				foreach (cPowder CheckPowder in m_PowderList)
					{
					if (CheckPowder.Manufacturer.CompareTo(Manufacturer) == 0)
						nPowderCount++;
					}

				//----------------------------------------------------------------------------*
				// Count all primers made by this manufacturer
				//----------------------------------------------------------------------------*

				foreach (cPrimer CheckPrimer in m_PrimerList)
					{
					if (CheckPrimer.Manufacturer.CompareTo(Manufacturer) == 0)
						nPrimerCount++;
					}

				if (nFirearmCount > 0)
					strCount += String.Format("{0:G0} Firearm{1}\n", nFirearmCount, nFirearmCount > 1 ? "s" : "");

				if (nFirearmAccessoryCount > 0)
					strCount += String.Format("{0:G0} Firearm Accessor{1}\n", nFirearmAccessoryCount, nFirearmAccessoryCount > 1 ? "ies" : "y");

				if (nBulletCount > 0)
					strCount += String.Format("{0:G0} Bullet{1}\n", nBulletCount, nBulletCount > 1 ? "s" : "");

				if (nCaseCount > 0)
					strCount += String.Format("{0:G0} Case{1}\n", nCaseCount, nCaseCount > 1 ? "s" : "");

				if (nPowderCount > 0)
					strCount += String.Format("{0:G0} Powder{1}\n", nPowderCount, nPowderCount > 1 ? "s" : "");

				if (nPrimerCount > 0)
					strCount += String.Format("{0:G0} Primer{1}\n", nPrimerCount, nPrimerCount > 1 ? "s" : "");

				return (strCount);
				}

			//----------------------------------------------------------------------------*
			// Now delete the manufacturer if we're not just counting
			//----------------------------------------------------------------------------*

			if (!fCountOnly)
				m_ManufacturerList.Remove(Manufacturer);

			return (strCount);
			}

		//============================================================================*
		// DeletePowder()
		//============================================================================*

		public string DeletePowder(cPowder Powder, bool fCountOnly = false)
			{
			string strCount = "";

			if (fCountOnly)
				{
				int nLoadCount = 0;

				//----------------------------------------------------------------------------*
				// Count all loads that use this powder
				//----------------------------------------------------------------------------*

				foreach (cLoad CheckLoad in m_LoadList)
					{
					if (CheckLoad.Powder.CompareTo(Powder) == 0)
						nLoadCount++;
					}

				if (nLoadCount > 0)
					strCount += String.Format("{0:N0} Load{1}\n", nLoadCount, nLoadCount > 1 ? "s" : "");
				}

			//----------------------------------------------------------------------------*
			// Now delete the powder if we're not just counting
			//----------------------------------------------------------------------------*

			if (!fCountOnly)
				m_PowderList.Remove(Powder);

			return (strCount);
			}

		//============================================================================*
		// DeletePrimer()
		//============================================================================*

		public string DeletePrimer(cPrimer Primer, bool fCountOnly = false)
			{
			string strCount = "";

			if (fCountOnly)
				{
				int nLoadCount = 0;

				//----------------------------------------------------------------------------*
				// Count all loads that use this primer
				//----------------------------------------------------------------------------*

				foreach (cLoad CheckLoad in m_LoadList)
					{
					if (CheckLoad.Primer.CompareTo(Primer) == 0)
						nLoadCount++;
					}

				if (nLoadCount > 0)
					strCount += String.Format("{0:N0} Load{1}\n", nLoadCount, nLoadCount > 1 ? "s" : "");
				}

			//----------------------------------------------------------------------------*
			// Now delete the Primer if we're not just counting
			//----------------------------------------------------------------------------*

			if (!fCountOnly)
				m_PrimerList.Remove(Primer);

			return (strCount);
			}

		//============================================================================*
		// FirearmList Property
		//============================================================================*

		public cFirearmList FirearmList
			{
			get
				{
				return (m_FirearmList);
				}
			}

		//============================================================================*
		// FirstTransactionDate Property
		//============================================================================*

		public DateTime FirstTransactionDate
			{
			get
				{
				DateTime FirstDate = new DateTime(2098, 1, 1);

				//----------------------------------------------------------------------------*
				// Bullets
				//----------------------------------------------------------------------------*

				foreach (cSupply Supply in m_BulletList)
					{
					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (Transaction.Date < FirstDate)
							FirstDate = Transaction.Date;
						}
					}

				//----------------------------------------------------------------------------*
				// Cases
				//----------------------------------------------------------------------------*

				foreach (cSupply Supply in m_CaseList)
					{
					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (Transaction.Date < FirstDate)
							FirstDate = Transaction.Date;
						}
					}

				//----------------------------------------------------------------------------*
				// Powder
				//----------------------------------------------------------------------------*

				foreach (cSupply Supply in m_PowderList)
					{
					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (Transaction.Date < FirstDate)
							FirstDate = Transaction.Date;
						}
					}

				//----------------------------------------------------------------------------*
				// Primers
				//----------------------------------------------------------------------------*

				foreach (cSupply Supply in m_PrimerList)
					{
					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (Transaction.Date < FirstDate)
							FirstDate = Transaction.Date;
						}
					}

				//----------------------------------------------------------------------------*
				// Ammo
				//----------------------------------------------------------------------------*

				foreach (cSupply Supply in m_AmmoList)
					{
					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (Transaction.Date < FirstDate)
							FirstDate = Transaction.Date;
						}
					}

				if (FirstDate.Year == 2098)
					FirstDate = new DateTime(2010, 1, 1, 0, 0, 0);
				else
					FirstDate = new DateTime(FirstDate.Year, FirstDate.Month, FirstDate.Day, 0, 0, 0);

				return (FirstDate);
				}
			}

		//============================================================================*
		// GearList Property
		//============================================================================*

		public cGearList GearList
			{
			get
				{
				return (m_GearList);
				}
			}

		//============================================================================*
		// GetAmmoList()
		//============================================================================*

		public cAmmoList GetAmmoList()
			{
			//----------------------------------------------------------------------------*
			// Gather the list of ammo
			//----------------------------------------------------------------------------*

			cAmmoList AmmoList = new cAmmoList();

			foreach (cAmmo Ammo in m_AmmoList)
				{
				if ((cPreferences.StaticPreferences.AmmoPrintAll ||
					(cPreferences.StaticPreferences.AmmoPrintChecked && Ammo.Checked)) &&
					(!cPreferences.StaticPreferences.AmmoPrintNonZero || SupplyQuantity(Ammo) != 0.0) &&
					(!cPreferences.StaticPreferences.AmmoPrintFactoryOnly || Ammo.BatchID == 0) &&
					(!cPreferences.StaticPreferences.AmmoPrintBelowStock || SupplyQuantity(Ammo) < Ammo.MinimumStockLevel))

					if (!AmmoList.Contains(Ammo))
						AmmoList.Add(Ammo);
				}

			return (AmmoList);
			}

		//============================================================================*
		// GetBatchByID()
		//============================================================================*

		public cBatch GetBatchByID(int nBatchID)
			{
			cBatch Batch = null;

			foreach (cBatch CheckBatch in m_BatchList)
				{
				if (CheckBatch.BatchID == nBatchID)
					{
					Batch = CheckBatch;

					break;
					}
				}

			return (Batch);
			}

		//============================================================================*
		// GetDataPath()
		//============================================================================*

		public string GetDataPath()
			{
			return (@"c:\Users\Public\Reloader's WorkShop");
			}

		//============================================================================*
		// GetSupplyList()
		//============================================================================*

		public cSupplyList GetSupplyList()
			{
			//----------------------------------------------------------------------------*
			// Gather the list of supplies
			//----------------------------------------------------------------------------*

			cSupplyList SupplyList = new cSupplyList();

			// Bullets

			foreach (cSupply Supply in m_BulletList)
				{
				if ((cPreferences.StaticPreferences.SupplyPrintAll ||
					(cPreferences.StaticPreferences.SupplyPrintChecked && Supply.Checked)) &&
					(!cPreferences.StaticPreferences.SupplyPrintNonZero || SupplyQuantity(Supply) > 0.0) &&
					(!cPreferences.StaticPreferences.SupplyPrintBelowStock || SupplyQuantity(Supply) < Supply.MinimumStockLevel))
					{
					if (!SupplyList.Contains(Supply))
						SupplyList.AddSupply(Supply);
					}
				}

			// Cases

			foreach (cSupply Supply in m_CaseList)
				{
				if ((cPreferences.StaticPreferences.SupplyPrintAll ||
					(cPreferences.StaticPreferences.SupplyPrintChecked && Supply.Checked)) &&
					(!cPreferences.StaticPreferences.SupplyPrintNonZero || SupplyQuantity(Supply) > 0.0) &&
					(!cPreferences.StaticPreferences.SupplyPrintBelowStock || SupplyQuantity(Supply) < Supply.MinimumStockLevel))
					{
					if (!SupplyList.Contains(Supply))
						SupplyList.AddSupply(Supply);
					}
				}

			// Powder

			foreach (cSupply Supply in m_PowderList)
				{
				if ((cPreferences.StaticPreferences.SupplyPrintAll ||
					(cPreferences.StaticPreferences.SupplyPrintChecked && Supply.Checked)) &&
					(!cPreferences.StaticPreferences.SupplyPrintNonZero || SupplyQuantity(Supply) > 0.0) &&
					(!cPreferences.StaticPreferences.SupplyPrintBelowStock || SupplyQuantity(Supply) < Supply.MinimumStockLevel))
					{
					if (!SupplyList.Contains(Supply))
						SupplyList.AddSupply(Supply);
					}
				}

			// Primers

			foreach (cSupply Supply in m_PrimerList)
				{
				if ((cPreferences.StaticPreferences.SupplyPrintAll ||
					(cPreferences.StaticPreferences.SupplyPrintChecked && Supply.Checked)) &&
					(!cPreferences.StaticPreferences.SupplyPrintNonZero || SupplyQuantity(Supply) > 0.0) &&
					(!cPreferences.StaticPreferences.SupplyPrintBelowStock || SupplyQuantity(Supply) < Supply.MinimumStockLevel))
					{
					if (!SupplyList.Contains(Supply))
						SupplyList.AddSupply(Supply);
					}
				}

			SupplyList.Sort();

			return (SupplyList);
			}

		//============================================================================*
		// GetTransactionSourceList()
		//============================================================================*

		public List<string> GetTransactionSourceList(cTransaction.eTransactionType eTransactionType)
			{
			List<string> LocationList = new List<string>();

			//----------------------------------------------------------------------------*
			// Ammo
			//----------------------------------------------------------------------------*

			foreach (cAmmo Supply in m_AmmoList)
				{
				foreach (cTransaction Transaction in Supply.TransactionList)
					{
					if (Transaction.TransactionType == eTransactionType)
						AddToSourceList(ref LocationList, Transaction.Source);
					}
				}

			//----------------------------------------------------------------------------*
			// Bullets
			//----------------------------------------------------------------------------*

			foreach (cBullet Supply in m_BulletList)
				{
				foreach (cTransaction Transaction in Supply.TransactionList)
					{
					if (Transaction.TransactionType == eTransactionType)
						AddToSourceList(ref LocationList, Transaction.Source);
					}
				}

			//----------------------------------------------------------------------------*
			// Cases
			//----------------------------------------------------------------------------*

			foreach (cCase Supply in m_CaseList)
				{
				foreach (cTransaction Transaction in Supply.TransactionList)
					{
					if (Transaction.TransactionType == eTransactionType)
						AddToSourceList(ref LocationList, Transaction.Source);
					}
				}

			//----------------------------------------------------------------------------*
			// Powder
			//----------------------------------------------------------------------------*

			foreach (cPowder Supply in m_PowderList)
				{
				foreach (cTransaction Transaction in Supply.TransactionList)
					{
					if (Transaction.TransactionType == eTransactionType)
						AddToSourceList(ref LocationList, Transaction.Source);
					}
				}

			//----------------------------------------------------------------------------*
			// Primers
			//----------------------------------------------------------------------------*

			foreach (cPrimer Supply in m_PrimerList)
				{
				foreach (cTransaction Transaction in Supply.TransactionList)
					{
					if (Transaction.TransactionType == eTransactionType)
						AddToSourceList(ref LocationList, Transaction.Source);
					}
				}

			LocationList.Sort();

			return (LocationList);
			}

		//============================================================================*
		// GetLastTransactionSource()
		//============================================================================*

		public string GetLastTransactionSource(cTransaction.eTransactionType eTransactionType)
			{
			switch (eTransactionType)
				{
				case cTransaction.eTransactionType.AddStock:
					return (cPreferences.StaticPreferences.LastAddStockReason);

				case cTransaction.eTransactionType.Fired:
					return (cPreferences.StaticPreferences.LastFiredLocation);

				case cTransaction.eTransactionType.Purchase:
					return (cPreferences.StaticPreferences.LastPurchaseSource);

				case cTransaction.eTransactionType.ReduceStock:
					return (cPreferences.StaticPreferences.LastReduceStockReason);
				}

			return ("");
			}

		//============================================================================*
		// LastTransactionDate Property
		//============================================================================*

		public DateTime LastTransactionDate
			{
			get
				{
				DateTime LastDate = new DateTime(2010, 1, 1);

				//----------------------------------------------------------------------------*
				// Bullets
				//----------------------------------------------------------------------------*

				foreach (cSupply Supply in m_BulletList)
					{
					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (Transaction.Date > LastDate)
							LastDate = Transaction.Date;
						}
					}

				//----------------------------------------------------------------------------*
				// Cases
				//----------------------------------------------------------------------------*

				foreach (cSupply Supply in m_CaseList)
					{
					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (Transaction.Date > LastDate)
							LastDate = Transaction.Date;
						}
					}

				//----------------------------------------------------------------------------*
				// Powder
				//----------------------------------------------------------------------------*

				foreach (cSupply Supply in m_PowderList)
					{
					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (Transaction.Date > LastDate)
							LastDate = Transaction.Date;
						}
					}

				//----------------------------------------------------------------------------*
				// Primers
				//----------------------------------------------------------------------------*

				foreach (cSupply Supply in m_PrimerList)
					{
					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (Transaction.Date > LastDate)
							LastDate = Transaction.Date;
						}
					}

				//----------------------------------------------------------------------------*
				// Ammo
				//----------------------------------------------------------------------------*

				foreach (cSupply Supply in m_AmmoList)
					{
					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (Transaction.Date > LastDate)
							LastDate = Transaction.Date;
						}
					}

				if (LastDate.Year == 2010)
					LastDate = DateTime.Now;
				else
					LastDate = new DateTime(LastDate.Year, LastDate.Month, LastDate.Day, 23, 59, 59);

				return (LastDate);
				}
			}

		//============================================================================*
		// Load()
		//============================================================================*

		public bool Load(string strBackupFilePath = null, bool fRestore = false)
			{
			if (!LoadDataFile(strBackupFilePath, fRestore))
				return (false);

			cPreferences.StaticPreferences.BallisticsData.MuzzleHeight = 60;

			if (cPreferences.StaticPreferences.TargetAimPointColor.A == 0)
				cPreferences.StaticPreferences.TargetAimPointColor = cTarget.DefaultAimPointColor;

			if (cPreferences.StaticPreferences.TargetOffsetColor.A == 0)
				cPreferences.StaticPreferences.TargetOffsetColor = cTarget.DefaultOffsetColor;

			if (cPreferences.StaticPreferences.TargetShotColor.A == 0)
				cPreferences.StaticPreferences.TargetShotColor = cTarget.DefaultShotColor;

			if (cPreferences.StaticPreferences.TargetShotForecolor.A == 0)
				cPreferences.StaticPreferences.TargetShotForecolor = cTarget.DefaultShotForecolor;

			if (cPreferences.StaticPreferences.TargetReticleColor.A == 0)
				cPreferences.StaticPreferences.TargetReticleColor = cTarget.DefaultReticleColor;

			if (cPreferences.StaticPreferences.TargetScaleForecolor.A == 0)
				cPreferences.StaticPreferences.TargetScaleForecolor = cTarget.DefaultScaleForecolor;

			if (cPreferences.StaticPreferences.TargetScaleBackcolor.A == 0)
				cPreferences.StaticPreferences.TargetScaleBackcolor = cTarget.DefaultScaleBackcolor;

			if (cPreferences.StaticPreferences.TargetExtremesColor.A == 0)
				cPreferences.StaticPreferences.TargetExtremesColor = cTarget.DefaultExtremesColor;

			if (cPreferences.StaticPreferences.TargetGroupBoxColor.A == 0)
				cPreferences.StaticPreferences.TargetGroupBoxColor = cTarget.DefaultGroupBoxColor;

			if (!cPreferences.StaticPreferences.TargetShowBoxesSet)
				{
				cPreferences.StaticPreferences.TargetShowAimPoint = true;
				cPreferences.StaticPreferences.TargetShowExtremes = false;
				cPreferences.StaticPreferences.TargetShowGroupBox = false;
				cPreferences.StaticPreferences.TargetShowOffset = true;
				cPreferences.StaticPreferences.TargetShowScale = true;
				cPreferences.StaticPreferences.TargetShowShotNum = false;

				cPreferences.StaticPreferences.TargetShowBoxesSet = true;
				}

			//----------------------------------------------------------------------------*
			// Add the Batch Editor Manufacturer if it's not already there
			//----------------------------------------------------------------------------*

			m_BatchManufacturer = new cManufacturer();

			m_BatchManufacturer.Name = "Batch Editor";
			m_BatchManufacturer.Ammo = true;

			bool fFound = false;

			foreach (cManufacturer Manufacturer in m_ManufacturerList)
				{
				if (Manufacturer.CompareTo(m_BatchManufacturer) == 0)
					{
					m_BatchManufacturer = Manufacturer;

					fFound = true;

					break;
					}
				}

			if (!fFound)
				m_ManufacturerList.Add(m_BatchManufacturer);

			//----------------------------------------------------------------------------*
			// Make sure ChargeTest data is set
			//----------------------------------------------------------------------------*

			foreach (cLoad Load in m_LoadList)
				{
				foreach (cCharge Charge in Load.ChargeList)
					Charge.SetTestData();
				}

			//----------------------------------------------------------------------------*
			// Sort the Lists
			//----------------------------------------------------------------------------*

			SortDataLists();

			//----------------------------------------------------------------------------*
			// Synch all the data lists so that they all point to the same instances
			//----------------------------------------------------------------------------*

			SynchDataLists();

			//----------------------------------------------------------------------------*
			// Recalculate Inventory totals for all components
			//----------------------------------------------------------------------------*

			RecalculateInventory();

			//----------------------------------------------------------------------------*
			// If this is a restore operation, show message before exiting
			//----------------------------------------------------------------------------*

			if (fRestore)
				{
				MessageBox.Show("Backup restored successfully!", "Backup Restoration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

			return (true);
			}

		//============================================================================*
		// LoadDataFile()
		//============================================================================*

		public bool LoadDataFile(string strPath = null, bool fRestore = false)
			{
			bool fLoadOK = true;

			Stream Stream = null;

			string strFilePath = "";
			string strDataFileName = "";

			string strApplicationDataPath = GetDataPath();

			m_ManufacturerList = new cManufacturerList();
			m_CaliberList = new cCaliberList();
			m_FirearmList = new cFirearmList();
			m_BulletList = new cBulletList();
			m_CaseList = new cCaseList();
			m_PowderList = new cPowderList();
			m_PrimerList = new cPrimerList();
			m_LoadList = new cLoadList();
			m_BatchList = new cBatchList();
			m_AmmoList = new cAmmoList();
			m_GearList = new cGearList();

			//----------------------------------------------------------------------------*
			// Restore Backup?
			//----------------------------------------------------------------------------*

			if (fRestore)
				{
				//----------------------------------------------------------------------------*
				// Build the file name and create the stream
				//----------------------------------------------------------------------------*

				if (string.IsNullOrEmpty(strPath))
					{
					MessageBox.Show("Error while restoring backup!!  Invalid backup path specified.", "Restore Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

					return (false);
					}

				strFilePath = strPath;

				if (Path.GetExtension(strFilePath) != "rwb")
					Path.ChangeExtension(strFilePath, "rwb");
				}

			//----------------------------------------------------------------------------*
			// Normal File Load
			//----------------------------------------------------------------------------*

			else
				{
				if (string.IsNullOrEmpty(strDataFileName))
					strDataFileName = "ReloadersWorkShop.rwd";

				strFilePath = Path.Combine(strApplicationDataPath, strDataFileName);
				}

			//----------------------------------------------------------------------------*
			// Load the data files
			//----------------------------------------------------------------------------*

			try
				{
				//----------------------------------------------------------------------------*
				// Open the data file
				//----------------------------------------------------------------------------*

				Stream = File.Open(strFilePath, FileMode.Open);

				if (Stream != null)
					{
					//----------------------------------------------------------------------------*
					// Create the formatter
					//----------------------------------------------------------------------------*

					BinaryFormatter Formatter = new BinaryFormatter();

					//----------------------------------------------------------------------------*
					// Load the data members
					//----------------------------------------------------------------------------*

					try
						{
						m_ManufacturerList = (cManufacturerList) Formatter.Deserialize(Stream);
						m_CaliberList = (cCaliberList) Formatter.Deserialize(Stream);
						m_FirearmList = (cFirearmList) Formatter.Deserialize(Stream);
						m_BulletList = (cBulletList) Formatter.Deserialize(Stream);
						m_CaseList = (cCaseList) Formatter.Deserialize(Stream);
						m_PowderList = (cPowderList) Formatter.Deserialize(Stream);
						m_PrimerList = (cPrimerList) Formatter.Deserialize(Stream);
						m_LoadList = (cLoadList) Formatter.Deserialize(Stream);
						m_BatchList = (cBatchList) Formatter.Deserialize(Stream);
						m_AmmoList = (cAmmoList) Formatter.Deserialize(Stream);

						//----------------------------------------------------------------------------*
						// Load the Preferences
						//----------------------------------------------------------------------------*

						cPreferences.StaticPreferences.Deserialize(Formatter, Stream);

						try
							{
							m_GearList = (cGearList) Formatter.Deserialize(Stream);
							}
						catch { }
						}
					catch
						{
						string strMessage = String.Format("An error was encountered while reading the file {0}.  This can be caused by a corrupted data file or by attempting to load an older data file from an earlier release of Reloader's WorkShop.  Some or all of your data may not have loaded properly.", Path.GetFileName(strFilePath));

						if (fRestore)
							strMessage += "\n\nDo you wish to continue?";

						DialogResult rc = MessageBox.Show(strMessage, "Data File Load Error", (fRestore) ? MessageBoxButtons.YesNo : MessageBoxButtons.OK, MessageBoxIcon.Exclamation, (fRestore) ? MessageBoxDefaultButton.Button2 : MessageBoxDefaultButton.Button1);

						if (fRestore)
							{
							if (rc == DialogResult.No)
								fLoadOK = false;
							}
						}
					}
				}

			//----------------------------------------------------------------------------*
			// If any part of the data cannot be loaded, create the missing data members
			//----------------------------------------------------------------------------*

			catch
				{
				if (fRestore)
					{
					string strText = String.Format("Error while restoring backup!!  {0} could not be opened.", Path.GetFileName(strFilePath));

					MessageBox.Show(strText, "Restore Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

					fLoadOK = false;
					}
				}

			finally
				{
				if (Stream != null)
					Stream.Close();
				}

			if (fLoadOK)
				{
				if (m_ManufacturerList == null)
					m_ManufacturerList = new cManufacturerList();

				if (m_CaliberList == null)
					m_CaliberList = new cCaliberList();

				if (m_FirearmList == null)
					m_FirearmList = new cFirearmList();
				else
					m_FirearmList.Validate();

				if (m_BulletList == null)
					m_BulletList = new cBulletList();

				if (m_CaseList == null)
					m_CaseList = new cCaseList();

				if (m_PowderList == null)
					m_PowderList = new cPowderList();

				if (m_PrimerList == null)
					m_PrimerList = new cPrimerList();

				if (m_LoadList == null)
					m_LoadList = new cLoadList();

				if (m_BatchList == null)
					m_BatchList = new cBatchList();

				if (m_AmmoList == null)
					m_AmmoList = new cAmmoList();

				if (m_GearList == null)
					m_GearList = new cGearList();

				//----------------------------------------------------------------------------*
				// Set up default preferences
				//----------------------------------------------------------------------------*

				//----------------------------------------------------------------------------*
				// Set up the next batch ID
				//----------------------------------------------------------------------------*

				SetNextBatchID();
				}

			return (fLoadOK);
			}

		//============================================================================*
		// LoadList Property
		//============================================================================*

		public cLoadList LoadList
			{
			get
				{
				return (m_LoadList);
				}
			}

		//============================================================================*
		// ManufacturerList Property
		//============================================================================*

		public cManufacturerList ManufacturerList
			{
			get
				{
				return (m_ManufacturerList);
				}
			}

		//============================================================================*
		// Merge()
		//============================================================================*

		public bool Merge(cDataFiles Datafiles, bool fCountOnly = false)
			{
			bool fDataMerged = false;

			//----------------------------------------------------------------------------*
			// Start the merge operation
			//----------------------------------------------------------------------------*

			bool fLoop = true;

			while (fLoop)
				{
				m_MainForm.Cursor = Cursors.WaitCursor;

				string strMerge = MergeManufacturers(Datafiles.ManufacturerList, fCountOnly);
				strMerge += MergeCalibers(Datafiles.CaliberList, fCountOnly);
				strMerge += MergeFirearms(Datafiles.FirearmList, fCountOnly);
				strMerge += MergeBullets(Datafiles.BulletList, fCountOnly);
				strMerge += MergeCases(Datafiles.CaseList, fCountOnly);
				strMerge += MergePowders(Datafiles.PowderList, fCountOnly);
				strMerge += MergePrimers(Datafiles.PrimerList, fCountOnly);
				strMerge += MergeLoads(Datafiles.LoadList, fCountOnly);
				strMerge += MergeBatches(Datafiles.BatchList, fCountOnly);
				strMerge += MergeAmmo(Datafiles.AmmoList, fCountOnly);

				if (!fCountOnly)
					{
					SortDataLists();

					SynchDataLists();

					SetNextBatchID();

					RecalculateInventory();

					string strMessage = "The following items have been merged with the current data:\n\n";

					if (strMerge.Length == 0)
						strMessage += "No new data has been merged.";
					else
						strMessage += strMerge;

					MessageBox.Show(strMessage, "Merge Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

					fLoop = false;
					fDataMerged = true;
					}
				else
					{
					if (strMerge.Length == 0)
						{
						MessageBox.Show("No new data updates are available.", "No Update Required", MessageBoxButtons.OK, MessageBoxIcon.Information);

						fLoop = false;
						}
					else
						{
						string strMessage = "The following new items will be merged with the current data:\n\n";

						strMessage += strMerge;

						strMessage += "\nDo you wish to continue?";

						DialogResult rc = MessageBox.Show(strMessage, "Continue with Merge?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

						if (rc == DialogResult.No)
							fLoop = false;
						else
							fCountOnly = false;
						}
					}

				m_MainForm.Cursor = Cursors.Default;
				}

			return (fDataMerged);
			}

		//============================================================================*
		// MergeAmmo()
		//============================================================================*

		public string MergeAmmo(cAmmoList AmmoList, bool fCountOnly = false)
			{
			//----------------------------------------------------------------------------*
			// Merge Ammo
			//----------------------------------------------------------------------------*

			int nCount = 0;
			int nTransactionCount = 0;

			foreach (cAmmo Ammo in AmmoList)
				{
				bool fFound = false;

				foreach (cAmmo CheckAmmo in m_AmmoList)
					{
					if (CheckAmmo.CompareTo(Ammo) == 0)
						{
						nTransactionCount += MergeTransactions(CheckAmmo, Ammo, fCountOnly);

						fFound = true;

						//----------------------------------------------------------------------------*
						// Merge Ammo Tests
						//----------------------------------------------------------------------------*

						if (!fCountOnly)
							{
							foreach (cAmmoTest AmmoTest in Ammo.TestList)
								{
								bool fFoundTest = false;

								foreach (cAmmoTest CheckAmmoTest in CheckAmmo.TestList)
									{
									if (CheckAmmoTest.CompareTo(AmmoTest) == 0)
										{
										fFoundTest = true;

										break;
										}
									}

								if (!fCountOnly && !fFoundTest)
									CheckAmmo.TestList.Add(AmmoTest);
								}
							}

						break;
						}
					}

				if (!fFound)
					{
					if (!fCountOnly)
						m_AmmoList.Add(Ammo);

					nCount++;
					}
				}

			//----------------------------------------------------------------------------*
			// Create the return string
			//----------------------------------------------------------------------------*

			if (nCount == 0 && nTransactionCount == 0)
				return ("");

			string strText = String.Format("Ammo: {0:N0}", nCount);

			if (nTransactionCount > 0)
				strText += String.Format(" (plus a total of {0:N0} inventory activities)", nTransactionCount);

			strText += "\n";

			return (strText);
			}

		//============================================================================*
		// MergeBatches()
		//============================================================================*

		public string MergeBatches(cBatchList BatchList, bool fCountOnly = false)
			{
			if (fCountOnly)
				return ("");

			//----------------------------------------------------------------------------*
			// Merge Batches
			//----------------------------------------------------------------------------*

			int nCount = 0;
			int nTestCount = 0;
			int nTestShotCount = 0;

			foreach (cBatch Batch in BatchList)
				{
				bool fFound = false;

				foreach (cBatch CheckBatch in m_BatchList)
					{
					if (CheckBatch.CompareTo(Batch) == 0)
						{
						fFound = true;

						if ((Batch.BatchTest != null && CheckBatch.BatchTest == null) &&
							Batch.Load.CompareTo(CheckBatch.Load) == 0 &&
							Batch.PowderWeight == CheckBatch.PowderWeight &&
							Batch.Firearm.CompareTo(CheckBatch.Firearm) == 0 &&
							Batch.DateLoaded == CheckBatch.DateLoaded &&
							Batch.NumRounds == CheckBatch.NumRounds)
							{
							CheckBatch.BatchTest = Batch.BatchTest;

							nTestCount++;
							}

						//----------------------------------------------------------------------------*
						// Merge Batch Tests
						//----------------------------------------------------------------------------*

						if (Batch.BatchTest != null)
							{
							foreach (cTestShot TestShot in Batch.BatchTest.TestShotList)
								{
								bool fFoundTestShot = false;

								if (CheckBatch.BatchTest != null)
									{
									foreach (cTestShot CheckTestShot in CheckBatch.BatchTest.TestShotList)
										{
										if (CheckTestShot.CompareTo(TestShot) == 0)
											{
											fFoundTestShot = true;

											break;
											}
										}

									if (!fFoundTestShot)
										{
										CheckBatch.BatchTest.TestShotList.Add(TestShot);

										CheckBatch.BatchTest.NumRounds = CheckBatch.BatchTest.TestShotList.Count;

										nTestShotCount++;
										}
									}
								}
							}

						break;
						}
					}

				if (!fFound)
					{
					m_BatchList.Add(Batch);

					nCount++;
					}
				}

			//----------------------------------------------------------------------------*
			// Create the return string
			//----------------------------------------------------------------------------*

			if (nCount == 0 && nTestCount == 0 && nTestShotCount == 0)
				return ("");

			string strText = "";

			if (nCount > 0)
				strText += String.Format("New Batches: {0:N0}\n", nCount);

			if (nTestCount > 0)
				strText += String.Format("Batch Tests: {0:N0}\n", nTestCount);

			if (nTestShotCount > 0)
				strText += String.Format("Batch Test Shots: {0:N0}\n", nTestShotCount);

			return (strText);
			}

		//============================================================================*
		// MergeBullets()
		//============================================================================*

		public string MergeBullets(cBulletList BulletList, bool fCountOnly = false)
			{
			//----------------------------------------------------------------------------*
			// Merge Bullets
			//----------------------------------------------------------------------------*

			int nCount = 0;
			int nUpdateCount = 0;
			int nTransactionCount = 0;

			foreach (cBullet Bullet in BulletList)
				{
				bool fFound = false;

				foreach (cBullet CheckBullet in m_BulletList)
					{
					if (CheckBullet.CompareTo(Bullet) == 0)
						{
						nTransactionCount += MergeTransactions(CheckBullet, Bullet, fCountOnly);

						fFound = true;

						if (!fCountOnly)
							CheckBullet.Checked = CheckBullet.Checked || Bullet.Checked;

						//----------------------------------------------------------------------------*
						// Merge Bullet Calibers
						//----------------------------------------------------------------------------*

						foreach (cBulletCaliber BulletCaliber in Bullet.CaliberList)
							{
							bool fFoundBulletCaliber = false;

							foreach (cBulletCaliber CheckBulletCaliber in CheckBullet.CaliberList)
								{
								if (CheckBulletCaliber.CompareTo(BulletCaliber) == 0)
									{
									fFoundBulletCaliber = true;

									break;
									}
								}

							if (!fFoundBulletCaliber)
								{
								if (!fCountOnly)
									CheckBullet.CaliberList.Add(BulletCaliber);

								nUpdateCount++;
								}
							}

						break;
						}
					}

				if (!fFound)
					{
					if (!fCountOnly)
						m_BulletList.Add(Bullet);

					nCount++;
					}
				}

			//----------------------------------------------------------------------------*
			// Create the return string
			//----------------------------------------------------------------------------*

			if (nCount == 0 && nTransactionCount == 0 && nUpdateCount == 0)
				return ("");

			string strText = "";

			strText = String.Format("New Bullets: {0:N0}", nCount);

			if (nTransactionCount > 0)
				strText += String.Format(" (plus a total of {0:N0} inventory activities)", nTransactionCount);

			strText += "\n";

			if (nUpdateCount > 0)
				strText += String.Format("Updates to existing bullets: {0:N0}\n", nUpdateCount);

			return (strText);
			}

		//============================================================================*
		// MergeCalibers()
		//============================================================================*

		public string MergeCalibers(cCaliberList CaliberList, bool fCountOnly = false)
			{
			int nCount = 0;
			int nUpdateCount = 0;

			//----------------------------------------------------------------------------*
			// Loop through the calibers
			//----------------------------------------------------------------------------*

			foreach (cCaliber Caliber in CaliberList)
				{
				bool fFound = false;

				foreach (cCaliber CheckCaliber in m_CaliberList)
					{
					//----------------------------------------------------------------------------*
					// See if this is an existing caliber
					//----------------------------------------------------------------------------*

					if (CheckCaliber.CompareTo(Caliber) == 0)
						{
						fFound = true;

						if (!fCountOnly)
							{
							CheckCaliber.Checked = CheckCaliber.Checked || Caliber.Checked;

							//----------------------------------------------------------------------------*
							// Update the exiting caliber data
							//----------------------------------------------------------------------------*

							if (CheckCaliber.MinBulletDiameter > Caliber.MinBulletDiameter)
								{
								if (!fCountOnly)
									CheckCaliber.MinBulletDiameter = Caliber.MinBulletDiameter;

								nUpdateCount++;
								}

							if (CheckCaliber.MaxBulletDiameter < Caliber.MaxBulletDiameter)
								{
								if (!fCountOnly)
									CheckCaliber.MaxBulletDiameter = Caliber.MaxBulletDiameter;

								nUpdateCount++;
								}

							if (CheckCaliber.MinBulletWeight == 0.0 || CheckCaliber.MinBulletWeight > Caliber.MinBulletWeight)
								{
								if (!fCountOnly)
									CheckCaliber.MinBulletWeight = Caliber.MinBulletWeight;

								nUpdateCount++;
								}

							if (CheckCaliber.MaxBulletWeight == 0.0 || CheckCaliber.MaxBulletWeight < Caliber.MaxBulletWeight)
								{
								if (!fCountOnly)
									CheckCaliber.MaxBulletWeight = Caliber.MaxBulletWeight;

								nUpdateCount++;
								}

							if (CheckCaliber.MaxCaseLength < Caliber.MaxCaseLength)
								{
								if (!fCountOnly)
									CheckCaliber.MaxCaseLength = Caliber.MaxCaseLength;

								nUpdateCount++;
								}

							if (CheckCaliber.MaxCOL < Caliber.MaxCOL)
								{
								if (!fCountOnly)
									CheckCaliber.MaxCOL = Caliber.MaxCOL;

								nUpdateCount++;
								}

							if (CheckCaliber.MaxNeckDiameter == 0.0 && Caliber.MaxNeckDiameter != 0.0)
								{
								if (!fCountOnly)
									CheckCaliber.MaxNeckDiameter = Caliber.MaxNeckDiameter;

								nUpdateCount++;
								}

							if (string.IsNullOrEmpty(CheckCaliber.SAAMIPDF) && string.IsNullOrEmpty(Caliber.SAAMIPDF))
								{
								if (!fCountOnly)
									CheckCaliber.SAAMIPDF = Caliber.SAAMIPDF;

								nUpdateCount++;
								}
							}

						break;
						}
					}

				//----------------------------------------------------------------------------*
				// If it's new, add it to the list
				//----------------------------------------------------------------------------*

				if (!fFound)
					{
					if (!fCountOnly)
						m_CaliberList.Add(Caliber);

					nCount++;
					}
				}

			//----------------------------------------------------------------------------*
			// Create the return string
			//----------------------------------------------------------------------------*

			if (nCount == 0 && nUpdateCount == 0)
				return ("");

			string strText = "";

			if (nCount != 0)
				strText = String.Format("New Calibers: {0:N0}\n", nCount);

			if (nUpdateCount != 0)
				strText += String.Format("Updates to existing calibers: {0:N0}\n", nUpdateCount);

			return (strText);
			}

		//============================================================================*
		// MergeCases()
		//============================================================================*

		public string MergeCases(cCaseList CaseList, bool fCountOnly = false)
			{
			int nCount = 0;
			int nTransactionCount = 0;

			//----------------------------------------------------------------------------*
			// Loop through the cases
			//----------------------------------------------------------------------------*

			foreach (cCase Case in CaseList)
				{
				bool fFound = false;

				foreach (cCase CheckCase in m_CaseList)
					{
					if (CheckCase.CompareTo(Case) == 0)
						{
						nTransactionCount += MergeTransactions(CheckCase, Case);

						fFound = true;

						if (!fCountOnly)
							CheckCase.Checked = CheckCase.Checked || Case.Checked;

						break;
						}
					}

				if (!fFound)
					{
					m_CaseList.Add(Case);

					nCount++;
					}
				}

			//----------------------------------------------------------------------------*
			// Create the return string
			//----------------------------------------------------------------------------*

			if (nCount == 0 && nTransactionCount == 0)
				return ("");

			string strText = String.Format("New Cases: {0:N0}", nCount);

			if (nTransactionCount > 0)
				strText += String.Format(" (plus a total of {0:N0} inventory activities)", nTransactionCount);

			strText += "\n";

			return (strText);
			}

		//============================================================================*
		// MergeFirearms()
		//============================================================================*

		public string MergeFirearms(cFirearmList FirearmList, bool fCountOnly = false)
			{
			//----------------------------------------------------------------------------*
			// Merge Firearms
			//----------------------------------------------------------------------------*

			int nCount = 0;

			foreach (cFirearm Firearm in FirearmList)
				{
				bool fFound = false;

				foreach (cFirearm CheckFirearm in m_FirearmList)
					{
					if (CheckFirearm.CompareTo(Firearm) == 0)
						{
						fFound = true;

						if (!fCountOnly)
							CheckFirearm.Checked = CheckFirearm.Checked || Firearm.Checked;

						//----------------------------------------------------------------------------*
						// Merge Firearm Calibers
						//----------------------------------------------------------------------------*

						if (!fCountOnly)
							{
							foreach (cFirearmCaliber FirearmCaliber in Firearm.CaliberList)
								{
								if (!CheckFirearm.HasCaliber(FirearmCaliber.Caliber))
									{
									cFirearmCaliber CheckFirearmCaliber = new cFirearmCaliber(FirearmCaliber);

									CheckFirearm.CaliberList.Add(CheckFirearmCaliber);
									}
								}
							}

						//----------------------------------------------------------------------------*
						// Merge Firearm Bullets
						//----------------------------------------------------------------------------*

						if (!fCountOnly)
							{
							foreach (cFirearmBullet FirearmBullet in Firearm.FirearmBulletList)
								{
								bool fFoundBullet = false;

								foreach (cFirearmBullet CheckFirearmBullet in CheckFirearm.FirearmBulletList)
									{
									if (CheckFirearmBullet.CompareTo(FirearmBullet) == 0)
										fFound = true;
									}

								if (!fFoundBullet)
									CheckFirearm.FirearmBulletList.Add(FirearmBullet);
								}
							}

						break;
						}
					}

				if (!fFound)
					{
					if (!fCountOnly)
						m_FirearmList.Add(Firearm);

					nCount++;
					}
				}

			//----------------------------------------------------------------------------*
			// Create the return string
			//----------------------------------------------------------------------------*

			if (nCount == 0)
				return ("");

			string strText = String.Format("Firearms: {0:N0}\n", nCount);

			return (strText);
			}

		//============================================================================*
		// MergeLoads()
		//============================================================================*

		public string MergeLoads(cLoadList LoadList, bool fCountOnly = false)
			{
			if (fCountOnly)
				return ("");

			//----------------------------------------------------------------------------*
			// Merge Loads
			//----------------------------------------------------------------------------*

			int nCount = 0;

			foreach (cLoad Load in LoadList)
				{
				bool fFound = false;

				foreach (cLoad CheckLoad in m_LoadList)
					{
					if (CheckLoad.CompareTo(Load) == 0)
						{
						fFound = true;

						if (!fCountOnly)
							CheckLoad.Checked = CheckLoad.Checked || Load.Checked;

						//----------------------------------------------------------------------------*
						// Merge Load Charges
						//----------------------------------------------------------------------------*

						foreach (cCharge Charge in Load.ChargeList)
							{
							bool fFoundCharge = false;

							foreach (cCharge CheckCharge in CheckLoad.ChargeList)
								{
								if (CheckCharge.CompareTo(Charge) == 0)
									{
									fFoundCharge = true;

									//----------------------------------------------------------------------------*
									// Merge ChargeTests
									//----------------------------------------------------------------------------*

									foreach (cChargeTest ChargeTest in Charge.TestList)
										{
										bool fFoundChargeTest = false;

										foreach (cChargeTest CheckChargeTest in CheckCharge.TestList)
											{
											if (CheckChargeTest.CompareTo(ChargeTest) == 0)
												{
												fFoundChargeTest = true;

												break;
												}
											}

										if (!fFoundChargeTest)
											CheckCharge.TestList.Add(ChargeTest);
										}

									break;
									}
								}

							if (!fFoundCharge)
								CheckLoad.ChargeList.Add(Charge);
							}

						break;
						}
					}

				if (!fFound)
					{
					m_LoadList.Add(Load);

					nCount++;
					}
				}

			//----------------------------------------------------------------------------*
			// Create the return string
			//----------------------------------------------------------------------------*

			if (nCount == 0)
				return ("");

			return (String.Format("Loads: {0:N0}\n", nCount));
			}

		//============================================================================*
		// MergeManufacturers()
		//============================================================================*

		public string MergeManufacturers(cManufacturerList ManufacturerList, bool fCountOnly = false)
			{
			int nCount = 0;
			int nUpdateCount = 0;

			//----------------------------------------------------------------------------*
			// Loop through the Manufacturers
			//----------------------------------------------------------------------------*

			foreach (cManufacturer Manufacturer in ManufacturerList)
				{
				bool fFound = false;

				//----------------------------------------------------------------------------*
				// Loop through the existing Manufacturers
				//----------------------------------------------------------------------------*

				foreach (cManufacturer CheckManufacturer in m_ManufacturerList)
					{
					//----------------------------------------------------------------------------*
					// Manufacturer already exists
					//----------------------------------------------------------------------------*

					if (CheckManufacturer.CompareTo(Manufacturer) == 0)
						{
						fFound = true;

						//----------------------------------------------------------------------------*
						// Update the existing Manufacturer
						//----------------------------------------------------------------------------*

						if (string.IsNullOrEmpty(CheckManufacturer.Website) && !string.IsNullOrEmpty(Manufacturer.Website))
							{
							if (!fCountOnly)
								CheckManufacturer.Website = Manufacturer.Website;

							nUpdateCount++;
							}

						if (string.IsNullOrEmpty(CheckManufacturer.HeadStamp) && !string.IsNullOrEmpty(Manufacturer.HeadStamp))
							{
							if (!fCountOnly)
								CheckManufacturer.HeadStamp = Manufacturer.HeadStamp;

							nUpdateCount++;
							}

						if (!CheckManufacturer.Ammo && Manufacturer.Ammo)
							{
							if (!fCountOnly)
								CheckManufacturer.Ammo = true;

							nUpdateCount++;
							}

						if (!CheckManufacturer.Bullets && Manufacturer.Bullets)
							{
							if (!fCountOnly)
								CheckManufacturer.Bullets = true;

							nUpdateCount++;
							}

						if (!CheckManufacturer.BulletMolds && Manufacturer.BulletMolds)
							{
							if (!fCountOnly)
								CheckManufacturer.BulletMolds = true;

							nUpdateCount++;
							}

						if (!CheckManufacturer.Cases && Manufacturer.Cases)
							{
							if (!fCountOnly)
								CheckManufacturer.Cases = true;

							nUpdateCount++;
							}

						if (!CheckManufacturer.Primers && Manufacturer.Primers)
							{
							if (!fCountOnly)
								CheckManufacturer.Primers = true;

							nUpdateCount++;
							}

						if (!CheckManufacturer.Powder && Manufacturer.Powder)
							{
							if (!fCountOnly)
								CheckManufacturer.Powder = true;

							nUpdateCount++;
							}

						if (!CheckManufacturer.Handguns && Manufacturer.Handguns)
							{
							if (!fCountOnly)
								CheckManufacturer.Handguns = true;

							nUpdateCount++;
							}

						if (!CheckManufacturer.Rifles && Manufacturer.Rifles)
							{
							if (!fCountOnly)
								CheckManufacturer.Rifles = true;

							nUpdateCount++;
							}

						if (!CheckManufacturer.Shotguns && Manufacturer.Shotguns)
							{
							if (!fCountOnly)
								CheckManufacturer.Shotguns = true;

							nUpdateCount++;
							}

						if (!CheckManufacturer.Scopes && Manufacturer.Scopes)
							{
							if (!fCountOnly)
								CheckManufacturer.Scopes = true;

							nUpdateCount++;
							}

						if (!CheckManufacturer.Triggers && Manufacturer.Triggers)
							{
							if (!fCountOnly)
								CheckManufacturer.Triggers = true;

							nUpdateCount++;
							}

						if (!CheckManufacturer.Furniture && Manufacturer.Furniture)
							{
							if (!fCountOnly)
								CheckManufacturer.Furniture = true;

							nUpdateCount++;
							}

						break;
						}
					}

				if (!fFound)
					{
					if (!fCountOnly)
						m_ManufacturerList.Add(Manufacturer);

					nCount++;
					}
				}

			//----------------------------------------------------------------------------*
			// Create the return string
			//----------------------------------------------------------------------------*

			if (nCount == 0 && nUpdateCount == 0)
				return ("");

			string strText = "";

			if (nCount > 0)
				strText += String.Format("Manufacturers: {0:N0}\n", nCount);

			if (nUpdateCount > 0)
				strText += String.Format("Updates to existing manufacturers: {0:N0}\n", nUpdateCount);

			return (strText);
			}

		//============================================================================*
		// MergePrimers()
		//============================================================================*

		public string MergePrimers(cPrimerList PrimerList, bool fCountOnly = false)
			{
			int nCount = 0;
			int nTransactionCount = 0;

			//----------------------------------------------------------------------------*
			// Loop through the Primers
			//----------------------------------------------------------------------------*

			foreach (cPrimer Primer in PrimerList)
				{
				bool fFound = false;

				foreach (cPrimer CheckPrimer in m_PrimerList)
					{
					if (CheckPrimer.CompareTo(Primer) == 0)
						{
						nTransactionCount += MergeTransactions(CheckPrimer, Primer, fCountOnly);

						fFound = true;

						CheckPrimer.Checked = CheckPrimer.Checked || Primer.Checked;

						break;
						}
					}

				if (!fFound)
					{
					if (!fCountOnly)
						m_PrimerList.Add(Primer);

					nCount++;
					}
				}

			//----------------------------------------------------------------------------*
			// Create the return string
			//----------------------------------------------------------------------------*

			if (nCount == 0 && nTransactionCount == 0)
				return ("");

			string strText = String.Format("New Primers: {0:N0}", nCount);

			if (nTransactionCount > 0)
				strText += String.Format(" (plus a total of {0:N0} inventory activities)", nTransactionCount);

			strText += "\n";

			return (strText);
			}

		//============================================================================*
		// MergePowders()
		//============================================================================*

		public string MergePowders(cPowderList PowderList, bool fCountOnly = false)
			{
			int nCount = 0;
			int nUpdateCount = 0;
			int nTransactionCount = 0;

			//----------------------------------------------------------------------------*
			// Loop through the Powders
			//----------------------------------------------------------------------------*

			foreach (cPowder Powder in PowderList)
				{
				bool fFound = false;

				foreach (cPowder CheckPowder in m_PowderList)
					{
					if (CheckPowder.CompareTo(Powder) == 0)
						{
						nTransactionCount += MergeTransactions(CheckPowder, Powder, fCountOnly);

						fFound = true;

						if (Powder.PowderType != cPowder.ePowderType.Other && Powder.PowderType != CheckPowder.PowderType)
							{
							if (!fCountOnly)
								CheckPowder.PowderType = Powder.PowderType;

							nUpdateCount++;
							}

						CheckPowder.Checked = CheckPowder.Checked || Powder.Checked;

						break;
						}
					}

				if (!fFound)
					{
					if (!fCountOnly)
						m_PowderList.Add(Powder);

					nCount++;
					}
				}

			//----------------------------------------------------------------------------*
			// Create the return string
			//----------------------------------------------------------------------------*

			if (nCount == 0 && nUpdateCount == 0 && nTransactionCount == 0)
				return ("");

			string strText = String.Format("New Powders: {0:N0}", nCount);

			if (nTransactionCount > 0)
				strText += String.Format(" (plus a total of {0:N0} inventory activities)", nTransactionCount);

			strText += "\n";

			if (nUpdateCount > 0)
				strText += String.Format("Updates to existing powders: {0:N0}\n", nUpdateCount);

			return (strText);
			}

		//============================================================================*
		// MergeTransactions()
		//============================================================================*

		public int MergeTransactions(cSupply Supply, cSupply NewSupply, bool fCountOnly = false)
			{
			//----------------------------------------------------------------------------*
			// Check the input data
			//----------------------------------------------------------------------------*

			if (Supply == null || NewSupply == null)
				return (0);

			if (Supply.TransactionList == null)
				Supply.TransactionList = new cTransactionList();

			if (NewSupply.TransactionList == null)
				NewSupply.TransactionList = new cTransactionList();

			//----------------------------------------------------------------------------*
			// Make sure Inventory Tracking is turned on
			//----------------------------------------------------------------------------*

			if (!cPreferences.StaticPreferences.TrackInventory)
				return (0);

			//----------------------------------------------------------------------------*
			// Initialize
			//----------------------------------------------------------------------------*

			int nTransactionCount = 0;

			bool fRecalc = false;

			//----------------------------------------------------------------------------*
			// Merge Transactions
			//----------------------------------------------------------------------------*

			foreach (cTransaction Transaction in NewSupply.TransactionList)
				{
				bool fFound = false;

				foreach (cTransaction CheckTransaction in Supply.TransactionList)
					{
					if (CheckTransaction.CompareTo(Transaction) == 0)
						{
						fFound = true;

						break;
						}
					}

				if (!fFound)
					{
					if (!fCountOnly)
						{
						if (!fCountOnly)
							Supply.TransactionList.Add(Transaction);

						fRecalc = true;
						}

					nTransactionCount++;
					}
				}

			if (fRecalc)
				Supply.RecalculateInventory(this);

			return (nTransactionCount);
			}

		//============================================================================*
		// MetricLongString()
		//============================================================================*

		public string MetricLongString(eDataType LabelType)
			{
			switch (LabelType)
				{
				case eDataType.Altitude:
					return (cPreferences.StaticPreferences.MetricAltitudes ? "Meters" : "Feet");

				case eDataType.BulletWeight:
					return (cPreferences.StaticPreferences.MetricBulletWeights ? "Grams" : "Grains");

				case eDataType.CanWeight:
					return (cPreferences.StaticPreferences.MetricCanWeights ? "Kilos" : "Pounds");

				case eDataType.Dimension:
					return (cPreferences.StaticPreferences.MetricDimensions ? "Millimeters" : "Inches");

				case eDataType.Firearm:
					return (cPreferences.StaticPreferences.MetricFirearms ? "Centimeters" : "Inches");

				case eDataType.GroupSize:
					return (cPreferences.StaticPreferences.MetricGroups ? "Centimeters" : "Inches");

				case eDataType.PowderWeight:
					return (cPreferences.StaticPreferences.MetricPowderWeights ? "Grams" : "Grains");

				case eDataType.Pressure:
					return (cPreferences.StaticPreferences.MetricAltitudes ? "Inches of Mercury" : "Millibars");

				case eDataType.Range:
					return (cPreferences.StaticPreferences.MetricRanges ? "Meters" : "Yards");

				case eDataType.ShotWeight:
					return (cPreferences.StaticPreferences.MetricShotWeights ? "Grams" : "Grains");

				case eDataType.Speed:
					return (cPreferences.StaticPreferences.MetricVelocities ? "Kilometers per Hour" : "Mile per Hour");

				case eDataType.Temperature:
					return (cPreferences.StaticPreferences.MetricTemperatures ? "Celsius" : "Fahrenheit");

				case eDataType.Velocity:
					return (cPreferences.StaticPreferences.MetricVelocities ? "Meter per Second (m/s)" : "Feet per Second (fps)");
				}

			return ("");
			}

		//============================================================================*
		// MetricString()
		//============================================================================*

		public static string MetricString(eDataType LabelType)
			{
			switch (LabelType)
				{
				case eDataType.Altitude:
					return (cPreferences.StaticPreferences.MetricAltitudes ? "m" : "ft");

				case eDataType.BulletWeight:
					return (cPreferences.StaticPreferences.MetricBulletWeights ? "g" : "gr");

				case eDataType.CanWeight:
					return (cPreferences.StaticPreferences.MetricCanWeights ? "kilo" : "lb");

				case eDataType.Dimension:
					return (cPreferences.StaticPreferences.MetricDimensions ? "mm" : "in.");

				case eDataType.Firearm:
					return (cPreferences.StaticPreferences.MetricFirearms ? "cm" : "in.");

				case eDataType.GroupSize:
					return (cPreferences.StaticPreferences.MetricGroups ? "cm" : "in.");

				case eDataType.PowderWeight:
					return (cPreferences.StaticPreferences.MetricPowderWeights ? "g" : "gr");

				case eDataType.Pressure:
					return (cPreferences.StaticPreferences.MetricPressures ? "mb" : "in Hg");

				case eDataType.Range:
					return (cPreferences.StaticPreferences.MetricRanges ? "m" : "yds");

				case eDataType.ShotWeight:
					return (cPreferences.StaticPreferences.MetricShotWeights ? "g" : "gr");

				case eDataType.Speed:
					return (cPreferences.StaticPreferences.MetricVelocities ? "kph" : "mph");

				case eDataType.Temperature:
					return (cPreferences.StaticPreferences.MetricTemperatures ? "C" : "F");

				case eDataType.Velocity:
					return (cPreferences.StaticPreferences.MetricVelocities ? "m/s" : "fps");
				}

			return ("");
			}

		//============================================================================*
		// MetricToStandard()
		//============================================================================*

		public static double MetricToStandard(double dValue, eDataType LabelType)
			{
			switch (LabelType)
				{
				case eDataType.Altitude:
					dValue = cPreferences.StaticPreferences.MetricAltitudes ? cConversions.MetersToFeet(dValue) : dValue;
					break;

				case eDataType.BulletWeight:
					dValue = cPreferences.StaticPreferences.MetricBulletWeights ? cConversions.GramsToGrains(dValue) : dValue;
					break;

				case eDataType.CanWeight:
					dValue = cPreferences.StaticPreferences.MetricCanWeights ? cConversions.KilosToPounds(dValue) : dValue;
					break;

				case eDataType.Dimension:
					dValue = cPreferences.StaticPreferences.MetricDimensions ? cConversions.MillimetersToInches(dValue) : dValue;
					break;

				case eDataType.Firearm:
					dValue = cPreferences.StaticPreferences.MetricFirearms ? cConversions.CentimetersToInches(dValue) : dValue;
					break;

				case eDataType.GroupSize:
					dValue = cPreferences.StaticPreferences.MetricGroups ? cConversions.CentimetersToInches(dValue) : dValue;
					break;

				case eDataType.PowderWeight:
					dValue = cPreferences.StaticPreferences.MetricPowderWeights ? cConversions.GramsToGrains(dValue) : dValue;
					break;

				case eDataType.Pressure:
					dValue = cPreferences.StaticPreferences.MetricPressures ? cConversions.MillibarsToInHg(dValue) : dValue;
					break;

				case eDataType.Range:
					dValue = cPreferences.StaticPreferences.MetricRanges ? cConversions.MetersToYards(dValue) : dValue;
					break;

				case eDataType.ShotWeight:
					dValue = cPreferences.StaticPreferences.MetricShotWeights ? cConversions.GramsToOunces(dValue) : dValue;
					break;

				case eDataType.Speed:
					dValue = cPreferences.StaticPreferences.MetricVelocities ? cConversions.KPHToMPH(dValue) : dValue;
					break;

				case eDataType.Temperature:
					dValue = cPreferences.StaticPreferences.MetricTemperatures ? cConversions.CelsiusToFahrenheit(dValue) : dValue;
					break;

				case eDataType.Velocity:
					dValue = cPreferences.StaticPreferences.MetricVelocities ? cConversions.MSToFPS(dValue) : dValue;
					break;
				}

			return (dValue);
			}

		//============================================================================*
		// PowderList Property
		//============================================================================*

		public cPowderList PowderList
			{
			get
				{
				return (m_PowderList);
				}
			}

		//============================================================================*
		// Preferences Property
		//============================================================================*

		public cPreferences Preferences
			{
			get
				{
				return (cPreferences.StaticPreferences);
				}
			}

		//============================================================================*
		// PrimerList Property
		//============================================================================*

		public cPrimerList PrimerList
			{
			get
				{
				return (m_PrimerList);
				}
			}

		//============================================================================*
		// RecalculateInventory()
		//============================================================================*

		public void RecalculateInventory()
			{
			m_BulletList.RecalulateInventory(this);
			m_PowderList.RecalulateInventory(this);
			m_PrimerList.RecalulateInventory(this);
			m_CaseList.RecalulateInventory(this);
			m_AmmoList.RecalulateInventory(this);
			}

		//============================================================================*
		// Reset()
		//============================================================================*

		public void Reset()
			{
			//----------------------------------------------------------------------------*
			// Reset data files
			//----------------------------------------------------------------------------*

			m_BatchList.Clear();
			m_LoadList.Clear();
			m_FirearmList.Clear();
			m_AmmoList.Clear();

			//----------------------------------------------------------------------------*
			// Reset Caliber Data
			//----------------------------------------------------------------------------*

			foreach (cCaliber Caliber in m_CaliberList)
				Caliber.Checked = false;

			//----------------------------------------------------------------------------*
			// Reset Bullet Data
			//----------------------------------------------------------------------------*

			foreach (cBullet Bullet in m_BulletList)
				{
				Bullet.Checked = false;

				Bullet.ResetAllInventoryData();
				}

			//----------------------------------------------------------------------------*
			// Reset Case Data
			//----------------------------------------------------------------------------*

			foreach (cCase Case in m_CaseList)
				{
				Case.Checked = false;

				Case.ResetAllInventoryData();
				}

			//----------------------------------------------------------------------------*
			// Reset Powder Data
			//----------------------------------------------------------------------------*

			foreach (cPowder Powder in m_PowderList)
				{
				Powder.Checked = false;

				Powder.ResetAllInventoryData();
				}

			//----------------------------------------------------------------------------*
			// Reset Primer Data
			//----------------------------------------------------------------------------*

			foreach (cPrimer Primer in m_PrimerList)
				{
				Primer.Checked = false;

				Primer.ResetAllInventoryData();
				}

			//----------------------------------------------------------------------------*
			// Reset website visited flags
			//----------------------------------------------------------------------------*

			foreach (cManufacturer Manufacturer in m_ManufacturerList)
				Manufacturer.WebSiteVisited = false;

			//----------------------------------------------------------------------------*
			// Reset Preferences
			//----------------------------------------------------------------------------*

			cPreferences.Reset();

			Save();
			}

		//============================================================================*
		// ResetBatches()
		//============================================================================*

		public void ResetBatches()
			{
			m_BatchList.Clear();

			foreach (cLoad Load in m_LoadList)
				{
				foreach (cCharge Charge in Load.ChargeList)
					{
					while (true)
						{
						bool fTestFound = false;

						foreach (cChargeTest ChargeTest in Charge.TestList)
							{
							if (ChargeTest.BatchTest || ChargeTest.BatchID != 0)
								{
								Charge.TestList.Remove(ChargeTest);

								fTestFound = true;

								break;
								}
							}

						if (!fTestFound)
							break;
						}
					}
				}

			cPreferences.StaticPreferences.NextBatchID = 1;

			Save();
			}

		//============================================================================*
		// ResetTransactions()
		//============================================================================*

		public void ResetTransactions()
			{
			foreach (cBullet Bullet in m_BulletList)
				Bullet.ResetInventoryData();

			foreach (cCase Case in m_CaseList)
				Case.ResetInventoryData();

			foreach (cPowder Powder in m_PowderList)
				Powder.ResetInventoryData();

			foreach (cPrimer Primer in m_PrimerList)
				Primer.ResetInventoryData();

			foreach (cAmmo Ammo in m_AmmoList)
				Ammo.ResetInventoryData();

			Save();
			}

		//============================================================================*
		// Restore()
		//============================================================================*

		public void Restore(string strFileName)
			{
			Load(strFileName, true);
			}

		//============================================================================*
		// Save()
		//============================================================================*

		public bool Save(string strFilePath = null)
			{
			Stream Stream = null;

			bool fSuccess = true;

			//----------------------------------------------------------------------------*
			// Save Data
			//----------------------------------------------------------------------------*

			try
				{
				//----------------------------------------------------------------------------*
				// Open data file and create formatter
				//----------------------------------------------------------------------------*

				if (strFilePath == null)
					strFilePath = Path.Combine(GetDataPath(), "ReloadersWorkShop.rwd");

				Stream = File.Open(strFilePath, FileMode.Create);

				BinaryFormatter Formatter = new BinaryFormatter();

				//----------------------------------------------------------------------------*
				// Serialize the data members
				//----------------------------------------------------------------------------*

				Formatter.Serialize(Stream, m_ManufacturerList);
				Formatter.Serialize(Stream, m_CaliberList);
				Formatter.Serialize(Stream, m_FirearmList);
				Formatter.Serialize(Stream, m_BulletList);
				Formatter.Serialize(Stream, m_CaseList);
				Formatter.Serialize(Stream, m_PowderList);
				Formatter.Serialize(Stream, m_PrimerList);
				Formatter.Serialize(Stream, m_LoadList);
				Formatter.Serialize(Stream, m_BatchList);
				Formatter.Serialize(Stream, m_AmmoList);

				//----------------------------------------------------------------------------*
				// Save Preferences
				//----------------------------------------------------------------------------*

				cPreferences.StaticPreferences.Serialize(Formatter, Stream);

				//----------------------------------------------------------------------------*
				// Save Extended Data
				//----------------------------------------------------------------------------*

				Formatter.Serialize(Stream, m_GearList);

				//----------------------------------------------------------------------------*
				// Close the stream
				//----------------------------------------------------------------------------*

				Stream.Close();

				Stream = null;
				}
			catch (Exception e1)
				{
				MessageBox.Show(e1.Message);

				fSuccess = false;
				}
			finally
				{
				if (Stream != null)
					Stream.Close();
				}

			return (fSuccess);
			}

		//============================================================================*
		// SetInputParameters()
		//============================================================================*

		public static void SetInputParameters(cDoubleValueTextBox TextBox, cDataFiles.eDataType eDataType, bool fPowder = false)
			{
			switch (eDataType)
				{
				case eDataType.Altitude:
					TextBox.NumDecimals = 0;
					TextBox.MaxLength = 5;
					break;

				case eDataType.BulletWeight:
					TextBox.NumDecimals = cPreferences.StaticPreferences.BulletWeightDecimals;
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricBulletWeights ? 3 : 4) + cPreferences.StaticPreferences.BulletWeightDecimals;
					break;

				case eDataType.CanWeight:
					if (cPreferences.StaticPreferences.TrackInventory)
						TextBox.NumDecimals = 3;
					else
						TextBox.NumDecimals = cPreferences.StaticPreferences.CanWeightDecimals;

					TextBox.MaxLength = TextBox.NumDecimals + 3;

					break;

				case eDataType.Cost:
					TextBox.NumDecimals = 2;
					TextBox.MaxLength = 7;
					break;

				case eDataType.Dimension:
					TextBox.NumDecimals = cPreferences.StaticPreferences.DimensionDecimals;
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricDimensions ? 4 : 2) + cPreferences.StaticPreferences.DimensionDecimals;
					break;

				case eDataType.Firearm:
					TextBox.NumDecimals = cPreferences.StaticPreferences.FirearmDecimals;
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricFirearms ? 5 : 4) + cPreferences.StaticPreferences.FirearmDecimals;
					break;

				case eDataType.GroupSize:
					TextBox.NumDecimals = cPreferences.StaticPreferences.GroupDecimals;
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricGroups ? 5 : 4) + cPreferences.StaticPreferences.GroupDecimals;
					break;

				case eDataType.PowderWeight:
					TextBox.NumDecimals = cPreferences.StaticPreferences.PowderWeightDecimals;
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricPowderWeights ? 3 : 4) + cPreferences.StaticPreferences.PowderWeightDecimals;
					break;

				case eDataType.Pressure:
					TextBox.NumDecimals = 2;
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricPressures ? 7 : 5);
					TextBox.MinValue = StandardToMetric(25.0, eDataType.Pressure);
					TextBox.MaxValue = StandardToMetric(33.0, eDataType.Pressure);
					break;

				case eDataType.Quantity:
					TextBox.NumDecimals = fPowder ? cPreferences.StaticPreferences.CanWeightDecimals : 0;
					TextBox.MaxLength = fPowder ? 3 + cPreferences.StaticPreferences.CanWeightDecimals : 4;
					break;

				case eDataType.Range:
					TextBox.NumDecimals = 0;
					TextBox.MaxLength = 4;
					break;

				case eDataType.ShotWeight:
					TextBox.NumDecimals = cPreferences.StaticPreferences.ShotWeightDecimals;
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricShotWeights ? 4 : 3) + cPreferences.StaticPreferences.ShotWeightDecimals;
					break;

				case eDataType.Speed:
					TextBox.NumDecimals = 0;
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricVelocities ? 4 : 3);
					break;

				case eDataType.Temperature:
					TextBox.NumDecimals = 0;
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricTemperatures ? 2 : 3);
					TextBox.MinValue = 0.0;
					TextBox.MaxValue = StandardToMetric(150.0, eDataType.Temperature);
					break;

				case eDataType.Velocity:
					TextBox.NumDecimals = 0;
					TextBox.MaxLength = 4;
					break;
				}
			}

		//============================================================================*
		// SetInputParameters()
		//============================================================================*

		public static void SetInputParameters(cIntegerValueTextBox TextBox, cDataFiles.eDataType eDataType)
			{
			switch (eDataType)
				{
				case eDataType.Altitude:
					TextBox.MaxLength = 5;
					break;

				case eDataType.BulletWeight:
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricBulletWeights ? 2 : 3);
					break;

				case eDataType.CanWeight:
					TextBox.MaxLength = 3;
					break;

				case eDataType.Dimension:
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricDimensions ? 3 : 2);
					break;

				case eDataType.Firearm:
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricFirearms ? 4 : 3);
					break;

				case eDataType.GroupSize:
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricGroups ? 3 : 2);
					break;

				case eDataType.PowderWeight:
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricPowderWeights ? 1 : 2);
					break;

				case eDataType.Pressure:
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricPressures ? 4 : 2);
					break;

				case eDataType.Range:
					TextBox.MaxLength = 4;
					break;

				case eDataType.ShotWeight:
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricShotWeights ? 4 : 2);
					break;

				case eDataType.Speed:
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricVelocities ? 4 : 3);
					break;

				case eDataType.Temperature:
					TextBox.MaxLength = (cPreferences.StaticPreferences.MetricTemperatures ? 2 : 3);
					break;

				case eDataType.Velocity:
					TextBox.MaxLength = 4;
					break;
				}
			}

		//============================================================================*
		// SetMetricLabel()
		//============================================================================*

		public static void SetMetricLabel(Label Label, eDataType LabelType)
			{
			Label.Text = MetricString(LabelType);
			}

		//============================================================================*
		// SetNextBatchID()
		//============================================================================*

		public void SetNextBatchID()
			{
			//----------------------------------------------------------------------------*
			// Make sure that the next batch number is one higher than the last batch made
			//----------------------------------------------------------------------------*

			int nBatchID = 0;

			foreach (cBatch CheckBatch in m_BatchList)
				{
				if (CheckBatch.BatchID > nBatchID)
					nBatchID = CheckBatch.BatchID;
				}

			cPreferences.StaticPreferences.NextBatchID = nBatchID + 1;
			}

		//============================================================================*
		// SortDataLists()
		//============================================================================*

		public void SortDataLists()
			{
			try
				{
				m_ManufacturerList.Sort(cManufacturer.Comparer);
				}
			catch { }

			try
				{
				m_CaliberList.Sort(cCaliber.Comparer);
				}
			catch { }

			try
				{
				m_FirearmList.Sort(cFirearm.Comparer);
				}
			catch { }

			try
				{
				m_BulletList.Sort(cBullet.Comparer);
				}
			catch { }

			try
				{
				m_CaseList.Sort(cCase.Comparer);
				}
			catch { }

			try
				{
				m_PowderList.Sort(cPowder.Comparer);
				}
			catch { }

			try
				{
				m_PrimerList.Sort(cPrimer.Comparer);
				}
			catch { }

			try
				{
				m_LoadList.Sort(cLoad.Comparer);
				}
			catch { }

			try
				{
				m_BatchList.Sort(cBatch.Comparer);
				}
			catch { }

			try
				{
				m_AmmoList.Sort(cAmmo.Comparer);
				}
			catch { }

			try
				{
				m_GearList.Sort(cGear.Comparer);
				}
			catch { }
			}

		//============================================================================*
		// StandardToMetric()
		//============================================================================*

		public static double StandardToMetric(double dValue, eDataType LabelType)
			{
			switch (LabelType)
				{
				case eDataType.Altitude:
					dValue = cPreferences.StaticPreferences.MetricAltitudes ? cConversions.FeetToMeters(dValue) : dValue;
					break;

				case eDataType.BulletWeight:
					dValue = cPreferences.StaticPreferences.MetricBulletWeights ? cConversions.GrainsToGrams(dValue) : dValue;
					break;

				case eDataType.CanWeight:
					dValue = cPreferences.StaticPreferences.MetricCanWeights ? cConversions.PoundsToKilos(dValue) : dValue;
					break;

				case eDataType.Dimension:
					dValue = cPreferences.StaticPreferences.MetricDimensions ? cConversions.InchesToMillimeters(dValue) : dValue;
					break;

				case eDataType.Firearm:
					dValue = cPreferences.StaticPreferences.MetricFirearms ? cConversions.InchesToCentimeters(dValue) : dValue;
					break;

				case eDataType.GroupSize:
					dValue = cPreferences.StaticPreferences.MetricGroups ? cConversions.InchesToCentimeters(dValue) : dValue;
					break;

				case eDataType.PowderWeight:
					dValue = cPreferences.StaticPreferences.MetricPowderWeights ? cConversions.GrainsToGrams(dValue) : dValue;
					break;

				case eDataType.Pressure:
					dValue = cPreferences.StaticPreferences.MetricPressures ? cConversions.InHgToMillibars(dValue) : dValue;
					break;

				case eDataType.Range:
					dValue = cPreferences.StaticPreferences.MetricRanges ? cConversions.YardsToMeters(dValue) : dValue;
					break;

				case eDataType.ShotWeight:
					dValue = cPreferences.StaticPreferences.MetricShotWeights ? cConversions.OuncesToGrams(dValue) : dValue;
					break;

				case eDataType.Speed:
					dValue = cPreferences.StaticPreferences.MetricVelocities ? cConversions.MPHToKPH(dValue) : dValue;
					break;

				case eDataType.Temperature:
					dValue = cPreferences.StaticPreferences.MetricTemperatures ? cConversions.FahrenheitToCelsius(dValue) : dValue;
					break;

				case eDataType.Velocity:
					dValue = cPreferences.StaticPreferences.MetricVelocities ? cConversions.FPSToMS(dValue) : dValue;
					break;
				}

			return (dValue);
			}

		//============================================================================*
		// SupplyCost()
		//============================================================================*

		public double SupplyCost(cSupply Supply)
			{
			if (Supply == null)
				return (0.0);

			double dQuantity = SupplyQuantity(Supply);

			double dCostEach = SupplyCostEach(Supply);

			return (dQuantity * dCostEach);
			}

		//============================================================================*
		// SupplyCostEach()
		//============================================================================*

		public double SupplyCostEach(cSupply Supply)
			{
			if (Supply == null)
				return (0.0);

			double dQuantity = 0.0;
			double dCost = 0.0;
			double dCostEach = 0.0;

			bool fReload = false;

			if (Supply != null)
				{
				if (cPreferences.StaticPreferences.TrackInventory)
					{
					if (Supply.SupplyType == cSupply.eSupplyTypes.Bullets)
						{
						foreach (cBullet Bullet in m_BulletList)
							{
							if (Bullet.Manufacturer.CompareTo(Supply.Manufacturer) == 0 &&
								Bullet.PartNumber == (Supply as cBullet).PartNumber)
								{
								if (Preferences.UseLastPurchase)
									{
									dQuantity += Bullet.LastPurchaseQty;
									dCost += Bullet.LastPurchaseCost;
									}

								if (Preferences.AverageCosts)
									{
									dQuantity += Bullet.TotalPurchaseQty;
									dCost += Bullet.TotalPurchaseCost;
									}
								}
							}
						}
					else
						{
						if (Supply.SupplyType == cSupply.eSupplyTypes.Ammo)
							{
							if ((Supply as cAmmo).BatchID != 0)
								{
								fReload = true;

								foreach (cBatch Batch in m_BatchList)
									{
									if (Batch.BatchID == (Supply as cAmmo).BatchID)
										{
										dQuantity = Batch.NumRounds;
										dCostEach = BatchCartridgeCost(Batch);

										break;
										}
									}
								}
							}

						if (!fReload)
							{
							if (Preferences.UseLastPurchase)
								{
								dQuantity = Supply.LastPurchaseQty;
								dCost = Supply.LastPurchaseCost;
								}

							if (Preferences.AverageCosts)
								{
								dQuantity = Supply.TotalPurchaseQty;
								dCost = Supply.TotalPurchaseCost;
								}
							}
						}
					}
				else
					{
					dQuantity = Supply.Quantity;
					dCost = Supply.Cost;
					}
				}

			if (dCostEach == 0.0 && dQuantity > 0.0)
				dCostEach = dCost / dQuantity;

			return (dCostEach);
			}

		//============================================================================*
		// SupplyQuantity()
		//============================================================================*

		public double SupplyQuantity(cSupply Supply)
			{
			if (Supply == null)
				return (0.0);

			if (cPreferences.StaticPreferences.TrackInventory)
				{
				if (Supply.SupplyType != cSupply.eSupplyTypes.Bullets)
					{
					return (Supply.QuantityOnHand);
					}
				else
					{
					double dQuanity = 0.0;

					foreach (cBullet Bullet in m_BulletList)
						{
						if (Supply.Manufacturer.CompareTo(Bullet.Manufacturer) == 0 &&
							Bullet.PartNumber == (Supply as cBullet).PartNumber)
							{
							dQuanity += Bullet.QuantityOnHand;
							}
						}

					return (dQuanity);
					}
				}

			return (Supply.Quantity);
			}

		//============================================================================*
		// Synch() - Batch
		//============================================================================*

		public void Synch()
			{
			foreach (cBatch CheckBatch in m_BatchList)
				CheckBatch.Synch();
			}

		//============================================================================*
		// Synch() - Bullet
		//============================================================================*

		public void Synch(cBullet Bullet)
			{
			//----------------------------------------------------------------------------*
			// Firearms
			//----------------------------------------------------------------------------*

			foreach (cFirearm CheckFirearm in m_FirearmList)
				CheckFirearm.Synch(Bullet);

			//----------------------------------------------------------------------------*
			// Loads
			//----------------------------------------------------------------------------*

			foreach (cLoad CheckLoad in m_LoadList)
				CheckLoad.Synch(Bullet);

			//----------------------------------------------------------------------------*
			// Transactions
			//----------------------------------------------------------------------------*

			foreach (cTransaction CheckTransaction in Bullet.TransactionList)
				CheckTransaction.Synch(Bullet);

			//----------------------------------------------------------------------------*
			// Preferences
			//----------------------------------------------------------------------------*

			if (cPreferences.StaticPreferences.BallisticsBullet != null && cPreferences.StaticPreferences.BallisticsBullet.CompareTo(Bullet) == 0)
				cPreferences.StaticPreferences.BallisticsBullet = Bullet;

			if (cPreferences.StaticPreferences.BatchEditorBullet != null && cPreferences.StaticPreferences.BatchEditorBullet.CompareTo(Bullet) == 0)
				cPreferences.StaticPreferences.BatchEditorBullet = Bullet;

			if (cPreferences.StaticPreferences.LastBatchBulletSelected != null && cPreferences.StaticPreferences.LastBatchBulletSelected.CompareTo(Bullet) == 0)
				cPreferences.StaticPreferences.LastBatchBulletSelected = Bullet;

			if (cPreferences.StaticPreferences.LastBatchLoadBulletSelected != null && cPreferences.StaticPreferences.LastBatchLoadBulletSelected.CompareTo(Bullet) == 0)
				cPreferences.StaticPreferences.LastBatchLoadBulletSelected = Bullet;

			if (cPreferences.StaticPreferences.LastBullet != null && cPreferences.StaticPreferences.LastBullet.CompareTo(Bullet) == 0)
				cPreferences.StaticPreferences.LastBullet = Bullet;

			if (cPreferences.StaticPreferences.LastBulletSelected != null && cPreferences.StaticPreferences.LastBulletSelected.CompareTo(Bullet) == 0)
				cPreferences.StaticPreferences.LastBulletSelected = Bullet;

			if (cPreferences.StaticPreferences.LastLoadDataBulletSelected != null && cPreferences.StaticPreferences.LastLoadDataBulletSelected.CompareTo(Bullet) == 0)
				cPreferences.StaticPreferences.LastLoadDataBulletSelected = Bullet;
			}

		//============================================================================*
		// Synch() - Caliber
		//============================================================================*

		public void Synch(cCaliber Caliber)
			{
			//----------------------------------------------------------------------------*
			// Firearms
			//----------------------------------------------------------------------------*

			foreach (cFirearm CheckFirearm in m_FirearmList)
				CheckFirearm.Synch(Caliber);

			//----------------------------------------------------------------------------*
			// Bullets
			//----------------------------------------------------------------------------*

			foreach (cBullet CheckBullet in m_BulletList)
				CheckBullet.Synch(Caliber);

			//----------------------------------------------------------------------------*
			// Cases
			//----------------------------------------------------------------------------*

			foreach (cCase CheckCase in m_CaseList)
				CheckCase.Synch(Caliber);

			//----------------------------------------------------------------------------*
			// Loads
			//----------------------------------------------------------------------------*

			foreach (cLoad CheckLoad in m_LoadList)
				CheckLoad.Synch(Caliber);

			//----------------------------------------------------------------------------*
			// Ammo
			//----------------------------------------------------------------------------*

			foreach (cAmmo Ammo in m_AmmoList)
				Ammo.Synch(Caliber);

			//----------------------------------------------------------------------------*
			// Preferences
			//----------------------------------------------------------------------------*

			if (cPreferences.StaticPreferences.BallisticsCaliber != null && cPreferences.StaticPreferences.BallisticsCaliber.CompareTo(Caliber) == 0)
				cPreferences.StaticPreferences.BallisticsCaliber = Caliber;

			if (cPreferences.StaticPreferences.BatchEditorCaliber != null && cPreferences.StaticPreferences.BatchEditorCaliber.CompareTo(Caliber) == 0)
				cPreferences.StaticPreferences.BatchEditorCaliber = Caliber;

			if (cPreferences.StaticPreferences.LastBatchCaliberSelected != null && cPreferences.StaticPreferences.LastBatchCaliberSelected.CompareTo(Caliber) == 0)
				cPreferences.StaticPreferences.LastBatchCaliberSelected = Caliber;

			if (cPreferences.StaticPreferences.LastBatchLoadCaliberSelected != null && cPreferences.StaticPreferences.LastBatchLoadCaliberSelected.CompareTo(Caliber) == 0)
				cPreferences.StaticPreferences.LastBatchLoadCaliberSelected = Caliber;

			if (cPreferences.StaticPreferences.LastBulletCaliber != null && cPreferences.StaticPreferences.LastBulletCaliber.CompareTo(Caliber) == 0)
				cPreferences.StaticPreferences.LastBulletCaliber = Caliber;

			if (cPreferences.StaticPreferences.LastCaliber != null && cPreferences.StaticPreferences.LastCaliber.CompareTo(Caliber) == 0)
				cPreferences.StaticPreferences.LastCaliber = Caliber;

			if (cPreferences.StaticPreferences.LastCaliberSelected != null && cPreferences.StaticPreferences.LastCaliberSelected.CompareTo(Caliber) == 0)
				cPreferences.StaticPreferences.LastCaliberSelected = Caliber;

			if (cPreferences.StaticPreferences.LastLoadDataCaliberSelected != null && cPreferences.StaticPreferences.LastLoadDataCaliberSelected.CompareTo(Caliber) == 0)
				cPreferences.StaticPreferences.LastLoadDataCaliberSelected = Caliber;
			}

		//============================================================================*
		// Synch() - Case
		//============================================================================*

		public void Synch(cCase Case)
			{
			//----------------------------------------------------------------------------*
			// Loads
			//----------------------------------------------------------------------------*

			foreach (cLoad CheckLoad in m_LoadList)
				CheckLoad.Synch(Case);

			//----------------------------------------------------------------------------*
			// Transactions
			//----------------------------------------------------------------------------*

			foreach (cTransaction CheckTransaction in Case.TransactionList)
				CheckTransaction.Synch(Case);

			//----------------------------------------------------------------------------*
			// Preferences
			//----------------------------------------------------------------------------*

			if (cPreferences.StaticPreferences.LastCase != null && cPreferences.StaticPreferences.LastCase.CompareTo(Case) == 0)
				cPreferences.StaticPreferences.LastCase = Case;

			if (cPreferences.StaticPreferences.LastCaseSelected != null && cPreferences.StaticPreferences.LastCaseSelected.CompareTo(Case) == 0)
				cPreferences.StaticPreferences.LastCaseSelected = Case;
			}

		//============================================================================*
		// Synch() - Ammo
		//============================================================================*

		public void Synch(cAmmo Ammo)
			{
			//----------------------------------------------------------------------------*
			// Ammo Tests
			//----------------------------------------------------------------------------*

			foreach (cAmmoTest AmmoTest in Ammo.TestList)
				AmmoTest.Synch(Ammo);

			//----------------------------------------------------------------------------*
			// Transactions
			//----------------------------------------------------------------------------*

			foreach (cTransaction CheckTransaction in Ammo.TransactionList)
				CheckTransaction.Synch(Ammo);
			}

		//============================================================================*
		// Synch() - Firearm
		//============================================================================*

		public void Synch(cFirearm Firearm)
			{
			//----------------------------------------------------------------------------*
			// Loads
			//----------------------------------------------------------------------------*

			foreach (cLoad CheckLoad in m_LoadList)
				CheckLoad.Synch(Firearm);

			//----------------------------------------------------------------------------*
			// Ammo
			//----------------------------------------------------------------------------*

			foreach (cAmmo Ammo in m_AmmoList)
				Ammo.Synch(Firearm);

			//----------------------------------------------------------------------------*
			// Gear
			//----------------------------------------------------------------------------*

			foreach (cGear Gear in m_GearList)
				Gear.Synch(Firearm);

			//----------------------------------------------------------------------------*
			// Preferences
			//----------------------------------------------------------------------------*

			if (cPreferences.StaticPreferences.BallisticsFirearm != null && cPreferences.StaticPreferences.BallisticsFirearm.CompareTo(Firearm) == 0)
				cPreferences.StaticPreferences.BallisticsFirearm = Firearm;

			if (cPreferences.StaticPreferences.LastFirearm != null && cPreferences.StaticPreferences.LastFirearm.CompareTo(Firearm) == 0)
				cPreferences.StaticPreferences.LastFirearm = Firearm;

			if (cPreferences.StaticPreferences.LastFirearmSelected != null && cPreferences.StaticPreferences.LastFirearmSelected.CompareTo(Firearm) == 0)
				cPreferences.StaticPreferences.LastFirearmSelected = Firearm;
			}

		//============================================================================*
		// Synch() - Firearm Accessories
		//============================================================================*

		public void Synch(cGear Gear)
			{
			foreach (cGear CheckGear in m_GearList)
				CheckGear.Synch(Gear);
			}

		//============================================================================*
		// Synch() - Loads
		//============================================================================*

		public void Synch(cLoad Load)
			{
			//----------------------------------------------------------------------------*
			// Batches
			//----------------------------------------------------------------------------*

			foreach (cBatch CheckBatch in m_BatchList)
				CheckBatch.Synch(Load);

			//----------------------------------------------------------------------------*
			// Preferences
			//----------------------------------------------------------------------------*

			if (cPreferences.StaticPreferences.BallisticsLoad != null && cPreferences.StaticPreferences.BallisticsLoad.CompareTo(Load) == 0)
				cPreferences.StaticPreferences.BallisticsLoad = Load;

			if (cPreferences.StaticPreferences.LastBatchLoadSelected != null && cPreferences.StaticPreferences.LastBatchLoadSelected.CompareTo(Load) == 0)
				cPreferences.StaticPreferences.LastBatchLoadSelected = Load;

			if (cPreferences.StaticPreferences.LastCopyLoadSelected != null && cPreferences.StaticPreferences.LastCopyLoadSelected.CompareTo(Load) == 0)
				cPreferences.StaticPreferences.LastCopyLoadSelected = Load;

			if (cPreferences.StaticPreferences.LastLoad != null && cPreferences.StaticPreferences.LastLoad.CompareTo(Load) == 0)
				cPreferences.StaticPreferences.LastLoad = Load;

			if (cPreferences.StaticPreferences.LastLoadSelected != null && cPreferences.StaticPreferences.LastLoadSelected.CompareTo(Load) == 0)
				cPreferences.StaticPreferences.LastLoadSelected = Load;
			}

		//============================================================================*
		// Synch() - Manufacturer
		//============================================================================*

		public void Synch(cManufacturer Manufacturer)
			{
			//----------------------------------------------------------------------------*
			// Bullets
			//----------------------------------------------------------------------------*

			foreach (cBullet CheckBullet in m_BulletList)
				CheckBullet.Synch(Manufacturer);

			//----------------------------------------------------------------------------*
			// Cases
			//----------------------------------------------------------------------------*

			foreach (cCase CheckCase in m_CaseList)
				CheckCase.Synch(Manufacturer);

			//----------------------------------------------------------------------------*
			// Ammo
			//----------------------------------------------------------------------------*

			foreach (cAmmo CheckAmmo in m_AmmoList)
				CheckAmmo.Synch(Manufacturer);

			//----------------------------------------------------------------------------*
			// Firearms
			//----------------------------------------------------------------------------*

			foreach (cFirearm CheckFirearm in m_FirearmList)
				CheckFirearm.Synch(Manufacturer);

			//----------------------------------------------------------------------------*
			// Primers
			//----------------------------------------------------------------------------*

			foreach (cPrimer CheckPrimer in m_PrimerList)
				CheckPrimer.Synch(Manufacturer);

			//----------------------------------------------------------------------------*
			// Powders
			//----------------------------------------------------------------------------*

			foreach (cPowder CheckPowder in m_PowderList)
				CheckPowder.Synch(Manufacturer);

			//----------------------------------------------------------------------------*
			// Firearm Accessories
			//----------------------------------------------------------------------------*

			foreach (cGear CheckGear in m_GearList)
				CheckGear.Synch(Manufacturer);

			//----------------------------------------------------------------------------*
			// Preferences
			//----------------------------------------------------------------------------*

			if (cPreferences.StaticPreferences.LastManufacturerSelected != null && cPreferences.StaticPreferences.LastManufacturerSelected.CompareTo(Manufacturer) == 0)
				cPreferences.StaticPreferences.LastManufacturerSelected = Manufacturer;
			}

		//============================================================================*
		// Synch() - Powder
		//============================================================================*

		public void Synch(cPowder Powder)
			{
			//----------------------------------------------------------------------------*
			// Loads
			//----------------------------------------------------------------------------*

			foreach (cLoad CheckLoad in m_LoadList)
				CheckLoad.Synch(Powder);

			//----------------------------------------------------------------------------*
			// Transactions
			//----------------------------------------------------------------------------*

			foreach (cTransaction CheckTransaction in Powder.TransactionList)
				CheckTransaction.Synch(Powder);

			//----------------------------------------------------------------------------*
			// Preferences
			//----------------------------------------------------------------------------*

			if (cPreferences.StaticPreferences.LastBatchLoadPowderSelected != null && cPreferences.StaticPreferences.LastBatchLoadPowderSelected.CompareTo(Powder) == 0)
				cPreferences.StaticPreferences.LastBatchLoadPowderSelected = Powder;

			if (cPreferences.StaticPreferences.LastBatchPowderSelected != null && cPreferences.StaticPreferences.LastBatchPowderSelected.CompareTo(Powder) == 0)
				cPreferences.StaticPreferences.LastBatchPowderSelected = Powder;

			if (cPreferences.StaticPreferences.LastLoadDataPowderSelected != null && cPreferences.StaticPreferences.LastLoadDataPowderSelected.CompareTo(Powder) == 0)
				cPreferences.StaticPreferences.LastLoadDataPowderSelected = Powder;

			if (cPreferences.StaticPreferences.LastPowder != null && cPreferences.StaticPreferences.LastPowder.CompareTo(Powder) == 0)
				cPreferences.StaticPreferences.LastPowder = Powder;

			if (cPreferences.StaticPreferences.LastPowderSelected != null && cPreferences.StaticPreferences.LastPowderSelected.CompareTo(Powder) == 0)
				cPreferences.StaticPreferences.LastPowderSelected = Powder;
			}

		//============================================================================*
		// Synch() - Primers
		//============================================================================*

		public void Synch(cPrimer Primer)
			{
			//----------------------------------------------------------------------------*
			// Loads
			//----------------------------------------------------------------------------*

			foreach (cLoad CheckLoad in m_LoadList)
				CheckLoad.Synch(Primer);

			//----------------------------------------------------------------------------*
			// Transactions
			//----------------------------------------------------------------------------*

			foreach (cTransaction CheckTransaction in Primer.TransactionList)
				CheckTransaction.Synch(Primer);

			//----------------------------------------------------------------------------*
			// Preferences
			//----------------------------------------------------------------------------*

			if (cPreferences.StaticPreferences.LastPrimer != null && cPreferences.StaticPreferences.LastPrimer.CompareTo(Primer) == 0)
				cPreferences.StaticPreferences.LastPrimer = Primer;

			if (cPreferences.StaticPreferences.LastPrimerSelected != null && cPreferences.StaticPreferences.LastPrimerSelected.CompareTo(Primer) == 0)
				cPreferences.StaticPreferences.LastPrimerSelected = Primer;
			}

		//============================================================================*
		// SynchDataLists()
		//============================================================================*

		public void SynchDataLists()
			{
			//----------------------------------------------------------------------------*
			// Manufacturers
			//----------------------------------------------------------------------------*

			foreach (cManufacturer Manufacturer in m_ManufacturerList)
				Synch(Manufacturer);

			//----------------------------------------------------------------------------*
			// Calibers
			//----------------------------------------------------------------------------*

			foreach (cCaliber Caliber in m_CaliberList)
				Synch(Caliber);

			//----------------------------------------------------------------------------*
			// Firearms
			//----------------------------------------------------------------------------*

			foreach (cFirearm Firearm in m_FirearmList)
				Synch(Firearm);

			//----------------------------------------------------------------------------*
			// Bullets
			//----------------------------------------------------------------------------*

			foreach (cBullet Bullet in m_BulletList)
				{
				if (Bullet.TransactionList == null)
					Bullet.TransactionList = new cTransactionList();

				Synch(Bullet);
				}

			//----------------------------------------------------------------------------*
			// Cases
			//----------------------------------------------------------------------------*

			foreach (cCase Case in m_CaseList)
				{
				if (Case.TransactionList == null)
					Case.TransactionList = new cTransactionList();

				Synch(Case);
				}

			//----------------------------------------------------------------------------*
			// Powders
			//----------------------------------------------------------------------------*

			foreach (cPowder Powder in m_PowderList)
				{
				if (Powder.TransactionList == null)
					Powder.TransactionList = new cTransactionList();

				Synch(Powder);
				}

			//----------------------------------------------------------------------------*
			// Primers
			//----------------------------------------------------------------------------*

			foreach (cPrimer Primer in m_PrimerList)
				{
				if (Primer.TransactionList == null)
					Primer.TransactionList = new cTransactionList();

				Synch(Primer);
				}

			//----------------------------------------------------------------------------*
			// Loads
			//----------------------------------------------------------------------------*

			foreach (cLoad Load in m_LoadList)
				Synch(Load);

			foreach (cBatch Batch in m_BatchList)
				Batch.Synch();

			//----------------------------------------------------------------------------*
			// Ammo
			//----------------------------------------------------------------------------*

			foreach (cAmmo Ammo in m_AmmoList)
				{
				if (Ammo.TransactionList == null)
					Ammo.TransactionList = new cTransactionList();

				Synch(Ammo);
				}
			}

		//============================================================================*
		// TransactionCount Property
		//============================================================================*

		public int TransactionCount
			{
			get
				{
				int nTransactionCount = 0;

				//----------------------------------------------------------------------------*
				// Ammo
				//----------------------------------------------------------------------------*

				foreach (cSupply Supply in m_AmmoList)
					nTransactionCount += Supply.TransactionList.Count;

				//----------------------------------------------------------------------------*
				// Bullets
				//----------------------------------------------------------------------------*

				foreach (cSupply Supply in m_BulletList)
					nTransactionCount += Supply.TransactionList.Count;

				//----------------------------------------------------------------------------*
				// Cases
				//----------------------------------------------------------------------------*

				foreach (cSupply Supply in m_CaseList)
					nTransactionCount += Supply.TransactionList.Count;

				//----------------------------------------------------------------------------*
				// Powders
				//----------------------------------------------------------------------------*

				foreach (cSupply Supply in m_PowderList)
					nTransactionCount += Supply.TransactionList.Count;

				//----------------------------------------------------------------------------*
				// Primers
				//----------------------------------------------------------------------------*

				foreach (cSupply Supply in m_PrimerList)
					nTransactionCount += Supply.TransactionList.Count;

				return (nTransactionCount);
				}
			}

		//============================================================================*
		// VerifyLoadQuantities()
		//============================================================================*

		public bool VerifyLoadQuantities(cLoad Load)
			{
			if (Load == null)
				return (false);

			if (!cPreferences.StaticPreferences.TrackInventory)
				return (true);

			if (Load.Bullet == null || SupplyQuantity(Load.Bullet) <= 0.0)
				return (false);

			if (Load.Case == null || SupplyQuantity(Load.Case) <= 0.0)
				return (false);

			if (Load.Powder == null || SupplyQuantity(Load.Powder) <= 0.0)
				return (false);

			if (Load.Primer == null || SupplyQuantity(Load.Primer) <= 0.0)
				return (false);

			return (true);
			}

		//============================================================================*
		// VerifyLoadQuantities() - Batch + Load
		//============================================================================*

		public bool VerifyLoadQuantities(cBatch Batch, cLoad Load)
			{
			if (Load == null || Batch == null)
				return (false);

			if (!cPreferences.StaticPreferences.TrackInventory || !Batch.TrackInventory)
				return (true);

			if (Load.Bullet == null || SupplyQuantity(Load.Bullet) <= 0.0)
				return (false);

			if (Load.Case == null || SupplyQuantity(Load.Case) <= 0.0)
				return (false);

			if (Load.Powder == null || SupplyQuantity(Load.Powder) <= 0.0)
				return (false);

			if (SupplyQuantity(Load.Powder) < Batch.NumRounds * Batch.PowderWeight)
				return (false);

			if (Load.Primer == null || SupplyQuantity(Load.Primer) <= 0.0)
				return (false);

			return (true);
			}

		//============================================================================*
		// VerifySMTPAddress()
		//============================================================================*

		public bool VerifySMTPAddress(string strSMTPAddress)
			{
			string strValidChars = ".-_";

			if (strSMTPAddress.Length < 4)
				return (false);

			if (!char.IsLetter(strSMTPAddress[0]) && !char.IsDigit(strSMTPAddress[0]))
				return (false);

			if (strSMTPAddress[strSMTPAddress.Length - 3] != '.' && strSMTPAddress[strSMTPAddress.Length - 4] != '.')
				return (false);

			if (strSMTPAddress.IndexOf("..") != -1 || strSMTPAddress.IndexOf("--") != -1)
				return (false);

			int nPos = 0;

			foreach (char chChar in strSMTPAddress)
				{
				if (!char.IsLetter(chChar) && !char.IsDigit(chChar))
					{
					if (strValidChars.IndexOf(chChar) == -1)
						return (false);

					if (strSMTPAddress[nPos - 1] == '.' || strSMTPAddress[nPos + 1] == '.')
						return (false);
					}

				nPos++;
				}

			return (true);
			}
		}
	}
