namespace rComponents
{
    partial class rTextBox
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
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxElement
            // 
            this.textBoxElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
            this.textBoxElement.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxElement.Padding = new System.Windows.Forms.Padding(2, 2, 2, 3);
            this.textBoxElement.StretchVertically = false;
            this.textBoxElement.Text = "";
            // 
            // textBoxItem
            // 
            this.textBoxItem.CanFocus = true;
            this.textBoxItem.Text = "";
            // 
            // rTextBox
            // 
            this.Enter += new System.EventHandler(this.rTextBox_Enter);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rTextBox_KeyPress);
            this.Initialized += new System.EventHandler(this.rTextBox_Initialized);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
