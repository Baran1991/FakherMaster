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
using rComponents;

namespace Fakher.UI.Educational.Students
{
    public partial class frmRefund : rRadForm
    {
        

        public frmRefund()
        {
            InitializeComponent();

            rGroupBox1.Text = "سررسید انصرافی ها: " + PersianDate.Today.ToString();
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Code", TextAlign = HorizontalAlignment.Center });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره انصرافی", ObjectProperty = "Quit.Code", TextAlign = HorizontalAlignment.Center });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "دوره/ترم آموزشی", ObjectProperty = "Period.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "دپارتمان", ObjectProperty = "Major.Department.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FarsiFinancialStatusVerboseText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت آموزشی", ObjectProperty = "StatusText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت نام", ObjectProperty = "RegisterDate" });

            var list = DbContext.Entity<Register>().Where(m => m.Type == RegisterType.FullQuited && m.Quit.RefundDate == PersianDate.Today).ToList();


            
                rGridView1.DataBind(list);
//            rGridView2.DataBind(register.GetParticipates(ParticipateStatus.Quited));
        }

    }
}
