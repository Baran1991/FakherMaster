using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Telerik.Web.UI;

public partial class Components_StudentTopPanel : UserControl
{
    public event EventHandler RegisterChanged;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (WebsiteHandler.CurrentRegister != null)
        {
            foreach (RadComboBoxItem item in cmbMajor.Items)
            {
                if (item.Value == WebsiteHandler.CurrentRegister.Major.Id + "")
                {
                    item.Selected = true;
                    break;
                }
            }
            foreach (RadComboBoxItem item in cmbPeriod.Items)
            {
                if (item.Value == WebsiteHandler.CurrentRegister.Period.Id + "")
                {
                    item.Selected = true;
                    break;
                }
            }
        }
    }

    public new void DataBind()
    {
        cmbMajor.DataTextField = "Name";
        cmbMajor.DataValueField = "Id";
        cmbMajor.DataSource = WebsiteHandler.CurrentStudent.GetRegisteredMajors();
        cmbMajor.DataBind();
    }

    private void OnRegisterChanged()
    {
        if (RegisterChanged != null)
            RegisterChanged(this, EventArgs.Empty);
    }

    public void FillPanel()
    {
        
        RadBinaryImage1.DataValue = WebsiteHandler.CurrentRegister.Student.Photo.PictureBytes;
        lblName.Text = WebsiteHandler.CurrentRegister.Student.FarsiFullname;
        lblStudentCode.Text = WebsiteHandler.CurrentRegister.Code;
        lblEducationalStatus.Text = WebsiteHandler.CurrentRegister.TypeText;
        lblFinancialStatus.Text = WebsiteHandler.CurrentRegister.FarsiFinancialStatusVerboseText;

        Panel1.Visible = true;
    }

    private void FillCmbPeriod()
    {
        Major major = Major.FromId(Convert.ToInt32(cmbMajor.SelectedItem.Value));
        if (major == null)
            return;

        cmbPeriod.DataTextField = "Name";
        cmbPeriod.DataValueField = "Id";
        cmbPeriod.DataSource = WebsiteHandler.CurrentStudent.GetRegisteredPeriods(major);
        cmbPeriod.DataBind();
    }

    public void UpdateRegister()
    {
        Major major = Major.FromId(Convert.ToInt32(cmbMajor.SelectedItem.Value));
        EducationalPeriod period = EducationalPeriod.FromId(Convert.ToInt32(cmbPeriod.SelectedItem.Value));
        if (period == null || major == null)
            return;

        Register register = WebsiteHandler.CurrentStudent.GetRegister(period, major);
        WebsiteHandler.CurrentRegister = register;

        OnRegisterChanged();
    }

    protected void cmbMajor_DataBound(object sender, EventArgs e)
    {
        FillCmbPeriod();
    }
    protected void cmbMajor_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillCmbPeriod();
    }
    //protected void cmbMajor_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    FillCmbPeriod();
    //}

    protected void cmbPeriod_DataBound(object sender, EventArgs e)
    {
        if (IsPostBack || WebsiteHandler.CurrentRegister == null)
            UpdateRegister();
    }
    protected void cmbPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateRegister();
        FillPanel();
    }
    //protected void cmbPeriod_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    //{
    //    UpdateRegister();
    //    FillPanel();
    //}
}
