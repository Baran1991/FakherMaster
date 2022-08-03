using Telerik.WinControls.UI;

namespace Fakher.UI.Report
{
    partial class frmWait
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rWaitingBar2 = new Telerik.WinControls.UI.RadWaitingBar();
            this.rLabel1 = new rComponents.rLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rWaitingBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // rWaitingBar2
            // 
            this.rWaitingBar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rWaitingBar2.Location = new System.Drawing.Point(0, 31);
            this.rWaitingBar2.Name = "rWaitingBar2";
            this.rWaitingBar2.Size = new System.Drawing.Size(350, 38);
            this.rWaitingBar2.TabIndex = 0;
            this.rWaitingBar2.Text = "جمع آوری داده ...";
            this.rWaitingBar2.ThemeName = "ControlDefault";
            this.rWaitingBar2.WaitingIndicatorWidth = 50;
            this.rWaitingBar2.WaitingSpeed = 10;
            // 
            // rLabel1
            // 
            this.rLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rLabel1.AutoSize = false;
            this.rLabel1.BackColor = System.Drawing.Color.Transparent;
            this.rLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLabel1.ForeColor = System.Drawing.Color.Black;
            this.rLabel1.Location = new System.Drawing.Point(0, 18);
            this.rLabel1.Name = "rLabel1";
            // 
            // 
            // 
            this.rLabel1.RootElement.ForeColor = System.Drawing.Color.Black;
            this.rLabel1.Size = new System.Drawing.Size(367, 19);
            this.rLabel1.TabIndex = 1;
            this.rLabel1.Text = "در حال جمع آوری داده ...";
            this.rLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmWait
            // 
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(350, 69);
            this.ControlBox = false;
            this.Controls.Add(this.rLabel1);
            this.Controls.Add(this.rWaitingBar2);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWait";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.rWaitingBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLabel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RadWaitingBar rWaitingBar2;
        private rComponents.rLabel rLabel1;
    }
}