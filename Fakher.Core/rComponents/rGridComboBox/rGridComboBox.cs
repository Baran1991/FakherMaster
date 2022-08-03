using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace rComponents
{
    public partial class rGridComboBox : RadMultiColumnComboBox
    {
        public rGridComboBox()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            DropDownStyle = RadDropDownStyle.DropDownList;
            EditorControl.AutoGenerateColumns = false;
            Font = new Font("Tahoma", 8.25f);
            EditorControl.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            EditorControl.Font = new Font("Tahoma", 8.25f);
            Text = "";
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

        public new IList DataSource
        {
            get
            {
                return EditorControl.DataSource as IList;
            }
            set
            {
                Text = "";
                EditorControl.DataSource = value;
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
                Text = "";
                if (value == null)
                    return;
                foreach (GridViewRowInfo row in EditorControl.Rows)
                {
                    if(row.DataBoundItem == value)
                    {
                        SelectedItem = row;
//                        row.IsSelected = true;
                        return;
                    }
                }
            }
        }

        public bool ShowFilteringRow
        {
            get { return EditorControl.ShowFilteringRow; }
            set { EditorControl.EnableFiltering = EditorControl.ShowFilteringRow = value; }
        }

        public T GetValue<T>()
        {
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
                foreach (GridViewDataColumn column in updatingColumns)
                {
                    string[] items = column.FieldName.Split('.');
                    row.Cells[column.Index].Value = Services.GetValue(row.DataBoundItem, new List<string>(items));
                }
            }
        }
    }
}
