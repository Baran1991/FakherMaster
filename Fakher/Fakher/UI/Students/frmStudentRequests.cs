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

namespace Fakher.UI.Educational.Students
{
    public partial class frmStudentRequests : rRadForm
    {
        private Student mStudent;
        public frmStudentRequests(Student student)
        {
            InitializeComponent();
            rGridView1.Mappings.Add(new ColumnMapping{Caption = "شناسه", ObjectProperty = "Id"});
            rGridView1.Mappings.Add(new ColumnMapping{Caption = "تاریخ", ObjectProperty = "Date"});
            rGridView1.Mappings.Add(new ColumnMapping{Caption = "عنوان", ObjectProperty = "Title"});
            rGridView1.Mappings.Add(new ColumnMapping{Caption = "وضعیت", ObjectProperty = "StatusText"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ به روز رسانی", ObjectProperty = "LastUpdateDate" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ساعت به روز رسانی", ObjectProperty = "LastUpdateTime" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کاربر اقدام کننده", ObjectProperty = "Employee.FarsiFullname" });

            mStudent = student;
            rGridView1.DataBind(mStudent.Requests);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Request request = new Request() { Student = mStudent };
            frmRequestDetail frm = new frmRequestDetail(request, false);
            if(!frm.ProcessObject())
                return;
            request.Save();
            rGridView1.Insert(request);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Request request = rGridView1.GetSelectedObject<Request>();
            frmRequestDetail frm = new frmRequestDetail(request, false);
            if (!frm.ProcessObject())
                return;
            request.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Request request = rGridView1.GetSelectedObject<Request>();

            request.Student.Requests.Remove(request);
            request.Delete();
            rGridView1.RemoveSelectedRow();
        }
    }
}
