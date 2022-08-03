using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace rComponents
{
    public partial class rRadForm : RadForm
    {
        public rRadForm()
        {
            InitializeComponent();
        }

        protected void ShowChildForm(Form frm)
        {
            try
            {
                Application.UseWaitCursor = true;
                Application.DoEvents();

                foreach (Form mdiChild in MdiChildren)
                    if (mdiChild.Text == frm.Text)
                        mdiChild.Close();
                if (IsMdiContainer)
                    frm.MdiParent = this;
                frm.FormBorderStyle = FormBorderStyle.FixedDialog;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.Load += new EventHandler(frm_Load);
                frm.Show();
            }
            finally
            {
                Application.UseWaitCursor = false;
                Application.DoEvents();
            }
        }

        protected void CloseAllForms()
        {
            foreach (Form mdiChild in MdiChildren)
                mdiChild.Close();
            Application.DoEvents();
        }

        protected void frm_Load(object sender, EventArgs e)
        {
            (sender as Form).WindowState = FormWindowState.Maximized;
        }
    }
}
