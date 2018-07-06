using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocEntry.formas
{
    public partial class Viewer : Form
    {
        public Viewer()
        {
            InitializeComponent();
        }
        public WebBrowser getBrowser()
        {
            return webBrowser1;
        }
    }
}

   
