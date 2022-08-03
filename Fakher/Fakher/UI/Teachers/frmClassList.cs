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
using Fakher.UI.Educational.Common;
using Fakher.UI.Educational.Students;
using rComponents;

namespace Fakher.UI.Educational
{
    public partial class frmClassList : rRadForm
    {
        private EducationalPeriod mCurrentPeriod;
        private bool mConfirm;
        private Teacher mCurrentteacher;
     

        public frmClassList(Teacher teacher, EducationalPeriod period,Department department)
        {
            InitializeComponent();
            
            mCurrentPeriod = period;
            rGridView1.CanDelete = false;
            mCurrentteacher = teacher;
            rGridView1.CustomButtons.Add(new rGridViewButton { Text = "غیبت ها", VisibleOnSelect = true, Position = rGridViewButtonPosition.After });
            //rGridView1.CustomButtonClick += rGridView1_CustomButtonClick;

            rGridView1.CustomButtons.Add(new rGridViewButton { Text = "تاخیرها", VisibleOnSelect = true, Position = rGridViewButtonPosition.After });
            
            rGridView1.CustomButtons.Add(new rGridViewButton { Text = "فعالیت کلاسی", VisibleOnSelect = true, Position = rGridViewButtonPosition.After });
            rGridView1.CustomButtonClick += rGridView1_CustomButtonClick;
           
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Register.Code" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Register.Student.FarsiFirstName" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Register.Student.FarsiLastName" });
         
            Fill();
        }

        private void Fill()
        {
            rGridComboBoxMajor.Columns.Add("نام رشته", "نام رشته", "Name"); 
            rGridComboBoxLesson.Columns.Add("نام درس ", "نام درس", "Name");
            rGridComboGroup.Columns.Add("نام  ", "نام ", "Section.Name");

            rGridComboBoxMajor.DataSource = mCurrentteacher.GetTeachingSections(mCurrentPeriod).Select(m => m.Major).Distinct();
           


          
        }

     

        

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Presence presence = rGridView1.GetSelectedObject<Presence>();

            frmPresenceDetail frm = new frmPresenceDetail(presence);
            if (!frm.ProcessObject())
                return;
            presence.Save();
            rGridView1.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
           
            Presence presence = rGridView1.GetSelectedObject<Presence>();
            mCurrentteacher.Presences.Remove(presence);
            presence.Delete();
            rGridView1.RemoveSelectedRow();
        }

        private void rGridComboBoxMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var major = rGridComboBoxMajor.GetValue<Major>();
           //if(major!=null)
           var lessons= mCurrentteacher.GetTeachingSections(mCurrentPeriod).SelectMany(m => m.Major.Lessons).Distinct();
            rGridComboBoxLesson.DataSource = lessons;
        }

        private void rGridComboBoxLesson_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lesson = rGridComboBoxLesson.GetValue<Lesson>();

            //List<SectionItem> sectionItems = SectionItem.GetSectionItems(mCurrentPeriod, lesson);
            List<SectionItem> sectionItems = mCurrentteacher.GetTeachingSections(mCurrentPeriod).SelectMany(m => m.Items).Where(m=>m.Lesson==lesson).ToList();
            rGridComboGroup.DataSource = sectionItems;
        }

        private void rGridComboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //rGridView1.Clear();
            var section = rGridComboGroup.GetValue<SectionItem>();
            //var lesson = rGridComboBoxLesson.GetValue<Lesson>();
            IList<Participate> participates = null;
            if (section != null)
            {
                participates = section.GetParticipates();

                rGridView1.DataBind(participates);
            }
        }

        private void rGridComboBoxMajor_DataBindingComplete(object sender, Telerik.WinControls.UI.GridViewBindingCompleteEventArgs e)
        {
            //var major = rGridComboBoxMajor.GetValue<Major>();
            ////if(major!=null)
            //var lessons = DbContext.GetAll<Section>().Where(m => m.Teacher == mCurrentteacher).SelectMany(m => m.Major.Lessons).Distinct();
            //rGridComboBoxLesson.DataSource = lessons;
        }

        private void rGridComboBoxLesson_DataBindingComplete(object sender, Telerik.WinControls.UI.GridViewBindingCompleteEventArgs e)
        {
            //var lesson = rGridComboBoxLesson.GetValue<Lesson>();
            //List<SectionItem> sectionItems = SectionItem.GetSectionItems(mCurrentPeriod, lesson);

            //rGridComboGroup.DataSource = sectionItems;
        }

        private void rGridView1_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            var participte = rGridView1.GetSelectedObject<Participate>();

            

            if (participte == null)
                return;
            if (e.ButtonIndex == 0)
            {
                DbContext.OpenUnitOfWork(true);
                var participateList = new List<Participate>();
                participateList.Add(participte);
                var frm = new frmRegisterAbsences(participateList,false);
                frm.ShowDialog();
                DbContext.CloseUnitOfWork();

            }
            else if (e.ButtonIndex == 1)
            {
                DbContext.OpenUnitOfWork(true);
                var participateList = new List<Participate>();
                participateList.Add(participte);
                var frm = new frmRegisterDelays(participateList);
                frm.ShowDialog();
                DbContext.CloseUnitOfWork();

            }
          
            else if (e.ButtonIndex == 2)
            {
                DbContext.OpenUnitOfWork(true);

                var frm = new frmRegisterActivityMarks(participte);
                frm.ShowDialog();
                DbContext.CloseUnitOfWork();
            }
              
        }

    }
}
