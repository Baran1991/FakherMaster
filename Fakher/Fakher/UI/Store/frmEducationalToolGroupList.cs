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

namespace Fakher.UI.Fundamental
{
    public partial class frmEducationalToolGroupList : rRadForm
    {
        public frmEducationalToolGroupList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "Lesson.Name" });
        }

        private void majorSelector1_SelectedChanged(object sender, EventArgs e)
        {
            rGridView1.Clear();
            if (majorSelector1.Major == null)
                return;
            rGridView1.DataBind(majorSelector1.Major.ToolGroups);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            if (majorSelector1.Major == null)
                return;

            EducationalToolGroup toolGroup = new EducationalToolGroup { Major = majorSelector1.Major };
            frmEducationalToolGroupDetail frm = new frmEducationalToolGroupDetail(toolGroup);
            if (!frm.ProcessObject())
                return;
            toolGroup.Save();
            rGridView1.Insert(toolGroup);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            EducationalToolGroup toolGroup = rGridView1.GetSelectedObject<EducationalToolGroup>();
            frmEducationalToolGroupDetail frm = new frmEducationalToolGroupDetail(toolGroup);
            if (!frm.ProcessObject())
                return;
            toolGroup.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            EducationalToolGroup toolGroup = rGridView1.GetSelectedObject<EducationalToolGroup>();
            toolGroup.Delete();
            rGridView1.RemoveSelectedRow();
        }
    }
}
