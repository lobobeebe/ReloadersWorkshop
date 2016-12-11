//============================================================================*
// cDataIntegrity.cs
//
// Copyright © 2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cDataIntegrity Class
	//============================================================================*

	public class cDataIntegrity
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		private int m_nNumManufacturers = 0;
		private int m_nNumBadManufacturers = 0;

		private int m_nNumCalibers = 0;
		private int m_nNumBadCalibers = 0;

		//============================================================================*
		// cDataIntegrity() - Constructor
		//============================================================================*

		public cDataIntegrity(cDataFiles DataFiles)
			{
			m_DataFiles = DataFiles;

			ProcessAll();
			}

		//============================================================================*
		// ProcessAll()
		//============================================================================*

		public void ProcessAll()
			{
			ProcessManufacturers();
			ProcessCalibers();
			}

		//============================================================================*
		// ProcessCalibers()
		//============================================================================*

		public void ProcessCalibers()
			{
			m_nNumCalibers = m_DataFiles.CaliberList.Count;

			foreach (cCaliber Caliber in m_DataFiles.CaliberList)
				{
				if (!Caliber.Validate())
					m_nNumBadCalibers++;
				}
			}

		//============================================================================*
		// ProcessManufacturers()
		//============================================================================*

		public void ProcessManufacturers()
			{
			m_nNumManufacturers = m_DataFiles.ManufacturerList.Count;

			foreach (cManufacturer Manufacturer in m_DataFiles.ManufacturerList)
				{
				if (!Manufacturer.Validate())
					m_nNumBadManufacturers++;
				}
			}
		}
	}
