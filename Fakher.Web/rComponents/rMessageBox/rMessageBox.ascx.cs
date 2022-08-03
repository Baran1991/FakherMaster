using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class rComponents_rMessageBox : UserControl
{
    private bool mHasResult;
    public event EventHandler<DialogResultEventArgs> DialogResult;

    protected void Page_Load(object sender, EventArgs e)
    {
        pnlInformation.Visible = false;
        pnlOkCancel.Visible = false;
        pnlYesNo.Visible = false;
        RadWindow1.Visible = false;
    }

    protected void Page_Init(object sender, EventArgs e)
    {

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (mHasResult)
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "hasResult",
                                                        "<script type=\"text/javascript\"> var hasResult = true; </script>");
        else
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "hasResult",
                                                        "<script type=\"text/javascript\"> var hasResult = false; </script>");
    }

    public void ShowInformation(string text)
    {
        lblMessage.Text = text;
        RadWindow1.Visible = true;
        pnlInformation.Visible = true;
    }

    public void ShowInformation(string text, bool hasResult, params string[] args)
    {
        mHasResult = hasResult;
        ShowInformation(string.Format(text, args));
    }

    public void ShowOkQuestion(string text)
    {
        lblMessage.Text = text;
        RadWindow1.Visible = true;
        pnlOkCancel.Visible = true;
    }

    public void ShowOkQuestion(string text, bool hasResult, params string[] args)
    {
        mHasResult = hasResult;
        ShowOkQuestion(string.Format(text, args));
    }

    public void ShowQuestion(string text)
    {
        lblMessage.Text = text;
        RadWindow1.Visible = true;
        pnlYesNo.Visible = true;
    }

    public void ShowQuestion(string text, bool hasResult, params string[] args)
    {
        mHasResult = hasResult;
        ShowQuestion(string.Format(text, args));
    }

    public void rBtnOk_Click(object sender, EventArgs e)
    {
        OnDialogResult(global::DialogResult.Ok);
    }
    public void rBtnCancel_Click(object sender, EventArgs e)
    {
        OnDialogResult(global::DialogResult.Cancel);
    }
    public void rBtnYes_Click(object sender, EventArgs e)
    {
        OnDialogResult(global::DialogResult.Yes);
    }
    public void rBtnNo_Click(object sender, EventArgs e)
    {
        OnDialogResult(global::DialogResult.No);
    }

    private void OnDialogResult(DialogResult result)
    {
        if (DialogResult != null)
            DialogResult(this, new DialogResultEventArgs(result));
    }
}

public class DialogResultEventArgs : EventArgs
{
    public DialogResult Result { get; set; }

    public DialogResultEventArgs(DialogResult result)
    {
        this.Result = result;
    }
}

public enum DialogResult
{
    Ok,
    Cancel,
    Yes,
    No
}
