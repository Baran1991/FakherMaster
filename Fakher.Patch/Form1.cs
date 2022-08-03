using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Services;

namespace Fakher.Patch
{
    public partial class Form1 : Form
    {
        private SQLDbOperations dbOperationSource;
        private SQLDbOperations dbOperationDest;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbOperationSource = new SQLDbOperations(".", "TempMIS", "MISUser", "Ju5x7sPT946c");
            dbOperationSource.Progress += new EventHandler<ProgressEventArgs>(dbOperationSource_Progress);
            
            dbOperationDest = new SQLDbOperations(".", "FakherMIS", "MISUser", "Ju5x7sPT946c");
            List<string> tables = dbOperationDest.GetAllDbTable();

            dbOperationDest.Close();

            foreach (string table in tables)
            {
                dbOperationSource.Migrate(table, ".", "FakherMIS", "MISUser", "Ju5x7sPT946c");
            }

            dbOperationSource.Close();
            MessageBox.Show("FINISHED!");
        }

        void dbOperationSource_Progress(object sender, ProgressEventArgs e)
        {
            label1.Text = e.Text + " رکورد " + e.Value + " از " + e.MaxValue;
            progressBar1.Maximum = e.MaxValue;
            progressBar1.Value = e.Value;
            Application.DoEvents();
        }
    }
}
