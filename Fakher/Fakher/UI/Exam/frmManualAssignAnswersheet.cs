using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Exam
{
    public partial class frmManualAssignAnswersheet : rRadForm
    {
        public frmManualAssignAnswersheet()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Register.Code" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Register.Student.FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Register.Student.FarsiLastName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "SectionItem.Item.Lesson.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کلاس", ObjectProperty = "SectionItem.Section.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "Register.Student.FinancialStatusFarsiText" });
        }

        private void sectionItemSelector1_SelectedChanged(object sender, EventArgs e)
        {
            if(sectionItemSelector1.SectionItem == null)
                return;
            rGridView1.DataBind(sectionItemSelector1.SectionItem.GetParticipates());
        }

        private void radBtnAssign_Click(object sender, EventArgs e)
        {
            Participate participate = rGridView1.GetSelectedObject<Participate>();
            int code = rTextBox1.GetValue<int>();

            if(participate == null)
            {
                rMessageBox.ShowError("یک دانشجو را از لیست انتخاب کنید.");
                return;
            }
            ExamParticipate examParticipate = ExamParticipate.GetExamParticipate(code);
            if(examParticipate == null)
            {
                rMessageBox.ShowError("پاسخنامه ای با این کد شناسه وجود ندارد.");
                return;
            }

            examParticipate.Register = participate.Register;
            examParticipate.Save();
            rMessageBox.ShowError(string.Format("انتساب پاسخنامه {0} به {1} انجام گرفت.", code, participate.Register.Student.FarsiFullname));
        }
    }
}
