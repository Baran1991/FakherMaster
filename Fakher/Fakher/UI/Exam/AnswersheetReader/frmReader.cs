using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Properties;
using Fakher.UI.Exam;
using Fakher.UI.Exam.AnswersheetReader;
using Fakher.UI.Reception;
using rComponents;
using rFormProcessor;
using rTwain;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace Fakher.UI.AnswersheetReader
{
    public partial class frmReader : rRadForm
    {
        private rFormProcessor.rFormProcessor mFormProcessor;
        private bool mNormalScanMode;
        private string mLastProcessedCode;
        private ExamParticipate mCurrentExamParticipate;
        private string mSavePath;

        public frmReader()
        {
            InitializeComponent();

            rGridComboBoxEvalItem.Columns.Add("نام آیتم", "نام آیتم", "Name");

            rGridComboBoxExam.Columns.Add("نام آزمون", "نام آزمون", "Name");
            rGridComboBoxExam.Columns.Add("کلاس/گروه", "کلاس/گروه", "FarsiExamSectionsText");
//            rGridComboBoxExam.Columns.Add("آیتم نتیجه", "آیتم نتیجه", "EvaluationItem.Name");
//            rGridComboBoxExam.Columns.Add("نوع آزمون", "نوع آزمون", "FarsiTypeText");

            rGridComboBoxExamSection.Columns.Add("نام کلاس", "نام کلاس", "SectionItem.Section.FarsiName");
            rGridComboBoxExamSection.Columns.Add("مدرس", "مدرس", "SectionItem.Section.Teacher.FarsiFullname");

            rGridViewExamParticipates.Mappings.Add(new ColumnMapping { Caption = "شناسه پاسخنامه", ObjectProperty = "Code" });
            rGridViewExamParticipates.Mappings.Add(new ColumnMapping { Caption = "نام", ObjectProperty = "Register.Student.FarsiFirstName" });
            rGridViewExamParticipates.Mappings.Add(new ColumnMapping { Caption = "نام خانوادگی", ObjectProperty = "Register.Student.FarsiLastName" });
            rGridViewExamParticipates.Mappings.Add(new ColumnMapping { Caption = "فرم آزمون", ObjectProperty = "ExamForm.Name" });
            rGridViewExamParticipates.Mappings.Add(new ColumnMapping { Caption = "شماره آزمون", ObjectProperty = "SeatNumber" });
            rGridViewExamParticipates.Mappings.Add(new ColumnMapping { Caption = "وضعیت", ObjectProperty = "StatusText" });
            rGridViewExamParticipates.Mappings.Add(new ColumnMapping { Caption = "نمره", ObjectProperty = "CalculateMark", NestedUpdate = true});
            rGridViewExamParticipates.CustomButtons.Add(new rGridViewButton { Text = "ارسال پیامک", VisibleOnSelect = true, Position = rGridViewButtonPosition.After });
            rGridViewExamParticipates.CustomButtonClick += rGridViewExamParticipates_CustomButtonClick;
            mFormProcessor = new rFormProcessor.rFormProcessor();
            mFormProcessor.ProcessStep += new EventHandler<ItemEventArgs<ProcessStep>>(mFormProcessor_ProcessStep);
            Image formTemplate = Fakher.Resources.Properties.Resources.Answersheet120_300;
            mFormProcessor.InitializeFormDefinition300(formTemplate);

            rTwainControl1.Initialize(Handle);
        }

        private void mFormProcessor_ProcessStep(object sender, ItemEventArgs<ProcessStep> e)
        {
            if(e.Item == ProcessStep.PreProcess)
                SetStep(1);
            if(e.Item == ProcessStep.FormIdentification)
                SetStep(2);
            if(e.Item == ProcessStep.ReadFields)
                SetStep(3);
        }

        private void SetStep(int step)
        {
            ResetStepLabels();

            if(step == 1)
                lblStep1.Font = new Font(lblStep1.Font.Name, lblStep1.Font.Size, FontStyle.Bold);
            if (step == 2)
                lblStep2.Font = new Font(lblStep2.Font.Name, lblStep2.Font.Size, FontStyle.Bold);
            if (step == 3)
                lblStep3.Font = new Font(lblStep3.Font.Name, lblStep3.Font.Size, FontStyle.Bold);
            if (step == 4)
                lblStep4.Font = new Font(lblStep4.Font.Name, lblStep4.Font.Size, FontStyle.Bold);

            Application.DoEvents();
        }

        private void ResetStepLabels()
        {
            lblStep1.Font = new Font(lblStep1.Font.Name, lblStep1.Font.Size, FontStyle.Regular);
            lblStep2.Font = new Font(lblStep2.Font.Name, lblStep2.Font.Size, FontStyle.Regular);
            lblStep3.Font = new Font(lblStep3.Font.Name, lblStep3.Font.Size, FontStyle.Regular);
            lblStep4.Font = new Font(lblStep4.Font.Name, lblStep4.Font.Size, FontStyle.Regular);

            Application.DoEvents();
        }
        private void rGridViewExamParticipates_CustomButtonClick(object sender,EventArgs e)
        {

            var exam = rGridComboBoxExam.GetValue<Core.DomainModel.Exam>();
            ExamSection examSection = rGridComboBoxExamSection.GetValue<ExamSection>();
            ShowDialogForm(new frmSmsWizard(majorSelector1.Major,exam.Lesson, examSection.SectionItem));
           
        }
        private void radBtnScan_Click(object sender, EventArgs e)
        {
            if (rGridComboBoxExam.Value == null)
            {
                rMessageBox.ShowError("ابتدا یک آزمون را انتخاب کنید.");
                return;
            }

            Core.DomainModel.Exam exam = rGridComboBoxExam.GetValue<Core.DomainModel.Exam>();

            try
            {
                mNormalScanMode = false;
                exam.CheckKey();
                rTwainControl1.Scan();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void radBtnNormalScan_Click(object sender, EventArgs e)
        {
            List<ExamParticipate> checkedParticipates = rGridViewExamParticipates.GetCheckedObjects<ExamParticipate>();
            if (rGridComboBoxExam.Value == null)
            {
                rMessageBox.ShowError("ابتدا یک آزمون را انتخاب کنید.");
                return;
            }
            if (checkedParticipates.Count == 0)
            {
                rMessageBox.ShowError("ابتدا دانشجویان را از لیست انتخاب کنید.");
                return;
            }

            Core.DomainModel.Exam exam = rGridComboBoxExam.GetValue<Core.DomainModel.Exam>();
            
            try
            {
                mNormalScanMode = true;
                exam.CheckKey();
                rTwainControl1.Scan();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
            finally
            {
            }
        }

        private void rTwainControl1_DocumentScanned(object sender, DocumentScannedEventArgs e)
        {
            GC.Collect();

            if(e.Image == null)
                return;

            // For solving Exception "The input image format is not supported by ScanFix"
            //Bitmap jpegImage = TwainImageConverter.ConvertType(e.Image, ImageFormat.Jpeg);
            Process(e.Image);
            //jpegImage.Dispose();
            ResetStepLabels();
        }

        private void Process(Bitmap bitmap)
        {
            ProcessResult processResult = null;
            PaperBasedExamParticipate examParticipate = null;
            Image answerSheetBitmap = null;
//            Bitmap workingBitmap = null;
            try
            {
//                workingBitmap = TwainImageConverter.ConvertType(bitmap, ImageFormat.Jpeg);

                if(!string.IsNullOrEmpty(mSavePath))
                {
                    Bitmap tmpBitmap = new Bitmap(bitmap);
                    tmpBitmap.Save(mSavePath + "\\" + Guid.NewGuid() + ".jpg");
                    tmpBitmap.Dispose();
                }

                radLabelElement1.Text = ((System.Diagnostics.Process.GetCurrentProcess().PrivateMemorySize64/ 1024) / 1024) + " MB";
                pictureBoxCurrent.Image = bitmap;
                Application.DoEvents();

                processResult = mFormProcessor.Process(bitmap);

                SetStep(4);
                if (mNormalScanMode)
                {
                    examParticipate = rGridViewExamParticipates.GetCheckedObjects<PaperBasedExamParticipate>()[0];
                    rGridViewExamParticipates.Select(examParticipate);
                    rGridViewExamParticipates.UnCheck(examParticipate);
                }
                else
                {
                    string codeText;
                    if (!string.IsNullOrEmpty(processResult.Identifier))
                    {
                        try
                        {
                            codeText = Convert.ToInt64(processResult.Identifier) + "";
                        }
                        catch
                        {
                            frmDataEntry frm = new frmDataEntry("شناسه پاسخنامه را وارد کنید؛", "شناسه پاسخنامه:", processResult.RawImage, processResult.Identifier);
                            if (!frm.ProcessObject())
                                throw new Exception("عدم شناسایی شناسه پاسخنامه");
                            codeText = frm.EntryText;
                        }
                    }
                    else
                    {
                        frmDataEntry frm = new frmDataEntry("شناسه پاسخنامه را وارد کنید؛", "شناسه پاسخنامه:", processResult.RawImage, processResult.Identifier);
                        if (!frm.ProcessObject())
                            throw new Exception("سیستم قادر به تشخیص کدینگ این پاسخنامه نمی باشد.");
                        codeText = frm.EntryText;
                    }
                
                    long code = Convert.ToInt64(codeText);
                    examParticipate = PaperBasedExamParticipate.GetExamParticipate(code);
                }
                if (examParticipate != null)
                {
                    examParticipate.SetAnswers(processResult.Answers);
                    examParticipate.Save();

                    answerSheetBitmap = TwainImageConverter.ConvertToThumbnail(processResult.ProcessedImage, 640, 480);
                    mLastProcessedCode = processResult.Identifier;
                }
                else
                {
                    throw new Exception("کدینگ نامعتبر");
                }
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError("سیستم قادر به تصحیح این پاسخنامه نمی باشد. \r\n" + ex.Message);
                if(!string.IsNullOrEmpty(mLastProcessedCode))
                    rMessageBox.ShowInformation("شناسه آخرین پاسخنامه تصحیح شده: " + mLastProcessedCode);
                return;
            }
            finally
            {
                if(answerSheetBitmap != null)
                    pictureBoxPrevious.Image = answerSheetBitmap;
                if (processResult != null)
                    processResult.Dispose();
                pictureBoxCurrent.Image = null;
//                rGridViewExamParticipates.UpdateGridView();
                ResetStepLabels();
                Application.DoEvents();
            }
        }

        private void radBtnReadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files (*.*)|*.*";
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            Bitmap bitmap = (Bitmap)Bitmap.FromFile(dialog.FileName);
            Process(bitmap);
        }

        private void frmReader_FormClosed(object sender, FormClosedEventArgs e)
        {
            rTwainControl1.Dispose();
            mFormProcessor.Dispose();
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            rTwainControl1.SelectSource();
        }

        private void frmReader_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            radLabelElement1.Text = ((System.Diagnostics.Process.GetCurrentProcess().PrivateMemorySize64 / 1024) / 1024) + " MB";
        }

        private void majorSelector1_SelectedChanged(object sender, EventArgs e)
        {
            if (majorSelector1.Major == null)
                return;
            rGridComboBoxEvalItem.DataSource = majorSelector1.Major.GetExamEvaluationItems(Program.CurrentPeriod);
        }

        private void rGridComboBoxExam_SelectedIndexChanged(object sender, EventArgs e)
        {
            Core.DomainModel.Exam exam = rGridComboBoxExam.GetValue<Core.DomainModel.Exam>();
            if(exam == null)
                return;
            rGridComboBoxExamSection.DataSource = exam.ExamSections;
            if(exam.ExamSections.Count == 0)
                Fill(exam, null);
        }

        private void radChkShowUI_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rTwainControl1.ShowUI = radChkShowUI.ToggleState == ToggleState.On;
        }

        private void rGridViewExamParticipates_Edit(object sender, EventArgs e)
        {
            ExamParticipate examParticipate = rGridViewExamParticipates.GetSelectedObject<PaperBasedExamParticipate>();

            if (examParticipate.Status != ExamParticipateStatus.HasResult)
            {
                rMessageBox.ShowError("این پاسخنامه هنوز تصحیح نشده است.");
                return;
            }

            examParticipate.RefreshEntity();
            frmExamParticipateDetail frm = new frmExamParticipateDetail(examParticipate);
            if (!frm.ProcessObject())
                return;
            examParticipate.Save();
            rGridViewExamParticipates.UpdateGridView();
        }

        private void radMenuItem2_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            rTwainControl1.ShowUI = radMenuItem2.IsChecked;
        }

        private void rGridComboBoxEvalItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            EvaluationItem item = rGridComboBoxEvalItem.GetValue<EvaluationItem>();
            if (item == null)
                return;
            rGridComboBoxExam.DataSource = majorSelector1.Major.GetExams(Program.CurrentPeriod, item);
        }

        private void rGridComboBoxExamSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Core.DomainModel.Exam exam = rGridComboBoxExam.GetValue<Core.DomainModel.Exam>();
            ExamSection examSection = rGridComboBoxExamSection.GetValue<ExamSection>();
            if (examSection == null)
                return;
            if(exam == null)
                return;

            Fill(exam, examSection);
        }

        private void Fill(Core.DomainModel.Exam exam, ExamSection examSection)
        {
            try
            {
                rGridViewExamParticipates.Clear();
                exam.CheckKey();
                if(examSection != null)
                    rGridViewExamParticipates.DataBind(exam.GetParticipates(examSection));
                else
                    rGridViewExamParticipates.DataBind(exam.GetParticipates());
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void radCheckBoxElement1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if(radCheckBoxElement1.Checked)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog(this) != DialogResult.OK)
                    return;
                mSavePath = dialog.SelectedPath;
            }
            else
                mSavePath = null;
        }

        private void rTwainControl1_ScanFinished(object sender, EventArgs e)
        {
            rGridViewExamParticipates.UpdateGridView();
        }
    }
}
