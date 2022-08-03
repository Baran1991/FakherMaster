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

namespace Fakher.UI.Exam.Online_Exam_UI
{
    public partial class frmExamTestQuestionDetail : rRadDetailForm
    {
        public frmExamTestQuestionDetail(ExamTestQuestion testQuestion, IList<ExamItem> examItems)
        {
            InitializeComponent();
            SetProcessingObject(testQuestion);

            rGridComboBox1.Columns.Add("نام", "نام", "Name");
            rGridComboBox1.DataSource = examItems;
            
            BindToControls();
        }

        private void BindToControls()
        {
            ExamTestQuestion testQuestion = GetProcessingObject<ExamTestQuestion>();

            if (testQuestion.Group != null)
                rGridComboBox1.Value = testQuestion.Group.ExamItem;


            while (rHtmlEditorText.Document == null || rHtmlEditorText.Document.Body == null)
                Application.DoEvents();
            rHtmlEditorText.Document.OpenNew(true).Write(testQuestion.Text);

            if (!string.IsNullOrEmpty(testQuestion.Choice1))
            {
                while (rHtmlEditorChoice1.Document == null || rHtmlEditorChoice1.Document.Body == null)
                    Application.DoEvents();
                rHtmlEditorChoice1.Document.OpenNew(true).Write(testQuestion.Choice1);
            }
            if (!string.IsNullOrEmpty(testQuestion.Choice2))
            {
                while (rHtmlEditorChoice2.Document == null || rHtmlEditorChoice2.Document.Body == null)
                    Application.DoEvents();
                rHtmlEditorChoice2.Document.OpenNew(true).Write(testQuestion.Choice2);
            }
            if (!string.IsNullOrEmpty(testQuestion.Choice3))
            {
                while (rHtmlEditorChoice3.Document == null || rHtmlEditorChoice3.Document.Body == null)
                    Application.DoEvents();
                rHtmlEditorChoice3.Document.OpenNew(true).Write(testQuestion.Choice3);
            }
            if (!string.IsNullOrEmpty(testQuestion.Choice4))
            {
                while (rHtmlEditorChoice4.Document == null || rHtmlEditorChoice4.Document.Body == null)
                    Application.DoEvents();
                rHtmlEditorChoice4.Document.OpenNew(true).Write(testQuestion.Choice4);
            }
            
            
            //rHtmlEditorText.DocumentText = testQuestion.Text;
            //rHtmlEditorChoice1.DocumentText = testQuestion.Choice1;
            //rHtmlEditorChoice2.DocumentText = testQuestion.Choice2;
            //rHtmlEditorChoice3.DocumentText = testQuestion.Choice3;
            //rHtmlEditorChoice4.DocumentText = testQuestion.Choice4;
        }

        private void BindToObject()
        {
            ExamTestQuestion testQuestion = GetProcessingObject<ExamTestQuestion>();

            if (testQuestion.Group != null)
                testQuestion.Group.ExamItem = rGridComboBox1.GetValue<ExamItem>();

            testQuestion.Text = rHtmlEditorText.BodyHtml;
            testQuestion.Choice1 = rHtmlEditorChoice1.BodyHtml;
            testQuestion.Choice2 = rHtmlEditorChoice2.BodyHtml;
            testQuestion.Choice3 = rHtmlEditorChoice3.BodyHtml;
            testQuestion.Choice4 = rHtmlEditorChoice4.BodyHtml;

            testQuestion.IsRightToLeft = rHtmlEditorText.IsRightToLeft();
            testQuestion.Choice1RightToLeft = rHtmlEditorChoice1.IsRightToLeft();
            testQuestion.Choice2RightToLeft = rHtmlEditorChoice2.IsRightToLeft();
            testQuestion.Choice3RightToLeft = rHtmlEditorChoice3.IsRightToLeft();
            testQuestion.Choice4RightToLeft = rHtmlEditorChoice4.IsRightToLeft();
//            question.IsRightToLeft = rHtmlEditorText.BlockRightToLeft;
//            question.Choice1RightToLeft = rHtmlEditorChoice1.BlockRightToLeft;
//            question.Choice2RightToLeft = rHtmlEditorChoice2.BlockRightToLeft;
//            question.Choice3RightToLeft = rHtmlEditorChoice3.BlockRightToLeft;
//            question.Choice4RightToLeft = rHtmlEditorChoice4.BlockRightToLeft;
        }

        private void rHtmlEditorText_Enter(object sender, EventArgs e)
        {
            rHtmlEditor rHtmlEditor = sender as rHtmlEditor;
            rHtmlEditorToolbar1.HtmlEditor = rHtmlEditor;
        }

        protected override void AfterValidate()
        {
            if (string.IsNullOrEmpty(rHtmlEditorText.BodyHtml))
                throw new ValidationException(rHtmlEditorText, "متن سئوال را وارد کنید");
            //if (string.IsNullOrEmpty(rHtmlEditorChoice1.BodyHtml))
            //    throw new ValidationException(rHtmlEditorChoice1, "متن گزینه 1 را وارد کنید");
            //if (string.IsNullOrEmpty(rHtmlEditorChoice2.BodyHtml))
            //    throw new ValidationException(rHtmlEditorChoice2, "متن گزینه 2 را وارد کنید");
            //if (string.IsNullOrEmpty(rHtmlEditorChoice3.BodyHtml))
            //    throw new ValidationException(rHtmlEditorChoice3, "متن گزینه 3 را وارد کنید");
            //if (string.IsNullOrEmpty(rHtmlEditorChoice4.BodyHtml))
            //    throw new ValidationException(rHtmlEditorChoice4, "متن گزینه 4 را وارد کنید");
        } 

        protected override void AfterBindToObject()
        {
            ExamTestQuestion testQuestion = GetProcessingObject<ExamTestQuestion>();

            BindToObject();
        }

        private void frmExamQuestionDetail_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void rHtmlEditorToolbar1_DirectionChanged(object sender, DirectionChangedEventArgs e)
        {

        }
    }
}
