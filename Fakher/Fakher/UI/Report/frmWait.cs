using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fakher.UI.Report
{
    public partial class frmWait : Form
    {
        public frmWait()
        {
            InitializeComponent();
            rWaitingBar2.StartWaiting();
            Application.DoEvents();
        }

        public frmWait(string text) : this()
        {
            rLabel1.Text = text;
        }
    }
}
