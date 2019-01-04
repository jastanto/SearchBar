using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SearchBar
{
    public partial class MainForm : Form
    {
        PopupFileSearchForm pfsf;
        FileSearch fs;

        public MainForm()
        {
            InitializeComponent();
            pfsf = new PopupFileSearchForm();
            pfsf.Visible = false;
            pfsf.Left = this.Left;
            pfsf.Top = this.Top - 50;
            fs = new FileSearch(ref pfsf);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (pfsf.Visible == false)
            {
                pfsf.Visible = true;
                pfsf.Left = this.Left;
                pfsf.Top = this.Top + 60;
                pfsf.Width = this.Width;
                this.Focus();
            }
            fs.lookupFiles(this.textBox1.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Console.Out.WriteLine("Logo was clicked, launch the settings window");
        }
    }
}
