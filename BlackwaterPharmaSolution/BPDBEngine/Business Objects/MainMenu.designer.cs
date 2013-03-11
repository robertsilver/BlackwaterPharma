/*
-- Anglia Business Solutions http://www.angliabs.com --
Data Maker Created Class
Created - 18 April 2010
-- Table tblMainMenu --
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
	public partial class Tblmainmenu
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
			// Item[] ouritems = iagg.GetSingular(this.Menuid);
			// iagg.Dispose();
			// if (ouritems.Length==0) return;
			// ouritem=ouritems[0];
		// }
	}
	
	public partial class TblmainmenuAggregate
	{
	}
	
}

*/

namespace BPDBEngine
{
	public partial class Tblmainmenu : IDisposable
	{
		#region private variables
		private string tableowner = Core.AppSetting("TableOwner"); // dbo - at time of build
		private string tablename = "tblMainMenu";

		private int btwobcustomer = 0; // Maps To Database Field - [B2BCustomer]
		private string description = string.Empty; // Maps To Database Field - [Description]
		private int display = 0; // Maps To Database Field - [Display]
		private int distributor = 0; // Maps To Database Field - [Distributor]
		private int everyone = 0; // Maps To Database Field - [Everyone]
		private int menuid = 0; // Maps To Database Field - [MenuID]
		private int parentid = 0; // Maps To Database Field - [ParentID]
		private int specialaccount = 0; // Maps To Database Field - [SpecialAccount]
		private int superuser = 0; // Maps To Database Field - [SuperUser]
		private string text = string.Empty; // Maps To Database Field - [Text]
		private string url = string.Empty; // Maps To Database Field - [URL]
		private int vendor = 0; // Maps To Database Field - [Vendor]
		private string whocanview = string.Empty; // Maps To Database Field - [WhoCanView]
		private bool disposed = false;
		#endregion

		#region public properties
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
		/// Maps To Database Field - [B2BCustomer] - tinyint(3)
		/// </summary>
		public int Btwobcustomer
		{
			get
			{
				return btwobcustomer;
			}
		}

		/// <summary>
		/// Maps To Database Field - [Description] - varchar(100)
		/// </summary>
		public string Description
		{
			get
			{
				return description;
			}
		}

		/// <summary>
		/// Maps To Database Field - [Display] - tinyint(3)
		/// </summary>
		public int Display
		{
			get
			{
				return display;
			}
		}

		/// <summary>
		/// Maps To Database Field - [Distributor] - tinyint(3)
		/// </summary>
		public int Distributor
		{
			get
			{
				return distributor;
			}
		}

		/// <summary>
		/// Maps To Database Field - [Everyone] - tinyint(3)
		/// </summary>
		public int Everyone
		{
			get
			{
				return everyone;
			}
		}

		/// <summary>
		/// Maps To Database Field - [MenuID] - int(10)
		/// </summary>
		public int Menuid
		{
			get
			{
				return menuid;
			}
		}

		/// <summary>
		/// Maps To Database Field - [ParentID] - int(10)
		/// </summary>
		public int Parentid
		{
			get
			{
				return parentid;
			}
		}

		/// <summary>
		/// Maps To Database Field - [SpecialAccount] - tinyint(3)
		/// </summary>
		public int Specialaccount
		{
			get
			{
				return specialaccount;
			}
		}

		/// <summary>
		/// Maps To Database Field - [SuperUser] - tinyint(3)
		/// </summary>
		public int Superuser
		{
			get
			{
				return superuser;
			}
		}

		/// <summary>
		/// Maps To Database Field - [Text] - varchar(100)
		/// </summary>
		public string Text
		{
			get
			{
				return text;
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
		}

		/// <summary>
		/// Maps To Database Field - [Vendor] - tinyint(3)
		/// </summary>
		public int Vendor
		{
			get
			{
				return vendor;
			}
		}

		/// <summary>
		/// Maps To Database Field - [WhoCanView] - varchar(100)
		/// </summary>
		public string Whocanview
		{
			get
			{
				return whocanview;
			}
		}
		#endregion

		#region constructor
		public Tblmainmenu(
			 int btwobcustomer
			, string description
			, int display
			, int distributor
			, int everyone
			, int menuid
			, int parentid
			, int specialaccount
			, int superuser
			, string text
			, string url
			, int vendor
			, string whocanview
		)
		{
			this.btwobcustomer = btwobcustomer;
			this.description = description;
			this.display = display;
			this.distributor = distributor;
			this.everyone = everyone;
			this.menuid = menuid;
			this.parentid = parentid;
			this.specialaccount = specialaccount;
			this.superuser = superuser;
			this.text = text;
			this.url = url;
			this.vendor = vendor;
			this.whocanview = whocanview;
		}
		#endregion

		#region public members
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
			}
			disposed = true;
		}

		#endregion

		#region private members
		#endregion
	}

	public partial class TblmainmenuAggregate : CoreDb
	{
		#region private variables

		private string tableowner = Core.AppSetting("TableOwner"); // dbo - at time of build
		private string tablename = "tblMainMenu";
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
		public TblmainmenuAggregate()
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

		public Tblmainmenu[] GetSingular(
		 int menuid
		)
		{
			StringBuilder sbsql = new StringBuilder();
			sbsql.Append("WHERE ");
			sbsql.Append("runsql.[MenuID] = " + (int)(menuid) + " ");

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

		public Tblmainmenu GetSingle(
		 int menuid
		)
		{
			StringBuilder sbsql = new StringBuilder();
			sbsql.Append("WHERE ");
			sbsql.Append("runsql.[MenuID] = " + (int)(menuid) + " ");

			/*
			sbsql.Append(" AND ");
			sbsql.Append(" runsql.[field]='"+CoreDb.SqlLiteral(field)+"' ");
			sbsql.Append(" AND ");
			sbsql.Append(" runsql.[field]="+field+" ");
			sbsql.Append("");
			sbsql.Append("ORDER BY ");
			*/
			Tblmainmenu[] temp_Tblmainmenu = runsql(sbsql.ToString(), 1); // restrict to just get a single row back
			if (temp_Tblmainmenu.Length == 0) return null;
			return temp_Tblmainmenu[0];
		}

		public Tblmainmenu[] GetAll()
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
		/// executes sql to build up an array of Tblmainmenu
		/// </summary>
		private Tblmainmenu[] runsql(string strsql, int rowcount)
		{
			return runsql(strsql, null, rowcount);
		}

		/// <summary>
		/// executes sql to build up an array of Tblmainmenu
		/// </summary>
		private Tblmainmenu[] runsql(string strsql)
		{
			return runsql(strsql, null, -1);
		}

		/// <summary>
		/// executes sql to build up an array of Tblmainmenu
		/// </summary>
		private Tblmainmenu[] runsql(string strsql, SqlParameter[] prms, int rowcount)
		{
			if (!DoesTableExist())
				throw new Exception("Table " + tableowner + tablename + " Does Not Exist");

			SqlDataReader result_set = null;
			ArrayList res = new ArrayList();
			Tblmainmenu tempTblmainmenu = null;

			StringBuilder sbsql = new StringBuilder();
			if (!strsql.ToUpper().StartsWith("SELECT")) // determine if we have passed in the select part of the query
			{
				sbsql.Append("SELECT ");

				if (rowcount > -1) // check to see if we want to row restrict our results
					sbsql.Append("TOP " + rowcount + " ");

				sbsql.Append("runsql.[B2BCustomer], runsql.[Description], runsql.[Display], runsql.[Distributor], runsql.[Everyone], runsql.[MenuID], runsql.[ParentID], runsql.[SpecialAccount], runsql.[SuperUser], runsql.[Text], runsql.[URL], runsql.[Vendor], runsql.[WhoCanView] ");
				sbsql.Append("FROM ");
				sbsql.Append(tableowner + tablename + " runsql ");
			}
			sbsql.Append(strsql);

			result_set = Sql(sbsql.ToString(), prms);
			if (result_set != null)
			{
				while (result_set.Read())
				{
					int btwobcustomer = CoreDb.DbToInt(result_set["B2BCustomer"]); // Field = B2BCustomer
					string description = CoreDb.DbToString(result_set["Description"]); // Field = Description
					int display = CoreDb.DbToInt(result_set["Display"]); // Field = Display
					int distributor = CoreDb.DbToInt(result_set["Distributor"]); // Field = Distributor
					int everyone = CoreDb.DbToInt(result_set["Everyone"]); // Field = Everyone
					int menuid = CoreDb.DbToInt(result_set["MenuID"]); // Field = MenuID
					int parentid = CoreDb.DbToInt(result_set["ParentID"]); // Field = ParentID
					int specialaccount = CoreDb.DbToInt(result_set["SpecialAccount"]); // Field = SpecialAccount
					int superuser = CoreDb.DbToInt(result_set["SuperUser"]); // Field = SuperUser
					string text = CoreDb.DbToString(result_set["Text"]); // Field = Text
					string url = CoreDb.DbToString(result_set["URL"]); // Field = URL
					int vendor = CoreDb.DbToInt(result_set["Vendor"]); // Field = Vendor
					string whocanview = CoreDb.DbToString(result_set["WhoCanView"]); // Field = WhoCanView
					tempTblmainmenu = new Tblmainmenu(btwobcustomer, description, display, distributor, everyone, menuid, parentid, specialaccount, superuser, text, url, vendor, whocanview);
					if (overridentableidentifier)
					{
						tempTblmainmenu.TableOwner = tableowner;
						tempTblmainmenu.TableName = tablename;
					}

					res.Add(tempTblmainmenu);
					tempTblmainmenu = null;
				}
				result_set.Close();
				result_set.Dispose();
			}
			Close(); // ensure our database connection is completly closed
			return (Tblmainmenu[])res.ToArray(typeof(Tblmainmenu));
		}
		#endregion
	}
}
