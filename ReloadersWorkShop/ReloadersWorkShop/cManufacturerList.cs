//============================================================================*
// cManufacturerList.cs
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

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	[Serializable]
	public class cManufacturerList : List<cManufacturer>
		{
		//============================================================================*
		// AddManufacturer()
		//============================================================================*

		public bool AddManufacturer(cManufacturer Manufacturer)
			{
			foreach(cManufacturer CheckManufacturer in this)
				{
				if (CheckManufacturer.CompareTo(Manufacturer) == 0)
					return(false);
				}

			Add(Manufacturer);

			return(true);
			}

		//============================================================================*
		// Load()
		//============================================================================*

		public void Load()
			{
			//----------------------------------------------------------------------------*
			// Load the data
			//----------------------------------------------------------------------------*

			Stream DataStream = null;

			try
				{
				//----------------------------------------------------------------------------*
				// Open the data file
				//----------------------------------------------------------------------------*

				DataStream = File.Open("Manufacturers.dat", FileMode.Open);

				if (DataStream != null)
					{
					//----------------------------------------------------------------------------*
					// Create the formatter
					//----------------------------------------------------------------------------*

					BinaryFormatter Formatter = new BinaryFormatter();

					//----------------------------------------------------------------------------*
					// Load the data members
					//----------------------------------------------------------------------------*

					cManufacturerList ManufacturerList = null;

					ManufacturerList = (cManufacturerList)Formatter.Deserialize(DataStream);

					//----------------------------------------------------------------------------*
					// Copy the loaded data into this list
					//----------------------------------------------------------------------------*

					Clear();

					foreach (cManufacturer Manufacturer in ManufacturerList)
						Add(Manufacturer);
					}
				}

			//----------------------------------------------------------------------------*
			// If the data can't be loaded, oh well
			//----------------------------------------------------------------------------*

			catch
				{
				}

			finally
				{
				if (DataStream != null)
					DataStream.Close();
				}
			}

		//============================================================================*
		// Save()
		//============================================================================*

		public void Save()
			{
			Stream Stream = null;

			//----------------------------------------------------------------------------*
			// Save Data
			//----------------------------------------------------------------------------*

			try
				{
				//----------------------------------------------------------------------------*
				// Open data file and create formatter
				//----------------------------------------------------------------------------*

				Stream = File.Open("Manufacturers.dat", FileMode.Create);

				BinaryFormatter Formatter = new BinaryFormatter();

				//----------------------------------------------------------------------------*
				// Serialize the data members
				//----------------------------------------------------------------------------*

				Formatter.Serialize(Stream, this);

				//----------------------------------------------------------------------------*
				// Close the stream
				//----------------------------------------------------------------------------*

				Stream.Close();

				Stream = null;
				}
			catch
				{
				}
			finally
				{
				if (Stream != null)
					Stream.Close();
				}
			}
		}
	}
