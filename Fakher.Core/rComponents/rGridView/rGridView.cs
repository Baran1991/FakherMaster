using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using Telerik.WinControls.UI.Localization;

namespace rComponents
{
    public partial class rGridView : UserControl
    {
        private List<object> mRawData;
        private bool mColumnFilled;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Mapping> Mappings { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<rGridViewButton> CustomButtons { get; set; }

        public Image ItemImage { get; set; }
        public bool ColumnAutoSize { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool ShowBottomToolbar { get; set; }
        public bool ConfirmOnDelete { get; set; }
        public bool ShowTopToolbar { get; set; }
        public int RowHeight { get; set; }

        public bool IsItemSelected
        {
            get { return radGridView1.SelectedRows.Count > 0; }
        }
        public bool CanGroup
        {
            get
            {
                return radGridView1.EnableGrouping;
            }
            set
            {
                radGridView1.EnableGrouping = value;
            }
        }

        public event EventHandler Add;
        public event EventHandler Edit;
        public event EventHandler Delete;
        public event EventHandler<CustomButtonClickEventArgs> CustomButtonClick;
//        public event EventHandler<CustomSearchEventArgs> CustomSearch;
        public event EventHandler SelectedItemChanged;
        public new event MouseEventHandler MouseDoubleClick;

        public IList DataSource
        {
            get { return mRawData; }
        }

        static rGridView()
        {
//            rSentinel.Check();
        }

        public rGridView()
        {
            InitializeComponent();
            mRawData = new List<object>();
            Mappings = new List<Mapping>();
            CustomButtons = new List<rGridViewButton>();
            ColumnAutoSize = true;
            CanAdd = true;
            CanEdit = true;
            CanDelete = true;
            ConfirmOnDelete = true;
            ShowTopToolbar = true;
            ShowBottomToolbar = false;
            RowHeight = 25;
            RadGridLocalizationProvider.CurrentProvider = new FarsiRadGridLocalizationProvider();  
        }

        private void OnAdd()
        {
            if (Add != null)
                Add(this, EventArgs.Empty);
        }

        private void OnEdit()
        {
            if (Edit != null)
                Edit(this, EventArgs.Empty);
        }

        private void OnDelete()
        {
            if (Delete != null)
                Delete(this, EventArgs.Empty);
        }
        private void OnDoubleClick(MouseEventArgs e)
        {
            if (MouseDoubleClick != null)
                MouseDoubleClick(this, e);
        }

        private void OnCustomButtonClick(rGridViewButton button, int index)
        {
            if (CustomButtonClick != null)
                CustomButtonClick(this, new CustomButtonClickEventArgs(button, index));
        }

        private void OnSelectedItemChanged()
        {
            if (SelectedItemChanged != null)
                SelectedItemChanged(this, EventArgs.Empty);
        }

        private void FillColumns()
        {
            radGridView1.Columns.Clear();
            foreach (Mapping mapping in Mappings)
            {
                if (!(mapping is ColumnMapping))
                    continue;
                if ((mapping as ColumnMapping).Type == ColumnType.Image)
                {
                    GridViewImageColumn column = new GridViewImageColumn(mapping.Caption, mapping.ObjectProperty);
                    column.ImageLayout = ImageLayout.Zoom;
                    radGridView1.Columns.Add(column);
                }
                else
                {
                    GridViewTextBoxColumn column = new GridViewTextBoxColumn(mapping.Caption, mapping.ObjectProperty);
                    if (!String.IsNullOrEmpty((mapping as ColumnMapping).Format))
                        column.FormatString = (mapping as ColumnMapping).Format;
                    radGridView1.Columns.Add(column);
//                    radGridView1.Columns.Add(mapping.Caption, mapping.Caption, mapping.ObjectProperty);
                }
            }
            mColumnFilled = true;
        }

        public void DataBind(IList data)
        {
            mRawData = new List<object>();
            foreach (var obj in data)
                mRawData.Add(obj);

            if(!mColumnFilled)
                FillColumns();
            BindToGrid(mRawData);
        }

        private void BindToGrid(IList data)
        {
            if (data == null)
                return;
            radGridView1.DataSource = null;
            radGridView1.DataSource = data;
        }

        public void Insert(object obj)
        {
            if (!mColumnFilled)
                FillColumns();
            mRawData.Add(obj);
            BindToGrid(mRawData);
        }

        public void UpdateGridView()
        {
            BindToGrid(mRawData);
        }

        public void RemoveSelectedRow()
        {
            radGridView1.SelectedRows[0].Delete();
            BindToGrid(mRawData);
        }

        public void Remove(object obj)
        {
            mRawData.Remove(obj);
            UpdateGridView();
        }

        private void UpdateTopToolbar()
        {
            if (!ShowTopToolbar)
            {
                radStatusStrip1.Visible = ShowTopToolbar;
                tableLayoutPanel1.RowStyles[0].Height = 0;
            }
            btnAdd.Visibility = CanAdd ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            btnEdit.Visibility = CanEdit && radGridView1.SelectedRows.Count > 0 ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            btnDelete.Visibility = CanDelete && radGridView1.SelectedRows.Count > 0 ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            foreach (rGridViewButton customButton in CustomButtons)
            {
                if (customButton.EnableOnSelect)
                    (customButton.Control as ToolStripButton).Enabled = radGridView1.SelectedRows.Count > 0;
                if (customButton.VisibleOnSelect)
                    (customButton.Control as ToolStripButton).Visible = radGridView1.SelectedRows.Count > 0;
            }
//            if (txtSearch.Focused && txtSearch.Text == mSearchWatermark)
//                txtSearch.Text = "";
//            if (!txtSearch.Focused && string.IsNullOrEmpty(txtSearch.Text))
//                txtSearch.Text = mSearchWatermark;
        }

        public object GetSelectedObject()
        {
            if (radGridView1.SelectedRows.Count > 0)
                return radGridView1.SelectedRows[0].DataBoundItem;
            return null;
        }

        public T GetSelectedObject<T>() where T : class
        {
            if (radGridView1.SelectedRows.Count > 0)
                return (T)radGridView1.SelectedRows[0].DataBoundItem;
            //            return default(T);
            return null;
        }

        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateTopToolbar();
            OnSelectedItemChanged();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OnAdd();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (radGridView1.SelectedRows.Count > 0)
                OnEdit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (radGridView1.SelectedRows.Count > 0)
            {
                if (ConfirmOnDelete && rMessageBox.ShowQuestion("عمل حذف غیرقابل بازگشت است. آیا مطمئن هستید؟") == DialogResult.No)
                    return;
                OnDelete();
            }
        }

        private void radMenuItem1_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel File *.xls|*.xls";
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            ExportToExcelML exporter = new ExportToExcelML(radGridView1);  
            exporter.HiddenColumnOption = HiddenOption.DoNotExport;
            exporter.ExportVisualSettings = false;
            exporter.SheetName = "Sheet1";
            exporter.RunExport(dialog.FileName);
        }

        private void rGridView_Load(object sender, EventArgs e)
        {
            UpdateTopToolbar();
        }

        private void radGridView1_DataBindingComplete(object sender, GridViewBindingCompleteEventArgs e)
        {
            if (radGridView1.Rows.Count == 0)
                return;

            List<GridViewDataColumn> updatingColumns = new List<GridViewDataColumn>();
            foreach (GridViewDataColumn column in radGridView1.Columns)
            {
                string[] items = column.FieldName.Split('.');
                if (items.Length > 1)
                {
                    updatingColumns.Add(column);
                }
            }

            foreach (GridViewRowInfo row in radGridView1.Rows)
            {
                foreach (GridViewDataColumn column in updatingColumns)
                {
                    string[] items = column.FieldName.Split('.');
                    row.Cells[column.Index].Value = Services.GetValue(row.DataBoundItem, new List<string>(items));
                }
            }

            foreach (GridViewRowInfo row in radGridView1.Rows)
            {
                row.Height = RowHeight;
               // GridViewRowInfo gridViewRowInfo = row.ChildRows[0];
            }

        }

        private void radGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (radGridView1.SelectedRows.Count == 0)
                return;
            OnEdit();
            OnDoubleClick(e);
        }
    }
}
