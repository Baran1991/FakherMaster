namespace Fakher
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.rHtmlEditorToolbar1 = new rComponents.rHtmlEditorToolbar();
            this.rHtmlEditor1 = new rComponents.rHtmlEditor();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rHtmlEditorToolbar1
            // 
            this.rHtmlEditorToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rHtmlEditorToolbar1.FontSize = rComponents.FontSize.Three;
            this.rHtmlEditorToolbar1.HtmlEditor = this.rHtmlEditor1;
            this.rHtmlEditorToolbar1.Location = new System.Drawing.Point(0, 0);
            this.rHtmlEditorToolbar1.Name = "rHtmlEditorToolbar1";
            this.rHtmlEditorToolbar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rHtmlEditorToolbar1.Size = new System.Drawing.Size(771, 50);
            this.rHtmlEditorToolbar1.TabIndex = 0;
            // 
            // rHtmlEditor1
            // 
            this.rHtmlEditor1.BodyHtml = null;
            this.rHtmlEditor1.BodyText = null;
            this.rHtmlEditor1.DocumentText = resources.GetString("rHtmlEditor1.DocumentText");
            this.rHtmlEditor1.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rHtmlEditor1.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rHtmlEditor1.Location = new System.Drawing.Point(16, 76);
            this.rHtmlEditor1.Name = "rHtmlEditor1";
            this.rHtmlEditor1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rHtmlEditor1.Size = new System.Drawing.Size(735, 302);
            this.rHtmlEditor1.TabIndex = 1;
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(12, 384);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(130, 24);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "radButton1";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 420);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.rHtmlEditor1);
            this.Controls.Add(this.rHtmlEditorToolbar1);
            this.Name = "Form3";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private rComponents.rHtmlEditorToolbar rHtmlEditorToolbar1;
        private rComponents.rHtmlEditor rHtmlEditor1;
        private Telerik.WinControls.UI.RadButton radButton1;



    }
}