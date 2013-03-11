using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BPDBEngine;

namespace BPBusinessEngine
{
	#region Public, static, methods
	public class RightNavBar
	{
		public static List<Tblrightnavbar> GetMainMenu()
		{
			List<Tblrightnavbar> navBar = new List<Tblrightnavbar>();
			TblrightnavbarAggregate navAgg = new TblrightnavbarAggregate();
			try
			{
				navBar.AddRange(navAgg.GetAllForHomePage());
			}
			catch (Exception ex)
			{
				Utility.SaveEvents("RightBarNav.GetMainMenu", "navBar.AddRange(navAgg.GetAllForHomePage()) returned error: " + ex.Message, "Error");
				throw new ApplicationException("There was a problem retrieving the right navigation.  Error: " + ex.Message);
			}
			finally
			{
				if (null != navAgg)
				{
					navAgg.Dispose();
					navAgg = null;
				}
			}

			return navBar;
		}

		public static Tblrightnavbar GetOneRecord(int ID)
		{
			TblrightnavbarAggregate navAgg = new TblrightnavbarAggregate();
			Tblrightnavbar navBar = null;
			try
			{
				navBar = navAgg.GetSingle(ID);
			}
			catch (Exception ex)
			{
				Utility.SaveEvents("RightBarNav.GetOneRecord", "navAgg.GetSingle() returned error: " + ex.Message, "Error");
				throw new ApplicationException("There was a problem retrieving the right navigation.  Error: " + ex.Message);
			}
			finally
			{
				if (null != navAgg)
				{
					navAgg.Dispose();
					navAgg = null;
				}
			}

			return navBar;
		}
	}
	#endregion Public, static, methods
}
