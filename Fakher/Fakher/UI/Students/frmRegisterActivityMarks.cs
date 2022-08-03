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
    public partial class frmRegisterActivityMarks : rRadForm
    {
        Participate selectedParticipate;
        public frmRegisterActivityMarks(Participate participate)
        {
            InitializeComponent();

            //SetProcessingObject(register);

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس", ObjectProperty = "SectionItem.Lesson.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کلاس", ObjectProperty = "SectionItem.Section.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تعداد نمرات ثبت شده", ObjectProperty = "ActivityMarks.Count()" });
            rGridViewAbsents.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
            rGridViewAbsents.Mappings.Add(new ColumnMapping { Caption = "نمره", ObjectProperty = "Mark" , AggregateSummary = AggregateSummary.Sum });
            rGridViewAbsents.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "Description" });
            List<Participate> participateList = new List<Participate>();
            participateList.Add(participate);
            rGridView1.DataBind(participateList);
            selectedParticipate = participate;
            rGridViewAbsents.DataBind(participate.GetActivityMark(selectedParticipate.Register.Student as Fakher.Core.DomainModel.Person));

        }

     
        private void rGridView1_SelectedItemChanged(object sender, EventArgs e)
        {
            rGridViewAbsents.Clear();
            if(!rGridView1.IsItemSelected)
                return;
            //Register register = GetProcessingObject<Register>();
            Participate participate = selectedParticipate;
            if (participate == null)
                return;

            rGridViewAbsents.DataBind(participate.GetActivityMark(selectedParticipate.Register.Student as Fakher.Core.DomainModel.Person ));
        }

        private void rGridViewAbsents_Add(object sender, EventArgs e)
        {
            Participate participate = selectedParticipate;
            if (participate == null)
                return;

            ActivityMark mark = participate.CreateActivityMark();
            frmActivityMarkDetail frm = new frmActivityMarkDetail(mark);
            if (!frm.ProcessObject())
                return;
            //register.Student.acti.Add(delay);
            mark.Save();
            rGridViewAbsents.Insert(mark);
            rGridView1.UpdateGridView();
        }

        private void rGridViewAbsents_Edit(object sender, EventArgs e)
        {
            ActivityMark mark = rGridViewAbsents.GetSelectedObject<ActivityMark>();
            frmActivityMarkDetail frm = new frmActivityMarkDetail(mark);
            if (!frm.ProcessObject())
                return;
            mark.Save();
            rGridViewAbsents.UpdateGridView();
            rGridView1.UpdateGridView();
        }

        private void rGridViewAbsents_Delete(object sender, EventArgs e)
        {
            
            ActivityMark mark = rGridViewAbsents.GetSelectedObject<ActivityMark>();
           mark.Delete();
            rGridViewAbsents.RemoveSelectedRow();
            rGridView1.UpdateGridView();
        }
    }
}
