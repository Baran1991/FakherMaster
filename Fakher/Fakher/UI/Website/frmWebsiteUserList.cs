using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Website
{
    public partial class frmWebsiteUserList : rRadForm
    {
        public frmWebsiteUserList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شناســه", ObjectProperty = "UserInfo.Id" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نــام", ObjectProperty = "FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نــام خانوادگی", ObjectProperty = "FarsiLastName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ایمیل", ObjectProperty = "UserInfo.GetRawEmail()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ فعالسازی", ObjectProperty = "UserInfo.WebActivateDate.ToShortDateString()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "آخرین وضعیت آموزشی", ObjectProperty = "GetCurrentEducationalStatus()" });

            FillGrid();
        }

        private void FillGrid()
        {
            rGridView1.DataBind(Student.GetWebsiteStudents());
        }

        private void toolStripBtnReSend_Click(object sender, EventArgs e)
        {
            Student student = rGridView1.GetSelectedObject<Student>();
            if(student == null)
            {
                rMessageBox.ShowWarning("ابتدا یک نفر را انتخاب کنید");
                return;
            }

            try
            {
                InternetPostMaster.Send(InternetPostMaster.NoReply, new[] { new MailAddress(student.UserInfo.GetRawEmail()) }, "شناسه کاربری", student.UserInfo.GetLoginHtmlText(), true, true);
                rMessageBox.ShowInformation("شناسه و رمزعبور، به ایمیل {0} ارسال گردید.", student.UserInfo.GetRawEmail());
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void toolStripBtnRemove_Click(object sender, EventArgs e)
        {
            Student student = rGridView1.GetSelectedObject<Student>();
            if (student == null)
            {
                rMessageBox.ShowWarning("ابتدا یک نفر را انتخاب کنید");
                return;
            }
            try
            {
                student.UserInfo.DeactivateApp();
                student.UserInfo.DeactivateWeb();
                student.UserInfo.Save();
                rMessageBox.ShowInformation("کاربر موردنظر غیرفعال گردید.");
                FillGrid();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
    }
}
