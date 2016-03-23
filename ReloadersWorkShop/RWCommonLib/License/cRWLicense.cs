//============================================================================*
// cRWLicense.cs
//============================================================================*

//============================================================================*
// Using Statements
//============================================================================*

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//============================================================================*
// namespace
//============================================================================*

namespace RWCommonLib.License
	{
	//============================================================================*
	// cRWLicense Class
	//============================================================================*

	public class cRWLicense
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private string m_strName = null;
		private string m_strEmail = null;
		private string m_strKey = null;
		private string m_strComputerName = null;
        private string m_strNIC = null;

		//============================================================================*
		// cRWLicense() - Default Constructor
		//============================================================================*

		public cRWLicense()
			{
			}

		//============================================================================*
		// cRWLicense() - Constructor
		//============================================================================*

		public cRWLicense(string strName, string strEmail, string strKey, string strComputerName = null, string strNIC = null)
			{
			m_strName = strName;
			m_strEmail = strEmail;
			m_strKey = strKey;
			m_strComputerName = strComputerName;
			m_strNIC = strNIC;
			}

		//============================================================================*
		// ComputerName Property
		//============================================================================*

		public string ComputerName
			{
			get
				{
				return (m_strComputerName);
				}
			set
				{
				m_strComputerName = value;
				}
			}

		//============================================================================*
		// Email Property
		//============================================================================*

		public string Email
			{
			get
				{
				return (m_strEmail);
				}
			set
				{
				m_strEmail = value;
				}
			}

		//============================================================================*
		// Key Property
		//============================================================================*

		public string Key
			{
			get
				{
				return (m_strKey);
				}
			set
				{
				m_strKey = value;
				}
			}

		//============================================================================*
		// Name Property
		//============================================================================*

		public string Name
			{
			get
				{
				return (m_strName);
				}
			set
				{
				m_strName = value;
				}
			}

		//============================================================================*
		// NIC Property
		//============================================================================*

		public string NIC
			{
			get
				{
				return (m_strNIC);
				}
			set
				{
				m_strNIC = value;
				}
			}
		}
	}
