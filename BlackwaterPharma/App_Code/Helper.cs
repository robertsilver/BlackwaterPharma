using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;

public class Helper
{
    #region Public, static, methods
  
    public static string AppSetting(string key)
    {
        return ConfigurationManager.AppSettings[key];
    }

    /// <summary>
    /// Display all the product images once a category has been chosen
    /// </summary>
    /// <param name="imageName">Name of the image to display</param>
    /// <returns></returns>
    public static string DisplayProductImages(string imageName)
    {
        string pathAndFile = string.Empty;

        if (imageName == null)
            return AppSetting("GeneralUNC") + "/noimage.jpg";

        string filename = AppSetting("GeneralImages") + @"\" + imageName;

        if (System.IO.File.Exists(filename))
        {
            return AppSetting("GeneralUNC") + "/" + imageName;
        }
        else
        {
            return AppSetting("GeneralUNC") + "/noimage.jpg";
        }
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

        return valid;
    }

    public static void SaveIPData(HttpRequest IPData, string pageName)
    {
        if (AppSetting("CollectIPs").ToLower() != "True".ToLower())
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
        { }
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
        catch { }
        if (string.Empty == remoteHost)
            remoteHost = "No data";
        #endregion Get remote host

        #region Get request method
        string requestMethod = "No data";
        try
        {
            requestMethod = IPData["request_method"];
        }
        catch { }
        if (string.Empty == requestMethod)
            requestMethod = "No data";
        #endregion Get request method

        #region Get server name
        string serverName = "No data";
        try
        {
            serverName = IPData["server_name"];
        }
        catch { }
        if (string.Empty == serverName)
            serverName = "No data";
        #endregion Get server name

        #region Get server port
        string serverPort = "No data";
        try
        {
            serverPort = IPData["server_port"];
        }
        catch { }
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
        //try
        //{
        //    BPBusinessEngine.Utility.SaveIPs(forwardAddr, httpUserAgent, remoteAddr, 
        //        remoteHost, requestMethod, serverName, 
        //        serverPort, serverSoftware, pageName);
        //}
        //catch(Exception caught)
        //{
        //}
        #endregion Save IP data to DB
    }

    public static bool ValidEmail(string myemail)
    {
        Regex regEx = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$", RegexOptions.None);
        return regEx.IsMatch(myemail);
    }

    #endregion Public, static, methods
}
