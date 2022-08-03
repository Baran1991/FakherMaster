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

namespace Fakher.UI.Person
{
    public partial class frmTeacherList : rRadForm
    {
        public frmTeacherList()
        {
            InitializeComponent();

            rPageView1.SelectedPage = radPageViewPage1;

//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تصویر", ObjectProperty = "Picture", Type = ColumnType.Image});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کد", ObjectProperty = "Id" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره پرونده", ObjectProperty = "Code" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "FarsiLastName" });
            rGridView1.CustomButtons.Add(new rGridViewButton { Text = "بازنشانی ورود", VisibleOnSelect = true, Position = rGridViewButtonPosition.After });


            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شماره پرونده", ObjectProperty = "Code" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "FarsiFirstName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "FarsiLastName" });

            Fill();
        }

        private void Fill()
        {
            rGridView1.DataBind(Teacher.GetActiveTeachers());
            rGridView2.DataBind(Teacher.GetAllTeachers());
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher();
            frmPersonDetail frm = new frmPersonDetail(teacher);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            teacher.Code = Core.DomainModel.Person.GetNextCode<Teacher>();
            teacher.Save();
            rGridView1.Insert(teacher);
            rMessageBox.ShowInformation(string.Format("مدرس [{0}] با شماره پرونده [{1}] ثبت گردید.", teacher.FarsiFullname, teacher.Code));
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Teacher teacher = rGridView1.GetSelectedObject<Teacher>();
            frmPersonDetail frm = new frmPersonDetail(teacher);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            teacher.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Teacher teacher = rGridView1.GetSelectedObject<Teacher>();
            if (teacher.TeachingSections.Count > 0)
                if (
                    rMessageBox.ShowQuestion("این مدرس در کلاس هایی مشغول به تدریس است. از غیرفعالسازی مطمئن هستید؟") !=
                    DialogResult.Yes)
                    return;

            teacher.Disabled = true;
            teacher.Save();
            Fill();

            rMessageBox.ShowInformation("مدرس غیرفعال شد.");
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            Teacher teacher = rGridView2.GetSelectedObject<Teacher>();
            frmPersonDetail frm = new frmPersonDetail(teacher);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            teacher.Save();
            rGridView2.UpdateGridView();
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            Teacher teacher = rGridView2.GetSelectedObject<Teacher>();

            teacher.Disabled = false;
            teacher.Save();
            Fill();

            rMessageBox.ShowInformation("مدرس فعال شد.");
        }
        private void rGridView1_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            Teacher employee = rGridView1.GetSelectedObject<Teacher>();
            if (e.ButtonIndex == 0)
            {
                employee.UserInfo.Signin("127.0.0.1");
                employee.UserInfo.Save();
            }
            rMessageBox.ShowInformation("ورود مدرس بازنشانی شد.");
        }
    }
}
