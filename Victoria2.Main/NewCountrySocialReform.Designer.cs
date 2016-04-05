namespace Victoria2.Main
{
    partial class NewCountrySocialReforms
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
            this.buttonNextStep = new System.Windows.Forms.Button();
            this.buttonPreviousStep = new System.Windows.Forms.Button();
            this.listBoxSocialReformsValues = new System.Windows.Forms.ListBox();
            this.listBoxSocialReforms = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonNextStep
            // 
            this.buttonNextStep.Location = new System.Drawing.Point(386, 454);
            this.buttonNextStep.Name = "buttonNextStep";
            this.buttonNextStep.Size = new System.Drawing.Size(148, 42);
            this.buttonNextStep.TabIndex = 11;
            this.buttonNextStep.Text = "下一步";
            this.buttonNextStep.UseVisualStyleBackColor = true;
            this.buttonNextStep.Click += new System.EventHandler(this.buttonNextStep_Click);
            // 
            // buttonPreviousStep
            // 
            this.buttonPreviousStep.Location = new System.Drawing.Point(12, 454);
            this.buttonPreviousStep.Name = "buttonPreviousStep";
            this.buttonPreviousStep.Size = new System.Drawing.Size(148, 42);
            this.buttonPreviousStep.TabIndex = 10;
            this.buttonPreviousStep.Text = "上一步";
            this.buttonPreviousStep.UseVisualStyleBackColor = true;
            this.buttonPreviousStep.Click += new System.EventHandler(this.buttonPreviousStep_Click);
            // 
            // listBoxSocialReformsValues
            // 
            this.listBoxSocialReformsValues.FormattingEnabled = true;
            this.listBoxSocialReformsValues.ItemHeight = 18;
            this.listBoxSocialReformsValues.Location = new System.Drawing.Point(276, 12);
            this.listBoxSocialReformsValues.Name = "listBoxSocialReformsValues";
            this.listBoxSocialReformsValues.Size = new System.Drawing.Size(258, 436);
            this.listBoxSocialReformsValues.TabIndex = 9;
            this.listBoxSocialReformsValues.SelectedIndexChanged += new System.EventHandler(this.listBoxSocialReformsValues_SelectedIndexChanged);
            // 
            // listBoxSocialReforms
            // 
            this.listBoxSocialReforms.FormattingEnabled = true;
            this.listBoxSocialReforms.ItemHeight = 18;
            this.listBoxSocialReforms.Location = new System.Drawing.Point(12, 12);
            this.listBoxSocialReforms.Name = "listBoxSocialReforms";
            this.listBoxSocialReforms.Size = new System.Drawing.Size(258, 436);
            this.listBoxSocialReforms.TabIndex = 8;
            this.listBoxSocialReforms.SelectedIndexChanged += new System.EventHandler(this.listBoxSocialReforms_SelectedIndexChanged);
            // 
            // NewCountrySocialReforms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 512);
            this.ControlBox = false;
            this.Controls.Add(this.buttonNextStep);
            this.Controls.Add(this.buttonPreviousStep);
            this.Controls.Add(this.listBoxSocialReformsValues);
            this.Controls.Add(this.listBoxSocialReforms);
            this.Name = "NewCountrySocialReforms";
            this.Text = "NewCountrySocialReform";
            this.Load += new System.EventHandler(this.NewCountrySocialReforms_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNextStep;
        private System.Windows.Forms.Button buttonPreviousStep;
        private System.Windows.Forms.ListBox listBoxSocialReformsValues;
        private System.Windows.Forms.ListBox listBoxSocialReforms;
    }
}