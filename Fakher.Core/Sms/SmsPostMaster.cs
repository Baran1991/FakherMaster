using System;
using System.Collections.Generic;
using System.Linq;
using Fakher.Core.ir.afe.www;
using Fakher.Core.v1.ir.afe.www;
using rComponents;

namespace Fakher.Core
{
    public static class SmsPostMaster
    {
        private static string Sender
        {
            get { return "30007957959868"; }
        }

        private static string Username
        {
            get { return "m_fakher"; }
        }

        private static string Password
        {
            get { return "6479144"; }
        }
        
        public static int SmsPrice
        {
            get { return 120; }
        }

        public static bool CanSendSms()
        {
            long credit = GetRemainingCredit();
            return credit >= SmsPrice;
        }

        public static long GetRemainingCredit()
        {
            WebService webService = new WebService();
            string remainingCredit = webService.GetRemainingCredit(Username, Password);
            return Convert.ToInt64(remainingCredit);
        }

        /// <summary>
        /// Save smsGroup after this method Call
        /// </summary>
        /// <param name="smsGroup"></param>
        public static void Send(SmsGroup smsGroup)
        {
            List<Sms> smses = new List<Sms>();
            for (int i = 0; i < smsGroup.Smses.Count; i++)
            {
                Sms iSms = smsGroup.Smses[i];
                if (i != 0 && i%85 == 0)
                {
                    Send(smses, smsGroup.Text);
                    smses.Clear();
                }
                smses.Add(iSms);
            }

            if (smses.Count > 0)
                Send(smses, smsGroup.Text);

            smsGroup.Status = SmsGroupStatus.Sent;
        }

        private static void Send(List<Sms> smses, string text)
        {
            List<string> numbers = new List<string>();
            foreach (Sms sms in smses)
                numbers.Add(sms.Number);


//            BoxService service = new BoxService();
//            string[] results = service.SendMessage(Username, Password, Sender, numbers.ToArray(), text, "1");
            string[] results = Send(text, numbers.ToArray());

            for (int i = 0; i < results.Length; i++)
            {
                string code = results[i];
                Sms sms = smses[i];

                sms.Sent(code);
            }
        }

        /// <summary>
        /// CAUTION: Limit numbers to 85
        /// </summary>
        /// <param name="text"></param>
        /// <param name="numbers">Limit numbers to 85</param>
        /// <returns></returns>
        public static string[] Send(string text, params string[] numbers)
        {
            BoxService service = new BoxService();
            string[] results = service.SendMessage(Username, Password, Sender, numbers.ToArray(), text, "1");
            return results;
        }

    }
}