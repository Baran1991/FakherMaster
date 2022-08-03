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

public partial class Student_pageExamEnroll : Page
{
    private int mCurrentStep
    {
        get
        {
            if (ViewState["CurrentStep"] != null)
                return (int)ViewState["CurrentStep"];
            return 0;
        }
        set { ViewState["CurrentStep"] = value; }
    }

    public IList<int> SelectedExamIds
    {
        get
        {
            if (Session["SelectedExamIds"] != null)
                return Session["SelectedExamIds"] as IList<int>;
            return null;
        }
        set
        {
            if (value == null)
                Session.Remove("SelectedExamIds");
            else
                Session["SelectedExamIds"] = value;
        }
    }

    public IList<int> EnrolledExamParticipateIds
    {
        get
        {
            if (Session["EnrolledExamParticipateIds"] != null)
                return Session["EnrolledExamParticipateIds"] as IList<int>;
            return null;
        }
        set
        {
            if (value == null)
                Session.Remove("EnrolledExamParticipateIds");
            else
                Session["EnrolledExamParticipateIds"] = value;
        }
    }

    public IList<ExamParticipate> EnrolledExamParticipates
    {
        get
        {
            IList<ExamParticipate> examParticipates = new List<ExamParticipate>();
            foreach (int id in EnrolledExamParticipateIds)
            {
                ExamParticipate examParticipate = ExamParticipate.FromId(id);
                examParticipates.Add(examParticipate);
            }
            return examParticipates;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
//        if (WebsiteHandler.CurrentRegister.Student.Id != 104)
//        {
//            Response.Redirect("~/Student/Default.aspx", true);
//            return;
//        }

//        if (!WebsiteHandler.CurrentRegister.InternetRegisteration)
//        {
//            Response.Redirect("~/Student/Default.aspx", true);
//            return;
//        }

        if(!IsPostBack)
        {
            SelectedExamIds = new List<int>();
            EnrolledExamParticipateIds = new List<int>();
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        bool setting = WebsiteManager.GetAppSetting<bool>(WebsiteHandler.OnlineExamEnrollmentKey);
        if (!setting)
        {
            rMessageBox1.ShowInformation("امکان ثبت نام اینترنتی آزمون های آنلاین توسط مدیر سیستم غیرفعال است.", true);
            return;
        }

        if(mCurrentStep == 0)
        {
            FillStep0();
        }

        if (mCurrentStep == 1)
        {
            WebsiteManager.IsInExamEnrollmentPhase();
            FillStep1();
        }

        pnlStep0.Visible = mCurrentStep == 0;
        pnlStep1.Visible = mCurrentStep == 1;
    }

    private void FillStep0()
    {
        IList<Exam> exams = WebsiteHandler.CurrentRegister.GetEnrollableExams(ExamType.OnlineExam, true, false, PersianDate.Today);

        if(exams.Count == 0)
        {
            rMessageBox1.ShowInformation("برای شما در رشته {0} و ترم {1} هیچ آزمون با قابلیت ثبت نام اینترنتی وجود ندارد.", true,
                                         WebsiteHandler.CurrentRegister.Major.Name,
                                         WebsiteHandler.CurrentRegister.Period.Name);
            return;
        }

        Repeater1.DataSource = exams;
        Repeater1.DataBind();
    }

    private void FillStep1()
    {
        List<Exam> exams = new List<Exam>();
        foreach (int examId in SelectedExamIds)
        {
            Exam exam = Exam.FromId(examId);
            exams.Add(exam);
        }

        RadGrid3.DataSource = exams;
        RadGrid3.DataBind();

        long sum = 0;
        foreach (Exam exam in exams)
            sum += exam.GetTuitionFee(WebsiteHandler.CurrentRegister.Major,
                                      WebsiteHandler.CurrentRegister.GetRegisterParticipation(false, true));
        lblPayableAmout.Text = sum.ToString("C0");
    }

//    private IList<ExamParticipate> GetEnrolledExamParticipates()
//    {
//        IList<ExamParticipate> examParticipates = new List<ExamParticipate>();
//        foreach (int id in EnrolledExamParticipateIds)
//        {
//            ExamParticipate examParticipate = ExamParticipate.FromId(id);
//            examParticipates.Add(examParticipate);
//        }
//        return examParticipates;
//    }

    protected void rMessageBox1_DialogResult(object sender, EventArgs e)
    {
        Response.Redirect("~/Student/Default.aspx", true);
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("lblIndex") as Label;
            lbl.Text = e.Item.ItemIndex + 1 + "";
        }
    }

    protected void btnNext0_Click(object sender, EventArgs e)
    {
        SelectedExamIds.Clear();
        foreach (RepeaterItem item in Repeater1.Items)
        {
            CheckBox checkBox = item.FindControl("chkSelect") as CheckBox;
            HiddenField fieldId = item.FindControl("hFieldId") as HiddenField;

            if (checkBox.Checked)
            {
                int id = Convert.ToInt32(fieldId.Value);
                Exam exam = Exam.FromId(id);
                SelectedExamIds.Add(exam.Id);
            }
        }

        if (!chkPolicy.Checked)
        {
            rMessageBox1.ShowInformation("برای ثبت نام، باید شرایط ثبت نام را بپذیرید و آن را تیک بزنید.");
            return;
        }

        if (SelectedExamIds.Count == 0)
        {
            rMessageBox1.ShowInformation("آزمون های موردنظر خود را تیک بزنید.");
            return;
        }

        mCurrentStep++;
    }

    protected void btnPrev_Click(object sender, EventArgs e)
    {
        mCurrentStep--;
    }

    protected void btnNext2_Click(object sender, EventArgs e)
    {
        try
        {
            WebsiteManager.IsInExamEnrollmentPhase();

            if (SelectedExamIds.Count == 0)
                throw new MessageException("آزمون های انتخابی شما از سیستم حذف گردیده اند. آزمون ها را مجددا انتخاب کنید.");

            IQueryable<ExamParticipate> examParticipates = WebsiteHandler.CurrentRegister.GetExamParticipates();
            for (int i = examParticipates.Count() - 1; i >= 0 ; i--)
            {
                ExamParticipate examParticipate = examParticipates.ElementAt(i);
                if (examParticipate.InternetRegisteration && !examParticipate.EnrollmentConfirmed)
                {
                    WebsiteHandler.CurrentRegister.RemoveExamParticipate(examParticipate);
                    examParticipate.Delete();
                }
            }

            foreach (int examId in SelectedExamIds)
            {
                Exam exam = Exam.FromId(examId);

                ExamForm mSelectedExamForm = exam.GetNextFreeExamForm();
                if (mSelectedExamForm == null)
                    mSelectedExamForm = exam.GetRandomExamForm();
                Formation mSelectedExamFormation = exam.ExamHolding.GetRandomFormation();

                if (exam.IsSignedUp(WebsiteHandler.CurrentRegister))
                    continue;

                ExamParticipate mExamParticipate = mSelectedExamForm.Signup(WebsiteHandler.CurrentRegister,
                                                                            mSelectedExamFormation, true, false);
                mExamParticipate.InternetRegisteration = true;
                mExamParticipate.PrepareExamCardForDelivery();
                mExamParticipate.Save();

                EnrolledExamParticipateIds.Add(mExamParticipate.Id);
            }

            WebsiteHandler.CurrentRegister.Student.EnsureDefaultDocumentActivation();
            WebsiteHandler.CurrentRegister.Student.Save();
        }
        catch (MessageException ex)
        {
            WebsiteManager.SaveException(this, ex);
            rMessageBox1.ShowInformation(ex.Message);
            return;
        }
        catch (Exception ex)
        {
            WebsiteManager.SaveException(this, ex);
            rMessageBox1.ShowInformation("خطا در فرآیند ثبت نام");
            return;
        }

        try
        {
            long amount = EnrolledExamParticipates.Sum(x => x.PayableTuition);

            MellatPayTransaction payTransaction = new MellatPayTransaction();
            payTransaction.Person = WebsiteHandler.CurrentRegister.Student;
            payTransaction.Amount = amount;
            payTransaction.Description = "ثبت نام آزمون " + WebsiteHandler.CurrentRegister.Student.FarsiFullname + "- رشته " + WebsiteHandler.CurrentRegister.Major.Name + "- ترم " + WebsiteHandler.CurrentRegister.Period.Name;

            string text = "افزایش اعتبار " + WebsiteHandler.CurrentRegister.Student.FarsiFullname;
            payTransaction.AddItem(PayTransactionItemType.ElectronicPayment, amount,
                                   WebsiteHandler.CurrentRegister.Student.DefaultDocument, text, FinancialHeading.Signup);

            foreach (ExamParticipate examParticipate in EnrolledExamParticipates)
            {
                text = "ثبت نام " + examParticipate.Register.Student.FarsiFullname + " در آزمون " +
                            examParticipate.ExamForm.Exam.Name + " - رشته " +
                            examParticipate.ExamForm.Exam.Lesson.Major.Name;

                payTransaction.AddItem(PayTransactionItemType.Debt, examParticipate.PayableTuition,
                       WebsiteHandler.CurrentRegister.Student.DefaultDocument, text, FinancialHeading.Signup);

                payTransaction.AddItem(PayTransactionItemType.Credit, examParticipate.PayableTuition,
                                       examParticipate.FinancialDocument, text, FinancialHeading.Signup);
            }


            // Get Id
            payTransaction.Save();
            WebsiteHandler.CurrentPayTransaction = payTransaction;

            WebsiteHandler.CurrentPayTransaction.Start("http://www.fakher.ac.ir/pageMellatHandler.aspx");
            WebsiteHandler.CurrentPayTransaction.Save();

            WebsiteHandler.ReturnPageUrl = "~/Student/Default.aspx";
            Response.Redirect("~/pagePayRequest.aspx");
            return;
        }
        catch (Exception ex)
        {
            WebsiteManager.SaveException(this, ex);
            rMessageBox1.ShowInformation("متاسفانه بانک ملت در حال حاضر نمی تواند پاسخگوی شما باشد. لطفا بعدا مراجعه فرمایید.");
            return;
        }
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        CheckBox checkBox = e.Item.FindControl("chkSelect") as CheckBox;
        HiddenField fieldId = e.Item.FindControl("hFieldId") as HiddenField;

        checkBox.Checked = SelectedExamIds.Contains(Convert.ToInt32(fieldId.Value));
    }
}
