namespace Victoria2.Main
{
    partial class NewCountryPoliticalReforms
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
            this.listBoxPoliticalReformsValues = new System.Windows.Forms.ListBox();
            this.listBoxPoliticalReforms = new System.Windows.Forms.ListBox();
            this.buttonPreviousStep = new System.Windows.Forms.Button();
            this.buttonNextStep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxPoliticalReformsValues
            // 
            this.listBoxPoliticalReformsValues.FormattingEnabled = true;
            this.listBoxPoliticalReformsValues.ItemHeight = 18;
            this.listBoxPoliticalReformsValues.Location = new System.Drawing.Point(276, 12);
            this.listBoxPoliticalReformsValues.Name = "listBoxPoliticalReformsValues";
            this.listBoxPoliticalReformsValues.Size = new System.Drawing.Size(258, 436);
            this.listBoxPoliticalReformsValues.TabIndex = 5;
            this.listBoxPoliticalReformsValues.SelectedIndexChanged += new System.EventHandler(this.listBoxPoliticalReformsValues_SelectedIndexChanged);
            // 
            // listBoxPoliticalReforms
            // 
            this.listBoxPoliticalReforms.FormattingEnabled = true;
            this.listBoxPoliticalReforms.ItemHeight = 18;
            this.listBoxPoliticalReforms.Location = new System.Drawing.Point(12, 12);
            this.listBoxPoliticalReforms.Name = "listBoxPoliticalReforms";
            this.listBoxPoliticalReforms.Size = new System.Drawing.Size(258, 436);
            this.listBoxPoliticalReforms.TabIndex = 4;
            this.listBoxPoliticalReforms.SelectedIndexChanged += new System.EventHandler(this.listBoxPoliticalReforms_SelectedIndexChanged);
            // 
            // buttonPreviousStep
            // 
            this.buttonPreviousStep.Location = new System.Drawing.Point(12, 454);
            this.buttonPreviousStep.Name = "buttonPreviousStep";
            this.buttonPreviousStep.Size = new System.Drawing.Size(148, 42);
            this.buttonPreviousStep.TabIndex = 6;
            this.buttonPreviousStep.Text = "上一步";
            this.buttonPreviousStep.UseVisualStyleBackColor = true;
            this.buttonPreviousStep.Click += new System.EventHandler(this.buttonPreviousStep_Click);
            // 
            // buttonNextStep
            // 
            this.buttonNextStep.Location = new System.Drawing.Point(386, 454);
            this.buttonNextStep.Name = "buttonNextStep";
            this.buttonNextStep.Size = new System.Drawing.Size(148, 42);
            this.buttonNextStep.TabIndex = 7;
            this.buttonNextStep.Text = "下一步";
            this.buttonNextStep.UseVisualStyleBackColor = true;
            this.buttonNextStep.Click += new System.EventHandler(this.buttonNextStep_Click);
            // 
            // NewCountryPoliticalReforms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 508);
            this.ControlBox = false;
            this.Controls.Add(this.buttonNextStep);
            this.Controls.Add(this.buttonPreviousStep);
            this.Controls.Add(this.listBoxPoliticalReformsValues);
            this.Controls.Add(this.listBoxPoliticalReforms);
            this.Name = "NewCountryPoliticalReforms";
            this.Text = "NewCountryPoliticalReforms";
            this.Load += new System.EventHandler(this.NewCountryPoliticalReforms_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPoliticalReformsValues;
        private System.Windows.Forms.ListBox listBoxPoliticalReforms;
        private System.Windows.Forms.Button buttonPreviousStep;
        private System.Windows.Forms.Button buttonNextStep;
    }
}