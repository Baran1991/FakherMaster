using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using rComponents;
using rComponents;

namespace rComponents
{
    public partial class frmSelect : rRadForm
    {
        private IEnumerable mData;

        public object SelectedObject { get; set; }
        public bool MultiSelect
        {
            get { return rGridView1.CheckBoxes; }
            set { rGridView1.CheckBoxes = value; }
        }

        public frmSelect(IEnumerable data, params ColumnMapping[] columnMappings)
        {
            InitializeComponent();
            mData = data;
           
            rGridView1.Clear();
            rGridView1.Mappings.AddRange(columnMappings);
        }
        public frmSelect(string text, IEnumerable data, params ColumnMapping[] columnMappings)
            : this(data, columnMappings)
        {
            rLabel1.Text = text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(MultiSelect && rGridView1.GetCheckedObjects<object>().Count == 0)
            {
                rMessageBox.ShowWarning("حداقل یک آیتم از لیست را انتخاب کنید و تیک بزنید.");
                DialogResult = DialogResult.None;
                return;
            }

            if (!MultiSelect && !rGridView1.IsItemSelected)
            {
                rMessageBox.ShowWarning("یک آیتم از لیست را انتخاب کنید.");
                DialogResult = DialogResult.None;
                return;
            }

            SelectedObject = rGridView1.GetSelectedObject();
            Close();
        }

        private void rGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                DialogResult = DialogResult.OK;
                btnOk_Click(sender, EventArgs.Empty);
            }
        }

        public T GetSelectedObject<T>() where T : class
        {
            return rGridView1.GetSelectedObject<T>();
        }

        public List<T> GetSelectedObjects<T>() where T : class
        {
            return rGridView1.GetCheckedObjects<T>();
        }

        private void frmSelect_Load(object sender, EventArgs e)
        {
            rGridView1.DataBind(mData);
        }

        public void CheckAll()
        {
            rGridView1.CheckAll();
        }

        public void UnCheckAll()
        {
            rGridView1.UnCheckAll();
        }
    }
}
