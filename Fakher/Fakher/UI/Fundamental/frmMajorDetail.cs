using Fakher.Core.DomainModel;
using rComponents;
using rComponents;

namespace Fakher.UI.Struture
{
    public partial class frmMajorDetail : rRadDetailForm
    {
        public frmMajorDetail(Major major)
        {
            InitializeComponent();
            ControlMappings.Add(new ControlMapping
                                         {
                                             Control = radTextBox2,
                                             ControlProperty = "Text",
                                             DataObject = major,
                                             ObjectProperty = "Code",
                                             ConvertNeeded = true
                                         });
            ControlMappings.Add(new ControlMapping
                                         {
                                             Control = radTextBox1,
                                             ControlProperty = "Text",
                                             DataObject = major,
                                             ObjectProperty = "Name"
                                         });
            ControlMappings.Add(new ControlMapping
                                         {
                                             Control = rCheckBox1,
                                             ControlProperty = "IsChecked",
                                             DataObject = major,
                                             ObjectProperty = "InternetRegisterable"
                                         });

            ControlValidations.Add(new RequiredControlValidation
                                            {Control = radTextBox1, Field = "Text", FieldName = "نام رشته"});
            ControlValidations.Add(new RequiredControlValidation
                                            {Control = radTextBox2, Field = "Text", FieldName = "کد رشته"});
        }
    }
}
