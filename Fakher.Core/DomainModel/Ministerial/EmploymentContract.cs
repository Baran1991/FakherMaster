using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DataAccessLayer;
using rComponents;

namespace Fakher.Core.DomainModel
{
    public class EmploymentContract : Contract
    {

        public EmploymentContract()
        {
        }

        [NonPersistent]
        public virtual Employee Employee
        {
            get { return Staff as Employee; }
        }

        [NonPersistent]
        public override string Text
        {
            get { return "قرارداد همکاری " + Employee.FarsiFullname; }
        }

        public override void PreCalculate(PayrollContract payrollContract)
        {

        }

        public override void Calculate(PayrollContract payrollContract)
        {
            if (PaymentSystem == PaymentSystem.Fixed)
            {
                PayrollItem payrollItem = new PayrollItem();
                payrollItem.FinancialType = FinancialType.Credit;
                payrollItem.Heading = PayrollItemHeading.Working;
                payrollItem.Text = payrollContract.StartDate + " الی " + payrollContract.EndDate;
                payrollItem.Description = "حقوق پایه " + payrollContract.StartDate + " الی " + payrollContract.EndDate; ;
                payrollItem.Unit = "دوره";
                payrollItem.Count = 1;
                if (BaseAmount > 0)
                    payrollItem.AddRateElements(new[]
                                                    {
                                                        new RateElement
                                                            {
                                                                Condition = SalaryCondition.BasePayment,
                                                                Amount = BaseAmount,
                                                                Text = "نرخ پایه",
                                                                Value = BaseAmount.ToString("C0")
                                                            }
                                                    });

                //                RateElement[] rateElements = CalculateRateElements(ElementCalculationType.SectionCalculation, payrollContract.StartDate, payrollContract.EndDate);
                //                payrollItem.AddRateElements(rateElements);
                payrollItem.Fee = payrollItem.RateElements.Sum(x => x.Amount);

                payrollContract.AddItem(payrollItem);
            }

            // اضافه کاری
            // بیمه و مالیات
            //            OnProgress();
            if (InsuranceCalculationType != CalculationType.NoCalculation)
            {
                PayrollItem payrollItem = new PayrollItem();
                payrollItem.FinancialType = FinancialType.Debt;
                payrollItem.Heading = PayrollItemHeading.Insurance;
                payrollItem.Text = "بیمه";
                payrollItem.Description = "بیمه";
                payrollItem.Unit = "دوره";
                payrollItem.Count = 1;
                float fee = 0;
                if (InsuranceCalculationType == CalculationType.ByFixedAmount)
                {
                    fee = ((float)InsuranceBase * InsurancePercent) / 100;
                }
                else if (InsuranceCalculationType == CalculationType.BySalary)
                {
                    var query = from item in payrollContract.Items
                                where item.Heading == PayrollItemHeading.Working
                                      && item.FinancialType == FinancialType.Credit
                                select item.Amount;
                    float salary = query.Sum();
                    fee = (salary * InsurancePercent) / 100;
                }
                else if (InsuranceCalculationType == CalculationType.ExactAmount)
                {
                    fee = InsuranceBase;
                }
                payrollItem.Fee = fee;
                payrollContract.AddItem(payrollItem);
            }

            //            OnProgress();
            if (TaxCalculationType != CalculationType.NoCalculation)
            {
                PayrollItem payrollItem = new PayrollItem();
                payrollItem.FinancialType = FinancialType.Debt;
                payrollItem.Heading = PayrollItemHeading.Tax;
                payrollItem.Text = "مالیات";
                payrollItem.Description = "مالیات";
                payrollItem.Unit = "دوره";
                payrollItem.Count = 1;
                float fee = 0;
                if (TaxCalculationType == CalculationType.ByFixedAmount)
                {
                    fee = ((float)TaxBase * TaxPercent) / 100;
                }
                else if (TaxCalculationType == CalculationType.BySalary)
                {
                    var query = from item in payrollContract.Items
                                where item.Heading == PayrollItemHeading.Working
                                      && item.FinancialType == FinancialType.Credit
                                select item.Amount;
                    float salary = query.Sum();
                    fee = (salary * TaxPercent) / 100;
                }
                else if (TaxCalculationType == CalculationType.ExactAmount)
                {
                    fee = TaxBase;
                }
                payrollItem.Fee = fee;
                payrollContract.AddItem(payrollItem);
            }
        }

        public virtual RateElement[] CalculateRateElements(ElementCalculationType calculationType, PersianDate calculationStartDate, PersianDate calculationEndDate)
        {
            if (RateType == RateType.Fixed)
                return new[] { new RateElement { Text = "نرخ ثابت", Amount = BaseAmount } };
            if (RateType == RateType.ByProtocol)
                return RateProtocol.CalculateRate(this, calculationType, calculationStartDate, calculationEndDate);
            throw new Exception("مقدار دستمزد قابل محاسبه نیست.");
        }
    }
}