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
            // textBoxItem
            // 
            this.MaskedEditBoxElement.CanFocus = true;
            this.MaskedEditBoxElement.Text = "";
            // 
            // rTextBox
            // 
            this.Leave += new System.EventHandler(this.rTextBox_Leave);
            this.Enter += new System.EventHandler(this.rTextBox_Enter);
            this.Initialized += new System.EventHandler(this.rTextBox_Initialized);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
