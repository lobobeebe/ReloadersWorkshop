//============================================================================*
// cSQL.cs
//
// Copyright 2015, Kevin S, Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// Using Statements
//============================================================================*

using System;
using System.Data.SqlClient;

//============================================================================*
// Namespace
//============================================================================*

namespace CommonLib.Data
	{
	//============================================================================*
	// cSQL Class
	//============================================================================*

	public class cSQL : IDisposable
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private SqlConnection m_SqlConnection = null;

		private string m_strConnectionString = string.Empty;

		private string m_strServer = string.Empty;
		private string m_strDatabase = string.Empty;
		private string m_strUserID = string.Empty;
		private string m_strPassword = string.Empty;

		private bool m_fDisposed = false;

		private string m_strErrorMessage = string.Empty;
		private int m_nErrorCode = 0;

		//============================================================================*
		// cSQL() - Default Constructor
		//============================================================================*

		public cSQL()
			{

			}

		//============================================================================*
		// cSQL() - Constructor - server, Database, UserID, Password
		//============================================================================*

		public cSQL(string strServer, string strDataBase, string strUserID, string strPassword)
			{
			Server = strServer;
			Database = strDataBase;
			UserID = strUserID;
			Password = strPassword;
			}

		//============================================================================*
		// cSQL() - Constructor - Connection String
		//============================================================================*

		public cSQL(string strConnectionString)
			{
			ConnectionString = strConnectionString;
			}

		//============================================================================*
		// Close()
		//============================================================================*

		public void Close()
			{
			if (m_SqlConnection != null && m_SqlConnection.State == System.Data.ConnectionState.Open)
				m_SqlConnection.Close();
			}

		//============================================================================*
		// ConnectionString Property
		//============================================================================*

		public string ConnectionString
			{
			get
				{
				return (m_strConnectionString);
				}
			set
				{
				m_strConnectionString = value;

				Initialize();
				}
			}

		//============================================================================*
		// Database Property
		//============================================================================*

		public string Database
			{
			get
				{
				return (m_strDatabase);
				}
			set
				{
				m_strDatabase = value;

				Initialize();
				}
			}

		//============================================================================*
		// Dispose()
		//============================================================================*

		public void Dispose()
			{
			Dispose(true);

			GC.SuppressFinalize(this);
			}

		//============================================================================*
		// Dispose()
		//============================================================================*

		protected virtual void Dispose(bool fDisposing)
			{
			if (!m_fDisposed)
				{
				if (fDisposing)
					{
					if (m_SqlConnection != null)
						m_SqlConnection.Dispose();
					}
				}

			m_fDisposed = true;
            }

		//============================================================================*
		// ErrorCode Property
		//============================================================================*

		public int ErrorCode
			{
			get
				{
				return (m_nErrorCode);
				}
			set
				{
				m_nErrorCode = value;
				}
			}

		//============================================================================*
		// ErrorMessage Property
		//============================================================================*

		public string ErrorMessage
			{
			get
				{
				return (m_strErrorMessage);
				}
			set
				{
				m_strErrorMessage = value;
				}
			}

		//============================================================================*
		// ExecuteCommand()
		//============================================================================*

		public int ExecuteCommand(string strCommand)
			{
			int nCount = 0;

			try
				{
				m_SqlConnection.Open();

				SqlCommand Command = new SqlCommand(strCommand, m_SqlConnection);

				nCount = Command.ExecuteNonQuery();
				}
			catch (SqlException se)
				{
				m_strErrorMessage = se.Message;
				m_nErrorCode = se.ErrorCode;

				nCount = 0;
				}
			finally
				{
				if (m_SqlConnection != null && m_SqlConnection.State == System.Data.ConnectionState.Open)
					m_SqlConnection.Close();
				}

			return (nCount);
			}

		//============================================================================*
		// ExecuteQuery()
		//============================================================================*

		public SqlDataReader ExecuteQuery(string strCommand)
			{
			SqlDataReader Reader = null;

			try
				{
				m_SqlConnection.Open();

				SqlCommand Command = new SqlCommand(strCommand, m_SqlConnection);

				Reader = Command.ExecuteReader();
				}
			catch(SqlException se)
				{
				Reader = null;

				m_nErrorCode = se.ErrorCode;
				m_strErrorMessage = se.Message;
				}

			return (Reader);
			}

		//============================================================================*
		// Initialize()
		//============================================================================*

		private void Initialize()
			{
			m_strConnectionString = string.Empty;

			if (m_SqlConnection != null)
				{
				m_SqlConnection.Close();

				m_SqlConnection = null;
				}

			if (!string.IsNullOrEmpty(m_strServer) && !string.IsNullOrEmpty(m_strDatabase) && !string.IsNullOrEmpty(m_strUserID) && !string.IsNullOrEmpty(m_strPassword))
				{
				m_strConnectionString = String.Format("Data Source={2};Initial Catalog={3};User Id={0};Password={1}", m_strUserID, m_strPassword, m_strServer, m_strDatabase);

				m_SqlConnection = new SqlConnection(m_strConnectionString);
				}
			}

		//============================================================================*
		// Password Property
		//============================================================================*

		public string Password
			{
			get
				{
				return (m_strPassword);
				}
			set
				{
				m_strPassword = value;

				Initialize();
				}
			}

		//============================================================================*
		// Server Property
		//============================================================================*

		public string Server
			{
			get
				{
				return (m_strServer);
				}
			set
				{
				m_strServer = value;

				Initialize();
				}
			}

		//============================================================================*
		// UserID Property
		//============================================================================*

		public string UserID
			{
			get
				{
				return (m_strUserID);
				}
			set
				{
				m_strUserID = value;

				Initialize();
				}
			}
		}
	}
