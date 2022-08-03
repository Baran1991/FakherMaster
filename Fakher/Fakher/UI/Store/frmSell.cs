using System;
using System.Collections;
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

namespace Fakher.UI.Store
{
    public partial class frmSell : rRadForm
    {
        public frmSell(Fakher.Core.DomainModel.Person person)
        {
            InitializeComponent();

            SetProcessingObject(person);

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "EducationalTool.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "موجودی", ObjectProperty = "EducationalTool.Remainder" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "قیمت", ObjectProperty = "EducationalTool.LastSellPrice", Type = ColumnType.GroupedNumber });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "EducationalTool.Name" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ خرید", ObjectProperty = "Date" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "قیمت", ObjectProperty = "UsePrice", Type = ColumnType.Money, AggregateSummary = AggregateSummary.Sum });
            rGridView2.CustomButtons.Add(new rGridViewButton { Text = "چاپ فاکتور", VisibleOnSelect = true, Position = rGridViewButtonPosition.Before });
            rGridView2.CustomButtonClick += rGridView2_CustomButtonClick;

            rGridView3.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "EducationalTool.Name" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "تعداد", ObjectProperty = "count", AggregateSummary = AggregateSummary.Sum });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "قیمت", ObjectProperty = "UsePrice_t", Type = ColumnType.Money, AggregateSummary = AggregateSummary.Sum });

            rGridCmbGroup.Columns.Add("نام", "نام", "Name");

            if (person is Student)
            {
                Student student = person as Student;
                departmentSelector1.Databind(student.GetRegisteredDepartments());
            }
            else
            {
                departmentSelector1.Databind(Department.GetDepartments());
            }
            rGridView2.DataBind(person.GetUses(UseType.Buy));
        }
        private void rGridView2_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            var items = rGridView2.GetCheckedObjects<Use>();
            if (e.ButtonIndex == 0)
            {
                rptSellReceipts rpt = new rptSellReceipts();
                long NextFactorNo = Use.GetNextFactorNo();
                IList uses = rGridView2.DataSource;
                foreach (Use use in uses)
                {
                    use.FactorNo = NextFactorNo;
                    use.Save();
                }
                rpt.fItems = items;
                rpt.ReportName = "فاکتور فروش به شماره فاکتور  " +items[0].FactorNo+ "   شعبه : ";
                rpt.PrepareDataset(null);
                rpt.Apply(null);    
                frmReportViewer viewer = new frmReportViewer(rpt) { AutoPrint = true };
                viewer.ShowDialog(this);
            }
        }
        private void rGridView1_Edit_1(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();
            GroupTool groupTool = rGridView1.GetSelectedObject<GroupTool>();
            try
            {
                groupTool.RefreshEntity();
                if (!person.CanUse(groupTool, UseType.Buy))
                    if (rMessageBox.ShowQuestion("این کتاب قبلا به این شخص فروخته شده است. از فروش مجدد آن اطمینان دارید؟") != DialogResult.Yes)
                        return;
                Use use = groupTool.EducationalTool.CreateUse(person, UseType.Buy, true);
                use.count = 1;
                rGridView3.Insert(use);
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
            if (person is Student)
            {
                Student student = person as Student;
                IQueryable<Major> queryable = student.GetRegisteredMajors();
                IQueryable<Major> registeredMajors = queryable.Where(x => x.Department.Id == department.Id);
                majorSelector1.Databind(registeredMajors);
            }
            else
                majorSelector1.Databind(department.Majors);
        }
        private void rGridView3_Add(object sender, EventArgs e)
        {
            Core.DomainModel.Person person = GetProcessingObject<Core.DomainModel.Person>();
            int batchNumber = Use.GetNextBatchNumber();
            IList uses = rGridView3.DataSource;
            foreach (Use use in uses)
            {
                use.BatchNumber = batchNumber;
                if (use.count > 0)
                    for (int i = 0; i < use.count; i++)
                    {
                        person.SubmitUseAndSave(use);

                        Program.CurrentEmployee.RegisterTransactionFor(use);

                        rGridView2.Insert(use);
                    }
            }
            rGridView3.Clear();
            rGridView1.UpdateGridView();

            if (rCheckBox1.Checked)
            {
                rptSellReceipt rpt = new rptSellReceipt();
                rpt.DataSource = uses;
                
                frmReportViewer viewer = new frmReportViewer(rpt) { AutoPrint = true };
                viewer.ShowDialog(this);
            }
        }
        private void rGridView3_Edit(object sender, EventArgs e)
        {
            var selectedUse = rGridView3.GetSelectedObject<Use>();
            var frm = new frmUseEdit(selectedUse);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                rGridView3.RemoveSelectedRow();
                rGridView3.Insert(frm.selectedUse);
            }
        }
        private void rGridView3_Delete(object sender, EventArgs e)
        {
            rGridView3.RemoveSelectedRow();
        }

        private void frmSell_Load(object sender, EventArgs e)
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

            rGridView1.DataBind(toolGroup.GetSellGroupTools());
        }
    }
}
