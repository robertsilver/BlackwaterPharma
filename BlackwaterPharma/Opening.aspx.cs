using System;
using System.Web.UI.WebControls;

public partial class Opening : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var url = Helper.AppSetting("JSON.Carousel");

        Helper.SaveIPData(Request, "Opening.aspx");

        var carouselData = BlackwaterPharma.Business.Carousel.GetAll(url);
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
