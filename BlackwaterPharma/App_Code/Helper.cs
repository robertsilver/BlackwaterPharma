using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using AngliaTemplate;
using BPDBEngine;
using System.Diagnostics;

/// <summary>
/// Summary description for Helper
/// </summary>
public class Helper
{
	public Helper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region Public, static, methods
    public static void SaveIPData(HttpRequest IPData, string pageName)
	{
		if (Core.AppSetting("CollectIPs").ToLower() != "True".ToLower())
			// Don't waste time processing the request, if
			// value is NOT set.
			return;

		#region Get forward address
		string forwardAddr = string.Empty;
		try
		{
			forwardAddr = IPData["HTTP_X_FORWARDED_FOR"];
		}
		catch { }

		if (!string.IsNullOrEmpty(forwardAddr))
		{
			string[] ipRange = forwardAddr.Split(',');
			int le = ipRange.Length - 1;
			forwardAddr = ipRange[le];
		}
		else
			forwardAddr = "No data";
		#endregion Get forward address

		#region Get HTTP user agent
		string httpUserAgent = "No data";
		try
		{
			httpUserAgent = IPData["http_user_agent"];
		}
		catch
		{}
		if (string.Empty == httpUserAgent)
			httpUserAgent = "No data";
		#endregion Get HTTP user agent

		#region Get remote address
		string remoteAddr = "No data";
		try
		{
			remoteAddr = IPData["remote_addr"];
		}
		catch
		{ }
		if (string.Empty == remoteAddr)
			remoteAddr = "No data";
		#endregion Get remote address

		#region Get remote host
		string remoteHost = "No data";
		try
		{
			remoteHost = IPData["remote_host"];
		}
		catch {}
		if (string.Empty == remoteHost)
			remoteHost = "No data";
		#endregion Get remote host

		#region Get request method
		string requestMethod = "No data";
		try
		{
			requestMethod = IPData["request_method"];
		}
		catch{}
		if (string.Empty == requestMethod)
			requestMethod = "No data";
		#endregion Get request method

		#region Get server name
		string serverName = "No data";
		try
		{
			serverName = IPData["server_name"];
		}
		catch {}
		if (string.Empty == serverName)
			serverName = "No data";
		#endregion Get server name

		#region Get server port
		string serverPort = "No data";
		try
		{
			serverPort = IPData["server_port"];
		}
		catch {}
		if (string.Empty == serverPort)
			serverPort = "No data";
		#endregion Get server port

		#region Get server software
		string serverSoftware = "No data";
		try
		{
			serverSoftware = IPData["server_software"];
		}
		catch
		{ }
		if (string.Empty == serverSoftware)
			serverSoftware = "No data";
		#endregion Get server software

		#region Save IP data to DB
		try
		{
			BPBusinessEngine.Utility.SaveIPs(forwardAddr, httpUserAgent, remoteAddr, 
				remoteHost, requestMethod, serverName, 
				serverPort, serverSoftware, pageName);
		}
		catch(Exception caught)
		{
			BPBusinessEngine.Utility.SaveEvents("App_Code.Helper.SaveIPData", "BPBusinessEngine.Utility.SaveIPs() returned error: " + caught.Message, "Error");
		}
		#endregion Save IP data to DB
    }

    /// <summary>
    /// Checks to see if the value entered by the user
    /// is a valid string in size and content
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static bool IsUserValueSafe(string data, int lengthToCheck)
    {
        bool valid = false;

        if (data.Length <= lengthToCheck)
            valid = true;

        if (valid)
        {
            if (data.IndexOf("'") >= 0)
                valid = false;
            else if (data.IndexOf(";") >= 0)
                valid = false;
            else if (data.IndexOf("macro") >= 0)
                valid = false;
        }

        if (!valid)
            BPBusinessEngine.Utility.SaveEvents("IsUserValueSafe()", "The method has identifed that the following text may be dangerous: " + data + ".  Variable, lengthToCheck, was set to: " + lengthToCheck.ToString(), "Error");

        return valid;
    }

    #endregion Public, static, methods
}
