using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.UI.Educational.Students;
using rComponents;

namespace Fakher.UI.Financial
{
    public partial class frmOutHistoryList : rRadForm
    {
        public frmOutHistoryList(Student student)
        {
            InitializeComponent();
            SetProcessingObject(student);
            rGridViewQuits.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Code", TextAlign = HorizontalAlignment.Center });
            rGridViewQuits.Mappings.Add(new ColumnMapping { Caption = "شماره انصرافی", ObjectProperty = "Quit.Code", TextAlign = HorizontalAlignment.Center });
            rGridViewQuits.Mappings.Add(new ColumnMapping { Caption = "دوره/ترم آموزشی", ObjectProperty = "Period.Name" });
            rGridViewQuits.Mappings.Add(new ColumnMapping { Caption = "دپارتمان", ObjectProperty = "Major.Department.Name" });
            rGridViewQuits.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major.Name" });
            rGridViewQuits.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "FarsiFinancialStatusVerboseText" });
            rGridViewQuits.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "Quit.StatusText" });
            rGridViewQuits.Mappings.Add(new ColumnMapping { Caption = "تاریخ ثبت نام", ObjectProperty = "RegisterDate" });
            rGridViewQuits.CustomButtons.Add(new rGridViewButton { VisibleOnSelect = true, Text = "چاپ رسید", Position = rGridViewButtonPosition.After });
            List<Register> quitRegisters = new List<Register>();
            foreach (Register register in student.Registers)
            {
                if (register.Type == RegisterType.FullQuited)
                    quitRegisters.Add(register);
            }
            rGridViewQuits.DataBind(quitRegisters);

        }

        private void rGridViewQuits_Edit(object sender, EventArgs e)
        {
            Register register = rGridViewQuits.GetSelectedObject<Register>();
            if (register.Quit == null)
            {
                rMessageBox.ShowError("امکان ویرایش انصراف این دانشجو وجود ندارد.");
                return;
            }
            frmQuitDetail frm = new frmQuitDetail(register.Quit, register.FinancialDocument);
            if (!frm.ProcessObject())
                return;

            register.Save();
            rGridViewQuits.UpdateGridView();

            Program.SaveLog(string.Format("ویرایش انصراف [{0}]", register.ToString()));
        }

        private void rGridViewQuits_Delete(object sender, EventArgs e)
        {
            if (rMessageBox.ShowQuestion("با حذف انصراف این دانشجو، باید دوباره او را کلاس بندی کنید. آیا موافق هستید؟") != DialogResult.Yes)
                return;

            Register register = rGridViewQuits.GetSelectedObject<Register>();
            Quit quit = register.Quit;

            register.Quit = null;
            register.Type = RegisterType.Participation;
            register.Participates.Clear();

            if (quit != null)
                quit.Delete();
            register.Save();
            rGridViewQuits.UpdateGridView();

            Program.SaveLog(string.Format("حذف انصراف [{0}]", register.ToString()));
        }

    }
}
