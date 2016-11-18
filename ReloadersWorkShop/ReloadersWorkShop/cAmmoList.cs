//============================================================================*
// cFactoryAmmoList.cs
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

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFactoryAmmoList Class
	//============================================================================*

	[Serializable]
	public class cAmmoList : List<cAmmo>
		{
		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(StreamWriter Writer, cDataFiles.eExportType eType)
			{
			string strLine = "";

			switch (eType)
				{
				case cDataFiles.eExportType.CSV:
					Writer.WriteLine(cAmmo.CSVHeader);
					Writer.WriteLine();

					Writer.WriteLine(cAmmo.CSVLineHeader);
					Writer.WriteLine();

					foreach (cAmmo Ammo in this)
						{
						strLine = Ammo.CSVLine;

						Writer.WriteLine(strLine);
						}

					Writer.WriteLine();

					break;

				case cDataFiles.eExportType.XML:
					Writer.WriteLine(cAmmo.XMLHeader);
					Writer.WriteLine(cAmmo.XMLLineHeader);

					foreach (cAmmo Ammo in this)
						{
						strLine = Ammo.XMLLine;

						Writer.WriteLine(strLine);
						}

					break;
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
		}
	}
