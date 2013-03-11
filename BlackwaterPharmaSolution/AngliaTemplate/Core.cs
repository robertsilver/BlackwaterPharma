using System;
using System.Web;
using System.Configuration;
using System.Net;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Specialized;
using System.Diagnostics;

using System.Windows.Forms;
using System.IO;




namespace AngliaTemplate
{
    public class EnDecryptStrings
    {

        public static string Encrypt(string original)
        {
			if (original.Length == 0)
				return "";
            string password = "secretpassword1!";  // +DateTime.Now.Minute.ToString();

            TripleDESCryptoServiceProvider des;
            MD5CryptoServiceProvider hashmd5;
            byte[] pwdhash, buff;

            hashmd5 = new MD5CryptoServiceProvider();
            pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            hashmd5 = null;

            //implement DES3 encryption
            des = new TripleDESCryptoServiceProvider();

            //the key is the secret password hash.
            des.Key = pwdhash;

            //the mode is the block cipher mode which is basically the
            //details of how the encryption will work. There are several
            //kinds of ciphers available in DES3 and they all have benefits
            //and drawbacks. Here the Electronic Codebook cipher is used
            //which means that a given bit of text is always encrypted
            //exactly the same when the same password is used.
            des.Mode = CipherMode.ECB; //CBC, CFB


            //----- encrypt an un-encrypted string ------------
            //the original string, which needs encrypted, must be in byte
            //array form to work with the des3 class. everything will because
            //most encryption works at the byte level so you'll find that
            //the class takes in byte arrays and returns byte arrays and
            //you'll be converting those arrays to strings.
            buff = ASCIIEncoding.ASCII.GetBytes(original);

            //encrypt the byte buffer representation of the original string
            //and base64 encode the encrypted string. the reason the encrypted
            //bytes are being base64 encoded as a string is the encryption will
            //have created some weird characters in there. Base64 encoding
            //provides a platform independent view of the encrypted string 
            //and can be sent as a plain text string to wherever.
            return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));

        }

        public static string Decrypt(string encrypted)
        {
			if (encrypted.Length == 0)
				return "";
            string password = "secretpassword1!";

            TripleDESCryptoServiceProvider des;
            MD5CryptoServiceProvider hashmd5;
            byte[] pwdhash, buff;

            hashmd5 = new MD5CryptoServiceProvider();
            pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            hashmd5 = null;

            //implement DES3 encryption
            des = new TripleDESCryptoServiceProvider();

            //the key is the secret password hash.
            des.Key = pwdhash;

            //the mode is the block cipher mode which is basically the
            //details of how the encryption will work. There are several
            //kinds of ciphers available in DES3 and they all have benefits
            //and drawbacks. Here the Electronic Codebook cipher is used
            //which means that a given bit of text is always encrypted
            //exactly the same when the same password is used.
            des.Mode = CipherMode.ECB; //CBC, CFB


            buff = Convert.FromBase64String(encrypted);

            //decrypt DES 3 encrypted byte buffer and return ASCII string
            return ASCIIEncoding.ASCII.GetString(
                des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length)
                );

        }

    }
    public class Core
    {
        /// <summary>
        /// Returns our meta tag for each site
        /// </summary>
        /// <returns></returns>
        public static string MetaTags()
        {
            string metame = "";
            metame += "<meta name=\"keywords\" content=\"";
            metame += Core.AppSetting("metakeywords");
            metame += "\">";

            metame += "<meta name=\"description\" content=\"";
            metame += Core.AppSetting("metadescription");
            metame += "\">";
            return metame;

        }

       public static void SessionRemove(string sessionvar)
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            try
            {
                context.Session.Remove(sessionvar);
            }
            catch
            {
            }


        }

        public static bool LanUser(string requestip)
        {
            if (requestip == "127.0.0.1") return true;
            string locallan = Core.AppSetting("LocalLan");
            return requestip.StartsWith(locallan);
        }

        public static bool OnLocalHost()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            return context.Request.IsLocal;
        }

 
  
        public static string Shop()
        {
            try
            {
                string strshop = "";
                System.Web.HttpContext context = System.Web.HttpContext.Current;
                strshop = context.Session["Shop"].ToString();
                if (strshop != null) return strshop;
            }
            catch
            {

            }

            return Core.AppSetting("Shop");
        }

        /// <summary>
        /// returns manufacturer to filter
        /// </summary>
        /// <returns></returns>
        public static int ManuFilter()
        {
            int manu = 0;
            try
            {

                manu = Convert.ToInt32(Core.AppSetting("manufilter"));
            }
            catch
            {
                return 0;
            }

            return manu;
        }

        public static string BulletMe(object objbullet)
        {

            string strret = objbullet.ToString();

            strret = strret.Replace("<li>", "<img src=\"" + Core.Shop() + "/gs.gif\">");
            strret = strret.Replace("\r\n", "<br>");
            return strret;
        }

        public static bool ValidEmail(string myemail)
        {
            Regex regEx = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$", RegexOptions.None);
            return regEx.IsMatch(myemail);

        }

        public static string Exec(string strCmd, string strArgs)
        {
            // Execute a command line program
            ProcessStartInfo myStartInfo = new ProcessStartInfo();
            myStartInfo.FileName = strCmd;
            myStartInfo.Arguments = strArgs;
            myStartInfo.UseShellExecute = false;
            myStartInfo.RedirectStandardOutput = true;

            Process myProcess = Process.Start(myStartInfo);
            return myProcess.StandardOutput.ReadToEnd().ToString();
        }

        public static string AppSetting(string strkey)
        {
			string strKeyToGet = "";

			string computerName = "";

			try
			{
				computerName=SystemInformation.ComputerName.ToLower() + " ";
			}
			catch
			{

			}
			strKeyToGet = computerName + strkey;

			string ret = ConfigurationManager.AppSettings[strKeyToGet];

            if (ret != null)
            {
                return ret;
            }

            else
            {
                ret = ConfigurationManager.AppSettings[strkey];
                if (ret==null) ret="";
                return ret;
            }

        }

        public static String GetFile(string strfile)
        {
            // gets a file straight into a string
            StreamReader din = File.OpenText(strfile);
            String str = "";
            StringBuilder sb = new StringBuilder();

            while ((str = din.ReadLine()) != null)
                sb.Append(str);
            return sb.ToString();
        }



		/// <summary>
		/// Capitalise the first letter of each word in a string.
		/// </summary>
		/// <param name="input">The text to capitalise.</param>
		/// <returns>A string with the first letter in each word capitalised.</returns>
		public static string CapitaliseString(string input)
		{
			if (!input.Contains(" "))
				return input.Substring(0, 1).ToUpper() + input.Substring(1).ToLower();

			StringBuilder ret = new StringBuilder();

			string[] strings = input.Split(" ".ToCharArray());
			foreach (string item in strings)
				if (item.Length > 0)
					ret.Append(item.Substring(0, 1).ToUpper() + item.Substring(1).ToLower() + " ");

			return ret.ToString().Trim();
		}
    }
}
