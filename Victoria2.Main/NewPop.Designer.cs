namespace Victoria2.Main
{
    partial class NewPop
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
            this.comboBoxCulture = new System.Windows.Forms.ComboBox();
            this.comboBoxReligion = new System.Windows.Forms.ComboBox();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPoptype = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxCulture
            // 
            this.comboBoxCulture.FormattingEnabled = true;
            this.comboBoxCulture.Location = new System.Drawing.Point(23, 70);
            this.comboBoxCulture.Name = "comboBoxCulture";
            this.comboBoxCulture.Size = new System.Drawing.Size(112, 20);
            this.comboBoxCulture.TabIndex = 0;
            // 
            // comboBoxReligion
            // 
            this.comboBoxReligion.FormattingEnabled = true;
            this.comboBoxReligion.Location = new System.Drawing.Point(23, 113);
            this.comboBoxReligion.Name = "comboBoxReligion";
            this.comboBoxReligion.Size = new System.Drawing.Size(112, 20);
            this.comboBoxReligion.TabIndex = 1;
            // 
            // textBoxSize
            // 
            this.textBoxSize.Location = new System.Drawing.Point(23, 155);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(111, 21);
            this.textBoxSize.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "文化";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "宗教";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "大小";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(46, 199);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(53, 20);
            this.buttonConfirm.TabIndex = 66;
            this.buttonConfirm.Text = "确定";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 68;
            this.label4.Text = "职业";
            // 
            // comboBoxPoptype
            // 
            this.comboBoxPoptype.FormattingEnabled = true;
            this.comboBoxPoptype.Location = new System.Drawing.Point(22, 29);
            this.comboBoxPoptype.Name = "comboBoxPoptype";
            this.comboBoxPoptype.Size = new System.Drawing.Size(112, 20);
            this.comboBoxPoptype.TabIndex = 67;
            // 
            // NewPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(157, 229);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxPoptype);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSize);
            this.Controls.Add(this.comboBoxReligion);
            this.Controls.Add(this.comboBoxCulture);
            this.Name = "NewPop";
            this.Text = "NewPop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCulture;
        private System.Windows.Forms.ComboBox comboBoxReligion;
        private System.Windows.Forms.TextBox textBoxSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxPoptype;

    }
}