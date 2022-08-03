using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using NHibernate;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace rComponents
{
    public partial class rRadForm : RadForm
    {
        private object mProcessingObject;
        private bool mEscapePressed;

        public bool AutoOpenUnitOfWork { get; set; }
        public bool AutoCloseUnitOfWork { get; set; }
        public bool IsChild { get; set; }
        public bool IsShowed { get; private set; }
        public ISession DbSession { get; set; }

        public event EventHandler<FormShowingEventArgs> ChildShowing;
        public event EventHandler<FormShowingEventArgs> DialogShowing;
        public event EventHandler<FormShowingEventArgs> ChildClosing;

        public rRadForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            Shown += new EventHandler(rRadForm_Shown);
            AutoOpenUnitOfWork = false;
            AutoCloseUnitOfWork = true;
            GC.Collect();
        }

        private void OnChildClosing(Form frm)
        {
            if (ChildClosing != null)
                ChildClosing(this, new FormShowingEventArgs {Form = frm});
        }

        private void OnChildShowing(Form frm)
        {
            if (ChildShowing != null)
                ChildShowing(this, new FormShowingEventArgs {Form = frm});
        }

        private void OnDialogShowing(Form frm)
        {
            if(DialogShowing != null)
                DialogShowing(this, new FormShowingEventArgs { Form = frm });
        }

        void rRadForm_Shown(object sender, EventArgs e)
        {
            IsShowed = true;
        }

        protected void ShowChildForm(Form frm)
        {
            OnChildShowing(frm);

            if(AutoOpenUnitOfWork)
                DbContext.OpenUnitOfWork();

            foreach (Form mdiChild in MdiChildren)
                if (mdiChild.Text == frm.Text)
                    mdiChild.Close();
            if (IsMdiContainer)
                frm.MdiParent = this;

//            frm.IsChild = true;
            if (IsMdiContainer)
                frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Load += new EventHandler(frm_Load);
            frm.Closing += frm_Closing;
            frm.Closed += new EventHandler(frm_Closed);
            if (IsMdiContainer)
                frm.Show();
            else
                frm.ShowDialog();
        }

        protected void frm_Closing(object sender, EventArgs e)
        {
            OnChildClosing(sender as Form);
        }

        protected void frm_Closed(object sender, EventArgs e)
        {
            if (AutoCloseUnitOfWork)
            {
                rRadForm frm = sender as rRadForm;
                if (frm.DbSession != null)
                    DbContext.CloseUnitOfWork(frm.DbSession);
                else
                    DbContext.CloseUnitOfWork();
            }
        }

        protected bool ShowDialogForm(Form frm)
        {
            OnDialogShowing(frm);

            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Closing += frm_Closing;
            if(frm.ShowDialog(this) == DialogResult.OK)
                return true;
            return false;
        }

        protected void CloseAllForms()
        {
            foreach (Form mdiChild in MdiChildren)
                mdiChild.Close();
            Application.DoEvents();
        }

        protected void frm_Load(object sender, EventArgs e)
        {
            (sender as Form).WindowState = FormWindowState.Maximized;
            FormElement.TitleBar.Font = Font;
            Application.DoEvents();
        }

        protected void AttachToClose(Form form)
        {
            form.Closed += new EventHandler(form_Closed);
        }

        private void form_Closed(object sender, EventArgs e)
        {
            Close();
        }

        public void SetProcessingObject(object obj)
        {
            mProcessingObject = obj;
        }

        public T GetProcessingObject<T>()
        {
            return (T) mProcessingObject;
        }

        private void rRadForm_KeyDown(object sender, KeyEventArgs e)
        {
//            if (!IsChild)
//                return;
//            if(!mEscapePressed)
//            {
//                if (e.KeyData == Keys.Escape)
//                    mEscapePressed = true;
//            }
//            else
//            {
//                if (e.KeyData == Keys.Escape)
//                    Close();
//            }
        }
    }

    public class FormShowingEventArgs : EventArgs
    {
        public Form Form { get; set; }
    }
}
