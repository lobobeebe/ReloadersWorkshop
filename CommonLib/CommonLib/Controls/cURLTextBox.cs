//============================================================================*
// cURLTextBox.cs
//
// Copyright © 2013-2015, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;

//============================================================================*
// NameSpace
//============================================================================*

namespace CommonLib.Controls
	{
	//============================================================================*
	// cURLTextBox Class
	//============================================================================*

	public class cURLTextBox : cTextBox
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		//============================================================================*
		// cURLTextBox() - Constructor
		//============================================================================*

		public cURLTextBox()
			{
			Populate();
			}

		//============================================================================*
		// Verify()
		//============================================================================*

		protected override bool Verify()
			{
			string strToolTip = ToolTip;
			ValueOK = true;

			base.Verify();

			if (!Required && ValueOK)
				return (true);

			//----------------------------------------------------------------------------*
			// Make sure there are no invalid characters
			//----------------------------------------------------------------------------*

			if (ValueOK)
				{
				string strSpecialChars = @"\/:-_.~";

				foreach(char ch in Value)
					{
					if (Char.IsLetterOrDigit(ch))
						continue;

					if (strSpecialChars.IndexOf(ch) == -1)
						{
						ValueOK = false;

						strToolTip += String.Format("\n\nInvalid character, '{0}', in URL.", ch);

						break;
						}
					}
				}
			
			//----------------------------------------------------------------------------*
			// Make sure the first and last chars are a letter or number
			//----------------------------------------------------------------------------*

			if (ValueOK && Value.Length > 0)
				{
				if ((!Char.IsLetterOrDigit(Value[0]) || !Char.IsLetterOrDigit(Value[Value.Length - 1])) && Value[Value.Length - 1] != '/')
					{
					ValueOK = false;

					strToolTip += "\n\nThe first and last character MUST be a letter or number, or the last character may be /.";
					}
				}

			//----------------------------------------------------------------------------*
			// Need to have at least 7 chars
			//----------------------------------------------------------------------------*

			if (ValueOK && Value.Length < 7)
				{
				ValueOK = false;

				strToolTip += "\n\nURL is too short to be valid.";
				}

			//----------------------------------------------------------------------------*
			// Musat have at least 1 dot
			//----------------------------------------------------------------------------*

			if (ValueOK && !Value.Contains("."))
				{
				ValueOK = false;

				strToolTip += "\n\nInvalid URL.";
				}

			//----------------------------------------------------------------------------*
			// Set Background color
			//----------------------------------------------------------------------------*

			if (!ValueOK && Enabled)
				BackColor = Color.LightPink;
			else
				BackColor = SystemColors.Window;

			if (ToolTip.Length > 0)
				ToolTip = strToolTip;

			return (ValueOK);
			}
		}
	}
