using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using System.Web;
using Fakher.Core.DomainModel.Order;
using NHibernate;
using rComponents;

namespace Fakher.Core.Website
{
    public static class WebsiteHandler
    {
        public static string CaptchaSessionKey = "Captcha";

        public static string CurrentDbISessionKey = "CurrentDbISession";
        public static string CurrentPersonKey = "CurrentPerson";
        public static string CurrentRegisterKey = "CurrentRegister";
        public static string CurrentParticipateKey = "CurrentParticipate";
        public static string CurrentPayTransactionKey = "CurrentPayTransaction";
        public static string CurrentEnrollmentLicenseKey = "CurrentEnrollmentLicense";
        public static string CurrentMajorKey = "CurrentMajor";
        public static string CurrentEducationalPeriodKey = "CurrentEducationalPeriod";
        public static string CurrentSectionKey = "CurrentSection";
        public static string CurrentOrderKey = "CurrentOrder";

        public static string IsInEnrollmentPhaseKey = "IsInRegisterEnrollment";
        public static string IsInExamEnrollmentPhaseKey = "IsInExamEnrollment";
        public static string IsInOnlineExamPhaseKey = "IsInOnlineExamPhase";
        public static string IsInEnrollmentPhaseCacheKey = "IsInEnrollmentCache";
        public static string EnrollableLessonsKey = "EnrollableLessons";
        public static string CurrentStudentConfigurationKey = "CurrentStudentConfiguration";
        public static string OnlineExamParticipateTestAnswersKey = "OnlineExamParticipateTestAnswersDictionary";
        public static string OnlineExamParticipateEssayAnswersKey = "OnlineExamParticipateEssayAnswersDictionary";

        public static string MasterPageMenuKey = "MasterPageMenu";
        public static string TotalUserCountKey = "TotalUserCount";
        public static string ReturnPageUrlKey = "ReturnPageUrl";
        public static string CallbackMessageKey = "CallbackMessage";

        public static string WebsiteStatus = "WebsiteStatus";
        public static string WebsiteStatusDescription = "WebsiteStatusDescription";
        public static string WebgozarSettingKey = "WebgozarCounter";
        public static string ShowFrontpagePollKey = "ShowFrontpagePoll";
        public static string FrontpagePollIdKey = "FrontpagePollId";
        public static string SectionAttachmentKey = "SectionAttachment";
        public static string SectionPollKey = "SectionAttachment";
        public static bool PagePollRedirect = false;
        public static string ExamAttachmentKey = "SectionAttachment";
        public static string ExamPollKey = "SectionAttachment";
        public static string BookShowKey = "BookShow";
        public static string BookShowCount = "BookShowCount";
        public static string BookShopKey = "BookShop";
        public static string OnlineExamEnrollmentKey = "OnlineExamEnrollment";
        public static string OralExamEnrollmentKey = "OralExamEnrollment";
        public static string JudicialConsultationStatus = "JudicialConsultationStatus";
        public static string JudicialConsultationStatusDescription = "JudicialConsultationStatusDescription";
        public static string JudicialConsultationStartDate = "JudicialConsultationStartDate";
        public static string JudicialConsultationStartTime = "JudicialConsultationStartTime";
        public static string JudicialConsultationEndDate = "JudicialConsultationEndDate";
        public static string JudicialConsultationEndTime = "JudicialConsultationEndTime";
        public static string EducationalConsultationStatus = "EducationalConsultationStatus";
        public static string EducationalConsultationStatusDescription = "EducationalConsultationStatusDescription";
        public static string EducationalConsultationStartDate = "EducationalConsultationStartDate";
        public static string EducationalConsultationStartTime = "EducationalConsultationStartTime";
        public static string EducationalConsultationEndDate = "EducationalConsultationEndDate";
        public static string EducationalConsultationEndTime = "EducationalConsultationEndTime";
        public static string SlideshowImages = "SlideshowImages";
        public static string EmployeePayrollReceiptShowStartDate = "EmployeePayrollReceiptShowStartDate";
        public static string EmployeePayrollReceiptShowEndDate = "EmployeePayrollReceiptShowEndDate";

        public static string TeacherPayrollReceiptShowStartDate = "TeacherPayrollReceiptShowStartDate";
        public static string TeacherPayrollReceiptShowEndDate = "TeacherPayrollReceiptShowEndDate";
        //public static int ExerciseTimeDuration = -1;
        public static string SlideshowSeparator
        {
            get { return "::{}::"; }
        }

        public static bool MasterPageMenu
        {
            get
            {
                if (HttpContext.Current.Session[MasterPageMenuKey] != null)
                    return (bool)HttpContext.Current.Session[MasterPageMenuKey];
                return true;
            }
            set
            {
                HttpContext.Current.Session[MasterPageMenuKey] = value;
            }
        }

        public static string ReturnPageUrl
        {
            get
            {
                if (HttpContext.Current.Session[ReturnPageUrlKey] != null)
                    return HttpContext.Current.Session[ReturnPageUrlKey] + "";
                return null;
            }
            set
            {
                HttpContext.Current.Session[ReturnPageUrlKey] = value;
            }
        }

        public static string CallbackMessage
        {
            get
            {
                if (HttpContext.Current.Session[CallbackMessageKey] != null)
                    return HttpContext.Current.Session[CallbackMessageKey] + "";
                return null;
            }
            set
            {
                HttpContext.Current.Session[CallbackMessageKey] = value;
            }
        }

        public static ISession CurrentDbISession
        {
            get
            {
                if (HttpContext.Current.Session[CurrentDbISessionKey] != null)
                    return HttpContext.Current.Session[CurrentDbISessionKey] as ISession;
                return null;
            }
            set
            {
                if (value == null)
                    HttpContext.Current.Session.Remove(CurrentDbISessionKey);
                else
                    HttpContext.Current.Session[CurrentDbISessionKey] = value;
            }
        }

//        public static int TotalUserCount
//        {
//            get
//            {
//                if (HttpContext.Current.Application[TotalUserCountKey] != null)
//                    return (int) HttpContext.Current.Application[TotalUserCountKey];
//                return 0;
//            }
//            set { HttpContext.Current.Application[TotalUserCountKey] = value; }
//        }

        public static Person CurrentPerson
        {
            get
            {
                if (HttpContext.Current.Session[CurrentPersonKey] != null)
                {
                    int id = Convert.ToInt32(HttpContext.Current.Session[CurrentPersonKey]);
                    return DbContext.FromId<Person>(id);
                }
                return null;
            }
            set
            {
                if (value == null)
                    HttpContext.Current.Session.Remove(CurrentPersonKey);
                else
                    HttpContext.Current.Session[CurrentPersonKey] = value.Id;
            }
        }

        public static bool IsInEnrollmentPhase
        {
            get
            {
                if (HttpContext.Current.Session[IsInEnrollmentPhaseKey] != null)
                    return (bool)HttpContext.Current.Session[IsInEnrollmentPhaseKey];
                return false;
            }
            set
            {
                HttpContext.Current.Session[IsInEnrollmentPhaseKey] = value;
            }
        }

        public static bool IsInExamEnrollmentPhase
        {
            get
            {
                if (HttpContext.Current.Session[IsInExamEnrollmentPhaseKey] != null)
                    return (bool)HttpContext.Current.Session[IsInExamEnrollmentPhaseKey];
                return false;
            }
            set
            {
                HttpContext.Current.Session[IsInExamEnrollmentPhaseKey] = value;
            }
        }

        public static bool IsInOnlineExamPhase
        {
            get
            {
                if (HttpContext.Current.Session[IsInOnlineExamPhaseKey] != null)
                    return (bool)HttpContext.Current.Session[IsInOnlineExamPhaseKey];
                return false;
            }
            set
            {
                HttpContext.Current.Session[IsInOnlineExamPhaseKey] = value;
            }
        }

        public static Student CurrentStudent
        {
            get
            {
                return CurrentPerson as Student;
            }
        }        
        
        public static Teacher CurrentTeacher
        {
            get
            {
                return CurrentPerson as Teacher;
            }
        }

        public static Register CurrentRegister
        {
            get
            {
                if (HttpContext.Current.Session[CurrentRegisterKey] != null)
                {
                    int id = Convert.ToInt32(HttpContext.Current.Session[CurrentRegisterKey]);
                    return DbContext.FromId<Register>(id);
//                    return HttpContext.Current.Session[CurrentRegisterKey] as Register;
                }
                return null;
            }
            set
            {
                if (value == null)
                    HttpContext.Current.Session.Remove(CurrentRegisterKey);
                else
                    HttpContext.Current.Session[CurrentRegisterKey] = value.Id;
            }
        }

        public static Participate CurrentParticipate
        {
            get
            {
                if (HttpContext.Current.Session[CurrentParticipateKey] != null)
                {
                    int id = Convert.ToInt32(HttpContext.Current.Session[CurrentParticipateKey]);
                    return DbContext.FromId<Participate>(id);
//                    return HttpContext.Current.Session[CurrentParticipateKey] as Participate;
                }
                return null;
            }
            set
            {
                if (value == null)
                    HttpContext.Current.Session.Remove(CurrentParticipateKey);
                else
                    HttpContext.Current.Session[CurrentParticipateKey] = value.Id;
            }
        }

        public static EnrollmentLicense CurrentEnrollmentLicense
        {
            get
            {
                if (HttpContext.Current.Session[CurrentEnrollmentLicenseKey] != null)
                {
                    string id = HttpContext.Current.Session[CurrentEnrollmentLicenseKey] + "";
                    return EnrollmentLicense.FromId(Convert.ToInt32(id));
                }
                return null;
            }
            set
            {
                if (value == null)
                    HttpContext.Current.Session.Remove(CurrentEnrollmentLicenseKey);
                else
                    HttpContext.Current.Session[CurrentEnrollmentLicenseKey] = value.Id;
            }
        }

        public static Major CurrentMajor
        {
            get
            {
                if (HttpContext.Current.Session[CurrentMajorKey] != null)
                {
                    int id = Convert.ToInt32(HttpContext.Current.Session[CurrentMajorKey]);
                    return DbContext.FromId<Major>(id);
                }
                return null;
            }
            set
            {
                if (value == null)
                    HttpContext.Current.Session.Remove(CurrentMajorKey);
                else
                    HttpContext.Current.Session[CurrentMajorKey] = value.Id;
            }
        }

        public static EducationalPeriod CurrentEducationalPeriod
        {
            get
            {
                if (HttpContext.Current.Session[CurrentEducationalPeriodKey] != null)
                {
                    int id = Convert.ToInt32(HttpContext.Current.Session[CurrentEducationalPeriodKey]);
                    return DbContext.FromId<EducationalPeriod>(id);
                }
                return null;
            }
            set
            {
                if (value == null)
                    HttpContext.Current.Session.Remove(CurrentEducationalPeriodKey);
                else
                    HttpContext.Current.Session[CurrentEducationalPeriodKey] = value.Id;
            }
        }

        public static Section CurrentSection
        {
            get
            {
                if (HttpContext.Current.Session[CurrentSectionKey] != null)
                {
                    int id = Convert.ToInt32(HttpContext.Current.Session[CurrentSectionKey]);
                    return DbContext.FromId<Section>(id);
                }
                return null;
            }
            set
            {
                if (value == null)
                    HttpContext.Current.Session.Remove(CurrentSectionKey);
                else
                    HttpContext.Current.Session[CurrentSectionKey] = value.Id;
            }
        }

        public static Order CurrentOrder
        {
            get
            {
                if (HttpContext.Current.Session[CurrentOrderKey] != null)
                {
                    int id = Convert.ToInt32(HttpContext.Current.Session[CurrentOrderKey]);
                    return DbContext.FromId<Order>(id);
                }
                return null;
            }
            set
            {
                if (value == null)
                    HttpContext.Current.Session.Remove(CurrentOrderKey);
                else
                    HttpContext.Current.Session[CurrentOrderKey] = value.Id;
            }
        }

        public static OnlineExamParticipate CurrentOnlineExamParticipate
        {
            get
            {
                if (HttpContext.Current.Session[CurrentParticipateKey] != null)
                {
                    int id = Convert.ToInt32(HttpContext.Current.Session[CurrentParticipateKey]);
                    return DbContext.FromId<OnlineExamParticipate>(id);
                }
                return null;
            }
        }
        public static ExerciseParticipate CurrentExerciseParticipate
        {
            get
            {
                if (HttpContext.Current.Session[CurrentParticipateKey] != null)
                {
                    int id = Convert.ToInt32(HttpContext.Current.Session[CurrentParticipateKey]);
                    return DbContext.FromId<ExerciseParticipate>(id);
                }
                return null;
            }
        }
        //public static BlackboardLessonParticipate CurrentBlackboardLessonParticipate
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session[CurrentParticipateKey] != null)
        //        {
        //            int id = Convert.ToInt32(HttpContext.Current.Session[CurrentParticipateKey]);
        //            return DbContext.FromId<BlackboardLessonParticipate>(id);
        //        }
        //        return null;
        //    }
        //}
        public static ExamParticipate CurrentExamParticipate
        {
            get
            {
                if (HttpContext.Current.Session[CurrentParticipateKey] != null)
                {
                    int id = Convert.ToInt32(HttpContext.Current.Session[CurrentParticipateKey]);
                    return DbContext.FromId<ExamParticipate>(id);
//                    return HttpContext.Current.Session[CurrentParticipateKey] as ExamParticipate;
                }
                return null;
            }
            set
            {
                if (value == null)
                    HttpContext.Current.Session.Remove(CurrentParticipateKey);
                else
                    HttpContext.Current.Session[CurrentParticipateKey] = value.Id;
            }
        }

        public static MellatPayTransaction CurrentPayTransaction
        {
            get
            {
                if (HttpContext.Current.Session[CurrentPayTransactionKey] != null)
                {
                    int id = Convert.ToInt32(HttpContext.Current.Session[CurrentPayTransactionKey]);
                    return DbContext.FromId<MellatPayTransaction>(id);
                }
                return null;
            }
            set
            {
                if (value == null)
                    HttpContext.Current.Session.Remove(CurrentPayTransactionKey);
                else
                    HttpContext.Current.Session[CurrentPayTransactionKey] = value.Id;
            }
        }

//        public static IList<int> EnrollableLessonIds
//        {
//            get
//            {
//                if (HttpContext.Current.Session[EnrollableLessonsKey] != null)
//                    return HttpContext.Current.Session[EnrollableLessonsKey] as IList<int>;
//                return null;
//            }
//            set
//            {
//                if (value == null)
//                    HttpContext.Current.Session.Remove(EnrollableLessonsKey);
//                else
//                    HttpContext.Current.Session[EnrollableLessonsKey] = value;
//            }
//        }

        public static StudentConfiguration CurrentStudentConfiguration
        {
            get
            {
                if (HttpContext.Current.Session[CurrentStudentConfigurationKey] != null)
                {
                    int id = Convert.ToInt32(HttpContext.Current.Session[CurrentStudentConfigurationKey]);
                    return DbContext.FromId<StudentConfiguration>(id);
                }
                return null;
            }
            set
            {
                if (value == null)
                    HttpContext.Current.Session.Remove(CurrentStudentConfigurationKey);
                else
                    HttpContext.Current.Session[CurrentStudentConfigurationKey] = value.Id;
            }
        }

        public static List<string> PermanentSessionKeys
        {
            get
            {
                return new List<string> { CurrentDbISessionKey };
            }
        }

        public static void ClearDbSession()
        {
            if (CurrentDbISession != null)
                CurrentDbISession.Clear();
        }

        public static void ClearSession()
        {
            for (int i = HttpContext.Current.Session.Keys.Count - 1; i >= 0; i++)
            {
                string key = HttpContext.Current.Session.Keys[i];
                if(!PermanentSessionKeys.Contains(key))
                    HttpContext.Current.Session.Remove(key);
            }
        }

        public static void FullClearSession()
        {
            HttpContext.Current.Session.Clear();
        }

        public static string GetIP()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }

        public static string GetUserAgent()
        {
            return HttpContext.Current.Request.UserAgent;
        }

//        public static void Signin(Student student)
//        {
//            if(!student.UserInfo.WebLogin)
//                throw new Exception("ورود شما به وب سایت مجاز نیست.");
//
//            CurrentPerson = student;
//            if (CurrentPerson != null)
//            {
//                CurrentPerson.UserInfo.Signin(GetIP());
//                CurrentPerson.UserInfo.Save();
//            }
//        }

        public static void Signin(Person person)
        {
            if (!person.UserInfo.WebLogin)
                throw new MessageException("ورود شما به وب سایت مجاز نیست.");

            CurrentPerson = person;
            if (CurrentPerson != null)
            {
                CurrentPerson.UserInfo.Signin(GetIP());
                CurrentPerson.UserInfo.Save();
            }
        }

        public static void SignOut()
        {
            if (CurrentPerson != null)
            {
                CurrentPerson.UserInfo.Signout();
                CurrentPerson.UserInfo.Save();
            }

            CurrentPerson = null;
        }

        public static string UrlEncode(string input)
        {
            return HttpServerUtility.UrlTokenEncode(Encoding.UTF8.GetBytes(input));
        }

        public static string UrlDecode(string input)
        {
            return Encoding.UTF8.GetString(HttpServerUtility.UrlTokenDecode(input));
        }

        public static string Encrypt(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }

        public static string Decrypt(string input)
        {
            byte[] base64String = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(base64String);
        }
    }

    public enum WebsiteStatus
    {
        [EnumDescription("کل بخش های وب سایت")]
        Normal = 0,
        [EnumDescription("ثبت نام آنلاین")]
        SectionEnrollment = 1,
        [EnumDescription("آزمـون آنلاین")]
        OnlineExam = 2,
    }

    public enum ConsultationStatus
    {
        [EnumDescription("فعـال")]
        Enable = 0,
        [EnumDescription("در بازه زمانی مشخص")]
        ByPeriod = 1,
        [EnumDescription("غیـر فعـال")]
        Disable = 2,
    }
}