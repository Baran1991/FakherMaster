using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.UI.Educational.Common;
using rComponents;

namespace Fakher.UI.Educational.Sections
{
    public partial class frmParticipateAbsences : rRadForm
    {
        public frmParticipateAbsences()
        {
            InitializeComponent();

            rGridViewStudents.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Register.Code" });
            rGridViewStudents.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Register.Student.FarsiFirstName" });
            rGridViewStudents.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Register.Student.FarsiLastName" });

            rGridViewAbsents.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
            rGridViewAbsents.Mappings.Add(new ColumnMapping { Caption = "علت", ObjectProperty = "Reason" });
            rGridViewAbsents.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
        }

        private void rGridViewStudents_SelectedItemChanged(object sender, EventArgs e)
        {
            Participate participate = rGridViewStudents.GetSelectedObject<Participate>();
            rGridViewAbsents.Clear();
            if(participate == null)
                return;
            rGridViewAbsents.DataBind(participate.GetAbsences().ToList());
        }

        private void rGridViewAbsents_Add(object sender, EventArgs e)
        {
            Participate participate = rGridViewStudents.GetSelectedObject<Participate>();
            if(participate == null)
                return;
            Absence absence = new Absence { SectionItem = participate.SectionItem, Person = participate.Register.Student};
            if (!new frmAbsenceDetail(absence).ProcessObject())
                return;
            participate.Register.Student.Absences.Add(absence);
            absence.Save();
            rGridViewAbsents.Insert(absence);
        }

        private void rGridViewAbsents_Edit(object sender, EventArgs e)
        {
            Participate participate = rGridViewStudents.GetSelectedObject<Participate>();
            if (participate == null)
                return;
            Absence absence = rGridViewAbsents.GetSelectedObject<Absence>();
            if (!new frmAbsenceDetail(absence).ProcessObject())
                return;
            absence.Save();
            rGridViewAbsents.UpdateGridView();
        }

        private void rGridViewAbsents_Delete(object sender, EventArgs e)
        {
            Participate participate = rGridViewStudents.GetSelectedObject<Participate>();
            if (participate == null)
                return;
            Absence absence = rGridViewAbsents.GetSelectedObject<Absence>();
            participate.Register.Student.Absences.Remove(absence);
            absence.Delete();
            rGridViewAbsents.RemoveSelectedRow();
        }

        private void sectionItemSelector1_SelectedChanged(object sender, EventArgs e)
        {
            rGridViewStudents.DataBind(sectionItemSelector1.SectionItem.GetParticipates());
        }
    }
}
