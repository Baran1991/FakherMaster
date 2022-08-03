using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;

namespace Fakher.Controls
{
    public partial class FinancialDocumentView : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private FinancialDocument mDocument;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private FinancialHeading mHeading;

        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

        public event EventHandler Add;
        public event EventHandler Edit;
        public event EventHandler Delete;

        public FinancialDocumentView()
        {
            InitializeComponent();

            rGridView5.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "ItemDate.ToShortDateString()" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "سرفصل", ObjectProperty = "HeadingText" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "شرح", ObjectProperty = "DescriptionText" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "متعلق به", ObjectProperty = "Document.Person.FarsiFullname" });
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "بدهکار", ObjectProperty = "DebtText", AggregateSummary = AggregateSummary.Sum});
            rGridView5.Mappings.Add(new ColumnMapping { Caption = "بستانکار", ObjectProperty = "CreditText", AggregateSummary = AggregateSummary.Sum});
        }

        public void Databind(FinancialDocument document)
        {
            rGridView5.Clear();
            mDocument = document;
            AddItems(document.Items);
        }

        public void AddItems(IList<FinancialItem> items)
        {
            foreach (FinancialItem item in items)
            {
                rGridView5.Insert(item);
            }
        }

        private void FinancialDocumentView_Load(object sender, EventArgs e)
        {
            rGridView5.CanAdd = CanAdd;
            rGridView5.CanEdit = CanEdit;
            rGridView5.CanDelete = CanDelete;
        }

        private void rGridView5_Add(object sender, EventArgs e)
        {
            if (Add != null)
                Add(this, EventArgs.Empty);
        }

        private void rGridView5_Edit(object sender, EventArgs e)
        {
            if (Edit != null)
                Edit(this, EventArgs.Empty);
        }

        private void rGridView5_Delete(object sender, EventArgs e)
        {
            if (Delete != null)
                Delete(this, EventArgs.Empty);
        }

        public FinancialItem GetSelectedItem()
        {
            return rGridView5.GetSelectedObject<FinancialItem>();
        }

        public void Clear()
        {
            rGridView5.Clear();
        }
    }
}
