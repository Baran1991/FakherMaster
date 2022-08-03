using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Application_Controls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Fakher.UI.Exam.Online_Exam_UI;
using rComponents;

namespace Fakher.UI.Exam
{
    public partial class frmExamQuestionnaireDesigner : rRadDetailForm
    {
        public frmExamQuestionnaireDesigner(ExamForm examForm)
        {
            InitializeComponent();
            SetProcessingObject(examForm);
            FillPages();
        }

        private void toolStripBtnAddPage_Click(object sender, EventArgs e)
        {
            ExamForm examForm = GetProcessingObject<ExamForm>();

            ExamPage newPage = new ExamPage { Name = "صفحه " + (listView1.Items.Count + 1), ExamForm = examForm};
            AddPage(newPage);
            SelectPage(newPage);
        }

        private void SelectPage(ExamPage page)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Tag == page)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                    break;
                }
            }
        }

        private void FillPages()
        {
            ExamForm examForm = GetProcessingObject<ExamForm>();
            
            foreach (ExamPage page in examForm.Pages)
                AddPage(page);

            if (examForm.Pages.Count > 0)
                SelectPage(examForm.Pages.First());
        }

        private void AddPage(ExamPage page)
        {
            ListViewItem item = new ListViewItem(page.Name, 0);
            item.Tag = page;
            listView1.Items.Add(item);
        }

        private void frmExamQuestionnaireDesigner_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void toolStripBtnNewQuestion_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                rMessageBox.ShowWarning("ابتدا یک صفحه را انتخاب کنید");
                return;
            }

            ExamForm examForm = GetProcessingObject<ExamForm>();
            ExamPage page = listView1.SelectedItems[0].Tag as ExamPage;

            ExamTestQuestion testQuestion = new ExamTestQuestion();
            ExamPageGroup pageGroup = new ExamPageGroup();
            testQuestion.Group = pageGroup;
            pageGroup.Items.Add(testQuestion);

            if (Edit(testQuestion))
            {
                pageGroup.ExamPage = page;
                page.Groups.Add(pageGroup);
                pageGroup.Position = page.Groups.Count;
                DrawPage(page);
            }
        }

        private void toolStripBtnNewEssayQuestion_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                rMessageBox.ShowWarning("ابتدا یک صفحه را انتخاب کنید");
                return;
            }

            ExamForm examForm = GetProcessingObject<ExamForm>();
            ExamPage page = listView1.SelectedItems[0].Tag as ExamPage;

            ExamEssayQuestion essayQuestion = new ExamEssayQuestion();
            ExamPageGroup pageGroup = new ExamPageGroup();
            essayQuestion.Group = pageGroup;
            pageGroup.Items.Add(essayQuestion);

            if (Edit(essayQuestion))
            {
                pageGroup.ExamPage = page;
                page.Groups.Add(pageGroup);
                pageGroup.Position = page.Groups.Count;
                DrawPage(page);
            }
        }

        private void toolStripBtnNewTextItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                rMessageBox.ShowWarning("ابتدا یک صفحه را انتخاب کنید");
                return;
            }

            ExamForm examForm = GetProcessingObject<ExamForm>();
            ExamPage page = listView1.SelectedItems[0].Tag as ExamPage;

            TextPageItem textPageItem = new TextPageItem();
            ExamPageGroup pageGroup = new ExamPageGroup();
            textPageItem.Group = pageGroup;
            pageGroup.Items.Add(textPageItem);

            if (Edit(textPageItem))
            {
                pageGroup.ExamPage = page;
                page.Groups.Add(pageGroup);
                pageGroup.Position = page.Groups.Count;
                DrawPage(page);
            }
        }

        protected override void AfterBindToObject()
        {
            Save(false);
//            ExamForm examForm = GetProcessingObject<ExamForm>();
//
//            int questionCount = 0;
//            List<ExamPage> pages = new List<ExamPage>();
//            foreach (ListViewItem listViewItem in listView1.Items)
//            {
//                ExamPage examPage = listViewItem.Tag as ExamPage;
//                questionCount += examPage.QuestionCount;
//                pages.Add(examPage);
//            }
//
//            if (questionCount < examForm.Exam.QuestionCount)
//            {
//                if (rMessageBox.ShowQuestion("تعداد سئوالات تعریف شده در این آزمون {0} سئوال است. در حال حاضر سئوالات کمتری تعریف شده است. از ثبت پرسشنامه مطمئن هستید؟", examForm.Exam.QuestionCount) != DialogResult.Yes)
//                {
//                    CancelClosing();
//                    return;
//                }
//            }
//            if(questionCount > examForm.Exam.QuestionCount)
//            {
//                if (rMessageBox.ShowQuestion("تعداد سئوالات تعریف شده بیشتر از تعداد سئوالات آزمون است. آیا مطمئن هستید؟") != DialogResult.Yes)
//                {
//                    CancelClosing();
//                    return;
//                }
//            }
//
//            examForm.Pages.SyncWith(pages);
        }

        private void Save(bool dbSave)
        {
            ExamForm examForm = GetProcessingObject<ExamForm>();

            int questionCount = 0;
            List<ExamPage> pages = new List<ExamPage>();
            foreach (ListViewItem listViewItem in listView1.Items)
            {
                ExamPage examPage = listViewItem.Tag as ExamPage;
                questionCount += examPage.QuestionCount;
                pages.Add(examPage);
            }

            if (questionCount < examForm.Exam.QuestionCount)
            {
                if (rMessageBox.ShowQuestion("تعداد سئوالات تعریف شده در این آزمون {0} سئوال است. در حال حاضر سئوالات کمتری تعریف شده است. از ثبت پرسشنامه مطمئن هستید؟", examForm.Exam.QuestionCount) != DialogResult.Yes)
                {
                    CancelClosing();
                    return;
                }
            }
            if (questionCount > examForm.Exam.QuestionCount)
            {
                if (rMessageBox.ShowQuestion("تعداد سئوالات تعریف شده بیشتر از تعداد سئوالات آزمون است. آیا مطمئن هستید؟") != DialogResult.Yes)
                {
                    CancelClosing();
                    return;
                }
            }

            examForm.Pages.SyncWith(pages);
            if(dbSave)
                examForm.Save();
            rLblSave.Text = "آخرین ذخیره در " + Time.Now.ToString();
        }

        private void control_Delete(object sender, EventArgs e)
        {
            if (rMessageBox.ShowQuestion("عمل حذف غیرقابل برگشت است، آیا مطمئن هستید؟") != DialogResult.Yes)
                return;
            ExamPageItemControl control = sender as ExamPageItemControl;
            ExamPageItem item = control.Item;
            item.Group.Items.Remove(item);
            if (item.Group.Items.Count == 0)
                item.Group.ExamPage.Groups.Remove(item.Group);

            panel1.Controls.Remove(control);
        }

        private void control_Edit(object sender, EventArgs e)
        {
            ExamPageItemControl control = sender as ExamPageItemControl;
            ExamPageItem item = control.Item;

            if(Edit(item))
                DrawPage(item.Group.ExamPage);
        }

        private void control_MoveUp(object sender, EventArgs e)
        {
            ExamPageItemControl control = sender as ExamPageItemControl;
            ExamPageItem item = control.Item;

            item.Group.Position--;
            DrawPage(item.Group.ExamPage);
//            int groupIndex = item.Group.ExamPage.Groups.IndexOf(item.Group);
//            if (groupIndex > 0)
//            {
//                item.Group.ExamPage.Groups.Remove(item.Group);
//                item.Group.ExamPage.Groups.Insert(groupIndex - 1, item.Group);
//
//                DrawPage(item.Group.ExamPage);
//            }
        }

        private void control_MoveDown(object sender, EventArgs e)
        {
            ExamPageItemControl control = sender as ExamPageItemControl;
            ExamPageItem item = control.Item;

            item.Group.Position++;
            DrawPage(item.Group.ExamPage);
//            int groupIndex = item.Group.ExamPage.Groups.IndexOf(item.Group);
//            if (groupIndex < item.Group.ExamPage.Groups.Count - 1)
//            {
//                item.Group.ExamPage.Groups.Remove(item.Group);
//                item.Group.ExamPage.Groups.Insert(groupIndex + 1, item.Group);
//
//                DrawPage(item.Group.ExamPage);
//            }
        }

        private bool Edit(ExamPageItem item)
        {
            ExamForm examForm = GetProcessingObject<ExamForm>();
            item.RefreshEntity();

            if (item is ExamTestQuestion)
            {
                frmExamTestQuestionDetail frm = new frmExamTestQuestionDetail(item as ExamTestQuestion, examForm.Exam.Items);
                return frm.ProcessObject();
            }
            if(item is TextPageItem)
            {
                frmTextPageItemDetail frm = new frmTextPageItemDetail(item as TextPageItem, examForm.Exam.Items);
                return frm.ProcessObject();
            }
            if(item is ExamEssayQuestion)
            {
                frmExamEssayQuestionDetail frm = new frmExamEssayQuestionDetail(item as ExamEssayQuestion, examForm.Exam.Items);
                return frm.ProcessObject();
            }
            return false;
        }

        private void ClearPanel()
        {
            panel1.Controls.Clear();
        }

        private void DrawPage(ExamPage page)
        {
            int top = 0;
            ClearPanel();

            IEnumerable<ExamPageGroup> groups = page.Groups.OrderBy(x => x.Position);
            foreach (ExamPageGroup pageGroup in groups)
            {
                IEnumerable<ExamPageItem> examPageItems = pageGroup.Items.OrderBy(x => x.Position);
                foreach (ExamPageItem item in examPageItems)
                {
                    ExamPageItemControl control = new ExamPageItemControl();
                    control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    control.Edit += new EventHandler(control_Edit);
                    control.Delete += new EventHandler(control_Delete);
                    control.MoveUp += new EventHandler(control_MoveUp);
                    control.MoveDown += new EventHandler(control_MoveDown);
                    control.Databind(item);
                    control.Top = top;
                    control.Left = 0;
                    control.Width = panel1.Width - 5;
                    panel1.Controls.Add(control);
                    top += control.Height + 5;
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            ExamForm examForm = GetProcessingObject<ExamForm>();
            ExamPage page = listView1.SelectedItems[0].Tag as ExamPage;
            DrawPage(page);
        }

        private void frmExamQuestionnaireDesigner_Resize(object sender, EventArgs e)
        {
            listView1_SelectedIndexChanged(sender, e);
        }

        private void toolStripBtnCopyPage_Click(object sender, EventArgs e)
        {
            ExamForm examForm = GetProcessingObject<ExamForm>();
            List<Core.DomainModel.Exam> exams = Fakher.Core.DomainModel.Exam.GetExams(examForm.Exam.Period, ExamType.OnlineExam);
            var examForms = from exam in exams
                            from form in exam.Forms
                            select form;

            frmSelect frm = new frmSelect("ابتدا آزمون و فرم آن را انتخاب کنید؛", examForms,
                                          new ColumnMapping {Caption = "نام آزمون", ObjectProperty = "Exam.Name"},
                                          new ColumnMapping {Caption = "رشتـه", ObjectProperty = "Exam.Lesson.Major.Name"},
                                          new ColumnMapping { Caption = "فـرم آزمون", ObjectProperty = "Name" });
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;


            ExamForm selectedExamForm = frm.GetSelectedObject<ExamForm>();
            frmSelect frm2 = new frmSelect("صفحه را انتخاب کنید؛", selectedExamForm.Pages,
                              new ColumnMapping { Caption = "نام صفحه", ObjectProperty = "Name" }
                              , new ColumnMapping { Caption = "آیتم های صفحه", ObjectProperty = "ExamItemsText" });
            if (frm2.ShowDialog(this) != DialogResult.OK)
                return;

            ExamPage page = frm2.GetSelectedObject<ExamPage>();
            
            ExamPage newExamPage = page.Clone();
            newExamPage.ExamForm = examForm;
            newExamPage.Name += " (کپی)";
            AddPage(newExamPage);
            SelectPage(newExamPage);
        }

        private void toolStripBtnDelete_Click(object sender, EventArgs e)
        {
            ExamForm examForm = GetProcessingObject<ExamForm>();
            ListViewItem item = listView1.SelectedItems[0];
            int index = listView1.Items.IndexOf(item);
            ExamPage page = item.Tag as ExamPage;
            
            if (rMessageBox.ShowQuestion("عمل حذف غیرقابل بازگشت است. آیا مطمئن هستید؟") != DialogResult.Yes)
                return;

            listView1.Items.Remove(item);

            ClearPanel();
            if ((index) < listView1.Items.Count)
                SelectPage(listView1.Items[index].Tag as ExamPage);
            else if ((index - 1) >= 0)
                SelectPage(listView1.Items[index - 1].Tag as ExamPage);
        }

        private void radBtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save(true);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
    }
}
