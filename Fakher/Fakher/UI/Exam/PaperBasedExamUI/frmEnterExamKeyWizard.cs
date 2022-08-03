using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using Fakher.Core.Properties;
using rComponents;
using rFormProcessor;
using rTwain;
using Telerik.WinControls.UI;

namespace Fakher.UI.Exam
{
    public partial class frmEnterExamKeyWizard : rRadForm
    {
        private bool mCustomChangeTabs;
        private bool mScanAll;
        private ExamForm mScanAllForm;
        private rFormProcessor.rFormProcessor mFormProcessor;
        private ExamType mExamType;

        public frmEnterExamKeyWizard(ExamType type)
        {
            InitializeComponent();

            mCustomChangeTabs = true;
            radPageView1.SelectedPage = radPageViewPage1;
            mCustomChangeTabs = false;

            mExamType = type;
            mFormProcessor = new rFormProcessor.rFormProcessor();
            Image formTemplate = Fakher.Resources.Properties.Resources.Answersheet120_300;
            mFormProcessor.InitializeFormDefinition300(formTemplate);

            rGridComboBoxForm.Columns.Add("نام فرم آزمون", "نام فرم آزمون", "Name");
            examSelector1.ExamType = mExamType;

            try
            {
                rTwainControl1.Initialize(Handle);
            }
            catch (Exception e)
            {
                rMessageBox.ShowError(e.Message);
                return;
            }

        }

        private int StepIndex
        {
            get
            {
                return radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            }
        }

        private void GotoNextStep()
        {
            mCustomChangeTabs = true;
            int index = radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            if (index + 1 < radPageView1.Pages.Count)
                radPageView1.SelectedPage = radPageView1.Pages[index + 1];
            mCustomChangeTabs = false;
        }

        private void GotoPrevStep()
        {
            mCustomChangeTabs = true;
            int index = radPageView1.Pages.IndexOf(radPageView1.SelectedPage);
            if (index - 1 >= 0)
                radPageView1.SelectedPage = radPageView1.Pages[index - 1];
            mCustomChangeTabs = false;
        }

        private void radPageView1_SelectedPageChanging(object sender, RadPageViewCancelEventArgs e)
        {
            e.Cancel = !mCustomChangeTabs;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (StepIndex == 0)
            {
                if(examSelector1.Exam == null)
                {
                    rMessageBox.ShowError("آزمون را انتخاب کنید.");
                    return;
                }
            }
            if(StepIndex == 1)
            {
                if(rGridComboBoxForm.Value == null)
                {
                    rMessageBox.ShowError("فرم آزمون را انتخاب کنید.");
                    return;
                }
                btnNext.Text = "تـــایــیــد";
            }
            if(StepIndex == 2)
            {
                examSelector1.Exam.Save();
                Close();
            }
            GotoNextStep();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            GotoPrevStep();
        }

        private void frmEnterExamKey_FormClosed(object sender, FormClosedEventArgs e)
        {
            rTwainControl1.Dispose();
            mFormProcessor.Dispose();
        }

        private void lnkSelectSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rTwainControl1.SelectSource();
        }

        private void lnkScan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                rTwainControl1.Scan();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void lnkScanAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (examSelector1.Exam == null)
                return;

            string txt = "";
            for (int i = examSelector1.Exam.Forms.Count - 1; i >= 0 ; i--)
            {
                ExamForm form = examSelector1.Exam.Forms[i];
                txt += form.Name;
                if (i != 0)
                    txt += " ";
            }

            if (rMessageBox.ShowQuestion("لطفا بررسی کنید که کلید فرم ها با ترتیب ( {0} ) در اسکنر قرار گرفته باشند. آیا همه فرم ها با این ترتیب در اسکنر قرار دارند؟", txt) != DialogResult.Yes)
                return;

            try
            {
                mScanAll = true;
                mScanAllForm = examSelector1.Exam.Forms[0];
                rTwainControl1.Scan();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }

        private void Process(Bitmap bitmap)
        {
            ExamForm form = rGridComboBoxForm.GetValue<ExamForm>();
            ProcessResult processResult;
            try
            {
                Application.UseWaitCursor = true;
                processResult = mFormProcessor.Process(bitmap);
                if(mScanAll)
                {
                    form = mScanAllForm;
                    int index = mScanAllForm.Exam.Forms.IndexOf(mScanAllForm);
                    if (index < mScanAllForm.Exam.Forms.Count - 1)
                        mScanAllForm = mScanAllForm.Exam.Forms[index + 1];
                    else
                        mScanAllForm = null;
                }
                
                form.SetKey(processResult.Answers);
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
            finally
            {
                Application.UseWaitCursor = false;
            }

            rLblMessage.Text += string.Format("کلید آزمون {0} فرم {1} وارد گردید" + "\r\n", form.Exam.Name, form.Name);
            rLblMessage2.Text += string.Format("کلید آزمون {0} فرم {1} وارد گردید" + "\r\n", form.Exam.Name, form.Name);
        }

        private void rTwainControl1_DocumentScanned(object sender, DocumentScannedEventArgs e)
        {
            GC.Collect();
            Process(e.Image);
        }

        private void examSelector1_SelectedChanged(object sender, EventArgs e)
        {
            if (examSelector1.Exam == null)
                return;
            rLblMessage2.Text = string.Format("آزمون: {0} " + "\r\n", examSelector1.Exam.FarsiText);
            rGridComboBoxForm.DataSource = examSelector1.Exam.Forms;
        }

        private void lnkManualExamKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExamForm form = rGridComboBoxForm.GetValue<ExamForm>();
            if(form == null)
            {
                rMessageBox.ShowError("فرم آزمون را انتخاب کنید.");
                return;
            }
            frmExamKeyDetail frm = new frmExamKeyDetail(form);
            if (!frm.ProcessObject())
                return;

            rLblMessage.Text += string.Format("کلید آزمون {0} فرم {1} وارد گردید" + "\r\n", form.Exam.Name, form.Name);
            rLblMessage2.Text += string.Format("کلید آزمون {0} فرم {1} وارد گردید" + "\r\n", form.Exam.Name, form.Name);
        }
    }
}
