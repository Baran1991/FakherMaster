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
using NHibernate;
using rComponents;

namespace Fakher.UI.Educational
{
    public partial class frmBatchSignup : rRadForm
    {
        public frmBatchSignup()
        {
            InitializeComponent();

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Register.Code" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Register.Student.FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Register.Student.FarsiLastName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "SectionItem.Item.Lesson.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کلاس", ObjectProperty = "SectionItem.Section.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "Register.Student.FinancialStatusFarsiText" });

            rGridView2.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Register.Code" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Register.Student.FarsiFirstName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Register.Student.FarsiLastName" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "SectionItem.Item.Lesson.Name" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "کلاس", ObjectProperty = "SectionItem.Section.Name" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "وضعیت مالی", ObjectProperty = "Register.Student.FinancialStatusFarsiText" });
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            List<Participate> participates = rGridView1.GetCheckedObjects<Participate>();
            if (sectionItemSelector1.SectionItem == null)
            {
                rMessageBox.ShowError("کلاس را مشخص کنید.");
                return;
            }
            if (lessonSelector2.Lesson.Id == lessonSelector1.Lesson.Id)
            {
                rMessageBox.ShowError("درس/سطح مقصد را مشخص کنید.");
                return;
            }

            SectionItem newItem = sectionItemSelector1.SectionItem.Section.GetItem(lessonSelector2.Lesson);
            if (newItem == null)
            {
                rMessageBox.ShowError("امکان ثبت نام در این درس/سطح وجود ندارد.");
                return;
            }
            ITransaction transaction = null;
            try
            {
                transaction = DbContext.BeginTransaction();
                foreach (Participate participate in participates)
                {
                    newItem.CheckCapacity();
                    Participate newParticipate = participate.Register.Signup(newItem, false);
                    participate.Register.AddParticipate(newParticipate);
//                    participate.Register.Save();
                    newParticipate.SavePartially();

                    rGridView1.UnCheck(participate);
                    rGridView2.Insert(newParticipate);
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void sectionItemSelector1_SelectedChanged(object sender, EventArgs e)
        {
            if (sectionItemSelector1.SectionItem == null)
                return;
            IList<Participate> participates = sectionItemSelector1.SectionItem.GetParticipates();
            rGridView1.DataBind(participates);
            FillGridView2();
        }

        private void rGridView2_Delete(object sender, EventArgs e)
        {
            Participate participate = rGridView2.GetSelectedObject<Participate>();
            participate.Register.Participates.Remove(participate);
            participate.Register = null;
            participate.Delete();
            rGridView2.RemoveSelectedRow();
        }

        private void lessonSelector2_SelectedChanged(object sender, EventArgs e)
        {
            FillGridView2();
        }

        private void FillGridView2()
        {
            rGridView2.Clear();
            if (sectionItemSelector1.SectionItem == null)
                return;
            if (lessonSelector2.Lesson == null)
                return;
            SectionItem sectionItem = sectionItemSelector1.SectionItem.Section.GetItem(lessonSelector2.Lesson);
            if (sectionItem != null)
            {
                IList<Participate> participates = sectionItem.GetParticipates();
                rGridView2.DataBind(participates);
            }
        }
    }
}
