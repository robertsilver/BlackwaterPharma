/*
-- Anglia Business Solutions http://www.angliabs.com --
DataMaker Created Class
DataMaker Version 1.0.0.5
Created - 29 January 2011
-- Table tblPrescriptionRequest --
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
	public partial class Tblprescriptionrequest
	{
		// sample join to go get data from another table
		// Item ouritem=null;
		// public Item Ouritem
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
	
	public partial class TblprescriptionrequestAggregate
	{
	}
	
}

*/

namespace BPDBEngine
{
    public partial class Tblprescriptionrequest : CoreDb, IDisposable
    {
        #region private variables
        private string tableowner = Core.AppSetting("TableOwner"); // dbo - at time of build
        private string tablename = "tblPrescriptionRequest";

        private string addressone = string.Empty; // Maps To Database Field - [Address1]
        private string addresstwo = string.Empty; // Maps To Database Field - [Address2]
        private string city = string.Empty; // Maps To Database Field - [City]
        private string county = string.Empty; // Maps To Database Field - [County]
        private string fname = string.Empty; // Maps To Database Field - [FName]
        private int id = 0; // Maps To Database Field - [ID]
        private DateTime insertdt = DateTime.MinValue; // Maps To Database Field - [InsertDT]
        private string lname = string.Empty; // Maps To Database Field - [LName]
        private string pcode = string.Empty; // Maps To Database Field - [PCode]
        private string pemail = string.Empty; // Maps To Database Field - [PEmail]
        private string phoneno = string.Empty; // Maps To Database Field - [PhoneNo]
        private string prescriptionrequest = string.Empty; // Maps To Database Field - [PrescriptionRequest]

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
        /// Maps To Database Field - [Address1] - varchar(30)
        /// </summary>
        public string Addressone
        {
            get
            {
                return addressone;
            }
            set
            {
                addressone = value;
                // automatic truncation of variables
                if (addressone.Length > 30)
                {
                    // throw new Exception("addressone is over maximum character length of 30 characters.");
                    addressone = addressone.Substring(0, 30);
                }
            }
        }

        /// <summary>
        /// Maps To Database Field - [Address2] - varchar(30)
        /// </summary>
        public string Addresstwo
        {
            get
            {
                return addresstwo;
            }
            set
            {
                addresstwo = value;
                // automatic truncation of variables
                if (addresstwo.Length > 30)
                {
                    // throw new Exception("addresstwo is over maximum character length of 30 characters.");
                    addresstwo = addresstwo.Substring(0, 30);
                }
            }
        }

        /// <summary>
        /// Maps To Database Field - [City] - varchar(30)
        /// </summary>
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                // automatic truncation of variables
                if (city.Length > 30)
                {
                    // throw new Exception("city is over maximum character length of 30 characters.");
                    city = city.Substring(0, 30);
                }
            }
        }

        /// <summary>
        /// Maps To Database Field - [County] - varchar(15)
        /// </summary>
        public string County
        {
            get
            {
                return county;
            }
            set
            {
                county = value;
                // automatic truncation of variables
                if (county.Length > 15)
                {
                    // throw new Exception("county is over maximum character length of 15 characters.");
                    county = county.Substring(0, 15);
                }
            }
        }

        /// <summary>
        /// Maps To Database Field - [FName] - varchar(20)
        /// </summary>
        public string Fname
        {
            get
            {
                return fname;
            }
            set
            {
                fname = value;
                // automatic truncation of variables
                if (fname.Length > 20)
                {
                    // throw new Exception("fname is over maximum character length of 20 characters.");
                    fname = fname.Substring(0, 20);
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
        /// Maps To Database Field - [InsertDT] - datetime
        /// </summary>
        public DateTime Insertdt
        {
            get
            {
                return insertdt;
            }
            set
            {
                insertdt = value;
            }
        }

        /// <summary>
        /// Label For Insertdt Maps To Database Field - [InsertDT] - datetime
        /// </summary>
        public string Insertdt_Label
        {
            get
            {
                return Insertdt.ToShortDateString();
            }
        }

        /// <summary>
        /// Maps To Database Field - [LName] - varchar(30)
        /// </summary>
        public string Lname
        {
            get
            {
                return lname;
            }
            set
            {
                lname = value;
                // automatic truncation of variables
                if (lname.Length > 30)
                {
                    // throw new Exception("lname is over maximum character length of 30 characters.");
                    lname = lname.Substring(0, 30);
                }
            }
        }

        /// <summary>
        /// Maps To Database Field - [PCode] - varchar(8)
        /// </summary>
        public string Pcode
        {
            get
            {
                return pcode;
            }
            set
            {
                pcode = value;
                // automatic truncation of variables
                if (pcode.Length > 8)
                {
                    // throw new Exception("pcode is over maximum character length of 8 characters.");
                    pcode = pcode.Substring(0, 8);
                }
            }
        }

        /// <summary>
        /// Maps To Database Field - [PEmail] - varchar(30)
        /// </summary>
        public string Pemail
        {
            get
            {
                return pemail;
            }
            set
            {
                pemail = value;
                // automatic truncation of variables
                if (pemail.Length > 30)
                {
                    // throw new Exception("pemail is over maximum character length of 30 characters.");
                    pemail = pemail.Substring(0, 30);
                }
            }
        }

        /// <summary>
        /// Maps To Database Field - [PhoneNo] - varchar(12)
        /// </summary>
        public string Phoneno
        {
            get
            {
                return phoneno;
            }
            set
            {
                phoneno = value;
                // automatic truncation of variables
                if (phoneno.Length > 12)
                {
                    // throw new Exception("phoneno is over maximum character length of 12 characters.");
                    phoneno = phoneno.Substring(0, 12);
                }
            }
        }

        /// <summary>
        /// Maps To Database Field - [PrescriptionRequest] - varchar
        /// </summary>
        public string Prescriptionrequest
        {
            get
            {
                return prescriptionrequest;
            }
            set
            {
                prescriptionrequest = value;
            }
        }
        #endregion

        #region constructor
        public Tblprescriptionrequest()
        {
            initialise();
        }

        public Tblprescriptionrequest(
             string addressone
            , string addresstwo
            , string city
            , string county
            , string fname
            , int id
            , DateTime insertdt
            , string lname
            , string pcode
            , string pemail
            , string phoneno
            , string prescriptionrequest
        )
        {
            initialise();
            this.addressone = addressone;
            this.addresstwo = addresstwo;
            this.city = city;
            this.county = county;
            this.fname = fname;
            this.id = id;
            this.insertdt = insertdt;
            this.lname = lname;
            this.pcode = pcode;
            this.pemail = pemail;
            this.phoneno = phoneno;
            this.prescriptionrequest = prescriptionrequest;
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
            sbsql.AppendLine("DELETE FROM " + tableowner + tablename + " ");
            sbsql.AppendLine("WHERE ");
            sbsql.AppendLine("[ID] = @id ");

            SqlExecute(sbsql.ToString(), this.GetWhereValues());
        }

        public void Update()
        {
            // Determine if keys are valid
            if (!keyintegrity)
                throw new Exception("tblPrescriptionRequest key integrity error, a previous insert operation occured without the class being updated with all key field values.");

            bool isinsert = true;
            // Determine if we are doing an insert or an update
            StringBuilder sbsql = new StringBuilder();
            // if block to determine if we need to test for record existance
            if (
                id != 0
            )
            {
                sbsql.AppendLine("SELECT ");
                sbsql.AppendLine("COUNT(1) ");
                sbsql.AppendLine("FROM ");
                sbsql.AppendLine(tableowner + tablename + " ");
                sbsql.AppendLine("WHERE ");
                sbsql.AppendLine("[ID] = @id ");

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

            sbsql.AppendLine("INSERT INTO ");
            sbsql.AppendLine(tableowner + tablename + " ");
            sbsql.AppendLine("(");
            sbsql.AppendLine(" [Address1] ");
            sbsql.AppendLine(",[Address2] ");
            sbsql.AppendLine(",[City] ");
            sbsql.AppendLine(",[County] ");
            sbsql.AppendLine(",[FName] ");
            sbsql.AppendLine(",[InsertDT] ");
            sbsql.AppendLine(",[LName] ");
            sbsql.AppendLine(",[PCode] ");
            sbsql.AppendLine(",[PEmail] ");
            sbsql.AppendLine(",[PhoneNo] ");
            sbsql.AppendLine(",[PrescriptionRequest] ");
            sbsql.AppendLine(") ");
            sbsql.AppendLine("VALUES ");
            sbsql.AppendLine("(");
            sbsql.AppendLine(" @addressone ");  // Maps To Database Field - [Address1]
            sbsql.AppendLine(",@addresstwo ");  // Maps To Database Field - [Address2]
            sbsql.AppendLine(",@city ");  // Maps To Database Field - [City]
            sbsql.AppendLine(",@county ");  // Maps To Database Field - [County]
            sbsql.AppendLine(",@fname ");  // Maps To Database Field - [FName]
            sbsql.AppendLine(",@insertdt ");  // Maps To Database Field - [InsertDT]
            sbsql.AppendLine(",@lname ");  // Maps To Database Field - [LName]
            sbsql.AppendLine(",@pcode ");  // Maps To Database Field - [PCode]
            sbsql.AppendLine(",@pemail ");  // Maps To Database Field - [PEmail]
            sbsql.AppendLine(",@phoneno ");  // Maps To Database Field - [PhoneNo]
            sbsql.AppendLine(",@prescriptionrequest ");  // Maps To Database Field - [PrescriptionRequest]
            sbsql.AppendLine(")");

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

            sbsql.AppendLine("UPDATE ");
            sbsql.AppendLine(tableowner + tablename + " ");
            sbsql.AppendLine("SET ");
            sbsql.AppendLine(" [Address1] = @addressone ");
            sbsql.AppendLine(",[Address2] = @addresstwo ");
            sbsql.AppendLine(",[City] = @city ");
            sbsql.AppendLine(",[County] = @county ");
            sbsql.AppendLine(",[FName] = @fname ");
            sbsql.AppendLine(",[InsertDT] = @insertdt ");
            sbsql.AppendLine(",[LName] = @lname ");
            sbsql.AppendLine(",[PCode] = @pcode ");
            sbsql.AppendLine(",[PEmail] = @pemail ");
            sbsql.AppendLine(",[PhoneNo] = @phoneno ");
            sbsql.AppendLine(",[PrescriptionRequest] = @prescriptionrequest ");
            sbsql.AppendLine("WHERE ");
            sbsql.AppendLine("[ID] = @id ");


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
            tempparam = new SqlParameter();  // Maps To - [Address1]
            tempparam.ParameterName = "@addressone";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 30;
            tempparam.Value = addressone;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [Address2]
            tempparam.ParameterName = "@addresstwo";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 30;
            tempparam.Value = addresstwo;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [City]
            tempparam.ParameterName = "@city";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 30;
            tempparam.Value = city;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [County]
            tempparam.ParameterName = "@county";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 15;
            tempparam.Value = county;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [FName]
            tempparam.ParameterName = "@fname";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 20;
            tempparam.Value = fname;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [InsertDT]
            tempparam.ParameterName = "@insertdt";
            tempparam.SqlDbType = System.Data.SqlDbType.DateTime;
            tempparam.Value = insertdt;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [LName]
            tempparam.ParameterName = "@lname";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 30;
            tempparam.Value = lname;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [PCode]
            tempparam.ParameterName = "@pcode";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 8;
            tempparam.Value = pcode;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [PEmail]
            tempparam.ParameterName = "@pemail";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 30;
            tempparam.Value = pemail;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [PhoneNo]
            tempparam.ParameterName = "@phoneno";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 12;
            tempparam.Value = phoneno;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [PrescriptionRequest]
            tempparam.ParameterName = "@prescriptionrequest";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Value = prescriptionrequest;
            paramcollection.Add(tempparam);

            return (SqlParameter[])paramcollection.ToArray(typeof(SqlParameter));
        }

        public SqlParameter[] GetUpdateValues()
        {
            ArrayList paramcollection = new ArrayList();
            SqlParameter tempparam = null;

            // build values
            tempparam = new SqlParameter();  // Maps To - [Address1]
            tempparam.ParameterName = "@addressone";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 30;
            tempparam.Value = addressone;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [Address2]
            tempparam.ParameterName = "@addresstwo";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 30;
            tempparam.Value = addresstwo;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [City]
            tempparam.ParameterName = "@city";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 30;
            tempparam.Value = city;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [County]
            tempparam.ParameterName = "@county";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 15;
            tempparam.Value = county;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [FName]
            tempparam.ParameterName = "@fname";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 20;
            tempparam.Value = fname;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [InsertDT]
            tempparam.ParameterName = "@insertdt";
            tempparam.SqlDbType = System.Data.SqlDbType.DateTime;
            tempparam.Value = insertdt;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [LName]
            tempparam.ParameterName = "@lname";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 30;
            tempparam.Value = lname;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [PCode]
            tempparam.ParameterName = "@pcode";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 8;
            tempparam.Value = pcode;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [PEmail]
            tempparam.ParameterName = "@pemail";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 30;
            tempparam.Value = pemail;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [PhoneNo]
            tempparam.ParameterName = "@phoneno";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Size = 12;
            tempparam.Value = phoneno;
            paramcollection.Add(tempparam);

            tempparam = new SqlParameter();  // Maps To - [PrescriptionRequest]
            tempparam.ParameterName = "@prescriptionrequest";
            tempparam.SqlDbType = System.Data.SqlDbType.VarChar;
            tempparam.Value = prescriptionrequest;
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

            sbsql.AppendLine("UPDATE ");
            sbsql.AppendLine(tableowner + tablename + " ");
            sbsql.AppendLine("SET ");
            sbsql.AppendLine(" [ID] = @newid ");
            sbsql.AppendLine("WHERE ");
            sbsql.AppendLine("[ID] = @id ");

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

    public partial class TblprescriptionrequestAggregate : CoreDb
    {
        #region private variables

        private string tableowner = Core.AppSetting("TableOwner"); // dbo - at time of build
        private string tablename = "tblPrescriptionRequest";
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
        public TblprescriptionrequestAggregate()
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

        public void BulkInsert(Tblprescriptionrequest[] dta)
        {
            bulk_operation(dta, true);
        }

        public void BulkUpdate(Tblprescriptionrequest[] dta)
        {
            bulk_operation(dta, false);
        }

        private void bulk_operation(Tblprescriptionrequest[] dta, bool isinsert)
        {
            if (dta == null)
                return;

            if (dta.Length == 0)
                return;

            SqlParameter[,] prs = null;
            int rowcount = 0;
            foreach (Tblprescriptionrequest e in dta)
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
            sbsql.AppendLine("SELECT ");
            sbsql.AppendLine("COUNT(1) ");
            sbsql.AppendLine("FROM ");
            sbsql.AppendLine(tableowner + tablename + " ");
            /* sbsql.AppendLine("WHERE ");
            sbsql.AppendLine("");
            sbsql.AppendLine(" AND ");
            sbsql.AppendLine(" ORDER BY ");
            */

            return CoreDb.DbToInt(SqlQuickValue(sbsql.ToString()));
        }

        public Tblprescriptionrequest[] GetSingular(
         int id
        )
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.AppendLine("WHERE ");
            sbsql.AppendLine("runsql.[ID] = " + (int)(id) + " ");

            /*
            sbsql.AppendLine(" AND ");
            sbsql.AppendLine(" runsql.[field]='"+CoreDb.SqlLiteral(field)+"' ");
            sbsql.AppendLine(" AND ");
            sbsql.AppendLine(" runsql.[field]="+field+" ");
            sbsql.AppendLine("");
            sbsql.AppendLine("ORDER BY ");
            */
            return runsql(sbsql.ToString());
            // return runsql(sbsql.ToString(),1); // restrict to just get a single row back
        }

        public Tblprescriptionrequest GetSingle(
         int id
        )
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.AppendLine("WHERE ");
            sbsql.AppendLine("runsql.[ID] = " + (int)(id) + " ");

            /*
            sbsql.AppendLine(" AND ");
            sbsql.AppendLine(" runsql.[field]='"+CoreDb.SqlLiteral(field)+"' ");
            sbsql.AppendLine(" AND ");
            sbsql.AppendLine(" runsql.[field]="+field+" ");
            sbsql.AppendLine("");
            sbsql.AppendLine("ORDER BY ");
            */
            Tblprescriptionrequest[] temp_Tblprescriptionrequest = runsql(sbsql.ToString(), 1); // restrict to just get a single row back
            if (temp_Tblprescriptionrequest.Length == 0) return null;
            return temp_Tblprescriptionrequest[0];
        }

        public Tblprescriptionrequest[] GetAll()
        {
            StringBuilder sbsql = new StringBuilder();
            // sbsql.AppendLine("WHERE ");
            // sbsql.AppendLine(" runsql.[field]='"+CoreDb.SqlLiteral(field)+"' ");
            /*
            sbsql.AppendLine(" AND ");
            sbsql.AppendLine(" runsql.[field]='"+CoreDb.SqlLiteral(field)+"' ");
            sbsql.AppendLine("");
            sbsql.AppendLine("ORDER BY ");
            */

            return runsql(sbsql.ToString());
        }
        public void DeleteSingular(
         int id
        )
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.AppendLine("DELETE FROM ");
            sbsql.AppendLine(tableowner + tablename + " ");
            sbsql.AppendLine("WHERE ");
            sbsql.AppendLine("[ID] = " + (int)(id) + " ");

            /*
            sbsql.AppendLine(" AND ");
            sbsql.AppendLine(" [field]='"+CoreDb.SqlLiteral(field)+"' ");
            sbsql.AppendLine(" AND ");
            sbsql.AppendLine(" [field]="+field+" ");
            sbsql.AppendLine("");
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
        /// executes sql to build up an array of Tblprescriptionrequest
        /// </summary>
        private Tblprescriptionrequest[] runsql(string strsql, int rowcount)
        {
            return runsql(strsql, null, rowcount);
        }

        /// <summary>
        /// executes sql to build up an array of Tblprescriptionrequest
        /// </summary>
        private Tblprescriptionrequest[] runsql(string strsql)
        {
            return runsql(strsql, null, -1);
        }

        /// <summary>
        /// executes sql to build up an array of Tblprescriptionrequest
        /// </summary>
        private Tblprescriptionrequest[] runsql(string strsql, SqlParameter[] prms, int rowcount)
        {
            if (!DoesTableExist())
                throw new Exception("Table " + tableowner + tablename + " Does Not Exist");

            SqlDataReader result_set = null;
            ArrayList res = new ArrayList();
            Tblprescriptionrequest tempTblprescriptionrequest = null;

            StringBuilder sbsql = new StringBuilder();
            if (!strsql.ToUpper().StartsWith("SELECT")) // determine if we have passed in the select part of the query
            {
                sbsql.AppendLine("SELECT ");

                if (rowcount > -1) // check to see if we want to row restrict our results
                    sbsql.AppendLine("TOP " + rowcount + " ");

                sbsql.AppendLine("runsql.[Address1], runsql.[Address2], runsql.[City], runsql.[County], runsql.[FName], runsql.[ID], runsql.[InsertDT], runsql.[LName], runsql.[PCode], runsql.[PEmail], runsql.[PhoneNo], runsql.[PrescriptionRequest] ");
                sbsql.AppendLine("FROM ");
                sbsql.AppendLine(tableowner + tablename + " runsql ");
            }
            sbsql.AppendLine(strsql);

            result_set = Sql(sbsql.ToString(), prms);
            if (result_set != null)
            {
                while (result_set.Read())
                {
                    string addressone = CoreDb.DbToString(result_set["Address1"]); // Field = Address1
                    string addresstwo = CoreDb.DbToString(result_set["Address2"]); // Field = Address2
                    string city = CoreDb.DbToString(result_set["City"]); // Field = City
                    string county = CoreDb.DbToString(result_set["County"]); // Field = County
                    string fname = CoreDb.DbToString(result_set["FName"]); // Field = FName
                    int id = CoreDb.DbToInt(result_set["ID"]); // Field = ID
                    DateTime insertdt = CoreDb.DbToDateTime(result_set["InsertDT"]); // Field = InsertDT
                    string lname = CoreDb.DbToString(result_set["LName"]); // Field = LName
                    string pcode = CoreDb.DbToString(result_set["PCode"]); // Field = PCode
                    string pemail = CoreDb.DbToString(result_set["PEmail"]); // Field = PEmail
                    string phoneno = CoreDb.DbToString(result_set["PhoneNo"]); // Field = PhoneNo
                    string prescriptionrequest = CoreDb.DbToString(result_set["PrescriptionRequest"]); // Field = PrescriptionRequest
                    tempTblprescriptionrequest = new Tblprescriptionrequest(addressone, addresstwo, city, county, fname, id, insertdt, lname, pcode, pemail, phoneno, prescriptionrequest);
                    if (overridentableidentifier)
                    {
                        tempTblprescriptionrequest.TableOwner = tableowner;
                        tempTblprescriptionrequest.TableName = tablename;
                    }

                    res.Add(tempTblprescriptionrequest);
                    tempTblprescriptionrequest = null;
                }
                result_set.Close();
                result_set.Dispose();
            }
            Close(); // ensure our database connection is completly closed
            return (Tblprescriptionrequest[])res.ToArray(typeof(Tblprescriptionrequest));
        }
        #endregion
    }
}
