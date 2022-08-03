using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;

public partial class Components_ExamPage : UserControl
{
    private ExamPage mCurrentPage;

    public List<Components_ExamPageItem> Items { get; set; }

    protected void Page_Init(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void SetTestAnswers(Dictionary<int, int> answers)
    {
        foreach (Components_ExamPageItem item in Items)
        {
            if (item.Type != ExamPageItemType.ExamTestQuestion)
                continue;
            ExamTestQuestion examTestQuestion = (item.Item as ExamTestQuestion);
            int index = examTestQuestion.QuestionIndex;
            if(answers.ContainsKey(index))
            {
                int choice = answers[index];
                item.SetSelectedChoice(choice);
            }
        }
    }

    public Dictionary<int, int> GetTestAnswers()
    {
        Dictionary<int, int> result = new Dictionary<int, int>();

        foreach (Components_ExamPageItem item in Items)
        {
            if(item.Type != ExamPageItemType.ExamTestQuestion)
                continue;

            KeyValuePair<int, int> pair = item.GetSelectedChoice();
            result.Add(pair.Key, pair.Value);
        }
        return result;
    }

    public string GetTestAnswersLogText()
    {
        string txt = "";
        Dictionary<int, int> answers = GetTestAnswers();
        foreach (KeyValuePair<int, int> answer in answers)
            txt += "(" + answer.Key + "," + answer.Value + ")";
        return txt;
    }

    public void SetEssayAnswers(Dictionary<int, string> essayAnswers)
    {
        foreach (Components_ExamPageItem item in Items)
        {
            if (item.Type != ExamPageItemType.ExamEssayQuestion)
                continue;
            ExamEssayQuestion examEssayQuestion = (item.Item as ExamEssayQuestion);
            int index = examEssayQuestion.QuestionIndex;
            if (essayAnswers.ContainsKey(index))
            {
                string answer = essayAnswers[index];
                item.SetEssayAnswer(answer);
            }
        }
    }

    public Dictionary<int, string> GetEssayAnswers()
    {
        Dictionary<int, string> result = new Dictionary<int, string>();
        foreach (Components_ExamPageItem item in Items)
        {
            if (item.Type != ExamPageItemType.ExamEssayQuestion)
                continue;

            KeyValuePair<int, string> pair = item.GetEssayAnswer();
            result.Add(pair.Key, pair.Value);
        }
        return result;
    }

    public void DataBind(ExamPage page)
    {
        try
        {
            Items = new List<Components_ExamPageItem>();
            Panel1.Controls.Clear();
            mCurrentPage = page;

            IEnumerable<ExamPageGroup> groups = mCurrentPage.Groups.OrderBy(x => x.Position);
            foreach (ExamPageGroup @group in groups)
            {
                int groupIndex = mCurrentPage.Groups.IndexOf(@group);
                IEnumerable<ExamPageItem> examPageItems = @group.Items.OrderBy(x => x.Position);
                foreach (ExamPageItem item in examPageItems)
                {
                    int index = @group.Items.IndexOf(item);
                    Components_ExamPageItem userControl =
                        LoadControl("~/UserControls/ExamPageItem.ascx") as Components_ExamPageItem;
                    userControl.ID = "ExamPageItem" + groupIndex + "-" + index;
                    Items.Add(userControl);
                    Panel1.Controls.Add(userControl);
                    userControl.DataBind(item);
                }
            }
        }
        catch (Exception ex)
        {
            WebsiteManager.SaveException(Page, ex);
            throw;
        }
    }
}
