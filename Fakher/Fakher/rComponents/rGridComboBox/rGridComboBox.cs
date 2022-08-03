using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace rComponents
{
    public partial class rGridComboBox : RadMultiColumnComboBox, IValidatableControl
    {
        private bool mShowNullButton;
        private IEnumerable mRawDataSource;

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
        public string CompareMember { get; set; }
        public bool ShowNullButton
        {
            get { return mShowNullButton; }
            set 
            { 
                mShowNullButton = value;
                UpdateButtons();
            }
        }

        public rGridComboBox()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            DropDownStyle = RadDropDownStyle.DropDownList;
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            EditorControl.AutoGenerateColumns = false;
            Font = new Font("Tahoma", 8.25f);
            EditorControl.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            EditorControl.Font = new Font("Tahoma", 8.25f);
            Text = "";
            EditorControl.VerticalScrollState = ScrollState.AlwaysShow;
            EditorControl.HorizontalScrollState = ScrollState.AlwaysShow;
            MultiColumnComboBoxElement.EditorControl.ShowFilteringRow = true;
            ShowNullButton = false;
            DropDownClosing += new RadPopupClosingEventHandler(rGridComboBox_DropDownClosing);
        }

        void rGridComboBox_DropDownClosing(object sender, RadPopupClosingEventArgs args)
        {
            if (EditorControl.ActiveEditor != null)
                args.Cancel = true;
        }

        public rGridComboBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Initialize();
        }

        public override string ThemeClassName
        {
            get { return typeof(RadMultiColumnComboBox).FullName; }
        }

        public GridViewColumnCollection Columns
        {
            get
            {
                return EditorControl.Columns;
            }
        }

        public new IEnumerable DataSource
        {
            get
            {
                return mRawDataSource;
//                return EditorControl.DataSource as IEnumerable;
            }
            set
            {
                mRawDataSource = value;
                ManualBind();
//                return;
//                EditorControl.TableElement.BeginUpdate();
//                EditorControl.DataSource = value;
//                EditorControl.TableElement.EndUpdate();
            }
        }

        public object Value
        {
            get
            {
                if (SelectedItem == null)
                    return null;
                return (SelectedItem as GridViewRowInfo).DataBoundItem;
            }
            set
            {
                if (value == null)
                {
                    SelectedItem = null;
                    OnSelectedIndexChanged(EventArgs.Empty);
                    return;
                }
                foreach (GridViewRowInfo row in EditorControl.Rows)
                {
                    if(!string.IsNullOrEmpty(CompareMember))
                    {
                        object id1 = Services.GetValue(row.DataBoundItem, new List<string>(CompareMember.Split('.')));
                        object id2 = Services.GetValue(value, new List<string>(CompareMember.Split('.')));
                        if(id1.Equals(id2))
                        {
                            SelectedItem = row;
                            return;                            
                        }
                    }
                    else
                    {
                        if(row.DataBoundItem == value)
                        {
                            SelectedItem = row;
                            row.IsSelected = true;
                            return;
                        }
                    }
                }
            }
        }

        public bool ShowFilteringRow
        {
            get { return EditorControl.ShowFilteringRow; }
            set { EditorControl.EnableFiltering = EditorControl.ShowFilteringRow = value; }
        }

        private void ManualBind()
        {
            if (mRawDataSource == null)
                return;
            EditorControl.BeginUpdate();
            EditorControl.TableElement.BeginUpdate();
            EditorControl.AllowAddNewRow = true;
            EditorControl.Rows.Clear();
            foreach (object obj in mRawDataSource)
            {
                GridViewRowInfo row = EditorControl.Rows.AddNew();
                for (int i = 0; i < EditorControl.Columns.Count; i++)
                {
                    GridViewDataColumn column = EditorControl.Columns[i];
                    string[] items = column.FieldName.Split(new [] {".", "(", ")"}, StringSplitOptions.RemoveEmptyEntries);
                    if (items.Length == 0)
                        continue;

                    row.Cells[i].Value = Services.GetValue(obj, new List<string>(items));
                }

                row.Tag = obj;
                FieldInfo fieldInfo = row.GetType().BaseType.GetField("dataBoundItem", BindingFlags.Instance | BindingFlags.NonPublic);
                fieldInfo.SetValue(row, obj);
            }
            EditorControl.AllowAddNewRow = false;
            EditorControl.TableElement.EndUpdate();
            EditorControl.EndUpdate();

            if (EditorControl.Rows.Count > 0)
            {
                SelectedIndex = 0;
                EditorControl.Rows[0].IsSelected = true;
//                EditorControl.Rows[0].EnsureVisible();
            }
        }

        public T GetValue<T>()
        {
            if (Value == null)
                return default(T);
            return (T) Value;
        }

        private void rGridComboBox_DataBindingComplete(object sender, GridViewBindingCompleteEventArgs e)
        {
            if (EditorControl.Rows.Count == 0)
                return;

            List<GridViewDataColumn> updatingColumns = new List<GridViewDataColumn>();
            foreach (GridViewDataColumn column in EditorControl.Columns)
            {
                string[] items = column.FieldName.Split('.');
                if (items.Length > 1)
                {
                    updatingColumns.Add(column);
                }
            }

            foreach (GridViewRowInfo row in EditorControl.Rows)
            {
                foreach (GridViewCellInfo cell in row.Cells)
                {
                    cell.Style.Font = Font;
                }
                foreach (GridViewDataColumn column in updatingColumns)
                {
                    string[] items = column.FieldName.Split('.');
                    row.Cells[column.Index].Value = Services.GetValue(row.DataBoundItem, new List<string>(items));
                }
            }

            UpdateButtons();
        }

        public void Clear()
        {
            DataSource = null;
            SelectedItem = null;
            OnSelectedIndexChanged(EventArgs.Empty);
            Text = "";
        }

        public void Validate()
        {
            if (ValidationType == ValidationType.NotEmpty)
                if (GetValue<object>() == null)
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

        private void rGridComboBox_Initialized(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            if (ShowNullButton)
            {
                RadButton radButton = new RadButton { Text = "X", Size = new Size(16, Height), Left = 16, Top = 1 };
                radButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
                radButton.Click += new EventHandler(radButton_Click);
                Controls.Add(radButton);
                
                MultiColumnComboBoxElement.TextBoxElement.AutoSize = false;
                MultiColumnComboBoxElement.TextBoxElement.Size = new Size(Width - 31, Height);
                MultiColumnComboBoxElement.TextBoxElement.PositionOffset = new SizeF(-14, 0);
            }
            else
            {
                MultiColumnComboBoxElement.TextBoxElement.AutoSize = true;
                MultiColumnComboBoxElement.TextBoxElement.PositionOffset = new SizeF(0, 0);
            }
        }

        private void radButton_Click(object sender, EventArgs e)
        {
            SelectedItem = null;
//            SelectedIndex = -1;
//            SelectedValue = null;
//            Text = "";
        }

        private void rGridComboBox_EditorControl_CellClick(object sender, GridViewCellEventArgs e)
        {
//            SelectedItem = e.Row;
//            Value = e.Row.DataBoundItem;
            int row = e.RowIndex;
        }
    }
}
