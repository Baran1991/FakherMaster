using System;

using System.Collections.Generic;

using System.Data;

using System.Linq;
using System.Net;

using System.Threading;
using System.Windows.Forms;
using DataAccessLayer;

using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Buffet;
using Fakher.Core.Sentinel;
using Fakher.Core.Website;
using Fakher.Reports;
using Fakher.UI;
using Fakher.UI.Report;
using Fakher.UI.SystemFeatures;
using FluentNHibernate.Cfg;
using rApplicationEventFramework;
using rComponents;

using Telerik.WinControls;

using System.Linq.Dynamic;
using mshtml;
using ThreadState = System.Threading.ThreadState;
using Fakher.UI.Reception;

namespace Fakher
{
    static class Program
    {
        private static Person mCurrentPerson;
        private static Department mCurrentDepartment;
        private static EducationalPeriod mCurrentPeriod;
        private static Form frmDesktop;
        private static int mBatchNumber;
        private static Thread mWaitingThread;
        private static int mPageRowNum=20;

        public delegate void VoidWithStringDelegate(string text);
        public delegate void VoidDelegate();
        public static int PageRowNum
        {
            get
            {
                return mPageRowNum;
            }
        }
        public static Person CurrentPerson
        {
            get
            {
                if (mCurrentPerson == null)
                    return null;
                if (mCurrentPerson.Id == 0)
                    return mCurrentPerson;
                return DbContext.FromId<Person>(mCurrentPerson.Id);
            }
        }
        public static Employee CurrentEmployee
        {
            get
            {
                return CurrentPerson as Employee;
            }
        }
        public static Teacher CurrentTeacher
        {
            get
            {
                return CurrentPerson as Teacher;
            }
        }
        public static BuffetSeller CurrentBuffetSeller
        {
            get
            {
                return CurrentPerson as BuffetSeller;
            }
        }
        public static Department CurrentDepartment
        {
            get
            {
                if (mCurrentDepartment == null)
                    return null;
                if (mCurrentDepartment.Id == 0)
                    return mCurrentDepartment;
                return DbContext.FromId<Department>(mCurrentDepartment.Id);
            }
        }
        public static EducationalPeriod CurrentPeriod
        {
            get
            {
                if (mCurrentPeriod == null)
                    return null;
                if (mCurrentPeriod.Id == 0)
                    return mCurrentPeriod;
                return DbContext.FromId<EducationalPeriod>(mCurrentPeriod.Id);
            }
        }

        public static event EventHandler<StartupEventArgs> StartupText;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //                        Test();
            //                        return;

            frmLogin frm = new frmLogin();
            frm.StartWait(false, "راه اندازی اولیه [پایگاه داده]...");
            frm.Show();
            Application.DoEvents();

            try
            {
                Services.InitializePersianNumberFormat();

                Sentinel.PasswordUINeeded += new EventHandler<PasswordUINeededArgs>(Sentinel_PasswordUINeeded);
                rHtmlEditor.InternalMediaRequest += new EventHandler<EventArgs>(rHtmlEditor_InternalMediaRequest);
                //var nhConfig = new ConfigurationBuilder().Build();
                //var sessionFactory = nhConfig.BuildSessionFactory();
                DbContext.InitializeDb();
                DbContext.PolicyMeeted += new EventHandler<rApplicationEventFramework.MeetPolicyEventArgs>(DbContext_PolicyMeeted);
                DbContext.EntityEvent += new EventHandler<EntityEventArgs>(DbContext_EntityEvent);
                DbContext.UnitOfWorkOpen += new EventHandler(DbContext_UnitOfWorkOpen);
                DbContext.OpenUnitOfWork();
            }
            catch (FluentConfigurationException ex)
            {
                MessageBox.Show(ex.InnerException + "");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            frm.EndWait();
            Application.Run(frm);
            if (frm.DialogResult != DialogResult.OK)
                return;

            Application.Run(frmDesktop);

            //            Signout();
            DbContext.CloseUnitOfWork();
        }

        static void rHtmlEditor_InternalMediaRequest(object sender, EventArgs e)
        {
            rHtmlEditor htmlEditor = sender as rHtmlEditor;
            IHTMLControlRange control = htmlEditor.doc.selection.createRange() as IHTMLControlRange;
            if (control != null && control.length > 0)
            {
                IHTMLElement htmlElement = control.item(0);
            }
            else
            {
                IList<WebMedia> allMedia = WebMedia.GetAllMedia(WebMediaType.Media);
                frmSelect frm = new frmSelect(allMedia, new ColumnMapping { Caption = "نـام", ObjectProperty = "Name" });
                if (frm.ShowDialog() != DialogResult.OK)
                    return;

                WebMedia selectedMedia = frm.GetSelectedObject<WebMedia>();
                HtmlElement element = htmlEditor.Document.CreateElement("iframe");
                string domain = "http://www.fakher.ac.ir";
                //                string domain = "http://localhost:37832/Fakher.Web";
                element.SetAttribute("src", domain + "/MediaView.aspx?" + selectedMedia.Code);
                element.Style += "; border: 1px dashed;";
                element.SetAttribute("width", "410px");
                element.SetAttribute("height", "100px");
                htmlEditor.Document.Body.AppendChild(element);
            }
        }

        static void Sentinel_PasswordUINeeded(object sender, PasswordUINeededArgs e)
        {
            frmAccessTagPassword frm = new frmAccessTagPassword();
            DialogResult dialog = frm.ShowDialog();
            if (dialog == DialogResult.OK)
                e.Password = frm.Password;
        }

        private static void OnStartupText(string text)
        {
            if (StartupText != null)
            {
                StartupEventArgs eventArgs = new StartupEventArgs { Text = text };
                StartupText(null, eventArgs);
            }
        }

        internal static void Start()
        {
            OnStartupText("راه اندازی زیرسیستم [کنترل و امنیت]...");
            IQueryable<DbPolicy> policies = DbContext.GetAll<DbPolicy>();
            foreach (DbPolicy policy in policies)
                DbContext.ApplicationEventFactory.Policies.Add(policy as IPolicy);

            OnStartupText("راه اندازی زیرسیستم [میزکار کاربر]...");
            if (CurrentBuffetSeller != null)
                frmDesktop = new frmBuffetSellerDesktop();
            else if (CurrentTeacher != null)
                frmDesktop = new frmTeacherDesktop();
            else if (CurrentEmployee != null)
                frmDesktop = new frmEmployeeDesktop();
            else
                throw new Exception("امکان ورود شما به این بخش از سیستم وجود ندارد");
        }

        internal static void DbContext_UnitOfWorkOpen(object sender, EventArgs e)
        {
            mBatchNumber = EntityEvent.GetNextBatchNumber();
        }

        internal static void DbContext_EntityEvent(object sender, EntityEventArgs e)
        {
            EntityEvent entityEvent = new EntityEvent();
            entityEvent.Action = e.Action;
            entityEvent.Registrar = CurrentPerson;
            entityEvent.RegistrarText = CurrentPerson.FarsiFormalName;
            entityEvent.EntityId = Convert.ToInt32(e.EntityId);
            entityEvent.EntityText = e.EntityText;
            entityEvent.EntityTypeText = e.EntityTypeName;
            entityEvent.BatchNumber = mBatchNumber;

            entityEvent.SavePartially();
        }

        internal static void DbContext_PolicyMeeted(object sender, MeetPolicyEventArgs e)
        {
            rApplicationEventFactory rApplicationEventFactory = (sender as rApplicationEventFactory);
            string expression = rApplicationEventFactory.BuildExpression(e.Policy, e.Entity, e.PreviousValue, e.CurrentValue);

            AppEvent applicationEvent = new AppEvent();
            applicationEvent.Actor = CurrentEmployee.FarsiFullname;
            applicationEvent.Date = PersianDate.Today + "";
            applicationEvent.Time = DateTime.Now.ToString("HH:mm");
            applicationEvent.Description = expression;
            applicationEvent.ObjectId = e.EntityId + "";

            DbPolicy dbPolicy = e.Policy as DbPolicy;
            if (dbPolicy != null)
            {
                applicationEvent.Entity = dbPolicy.TypeName;
                applicationEvent.Operator = dbPolicy.ActionText;
            }

            applicationEvent.SavePartially();
        }

        private static void ShowForm2()
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
            return;
        }

        private static void Test()
        {

            Form3 frm = new Form3();
            frm.ShowDialog();
            return;
            Register register2 = DbContext.FromId<Register>(2243);
            if (register2 == null)
                return;

            //            Report1 rpt = new Report1();
            rptSignupReceipt rpt = new rptSignupReceipt();
            rpt.DataSource = new object[] { register2 };
            frmReportViewer frmReport = new frmReportViewer(rpt);
            frmReport.RightToLeft = RightToLeft.No;
            frmReport.ShowDialog();
            return;

            //            Report1 rpt = new Report1();
            //            rpt.DataSource = new object[] {1, 2, 3, 4, 5, 6};
            //            rpt.PageSettings.PaperKind = PaperKind.A4;
            //            rpt.detail.ColumnCount = 2;
            //            rpt.Width = new Unit(rpt.Width.Value / 2, UnitType.Cm);
            //            frmReportViewer frm = new frmReportViewer(rpt);
            //            frm.ShowDialog();
            //            return;
            //            EducationalPeriod period = DbContext.FromId<EducationalPeriod>(7);
            //            Major major = DbContext.FromId<Major>(4);
            //            List<Register> registers2 = Register.GetVacationedRegisters(period, major).ToList();

            //            foreach (Register register in registers2)
            //            {
            //                int index = register.Student.Registers.IndexOf(register);
            //                if(index == 1)
            //                {
            //                    register.Code = register.Student.Registers[index - 1].Code;
            //                    register.Save();
            //                }
            //            }

            //            ExamParticipate examParticipate = ExamParticipate.GetExamParticipate(1456);
            //            float calculateMark = examParticipate.CalculateMark();

            //            Register register = DbContext.FromId<Register>(1174);
            //            foreach (Participate participate in register.Participates)
            //            {
            //                for (int i = participate.Marks.Count - 1; i >= 0 ; i--)
            //                {
            //                    Mark mark = participate.Marks[i];
            //                    if (mark.Lesson.Id != participate.SectionItem.Lesson.Id)
            //                    {
            //                        Participate lessonParticipate = register.GetParticipate(mark.Lesson);
            //                        participate.Marks.Remove(mark);
            //                        lessonParticipate.Marks.Add(mark);
            //                        mark.Participate = lessonParticipate;
            //                    }
            //                }
            //            }
            //            register.Save();
            //            return;
            var query = from register in DbContext.Entity<Register>()
                        where register.Student != null
                        && register.Major.Id == 2
                        && register.RegisterDate >= PersianDate.FromString("1389/10/01")
                        && register.RegisterDate <= PersianDate.FromString("1389/12/29")
                        select register;
            List<Register> registers = query.ToList();
            List<Register> participate = registers.Where(x => x.ParticipationSign == 1).ToList();
            List<Register> quited = registers.Where(x => x.FullQuitedSign == 1).ToList();

            List<long> longs = participate.Select(x => x.PayableTuition).ToList();
            long sum = participate.Select(x => x.PayableTuition).Sum();

            List<long> list = participate.Select(x => x.FinancialDocument.ReceiptBalance).ToList();
            List<long> list2 = participate.Select(x => x.FinancialDocument.EPaymentBalance).ToList();
            List<long> list3 = participate.Select(x => x.FinancialDocument.PassedChequeBalance).ToList();
            List<long> list4 = participate.Select(x => x.FinancialDocument.ReceiptBalance + x.FinancialDocument.EPaymentBalance + x.FinancialDocument.PassedChequeBalance).ToList();
            List<long> list5 = participate.Select(x => x.FinancialDocument.InProgressChequeBalance).ToList();
            List<long> list6 = participate.Select(x => x.FinancialDocument.ReturnedChequeBalance).ToList();
            List<long> list7 = participate.Select(x => x.FinancialDocument.SuspendedChequeBalance).ToList();
            List<long> list8 = participate.Select(x => x.FinancialDocument.DiscountBalance).ToList();
            List<long> list9 = participate.Select(x => x.DebtAmount).ToList();

            long list1Sum = list.Sum();
            long l = list2.Sum();
            long sum1 = list3.Sum();
            long l1 = list4.Sum();
            long l2 = list5.Sum();
            long sum3 = list6.Sum();
            long l3 = list7.Sum();
            long sum4 = list8.Sum();
            long l4 = list9.Sum();

            long sum2 = /*list1Sum + l + sum1 + */l1 + l2 + sum3 + l3 +
                        sum4 + l4;
            Register elementAt = participate.ElementAt(9);

            //            Major major = DbContext.FromId<Major>(2);
            //            EducationalPeriod period = DbContext.FromId<EducationalPeriod>(1);
            //            rptMasterCard rpt = new rptMasterCard();
            //            rpt.Culture = new CultureInfo("en-us");
            //            rptMasterCard.mMajor = major;
            //            rptMasterCard.mPeriod = period;
            //            rpt.DataSource = new object[] {register};
            //            rpt.Fill();
            //
            //            frmReportViewer frm = new frmReportViewer(rpt);
            //            frm.ShowDialog();
            //            var query = from register in DbContext.Entity<Register>()
            //                        where register.Type == RegisterType.FullQuited
            //                        select register;
            //            foreach (Register register in query.ToList())
            //            {
            //                if(register.Quit == null)
            //                {
            //                    Quit quit = new Quit();
            //                    quit.FinancialItem.Amount = 0;
            //                    quit.PenaltyFee = register.PayableTuition - quit.FinancialItem.Amount;
            //                    register.Quit = quit;
            //                    register.Type = RegisterType.FullQuited;
            //                    register.Student.Save();
            //                }
            //            }

            //            List<Reserve> reserves = DbContext.GetAllEntities<Reserve>();
            //            foreach (Reserve reserve in reserves)
            //            {
            //                if (!string.IsNullOrEmpty(reserve.Code) && 
            //                    reserve.ReserveList != null &&
            //                    (reserve.ReserveList.Id == 84) && 
            //                    reserve.Code.Length == 1)
            //                {
            //                    reserve.Code = reserve.ReserveList.GetNextCode();
            //                    reserve.Save();
            //                }
            //            }

            //            Register.GetCode(new Register() {Major = DbContext.FromId<Major>(3)});

            //            List<EducationalPeriod> educationalPeriods = DbContext.GetAllEntities<EducationalPeriod>();
            //            List<EvaluationProtocol> evaluationProtocols = DbContext.GetAllEntities<EvaluationProtocol>();
            //            List<EducationalRule> educationalRules = DbContext.GetAllEntities<EducationalRule>();
            //            List<ResultProtocol> resultProtocols = DbContext.GetAllEntities<ResultProtocol>();
            //            List<TrainingPlan> trainingPlans = DbContext.GetAllEntities<TrainingPlan>();
            //
            //            foreach (EducationalPeriod period in educationalPeriods)
            //            {
            //                if (period.Id == 4)
            //                    continue;
            //                foreach (EvaluationProtocol evaluationProtocol in evaluationProtocols)
            //                {
            //                    EvaluationProtocol clone = evaluationProtocol.Clone();
            //                    clone.Period = period;
            //                    clone.Save();
            //                }
            //                foreach (EducationalRule educationalRule in educationalRules)
            //                {
            //                    EducationalRule clone = educationalRule.Clone();
            //                    clone.Period = period;
            //                    clone.Save();
            //                }
            //                foreach (ResultProtocol resultProtocol in resultProtocols)
            //                {
            //                    ResultProtocol clone = resultProtocol.Clone();
            //                    clone.Period = period;
            //                    clone.Save();
            //                }
            //                foreach (TrainingPlan trainingPlan in trainingPlans)
            //                {
            //                    TrainingPlan clone = trainingPlan.Clone();
            //                    clone.Period = period;
            //                    clone.Save();
            //                }
            //            }
            //
        }

        internal static void SetTheme(string themeName)
        {
            ThemeResolutionService.ApplicationThemeName = themeName;
        }

        public static void StartWaiting(string text)
        {
            EndWaiting();

            mWaitingThread = new Thread(WaitingThreadStart);
            mWaitingThread.Start(text);

            Thread.Sleep(250);
            Application.UseWaitCursor = true;
            Application.DoEvents();
        }

        public static void StartWaiting()
        {
            EndWaiting();

            mWaitingThread = new Thread(WaitingThreadStart);
            mWaitingThread.Start();

            Thread.Sleep(250);
            Application.UseWaitCursor = true;
            Application.DoEvents();
        }

        public static void EndWaiting()
        {
            if (mWaitingThread != null )
                if(mWaitingThread.ThreadState == ThreadState.Running)
                mWaitingThread.Abort();

            //            Thread.Sleep(25);
            Application.UseWaitCursor = false;
            Application.DoEvents();
        }

        public static void WaitingThreadStart(object param)
        {
            try
            {
                frmWait frm = new frmWait();
                frm.ShowDialog();
            }
            catch (ThreadAbortException ex)
            {
                return;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public static string[] GetAccessEvents()
        {
            var access1 = (frmDesktop as frmEmployeeDesktop).GetAccessEvents().ToList();
            var access2= (new frmReceptionPanel()).GetAccessEvents().ToList();
            access1.AddRange(access2);
            
            return access1.ToArray();
        }

        public static string[] GetTeacherAccessEvents()
        {
            return new frmTeacherDesktop().GetAccessEvents();
        }

        public static void SetCurrentPeriod(EducationalPeriod period)
        {
            mCurrentPeriod = period;
            if (CurrentEmployee != null && period != null)
            {
                if (CurrentEmployee.UserInfo.WorkingPeriod != null && period.Id == CurrentEmployee.UserInfo.WorkingPeriod.Id)
                    return;
                CurrentEmployee.UserInfo.WorkingPeriod = period;
                CurrentEmployee.UserInfo.Save();

                Program.SaveLog("تغییر ترم جاری به [{0}]", period.Name);
            }
        }

        public static void SetCurrentDepartment(Department department)
        {
            mCurrentDepartment = department;
        }

        private static void SetCurrentPerson(Person person)
        {
            mCurrentPerson = person;
        }

        public static bool CanSignin(Person person)
        {
            if (person is Employee)
                return true;
            if (person is Teacher)
                return true;
            if (person is BuffetSeller)
                return true;
            return false;
        }

        public static void Signin(Person person)
        {
            SetCurrentPerson(person);
            if (mCurrentPerson != null)
            {
                mCurrentPerson.UserInfo.Signin(GetIP());
                mCurrentPerson.UserInfo.Save();
            }
        }

        public static void Signout()
        {
            if (mCurrentPerson != null)
            {
                mCurrentPerson.UserInfo.Signout();
                mCurrentPerson.UserInfo.Save();
            }
        }

        public static string GetIP()
        {
            IPHostEntry entry = Dns.GetHostEntry(Dns.GetHostName());
            string localIP = "?";
            foreach (IPAddress ip in entry.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        public static void SaveLog(string description, params object[] args)
        {
            AppLog log = new AppLog();
            log.IP = GetIP();
            log.Description = string.Format(description, args);
            log.Actor = CurrentPerson.FarsiFullname;
            log.Save();
        }


    }

    public class StartupEventArgs : EventArgs
    {
        public string Text { get; set; }
    }
   
}
