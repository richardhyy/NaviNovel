using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2022
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (string book in Bookshelf.ListBooks())
            {
                LabelBookList.Text += @"<div class=""col""><a class=""btn btn-light"" role=""button"" href=""ToC.aspx?book=" + book + @""">" + Book.GetDisplayName(book) + "</a></div>";
            }
        }
    }
}