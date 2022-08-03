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
    public partial class frmSectionObserves : rRadForm
    {
        public frmSectionObserves()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping {Caption = "تاریخ", ObjectProperty = "Date"});
            rGridView1.Mappings.Add(new ColumnMapping {Caption = "درس/سطح", ObjectProperty = "SectionItem.Item.Lesson.Name"});
            rGridView1.Mappings.Add(new ColumnMapping {Caption = "نمره", ObjectProperty = "Mark"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "عنوان نمره", ObjectProperty = "TypeText" });
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            if (sectionItemSelector1.SectionItem == null)
                return;

            ObserveMark observeMark = new ObserveMark() { SectionItem = sectionItemSelector1.SectionItem};
            frmObserveDetail frm = new frmObserveDetail(observeMark);
            if(!frm.ProcessObject())
                return;
            observeMark.Save();
            rGridView1.Insert(observeMark);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            ObserveMark observeMark = rGridView1.GetSelectedObject<ObserveMark>();
            frmObserveDetail frm = new frmObserveDetail(observeMark);
            if (!frm.ProcessObject())
                return;
            observeMark.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            ObserveMark observeMark = rGridView1.GetSelectedObject<ObserveMark>();
            observeMark.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void sectionItemSelector1_SelectedChanged(object sender, EventArgs e)
        {
            if (sectionItemSelector1.SectionItem == null)
                return;

            rLblTeacher.Text = sectionItemSelector1.SectionItem.Section.Teacher.FarsiFullname;
            rGridView1.DataBind(sectionItemSelector1.SectionItem.Section.GetObserveMarks());
        }
    }
}
