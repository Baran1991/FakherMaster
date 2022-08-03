using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Reports;
using Fakher.UI.Person;
using Fakher.UI.Report;
using rComponents;

namespace Fakher.UI.Educational.Reserves
{
    public partial class frmLevelDeterminationList : rRadForm
    {
        public frmLevelDeterminationList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام لیست", ObjectProperty = "Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ظرفیت", ObjectProperty = "Capacity" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "رزرو شده", ObjectProperty = "Reserves.Count", AggregateSummary = AggregateSummary.Sum });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ثبت نام شده", ObjectProperty = "RegisteredReservesCount", AggregateSummary = AggregateSummary.Sum });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "باقیمانده", ObjectProperty = "Remainder" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شهریه", ObjectProperty = "TuitionFee", Type = ColumnType.Money });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شماره رزرو", ObjectProperty = "Code" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Student.FarsiFirstName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = " نام خانوادگی", ObjectProperty = "Student.FarsiLastName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
        }
        private void rGridView1_SelectedItemChanged(object sender, EventArgs e)
        {
            ReserveList reserveList = rGridView1.GetSelectedObject<ReserveList>();
            if (reserveList == null)
                return;
            rGridView2.DataBind(reserveList.Reserves);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            if (majorSelector1.Major == null)
                return;
            ReserveList reserveList = new ReserveList { Major = majorSelector1.Major, Period = Program.CurrentPeriod, reserveType = ReserveList.ReserveType.LevelDetermination };
            frmLevelDeterminationListDetail frm = new frmLevelDeterminationListDetail(reserveList);
            if (!frm.ProcessObject())
                return;
            string rules = 
                " \n\n                                                                               مقررات تعیین سطح  \n" +
                "ساعت درج شده برای مصاحبه شما قطعی نیست و امکان تاخیر در وقت وجود دارد .\n"+
                "پس از انجام تعیین سطح،شما می توانید در صورتی که از سطحی که برای آن مناسب تشخیص داده شده اید ،راضی نباشید، مجددا در تعیین سطح دیگری به صورت رایگان شرکت نمایید . \n" +
                "لطفا پس از تعیین سطح، با مراجعه به آموزش ، کتاب ها و منابع سطح مربوط به خود را ملاحظه فرمایید .\n" +
                "درصورت ثبت نام،هزینه پرداخت شده برای تعیین سطح، جز شهریه ی شما محسوب خواهد شد .\n" +
                "تعیین سطح شونده می تواند قبل از ثبت نام در کلاس،از کلاس مربوطه بازدید نماید .\n" +
                "پس از تعیین سطح و ثبت نام ،تا زمانی که دو ترم فاصله تحصیلی ایجاد نشده باشد ، امکان تعیین سطح مجدد وجود ندارد .\n" +
                "تعیین سطح شونده تا قبل از شروع ترم می تواند برای شرکت مجدد در تعیین سطح به صورت رایگان اقدام نماید . پس از شروع ترم امکان تعیین سطح مجدد وجود نخواهد داشت . \n\n\n" +
                "______________________________________________________________________________________\n\n\n" +
                "                                                                                    نتیجه تعیین سطح  \n" +
                "از متقاضی فوق تعیین سطح به عمل آمد ، ارزیابی ایشان سطح    ...... دوره .......... می باشد .\n" +
                "نام تعیین سطح کننده                                  تاریخ                                            امضا\n\n\n";

            reserveList.RecieptNote = rules;

            reserveList.Save();
            rGridView1.Insert(reserveList);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            ReserveList reserveList = rGridView1.GetSelectedObject<ReserveList>();

            reserveList.RefreshEntity();
            frmLevelDeterminationListDetail frm = new frmLevelDeterminationListDetail(reserveList);
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
            frmLevelDeterminationDetail frm = new frmLevelDeterminationDetail(reserve);
            if (!frm.ProcessObject())
                return;
            reserve.Save();
            rGridView2.UpdateGridView();
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            Reserve reserve = rGridView2.GetSelectedObject<Reserve>();
            if (reserve == null)
                return;
            rptLevelDeterminationReceipt rpt = new rptLevelDeterminationReceipt();
            rpt.DataSource = reserve;
            frmReportViewer frmReport = new frmReportViewer(rpt);
            frmReport.ShowDialog(this);
        }

        private void rGridView2_Add(object sender, EventArgs e)
        {
            Reserve reserve = rGridView2.GetSelectedObject<Reserve>();
            if (reserve == null)
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
            rGridView1.DataBind(ReserveList.GetReserveListByType(Program.CurrentPeriod, majorSelector1.Major, ReserveList.ReserveType.LevelDetermination));

        }
    }
}
