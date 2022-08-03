using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Store
{
    public partial class frmUseEdit : rRadDetailForm
    {
       public Use selectedUse;
        public frmUseEdit(Use use)
        {
            InitializeComponent();
            lblBookName.Text = use.EducationalTool.Name;
            rTxtCount.Text = use.count.ToString();
            selectedUse = use;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            selectedUse.count =int.Parse( rTxtCount.Text);
            DialogResult = DialogResult.OK;
        }

      
    }
}
