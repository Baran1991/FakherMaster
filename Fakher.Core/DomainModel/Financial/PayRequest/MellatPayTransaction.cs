using System;
using System.Collections;
using System.IO;
using Fakher.Core.BPService;
using rComponents;
using System.Threading;

namespace Fakher.Core.DomainModel
{
    public class MellatPayTransaction : PayTransaction
    {
        private int mMaxTry;
        private int mSleepTime;

        public virtual string ReferenceId { get; set; }
        public virtual long SaleReferenceId { get; set; }
        public virtual string Result { get; set; }

        public MellatPayTransaction()
        {
            mMaxTry = 5;
            mSleepTime = 300;
        }

        public static long TerminalId
        {
            get { return 1493341; }
        }

        public static string TerminalUsername
        {
            get { return "fakhkher"; }
        }

        public static string TerminalPassword
        {
            get { return "22879989"; }
        }

        public static string GatewayUrl
        {
            get { return "https://pgw.bpm.bankmellat.ir/pgwchannel/startpay.mellat"; }
        }

//        public static string CallbackUrl
//        {
//            get { return "http://www.fakher.ac.ir/pageMellatHandler.aspx"; }
//        }

        public virtual void ThrowResultException(string codeText)
        {
            PayException exception = new PayException();
            exception.RawCode = codeText;
            int num = Convert.ToInt32(codeText);
            ResultCode code;
            if (Enum.IsDefined(typeof (ResultCode), num))
                code = (ResultCode) num;
            else
                code = ResultCode.UnknownFailure;
            exception.ResultCode = code;
            throw exception;
        }

        public override void Start(string callbackUrl)
        {
            BypassCertificateError();

            string localDate = StartDate.ToString().Replace("/", "");
            string localTime = StartTime.Replace(":", "");

            using (PaymentGatewayImplService bpService = new PaymentGatewayImplService())
            {
                string result = "-1";

                for (int i = 0; i < mMaxTry; i++)
                {
                    try
                    {
                        result = bpService.bpPayRequest(TerminalId, TerminalUsername, TerminalPassword,
                                                        Id, Amount, localDate, localTime, Description,
                                                        callbackUrl, 0);
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (i == mMaxTry - 1)
                            throw ex;
                        if (mSleepTime != 0)
                            Thread.Sleep(mSleepTime);
                    }
                }

                string[] resultArray = result.Split(',');
                if (resultArray[0] == "0")
                {
                    ReferenceId = resultArray[1];
                }
                else
                {
                    ThrowResultException(resultArray[0]);
                }
            }
            StartDate = PersianDate.Today;
            StartTime = DateTime.Now.ToLongTimeString();
            Status = PayRequestStatus.Started;
        }

        public override void PreTransfer()
        {
            Status = PayRequestStatus.PreTransfer;
        }

        public virtual void Prepare(string referenceId, string resultCode, long orderId, long saleReferenceId)
        {
            if (referenceId.Trim() != ReferenceId.Trim())
                throw new Exception("شناسه مرجع درخواست معتبر نیست.");
            if (orderId != Id)
                throw new Exception("شناسه درخواست پرداخت معتبر نیست.");

            SaleReferenceId = saleReferenceId;
            Result = resultCode;
        }

        public override void PostTransfer(/*string referenceId, string resultCode, long orderId, long saleReferenceId*/)
        {
//            if (referenceId != ReferenceId)
//                throw new Exception("شناسه مرجع درخواست معتبر نیست.");
//            if (resultCode != "0")
//                ThrowResultException(resultCode);
            if (Result != "0")
                ThrowResultException(Result);
//            if (orderId != Id)
//                throw new Exception("شناسه درخواست پرداخت معتبر نیست.");

//            SaleReferenceId = saleReferenceId;
            Status = PayRequestStatus.PostTransfer;

            using (PaymentGatewayImplService bpService = new PaymentGatewayImplService())
            {
                string result = "-1";
                for (int i = 0; i < mMaxTry; i++)
                {
                    try
                    {
                        result = bpService.bpVerifyRequest(TerminalId, TerminalUsername, TerminalPassword,
                                                           Id, Id, SaleReferenceId);
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (i == mMaxTry - 1)
                            throw ex;
                        if (mSleepTime != 0)
                            Thread.Sleep(mSleepTime);
                    }
                }

                if (result != "0")
                    ThrowResultException(result);
            }

            ConfirmDate = PersianDate.Today;
            ConfirmTime = DateTime.Now.ToLongTimeString();
            Status = PayRequestStatus.Verified;
        }

        public override void Complete()
        {
            using (PaymentGatewayImplService bpService = new PaymentGatewayImplService())
            {
                string result = "-1";
                for (int i = 0; i < mMaxTry; i++)
                {
                    try
                    {
                        result = bpService.bpSettleRequest(TerminalId, TerminalUsername, TerminalPassword,
                                                  Id, Id, SaleReferenceId);
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (i == mMaxTry - 1)
                            throw ex;
                        if (mSleepTime != 0)
                            Thread.Sleep(mSleepTime);
                    }
                }

                if (result != "0")
                    ThrowResultException(result);
            }

            foreach (PayTransactionItem item in Items)
            {
                FinancialItem financialItem = item.CreateFinancialItem();
                if (financialItem.Payment != null && financialItem.Payment is ElectronicPayment)
                {
                    (financialItem.Payment as ElectronicPayment).Type = ElectronicPaymentType.InternetPayment;
                    (financialItem.Payment as ElectronicPayment).TraceNumber = SaleReferenceId + "";
                    (financialItem.Payment as ElectronicPayment).TransactionNumber = ReferenceId;
                }

                item.FinancialItem = financialItem;
                item.FinancialDocument.AddItem(financialItem);
            }

            CompleteDate = PersianDate.Today;
            CompleteTime = DateTime.Now.ToLongTimeString();
            Status = PayRequestStatus.Completed;
        }

        public override string Inquiry()
        {
            string result = "-1";
            using (PaymentGatewayImplService bpService = new PaymentGatewayImplService())
            {
                result = bpService.bpInquiryRequest(TerminalId, TerminalUsername, TerminalPassword, Id, Id, SaleReferenceId);

                if (result != "0")
                    ThrowResultException(result);
            }
            return result;
        }

        public override void Reverse()
        {
            using (PaymentGatewayImplService bpService = new PaymentGatewayImplService())
            {
                string result = "-1";
                result = bpService.bpReversalRequest(TerminalId, TerminalUsername, TerminalPassword, Id, Id, SaleReferenceId);
                
                if (result != "0")
                    ThrowResultException(result);
            }

            ReverseDate = PersianDate.Today;
            ReverseTime = DateTime.Now.ToLongTimeString();
            Status = PayRequestStatus.Reversed;
        }
    }

    public enum ResultCode
    {
        [EnumDescription("تراکنش پرداخت انجام نشد")]
        UnknownFailure = -1,
        [EnumDescription("تراكنش با موفقيت انجام شد")]
        Successfull = 0,
        [EnumDescription("شماره كارت نامعتبر است")]
        InvalidCardNumber = 11,
        [EnumDescription("موجودی كافي نيست")]
        LowBalance = 12,
        [EnumDescription("رمز نادرست است")]
        InvalidPassword = 13,
        [EnumDescription("تعداد دفعات وارد كردن رمز بيش از حد مجاز است")]
        PasswordEntryExceeded = 14,
        [EnumDescription("كارت نامعتبر است")]
        InvalidCard = 15,
        [EnumDescription("دفعات برداشت وجه بيش از حد مجاز است")]
        WithdrawCountExceeded = 16,
        [EnumDescription("كاربر از انجام تراكنش منصرف شده است")]
        Canceled = 17,
        [EnumDescription("تاريخ انقضای كارت گذشته است")]
        CardExpired = 18,
        [EnumDescription("مبلغ برداشت وجه بيش از حد مجاز است")]
        WithdrawLimitExceeded = 19,
        [EnumDescription("پذيرنده نامعتبر است")]
        InvalidReceptive = 21,
        [EnumDescription("مبلغ نامعتبر است")]
        InvalidAmount = 25,
        [EnumDescription("پاسخ نامعتبر است")]
        InvalidResponse = 31,
        [EnumDescription("فرمت اطلاعات وارد شده صحيح نمي باشد")]
        InvalidInformationFormat = 32,
        [EnumDescription("حساب نامعتبر است")]
        InvalidAccount = 33,
        [EnumDescription("شناسه درخواست پرداخت اینترنتی تكراری است. مجددا اقدام کنید.")]
        RepeatitiveId = 41,
        [EnumDescription("تراکنش پرداخت وجود ندارد")]
        SaleNotFound = 42,
        [EnumDescription("IP سرور نامعتبر است.")]
        InvalidIP = 421,
        [EnumDescription("زمان جلسه كاری به پايان رسيده است")]
        SessionTimeout = 415,
        [EnumDescription("تعداد دفعات ورود اطلاعات از حد مجاز گذشته است")]
        DataEntryExceeded = 419,
    }
}