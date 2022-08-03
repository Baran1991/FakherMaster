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
using Fakher.UI;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using Telerik.WinControls.UI.Localization;
using Fakher;
using System.Web.UI;

namespace rComponents
{
    public partial class rGridView : System.Windows.Forms.UserControl, IValidatableControl
    {
        private List<object> mRawData;
        private IEnumerable mAllRawData;
        private bool mColumnFilled;
//        private bool mBindingMode;

        [Category("Validation")]
        public ValidationType ValidationType { get; set; }
        [Category("Validation")]
        public string FieldName { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ColumnMapping> Mappings { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<rGridViewButton> CustomButtons { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NestedCollection { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NestedProperty { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ParentProperty { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ColumnMapping> NestedMappings { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<int, object> ColumnTags { get; set; }


        public Image ItemImage { get; set; }
        public bool ColumnAutoSize { get; set; }
        public bool Paging { get; set; }
        public int PageNum = 0;
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanNavigate { get; set; }
        public bool CanExport { get; set; }
        public bool ShowTopToolbar { get; set; }
        public bool ShowBottomToolbar { get; set; }
        public bool ConfirmOnDelete { get; set; }
        public bool EditOnDoubleClick { get; set; }
        public int RowHeight { get; set; }
        public string CustomAddText { get; set; }
        public string CustomEditText { get; set; }
        public string CustomDeleteText { get; set; }
        public bool CheckBoxes { get; set; }

        public bool IsItemSelected
        {
            get { return radGridView1.MasterTemplate.SelectedRows.Count > 0; }
        }

        public bool MultiSelect
        {
            get { return radGridView1.MultiSelect; }
            set { radGridView1.MultiSelect = value; }
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

        public bool CanFilter
        {
            get
            {
                return radGridView1.EnableFiltering;
            }
            set
            {
                radGridView1.EnableFiltering = value;
            }
        }

        public bool ShowGroupPanel
        {
            get { return radGridView1.ShowGroupPanel; }
            set { radGridView1.ShowGroupPanel = value; }
        }

        public GridViewSummaryRowItemCollection BottomSummaryRow
        {
            get
            {
                return radGridView1.SummaryRowsBottom;
            }
        }

        public event EventHandler Add;
        public event EventHandler Edit;
        public event EventHandler Delete;
        public event EventHandler<CustomButtonClickEventArgs> CustomButtonClick;
        public event EventHandler<GridViewCellEventArgs> CellValueChanged;
        public event EventHandler<ValueChangingEventArgs> ValueChanging;
        public event EventHandler<CellValidatingEventArgs> CellValidating;
        public event EventHandler SelectedItemChanged;
        public new event MouseEventHandler MouseDoubleClick;
        public event EventHandler GridAction;

        public IList DataSource
        {
            get { return mRawData; }
        }

        internal RadGridView RadGridView
        {
            get { return radGridView1; }
        }

        private List<object> mNestedCollection { get; set; }

        public rGridView()
        {
            InitializeComponent();
            mRawData = new List<object>();
            Mappings = new List<ColumnMapping>();
            NestedCollection = null;
            NestedMappings = new List<ColumnMapping>();
            CustomButtons = new List<rGridViewButton>();
            ColumnTags = new Dictionary<int, object>();
            mNestedCollection = new List<object>();
            ColumnAutoSize = true;
            Paging = false;
            CanAdd = true;
            CanEdit = true;
            CanDelete = true;
            CanNavigate = true;
            CanExport = true;
            CanGroup = false;
            ConfirmOnDelete = true;
            EditOnDoubleClick = true;
            ShowTopToolbar = true;
            ShowBottomToolbar = false;
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
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

        private void OnGridAction()
        {
            if (GridAction != null)
                GridAction(this, EventArgs.Empty);
        }

        private void OnDoubleClick(MouseEventArgs e)
        {
            if (MouseDoubleClick != null)
                MouseDoubleClick(this, e);
        }

        private void OnCustomButtonClick(rGridViewButton button)
        {
            if (CustomButtonClick != null)
                CustomButtonClick(this, new CustomButtonClickEventArgs(button, CustomButtons.IndexOf(button)));
        }

        private void OnSelectedItemChanged()
        {
            if (SelectedItemChanged != null)
                SelectedItemChanged(this, EventArgs.Empty);
        }

        private void OnCellValueChanged(GridViewCellEventArgs args)
        {
            if (CellValueChanged != null)
                CellValueChanged(this, args);
        }

        private void OnCellValueChanging(ValueChangingEventArgs args)
        {
            if (ValueChanging != null)
                ValueChanging(this, args);
        }

        private void OnCellValidating(CellValidatingEventArgs args)
        {
            if (CellValidating != null)
                CellValidating(this, args);
        }

        private void FillColumns()
        {
            radGridView1.Columns.Clear();

            if(CheckBoxes)
            {
                GridViewCheckBoxColumn checkBoxColumn = new GridViewCheckBoxColumn();
                checkBoxColumn.HeaderText = "";
                checkBoxColumn.Width = 20;
                checkBoxColumn.AllowFiltering = false;
                checkBoxColumn.AllowGroup = false;
                checkBoxColumn.AllowHide = false;
                checkBoxColumn.AllowResize = false;
                checkBoxColumn.AllowSort = false;
                checkBoxColumn.ReadOnly = false;

                radGridView1.AllowEditRow = true;
                radGridView1.MasterTemplate.Columns.Add(checkBoxColumn);
                radGridView1.ContextMenuStrip = contextMenuStrip1;
            }

            List<GridViewSummaryItem> SummaryItems = new List<GridViewSummaryItem>();

            foreach (ColumnMapping mapping in Mappings)
            {
                if (!(mapping is ColumnMapping))
                    continue;
                if (mapping.AggregateSummary != AggregateSummary.None)
                {
                    SummaryItems.Add(new GridViewSummaryItem(
                                         mapping.Caption, 
                                         mapping.AggregateSummary.ToDescription() + ": " + mapping.Format, 
                                         (GridAggregateFunction) mapping.AggregateSummary));
                }
                AddColumn(radGridView1.MasterTemplate.Columns, mapping);
            }
            if (SummaryItems.Count > 0)
                radGridView1.SummaryRowsBottom.Add(new GridViewSummaryRowItem(SummaryItems.ToArray()));

            if (!string.IsNullOrEmpty(NestedCollection))
            {
                AddColumn(radGridView1.MasterTemplate.Columns, new ColumnMapping{Caption = "شناسه", ObjectProperty = ParentProperty});
                
                GridViewTemplate template = new GridViewTemplate();
                template.AllowAddNewRow = false;
                template.VerticalScrollState = ScrollState.AlwaysShow;
                template.HorizontalScrollState = ScrollState.AlwaysShow;

                radGridView1.MasterTemplate.Templates.Add(template);
                foreach (ColumnMapping mapping in NestedMappings)
                {
                    AddColumn(template.Columns, mapping);
                }
                AddColumn(template.Columns, new ColumnMapping { Caption = "شناسه", ObjectProperty = NestedProperty });
            }
            mColumnFilled = true;
        }

        private void AddColumn(GridViewColumnCollection collection, ColumnMapping mapping)
        {
            if (mapping.Type == ColumnType.Image)
            {
                GridViewImageColumn imageColumn = new GridViewImageColumn(mapping.Caption, mapping.ObjectProperty);
                imageColumn.ImageLayout = ImageLayout.Zoom;
                imageColumn.ReadOnly = true;
                collection.Add(imageColumn);
            }
            else if (mapping.Type == ColumnType.Decimal)
            {
                GridViewDecimalColumn column = new GridViewDecimalColumn(mapping.Caption, mapping.ObjectProperty);
                if (!string.IsNullOrEmpty(mapping.Format))
                    column.FormatString = mapping.Format;
                column.TextAlignment = ContentAlignment.MiddleCenter;
                column.DecimalPlaces = 2;
                column.ReadOnly = true;
                collection.Add(column);
            }
            else if(mapping.Type == ColumnType.Money)
            {
                GridViewDecimalColumn column = new GridViewDecimalColumn(mapping.Caption, mapping.ObjectProperty);
                if (!string.IsNullOrEmpty(mapping.Format))
                    column.FormatString = mapping.Format;
                column.TextAlignment = ContentAlignment.MiddleCenter;
                column.DecimalPlaces = 1;
                column.ReadOnly = true;
                collection.Add(column);
            }
            else
            {
                GridViewTextBoxColumn column = new GridViewTextBoxColumn(mapping.Caption, mapping.ObjectProperty);
                if (!string.IsNullOrEmpty(mapping.Format))
                    column.FormatString = mapping.Format;
                column.ReadOnly = true;
                collection.Add(column);
            }
        }

        public void Clear()
        {
            radGridView1.Rows.Clear();
            radGridView1.DataSource = null;
            mRawData = new List<object>();
            if(radGridView1.SelectedRows.Count > 0)
            {
                radGridView1.ClearSelection();
                OnSelectedItemChanged();
            }
        }

        public void ClearFilters()
        {
            foreach (GridViewDataColumn column in radGridView1.Columns)
            {
                if(column.FilterDescriptor != null)
                    column.FilterDescriptor.Value = "";
            }
        }

        public void Reset()
        {
            radGridView1.Rows.Clear();
            radGridView1.Columns.Clear();
            ColumnTags.Clear();
            Mappings.Clear();
            mColumnFilled = false;
        }

        public void DataBind(IEnumerable data)
        {
            try
            {
                if (mAllRawData == null)
                    mAllRawData = data;
                if (!mColumnFilled)
                    FillColumns();
                if (data == null)
                    return;
                var PageRowNum = Program.PageRowNum;
               
                mRawData = new List<object>();
                
                //if (Paging)
                //    data = data.Take(pagNum);
                foreach (var obj in data)
                {
                    mRawData.Add(obj);
                    if (!string.IsNullOrEmpty(NestedCollection))
                    {
                        string[] items = NestedCollection.Split('.');
                        IList nestedValues = Services.GetValue(obj, new List<string>(items)) as IList;
                        nestedValues.CopyTo(mNestedCollection);
                    }
                }
                if (Paging)
                    mRawData = mRawData.Skip(PageNum* PageRowNum).Take(PageRowNum).ToList();
                 BindToGrid(mRawData);
               
            }
            catch(Exception ex)
            {
                rMessageBox.ShowInformation(ex.Message);
            }
        }

        private void BindToGrid(IList data)
        {
            try { 
            radGridView1.TableElement.BeginUpdate();

            radGridView1.DataSource = null;
            if (data != null)
            {
//                radGridView1.DataSource = data;
                ManualBind(data);
                
                if (!string.IsNullOrEmpty(NestedCollection))
                {
                    radGridView1.Templates[0].DataSource = mNestedCollection;

                    GridViewRelation relation = new GridViewRelation(radGridView1.MasterTemplate,
                                                                     radGridView1.Templates[0]);
                    relation.ParentColumnNames.Add("شناسه");
                    relation.ChildColumnNames.Add("شناسه");
                    radGridView1.Relations.Add(relation);
                }
            }
            radGridView1.TableElement.EndUpdate();
//            radGridView1.BestFitColumns();
            UpdateTopToolbar();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowInformation(ex.Message);
            }
        }

        private void ManualBind(IList data)
        {
            int selectedRowIndex = 0;
            int selectedCellIndex = 0;
//            if (radGridView1.SelectedRows.Count > 0)
//            {
//                selectedRowIndex = radGridView1.SelectedRows[0].Index;
//                selectedCellIndex = radGridView1.SelectedCells[0].ColumnInfo.Index;
//            }


            radGridView1.TableElement.BeginUpdate();

            radGridView1.Rows.Clear();
            foreach (object obj in data)
            {
                GridViewRowInfo row = radGridView1.Rows.AddNew();
                for (int i = 0; i < radGridView1.Columns.Count; i++)
                {
                    GridViewDataColumn column = radGridView1.Columns[i];
                    string[] items = column.FieldName.Split(new[] { ".", "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
                    if (items.Length == 0)
                        continue;

                    row.Cells[i].Value = Services.GetValue(obj, new List<string>(items));
                }

                row.Tag = obj;
                FieldInfo fieldInfo = row.GetType().BaseType.GetField("dataBoundItem", BindingFlags.Instance | BindingFlags.NonPublic);
                fieldInfo.SetValue(row, obj);
            }
            radGridView1.TableElement.EndUpdate();
            if (radGridView1.Rows!=null)
            if (radGridView1.Rows.Count > 0)
            {
                if (selectedRowIndex != -1)
                {
                    if (selectedRowIndex > radGridView1.Rows.Count - 1)
                        selectedRowIndex = radGridView1.Rows.Count - 1;

                    if (radGridView1.CurrentRow.Cells.Count > selectedCellIndex)
                    {
                        radGridView1.CurrentRow = radGridView1.Rows[selectedRowIndex];
                        radGridView1.CurrentRow.IsSelected = true;
                        radGridView1.CurrentRow.Cells[selectedCellIndex].IsSelected = true;
                        radGridView1.CurrentRow.EnsureVisible();
                    }
                }
                //else
                //{
                //    radGridView1.CurrentRow = radGridView1.Rows[0];
                //    radGridView1.CurrentRow.Cells[0].IsSelected = true;
                //    radGridView1.CurrentRow.IsSelected = true;
                //    radGridView1.CurrentRow.EnsureVisible();
                //}
            }
        }

        public void Insert(object obj)
        {
            if (!mColumnFilled)
                FillColumns();
            mRawData.Add(obj);
            BindToGrid(mRawData);
            OnGridAction();
        }

        public void UpdateGridView()
        {
            List<object> checkedObjects = null;
            if(CheckBoxes)
                checkedObjects = GetCheckedObjects<object>();
            
            int selectedRowIndex = 0;
            int selectedCellIndex = 0;
            if (radGridView1.SelectedRows.Count > 0)
            {
                selectedRowIndex = radGridView1.SelectedRows[0].Index;
                selectedCellIndex = radGridView1.SelectedCells[0].ColumnInfo.Index;
            }

            BindToGrid(mRawData);

            if (radGridView1.Rows.Count > 0 && selectedRowIndex != -1)
            {
                if (selectedRowIndex > radGridView1.Rows.Count - 1)
                    selectedRowIndex = radGridView1.Rows.Count - 1;

                radGridView1.CurrentRow = radGridView1.Rows[selectedRowIndex];
                radGridView1.CurrentRow.IsSelected = true;
                radGridView1.CurrentRow.Cells[selectedCellIndex].IsSelected = true;
                radGridView1.CurrentRow.EnsureVisible();
            }

            //if(radGridView1.SelectedRows.Count > 0)
            //{
            //    radGridView1.SelectedRows[0].EnsureVisible();
            //}

            if (CheckBoxes)
                foreach (object checkedObject in checkedObjects)
                    Check(checkedObject);
            
            OnGridAction();
        }

        public void RemoveSelectedRow()
        {
            GridViewRowInfo row = radGridView1.SelectedRows[0];
            mRawData.Remove(row.DataBoundItem);
            row.Delete();
            BindToGrid(mRawData);
            OnGridAction();
        }

        public void Remove(object obj)
        {
            mRawData.Remove(obj);
            UpdateGridView();
            OnGridAction();
        }

        internal void UpdateTopToolbar()
        {
            if (!ShowTopToolbar)
            {
                radStatusStrip1.Visible = ShowTopToolbar;
                tableLayoutPanel1.RowStyles[0].Height = 0;
            }
            btnAdd.Visibility = CanAdd ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            btnEdit.Visibility = CanEdit && radGridView1.SelectedRows.Count > 0 ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            btnDelete.Visibility = CanDelete && radGridView1.SelectedRows.Count > 0 ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            btnFirst.Visibility =
                lblRecord.Visibility =
                btnLast.Visibility = CanNavigate ? ElementVisibility.Visible : ElementVisibility.Collapsed;
            btnTools.Visibility = CanExport ? ElementVisibility.Visible : ElementVisibility.Collapsed;

            if (!string.IsNullOrEmpty(CustomAddText))
                btnAdd.Text = CustomAddText;
            if (!string.IsNullOrEmpty(CustomEditText))
                btnEdit.Text = CustomEditText;
            if (!string.IsNullOrEmpty(CustomDeleteText))
                btnDelete.Text = CustomDeleteText;
            if (Paging)
            {
                if (mAllRawData != null)
                {
                    lblRecord.Text = string.Format("صفحه {0} از {1}", PageNum+1, (mAllRawData.GetCount() / Program.PageRowNum) + 1);

                    lblRecord.Text += string.Format("|تعداد رکورد:{0}", mAllRawData.GetCount());
                }
                //else
                //    lblRecord.Text = string.Format("صفحه 0 از {0}", (radGridView1.Rows.Count / Program.PageRowNum) + 1);
            }
            else
            {
                if (radGridView1.CurrentRow != null)
                    lblRecord.Text = string.Format("رکورد {0} از {1}", radGridView1.CurrentRow.Index + 1, radGridView1.ChildRows.Count);
                else
                    lblRecord.Text = string.Format("رکورد 0 از {0}", radGridView1.Rows.Count );

            }
            List<RadItem> removingItems = new List<RadItem>();
            foreach (RadItem item in radStatusStrip1.Items)
                if (item.Tag != null && item.Tag is rGridViewButton)
                    removingItems.Add(item);
            foreach (RadItem removingItem in removingItems)
                radStatusStrip1.Items.Remove(removingItem);
            foreach (rGridViewButton button in CustomButtons)
            {
                bool selected = radGridView1.MasterTemplate.SelectedRows.Count > 0;
                if(button.VisibleOnSelect || button.EnableOnSelect)
                {
                    if (selected)
                    {
                        AddButton(button);
                    }
                }
                else
                {
                    AddButton(button);
                }
            }
        }

        private void AddButton(rGridViewButton button)
        {
            RadButtonElement item = new RadButtonElement(button.Text, button.Image);
            item.Tag = button;
            item.AccessibleDescription = button.Text;
            item.AccessibleName = button.Text;
            item.DisplayStyle = DisplayStyle.ImageAndText;
            item.AutoSize = false;
            item.Bounds = new Rectangle(0, 0, 90, 25);
            item.Margin = new Padding(1);
            item.Text = button.Text;
            item.Visibility = ElementVisibility.Visible;
            item.Name = "btn" + button.Text;
            item.Click += new EventHandler(item_Click);
            
            radStatusStrip1.SetSpring(item, false);
            if(button.Position == rGridViewButtonPosition.Before)
                radStatusStrip1.Items.Add(item);
            else if (button.Position == rGridViewButtonPosition.After)
                radStatusStrip1.Items.Insert(radStatusStrip1.Items.Count - 3, item);
        }

        private void item_Click(object sender, EventArgs e)
        {
            rGridViewButton button = (sender as RadItem).Tag as rGridViewButton;
            OnCustomButtonClick(button);
//            if (CustomButtonClick != null)
//            {
//                CustomButtonClickEventArgs eventArgs = new CustomButtonClickEventArgs(button, 0);
//                CustomButtonClick(this, eventArgs);
//            }
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
            return null;
        }

        public List<T> GetSelectedObjects<T>() where T : class
        {
            List<T> result = new List<T>();
            foreach (GridViewRowInfo row in radGridView1.SelectedRows)
            {
                result.Add((T)row.DataBoundItem);
            }
            return result;
        }

        public List<T> GetVisibleObjects<T>() where T:class
        {
            List<T> result = new List<T>();
            foreach (GridViewRowInfo row in radGridView1.ChildRows)
            {
                result.Add((T)row.DataBoundItem);
            }
            return result;
        }

        public List<T> GetCheckedObjects<T>() where T : class
        {
            if(!CheckBoxes)
                throw new Exception("Checkboxes Property not Set!");

            List<T> result = new List<T>();
            foreach (GridViewRowInfo row in radGridView1.Rows)
            {
                if(Convert.ToBoolean(row.Cells[0].Value))
                    result.Add((T) row.DataBoundItem);
            }
            return result;
        }

        public void CheckAll()
        {
            if (!CheckBoxes)
                return;
            foreach (GridViewRowInfo row in radGridView1.ChildRows)
                row.Cells[0].Value = true;
        }

        public void Select(object obj)
        {
            foreach (GridViewRowInfo row in radGridView1.Rows)
            {
                row.IsSelected = false;
                if (row.DataBoundItem == obj)
                {
                    row.IsSelected = true;
                    row.EnsureVisible();
                }
            }
        }

        public void Check(object obj)
        {
            if (!CheckBoxes)
                return;
            foreach (GridViewRowInfo row in radGridView1.Rows)
            {
                if (row.DataBoundItem == obj && !Convert.ToBoolean(row.Cells[0].Value))
                    row.Cells[0].Value = true;
            }
        }

        public void UnCheck(object obj)
        {
            if (!CheckBoxes)
                return;
            foreach (GridViewRowInfo row in radGridView1.Rows)
            {
                if (row.DataBoundItem == obj && Convert.ToBoolean(row.Cells[0].Value))
                    row.Cells[0].Value = false;
            }
        }

        public void UnCheckAll()
        {
            if (!CheckBoxes)
                return;
            foreach (GridViewRowInfo row in radGridView1.ChildRows)
                row.Cells[0].Value = false;
        }

        public void CheckReverse()
        {
            if (!CheckBoxes)
                return;
            foreach (GridViewRowInfo row in radGridView1.ChildRows)
                row.Cells[0].Value = !Convert.ToBoolean(row.Cells[0].Value);
        }

        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateTopToolbar();
            OnSelectedItemChanged();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(CanAdd)
                OnAdd();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CanEdit && radGridView1.SelectedRows.Count > 0)
                OnEdit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CanDelete && radGridView1.SelectedRows.Count > 0)
            {
                if (ConfirmOnDelete && rMessageBox.ShowQuestion("عمل حذف غیرقابل بازگشت است. آیا مطمئن هستید؟") != DialogResult.Yes)
                    return;
                OnDelete();
            }
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            List<GridViewColumn> allColumns = new List<GridViewColumn>();
            foreach (GridViewDataColumn column in radGridView1.Columns)
            {
                if(column is GridViewImageColumn || column is GridViewCheckBoxColumn)
                    continue;
                allColumns.Add(column);
            }

            frmSelect frm = new frmSelect(allColumns, new ColumnMapping { Caption = "نام ستون", ObjectProperty = "HeaderText" });
            frm.MultiSelect = true;
            frm.CheckAll();
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel File *.xls|*.xls";
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                List<GridViewColumn> columns = frm.GetSelectedObjects<GridViewColumn>();
                foreach (GridViewDataColumn column in radGridView1.Columns)
                    if (!columns.Contains(column))
                        column.IsVisible = false;

                ExportToExcelML exporter = new ExportToExcelML(radGridView1);
                exporter.HiddenColumnOption = HiddenOption.DoNotExport;
                exporter.ExportVisualSettings = false;
                exporter.SheetName = "Sheet1";
                exporter.RunExport(dialog.FileName);

                rMessageBox.ShowInformation("فایل موردنظر با موفقیت صادر گردید.");
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
            finally
            {
                foreach (GridViewDataColumn column in radGridView1.Columns)
                    column.IsVisible = true;
            }
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            frmSelect frm = new frmSelect(radGridView1.Columns, new ColumnMapping { Caption = "نام ستون", ObjectProperty = "HeaderText" });
            frm.MultiSelect = true;
            frm.CheckAll();
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "CSV File *.csv|*.csv";
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                List<GridViewColumn> columns = frm.GetSelectedObjects<GridViewColumn>();
                foreach (GridViewDataColumn column in radGridView1.Columns)
                    if (!columns.Contains(column))
                        column.IsVisible = false;

                ExportToCSV exporter = new ExportToCSV(radGridView1);
                exporter.HiddenColumnOption = HiddenOption.DoNotExport;
                exporter.RunExport(dialog.FileName);

                rMessageBox.ShowInformation("فایل موردنظر با موفقیت صادر گردید.");
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
            finally
            {
                foreach (GridViewDataColumn column in radGridView1.Columns)
                    column.IsVisible = true;
            }
        }

        private void radMenuItem3_Click(object sender, EventArgs e)
        {
            frmSelect frm = new frmSelect(radGridView1.Columns, new ColumnMapping { Caption = "نام ستون", ObjectProperty = "HeaderText" });
            frm.MultiSelect = true;
            frm.CheckAll();
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "PDF File *.pdf|*.pdf";
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                List<GridViewColumn> columns = frm.GetSelectedObjects<GridViewColumn>();
                foreach (GridViewDataColumn column in radGridView1.Columns)
                    if (!columns.Contains(column))
                        column.IsVisible = false;

                ExportToPDF exporter = new ExportToPDF(radGridView1);
                exporter.HiddenColumnOption = HiddenOption.DoNotExport;
                exporter.ExportVisualSettings = false;
                exporter.RunExport(dialog.FileName);

                rMessageBox.ShowInformation("فایل موردنظر با موفقیت صادر گردید.");
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
            finally
            {
                foreach (GridViewDataColumn column in radGridView1.Columns)
                    column.IsVisible = true;
            }
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
                string[] items = column.FieldName.Split('.', '(', ')');
                if (items.Length > 1)
                    updatingColumns.UniqueAdd(column);
            }

            foreach (ColumnMapping mapping in Mappings)
            {
                if(mapping.NestedUpdate)
                {
                    foreach (GridViewDataColumn column in radGridView1.Columns)
                    {
                        if (column.FieldName == mapping.ObjectProperty)
                        {
                            updatingColumns.UniqueAdd(column);
                            break;
                        }
                    }
                }
            }

            foreach (GridViewRowInfo row in radGridView1.Rows)
            {
                foreach (GridViewDataColumn column in updatingColumns)
                {
                    string[] firstItems = column.FieldName.Split('.', '(', ')');
                    List<string> items = new List<string>();
                    foreach (string item in firstItems)
                        if (!string.IsNullOrEmpty(item))
                            items.Add(item);

                    if(row.DataBoundItem != null)
                        row.Cells[column.Index].Value = Services.GetValue(row.DataBoundItem, items);
                }
            }

            foreach (GridViewRowInfo row in radGridView1.Rows)
            {
                row.Height = RowHeight;
            }

            foreach (ColumnMapping mapping in Mappings)
            {
                if (mapping.SortOrder == SortOrder.None)
                    continue;
                foreach (GridViewDataColumn column in radGridView1.Columns)
                {
                    if(column.HeaderText != mapping.Caption)
                        continue;
                    if (mapping.SortOrder == SortOrder.Ascending)
                        column.Sort(RadSortOrder.Ascending, true);
                    if (mapping.SortOrder == SortOrder.Descending)
                        column.Sort(RadSortOrder.Descending, true);
                }
            }

            foreach (ColumnMapping mapping in Mappings)
            {
                if (mapping.GroupOrder == SortOrder.None)
                    continue;
                foreach (GridViewDataColumn column in radGridView1.Columns)
                {
                    if(column.HeaderText != mapping.Caption)
                        continue;
                    if (mapping.GroupOrder == SortOrder.Ascending)
                    {
                        GroupDescriptor descriptor1 = new GroupDescriptor();
                        descriptor1.GroupNames.Add(mapping.Caption, ListSortDirection.Ascending);
                        radGridView1.GroupDescriptors.Add(descriptor1);
                    }
                    if (mapping.GroupOrder == SortOrder.Descending)
                    {
                        GroupDescriptor descriptor1 = new GroupDescriptor();
                        descriptor1.GroupNames.Add(mapping.Caption, ListSortDirection.Descending);
                        radGridView1.GroupDescriptors.Add(descriptor1);
                    }
                }
            }

            foreach (GridViewRowInfo row in radGridView1.Rows)
            {
                
                //style
            }
        }

        private void radGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void radGridView1_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (radGridView1.SelectedRows.Count == 0)
                return;
            if(!CanEdit)
                return;
            if(EditOnDoubleClick)
                OnEdit();
            OnDoubleClick(e);
        }

        public void Validate()
        {
            if (ValidationType == ValidationType.NotEmpty)
            {
                if (mRawData.Count == 0)
                    throw new ValidationException(this, string.Format("برای {0} حداقل یک مورد را وارد کنید.", FieldName));
            }
        }

        private void radGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (radGridView1.IsInEditMode)
                OnCellValueChanged(e);
        }

        private void radGridView1_CellValidating(object sender, CellValidatingEventArgs e)
        {
            if(radGridView1.IsInEditMode)
            {
                OnCellValidating(e);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (radGridView1.Rows.Count == 0)
                return;
            if (Paging)
            {
                if (PageNum > 0)
                {
                    PageNum--;
                    DataBind(mAllRawData);
                }
                
            }
            else
            {
                radGridView1.CurrentRow = radGridView1.Rows[radGridView1.Rows.Count - 1];
                radGridView1.CurrentRow.EnsureVisible();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (radGridView1.Rows.Count == 0)
                return;
            if (Paging)
            {
                if (PageNum < mAllRawData.GetCount() / Program.PageRowNum)
                {
                    PageNum++;
                    DataBind(mAllRawData);
                }
            }
            else
            {
                radGridView1.CurrentRow = radGridView1.Rows[0];
                radGridView1.CurrentRow.EnsureVisible();
            }
        }

        private void radGridView1_FilterChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            UpdateTopToolbar();
        }

        public void SetRowBold(object obj)
        {
            foreach (GridViewRowInfo row in radGridView1.Rows)
                if (row.DataBoundItem == obj)
                {
                    foreach (GridViewCellInfo cell in row.Cells)
                        cell.Style.Font = new Font(radGridView1.Font.FontFamily, radGridView1.Font.Size, FontStyle.Bold);
                    row.EnsureVisible();
                }
        }

        public void SetRowNormal(object obj)
        {
            foreach (GridViewRowInfo row in radGridView1.Rows)
                if (row.DataBoundItem == obj)
                    foreach (GridViewCellInfo cell in row.Cells)
                        cell.Style.Font = new Font(radGridView1.Font.FontFamily, radGridView1.Font.Size);
        }

        private void انتخابهمهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckAll();
        }

        private void انـتخابهیچـکـدامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnCheckAll();
        }

        private void انـتـخابمـعـکـوسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckReverse();
        }
    }
}
