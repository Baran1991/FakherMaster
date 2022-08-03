using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Message = Fakher.Core.DomainModel.Message;

namespace Fakher.Controls
{
    public partial class MessageThreadView : UserControl
    {

        public MessageThreadView()
        {
            InitializeComponent();
        }

        public void Fill(Message message)
        {
            flowLayoutPanel1.Controls.Clear();

            IList<Message> threadMessages = message.GetThreadMessages().ToList();
            foreach (Message threadMessage in threadMessages)
                AddMessageView(threadMessage);
        }

        private void AddMessageView(Message message)
        {
            MessageView messageView = new MessageView();
            messageView.Fill(message);
            messageView.Width = flowLayoutPanel1.Width - 30;
            messageView.Refresh();
            flowLayoutPanel1.Controls.Add(messageView);
        }

        private void MessageThreadView_Load(object sender, EventArgs e)
        {

        }
    }
}
