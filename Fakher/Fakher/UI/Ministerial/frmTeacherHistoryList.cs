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
    public partial class frmTeacherHistoryList : rRadDetailForm
    {
        public class Test2Data
        {
            public string Name { get; set; }
            public string Contract { get; set; }
            public int History { get; set; }
        }

        public frmTeacherHistoryList()
        {
            InitializeComponent();
            List<Test2Data> datas = new List<Test2Data>();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "قرارداد", ObjectProperty = "Contract" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "سابقه", ObjectProperty = "History" });

            IQueryable<Teacher> teachers = Teacher.GetActiveTeachers();
            foreach (Teacher teacher in teachers)
            {
                foreach (Contract contract in teacher.Contracts)
                {
                    Test2Data data = new Test2Data();
                    data.Name = teacher.FarsiFullname;
                    data.Contract = (contract as TeachingContract).Major.Name;

                    int teachingHistory = teacher.GetPresenceTeachingPeriods((contract as TeachingContract).Major).Count();
                    teachingHistory += (contract as TeachingContract).TermHistory;

                    data.History = teachingHistory;

                    datas.Add(data);
                }
            }

            rGridView1.DataBind(datas);
        }
    }
}
