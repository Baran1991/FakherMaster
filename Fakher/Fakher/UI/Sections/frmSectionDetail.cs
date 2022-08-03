using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Website;
using Fakher.UI.Educational;
using Fakher.UI.Fundamental.Protocol;
using rComponents;
using Fakher.Core.Sentinel;
using Fakher.UI.Financial;

namespace Fakher.UI.Holding
{
    public partial class frmSectionDetail : rRadDetailForm
    {
        private TrainingPlan mOldSectionPlan;
        int sectionCapacity = 0;
        public frmSectionDetail(Section section)
        {
            InitializeComponent();
            this.rTextBox1.Leave += new System.EventHandler(this.rTextBox1_Leave);
            sectionCapacity = section.Capacity;
            radPageView1.SelectedPage = radPageViewPage2;
            SetProcessingObject(section);

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "درس/سطح", ObjectProperty = "Lesson.Name" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "ظرفیت", ObjectProperty = "Capacity" });

            rGridViewEvents.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "Date.ToShortDateString()" });
            rGridViewEvents.Mappings.Add(new ColumnMapping { Caption = "عنـوان", ObjectProperty = "Title" });
            rGridViewEvents.DataBind(section.EducationalEvents);

            rGridComboBoxPlan.Columns.Add("نام", "نام", "Name");

            rGridComboBoxTeacher.Columns.Add("نام", "نام", "FarsiFullname");
            rGridComboBoxTeacher.DataSource = Teacher.GetAllTeachers();

            rGridComboBoxSecondTeacher.Columns.Add("نام", "نام", "FarsiFullname");
            rGridComboBoxSecondTeacher.DataSource = Teacher.GetAllTeachers();

            rGridComboBoxMajor.Columns.Add("نام رشته", "نام رشته", "Name");
            rGridComboBoxMajor.DataSource = Program.CurrentDepartment.Majors;

            rGridViewFormations.Mappings.Add(new ColumnMapping { Caption = "روز", ObjectProperty = "DayText" });
            rGridViewFormations.Mappings.Add(new ColumnMapping {Caption = "از ساعت", ObjectProperty = "StartTime"});
            rGridViewFormations.Mappings.Add(new ColumnMapping {Caption = "تا ساعت", ObjectProperty = "FinishTime"});
            rGridViewFormations.Mappings.Add(new ColumnMapping {Caption = "مکان", ObjectProperty = "Place.Name"});
            rGridViewFormations.DataBind(section.Formations);

            rGridCmbPoll.Columns.Add("نام نظرسنجی", "نام نظرسنجی", "Name");
            rGridCmbPoll.Columns.Add("تاریخ شروع", "تاریخ شروع", "StartDateText");
            rGridCmbPoll.Columns.Add("تاریخ پایان", "تاریخ پایان", "EndDateText");
            rGridCmbPoll.DataSource = Core.DomainModel.Poll.Poll.GetAllPolls();

            rGridViewTuitionFee.Mappings.Add(new ColumnMapping { Caption = "رشته", ObjectProperty = "Major.Name" });
            rGridViewTuitionFee.Mappings.Add(new ColumnMapping { Caption = "شهریه", ObjectProperty = "Fee", Type = ColumnType.Money });
            rGridViewTuitionFee.DataBind(section.TuitionFees);


            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox2,
                                        ControlProperty = "Value",
                                        DataObject = section,
                                        ObjectProperty = "GroupNumber"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rDatePickerStart,
                                        ControlProperty = "Date",
                                        DataObject = section,
                                        ObjectProperty = "StartDate"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rDatePickerFinish,
                                        ControlProperty = "Date",
                                        DataObject = section,
                                        ObjectProperty = "FinishDate"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rGridComboBoxTeacher,
                                        ControlProperty = "Value",
                                        DataObject = section,
                                        ObjectProperty = "Teacher"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rGridComboBoxSecondTeacher,
                                        ControlProperty = "Value",
                                        DataObject = section,
                                        ObjectProperty = "SecondTeacher",
                                        MapNullValue = true
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rGridComboBoxMajor,
                                        ControlProperty = "Value",
                                        DataObject = section,
                                        ObjectProperty = "Major"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rGridComboBoxPlan,
                                        ControlProperty = "Value",
                                        DataObject = section,
                                        ObjectProperty = "TrainingPlan"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox1,
                                        ControlProperty = "Value",
                                        DataObject = section,
                                        ObjectProperty = "Capacity",
                                        ConvertNeeded = true
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox3,
                                        ControlProperty = "Value",
                                        DataObject = section,
                                        ObjectProperty = "Notes",
                                        ConvertNeeded = true
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox4,
                                        ControlProperty = "Value",
                                        DataObject = section,
                                        ObjectProperty = "HoldingHours"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rChkHasPoll,
                                        ControlProperty = "Checked",
                                        DataObject = section,
                                        ObjectProperty = "HasPoll"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rGridCmbPoll,
                                        ControlProperty = "Value",
                                        DataObject = section,
                                        ObjectProperty = "Poll"
                                    });

            rGridViewAttachments.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Name" });
            rGridViewAttachments.Mappings.Add(new ColumnMapping { Caption = "فعال از تاریخ", ObjectProperty = "StartDate" });
            rGridViewAttachments.Mappings.Add(new ColumnMapping { Caption = " از ساعت", ObjectProperty = "StartTime" });
            rGridViewAttachments.Mappings.Add(new ColumnMapping { Caption = "فعال تا تاریخ", ObjectProperty = "EndDate" });
            rGridViewAttachments.Mappings.Add(new ColumnMapping { Caption = " تا ساعت", ObjectProperty = "EndTime" });
            rGridViewAttachments.CustomButtons.Add(new rGridViewButton { Text = "تغیر تاریخ", VisibleOnSelect = true, Position = rGridViewButtonPosition.After });
            rGridViewAttachments.CustomButtonClick += rGridViewAttachments_CustomButtonClick;
            rGridViewAttachments.DataBind(section.Attachments);

            rGridCmbPoll.Enabled = section.HasPoll;
        }

       

        protected override void AfterValidate()
        {
            Section section = GetProcessingObject<Section>();

            if(rDatePickerStart.Date >= rDatePickerFinish.Date)
            {
                rMessageBox.ShowError("تاریخ پایان کلاس باید بزرگتر از تاریخ شروع آن باشد.");
                rDatePickerFinish.Focus();
                CancelClosing();
                return;
            }

            mOldSectionPlan = section.TrainingPlan;
        }

        protected override void AfterBindToObject()
        {
            Section section = GetProcessingObject<Section>();
            section.Formations.SyncWith(rGridViewFormations.DataSource);

            List<SectionTrainingItem> sectionItems = rGridView1.GetCheckedObjects<SectionTrainingItem>();

            if (mOldSectionPlan == null || section.TrainingPlan.Id != mOldSectionPlan.Id)
            {
                if(section.GetParticipates().Count != 0)
                {
                    rMessageBox.ShowError(
                        "در این کلاس، دانشجو ثبت نام شده است. بنابراین امکان تغییر برنامه آموزشی کلاس وجود ندارد.");
                    CancelClosing();
                    return;
                }

                section.Items.Clear();
                foreach (SectionTrainingItem item in sectionItems)
                {
                    SectionItem sectionItem = section.CreateItem(item);
                    section.Items.Add(sectionItem);
                }
            }

            if(sectionItems.Count != rGridView1.DataSource.Count)
            {
                rMessageBox.ShowError("همه آیتم های آموزشی را تیک بزنید.");
                CancelClosing();
                return;
            }

            foreach (SectionTrainingItem sectionTrainingItem in sectionItems)
            {
                bool found = false;
                foreach (SectionItem item in section.Items)
                {
                    if(item.Item.Id == sectionTrainingItem.Id)
                    {
                        found = true;
                        break;
                    }
                }
                if(!found)
                {
                    if(rMessageBox.ShowQuestion("آیتم [{0}] جدید است و به گروه اضافه خواهد شد. این عمل خطرناک است. آیا واقعا مطمئن هستید ؟", sectionTrainingItem.Lesson.Name) != DialogResult.Yes)
                    {
                        CancelClosing();
                        return;
                    }
                    SectionItem newSectionItem = section.CreateItem(sectionTrainingItem);
                    section.Items.Add(newSectionItem);
                }
            }

            Formation conflictingFormation = section.GetConflictingFormation();
            if (conflictingFormation != null)
            {
                if (rMessageBox.ShowQuestion(
                    string.Format("این کلاس با [{0}] از رشته {1} در روز [{2}] زمان [{3}] در اتاق [{4}] تداخل دارد. از ثبت کلاس به تداخل اطمینان دارید؟",
                                  conflictingFormation.Section.Name + " " + conflictingFormation.Section.MasterItemText, conflictingFormation.Section.Major.Name, conflictingFormation.DayText,
                                  conflictingFormation.Time, conflictingFormation.Place.Name)) != DialogResult.Yes)
                {
                    CancelClosing();
                    return;
                }
            }

            conflictingFormation = null;
            foreach (Formation formation in section.Formations)
            {
                conflictingFormation = section.Teacher.GetConflictingFormation(formation);
                if (conflictingFormation != null && conflictingFormation.Section.Id != section.Id)
                {
                    if (rMessageBox.ShowQuestion(string.Format("مدرس در روز [{0}] زمان [{1}] در [{2}] مشغول به تدریس است. از ثبت کلاس با تداخل اطمینان دارید؟",
                                                        conflictingFormation.DayText, conflictingFormation.Time, conflictingFormation.Section)) != DialogResult.Yes)
                    {
                        CancelClosing();
                        return;
                    }
                }
            }

            if (section.Id == 0)
            {
                foreach (SectionItem item in section.Items)
                {
                    foreach (EducationalToolGroup toolGroup in item.Lesson.ToolGroups)
                    {
                        foreach (GroupTool groupTool in toolGroup.GroupTools)
                        {
                            if (groupTool.EducationalTool.Remainder < section.Capacity)
                            {
                                if (rMessageBox.ShowQuestion(
                                    string.Format(
                                        " کتاب [{0}] برای تشکیل این کلاس با ظرفیت {1} نفر موجود نیست. موجودی فعلی این کتاب {2} تعداد است. آیا مطمئن هستید ؟",
                                        groupTool.EducationalTool.Name, section.Capacity,
                                        groupTool.EducationalTool.Remainder)) != DialogResult.Yes)
                                {
                                    CancelClosing();
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            section.EducationalEvents.SyncWith(rGridViewEvents.DataSource);
            section.Attachments.SyncWith(rGridViewAttachments.DataSource);
            section.TuitionFees.SyncWith(rGridViewTuitionFee.DataSource);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Section section = GetProcessingObject<Section>();
            Formation formation = new Formation { Section = section };
            frmFormationDetail frm = new frmFormationDetail(formation);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            rGridViewFormations.Insert(formation);
        }

        private void rGridView1_Edit(object sender, EventArgs e)
        {
            Section section = GetProcessingObject<Section>();
            Formation formation = rGridViewFormations.GetSelectedObject<Formation>();
            frmFormationDetail frm = new frmFormationDetail(formation);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            rGridViewFormations.UpdateGridView();
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            Section section = GetProcessingObject<Section>();
            Formation formation = rGridViewFormations.GetSelectedObject<Formation>();
            rGridViewFormations.RemoveSelectedRow();
        }

        private void rGridComboBoxMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            rGridComboBoxPlan.Clear();
            Major major = rGridComboBoxMajor.GetValue<Major>();
            if(major == null)
                return;
            rGridComboBoxPlan.DataSource = TrainingPlan.GetPlans(Program.CurrentPeriod, major, false);
        }

        private void rGridComboBoxPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrainingPlan plan = rGridComboBoxPlan.GetValue<TrainingPlan>();
            if(plan == null)
                return;

            rTextBox1.Value = plan.Capacity;
            rGridView1.DataBind(plan.GetSectionItems());
            rGridView1.CheckAll();
        }

        private void rGridViewEvents_Add(object sender, EventArgs e)
        {
            Section section = GetProcessingObject<Section>();
            EducationalEvent @event = new EducationalEvent { Section = section };
            frmEducationalEventDetail frm = new frmEducationalEventDetail(@event);
            if (!frm.ProcessObject())
                return;
            section.AddEvent(@event);
            rGridViewEvents.Insert(@event);
        }

        private void rGridViewEvents_Edit(object sender, EventArgs e)
        {
            EducationalEvent @event = rGridViewEvents.GetSelectedObject<EducationalEvent>();
            frmEducationalEventDetail frm = new frmEducationalEventDetail(@event);
            if (!frm.ProcessObject())
                return;
            rGridViewEvents.UpdateGridView();
        }

        private void rGridViewEvents_Delete(object sender, EventArgs e)
        {
            EducationalEvent @event = rGridViewEvents.GetSelectedObject<EducationalEvent>();
            rGridViewEvents.RemoveSelectedRow();
        }

        private void rGridViewAttachments_Add(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files (*.*)|*.*";
            dialog.Multiselect = false;
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            WebMedia media = WebMedia.FromFileName(dialog.FileName, WebMediaType.Attachment);
            rGridViewAttachments.Insert(media);
        }

        private void rGridViewAttachments_Edit(object sender, EventArgs e)
        {
            WebMedia media = rGridViewAttachments.GetSelectedObject<WebMedia>();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files (*.*)|*.*";
            dialog.Multiselect = false;
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            media.SetFile(dialog.FileName);
            rGridViewAttachments.UpdateGridView();
        }
        private void rGridViewAttachments_CustomButtonClick(object sender, EventArgs e)
        {

            WebMedia media = rGridViewAttachments.GetSelectedObject<WebMedia>();

            frmAttachmentDateChange frm = new frmAttachmentDateChange(media);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            rGridViewAttachments.UpdateGridView();
        }
        private void rGridViewAttachments_Delete(object sender, EventArgs e)
        {
            WebMedia media = rGridViewAttachments.GetSelectedObject<WebMedia>();
            rGridViewAttachments.RemoveSelectedRow();
        }

        private void rChkHasPoll_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            rGridCmbPoll.Enabled = rChkHasPoll.Checked;
        }

        private void rGridViewTuitionFee_Add(object sender, EventArgs e)
        {
            Section section = GetProcessingObject<Section>();
            IList<Major> majors =
                section.Period.GetLessonHoldings(section.Major).SelectMany(x => x.AllowedMajors).Distinct().ToList();
            TuitionFee tuitionFee = new TuitionFee();
            frmTuitionFeeDetail frm = new frmTuitionFeeDetail(tuitionFee, majors);
            if (!frm.ProcessObject())
                return;
            foreach (TuitionFee fee in rGridViewTuitionFee.DataSource)
                if (fee.Major.Id == tuitionFee.Major.Id)
                {
                    rMessageBox.ShowError("برای این رشته قبلا شهریه ثبت شده است.");
                    return;
                }
            rGridViewTuitionFee.Insert(tuitionFee);
        }

        private void rGridViewTuitionFee_Edit(object sender, EventArgs e)
        {
            Section section = GetProcessingObject<Section>();
            TuitionFee tuitionFee = rGridViewTuitionFee.GetSelectedObject<TuitionFee>();
            IList<Major> majors = section.Period.GetLessonHoldings(section.Major).SelectMany(x => x.AllowedMajors).Distinct().ToList();

            frmTuitionFeeDetail frm = new frmTuitionFeeDetail(tuitionFee, majors);
            if (!frm.ProcessObject())
                return;

            foreach (TuitionFee fee in rGridViewTuitionFee.DataSource)
                if (fee.Major.Id == tuitionFee.Major.Id && tuitionFee.Id != fee.Id)
                {
                    rMessageBox.ShowError("برای این رشته قبلا شهریه ثبت شده است.");
                    return;
                }
            rGridViewTuitionFee.UpdateGridView();
        }

        private void rGridViewTuitionFee_Delete(object sender, EventArgs e)
        {
            TuitionFee tuitionFee = rGridViewTuitionFee.GetSelectedObject<TuitionFee>();
            rGridViewTuitionFee.RemoveSelectedRow();
        }

        private void rTextBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                if(rTextBox1.Value.ToString()!=sectionCapacity.ToString())
                Sentinel.Check(Program.CurrentEmployee.UserInfo, AccessTagType.EducationalSectionCapacityEdit);
               
            }
            catch (Exception ex)
            {
                rTextBox1.Value = sectionCapacity;
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

       
    }
}
