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
using SortOrder = rComponents.SortOrder;

namespace Fakher.UI.Exam
{
    public partial class frmQuestionnaireExamList : rRadForm
    {
        public frmQuestionnaireExamList()
        {
            InitializeComponent();

            rGridComboBoxEvalItem.Columns.Add("نام آیتم", "نام آیتم", "Name");

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام آزمون", ObjectProperty = "Name", SortOrder = SortOrder.Ascending });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "گروه", ObjectProperty = "FarsiExamSectionsText" });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام فرم", ObjectProperty = "Name", SortOrder = SortOrder.Ascending });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تعداد سئوالات آزمون", ObjectProperty = "Exam.QuestionCount" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تعداد سئوالات دفترچه", ObjectProperty = "QuestionCount" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تعداد صفحه های دفترچه", ObjectProperty = "Pages.Count" });
        }

        private void majorSelector1_SelectedChanged(object sender, EventArgs e)
        {
            rGridComboBoxEvalItem.Clear();
            if (majorSelector1.Major == null)
                return;

            rGridComboBoxEvalItem.DataSource = majorSelector1.Major.GetExamEvaluationItems(Program.CurrentPeriod, ExamType.OnlineExam);
        }

        private void rGridComboBoxEvalItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            EvaluationItem item = rGridComboBoxEvalItem.GetValue<EvaluationItem>();
            rGridView1.Clear();
            if (item == null)
                return;
            rGridView1.DataBind(majorSelector1.Major.GetExams(Program.CurrentPeriod, item, ExamType.OnlineExam));
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {

        }

        private void rGridView1_SelectedItemChanged(object sender, EventArgs e)
        {
            Core.DomainModel.Exam exam = rGridView1.GetSelectedObject<Core.DomainModel.Exam>();
            rGridView2.Clear();
            if (exam == null)
                return;
            rGridView2.DataBind(exam.Forms);
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            ExamForm examForm = rGridView2.GetSelectedObject<ExamForm>();

            examForm.RefreshEntity();
            frmExamQuestionnaireDesigner frm = new frmExamQuestionnaireDesigner(examForm);
            if (!frm.ProcessObject())
                return;

            examForm.Save();
            rGridView2.UpdateGridView();
        }
    }
}
