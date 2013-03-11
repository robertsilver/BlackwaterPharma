using System;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Collections;
using System.Text;

namespace AngliaTemplate
{
    /// <summary>
    /// Summary description for CoreDbOracle.
    /// </summary>
    public class CoreDbOracle
    {
        protected OracleConnection Cn = new OracleConnection(Core.AppSetting("ConnectionStringOracle"));

        #region generic sql commands



        protected void showexception(string msg, string strsql)
        {
            Console.WriteLine(msg + " Database Open Exception\n\n" + strsql);
            //, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

        }

      
      
        protected OracleException showexception(OracleException e, string strsql)
        {
            //if (silentmode) return e;


            Console.WriteLine("Oracle Error " + e.ErrorCode + " " + e.Message);
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


        public static string SqlBoolJDE(bool totest)
        {
            return totest ? "'Y'" : "'N'";

        }

        /// <summary>
        /// turns a date into to a date suitable for inserting into JDE
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string SqlDateJDE(DateTime dt)
        {
            int d = (dt.Year - 1900) * 1000 + dt.DayOfYear;
            return d.ToString();
        }

        /// <summary>
        /// Turns a datetime into a time suitable for insertion into JDE
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string SqlTimeJDE(DateTime dt)
        {
            string strReturn;
            strReturn = dt.ToString("HHmmss", null);
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
            OracleCommand myCommand = null;
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
                myCommand = new OracleCommand(strSql, Cn);
                myCommand.CommandType = System.Data.CommandType.Text;


                OracleDataReader myReader = myCommand.ExecuteReader();
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
            return doesobjectexist(tablename, "BASE TABLE");
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


        public OracleDataReader Sql(string strSql)
        {
            return Sql(strSql, null);
        }


        protected object SqlExecuteIdentity(string strsql)
        {
            return this.SqlExecuteIdentity(strsql, null);

        }

        protected object SqlExecuteIdentity(string strsql, OracleParameter[] prms)
        {
            object ret = 0;
            bool isopen = (Cn.State == ConnectionState.Open);

           OracleCommand cmd = null;

            try
            {
                if (!isopen) Open();
                cmd = new OracleCommand(strsql, Cn);
                cmd.CommandType = CommandType.Text;

                if (prms != null)
                {
                    foreach (OracleParameter x in prms)
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

        public OracleDataReader Sql(string strSql, OracleParameter[] prms)
        {

            // returns a list of values

            OracleDataReader Reader;
            bool bOpen = (Cn.State == ConnectionState.Open);

            if (!bOpen)
                Cn.Open();

            OracleCommand myCommand = null;
            try
            {
                myCommand = new OracleCommand(strSql, Cn);
                myCommand.CommandType = System.Data.CommandType.Text;
                if (prms != null)
                {
                    foreach (OracleParameter p in prms)
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
        public object SqlQuickValue(string strSql, OracleParameter[] prms)
        {
            object lv_ret = null;
            OracleCommand myCommand = null;
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
                myCommand = new OracleCommand(strSql, Cn);

                if (prms != null)
                {
                    foreach (OracleParameter p in prms)
                        myCommand.Parameters.Add(p);
                }
                lv_ret = myCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new Exception("SqlQuickValue Error occurred running following SQL statement:\n\n" + strSql, e);
            }
            finally
            {
                if (myCommand != null) myCommand.Dispose();
                if (!bOpen) Cn.Close();
            }
            return lv_ret;
        }

        public void SqlExecute(string strSql)
        {
            SqlExecute(strSql, null);
        }
        public void SqlExecute(string strSql, OracleParameter[] prms)
        {

            //Current connection status.
            bool bOpen = (Cn.State == ConnectionState.Open);
            OracleCommand Dbc = null;

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

                Dbc = new OracleCommand(strSql, Cn);
                if (prms != null)
                {
                    foreach (OracleParameter p in prms)
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
            OracleCommand Dbc = null;


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

                Dbc = new OracleCommand(strSql, Cn);
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

        public static DataTable Rotate(OracleDataReader ret)
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


        public static float DbToFloat(object val)
        {
            if (Convert.IsDBNull(val))
                return 0;
            float ret = 0;
            try
            {
                return (float)Convert.ToDecimal(val.ToString());
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

        public static string DbToStringRTrim(object val)
        {
            string ret = DbToString(val);
            char[] c = new char[1];
            c[0] = ' ';
            ret = ret.TrimEnd(c);
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

        public static bool DbToBoolJDE(object val)
        {
            if (Convert.IsDBNull(val))
                return false;
            bool ret = false;
            try
            {
                switch (val.ToString())
                {
                    case "Y":
                    case "1":
                        ret = true;
                        break;
                }

            }
            catch
            {

            }
            return ret;
        }

        public static DateTime DbToDateJDE(object val)
        {
            if (Convert.IsDBNull(val))
                return DateTime.MinValue; ;

            decimal d = Convert.ToDecimal(val);
            string ret = d.ToString("000000");
            int cent = Convert.ToInt32(ret.Substring(0, 1));
            int yy = Convert.ToInt32(ret.Substring(1, 2));
            int doy = Convert.ToInt32(ret.Substring(3));
            int year = (yy + ((19 + cent) * 100));
            DateTime dt = new DateTime(year, 1, 1);
            dt = dt.AddDays(doy - 1);
            return dt;

        }

        public static DateTime DbToTimeJDE(object val)
        {
            if (Convert.IsDBNull(val))
                return DateTime.MinValue;

            decimal tim = Convert.ToDecimal(val);
            string ret = tim.ToString("000000");
            int hour = Convert.ToInt32(ret.Substring(0, 2));
            int minute = Convert.ToInt32(ret.Substring(2, 2));
            int second = Convert.ToInt32(ret.Substring(5));
            DateTime dt = new DateTime(DateTime.MinValue.Year, 1, 1, hour, minute, second);
            return dt;
        }

        public static DateTime DbToDateTime(object val)
        {
            DateTime ret = DateTime.MinValue;
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
