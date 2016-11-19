//============================================================================*
// cTestShotList.cs
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
using System.Xml;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cTestShotList Class
	//============================================================================*

	[Serializable]
	public class cTestShotList : List<cTestShot>
		{
		//============================================================================*
		// cTestShotList() - Constructor
		//============================================================================*

		public cTestShotList()
			{
			}

		//============================================================================*
		// cTestShotList() - Copy Constructor
		//============================================================================*

		public cTestShotList(cTestShotList TestShotList)
			{
			foreach (cTestShot TestShot in TestShotList)
				Add(new cTestShot(TestShot));
			}

		//============================================================================*
		// Export() - CSV
		//============================================================================*

		public void Export(StreamWriter Writer)
			{
			if (Count <= 0)
				return;

			Writer.WriteLine(",,TestShots");
			Writer.WriteLine();

			Writer.WriteLine(",," + cTestShot.CSVLineHeader);
			Writer.WriteLine();

			foreach (cTestShot TestShot in this)
				TestShot.Export(Writer);

			Writer.WriteLine();
			}

		//============================================================================*
		// Export() - XML
		//============================================================================*

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement(string.Empty, "TestShots", string.Empty);
				XMLParentElement.AppendChild(XMLElement);

				foreach (cTestShot TestShot in this)
					TestShot.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// GetStatistics()
		//============================================================================*

		public cTestStatistics GetStatistics(int nNumRounds)
			{
			cTestStatistics Statistics = new cTestStatistics();
			Statistics.NumRounds = nNumRounds;

			int nTotalVelocity = 0;

			foreach (cTestShot TestShot in this)
				{
				if (TestShot.MuzzleVelocity > 0 && !TestShot.Misfire && !TestShot.Squib)
					{
					Statistics.NumShots++;
					nTotalVelocity += TestShot.MuzzleVelocity;

					if (Statistics.MinVelocity == 0 || TestShot.MuzzleVelocity < Statistics.MinVelocity)
						Statistics.MinVelocity = TestShot.MuzzleVelocity;

					if (Statistics.MaxVelocity == 0 || TestShot.MuzzleVelocity > Statistics.MaxVelocity)
						Statistics.MaxVelocity = TestShot.MuzzleVelocity;
					}
				}

			if (Statistics.NumShots > 0 && nTotalVelocity > 0)
				{
				Statistics.AverageVelocity = (double) nTotalVelocity / (double) Statistics.NumShots;

				foreach (cTestShot TestShot in this)
					{
					if (TestShot.MuzzleVelocity > 0 && !TestShot.Misfire && !TestShot.Squib)
						Statistics.Variance += (((double) TestShot.MuzzleVelocity - Statistics.AverageVelocity) * ((double) TestShot.MuzzleVelocity - Statistics.AverageVelocity));
					}

				Statistics.Variance /= (double) (Statistics.NumShots - 1);

				Statistics.StdDev = Math.Sqrt(Statistics.Variance);
				}

			return (Statistics);
			}
		}
	}
