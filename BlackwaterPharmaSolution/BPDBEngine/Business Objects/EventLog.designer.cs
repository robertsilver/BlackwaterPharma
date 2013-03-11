/*
-- Anglia Business Solutions http://www.angliabs.com --
Data Maker Created Class
Created - 27 March 2010
-- Table tblEventLog --
assumption below made for config file:
<add key="TableOwner" value="dbo"/>
*/

using System;
using System.Collections;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using AngliaTemplate;

// Please copy and paste the below commented section, to a new file to extend this class.
/*
namespace BPDBEngine
{
	public partial class Tbleventlog
	{
		// sample join to go get data from another table
		// Item ouritem=null;
		// Item Ouritem
		// {
			// get
			// {
				// refresh_item();
				// return ouritem;
			// }
		// }
		// private void refresh_item()
		// {
			// if (ouritem!=null) return;
			// ItemAggregate iagg = new ItemAggregate();
			// Item[] ouritems = iagg.GetSingular(this.Id);
			// iagg.Dispose();
			// if (ouritems.Length==0) return;
			// ouritem=ouritems[0];
		// }
	}
	
	public partial class TbleventlogAggregate
	{
	}
	
}

*/

namespace BPDBEngine
{
	public partial class Tbleventlog : CoreDb, IDisposable
	{
		#region private variables
		private string tableowner = Core.AppSetting("TableOwner"); // dbo - at time of build
		private string tablename = "tblEventLog";

		private string applicationname = string.Empty; // Maps To Database Field - [ApplicationName]
		private string description = string.Empty; // Maps To Database Field - [Description]
		private string entrytype = string.Empty; // Maps To Database Field - [EntryType]
		private int id = 0; // Maps To Database Field - [ID]
		private DateTime insertdatetime = DateTime.MinValue; // Maps To Database Field - [InsertDateTime]
		private string methodname = string.Empty; // Maps To Database Field - [MethodName]

		private bool keyintegrity = true; // used to indicate that our class correctly maps to key fields of underlying data
		private bool disposed = false;
		#endregion

		#region public properties

		public bool KeyIntegrity // used to indicate that our class correctly maps to key fields of underlying data
		{
			get
			{
				return keyintegrity;
			}
			set
			{
				keyintegrity = value;
			}
		}

		public string TableOwner
		{
			set
			{
				tableowner = value;
			}

			get
			{
				return tableowner;
			}

		}

		public string TableName
		{
			set
			{
				tablename = value;
			}

			get
			{
				return tablename;
			}

		}


		/// <summary>
		/// Maps To Database Field - [ApplicationName] - varchar(100)
		/// </summary>
		public string Applicationname
		{
			get
			{
				return applicationname;
			}
			set
			{
				applicationname = value;
				// automatic truncation of variables
				if (applicationname.Length > 100)
				{
					// throw new Exception("applicationname is over maximum character length of 100 characters.");
					applicationname = applicationname.Substring(0, 100);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [Description] - varchar(2000)
		/// </summary>
		public string Description
		{
			get
			{
				return description;
			}
			set
			{
				description = value;
				// automatic truncation of variables
				if (description.Length > 2000)
				{
					// throw new Exception("description is over maximum character length of 2000 characters.");
					description = description.Substring(0, 2000);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [EntryType] - varchar(100)
		/// </summary>
		public string Entrytype
		{
			get
			{
				return entrytype;
			}
			set
			{
				entrytype = value;
				// automatic truncation of variables
				if (entrytype.Length > 100)
				{
					// throw new Exception("entrytype is over maximum character length of 100 characters.");
					entrytype = entrytype.Substring(0, 100);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [ID] - int(10)
		/// </summary>
		public int Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		/// <summary>
		/// Maps To Database Field - [InsertDateTime] - datetime
		/// </summary>
		public DateTime Insertdatetime
		{
			get
			{
				return insertdatetime;
			}
			set
			{
				insertdatetime = value;
			}
		}

		/// <summary>
		/// Label For Insertdatetime Maps To Database Field - [InsertDateTime] - datetime
		/// </summary>
		public string Insertdatetime_Label
		{
			get
			{
				return Insertdatetime.ToShortDateString();
			}
		}

		/// <summary>
		/// Maps To Database Field - [MethodName] - varchar(200)
		/// </summary>
		public string Methodname
		{
			get
			{
				return methodname;
			}
			set
			{
				methodname = value;
				// automatic truncation of variables
				if (methodname.Length > 200)
				{
					// throw new Exception("methodname is over maximum character length of 200 characters.");
					methodname = methodname.Substring(0, 200);
				}
			}
		}
		#endregion

		#region constructor
		public Tbleventlog()
		{
			initialise();
		}

		public Tbleventlog(
			 string applicationname
			, string description
			, string entrytype
			, int id
			, DateTime insertdatetime
			, string methodname
		)
		{
			initialise();
			this.applicationname = applicationname;
			this.description = description;
			this.entrytype = entrytype;
			this.id = id;
			this.insertdatetime = insertdatetime;
			this.methodname = methodname;
		}
		#endregion

		#region public members
		public new void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		public new void Dispose(bool disposing)
		{
			if (disposed) return;
			if (disposing)
			{
			}
			disposed = true;
			base.Dispose(disposing);
		}

		public void Delete()
		{
			StringBuilder sbsql = new StringBuilder();
			sbsql.Append("DELETE FROM " + tableowner + tablename + " ");
			sbsql.Append("WHERE ");
			sbsql.Append("[ID] = @id ");

			SqlExecute(sbsql.ToString(), this.GetWhereValues());
		}

		public void Update()
		{
			// Determine if keys are valid
			if (!keyintegrity)
				throw new Exception("tblEventLog key integrity error, a previous insert operation occured without the class being updated with all key field values.");

			bool isinsert = true;
			// Determine if we are doing an insert or an update
			StringBuilder sbsql = new StringBuilder();
			// if block to determine if we need to test for record existance
			if (
				id != 0
			)
			{
				sbsql.Append("SELECT ");
				sbsql.Append("COUNT(1) ");
				sbsql.Append("FROM ");
				sbsql.Append(tableowner + tablename + " ");
				sbsql.Append("WHERE ");
				sbsql.Append("[ID] = @id ");

				isinsert = (CoreDb.DbToInt(SqlQuickValue(sbsql.ToString(), this.GetWhereValues())) == 0);

			}
			if (isinsert)
			{
				SqlParameter[] ourparams = this.GetInsertValues();
				SqlParameter[,] ret = new SqlParameter[1, ourparams.Length];
				int intcount = 0;
				foreach (SqlParameter c in ourparams)
				{
					ret[0, intcount] = c;
					intcount++;
				}
				id = CoreDb.DbToInt(BulkInsert(ret));

				// TODO - Check that the identity is the key and remove below line if true
				keyintegrity = false;
			}
			else
			{
				SqlParameter[] ourparams = this.GetUpdateValues();
				SqlParameter[,] ret = new SqlParameter[1, ourparams.Length];
				int intcount = 0;
				foreach (SqlParameter c in ourparams)
				{
					ret[0, intcount] = c;
					intcount++;
				}
				BulkUpdate(ret);
			}

		}

		public object BulkInsert(SqlParameter[,] ourparams)
		{
			#region initalising
			ActionState state = ActionState.Initialising;
			object ret = null;
			if (ourparams.GetLength(0) == 0) return ret;
			StringBuilder sbsql = new StringBuilder();

			sbsql.Append("INSERT INTO ");
			sbsql.Append(tableowner + tablename + " ");
			sbsql.Append("(");
			sbsql.Append(" [ApplicationName] ");
			sbsql.Append(",[Description] ");
			sbsql.Append(",[EntryType] ");
			sbsql.Append(",[InsertDateTime] ");
			sbsql.Append(",[MethodName] ");
			sbsql.Append(") ");
			sbsql.Append("VALUES ");
			sbsql.Append("(");
			sbsql.Append(" @applicationname ");  // Maps To Database Field - [ApplicationName]
			sbsql.Append(",@description ");  // Maps To Database Field - [Description]
			sbsql.Append(",@entrytype ");  // Maps To Database Field - [EntryType]
			sbsql.Append(",@insertdatetime ");  // Maps To Database Field - [InsertDateTime]
			sbsql.Append(",@methodname ");  // Maps To Database Field - [MethodName]
			sbsql.Append(")");

			bool isopen = (Cn != null && Cn.State == ConnectionState.Open);
			SqlCommand cmd = null;
			SqlTransaction trans = null;
			int rowcount = 0;
			#endregion Initialise
			try
			{
				#region Open DB
				state = ActionState.OpeningDB;
				if (!isopen) this.Open();
				#endregion Open DB

				#region Preparing
				state = ActionState.Preparing;
				trans = Cn.BeginTransaction();
				cmd = new SqlCommand(sbsql.ToString(), this.Cn, trans);
				for (int intcount = 0; intcount < ourparams.GetLength(1); intcount++)
					cmd.Parameters.Add(ourparams[0, intcount]);
				#endregion Preparing

				#region Execute
				// see if we are really inserting multiple records
				if (ourparams.GetLength(0) > 1)
				{
					cmd.Prepare();
					state = ActionState.Executing;
					for (rowcount = 0; rowcount < ourparams.GetLength(0); rowcount++)
					{
						if (rowcount > 0) // first row has already been setup
							for (int intcount = 0; intcount < ourparams.GetLength(1); intcount++)
								cmd.Parameters[intcount].Value = ourparams[rowcount, intcount].Value;
						cmd.ExecuteNonQuery();
					}

					state = ActionState.Executed;
				}

				else
				{
					state = ActionState.Executing;
					cmd.ExecuteNonQuery();
					cmd.CommandText = "SELECT @@IDENTITY";
					ret = CoreDb.DbToString(cmd.ExecuteScalar());
					state = ActionState.Executed;
				}

			}

				#endregion Execute
			catch (System.Exception ex)
			{
				#region Handle any errors
				string error = "";
				switch (state)
				{
					case ActionState.OpeningDB:
						error = ex.Message + " - Failed to open/connect to DB";
						break;
					case ActionState.Initialising:
						error = ex.Message + " - Failed to initialise transaction";
						break;
					case ActionState.Preparing:
						error = ex.Message + " - Failed to prepare DB transaction";
						break;
					case ActionState.Executing:
						error = ex.Message + " - Failed to execute DB transaction" + (rowcount > 0 ? " on record " + rowcount : "");
						break;
					default:
						error = ex.Message + " - Unknown DB error";
						break;
				#endregion Handle any errors
				}

				throw new ApplicationException(error, ex);
			}

			finally
			{
				#region Cleanup
				if (trans != null)
				{
					switch (state)
					{
						case ActionState.Executed:
							trans.Commit();
							break;
						default:
							trans.Rollback();
							break;
					}

					trans.Dispose();
				}

				if (cmd != null) cmd.Dispose();
				if (!isopen) this.Close();
				#endregion Cleanup
			}

			return ret;
		}


		public void BulkUpdate(SqlParameter[,] ourparams)
		{
			#region Initalising
			ActionState state = ActionState.Initialising;
			if (ourparams.GetLength(0) == 0) return;
			StringBuilder sbsql = new StringBuilder();

			sbsql.Append("UPDATE ");
			sbsql.Append(tableowner + tablename + " ");
			sbsql.Append("SET ");
			sbsql.Append(" [ApplicationName] = @applicationname ");
			sbsql.Append(",[Description] = @description ");
			sbsql.Append(",[EntryType] = @entrytype ");
			sbsql.Append(",[InsertDateTime] = @insertdatetime ");
			sbsql.Append(",[MethodName] = @methodname ");
			sbsql.Append("WHERE ");
			sbsql.Append("[ID] = @id ");


			bool isopen = (Cn.State == ConnectionState.Open);
			SqlCommand cmd = null;
			SqlTransaction trans = null;
			int rowcount = 0;
			#endregion Initialise
			try
			{
				#region Open DB
				state = ActionState.OpeningDB;
				if (!isopen) this.Open();
				#endregion Open DB

				#region Preparing
				state = ActionState.Preparing;
				trans = Cn.BeginTransaction();
				cmd = new SqlCommand(sbsql.ToString(), this.Cn, trans);
				for (int intcount = 0; intcount < ourparams.GetLength(1); intcount++)
					cmd.Parameters.Add(ourparams[0, intcount]);
				#endregion Preparing

				#region Execute
				// see if we are really inserting multiple records
				if (ourparams.GetLength(0) > 1)
				{
					cmd.Prepare();
					state = ActionState.Executing;
					for (rowcount = 0; rowcount < ourparams.GetLength(0); rowcount++)
					{
						if (rowcount > 0) // first row has already been setup
							for (int intcount = 0; intcount < ourparams.GetLength(1); intcount++)
								cmd.Parameters[intcount].Value = ourparams[rowcount, intcount].Value;
						cmd.ExecuteNonQuery();
					}

					state = ActionState.Executed;
				}

				else
				{
					state = ActionState.Executing;
					cmd.ExecuteNonQuery();
					state = ActionState.Executed;
				}

			}

				#endregion Execute
			catch (System.Exception ex)
			{
				#region Handle any errors
				string error = "";
				switch (state)
				{
					case ActionState.OpeningDB:
						error = "Failed to open/connect to DB";
						break;
					case ActionState.Initialising:
						error = "Failed to initialise transaction";
						break;
					case ActionState.Preparing:
						error = "Failed to prepare DB transaction";
						break;
					case ActionState.Executing:
						error = "Failed to execute DB transaction" + (rowcount > 0 ? " on record " + rowcount : "");
						break;
					default:
						error = "Unknown DB error";
						break;
				#endregion Handle any errors
				}

				throw new ApplicationException(error, ex);
			}

			finally
			{
				#region Cleanup
				if (trans != null)
				{
					switch (state)
					{
						case ActionState.Executed:
							trans.Commit();
							break;
						default:
							trans.Rollback();
							break;
					}

					trans.Dispose();
				}

				if (cmd != null) cmd.Dispose();
				if (!isopen) this.Close();
				#endregion Cleanup
			}

		}


		public SqlParameter[] GetInsertValues()
		{
			ArrayList paramcollection = new ArrayList();
			SqlParameter tempparam = null;

			// build values
			tempparam = new SqlParameter();  // Maps To - [ApplicationName]
			tempparam.ParameterName = "@applicationname";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 100;
			tempparam.Value = applicationname;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [Description]
			tempparam.ParameterName = "@description";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 2000;
			tempparam.Value = description;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [EntryType]
			tempparam.ParameterName = "@entrytype";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 100;
			tempparam.Value = entrytype;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [InsertDateTime]
			tempparam.ParameterName = "@insertdatetime";
			tempparam.SqlDbType = System.Data.SqlDbType.DateTime;
			tempparam.Value = insertdatetime;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [MethodName]
			tempparam.ParameterName = "@methodname";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 200;
			tempparam.Value = methodname;
			paramcollection.Add(tempparam);

			return (SqlParameter[])paramcollection.ToArray(typeof(SqlParameter));
		}

		public SqlParameter[] GetUpdateValues()
		{
			ArrayList paramcollection = new ArrayList();
			SqlParameter tempparam = null;

			// build values
			tempparam = new SqlParameter();  // Maps To - [ApplicationName]
			tempparam.ParameterName = "@applicationname";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 100;
			tempparam.Value = applicationname;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [Description]
			tempparam.ParameterName = "@description";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 2000;
			tempparam.Value = description;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [EntryType]
			tempparam.ParameterName = "@entrytype";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 100;
			tempparam.Value = entrytype;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [InsertDateTime]
			tempparam.ParameterName = "@insertdatetime";
			tempparam.SqlDbType = System.Data.SqlDbType.DateTime;
			tempparam.Value = insertdatetime;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [MethodName]
			tempparam.ParameterName = "@methodname";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 200;
			tempparam.Value = methodname;
			paramcollection.Add(tempparam);

			// build where clause
			paramcollection.AddRange(GetWhereValues());

			return (SqlParameter[])paramcollection.ToArray(typeof(SqlParameter));
		}

		public void UpdateKeys(
		int newid
		)
		{
			StringBuilder sbsql = new StringBuilder();

			sbsql.Append("UPDATE ");
			sbsql.Append(tableowner + tablename + " ");
			sbsql.Append("SET ");
			sbsql.Append(" [ID] = @newid ");
			sbsql.Append("WHERE ");
			sbsql.Append("[ID] = @id ");

			ArrayList paramcollection = new ArrayList();
			SqlParameter tempparam = null;

			// build update values
			tempparam = new SqlParameter();  // Maps To - [ID]
			tempparam.ParameterName = "@newid";
			tempparam.SqlDbType = System.Data.SqlDbType.Int;
			tempparam.Precision = 10;
			tempparam.Value = (int)(newid);
			paramcollection.Add(tempparam);

			// build where clause
			paramcollection.AddRange(GetWhereValues());
			SqlParameter[] sqlparms = (SqlParameter[])paramcollection.ToArray(typeof(SqlParameter));
			SqlExecute(sbsql.ToString(), sqlparms);
			// overwrite our keys
			id = newid;
		}


		public SqlParameter[] GetWhereValues()
		{
			ArrayList paramcollection = new ArrayList();
			SqlParameter tempparam = null;

			// build where clause
			tempparam = new SqlParameter();  // Maps To - [ID]
			tempparam.ParameterName = "@id";
			tempparam.SqlDbType = System.Data.SqlDbType.Int;
			tempparam.Precision = 10;
			tempparam.Value = (int)(id);
			paramcollection.Add(tempparam);

			return (SqlParameter[])paramcollection.ToArray(typeof(SqlParameter));
		}

		#endregion

		#region private members
		private void initialise()
		{
			// Cn = new SqlConnection(Core.AppSetting("ConnectionString Override"));
			if (tableowner.Length > 0) tableowner = "[" + tableowner + "].";
		}

		#endregion
	}

	public partial class TbleventlogAggregate : CoreDb
	{
		#region private variables

		private string tableowner = Core.AppSetting("TableOwner"); // dbo - at time of build
		private string tablename = "tblEventLog";
		private bool overridentableidentifier = false;
		#endregion

		#region public properties
		public string TableOwner
		{
			set
			{
				tableowner = value;
				overridentableidentifier = true;
			}

			get
			{
				return tableowner;
			}

		}

		public string TableName
		{
			set
			{
				tablename = value;
				overridentableidentifier = true;
			}

			get
			{
				return tablename;
			}

		}

		#endregion
		#region constructor
		public TbleventlogAggregate()
		{
			initialise();
		}

		#endregion

		#region public members
		/// <summary>
		/// returns true if Table exists in database
		/// </summary>
		public bool DoesTableExist()
		{
			return DoesTableExist(tablename);
		}

		public void BulkInsert(Tbleventlog[] dta)
		{
			bulk_operation(dta, true);
		}

		public void BulkUpdate(Tbleventlog[] dta)
		{
			bulk_operation(dta, false);
		}

		private void bulk_operation(Tbleventlog[] dta, bool isinsert)
		{
			if (dta == null)
				return;

			if (dta.Length == 0)
				return;

			SqlParameter[,] prs = null;
			int rowcount = 0;
			foreach (Tbleventlog e in dta)
			{
				SqlParameter[] ret = isinsert ? e.GetInsertValues() : e.GetUpdateValues();
				if (rowcount == 0)
					prs = new SqlParameter[dta.Length, ret.Length];
				for (int i = 0; i < ret.Length; i++)
					prs[rowcount, i] = ret[i];
				rowcount++;
				if (rowcount == dta.Length)
					if (isinsert)
						e.BulkInsert(prs);
					else
						e.BulkUpdate(prs);
			}
		}

		/// <summary>
		/// returns count of rows in Table
		/// </summary>
		public int Count()
		{
			if (!DoesTableExist())
				throw new Exception("Table " + tableowner + tablename + " Does Not Exist");

			StringBuilder sbsql = new StringBuilder();
			sbsql.Append("SELECT ");
			sbsql.Append("COUNT(1) ");
			sbsql.Append("FROM ");
			sbsql.Append(tableowner + tablename + " ");
			/* sbsql.Append("WHERE ");
			sbsql.Append("");
			sbsql.Append(" AND ");
			sbsql.Append(" ORDER BY ");
			*/

			return CoreDb.DbToInt(SqlQuickValue(sbsql.ToString()));
		}

		public Tbleventlog[] GetSingular(
		 int id
		)
		{
			StringBuilder sbsql = new StringBuilder();
			sbsql.Append("WHERE ");
			sbsql.Append("runsql.[ID] = " + (int)(id) + " ");

			/*
			sbsql.Append(" AND ");
			sbsql.Append(" runsql.[field]='"+CoreDb.SqlLiteral(field)+"' ");
			sbsql.Append(" AND ");
			sbsql.Append(" runsql.[field]="+field+" ");
			sbsql.Append("");
			sbsql.Append("ORDER BY ");
			*/
			return runsql(sbsql.ToString());
			// return runsql(sbsql.ToString(),1); // restrict to just get a single row back
		}

		public Tbleventlog GetSingle(
		 int id
		)
		{
			StringBuilder sbsql = new StringBuilder();
			sbsql.Append("WHERE ");
			sbsql.Append("runsql.[ID] = " + (int)(id) + " ");

			/*
			sbsql.Append(" AND ");
			sbsql.Append(" runsql.[field]='"+CoreDb.SqlLiteral(field)+"' ");
			sbsql.Append(" AND ");
			sbsql.Append(" runsql.[field]="+field+" ");
			sbsql.Append("");
			sbsql.Append("ORDER BY ");
			*/
			Tbleventlog[] temp_Tbleventlog = runsql(sbsql.ToString(), 1); // restrict to just get a single row back
			if (temp_Tbleventlog.Length == 0) return null;
			return temp_Tbleventlog[0];
		}

		public Tbleventlog[] GetAll()
		{
			StringBuilder sbsql = new StringBuilder();
			// sbsql.Append("WHERE ");
			// sbsql.Append(" runsql.[field]='"+CoreDb.SqlLiteral(field)+"' ");
			/*
			sbsql.Append(" AND ");
			sbsql.Append(" runsql.[field]='"+CoreDb.SqlLiteral(field)+"' ");
			sbsql.Append("");
			sbsql.Append("ORDER BY ");
			*/

			return runsql(sbsql.ToString());
		}
		public void DeleteSingular(
		 int id
		)
		{
			StringBuilder sbsql = new StringBuilder();
			sbsql.Append("DELETE FROM ");
			sbsql.Append(tableowner + tablename + " ");
			sbsql.Append("WHERE ");
			sbsql.Append("[ID] = " + (int)(id) + " ");

			/*
			sbsql.Append(" AND ");
			sbsql.Append(" [field]='"+CoreDb.SqlLiteral(field)+"' ");
			sbsql.Append(" AND ");
			sbsql.Append(" [field]="+field+" ");
			sbsql.Append("");
			*/
			SqlExecute(sbsql.ToString());
		}

		#endregion

		#region private members
		private void initialise()
		{
			// Cn = new SqlConnection(Core.AppSetting("ConnectionString Override"));
			if (tableowner.Length > 0) tableowner = "[" + tableowner + "].";
		}

		/// <summary>
		/// executes sql to build up an array of Tbleventlog
		/// </summary>
		private Tbleventlog[] runsql(string strsql, int rowcount)
		{
			return runsql(strsql, null, rowcount);
		}

		/// <summary>
		/// executes sql to build up an array of Tbleventlog
		/// </summary>
		private Tbleventlog[] runsql(string strsql)
		{
			return runsql(strsql, null, -1);
		}

		/// <summary>
		/// executes sql to build up an array of Tbleventlog
		/// </summary>
		private Tbleventlog[] runsql(string strsql, SqlParameter[] prms, int rowcount)
		{
			if (!DoesTableExist())
				throw new Exception("Table " + tableowner + tablename + " Does Not Exist");

			SqlDataReader result_set = null;
			ArrayList res = new ArrayList();
			Tbleventlog tempTbleventlog = null;

			StringBuilder sbsql = new StringBuilder();
			if (!strsql.ToUpper().StartsWith("SELECT")) // determine if we have passed in the select part of the query
			{
				sbsql.Append("SELECT ");

				if (rowcount > -1) // check to see if we want to row restrict our results
					sbsql.Append("TOP " + rowcount + " ");

				sbsql.Append("runsql.[ApplicationName], runsql.[Description], runsql.[EntryType], runsql.[ID], runsql.[InsertDateTime], runsql.[MethodName] ");
				sbsql.Append("FROM ");
				sbsql.Append(tableowner + tablename + " runsql ");
			}
			sbsql.Append(strsql);

			result_set = Sql(sbsql.ToString(), prms);
			if (result_set != null)
			{
				while (result_set.Read())
				{
					string applicationname = CoreDb.DbToString(result_set["ApplicationName"]); // Field = ApplicationName
					string description = CoreDb.DbToString(result_set["Description"]); // Field = Description
					string entrytype = CoreDb.DbToString(result_set["EntryType"]); // Field = EntryType
					int id = CoreDb.DbToInt(result_set["ID"]); // Field = ID
					DateTime insertdatetime = CoreDb.DbToDateTime(result_set["InsertDateTime"]); // Field = InsertDateTime
					string methodname = CoreDb.DbToString(result_set["MethodName"]); // Field = MethodName
					tempTbleventlog = new Tbleventlog(applicationname, description, entrytype, id, insertdatetime, methodname);
					if (overridentableidentifier)
					{
						tempTbleventlog.TableOwner = tableowner;
						tempTbleventlog.TableName = tablename;
					}

					res.Add(tempTbleventlog);
					tempTbleventlog = null;
				}
				result_set.Close();
				result_set.Dispose();
			}
			Close(); // ensure our database connection is completly closed
			return (Tbleventlog[])res.ToArray(typeof(Tbleventlog));
		}
		#endregion
	}
}
