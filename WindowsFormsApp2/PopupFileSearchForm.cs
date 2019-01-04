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
    public partial class PopupFileSearchForm : Form
    {
        public ImageList imageList1 { get; set; }
        public PopupFileSearchForm()
        {
            imageList1 = new ImageList();
            InitializeComponent();
            ListViewFileSearch.SmallImageList = imageList1;
        }
    }
}
