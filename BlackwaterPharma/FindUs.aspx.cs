﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
d
public partial class FindUs : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Helper.SaveIPData(Request, "FindUs.aspx");
	}
}
