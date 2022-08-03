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
using NHibernate;
using rComponents;

namespace Fakher.UI.Students
{
    public partial class frmRegisterAnnouncementWizard : rRadDetailForm
    {
        public frmRegisterAnnouncementWizard()
        {
            InitializeComponent();

            rPageView1.SelectedPage = radPageViewPage1;

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Code", TextAlign = HorizontalAlignment.Center });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Student.FarsiFirstName", TextAlign = HorizontalAlignment.Center });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Student.FarsiLastName", TextAlign = HorizontalAlignment.Center });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "دوره/ترم آموزشی", ObjectProperty = "Period.Name" });
        }

        private List<ColumnMapping> GetGridMappings()
        {
            List<ColumnMapping> mappings = new List<ColumnMapping>();

            mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Student.FarsiFirstName" });
            mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Student.FarsiLastName" });
            mappings.Add(new ColumnMapping { Caption = "نوع ثبت نام", ObjectProperty = "RegisterParticipationText" });

            if (rChkEducationalStatus.Checked)
                mappings.Add(new ColumnMapping { Caption = "آخرین وضعیت آموزشی", ObjectProperty = "Student.GetCurrentEducationalStatus()" });

            if (rChkFinancialStatus.Checked)
                mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "Student.GetCurrentFinancialStatus()" });

            if (rChkWebLogin.Checked)
                mappings.Add(new ColumnMapping { Caption = "شناسه وب سایت", ObjectProperty = "Student.UserInfo.WebLoginText" });

            return mappings;
        }

        private void radBtnSelect_Click(object sender, EventArgs e)
        {
            IList<Register> registers = null;
            if (sectionItemSelector1.SectionItem != null)
            {
                IList<Participate> participates = sectionItemSelector1.SectionItem.GetParticipates();
                registers = participates.GroupBy(x => x.Register).Select(x => x.Key).ToList();
            }
            else if (lessonSelector1.Lesson != null)
            {
                IList<Participate> participates = Participate.GetParticipates(Program.CurrentPeriod, lessonSelector1.Lesson);
                registers = participates.GroupBy(x => x.Register).Select(x => x.Key).ToList();
            }
            else if (majorSelector1.Major != null)
            {
                registers = Register.GetRegisters(Program.CurrentPeriod, majorSelector1.Major);
            }

            if(registers.Count == 0)
            {
                rMessageBox.ShowWarning("دانشجویان را مشخص کنید.");
                return;
            }

            if (rCheckBox1.Checked)
            {
                frmSelect frm = new frmSelect(registers, GetGridMappings().ToArray()) { MultiSelect = true };
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    registers = frm.GetSelectedObjects<Register>().ToList();
                    if(registers.Count > 0)
                        rGridView1.DataBind(registers);
                }
            }
            else
            {
                rGridView1.DataBind(registers);
            }
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            rGridView1.RemoveSelectedRow();
        }

        protected override void AfterValidate()
        {
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(rGridView1.DataSource.Count == 0)
            {
                rMessageBox.ShowWarning("دانشجویان را مشخص کنید.");
                return;
            }
            if(string.IsNullOrEmpty(rHtmlEditor1.BodyHtml))
            {
                rMessageBox.ShowWarning("متن اطلاعیه را مشخص کنید.");
                return;
            }

            ITransaction transaction = DbContext.BeginTransaction();
            try
            {
                foreach (Register register in rGridView1.DataSource)
                {
                    register.Announcement = rHtmlEditor1.BodyHtml;
                    register.AnnouncementEndDate = rDatePicker2.Text;
                    register.AnnouncementEndTime = rTextBox2.Text;
                    register.AnnouncementStartTime = rTextBox1.Text;
                    register.AnnouncementStartDate = rDatePicker1.Text;
                    register.Save();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                transaction.Rollback();
                return;
            }

            rMessageBox.ShowInformation("انتساب اطلاعیه با موفقیت انجام شد.");
            Close();
        }
    }
}
