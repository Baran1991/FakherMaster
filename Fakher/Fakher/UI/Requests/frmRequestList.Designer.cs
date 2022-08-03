using Fakher.Core.DomainModel;

namespace Fakher.UI.Educational.Requests
{
    partial class frmRequestList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView1 = new rComponents.rGridView();
            this.radPageViewPage3 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView3 = new rComponents.rGridView();
            //this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView2 = new rComponents.rGridView();
            this.radPageViewPage4 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView4 = new rComponents.rGridView();
            this.radPageViewPage5 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView5 = new rComponents.rGridView();
            this.radPageViewPage6 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView6 = new rComponents.rGridView();
            this.radPageViewPage7 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView7 = new rComponents.rGridView();
            this.radPageViewPage8 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView8 = new rComponents.rGridView();
            this.radPageViewPage9 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView9 = new rComponents.rGridView();
            this.radPageViewPage10 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView10 = new rComponents.rGridView();
            this.radPageViewPage11 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView11 = new rComponents.rGridView();
            this.radPageViewPage12 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView12 = new rComponents.rGridView();
            this.radPageViewPage13 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView13 = new rComponents.rGridView();
            this.radPageViewPage14 = new Telerik.WinControls.UI.RadPageViewPage();
            this.rGridView14 = new rComponents.rGridView();
            this.btnAllRequest = new System.Windows.Forms.Button();
            this.btnDefaultAns = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            this.radPageViewPage3.SuspendLayout();
            //this.radPageViewPage2.SuspendLayout();
            this.radPageViewPage4.SuspendLayout();
            this.radPageViewPage5.SuspendLayout();
            this.radPageViewPage6.SuspendLayout();
            this.radPageViewPage7.SuspendLayout();
            this.radPageViewPage8.SuspendLayout();
            this.radPageViewPage9.SuspendLayout();
            this.radPageViewPage10.SuspendLayout();
            this.radPageViewPage11.SuspendLayout();
            this.radPageViewPage12.SuspendLayout();
            this.radPageViewPage13.SuspendLayout();
            this.radPageViewPage14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            var notRepliedRequestsCount = Request.GetRequestsByStatusCount(RequestStatus.Waiting);
            var InReviseCount = Request.GetRequestsByStatusCount(RequestStatus.InRevise);
            var ReferrToLeaveCount = Request.GetRequestsByStatusCount(RequestStatus.ReferrToLeave);
            var ReferrToInterviewCount = Request.GetRequestsByStatusCount(RequestStatus.ReferrToInterview);
            var ReferrToConsultantCount = Request.GetRequestsByStatusCount(RequestStatus.ReferrToConsultant);
            var ReferrToCertificateCount = Request.GetRequestsByStatusCount(RequestStatus.ReferrToCertificate);
            var ReferrToExamCount = Request.GetRequestsByStatusCount(RequestStatus.ReferrToExam);
            var ReferrToStaffCount = Request.GetRequestsByStatusCount(RequestStatus.ReferrToStaff);
            var ReferrToFinansialCount = Request.GetRequestsByStatusCount(RequestStatus.ReferrToFinansial);
            var ReferrToPublishingCount = Request.GetRequestsByStatusCount(RequestStatus.ReferrToPublishing);
            var ReferrToTeachersCount = Request.GetRequestsByStatusCount(RequestStatus.ReferrToTeachers);
            var ReferrToTrainingCount = Request.GetRequestsByStatusCount(RequestStatus.ReferrToTraining);
            var ReferrToTrCount = Request.GetRequestsByStatusCount(RequestStatus.ReferrToTr);


            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Controls.Add(this.radPageViewPage3);
            //this.radPageView1.Controls.Add(this.radPageViewPage2);
            this.radPageView1.Controls.Add(this.radPageViewPage4);
            this.radPageView1.Controls.Add(this.radPageViewPage5);
            this.radPageView1.Controls.Add(this.radPageViewPage6);
            this.radPageView1.Controls.Add(this.radPageViewPage7);
            this.radPageView1.Controls.Add(this.radPageViewPage8);
            this.radPageView1.Controls.Add(this.radPageViewPage9);
            this.radPageView1.Controls.Add(this.radPageViewPage10);
            this.radPageView1.Controls.Add(this.radPageViewPage11);
            this.radPageView1.Controls.Add(this.radPageViewPage12);
            this.radPageView1.Controls.Add(this.radPageViewPage13);
            this.radPageView1.Controls.Add(this.radPageViewPage14);
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPageView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radPageView1.Location = new System.Drawing.Point(0, 59);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage14;
            this.radPageView1.Size = new System.Drawing.Size(1206, 430);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.SelectedPageChanged += new System.EventHandler(this.radPageView1_SelectedPageChanged);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.rGridView1);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 39);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(1185, 380);
            this.radPageViewPage1.Text = "درخواست های بدون پاسخ" + "(" + notRepliedRequestsCount + ")";
            // 
            // rGridView1
            // 
            this.rGridView1.CanAdd = false;
            this.rGridView1.CanDelete = true;
            this.rGridView1.CanEdit = true;
            this.rGridView1.CanExport = true;
            this.rGridView1.CanFilter = true;
            this.rGridView1.CanGroup = false;
            this.rGridView1.CanNavigate = true;
            this.rGridView1.CheckBoxes = false;
            this.rGridView1.ColumnAutoSize = true;
            this.rGridView1.ConfirmOnDelete = false;
            this.rGridView1.CustomAddText = null;
            this.rGridView1.CustomDeleteText = "چاپ";
            this.rGridView1.CustomEditText = null;
            this.rGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView1.EditOnDoubleClick = true;
            this.rGridView1.FieldName = null;
            this.rGridView1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView1.ItemImage = null;
            this.rGridView1.Location = new System.Drawing.Point(0, 0);
            this.rGridView1.MultiSelect = false;
            this.rGridView1.Name = "rGridView1";
            this.rGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView1.RowHeight = 25;
            this.rGridView1.ShowBottomToolbar = false;
            this.rGridView1.ShowGroupPanel = true;
            this.rGridView1.ShowTopToolbar = true;
            this.rGridView1.Size = new System.Drawing.Size(1185, 380);
            this.rGridView1.TabIndex = 0;
            this.rGridView1.ValidationType = rComponents.ValidationType.None;
            this.rGridView1.Edit += new System.EventHandler(this.rGridView1_Edit);
            this.rGridView1.Delete += new System.EventHandler(this.rGridView1_Delete);
            // 
            // radPageViewPage3
            // 
            this.radPageViewPage3.Controls.Add(this.rGridView3);
            this.radPageViewPage3.Location = new System.Drawing.Point(10, 39);
            this.radPageViewPage3.Name = "radPageViewPage3";
            this.radPageViewPage3.Size = new System.Drawing.Size(1185, 380);
            this.radPageViewPage3.Text = "درخواست های در حال بازبینی" + "(" + InReviseCount + ")";
            // 
            // rGridView3
            // 
            this.rGridView3.CanAdd = false;
            this.rGridView3.CanDelete = true;
            this.rGridView3.CanEdit = true;
            this.rGridView3.CanExport = true;
            this.rGridView3.CanFilter = true;
            this.rGridView3.CanGroup = false;
            this.rGridView3.CanNavigate = true;
            this.rGridView3.CheckBoxes = false;
            this.rGridView3.ColumnAutoSize = true;
            this.rGridView3.ConfirmOnDelete = false;
            this.rGridView3.CustomAddText = null;
            this.rGridView3.CustomDeleteText = "چاپ";
            this.rGridView3.CustomEditText = null;
            this.rGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView3.EditOnDoubleClick = true;
            this.rGridView3.FieldName = null;
            this.rGridView3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView3.ItemImage = null;
            this.rGridView3.Location = new System.Drawing.Point(0, 0);
            this.rGridView3.MultiSelect = false;
            this.rGridView3.Name = "rGridView3";
            this.rGridView3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView3.RowHeight = 25;
            this.rGridView3.ShowBottomToolbar = false;
            this.rGridView3.ShowGroupPanel = true;
            this.rGridView3.ShowTopToolbar = true;
            this.rGridView3.Size = new System.Drawing.Size(1185, 380);
            this.rGridView3.TabIndex = 2;
            this.rGridView3.ValidationType = rComponents.ValidationType.None;
            this.rGridView3.Edit += new System.EventHandler(this.rGridView3_Edit);
            this.rGridView3.Delete += new System.EventHandler(this.rGridView3_Delete);
            // 
            // radPageViewPage2
            // 
            //this.radPageViewPage2.Controls.Add(this.rGridView2);
            //this.radPageViewPage2.Location = new System.Drawing.Point(10, 39);
            //this.radPageViewPage2.Name = "radPageViewPage2";
            //this.radPageViewPage2.Size = new System.Drawing.Size(1185, 380);
            //this.radPageViewPage2.Text = "کـــل درخــواســت هـــا";

            // 
            // rGridView2
            // 
            this.rGridView2.CanAdd = false;
            this.rGridView2.CanDelete = true;
            this.rGridView2.CanEdit = true;
            this.rGridView2.CanExport = true;
            this.rGridView2.CanFilter = true;
            this.rGridView2.CanGroup = false;
            this.rGridView2.CanNavigate = true;
            this.rGridView2.CheckBoxes = false;
            this.rGridView2.ColumnAutoSize = true;
            this.rGridView2.ConfirmOnDelete = false;
            this.rGridView2.CustomAddText = null;
            this.rGridView2.CustomDeleteText = "چاپ";
            this.rGridView2.CustomEditText = null;
            this.rGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView2.EditOnDoubleClick = true;
            this.rGridView2.FieldName = null;
            this.rGridView2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView2.ItemImage = null;
            this.rGridView2.Location = new System.Drawing.Point(0, 0);
            this.rGridView2.MultiSelect = false;
            this.rGridView2.Name = "rGridView2";
            this.rGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView2.RowHeight = 25;
            this.rGridView2.ShowBottomToolbar = false;
            this.rGridView2.ShowGroupPanel = true;
            this.rGridView2.ShowTopToolbar = true;
            this.rGridView2.Size = new System.Drawing.Size(1185, 380);
            this.rGridView2.TabIndex = 1;
            this.rGridView2.ValidationType = rComponents.ValidationType.None;
            this.rGridView2.Edit += new System.EventHandler(this.rGridView2_Edit);
            this.rGridView2.Delete += new System.EventHandler(this.rGridView2_Delete);
            // 
            // radPageViewPage4
            // 
            this.radPageViewPage4.Controls.Add(this.rGridView4);
            this.radPageViewPage4.Location = new System.Drawing.Point(10, 39);
            this.radPageViewPage4.Name = "radPageViewPage4";
            this.radPageViewPage4.Size = new System.Drawing.Size(1185, 380);
            this.radPageViewPage4.Text = " آموزش" + "(" + ReferrToTrainingCount + ")";
            // 
            // rGridView4
            // 
            this.rGridView4.CanAdd = false;
            this.rGridView4.CanDelete = true;
            this.rGridView4.CanEdit = true;
            this.rGridView4.CanExport = true;
            this.rGridView4.CanFilter = true;
            this.rGridView4.CanGroup = false;
            this.rGridView4.CanNavigate = true;
            this.rGridView4.CheckBoxes = false;
            this.rGridView4.ColumnAutoSize = true;
            this.rGridView4.ConfirmOnDelete = false;
            this.rGridView4.CustomAddText = null;
            this.rGridView4.CustomDeleteText = "چاپ";
            this.rGridView4.CustomEditText = null;
            this.rGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView4.EditOnDoubleClick = true;
            this.rGridView4.FieldName = null;
            this.rGridView4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView4.ItemImage = null;
            this.rGridView4.Location = new System.Drawing.Point(0, 0);
            this.rGridView4.MultiSelect = false;
            this.rGridView4.Name = "rGridView4";
            this.rGridView4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView4.RowHeight = 25;
            this.rGridView4.ShowBottomToolbar = false;
            this.rGridView4.ShowGroupPanel = true;
            this.rGridView4.ShowTopToolbar = true;
            this.rGridView4.Size = new System.Drawing.Size(1185, 380);
            this.rGridView4.TabIndex = 1;
            this.rGridView4.ValidationType = rComponents.ValidationType.None;
            this.rGridView4.Edit += new System.EventHandler(this.rGridView4_Edit);
            this.rGridView4.Delete += new System.EventHandler(this.rGridView4_Delete);
            // 
            // radPageViewPage5
            // 
            this.radPageViewPage5.Controls.Add(this.rGridView5);
            this.radPageViewPage5.Location = new System.Drawing.Point(10, 39);
            this.radPageViewPage5.Name = "radPageViewPage5";
            this.radPageViewPage5.Size = new System.Drawing.Size(1185, 380);
            this.radPageViewPage5.Text = " مرخصی" + "(" + ReferrToLeaveCount + ")";
            // 
            // rGridView5
            // 
            this.rGridView5.CanAdd = false;
            this.rGridView5.CanDelete = true;
            this.rGridView5.CanEdit = true;
            this.rGridView5.CanExport = true;
            this.rGridView5.CanFilter = true;
            this.rGridView5.CanGroup = false;
            this.rGridView5.CanNavigate = true;
            this.rGridView5.CheckBoxes = false;
            this.rGridView5.ColumnAutoSize = true;
            this.rGridView5.ConfirmOnDelete = false;
            this.rGridView5.CustomAddText = null;
            this.rGridView5.CustomDeleteText = "چاپ";
            this.rGridView5.CustomEditText = null;
            this.rGridView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView5.EditOnDoubleClick = true;
            this.rGridView5.FieldName = null;
            this.rGridView5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView5.ItemImage = null;
            this.rGridView5.Location = new System.Drawing.Point(0, 0);
            this.rGridView5.MultiSelect = false;
            this.rGridView5.Name = "rGridView5";
            this.rGridView5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView5.RowHeight = 25;
            this.rGridView5.ShowBottomToolbar = false;
            this.rGridView5.ShowGroupPanel = true;
            this.rGridView5.ShowTopToolbar = true;
            this.rGridView5.Size = new System.Drawing.Size(1185, 380);
            this.rGridView5.TabIndex = 1;
            this.rGridView5.ValidationType = rComponents.ValidationType.None;
            this.rGridView5.Edit += new System.EventHandler(this.rGridView5_Edit);
            this.rGridView5.Delete += new System.EventHandler(this.rGridView5_Delete);
            // 
            // radPageViewPage6
            // 
            this.radPageViewPage6.Controls.Add(this.rGridView6);
            this.radPageViewPage6.Location = new System.Drawing.Point(10, 39);
            this.radPageViewPage6.Name = "radPageViewPage6";
            this.radPageViewPage6.Size = new System.Drawing.Size(1185, 380);
            this.radPageViewPage6.Text = " آزمون" + "(" + ReferrToExamCount + ")";
            // 
            // rGridView6
            // 
            this.rGridView6.CanAdd = false;
            this.rGridView6.CanDelete = true;
            this.rGridView6.CanEdit = true;
            this.rGridView6.CanExport = true;
            this.rGridView6.CanFilter = true;
            this.rGridView6.CanGroup = false;
            this.rGridView6.CanNavigate = true;
            this.rGridView6.CheckBoxes = false;
            this.rGridView6.ColumnAutoSize = true;
            this.rGridView6.ConfirmOnDelete = false;
            this.rGridView6.CustomAddText = null;
            this.rGridView6.CustomDeleteText = "چاپ";
            this.rGridView6.CustomEditText = null;
            this.rGridView6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView6.EditOnDoubleClick = true;
            this.rGridView6.FieldName = null;
            this.rGridView6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView6.ItemImage = null;
            this.rGridView6.Location = new System.Drawing.Point(0, 0);
            this.rGridView6.MultiSelect = false;
            this.rGridView6.Name = "rGridView6";
            this.rGridView6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView6.RowHeight = 25;
            this.rGridView6.ShowBottomToolbar = false;
            this.rGridView6.ShowGroupPanel = true;
            this.rGridView6.ShowTopToolbar = true;
            this.rGridView6.Size = new System.Drawing.Size(1185, 380);
            this.rGridView6.TabIndex = 1;
            this.rGridView6.ValidationType = rComponents.ValidationType.None;
            this.rGridView6.Edit += new System.EventHandler(this.rGridView6_Edit);
            this.rGridView6.Delete += new System.EventHandler(this.rGridView6_Delete);
            // 
            // radPageViewPage7
            // 
            this.radPageViewPage7.Controls.Add(this.rGridView7);
            this.radPageViewPage7.Location = new System.Drawing.Point(10, 39);
            this.radPageViewPage7.Name = "radPageViewPage7";
            this.radPageViewPage7.Size = new System.Drawing.Size(1185, 380);
            this.radPageViewPage7.Text = " مصاحبه" + "(" + ReferrToInterviewCount + ")";
            // 
            // rGridView7
            // 
            this.rGridView7.CanAdd = false;
            this.rGridView7.CanDelete = true;
            this.rGridView7.CanEdit = true;
            this.rGridView7.CanExport = true;
            this.rGridView7.CanFilter = true;
            this.rGridView7.CanGroup = false;
            this.rGridView7.CanNavigate = true;
            this.rGridView7.CheckBoxes = false;
            this.rGridView7.ColumnAutoSize = true;
            this.rGridView7.ConfirmOnDelete = false;
            this.rGridView7.CustomAddText = null;
            this.rGridView7.CustomDeleteText = "چاپ";
            this.rGridView7.CustomEditText = null;
            this.rGridView7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView7.EditOnDoubleClick = true;
            this.rGridView7.FieldName = null;
            this.rGridView7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView7.ItemImage = null;
            this.rGridView7.Location = new System.Drawing.Point(0, 0);
            this.rGridView7.MultiSelect = false;
            this.rGridView7.Name = "rGridView7";
            this.rGridView7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView7.RowHeight = 25;
            this.rGridView7.ShowBottomToolbar = false;
            this.rGridView7.ShowGroupPanel = true;
            this.rGridView7.ShowTopToolbar = true;
            this.rGridView7.Size = new System.Drawing.Size(1185, 380);
            this.rGridView7.TabIndex = 1;
            this.rGridView7.ValidationType = rComponents.ValidationType.None;
            this.rGridView7.Edit += new System.EventHandler(this.rGridView7_Edit);
            this.rGridView7.Delete += new System.EventHandler(this.rGridView7_Delete);
            // 
            // radPageViewPage8
            // 
            this.radPageViewPage8.Controls.Add(this.rGridView8);
            this.radPageViewPage8.Location = new System.Drawing.Point(10, 39);
            this.radPageViewPage8.Name = "radPageViewPage8";
            this.radPageViewPage8.Size = new System.Drawing.Size(1185, 380);
            this.radPageViewPage8.Text = " انتقال" + "(" + ReferrToTrCount + ")";
            // 
            // rGridView8
            // 
            this.rGridView8.CanAdd = false;
            this.rGridView8.CanDelete = true;
            this.rGridView8.CanEdit = true;
            this.rGridView8.CanExport = true;
            this.rGridView8.CanFilter = true;
            this.rGridView8.CanGroup = false;
            this.rGridView8.CanNavigate = true;
            this.rGridView8.CheckBoxes = false;
            this.rGridView8.ColumnAutoSize = true;
            this.rGridView8.ConfirmOnDelete = false;
            this.rGridView8.CustomAddText = null;
            this.rGridView8.CustomDeleteText = "چاپ";
            this.rGridView8.CustomEditText = null;
            this.rGridView8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView8.EditOnDoubleClick = true;
            this.rGridView8.FieldName = null;
            this.rGridView8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView8.ItemImage = null;
            this.rGridView8.Location = new System.Drawing.Point(0, 0);
            this.rGridView8.MultiSelect = false;
            this.rGridView8.Name = "rGridView8";
            this.rGridView8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView8.RowHeight = 25;
            this.rGridView8.ShowBottomToolbar = false;
            this.rGridView8.ShowGroupPanel = true;
            this.rGridView8.ShowTopToolbar = true;
            this.rGridView8.Size = new System.Drawing.Size(1185, 380);
            this.rGridView8.TabIndex = 1;
            this.rGridView8.ValidationType = rComponents.ValidationType.None;
            this.rGridView8.Edit += new System.EventHandler(this.rGridView8_Edit);
            this.rGridView8.Delete += new System.EventHandler(this.rGridView8_Delete);
            // 
            // radPageViewPage9
            // 
            this.radPageViewPage9.Controls.Add(this.rGridView9);
            this.radPageViewPage9.Location = new System.Drawing.Point(10, 39);
            this.radPageViewPage9.Name = "radPageViewPage9";
            this.radPageViewPage9.Size = new System.Drawing.Size(1185, 380);
            this.radPageViewPage9.Text = " مالی و انصراف" + "(" + ReferrToFinansialCount + ")";
            // 
            // rGridView9
            // 
            this.rGridView9.CanAdd = false;
            this.rGridView9.CanDelete = true;
            this.rGridView9.CanEdit = true;
            this.rGridView9.CanExport = true;
            this.rGridView9.CanFilter = true;
            this.rGridView9.CanGroup = false;
            this.rGridView9.CanNavigate = true;
            this.rGridView9.CheckBoxes = false;
            this.rGridView9.ColumnAutoSize = true;
            this.rGridView9.ConfirmOnDelete = false;
            this.rGridView9.CustomAddText = null;
            this.rGridView9.CustomDeleteText = "چاپ";
            this.rGridView9.CustomEditText = null;
            this.rGridView9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView9.EditOnDoubleClick = true;
            this.rGridView9.FieldName = null;
            this.rGridView9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView9.ItemImage = null;
            this.rGridView9.Location = new System.Drawing.Point(0, 0);
            this.rGridView9.MultiSelect = false;
            this.rGridView9.Name = "rGridView9";
            this.rGridView9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView9.RowHeight = 25;
            this.rGridView9.ShowBottomToolbar = false;
            this.rGridView9.ShowGroupPanel = true;
            this.rGridView9.ShowTopToolbar = true;
            this.rGridView9.Size = new System.Drawing.Size(1185, 380);
            this.rGridView9.TabIndex = 1;
            this.rGridView9.ValidationType = rComponents.ValidationType.None;
            this.rGridView9.Edit += new System.EventHandler(this.rGridView9_Edit);
            this.rGridView9.Delete += new System.EventHandler(this.rGridView9_Delete);
            // 
            // radPageViewPage10
            // 
            this.radPageViewPage10.Controls.Add(this.rGridView10);
            this.radPageViewPage10.Location = new System.Drawing.Point(10, 39);
            this.radPageViewPage10.Name = "radPageViewPage10";
            this.radPageViewPage10.Size = new System.Drawing.Size(1185, 380);
            this.radPageViewPage10.Text = " صدور مدرک و گواهی" + "(" + ReferrToCertificateCount + ")";
            // 
            // rGridView10
            // 
            this.rGridView10.CanAdd = false;
            this.rGridView10.CanDelete = true;
            this.rGridView10.CanEdit = true;
            this.rGridView10.CanExport = true;
            this.rGridView10.CanFilter = true;
            this.rGridView10.CanGroup = false;
            this.rGridView10.CanNavigate = true;
            this.rGridView10.CheckBoxes = false;
            this.rGridView10.ColumnAutoSize = true;
            this.rGridView10.ConfirmOnDelete = false;
            this.rGridView10.CustomAddText = null;
            this.rGridView10.CustomDeleteText = "چاپ";
            this.rGridView10.CustomEditText = null;
            this.rGridView10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView10.EditOnDoubleClick = true;
            this.rGridView10.FieldName = null;
            this.rGridView10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView10.ItemImage = null;
            this.rGridView10.Location = new System.Drawing.Point(0, 0);
            this.rGridView10.MultiSelect = false;
            this.rGridView10.Name = "rGridView10";
            this.rGridView10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView10.RowHeight = 25;
            this.rGridView10.ShowBottomToolbar = false;
            this.rGridView10.ShowGroupPanel = true;
            this.rGridView10.ShowTopToolbar = true;
            this.rGridView10.Size = new System.Drawing.Size(1185, 380);
            this.rGridView10.TabIndex = 1;
            this.rGridView10.ValidationType = rComponents.ValidationType.None;
            this.rGridView10.Edit += new System.EventHandler(this.rGridView10_Edit);
            this.rGridView10.Delete += new System.EventHandler(this.rGridView10_Delete);
            // 
            // radPageViewPage11
            // 
            this.radPageViewPage11.Controls.Add(this.rGridView11);
            this.radPageViewPage11.Location = new System.Drawing.Point(10, 39);
            this.radPageViewPage11.Name = "radPageViewPage11";
            this.radPageViewPage11.Size = new System.Drawing.Size(1185, 380);
            this.radPageViewPage11.Text = " انتشارات" + "(" + ReferrToPublishingCount + ")";
            // 
            // rGridView11
            // 
            this.rGridView11.CanAdd = false;
            this.rGridView11.CanDelete = true;
            this.rGridView11.CanEdit = true;
            this.rGridView11.CanExport = true;
            this.rGridView11.CanFilter = true;
            this.rGridView11.CanGroup = false;
            this.rGridView11.CanNavigate = true;
            this.rGridView11.CheckBoxes = false;
            this.rGridView11.ColumnAutoSize = true;
            this.rGridView11.ConfirmOnDelete = false;
            this.rGridView11.CustomAddText = null;
            this.rGridView11.CustomDeleteText = "چاپ";
            this.rGridView11.CustomEditText = null;
            this.rGridView11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView11.EditOnDoubleClick = true;
            this.rGridView11.FieldName = null;
            this.rGridView11.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView11.ItemImage = null;
            this.rGridView11.Location = new System.Drawing.Point(0, 0);
            this.rGridView11.MultiSelect = false;
            this.rGridView11.Name = "rGridView11";
            this.rGridView11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView11.RowHeight = 25;
            this.rGridView11.ShowBottomToolbar = false;
            this.rGridView11.ShowGroupPanel = true;
            this.rGridView11.ShowTopToolbar = true;
            this.rGridView11.Size = new System.Drawing.Size(1185, 380);
            this.rGridView11.TabIndex = 1;
            this.rGridView11.ValidationType = rComponents.ValidationType.None;
            this.rGridView11.Edit += new System.EventHandler(this.rGridView11_Edit);
            this.rGridView11.Delete += new System.EventHandler(this.rGridView11_Delete);
            // 
            // radPageViewPage12
            // 
            this.radPageViewPage12.Controls.Add(this.rGridView12);
            this.radPageViewPage12.Location = new System.Drawing.Point(10, 39);
            this.radPageViewPage12.Name = "radPageViewPage12";
            this.radPageViewPage12.Size = new System.Drawing.Size(1185, 380);
            this.radPageViewPage12.Text = " مدرسین" + "(" + ReferrToTeachersCount + ")";
            // 
            // rGridView12
            // 
            this.rGridView12.CanAdd = false;
            this.rGridView12.CanDelete = true;
            this.rGridView12.CanEdit = true;
            this.rGridView12.CanExport = true;
            this.rGridView12.CanFilter = true;
            this.rGridView12.CanGroup = false;
            this.rGridView12.CanNavigate = true;
            this.rGridView12.CheckBoxes = false;
            this.rGridView12.ColumnAutoSize = true;
            this.rGridView12.ConfirmOnDelete = false;
            this.rGridView12.CustomAddText = null;
            this.rGridView12.CustomDeleteText = "چاپ";
            this.rGridView12.CustomEditText = null;
            this.rGridView12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView12.EditOnDoubleClick = true;
            this.rGridView12.FieldName = null;
            this.rGridView12.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView12.ItemImage = null;
            this.rGridView12.Location = new System.Drawing.Point(0, 0);
            this.rGridView12.MultiSelect = false;
            this.rGridView12.Name = "rGridView12";
            this.rGridView12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView12.RowHeight = 25;
            this.rGridView12.ShowBottomToolbar = false;
            this.rGridView12.ShowGroupPanel = true;
            this.rGridView12.ShowTopToolbar = true;
            this.rGridView12.Size = new System.Drawing.Size(1185, 380);
            this.rGridView12.TabIndex = 1;
            this.rGridView12.ValidationType = rComponents.ValidationType.None;
            this.rGridView12.Edit += new System.EventHandler(this.rGridView12_Edit);
            this.rGridView12.Delete += new System.EventHandler(this.rGridView13_Delete);
            // 
            // radPageViewPage13
            // 
            this.radPageViewPage13.Controls.Add(this.rGridView13);
            this.radPageViewPage13.Location = new System.Drawing.Point(10, 39);
            this.radPageViewPage13.Name = "radPageViewPage13";
            this.radPageViewPage13.Size = new System.Drawing.Size(1185, 380);
            this.radPageViewPage13.Text = " پرسنل" + "(" + ReferrToStaffCount + ")";
            // 
            // rGridView13
            // 
            this.rGridView13.CanAdd = false;
            this.rGridView13.CanDelete = true;
            this.rGridView13.CanEdit = true;
            this.rGridView13.CanExport = true;
            this.rGridView13.CanFilter = true;
            this.rGridView13.CanGroup = false;
            this.rGridView13.CanNavigate = true;
            this.rGridView13.CheckBoxes = false;
            this.rGridView13.ColumnAutoSize = true;
            this.rGridView13.ConfirmOnDelete = false;
            this.rGridView13.CustomAddText = null;
            this.rGridView13.CustomDeleteText = "چاپ";
            this.rGridView13.CustomEditText = null;
            this.rGridView13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView13.EditOnDoubleClick = true;
            this.rGridView13.FieldName = null;
            this.rGridView13.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView13.ItemImage = null;
            this.rGridView13.Location = new System.Drawing.Point(0, 0);
            this.rGridView13.MultiSelect = false;
            this.rGridView13.Name = "rGridView13";
            this.rGridView13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView13.RowHeight = 25;
            this.rGridView13.ShowBottomToolbar = false;
            this.rGridView13.ShowGroupPanel = true;
            this.rGridView13.ShowTopToolbar = true;
            this.rGridView13.Size = new System.Drawing.Size(1185, 380);
            this.rGridView13.TabIndex = 1;
            this.rGridView13.ValidationType = rComponents.ValidationType.None;
            this.rGridView13.Edit += new System.EventHandler(this.rGridView13_Edit);
            this.rGridView13.Delete += new System.EventHandler(this.rGridView13_Delete);
            // 
            // radPageViewPage14
            // 
            this.radPageViewPage14.Controls.Add(this.rGridView14);
            this.radPageViewPage14.Location = new System.Drawing.Point(10, 39);
            this.radPageViewPage14.Name = "radPageViewPage14";
            this.radPageViewPage14.Size = new System.Drawing.Size(1185, 380);
            this.radPageViewPage14.Text = " مشاوره" + "(" + ReferrToConsultantCount + ")";
            // 
            // rGridView14
            // 
            this.rGridView14.CanAdd = false;
            this.rGridView14.CanDelete = true;
            this.rGridView14.CanEdit = true;
            this.rGridView14.CanExport = true;
            this.rGridView14.CanFilter = true;
            this.rGridView14.CanGroup = false;
            this.rGridView14.CanNavigate = true;
            this.rGridView14.CheckBoxes = false;
            this.rGridView14.ColumnAutoSize = true;
            this.rGridView14.ConfirmOnDelete = false;
            this.rGridView14.CustomAddText = null;
            this.rGridView14.CustomDeleteText = "چاپ";
            this.rGridView14.CustomEditText = null;
            this.rGridView14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGridView14.EditOnDoubleClick = true;
            this.rGridView14.FieldName = null;
            this.rGridView14.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridView14.ItemImage = null;
            this.rGridView14.Location = new System.Drawing.Point(0, 0);
            this.rGridView14.MultiSelect = false;
            this.rGridView14.Name = "rGridView14";
            this.rGridView14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridView14.RowHeight = 25;
            this.rGridView14.ShowBottomToolbar = false;
            this.rGridView14.ShowGroupPanel = true;
            this.rGridView14.ShowTopToolbar = true;
            this.rGridView14.Size = new System.Drawing.Size(1185, 380);
            this.rGridView14.TabIndex = 1;
            this.rGridView14.ValidationType = rComponents.ValidationType.None;
            this.rGridView14.Edit += new System.EventHandler(this.rGridView14_Edit);
            this.rGridView14.Delete += new System.EventHandler(this.rGridView14_Delete);
                
         
            // 
            // btnDefaultAns
            // 
            this.btnDefaultAns.Location = new System.Drawing.Point(395, 20);
            this.btnDefaultAns.Name = "btnDefaultAns";
            this.btnDefaultAns.Size = new System.Drawing.Size(157, 28);
            this.btnDefaultAns.TabIndex = 32;
            this.btnDefaultAns.Text = "پاسخ های پیش فرض";
            this.btnDefaultAns.UseVisualStyleBackColor = true;
            this.btnDefaultAns.Click += new System.EventHandler(this.btnDefaultAns_Click);
            // 
            // btnAllRequest
            // 
            this.btnAllRequest.Location = new System.Drawing.Point(595, 20);
            this.btnAllRequest.Name = "btnAllRequest";
            this.btnAllRequest.Size = new System.Drawing.Size(157, 28);
            this.btnAllRequest.TabIndex = 32;
            this.btnAllRequest.Text = "کل درخواست ها";
            this.btnAllRequest.UseVisualStyleBackColor = true;
            this.btnAllRequest.Click += new System.EventHandler(this.BtnAllRequest_Click);
            // 
            // frmRequestList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1206, 489);
            this.Controls.Add(this.btnDefaultAns);
            this.Controls.Add(this.btnAllRequest);
            this.Controls.Add(this.radPageView1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmRequestList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "درخواست های دانشجویان";
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage3.ResumeLayout(false);
            //this.radPageViewPage2.ResumeLayout(false);
            this.radPageViewPage4.ResumeLayout(false);
            this.radPageViewPage5.ResumeLayout(false);
            this.radPageViewPage6.ResumeLayout(false);
            this.radPageViewPage7.ResumeLayout(false);
            this.radPageViewPage8.ResumeLayout(false);
            this.radPageViewPage9.ResumeLayout(false);
            this.radPageViewPage10.ResumeLayout(false);
            this.radPageViewPage11.ResumeLayout(false);
            this.radPageViewPage12.ResumeLayout(false);
            this.radPageViewPage13.ResumeLayout(false);
            this.radPageViewPage14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private rComponents.rGridView rGridView1;
        private rComponents.rGridView rGridView2;
        private rComponents.rGridView rGridView3;
        private rComponents.rGridView rGridView4;
        private rComponents.rGridView rGridView5;
        private rComponents.rGridView rGridView6;
        private rComponents.rGridView rGridView7;
        private rComponents.rGridView rGridView8;
        private rComponents.rGridView rGridView9; 
        private rComponents.rGridView rGridView10;
        private rComponents.rGridView rGridView11;
        private rComponents.rGridView rGridView12; 
        private rComponents.rGridView rGridView13;
        private rComponents.rGridView rGridView14;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        //private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage3;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage4;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage5;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage6;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage7;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage8;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage9;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage10;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage11;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage12;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage13;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage14;
        
        private System.Windows.Forms.Button btnAllRequest;
        private System.Windows.Forms.Button btnDefaultAns;
    }
}