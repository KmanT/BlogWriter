using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWriter
{
    public class BlogEntry
    {
        private DateTime entryTime;
        private string title;
        private List<string> paragraphs;

        /// <summary>
        /// Defines a blog entry to be written to an html file. This html will
        /// be parsed by a php file and placed into the blog section of my
        /// website
        /// </summary>
        /// <param name="title"></param>
        /// <param name="p"></param>
        public BlogEntry(string title, string p)
        {
            this.entryTime = DateTime.Now;
            this.title = title;
            this.paragraphs = new List<string>();
            convertToParagraphs(p);
        }

        /// <summary>
        /// This will be the h1 element of the page.
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
        }

        /// <summary>
        /// A list of paragraphs to be printed to <p> tags
        /// </summary>
        public List<string> Paragraphs
        {
            get
            {
                return paragraphs;
            }
        }

        /// <summary>
        /// Converts the text from the large text box into different paragraph
        /// segments and appends them to the paragraph list.
        /// </summary>
        /// <param name="textBlock">The text contents to be converted to 
        /// a paragraph list</param>
        public void convertToParagraphs(string textBlock)
        {
            List<string> paraList = textBlock.Split('\n').ToList<string>();
            foreach(string p in paraList)
            {
                p.Trim('\n');
                paragraphs.Add($"\t<p>{p}</p>\n");
            }
        }

        override public string ToString()
        {
            string blogString = "";
            blogString = $"<h1>{title}</h1>\n"
                + $"<p id=\"subtitle\">{entryTime}</p>\n<article>\n";

            foreach(string p in paragraphs)
            {
                blogString += p;
            }
            blogString += "</article>";
            return blogString;
        }

    }
}
