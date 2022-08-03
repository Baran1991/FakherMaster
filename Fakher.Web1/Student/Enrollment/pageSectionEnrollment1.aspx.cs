using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;

public partial class Student_Enrollment_pageStartEnrollment : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentStudent == null)
        {
            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentStudent, "Student is Null in Load(Redirect)");
            Response.Redirect("~/Student/Enrollment/Default.aspx", true);
            return;
        }

        if (!IsPostBack)
        {
            Fill();
        }
    }

    private void Fill()
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
            rSimpleMessageBox1.ShowInformation("اکنون امکان ثبت نام برای شما وجود ندارد. لطفا در زمانبندی تعیین شده مراجعه کنید.");
            return;
        }

        rCmbLicense.DataTextField = "EnrollText";
        rCmbLicense.DataValueField = "Id";
        rCmbLicense.DataSource = licenses;
        rCmbLicense.DataBind();
    }

    protected void btnStart_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(rCmbLicense.SelectedValue))
        {
            rSimpleMessageBox1.ShowInformation("زمان بندی ثبت نام را انتخاب کنید");
            return;
        }
        if (!chkPolicy.Checked)
        {
            rSimpleMessageBox1.ShowInformation("شرایط و مفاد ثبت نام را مورد تایید قرار دهید و تیک مربوط به آن را بزنید");
            return;
        }

        try
        {
            int id = Convert.ToInt32(rCmbLicense.SelectedValue);
            EnrollmentLicense mCurrentEnrollmentLicense = EnrollmentLicense.FromId(id);

            if (!mCurrentEnrollmentLicense.CanEnroll(WebsiteHandler.CurrentStudent))
            {
                rSimpleMessageBox1.ShowInformation("عدم رعایت زمان بندی یا شرایط ثبت نام، ثبت نام شما در حال حاضر مقدور نیست");
                return;
            }

            if (WebsiteHandler.CurrentStudent.GetRegisters(mCurrentEnrollmentLicense.Major).Count == 0)
            {
                rSimpleMessageBox1.ShowInformation("امکان ثبت نام اینترنتی برای شما وجود ندارد");
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
                    rSimpleMessageBox1.ShowInformation("شما در ترم قبل در موسسه ثبت نام نشده اید. بنابراین امکان ثبت نام در این رشته و این ترم برای شما وجود ندارد");
                    return;
                }

                if (lastRegister.NextEnrollmentBanned)
                {
                    rSimpleMessageBox1.ShowInformation("شما از ثبت نام در ترم جـدید منع شده اید. علت منع: " + lastRegister.NextEnrollmentBanReason);
                    return;
                }

                if (lastRegister.Type == RegisterType.FullQuited ||
                    lastRegister.Type == RegisterType.PartialVacation ||
                    lastRegister.Type == RegisterType.TermVacation)
                {
                    rSimpleMessageBox1.ShowInformation("شما در حال انصراف ویا مرخصی هستید. بنابراین امکان ثبت نام اینترنتی برای شما وجود ندارد");
                    return;
                }

//                if(lastRegister.Participates.Count == 0)
//                {
//                    rSimpleMessageBox1.ShowInformation("شما در ترم قبل در هیچ کلاسی شرکت نکرده اید. بنابراین امکان ثبت نام اینترنتی برای شما وجود ندارد");
//                    return;
//                }
            }
            else
            {
                rSimpleMessageBox1.ShowInformation("امکان ثبت نام شما در {0} وجود ندارد.",
                             mCurrentEnrollmentLicense.EnrollText);
                return;
            }

            StudentConfiguration configuration = WebsiteHandler.CurrentStudentConfiguration;
            if (configuration == null)
            {
                configuration = WebsiteHandler.CurrentStudent.GetConfiguration(mCurrentEnrollmentLicense.Major, mCurrentEnrollmentLicense.EducationalPeriod);
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
                rSimpleMessageBox1.ShowInformation("امکان ثبت نام شما در {0} وجود ندارد.",
                                             mCurrentEnrollmentLicense.EnrollText);
                return;
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
                mRegister.Save();
            }

            if (mRegister.Type == RegisterType.FullQuited ||
                mRegister.Type == RegisterType.PartialVacation ||
                mRegister.Type == RegisterType.TermVacation)
            {
                rSimpleMessageBox1.ShowInformation("شما در حال انصراف ویا مرخصی هستید. بنابراین امکان ثبت نام در این رشته و این ترم برای شما وجود ندارد");
                return;
            }

            if (mRegister.EnrollmentConfirmed)
            {
                rSimpleMessageBox1.ShowInformation("پس از تایید نهایی، امکان ثبت نام یا ویرایش آن وجود ندارد");
                return;
            }

            WebsiteManager.SaveEnrollmentLog(this, WebsiteHandler.CurrentStudent, "Started Enrollment");

            WebsiteHandler.CurrentRegister = mRegister;
            WebsiteHandler.CurrentEnrollmentLicense = mCurrentEnrollmentLicense;
            WebsiteHandler.CurrentStudentConfiguration = configuration;
            Response.Redirect("~/Student/Enrollment/pageSectionEnrollment2.aspx", false);
        }
        catch (Exception ex)
        {
            rSimpleMessageBox1.ShowInformation(ex.Message);
            return;
        }
    }
}
