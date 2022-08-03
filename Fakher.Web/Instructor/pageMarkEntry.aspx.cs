using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Telerik.Web.UI;
using rComponents;

public partial class Instructor_pageMarkEntry : Page
{
    private int mBatchNumber
    {
        get { return (int)ViewState["BatchNumber"]; }
        set { ViewState["BatchNumber"] = value; }
    }

//    private Lesson mLesson;
//    private MarkEntryLicense mMarkEntryLicense;


    protected void Page_Load(object sender, EventArgs e)
    {
        if(WebsiteHandler.CurrentSection == null)
        {
            Response.Redirect("~/Instructor", true);
            return;
        }

        lblLesson.Text = WebsiteHandler.CurrentSection.FarsiName + " - " + WebsiteHandler.CurrentSection.ItemsText;
        lblFormation.Text = WebsiteHandler.CurrentSection.FarsiFormationText;
        Title = "ورود نمره - " + WebsiteHandler.CurrentSection.FarsiName;

        if (!IsPostBack)
        {
            RadCmbLesson.DataSource = WebsiteHandler.CurrentSection.Items.Select(x => x.Lesson);
            RadCmbLesson.DataBind();

            if(RadCmbLesson.SelectedIndex != -1)
            {
                int lessonId = Convert.ToInt32(RadCmbLesson.SelectedValue);
                Lesson lesson = Lesson.FromId(lessonId);
                FillLicenses(lesson);
            }
        }
    }

    private IList<MarkEntryLicense> GetMarkLicenses(Lesson lesson)
    {
//        List<Major> majors = WebsiteHandler.CurrentTeacher.GetTeachingMajors().ToList();
        IList<MarkEntryLicense> licenses = MarkEntryLicense.GetMarkEntryLicenses(PersianDate.Today, DateTime.Now.Hour, DateTime.Now.Minute);
        var query = from license in licenses
                    where license.Lesson.Id == lesson.Id
                    select license;
        return query.ToList();
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("lblIndex") as Label;
            lbl.Text = e.Item.ItemIndex + 1 + "";


            int licenseId = Convert.ToInt32(RadCmbMarkEntryLicense.SelectedValue);
            MarkEntryLicense mMarkEntryLicense = MarkEntryLicense.FromId(licenseId);

            int id = Convert.ToInt32(RadGrid1.MasterTableView.DataKeyValues[e.Item.ItemIndex]["Id"]);
            Participate participate = Participate.FromId(id);
            Mark mark = participate.GetMark(mMarkEntryLicense.EvaluationItem, mBatchNumber);

            RadNumericTextBox markTextbox = e.Item.FindControl("RadTxtMark") as RadNumericTextBox;
            markTextbox.MinValue = 0;
            markTextbox.MaxValue = mMarkEntryLicense.EvaluationItem.Value;
            markTextbox.Value = mark.Value;
        }
    }

    private void FillGrid(Lesson lesson)
    {
        IList<Participate> participates = WebsiteHandler.CurrentSection.GetParticipates(lesson);

        RadGrid1.DataSource = participates;
        RadGrid1.DataBind();

        pnlMarkEntry.Visible = true;
    }

    protected void btnMarkEntry_Click(object sender, EventArgs e)
    {
        if(RadCmbLesson.SelectedIndex == -1)
        {
            rMessageBox1.ShowInformation("درس/سطح را انتخاب کنید.");
            return;
        }
        if (RadCmbMarkEntryLicense.SelectedIndex == -1)
        {
            rMessageBox1.ShowInformation("مقدار آیتم نمره انتخاب نشده است.");
            return;
        }

        int lessonId = Convert.ToInt32(RadCmbLesson.SelectedValue);
        Lesson mLesson = Lesson.FromId(lessonId);

        int licenseId = Convert.ToInt32(RadCmbMarkEntryLicense.SelectedValue);
        MarkEntryLicense mMarkEntryLicense = MarkEntryLicense.FromId(licenseId);

        IList<Participate> participates = WebsiteHandler.CurrentSection.GetParticipates(mLesson);
        if (participates.Count == 0)
        {
            rMessageBox1.ShowInformation("این درس/سطح هیچ دانشجویی ندارد.");
            return;
        }

        mBatchNumber = WebsiteHandler.CurrentSection.GetMarkBatchNumbers(mLesson, mMarkEntryLicense.EvaluationItem).FirstOrDefault();

        if (mBatchNumber == 0)
        {
            mBatchNumber = Mark.GetNextBatchNumber();

            foreach (Participate participate in participates)
//            for (int i = 0; i < RadGrid1.Items.Count; i++)
            {
//                int id = Convert.ToInt32(RadGrid1.MasterTableView.DataKeyValues[i]["Id"]);
//                Participate participate = Participate.FromId(id);
                if (participate.SectionItem.Lesson.Id != mLesson.Id)
                {
                    rMessageBox1.ShowInformation("درس/سطح انتخاب شده با درس/سطح دانشجوها متفاوت است.");
                    return;
                }

                Mark mark = participate.CreateMark(mLesson, mMarkEntryLicense.EvaluationItem, PersianDate.Today, mBatchNumber);
                mark.BatchNumber = mBatchNumber;
                participate.Marks.Add(mark);
                participate.Save();
            }
        }

        FillGrid(mLesson);
    }

    protected void RadCmbLesson_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        int lessonId = Convert.ToInt32(RadCmbLesson.SelectedValue);
        Lesson lesson = Lesson.FromId(lessonId);
        FillLicenses(lesson);
    }

    private void FillLicenses(Lesson lesson)
    {
        IList<MarkEntryLicense> licenses = GetMarkLicenses(lesson);
        RadCmbMarkEntryLicense.DataSource = licenses;
        RadCmbMarkEntryLicense.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (RadCmbLesson.SelectedIndex == -1)
        {
            rMessageBox1.ShowInformation("درس/سطح را انتخاب کنید.");
            return;
        }
        if (RadCmbMarkEntryLicense.SelectedIndex == -1)
        {
            rMessageBox1.ShowInformation("مقدار آیتم نمره انتخاب نشده است.");
            return;
        }
        if(mBatchNumber == 0)
        {
            rMessageBox1.ShowInformation("خطا در ثبت نمرات");
            return;
        }

        int lessonId = Convert.ToInt32(RadCmbLesson.SelectedValue);
        Lesson mLesson = Lesson.FromId(lessonId);

        int licenseId = Convert.ToInt32(RadCmbMarkEntryLicense.SelectedValue);
        MarkEntryLicense mMarkEntryLicense = MarkEntryLicense.FromId(licenseId);

        IList<Participate> participates = WebsiteHandler.CurrentSection.GetParticipates(mLesson);
        if (participates.Count == 0)
        {
            rMessageBox1.ShowInformation("این درس/سطح هیچ دانشجویی ندارد.");
            return;
        }

        string entryCode = RadTxtEntryCode.Text.Trim();
        if(entryCode != mMarkEntryLicense.EntryCode)
        {
            rMessageBox1.ShowInformation("کد ورود نمره اشتباه است.");
            return;
        }

        for (int i = 0; i < RadGrid1.Items.Count; i++)
        {
            GridDataItem gridDataItem = RadGrid1.Items[i];
            int id = Convert.ToInt32(RadGrid1.MasterTableView.DataKeyValues[i]["Id"]);
            RadNumericTextBox markTextbox = gridDataItem.FindControl("RadTxtMark") as RadNumericTextBox;
            
            Participate participate = Participate.FromId(id);

            if (markTextbox.Value == null)
            {
                rMessageBox1.ShowInformation("امکان ثبت نمره {0} وجود ندارد. لطفا این نمره را در محدوده مشخص و به صورت معتبر وارد کنید.", false, participate.Register.Student.FarsiFullname);
                return;
            }

            Mark mark = participate.GetMark(mMarkEntryLicense.EvaluationItem, mBatchNumber);
            mark.BatchNumber = mBatchNumber;
            mark.Value = (float) markTextbox.Value;
            mark.Save();
        }

        pnlMarkEntry.Visible = false;
        rMessageBox1.ShowInformation("نمرات با موفقیت ثبت و ذخیره شدند.");
    }
}
