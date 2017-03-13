using BlackwaterPharma.DataAccess;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class RightBarNav : System.Web.UI.UserControl
{
    private string url { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        url = Helper.AppSetting("JSON.RightNavBar");

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
            int Id = 0;
            try
            {
                Id = Convert.ToInt32(imageName.Value);
            }
            catch { }


            RightBarData nav = null;
            try
            {
                nav = BlackwaterPharma.Business.RightBar.GetOneRecord(Id, url);
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
                if (nav.Height.HasValue)
                    img.Height = nav.Height.Value;

                if (nav.Width.HasValue)
                    img.Width = nav.Width.Value;

                img.AlternateText = nav.AltText;
                img.Visible = true;

                nav = null;
            }
        }
        else
            img.Visible = false;
    }

    private List<RightBarData> getRightNavBar()
    {
        List<RightBarData> rightNavBar = null;
        try
        {
            rightNavBar = BlackwaterPharma.Business.RightBar.GetMainMenu(url);
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
            image = Helper.DisplayProductImages(DBImage);
        }
        catch (Exception ex)
        {
        }

        return image;
    }
    #endregion Public methods
}
