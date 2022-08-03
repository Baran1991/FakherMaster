using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using DataAccessLayer;
using Fakher.Core;
using NHibernate;
using NHibernate.Linq;
using rComponents;

namespace FakherSmsService
{
    partial class FakherSmsService : ServiceBase
    {
        private Thread mSMSThread;

        public FakherSmsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            DbContext.InitializeDb();

            mSMSThread = new Thread(StartSmsService);
            mSMSThread.Start();
        }

        protected override void OnStop()
        {
            if (mSMSThread != null)
            {
                mSMSThread.Abort();
            }

            DbContext.CloseDb();
        }

        private void StartSmsService()
        {
            while (true)
            {
                PersianDate today = PersianDate.Today;
                Time now = Time.Now;

                ISession session = DbContext.OpenUnitOfWork();
                var query = from smsGroup in session.Query<SmsGroup>()
                            where smsGroup.SendByService
                                  && smsGroup.Status != SmsGroupStatus.Sent
                                  && smsGroup.SendDate != null
                                  && smsGroup.SendDate == today
                            select smsGroup;
                List<SmsGroup> smsGroups = query.ToList().Where(x => now >= x.SendTime).ToList();

                foreach (SmsGroup smsGroup in smsGroups)
                {
                    ITransaction transaction = session.BeginTransaction();
                    try
                    {
                        SmsPostMaster.Send(smsGroup);

                        smsGroup.Sent();
                        smsGroup.Save();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }

                session.Close();
                Thread.Sleep(60000);
            }
        }
    }
}
