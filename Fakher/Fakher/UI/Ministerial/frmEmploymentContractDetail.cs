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

namespace Fakher.UI.Ministerial
{
    public partial class frmEmploymentContractDetail : rRadDetailForm
    {
        public frmEmploymentContractDetail(EmploymentContract contract)
        {
            InitializeComponent();

            radPageView1.SelectedPage = radPageViewPage1;

            rCmbBasePaymentSystem.DataSource = typeof (PaymentSystem).GetEnumDescriptions();
            rCmbPaymentType.DataSource = typeof (RateType).GetEnumDescriptions();
            rCmbInsCalType.DataSource = typeof (CalculationType).GetEnumDescriptions();
            rCmbTaxCalType.DataSource = typeof (CalculationType).GetEnumDescriptions();

//            rGridCmbMajor.Columns.Add("رشته", "رشته", "Name");
//            rGridCmbMajor.Columns.Add("دپارتمان", "دپارتمان", "Department.Name");

            rGridCmbSalaryRate.Columns.Add("نام", "نام", "Name");
//            rGridCmbSalaryRate.Columns.Add("ترم", "ترم", "Period.Name");

//            if(contract.Period != null)
//            {
//                majorSelector1.Databind(contract.Period.Department.Majors);
//                rGridComboBox1.DataSource = SalaryRateProtocol.GetProtocols(contract.Period);
//            }

//            rGridCmbMajor.DataSource = Major.GetAllMajors().Where(x => x.Department != null);
            rGridCmbSalaryRate.DataSource = SalaryRateProtocol.GetAllProtocols();

            #region Control Mappings
//            ControlMappings.Add(new ControlMapping
//                                    {
//                                        Control = rGridCmbMajor,
//                                        ControlProperty = "Value",
//                                        DataObject = contract,
//                                        ObjectProperty = "Major"
//                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rDatePicker1,
                                        ControlProperty = "Date",
                                        DataObject = contract,
                                        ObjectProperty = "StartDate"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rDatePicker2,
                                        ControlProperty = "Date",
                                        DataObject = contract,
                                        ObjectProperty = "EndDate"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rCmbBasePaymentSystem,
                                        ControlProperty = "SelectedIndex",
                                        DataObject = contract,
                                        ObjectProperty = "PaymentSystem"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rCmbPaymentType,
                                        ControlProperty = "SelectedIndex",
                                        DataObject = contract,
                                        ObjectProperty = "RateType"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox1,
                                        ControlProperty = "Value",
                                        DataObject = contract,
                                        ObjectProperty = "BaseAmount"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rGridCmbSalaryRate,
                                        ControlProperty = "Value",
                                        DataObject = contract,
                                        ObjectProperty = "RateProtocol"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox10,
                                        ControlProperty = "Value",
                                        DataObject = contract,
                                        ObjectProperty = "Notes"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox2,
                                        ControlProperty = "Value",
                                        DataObject = contract,
                                        ObjectProperty = "OverTimeFee"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox3,
                                        ControlProperty = "Value",
                                        DataObject = contract,
                                        ObjectProperty = "OverTimeRewardPercent"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox4,
                                        ControlProperty = "Value",
                                        DataObject = contract,
                                        ObjectProperty = "HolidayOverTimeFee"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox5,
                                        ControlProperty = "Value",
                                        DataObject = contract,
                                        ObjectProperty = "HolidayOverTimeRewardPercent"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rCmbInsCalType,
                                        ControlProperty = "SelectedIndex",
                                        DataObject = contract,
                                        ObjectProperty = "InsuranceCalculationType"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox7,
                                        ControlProperty = "Value",
                                        DataObject = contract,
                                        ObjectProperty = "InsuranceBase"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox6,
                                        ControlProperty = "Value",
                                        DataObject = contract,
                                        ObjectProperty = "InsurancePercent"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rCmbTaxCalType,
                                        ControlProperty = "SelectedIndex",
                                        DataObject = contract,
                                        ObjectProperty = "TaxCalculationType"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox8,
                                        ControlProperty = "Value",
                                        DataObject = contract,
                                        ObjectProperty = "TaxBase"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox9,
                                        ControlProperty = "Value",
                                        DataObject = contract,
                                        ObjectProperty = "TaxPercent"
                                    });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxAyab,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "AyabZahabUnit"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxAyabPrice,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "AyabZahab"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxKharBarPrice,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "KharBar"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxKharBar,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "KharBarUnit"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxMaskanPrice,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "Maskan"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxMaskan,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "MaskanUnit"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxSanavatPrice,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "Sanavat"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxSanavat,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "SanavatUnit"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxTaaholPrice,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "Taahol"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxTaahol,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "TaaholUnit"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxNaharPrice,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "Nahar"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxNahar,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "NaharUnit"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxExamMinPrice,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "ExamMin"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxExamMin,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "ExamMinUnit"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxExamFinalPrice,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "ExamFinal"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxExamFinal,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "ExamFinalUnit"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxExamSayerPrice,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "ExamOther"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxExamSayer,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "ExamOtherUnit"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxMosahebePrice,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "Mosahebe"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBoxMosahebe,
                ControlProperty = "Value",
                DataObject = contract,
                ObjectProperty = "MosahebeUnit"
            });
            //            ControlMappings.Add(new ControlMapping
            //                                    {
            //                                        Control = rTextBox14,
            //                                        ControlProperty = "Value",
            //                                        DataObject = contract,
            //                                        ObjectProperty = "TermHistory"
            //                                    });
            //            ControlMappings.Add(new ControlMapping
            //                                    {
            //                                        Control = rTextBox25,
            //                                        ControlProperty = "Value",
            //                                        DataObject = contract,
            //                                        ObjectProperty = "YearHistory"
            //                                    });
            //            ControlMappings.Add(new ControlMapping
            //                                    {
            //                                        Control = rTextBox26,
            //                                        ControlProperty = "Value",
            //                                        DataObject = contract,
            //                                        ObjectProperty = "TeachingHoursHistory"
            //                                    });
            #endregion

            rGridCmbSalaryRate.Enabled = rCmbPaymentType.SelectedIndex == 1;
        }

        private void rCmbPaymentType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
//            rTextBox1.Enabled = rCmbPaymentType.SelectedIndex == 0;
            rGridCmbSalaryRate.Enabled = rCmbPaymentType.SelectedIndex == 1;
        }

        private void rCmbInsCalType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (rCmbInsCalType.SelectedIndex == 0)
            {
                rTextBox6.Enabled = true;
                rTextBox7.Enabled = false;
            }
            if (rCmbInsCalType.SelectedIndex == 1)
            {
                rTextBox6.Enabled = true;
                rTextBox7.Enabled = true;
            }
            if (rCmbInsCalType.SelectedIndex == 2)
            {
                rTextBox6.Enabled = false;
                rTextBox7.Enabled = true;
            }
            if (rCmbInsCalType.SelectedIndex == 3)
            {
                rTextBox6.Enabled = false;
                rTextBox7.Enabled = false;
            }
        }

        private void rCmbTaxCalType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (rCmbTaxCalType.SelectedIndex == 0)
            {
                rTextBox9.Enabled = true;
                rTextBox8.Enabled = false;
            }
            if (rCmbTaxCalType.SelectedIndex == 1)
            {
                rTextBox9.Enabled = true;
                rTextBox8.Enabled = true;
            }
            if (rCmbTaxCalType.SelectedIndex == 2)
            {
                rTextBox9.Enabled = false;
                rTextBox8.Enabled = true;
            }
            if (rCmbTaxCalType.SelectedIndex == 3)
            {
                rTextBox9.Enabled = false;
                rTextBox8.Enabled = false;
            }
        }

        private void rGridCmbSalaryRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var salaryRateProtocol = rGridCmbSalaryRate.SelectedValue as SalaryRateProtocol;
            //var salaryItems =DbContext.GetAllEntities<SalaryRateItem>().Where(m=>m.Protocol.Id==salaryRateProtocol.Id);
            //foreach(var item in salaryItems)
            //{
            //    Label lbl = new Label();
            //    lbl.Text = item.SalaryCondition.ToDescription();
            //    radPageViewPage4.Controls.Add(lbl);
            //}
        }
    }
}
