using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace rComponents
{
    public class rMessageBox
    {
        
        public static Form FindCallingForm()
        {
            StackTrace trace = new StackTrace(false);
            foreach (StackFrame frame in trace.GetFrames())
            {
                MethodBase method = frame.GetMethod();
                if (method != null)
                {
                    break;
                }
            }
            return null;
        }

        public static DialogResult ShowQuestion(string text)
        {
            return ShowQuestion(text, "");
        }

        public static DialogResult ShowQuestion(string text, params object[] args)
        {
            return ShowQuestion(String.Format(text, args), "");
        }

        private static DialogResult ShowQuestion(string text, string title)
        {
            frmMessageBox frm = new frmMessageBox();
            frm.Title = title;
            frm.MessageText = text;
            frm.Icon = MessageBoxIcon.Question;
            return frm.ShowDialog();
        }

        public static DialogResult ShowError(string text)
        {
            return ShowError(text, "");
        }

        public static DialogResult ShowError(string text, params object[] args)
        {
            return ShowError(String.Format(text, args), "خطـــا");
        }

        private static DialogResult ShowError(string text, string title)
        {
            frmMessageBox frm = new frmMessageBox();
            frm.Title = title;
            frm.MessageText = text;
            frm.Icon = MessageBoxIcon.Error;
            return frm.ShowDialog();
        }

        public static DialogResult ShowWarning(string text)
        {
            return ShowWarning(text, "");
        }

        public static DialogResult ShowWarning(string text, params object[] args)
        {
            return ShowWarning(String.Format(text, args), "");
        }

        private static DialogResult ShowWarning(string text, string title)
        {
            frmMessageBox frm = new frmMessageBox();
            frm.Title = title;
            frm.MessageText = text;
            frm.Icon = MessageBoxIcon.Warning;
            return frm.ShowDialog();
        }

        public static DialogResult ShowInformation(string text)
        {
            return ShowInformation(text, "");
        }

        public static DialogResult ShowInformation(string text, params object[] args)
        {
            return ShowInformation(String.Format(text, args), "");
        }

        private static DialogResult ShowInformation(string text, string title)
        {
            frmMessageBox frm = new frmMessageBox();
            frm.Title = title;
            frm.MessageText = text;
            frm.Icon = MessageBoxIcon.Information;
            return frm.ShowDialog();
        }
    }
}
