using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.Reports;
using Fakher.UI.Person;
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Educational.Reserves
{
    public partial class frmReserveList : rRadForm
    {
        public frmReserveList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام لیست", ObjectProperty = "Name"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ظرفیت", ObjectProperty = "Capacity"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "رزرو شده", ObjectProperty = "Reserves.Count", AggregateSummary = AggregateSummary.Sum});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ثبت نام شده", ObjectProperty = "RegisteredReservesCount", AggregateSummary = AggregateSummary.Sum });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "باقیمانده", ObjectProperty = "Remainder" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شهریه", ObjectProperty = "TuitionFee", Type = ColumnType.Money });

            rGridView2.Mappings.Add(new ColumnMapping{Caption = "شماره رزرو", ObjectProperty = "Code"});
            rGridView2.Mappings.Add(new ColumnMapping{Caption = "نام", ObjectProperty = "Student.FarsiFirstName"});
            rGridView2.Mappings.Add(new ColumnMapping{Caption = "نام و نام خانوادگی", ObjectProperty = "Student.FarsiLastName"});
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
        }

        private void rGridView1_SelectedItemChanged(object sender, EventArgs e)
        {
            ReserveList reserveList = rGridView1.GetSelectedObject<ReserveList>();
            if(reserveList == null)
                return;
            rGridView2.DataBind(reserveList.Reserves);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            if(majorSelector1.Major == null)
                return;
            ReserveList reserveList = new ReserveList { Major = majorSelector1.Major, Period = Program.CurrentPeriod};
            frmReserveListDetail frm = new frmReserveListDetail(reserveList);
            if(!frm.ProcessObject())
                return;
            reserveList.Save();
            rGridView1.Insert(reserveList);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            ReserveList reserveList = rGridView1.GetSelectedObject<ReserveList>();

            reserveList.RefreshEntity();
            frmReserveListDetail frm = new frmReserveListDetail(reserveList);
            if (!frm.ProcessObject())
                return;
            reserveList.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            ReserveList reserveList = rGridView1.GetSelectedObject<ReserveList>();
            reserveList.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            Reserve reserve = rGridView2.GetSelectedObject<Reserve>();

            reserve.RefreshEntity();
            frmReserveDetail frm = new frmReserveDetail(reserve);
            if(!frm.ProcessObject())
                return;
            reserve.Save();
            rGridView2.UpdateGridView();
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            Reserve reserve = rGridView2.GetSelectedObject<Reserve>();
            if (reserve == null)
                return;

            rptReserveReceipt rpt = new rptReserveReceipt();
            rpt.DataSource = reserve;
            frmReportViewer frmReport = new frmReportViewer(rpt);
            frmReport.ShowDialog(this);
        }

        private void rGridView2_Add(object sender, EventArgs e)
        {
            Reserve reserve = rGridView2.GetSelectedObject<Reserve>();
            if(reserve == null)
            {
                rMessageBox.ShowWarning("یک دانشجو را انتخاب کنید.");
                return;
            }

            reserve.Student.RefreshEntity();
            frmEducationalHistory frm = new frmEducationalHistory(reserve.Student);
            frm.ShowDialog();

            reserve.Student.Save();
            rGridView2.UpdateGridView();
        }

        private void majorSelector1_SelectedChanged(object sender, EventArgs e)
        {
            rGridView1.Clear();
            rGridView2.Clear();
            if (majorSelector1.Major == null)
                return;
            rGridView1.DataBind(ReserveList.GetReserveList(Program.CurrentPeriod, majorSelector1.Major));
        }
    }
}
