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

namespace Fakher.UI.Ministerial
{
    public partial class frmTeachingContractList : rRadForm
    {
        public frmTeachingContractList()
        {
            InitializeComponent();

            rGridComboBox1.Columns.Add("نام", "نام", "FarsiFullname");
//            rGridComboBox1.Columns.Add("نام خانوادگی", "نام خانوادگی", "FarsiLastName");

//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کد", ObjectProperty = "Id" });
//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ترم", ObjectProperty = "Period.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نوع قرارداد", ObjectProperty = "PaymentSystemText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ شروع", ObjectProperty = "StartDate" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ پایان", ObjectProperty = "EndDate" });

            rGridComboBox1.DataSource = Teacher.GetActiveTeachers();
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Teacher teacher = rGridComboBox1.GetValue<Teacher>();
            if (teacher == null)
                return;

            TeachingContract contract = new TeachingContract
                                            {
                                                Staff = teacher,
//                                                Period = Program.CurrentPeriod,
                                                StartDate = Program.CurrentPeriod.StartDate,
                                                EndDate = Program.CurrentPeriod.EndDate
                                            };
            frmTeachingContractDetail frm = new frmTeachingContractDetail(contract);
            if(!frm.ProcessObject())
                return;
            contract.Save();
            rGridView1.Insert(contract);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            TeachingContract contract = rGridView1.GetSelectedObject<TeachingContract>();
            contract.RefreshEntity();

            frmTeachingContractDetail frm = new frmTeachingContractDetail(contract);
            if (!frm.ProcessObject())
                return;
            contract.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            TeachingContract contract = rGridView1.GetSelectedObject<TeachingContract>();
            contract.Staff.Contracts.Remove(contract);
            contract.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Teacher teacher = rGridComboBox1.GetValue<Teacher>();
            rGridView1.Clear();
            if (teacher == null)
                return;
            teacher.RefreshEntity();
            rGridView1.DataBind(teacher.Contracts);
        }
    }
}
