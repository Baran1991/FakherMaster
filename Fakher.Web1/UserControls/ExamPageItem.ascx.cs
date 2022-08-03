using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;

public partial class Components_ExamPageItem : UserControl
{
    public ExamPageItemType Type { get; set; }
    public ExamPageItem Item { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void ResetChoices()
    {
        RadioButton1.Checked = false;
        RadioButton2.Checked = false;
        RadioButton3.Checked = false;
        RadioButton4.Checked = false;
    }

    public void SetSelectedChoice(int choice)
    {
        ResetChoices();
        RadioButton1.Checked = choice == 1;
        RadioButton2.Checked = choice == 2;
        RadioButton3.Checked = choice == 3;
        RadioButton4.Checked = choice == 4;
    }

    public KeyValuePair<int, int> GetSelectedChoice()
    {
        int selectedChoice = 0;
        if (RadioButton1.Checked)
            selectedChoice = 1;
        if (RadioButton2.Checked)
            selectedChoice = 2;
        if (RadioButton3.Checked)
            selectedChoice = 3;
        if (RadioButton4.Checked)
            selectedChoice = 4;
        return new KeyValuePair<int, int>((Item as ExamTestQuestion).QuestionIndex, selectedChoice);
    }

    public void SetEssayAnswer(string answer)
    {
        txtEssayText.Text = answer;
    }

    public KeyValuePair<int,string> GetEssayAnswer()
    {
        string text = txtEssayText.Text.Trim();
        return new KeyValuePair<int, string>((Item as ExamEssayQuestion).QuestionIndex, HttpUtility.HtmlEncode(text));
    }

    public void DataBind(ExamPageItem item)
    {
        Item = item;

        if(item is TextPageItem)
        {
            LiteralText.Text = WebsiteManager.PrepareHtml(item.Text);
            pnlTextPageItem.Visible = true;
            Type = ExamPageItemType.Text;
            if (item.Attachment != null)
            {
              
                if (item.Attachment != null)
                {
                    var base64String = Convert.ToBase64String(item.Attachment.Bytes);
                    var src = "data:" + item.Attachment.MimeType + ";base64," + base64String;
                    attachment.Value = src;
                }
            }
        }
        else if(item is ExamTestQuestion)
        {
            ExamTestQuestion testQuestion = item as ExamTestQuestion;
            lblTestIndex.Text = testQuestion.QuestionIndex + ". ";
            LiteralTestQuestionText.Text = WebsiteManager.PrepareHtml(item.Text);
            if(item.Attachment!=null)
            {
                //attachment.HRef = "~/Media.aspx?c=" + item.Attachment.Code;
                //attachment.InnerHtml = "نمایش فایل";
                if (item.Attachment!=null)
                {
                    var base64String = Convert.ToBase64String(item.Attachment.Bytes);
                    var src = "data:"+item.Attachment.MimeType+";base64," + base64String;
                    //videoAttachment.Attributes.
                    attachment.Value = src;
                    //videoAttachment.FindControl("videoSource").
                }
            }
            RadioButton1.GroupName = "Choices-" + ID;
            RadioButton1.Attributes.Add("onclick", String.Format("myClick(document.getElementById('{0}'));", RadioButton1.ClientID));
            RadioButton1.Attributes.Add("onmousedown", string.Format("myMouseDown(document.getElementById('{0}'));", RadioButton1.ClientID));
            Literal1.Text = WebsiteManager.PrepareHtml(testQuestion.Choice1);

       
            RadioButton2.GroupName = "Choices-" + ID;
            RadioButton2.Attributes.Add("onclick", string.Format("myClick(document.getElementById('{0}'));", RadioButton2.ClientID));
            RadioButton2.Attributes.Add("onmousedown", string.Format("myMouseDown(document.getElementById('{0}'));", RadioButton2.ClientID));
            Literal2.Text = WebsiteManager.PrepareHtml(testQuestion.Choice2);

            RadioButton3.GroupName = "Choices-" + ID;
            RadioButton3.Attributes.Add("onclick", string.Format("myClick(document.getElementById('{0}'));", RadioButton3.ClientID));
            RadioButton3.Attributes.Add("onmousedown", string.Format("myMouseDown(document.getElementById('{0}'));", RadioButton3.ClientID));
            Literal3.Text = WebsiteManager.PrepareHtml(testQuestion.Choice3);

            RadioButton4.GroupName = "Choices-" + ID;
            RadioButton4.Attributes.Add("onclick", string.Format("myClick(document.getElementById('{0}'));", RadioButton4.ClientID));
            RadioButton4.Attributes.Add("onmousedown", string.Format("myMouseDown(document.getElementById('{0}'));", RadioButton4.ClientID));
            Literal4.Text = WebsiteManager.PrepareHtml(testQuestion.Choice4);
            if (string.IsNullOrEmpty(testQuestion.Choice1))
            {
                q1.Visible = false;
            }
            if (string.IsNullOrEmpty(testQuestion.Choice2))
            {
                q2.Visible = false;
            }
            if (string.IsNullOrEmpty(testQuestion.Choice3))
            {
                q3.Visible = false;
            }
            if (string.IsNullOrEmpty(testQuestion.Choice4))
            {
                q4.Visible = false;
            }
            if (testQuestion.CanViewAnswerDescription)
            {
                btnShowDesc.Visible = true;
                Literal1desc.Text = WebsiteManager.PrepareHtml(testQuestion.Choice1Desc);
                Literal2desc.Text = WebsiteManager.PrepareHtml(testQuestion.Choice2Desc);
                Literal3desc.Text = WebsiteManager.PrepareHtml(testQuestion.Choice3Desc);
                Literal4desc.Text = WebsiteManager.PrepareHtml(testQuestion.Choice4Desc);
                if (testQuestion.CorrectAnswer == 1)
                    RadioButton1.CssClass = "correct";
                if (testQuestion.CorrectAnswer == 2)
                    RadioButton2.CssClass = "correct";
                if (testQuestion.CorrectAnswer == 3)
                    RadioButton3.CssClass = "correct";
                if (testQuestion.CorrectAnswer == 4)
                    RadioButton4.CssClass = "correct";
            }
            pnlExamTestQuestion.Visible = true;
            Type = ExamPageItemType.ExamTestQuestion;
        }
        else if(item is ExamEssayQuestion)
        {
            ExamEssayQuestion essayQuestion = item as ExamEssayQuestion;
            lblEssayIndex.Text = essayQuestion.QuestionIndex + ". ";
            LiteralEssayQuestionText.Text = WebsiteManager.PrepareHtml(essayQuestion.Text);
            txtEssayText.Text = "";

            pnlExamEssayQuestion.Visible = true;
            Type = ExamPageItemType.ExamEssayQuestion;
            if (item.Attachment != null)
            {
               
                if (item.Attachment != null)
                {
                    var base64String = Convert.ToBase64String(item.Attachment.Bytes);
                    var src = "data:" + item.Attachment.MimeType + ";base64," + base64String;
                    attachment1.Value = src;
                 }
            }
        }

        //if (item.Group.ExamItem.Exam != null)
        {
            //if (item.Group.ExamItem.Exam.isFarsi)
            if(item.IsRightToLeft)
            {
                pnlExamTestQuestion.Style.Add("direction", "rtl");
                //pnlExamTestQuestion.Style.Add("font-family", "rtl");

                pnlTextPageItem.Style.Add("direction", "rtl");
                pnlExamEssayQuestion.Style.Add("direction", "rtl");

                pnlExamTestQuestion.Style.Add("text-align", "right");
                pnlTextPageItem.Style.Add("text-align", "right");
                pnlExamEssayQuestion.Style.Add("text-align", "right");

                pnlTextPageItem.Direction = pnlExamTestQuestion.Direction = pnlExamEssayQuestion.Direction = ContentDirection.RightToLeft;
            }
            else
            {
                pnlExamTestQuestion.Style.Add("direction", "ltr");
                pnlTextPageItem.Style.Add("direction", "ltr");
                pnlExamEssayQuestion.Style.Add("direction", "ltr");

                pnlExamTestQuestion.Style.Add("text-align", "left");
                pnlTextPageItem.Style.Add("text-align", "left");
                pnlExamEssayQuestion.Style.Add("text-align", "left");

                pnlTextPageItem.Direction = pnlExamTestQuestion.Direction = pnlExamEssayQuestion.Direction = ContentDirection.LeftToRight;
            }
        }
    }
}

public enum ExamPageItemType
{
    ExamTestQuestion,
    Text,
    ExamEssayQuestion,
}
