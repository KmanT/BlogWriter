using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlogWriter
{
    public partial class Form1 : Form
    {
        string blogDirectory = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine(blogDirectory);
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string textBlock = txtBlock.Text;
            BlogEntry blog = new BlogEntry(title, textBlock);
            Console.WriteLine(blog.ToString());
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            blogDirectory = ChooseFolder();
            Console.WriteLine(blogDirectory);
        }

        private string ChooseFolder()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog1.SelectedPath;
            }

            return null;
        }
    }
}
