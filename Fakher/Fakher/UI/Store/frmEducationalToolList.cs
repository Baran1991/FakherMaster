using System;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Struture
{
    public partial class frmEducationalToolList : rRadForm
    {
        public frmEducationalToolList()
        {
            InitializeComponent();
            radPageView1.SelectedPage = radPageViewPage1;

            rGridView1.Mappings.Add(new ColumnMapping {Caption = "نام", ObjectProperty = "Name"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نوع", ObjectProperty = "TypeText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تعداد کل", ObjectProperty = "Count" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تعداد موجودی", ObjectProperty = "Remainder" });

            rGridView2.Mappings.Add(new ColumnMapping {Caption = "نام", ObjectProperty = "Name"});
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نوع", ObjectProperty = "TypeText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تعداد کل", ObjectProperty = "Count" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تعداد موجودی", ObjectProperty = "Remainder" });

            Fill();
        }

        private void Fill()
        {
            rGridView1.DataBind(EducationalTool.GetActiveTools());
            rGridView2.DataBind(DbContext.GetAllEntities<EducationalTool>());
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            EducationalTool tool = new EducationalTool();
            frmEducationalToolDetail frm = new frmEducationalToolDetail(tool);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            tool.Save();
            rGridView1.Insert(tool);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            EducationalTool tool = rGridView1.GetSelectedObject<EducationalTool>();
            frmEducationalToolDetail frm = new frmEducationalToolDetail(tool);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            tool.Save();
            Fill();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            EducationalTool tool = rGridView1.GetSelectedObject<EducationalTool>();
            tool.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            EducationalTool tool = rGridView2.GetSelectedObject<EducationalTool>();
            frmEducationalToolDetail frm = new frmEducationalToolDetail(tool);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            tool.Save();
            Fill();
        }
    }
}
