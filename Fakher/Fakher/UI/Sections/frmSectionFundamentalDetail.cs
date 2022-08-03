using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Sections
{
    public partial class frmSectionFundamentalDetail : rRadDetailForm
    {
        public frmSectionFundamentalDetail()
        {
            InitializeComponent();
        }

        private void sectionSelector1_SelectedChanged(object sender, EventArgs e)
        {
            if (sectionSelector1.Section == null)
                return;

            rDatePickerStart.Date = sectionSelector1.Section.StartDate;
            rDatePickerFinish.Date = sectionSelector1.Section.FinishDate;
            rTextBox1.Value = sectionSelector1.Section.Capacity;
//            rCheckBox1.Checked = sectionSelector1.Section.WageCalculation;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Section section = sectionSelector1.Section;
            int capacity = rTextBox1.GetValue<int>();

            if (rDatePickerStart.Date == null)
            {
                rMessageBox.ShowError("تاریخ شروع را وارد کنید.");
                return;
            }

            if(rDatePickerFinish.Date == null)
            {
                rMessageBox.ShowError("تاریخ پایان را وارد کنید.");
                return;
            }

            if(capacity <= 0)
            {
                rMessageBox.ShowError("ظرفیت را وارد کنید.");
                return;
            }

//            if(rCheckBox1.Checked)
//            {
//                if (rMessageBox.ShowQuestion("آیا تاریخ شروع و پایان گروه صحیح و درست هستند؟") != DialogResult.Yes)
//                    return;
//            }

            section.StartDate = rDatePickerStart.Date;
            section.FinishDate = rDatePickerFinish.Date;
            section.Capacity = capacity;
//            section.WageCalculation = rCheckBox1.Checked;

            section.Save();
            rMessageBox.ShowInformation("تغییرات با موفقیت ذخیره گردید.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
//            if(rCheckBox1.Checked && IsShowed)
//            {
//                rMessageBox.ShowInformation("برای محاسبه دستمزد مدرس، از صحیح بودن تاریخ شروع و پایان مطمئن شوید.");
//            }
        }
    }
}
