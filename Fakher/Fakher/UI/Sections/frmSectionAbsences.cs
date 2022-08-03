using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.UI.Educational.Common;
using Fakher.UI.Educational.Students;
using Fakher.UI.Person;
using rComponents;

namespace Fakher.UI.Educational.Sections
{
    public partial class frmSectionAbsences : rRadForm
    {
        public frmSectionAbsences()
        {
            InitializeComponent();

            rGridViewStudents.Mappings.Add(new ColumnMapping { Caption = "شماره دانشجویی", ObjectProperty = "Register.Code" });
            rGridViewStudents.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Register.Student.FarsiFirstName" });
            rGridViewStudents.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Register.Student.FarsiLastName" });
            rGridViewStudents.Mappings.Add(new ColumnMapping { Caption = "غیبت موجه", ObjectProperty = "AcceptedAbsencesCount" });
            rGridViewStudents.Mappings.Add(new ColumnMapping { Caption = "غیبت غیرموجه", ObjectProperty = "RejectedAbsencesCount" });
            rGridViewStudents.CustomButtons.Add(new rGridViewButton
                                                    {
                                                        Text = "مشخصات فردی",
                                                        VisibleOnSelect = true,
                                                        Position = rGridViewButtonPosition.After
                                                    });

//            rGridViewAbsents.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Person.FarsiFirstName" });
//            rGridViewAbsents.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Person.FarsiLastName" });
//            rGridViewAbsents.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date" });
//            rGridViewAbsents.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });

//            rGridViewAbsents.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Register.Student.FarsiFirstName" });
//            rGridViewAbsents.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Register.Student.FarsiLastName" });
//            rGridViewAbsents.Mappings.Add(new ColumnMapping { Caption = "تعداد غیبت", ObjectProperty = "AbsencesCount" });
//            rGridViewAbsents.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });

            rDatePicker1.Date = PersianDate.Today;
        }

        private void rGridViewStudents_Edit(object sender, EventArgs e)
        {
            Participate participate = rGridViewStudents.GetSelectedObject<Participate>();
            var listParticipates = new List<Participate>();
            listParticipates.Add(participate);
            frmRegisterAbsences frm = new frmRegisterAbsences(listParticipates);
            frm.ShowDialog(this);
            rGridViewStudents.UpdateGridView();
        }

        private void sectionItemSelector1_SelectedChanged(object sender, EventArgs e)
        {
            if (sectionItemSelector1.SectionItem == null)
                return;
            PersianDate date = rDatePicker1.Date;
            Fill();
        }

        private void lnkShowAbsences_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PersianDate date = rDatePicker1.Date;
            Fill();
        }

        private void Fill()
        {
            rGridViewStudents.DataBind(sectionItemSelector1.SectionItem.GetFarsiOrderedParticipates());
        }

        private void rGridViewStudents_Add(object sender, EventArgs e)
        {
            PersianDate date = rDatePicker1.Date;
            List<Participate> participates = rGridViewStudents.GetCheckedObjects<Participate>();
            if (participates.Count == 0)
            {
                rMessageBox.ShowError("حداقل یک دانشجو را تیک بزنید.");
                return;
            }

            foreach (Participate participate in participates)
            {
                Absence absence = participate.CreateAbsence(date, "");
                participate.Register.Student.Absences.Add(absence);
                absence.Save();
            }
            rGridViewStudents.UpdateGridView();
            rGridViewStudents.UnCheckAll();
            rMessageBox.ShowInformation(string.Format("غیبت {0} دانشجو به تاریخ {1} ثبت گردید.", participates.Count,
                                                      date.ToShortDateString()));
        }

        private void rGridViewStudents_Delete(object sender, EventArgs e)
        {
            Participate participate = rGridViewStudents.GetSelectedObject<Participate>();
            if (participate == null)
            {
                rMessageBox.ShowWarning("یک دانشجو را انتخاب کنید.");
                return;
            }

            participate.Register.Student.RefreshEntity();
            frmEducationalHistory frm = new frmEducationalHistory(participate.Register.Student);
            frm.ShowDialog();

            participate.Register.Student.Save();
            rGridViewStudents.UpdateGridView();
        }

        private void rGridViewStudents_CustomButtonClick(object sender, CustomButtonClickEventArgs e)
        {
            Participate participate = rGridViewStudents.GetSelectedObject<Participate>();
            if (e.ButtonIndex == 0)
            {
                frmPersonDetail frm = new frmPersonDetail(participate.Register.Student);
                frm.ShowDialog();
            }
        }
    }
}
