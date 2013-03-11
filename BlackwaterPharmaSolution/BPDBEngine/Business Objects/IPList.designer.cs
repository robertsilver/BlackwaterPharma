/*
-- Anglia Business Solutions http://www.angliabs.com --
Data Maker Created Class
Created - 26 April 2010
-- Table tblIPList --
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
	public partial class Tbliplist
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
	
	public partial class TbliplistAggregate
	{
	}
	
}

*/

namespace BPDBEngine
{
	public partial class Tbliplist : CoreDb, IDisposable
	{
		#region private variables
		private string tableowner = Core.AppSetting("TableOwner"); // dbo - at time of build
		private string tablename = "tblIPList";

		private string forwardaddr = string.Empty; // Maps To Database Field - [ForwardAddr]
		private string httpuseragent = string.Empty; // Maps To Database Field - [HTTPUserAgent]
		private int id = 0; // Maps To Database Field - [ID]
		private DateTime insertdatetime = DateTime.MinValue; // Maps To Database Field - [InsertDateTime]
		private string pagename = string.Empty; // Maps To Database Field - [PageName]
		private string remoteaddress = string.Empty; // Maps To Database Field - [RemoteAddress]
		private string remotehost = string.Empty; // Maps To Database Field - [RemoteHost]
		private string requestmethod = string.Empty; // Maps To Database Field - [RequestMethod]
		private string servername = string.Empty; // Maps To Database Field - [ServerName]
		private string serverport = string.Empty; // Maps To Database Field - [ServerPort]
		private string serversoftware = string.Empty; // Maps To Database Field - [ServerSoftware]

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
		/// Maps To Database Field - [ForwardAddr] - varchar(50)
		/// </summary>
		public string Forwardaddr
		{
			get
			{
				return forwardaddr;
			}
			set
			{
				forwardaddr = value;
				// automatic truncation of variables
				if (forwardaddr.Length > 50)
				{
					// throw new Exception("forwardaddr is over maximum character length of 50 characters.");
					forwardaddr = forwardaddr.Substring(0, 50);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [HTTPUserAgent] - varchar(500)
		/// </summary>
		public string Httpuseragent
		{
			get
			{
				return httpuseragent;
			}
			set
			{
				httpuseragent = value;
				// automatic truncation of variables
				if (httpuseragent.Length > 500)
				{
					// throw new Exception("httpuseragent is over maximum character length of 500 characters.");
					httpuseragent = httpuseragent.Substring(0, 500);
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
		/// Maps To Database Field - [PageName] - varchar(50)
		/// </summary>
		public string Pagename
		{
			get
			{
				return pagename;
			}
			set
			{
				pagename = value;
				// automatic truncation of variables
				if (pagename.Length > 50)
				{
					// throw new Exception("pagename is over maximum character length of 50 characters.");
					pagename = pagename.Substring(0, 50);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [RemoteAddress] - varchar(50)
		/// </summary>
		public string Remoteaddress
		{
			get
			{
				return remoteaddress;
			}
			set
			{
				remoteaddress = value;
				// automatic truncation of variables
				if (remoteaddress.Length > 50)
				{
					// throw new Exception("remoteaddress is over maximum character length of 50 characters.");
					remoteaddress = remoteaddress.Substring(0, 50);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [RemoteHost] - varchar(50)
		/// </summary>
		public string Remotehost
		{
			get
			{
				return remotehost;
			}
			set
			{
				remotehost = value;
				// automatic truncation of variables
				if (remotehost.Length > 50)
				{
					// throw new Exception("remotehost is over maximum character length of 50 characters.");
					remotehost = remotehost.Substring(0, 50);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [RequestMethod] - varchar(50)
		/// </summary>
		public string Requestmethod
		{
			get
			{
				return requestmethod;
			}
			set
			{
				requestmethod = value;
				// automatic truncation of variables
				if (requestmethod.Length > 50)
				{
					// throw new Exception("requestmethod is over maximum character length of 50 characters.");
					requestmethod = requestmethod.Substring(0, 50);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [ServerName] - varchar(50)
		/// </summary>
		public string Servername
		{
			get
			{
				return servername;
			}
			set
			{
				servername = value;
				// automatic truncation of variables
				if (servername.Length > 50)
				{
					// throw new Exception("servername is over maximum character length of 50 characters.");
					servername = servername.Substring(0, 50);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [ServerPort] - varchar(50)
		/// </summary>
		public string Serverport
		{
			get
			{
				return serverport;
			}
			set
			{
				serverport = value;
				// automatic truncation of variables
				if (serverport.Length > 50)
				{
					// throw new Exception("serverport is over maximum character length of 50 characters.");
					serverport = serverport.Substring(0, 50);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [ServerSoftware] - varchar(50)
		/// </summary>
		public string Serversoftware
		{
			get
			{
				return serversoftware;
			}
			set
			{
				serversoftware = value;
				// automatic truncation of variables
				if (serversoftware.Length > 50)
				{
					// throw new Exception("serversoftware is over maximum character length of 50 characters.");
					serversoftware = serversoftware.Substring(0, 50);
				}
			}
		}
		#endregion

		#region constructor
		public Tbliplist()
		{
			initialise();
		}

		public Tbliplist(
			 string forwardaddr
			, string httpuseragent
			, int id
			, DateTime insertdatetime
			, string pagename
			, string remoteaddress
			, string remotehost
			, string requestmethod
			, string servername
			, string serverport
			, string serversoftware
		)
		{
			initialise();
			this.forwardaddr = forwardaddr;
			this.httpuseragent = httpuseragent;
			this.id = id;
			this.insertdatetime = insertdatetime;
			this.pagename = pagename;
			this.remoteaddress = remoteaddress;
			this.remotehost = remotehost;
			this.requestmethod = requestmethod;
			this.servername = servername;
			this.serverport = serverport;
			this.serversoftware = serversoftware;
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
				throw new Exception("tblIPList key integrity error, a previous insert operation occured without the class being updated with all key field values.");

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
			sbsql.Append(" [ForwardAddr] ");
			sbsql.Append(",[HTTPUserAgent] ");
			sbsql.Append(",[InsertDateTime] ");
			sbsql.Append(",[PageName] ");
			sbsql.Append(",[RemoteAddress] ");
			sbsql.Append(",[RemoteHost] ");
			sbsql.Append(",[RequestMethod] ");
			sbsql.Append(",[ServerName] ");
			sbsql.Append(",[ServerPort] ");
			sbsql.Append(",[ServerSoftware] ");
			sbsql.Append(") ");
			sbsql.Append("VALUES ");
			sbsql.Append("(");
			sbsql.Append(" @forwardaddr ");  // Maps To Database Field - [ForwardAddr]
			sbsql.Append(",@httpuseragent ");  // Maps To Database Field - [HTTPUserAgent]
			sbsql.Append(",@insertdatetime ");  // Maps To Database Field - [InsertDateTime]
			sbsql.Append(",@pagename ");  // Maps To Database Field - [PageName]
			sbsql.Append(",@remoteaddress ");  // Maps To Database Field - [RemoteAddress]
			sbsql.Append(",@remotehost ");  // Maps To Database Field - [RemoteHost]
			sbsql.Append(",@requestmethod ");  // Maps To Database Field - [RequestMethod]
			sbsql.Append(",@servername ");  // Maps To Database Field - [ServerName]
			sbsql.Append(",@serverport ");  // Maps To Database Field - [ServerPort]
			sbsql.Append(",@serversoftware ");  // Maps To Database Field - [ServerSoftware]
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
			sbsql.Append(" [ForwardAddr] = @forwardaddr ");
			sbsql.Append(",[HTTPUserAgent] = @httpuseragent ");
			sbsql.Append(",[InsertDateTime] = @insertdatetime ");
			sbsql.Append(",[PageName] = @pagename ");
			sbsql.Append(",[RemoteAddress] = @remoteaddress ");
			sbsql.Append(",[RemoteHost] = @remotehost ");
			sbsql.Append(",[RequestMethod] = @requestmethod ");
			sbsql.Append(",[ServerName] = @servername ");
			sbsql.Append(",[ServerPort] = @serverport ");
			sbsql.Append(",[ServerSoftware] = @serversoftware ");
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
			tempparam = new SqlParameter();  // Maps To - [ForwardAddr]
			tempparam.ParameterName = "@forwardaddr";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = forwardaddr;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [HTTPUserAgent]
			tempparam.ParameterName = "@httpuseragent";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 500;
			tempparam.Value = httpuseragent;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [InsertDateTime]
			tempparam.ParameterName = "@insertdatetime";
			tempparam.SqlDbType = System.Data.SqlDbType.DateTime;
			tempparam.Value = insertdatetime;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [PageName]
			tempparam.ParameterName = "@pagename";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = pagename;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [RemoteAddress]
			tempparam.ParameterName = "@remoteaddress";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = remoteaddress;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [RemoteHost]
			tempparam.ParameterName = "@remotehost";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = remotehost;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [RequestMethod]
			tempparam.ParameterName = "@requestmethod";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = requestmethod;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [ServerName]
			tempparam.ParameterName = "@servername";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = servername;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [ServerPort]
			tempparam.ParameterName = "@serverport";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = serverport;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [ServerSoftware]
			tempparam.ParameterName = "@serversoftware";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = serversoftware;
			paramcollection.Add(tempparam);

			return (SqlParameter[])paramcollection.ToArray(typeof(SqlParameter));
		}

		public SqlParameter[] GetUpdateValues()
		{
			ArrayList paramcollection = new ArrayList();
			SqlParameter tempparam = null;

			// build values
			tempparam = new SqlParameter();  // Maps To - [ForwardAddr]
			tempparam.ParameterName = "@forwardaddr";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = forwardaddr;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [HTTPUserAgent]
			tempparam.ParameterName = "@httpuseragent";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 500;
			tempparam.Value = httpuseragent;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [InsertDateTime]
			tempparam.ParameterName = "@insertdatetime";
			tempparam.SqlDbType = System.Data.SqlDbType.DateTime;
			tempparam.Value = insertdatetime;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [PageName]
			tempparam.ParameterName = "@pagename";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = pagename;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [RemoteAddress]
			tempparam.ParameterName = "@remoteaddress";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = remoteaddress;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [RemoteHost]
			tempparam.ParameterName = "@remotehost";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = remotehost;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [RequestMethod]
			tempparam.ParameterName = "@requestmethod";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = requestmethod;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [ServerName]
			tempparam.ParameterName = "@servername";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = servername;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [ServerPort]
			tempparam.ParameterName = "@serverport";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = serverport;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [ServerSoftware]
			tempparam.ParameterName = "@serversoftware";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = serversoftware;
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

	public partial class TbliplistAggregate : CoreDb
	{
		#region private variables

		private string tableowner = Core.AppSetting("TableOwner"); // dbo - at time of build
		private string tablename = "tblIPList";
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
		public TbliplistAggregate()
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

		public void BulkInsert(Tbliplist[] dta)
		{
			bulk_operation(dta, true);
		}

		public void BulkUpdate(Tbliplist[] dta)
		{
			bulk_operation(dta, false);
		}

		private void bulk_operation(Tbliplist[] dta, bool isinsert)
		{
			if (dta == null)
				return;

			if (dta.Length == 0)
				return;

			SqlParameter[,] prs = null;
			int rowcount = 0;
			foreach (Tbliplist e in dta)
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

		public Tbliplist[] GetSingular(
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

		public Tbliplist GetSingle(
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
			Tbliplist[] temp_Tbliplist = runsql(sbsql.ToString(), 1); // restrict to just get a single row back
			if (temp_Tbliplist.Length == 0) return null;
			return temp_Tbliplist[0];
		}

		public Tbliplist[] GetAll()
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
		/// executes sql to build up an array of Tbliplist
		/// </summary>
		private Tbliplist[] runsql(string strsql, int rowcount)
		{
			return runsql(strsql, null, rowcount);
		}

		/// <summary>
		/// executes sql to build up an array of Tbliplist
		/// </summary>
		private Tbliplist[] runsql(string strsql)
		{
			return runsql(strsql, null, -1);
		}

		/// <summary>
		/// executes sql to build up an array of Tbliplist
		/// </summary>
		private Tbliplist[] runsql(string strsql, SqlParameter[] prms, int rowcount)
		{
			if (!DoesTableExist())
				throw new Exception("Table " + tableowner + tablename + " Does Not Exist");

			SqlDataReader result_set = null;
			ArrayList res = new ArrayList();
			Tbliplist tempTbliplist = null;

			StringBuilder sbsql = new StringBuilder();
			if (!strsql.ToUpper().StartsWith("SELECT")) // determine if we have passed in the select part of the query
			{
				sbsql.Append("SELECT ");

				if (rowcount > -1) // check to see if we want to row restrict our results
					sbsql.Append("TOP " + rowcount + " ");

				sbsql.Append("runsql.[ForwardAddr], runsql.[HTTPUserAgent], runsql.[ID], runsql.[InsertDateTime], runsql.[PageName], runsql.[RemoteAddress], runsql.[RemoteHost], runsql.[RequestMethod], runsql.[ServerName], runsql.[ServerPort], runsql.[ServerSoftware] ");
				sbsql.Append("FROM ");
				sbsql.Append(tableowner + tablename + " runsql ");
			}
			sbsql.Append(strsql);

			result_set = Sql(sbsql.ToString(), prms);
			if (result_set != null)
			{
				while (result_set.Read())
				{
					string forwardaddr = CoreDb.DbToString(result_set["ForwardAddr"]); // Field = ForwardAddr
					string httpuseragent = CoreDb.DbToString(result_set["HTTPUserAgent"]); // Field = HTTPUserAgent
					int id = CoreDb.DbToInt(result_set["ID"]); // Field = ID
					DateTime insertdatetime = CoreDb.DbToDateTime(result_set["InsertDateTime"]); // Field = InsertDateTime
					string pagename = CoreDb.DbToString(result_set["PageName"]); // Field = PageName
					string remoteaddress = CoreDb.DbToString(result_set["RemoteAddress"]); // Field = RemoteAddress
					string remotehost = CoreDb.DbToString(result_set["RemoteHost"]); // Field = RemoteHost
					string requestmethod = CoreDb.DbToString(result_set["RequestMethod"]); // Field = RequestMethod
					string servername = CoreDb.DbToString(result_set["ServerName"]); // Field = ServerName
					string serverport = CoreDb.DbToString(result_set["ServerPort"]); // Field = ServerPort
					string serversoftware = CoreDb.DbToString(result_set["ServerSoftware"]); // Field = ServerSoftware
					tempTbliplist = new Tbliplist(forwardaddr, httpuseragent, id, insertdatetime, pagename, remoteaddress, remotehost, requestmethod, servername, serverport, serversoftware);
					if (overridentableidentifier)
					{
						tempTbliplist.TableOwner = tableowner;
						tempTbliplist.TableName = tablename;
					}

					res.Add(tempTbliplist);
					tempTbliplist = null;
				}
				result_set.Close();
				result_set.Dispose();
			}
			Close(); // ensure our database connection is completly closed
			return (Tbliplist[])res.ToArray(typeof(Tbliplist));
		}
		#endregion
	}
}
