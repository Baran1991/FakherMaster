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
using Fakher.Reports;
using Fakher.UI.Report;
using rComponents;
using Message = Fakher.Core.DomainModel.Message;
using SortOrder = rComponents.SortOrder;

namespace Fakher.UI.Exam
{
    public partial class frmExamRequestList : rRadForm
    {
        public frmExamRequestList()
        {
            InitializeComponent();

            radPageView1.SelectedPage = radPageViewPage1;
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "Date", SortOrder = SortOrder.Ascending });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ آزمون", ObjectProperty = "ExamDate.ToShortDateString()"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "مدرس", ObjectProperty = "Teacher.FarsiFullname" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "دوره/رشته", ObjectProperty = "Major" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "Lesson" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کلاس/گروه", ObjectProperty = "Section" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "زمان شروع", ObjectProperty = "StartTime"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "زمان پایان", ObjectProperty = "EndTime" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تعداد شرکت کننده", ObjectProperty = "ParticipateCount" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView1.CustomButtons.Add(new rGridViewButton{Text = "چــاپ", VisibleOnSelect = true});

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "Date", SortOrder = SortOrder.Ascending });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ آزمون", ObjectProperty = "ExamDate.ToShortDateString()", SortOrder = SortOrder.Ascending });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "مدرس", ObjectProperty = "Teacher.FarsiFullname" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "دوره/رشته", ObjectProperty = "Major" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "Lesson" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "کلاس/گروه", ObjectProperty = "Section" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "زمان شروع", ObjectProperty = "StartTime"});
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "زمان پایان", ObjectProperty = "EndTime" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تعداد شرکت کننده", ObjectProperty = "ParticipateCount" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView2.CustomButtons.Add(new rGridViewButton { Text = "چــاپ", VisibleOnSelect = true });

            rGridView3.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "Date", SortOrder = SortOrder.Ascending });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "تاریخ آزمون", ObjectProperty = "ExamDate.ToShortDateString()", SortOrder = SortOrder.Ascending });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "مدرس", ObjectProperty = "Teacher.FarsiFullname" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "دوره/رشته", ObjectProperty = "Major" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "Lesson" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "کلاس/گروه", ObjectProperty = "Section" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "زمان شروع", ObjectProperty = "StartTime"});
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "زمان پایان", ObjectProperty = "EndTime" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "تعداد شرکت کننده", ObjectProperty = "ParticipateCount" });
            rGridView3.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView3.CustomButtons.Add(new rGridViewButton { Text = "چــاپ", VisibleOnSelect = true });

            rGridView4.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "Date", SortOrder = SortOrder.Ascending });
            rGridView4.Mappings.Add(new ColumnMapping { Caption = "تاریخ آزمون", ObjectProperty = "ExamDate.ToShortDateString()", SortOrder = SortOrder.Descending });
            rGridView4.Mappings.Add(new ColumnMapping { Caption = "مدرس", ObjectProperty = "Teacher.FarsiFullname" });
            rGridView4.Mappings.Add(new ColumnMapping { Caption = "دوره/رشته", ObjectProperty = "Major" });
            rGridView4.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "Lesson" });
            rGridView4.Mappings.Add(new ColumnMapping { Caption = "کلاس/گروه", ObjectProperty = "Section" });
            rGridView4.Mappings.Add(new ColumnMapping { Caption = "زمان شروع", ObjectProperty = "StartTime" });
            rGridView4.Mappings.Add(new ColumnMapping { Caption = "زمان پایان", ObjectProperty = "EndTime" });
            rGridView4.Mappings.Add(new ColumnMapping { Caption = "تعداد شرکت کننده", ObjectProperty = "ParticipateCount" });
            rGridView4.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView4.CustomButtons.Add(new rGridViewButton { Text = "چــاپ", VisibleOnSelect = true });

            rGridView5.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت", ObjectProperty = "Date", SortOrder = SortOrder.Ascending });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "تاریخ آزمون", ObjectProperty = "ExamDate.ToShortDateString()", SortOrder = SortOrder.Descending });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "مدرس", ObjectProperty = "Teacher.FarsiFullname" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "دوره/رشته", ObjectProperty = "Major" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "Lesson" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "کلاس/گروه", ObjectProperty = "Section" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "زمان شروع", ObjectProperty = "StartTime" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "زمان پایان", ObjectProperty = "EndTime" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "تعداد شرکت کننده", ObjectProperty = "ParticipateCount" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridView5.CustomButtons.Add(new rGridViewButton { Text = "چــاپ", VisibleOnSelect = true });

            Fill();
        }

        private void rGridView1_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            rGridView rGridView = sender as rGridView;
            ExamRequest examRequest = rGridView.GetSelectedObject<ExamRequest>();

            Message message = InternalPostMaster.FromExamRequest(examRequest);
            rptMessage rpt = new rptMessage();
            rpt.DataSource = message;
            frmReportViewer frm = new frmReportViewer(rpt) { AutoPrint = true };
            frm.ShowDialog(this);
        }

        private void Fill()
        {
            IList<ExamRequest> examRequests = ExamRequest.GetRequests();
            IQueryable<ExamRequest> pendings = ExamRequest.GetRequests(examRequests, ExamRequestStatus.Pending);
            IQueryable<ExamRequest> accepted = ExamRequest.GetRequests(examRequests, ExamRequestStatus.Accepted);
            IQueryable<ExamRequest> rejected = ExamRequest.GetRequests(examRequests, ExamRequestStatus.Rejected);
            IQueryable<ExamRequest> started = ExamRequest.GetRequests(examRequests, ExamRequestStatus.Started);

            rGridView1.DataBind(examRequests);
            rGridView2.DataBind(pendings);
            rGridView3.DataBind(accepted);
            rGridView4.DataBind(rejected);
            rGridView5.DataBind(started);

            radPageViewPage1.Text = "درخواست های درحال بررسی (" + pendings.Count() + ")";
            radPageViewPage2.Text = "درخواست های تایید شده (" + accepted.Count() + ")";
            radPageViewPage3.Text = "درخواست های رد شده (" + rejected.Count() + ")";
            radPageViewPage4.Text = "کل درخواست ها (" + examRequests.Count + ")";
            radPageViewPage5.Text = "درخواست های اقدام شده (" + started.Count() + ")";
        }

        private void UpdateGridViews()
        {
            rGridView1.UpdateGridView();
            rGridView2.UpdateGridView();
            rGridView3.UpdateGridView();
            rGridView4.UpdateGridView();
            rGridView5.UpdateGridView();
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            rGridView rGridView = (sender as rGridView);
            ExamRequest examRequest = rGridView.GetSelectedObject<ExamRequest>();
            examRequest.Status = ExamRequestStatus.Accepted;
            examRequest.Save();

            UpdateGridViews();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            rGridView rGridView = (sender as rGridView);
            ExamRequest examRequest = rGridView.GetSelectedObject<ExamRequest>();
            examRequest.Status = ExamRequestStatus.Rejected;
            examRequest.Save();
            UpdateGridViews();
        }

        private void rGridView3_Add(object sender, EventArgs e)
        {
            ExamRequest examRequest = rGridView3.GetSelectedObject<ExamRequest>();
            if(examRequest == null)
            {
                rMessageBox.ShowError("یک درخواست را انتخاب کنید.");
                return;
            }
            examRequest.Status = ExamRequestStatus.Started;
            examRequest.Save();
            UpdateGridViews();
        }
    }
}
