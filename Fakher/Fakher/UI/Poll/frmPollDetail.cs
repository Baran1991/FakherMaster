using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel.Poll;
using rComponents;

namespace Fakher.UI.Poll
{
    public partial class frmPollDetail : rRadDetailForm
    {
        public frmPollDetail(Core.DomainModel.Poll.Poll poll)
        {
            InitializeComponent();
            SetProcessingObject(poll);

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "عنوان", ObjectProperty = "Text" });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTxtName,
                                        ControlProperty = "Text",
                                        DataObject = poll,
                                        ObjectProperty = "Name"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTxtText,
                                        ControlProperty = "Text",
                                        DataObject = poll,
                                        ObjectProperty = "Text"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rDatePickerStart,
                                        ControlProperty = "Date",
                                        DataObject = poll,
                                        ObjectProperty = "StartDate"
                                    });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox1,
                ControlProperty = "Text",
                DataObject = poll,
                ObjectProperty = "StartTime"
            });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rCheckBox1,
                                        ControlProperty = "Checked",
                                        DataObject = poll,
                                        ObjectProperty = "HasEnd"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rDatePickerFinish,
                                        ControlProperty = "Date",
                                        DataObject = poll,
                                        ObjectProperty = "EndDate"
                                    });
            ControlMappings.Add(new ControlMapping
            {
                Control = rTextBox2,
                ControlProperty = "Text",
                DataObject = poll,
                ObjectProperty = "EndTime"
            });

            rDatePickerFinish.Enabled = poll.HasEnd;
            rGridView1.DataBind(poll.Items);
        }

        protected override void AfterValidate()
        {
            if(rCheckBox1.Checked && rDatePickerFinish.Date == null)
            {
                rMessageBox.ShowWarning("تاریخ پایان نظرسنجی را مشخص کنید.");
                CancelClosing();
                return;
            }
        }

        protected override void AfterBindToObject()
        {
            Core.DomainModel.Poll.Poll poll = GetProcessingObject<Core.DomainModel.Poll.Poll>();
            poll.Items.SyncWith(rGridView1.DataSource);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Core.DomainModel.Poll.Poll poll = GetProcessingObject<Core.DomainModel.Poll.Poll>();
            
            PollItem item = new PollItem { Poll = poll };
            frmPollItemDetail frm = new frmPollItemDetail(item);
            if (!frm.ProcessObject())
                return;
            rGridView1.Insert(item);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            PollItem item = rGridView1.GetSelectedObject<PollItem>();
            frmPollItemDetail frm = new frmPollItemDetail(item);
            if (!frm.ProcessObject())
                return;
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            PollItem item = rGridView1.GetSelectedObject<PollItem>();
            rGridView1.RemoveSelectedRow();
        }

        private void rCheckBox1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rDatePickerFinish.Enabled = rCheckBox1.Checked;
        }
    }
}
