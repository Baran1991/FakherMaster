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

namespace Fakher.UI.Educational
{
    public partial class frmPeriodsList : rRadForm
    {
        public frmPeriodsList()
        {
            InitializeComponent();

            rGridComboBox1.Columns.Add("نام", "نام", "Name");

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام دوره", ObjectProperty = "Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کد ترم", ObjectProperty = "Code" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ شروع", ObjectProperty = "StartDate" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ پایان", ObjectProperty = "EndDate" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "دپارتمان", ObjectProperty = "Department.Name" });
            
            rGridComboBox1.DataSource = DbContext.GetAllEntities<Department>();
            if (Program.CurrentDepartment != null)
                rGridComboBox1.Value = Program.CurrentDepartment;
        }
        private void rGridView1_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
        }
            private void rGridView1_Add(object sender, EventArgs e)
        {
            Department department = rGridComboBox1.GetValue<Department>();
            EducationalPeriod period = new EducationalPeriod { Department = department };
            period.Code = EducationalPeriod.GenerateCode(department);
            frmEducationalPeriodDetail frm = new frmEducationalPeriodDetail(period);
            if(frm.ShowDialog(this) != DialogResult.OK)
                return;
            period.Save();
            rGridView1.Insert(period);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            EducationalPeriod period = rGridView1.GetSelectedObject<EducationalPeriod>();
            frmEducationalPeriodDetail frm = new frmEducationalPeriodDetail(period);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            period.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            EducationalPeriod period = rGridView1.GetSelectedObject<EducationalPeriod>();
            period.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Department department = rGridComboBox1.GetValue<Department>();
            rGridView1.DataBind(department.EducationalPeriods.OrderByDescending(x => x.Id));
        }
    }
}
