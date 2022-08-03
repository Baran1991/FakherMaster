using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Telerik.Web.UI;
using rComponents;

public partial class Student_pageInterviewEnroll : Page
{
    private int mSelectedExamId
    {
        get { return Convert.ToInt32(ViewState["SelectedExamId"]); }
        set { ViewState["SelectedExamId"] = value; }
    }

    private int mSelectedExamFormId
    {
        get { return Convert.ToInt32(ViewState["SelectedExamFormId"]); }
        set { ViewState["SelectedExamFormId"] = value; }
    }

    private int mSelectedFormationId
    {
        get { return Convert.ToInt32(ViewState["SelectedFormationId"]); }
        set { ViewState["SelectedFormationId"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Fill();
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        bool setting = WebsiteManager.GetAppSetting<bool>(WebsiteHandler.OralExamEnrollmentKey);
        if (!setting)
        {
            rMessageBox1.ShowInformation("امکان ثبت نام اینترنتی آزمون های مصاحبه توسط مدیر سیستم غیرفعال است.", true);
            return;
        }
    }

    protected void rMessageBox1_DialogResult(object sender, EventArgs e)
    {
        Response.Redirect("~/Student/Default.aspx", true);
    }

    private void Fill()
    {
        IList<Exam> enrollableExams = WebsiteHandler.CurrentRegister.GetEnrollableExams(ExamType.OralExam, false, true, PersianDate.Today);
        RadGrid1.DataSource = enrollableExams;
        RadGrid1.DataBind();
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("lblIndex") as Label;
            lbl.Text = e.Item.ItemIndex + 1 + "";

            RadButton button = e.Item.FindControl("btnSelect") as RadButton;
            button.CommandArgument = HttpServerUtility.UrlTokenEncode(Encoding.UTF8.GetBytes((e.Item.DataItem as Exam).Id + ""));
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        RadButton button = sender as RadButton;
        string idText = Encoding.UTF8.GetString(HttpServerUtility.UrlTokenDecode(button.CommandArgument));
        Exam exam = Exam.FromId(Convert.ToInt32(idText));

        IQueryable<ExamForm> freeExamForms = exam.GetFreeExamForms();
        IQueryable<Formation> freeFormations = exam.ExamHolding.GetFreeFormations();

        if (!exam.HasHolding)
        {
            rMessageBox1.ShowInformation("خطا: برگزاری این آزمون نامعتبر است");
            return;
        }

        if (exam.IsSignedUp(WebsiteHandler.CurrentRegister))
        {
            rMessageBox1.ShowInformation("شما قبلا در همین آزمون ثبت نام شده اید.", true);
            return;
        }

        if(freeExamForms.Count() == 0)
        {
            rMessageBox1.ShowInformation("ظرفیت همه فرمهای آزمون پر شده است. امکان ثبت نام در این مصاحبه وجود ندارد.");
            return;
        }

        if(freeFormations.Count() == 0)
        {
            rMessageBox1.ShowInformation("ظرفیت همه زمانهای آزمون پر شده است. امکان ثبت نام در این مصاحبه وجود ندارد.");
            return;
        }

        RadCmbExamForm.DataSource = freeExamForms;
        RadCmbExamForm.DataBind();

        RadCmbExamFormation.DataSource = freeFormations;
        RadCmbExamFormation.DataBind();

        mSelectedExamId = exam.Id;
        RadWindow1.Visible = true;
    }

    protected void radBtnOk_Click(object sender, EventArgs e)
    {
        if(mSelectedExamId == 0)
        {
            rMessageBox1.ShowInformation("خطا");
            return;
        }
        if(string.IsNullOrEmpty(RadCmbExamForm.SelectedValue))
        {
            rMessageBox1.ShowInformation("فرم آزمون را انتخاب کنید.");
            return;
        }
        if(string.IsNullOrEmpty(RadCmbExamFormation.SelectedValue))
        {
            rMessageBox1.ShowInformation("زمان/مکان آزمون را انتخاب کنید.");
            return;
        }
        Exam exam = Exam.FromId(mSelectedExamId);
        ExamForm selectedExamForm = ExamForm.FromId(Convert.ToInt32(RadCmbExamForm.SelectedValue));
        Formation selectedExamFormation = Formation.FromId(Convert.ToInt32(RadCmbExamFormation.SelectedValue));

        mSelectedExamFormId = selectedExamForm.Id;
        mSelectedFormationId = selectedExamFormation.Id;


        lblExam.Text = exam.Name;
        lblExamForm.Text = selectedExamForm.Name;
        lblFormation.Text = selectedExamFormation.FarsiText;

        Panel1.Visible = false;
        pnlAbstract.Visible = true;
        RadWindow1.Visible = false;
    }

    protected void radBtnCancel_Click(object sender, EventArgs e)
    {
        ClearSelection();
        RadWindow1.Visible = false;
    }

    private void ClearSelection()
    {
        mSelectedExamId = 0;
        mSelectedExamFormId = 0;
        mSelectedFormationId = 0;
    }

    protected void btnPrev_Click(object sender, EventArgs e)
    {
        pnlAbstract.Visible = false;
        Panel1.Visible = true;
        ClearSelection();
    }

    protected void btnPay_Click(object sender, EventArgs e)
    {
        if (mSelectedExamId == 0)
        {
            rMessageBox1.ShowInformation("خطا");
            return;
        }
        if (mSelectedExamFormId == 0)
        {
            rMessageBox1.ShowInformation("فرم آزمون را انتخاب کنید.");
            return;
        }
        if (mSelectedFormationId == 0)
        {
            rMessageBox1.ShowInformation("زمان/مکان آزمون را انتخاب کنید.");
            return;
        }

        Exam exam = Exam.FromId(mSelectedExamId);
        ExamForm selectedExamForm = ExamForm.FromId(mSelectedExamFormId);
        Formation selectedExamFormation = Formation.FromId(mSelectedFormationId);
        ExamParticipate mExamParticipate;

        try
        {
            WebsiteManager.IsInExamEnrollmentPhase();

            IQueryable<ExamParticipate> examParticipates = WebsiteHandler.CurrentRegister.GetExamParticipates();
            for (int i = examParticipates.Count() - 1; i >= 0; i--)
            {
                ExamParticipate examParticipate = examParticipates.ElementAt(i);
                if (examParticipate.InternetRegisteration && !examParticipate.EnrollmentConfirmed)
                {
                    WebsiteHandler.CurrentRegister.RemoveExamParticipate(examParticipate);
                    examParticipate.Delete();
                }
            }

            mExamParticipate = selectedExamForm.Signup(WebsiteHandler.CurrentRegister, selectedExamFormation, false, false);
            mExamParticipate.InternetRegisteration = true;
            mExamParticipate.Save();
        }
        catch (MessageException ex)
        {
            rMessageBox1.ShowInformation(ex.Message);
            return;
        }
        catch (Exception ex)
        {
            WebsiteManager.SaveException(this, ex);
            rMessageBox1.ShowInformation("خطا در هنگام ثبت نام در آزمون");
            return;
        }

        try
        {
            long amount = mExamParticipate.PayableTuition;

            if (amount > 0)
            {
                MellatPayTransaction payTransaction = new MellatPayTransaction();
                payTransaction.Person = WebsiteHandler.CurrentRegister.Student;
                payTransaction.Amount = amount;
                payTransaction.Description = "ثبت نام مصاحبه " + WebsiteHandler.CurrentRegister.Student.FarsiFullname +
                                             " در " + exam.Name;

                payTransaction.AddItem(PayTransactionItemType.ElectronicPayment, amount,
                                       mExamParticipate.FinancialDocument, "پرداخت اینترنتی", FinancialHeading.Signup);

                // Get Id
                payTransaction.Save();
                WebsiteHandler.CurrentPayTransaction = payTransaction;

                WebsiteHandler.CurrentPayTransaction.Start("http://www.fakher.ac.ir/pageMellatHandler.aspx");
                WebsiteHandler.CurrentPayTransaction.Save();

                WebsiteHandler.CurrentExamParticipate = mExamParticipate;

                WebsiteHandler.ReturnPageUrl = "~/Student/rptExamCard.aspx";
                Response.Redirect("~/pagePayRequest.aspx");
                return;
            }
            else
            {
                mExamParticipate.ConfirmEnrollment();
                mExamParticipate.Save();

                if (!WebsiteHandler.CurrentRegister.EnrollmentConfirmed)
                    WebsiteHandler.CurrentRegister.ConfirmEnrollment();
                WebsiteHandler.CurrentRegister.Save();

                WebsiteHandler.CurrentExamParticipate = mExamParticipate;
                Response.Redirect("~/Student/rptExamCard.aspx");
                return;
            }
        }
        catch (Exception ex)
        {
            WebsiteManager.SaveException(this, ex);
            rMessageBox1.ShowInformation("متاسفانه بانک ملت در حال حاضر نمی تواند پاسخگوی شما باشد. لطفا بعدا مراجعه فرمایید.");
            return;
        }
    }
}
