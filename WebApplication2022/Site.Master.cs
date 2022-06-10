using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2022
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LastReadBook"] != null)
            {
                Label1.Text = @"
                    <li class=""nav-item"">
                          <a class=""nav-link"" href=""" + Reader.UrlOf(Session["LastReadBook"].ToString(), Session["LastReadChapter"].ToString()) + @""">Continue Reading: " + Book.GetDisplayName(Session["LastReadBook"].ToString()) + @"</a>
                    </li>";
            }
        }
    }
}