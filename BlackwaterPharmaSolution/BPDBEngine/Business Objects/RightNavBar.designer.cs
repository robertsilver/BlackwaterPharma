/*
-- Anglia Business Solutions http://www.angliabs.com --
Data Maker Created Class
Created - 05 April 2010
-- Table tblRightNavBar --
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
	public partial class Tblrightnavbar
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
	
	public partial class TblrightnavbarAggregate
	{
	}
	
}

*/

namespace BPDBEngine
{
	public partial class Tblrightnavbar : CoreDb, IDisposable
	{
		#region private variables
		private string tableowner = Core.AppSetting("TableOwner"); // dbo - at time of build
		private string tablename = "tblRightNavBar";

		private string alttext = string.Empty; // Maps To Database Field - [AltText]
		private string bodytext = string.Empty; // Maps To Database Field - [BodyText]
		private string categoryids = string.Empty; // Maps To Database Field - [CategoryIDs]
		private string headertext = string.Empty; // Maps To Database Field - [HeaderText]
		private int height = 0; // Maps To Database Field - [Height]
		private int id = 0; // Maps To Database Field - [ID]
		private string image = string.Empty; // Maps To Database Field - [Image]
		private string name = string.Empty; // Maps To Database Field - [Name]
		private string showonhomepage = string.Empty; // Maps To Database Field - [ShowOnHomepage]
		private string url = string.Empty; // Maps To Database Field - [URL]
		private int weight = 0; // Maps To Database Field - [Weight]
		private int width = 0; // Maps To Database Field - [Width]

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
		/// Maps To Database Field - [AltText] - varchar(100)
		/// </summary>
		public string Alttext
		{
			get
			{
				return alttext;
			}
			set
			{
				alttext = value;
				// automatic truncation of variables
				if (alttext.Length > 100)
				{
					// throw new Exception("alttext is over maximum character length of 100 characters.");
					alttext = alttext.Substring(0, 100);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [BodyText] - varchar(2000)
		/// </summary>
		public string Bodytext
		{
			get
			{
				return bodytext;
			}
			set
			{
				bodytext = value;
				// automatic truncation of variables
				if (bodytext.Length > 2000)
				{
					// throw new Exception("bodytext is over maximum character length of 2000 characters.");
					bodytext = bodytext.Substring(0, 2000);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [CategoryIDs] - varchar(50)
		/// </summary>
		public string Categoryids
		{
			get
			{
				return categoryids;
			}
			set
			{
				categoryids = value;
				// automatic truncation of variables
				if (categoryids.Length > 50)
				{
					// throw new Exception("categoryids is over maximum character length of 50 characters.");
					categoryids = categoryids.Substring(0, 50);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [HeaderText] - varchar(500)
		/// </summary>
		public string Headertext
		{
			get
			{
				return headertext;
			}
			set
			{
				headertext = value;
				// automatic truncation of variables
				if (headertext.Length > 500)
				{
					// throw new Exception("headertext is over maximum character length of 500 characters.");
					headertext = headertext.Substring(0, 500);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [Height] - int(10)
		/// </summary>
		public int Height
		{
			get
			{
				return height;
			}
			set
			{
				height = value;
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
		/// Maps To Database Field - [Image] - varchar(50)
		/// </summary>
		public string Image
		{
			get
			{
				return image;
			}
			set
			{
				image = value;
				// automatic truncation of variables
				if (image.Length > 50)
				{
					// throw new Exception("image is over maximum character length of 50 characters.");
					image = image.Substring(0, 50);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [Name] - varchar(25)
		/// </summary>
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
				// automatic truncation of variables
				if (name.Length > 25)
				{
					// throw new Exception("name is over maximum character length of 25 characters.");
					name = name.Substring(0, 25);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [ShowOnHomepage] - varchar(2)
		/// </summary>
		public string Showonhomepage
		{
			get
			{
				return showonhomepage;
			}
			set
			{
				showonhomepage = value;
				// automatic truncation of variables
				if (showonhomepage.Length > 2)
				{
					// throw new Exception("showonhomepage is over maximum character length of 2 characters.");
					showonhomepage = showonhomepage.Substring(0, 2);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [URL] - varchar(50)
		/// </summary>
		public string Url
		{
			get
			{
				return url;
			}
			set
			{
				url = value;
				// automatic truncation of variables
				if (url.Length > 50)
				{
					// throw new Exception("url is over maximum character length of 50 characters.");
					url = url.Substring(0, 50);
				}
			}
		}

		/// <summary>
		/// Maps To Database Field - [Weight] - int(10)
		/// </summary>
		public int Weight
		{
			get
			{
				return weight;
			}
			set
			{
				weight = value;
			}
		}

		/// <summary>
		/// Maps To Database Field - [Width] - int(10)
		/// </summary>
		public int Width
		{
			get
			{
				return width;
			}
			set
			{
				width = value;
			}
		}
		#endregion

		#region constructor
		public Tblrightnavbar()
		{
			initialise();
		}

		public Tblrightnavbar(
			 string alttext
			, string bodytext
			, string categoryids
			, string headertext
			, int height
			, int id
			, string image
			, string name
			, string showonhomepage
			, string url
			, int weight
			, int width
		)
		{
			initialise();
			this.alttext = alttext;
			this.bodytext = bodytext;
			this.categoryids = categoryids;
			this.headertext = headertext;
			this.height = height;
			this.id = id;
			this.image = image;
			this.name = name;
			this.showonhomepage = showonhomepage;
			this.url = url;
			this.weight = weight;
			this.width = width;
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

		public void Update()
		{
			// Determine if keys are valid
			if (!keyintegrity)
				throw new Exception("tblRightNavBar key integrity error, a previous insert operation occured without the class being updated with all key field values.");

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
				// Warning No Identity Set
				BulkInsert(ret);

				// TODO - write code to refresh key information
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
			sbsql.Append(" [AltText] ");
			sbsql.Append(",[BodyText] ");
			sbsql.Append(",[CategoryIDs] ");
			sbsql.Append(",[HeaderText] ");
			sbsql.Append(",[Height] ");
			sbsql.Append(",[ID] ");
			sbsql.Append(",[Image] ");
			sbsql.Append(",[Name] ");
			sbsql.Append(",[ShowOnHomepage] ");
			sbsql.Append(",[URL] ");
			sbsql.Append(",[Weight] ");
			sbsql.Append(",[Width] ");
			sbsql.Append(") ");
			sbsql.Append("VALUES ");
			sbsql.Append("(");
			sbsql.Append(" @alttext ");  // Maps To Database Field - [AltText]
			sbsql.Append(",@bodytext ");  // Maps To Database Field - [BodyText]
			sbsql.Append(",@categoryids ");  // Maps To Database Field - [CategoryIDs]
			sbsql.Append(",@headertext ");  // Maps To Database Field - [HeaderText]
			sbsql.Append(",@height ");  // Maps To Database Field - [Height]
			sbsql.Append(",@id ");  // Maps To Database Field - [ID]
			sbsql.Append(",@image ");  // Maps To Database Field - [Image]
			sbsql.Append(",@name ");  // Maps To Database Field - [Name]
			sbsql.Append(",@showonhomepage ");  // Maps To Database Field - [ShowOnHomepage]
			sbsql.Append(",@url ");  // Maps To Database Field - [URL]
			sbsql.Append(",@weight ");  // Maps To Database Field - [Weight]
			sbsql.Append(",@width ");  // Maps To Database Field - [Width]
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
			sbsql.Append(" [AltText] = @alttext ");
			sbsql.Append(",[BodyText] = @bodytext ");
			sbsql.Append(",[CategoryIDs] = @categoryids ");
			sbsql.Append(",[HeaderText] = @headertext ");
			sbsql.Append(",[Height] = @height ");
			sbsql.Append(",[Image] = @image ");
			sbsql.Append(",[Name] = @name ");
			sbsql.Append(",[ShowOnHomepage] = @showonhomepage ");
			sbsql.Append(",[URL] = @url ");
			sbsql.Append(",[Weight] = @weight ");
			sbsql.Append(",[Width] = @width ");
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
			tempparam = new SqlParameter();  // Maps To - [AltText]
			tempparam.ParameterName = "@alttext";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 100;
			tempparam.Value = alttext;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [BodyText]
			tempparam.ParameterName = "@bodytext";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 2000;
			tempparam.Value = bodytext;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [CategoryIDs]
			tempparam.ParameterName = "@categoryids";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = categoryids;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [HeaderText]
			tempparam.ParameterName = "@headertext";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 500;
			tempparam.Value = headertext;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [Height]
			tempparam.ParameterName = "@height";
			tempparam.SqlDbType = System.Data.SqlDbType.Int;
			tempparam.Precision = 10;
			tempparam.Value = (int)(height);
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [ID]
			tempparam.ParameterName = "@id";
			tempparam.SqlDbType = System.Data.SqlDbType.Int;
			tempparam.Precision = 10;
			tempparam.Value = (int)(id);
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [Image]
			tempparam.ParameterName = "@image";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = image;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [Name]
			tempparam.ParameterName = "@name";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 25;
			tempparam.Value = name;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [ShowOnHomepage]
			tempparam.ParameterName = "@showonhomepage";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 2;
			tempparam.Value = showonhomepage;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [URL]
			tempparam.ParameterName = "@url";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = url;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [Weight]
			tempparam.ParameterName = "@weight";
			tempparam.SqlDbType = System.Data.SqlDbType.Int;
			tempparam.Precision = 10;
			tempparam.Value = (int)(weight);
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [Width]
			tempparam.ParameterName = "@width";
			tempparam.SqlDbType = System.Data.SqlDbType.Int;
			tempparam.Precision = 10;
			tempparam.Value = (int)(width);
			paramcollection.Add(tempparam);

			return (SqlParameter[])paramcollection.ToArray(typeof(SqlParameter));
		}

		public SqlParameter[] GetUpdateValues()
		{
			ArrayList paramcollection = new ArrayList();
			SqlParameter tempparam = null;

			// build values
			tempparam = new SqlParameter();  // Maps To - [AltText]
			tempparam.ParameterName = "@alttext";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 100;
			tempparam.Value = alttext;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [BodyText]
			tempparam.ParameterName = "@bodytext";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 2000;
			tempparam.Value = bodytext;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [CategoryIDs]
			tempparam.ParameterName = "@categoryids";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = categoryids;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [HeaderText]
			tempparam.ParameterName = "@headertext";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 500;
			tempparam.Value = headertext;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [Height]
			tempparam.ParameterName = "@height";
			tempparam.SqlDbType = System.Data.SqlDbType.Int;
			tempparam.Precision = 10;
			tempparam.Value = (int)(height);
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [Image]
			tempparam.ParameterName = "@image";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = image;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [Name]
			tempparam.ParameterName = "@name";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 25;
			tempparam.Value = name;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [ShowOnHomepage]
			tempparam.ParameterName = "@showonhomepage";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 2;
			tempparam.Value = showonhomepage;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [URL]
			tempparam.ParameterName = "@url";
			tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
			tempparam.Size = 50;
			tempparam.Value = url;
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [Weight]
			tempparam.ParameterName = "@weight";
			tempparam.SqlDbType = System.Data.SqlDbType.Int;
			tempparam.Precision = 10;
			tempparam.Value = (int)(weight);
			paramcollection.Add(tempparam);

			tempparam = new SqlParameter();  // Maps To - [Width]
			tempparam.ParameterName = "@width";
			tempparam.SqlDbType = System.Data.SqlDbType.Int;
			tempparam.Precision = 10;
			tempparam.Value = (int)(width);
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

	public partial class TblrightnavbarAggregate : CoreDb
	{
		#region private variables

		private string tableowner = Core.AppSetting("TableOwner"); // dbo - at time of build
		private string tablename = "tblRightNavBar";
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
		public TblrightnavbarAggregate()
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

		public void BulkInsert(Tblrightnavbar[] dta)
		{
			bulk_operation(dta, true);
		}

		public void BulkUpdate(Tblrightnavbar[] dta)
		{
			bulk_operation(dta, false);
		}

		private void bulk_operation(Tblrightnavbar[] dta, bool isinsert)
		{
			if (dta == null)
				return;

			if (dta.Length == 0)
				return;

			SqlParameter[,] prs = null;
			int rowcount = 0;
			foreach (Tblrightnavbar e in dta)
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

		public Tblrightnavbar[] GetSingular(
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

		public Tblrightnavbar GetSingle(
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
			Tblrightnavbar[] temp_Tblrightnavbar = runsql(sbsql.ToString(), 1); // restrict to just get a single row back
			if (temp_Tblrightnavbar.Length == 0) return null;
			return temp_Tblrightnavbar[0];
		}

		public Tblrightnavbar[] GetAll()
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
		#endregion

		#region private members
		private void initialise()
		{
			// Cn = new SqlConnection(Core.AppSetting("ConnectionString Override"));
			if (tableowner.Length > 0) tableowner = "[" + tableowner + "].";
		}

		/// <summary>
		/// executes sql to build up an array of Tblrightnavbar
		/// </summary>
		private Tblrightnavbar[] runsql(string strsql, int rowcount)
		{
			return runsql(strsql, null, rowcount);
		}

		/// <summary>
		/// executes sql to build up an array of Tblrightnavbar
		/// </summary>
		private Tblrightnavbar[] runsql(string strsql)
		{
			return runsql(strsql, null, -1);
		}

		/// <summary>
		/// executes sql to build up an array of Tblrightnavbar
		/// </summary>
		private Tblrightnavbar[] runsql(string strsql, SqlParameter[] prms, int rowcount)
		{
			if (!DoesTableExist())
				throw new Exception("Table " + tableowner + tablename + " Does Not Exist");

			SqlDataReader result_set = null;
			ArrayList res = new ArrayList();
			Tblrightnavbar tempTblrightnavbar = null;

			StringBuilder sbsql = new StringBuilder();
			if (!strsql.ToUpper().StartsWith("SELECT")) // determine if we have passed in the select part of the query
			{
				sbsql.Append("SELECT ");

				if (rowcount > -1) // check to see if we want to row restrict our results
					sbsql.Append("TOP " + rowcount + " ");

				sbsql.Append("runsql.[AltText], runsql.[BodyText], runsql.[CategoryIDs], runsql.[HeaderText], runsql.[Height], runsql.[ID], runsql.[Image], runsql.[Name], runsql.[ShowOnHomepage], runsql.[URL], runsql.[Weight], runsql.[Width] ");
				sbsql.Append("FROM ");
				sbsql.Append(tableowner + tablename + " runsql ");
			}
			sbsql.Append(strsql);

			result_set = Sql(sbsql.ToString(), prms);
			if (result_set != null)
			{
				while (result_set.Read())
				{
					string alttext = CoreDb.DbToString(result_set["AltText"]); // Field = AltText
					string bodytext = CoreDb.DbToString(result_set["BodyText"]); // Field = BodyText
					string categoryids = CoreDb.DbToString(result_set["CategoryIDs"]); // Field = CategoryIDs
					string headertext = CoreDb.DbToString(result_set["HeaderText"]); // Field = HeaderText
					int height = CoreDb.DbToInt(result_set["Height"]); // Field = Height
					int id = CoreDb.DbToInt(result_set["ID"]); // Field = ID
					string image = CoreDb.DbToString(result_set["Image"]); // Field = Image
					string name = CoreDb.DbToString(result_set["Name"]); // Field = Name
					string showonhomepage = CoreDb.DbToString(result_set["ShowOnHomepage"]); // Field = ShowOnHomepage
					string url = CoreDb.DbToString(result_set["URL"]); // Field = URL
					int weight = CoreDb.DbToInt(result_set["Weight"]); // Field = Weight
					int width = CoreDb.DbToInt(result_set["Width"]); // Field = Width
					tempTblrightnavbar = new Tblrightnavbar(alttext, bodytext, categoryids, headertext, height, id, image, name, showonhomepage, url, weight, width);
					if (overridentableidentifier)
					{
						tempTblrightnavbar.TableOwner = tableowner;
						tempTblrightnavbar.TableName = tablename;
					}

					res.Add(tempTblrightnavbar);
					tempTblrightnavbar = null;
				}
				result_set.Close();
				result_set.Dispose();
			}
			Close(); // ensure our database connection is completly closed
			return (Tblrightnavbar[])res.ToArray(typeof(Tblrightnavbar));
		}
		#endregion
	}
}
