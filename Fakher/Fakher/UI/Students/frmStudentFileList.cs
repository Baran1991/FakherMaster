using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.UI.Person;
using rComponents;
using Fakher.Core.DomainModel;

namespace Fakher.UI.Educational.Students
{
    public partial class frmStudentFileList : rRadForm
    {
        public frmStudentFileList()
        {
            InitializeComponent();

            rGridViewStudents.Mappings.Add(new ColumnMapping { Caption = "شماره پرونده", ObjectProperty = "Code" });
            rGridViewStudents.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "FarsiFirstName" });
            rGridViewStudents.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "FarsiLastName" });
//            rGridViewStudents.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FinancialStatusFarsiText" });

            rGridViewStudents.DataBind(Student.GetStudents());
        }

        private void rGridViewStudents_Edit(object sender, EventArgs e)
        {
            Student student = rGridViewStudents.GetSelectedObject<Student>();
            student.RefreshEntity();

            frmPersonDetail frm = new frmPersonDetail(student);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            student.Save();
            rGridViewStudents.UpdateGridView();
        }

        private void rGridViewStudents_Delete(object sender, EventArgs e)
        {
            Student student = rGridViewStudents.GetSelectedObject<Student>();
            Register lastRegister = student.GetLastRegister();
            if (lastRegister != null)
            {
                if (
                    rMessageBox.ShowQuestion(
                        string.Format("آخرین فعالیت آموزشی این فرد در {0} بوده است. از حذف اطمینان دارید؟",
                                      lastRegister.StatusText)) != DialogResult.Yes)
                    return;
                if (lastRegister.Major.Department.Id != Program.CurrentDepartment.Id)
                {
                    rMessageBox.ShowError(
                        "این دانشجو همزمان در چند دپارتمان مشغول به تحصیل است، بنابراین امکان حذف آن وجود ندارد.");
                    return;
                }
            }

            if(rMessageBox.ShowQuestion("با حذف این پرونده، کلیه سوابق آموزشی، مالی و تحصیلی این شخص در همه رشته ها و کلاس ها حذف خواهد شد. آیا مطمئن هستید؟") != DialogResult.Yes)
                return;

            try
            {
                student.Delete();
                rGridViewStudents.RemoveSelectedRow();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
    }
}
