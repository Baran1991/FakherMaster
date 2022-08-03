using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using Fakher.Core.DomainModel;
using rComponents;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace Fakher.UI.Holding
{
    public partial class frmSectionsSchedule : rRadForm
    {
        // Custom Date Time Format Strings : http://msdn.microsoft.com/en-us/library/8kb3ddd4.aspx
        public frmSectionsSchedule()
        {
            InitializeComponent();
            List<Section> sections = Section.GetSections(Program.CurrentPeriod);
//            List<Section> sections = DbContext.GetAllEntities<Section>();
            rScheduler1.Fill(sections);
        }
    }
}
