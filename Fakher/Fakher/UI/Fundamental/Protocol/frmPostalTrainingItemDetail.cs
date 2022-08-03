using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.UI.Fundamental.Protocol;
using rComponents;

namespace Fakher.UI.Educational
{
    public partial class frmPostalTrainingItemDetail : rRadDetailForm
    {
        public frmPostalTrainingItemDetail(PostalTrainingItem item)
        {
            InitializeComponent();

            radPageView1.SelectedPage = radPageViewPage1;

            rGridView1.Mappings.Add(new ColumnMapping {Caption = "رشته", ObjectProperty = "Major.Name"});
            rGridView1.Mappings.Add(new ColumnMapping {Caption = "شهریه", ObjectProperty = "Fee", Type = ColumnType.Money});

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Name" });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox1,
                                        ControlProperty = "Value",
                                        DataObject = item,
                                        ObjectProperty = "Name"
                                    });

            rGridView1.DataBind(item.TuitionFees);
            rGridView2.DataBind(item.PostalTools);
        }

        protected override void AfterBindToObject()
        {
            PostalTrainingItem item = GetProcessingObject<PostalTrainingItem>();
            item.TuitionFees.SyncWith(rGridView1.DataSource);
            item.PostalTools.SyncWith(rGridView2.DataSource);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            PostalTrainingItem item = GetProcessingObject<PostalTrainingItem>();
            
            TuitionFee tuitionFee = new TuitionFee();
            frmTuitionFeeDetail frm = new frmTuitionFeeDetail(tuitionFee, item.Plan.Period.Department.Majors);
            if(!frm.ProcessObject())
                return;
            foreach (TuitionFee fee in rGridView1.DataSource)
                if (fee.Major.Id == tuitionFee.Major.Id)
                {
                    rMessageBox.ShowError("برای این رشته قبلا شهریه ثبت شده است.");
                    return;
                }
            rGridView1.Insert(tuitionFee);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            PostalTrainingItem item = GetProcessingObject<PostalTrainingItem>();

            TuitionFee tuitionFee = rGridView1.GetSelectedObject<TuitionFee>();
            frmTuitionFeeDetail frm = new frmTuitionFeeDetail(tuitionFee, item.Plan.Period.Department.Majors);
            if (!frm.ProcessObject())
                return;

            foreach (TuitionFee fee in rGridView1.DataSource)
                if (fee.Major.Id == tuitionFee.Major.Id && tuitionFee.Id != fee.Id)
                {
                    rMessageBox.ShowError("برای این رشته قبلا شهریه ثبت شده است.");
                    return;
                }
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            TuitionFee tuitionFee = rGridView1.GetSelectedObject<TuitionFee>();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridView2_Add(object sender, EventArgs e)
        {
            PostalTrainingItem item = GetProcessingObject<PostalTrainingItem>();
            frmSelect frm = new frmSelect(EducationalTool.GetActiveTools(), rGridView2.Mappings.ToArray());
            frm.MultiSelect = true;
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            List<EducationalTool> selectedTools = frm.GetSelectedObjects<EducationalTool>();
            foreach (EducationalTool tool in selectedTools)
            {
                bool found = false;
                foreach (PostalTool postalTool in rGridView2.DataSource)
                    if (postalTool.EducationalTool.Id == tool.Id)
                    {
                        found = true;
                        break;
                    }

                if(found)
                    continue;

                PostalTool newPostalTool = new PostalTool();
                newPostalTool.EducationalTool = tool;
                newPostalTool.Item = item;
                item.AddPostalTool(newPostalTool);

                rGridView2.Insert(newPostalTool);
            }
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            rGridView2.RemoveSelectedRow();
        }
    }
}
