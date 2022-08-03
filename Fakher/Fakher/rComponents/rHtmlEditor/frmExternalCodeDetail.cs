using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rComponents
{
    public partial class frmExternalCodeDetail : Form
    {
        public string Code
        {
            get { return textBox1.Text; }
        }

        public int CodeWidth
        {
            get
            {
                if (string.IsNullOrEmpty(maskedTextBox1.Text))
                    return 0;
                return Convert.ToInt32(maskedTextBox1.Text);
            }
        }

        public int CodeHeight
        {
            get
            {
                if (string.IsNullOrEmpty(maskedTextBox2.Text))
                    return 0;
                return Convert.ToInt32(maskedTextBox2.Text);
            }
        }

        public frmExternalCodeDetail()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
