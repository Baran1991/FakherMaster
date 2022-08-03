using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakher.Core.DomainModel;
using Fakher.UI.Person;
using rComponents;

namespace Fakher.UI.Educational
{
    [Obsolete]
    public partial class frmSignup : rRadForm
    {
        public Student mStudent;
        public Register mRegister;

        public frmSignup()
        {
            InitializeComponent();
        }

        private void radBtnPerson_Click(object sender, EventArgs e)
        {
            mStudent = new Student();
            frmPersonDetail frm = new frmPersonDetail(mStudent);
            frm.ShowDialog(this);
        }

        private void radBtnRegister_Click(object sender, EventArgs e)
        {
            mRegister = new Register { Student = mStudent};
            frmRegister frm = new frmRegister(mRegister);
            frm.ShowDialog(this);
        }

        private void radBtnParticipate_Click(object sender, EventArgs e)
        {
//            mParticipate = new Participate { Register = mRegister };
//            frmParticipateDetail frm = new frmParticipateDetail(mParticipate);
//            frm.ShowDialog(this);
        }
    }
}
