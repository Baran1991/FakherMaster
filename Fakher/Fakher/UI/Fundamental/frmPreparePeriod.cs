using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Fundamental
{
    public partial class frmPreparePeriod : rRadForm
    {
        public frmPreparePeriod()
        {
            InitializeComponent();
            Program.CurrentPeriod.Progress += new EventHandler<ProgressEventArgs>(CurrentPeriod_Progress);

            rGridComboBoxDepartment.Columns.Add("نام" , "نام", "Name");
            rGridComboBoxPeriod.Columns.Add("نام" , "نام", "Name");

            rGridComboBoxDepartment.DataSource = DbContext.GetAllEntities<Department>();
            rGridComboBoxDepartment.Value = Program.CurrentDepartment;
        }

        protected void CurrentPeriod_Progress(object sender, ProgressEventArgs e)
        {
            progressBar1.Maximum = e.Maximum;
            rLblMessage.Text = e.Text;
            if(e.Value < progressBar1.Maximum)
                progressBar1.Value = e.Value;
            Application.DoEvents();
        }

        private void rGridComboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            Department department = rGridComboBoxDepartment.GetValue<Department>();
            if(department == null)
                return;
            rGridComboBoxPeriod.DataSource = department.EducationalPeriods;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            EducationalPeriod period = rGridComboBoxPeriod.GetValue<EducationalPeriod>();
            if(period == null)
            {
                rMessageBox.ShowError("ترم مرجع را انتخاب کنید.");
                return;
            }
            if(period.Id == Program.CurrentPeriod.Id)
            {
                rMessageBox.ShowError("ترم مرجع نباید با ترم جاری سیستم یکسان باشد.");
                return;
            }

            try
            {
                rMessageBox.ShowInformation("انجام این عملیات ممکن است کمی زمانبر باشد. لطفا صبور باشید.");
                Application.UseWaitCursor = true;
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                period.RefreshEntity();
                Program.CurrentPeriod.RefreshEntity();

                Program.CurrentPeriod.PrepareFrom(period);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
            finally
            {
                Application.UseWaitCursor = false;
                Cursor = Cursors.Default;
                Application.DoEvents();
            }

            rMessageBox.ShowInformation("عملیات با موفقیت انجام شد.");
            Close();
        }
    }
}
