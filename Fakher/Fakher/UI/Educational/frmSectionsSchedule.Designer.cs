﻿namespace Fakher.UI.Holding
{
    partial class frmSectionsSchedule
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
            this.rScheduler1 = new rComponents.rScheduler();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rScheduler1
            // 
            this.rScheduler1.ActiveViewType = Telerik.WinControls.UI.SchedulerViewType.Week;
            this.rScheduler1.CanPrint = true;
            this.rScheduler1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rScheduler1.Location = new System.Drawing.Point(0, 0);
            this.rScheduler1.Name = "rScheduler1";
            this.rScheduler1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rScheduler1.ShowNavigator = true;
            this.rScheduler1.Size = new System.Drawing.Size(817, 446);
            this.rScheduler1.TabIndex = 0;
            // 
            // frmSectionsSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 446);
            this.Controls.Add(this.rScheduler1);
            this.Name = "frmSectionsSchedule";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "برنامه آموزشی موسسه";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private rComponents.rScheduler rScheduler1;

    }
}