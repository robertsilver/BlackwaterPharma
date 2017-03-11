using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AngliaTemplate;
using BPDBEngine;
using System.IO;
using System.Net.Mail;

namespace BPBusinessEngine
{
	public class Utility
	{
		#region Public, static, methods
		/// <summary>
		/// Display all the product images once a category has been chosen
		/// </summary>
		/// <param name="imageName">Name of the image to display</param>
		/// <returns></returns>
		public static string DisplayProductImages(string imageName)
		{
			string pathAndFile = string.Empty;

			if (imageName == null)
				return Core.AppSetting("GeneralUNC") + "/noimage.jpg";

			string filename = Core.AppSetting("GeneralImages") + @"\" + imageName;

			if (System.IO.File.Exists(filename))
			{
				return Core.AppSetting("GeneralUNC") + "/" + imageName;
			}
			else
			{
				return Core.AppSetting("GeneralUNC") + "/noimage.jpg";
			}
		}

		/// <summary>
		/// Errors saved in the table, tblEventLog
		/// </summary>
		/// <param name="methodName"></param>
		/// <param name="data"></param>
		/// <param name="logType"></param>
		public static void SaveEvents(string methodName, string data, string logType)
		{
			#region Determine if we can save the data to the DB
			bool canSaveToDB = false;
			if (Core.AppSetting("LogEvents_Debug").ToLower() == "True".ToLower() && ("Debug" == logType))
				canSaveToDB = true;
			else if (Core.AppSetting("LogEvents_Information").ToLower() == "True".ToLower() && ("Information" == logType))
				canSaveToDB = true;
			else if (Core.AppSetting("LogEvents_Warning").ToLower() == "True".ToLower() && ("Warning" == logType))
				canSaveToDB = true;
			else if (Core.AppSetting("LogEvents_Error").ToLower() == "True".ToLower() && ("Error" == logType))
				canSaveToDB = true;
			#endregion Determine if we can save the data to the DB

			if (canSaveToDB)
			{
				#region Save the data to the DB
				Tbleventlog log = new Tbleventlog();

				log.Applicationname = "BlackwaterPharma";
				log.Description = data;
				log.Entrytype = logType;
				DateTime temp = DateTime.Now;
				log.Insertdatetime = new DateTime(temp.Year, temp.Month, temp.Day, temp.Hour, temp.Minute, temp.Second);
				log.Methodname = methodName;

				try
				{
					log.Update();
				}
				catch(Exception ex)
				{
					throw new ApplicationException(ex.Message);
				}
				finally
				{
					if (null != log)
					{
						log.Dispose();
						log = null;
					}
				}
				#endregion Save the data to the DB
			}
		}

		/// <summary>
		/// Saves the IP data to the DB.
		/// </summary>
		/// <param name="httpUserAgent"></param>
		/// <param name="remoteAddr"></param>
		/// <param name="remoteHost"></param>
		/// <param name="requestMethod"></param>
		/// <param name="serverName"></param>
		/// <param name="serverPort"></param>
		/// <param name="serverSoftware"></param>
		public static void SaveIPs(string forwardedAddr, string httpUserAgent, string remoteAddr,
			string remoteHost, string requestMethod, string serverName, 
			string serverPort, string serverSoftware, string pageName)
		{
			#region Determine if we can save the IP to the DB
			bool saveIP = false;
			if (Core.AppSetting("CollectIPs").ToLower() == "True".ToLower())
				saveIP= true;
			#endregion Determine if we can save the IP to the DB

			if (saveIP)
			{
				#region Save the IP to the DB
				Tbliplist ip = new Tbliplist();

				ip.Forwardaddr = forwardedAddr;
				ip.Httpuseragent = httpUserAgent;
				DateTime temp = DateTime.Now;
				ip.Insertdatetime = new DateTime(temp.Year, temp.Month, temp.Day, temp.Hour, temp.Minute, temp.Second);
				ip.Pagename = pageName;
				ip.Remoteaddress = remoteAddr;
				ip.Remotehost = remoteHost;
				ip.Requestmethod = requestMethod;
				ip.Servername = serverName;
				ip.Serverport = serverPort;
				ip.Serversoftware = serverSoftware;

				try
				{
					ip.Update();
				}
				catch (Exception ex)
				{
					throw new ApplicationException(ex.Message);
				}
				finally
				{
					if (null != ip)
					{
						ip.Dispose();
						ip = null;
					}
				}
				#endregion Save the IP to the DB
			}
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
                string fromMailAddress = Core.AppSetting("FromMailAddress");
                string emailServer = Core.AppSetting("EmailServer");
                int portNumber = Core.AppSetting("EmailPort") == string.Empty ? 0 : Convert.ToInt32(Core.AppSetting("EmailPort"));

                MailAddress fromMail = new MailAddress(fromMailAddress);
                MailAddress toMail = new MailAddress(toAddress);

                MailMessage msgDetails = new MailMessage(fromMail, toMail);

                #region Add the CC mail addresses
                if (string.Empty != customerEmail)
                    msgDetails.CC.Add(customerEmail);

                string ccEmail = Core.AppSetting("CCMailAddress");
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
                string bccEmail = Core.AppSetting("BCCMailAddress");
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

		#endregion Public, static, methods
	}
}
