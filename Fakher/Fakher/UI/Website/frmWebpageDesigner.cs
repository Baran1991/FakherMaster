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

namespace Fakher.UI.Website
{
    public partial class frmWebpageDesigner : rRadDetailForm
    {
        public frmWebpageDesigner(Webpage page)
        {
            InitializeComponent();
            SetProcessingObject(page);
            radPageView1.SelectedPage = radPageViewPage1;

            if (page.Type != WebpageType.StaticPage)
            {
                radPageView1.Pages.Remove(radPageViewPage2);
            }

            rCheckBox2.Visible = page.Type == WebpageType.Article;

            rCmbPreEnrollmentList.Enabled = rComboBoxDepartment.Enabled = page.PreEnrollmentListBinding;
            rComboBoxDepartment.DataSource = Department.GetDepartments();

//            if (page.PreEnrollmentListBinding)
//                rCmbPreEnrollmentList.DataSource = PreEnrollmentList.GetLists(page.PreEnrollmentList.Major.Department);

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Text",
                DataObject = page,
                ObjectProperty = "Title"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rChkPreEnrollmentList,
                ControlProperty = "IsChecked",
                DataObject = page,
                ObjectProperty = "PreEnrollmentListBinding"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rCheckBox2,
                ControlProperty = "IsChecked",
                DataObject = page,
                ObjectProperty = "IsRed"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rCmbPreEnrollmentList,
                ControlProperty = "SelectedValue",
                DataObject = page,
                ObjectProperty = "PreEnrollmentList"
            });


            if(page.PreEnrollmentListBinding)
            {
                rComboBoxDepartment.SelectedValue = page.PreEnrollmentList.Major.Department;
            }

            rGridViewAttachments.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Name" });
            rGridViewAttachments.DataBind(page.Attachments);
        }

        protected override void AfterValidate()
        {
            if (rChkPreEnrollmentList.IsChecked && rCmbPreEnrollmentList.SelectedValue == null)
            {
                rMessageBox.ShowError("مقدار لیست پیش ثبت نام را مشخص کنید.");
                CancelClosing();
                return;
            }
        }

        protected override void AfterBindToObject()
        {
            Webpage page = GetProcessingObject<Webpage>();

            page.Html = Services.NormalizeFarsiString(rHtmlEditor1.BodyHtml);
            page.Attachments.SyncWith(rGridViewAttachments.DataSource);
        }

        private void rChkPreEnrollmentList_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rCmbPreEnrollmentList.Enabled = rComboBoxDepartment.Enabled = rChkPreEnrollmentList.IsChecked;
        }

        private void rGridViewAttachments_Add(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files (*.*)|*.*";
            dialog.Multiselect = false;
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            WebMedia media = WebMedia.FromFileName(dialog.FileName, WebMediaType.Attachment);
            rGridViewAttachments.Insert(media);
        }

        private void rGridViewAttachments_Edit(object sender, EventArgs e)
        {
            WebMedia media = rGridViewAttachments.GetSelectedObject<WebMedia>();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files (*.*)|*.*";
            dialog.Multiselect = false;
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            media.SetFile(dialog.FileName);
            rGridViewAttachments.UpdateGridView();
        }

        private void rGridViewAttachments_Delete(object sender, EventArgs e)
        {
            WebMedia media = rGridViewAttachments.GetSelectedObject<WebMedia>();
            rGridViewAttachments.RemoveSelectedRow();
        }

        private void rComboBoxDepartment_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (rComboBoxDepartment.SelectedValue == null)
                return;

            Department department = rComboBoxDepartment.SelectedValue as Department;
            rCmbPreEnrollmentList.DataSource = PreEnrollmentList.GetLists(department);
        }

        private void frmWebpageDesigner_Shown(object sender, EventArgs e)
        {
            Webpage page = GetProcessingObject<Webpage>();

            rHtmlEditor1.BodyHtml = page.Html;
        }
    }
}
