using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.Website;
using rComponents;

namespace Fakher.UI.Website
{
    public partial class frmEnrollmentLicenseList : rRadForm
    {
        public frmEnrollmentLicenseList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نوع مجوز", ObjectProperty = "LicenseTypeText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ شروع", ObjectProperty = "StartDate.ToShortDateString()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "زمان شروع", ObjectProperty = "StartTime" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ پایان", ObjectProperty = "EndDate.ToShortDateString()" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "زمان پایان", ObjectProperty = "EndTime" });

            IList<EnrollmentLicense> licenses = EnrollmentLicense.GetEnrollmentLicenses(Program.CurrentPeriod);
            rGridView1.DataBind(licenses);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            EnrollmentLicense enrollmentLicense = new EnrollmentLicense {EducationalPeriod = Program.CurrentPeriod};
            frmEnrollmentLicenseDetail frm = new frmEnrollmentLicenseDetail(enrollmentLicense);
            if (!frm.ProcessObject())
                return;
            enrollmentLicense.Save();
            rGridView1.Insert(enrollmentLicense);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            EnrollmentLicense enrollmentLicense = rGridView1.GetSelectedObject<EnrollmentLicense>();
            frmEnrollmentLicenseDetail frm = new frmEnrollmentLicenseDetail(enrollmentLicense);
            if (!frm.ProcessObject())
                return;
            enrollmentLicense.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            EnrollmentLicense enrollmentLicense = rGridView1.GetSelectedObject<EnrollmentLicense>();
            enrollmentLicense.Delete();
            rGridView1.RemoveSelectedRow();
        }
    }
}
