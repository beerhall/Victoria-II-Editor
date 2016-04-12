namespace Victoria2.Main
{
    partial class Pops
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
            this.checkedListBoxPops = new System.Windows.Forms.CheckedListBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.comboBoxProvince = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // checkedListBoxPops
            // 
            this.checkedListBoxPops.CheckOnClick = true;
            this.checkedListBoxPops.FormattingEnabled = true;
            this.checkedListBoxPops.Location = new System.Drawing.Point(11, 43);
            this.checkedListBoxPops.Margin = new System.Windows.Forms.Padding(2);
            this.checkedListBoxPops.Name = "checkedListBoxPops";
            this.checkedListBoxPops.Size = new System.Drawing.Size(180, 308);
            this.checkedListBoxPops.TabIndex = 1;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(138, 365);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(53, 20);
            this.buttonConfirm.TabIndex = 67;
            this.buttonConfirm.Text = "确定";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(11, 365);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(53, 20);
            this.buttonAdd.TabIndex = 68;
            this.buttonAdd.Text = "增加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // comboBoxProvince
            // 
            this.comboBoxProvince.FormattingEnabled = true;
            this.comboBoxProvince.Location = new System.Drawing.Point(11, 8);
            this.comboBoxProvince.Name = "comboBoxProvince";
            this.comboBoxProvince.Size = new System.Drawing.Size(179, 20);
            this.comboBoxProvince.TabIndex = 69;
            // 
            // Pops
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 409);
            this.Controls.Add(this.comboBoxProvince);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.checkedListBoxPops);
            this.Name = "Pops";
            this.Text = "Pops";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxPops;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ComboBox comboBoxProvince;
    }
}