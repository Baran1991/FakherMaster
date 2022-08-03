using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.UI.Educational.Reserves
{
    public partial class frmReserveDetail : rRadDetailForm
    {
        private EducationalCode mEducationalCode;
        private Reserve reserve1;


        public frmReserveDetail(Reserve reserve)
        {
            InitializeComponent();

            radPageView1.SelectedPage = radPageViewPage1;

            studentInfo1.Student = reserve.Student;
            if (reserve.ReserveList.reserveType == ReserveList.ReserveType.ReserveList)
            {
                paymentControl1.Databind(reserve.FinancialDocument, FinancialHeading.ReserveSignup);

            }
            if (reserve.ReserveList.reserveType == ReserveList.ReserveType.LevelDetermination)
            {
                paymentControl1.Databind(reserve.FinancialDocument, FinancialHeading.LevelDeterminationSignup);

            }
            //paymentControl1.Databind(reserve.FinancialDocument, FinancialHeading.ReserveSignup);

            //            ControlMappings.Add(new ControlMapping
            //            {
            //                Control = rTextBox1,
            //                ControlProperty = "Value",
            //                DataObject = reserve,
            //                ObjectProperty = "Code"
            //            });

            mEducationalCode = reserve.EducationalCode;
            reserve1=reserve;
            rTextBox1.Text = reserve.Code;
            
        }

        protected override void AfterBindToObject()
        {
            //Reserve reserve = GetProcessingObject<Reserve>();

            reserve1.EducationalCode = mEducationalCode;
            paymentControl1.BindToObject();
            foreach (FinancialItem item in reserve1.FinancialDocument.Items)
                Program.CurrentEmployee.RegisterItem(item);
        }

        private void lnkNewCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Reserve reserve = GetProcessingObject<Reserve>();
            if (rMessageBox.ShowQuestion("از انتساب شماره رزرو جدید مطمئن هستید؟") != DialogResult.Yes)
                return;
            mEducationalCode = reserve1.Student.GenerateCode(reserve1.ReserveList.Period, reserve1.ReserveList.Major, true);
            rTextBox1.Text = mEducationalCode.Code;
        }
    }
}
