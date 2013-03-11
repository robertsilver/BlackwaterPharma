using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BPDBEngine;

namespace BPBusinessEngine
{
	public partial class MainMenu
	{
		#region Public, static, methods

		public static List<Tblmainmenu> GetMainMenu(int level)
		{
			List<Tblmainmenu> tabs = new List<Tblmainmenu>();
			TblmainmenuAggregate menuAgg = new TblmainmenuAggregate();
			try
			{
				tabs.AddRange(menuAgg.GetAll(level));
			}
			catch (Exception ex)
			{
				throw new ApplicationException("BPDBEngine.GetMainMenu(): menuAgg.GetAll() returned error: " + ex.Message);
			}
			finally
			{
				if (null != menuAgg)
				{
					menuAgg.Dispose();
					menuAgg = null;
				}
			}

			return tabs;
		}

		#endregion Public, static, methods
	}
}
