namespace Victoria2.Main
{
    partial class Parties
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ( );
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.listBoxPolicies = new System.Windows.Forms.ListBox();
            this.listBoxPolicyValues = new System.Windows.Forms.ListBox();
            this.comboBoxParties = new System.Windows.Forms.ComboBox();
            this.comboBoxIdeologies = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonNewParty = new System.Windows.Forms.Button();
            this.textBoxStartDate = new System.Windows.Forms.TextBox();
            this.textBoxEndDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxPolicies
            // 
            this.listBoxPolicies.FormattingEnabled = true;
            this.listBoxPolicies.ItemHeight = 18;
            this.listBoxPolicies.Location = new System.Drawing.Point(12, 196);
            this.listBoxPolicies.Name = "listBoxPolicies";
            this.listBoxPolicies.Size = new System.Drawing.Size(222, 382);
            this.listBoxPolicies.TabIndex = 0;
            this.listBoxPolicies.SelectedIndexChanged += new System.EventHandler(this.listBoxPolicies_SelectedIndexChanged);
            // 
            // listBoxPolicyValues
            // 
            this.listBoxPolicyValues.FormattingEnabled = true;
            this.listBoxPolicyValues.ItemHeight = 18;
            this.listBoxPolicyValues.Location = new System.Drawing.Point(280, 196);
            this.listBoxPolicyValues.Name = "listBoxPolicyValues";
            this.listBoxPolicyValues.Size = new System.Drawing.Size(222, 382);
            this.listBoxPolicyValues.TabIndex = 1;
            // 
            // comboBoxParties
            // 
            this.comboBoxParties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParties.FormattingEnabled = true;
            this.comboBoxParties.Location = new System.Drawing.Point(12, 62);
            this.comboBoxParties.Name = "comboBoxParties";
            this.comboBoxParties.Size = new System.Drawing.Size(222, 26);
            this.comboBoxParties.TabIndex = 2;
            this.comboBoxParties.SelectedIndexChanged += new System.EventHandler(this.comboBoxParties_SelectedIndexChanged);
            // 
            // comboBoxIdeologies
            // 
            this.comboBoxIdeologies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIdeologies.FormattingEnabled = true;
            this.comboBoxIdeologies.Location = new System.Drawing.Point(280, 62);
            this.comboBoxIdeologies.Name = "comboBoxIdeologies";
            this.comboBoxIdeologies.Size = new System.Drawing.Size(222, 26);
            this.comboBoxIdeologies.TabIndex = 3;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(280, 589);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(222, 38);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonFinish_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "政党";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "意识形态";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "政策";
            // 
            // buttonNewParty
            // 
            this.buttonNewParty.Location = new System.Drawing.Point(12, 589);
            this.buttonNewParty.Name = "buttonNewParty";
            this.buttonNewParty.Size = new System.Drawing.Size(222, 38);
            this.buttonNewParty.TabIndex = 8;
            this.buttonNewParty.Text = "新政党";
            this.buttonNewParty.UseVisualStyleBackColor = true;
            this.buttonNewParty.Click += new System.EventHandler(this.buttonNewParty_Click);
            // 
            // textBoxStartDate
            // 
            this.textBoxStartDate.Location = new System.Drawing.Point(12, 128);
            this.textBoxStartDate.Name = "textBoxStartDate";
            this.textBoxStartDate.Size = new System.Drawing.Size(222, 28);
            this.textBoxStartDate.TabIndex = 9;
            // 
            // textBoxEndDate
            // 
            this.textBoxEndDate.Location = new System.Drawing.Point(280, 128);
            this.textBoxEndDate.Name = "textBoxEndDate";
            this.textBoxEndDate.Size = new System.Drawing.Size(222, 28);
            this.textBoxEndDate.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "开始日期";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "结束日期";
            // 
            // Parties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 652);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxEndDate);
            this.Controls.Add(this.textBoxStartDate);
            this.Controls.Add(this.buttonNewParty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxIdeologies);
            this.Controls.Add(this.comboBoxParties);
            this.Controls.Add(this.listBoxPolicyValues);
            this.Controls.Add(this.listBoxPolicies);
            this.Name = "Parties";
            this.Text = "Parties";
            this.Load += new System.EventHandler(this.Parties_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPolicies;
        private System.Windows.Forms.ListBox listBoxPolicyValues;
        private System.Windows.Forms.ComboBox comboBoxParties;
        private System.Windows.Forms.ComboBox comboBoxIdeologies;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonNewParty;
        private System.Windows.Forms.TextBox textBoxStartDate;
        private System.Windows.Forms.TextBox textBoxEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}