using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace SRLOCSistema.Dto
{
	public class DbContext
	{
		private SQLiteConnection _conn = null;
		String _connectionString = @"Data Source=Db\database.db"; //  \

		private void SetConnection()
		{
			_conn = new SQLiteConnection
				(_connectionString);
		}

		public void ExecuteQuery(string txtQuery)
		{
			SQLiteCommand command;
			try
			{
				SetConnection();
				_conn.Open();
								
				command = _conn.CreateCommand();
				command.CommandText = txtQuery;
				command.ExecuteNonQuery();

				_conn.Close();
			}
			catch
			{
				throw;
			}
		}

		public DataTable ExecuteSelect(string query)
		{
			var retorno = new DataTable();
			SQLiteCommand command;
			SQLiteDataAdapter adapter;
			DataSet dataSet;
			try
			{
				SetConnection();
				_conn.Open();

				command = _conn.CreateCommand();
				adapter = new SQLiteDataAdapter(query, _conn);
				dataSet = new DataSet();
				dataSet.Reset();
				adapter.Fill(dataSet);
				retorno = dataSet.Tables[0];

				_conn.Close();
			}
			catch
			{
				throw;
			}

			return retorno;
		}
	}
}
