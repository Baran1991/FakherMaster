using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core;
using Fakher.Core.DomainModel;
using Fakher.Core.SMS;
using Fakher.Reports;
using Fakher.UI.Educational.Students;
using Fakher.UI.Report;
using NHibernate;
using rComponents;

namespace Fakher.UI.Educational.Requests
{
    public partial class frmAllRequests : rRadForm
    {
        private bool mTotalRequestsLoaded;

        public frmAllRequests()
        {
            InitializeComponent();

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "CreateDateTime" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Student.FarsiFullname" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Student.GetLastRegister().StatusText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت", ObjectProperty = "SubmitTypeText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ به روز رسانی", ObjectProperty = "LastUpdateDate" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "ساعت به روز رسانی", ObjectProperty = "LastUpdateTime" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "کاربر اقدام کننده", ObjectProperty = "Employee.FarsiFullname" });
        }

        private void Fill()
        {
            PersianDate date1 = rDatePicker1.Date;
            PersianDate date2 = rDatePicker2.Date;
            if (date1 == null | date2 == null)
            {
                rMessageBox.ShowError("تاریخ را وارد کنید.");
                return;
            }
            Program.StartWaiting();
            var list = DbContext.Entity<Request>().Where(m => m.Date <= date2 && m.Date >= date1);
            rGridView2.DataBind(list);
            //با تغییر تعریف لیست سرعت لودلیستم به شدت رفت بالا!!
            //List<Request> requests = DbContext.GetAllEntities<Request>().Where(m => m.Date <= date2 && m.Date >= date1).ToList();
            //rGridView2.DataBind(requests);
            Program.EndWaiting();
            mTotalRequestsLoaded = true;
        }
        private void SendSMS(Request request)
        {
            var smsGroup = new SmsGroup();
            String smsText = AppSetting.GetSetting(SmsHandler.RequestTemplate);
            smsText = smsText.Replace("[نام دانشجو]", request.Student.FarsiFirstName);
            smsText = smsText.Replace("[نام خانوادگی دانشجو]", request.Student.FarsiLastName);
            smsText = smsText.Replace("[تاریخ پاسخگویی]", request.LastUpdateDate + "");
            smsText = smsText.Replace("[ساعت پاسخگویی]", request.LastUpdateTime + "");
            smsText = smsText.Replace("[وضعیت]", request.StatusText);

            try
            {
                var tempReceiver = new SmsReceiver { Persons = new List<Core.DomainModel.Person> { request.Student } };
                tempReceiver.LoadNumbers();
                if (tempReceiver.Numbers.Count == 0)
                {
                    rMessageBox.ShowError("گیرنده ({0}) هیچ شماره تلفن معتبری برای ارسال پیامک ندارند.", tempReceiver.Text);
                    return;
                }
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }

            if (string.IsNullOrEmpty(smsText))
            {
                rMessageBox.ShowError("متن پیامک را مشخص کنید.");
                return;
            }


            smsGroup.Text = smsText;
            smsGroup.Smses.Clear();
            smsGroup.Status = SmsGroupStatus.Created;

            var receiver = new SmsReceiver();
            receiver.Persons = new List<Core.DomainModel.Person>();
            var person = request.Student;
            receiver.Persons.Add(person);
            receiver.LoadNumbers();
            foreach (string number in receiver.Numbers)
            {
                Sms sms = smsGroup.CreateSms();
                sms.Number = number;
                smsGroup.AddSms(sms);
            }

            try
            {
                Application.DoEvents();
                SmsPostMaster.Send(smsGroup);
                Application.DoEvents();
                ITransaction transaction = null;

                try
                {
                    transaction = DbContext.BeginTransaction();

                    smsGroup.Status = SmsGroupStatus.Sent;
                    smsGroup.Save();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    rMessageBox.ShowError(ex.Message);
                    return;
                }

                rMessageBox.ShowInformation("بسته پیامک با موفقیت ارسال گردید.");
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
            }
        }

        private void SendEmail(Request request)
        {
            try
            {
                MailAddress emailAddress = request.Student.ContactInfo.EmailAddress;
                if(emailAddress != null)
                    InternetPostMaster.Send(InternetPostMaster.NoReply, new[] {emailAddress},
                                            "پاسخ به درخواست شما", request.GetReplyHtmlText(), true, false);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }


        private void rGridView2_Edit(object sender, EventArgs e)
        {
            Request request = rGridView2.GetSelectedObject<Request>();
            request.RefreshEntity();

            frmRequestDetail frm = new frmRequestDetail(request, true);
            if (!frm.ProcessObject())
                return;

            request.LastUpdateDate = PersianDate.Today;
            request.LastUpdateHour = DateTime.Now.Hour;
            request.LastUpdateMinute = DateTime.Now.Minute;
            if (request.resDate1 == null & !string.IsNullOrEmpty(request.Result))
            {
                request.Employee = Program.CurrentEmployee;
            }
            if (request.resDate2 == null & !string.IsNullOrEmpty(request.Result2))
            {
                request.Employee2 = Program.CurrentEmployee;
            }

            request.Save();
            rGridView2.UpdateGridView();

            if (frm.SendSMS)
                SendSMS(request);

            if (frm.SendEmail)
                SendEmail(request);
        }
        private void rGridView2_Delete(object sender, EventArgs e)
        {
            Request request = rGridView2.GetSelectedObject<Request>();
            request.RefreshEntity();

            rptRequest rpt = new rptRequest();
            rpt.DataSource = new[] { request };

            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog();
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            mTotalRequestsLoaded = false;
            Fill();
        }
    }
}
