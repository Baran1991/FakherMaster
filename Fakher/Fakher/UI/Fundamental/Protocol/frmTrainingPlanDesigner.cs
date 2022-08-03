using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Controls;
using Fakher.Core.DomainModel;
using Fakher.Properties;
using Fakher.UI.Educational;
using rComponents;

namespace Fakher.UI.Fundamental.Protocol
{
    public partial class frmTrainingPlanDesigner : rRadDetailForm
    {
        public frmTrainingPlanDesigner(TrainingPlan plan)
        {
            InitializeComponent();

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = radTxtName,
                                        ControlProperty = "Text",
                                        DataObject = plan,
                                        ObjectProperty = "Name"
                                    });

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox1,
                                        ControlProperty = "Value",
                                        DataObject = plan,
                                        ObjectProperty = "Capacity"
                                    });
            
            imageList1.Images.Clear();
            imageList1.Images.Add(Fakher.Resources.Properties.Resources.whiteboard_256);
            imageList1.Images.Add(Fakher.Resources.Properties.Resources.exam_256);

            Fill(plan);

            lnkNewPostalItem.Visible = false;
        }

        protected override void AfterBindToObject()
        {
            TrainingPlan plan = GetProcessingObject<TrainingPlan>();
            
            List<TrainingItem> items = new List<TrainingItem>();
            foreach (ListViewItem listViewItem in listViewItems.Items)
                items.Add(listViewItem.Tag as TrainingItem);

            plan.Items.SyncWith(items);
        }

        private void Fill(TrainingPlan mPlan)
        {
            listViewItems.Items.Clear();
            foreach (TrainingItem item in mPlan.GetOrderedItems())
                AddControl(item);
        }

        private void AddControl(TrainingItem trainingItem)
        {
            ListViewItem listViewItem = new ListViewItem();
            Bind(listViewItem, trainingItem);
            listViewItems.Items.Add(listViewItem);
        }

        private void Bind(ListViewItem listViewItem, TrainingItem trainingItem)
        {
            listViewItem.Text = trainingItem.Text;
            listViewItem.Tag = trainingItem;
            if (trainingItem is SectionTrainingItem)
                listViewItem.ImageIndex = 0;
            if (trainingItem is ExamTrainingItem || trainingItem is ExerciseTrainingItem)
                listViewItem.ImageIndex = 1;
        }

        private void lnkNewSectionItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TrainingPlan plan = GetProcessingObject<TrainingPlan>();
            SectionTrainingItem item = plan.CreateTrainingItem<SectionTrainingItem>();
            if (!Edit(item))
                return;

//            frmSectionTrainingItemDetail frm = new frmSectionTrainingItemDetail(item);
//            if(!frm.ProcessObject())
//                return;

            AddControl(item);
        }

        private void lnkNewExamItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TrainingPlan plan = GetProcessingObject<TrainingPlan>();
            ExamTrainingItem item = plan.CreateTrainingItem<ExamTrainingItem>();
            if (!Edit(item))
                return;

//            frmExamTrainingItemDetail frm = new frmExamTrainingItemDetail(item);
//            if(!frm.ProcessObject())
//                return;

            AddControl(item);
        }

        private void lnkNewPostalItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TrainingPlan plan = GetProcessingObject<TrainingPlan>();
            PostalTrainingItem item = plan.CreateTrainingItem<PostalTrainingItem>();
            if (!Edit(item))
                return;

//            frmExamTrainingItemDetail frm = new frmExamTrainingItemDetail(item);
//            if (!frm.ProcessObject())
//                return;

            AddControl(item);
        }

        private void frmTrainingPlanDesigner_Load(object sender, EventArgs e)
        {

        }

        private void lnkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listViewItems.SelectedItems.Count == 0)
                return;

            TrainingPlan plan = GetProcessingObject<TrainingPlan>();
            ListViewItem listViewItem = listViewItems.SelectedItems[0];
            TrainingItem trainingItem = listViewItem.Tag as TrainingItem;

            if (!Edit(trainingItem))
                return;

            Bind(listViewItem, trainingItem);
        }

        private bool Edit(TrainingItem item)
        {
            if (item is SectionTrainingItem)
            {
                frmSectionTrainingItemDetail frm = new frmSectionTrainingItemDetail(item as SectionTrainingItem);
                return frm.ProcessObject();
            }
            if (item is ExamTrainingItem)
            {
                frmExamTrainingItemDetail frm = new frmExamTrainingItemDetail(item as ExamTrainingItem);
                return frm.ProcessObject();
            }
            if (item is ExerciseTrainingItem)
            {
                frmExerciseTrainingItemDetail frm = new frmExerciseTrainingItemDetail(item as ExerciseTrainingItem);
                return frm.ProcessObject();
            }
            if (item is PostalTrainingItem)
            {
                frmPostalTrainingItemDetail frm = new frmPostalTrainingItemDetail(item as PostalTrainingItem);
                return frm.ProcessObject();
            }
            if (item is LessonTrainingItem)
            {
                frmLessonTrainingItemDetail frm = new frmLessonTrainingItemDetail(item as LessonTrainingItem);
                return frm.ProcessObject();
            }

            throw new Exception();
        }

        private void lnkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listViewItems.SelectedItems.Count == 0)
                return;

            TrainingPlan plan = GetProcessingObject<TrainingPlan>();
            ListViewItem listViewItem = listViewItems.SelectedItems[0];
            TrainingItem trainingItem = listViewItem.Tag as TrainingItem;

            listViewItems.Items.Remove(listViewItem);
        }

        private void listViewItems_DoubleClick(object sender, EventArgs e)
        {
            if(listViewItems.SelectedItems.Count == 0)
                return;

            TrainingPlan plan = GetProcessingObject<TrainingPlan>();
            ListViewItem listViewItem = listViewItems.SelectedItems[0];
            TrainingItem trainingItem = listViewItem.Tag as TrainingItem;

            Edit(trainingItem);
            Bind(listViewItem, trainingItem);
        }

        private void lnkMoveToPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listViewItems.SelectedItems.Count == 0)
                return;

            TrainingPlan plan = GetProcessingObject<TrainingPlan>();
            ListViewItem listViewItem = listViewItems.SelectedItems[0];
            TrainingItem trainingItem = listViewItem.Tag as TrainingItem;
            int itemIndex = listViewItems.Items.IndexOf(listViewItem);
            if(itemIndex == 0)
                return;
            TrainingItem prevTrainingItem = listViewItems.Items[itemIndex - 1].Tag as TrainingItem;

            int position = trainingItem.Position;
            trainingItem.Position = prevTrainingItem.Position;
            prevTrainingItem.Position = position;

            Fill(plan);
        }

        private void lnkMoveToNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listViewItems.SelectedItems.Count == 0)
                return;

            TrainingPlan plan = GetProcessingObject<TrainingPlan>();
            ListViewItem listViewItem = listViewItems.SelectedItems[0];
            TrainingItem trainingItem = listViewItem.Tag as TrainingItem;
            int itemIndex = listViewItems.Items.IndexOf(listViewItem);
            if (itemIndex == listViewItems.Items.Count - 1)
                return;
            TrainingItem nextTrainingItem = listViewItems.Items[itemIndex + 1].Tag as TrainingItem;

            int position = trainingItem.Position;
            trainingItem.Position = nextTrainingItem.Position;
            nextTrainingItem.Position = position;

            Fill(plan);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TrainingPlan plan = GetProcessingObject<TrainingPlan>();
            ExerciseTrainingItem item = plan.CreateTrainingItem<ExerciseTrainingItem>();
            if (!Edit(item))
                return;

            //            frmExamTrainingItemDetail frm = new frmExamTrainingItemDetail(item);
            //            if(!frm.ProcessObject())
            //                return;

            AddControl(item);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TrainingPlan plan = GetProcessingObject<TrainingPlan>();
            LessonTrainingItem item = plan.CreateTrainingItem<LessonTrainingItem>();
            if (!Edit(item))
                return;

            AddControl(item);
        }
    }
}
