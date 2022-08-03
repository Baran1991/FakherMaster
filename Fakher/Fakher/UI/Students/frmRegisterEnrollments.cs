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

namespace Fakher.UI.Students
{
    public partial class frmRegisterEnrollments : rRadDetailForm
    {
        public frmRegisterEnrollments(Register register)
        {
            InitializeComponent();
            SetProcessingObject(register);

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شناسه", ObjectProperty = "Id" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام آزمون", ObjectProperty = "TrainingItem.Lesson.Name" });

            FillGrid();
        }

        private void FillGrid()
        {
            Register register = GetProcessingObject<Register>();
            IQueryable<Enrollment> examEnrollments = register.GetGeneralExamEnrollments();
            rGridView1.DataBind(examEnrollments);
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Register register = GetProcessingObject<Register>();
            List<Enrollment> checkedObjects = rGridView1.GetCheckedObjects<Enrollment>();
            foreach (Enrollment item in checkedObjects)
                rGridView1.Remove(item);
        }

        protected override void AfterBindToObject()
        {
            Register register = GetProcessingObject<Register>();
            register.Enrollments.SyncWith(rGridView1.DataSource);
        }
    }
}
