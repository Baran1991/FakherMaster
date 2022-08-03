using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.Controls
{
    public partial class RegisterSearchBox : UserControl
    {
        public Register SelectedRegister { get; set; }
        public bool OpenUowOnSearch { get; set; }
        public event EventHandler SelectedChanged;

        public RegisterSearchBox()
        {
            InitializeComponent();
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Code" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Student.FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Student.FarsiLastName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام پدر", ObjectProperty = "Student.FarsiFatherName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FarsiFinancialStatusVerboseText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت آموزشی", ObjectProperty = "StatusText" });
        }

        protected void OnSelectedChanged()
        {
            if (SelectedChanged != null)
                SelectedChanged(this, EventArgs.Empty);
        }

        private void Search()
        {
            if(OpenUowOnSearch)
                DbContext.OpenUnitOfWork();

            int code = rTxtCode.GetValue<int>();
            string firstName = radTxtFirstname.Text.Trim();
            string lastName = radTxtLastname.Text.Trim();

            List<Register> result = new List<Register>();
            if (code != 0)
            {
                List<Register> registers = Register.FromCode(code + "");
                foreach (Register register in registers)
                    result.UniqueAdd(register);
            }
            else
            {
                if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                {
                    rMessageBox.ShowError("جستجو فقط می تواند بر اساس (شماره دانشجویی) یا (نام و نام خانوادگی) انجام شود.");
                    return;
                }

                if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                {
                    result.AddRange(Register.Search(firstName, lastName));
                }
                else
                {
                    result.AddRange(Register.SearchByFirstname(firstName));
                    result.AddRange(Register.SearchByLastname(lastName));
                }
            }
            rGridView1.DataBind(result);
        }

        private void rGridView1_SelectedItemChanged(object sender, EventArgs e)
        {
            SelectedRegister = rGridView1.GetSelectedObject<Register>();
            OnSelectedChanged();
        }

        private void rTxtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Search();
        }

        private void radTxtFirstname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Search();
        }

        private void radTxtLastname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Search();
        }

        private void radBtnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}
