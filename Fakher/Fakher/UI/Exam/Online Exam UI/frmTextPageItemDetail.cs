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
    public partial class frmTextPageItemDetail : rRadDetailForm
    {
        public frmTextPageItemDetail(TextPageItem item, IList<ExamItem> examItems)
        {
            InitializeComponent();
            SetProcessingObject(item);

            rGridComboBox1.Columns.Add("نام", "نام", "Name");
            rGridComboBox1.DataSource = examItems;

            BindToControls();
        }
        private void BindToControls()
        {
            TextPageItem item = GetProcessingObject<TextPageItem>();

            if (item.Group != null)
                rGridComboBox1.Value = item.Group.ExamItem;

            rHtmlEditorText.DocumentText = item.Text;
        }

        private void BindToObject()
        {
            TextPageItem item = GetProcessingObject<TextPageItem>();

            if (item.Group != null)
                item.Group.ExamItem = rGridComboBox1.GetValue<ExamItem>();

            item.Text = rHtmlEditorText.BodyHtml;
            item.IsRightToLeft = rHtmlEditorText.IsRightToLeft();
        }

        protected override void AfterValidate()
        {
            if (string.IsNullOrEmpty(rHtmlEditorText.BodyHtml))
                throw new ValidationException(rHtmlEditorText, "متن را وارد کنید");
        }

        protected override void AfterBindToObject()
        {
            TextPageItem item = GetProcessingObject<TextPageItem>();

            BindToObject();
        }
    }
}
