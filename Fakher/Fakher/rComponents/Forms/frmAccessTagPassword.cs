using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rComponents;

namespace Fakher.UI.SystemFeatures
{
    public partial class frmAccessTagPassword : rRadDetailForm
    {
        public string Password { get; set; }

        public frmAccessTagPassword()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Password = rTextBox1.Text;
        }
    }
}
