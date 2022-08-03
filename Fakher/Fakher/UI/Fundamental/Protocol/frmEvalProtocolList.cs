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
using rComponents;

namespace Fakher.UI
{
    public partial class frmEvalProtocolList : rRadForm
    {
        public frmEvalProtocolList()
        {
            InitializeComponent();
            rGridView1.Mappings.Add(new ColumnMapping{ Caption = "نام آیین نامه", ObjectProperty = "Name"});
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تعداد گروه ارزشیابی", ObjectProperty = "EvaluationGroups.Count" });
//            rGridView1.DataBind(DbContext.GetAllEntities<EvaluationProtocol>());
            rGridView1.DataBind(EvaluationProtocol.GetProtocols(Program.CurrentPeriod));
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            EvaluationProtocol protocol = new EvaluationProtocol();
            protocol.Period = Program.CurrentPeriod;
            frmEvalProtocolDetail frm = new frmEvalProtocolDetail(protocol);
            if(frm.ShowDialog(this) != DialogResult.OK)
                return;
            protocol.Save();
            rGridView1.Insert(protocol);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            EvaluationProtocol protocol = rGridView1.GetSelectedObject<EvaluationProtocol>();
            frmEvalProtocolDetail frm = new frmEvalProtocolDetail(protocol);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            protocol.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            try { 
            EvaluationProtocol protocol = rGridView1.GetSelectedObject<EvaluationProtocol>();
                if(!protocol.CanDelete())
                {
                    rMessageBox.ShowError("بدلیل ارتباط با اطلاعات دیگر، حذف امکان پذیر نمیباشد!");
                    return;
                }
            protocol.Delete();
            rGridView1.RemoveSelectedRow();
            }
           catch(SqlException ex)
            {
                rMessageBox.ShowError(ex.Message+":"+ex.Number);
                return;
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
    }
}
