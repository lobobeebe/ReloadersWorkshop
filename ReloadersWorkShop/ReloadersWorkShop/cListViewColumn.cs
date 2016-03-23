//============================================================================*
// cListViewColumn.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Windows.Forms;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cListViewColumn class
	//============================================================================*

	[Serializable]
	public class cListViewColumn : ColumnHeader
		{
		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		//============================================================================*
		// cListViewColumn() - Default Constructor
		//============================================================================*

		public cListViewColumn()
			{
			}

		//============================================================================*
		// cListViewColumn() - Constructor
		//============================================================================*

		public cListViewColumn(int nDisplayIndex, string strName, string strText, HorizontalAlignment Alignment, int nWidth)
			{
			DisplayIndex = nDisplayIndex;
			Name = strName;
			Text = strText;
			TextAlign = Alignment;
			Width = nWidth;
			}

		//============================================================================*
		// cListViewColumn() - Constructor
		//============================================================================*

		public cListViewColumn(ColumnHeader Column)
			{
			DisplayIndex = Column.DisplayIndex;
			Name = Column.Name;
			Text = Column.Text;
			TextAlign = Column.TextAlign;
			Width = Column.Width;
			}

		//============================================================================*
		// cListViewColumn() - Copy Constructor
		//============================================================================*

		public cListViewColumn(cListViewColumn Column)
			{
			DisplayIndex = Column.DisplayIndex;
			Name = Column.Name;
			Text = Column.Text;
			TextAlign = Column.TextAlign;
			Width = Column.Width;
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cListViewColumn Column1, cListViewColumn Column2)
			{
			if (Column1 == null)
				{
				if (Column2 != null)
					return (-1);
				else
					return (0);
				}

			return (Column1.CompareTo(Column2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(cListViewColumn Column)
			{
			if (Column == null)
				return (1);

			//----------------------------------------------------------------------------*
			// Compare Display Index
			//----------------------------------------------------------------------------*

			return(DisplayIndex.CompareTo(Column.DisplayIndex));
			}
		}
	}
