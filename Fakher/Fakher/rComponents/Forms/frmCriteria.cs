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
    public partial class frmCriteria : rRadForm
    {
        private Dictionary<string, string> mData;

        public IList<Criteria> Criterias
        {
            get
            {
                List<Criteria> criterias = new List<Criteria>();
                foreach (Criteria criteria in rGridView1.DataSource)
                {
                    criterias.Add(criteria);
                }
                return criterias;
            }
        }

        public frmCriteria(Dictionary<string, string> data)
        {
            InitializeComponent();
            mData = data;

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شرط", ObjectProperty = "FarsiText" });
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Criteria criteria = new Criteria();
            frmCriteriaDetail frm = new frmCriteriaDetail(criteria, mData);
            if (!frm.ProcessObject())
                return;

            rGridView1.Insert(criteria);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rGridView1.DataSource.Count == 0)
            {
                rMessageBox.ShowWarning("حداقل یک شرط را مشخص کنید.");
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }

}
