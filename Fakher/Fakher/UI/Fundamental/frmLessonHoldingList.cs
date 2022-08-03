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
    public partial class frmLessonHoldingList : rRadForm
    {
        public frmLessonHoldingList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس" , ObjectProperty = "Lesson.Name"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "آیین نامه ارزشیابی", ObjectProperty = "EvaluationProtocol.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "آیین نامه نتیجه", ObjectProperty = "ResultProtocol.Name" });
//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "آیین نامه تعیین سطح", ObjectProperty = "PlacementProtocol.Name" });
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            LessonHolding lessonHolding = new LessonHolding();
            lessonHolding.Period = Program.CurrentPeriod;
            frmLessonHoldingDetail frm = new frmLessonHoldingDetail(majorSelector1.Major, lessonHolding);
            if(!frm.ProcessObject())
                return;
            foreach (LessonHolding lPeriod in rGridView1.DataSource)
            {
                if(lessonHolding.Lesson.Id == lPeriod.Lesson.Id)
                {
                    rMessageBox.ShowError("برای این درس/سطح قبلا آیین نامه تعریف شده است.");
                    return;
                }
            }
            Program.CurrentPeriod.AddLessonHolding(lessonHolding);
            lessonHolding.Save();
            rGridView1.Insert(lessonHolding);
        }

        private void majorSelector1_SelectedChanged(object sender, EventArgs e)
        {
            rGridView1.Clear();
            if(majorSelector1.Major == null)
                return;
            rGridView1.DataBind(Program.CurrentPeriod.GetLessonHoldings(majorSelector1.Major));
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            LessonHolding lessonHolding = rGridView1.GetSelectedObject<LessonHolding>();
            frmLessonHoldingDetail frm = new frmLessonHoldingDetail(majorSelector1.Major, lessonHolding);
            if (!frm.ProcessObject())
                return;

            foreach (LessonHolding lPeriod in rGridView1.DataSource)
            {
                if (lPeriod.Id != lessonHolding.Id && lessonHolding.Lesson.Id == lPeriod.Lesson.Id)
                {
                    rMessageBox.ShowError("برای این درس/سطح قبلا آیین نامه تعریف شده است.");
                    return;
                }
            }

            lessonHolding.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            LessonHolding lessonHolding = rGridView1.GetSelectedObject<LessonHolding>();
            
            lessonHolding.Period.LessonHoldings.Remove(lessonHolding);
            lessonHolding.Delete();
            
            rGridView1.RemoveSelectedRow();
        }
    }
}
