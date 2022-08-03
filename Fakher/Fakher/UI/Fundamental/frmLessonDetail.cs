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
using rComponents;
using rComponents;
using Telerik.WinControls;

namespace Fakher.UI.Struture
{
    public partial class frmLessonDetail : rRadDetailForm
    {
        public frmLessonDetail(Lesson lesson)
        {
            InitializeComponent();

            radPageView1.SelectedPage = radPageViewPage1;

            rComboBox1.DataSource = typeof(HoldingType).GetEnumDescriptions();

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = radTextBox1,
                                        ControlProperty = "Text",
                                        DataObject = lesson,
                                        ObjectProperty = "Code",
                                        ConvertNeeded = true
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = radTextBox2,
                                        ControlProperty = "Text",
                                        DataObject = lesson,
                                        ObjectProperty = "Name"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rComboBox1,
                                        ControlProperty = "SelectedIndex",
                                        DataObject = lesson,
                                        ObjectProperty = "HoldingType"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rCheckBox1,
                                        ControlProperty = "IsChecked",
                                        DataObject = lesson,
                                        ObjectProperty = "InternetRegisterable"
                                    });

            rGridView1.Mappings.Add(new ColumnMapping { Caption = "کد درس", ObjectProperty = "Code" });
            rGridView1.Mappings.Add(new ColumnMapping { Caption = "نام درس", ObjectProperty = "Name" });
            rGridView1.DataBind(lesson.Prerequisites);

//            rGridViewStuffs.Mappings.Add(new ColumnMapping { Caption = "نام کتاب", ObjectProperty = "EducationalTool.Name" });
//            rGridViewStuffs.DataBind(lesson.LessonTools);
        }

        private void rGridView1_Add(object sender, EventArgs e)
        {
            Lesson thisItem = GetProcessingObject<Lesson>();

            frmSelect frm = new frmSelect(thisItem.Major.Lessons,
                                          new ColumnMapping {Caption = "کد", ObjectProperty = "Code"},
                                          new ColumnMapping {Caption = "نام درس", ObjectProperty = "Name"});
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            Lesson selectedItem = frm.SelectedObject as Lesson;
            
            if(selectedItem.Id == thisItem.Id)
            {
                rMessageBox.ShowError("درس را به صورت صحیح و معتبر انتخاب کنید.");
                return;
            }

            foreach (Lesson educationalItem in rGridView1.DataSource)
            {
                if (educationalItem.Id == selectedItem.Id)
                {
                    rMessageBox.ShowError("این درس قبلا اضافه شده است");
                    return;
                }
            }
            rGridView1.Insert(selectedItem);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Lesson thisLesson = GetProcessingObject<Lesson>();
            try
            {
                Validate();
                BindControlsToObject();
//                thisLesson.Prerequisites.SyncWith(rGridView1.DataSource);
                thisLesson.Prerequisites.SyncPreciseWith(rGridView1.DataSource);
//                thisLesson.LessonTools.SyncWith(rGridViewStuffs.DataSource);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void rGridView1_Delete(object sender, EventArgs e)
        {
            rGridView1.RemoveSelectedRow();
        }

//        private void rGridViewStuffs_Add(object sender, EventArgs e)
//        {
//            Lesson lesson = GetProcessingObject<Lesson>();
//            
//            List<EducationalTool> tools = DbContext.GetAll<EducationalTool>().ToList();
//
//            frmSelect frm = new frmSelect(tools,
//                              new ColumnMapping { Caption = "نام کتاب", ObjectProperty = "Name" });
//            if (frm.ShowDialog(this) != DialogResult.OK)
//                return;
//            EducationalTool educationalTool = frm.SelectedObject as EducationalTool;
//
//            rGridViewStuffs.Insert(new LessonTool {EducationalTool = educationalTool, Lesson = lesson});
//        }
//
//        private void rGridViewStuffs_Delete(object sender, EventArgs e)
//        {
//            rGridViewStuffs.RemoveSelectedRow();
//        }
    }
}
