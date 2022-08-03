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
    private int mCurrentStep
    {
        get
        {
            if (ViewState["CurrentEnrollStep"] != null)
                return (int)ViewState["CurrentEnrollStep"];
            return 0;
        }
        set { ViewState["CurrentEnrollStep"] = value; }
    }

    //    private bool mRegisterSet
    //    {
    //        get
    //        {
    //            if (ViewState["RegisterSet"] != null)
    //                return (bool)ViewState["RegisterSet"];
    //            return false;
    //        }
    //        set { ViewState["RegisterSet"] = value; }
    //    }

    private EnrollmentLicense mCurrentEnrollmentLicense
    {
        get
        {
            if (ViewState[WebsiteHandler.CurrentEnrollmentLicenseKey] != null)
            {
                string id = ViewState[WebsiteHandler.CurrentEnrollmentLicenseKey] + "";
                return EnrollmentLicense.FromId(Convert.ToInt32(id));
            }
            return null;
        }
        set
        {
            ViewState[WebsiteHandler.CurrentEnrollmentLicenseKey] = value.Id;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //        if (!IsPostBack)
        //        {
        //            WebsiteHandler.EnrollableLessonIds = null;
        //        }

        Response.Redirect("~/Student/Default.aspx", true);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
//        if (WebsiteHandler.CurrentStudent != null)
//        {
//        }

        if (mCurrentStep == 0)
        {
            chkPolicy.Text = string.Format("اینجانب {0}، کلیه مفاد و شرایط قرارداد ثبت نام در موسسه را می پذیرم و متعهد به اجرای تمام و کمال آن در طول تحصیل در موسسه می باشم",
                                            WebsiteHandler.CurrentStudent.FarsiFullname);

            IQueryable<Major> registeredMajors = WebsiteHandler.CurrentStudent.GetRegisteredMajors();
            IList<EnrollmentLicense> enrollmentLicenses = EnrollmentLicense.GetEnrollmentLicenses(EnrollmentLicenseType.SectionEnrollment, PersianDate.Today, DateTime.Now.Hour, DateTime.Now.Minute);

            List<EnrollmentLicense> licenses = new List<EnrollmentLicense>();
            foreach (EnrollmentLicense license in enrollmentLicenses)
                if (registeredMajors.Contains(license.Major))
                    licenses.Add(license);

            if (licenses.Count == 0)
            {
                rMessageBox1.ShowInformation("اکنون امکان ثبت نام برای شما وجود ندارد. لطفا در زمانبندی تعیین شده مراجعه کنید.", true);
                return;
            }

            rCmbLicense.DataTextField = "EnrollText";
            rCmbLicense.DataValueField = "Id";
            rCmbLicense.DataSource = licenses;
            rCmbLicense.DataBind();
        }

        if (mCurrentStep == 1)
        {
            if (mCurrentEnrollmentLicense == null)
            {
                rMessageBox1.ShowInformation("هیچ مجوز ثبت نامی برای شما وجود ندارد. بنابراین ثبت نام شما امروز امکان پذیر نمی باشد.", true);
                return;
            }

            /////// xx
            //            if (!mCurrentEnrollmentLicense.CanEnroll(WebsiteHandler.CurrentStudent))
            //            {
            //                rMessageBox1.ShowInformation("عدم رعایت زمان بندی ثبت نام، ثبت نام شما مقدور نیست", true);
            //                return;
            //            }
            //            if (!mRegisterSet)
            //            {
            //                Register mRegister = WebsiteHandler.CurrentStudent.GetRegister(mCurrentEnrollmentLicense.EducationalPeriod,
            //                                                              mCurrentEnrollmentLicense.Major);
            //                if (mRegister == null)
            //                {
            //                    mRegister = WebsiteHandler.CurrentStudent.CreateRegister(
            //                        mCurrentEnrollmentLicense.EducationalPeriod,
            //                        mCurrentEnrollmentLicense.Major,
            //                        RegisterType.Participation, true);
            //                    mRegister.InternetRegisteration = true;
            //                    mRegister.Registrar = WebsiteHandler.CurrentStudent.FarsiFullname;
            //                }
            //
            //                Register lastRegister = WebsiteHandler.CurrentStudent.GetLastRegister(mCurrentEnrollmentLicense.Major);
            //                if (lastRegister != null)
            //                {
            //                    List<EducationalPeriod> periods = lastRegister.Period.Department.EducationalPeriods.OrderBy(x => x.StartDate).ToList();
            //                    int indexNew = periods.IndexOf(mRegister.Period);
            //                    int indexLast = periods.IndexOf(lastRegister.Period);
            //                    if (indexNew - indexLast > 1)
            //                    {
            //                        rMessageBox1.ShowInformation("شما در ترم قبل در موسسه ثبت نام نشده اید. بنابراین امکان ثبت نام در این رشته و این ترم برای شما وجود ندارد", true);
            //                        return;
            //                    }
            //
            //                    if (lastRegister.NextEnrollmentBanned)
            //                    {
            //                        rMessageBox1.ShowInformation("شما از ثبت نام در ترم جـدید منع شده اید. علت منع: " + lastRegister.NextEnrollmentBanReason, true);
            //                        return;
            //                    }
            //
            //                    if (lastRegister.Type == RegisterType.FullQuited ||
            //                        lastRegister.Type == RegisterType.PartialVacation ||
            //                        lastRegister.Type == RegisterType.TermVacation)
            //                    {
            //                        rMessageBox1.ShowInformation("شما در حال انصراف ویا مرخصی هستید. بنابراین امکان ثبت نام اینترنتی برای شما وجود ندارد", true);
            //                        return;
            //                    }
            //                }
            //
            //                if (mRegister.Type == RegisterType.FullQuited ||
            //                    mRegister.Type == RegisterType.PartialVacation ||
            //                    mRegister.Type == RegisterType.TermVacation)
            //                {
            //                    rMessageBox1.ShowInformation("شما در حال انصراف ویا مرخصی هستید. بنابراین امکان ثبت نام در این رشته و این ترم برای شما وجود ندارد", true);
            //                    return;
            //                }
            //
            //                if (mRegister.EnrollmentConfirmed)
            //                {
            //                    rMessageBox1.ShowInformation("پس از تایید نهایی، امکان ثبت نام یا ویرایش آن وجود ندارد", true);
            //                    return;
            //                }
            //
            //                mRegister.Save();
            //                WebsiteHandler.CurrentRegister = mRegister;
            //                mRegisterSet = true;
            //            }
            FillStep1();
            WebsiteManager.IsInEnrollmentPhase();
        }

        if (mCurrentStep == 2)
        {
            FillStep2();
            WebsiteManager.IsInEnrollmentPhase();
        }

        pnlStep0.Visible = mCurrentStep == 0;
        pnlStep1.Visible = mCurrentStep == 1;
        pnlStep2.Visible = mCurrentStep == 2;
    }

    private void FillStep1()
    {
        if (WebsiteHandler.CurrentStudent == null || WebsiteHandler.CurrentRegister == null)
        {
            Response.Redirect("Default.aspx", true);
            return;
        }

        //        if (WebsiteHandler.EnrollableLessonIds == null)
        //            WebsiteHandler.EnrollableLessonIds =
        //                WebsiteHandler.CurrentRegister.GetEnrollableLessons(true, true).Select(x => x.Id).ToList();

        //new
        //        if (WebsiteHandler.CurrentStudentConfiguration == null)
        //        {
        //            StudentConfiguration configuration = WebsiteHandler.CurrentStudent.GetConfiguration(mCurrentEnrollmentLicense.Major, mCurrentEnrollmentLicense.EducationalPeriod);
        //            if (configuration == null)
        //            {
        //                configuration = WebsiteHandler.CurrentStudent.CreateConfiguration(mCurrentEnrollmentLicense.Major,
        //                                                                                  mCurrentEnrollmentLicense.
        //                                                                                      EducationalPeriod);
        //                WebsiteHandler.CurrentStudent.AddConfiguration(configuration);
        //                configuration.Save();
        //            }
        //            else
        //            {
        //                if(configuration.EnrollableLessons.Count == 0)
        //                {
        //                    configuration.CalculateEnrollableLessons();
        //                    configuration.Save();
        //                }
        //            }
        //            WebsiteHandler.CurrentStudentConfiguration = configuration;
        //        }
        //end new

        List<SectionItem> result = new List<SectionItem>();
        foreach (EnrollableLesson enrollableLesson in WebsiteHandler.CurrentStudentConfiguration.EnrollableLessons)
        {
            if (!mCurrentEnrollmentLicense.CanEnrollIn(enrollableLesson.Lesson))
                continue;
            List<SectionItem> sectionItems = SectionItem.GetSectionItems(WebsiteHandler.CurrentRegister.Period, enrollableLesson.Lesson);
            result.AddRange(sectionItems);
        }

        //        foreach (SectionItem sectionItem in result)
        //            sectionItem.RefreshEntity();

        RadGrid1.DataSource = result;
        RadGrid1.DataBind();

        RadGrid2.DataSource = WebsiteHandler.CurrentRegister.Participates;
        RadGrid2.DataBind();
    }

    private void FillStep2()
    {
        if (WebsiteHandler.CurrentStudent == null || WebsiteHandler.CurrentRegister == null)
        {
            Response.Redirect("Default.aspx", true);
            return;
        }

        RadGrid3.DataSource = WebsiteHandler.CurrentRegister.Participates;
        RadGrid3.DataBind();

        lblPayableAmout.Text = WebsiteHandler.CurrentRegister.PayableTuition.ToString("C0");
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("lblIndex") as Label;
            lbl.Text = e.Item.ItemIndex + 1 + "";
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (RadGrid1.SelectedItems.Count == 0)
        {
            rMessageBox1.ShowInformation("ابتدا درس/سطح را انتخاب کنید و سپس دکمه اخذ را بزنید.");
            return;
        }
        if (RadGrid1.SelectedItems.Count > 1)
        {
            rMessageBox1.ShowInformation("فقط یک درس/سطح را انتخاب کنید.");
            return;
        }

        try
        {
            int id = Convert.ToInt32(RadGrid1.SelectedValue);
            SectionItem sectionItem = SectionItem.FromId(id);
            sectionItem.RefreshEntity();

            sectionItem.CheckCapacity();
            foreach (Participate participate in WebsiteHandler.CurrentRegister.Participates)
                if (participate.SectionItem.Lesson.Id == sectionItem.Lesson.Id)
                    throw new Exception("این درس/سطح قبلا اخذ شده است.");
            foreach (Participate participate in WebsiteHandler.CurrentRegister.Participates)
                if (participate.SectionItem.Id == sectionItem.Id)
                    throw new Exception("این گــروه قبلا اخذ شده است.");
            if (WebsiteHandler.CurrentRegister.Student.SignedUpIn(sectionItem))
                throw new Exception("دانشجو قبلا در همین کلاس ثبت نام شده است.");


            Participate newParticipate = WebsiteHandler.CurrentRegister.Signup(sectionItem, false);
            newParticipate.InternetRegisteration = true;
            WebsiteHandler.CurrentRegister.AddParticipate(newParticipate);
            WebsiteHandler.CurrentRegister.AddEnrollment(newParticipate.Enrollment);
            WebsiteHandler.CurrentRegister.Save();

            WebsiteManager.SaveLog(this, WebsiteHandler.CurrentRegister.Student, string.Format("Added Participate #{0} [{1} - {2}]", newParticipate.Id, newParticipate.SectionItem.Lesson.Name,
                newParticipate.SectionItem.Section.GroupNumber));
        }
        catch (Exception ex)
        {
            rMessageBox1.ShowInformation(ex.Message);
            return;
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        if (RadGrid2.SelectedItems.Count == 0)
        {
            rMessageBox1.ShowInformation("ابتدا درس/سطح را انتخاب کنید و سپس دکمه حـذف را بزنید.");
            return;
        }
        if (RadGrid2.SelectedItems.Count > 1)
        {
            rMessageBox1.ShowInformation("فقط یک درس/سطح را انتخاب کنید.");
            return;
        }

        try
        {
            int id = Convert.ToInt32(RadGrid2.SelectedValue);
            Participate participate = Participate.FromId(id);

            WebsiteManager.SaveLog(this, WebsiteHandler.CurrentRegister.Student, string.Format("Removing Participate #{0} [{1} - {2}]", participate.Id, participate.SectionItem.Lesson.Name,
                participate.SectionItem.Section.GroupNumber));

            WebsiteHandler.CurrentRegister.RemoveParticipate(participate);
            WebsiteHandler.CurrentRegister.UpdateParticipateEnrollments();
            WebsiteHandler.CurrentRegister.Save();
        }
        catch (Exception ex)
        {
            rMessageBox1.ShowInformation(ex.Message);
            return;
        }
    }

    protected void rMessageBox1_DialogResult(object sender, DialogResultEventArgs e)
    {
        Response.Redirect("~/Student/Default.aspx", true);
    }

    protected void btnPrev_Click(object sender, EventArgs e)
    {
        if (mCurrentStep > 1)
            mCurrentStep--;
    }

    protected void btnNext0_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(rCmbLicense.SelectedValue))
        {
            rMessageBox1.ShowInformation("رشته ثبت نامی را انتخاب کنید");
            return;
        }
        if (!chkPolicy.Checked)
        {
            rMessageBox1.ShowInformation("شرایط و مفاد قرارداد ثبت نام را مورد تایید قرار دهید");
            return;
        }

        try
        {
            int id = Convert.ToInt32(rCmbLicense.SelectedValue);
            mCurrentEnrollmentLicense = EnrollmentLicense.FromId(id);

            if (!mCurrentEnrollmentLicense.CanEnroll(WebsiteHandler.CurrentStudent))
            {
                rMessageBox1.ShowInformation("عدم رعایت زمان بندی یا شرایط ثبت نام، ثبت نام شما در حال حاضر مقدور نیست", true);
                return;
            }

            Register lastRegister = WebsiteHandler.CurrentStudent.GetLastRegister(mCurrentEnrollmentLicense.Major);
            if (lastRegister != null)
            {
                List<EducationalPeriod> periods = lastRegister.Period.Department.EducationalPeriods.OrderBy(x => x.StartDate).ToList();
                int indexNew = periods.IndexOf(mCurrentEnrollmentLicense.EducationalPeriod);
                int indexLast = periods.IndexOf(lastRegister.Period);
                if (indexNew - indexLast > 1)
                {
                    rMessageBox1.ShowInformation("شما در ترم قبل در موسسه ثبت نام نشده اید. بنابراین امکان ثبت نام در این رشته و این ترم برای شما وجود ندارد", true);
                    return;
                }

                if (lastRegister.NextEnrollmentBanned)
                {
                    rMessageBox1.ShowInformation("شما از ثبت نام در ترم جـدید منع شده اید. علت منع: " + lastRegister.NextEnrollmentBanReason, true);
                    return;
                }

                if (lastRegister.Type == RegisterType.FullQuited ||
                    lastRegister.Type == RegisterType.PartialVacation ||
                    lastRegister.Type == RegisterType.TermVacation)
                {
                    rMessageBox1.ShowInformation("شما در حال انصراف ویا مرخصی هستید. بنابراین امکان ثبت نام اینترنتی برای شما وجود ندارد", true);
                    return;
                }
            }

            if (WebsiteHandler.CurrentStudentConfiguration == null)
            {
                StudentConfiguration configuration = WebsiteHandler.CurrentStudent.GetConfiguration(mCurrentEnrollmentLicense.Major, mCurrentEnrollmentLicense.EducationalPeriod);
                if (configuration == null)
                {
                    configuration = WebsiteHandler.CurrentStudent.CreateConfiguration(mCurrentEnrollmentLicense.Major,
                                                                                      mCurrentEnrollmentLicense.
                                                                                          EducationalPeriod);
                    WebsiteHandler.CurrentStudent.AddConfiguration(configuration);
                    configuration.Save();
                }
                else
                {
                    if (configuration.EnrollableLessons.Count == 0)
                    {
                        configuration.CalculateEnrollableLessons();
                        configuration.Save();
                    }
                }

                bool canEnroll = false;
                foreach (EnrollableLesson enrollableLesson in configuration.EnrollableLessons)
                {
                    if (mCurrentEnrollmentLicense.CanEnrollIn(enrollableLesson.Lesson))
                    {
                        canEnroll = true;
                        break;
                    }
                }

                if (!canEnroll)
                {
                    rMessageBox1.ShowInformation("امکان ثبت نام شما در {0} وجود ندارد.", false,
                                                 mCurrentEnrollmentLicense.EnrollText);
                    return;
                }

                WebsiteHandler.CurrentStudentConfiguration = configuration;
            }

            Register mRegister = WebsiteHandler.CurrentStudent.GetRegister(mCurrentEnrollmentLicense.EducationalPeriod,
                                              mCurrentEnrollmentLicense.Major);
            if (mRegister == null)
            {
                mRegister = WebsiteHandler.CurrentStudent.CreateRegister(
                    mCurrentEnrollmentLicense.EducationalPeriod,
                    mCurrentEnrollmentLicense.Major,
                    RegisterType.Participation, true);
                mRegister.InternetRegisteration = true;
                mRegister.Registrar = WebsiteHandler.CurrentStudent.FarsiFullname;
            }

            if (mRegister.Type == RegisterType.FullQuited ||
                mRegister.Type == RegisterType.PartialVacation ||
                mRegister.Type == RegisterType.TermVacation)
            {
                rMessageBox1.ShowInformation("شما در حال انصراف ویا مرخصی هستید. بنابراین امکان ثبت نام در این رشته و این ترم برای شما وجود ندارد", true);
                return;
            }

            if (mRegister.EnrollmentConfirmed)
            {
                rMessageBox1.ShowInformation("پس از تایید نهایی، امکان ثبت نام یا ویرایش آن وجود ندارد", true);
                return;
            }

            mRegister.Save();
            WebsiteHandler.CurrentRegister = mRegister;
        }
        catch (Exception ex)
        {
            rMessageBox1.ShowInformation(ex.Message);
            return;
        }

        mCurrentStep++;
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        WebsiteHandler.CurrentRegister.RefreshEntity();
        if (WebsiteHandler.CurrentRegister.Participates.Count == 0)
        {
            rMessageBox1.ShowInformation("ابتدا درس/سطح های موردنظر خود را به طور کامل و صحیح انتخاب کنید");
            return;
        }

        mCurrentStep++;
    }

    protected void btnNext2_Click(object sender, EventArgs e)
    {
        try
        {
            WebsiteManager.IsInEnrollmentPhase();

            //            WebsiteHandler.CurrentRegister.RefreshEntity();
            if (WebsiteHandler.CurrentRegister.Participates.Count == 0)
                throw new MessageException("به دلیل پایان زمان ثبت نام شما، درس/سطوح انتخابی شما از سیستم حذف گردیده اند. می توانید درس/سطح ها را مجددا انتخاب کنید.");

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
            WebsiteHandler.CurrentPayTransaction = payTransaction;

            WebsiteHandler.CurrentPayTransaction.Start("http://www.fakher.ac.ir/pageMellatHandler.aspx");
            WebsiteHandler.CurrentPayTransaction.Save();

            WebsiteHandler.ReturnPageUrl = "~/Student/rptSignupReceipt.aspx";
            Response.Redirect("~/pagePayRequest.aspx", true);
            return;
        }
        catch (MessageException ex)
        {
            rMessageBox1.ShowInformation(ex.Message);
            return;
        }
        catch (PayException ex)
        {
            WebsiteManager.SaveException(this, ex);
            rMessageBox1.ShowInformation("متاسفانه بانک ملت در حال حاضر نمی تواند پاسخگوی شما باشد. لطفا مجددا مراجعه فرمایید. کد [{0}]", false, ex.RawCode);
            return;
        }
        catch (Exception ex)
        {
            WebsiteManager.SaveException(this, ex);
            rMessageBox1.ShowInformation("متاسفانه بانک ملت در حال حاضر نمی تواند پاسخگوی شما باشد. لطفا مجددا مراجعه فرمایید.");
            return;
        }
    }
}
