using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Text;

namespace AngliaTemplate
{
	/// <summary>
	/// Summary description for CoreDb.
	/// </summary>
	public class CoreDb : IDisposable
	{
		protected SqlConnection Cn = new SqlConnection(Core.AppSetting("ConnectionString"));

        // <summary>
        /// Determine the state of execution when inserting or updating records.
        /// </summary>
        public enum ActionState
        {
            /// <summary>
            /// Initialisation phase.
            /// </summary>
            Initialising,
            /// <summary>
            /// Opening a connection to the database.
            /// </summary>
            OpeningDB,
            /// <summary>
            /// Preparing parameters for the SQL command.
            /// </summary>
            Preparing,
            /// <summary>
            /// Busy executing commands against the database connection.
            /// </summary>
            Executing,
            /// <summary>
            /// Execution of commands finished successfully.
            /// </summary>
            Executed
        }

		private bool disposed = false;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);

		}

		public void Dispose(bool disposing)
		{
			if (disposed) return;
			if (disposing)
			{
				Cn.Dispose();
			}

			disposed = true;
		}
		#region generic sql commands

		#region Navision Conversions

		public static string SqlNavisionTime(DateTime dt)
		{
			string strReturn;
			strReturn = "'1 JAN 1754 " + dt.ToString("HH:mm:ss", null) + "'";
			return strReturn;
		}

		public static DateTime NavisionMinDate
		{
			get
			{
				return new DateTime(1753, 1, 1);
			}
		}

		public static DateTime NavisionMinTime
		{
			get
			{
				return new DateTime(1754, 1, 1);
			}
		}

		public static DateTime NavisionTime(DateTime dt)
		{
			return new DateTime(1754, 1, 1, dt.Hour, dt.Minute, dt.Second);

		}

		public static DateTime NavisionDateTime(DateTime dt)
		{
			return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);

		}

		public static DateTime NavisionDate(DateTime dt)
		{
			return new DateTime(dt.Year, dt.Month, dt.Day);
		}
		#endregion


		protected void showexception(string msg, string strsql)
		{
			Console.WriteLine(msg + " Database Open Exception\n\n" + strsql);
			//, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

		}

		protected void showexception(SqlException e, string strsql)
		{
			Console.WriteLine(e.Message + " Database Open Exception\n\n" + strsql);

		}


		protected SqlException showerrors(SqlException e, string strsql)
		{
			//if (silentmode) return e;

			SqlErrorCollection errorCollection = e.Errors;

			StringBuilder bld = new StringBuilder();
			Exception inner = e.InnerException;


			if (null != inner)
			{
				Console.WriteLine("Inner Exception: " + inner.ToString(), "SQL Error");
			}

			foreach (SqlError err in errorCollection)
			{
				bld.Append("\n Error Code: " + err.Number.ToString("X"));
				bld.Append("\n Message   : " + err.Message);

				bld.Append("\n Source    : " + err.Source);


				Console.WriteLine(bld.ToString());

				//MessageBox.Show(bld.ToString(), "SQL Error", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
				//AngliaTemplate.Core.Log("SQL Error - [" + strsql + "] " + bld.ToString());
				bld.Remove(0, bld.Length);




			}
			return e;
		}

		public static string AddQuotes(object val, bool addquotes)
		{
			if (!addquotes) return val.ToString();

			return "'" + val.ToString() + "'";
		}

		public static string SqlDate(DateTime dt)
		{
			string strReturn;

			strReturn = "'" + dt.ToString("dd/MMM/yyyy", null) + "'";

			return strReturn;
		}

		public static string SqlDateTime(DateTime dt)
		{
			string strReturn;
			strReturn = "'" + dt.ToString("dd/MMM/yyyy HH:mm:ss", null) + "'";

			return strReturn;

		}

		/// <summary>
		/// Returns datetime at midnight
		/// </summary>
		/// <param name="dt">Date to be converted</param>
		/// <returns></returns>
		public static string SqlDateTimeMidnight(DateTime dt)
		{
			string strReturn;
			strReturn = "'" + dt.ToString("dd/MMM/yyyy 00:00:00", null) + "'";

			return strReturn;

		}
		public static string SqlLiteral(string str)
		{

			//Create a StringBuilder to perform the replacements.
			StringBuilder sb = new StringBuilder(str);

			//Perform replacements.
			sb = sb.Replace("'", "''");
			sb = sb.Replace("\"", "\"\"");

			return sb.ToString();
		}


		public ArrayList SqlQuickList(string strSql)
		{

			// returns a list of values

			ArrayList alResults = new ArrayList();
			bool bOpen = (Cn.State == ConnectionState.Open);
			SqlCommand myCommand = null;
			if (!bOpen)
			{
				try
				{
					Cn.Open();
				}
				catch (Exception e)
				{
					throw new Exception("Unable to open database connection.", e);
				}
			}

			try
			{
				myCommand = new SqlCommand(strSql, Cn);
				myCommand.CommandType = System.Data.CommandType.Text;


				SqlDataReader myReader = myCommand.ExecuteReader();
				while (myReader.Read())
				{
					alResults.Add(myReader.GetValue(0).ToString());
				}
				myReader.Close();

			}
			catch (Exception e)
			{
				throw new Exception("SqlQuickList Error occurred running following SQL statement:\n\n" + strSql, e);
			}
			finally
			{
				//If the connection was closed to begin with, close it now.
				if (myCommand != null) myCommand.Dispose();
				if (!bOpen) Cn.Close();
			}
			return alResults;
		}


		protected bool DoesTableExist(string tablename)
		{
			string tabletest = tablename.Replace("[", "");
			tabletest = tabletest.Replace("]", "");
			string sql = "SELECT count(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='" + tabletest + "'";

			int ret = 0;
			//try
			//{
				ret = (int)SqlQuickValue(sql);
			//}
			//catch
			//{
			//}

			return ret == 1;
		}
		public SqlDataReader Sql(string strSql)
		{
			return Sql(strSql, null);
		}


		protected object SqlExecuteIdentity(string strsql)
		{
			return this.SqlExecuteIdentity(strsql, null);

		}

		protected object SqlExecuteIdentity(string strsql, SqlParameter[] prms)
		{
			object ret = 0;
			bool isopen = (Cn.State == ConnectionState.Open);

			System.Data.SqlClient.SqlCommand cmd = null;

			try
			{
				if (!isopen) Open();
				cmd = new SqlCommand(strsql, Cn);
				cmd.CommandType = CommandType.Text;

				if (prms != null)
				{
					foreach (SqlParameter x in prms)
						cmd.Parameters.Add(x);
				}
			}
			catch
			{
				if (cmd != null) cmd.Dispose();
				if (!isopen) Close();
				// showexception("SqlExecuteIdentity - Could Not Open Db Connection", strsql);
				return null;
			}

			try
			{
				cmd.ExecuteNonQuery();
				cmd.CommandText = "select @@identity";
				ret = CoreDb.DbToString(cmd.ExecuteScalar());

			}
			catch (System.Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());

			}
			if (cmd != null) cmd.Dispose();
			if (!isopen) Close();

			return ret;

		}

		public SqlDataReader Sql(string strSql, SqlParameter[] prms)
		{

			// returns a list of values

			SqlDataReader Reader;
			bool bOpen = (Cn.State == ConnectionState.Open);

			if (!bOpen)
				Cn.Open();

			SqlCommand myCommand = null;
			try
			{
				myCommand = new SqlCommand(strSql, Cn);
				myCommand.CommandType = System.Data.CommandType.Text;
				if (prms != null)
				{
					foreach (SqlParameter p in prms)
						myCommand.Parameters.Add(p);
				}
			}
			catch (Exception e)
			{
				myCommand.Dispose();
				throw new Exception("Sql Error occurred running following SQL statement:\n\n" + strSql, e);
			}



			if (!bOpen)
				Reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
			else
				Reader = myCommand.ExecuteReader();

			myCommand.Dispose();
			return Reader;
		}




		/// <summary>
		/// produces a comma seperated list of values
		/// </summary>
		/// <param name="strSql"></param>
		/// <returns></returns>
		public string SqlQuickCSVList(string strsql)
		{
			ArrayList al = this.SqlQuickList(strsql);
			if (al.Count == 0) return "";

			string ret = "";
			foreach (object x in al)
			{
				ret += x.ToString();
				ret += ",";
			}
			return ret.Substring(0, ret.Length - 1);

		}

		public object SqlQuickValue(string strSql)
		{
			return SqlQuickValue(strSql, null);
		}
		public object SqlQuickValue(string strSql, SqlParameter[] prms)
		{
			object lv_ret = null;
			SqlCommand cmd = null;
			bool bOpen = (Cn.State == ConnectionState.Open);
			if (!bOpen)
			{
				try
				{
					Cn.Open();
				}
				catch (Exception e)
				{
					throw new Exception("Unable to open database connection.", e);
				}
			}

			try
			{
				cmd = new SqlCommand(strSql, Cn);
				if (prms != null)
				{
					foreach (SqlParameter x in prms)
						cmd.Parameters.Add(x);
				}
				lv_ret = cmd.ExecuteScalar();
			}
			catch (Exception e)
			{
				throw new Exception("SqlQuickValue Error occurred running following SQL statement:\n\n" + strSql, e);
			}
			finally
			{
				if (cmd != null) cmd.Dispose();
				if (!bOpen) Cn.Close();
			}
			return lv_ret;
		}

		public void SqlExecute(string strSql)
		{
			SqlExecute(strSql, null);
		}
		public void SqlExecute(string strSql, SqlParameter[] prms)
		{

			//Current connection status.
			bool bOpen = (Cn.State == ConnectionState.Open);
			SqlCommand Dbc = null;

			//Check if the connection is open.
			if (!bOpen)
			{
				try
				{
					Cn.Open();
				}
				catch (Exception e)
				{
					throw new Exception("Unable to open database connection.", e);
				}
			}

			try
			{

				Dbc = new SqlCommand(strSql, Cn);
				if (prms != null)
				{
					foreach (SqlParameter p in prms)
						Dbc.Parameters.Add(p);
				}
				Dbc.ExecuteNonQuery();
			}
			catch (Exception e)
			{

				throw new Exception("SqlExecute Error occurred running following SQL statement:\n\n" + strSql, e);
			}
			finally
			{
				if (Dbc != null) Dbc.Dispose();
				if (!bOpen) Cn.Close();
			}
		}
		public void sqlcheckdata(string strSql)
		{

			//Current connection status.
			bool bOpen = (Cn.State == ConnectionState.Open);
			SqlCommand Dbc = null;


			//Check if the connection is open.
			if (!bOpen)
			{
				try
				{
					Cn.Open();
				}
				catch (Exception e)
				{
					throw new Exception("Unable to open database connection.", e);
				}
			}

			try
			{

				Dbc = new SqlCommand(strSql, Cn);
				Dbc.ExecuteReader();
			}
			catch (Exception e)
			{
				throw new Exception("SqlExecute Error occurred running following SQL statement:\n\n" + strSql, e);
			}
			finally
			{
				if (Dbc != null) Dbc.Dispose();
				if (!bOpen) Cn.Close();
			}
		}



		public void Open()
		{
			bool bOpen = (Cn.State == ConnectionState.Open);


			//Check if the connection is open.
			if (!bOpen)
				Cn.Open();
		}

		public void Close()
		{
			bool bOpen = (Cn.State == ConnectionState.Open);

			//Cceck if the connection is open.
			if (bOpen)
				Cn.Close();
		}

		public static DataTable Rotate(SqlDataReader ret)
		{
			int colcount = 0;
			ArrayList dataarray = new ArrayList();
			if (!ret.HasRows) return null;
			int introwcount = 0;
			while (ret.Read())
			{
				// loop around our columns  
				if (colcount == 0) colcount = ret.FieldCount;
				string[] ourrow = new string[ret.FieldCount];
				for (int i = 0; i < ret.FieldCount; i++)
				{
					if (ret[i] != DBNull.Value)
						ourrow[i] = ret[i].ToString();
					else
						ourrow[i] = "";
				}
				dataarray.Add(ourrow);
				introwcount++;
			}
			ret.Close();

			// Switch columns and rows, dynamically filling in the table

			DataTable dt = new DataTable();
			for (int i = 0; i < introwcount; i++)
				dt.Columns.Add(i.ToString());


			string[,] output = new string[colcount, introwcount];
			for (int col = 0; col < colcount; col++)
			{
				string[] thenerow = new string[introwcount];
				for (int row = 0; row < introwcount; row++)
				{
					string[] ourrow = (string[])dataarray[row];
					string ourval = ourrow[col];
					thenerow[row] = ourval;


				}
				dt.Rows.Add(thenerow);
			}
			return dt;

		}
		#endregion
		public static int DbToInt(object val)
		{
			if (Convert.IsDBNull(val))
				return 0;
			int ret = 0;
			try
			{
				return Convert.ToInt32(val.ToString());
			}
			catch
			{

			}
			return ret;
		}

		public static bool DbToBool(object val)
		{
			if (Convert.IsDBNull(val))
				return false;

			bool ret = false;
			try
			{
				return Math.Abs(Convert.ToInt32(val.ToString())) == 1;
			}
			catch
			{

			}

			try
			{
				return val.ToString().ToLower().StartsWith("y");
			}
			catch
			{

			}
			return ret;
		}


		public static decimal DbToDecimal(object val)
		{
			if (Convert.IsDBNull(val))
				return 0;
			decimal ret = 0;
			try
			{
				return Convert.ToDecimal(val.ToString());
			}
			catch
			{

			}
			return ret;
		}

		public static string DbToString(object val)
		{
			if (Convert.IsDBNull(val))
				return "";
			string ret = "";
			try
			{
				return val.ToString();
			}
			catch
			{

			}
			return ret;
		}

		protected bool DoesViewExist(string tablename)
		{
			return doesobjectexist(tablename, "VIEW");
		}

		private bool doesobjectexist(string objectname, string objecttype)
		{
			string objecttest = objectname.Replace("[", "");
			objecttest = objecttest.Replace("]", "");
			string sql = "SELECT count(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='" + CoreDb.SqlLiteral(objecttype) + "' AND TABLE_NAME='" + CoreDb.SqlLiteral(objecttest) + "'";

			int ret = 0;
			try
			{
				ret = (int)SqlQuickValue(sql);
			}
			catch (Exception e)
			{
			}

			return ret == 1;
		}


		public static string DbToStringRTrim(object val)
		{
			return DbToString(val).TrimEnd();
		}


		public static DateTime DbToDateTime(object val)
		{
			DateTime ret = CoreDb.NavisionMinDate;
			if (Convert.IsDBNull(val))
				return ret;

			try
			{
				return Convert.ToDateTime(val);
			}
			catch
			{

			}
			return ret;
		}
	}
}
