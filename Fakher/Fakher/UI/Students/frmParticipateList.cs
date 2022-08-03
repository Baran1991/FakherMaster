using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Person
{
    public partial class frmParticipateList : rRadForm
    {
        public frmParticipateList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Register.Code" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Register.Student.FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Register.Student.FarsiLastName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "SectionItem.Item.Lesson.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کلاس", ObjectProperty = "SectionItem.Section.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "Register.Student.FinancialStatusFarsiText" });
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Participate participate = rGridView1.GetSelectedObject<Participate>();
            frmRegister frm = new frmRegister(participate.Register);
            if(!frm.ProcessObject())
                return;
            participate.Register.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Register register = rGridView1.GetSelectedObject<Register>();
            register.Student.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void sectionItemSelector1_SelectedChanged(object sender, EventArgs e)
        {
            rGridView1.Clear();
            if (lessonSelector1.Lesson == null)
                return;
            IList<Participate> participates = null;
            if(sectionItemSelector1.SectionItem == null && IsShowed)
            {
                participates = Participate.GetParticipates(Program.CurrentPeriod, lessonSelector1.Lesson);
            }
            else if (sectionItemSelector1.SectionItem != null)
            {
                participates = sectionItemSelector1.SectionItem.GetParticipates();
            }

            if(participates != null)
                rGridView1.DataBind(participates);
        }
    }
}
