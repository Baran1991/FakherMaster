using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using Fakher.Core;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Fakher.Reports;
using Fakher.Reports.Career;
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Website.WebRegister
{
    public partial class frmWebRegisterList : rRadForm
    {
        public frmWebRegisterList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "PersonalInfo.FarsiFullname" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام پدر", ObjectProperty = "PersonalInfo.FarsiFatherName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "استان", ObjectProperty = "ContactInfo.Province" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شهر", ObjectProperty = "ContactInfo.City" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "رشته ثبت نامی", ObjectProperty = "Text" });

            FillGrid();
        }

        private void FillGrid()
        {
            List<Core.Website.WebRegister> registers = Fakher.Core.Website.WebRegister.GetWebRegistersQuery(WebRegisterStatus.Completed).ToList();
            rGridView1.DataBind(registers);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Fakher.Core.Website.WebRegister webRegister =
                rGridView1.GetSelectedObject<Fakher.Core.Website.WebRegister>();

            try
            {
                if (!SmsPostMaster.CanSendSms())
                    throw new Exception("اعتبار پیامک به پایان رسیده است.");
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }

            Register register;
            try
            {
                register = webRegister.GenerateRegister();
                register.Student.InternetRegisteration = true;
                //                register.Student.ConfirmEnrollment();
                register.Student.Save();

                if (register.Student.UserInfo.LoginStatus == LoginStatus.Disabled)
                    throw new Exception("ایجاد شناسه کاربری برای این شخص امکان پذیر نیست.");

                if (register.Student.UserInfo.WebLogin)
                    throw new Exception("شناسه کاربری قبلا ایجاد شده است.");

                register.Student.UserInfo.SetEmail(register.Student.ContactInfo.Email);
                register.Student.UserInfo.SetUsername(register.Student.ContactInfo.Email);
                register.Student.UserInfo.SetPassword(register.Student.Code);
                register.Student.UserInfo.ActivateWeb();
                register.Student.UserInfo.Save();

                webRegister.Register = register;
                webRegister.Confirm();
                webRegister.Save();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }

            try
            {
                InternetPostMaster.Send(InternetPostMaster.NoReply, new[] { new MailAddress(register.Student.ContactInfo.Email) }, "شناسه کاربری", register.Student.UserInfo.GetLoginHtmlText(), true, true);
                SmsPostMaster.Send(register.Student.UserInfo.GetLoginSmsText(), Services.NormalizeMobileString(register.Student.ContactInfo.Mobile));
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }

            FillGrid();

            rptRegisterInfo rpt = new rptRegisterInfo();
            rpt.DataSource = new object[] { register };
            frmReportViewer frmReport = new frmReportViewer(rpt) { AutoPrint = true };
            frmReport.ShowDialog(this);
        }
    }
}
