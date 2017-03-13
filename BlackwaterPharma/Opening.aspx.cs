using BlackwaterPharma.DataAccess;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Opening : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var url = Helper.AppSetting("JSON.Carousel");

        Helper.SaveIPData(Request, "Opening.aspx");

        var carouselData = new List<CarouselData>();

        try
        {
            carouselData = BlackwaterPharma.Business.Carousel.GetAll(url);
        }
        catch (Exception ex)
        {
            Helper.SaveError("Opening.aspx.cs.Page_Load()", ex.Message);
        }
        
        Carousel.DataSource = carouselData;
        Carousel.DataBind();
    }

    protected void Carousel_OnItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var carouselText = (Repeater)e.Item.FindControl("CarouselText");
            carouselText.DataSource = ((BlackwaterPharma.DataAccess.CarouselData)(e.Item.DataItem)).CarouselText;
            carouselText.DataBind();
        }
    }
}
