using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Reports;
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Financial
{
    public partial class frmStudentSearch : rRadForm
    {
        public string fName;
        public string LastName;
        public frmStudentSearch()
        {
            InitializeComponent();
           
        }

        private void rBtnPayoff_Click(object sender, EventArgs e)
        {
            
            fName = rTextBox1.Text;
            LastName = rTextBox2.Text;
            if(string.IsNullOrEmpty(fName)|string.IsNullOrEmpty(LastName))
            {
                rMessageBox.ShowWarning("لطفا نام و نام خانوادگی را وارد کنید.");
                DialogResult = DialogResult.None;
                return;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

       
      
    }
}
