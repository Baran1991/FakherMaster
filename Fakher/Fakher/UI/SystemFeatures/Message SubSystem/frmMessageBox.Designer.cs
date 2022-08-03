namespace Fakher.UI
{
    partial class frmMessageBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rGridViewMessages = new rComponents.rGridView();
            this.messageThreadView1 = new Fakher.Controls.MessageThreadView();
            this.rGroupBox1 = new rComponents.rGroupBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLnkMarkAllRead = new System.Windows.Forms.LinkLabel();
            this.radBtnNewMessage = new Telerik.WinControls.UI.RadButton();
            this.lnkSentBox = new System.Windows.Forms.LinkLabel();
            this.lnkInbox = new System.Windows.Forms.LinkLabel();
            this.rGroupBox2 = new rComponents.rGroupBox(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).BeginInit();
            this.rGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnNewMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).BeginInit();
            this.rGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.rGridViewMessages, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.messageThreadView1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.83499F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.16502F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(665, 387);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // rGridViewMessages
            // 
            this.rGridViewMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rGridViewMessages.CanAdd = false;
            this.rGridViewMessages.CanDelete = false;
            this.rGridViewMessages.CanEdit = true;
            this.rGridViewMessages.CanExport = true;
            this.rGridViewMessages.CanFilter = true;
            this.rGridViewMessages.CanGroup = false;
            this.rGridViewMessages.CanNavigate = true;
            this.rGridViewMessages.CheckBoxes = false;
            this.rGridViewMessages.ColumnAutoSize = true;
            this.rGridViewMessages.ConfirmOnDelete = true;
            this.rGridViewMessages.CustomAddText = null;
            this.rGridViewMessages.CustomDeleteText = null;
            this.rGridViewMessages.CustomEditText = "";
            this.rGridViewMessages.EditOnDoubleClick = true;
            this.rGridViewMessages.FieldName = null;
            this.rGridViewMessages.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGridViewMessages.ItemImage = null;
            this.rGridViewMessages.Location = new System.Drawing.Point(3, 3);
            this.rGridViewMessages.MultiSelect = false;
            this.rGridViewMessages.Name = "rGridViewMessages";
            this.rGridViewMessages.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rGridViewMessages.RowHeight = 25;
            this.rGridViewMessages.ShowBottomToolbar = false;
            this.rGridViewMessages.ShowGroupPanel = true;
            this.rGridViewMessages.ShowTopToolbar = true;
            this.rGridViewMessages.Size = new System.Drawing.Size(659, 186);
            this.rGridViewMessages.TabIndex = 0;
            this.rGridViewMessages.ValidationType = rComponents.ValidationType.None;
            this.rGridViewMessages.Edit += new System.EventHandler(this.rGridViewMessages_Edit);
            this.rGridViewMessages.Delete += new System.EventHandler(this.rGridViewMessages_Delete);
            this.rGridViewMessages.SelectedItemChanged += new System.EventHandler(this.rGridViewMessages_SelectedItemChanged);
            // 
            // messageThreadView1
            // 
            this.messageThreadView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageThreadView1.Location = new System.Drawing.Point(3, 195);
            this.messageThreadView1.Name = "messageThreadView1";
            this.messageThreadView1.Size = new System.Drawing.Size(659, 189);
            this.messageThreadView1.TabIndex = 1;
            // 
            // rGroupBox1
            // 
            this.rGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox1.Controls.Add(this.label2);
            this.rGroupBox1.Controls.Add(this.label1);
            this.rGroupBox1.Controls.Add(this.linkLnkMarkAllRead);
            this.rGroupBox1.Controls.Add(this.radBtnNewMessage);
            this.rGroupBox1.Controls.Add(this.lnkSentBox);
            this.rGroupBox1.Controls.Add(this.lnkInbox);
            this.rGroupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.rGroupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox1.FooterImageIndex = -1;
            this.rGroupBox1.FooterImageKey = "";
            this.rGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox1.HeaderImageIndex = -1;
            this.rGroupBox1.HeaderImageKey = "";
            this.rGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox1.HeaderText = "منوها";
            this.rGroupBox1.Location = new System.Drawing.Point(669, 0);
            this.rGroupBox1.Name = "rGroupBox1";
            this.rGroupBox1.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox1.Size = new System.Drawing.Size(150, 409);
            this.rGroupBox1.TabIndex = 2;
            this.rGroupBox1.Text = "منوها";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 2);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 2);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // linkLnkMarkAllRead
            // 
            this.linkLnkMarkAllRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLnkMarkAllRead.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLnkMarkAllRead.Location = new System.Drawing.Point(6, 150);
            this.linkLnkMarkAllRead.Name = "linkLnkMarkAllRead";
            this.linkLnkMarkAllRead.Size = new System.Drawing.Size(139, 35);
            this.linkLnkMarkAllRead.TabIndex = 3;
            this.linkLnkMarkAllRead.TabStop = true;
            this.linkLnkMarkAllRead.Text = "همه را به عنوان خوانده شده علامت بزن";
            this.linkLnkMarkAllRead.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLnkMarkAllRead_LinkClicked);
            // 
            // radBtnNewMessage
            // 
            this.radBtnNewMessage.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radBtnNewMessage.Location = new System.Drawing.Point(5, 28);
            this.radBtnNewMessage.Name = "radBtnNewMessage";
            this.radBtnNewMessage.Size = new System.Drawing.Size(140, 24);
            this.radBtnNewMessage.TabIndex = 1;
            this.radBtnNewMessage.Text = "ارســال پــیــام جــدیــد";
            this.radBtnNewMessage.Click += new System.EventHandler(this.radBtnNewMessage_Click);
            // 
            // lnkSentBox
            // 
            this.lnkSentBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkSentBox.BackColor = System.Drawing.Color.Transparent;
            this.lnkSentBox.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkSentBox.Location = new System.Drawing.Point(5, 105);
            this.lnkSentBox.Name = "lnkSentBox";
            this.lnkSentBox.Size = new System.Drawing.Size(133, 19);
            this.lnkSentBox.TabIndex = 0;
            this.lnkSentBox.TabStop = true;
            this.lnkSentBox.Text = "صندوق ارسال";
            this.lnkSentBox.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSentBox_LinkClicked);
            // 
            // lnkInbox
            // 
            this.lnkInbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkInbox.BackColor = System.Drawing.Color.Transparent;
            this.lnkInbox.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkInbox.Location = new System.Drawing.Point(5, 79);
            this.lnkInbox.Name = "lnkInbox";
            this.lnkInbox.Size = new System.Drawing.Size(133, 26);
            this.lnkInbox.TabIndex = 0;
            this.lnkInbox.TabStop = true;
            this.lnkInbox.Text = "صندوق دریافت";
            this.lnkInbox.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkInbox_LinkClicked);
            // 
            // rGroupBox2
            // 
            this.rGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rGroupBox2.Controls.Add(this.tableLayoutPanel2);
            this.rGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rGroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rGroupBox2.FooterImageIndex = -1;
            this.rGroupBox2.FooterImageKey = "";
            this.rGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.rGroupBox2.HeaderImageIndex = -1;
            this.rGroupBox2.HeaderImageKey = "";
            this.rGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.rGroupBox2.HeaderText = "rGroupBox2";
            this.rGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.rGroupBox2.Name = "rGroupBox2";
            this.rGroupBox2.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            // 
            // 
            // 
            this.rGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.rGroupBox2.Size = new System.Drawing.Size(669, 409);
            this.rGroupBox2.TabIndex = 3;
            this.rGroupBox2.Text = "rGroupBox2";
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 409);
            this.Controls.Add(this.rGroupBox2);
            this.Controls.Add(this.rGroupBox1);
            this.Name = "frmMessageBox";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "صندوق پیام ها";
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox1)).EndInit();
            this.rGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radBtnNewMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rGroupBox2)).EndInit();
            this.rGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private rComponents.rGridView rGridViewMessages;
        private rComponents.rGroupBox rGroupBox1;
        private System.Windows.Forms.LinkLabel lnkSentBox;
        private System.Windows.Forms.LinkLabel lnkInbox;
        private Telerik.WinControls.UI.RadButton radBtnNewMessage;
        private rComponents.rGroupBox rGroupBox2;
        private System.Windows.Forms.Timer timer1;
        private Fakher.Controls.MessageThreadView messageThreadView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLnkMarkAllRead;
    }
}