namespace Victoria2.Main
{
    partial class Technology
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
            this.checkedListBoxTechnologies = new System.Windows.Forms.CheckedListBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBoxTechnologies
            // 
            this.checkedListBoxTechnologies.CheckOnClick = true;
            this.checkedListBoxTechnologies.FormattingEnabled = true;
            this.checkedListBoxTechnologies.Location = new System.Drawing.Point(10, 7);
            this.checkedListBoxTechnologies.Name = "checkedListBoxTechnologies";
            this.checkedListBoxTechnologies.Size = new System.Drawing.Size(333, 533);
            this.checkedListBoxTechnologies.TabIndex = 0;
            //this.checkedListBoxTechnologies.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxTechnologies_SelectedIndexChanged);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(68, 555);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(101, 52);
            this.buttonConfirm.TabIndex = 1;
            this.buttonConfirm.Text = "确定";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(175, 555);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(101, 52);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // Technology
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 618);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.checkedListBoxTechnologies);
            this.Name = "Technology";
            this.Text = "Technology";
            this.Load += new System.EventHandler(this.Technology_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxTechnologies;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
    }
}