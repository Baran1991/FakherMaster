using System;
using System.Collections.Generic;

using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;

using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;

using Fakher.Core.DomainModel.Consult;

using Fakher.Core.Website;
using Fakher.Reports;
using Fakher.Reports.Buffet_Reports;
using Fakher.Reports.Ministerial_Reports;
using Fakher.Reports.Poll_Reports;
using Fakher.Reports.Store_Reports;
using Fakher.UI.AnswersheetReader;
using Fakher.UI.Buffet;
using Fakher.UI.Career;
using Fakher.UI.Consult;
using Fakher.UI.Educational;
using Fakher.UI.Educational.Requests;
using Fakher.UI.Educational.Reserves;
using Fakher.UI.Educational.Sections;
using Fakher.UI.Educational.Students;
using Fakher.UI.Educational.Teachers;
using Fakher.UI.Exam;
using Fakher.UI.Exam.Online_Exam_UI;
using Fakher.UI.Financial;
using Fakher.UI.Fundamental;
using Fakher.UI.Fundamental.Protocol;
using Fakher.UI.Holding;
using Fakher.UI.Ministerial;
using Fakher.UI.Order;
using Fakher.UI.Person;
using Fakher.UI.Poll;
using Fakher.UI.Reception;
using Fakher.UI.Report;
using Fakher.UI.Reserves;
using Fakher.UI.Sections;
using Fakher.UI.Store;
using Fakher.UI.Struture;
using Fakher.UI.Struture.Protocol;
using Fakher.UI.Students;
using Fakher.UI.SystemFeatures;
using Fakher.UI.Website;
using Fakher.UI.Website.Enrollment;
using Fakher.UI.Website.Media;
using Fakher.UI.Website.WebRegister;
using NHibernate;
using rComponents;

using Telerik.WinControls.UI.Docking;
using Message = Fakher.Core.DomainModel.Message;
using Fakher.Reports.Exam_Reports;
using Fakher.Core;
using Fakher.UI.Teachers;
using System.Threading.Tasks;
using System.Threading;
using Fakher.UI.Persons;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace Fakher.UI
{
    public partial class frmEmployeeDesktop : rRadForm
    {
        private Student selectedStudent;
        private List<LinkLabel> mAccessLinks;
        private ISession mLastSearchSession;
        //        private Timer timer;
        //private BackgroundWorker backgroundWorker1;
        //protected override CreateParams CreateParams
        //{
        //    get { CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }

        //}

    public frmEmployeeDesktop()
        {
            InitializeComponent();
           
            Program.SetTheme("Office2010Silver");
            //            Program.SetTheme("Office2010Blue");
            //            Program.SetTheme("Breeze");
            //backgroundWorker1 = new BackgroundWorker();
            //backgroundWorker1.DoWork += new DoWorkEventHandler(BackgroundWorker1_DoWork);
            //documentWindow7.Hide();
            //documentWindow9.Hide();
            //documentWindow4.Hide();
            //documentWindow3.Hide();
            //documentWindow11.Hide();
            //documentWindow10.Hide();
            //documentWindow8.Hide();
            ChildShowing += new EventHandler<FormShowingEventArgs>(frmEmployeeDesktop_ChildShowing);
            DialogShowing += new EventHandler<FormShowingEventArgs>(frmEmployeeDesktop_DialogShowing);
            ChildClosing += frmEmployeeDesktop_ChildClosing;

            lnkFastSignup.Font = Font;
            lnkFastReserve.Font = Font;
            lnkFastQuit.Font = Font;
            lnkFastVacation.Font = Font;
            lnkDeliveryWizard.Font = Font;
            lnkAdvanceSearch.Font = Font;

            rGridViewSearch.Mappings.Add(new ColumnMapping
                                             {
                                                 Caption = "شماره دانشجویی",
                                                 ObjectProperty = "GetCurrentCode",
                                                 NestedUpdate = true
                                             });
            rGridViewSearch.Mappings.Add(new ColumnMapping {Caption = "نام", ObjectProperty = "FarsiFirstName"});
            rGridViewSearch.Mappings.Add(new ColumnMapping {Caption = "نام خانوادگی", ObjectProperty = "FarsiLastName"});
            rGridViewSearch.Mappings.Add(new ColumnMapping {Caption = "نام پدر", ObjectProperty = "FarsiFatherName"});
            rGridViewSearch.Mappings.Add(new ColumnMapping
                                             {
                                                 Caption = "وضعیت آموزشی",
                                                 ObjectProperty = "GetCurrentEducationalStatus()"
                                             });
            rGridViewSearch.Mappings.Add(new ColumnMapping
                                             {Caption = "وضعیت مالی", ObjectProperty = "GetCurrentFinancialStatus()"});

            rGridComboBoxDepartment.Columns.Add("نام دپارتمان", "نام دپارتمان", "Name");

            rGridComboBoxPeriod.Columns.Add("نام", "نام", "Name");
            rGridComboBoxPeriod.Columns.Add("تاریخ شروع", "تاریخ شروع", "StartDate");
            rGridComboBoxPeriod.Columns.Add("تاریخ پایان", "تاریخ پایان", "EndDate");

            rGridComboBoxDepartment.DataSource = Program.CurrentEmployee.AllowedDepartments;

            if (Program.CurrentEmployee.UserInfo.WorkingPeriod != null)
            {
                rGridComboBoxDepartment.Value = Program.CurrentEmployee.UserInfo.WorkingPeriod.Department;
                rGridComboBoxPeriod.Value = Program.CurrentEmployee.UserInfo.WorkingPeriod;

                Program.SetCurrentDepartment(Program.CurrentEmployee.UserInfo.WorkingPeriod.Department);
                Program.SetCurrentPeriod(Program.CurrentEmployee.UserInfo.WorkingPeriod);
            }
        }

        private void frmEmployeeDesktop_DialogShowing(object sender, FormShowingEventArgs e)
        {
            rRadForm rRadForm = e.Form as rRadForm;
            if (rRadForm != null)
            {
                rRadForm.DbSession = DbContext.CurrentSession;
                Program.SaveLog("ورود به [{0}]", rRadForm.Text);
            }
            Reset();
        }

        private void frmEmployeeDesktop_ChildClosing(object sender, FormShowingEventArgs e)
        {
            rRadForm rRadForm = e.Form as rRadForm;
            if (rRadForm != null)
                Program.SaveLog("خروج از [{0}]", rRadForm.Text);
        }

        private void frmEmployeeDesktop_ChildShowing(object sender, FormShowingEventArgs e)
        {
            rRadForm rRadForm = e.Form as rRadForm;
            if (rRadForm != null)
            {
                rRadForm.DbSession = DbContext.CurrentSession;
                Program.SaveLog("ورود به [{0}]", rRadForm.Text);
            }
            Reset();
        }

        private void Reset()
        {
            CloseAllChildForms();
            rGridViewSearch.Clear();
        }
        //private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    UpdateTopPanel();
        //}
        private  void frmDesktop_Load(object sender, EventArgs e)
        {

            //Cursor = Cursors.WaitCursor;
            //Application.UseWaitCursor = true;
            //Application.DoEvents();
            //WaitWnd.WaitWndFun waitForm = new WaitWnd.WaitWndFun();

            this.Enabled = false;

            WindowState = FormWindowState.Maximized;

            //waitForm.Show();
            //WaitingForm wfrm = new WaitingForm();
            //wfrm.ShowDialog();
            //Application.DoEvents();
            //backgroundWorker1.RunWorkerAsync();
            //ShowWaitDialog(this.ac);
            UpdateAccessLinks();
            //            FillTodaySchedule();
            Services.SetLanguageFarsi();



            toolWindow2.DockState = DockState.Docked;
            toolWindow2.DockState = DockState.AutoHide;
            //            toolWindow3.DockState = DockState.Docked;
            //            toolWindow3.DockState = DockState.AutoHide;
            radDock1.ActivateWindow(documentWindow1);
            toolWindow3.Close();

            //            rGridViewSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            //            timer = new Timer();
            //            timer.Interval = 2700000;
            //            timer.Tick += new EventHandler(timer_Tick);
            //            StartTimer();
            lblUserName.Text = Program.CurrentEmployee.FarsiFullname;

           
            long balance =  Program.CurrentEmployee.GetFinancialBalance();
            if (balance < 0)
                rMessageBox.ShowError(
                    "حساب روزانه شما تسویه نشده است. لطفا قبل از هر کاری حتما به مسئول تسویه مراجعه کنید.");

            #region Financial Balance

            //تغیر در محاسبه مالی انجام شد و درست است.
            lnkFinancial.Text = balance.ToString("C0");
            if (balance < 0)
                lnkFinancial.LinkColor = lnkFinancial.VisitedLinkColor = Color.Red;
            else
                lnkFinancial.LinkColor = lnkFinancial.VisitedLinkColor = Color.Black;

            #endregion
             UpdateTopPanel();
            DbContext.ExclusiveSessionStart += new EventHandler(DbContext_ExclusiveSessionStart);
            DbContext.ExclusiveSessionEnd += new EventHandler(DbContext_ExclusiveSessionEnd);
            //Cursor = Cursors.Default;
            //Application.UseWaitCursor = false;
            //Application.DoEvents();
            var TodayRefunds = DbContext.Entity<Quit>().Where(m => m.RefundDate == PersianDate.Today);
            lnkTodayRefunds.Visible = false;
            if (TodayRefunds != null)
                if (TodayRefunds.Count() > 0)
                    lnkTodayRefunds.Visible = true;

            var TodayCheques = Cheque.GetCheques(PersianDate.Today, PersianDate.Today);
            lnkTodayCheque.Visible = false;
            if (TodayCheques != null)
                if (TodayCheques.Count() > 0)
                    lnkTodayCheque.Visible = true;
            this.Enabled = true;
            //wfrm.Close();
        }
        //private  void frmDesktop_Load(object sender, EventArgs e)
        //{

        //    //Cursor = Cursors.WaitCursor;
        //    //Application.UseWaitCursor = true;
        //    //Application.DoEvents();
        //    //WaitWnd.WaitWndFun waitForm = new WaitWnd.WaitWndFun();

        //    this.Enabled = false;

        //    WindowState = FormWindowState.Maximized;

        //    //waitForm.Show();
        //    //WaitingForm wfrm = new WaitingForm();
        //    //wfrm.ShowDialog();
        //    //Application.DoEvents();
        //    //backgroundWorker1.RunWorkerAsync();
        //    //ShowWaitDialog(this.ac);
        //    UpdateAccessLinks();
        //    //            FillTodaySchedule();
        //    Services.SetLanguageFarsi();



        //    toolWindow2.DockState = DockState.Docked;
        //    toolWindow2.DockState = DockState.AutoHide;
        //    //            toolWindow3.DockState = DockState.Docked;
        //    //            toolWindow3.DockState = DockState.AutoHide;
        //    radDock1.ActivateWindow(documentWindow1);
        //    toolWindow3.Close();

        //    //            rGridViewSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left;

        //    //            timer = new Timer();
        //    //            timer.Interval = 2700000;
        //    //            timer.Tick += new EventHandler(timer_Tick);
        //    //            StartTimer();
        //    lblUserName.Text = Program.CurrentEmployee.FarsiFullname;


        //    //long balance = await Program.CurrentEmployee.GetFinancialBalance();
        //    //if (balance < 0)
        //    //    rMessageBox.ShowError(
        //    //        "حساب روزانه شما تسویه نشده است. لطفا قبل از هر کاری حتما به مسئول تسویه مراجعه کنید.");

        //    #region Financial Balance

        //    //تغیر در محاسبه مالی انجام شد و درست است.
        //    //lnkFinancial.Text = balance.ToString("C0");
        //    //if (balance < 0)
        //    //    lnkFinancial.LinkColor = lnkFinancial.VisitedLinkColor = Color.Red;
        //    //else
        //    //    lnkFinancial.LinkColor = lnkFinancial.VisitedLinkColor = Color.Black;

        //    #endregion
        //    //await UpdateTopPanel();
        //    DbContext.ExclusiveSessionStart += new EventHandler(DbContext_ExclusiveSessionStart);
        //    DbContext.ExclusiveSessionEnd += new EventHandler(DbContext_ExclusiveSessionEnd);
        //    //Cursor = Cursors.Default;
        //    //Application.UseWaitCursor = false;
        //    //Application.DoEvents();
        //    this.Enabled = true;
        //    //wfrm.Close();
        //}
        private void ShowWaitDialog(Action codeToRun)
        {
            ManualResetEvent dialogLoadedFlag = new ManualResetEvent(false);

            // open the dialog on a new thread so that the dialog window gets
            // drawn. otherwise our long running code will run and the dialog
            // window never renders.
            (new Thread(() =>
            {
                Form waitDialog = new Form()
                {
                    Name = "WaitForm",
                    Text ="درحال پردازش اطلاعات. لطفا منتظر بمانید...",
                    ControlBox = false,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    StartPosition = FormStartPosition.CenterParent,
                    Width = 240,
                    Height = 50,
                    Enabled = true
                };

                ProgressBar ScrollingBar = new ProgressBar()
                {
                    Style = ProgressBarStyle.Marquee,
                    Parent = waitDialog,
                    Dock = DockStyle.Fill,
                    Enabled = true
                };

                waitDialog.Load += new EventHandler((x, y) =>
                {
                    dialogLoadedFlag.Set();
                });

                waitDialog.Shown += new EventHandler((x, y) =>
                {
                    // note: if codeToRun function takes a while it will 
                    // block this dialog thread and the loading indicator won't draw
                    // so launch it too in a different thread
                    (new Thread(() =>
                    {
                        codeToRun();

                        // after that code completes, kill the wait dialog which will unblock 
                        // the main thread
                        this.Invoke((MethodInvoker)(() => waitDialog.Close()));
                    })).Start();
                });

                this.Invoke((MethodInvoker)(() => waitDialog.ShowDialog(this)));
            })).Start();

            while (dialogLoadedFlag.WaitOne(100, true) == false)
                Application.DoEvents(); // note: this will block the main thread once the wait dialog shows
        }
        private void DbContext_ExclusiveSessionStart(object sender, EventArgs e)
        {
            //            StopTimer();
        }

        private void DbContext_ExclusiveSessionEnd(object sender, EventArgs e)
        {
            //            StartTimer();
        }

        public void StartTimer()
        {
            //            timer.Enabled = true;
        }

        public void StopTimer()
        {
            //            timer.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //            UpdateTopPanel();
        }

        private void Search()
        {
            if (mLastSearchSession != null)
            {
                DbContext.CloseUnitOfWork(mLastSearchSession);
                mLastSearchSession = null;
            }

            //            CloseAllChildForms();
            //            DbContext.BackToMainSession();

            mLastSearchSession = DbContext.OpenUnitOfWork();

            int code = rTxtCode.GetValue<int>();
            string firstName = radTxtFirstname.Text.Trim();
            firstName = Regex.Replace(firstName, @"\s+", "");
            string lastName = radTxtLastname.Text.Trim();
            lastName= Regex.Replace(lastName, @"\s+", "");
            List<Student> result = new List<Student>();

            try
            {
                Cursor = Cursors.WaitCursor;
                Application.UseWaitCursor = true;
                Application.DoEvents();

                Program.SaveLog("جستجو [{0}] [{1}] [{2}]", code, firstName, lastName);

                if (code != 0)
                {
                    List<Register> registers = Register.FromCode(code + "");
                    foreach (Register register in registers)
                        result.UniqueAdd(register.Student);
                    List<Reserve> reserves = Reserve.FromCode(code + "");
                    foreach (Reserve reserve in reserves)
                        result.UniqueAdd(reserve.Student);
                }
                else
                {
                    if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                    {
                        rMessageBox.ShowError(
                            "جستجو فقط می تواند بر اساس (شماره دانشجویی) یا (نام و نام خانوادگی) انجام شود.");
                        return;
                    }

                    if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                    {
                        result.AddRange(Student.Search(firstName, lastName));
                    }
                    else
                    {
                        result.AddRange(Student.SearchByFirstname(firstName));
                        result.AddRange(Student.SearchByLastname(lastName));
                    }
                }
            }
            catch (Exception e)
            {
                rMessageBox.ShowError(e.Message);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
                Application.UseWaitCursor = false;
                Application.DoEvents();
            }

            rGridViewSearch.ClearFilters();
            rGridViewSearch.DataBind(result);
            rGridViewSearch.Focus();
        }

        private void lnkAdvanceSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("نام", "FarsiFirstName");
            data.Add("نام خانوادگی", "FarsiLastName");
            data.Add("نام پدر", "FarsiFatherName");
            data.Add("تلفن", "ContactInfo.Phone");
            data.Add("تلفن همراه", "ContactInfo.Mobile");
            frmCriteria frm = new frmCriteria(data);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            if (frm.Criterias.Count == 0)
                return;

            if (mLastSearchSession != null)
            {
                DbContext.CloseUnitOfWork(mLastSearchSession);
                mLastSearchSession = null;
            }

            mLastSearchSession = DbContext.OpenUnitOfWork();

            List<Student> result;
            var query = DbContext.Entity<Student>();
            foreach (Criteria criteria in frm.Criterias)
                query = query.Where(criteria.Text);

            try
            {
                Cursor = Cursors.WaitCursor;
                Application.UseWaitCursor = true;
                Application.DoEvents();

                result = query.ToList();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
                Application.UseWaitCursor = false;
                Application.DoEvents();
            }

            rGridViewSearch.ClearFilters();
            rGridViewSearch.DataBind(result);
            rGridViewSearch.Focus();
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            try
            {
                DbContext.StartExclusiveSession(true);
                selectedStudent = rGridViewSearch.GetSelectedObject<Student>();
                ShowDialogForm(new frmReceptionPanel(selectedStudent) {AutoCloseUnitOfWork = false});
            }
            finally
            {
                DbContext.EndExclusiveSession();
            }
        }

        private void frmEmployeeDesktop_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseAllChildForms();
            Program.SaveLog("خروج از سیستم جامع");
        }

        private void UpdateAccessLinks()
        {
            List<LinkLabel> linkLabels = GetAllLinkLabels();
            foreach (LinkLabel label in linkLabels)
            {
                label.Enabled = Program.CurrentEmployee.UserInfo.IsAllowed(label.Text);
            }
        }

        //        private void FillTodaySchedule()
        //        {
        //            if (Program.CurrentPeriod != null)
        //            {
        //                List<Section> sections = Section.GetSections(Program.CurrentPeriod);
        //                rScheduler1.Fill(sections);
        //            }
        //        }

        public string[] GetAccessEvents()
        {
            List<string> accessEvents = new List<string>();
            List<LinkLabel> linkLabels = GetAllLinkLabels();
            foreach (LinkLabel label in linkLabels)
                accessEvents.Add(label.Text);
            return accessEvents.ToArray();
        }

        private List<LinkLabel> GetAllLinkLabels()
        {
            if (mAccessLinks == null)
            {
                mAccessLinks = new List<LinkLabel>();
                List<LinkLabel> linkLabels = FindLinkLabels(Controls);
                linkLabels.Add(lnkFastSignup);
                linkLabels.Add(lnkFastTransition);
               linkLabels.Add(lnkFastVacation);
               linkLabels.Add(lnkFastReserve);
               linkLabels.Add(lnkFastQuit);
               linkLabels.Add(lnkFastBatchSignup);
               linkLabels.Add(lnkDeliveryWizard);
                linkLabels.Add(lnkPreEnrollmentWizard);
                mAccessLinks.AddRange(linkLabels);
               
            }
            return mAccessLinks;
        }

        private List<LinkLabel> FindLinkLabels(Control.ControlCollection controls)
        {
            List<LinkLabel> list = new List<LinkLabel>();
            foreach (Control control in controls)
            {
                if (control is LinkLabel && control.AccessibleRole != AccessibleRole.None)
                    list.Add(control as LinkLabel);
                list.AddRange(FindLinkLabels(control.Controls));

            }
            
                 
            return list;
        }
        
        private void lnkDepartments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmDepartmentList());
        }

        private void lnkPeriods_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmPeriodsList());
        }

        private void lnkLessons_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmLessonList());
        }

        private void lnkBooks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmEducationalToolList());
        }

        private void lnkPlaces_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmPlaceList());
        }

        private void lnkEvalProtocols_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmEvalProtocolList());
        }

        private void lnkResultProtocols_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmResultProtocolList());
        }

        private void lnkStudents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmParticipateList());
        }

        private void lnkTeachers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmTeacherList());
        }

        private void lnkNewSection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();

            Section section = new Section
                                  {
                                      Period = Program.CurrentPeriod,
                                      StartDate = Program.CurrentPeriod.StartDate,
                                      FinishDate = Program.CurrentPeriod.EndDate
                                  };
            frmSectionDetail frm = new frmSectionDetail(section);
            if (!frm.ProcessObject())
                return;
            section.Save();
            rMessageBox.ShowInformation(string.Format("کلاس {0} با موفقیت ثبت و تشکیل گردید.", section.Name));
            DbContext.CloseUnitOfWork();
        }

        private void lnkSectionsSchedule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmSectionsSchedule());
        }

        private void lnkDailyPayoff_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmPayoff());
            DbContext.CloseUnitOfWork();
        }

        private void lnkEmployeeList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmEmployeeList());
        }

        private void lnkNewEmployee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            Employee employee = new Employee();
            frmPersonDetail frm = new frmPersonDetail(employee);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            employee.Code = Core.DomainModel.Person.GetNextCode<Employee>();
            employee.Save();
            rMessageBox.ShowInformation(string.Format("پرسنل [{0}] با شماره پرونده [{1}] ثبت گردید.",
                                                      employee.FarsiFullname, employee.Code));
            DbContext.CloseUnitOfWork();
        }

        private void rGridComboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            CloseAllChildForms();
            DbContext.BackToMainSession();
            Department department = rGridComboBoxDepartment.GetValue<Department>();
            rGridComboBoxPeriod.Clear();
            rGridComboBoxPeriod.DataSource = department?.EducationalPeriods.OrderByDescending(x => x.Id);
            if (IsHandleCreated)
            {
                Program.SetCurrentDepartment(department);
                if (department.EducationalPeriods.Count > 0)
                {
                    rGridComboBoxPeriod.Value = department.GetProperPeriod();
                }
            }
        }

        private new void CloseAllChildForms()
        {
            List<HostWindow> windows = new List<HostWindow>();
            foreach (DockWindow dockWindow in radDock1.DockWindows)
                if (dockWindow is HostWindow)
                    windows.Add(dockWindow as HostWindow);

            foreach (HostWindow hostWindow in windows)
                hostWindow.Close();

            rGridViewSearch.Clear();
        }

        private void rGridComboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsShowed)
            {
                CloseAllChildForms();
                DbContext.BackToMainSession();
                EducationalPeriod period = rGridComboBoxPeriod.GetValue<EducationalPeriod>();
                if (period != null)
                {
                    period.RefreshEntity();
                    Program.SetCurrentPeriod(period);
                }
            }
        }

        private void lnkSectionAbsences_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmSectionAbsences());
        }

        private void lnkSectionList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmSectionsList());
        }

        private void UpdateTopPanel()
        {
            try
            {
                DbContext.OpenUnitOfWork();

                #region Messages

                //IQueryable<Message> receivedMessages = Program.CurrentEmployee.GetReceivedMessages(MessageStatus.UnRead);
                int count =( Program.CurrentEmployee.GetReceivedMessages(MessageStatus.UnRead)).Count();
                string linkText = "صندوق پیام";

                if (count > 0)
                {
                    lnkMessage.Text = string.Format("{0} ({1} پیام جدید)", linkText, count);
                    lnkMessage.Font = new Font(lnkMessage.Font.Name, lnkMessage.Font.Size, FontStyle.Bold);
                }
                else
                {
                    lnkMessage.Text = string.Format(linkText);
                    lnkMessage.Font = new Font(lnkMessage.Font.Name, lnkMessage.Font.Size, FontStyle.Regular);
                }

                #endregion



                #region Student Requests
                //محسابه تعداد درخواستها بدون لود لیست کامل
                IQueryable<Request> notRepliedRequests = Request.GetRequestsByStatus(RequestStatus.Waiting);
                var notRepliedRequestsCount = Request.GetRequestsByStatusCount(RequestStatus.Waiting);
                IQueryable<Request> toReviseRequests = Request.GetRequestsByStatus(RequestStatus.InRevise);
                var toReviseRequestsCount = Request.GetRequestsByStatusCount(RequestStatus.InRevise);
                string requestText = "درخواست ها";
                string toReviseText = toReviseRequestsCount > 0 ? string.Format(" ({0}) ", toReviseRequestsCount) : "";

                if (notRepliedRequestsCount > 0)
                {
                    lnkTopRequests.Text = string.Format("{0} ({1})", requestText, notRepliedRequestsCount);
                    lnkTopRequests.Font = new Font(lnkTopRequests.Font.Name, lnkTopRequests.Font.Size, FontStyle.Bold);
                }
                else
                {
                    lnkTopRequests.Text = string.Format("{0}", requestText);
                    lnkTopRequests.Font = new Font(lnkTopRequests.Font.Name, lnkTopRequests.Font.Size, FontStyle.Regular);
                }
                lnkTopRequests.Text += toReviseText;

                #endregion

                #region Exam Requests
                ///لود تعداد درخواستها بجای لود لیست درخواستها
                var pendingExamRequestsCount = ExamRequest.GetRequestsCount(ExamRequestStatus.Pending);
                var acceptedExamRequestsCount = ExamRequest.GetRequestsCount(ExamRequestStatus.Accepted);
                string examRequestText = "درخواست آزمون";
                string pendingText = "";
                string acceptedText = "";
                if (pendingExamRequestsCount > 0)
                {
                    pendingText = string.Format("جـدیــد ({0})", pendingExamRequestsCount);
                }
                if (acceptedExamRequestsCount > 0)
                {
                    acceptedText = string.Format("اقدام نشده ({0})", acceptedExamRequestsCount);
                }

                if (string.IsNullOrEmpty(pendingText) && string.IsNullOrEmpty(acceptedText))
                {
                    lnkTopExamRequests.Text = string.Format("{0}", examRequestText);
                    lnkTopExamRequests.Font = new Font(lnkTopExamRequests.Font.Name, lnkTopExamRequests.Font.Size,
                                                       FontStyle.Regular);
                }
                else
                {
                    string delimiterText = !string.IsNullOrEmpty(acceptedText) && !string.IsNullOrEmpty(pendingText)
                                               ? " | "
                                               : "";
                    lnkTopExamRequests.Text = string.Format("{0} [ {1}{2}{3} ]", examRequestText, pendingText,
                                                            delimiterText, acceptedText);
                    lnkTopExamRequests.Font = new Font(lnkTopExamRequests.Font.Name, lnkTopExamRequests.Font.Size,
                                                       FontStyle.Bold);
                }

                #endregion

                #region PreEnrollments
                //فراخوانی تعداد پیش ثبت نام ها بجای لود کامل لیست
                //IList<Fakher.Core.DomainModel.PreEnrollment> preEnrollments =
                //    Fakher.Core.DomainModel.PreEnrollment.GetPreEnrollments();
                //IQueryable<Fakher.Core.DomainModel.PreEnrollment> didNotMakeContact =
                //    Fakher.Core.DomainModel.PreEnrollment.GetPreEnrollments(preEnrollments,
                //                                                            Fakher.Core.DomainModel.PreEnrollment.
                //                                                                ContactStatus.Waiting);
                var didNotMakeContactCount = Fakher.Core.DomainModel.PreEnrollment.GetPreEnrollmentsCount(Fakher.Core.DomainModel.PreEnrollment.
                                                                      ContactStatus.Waiting);
                string preEnrollmentText = "پیش ثبت نام ها";
                string toContactText = "";
                if (didNotMakeContactCount > 0)
                {
                    lnkPreEnrollments.Text = string.Format("{0} ({1})", preEnrollmentText, didNotMakeContactCount);
                    lnkPreEnrollments.Font = new Font(lnkPreEnrollmentList.Font.Name, lnkPreEnrollmentList.Font.Size,
                                                      FontStyle.Bold);
                }
                else
                {
                    lnkPreEnrollments.Text = string.Format("{0}", requestText);
                    lnkPreEnrollments.Font = new Font(lnkPreEnrollmentList.Font.Name, lnkPreEnrollmentList.Font.Size,
                                                      FontStyle.Regular);
                }
                lnkPreEnrollments.Text += toContactText;

                #endregion

                #region FinancialCommitments

                string financialCommitmentText = "تعهدات مالی";
                int todayCommitments =( FinancialCommitment.GetCommitments(PersianDate.Today, PersianDate.Today)).Count();
                if (todayCommitments > 0)
                {
                    lnkTopFinancialCommitments.Text = string.Format("{0} ({1})", financialCommitmentText, todayCommitments);
                    lnkTopFinancialCommitments.Font = new Font(lnkTopFinancialCommitments.Font.Name, lnkTopFinancialCommitments.Font.Size,
                                                      FontStyle.Bold);
                }
                else
                {
                    lnkTopFinancialCommitments.Text = string.Format("{0}", financialCommitmentText);
                    lnkTopFinancialCommitments.Font = new Font(lnkTopFinancialCommitments.Font.Name, lnkTopFinancialCommitments.Font.Size,
                                                      FontStyle.Regular);
                }

                #endregion

//                #region FuturePayments
//
//                string futurePaymentText = "پرداخت های آتیه";
//                int c = FinancialItem.GetIssuedFinancialItem(PersianDate.Today, PersianDate.Today).Count();
//                if (c > 0)
//                {
//                    lnkTopFuturePayments.Text = string.Format("{0} ({1})", futurePaymentText, c);
//                    lnkTopFuturePayments.Font = new Font(lnkTopFuturePayments.Font.Name, lnkTopFuturePayments.Font.Size,
//                                                      FontStyle.Bold);
//                }
//                else
//                {
//                    lnkTopFuturePayments.Text = string.Format("{0}", futurePaymentText);
//                    lnkTopFuturePayments.Font = new Font(lnkTopFuturePayments.Font.Name, lnkTopFuturePayments.Font.Size,
//                                                      FontStyle.Regular);
//                }
//
//                #endregion
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
            }
            finally
            {
                DbContext.CloseUnitOfWork();
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Search();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void radTxtFirstname_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                    Search();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void radTxtLastname_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                    Search();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void lnkPlacementProtocols_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmPlacementProtocolList());
        }

        private void lnkClassListReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmParameters = new frmReportParameters(new rptFaClassList(), new rptEnClassList());
            frmParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkFastSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CloseAllChildForms();
            DbContext.BackToMainSession();

            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmSignupWizard());
            DbContext.CloseUnitOfWork();
        }

        private void lnkTeacherAbsence_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmTeacherAbsences());
        }

        private void lnkChequeList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmParameters = new frmReportParameters(new rptChequeList());
            frmParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkChequeSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmChequeSearch());
        }
        private void lnkChequeSendingDates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmChequeSendingDates());
        }

        private void lnkDiscountProtocols_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmEducationalRuleList());
        }

        private void lnkToolEntry_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //            DbContext.OpenUnitOfWork();
            //            ShowDialogForm(new frmEducationalToolSupplyDetail());
            //            DbContext.CloseUnitOfWork();
        }

        private void lnkToolSupply_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmParameters = new frmReportParameters(new rptToolSupply());
            frmParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkExamList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmExamList(ExamType.PaperBasedExam));
        }

        private void lnkSectionReplacement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmSectionReplacements());
        }

        private void lnkMakeups_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmSectionMakeups());
        }

        private void lnkSignupReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmParameters = new frmReportParameters(new rptSignupStat());
            frmParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkReserveList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmReserveList());
        }

        private void lnkRequests_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.CurrentPerson.UserInfo.IsAllowed(lnkRequests.Text))
                return;
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmRequestList());
        }

        private void lnkStudentAbsencesReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptStudentAbsences());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkDebtorStudentsReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptDebtorStudents());
            frmReportParameters.ShowDialog();
            DbContext.CloseUnitOfWork();
        }

        private void lnkAccessGroups_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmAccessGroupList());
        }

        private void lnkTeacherObserves_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmSectionObserves());
        }

        private void lnkSellReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmParameters = new frmReportParameters(new rptStoreSells());
            frmParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkTrainingPlans_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmTrainingPlanList());
        }

        private void lnkQuitedStudentReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmParameters = new frmReportParameters(new rptQuitedStudents());
            frmParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkIdCardReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmParameters = new frmReportParameters(new rptFaIdCard(), new rptEnIdCard());
            frmParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkPolicyList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmEventPolicyList());
        }

        private void lnkAnswersheetReader_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();

            // 3 Hours get me to this: if showintaskbar=false then twain cannot work properly !!!!!
            frmReader frmReader = new frmReader();
            frmReader.ShowInTaskbar = true;
            frmReader.ShowDialog(this);

            DbContext.CloseUnitOfWork();
        }

        private void lnkMessage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmMessageBox(Program.CurrentEmployee));
        }

        private void lnkEntryStudentsReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmParameters = new frmReportParameters(new rptEntryStudents());
            frmParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkFullQuitedStudentsReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmParameters = new frmReportParameters(new rptFullQuitedStudents());
            frmParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkBackup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.RestoreDirectory = true;
            dialog.AddExtension = true;
            dialog.Filter = "Backup File (*.backup)|*.backup";
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                DbContext.OpenUnitOfWork();
                DbContext.CreateBackup(dialog.FileName);
                rMessageBox.ShowInformation("فایل پشتیبان پایگاه داده ایجاد گردید.");
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
            finally
            {
                DbContext.CloseUnitOfWork();
            }
        }

        private void lnkRestore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.RestoreDirectory = true;
            dialog.AddExtension = true;
            dialog.Filter = "Backup File (*.backup)|*.backup";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                CloseAllChildForms();
                DbContext.OpenUnitOfWork();
                DbContext.RestoreBackup(dialog.FileName);
                rMessageBox.ShowInformation("فایل پشتیبان پایگاه داده جایگزین گردید.");
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
            finally
            {
                DbContext.CloseUnitOfWork();
            }
        }

        private void lnkCodingReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StopTimer();

            DbContext.OpenUnitOfWork();

            frmReportParameters frmParameters = new frmReportParameters(new rptFaAnswersheetHeader(),
                                                                        new rptEnAnswersheetHeader());
            frmParameters.ShowDialog(this);

            DbContext.CloseUnitOfWork();

            StartTimer();
        }

        private void lnkEnterMarks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            ShowChildForm(new frmEnterMark());
        }

        private void lnkOralExamList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmExamList(ExamType.OralExam));
        }

        private void lnkOnlineExamList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmExamList(ExamType.OnlineExam));
        }

        private void lnkNewOralExam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmOralExamWizard frm = new frmOralExamWizard();
            frm.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkNewOnlineExam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmOnlineExamWizard frm = new frmOnlineExamWizard();
            frm.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkExamKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();

            frmEnterExamKeyWizard frm = new frmEnterExamKeyWizard(ExamType.PaperBasedExam);
            frm.ShowDialog(this);

            DbContext.CloseUnitOfWork();
        }

        private void lnkExamWizard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();

            frmExamWizard frm = new frmExamWizard();
            frm.ShowDialog(this);

            DbContext.CloseUnitOfWork();
        }

        private void lnkExamCardReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmParameters = new frmReportParameters(new rptFaExamCard(), new rptEnExamCard());
            frmParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkEvents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmEventList());
        }

        private void lnkReportCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmParameters = new frmReportParameters(new rptFaReportCard(), new rptEnReportCard());
            frmParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkEnterStudentPictures_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmEnterStudentPicture());
        }

        private void lnkPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowDialogForm(new frmPersonPassword(Program.CurrentEmployee.UserInfo));
            DbContext.CloseUnitOfWork();
        }

        private void lnkLessonPeriod_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmLessonHoldingList());
        }

        private void lnkFastReserve_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CloseAllChildForms();
            DbContext.BackToMainSession();

            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmReserveWizard());
            DbContext.CloseUnitOfWork();
        }

        private void lnkStudentFileList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmStudentFileList());
        }

        private void lnkFastQuit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CloseAllChildForms();
            DbContext.BackToMainSession();

            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmQuitWizard());
            DbContext.CloseUnitOfWork();
        }
        private void lnkFastTransition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CloseAllChildForms();
            DbContext.BackToMainSession();

            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmTransitionWizard());
            DbContext.CloseUnitOfWork();
        }
        private void lnkFastVacation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CloseAllChildForms();
            DbContext.BackToMainSession();

            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmVacationWizard());
            DbContext.CloseUnitOfWork();
        }

        private void lnkActivityListReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptEnClassActivityList());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkStudentContacts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptRegisterContacts());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkRegisterStatReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptRegisterStat());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }
        private void lnkElectronicPaymentSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmElectronicPaymentSearch());
        }
        private void lnkReceiptSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmReceiptSearch());
        }

        private void lnkExamRequestReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptExamRequestList());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkBatchSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmBatchSignup());
        }

        private void lnkExamResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptFaExamResult(),
                                                                              new rptEnExamResult());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkInstituteSignupReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptInstituteSignup());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkExamRequestList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Program.CurrentPerson.UserInfo.IsAllowed(lnkExamRequestList.Text))
                return;
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmExamRequestList());
        }

        private void lnkTeacherContracts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmTeachingContractList());
        }

        private void lnkExamReportCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptFaExamReportCard(),
                                                                              new rptEnExamReportCard());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkVacationedRegisterReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptVacationRegisters());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkStoreStatReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptStoreStat());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkMasterCardReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptMasterCard());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkSignupStatBySection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptSignupStatBySection());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkStudentResultsReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptStudentResults());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkReceiptListReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptReceiptList());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkEPaymentsListReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptEPaymentList());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkBanParticipates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmBansList());
        }

        private void lnkDiscountedRegistersReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptDiscountedRegisters());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkRegistersSignupInfoReport_Click(object sender, EventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptRegistersSignupInfo());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkEditSupply_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowDialogForm(new frmSupplyEdit());
            DbContext.CloseUnitOfWork();
        }

        private void lnkStoreUsesReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptStoreUses());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkManualAssignAnswersheet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowDialogForm(new frmManualAssignAnswersheet());
            DbContext.CloseUnitOfWork();
        }

        private void lnkOralExamPanel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmOralExamHoldingPanel());
            DbContext.CloseUnitOfWork();
        }

        private void lnkSalaryRateProtocolList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmSalaryRateProtocolList());
        }

        private void lnkIncompleteRegistersReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptIncompleteRegisterContacts());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkCalculatePayroll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowDialogForm(new frmCalculatePayroll(true, false));
            DbContext.CloseUnitOfWork();
        }

        private void lnkCreditorStudentsReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptCreditorStudents());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkPreparePeriod_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowDialogForm(new frmPreparePeriod());
            DbContext.CloseUnitOfWork();
        }

        private void lnkReserveListStatReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptReserveListStat());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkExamAnalysisReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptExamAnalysis());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkSectionResultsReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptSectionResults());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkUpgrade_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmUpgrade());
            DbContext.CloseUnitOfWork();
        }

        private void lnkStudentResultDetailReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptStudentResultDetails());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkManageOralExam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmOralExamManagePanel());
            DbContext.CloseUnitOfWork();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmExamBatchSignup());
            DbContext.CloseUnitOfWork();
        }

        private void lnkFinancial_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            IList<FinancialItem> items =
                Program.CurrentEmployee.GetInsertedFinancialItems(PersianDate.Today, PersianDate.Today)
                    .ToList();
            IList<FinancialItem> pureItems = items.Except(Program.CurrentEmployee.DailyDocument.Items).ToList();
            frmAdvanceFinancialDetail frm = new frmAdvanceFinancialDetail(pureItems);
            frm.IsCustomed = true;
            frm.CanAdd = frm.CanEdit = frm.CanDelete = false;
            ShowDialogForm(frm);
            DbContext.CloseUnitOfWork();
        }

        private void lnkAssignSeatNumberWizard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmPaperBasedExamHoldingWizard());
            DbContext.CloseUnitOfWork();
        }

        private void lnkDeliveryWizard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CloseAllChildForms();
            DbContext.BackToMainSession();

            frmDeliveryWizard frm;
            do
            {
                DbContext.OpenUnitOfWork(true);
                frm = new frmDeliveryWizard();
                ShowDialogForm(frm);
                DbContext.CloseUnitOfWork();
            } while (frm.IsUsed);
        }

        private void lnkExamParticipateListReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptExamParticipateList());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkStorePanel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmStorePanel());
        }

        private void lnkExamHoldingReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptExamHoldingList());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkTeachingAbstractReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptTeachingAbstract());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkPresenceList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmPresenceList());
        }

        private void lnkSectionFundamentalDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmSectionFundamentalDetail());
            DbContext.CloseUnitOfWork();
        }

        private void lnkPayrollReceiptReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters =
                new frmReportParameters(new rptPayrollReceipt() {forTeacher = true});
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkTeacherPayrollList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmPayrollList(true, false));
        }

        private void lnkToolGroupList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmEducationalToolGroupList());
        }

        private void lnkQuestionnaireDesign_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            ShowChildForm(new frmQuestionnaireExamList());
        }

        private void lnkSiteMenus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmMenuItemList());
        }


        private void lnkNewsList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmNewsList());
        }

        private void lnkWebpageList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmWebpageList());
        }

        private void lnkExamTopResultReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptFaExamTopResultList());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkImageLessReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptImageLessStudents());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkExtractStudentPictures_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowDialogForm(new frmExtractStudentPictures());
            DbContext.CloseUnitOfWork();
        }

        private void lnkReserveListFullStat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptReserveListFullStat());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void frmEmployeeDesktop_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void lnkWebsiteSections_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmWebsiteSectionList());
        }

        private void lnkWebsiteUserList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmWebsiteUserList());
        }

        private void lnkOnlineExamKeyWizard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();

            frmEnterExamKeyWizard frm = new frmEnterExamKeyWizard(ExamType.OnlineExam);
            frm.ShowDialog(this);

            DbContext.CloseUnitOfWork();
        }

        private void lnkPreEnrollmentList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmPreEnrollmentList());
        }

        private void lnkFastAddNews_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();

            WebNews news = new WebNews();
            frmNewsDetail frm = new frmNewsDetail(news);
            if (!frm.ProcessObject())
                return;
            news.Save();

            rMessageBox.ShowInformation(string.Format("خبر {0} با موفقیت ثبت گردید.", news.Title));
            DbContext.CloseUnitOfWork();
        }

        private void lnkJudicialConsultations_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmConsultationsList(ConsultationCategory.Judicial));
        }

        private void lnkEducationalConsultations_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmConsultationsList(ConsultationCategory.Educational));
        }

        private void lnkCareerList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmCareerList());
        }

        private void lnkTeacherPresenceReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptTeacherPresences());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkSmsWizard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CloseAllChildForms();
            DbContext.BackToMainSession();

            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmSmsWizard());
            DbContext.CloseUnitOfWork();
        }

        private void lnkFrontpageConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowDialogForm(new frmWebsiteConfig());
            DbContext.CloseUnitOfWork();
        }

        private void lnkWebsiteWidgets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmWebsiteWidgetList());
        }

        private void lnkFastBatchSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CloseAllChildForms();
            DbContext.BackToMainSession();

            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmBatchSignupWizard());
            DbContext.CloseUnitOfWork();
        }

        private void lnkWebRegisterList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmWebRegisterList());
        }

        private void lnkSmsRemainingCredit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                long credit = SmsPostMaster.GetRemainingCredit();
                rMessageBox.ShowInformation("اعتبار باقی مانده: {0}", credit.ToString("C0"));
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void lnkRegisterAccuracyReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptRegisterAccuracy());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkWebMediaList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmWebMediaList());
        }

        private void lnkPollList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmPollList());
        }

        private void lnkTeacherPresenceWizard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmTeacherPresenceWizard frm = new frmTeacherPresenceWizard();
            frm.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkOrderList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmOrderList());
        }

        private void lnkPollReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);

            frmSelect frm = new frmSelect(Fakher.Core.DomainModel.Poll.Poll.GetAllPolls(),
                                          new ColumnMapping {Caption = "نام", ObjectProperty = "Name"});
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            Core.DomainModel.Poll.Poll poll = frm.GetSelectedObject<Fakher.Core.DomainModel.Poll.Poll>();
            rptPollChart rpt = new rptPollChart();
            rpt.DataSource = poll;

            frmReportViewer frmReportViewer = new frmReportViewer(rpt);
            frmReportViewer.ShowDialog(this);

            DbContext.CloseUnitOfWork();
        }

        private void lnkExamEnrollmentList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmExamEnrollmentsList());
        }

        private void lnkBuffetProductList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmBuffetProductList());
        }

        private void lnkBuffetSellerList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmBuffetSellerList());
        }

        private void lnkBuffetReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptBuffetStat());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkBuffetSellerDailyReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptBuffetSellerSales());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();

            //            IList<BuffetSeller> sellers = BuffetSeller.GetBuffetSellers();
            //            frmSelect frm = new frmSelect(sellers,
            //                                          new ColumnMapping {Caption = "نام", ObjectProperty = "FarsiFirstName"}
            //                                          , new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "FarsiLastName" });
            //            if (frm.ShowDialog(this) != DialogResult.OK)
            //                return;
            //            BuffetSeller buffetSeller = frm.GetSelectedObject<BuffetSeller>();
            //
            //            rptBuffetSellerSales rpt = new rptBuffetSellerSales {BuffetSeller = buffetSeller};
            //            rpt.DataSource = BuffetSaleItem.GetItems(PersianDate.Today, PersianDate.Today);
            //            frmReportViewer frmViewer = new frmReportViewer(rpt);
            //            frmViewer.ShowDialog(this);
        }

        private void lnkWebEnrollmentManagement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmWebEnrollmentManagement());
        }

        private void lnkSignupReceiptReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptSignupReceipt());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkExamParticipatesExport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmExamParticipatesExport frm = new frmExamParticipatesExport();
            frm.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkExamHoldingSeatLabelReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptFaExamHoldingSeatLabel());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkBuffetSupplyList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmBuffetSupplyList());
        }

        private void lnkTeacherHistoryList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmTeacherHistoryList());
        }

        private void lnkRegisterAnnouncement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmRegisterAnnouncementWizard frm = new frmRegisterAnnouncementWizard();
            frm.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkBannedStudentReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptBannedStudents());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkNextEnrollmentBannedStudentsReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptNextEnrollmentBannedStudents());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkProductReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptProductStat());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkEducationalToolUseStat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptEducationalToolUseStat());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkStudentPeriodResultReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptStudentPeriodResults2());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkToolSupplyList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmEducationalToolSupplyList());
        }

        private void lnkEducationalToolSupplyStat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptEducationalToolSupplyStat());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkBuffetSupplyStatReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptBuffetSupplyStat());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkfrmSmsTemplateSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CloseAllChildForms();
            DbContext.BackToMainSession();

            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmSmsTemplateSetting());
            DbContext.CloseUnitOfWork();
        }

        private void lnkStoreBorrowsReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptStoreBorrows());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkEducationalToolsBorrowsReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptEducationalToolBorrows());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkSecuritySync_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.CurrentEmployee.UserInfo.AccessGroup.RefreshEntity();
            UpdateAccessLinks();
        }

        private void lnkOralExamResultReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptFaOralExamResult());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkPreEnrollmentWizard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CloseAllChildForms();
            DbContext.BackToMainSession();

            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmPreEnrollmentWizard());
            DbContext.CloseUnitOfWork();
        }

        private void lnkEmploymentContractList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmEmploymentContractList());
        }

        private void lnkCalculatePayrollEmployee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowDialogForm(new frmCalculatePayroll(false, true));
            DbContext.CloseUnitOfWork();
        }

        private void lnkEmploymentPayrollReceiptReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters =
                new frmReportParameters(new rptPayrollReceipt() {forEmployee = true});
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkExamAbsentsReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptFaExamAbsents());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkMajorEducationalToolsReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptMajorEducationalTools());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkBuffetSupplyReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmParameters = new frmReportParameters(new rptProductSupply());
            frmParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkStoreEntryInvoice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmStoreSupplyInvoiceDetail());
        }

        private void lnkBuffetEntryInvoice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmBuffetSupplyInvoiceDetail());
        }

        private void lnkEmployeePayrollList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmPayrollList(false, true));
        }

        private void lnkMyPayroll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IList<Payroll> payrolls = Program.CurrentEmployee.Payrolls;
            frmSelect frm = new frmSelect(payrolls,
                                          new ColumnMapping() {Caption = "تاریخ شروع", ObjectProperty = "StartDate"},
                                          new ColumnMapping {Caption = "تاریخ پایان", ObjectProperty = "EndDate"});
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            Payroll payroll = frm.GetSelectedObject<Payroll>();
            PersianDate startDate =
                PersianDate.FromString(AppSetting.GetSetting(WebsiteHandler.EmployeePayrollReceiptShowStartDate));
            PersianDate endDate =
                PersianDate.FromString(AppSetting.GetSetting(WebsiteHandler.EmployeePayrollReceiptShowEndDate));
            PersianDate today = PersianDate.Today;
            if (startDate == null || endDate == null)
                return;
            if (today >= startDate && today <= endDate)
            {
                rptPayrollReceipt rpt = new rptPayrollReceipt();
                rpt.Fill(payroll);
                rpt.DataSource = new[] {payroll};
                frmReportViewer frmViewer = new frmReportViewer(rpt) {CanPrint = false, CanExport = false};
                frmViewer.ShowDialog(this);
            }
            else
            {
                rMessageBox.ShowError("زمان مشاهده فیش حقوق گذشته است. بنابراین امکان مشاهده فیش حقوق وجود ندارد");
                return;
            }
        }

        private void lnkBankAccountList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmBankAccountList());
        }

        private void lnkPayrollSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPayrollSettings frm = new frmPayrollSettings();
            frm.ShowDialog();
        }

        private void lnkFinancialHeadingStatReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptFinancialHeadingStat());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkFuturePaymentsList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmFuturePaymentList());
        }

        private void lnkConsultationSessionList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmConsultationSessionList());
        }

        private void lnkConsultationSessionWizard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmConsultationSessionWizard frmConsultationSessionWizard = new frmConsultationSessionWizard();
            frmConsultationSessionWizard.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkConsultantApplicantsReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptFaConsultationApplicants());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkFuturePaymentsListReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptFuturePaymentsList());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkTeacherPaymentsReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptTeacherPayments());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkFinancialCommitmentsReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptFinancialCommitmentList());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkFinancialCommitmentList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmFinancialCommitmentList());
        }

        private void lnkTopFinancialCommitments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkFinancialCommitmentList_LinkClicked(sender, e);
        }

        private void lnkCertficateList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmReportParameters = new frmReportParameters(new rptCertificateList());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkBranch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmBranchList());
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmParameters = new frmReportParameters(new rptTransitionedStudents());
            frmParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkTransitionPayOff_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            DbContext.OpenUnitOfWork();
            frmReportParameters frmParameters = new frmReportParameters(new rptTransitionedStudentsPayOff());
            frmParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void linkLabelAlalHesabEmployee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmAlalHesabList(false, true));
        }

        private void linkLabelAlalHesabTeacher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmAlalHesabList(true, false));
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters =
                new frmReportParameters(new rptAlalHesab() { forEmployee = false });
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters =
                new frmReportParameters(new rptAlalHesab() { forEmployee = true });
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnkBayganiReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmBayganiNosList frm = new frmBayganiNosList();
            frm.ShowDialog();
        }

        private void lnkTodayRefunds_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowChildForm(new frmRefund());
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            ShowChildForm(new frmTodayChequeList());
        }

        private void linkLabel5_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTeacherPayrollSettings frm = new frmTeacherPayrollSettings();
            frm.ShowDialog();
        }

        //private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    DbContext.OpenUnitOfWork();

        //    frmBlackBoardWizard frm = new frmBlackBoardWizard();
        //    frm.ShowDialog(this);

        //    DbContext.CloseUnitOfWork();
        //}

        //private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    DbContext.OpenUnitOfWork();
        //    ShowChildForm(new frmExerciseList(ExamType.Exercise));
        //}

        //private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    DbContext.OpenUnitOfWork(true);
        //    ShowChildForm(new frmQuestionnaireExerciseList());
        //}

        //private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    DbContext.OpenUnitOfWork();
        //    ShowChildForm(new frmBlackboardLessonList(ExamType.Lesson));
        //}

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptFaExerciseResult(),
                                                                              new rptEnExamResult());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();

            frmEnterExamKeyWizard frm = new frmEnterExamKeyWizard(ExamType.Exercise);
            frm.ShowDialog(this);

            DbContext.CloseUnitOfWork();
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptIDImageLessStudents());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            DbContext.OpenUnitOfWork(true);
            frmReportParameters frmReportParameters = new frmReportParameters(new rptNCImageLessStudents());
            frmReportParameters.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void radDock1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel10_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmReceiptSendingDates());
        }

        private void linkLabel11_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            DbContext.OpenUnitOfWork(true);
            frmSignnupReport frm = new frmSignnupReport();
            frm.ShowDialog(this);
            DbContext.CloseUnitOfWork();


            //DbContext.OpenUnitOfWork(true);
            //frmReportParameters frmReportParameters = new frmReportParameters(new rptSignupReceiptTotal());
            //frmReportParameters.ShowDialog(this);
            //DbContext.CloseUnitOfWork();
        }

        private void lnkAllCheques_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmParameters = new frmReportParameters(new rptAllChequeList());
            frmParameters.ShowDialog(this);
            //frmChequeReport frm = new frmChequeReport();
            //frm.ShowDialog(this);
            DbContext.CloseUnitOfWork();

        }

        private void lnkAllReceipt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            frmReportParameters frmParameters = new frmReportParameters(new rptAllReceiptList());
            frmParameters.ShowDialog(this);
            //frmReceiptReport frm = new frmReceiptReport();
            //frm.ShowDialog(this);
            DbContext.CloseUnitOfWork();
        }

        private void lnklblLevelDetermination_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbContext.OpenUnitOfWork();
            ShowChildForm(new frmLevelDeterminationList());
        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CloseAllChildForms();
            DbContext.BackToMainSession();

            DbContext.OpenUnitOfWork(true);
            ShowDialogForm(new frmReserveLevelDeterminationWizard());
            DbContext.CloseUnitOfWork();
        }
    }
}