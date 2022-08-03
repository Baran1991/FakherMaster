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

namespace Fakher.UI.Educational.Students
{
    public partial class frmPersonUseList : rRadForm
    {
        public frmPersonUseList(Core.DomainModel.Person person)
        {
            InitializeComponent();

            Text = "لیست کتاب های " + person.FarsiFullname;

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "EducationalTool.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "TypeText", TextAlign = HorizontalAlignment.Center});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "قیمت", ObjectProperty = "Price", Type = ColumnType.Money, AggregateSummary = AggregateSummary.Sum });

            rGridView1.DataBind(person.Uses);
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            if (rMessageBox.ShowQuestion("با انجام این عمل، این اطلاعات کامل از سیستم حذف خواهد شد. آیا واقعا مطمئن هستید؟") != DialogResult.Yes)
                return;

            Use use = rGridView1.GetSelectedObject<Use>();
            try
            {
                use.Person.Uses.Remove(use);
                use.Delete();
                rGridView1.RemoveSelectedRow();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
    }
}
