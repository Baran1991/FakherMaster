using System;

namespace rComponents
{
    partial class rComboBox
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.dropDownListElement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dropDownListElement
            // 
            this.dropDownListElement.BackColor = System.Drawing.SystemColors.Control;
            this.dropDownListElement.Font = new System.Drawing.Font("Tahoma", 8.25F);
            // 
            // rComboBox
            // 
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Leave += new System.EventHandler(this.rComboBox_Leave);
            this.Enter += new System.EventHandler(this.rComboBox_Enter);
            this.ItemDataBound += new Telerik.WinControls.UI.ListItemDataBoundEventHandler(this.rComboBox_ItemDataBound);
            this.Initialized += new System.EventHandler(this.rComboBox_Initialized);
            ((System.ComponentModel.ISupportInitialize)(this.dropDownListElement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
