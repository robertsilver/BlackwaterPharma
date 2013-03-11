using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BPDBEngine;

namespace BPBusinessEngine
{
    public class PrescriptionRequest
    {
        #region Public, static, methods
        /// <summary>
        /// Attempts to save the request to the DB.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static bool SavePrescriptionRequestToDB(Tblprescriptionrequest req)
        {
            bool success = false;

            if (null == req)
                throw new ArgumentException("Variable, req, is null.");

            try
            {
                req.Update();
                success = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (null != req)
                {
                    req.Dispose();
                    req = null;
                }
            }

            return success;
        }
        #endregion Public, static, methods
    }
}
