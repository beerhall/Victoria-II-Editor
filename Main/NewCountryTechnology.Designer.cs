namespace Victoria2.Main
{
    partial class NewCountryTechnology
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
            this.checkedListBoxTechnologies = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // buttonNextStep
            // 
            this.buttonNextStep.Location = new System.Drawing.Point(244, 560);
            this.buttonNextStep.Name = "buttonNextStep";
            this.buttonNextStep.Size = new System.Drawing.Size(101, 37);
            this.buttonNextStep.TabIndex = 5;
            this.buttonNextStep.Text = "下一步";
            this.buttonNextStep.UseVisualStyleBackColor = true;
            this.buttonNextStep.Click += new System.EventHandler(this.buttonNextStep_Click);
            // 
            // buttonPreviousStep
            // 
            this.buttonPreviousStep.Location = new System.Drawing.Point(12, 560);
            this.buttonPreviousStep.Name = "buttonPreviousStep";
            this.buttonPreviousStep.Size = new System.Drawing.Size(101, 37);
            this.buttonPreviousStep.TabIndex = 4;
            this.buttonPreviousStep.Text = "上一步";
            this.buttonPreviousStep.UseVisualStyleBackColor = true;
            this.buttonPreviousStep.Click += new System.EventHandler(this.buttonPreviousStep_Click);
            // 
            // checkedListBoxTechnologies
            // 
            this.checkedListBoxTechnologies.CheckOnClick = true;
            this.checkedListBoxTechnologies.FormattingEnabled = true;
            this.checkedListBoxTechnologies.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxTechnologies.Name = "checkedListBoxTechnologies";
            this.checkedListBoxTechnologies.Size = new System.Drawing.Size(333, 533);
            this.checkedListBoxTechnologies.TabIndex = 3;
            // 
            // NewCountryTechnology
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 612);
            this.ControlBox = false;
            this.Controls.Add(this.buttonNextStep);
            this.Controls.Add(this.buttonPreviousStep);
            this.Controls.Add(this.checkedListBoxTechnologies);
            this.Name = "NewCountryTechnology";
            this.Text = "NewCountryTechnology";
            this.Load += new System.EventHandler(this.NewCountryTechnology_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNextStep;
        private System.Windows.Forms.Button buttonPreviousStep;
        private System.Windows.Forms.CheckedListBox checkedListBoxTechnologies;
    }
}