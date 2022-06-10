using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication2022
{

    public static class Bookshelf
    {
        static readonly string ROOT = HttpRuntime.AppDomainAppPath;

        public static string[] ListBooks()
        {
            List<string> books = new List<string>();
            foreach (string path in Directory.GetFiles(ROOT + "books").Where(f => f.EndsWith(".md")))
            {
                string name = path.Substring(path.LastIndexOf("\\") + 1);
                books.Add(name.Substring(0, name.Length - 3));
            }
            return books.ToArray();
        }
    }

    public class Book
    {
        static readonly string ROOT = HttpRuntime.AppDomainAppPath;

        string path { get; set; }
        private List<string> tableOfContent = new List<string>();
        private Dictionary<string, string> chapters = new Dictionary<string, string>();

        public static string GetDisplayName(string rawName)
        {
            return rawName.Replace('_', ' ');
        }

        public Book(string name)
        {
            path = ROOT + "books/" + name + ".md";

            if (!File.Exists(path))
            {
                throw new Exception("Book not found");
            }

            bool isToC = false;

            foreach (string line in File.ReadLines(path))
            {
                if (line.Equals("## Table of Contents"))
                {
                    isToC = true;
                    continue;
                } else if (isToC && line.StartsWith("## ")) {
                    // end of toc
                    isToC = false;
                    break;
                }

                if (isToC && line.Length > 2)
                {
                    // ToC lines are of format:
                    // * Chapter 1
                    string title = line.Substring(2);
                    chapters.Add(title, null);
                    tableOfContent.Add(title);
                }
            }
        }

        public string GetChapterTitle(int index)
        {
            string title;
            if (tableOfContent.Count > index && index >= 0)
            {
                title = tableOfContent[index];
            } else
            {
                return null;
            }
            return title;
        }

        public int GetChapterIndex(string chapter)
        {
            return tableOfContent.IndexOf(chapter);
        }

        public int GetTotalChapters()
        {
            return tableOfContent.Count;
        }

        public String[] GetChapters()
        {
            return tableOfContent.ToArray();
        }

        public string GetChapter(string chapter)
        {
            string text = null;
            chapters.TryGetValue(chapter, out text);

            if (text == null)
            {
                bool isText = false;

                foreach (string line in File.ReadLines(path))
                {
                    if (line.Equals("## " + chapter))
                    {
                        isText = true;
                        continue;
                    }
                    else if (isText && line.StartsWith("## "))
                    {
                        // End of text
                        break;
                    }

                    if (isText)
                    {
                        text += line + "\n";
                    }
                }
            }

            return text;
        }
    }
}