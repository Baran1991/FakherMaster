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
using Fakher.UI.Struture.Protocol;
using rComponents;

namespace Fakher.UI.Struture
{
    public partial class frmEducationalRuleList : rRadForm
    {
        public frmEducationalRuleList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "آیین نامه نمره دهی", ObjectProperty = "ResultLabel.ResultProtocol.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "آیتم نمره دهی", ObjectProperty = "ResultLabel.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "اپراتور", ObjectProperty = "RecurrenceOperatorText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تعداد دفعات تکرار", ObjectProperty = "RecurrenceCount" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نوع تکرار", ObjectProperty = "RecurrenceTypeText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس/سطح نتیجه", ObjectProperty = "NextIndex" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نوع نتیجه", ObjectProperty = "ResultText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ترتیب اعمال", ObjectProperty = "Position" });

            rGridView1.DataBind(EducationalRule.GetRules(Program.CurrentPeriod));
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            EducationalRule rule = new EducationalRule();
            rule.Period = Program.CurrentPeriod;
            frmEducationalRuleDetail frm = new frmEducationalRuleDetail(rule);
            if(!frm.ProcessObject())
                return;
            rule.Save();
            rGridView1.Insert(rule);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            EducationalRule rule = rGridView1.GetSelectedObject<EducationalRule>();
            frmEducationalRuleDetail frm = new frmEducationalRuleDetail(rule);
            if (!frm.ProcessObject())
                return;
            rule.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            EducationalRule rule = rGridView1.GetSelectedObject<EducationalRule>();
            rule.Delete();
            rGridView1.RemoveSelectedRow();
        }
    }
}
