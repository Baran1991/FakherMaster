using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Core.Sentinel;
using Fakher.UI.Holding;
using Fakher.UI.SystemFeatures;
using rComponents;
using SortOrder = rComponents.SortOrder;

namespace Fakher.UI.Educational.Sections
{
    public partial class frmSectionsList : rRadForm
    {
        public frmSectionsList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شناسه", ObjectProperty = "Id"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "گروه", ObjectProperty = "Section.Name"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "Section.ItemsText", SortOrder = SortOrder.Ascending });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ظرفیت", ObjectProperty = "Section.Capacity", AggregateSummary = AggregateSummary.Sum });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "پرشده", ObjectProperty = "ParticipateCount", AggregateSummary = AggregateSummary.Sum });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "باقیمانده", ObjectProperty = "RemainderCount", AggregateSummary = AggregateSummary.Sum});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مدرس", ObjectProperty = "Section.FarsiTeacherText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شیفت", ObjectProperty = "Section.FarsiFormationText" });
            //Program.CurrentEmployee.UserInfo.AccessTags
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.EducationalSectionEdit);
            
            SectionItem sectionItem = rGridView1.GetSelectedObject<SectionItem>();
                sectionItem.Section.RefreshEntity();

                frmSectionDetail frm = new frmSectionDetail(sectionItem.Section);
                if (frm.ShowDialog(this) != DialogResult.OK)
                    return;
                sectionItem.Section.Save();
                rGridView1.UpdateGridView();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }

        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.EducationalSectionEdit);

                SectionItem sectionItem = rGridView1.GetSelectedObject<SectionItem>();
            int count = sectionItem.GetParticipates().Count;
            if (count > 0)
            {
                rMessageBox.ShowError("در حال حاضر {0} دانشجو در این گروه ثبت نام شده اند. ابتدا آنها را از این گروه حذف کنید.", count);
                return;
            }
            if (rMessageBox.ShowQuestion("با حذف، کلیه ثبت نام دانشجویان در این گروه از بین خواهد رفت. آیا مطمئن هستید ؟") != DialogResult.Yes)
                return;
            if (rMessageBox.ShowQuestion("این عمل غیرقابل بازگشت است و کلیه ثبت نام های دانشجویان در این گروه حذف خواهد شد. آیا واقعا مطمئن هستید؟") != DialogResult.Yes)
                return;

            sectionItem.Section.Delete();
            rGridView1.RemoveSelectedRow();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void lessonSelector1_SelectedChanged(object sender, EventArgs e)
        {
            if(majorSelector1.Major == null)
                return;
            if(lessonSelector1.Lesson == null)
                return;
            rGridView1.DataBind(SectionItem.GetSectionItems(Program.CurrentPeriod, majorSelector1.Major,
                                                            lessonSelector1.Lesson));
        }
    }
}
