namespace Fakher.Core.DomainModel
{
    public interface IFinancialEntity
    {
        /// <summary>
        /// مقدار شهریه که باید به طور رسمی پرداخت شود
        /// </summary>
        long PayableTuition { get; }
        /// <summary>
        /// مقدار ما به التفاوت شهریه
        /// </summary>
        long TuitionDifference { get; }
        /// <summary>
        /// مقدار شهریه موثر که باید پرداخت شود
        /// </summary>
        long EffectivePayableTuition { get; }
        /// <summary>
        /// بدهی حاصل از کسری پرداخت
        /// </summary>
        long IncompletePayDebtBalance { get; }
        FinancialStatus FinancialStatus { get; }
        int DebtorSign { get; }
        /// <summary>
        /// مبلغ بدهی یعنی بدهی حاصل از کسری پرداخت + بدهی حاصل از چک ها
        /// </summary>
        long DebtAmount { get; }
        string FarsiFinancialStatusText { get; }
        string FarsiFinancialStatusVerboseText { get; }
        string EnglishFinancialStatusText { get; }
        string EnglishFinancialStatusVerboseText { get; }
    }
}