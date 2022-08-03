using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;

namespace Fakher.UI.Ministerial
{
    public partial class frmTeacherPayrollSettings : rRadDetailForm
    {
        public frmTeacherPayrollSettings()
        {
            InitializeComponent();

            Fill();
        }

        private void Fill()
        {
            rDatePicker1.Date = PersianDate.FromString(AppSetting.GetSetting(WebsiteHandler.TeacherPayrollReceiptShowStartDate));
            rDatePicker2.Date = PersianDate.FromString(AppSetting.GetSetting(WebsiteHandler.TeacherPayrollReceiptShowEndDate));
        }

        private void Save()
        {
            AppSetting.SetSetting(WebsiteHandler.EmployeePayrollReceiptShowStartDate, rDatePicker1.Date + "");
            AppSetting.SetSetting(WebsiteHandler.EmployeePayrollReceiptShowEndDate, rDatePicker2.Date + "");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Program.StartWaiting();
                Save();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
            finally
            {
                Program.EndWaiting();
            }

            Close();
        }
    }
}
