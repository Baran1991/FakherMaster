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

namespace Fakher.UI.Educational.Students
{
    public partial class frmRegisterAbsences : rRadForm
    {
        Participate selectedParticipate;
        public frmRegisterAbsences(IList<Participate> participates,bool isList=false)
        {
            InitializeComponent();

          
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس", ObjectProperty = "SectionItem.Lesson.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کلاس", ObjectProperty = "SectionItem.Section.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "غیبت موجه", ObjectProperty = "AcceptedAbsencesCount" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "غیبت غیرموجه", ObjectProperty = "RejectedAbsencesCount" });

            rGridViewAbsents.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
            rGridViewAbsents.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            
            rGridView1.DataBind(participates);
            if (!isList)
            {
                selectedParticipate = participates.FirstOrDefault();
                rGridViewAbsents.DataBind(selectedParticipate.GetAbsences().ToList());
            }
        }

        private void rGridView1_SelectedItemChanged(object sender, EventArgs e)
        {
            rGridViewAbsents.Clear();
            if(!rGridView1.IsItemSelected)
                return;
            Participate participate = rGridView1.GetSelectedObject<Participate>();
            if (participate == null)
                return;

            rGridViewAbsents.DataBind(participate.GetAbsences().ToList());
        }

        private void rGridViewAbsents_Add(object sender, EventArgs e)
        {
           var participate= rGridView1.GetSelectedObject<Participate>();
            Absence absence = participate.CreateAbsence();
            if (!new frmAbsenceDetail(absence).ProcessObject())
                return;
            participate.Register.Student.Absences.Add(absence);
            absence.Save();
            rGridViewAbsents.Insert(absence);
            rGridView1.UpdateGridView();
        }

        private void rGridViewAbsents_Edit(object sender, EventArgs e)
        {
            Absence absence = rGridViewAbsents.GetSelectedObject<Absence>();
            if (!new frmAbsenceDetail(absence).ProcessObject())
                return;
            absence.Save();
            rGridViewAbsents.UpdateGridView();
            rGridView1.UpdateGridView();
        }

        private void rGridViewAbsents_Delete(object sender, EventArgs e)
        {
            var participate = rGridView1.GetSelectedObject<Participate>();
            Absence absence = rGridViewAbsents.GetSelectedObject<Absence>();
            participate.Register.Student.Absences.Remove(absence);
            absence.Delete();
            rGridViewAbsents.RemoveSelectedRow();
            rGridView1.UpdateGridView();
        }
    }
}
