using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core;
using Fakher.Core.DomainModel;
using Fakher.Reports;
using Fakher.UI.Reception;
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Store
{
    public partial class frmBorrow : rRadForm
    {
        public frmBorrow(Fakher.Core.DomainModel.Person person)
        {
            InitializeComponent();

            SetProcessingObject(person);

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "EducationalTool.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "موجودی", ObjectProperty = "EducationalTool.Remainder" });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "EducationalTool.Name" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ امانت", ObjectProperty = "Date" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ بازگشت", ObjectProperty = "ReturnDate" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "ReturnStatusText" });

            rGridCmbGroup.Columns.Add("نام", "نام", "Name");

            if(person is Student)
            {
                Student student = person as Student;
                departmentSelector1.Databind(student.GetRegisteredDepartments());
            }
            else
            {
                departmentSelector1.Databind(Department.GetDepartments());
            }
            rGridView2.DataBind(person.GetUses(UseType.Borrow));
        }

        private void rGridView1_Edit_1(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();
            GroupTool groupTool = rGridView1.GetSelectedObject<GroupTool>();

            try
            {
                groupTool.RefreshEntity();
                if (!person.CanUse(groupTool, UseType.Borrow))
                    if (rMessageBox.ShowQuestion("این کتاب قبلا به این شخص امانت داده شده است. از امانت مجدد آن اطمینان دارید؟") != DialogResult.Yes)
                        return;

                Use use = groupTool.EducationalTool.CreateUse(person, UseType.Borrow, true);
                use.BatchNumber = Use.GetNextBatchNumber();
                person.SubmitUseAndSave(use);

                rGridView2.Insert(use);
                rGridView1.UpdateGridView();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void departmentSelector1_SelectedChanged(object sender, EventArgs e)
        {
            Department department = departmentSelector1.Department;
            Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();
            majorSelector1.rGridComboBox1.Clear();

            if (department == null)
                return;

            if(person is Student)
            {
                Student student = person as Student;
                IQueryable<Major> queryable = student.GetRegisteredMajors();
                IQueryable<Major> registeredMajors = queryable.Where(x=>x.Department.Id == department.Id);
                majorSelector1.Databind(registeredMajors);
            }
            else
                majorSelector1.Databind(department.Majors);
        }

        private void rGridView2_Add(object sender, EventArgs e)
        {
            //چاپ رسید
            Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();
            List<Use> uses = person.GetUses(UseType.Borrow).Where(x => !x.IsReturned).ToList();

            frmStoreSetting frm = new frmStoreSetting(SettingKeys.BorrowReceiptDescription);
            frm.ShowDialog();

            rptBorrowReceipt rpt = new rptBorrowReceipt();
            rpt.DataSource = uses;
            frmReportViewer viewer = new frmReportViewer(rpt) { AutoPrint = true };
            viewer.ShowDialog(this);
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();
            Use use = rGridView2.GetSelectedObject<Use>();
            if(use.IsReturned)
            {
                rMessageBox.ShowInformation("بازگشت قبلا ثبت شده است.");
                return;
            }
            if (rMessageBox.ShowQuestion(string.Format("آیا بازگشت کتاب {0} به تاریخ {1} ثبت گردد؟", use.EducationalTool.Name, PersianDate.Today))
                != DialogResult.Yes)
                return;

            person.SubmitReturnAndSave(use);
//            use.ReturnDate = PersianDate.Today;
//            use.Save();
            rGridView2.UpdateGridView();
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();
            List<Use> uses = person.GetUses(UseType.Borrow).Where(x => x.IsReturned).ToList();

            frmStoreSetting frm = new frmStoreSetting(SettingKeys.BorrowReturnReceiptDescription);
            frm.ShowDialog();

            rptReturnReceipt rpt = new rptReturnReceipt();
            rpt.DataSource = uses;
            frmReportViewer viewer = new frmReportViewer(rpt) { AutoPrint = true };
            viewer.ShowDialog(this);
        }

        private void frmBorrow_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void majorSelector1_SelectedChanged(object sender, EventArgs e)
        {
            if (majorSelector1.Major == null)
                return;
            rGridCmbGroup.DataSource = majorSelector1.Major.ToolGroups;
        }

        private void rGridCmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            EducationalToolGroup toolGroup = rGridCmbGroup.GetValue<EducationalToolGroup>();
            Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();

            rGridView1.Clear();
            if (toolGroup == null)
                return;

            rGridView1.DataBind(toolGroup.GetBorrowGroupTools());
//            rGridView1.DataBind(toolGroup.GroupTools);
        }
    }
}
