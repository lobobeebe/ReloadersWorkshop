//============================================================================*
// cPowderList.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.IO;
using System.Collections.Generic;

namespace ReloadersWorkShop
	{
	[Serializable]
	public class cPowderList : List<cPowder>
		{
		//============================================================================*
		// AddPowder()
		//============================================================================*

		public bool AddPowder(cPowder Powder)
			{
			foreach (cPowder CheckPowder in this)
				{
				if (CheckPowder.CompareTo(Powder) == 0)
					return(false);
				}

			Add(Powder);

			return(true);
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(StreamWriter Writer, cDataFiles.eExportType eType)
			{
			string strLine = "";

			switch (eType)
				{
				case cDataFiles.eExportType.CSV:
					Writer.WriteLine(cPowder.CSVHeader);
					Writer.WriteLine();

					Writer.WriteLine(cPowder.CSVLineHeader);
					Writer.WriteLine();

					foreach (cPowder Powder in this)
						{
						strLine = Powder.CSVLine;

						Writer.WriteLine(strLine);
						}

					Writer.WriteLine();

					break;

				case cDataFiles.eExportType.XML:
					Writer.WriteLine(cPowder.XMLHeader);
					Writer.WriteLine(cPowder.XMLLineHeader);

					foreach (cPowder Powder in this)
						{
						strLine = Powder.XMLLine;

						Writer.WriteLine(strLine);
						}

					break;
				}
			}

		//============================================================================*
		// HandgunCount Property
		//============================================================================*

		public int HandgunCount
			{
			get
				{
				int nCount = 0;

				foreach (cPowder Powder in this)
					{
					if (Powder.FirearmType == cFirearm.eFireArmType.Handgun)
						nCount++;
					}

				return (nCount);
				}
			}

		//============================================================================*
		// RecalulateInventory()
		//============================================================================*

		public void RecalulateInventory(cDataFiles DataFiles)
			{
			foreach (cSupply Supply in this)
				Supply.RecalculateInventory(DataFiles);
			}

		//============================================================================*
		// RifleCount Property
		//============================================================================*

		public int RifleCount
			{
			get
				{
				int nCount = 0;

				foreach (cPowder Powder in this)
					{
					if (Powder.FirearmType == cFirearm.eFireArmType.Rifle)
						nCount++;
					}

				return (nCount);
				}
			}
		}
	}
