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

namespace Fakher.UI.Financial
{
    public partial class frmElectronicPaymentDetail : rRadDetailForm
    {
        public frmElectronicPaymentDetail(ElectronicPayment payment)
        {
            InitializeComponent();

            rGridCmbBankAccounts.Columns.Add("بانک", "بانک", "BankName");
            rGridCmbBankAccounts.DataSource = BankAccount.GetPOSAccounts();

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rDatePicker1,
                                        ControlProperty = "Date",
                                        DataObject = payment,
                                        ObjectProperty = "Date"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox4,
                                        ControlProperty = "Value",
                                        DataObject = payment,
                                        ObjectProperty = "Amount"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox2,
                                        ControlProperty = "Text",
                                        DataObject = payment,
                                        ObjectProperty = "CardNumber"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox1,
                                        ControlProperty = "Text",
                                        DataObject = payment,
                                        ObjectProperty = "TraceNumber"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox3,
                                        ControlProperty = "Text",
                                        DataObject = payment,
                                        ObjectProperty = "TransactionNumber"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rGridCmbBankAccounts,
                                        ControlProperty = "Value",
                                        DataObject = payment,
                                        ObjectProperty = "Item.BankAccount"
                                    });
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
        }

        private void btnOk_MouseDown(object sender, MouseEventArgs e)
        {
var transCode = rTextBox3.Text;
            var traceCode = rTextBox1.Text;
            var payment = DbContext.GetAllEntities<ElectronicPayment>();
            var lst = payment.Where(m => m.TransactionNumber == transCode & m.TraceNumber == traceCode);
            if (lst.Any())
            {
                rMessageBox.ShowError("شماره پیگیری و شماره تراکنش تکراری است!");
               
                return ;
            }
        }
    }
}
