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

namespace Fakher.UI.Reception
{
    public partial class frmNextEnrollmentView : rRadDetailForm
    {
        private Major mMajor;
        private EducationalPeriod mPeriod;

        public frmNextEnrollmentView(Student student, Major major, EducationalPeriod period)
        {
            InitializeComponent();
            SetProcessingObject(student);
            mMajor = major;
            mPeriod = period;

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شناسه", ObjectProperty = "Id" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "Name" });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تـرم", ObjectProperty = "Period.Name" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "MasterParticipate" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نتیجه", ObjectProperty = "MasterParticipate.GetResultLabel()" });

//            Register prevRegister = register.GetPrevRegister();
//            if (prevRegister != null && prevRegister.MasterParticipate != null)
//            {
//                rLblPrev.Text = prevRegister.Period.Name + " سطح " + prevRegister.MasterParticipate + " (" +
//                                prevRegister.MasterParticipate.GetResultLabel() + ")";
//            }
//            if (register.MasterParticipate != null)
//            {
//                rLblCurrent.Text = register.Period.Name + " سطح " + register.MasterParticipate + " (" +
//                                   register.MasterParticipate.GetResultLabel() + ")";
//            }
//            else if (prevRegister != null)
//            {
//                Register prevPrevRegister = prevRegister.GetPrevRegister();
//                if (prevPrevRegister.MasterParticipate != null)
//                    rLblCurrent.Text = prevPrevRegister.Period.Name + " سطح " + prevPrevRegister.MasterParticipate + " (" +
//                                       prevPrevRegister.MasterParticipate.GetResultLabel() + ")";
//            }

            FillGrid2();
            FillGrid1();
        }

        private void FillGrid1()
        {
            Student student = GetProcessingObject<Student>();
            List<Lesson> lessons = student.GetEnrollableLessons(mMajor, mPeriod, true, true).ToList();
            rGridView1.DataBind(lessons);
        }

        private void FillGrid2()
        {
            Student student = GetProcessingObject<Student>();
            List<Register> registers = student.GetRegisters(mMajor).OrderByDescending(x => x.Id).ToList();
            rGridView2.DataBind(registers);
        }
    }
}
