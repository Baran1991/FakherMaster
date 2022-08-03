using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Reports;
using Fakher.UI.Report;

namespace Fakher.Controls
{
    public partial class MessageView : UserControl
    {
        private Core.DomainModel.Message mMessage;

        public MessageView()
        {
            InitializeComponent();
        }

        public void Fill(Core.DomainModel.Message message)
        {
            mMessage = message;
            rLblSubject.Text = message.Subject;
            rLblFrom.Text = message.Sender.MessageAddress;
            rLblTo.Text = message.ReceiverText;
            rTextBox1.Text = message.Body;
        }

        private void lnkPrint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rptMessage rpt = new rptMessage();
            rpt.DataSource = mMessage;
            frmReportViewer frm = new frmReportViewer(rpt) { AutoPrint = true};
            frm.ShowDialog(this);
        }
    }
}
