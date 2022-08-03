using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Telerik.Web.UI;
using Fakher.Core.Website;
using rComponents;

public partial class Student_pageSectionEnroll : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentStudent == null
            || WebsiteHandler.CurrentRegister == null
                || WebsiteHandler.CurrentStudentConfiguration == null
            || WebsiteHandler.CurrentEnrollmentLicense == null)
        {
            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentStudent, "Entities is Null in Page_Load(Redirect)");
            Response.Redirect("~/Student/Enrollment/pageSectionEnrollment1.aspx", true);
            return;
        }

        if (WebsiteHandler.CurrentRegister.EnrollmentConfirmed)
        {
            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentStudent, "Confirmed Register in Load(Redirect)");
            Response.Redirect("~/Student/Enrollment/pageSectionEnrollment1.aspx", true);
            return;
        }


        if (!IsPostBack)
        {

        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        Fill();
    }

    private void Fill()
    {
        if (WebsiteHandler.CurrentStudent == null
            || WebsiteHandler.CurrentRegister == null
                || WebsiteHandler.CurrentStudentConfiguration == null)
        {
            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentStudent, "Entities is Null in Fill(Redirect)");
            Response.Redirect("~/Student/Enrollment/Default.aspx", true);
            return;
        }

        List<SectionItem> result = new List<SectionItem>();
        foreach (EnrollableLesson enrollableLesson in WebsiteHandler.CurrentStudentConfiguration.EnrollableLessons)
        {
            if (!WebsiteHandler.CurrentEnrollmentLicense.CanEnrollIn(enrollableLesson.Lesson))
                continue;
            List<SectionItem> sectionItems = SectionItem.GetSectionItems(WebsiteHandler.CurrentRegister.Period, enrollableLesson.Lesson);
            result.AddRange(sectionItems);
        }

        GridView1.DataSource = result;
        GridView1.DataBind();

        GridView2.DataSource = WebsiteHandler.CurrentRegister.Participates;
        GridView2.DataBind();

        lblPayableAmout.Text = WebsiteHandler.CurrentRegister.PayableTuition.ToString("C0");
        lblPayStatus.Text = WebsiteHandler.CurrentRegister.FarsiFinancialStatusText;
    }

    protected void btnPay_Click(object sender, EventArgs e)
    {
        try
        {
            if (WebsiteHandler.CurrentRegister.Participates.Count == 0)
                throw new MessageException("ابتدا درس/سطح مورد نظر را اخذ کنید.");

            WebsiteHandler.CurrentStudent.EnsureDefaultDocumentActivation();
            WebsiteHandler.CurrentStudent.Registers.UniqueAdd(WebsiteHandler.CurrentRegister);
            WebsiteHandler.CurrentStudent.Save();

            MellatPayTransaction payTransaction = new MellatPayTransaction();
            payTransaction.Person = WebsiteHandler.CurrentStudent;
            payTransaction.Amount = WebsiteHandler.CurrentRegister.PayableTuition;
            payTransaction.Description = "ثبت نام " + WebsiteHandler.CurrentRegister.Student.FarsiFullname + "- رشته " + WebsiteHandler.CurrentRegister.Major.Name + "- ترم " + WebsiteHandler.CurrentRegister.Period.Name;

            PayTransactionItem item = new PayTransactionItem();
            item.Type = PayTransactionItemType.ElectronicPayment;
            item.Amount = WebsiteHandler.CurrentRegister.PayableTuition;
            item.FinancialDocument = WebsiteHandler.CurrentRegister.FinancialDocument;
            item.Text = "ثبت نام " + WebsiteHandler.CurrentRegister.Student.FarsiFullname + "- رشته " +
                        WebsiteHandler.CurrentRegister.Major.Name + "- ترم " +
                        WebsiteHandler.CurrentRegister.Period.Name;
            item.Heading = FinancialHeading.Signup;

            payTransaction.Items.Add(item);

            // Get Id
            payTransaction.Save();

            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentStudent, string.Format("Payment #{0} Starting", payTransaction.Id));
            payTransaction.Start("http://www.fakher.ac.ir/Student/Enrollment/pageMellatHandler.aspx");
            payTransaction.Save();
            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentStudent, string.Format("Payment #{0} Started", payTransaction.Id));

            WebsiteHandler.CurrentPayTransaction = payTransaction;
            WebsiteHandler.ReturnPageUrl = "~/Student/Enrollment/rptSignupReceipt.aspx";

            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentStudent, "Go For Payment");
            Response.Redirect("~/Student/Enrollment/pageSectionEnrollment3.aspx");
            return;
        }
        catch (MessageException ex)
        {
            rSimpleMessageBox1.ShowInformation(ex.Message);
            return;
        }
        catch (PayException ex)
        {
            WebsiteManager.SaveException(this, ex);
            rSimpleMessageBox1.ShowInformation("متاسفانه بانک ملت در حال حاضر نمی تواند پاسخگوی شما باشد. لطفا مجددا مراجعه فرمایید. کد [{0}]", ex.RawCode);
            return;
        }
        catch (Exception ex)
        {
            WebsiteManager.SaveException(this, ex);
            rSimpleMessageBox1.ShowInformation("متاسفانه بانک ملت در حال حاضر نمی تواند پاسخگوی شما باشد. لطفا مجددا مراجعه فرمایید.");
            return;
        }

    }

    protected void btnEnroll_Click(object sender, EventArgs e)
    {
        Button button = (sender as Button);

        try
        {
            int id = Convert.ToInt32(button.CommandArgument);
            SectionItem sectionItem = SectionItem.FromId(id);

            if (sectionItem == null)
                return;

            sectionItem.RefreshEntity();
            sectionItem.CheckCapacity();
            foreach (Participate participate in WebsiteHandler.CurrentRegister.Participates)
                if (participate.SectionItem.Lesson.Id == sectionItem.Lesson.Id)
                    throw new MessageException("این درس/سطح قبلا اخذ شده است.");
            foreach (Participate participate in WebsiteHandler.CurrentRegister.Participates)
                if (participate.SectionItem.Id == sectionItem.Id)
                    throw new MessageException("این گــروه قبلا اخذ شده است.");
            if (WebsiteHandler.CurrentRegister.Student.SignedUpIn(sectionItem))
                throw new MessageException("دانشجو قبلا در همین کلاس ثبت نام شده است.");


            Participate newParticipate = WebsiteHandler.CurrentRegister.Signup(sectionItem, false);
            newParticipate.InternetRegisteration = true;
            WebsiteHandler.CurrentRegister.AddParticipate(newParticipate);
//            WebsiteHandler.CurrentRegister.AddEnrollment(newParticipate.Enrollment);
//            WebsiteHandler.CurrentRegister.Save();
            newParticipate.Save();

            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentRegister.Student, string.Format("Added Participate #{0} [{1} - {2}]", newParticipate.Id, newParticipate.SectionItem.Lesson.Name,
                newParticipate.SectionItem.Section.GroupNumber));
        }
        catch (Exception ex)
        {
            rSimpleMessageBox1.ShowInformation(ex.Message);
            return;
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        SectionItem sectionItem = e.Row.DataItem as SectionItem;
        if (sectionItem != null)
        {
            Button button = e.Row.FindControl("btnEnroll") as Button;
            if (button != null)
            {
                button.CommandArgument = sectionItem.Id + "";
            }
        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Participate participate = e.Row.DataItem as Participate;
        if (participate != null)
        {
            Button button = e.Row.FindControl("btnDelete") as Button;
            if (button != null)
            {
                button.CommandArgument = participate.Id + "";
            }
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Button button = (sender as Button);

        try
        {
            int id = Convert.ToInt32(button.CommandArgument);
            Participate participate = Participate.FromId(id);

            if (participate == null)
                return;

            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentRegister.Student, string.Format("Removing Participate #{0} [{1} - {2}]", participate.Id, participate.SectionItem.Lesson.Name,
                participate.SectionItem.Section.GroupNumber));

            WebsiteHandler.CurrentRegister.RemoveParticipate(participate);
//            WebsiteHandler.CurrentRegister.UpdateParticipateEnrollments();
//            WebsiteHandler.CurrentRegister.Save();
            participate.Save();
        }
        catch (Exception ex)
        {
            rSimpleMessageBox1.ShowInformation(ex.Message);
            return;
        }
    }
}
