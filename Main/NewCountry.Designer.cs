namespace Victoria2.Main
{
    partial class NewCountry
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCountryTagName = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCountryName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonNextStep
            // 
            this.buttonNextStep.Location = new System.Drawing.Point(12, 196);
            this.buttonNextStep.Name = "buttonNextStep";
            this.buttonNextStep.Size = new System.Drawing.Size(109, 36);
            this.buttonNextStep.TabIndex = 92;
            this.buttonNextStep.Text = "下一步";
            this.buttonNextStep.UseVisualStyleBackColor = true;
            this.buttonNextStep.Click += new System.EventHandler(this.buttonNextStep_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 76;
            this.label2.Text = "国家简称";
            // 
            // textBoxCountryTagName
            // 
            this.textBoxCountryTagName.Location = new System.Drawing.Point(12, 59);
            this.textBoxCountryTagName.Name = "textBoxCountryTagName";
            this.textBoxCountryTagName.Size = new System.Drawing.Size(235, 28);
            this.textBoxCountryTagName.TabIndex = 72;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(138, 196);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(109, 36);
            this.buttonCancel.TabIndex = 95;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 96;
            this.label1.Text = "国家名";
            // 
            // textBoxCountryName
            // 
            this.textBoxCountryName.Location = new System.Drawing.Point(12, 147);
            this.textBoxCountryName.Name = "textBoxCountryName";
            this.textBoxCountryName.Size = new System.Drawing.Size(235, 28);
            this.textBoxCountryName.TabIndex = 97;
            // 
            // NewCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 255);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxCountryName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonNextStep);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCountryTagName);
            this.Name = "NewCountry";
            this.Text = "NewCountry";
            //this.Load += new System.EventHandler(this.NewCountry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNextStep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCountryTagName;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCountryName;
    }
}