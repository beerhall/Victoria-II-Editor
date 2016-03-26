namespace Victoria2.Main
{
    partial class SocialReforms
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.listBoxSocialReformsValues = new System.Windows.Forms.ListBox();
            this.listBoxSocialReforms = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(234, 454);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(97, 31);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "确认";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click_1);
            // 
            // listBoxSocialReformsValues
            // 
            this.listBoxSocialReformsValues.FormattingEnabled = true;
            this.listBoxSocialReformsValues.ItemHeight = 18;
            this.listBoxSocialReformsValues.Location = new System.Drawing.Point(283, 12);
            this.listBoxSocialReformsValues.Name = "listBoxSocialReformsValues";
            this.listBoxSocialReformsValues.Size = new System.Drawing.Size(258, 436);
            this.listBoxSocialReformsValues.TabIndex = 5;
            this.listBoxSocialReformsValues.SelectedIndexChanged += new System.EventHandler(this.listBoxSocialReformsValues_SelectedIndexChanged_1);
            // 
            // listBoxSocialReforms
            // 
            this.listBoxSocialReforms.FormattingEnabled = true;
            this.listBoxSocialReforms.ItemHeight = 18;
            this.listBoxSocialReforms.Location = new System.Drawing.Point(19, 12);
            this.listBoxSocialReforms.Name = "listBoxSocialReforms";
            this.listBoxSocialReforms.Size = new System.Drawing.Size(258, 436);
            this.listBoxSocialReforms.TabIndex = 4;
            this.listBoxSocialReforms.SelectedIndexChanged += new System.EventHandler(this.listBoxSocialReforms_SelectedIndexChanged_1);
            // 
            // SocialReforms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 502);
            this.ControlBox = false;
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.listBoxSocialReformsValues);
            this.Controls.Add(this.listBoxSocialReforms);
            this.Name = "SocialReforms";
            this.Text = "SocialReforms";
            this.Load += new System.EventHandler(this.SocialReforms_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ListBox listBoxSocialReformsValues;
        private System.Windows.Forms.ListBox listBoxSocialReforms;
    }
}