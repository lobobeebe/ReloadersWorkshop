//============================================================================*
// cListViewComparer.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Collections;
using System.Windows.Forms;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cListViewComparer Class
	//============================================================================*

	public class cListViewComparer : IComparer
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nSortColumn = 0;

		private SortOrder m_SortOrder = SortOrder.Ascending;

		//============================================================================*
		// cListViewComparer() - Constructor
		//============================================================================*

		public cListViewComparer(int nSortColumn, SortOrder SortOrder)
			{
			m_nSortColumn = nSortColumn;
			m_SortOrder = SortOrder;
			}

		//============================================================================*
		// Compare()
		//============================================================================*

		public virtual int Compare(Object Object1, Object Object2)
			{
			if (Object1 == null)
				{
				if (Object2 == null)
					return (0);
				else
					return (-1);
				}
			else
				{
				if (Object2 == null)
					return (1);
				}

			int rc = String.Compare((Object1 as ListViewItem).SubItems[m_nSortColumn].Text, (Object2 as ListViewItem).SubItems[m_nSortColumn].Text);

			if (m_SortOrder == SortOrder.Descending)
				return(0 - rc);

			return(rc);
			}

		//============================================================================*
		// SortColumn Property
		//============================================================================*

		public int SortColumn
			{
			get { return(m_nSortColumn); }
			set { m_nSortColumn = value; }
			}

		//============================================================================*
		// SortingOrder Property
		//============================================================================*

		public SortOrder SortingOrder
			{
			get { return (m_SortOrder); }
			set { m_SortOrder = value; }
			}
		}
	}
