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

namespace Fakher.UI.Educational.Sections
{
    public partial class frmSectionMakeups : rRadForm
    {
        public frmSectionMakeups()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping{Caption = "تاریخ", ObjectProperty = "Date"});
            rGridView1.Mappings.Add(new ColumnMapping{Caption = "زمان برگزاری", ObjectProperty = "Formation.ToString"});
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            if(sectionItemSelector1.SectionItem == null)
                return;
            Makeup makeup = new Makeup();
            frmMakeupDetail frm = new frmMakeupDetail(makeup);
            if (!frm.ProcessObject())
                return;
            sectionItemSelector1.SectionItem.AddMakeup(makeup);
            makeup.Save();
            rGridView1.Insert(makeup);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Makeup makeup = rGridView1.GetSelectedObject<Makeup>();
            frmMakeupDetail frm = new frmMakeupDetail(makeup);
            if (!frm.ProcessObject())
                return;
            makeup.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Makeup makeup = rGridView1.GetSelectedObject<Makeup>();
            makeup.SectionItem.Makeups.Remove(makeup);
            makeup.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void sectionItemSelector1_SelectedChanged(object sender, EventArgs e)
        {
            if (sectionItemSelector1.SectionItem == null)
                return;
            rGridView1.DataBind(sectionItemSelector1.SectionItem.Makeups);
        }
    }
}
