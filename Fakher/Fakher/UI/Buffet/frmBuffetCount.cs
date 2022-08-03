using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rComponents;

namespace Fakher.UI.Buffet
{
    public partial class frmBuffetCount : rRadDetailForm
    {
        public int Count
        {
            get { return rTextBox1.GetValue<int>(); }
            set { rTextBox1.Value = value; }
        }

        public frmBuffetCount()
        {
            InitializeComponent();
        }

        private void radBtnOk_Click(object sender, EventArgs e)
        {
            if(Count <= 0)
            {
                rMessageBox.ShowError("تعداد نمی تواند صفر یا منفی باشد.");
                DialogResult = DialogResult.None;
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
