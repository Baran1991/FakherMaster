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

namespace Fakher.UI.Fundamental.Protocol
{
    public partial class frmSalaryRateProtocolList : rRadForm
    {
        public frmSalaryRateProtocolList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام آیین نامه", ObjectProperty = "Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تعداد آیتم", ObjectProperty = "Items.Count" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تــرم", ObjectProperty = "Period.Name" });

//            rGridView1.DataBind(SalaryRateProtocol.GetProtocols(Program.CurrentPeriod));
            rGridView1.DataBind(SalaryRateProtocol.GetAllProtocols());
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
//            SalaryRateProtocol protocol = new SalaryRateProtocol { Period = Program.CurrentPeriod};
            SalaryRateProtocol protocol = new SalaryRateProtocol();
            frmSalaryRateProtocolDetail frm = new frmSalaryRateProtocolDetail(protocol);
            if(!frm.ProcessObject())
                return;
            protocol.Save();
            rGridView1.Insert(protocol);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            SalaryRateProtocol protocol = rGridView1.GetSelectedObject<SalaryRateProtocol>();
            frmSalaryRateProtocolDetail frm = new frmSalaryRateProtocolDetail(protocol);
            if (!frm.ProcessObject())
                return;
            protocol.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            SalaryRateProtocol protocol = rGridView1.GetSelectedObject<SalaryRateProtocol>();

            IList<Contract> contracts = Contract.GetContracts(protocol);
            string name = "";
            foreach (Contract contract in contracts)
            {
                if(contract.Staff != null)
                    name += contract.Staff.FarsiFullname + " - ";
                else
                {
                    contract.RateProtocol = null;
                    contract.Save();
                }
            }

            if (!string.IsNullOrEmpty(name))
            {
                rMessageBox.ShowWarning(
                    "این آیین نامه دستمزد در قرارداد [{0}] بکار رفته است. ابتدا آنها را ویرایش کنید.", name);
                return;
            }

            protocol.Delete();
            rGridView1.RemoveSelectedRow();
        }
    }
}
