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
    public partial class frmRegisterQuits : rRadForm
    {
        private Register register;

        public frmRegisterQuits(Register register)
        {
            InitializeComponent();

            this.register = register;

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Code", TextAlign = HorizontalAlignment.Center });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره انصرافی", ObjectProperty = "Quit.Code", TextAlign = HorizontalAlignment.Center });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "دوره/ترم آموزشی", ObjectProperty = "Period.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "دپارتمان", ObjectProperty = "Major.Department.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FarsiFinancialStatusVerboseText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت آموزشی", ObjectProperty = "StatusText" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت نام", ObjectProperty = "RegisterDate" });

//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس", ObjectProperty = "Lesson.Name" });
//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کلاس", ObjectProperty = "Holding.Name" });

//            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شماره انصراف", ObjectProperty = "Quit.Id" });
//            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ انصراف", ObjectProperty = "Quit.Date" });
//            rGridView2.Mappings.Add(new ColumnMapping { Caption = "درس", ObjectProperty = "Lesson.Name" });
//            rGridView2.Mappings.Add(new ColumnMapping { Caption = "کلاس", ObjectProperty = "Holding.Name" });
//            rGridView2.Mappings.Add(new ColumnMapping { Caption = "علت", ObjectProperty = "Quit.Reason" });

            if (register.Type == RegisterType.FullQuited)
                rGridView1.DataBind(new[] {register});
//            rGridView2.DataBind(register.GetParticipates(ParticipateStatus.Quited));
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Register register = rGridView1.GetSelectedObject<Register>();
            if(register.Quit == null)
            {
                rMessageBox.ShowError("امکان ویرایش انصراف این دانشجو وجود ندارد.");
                return;
            }
            frmQuitDetail frm = new frmQuitDetail(register.Quit, register.FinancialDocument);
            if(!frm.ProcessObject())
                return;

//            register.Quit.PenaltyFee = register.FinancialDocument.PayedBalance - register.Quit.FinancialItem.Amount;
            register.Save();
            rGridView1.UpdateGridView();

            /*
            Participate participate = rGridView1.GetSelectedObject<Participate>();
            if(participate.Status != ParticipateStatus.Quited)
            {
                Quit quit = new Quit();
                frmQuitDetail frm = new frmQuitDetail(quit, participate.Register.FinancialDocument);
                if(!frm.ProcessObject())
                    return;
                quit.PenaltyFee = participate.TuitionFee - quit.FinancialItem.Amount;
                participate.Quit = quit;
                participate.Save();
                rGridView1.RemoveSelectedRow();
                rGridView2.Insert(participate);
            }
             */
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            if(rMessageBox.ShowQuestion("با حذف انصراف این دانشجو، باید دوباره او را کلاس بندی کنید. آیا موافق هستید؟") != DialogResult.Yes)
                return;

            Register register = rGridView1.GetSelectedObject<Register>();
            Quit quit = register.Quit;
            
            register.Quit = null;
            register.Type = RegisterType.Participation;
            register.Participates.Clear();

            if(quit != null)
                quit.Delete();
            register.Save();
            rGridView1.UpdateGridView();

            /*
            Quit quit = new Quit();
            frmQuitDetail frm = new frmQuitDetail(quit, register.FinancialDocument);
            if(!frm.ProcessObject())
                return;

            long returnedAmount = quit.FinancialItem.Amount / register.Participates.Count;

            foreach (Participate participate in register.Participates)
            {
                participate.PerformQuit(quit.Date, returnedAmount, quit.Reason);
//                Quit newQuit = quit.Clone();
//                newQuit.FinancialItem.Amount = returnedAmount;
//                newQuit.PenaltyFee = participate.TuitionFee - newQuit.FinancialItem.Amount;
//                if (newQuit.PenaltyFee < 0)
//                    throw new Exception("مقدار جریمه انصراف منفی شده است.");
//                participate.Quit = newQuit;
            }
            
            register.Type = RegisterType.FullQuited;
            register.Save();

            foreach (Participate participate in rGridView1.DataSource)
            {
                rGridView1.RemoveSelectedRow();
                rGridView2.Insert(participate);
            }
             */
        }
    }
}
