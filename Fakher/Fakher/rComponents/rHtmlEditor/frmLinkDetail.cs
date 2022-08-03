using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rComponents;

namespace rComponents
{
    public partial class frmLinkDetail : rRadDetailForm
    {
        private string mHref;
        public frmLinkDetail(HtmlElement element)
        {
            InitializeComponent();
            SetProcessingObject(element);
            mHref = element.GetAttribute("href");

            rTextBox1.Text = mHref;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            HtmlElement element = GetProcessingObject<HtmlElement>();
            element.SetAttribute("href", rTextBox1.Text.Trim());
            element.SetAttribute("target", "\"_blank\"");
        }
    }
}
