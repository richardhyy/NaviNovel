using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2022
{
    public partial class Reader : System.Web.UI.Page
    {
        string bookName { get; set; }
        string chapter { get; set; }

        string prevChapter { get; set; }

        string nextChapter { get; set; }

        Book book;

        public static string UrlOf(string book, string chapter)
        {
            return $"Reader.aspx?book={book}&chapter={chapter}";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            bookName = Request.QueryString["book"];
            chapter = Request.QueryString["chapter"];

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
                ShowError(ex.Message);
                return;
            }
            
            if (chapter == null)
            {
                chapter = book.GetChapterTitle(0);
            }

            LoadChapter();

            // Load ToC
            string toc = "<ol>";
            string[] chapters = book.GetChapters();
            for (int i = 0; i < chapters.Length; i++)
            {
                toc += $"<li><a href={UrlOf(bookName, chapters[i])}>{chapters[i]}</a></li>";
            }
            TableOfContentsLabel.Text = toc + "</ol>";
            
            // Set last reading info
            Session["LastReadBook"] = bookName;
            Session["LastReadChapter"] = chapter;
        }

        private void ShowError(string message)
        {
            AlertPanel.Visible = true;
            ALertLabel.Text = message;
        }

        private void LoadChapter()
        {
            string text = book.GetChapter(chapter);
            if (text == null || text.Equals("")) {
                ShowError("Failed loading chapter");
                return;
            }

            ContentLabel.Text = "<p>" + text.Replace("\n", "</p><p>") + "</p>";

            int index = book.GetChapterIndex(chapter);
            int total = book.GetTotalChapters();

            TitleLabel.Text = chapter.ToLower().StartsWith("chapter") ? chapter : $"Chapter {index + 1}: {chapter}";

            if (index < total - 1)
            {
                NextChapterButton.Enabled = true;
                nextChapter = book.GetChapterTitle(index + 1);
                NextChapterButton.Text = nextChapter + " >";
            }
            else
            {
                NextChapterButton.Enabled = false;
                nextChapter = null;
                NextChapterButton.Text = "End of the Book";
            }

            if (index > 0)
            {
                PreviousChapterButton.Enabled = true;
                prevChapter = book.GetChapterTitle(index - 1);
                PreviousChapterButton.Text = "< " + book.GetChapterTitle(index - 1);
            }
            else
            {
                PreviousChapterButton.Enabled = false;
                prevChapter = null;
                PreviousChapterButton.Text = "No Previous Chapter";
            }
        }

        protected void PreviousChapterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(UrlOf(bookName, prevChapter));
        }

        protected void NextChapterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(UrlOf(bookName, nextChapter));
        }
    }
}