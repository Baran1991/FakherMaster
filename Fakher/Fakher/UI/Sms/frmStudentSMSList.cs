using DataAccessLayer;
using Fakher.Core;
using Fakher.Core.DomainModel;
using rComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fakher.UI.Persons
{
    public partial class frmStudentSMSList : rRadForm
    {
        public frmStudentSMSList(Core.DomainModel.Person person)
        {
            InitializeComponent();
            //SetProcessingObject(person);
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "متن", ObjectProperty = "Group.Text",Width=500 });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "تاریخ", ObjectProperty = "SendDate" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "ساعت", ObjectProperty = "SendHour" });
            rGridView2.Mappings.Add(new ColumnMapping { Caption = "دقیقه", ObjectProperty = "SendMinute" });
            var mobile = long.Parse(person.ContactInfo.Mobile);
            var smsList = DbContext.GetAll<Sms>().Where(m => m.Number.Trim() == "0" + mobile.ToString()).OrderByDescending(m => m.SendDate);
            rGridView2.DataBind(smsList);
            
        }
      
    }
}
