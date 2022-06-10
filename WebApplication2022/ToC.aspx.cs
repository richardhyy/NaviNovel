using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2022
{
    public partial class ToC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Book book;
            string bookName = Request.QueryString["book"];

            if (bookName == null)
            {
                Response.Redirect("/");
                return;
            }

            try
            {
                book = new Book(bookName);
            }
            catch (Exception ex)
            {
                Response.Redirect("/");
                return;
            }
            
            string toc = "<ol>";
            string[] chapters = book.GetChapters();
            for (int i = 0; i < chapters.Length; i++)
            {
                toc += $"<li><a href={Reader.UrlOf(bookName, chapters[i])}>{chapters[i]}</a></li>";
            }
            LabelToC.Text = toc + "</ol>";
        }
    }
}