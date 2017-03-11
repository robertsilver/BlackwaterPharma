using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BPBusinessEngine;
using BPDBEngine;

public partial class RightBarNav : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		repRightNavBar.DataSource = this.getRightNavBar();
		repRightNavBar.DataBind();
	}

	protected void repRightNavBar_OnItemDataBound(Object Sender, RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item)
		{
			Image i = (Image)e.Item.FindControl("imgURL");
			HiddenField hidI = (HiddenField)e.Item.FindControl("hidImg");
			HyperLink hypL = (HyperLink)e.Item.FindControl("hypLink");
			if (null != i && null != hidI)
			{
				this.showOrHideControls(i, hidI, hypL);
				hidI.Dispose();
				hidI = null;
				i.Dispose();
				i = null;
			}
		}
		else if (e.Item.ItemType == ListItemType.AlternatingItem)
		{
			Image i = (Image)e.Item.FindControl("imgURLAlternate");
			HiddenField hidI = (HiddenField)e.Item.FindControl("hidImgAlternate");
			HyperLink hypL = (HyperLink)e.Item.FindControl("hypAltLink");
			if (null != i && null != hidI)
			{
				this.showOrHideControls(i, hidI, hypL);
				hidI.Dispose();
				hidI = null;
				i.Dispose();
				i = null;
			}
		}
	}

	#region Private methods

	private void showOrHideControls(Image img, HiddenField imageName, HyperLink hypLink)
	{
		if (string.Empty != imageName.Value)
		{
			int ID = 0;
			try
			{
				ID = Convert.ToInt32(imageName.Value);
			}
			catch { }

			Tblrightnavbar nav = null;
			try
			{
				nav = BPBusinessEngine.RightNavBar.GetOneRecord(ID);
			}
			catch (Exception ex)
			{
			}

			if (null != hypLink && string.Empty != nav.Url)
				hypLink.NavigateUrl = nav.Url;

			if (null != nav)
			{
				img.ImageUrl = this.GetImageURL(nav.Image);
				img.ImageAlign = ImageAlign.Right;
				img.Height = nav.Height;
				img.Width = nav.Width;
				img.AlternateText = nav.Alttext;
				img.Visible = true;

				nav.Dispose();
				nav = null;
			}
		}
		else
			img.Visible = false;
	}

	private List<Tblrightnavbar> getRightNavBar()
	{
		List<Tblrightnavbar> rightNavBar = null;
		try
		{
			rightNavBar = BPBusinessEngine.RightNavBar.GetMainMenu();
		}
		catch (Exception ex)
		{
		}

		return rightNavBar;
	}

	#endregion Private methods

	#region Public methods

	public string GetImageURL(string DBImage)
	{
		if (string.Empty == DBImage)
			return string.Empty;

		string image = string.Empty;
		try
		{
			image = BPBusinessEngine.Utility.DisplayProductImages(DBImage);
		}
		catch (Exception ex)
		{
		}

		return image;
	}
	#endregion Public methods
}
