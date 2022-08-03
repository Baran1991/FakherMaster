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
    public partial class frmRegisterDelays : rRadForm
    {
        Participate selectedParticipate;
        public frmRegisterDelays(IList<Participate> participates,bool isList=false)
        {
            InitializeComponent();

           
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس", ObjectProperty = "SectionItem.Lesson.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کلاس", ObjectProperty = "SectionItem.Section.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تعداد تاخیر", ObjectProperty = "DelaysCount" });
            rGridViewAbsents.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });

           
            rGridView1.DataBind(participates);
            if (!isList)
            {
                selectedParticipate = participates.FirstOrDefault();
                rGridViewAbsents.DataBind(selectedParticipate.GetDelays().ToList());
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

            rGridViewAbsents.DataBind(participate.GetDelays().ToList());
        }

        private void rGridViewAbsents_Add(object sender, EventArgs e)
        {

            Participate participate = rGridView1.GetSelectedObject<Participate>();
            Delay delay = participate.CreateDelay();
            if (!new frmDelayDetail(delay).ProcessObject())
                return;
            participate.Register.Student.Delays.Add(delay);
            delay.Save();
            rGridViewAbsents.Insert(delay);
            rGridView1.UpdateGridView();
        }

        private void rGridViewAbsents_Edit(object sender, EventArgs e)
        {
            Delay delay = rGridViewAbsents.GetSelectedObject<Delay>();
            if (!new frmDelayDetail(delay).ProcessObject())
                return;
            delay.Save();
            rGridViewAbsents.UpdateGridView();
            rGridView1.UpdateGridView();
        }

        private void rGridViewAbsents_Delete(object sender, EventArgs e)
        {
            Participate participate = rGridView1.GetSelectedObject<Participate>();
            Delay delay = rGridViewAbsents.GetSelectedObject<Delay>();
            participate.Register.Student.Delays.Remove(delay);
            delay.Delete();
            rGridViewAbsents.RemoveSelectedRow();
            rGridView1.UpdateGridView();
        }
    }
}
