using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using rComponents;
using rTwain;
using System.Drawing.Imaging;

namespace Fakher.UI.Struture
{
    public partial class frmEducationalToolDetail : rRadDetailForm
    {
        public frmEducationalToolDetail(EducationalTool tool)
        {
            InitializeComponent();

            SetProcessingObject(tool);
            radPageView1.SelectedPage = radPageViewPage1;
            rComboBox1.DataSource = typeof(EducationalToolType).GetEnumDescriptions();

            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = radTextBox1,
                                        ControlProperty = "Text",
                                        DataObject = tool,
                                        ObjectProperty = "Name"
                                    });
            ControlMappings.Add(new ControlMapping
            {
                Control = rComboBox1,
                ControlProperty = "SelectedIndex",
                DataObject = tool,
                ObjectProperty = "Type",
            });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox1,
                                        ControlProperty = "Text",
                                        DataObject = tool,
                                        ObjectProperty = "Author"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rTextBox2,
                                        ControlProperty = "Text",
                                        DataObject = tool,
                                        ObjectProperty = "Description"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = rCheckBox1,
                                        ControlProperty = "Checked",
                                        DataObject = tool,
                                        ObjectProperty = "Disabled"
                                    });
            ControlMappings.Add(new ControlMapping
                                    {
                                        Control = pictureBox1,
                                        ControlProperty = "Image",
                                        DataObject = tool,
                                        ObjectProperty = "Photo.Picture"
                                    });
            ControlMappings.Add(new ControlMapping
            {
                Control = rChkShowInWebsite,
                ControlProperty = "Checked",
                DataObject = tool,
                ObjectProperty = "ShowInWebsite"
            });
            ControlMappings.Add(new ControlMapping
            {
                Control = rChkSellInWebsite,
                ControlProperty = "Checked",
                DataObject = tool,
                ObjectProperty = "SellInWebsite"
            });
        }

        private void lnkSelectFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Picture Files|*.jpg;*.bmp";
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;
            Bitmap convertType = TwainImageConverter.ConvertType(new Bitmap(dialog.FileName), ImageFormat.Jpeg);
            pictureBox1.Image = convertType;
        }

        private void lnkRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            EducationalTool tool = GetProcessingObject<EducationalTool>();

            try
            {
                Validate();
                if (pictureBox1.Image != null && tool.Photo == null)
                    tool.Photo = new Photo();
                if (rChkShowInWebsite.Checked || rChkSellInWebsite.Checked)
                {
                    if (rMessageBox.ShowQuestion("آیا همه اطلاعات اعم از نام، نویسنده، توضیحات، تصویر جلد کتاب و قیمت آن را به طور کامل وارد کرده اید ؟") != DialogResult.Yes)
                    {
                        CancelClosing();
                        return;
                    }
                }
                BindControlsToObject();
            }
            catch (Exception ex)
            {
                rMessageBox.ShowError(ex.Message);
                return;
            }
        }
    }
}
