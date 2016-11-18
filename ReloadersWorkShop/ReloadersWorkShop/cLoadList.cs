//============================================================================*
// cLoadList.cs
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
	public class cLoadList : List<cLoad>
		{
		//============================================================================*
		// AddLoad()
		//============================================================================*

		public bool AddLoad(cLoad Load)
			{
			foreach (cLoad CheckLoad in this)
				{
				if (CheckLoad.CompareTo(Load) == 0)
					return (false);
				}

			Add(Load);

			return (true);
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
					Writer.WriteLine(cLoad.CSVHeader);
					Writer.WriteLine();

					Writer.WriteLine(cLoad.CSVLineHeader);
					Writer.WriteLine();

					foreach (cLoad Load in this)
						{
						cCaliber.CurrentFirearmType = Load.FirearmType;

						strLine = Load.CSVLine;

						Writer.WriteLine(strLine);
						}

					Writer.WriteLine();

					break;

				case cDataFiles.eExportType.XML:
					Writer.WriteLine(cLoad.XMLHeader);
					Writer.WriteLine(cLoad.XMLLineHeader);

					foreach (cLoad Load in this)
						{
						strLine = Load.XMLLine;

						Writer.WriteLine(strLine);
						}

					break;
				}
			}
		}
	}
