using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Educational.Reserves
{
    public partial class frmLevelDeterminationDetail : rRadDetailForm
    {
        private EducationalCode mEducationalCode;

        public frmLevelDeterminationDetail(Reserve reserve)
        {
            InitializeComponent();

            radPageView1.SelectedPage = radPageViewPage1;

            studentInfo1.Student = reserve.Student;
            paymentControl1.Databind(reserve.FinancialDocument, FinancialHeading.ReserveSignup);

//            ControlMappings.Add(new ControlMapping
//            {
//                Control = rTextBox1,
//                ControlProperty = "Value",
//                DataObject = reserve,
//                ObjectProperty = "Code"
//            });

            mEducationalCode = reserve.EducationalCode;
            rTextBox1.Text = reserve.Code;
        }

        protected override void AfterBindToObject()
        {
            Reserve reserve = GetProcessingObject<Reserve>();

            reserve.EducationalCode = mEducationalCode;
            paymentControl1.BindToObject();
            foreach (FinancialItem item in reserve.FinancialDocument.Items)
                Program.CurrentEmployee.RegisterItem(item);
        }

        private void lnkNewCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reserve reserve = GetProcessingObject<Reserve>();
            if (rMessageBox.ShowQuestion("از انتساب شماره رزرو جدید مطمئن هستید؟") != DialogResult.Yes)
                return;
            mEducationalCode = reserve.Student.GenerateCode(reserve.ReserveList.Period, reserve.ReserveList.Major, true);
            rTextBox1.Text = mEducationalCode.Code;
        }
    }
}
