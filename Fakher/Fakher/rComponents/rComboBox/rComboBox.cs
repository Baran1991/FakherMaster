using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace rComponents
{
    /// <summary>
    /// اگر مقدار را انتخاب نمی کرد، در InitializeComponent مقدار Text = "" را پاک کن.
    /// </summary>
    public partial class rComboBox : RadDropDownList, IValidatableControl
    {
        [Category("Validation")]
        public ValidationType ValidationType { get; set; }
        [Category("Validation")]
        public string FieldName { get; set; }
        [Category("Validation")]
        public string ValidatingProperty { get; set; }
        [Category("Validation")]
        public string MinimumValue { get; set; }
        [Category("Validation")]
        public string MaximumValue { get; set; }


        public rComboBox()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            RightToLeft = RightToLeft.Yes;
            DropDownStyle = RadDropDownStyle.DropDownList;
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        public rComboBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Initialize();
        }

        public override string ThemeClassName
        {
            get { return typeof(RadDropDownList).FullName; }
        }

        private void rComboBox_ItemDataBound(object sender, ListItemDataBoundEventArgs args)
        {
            args.NewItem.Font = Font;
        }

        private void rComboBox_Enter(object sender, EventArgs e)
        {
            DropDownListElement.EditableElement.BackColor = Color.LightSkyBlue;
        }

        private void rComboBox_Leave(object sender, EventArgs e)
        {
            if (DropDownListElement != null && DropDownListElement.EditableElement != null)
                DropDownListElement.EditableElement.BackColor = Color.FromArgb(255, 255, 255, 255);
        }

        public void Validate()
        {
            if (ValidationType == ValidationType.NotEmpty)
                if (SelectedIndex < 0)
                    throw new ValidationException(this, string.Format("مقدار {0} را انتخاب کنید.", FieldName));
            if (ValidationType == ValidationType.InRange)
            {
                if (!string.IsNullOrEmpty(MinimumValue))
                {
                    int minimumValue = Convert.ToInt32(MinimumValue);
                    if (SelectedIndex < minimumValue)
                        throw new ValidationException(this, string.Format("مقدار {0} نامعتبر است، از بین {1} مقدار اول انتخاب کنید.", FieldName, minimumValue));
                }
                if (!string.IsNullOrEmpty(MaximumValue))
                {
                    int maximumValue = Convert.ToInt32(MaximumValue);
                    if (SelectedIndex > maximumValue)
                        throw new ValidationException(this, string.Format("مقدار {0} نامعتبر است، از بین {1} مقدار آخر انتخاب کنید.", FieldName, maximumValue));
                }
            }
        }

        private void rComboBox_Initialized(object sender, EventArgs e)
        {
//            if (ValidationType == ValidationType.NotEmpty)
//                (DropDownListElement.Children[2] as Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = Color.Red;
        }

    }
}
