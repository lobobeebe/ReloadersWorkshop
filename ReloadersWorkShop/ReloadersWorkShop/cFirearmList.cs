//============================================================================*
// cFirearmList.cs
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
	// cFirearmList Class
	//============================================================================*

	[Serializable]
	public class cFirearmList : List<cFirearm>
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
					Writer.WriteLine(cFirearm.CSVHeader);
					Writer.WriteLine();

					Writer.WriteLine(cFirearm.CSVLineHeader);
					Writer.WriteLine();

					foreach (cFirearm Firearm in this)
						{
						strLine = Firearm.CSVLine;

						Writer.WriteLine(strLine);
						}

					Writer.WriteLine();

					break;

				case cDataFiles.eExportType.XML:
					Writer.WriteLine(cFirearm.XMLHeader);
					Writer.WriteLine(cFirearm.XMLLineHeader);

					foreach (cFirearm Firearm in this)
						{
						strLine = Firearm.XMLLine;

						Writer.WriteLine(strLine);
						}

					break;
				}
			}
		}
	}
