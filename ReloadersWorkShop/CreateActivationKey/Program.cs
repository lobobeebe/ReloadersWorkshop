using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using RWCommonLib.Registry;

namespace CreateActivationKey
	{
	static class Program
		{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
			{
			cRWRegistry RWRegistry = new cRWRegistry();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(RWRegistry));
			}
		}
	}
