//============================================================================*
// cBatchList.cs
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
	// cBatchList Class
	//============================================================================*

	[Serializable]
	public class cBatchList : List<cBatch>
		{
		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(StreamWriter Writer, cDataFiles.eExportType eType, bool fBatchTests)
			{
			string strLine = "";

			switch (eType)
				{
				case cDataFiles.eExportType.CSV:
					Writer.WriteLine(cBatch.CSVHeader);
					Writer.WriteLine();

					Writer.WriteLine(cBatch.CSVLineHeader);
					Writer.WriteLine();

					foreach (cBatch Batch in this)
						{
						strLine = Batch.CSVLine;

						Writer.WriteLine(strLine);

						if (Batch.BatchTest != null && fBatchTests)
							{
							Writer.WriteLine();

							Batch.BatchTest.Export(Writer, eType);

							Writer.WriteLine();
							}
						}

					Writer.WriteLine();

					break;

				case cDataFiles.eExportType.XML:
					Writer.WriteLine(cBatch.XMLHeader);
					Writer.WriteLine(cBatch.XMLLineHeader);

					foreach (cBatch Batch in this)
						{
						strLine = Batch.XMLLine;

						Writer.WriteLine(strLine);
						}

					break;
				}
			}
		}
	}
