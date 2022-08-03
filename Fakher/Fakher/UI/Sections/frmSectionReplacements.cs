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

namespace Fakher.UI.Educational.Sections
{
    public partial class frmSectionReplacements : rRadForm
    {
        public frmSectionReplacements()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ساعت", ObjectProperty = "ReplacementHours" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "علت", ObjectProperty = "Reason" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مدرس جانشین", ObjectProperty = "Teacher.FarsiFullname" });
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            if(sectionItemSelector1.SectionItem == null)
                return;
            Replacement replacement = new Replacement();
            replacement.SectionItem = sectionItemSelector1.SectionItem;
            frmReplacementDetail frm = new frmReplacementDetail(replacement);
            if(!frm.ProcessObject())
                return;
            sectionItemSelector1.SectionItem.AddReplacement(replacement);
            replacement.Save();
            rGridView1.Insert(replacement);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Replacement replacement = rGridView1.GetSelectedObject<Replacement>();
            frmReplacementDetail frm = new frmReplacementDetail(replacement);
            if (!frm.ProcessObject())
                return;
            replacement.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            if (sectionItemSelector1.SectionItem == null)
                return;

            Replacement replacement = rGridView1.GetSelectedObject<Replacement>();
            replacement.SectionItem.Replacements.Remove(replacement);
            replacement.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void sectionItemSelector1_SelectedChanged(object sender, EventArgs e)
        {
            rGridView1.Clear();
            if(sectionItemSelector1.SectionItem == null)
                return;
            rGridView1.DataBind(sectionItemSelector1.SectionItem.Replacements);
        }
    }
}
