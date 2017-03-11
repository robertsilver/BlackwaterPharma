using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BPDBEngine;
using BlackwaterPharma.DataAccess;

public partial class Pharma : System.Web.UI.MasterPage
{
    private string url { get; set; }

	private class PageNames
	{
		public static string Home = "Opening.aspx";
		public static string Sitemap = "Sitemap.aspx";
	}
	protected override void OnInit(EventArgs e)
	{
        url = Helper.AppSetting("JSON.MainMenu");

		base.OnInit(e);

		#region Display the main bullet menu
		this.displayMainBulletMenu(this.getAndShowTabs(-1));
		#endregion Display the main bullet menu

		int selectedMainMenuTab = -1, selectedSubMenuTab = -1, clickedMainMenuTab = -1;
		#region Get the number of the main menu tab
		try
		{
			selectedMainMenuTab = Convert.ToInt32(Session["SelectedMainMenuTab"]);
		}
		catch { }
		#endregion Get the number of the main menu tab

		#region Get the number of the sub menu tab
		try
		{
			selectedSubMenuTab = Convert.ToInt32(Session["SelectedSubMenuTab"]);
		}
		catch { }
		#endregion Get the number of the sub menu tab

		#region Get the position of main menu tab, that was clicked
		try
		{
			clickedMainMenuTab = Convert.ToInt32(Session["ClickedMainMenuTab"]);
		}
		catch { }
		#endregion Get the position of main menu tab, that was clicked

		if (selectedSubMenuTab != -1)
		{
			bulSubMenu.DataTextField = "Text";
			bulSubMenu.DataValueField = "URL";
			// Need to add one as the index is zero based.
			bulSubMenu.DataSource = this.getAndShowTabs(selectedSubMenuTab);
			bulSubMenu.DataBind();
		}

		#region Make one of the tabs go white
		if (null != bulMainMenu && bulMainMenu.Items.Count > 0 && clickedMainMenuTab >= 0)
			bulMainMenu.Items[clickedMainMenuTab].Attributes.Add("class", "current");
		#endregion Make one of the tabs go white

		#region Setup the links within the footer

		// Could've hardcoded the links, but when testing it would go
		// to the live site, which didn't contain the pages.
		aHome.HRef = Helper.AppSetting("Website") + "/" + PageNames.Home;
		aSitemap.HRef = Helper.AppSetting("Website") + "/" + PageNames.Sitemap;
		#endregion Setup the links within the footer
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Page.IsPostBack) return;
	}

	/// <summary>
	/// Displays the main bullet menu
	/// </summary>
	/// <param name="menus"></param>
	private void displayMainBulletMenu(List<MainMenuData> menus)
	{
		if (null == menus)
		{
			bulMainMenu.Visible = false;
			return;
		}

		bulMainMenu.Items.Clear();
		int count = 0;
        foreach (MainMenuData m in menus)
		{
			bulMainMenu.Items.Add(new ListItem(m.Text, m.URL + "|" + m.ParentId + "|" + m.MenuId + "|" + count));
			count++;
		}

		bulMainMenu.Visible = true;
	}

	protected void bulMainMenu_OnClick(object sender, BulletedListEventArgs e)
	{
		string requestedURL = string.Empty;
		
		ListItem mainMenu = bulMainMenu.Items[e.Index];
		if (null != mainMenu)
		{
			string[] bulletMenu = mainMenu.Value.Split('|');

			if (null != bulletMenu && bulletMenu.Length == 4)
			{
				requestedURL = bulletMenu[0];
				Session["SelectedMainMenuTab"] = bulletMenu[1];
				Session["SelectedSubMenuTab"] = bulletMenu[2];
				Session["ClickedMainMenuTab"] = bulletMenu[3];
			}
			mainMenu = null;
		}

		if (string.Empty != requestedURL)
			Response.Redirect(requestedURL, true);
	}

	protected void bulSubMenu_OnClick(object sender, BulletedListEventArgs e)
	{
		Response.Redirect(bulSubMenu.Items[e.Index].Value, true);
	}

	protected void LinkButton1_Command(object sender, CommandEventArgs e)
	{
	}

	#region Private methods

    private List<MainMenuData> getAndShowTabs(int level)
	{
        var tabs = new List<MainMenuData>();

		try
		{
            tabs = BlackwaterPharma.Business.MainMenu.GetMainMenu(level, url);
		}
		catch (Exception ex)
		{
		}

		return tabs;
	}

	#endregion Private methods
}
