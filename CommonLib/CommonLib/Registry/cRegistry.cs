//============================================================================*
// cRegistry.cs
//
// Copyright © 2015, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using Microsoft.Win32;
using System.Windows.Forms;

//============================================================================*
// Namespace
//============================================================================*

namespace CommonLib.Registry
	{
	//============================================================================*
	// cRegistry Class
	//============================================================================*

	public class cRegistry
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fShowError = false;

		private RegistryKey m_BaseRegistryKey = null;

		private string m_strApplicationKey = string.Empty;

		//============================================================================*
		// cRegistry() - Default Constructor
		//============================================================================*

		public cRegistry(string strApplicationName)
			{
			m_BaseRegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);

			m_strApplicationKey = strApplicationName;
			}

		//============================================================================*
		// ApplicationKey Property
		//============================================================================*

		public string ApplicationKey
			{
			get
				{
				return (m_strApplicationKey);
				}
			set
				{
				m_strApplicationKey = value;
				}
			}

		//============================================================================*
		// BaseRegistryKey Property
		//============================================================================*

		public RegistryKey BaseRegistryKey
			{
			get
				{
				return m_BaseRegistryKey;
				}
			set
				{
				m_BaseRegistryKey = value;
				}
			}

		//============================================================================*
		// DeleteKey()
		//============================================================================*

		public bool DeleteKey(string strKeyName)
			{
			RegistryKey SubKey = null;

			bool fOK = true;

			try
				{
				SubKey = m_BaseRegistryKey.CreateSubKey(m_strApplicationKey);

				if (SubKey != null)
					SubKey.DeleteValue(strKeyName);
				}

			catch (Exception e)
				{
				ShowErrorMessage(e, "DeleteKey(" + strKeyName + ")");

				fOK = false;
				}

			finally
				{
				if (SubKey != null)
					SubKey.Close();
				}

			return (fOK);
			}

		//============================================================================*
		// DeleteSubKeyTree()
		//============================================================================*

		public bool DeleteSubKeyTree()
			{
			bool fOK = true;

			RegistryKey SubKey = null;

			try
				{
				SubKey = m_BaseRegistryKey.OpenSubKey(m_strApplicationKey);

				if (SubKey != null)
					m_BaseRegistryKey.DeleteSubKeyTree(m_strApplicationKey);
				}

			catch (Exception e)
				{
				ShowErrorMessage(e, "DeleteSubKey( " + m_strApplicationKey + ")");

				fOK = false;
				}

			finally
				{
				if (SubKey != null)
					SubKey.Close();
				}

			return (fOK);
			}

		//============================================================================*
		// ReadKey() - double
		//============================================================================*

		public bool ReadKey(string strKeyName, ref double dValue)
			{
			bool fOK = true;

			RegistryKey SubKey = m_BaseRegistryKey.OpenSubKey(m_strApplicationKey);

			if (SubKey == null)
				fOK = false;

			if (fOK)
				{
				try
					{
					dValue = (double) SubKey.GetValue(strKeyName);
					}

				catch (Exception e)
					{
					ShowErrorMessage(e, "ReadKey(" + strKeyName + ",  double)");

					fOK = false;
					}

				finally
					{
					SubKey.Close();
					}
				}

			return (fOK);
			}

		//============================================================================*
		// ReadKey() - long
		//============================================================================*

		public bool ReadKey(string strKeyName, ref long lValue)
			{
			bool fOK = true;

			RegistryKey SubKey = m_BaseRegistryKey.OpenSubKey( m_strApplicationKey, false);

			if (SubKey == null)
				fOK = false;

			if (fOK)
				{
				try
					{
					lValue = (long) SubKey.GetValue(strKeyName);
					}

				catch (Exception e)
					{
					ShowErrorMessage(e, "ReadKey(" + strKeyName + ", long)");

					fOK = false;
					}

				finally
					{
					if (SubKey != null)
						SubKey.Close();
					}
				}

			return (fOK);
			}

		//============================================================================*
		// ReadKey() - string
		//============================================================================*

		public bool ReadKey(string strKeyName, ref string strValue)
			{
			bool fOK = true;

			RegistryKey SubKey = m_BaseRegistryKey.OpenSubKey(m_strApplicationKey);

			if (SubKey == null)
				fOK = false;

			if (fOK)
				{
				try
					{
					strValue = (string) SubKey.GetValue(strKeyName);
					}

				catch (Exception e)
					{
					ShowErrorMessage(e, "ReadKey(" + strKeyName + ", string)");
					}

				finally
					{
					SubKey.Close();
					}
				}

			return (fOK);
			}

		//============================================================================*
		// ReadKey() - ulong
		//============================================================================*

		public bool ReadKey(string strKeyName, ref ulong ulValue)
			{
			bool fOK = true;

			RegistryKey SubKey = m_BaseRegistryKey.OpenSubKey(m_strApplicationKey);

			if (SubKey == null)
				fOK = false;

			if (fOK)
				{
				try
					{
					ulValue = (ulong) SubKey.GetValue(strKeyName);
					}

				catch (Exception e)
					{
					ShowErrorMessage(e, "ReadUnsignedLongKey(" + strKeyName + ")");

					fOK = false;
					}

				finally
					{
					if (SubKey != null)
						SubKey.Close();
					}
				}

			return (fOK);
			}

		//============================================================================*
		// ShowError Property
		//============================================================================*

		public bool ShowError
			{
			get
				{
				return (m_fShowError);
				}
			set
				{
				m_fShowError = value;
				}
			}

		//============================================================================*
		// ShowErrorMessage()
		//============================================================================*

		private void ShowErrorMessage(Exception e, string strCaption)
			{
			if (m_fShowError)
				MessageBox.Show(e.Message, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		//============================================================================*
		// SubKeyCount()
		//============================================================================*

		public int SubKeyCount()
			{
			RegistryKey SubKey = null;

			int nKeyCount = 0;

			try
				{
				SubKey = m_BaseRegistryKey.OpenSubKey(m_strApplicationKey);

				if (SubKey != null)
					nKeyCount = SubKey.SubKeyCount;
				}

			catch (Exception e)
				{
				ShowErrorMessage(e, "SubKeyCount(" + m_strApplicationKey + ")");
				}

			finally
				{
				if (SubKey != null)
					SubKey.Close();
				}

			return (nKeyCount);
			}

		//============================================================================*
		// ValueCount()
		//============================================================================*

		public int ValueCount()
			{
			RegistryKey SubKey = null;

			int nValueCount = 0;

			try
				{
				SubKey = m_BaseRegistryKey.OpenSubKey(m_strApplicationKey);

				if (SubKey != null)
					nValueCount = SubKey.ValueCount;
				}

			catch (Exception e)
				{
				ShowErrorMessage(e, "ValueCount (" + m_strApplicationKey + ")");
				}

			finally
				{
				if (SubKey != null)
					SubKey.Close();
				}

			return (nValueCount);
			}

		//============================================================================*
		// WriteKey() - double
		//============================================================================*

		public bool WriteKey(string strKeyName, double dValue)
			{
			RegistryKey SubKey = null;

			bool fOK = true;

			try
				{
				SubKey = m_BaseRegistryKey.CreateSubKey(m_strApplicationKey);

				if (SubKey == null)
					fOK = false;

				if (fOK)
					SubKey.SetValue(strKeyName, dValue, RegistryValueKind.QWord);
				}

			catch (Exception e)
				{
				ShowErrorMessage(e, "WriteKey(" + strKeyName + ", long)");

				fOK = false;
				}

			finally
				{
				if (SubKey != null)
					SubKey.Close();
				}

			return (fOK);
			}

		//============================================================================*
		// WriteKey() - long
		//============================================================================*

		public bool WriteKey(string strKeyName, long lValue)
			{
			RegistryKey SubKey = null;

			bool fOK = true;

			try
				{
				SubKey = m_BaseRegistryKey.CreateSubKey(m_strApplicationKey);

				if (SubKey == null)
					fOK = false;

				if (fOK)
					SubKey.SetValue(strKeyName, lValue, RegistryValueKind.QWord);
				}

			catch (Exception e)
				{
				ShowErrorMessage(e, "WriteKey(" + strKeyName + ", long)");

				fOK = false;
				}

			finally
				{
				if (SubKey != null)
					SubKey.Close();
				}

			return (fOK);
			}

		//============================================================================*
		// WriteKey() - string
		//============================================================================*

		public bool WriteKey(string strKeyName, string strValue)
			{
			RegistryKey SubKey = null;

			bool fOK = true;

			try
				{
				SubKey = m_BaseRegistryKey.CreateSubKey(m_strApplicationKey);

				if (SubKey != null)
					SubKey.SetValue(strKeyName, strValue, RegistryValueKind.String);
				}

			catch (Exception e)
				{
				ShowErrorMessage(e, "WriteKey(" + strKeyName + ", string)");

				fOK = false;
				}

			finally
				{
				if (SubKey != null)
					SubKey.Close();
				}

			return (fOK);
			}

		//============================================================================*
		// WriteKey() - ulong
		//============================================================================*

		public bool WriteKey(string strKeyName, ulong ulValue)
			{
			RegistryKey SubKey = null;

			bool fOK = true;

			try
				{
				SubKey = m_BaseRegistryKey.CreateSubKey(m_strApplicationKey);

				if (SubKey != null)
					SubKey.SetValue(strKeyName, ulValue, RegistryValueKind.DWord);
				}

			catch (Exception e)
				{
				ShowErrorMessage(e, "WriteKey(" + strKeyName + ", ulong)");

				fOK = false;
				}

			finally
				{
				if (SubKey != null)
					SubKey.Close();
				}

			return (fOK);
			}
		}
	}
