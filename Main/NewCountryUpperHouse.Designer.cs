namespace Victoria2.Main
{
    partial class NewCountryUpperHouse
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
            this.buttonFinish = new System.Windows.Forms.Button();
            this.numericUpDownValue = new System.Windows.Forms.NumericUpDown();
            this.listBoxIdeologies = new System.Windows.Forms.ListBox();
            this.buttonPreviousStep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValue)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFinish
            // 
            this.buttonFinish.Location = new System.Drawing.Point(178, 354);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(111, 37);
            this.buttonFinish.TabIndex = 5;
            this.buttonFinish.Text = "完成";
            this.buttonFinish.UseVisualStyleBackColor = true;
            this.buttonFinish.Click += new System.EventHandler(this.buttonFinish_Click);
            // 
            // numericUpDownValue
            // 
            this.numericUpDownValue.Location = new System.Drawing.Point(12, 318);
            this.numericUpDownValue.Name = "numericUpDownValue";
            this.numericUpDownValue.Size = new System.Drawing.Size(269, 28);
            this.numericUpDownValue.TabIndex = 4;
            this.numericUpDownValue.ValueChanged += new System.EventHandler(this.numericUpDownValue_ValueChanged);
            // 
            // listBoxIdeologies
            // 
            this.listBoxIdeologies.FormattingEnabled = true;
            this.listBoxIdeologies.ItemHeight = 18;
            this.listBoxIdeologies.Location = new System.Drawing.Point(12, 12);
            this.listBoxIdeologies.Name = "listBoxIdeologies";
            this.listBoxIdeologies.Size = new System.Drawing.Size(270, 292);
            this.listBoxIdeologies.TabIndex = 3;
            this.listBoxIdeologies.SelectedIndexChanged += new System.EventHandler(this.listBoxIdeologies_SelectedIndexChanged);
            // 
            // buttonPreviousStep
            // 
            this.buttonPreviousStep.Location = new System.Drawing.Point(12, 354);
            this.buttonPreviousStep.Name = "buttonPreviousStep";
            this.buttonPreviousStep.Size = new System.Drawing.Size(111, 37);
            this.buttonPreviousStep.TabIndex = 6;
            this.buttonPreviousStep.Text = "上一步";
            this.buttonPreviousStep.UseVisualStyleBackColor = true;
            this.buttonPreviousStep.Click += new System.EventHandler(this.buttonPreviousStep_Click);
            // 
            // NewCountryUpperHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 401);
            this.Controls.Add(this.buttonPreviousStep);
            this.Controls.Add(this.buttonFinish);
            this.Controls.Add(this.numericUpDownValue);
            this.Controls.Add(this.listBoxIdeologies);
            this.Name = "NewCountryUpperHouse";
            this.Text = "NewCountryUpperHouse";
            this.Load += new System.EventHandler(this.NewCountryUpperHouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFinish;
        private System.Windows.Forms.NumericUpDown numericUpDownValue;
        private System.Windows.Forms.ListBox listBoxIdeologies;
        private System.Windows.Forms.Button buttonPreviousStep;
    }
}