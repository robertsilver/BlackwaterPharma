using System;
using System.Configuration;
using System.IO;
using System.Net.Mail;
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
            return AppSetting("Images.UNC") + "/noimage.jpg";

        string filename = AppSetting("Images.General") + @"\" + imageName;

        if (System.IO.File.Exists(filename))
        {
            return AppSetting("Images.UNC") + "/" + imageName;
        }
        else
        {
            return AppSetting("Images.UNC") + "/noimage.jpg";
        }
    }

    /// <summary>
    /// Gets the email template from the text file
    /// </summary>
    /// <param name="templatePath"></param>
    /// <param name="templateName"></param>
    /// <returns></returns>
    public static string GetEmailTemplate(string templatePath, string templateName)
    {
        string emailTemplate = string.Empty;
        StreamReader email = null;
        bool success = false;

        #region Open the file
        try
        {
            email = new StreamReader(templatePath + @"\" + templateName);
            success = true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("BPBusinessEngine.Utility.GetEmailTemplates() returned error: " + ex.Message);
        }
        finally
        {
            if (!success && null != email)
            {
                email.Dispose();
                email = null;
            }
        }
        #endregion Open the file

        #region Read to the end of the file
        emailTemplate = email.ReadToEnd();
        email.Dispose();
        email = null;
        #endregion Read to the end of the file

        return emailTemplate;
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

    /// <summary>
    /// Replaces the tags in the email template, with those
    /// passed into the args array.
    /// </summary>
    /// <param name="templatePath"></param>
    /// <param name="templateName"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static string ReplaceEmailTags(string templatePath, string templateName, string[] args)
    {
        if ((args.Length % 2) != 0)
            throw new ArgumentException("The args passed in was not an even number");

        #region Attempt to get the email template
        string emailTemplate = string.Empty;
        try
        {
            emailTemplate = GetEmailTemplate(templatePath, templateName);
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
        #endregion Attempt to get the email template

        if (string.Empty == emailTemplate)
            throw new ArgumentException("The email template is blank.  Nothing processsed.");

        #region Replace values in the template
        for (int count = 0; count < args.Length; count = count + 3)
        {
            if ("Optional".ToLower() == args[count].ToLower() && string.Empty != args[count + 2])
                emailTemplate = emailTemplate.Replace(args[count + 1], args[count + 2] + "<br/>");
            else
                emailTemplate = emailTemplate.Replace(args[count + 1], args[count + 2]);
        }

        // This removes any empty lines, such as that left by teh tag, <Address2>
        emailTemplate.Replace(Environment.NewLine, string.Empty);
        #endregion Replace values in the template

        return emailTemplate;
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

    /// <summary>
    /// Sends the requested email.
    /// </summary>
    /// <param name="toAddress"></param>
    /// <param name="subject"></param>
    /// <param name="emailBodyText"></param>
    public static void SendEmail(string toAddress, string subject, string emailBodyText, string customerEmail)
    {
        SmtpClient client = null;
        try
        {
            // Extract all of the required settings
            string fromMailAddress = Helper.AppSetting("FromMailAddress");
            string emailServer = Helper.AppSetting("EmailServer");
            int portNumber = Helper.AppSetting("EmailPort") == string.Empty ? 0 : Convert.ToInt32(Helper.AppSetting("EmailPort"));

            MailAddress fromMail = new MailAddress(fromMailAddress);
            MailAddress toMail = new MailAddress(toAddress);

            MailMessage msgDetails = new MailMessage(fromMail, toMail);

            #region Add the CC mail addresses
            if (string.Empty != customerEmail)
                msgDetails.CC.Add(customerEmail);

            string ccEmail = Helper.AppSetting("CCMailAddress");
            if (ccEmail.Contains(";"))
            {
                string[] ccMailAddresses = ccEmail.Split(';');
                foreach (string c in ccMailAddresses)
                    msgDetails.CC.Add(c);
            }
            else if (string.Empty != ccEmail)
                msgDetails.CC.Add(ccEmail);
            #endregion Add the CC mail addresses

            #region Add the BCC mail addresses
            string bccEmail = Helper.AppSetting("BCCMailAddress");
            if (bccEmail.Contains(";"))
            {
                string[] bccMailAddresses = bccEmail.Split(';');
                foreach (string b in bccMailAddresses)
                    msgDetails.Bcc.Add(b);
            }
            else if (string.Empty != bccEmail)
                msgDetails.Bcc.Add(bccEmail);
            #endregion Add the BCC mail addresses

            msgDetails.Body = emailBodyText;
            msgDetails.IsBodyHtml = true;
            msgDetails.Subject = subject;

            // Send the email.
            client = new SmtpClient(emailServer, portNumber);
            client.Send(msgDetails);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Email not sent: " + ex.Message);
        }
        finally
        {
            if (null != client)
                client = null;
        }
    }

    public static bool ValidEmail(string myemail)
    {
        Regex regEx = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$", RegexOptions.None);
        return regEx.IsMatch(myemail);
    }

    #endregion Public, static, methods
}
