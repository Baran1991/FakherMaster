using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Telerik.WinControls.UI;
using rComponents;

namespace Fakher.UI.Fundamental
{
    public partial class frmEducationalToolGroupDetail : rRadDetailForm
    {
        public frmEducationalToolGroupDetail(EducationalToolGroup toolGroup)
        {
            InitializeComponent();

//            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "EducationalTool.Name" });

            ControlMappings.Add(new ControlMapping
            {
                Control = radTextBox1,
                ControlProperty = "Text",
                DataObject = toolGroup,
                ObjectProperty = "Name"
            });

            ControlMappings.Add(new ControlMapping
            {
                Control = lessonSelector1,
                ControlProperty = "Lesson",
                DataObject = toolGroup,
                ObjectProperty = "Lesson"
            });

            lessonSelector1.Databind(toolGroup.Major.Lessons);
            lessonSelector1.Lesson = null;
        
//            rGridView1.DataBind(toolGroup.GroupTools);
            
            rGridView1.RadGridView.ReadOnly = false;
            rGridView1.RadGridView.Columns.Add(new GridViewTextBoxColumn("نـام"));
            rGridView1.RadGridView.Columns.Add(new GridViewCheckBoxColumn("خرید"));
            rGridView1.RadGridView.Columns.Add(new GridViewCheckBoxColumn("امانت"));
            rGridView1.RadGridView.Columns[0].ReadOnly = true;
            rGridView1.RadGridView.Columns[1].ReadOnly = false;
            rGridView1.RadGridView.Columns[2].ReadOnly = false;
            rGridView1.RadGridView.AllowEditRow = true;

            Fill(toolGroup);
        }

        private void Fill(EducationalToolGroup mToolGroup)
        {
            foreach (GroupTool groupTool in mToolGroup.GroupTools)
                AddGroupTool(groupTool);
        }

        private void AddGroupTool(GroupTool tool)
        {
            GridViewRowInfo row = rGridView1.RadGridView.Rows.AddNew();
            row.Cells[0].Value = tool.EducationalTool.Name;
            row.Cells[1].Value = tool.AllowSell;
            row.Cells[2].Value = tool.AllowBorrow;

            row.Tag = tool;
        }

        protected override void AfterBindToObject()
        {
            EducationalToolGroup toolGroup = GetProcessingObject<EducationalToolGroup>();
            toolGroup.GroupTools.Clear();
            
            foreach (GridViewRowInfo row in rGridView1.RadGridView.Rows)
            {
                GroupTool groupTool = row.Tag as GroupTool;
                groupTool.AllowSell = (bool) row.Cells[1].Value;
                groupTool.AllowBorrow = (bool) row.Cells[2].Value;
                toolGroup.GroupTools.Add(groupTool);
            }
//            toolGroup.GroupTools.SyncWith(rGridView1.DataSource);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            EducationalToolGroup toolGroup = GetProcessingObject<EducationalToolGroup>();
            List<EducationalTool> tools = DbContext.GetAllEntities<EducationalTool>();

            frmSelect frm = new frmSelect(tools,
                              new ColumnMapping { Caption = "نام", ObjectProperty = "Name" });
            frm.MultiSelect = true;
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            foreach (EducationalTool tool in frm.GetSelectedObjects<EducationalTool>())
            {
                AddGroupTool(GroupTool.FromEducationalTool(tool, toolGroup));
//                rGridView1.Insert(new GroupTool { EducationalTool = tool, Group = toolGroup });
            }
//            EducationalTool educationalTool = frm.SelectedObject as EducationalTool;
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            rGridView1.RemoveSelectedRow();
        }
    }
}
