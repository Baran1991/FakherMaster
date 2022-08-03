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

namespace Fakher.UI.SystemFeatures
{
    public partial class frmTest : rRadForm
    {
        public frmTest()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Student.FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Student.FarsiLastName" });
//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "سطح قبلی", ObjectProperty = "GetPrevRegister().MasterParticipate" });
//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نتیجه", ObjectProperty = "GetPrevRegister().MasterParticipate.GetResultLabel()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "سطح فعلی", ObjectProperty = "MasterParticipate" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نتیجه", ObjectProperty = "MasterParticipate.GetResultLabel()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "سطح بعدی", ObjectProperty = "GetEnrollableLessonsTest()" });
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            int skip = rTextBox1.GetValue<int>();
            int count = rTextBox2.GetValue<int>();
            Major major = Major.FromId(4);
            IList<Register> registers = Register.GetRegisters(Program.CurrentPeriod, major).Skip(skip).Take(count).ToList();
            rGridView1.DataBind(registers);
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            Register register = rGridView1.GetSelectedObject<Register>();
            Lesson lesson = register.GetEnrollableLessonsTest();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            Major major = Major.FromId(4);
            IList<Register> registers = Register.GetRegisters(Program.CurrentPeriod, major).ToList();
            for (int i = 0; i < registers.Count; i++)
            {
                Register register = registers[i];
                register.Participates.Clear();
                register.Save();
            }
            rMessageBox.ShowError("Done!");
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {

        }
    }
}
