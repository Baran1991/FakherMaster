using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using rComponents;

namespace Fakher.UI.Struture
{
    public partial class frmDepartmentList : rRadForm
    {
        public frmDepartmentList()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping {Caption = "کد دپارتمان", ObjectProperty = "Code"});
            rGridView1.Mappings.Add(new ColumnMapping {Caption = "نام دپارتمان", ObjectProperty = "Name"});

            rGridView2.Mappings.Add(new ColumnMapping {Caption = "کد رشته", ObjectProperty = "Code"});
            rGridView2.Mappings.Add(new ColumnMapping {Caption = "نام رشته", ObjectProperty = "Name"});

            rGridView1.DataBind(DbContext.GetAllEntities<Department>());
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Department department = new Department();
            department.Code = Department.GetNextCode();
            frmDepartmentDetail frm = new frmDepartmentDetail(department);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            department.Save();
            rGridView1.Insert(department);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Department department = rGridView1.GetSelectedObject<Department>();
            department.RefreshEntity();

            frmDepartmentDetail frm = new frmDepartmentDetail(department);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            department.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            try
            {
                Department department = rGridView1.GetSelectedObject<Department>();
                if (!department.CanDelete())
                {
                    rMessageBox.ShowError("بدلیل ارتباط با اطلاعات دیگر، حذف دپارتمان امکان پذیر نمیباشد!");
                    return;
                }
                department.Delete();
                rGridView1.RemoveSelectedRow();
            }
            catch (SqlException sqlex)
            {
                rMessageBox.ShowError(sqlex.Message + ":" + sqlex.Number);
                return;
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
          
        }
       
        private void rGridView1_SelectedItemChanged(object sender, EventArgs e)
        {
            Department department = rGridView1.GetSelectedObject<Department>();
            rGridView2.Clear();
            if(department == null)
                return;
            rGridView2.DataBind(department.Majors);
        }

        private void rGridView2_Add(object sender, EventArgs e)
        {
            Department department = rGridView1.GetSelectedObject<Department>();
            if(department == null)
            {
                rMessageBox.ShowError("دپارتمان موردنظر را انتخاب کنید.");
                return;
            }
            Major major = new Major {Department = department};
            major.Code = Major.GetNextCode();
            frmMajorDetail frm = new frmMajorDetail(major);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            department.Majors.Add(major);
            department.Save();
            rGridView2.Insert(major);
        }

        private void rGridView2_Edit(object sender, EventArgs e)
        {
            Department department = rGridView1.GetSelectedObject<Department>();
            Major major = rGridView2.GetSelectedObject<Major>();
            if (department == null)
            {
                rMessageBox.ShowError("دپارتمان موردنظر را انتخاب کنید.");
                return;
            }

            major.RefreshEntity();
            frmMajorDetail frm = new frmMajorDetail(major);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            major.Save();
            rGridView2.UpdateGridView();
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            try { 
            Department department = rGridView1.GetSelectedObject<Department>();
            Major major = rGridView2.GetSelectedObject<Major>();
            if (department == null)
            {
                rMessageBox.ShowError("دپارتمان موردنظر را انتخاب کنید.");
                return;
            }
            if(!major.CanDelete())
            {
                rMessageBox.ShowError("بدلیل ارتباط با اطلاعات دیگر، حذف رشته امکان پذیر نمیباشد");
                return;
            }
               
                department.Majors.Remove(major);
                department.Save(); 
                major.Delete();
                rGridView2.RemoveSelectedRow();
        }
            catch (SqlException sqlex)
            {
                rMessageBox.ShowError(sqlex.Message + ":" + sqlex.Number);
                return;
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
    }
}
