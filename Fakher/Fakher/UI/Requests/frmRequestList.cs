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
using Fakher.Core.Sentinel;
using Fakher.Core.SMS;
using Fakher.Reports;
using Fakher.UI.Educational.Students;
using Fakher.UI.Report;
using NHibernate;
using rComponents;

/// <summary>
/// /دیزاین فرم به دلیل اضافه کردن تعداد ها در عنوان ها از کار افتاده
/// </summary>
namespace Fakher.UI.Educational.Requests
{
    public partial class frmRequestList : rRadForm
    {
        private bool mTotalRequestsLoaded;

        public frmRequestList()
        {
            InitializeComponent();
            radPageView1.SelectedPage = radPageViewPage1;
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "CreateDateTime" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Student.FarsiFullname" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Student.GetLastRegister().StatusText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت", ObjectProperty = "SubmitTypeText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ به روز رسانی", ObjectProperty = "LastUpdateDate" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ساعت به روز رسانی", ObjectProperty = "LastUpdateTime" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کاربر اقدام کننده", ObjectProperty = "Employee.FarsiFullname" });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "CreateDateTime" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Student.FarsiFullname" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Student.GetLastRegister().StatusText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت", ObjectProperty = "SubmitTypeText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ به روز رسانی", ObjectProperty = "LastUpdateDate" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "ساعت به روز رسانی", ObjectProperty = "LastUpdateTime" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "کاربر اقدام کننده", ObjectProperty = "Employee.FarsiFullname" });
            
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "CreateDateTime" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Student.FarsiFullname" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Student.GetLastRegister().StatusText" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت", ObjectProperty = "SubmitTypeText" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "تاریخ به روز رسانی", ObjectProperty = "LastUpdateDate" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "ساعت به روز رسانی", ObjectProperty = "LastUpdateTime" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "کاربر اقدام کننده", ObjectProperty = "Employee.FarsiFullname" });

            rGridView4.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "CreateDateTime" });
            rGridView4.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Student.FarsiFullname" });
            rGridView4.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Student.GetLastRegister().StatusText" });
            rGridView4.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView4.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت", ObjectProperty = "SubmitTypeText" });
            rGridView4.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView4.Mappings.Add(new ColumnMapping { Caption = "تاریخ به روز رسانی", ObjectProperty = "LastUpdateDate" });
            rGridView4.Mappings.Add(new ColumnMapping { Caption = "ساعت به روز رسانی", ObjectProperty = "LastUpdateTime" });
            rGridView4.Mappings.Add(new ColumnMapping { Caption = "کاربر اقدام کننده", ObjectProperty = "Employee.FarsiFullname" });


            rGridView5.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "CreateDateTime" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Student.FarsiFullname" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Student.GetLastRegister().StatusText" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت", ObjectProperty = "SubmitTypeText" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "تاریخ به روز رسانی", ObjectProperty = "LastUpdateDate" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "ساعت به روز رسانی", ObjectProperty = "LastUpdateTime" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "کاربر اقدام کننده", ObjectProperty = "Employee.FarsiFullname" });

            rGridView6.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "CreateDateTime" });
            rGridView6.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Student.FarsiFullname" });
            rGridView6.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Student.GetLastRegister().StatusText" });
            rGridView6.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView6.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت", ObjectProperty = "SubmitTypeText" });
            rGridView6.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView6.Mappings.Add(new ColumnMapping { Caption = "تاریخ به روز رسانی", ObjectProperty = "LastUpdateDate" });
            rGridView6.Mappings.Add(new ColumnMapping { Caption = "ساعت به روز رسانی", ObjectProperty = "LastUpdateTime" });
            rGridView6.Mappings.Add(new ColumnMapping { Caption = "کاربر اقدام کننده", ObjectProperty = "Employee.FarsiFullname" });



            rGridView7.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "CreateDateTime" });
            rGridView7.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Student.FarsiFullname" });
            rGridView7.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Student.GetLastRegister().StatusText" });
            rGridView7.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView7.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت", ObjectProperty = "SubmitTypeText" });
            rGridView7.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView7.Mappings.Add(new ColumnMapping { Caption = "تاریخ به روز رسانی", ObjectProperty = "LastUpdateDate" });
            rGridView7.Mappings.Add(new ColumnMapping { Caption = "ساعت به روز رسانی", ObjectProperty = "LastUpdateTime" });
            rGridView7.Mappings.Add(new ColumnMapping { Caption = "کاربر اقدام کننده", ObjectProperty = "Employee.FarsiFullname" });


            rGridView8.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "CreateDateTime" });
            rGridView8.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Student.FarsiFullname" });
            rGridView8.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Student.GetLastRegister().StatusText" });
            rGridView8.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView8.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت", ObjectProperty = "SubmitTypeText" });
            rGridView8.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView8.Mappings.Add(new ColumnMapping { Caption = "تاریخ به روز رسانی", ObjectProperty = "LastUpdateDate" });
            rGridView8.Mappings.Add(new ColumnMapping { Caption = "ساعت به روز رسانی", ObjectProperty = "LastUpdateTime" });
            rGridView8.Mappings.Add(new ColumnMapping { Caption = "کاربر اقدام کننده", ObjectProperty = "Employee.FarsiFullname" });

            rGridView9.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "CreateDateTime" });
            rGridView9.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Student.FarsiFullname" });
            rGridView9.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Student.GetLastRegister().StatusText" });
            rGridView9.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView9.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت", ObjectProperty = "SubmitTypeText" });
            rGridView9.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView9.Mappings.Add(new ColumnMapping { Caption = "تاریخ به روز رسانی", ObjectProperty = "LastUpdateDate" });
            rGridView9.Mappings.Add(new ColumnMapping { Caption = "ساعت به روز رسانی", ObjectProperty = "LastUpdateTime" });
            rGridView9.Mappings.Add(new ColumnMapping { Caption = "کاربر اقدام کننده", ObjectProperty = "Employee.FarsiFullname" });

            rGridView10.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "CreateDateTime" });
            rGridView10.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Student.FarsiFullname" });
            rGridView10.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Student.GetLastRegister().StatusText" });
            rGridView10.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView10.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت", ObjectProperty = "SubmitTypeText" });
            rGridView10.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView10.Mappings.Add(new ColumnMapping { Caption = "تاریخ به روز رسانی", ObjectProperty = "LastUpdateDate" });
            rGridView10.Mappings.Add(new ColumnMapping { Caption = "ساعت به روز رسانی", ObjectProperty = "LastUpdateTime" });
            rGridView10.Mappings.Add(new ColumnMapping { Caption = "کاربر اقدام کننده", ObjectProperty = "Employee.FarsiFullname" });


            rGridView11.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "CreateDateTime" });
            rGridView11.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Student.FarsiFullname" });
            rGridView11.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Student.GetLastRegister().StatusText" });
            rGridView11.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView11.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت", ObjectProperty = "SubmitTypeText" });
            rGridView11.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView11.Mappings.Add(new ColumnMapping { Caption = "تاریخ به روز رسانی", ObjectProperty = "LastUpdateDate" });
            rGridView11.Mappings.Add(new ColumnMapping { Caption = "ساعت به روز رسانی", ObjectProperty = "LastUpdateTime" });
            rGridView11.Mappings.Add(new ColumnMapping { Caption = "کاربر اقدام کننده", ObjectProperty = "Employee.FarsiFullname" });

            rGridView12.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "CreateDateTime" });
            rGridView12.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Student.FarsiFullname" });
            rGridView12.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Student.GetLastRegister().StatusText" });
            rGridView12.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView12.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت", ObjectProperty = "SubmitTypeText" });
            rGridView12.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView12.Mappings.Add(new ColumnMapping { Caption = "تاریخ به روز رسانی", ObjectProperty = "LastUpdateDate" });
            rGridView12.Mappings.Add(new ColumnMapping { Caption = "ساعت به روز رسانی", ObjectProperty = "LastUpdateTime" });
            rGridView12.Mappings.Add(new ColumnMapping { Caption = "کاربر اقدام کننده", ObjectProperty = "Employee.FarsiFullname" });

            rGridView13.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "CreateDateTime" });
            rGridView13.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Student.FarsiFullname" });
            rGridView13.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Student.GetLastRegister().StatusText" });
            rGridView13.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView13.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت", ObjectProperty = "SubmitTypeText" });
            rGridView13.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView13.Mappings.Add(new ColumnMapping { Caption = "تاریخ به روز رسانی", ObjectProperty = "LastUpdateDate" });
            rGridView13.Mappings.Add(new ColumnMapping { Caption = "ساعت به روز رسانی", ObjectProperty = "LastUpdateTime" });
            rGridView13.Mappings.Add(new ColumnMapping { Caption = "کاربر اقدام کننده", ObjectProperty = "Employee.FarsiFullname" });


            rGridView14.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "CreateDateTime" });
            rGridView14.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Student.FarsiFullname" });
            rGridView14.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Student.GetLastRegister().StatusText" });
            rGridView14.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Title" });
            rGridView14.Mappings.Add(new ColumnMapping { Caption = "نوع ثبت", ObjectProperty = "SubmitTypeText" });
            rGridView14.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView14.Mappings.Add(new ColumnMapping { Caption = "تاریخ به روز رسانی", ObjectProperty = "LastUpdateDate" });
            rGridView14.Mappings.Add(new ColumnMapping { Caption = "ساعت به روز رسانی", ObjectProperty = "LastUpdateTime" });
            rGridView14.Mappings.Add(new ColumnMapping { Caption = "کاربر اقدام کننده", ObjectProperty = "Employee.FarsiFullname" });
            rGridView1.DataBind(Request.GetRequestsByStatus(RequestStatus.Waiting));
            rGridView3.DataBind(Request.GetRequestsByStatus(RequestStatus.InRevise));
            rGridView4.DataBind(Request.GetRequestsByStatus(RequestStatus.ReferrToTraining));
            rGridView5.DataBind(Request.GetRequestsByStatus(RequestStatus.ReferrToLeave));
            rGridView6.DataBind(Request.GetRequestsByStatus(RequestStatus.ReferrToExam));
            rGridView7.DataBind(Request.GetRequestsByStatus(RequestStatus.ReferrToInterview));
            rGridView8.DataBind(Request.GetRequestsByStatus(RequestStatus.ReferrToTr));
            rGridView9.DataBind(Request.GetRequestsByStatus(RequestStatus.ReferrToFinansial));
            rGridView10.DataBind(Request.GetRequestsByStatus(RequestStatus.ReferrToCertificate));
            rGridView11.DataBind(Request.GetRequestsByStatus(RequestStatus.ReferrToPublishing));
            rGridView12.DataBind(Request.GetRequestsByStatus(RequestStatus.ReferrToTeachers));
            rGridView13.DataBind(Request.GetRequestsByStatus(RequestStatus.ReferrToStaff));
            rGridView14.DataBind(Request.GetRequestsByStatus(RequestStatus.ReferrToConsultant));

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

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Request request = rGridView1.GetSelectedObject<Request>();
            request.RefreshEntity();
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.notRepliedRequests);
                frmRequestDetail frm = new frmRequestDetail(request, true);

                if (!frm.ProcessObject())
                    return;
                if (request.resDate1 == null & !string.IsNullOrEmpty(request.Result))
                {
                    request.resDate1 = PersianDate.Today;
                    request.resHour1 = DateTime.Now.Hour;
                    request.resMinute1 = DateTime.Now.Minute;
                    request.Employee = Program.CurrentEmployee;
                }
                if (request.resDate2 == null & !string.IsNullOrEmpty(request.Result2))
                {
                    request.resDate2 = PersianDate.Today;
                    request.resHour2 = DateTime.Now.Hour;
                    request.resMinute2 = DateTime.Now.Minute;
                    request.Employee2 = Program.CurrentEmployee;
                }

                //request.LastUpdateDate = PersianDate.Today;
                //request.LastUpdateHour = DateTime.Now.Hour;
                //request.LastUpdateMinute = DateTime.Now.Minute;


                request.Save();
                rGridView2.UpdateGridView();

                if (frm.SendSMS)
                    SendSMS(request);

                if (frm.SendEmail)
                    SendEmail(request);
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
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.InRevise);
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
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void rGridView3_Edit(object sender, EventArgs e)
        {
            Request request = rGridView3.GetSelectedObject<Request>();
            request.RefreshEntity();
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.InRevise);
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
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
        private void rGridView4_Edit(object sender, EventArgs e)
        {
            Request request = rGridView4.GetSelectedObject<Request>();
            request.RefreshEntity();
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.ReferrToTraining);
                frmRequestDetail frm = new frmRequestDetail(request, true);

            if (!frm.ProcessObject())
                return;
            if (request.resDate1 == null & !string.IsNullOrEmpty(request.Result))
            {
                request.resDate1 = PersianDate.Today;
                request.resHour1 = DateTime.Now.Hour;
                request.resMinute1 = DateTime.Now.Minute;
                request.Employee = Program.CurrentEmployee;
            }
            if (request.resDate2 == null & !string.IsNullOrEmpty(request.Result2))
            {
                request.resDate2 = PersianDate.Today;
                request.resHour2 = DateTime.Now.Hour;
                request.resMinute2 = DateTime.Now.Minute;
                request.Employee2 = Program.CurrentEmployee;
            }

            //request.LastUpdateDate = PersianDate.Today;
            //request.LastUpdateHour = DateTime.Now.Hour;
            //request.LastUpdateMinute = DateTime.Now.Minute;


            request.Save();
            rGridView2.UpdateGridView();

            if (frm.SendSMS)
                SendSMS(request);

            if (frm.SendEmail)
                SendEmail(request);
        }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
    }
        private void rGridView5_Edit(object sender, EventArgs e)
        {
            Request request = rGridView5.GetSelectedObject<Request>();
            request.RefreshEntity();
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.ReferrToLeave);
                frmRequestDetail frm = new frmRequestDetail(request, true);

                if (!frm.ProcessObject())
                    return;
                if (request.resDate1 == null & !string.IsNullOrEmpty(request.Result))
                {
                    request.resDate1 = PersianDate.Today;
                    request.resHour1 = DateTime.Now.Hour;
                    request.resMinute1 = DateTime.Now.Minute;
                    request.Employee = Program.CurrentEmployee;
                }
                if (request.resDate2 == null & !string.IsNullOrEmpty(request.Result2))
                {
                    request.resDate2 = PersianDate.Today;
                    request.resHour2 = DateTime.Now.Hour;
                    request.resMinute2 = DateTime.Now.Minute;
                    request.Employee2 = Program.CurrentEmployee;
                }

                //request.LastUpdateDate = PersianDate.Today;
                //request.LastUpdateHour = DateTime.Now.Hour;
                //request.LastUpdateMinute = DateTime.Now.Minute;


                request.Save();
                rGridView2.UpdateGridView();

                if (frm.SendSMS)
                    SendSMS(request);

                if (frm.SendEmail)
                    SendEmail(request);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
        private void rGridView6_Edit(object sender, EventArgs e)
        {
            Request request = rGridView6.GetSelectedObject<Request>();
            request.RefreshEntity();
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.ReferrToExam);
                frmRequestDetail frm = new frmRequestDetail(request, true);

                if (!frm.ProcessObject())
                    return;
                if (request.resDate1 == null & !string.IsNullOrEmpty(request.Result))
                {
                    request.resDate1 = PersianDate.Today;
                    request.resHour1 = DateTime.Now.Hour;
                    request.resMinute1 = DateTime.Now.Minute;
                    request.Employee = Program.CurrentEmployee;
                }
                if (request.resDate2 == null & !string.IsNullOrEmpty(request.Result2))
                {
                    request.resDate2 = PersianDate.Today;
                    request.resHour2 = DateTime.Now.Hour;
                    request.resMinute2 = DateTime.Now.Minute;
                    request.Employee2 = Program.CurrentEmployee;
                }

                //request.LastUpdateDate = PersianDate.Today;
                //request.LastUpdateHour = DateTime.Now.Hour;
                //request.LastUpdateMinute = DateTime.Now.Minute;


                request.Save();
                rGridView2.UpdateGridView();

                if (frm.SendSMS)
                    SendSMS(request);

                if (frm.SendEmail)
                    SendEmail(request);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
        private void rGridView7_Edit(object sender, EventArgs e)
        {
            Request request = rGridView7.GetSelectedObject<Request>();
            request.RefreshEntity();
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.ReferrToInterview);
                frmRequestDetail frm = new frmRequestDetail(request, true);

                if (!frm.ProcessObject())
                    return;
                if (request.resDate1 == null & !string.IsNullOrEmpty(request.Result))
                {
                    request.resDate1 = PersianDate.Today;
                    request.resHour1 = DateTime.Now.Hour;
                    request.resMinute1 = DateTime.Now.Minute;
                    request.Employee = Program.CurrentEmployee;
                }
                if (request.resDate2 == null & !string.IsNullOrEmpty(request.Result2))
                {
                    request.resDate2 = PersianDate.Today;
                    request.resHour2 = DateTime.Now.Hour;
                    request.resMinute2 = DateTime.Now.Minute;
                    request.Employee2 = Program.CurrentEmployee;
                }

                //request.LastUpdateDate = PersianDate.Today;
                //request.LastUpdateHour = DateTime.Now.Hour;
                //request.LastUpdateMinute = DateTime.Now.Minute;


                request.Save();
                rGridView2.UpdateGridView();

                if (frm.SendSMS)
                    SendSMS(request);

                if (frm.SendEmail)
                    SendEmail(request);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
        private void rGridView8_Edit(object sender, EventArgs e)
        {
            Request request = rGridView8.GetSelectedObject<Request>();
            request.RefreshEntity();
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.ReferrToTr);
                frmRequestDetail frm = new frmRequestDetail(request, true);

            if (!frm.ProcessObject())
                return;
            if (request.resDate1 == null & !string.IsNullOrEmpty(request.Result))
            {
                request.resDate1 = PersianDate.Today;
                request.resHour1 = DateTime.Now.Hour;
                request.resMinute1 = DateTime.Now.Minute;
                request.Employee = Program.CurrentEmployee;
            }
            if (request.resDate2 == null & !string.IsNullOrEmpty(request.Result2))
            {
                request.resDate2 = PersianDate.Today;
                request.resHour2 = DateTime.Now.Hour;
                request.resMinute2 = DateTime.Now.Minute;
                request.Employee2 = Program.CurrentEmployee;
            }

            //request.LastUpdateDate = PersianDate.Today;
            //request.LastUpdateHour = DateTime.Now.Hour;
            //request.LastUpdateMinute = DateTime.Now.Minute;


            request.Save();
            rGridView2.UpdateGridView();

            if (frm.SendSMS)
                SendSMS(request);

            if (frm.SendEmail)
                SendEmail(request);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
        private void rGridView9_Edit(object sender, EventArgs e)
        {
            Request request = rGridView9.GetSelectedObject<Request>();
            request.RefreshEntity();
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.ReferrToFinansial);
                frmRequestDetail frm = new frmRequestDetail(request, true);

            if (!frm.ProcessObject())
                return;
            if (request.resDate1 == null & !string.IsNullOrEmpty(request.Result))
            {
                request.resDate1 = PersianDate.Today;
                request.resHour1 = DateTime.Now.Hour;
                request.resMinute1 = DateTime.Now.Minute;
                request.Employee = Program.CurrentEmployee;
            }
            if (request.resDate2 == null & !string.IsNullOrEmpty(request.Result2))
            {
                request.resDate2 = PersianDate.Today;
                request.resHour2 = DateTime.Now.Hour;
                request.resMinute2 = DateTime.Now.Minute;
                request.Employee2 = Program.CurrentEmployee;
            }

            //request.LastUpdateDate = PersianDate.Today;
            //request.LastUpdateHour = DateTime.Now.Hour;
            //request.LastUpdateMinute = DateTime.Now.Minute;


            request.Save();
            rGridView2.UpdateGridView();

            if (frm.SendSMS)
                SendSMS(request);

            if (frm.SendEmail)
                SendEmail(request);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
        private void rGridView10_Edit(object sender, EventArgs e)
        {
            Request request = rGridView10.GetSelectedObject<Request>();
            request.RefreshEntity();
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.ReferrToCertificate);
                frmRequestDetail frm = new frmRequestDetail(request, true);

            if (!frm.ProcessObject())
                return;
            if (request.resDate1 == null & !string.IsNullOrEmpty(request.Result))
            {
                request.resDate1 = PersianDate.Today;
                request.resHour1 = DateTime.Now.Hour;
                request.resMinute1 = DateTime.Now.Minute;
                request.Employee = Program.CurrentEmployee;
            }
            if (request.resDate2 == null & !string.IsNullOrEmpty(request.Result2))
            {
                request.resDate2 = PersianDate.Today;
                request.resHour2 = DateTime.Now.Hour;
                request.resMinute2 = DateTime.Now.Minute;
                request.Employee2 = Program.CurrentEmployee;
            }

            //request.LastUpdateDate = PersianDate.Today;
            //request.LastUpdateHour = DateTime.Now.Hour;
            //request.LastUpdateMinute = DateTime.Now.Minute;


            request.Save();
            rGridView2.UpdateGridView();

            if (frm.SendSMS)
                SendSMS(request);

            if (frm.SendEmail)
                SendEmail(request);
        }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
        private void rGridView11_Edit(object sender, EventArgs e)
        {
            Request request = rGridView11.GetSelectedObject<Request>();
            request.RefreshEntity();
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.ReferrToPublishing);
                frmRequestDetail frm = new frmRequestDetail(request, true);

            if (!frm.ProcessObject())
                return;
            if (request.resDate1 == null & !string.IsNullOrEmpty(request.Result))
            {
                request.resDate1 = PersianDate.Today;
                request.resHour1 = DateTime.Now.Hour;
                request.resMinute1 = DateTime.Now.Minute;
                request.Employee = Program.CurrentEmployee;
            }
            if (request.resDate2 == null & !string.IsNullOrEmpty(request.Result2))
            {
                request.resDate2 = PersianDate.Today;
                request.resHour2 = DateTime.Now.Hour;
                request.resMinute2 = DateTime.Now.Minute;
                request.Employee2 = Program.CurrentEmployee;
            }

            //request.LastUpdateDate = PersianDate.Today;
            //request.LastUpdateHour = DateTime.Now.Hour;
            //request.LastUpdateMinute = DateTime.Now.Minute;


            request.Save();
            rGridView2.UpdateGridView();

            if (frm.SendSMS)
                SendSMS(request);

            if (frm.SendEmail)
                SendEmail(request);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
        private void rGridView12_Edit(object sender, EventArgs e)
        {
            Request request = rGridView12.GetSelectedObject<Request>();
            request.RefreshEntity();
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.ReferrToTeachers);
                frmRequestDetail frm = new frmRequestDetail(request, true);

            if (!frm.ProcessObject())
                return;
            if (request.resDate1 == null & !string.IsNullOrEmpty(request.Result))
            {
                request.resDate1 = PersianDate.Today;
                request.resHour1 = DateTime.Now.Hour;
                request.resMinute1 = DateTime.Now.Minute;
                request.Employee = Program.CurrentEmployee;
            }
            if (request.resDate2 == null & !string.IsNullOrEmpty(request.Result2))
            {
                request.resDate2 = PersianDate.Today;
                request.resHour2 = DateTime.Now.Hour;
                request.resMinute2 = DateTime.Now.Minute;
                request.Employee2 = Program.CurrentEmployee;
            }

            //request.LastUpdateDate = PersianDate.Today;
            //request.LastUpdateHour = DateTime.Now.Hour;
            //request.LastUpdateMinute = DateTime.Now.Minute;


            request.Save();
            rGridView2.UpdateGridView();

            if (frm.SendSMS)
                SendSMS(request);

            if (frm.SendEmail)
                SendEmail(request);
        }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
        private void rGridView13_Edit(object sender, EventArgs e)
        {
            Request request = rGridView13.GetSelectedObject<Request>();
            request.RefreshEntity();
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.ReferrToStaff);
                frmRequestDetail frm = new frmRequestDetail(request, true);

            if (!frm.ProcessObject())
                return;
            if (request.resDate1 == null & !string.IsNullOrEmpty(request.Result))
            {
                request.resDate1 = PersianDate.Today;
                request.resHour1 = DateTime.Now.Hour;
                request.resMinute1 = DateTime.Now.Minute;
                request.Employee = Program.CurrentEmployee;
            }
            if (request.resDate2 == null & !string.IsNullOrEmpty(request.Result2))
            {
                request.resDate2 = PersianDate.Today;
                request.resHour2 = DateTime.Now.Hour;
                request.resMinute2 = DateTime.Now.Minute;
                request.Employee2 = Program.CurrentEmployee;
            }

            //request.LastUpdateDate = PersianDate.Today;
            //request.LastUpdateHour = DateTime.Now.Hour;
            //request.LastUpdateMinute = DateTime.Now.Minute;


            request.Save();
            rGridView2.UpdateGridView();

            if (frm.SendSMS)
                SendSMS(request);

            if (frm.SendEmail)
                SendEmail(request);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
        private void rGridView14_Edit(object sender, EventArgs e)
        {
            Request request = rGridView14.GetSelectedObject<Request>();
            request.RefreshEntity();
            try
            {
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.ReferrToConsultant);
                frmRequestDetail frm = new frmRequestDetail(request, true);

            if (!frm.ProcessObject())
                return;
            if (request.resDate1 == null & !string.IsNullOrEmpty(request.Result))
            {
                request.resDate1 = PersianDate.Today;
                request.resHour1 = DateTime.Now.Hour;
                request.resMinute1 = DateTime.Now.Minute;
                request.Employee = Program.CurrentEmployee;
            }
            if (request.resDate2 == null & !string.IsNullOrEmpty(request.Result2))
            {
                request.resDate2 = PersianDate.Today;
                request.resHour2 = DateTime.Now.Hour;
                request.resMinute2 = DateTime.Now.Minute;
                request.Employee2 = Program.CurrentEmployee;
            }

            //request.LastUpdateDate = PersianDate.Today;
            //request.LastUpdateHour = DateTime.Now.Hour;
            //request.LastUpdateMinute = DateTime.Now.Minute;


            request.Save();
            rGridView2.UpdateGridView();

            if (frm.SendSMS)
                SendSMS(request);

            if (frm.SendEmail)
                SendEmail(request);
        }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
}

        private void radPageView1_SelectedPageChanged(object sender, EventArgs e)
        {
            //if(radPageView1.SelectedPage == radPageViewPage2 && !mTotalRequestsLoaded)
            //{
            //    try
            //    {
            //        PersianDate date1 = rDatePicker1.Date;
            //        PersianDate date2 = rDatePicker2.Date;
            //        if (date1 == null | date2 == null)
            //        {
            //            rMessageBox.ShowError("تاریخ را وارد کنید.");
            //            return;
            //        }
            //        Program.StartWaiting();
            //List<Request> requests = DbContext.GetAllEntities<Request>().ToList();
            //        rGridView2.DataBind(requests);
            mTotalRequestsLoaded = true;
            //    }
            //    finally 
            //    {
            //        Program.EndWaiting();
            //    }
            //}
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Request request = rGridView1.GetSelectedObject<Request>();
            request.RefreshEntity();

            rptRequest rpt = new rptRequest();
            rpt.DataSource = new[] {request};

            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog();
        }

        private void rGridView3_Delete(object sender, EventArgs e)
        {
            Request request = rGridView3.GetSelectedObject<Request>();
            request.RefreshEntity();

            rptRequest rpt = new rptRequest();
            rpt.DataSource = new[] { request };

            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog();
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
        private void rGridView4_Delete(object sender, EventArgs e)
        {
            Request request = rGridView1.GetSelectedObject<Request>();
            request.RefreshEntity();

            rptRequest rpt = new rptRequest();
            rpt.DataSource = new[] { request };

            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog();
        }

        private void rGridView5_Delete(object sender, EventArgs e)
        {
            Request request = rGridView3.GetSelectedObject<Request>();
            request.RefreshEntity();

            rptRequest rpt = new rptRequest();
            rpt.DataSource = new[] { request };

            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog();
        }

        private void rGridView6_Delete(object sender, EventArgs e)
        {
            Request request = rGridView6.GetSelectedObject<Request>();
            request.RefreshEntity();

            rptRequest rpt = new rptRequest();
            rpt.DataSource = new[] { request };

            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog();
        }
        private void rGridView7_Delete(object sender, EventArgs e)
        {
            Request request = rGridView1.GetSelectedObject<Request>();
            request.RefreshEntity();

            rptRequest rpt = new rptRequest();
            rpt.DataSource = new[] { request };

            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog();
        }

        private void rGridView8_Delete(object sender, EventArgs e)
        {
            Request request = rGridView3.GetSelectedObject<Request>();
            request.RefreshEntity();

            rptRequest rpt = new rptRequest();
            rpt.DataSource = new[] { request };

            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog();
        }

        private void rGridView9_Delete(object sender, EventArgs e)
        {
            Request request = rGridView9.GetSelectedObject<Request>();
            request.RefreshEntity();

            rptRequest rpt = new rptRequest();
            rpt.DataSource = new[] { request };

            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog();
        }
        private void rGridView10_Delete(object sender, EventArgs e)
        {
            Request request = rGridView1.GetSelectedObject<Request>();
            request.RefreshEntity();

            rptRequest rpt = new rptRequest();
            rpt.DataSource = new[] { request };

            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog();
        }

        private void rGridView11_Delete(object sender, EventArgs e)
        {
            Request request = rGridView3.GetSelectedObject<Request>();
            request.RefreshEntity();

            rptRequest rpt = new rptRequest();
            rpt.DataSource = new[] { request };

            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog();
        }

        private void rGridView12_Delete(object sender, EventArgs e)
        {
            Request request = rGridView12.GetSelectedObject<Request>();
            request.RefreshEntity();

            rptRequest rpt = new rptRequest();
            rpt.DataSource = new[] { request };

            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog();
        }
        private void rGridView13_Delete(object sender, EventArgs e)
        {
            Request request = rGridView1.GetSelectedObject<Request>();
            request.RefreshEntity();

            rptRequest rpt = new rptRequest();
            rpt.DataSource = new[] { request };

            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog();
        }

        private void rGridView14_Delete(object sender, EventArgs e)
        {
            Request request = rGridView3.GetSelectedObject<Request>();
            request.RefreshEntity();

            rptRequest rpt = new rptRequest();
            rpt.DataSource = new[] { request };

            frmReportViewer frm = new frmReportViewer(rpt);
            frm.ShowDialog();
        }

        private void btnDefaultAns_Click(object sender, EventArgs e)
        {
            frmRequestDefaultAns frm = new frmRequestDefaultAns();
            frm.ShowDialog();
        }

        private void BtnAllRequest_Click(object sender, EventArgs e)
        {
            frmAllRequests frm = new frmAllRequests();
            frm.ShowDialog();
        }
    }
}
