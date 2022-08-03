using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rComponents;
using mshtml;


namespace rComponents
{
    public partial class frmTableDetail : rRadDetailForm
    {
        string mDirection;
        string mBorder;
        HtmlElementCollection mTrCollection;
        HtmlElementCollection mTdCollection;

        public frmTableDetail(HtmlElement element)
        {
            InitializeComponent();
            SetProcessingObject(element);

            mDirection = element.GetAttribute("dir");
            mBorder = element.GetAttribute("border");
            mTrCollection = element.GetElementsByTagName("tr");
            mTdCollection = element.GetElementsByTagName("td");

            rTextBox1.Text = "100";
        }

        private void rChkWidth_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rTextBox1.Enabled = rRadioButton1.Enabled = rRadioButton2.Enabled = rChkWidth.IsChecked;
        }

        private void rChkHeight_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rTextBox2.Enabled = rRadioButton3.Enabled = rRadioButton4.Enabled = rChkHeight.IsChecked;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            HtmlElement element = GetProcessingObject<HtmlElement>();
            int rows = (int) radSpinEditorRows.Value;
            int cols = (int) radSpinEditorColumns.Value;
            int border = (int) radSpinEditorBorder.Value;
            int width = rTextBox1.GetValue<int>();
            int height = rTextBox2.GetValue<int>();

            for (int i = 0; i < rows; i++)
            {
                HtmlElement row = element.Document.CreateElement("tr");
                for (int j = 0; j < cols; j++)
                {
                    HtmlElement col = element.Document.CreateElement("td");
                    row.AppendChild(col);
                }
                element.AppendChild(row);
            }

            element.SetAttribute("border", border + "");
            element.SetAttribute("width", width + "%");
        }
    }
}
