namespace Victoria2.Main
{
    partial class NewCountryParty
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
            this.listBoxParties = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.comboBoxWarPolicy = new System.Windows.Forms.ComboBox();
            this.comboBoxCitizenshipPolicy = new System.Windows.Forms.ComboBox();
            this.comboBoxReligiousPolicy = new System.Windows.Forms.ComboBox();
            this.comboBoxTradePolicy = new System.Windows.Forms.ComboBox();
            this.comboBoxEconomicPolicy = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxIdeologies = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEndDate = new System.Windows.Forms.TextBox();
            this.textBoxStartDate = new System.Windows.Forms.TextBox();
            this.buttonNextStep = new System.Windows.Forms.Button();
            this.buttonPreviousStep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxParties
            // 
            this.listBoxParties.FormattingEnabled = true;
            this.listBoxParties.ItemHeight = 18;
            this.listBoxParties.Location = new System.Drawing.Point(9, 13);
            this.listBoxParties.Name = "listBoxParties";
            this.listBoxParties.Size = new System.Drawing.Size(314, 346);
            this.listBoxParties.TabIndex = 0;
            this.listBoxParties.SelectedIndexChanged += new System.EventHandler(this.listBoxParties_SelectedIndexChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(9, 374);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(133, 51);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "添加政党";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(190, 374);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(133, 51);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = "移除政党";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // comboBoxWarPolicy
            // 
            this.comboBoxWarPolicy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWarPolicy.FormattingEnabled = true;
            this.comboBoxWarPolicy.Location = new System.Drawing.Point(349, 460);
            this.comboBoxWarPolicy.Name = "comboBoxWarPolicy";
            this.comboBoxWarPolicy.Size = new System.Drawing.Size(240, 26);
            this.comboBoxWarPolicy.TabIndex = 40;
            // 
            // comboBoxCitizenshipPolicy
            // 
            this.comboBoxCitizenshipPolicy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCitizenshipPolicy.FormattingEnabled = true;
            this.comboBoxCitizenshipPolicy.Location = new System.Drawing.Point(349, 400);
            this.comboBoxCitizenshipPolicy.Name = "comboBoxCitizenshipPolicy";
            this.comboBoxCitizenshipPolicy.Size = new System.Drawing.Size(240, 26);
            this.comboBoxCitizenshipPolicy.TabIndex = 39;
            // 
            // comboBoxReligiousPolicy
            // 
            this.comboBoxReligiousPolicy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReligiousPolicy.FormattingEnabled = true;
            this.comboBoxReligiousPolicy.Location = new System.Drawing.Point(349, 340);
            this.comboBoxReligiousPolicy.Name = "comboBoxReligiousPolicy";
            this.comboBoxReligiousPolicy.Size = new System.Drawing.Size(240, 26);
            this.comboBoxReligiousPolicy.TabIndex = 38;
            // 
            // comboBoxTradePolicy
            // 
            this.comboBoxTradePolicy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTradePolicy.FormattingEnabled = true;
            this.comboBoxTradePolicy.Location = new System.Drawing.Point(349, 280);
            this.comboBoxTradePolicy.Name = "comboBoxTradePolicy";
            this.comboBoxTradePolicy.Size = new System.Drawing.Size(240, 26);
            this.comboBoxTradePolicy.TabIndex = 37;
            // 
            // comboBoxEconomicPolicy
            // 
            this.comboBoxEconomicPolicy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEconomicPolicy.FormattingEnabled = true;
            this.comboBoxEconomicPolicy.Location = new System.Drawing.Point(349, 220);
            this.comboBoxEconomicPolicy.Name = "comboBoxEconomicPolicy";
            this.comboBoxEconomicPolicy.Size = new System.Drawing.Size(240, 26);
            this.comboBoxEconomicPolicy.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(349, 434);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 18);
            this.label10.TabIndex = 35;
            this.label10.Text = "战争政策";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(349, 374);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 18);
            this.label9.TabIndex = 34;
            this.label9.Text = "公民权政策";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(349, 314);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 33;
            this.label8.Text = "宗教政策";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(349, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 32;
            this.label7.Text = "贸易政策";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(349, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 31;
            this.label6.Text = "经济政策";
            // 
            // comboBoxIdeologies
            // 
            this.comboBoxIdeologies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIdeologies.FormattingEnabled = true;
            this.comboBoxIdeologies.Location = new System.Drawing.Point(349, 160);
            this.comboBoxIdeologies.Name = "comboBoxIdeologies";
            this.comboBoxIdeologies.Size = new System.Drawing.Size(240, 26);
            this.comboBoxIdeologies.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 29;
            this.label5.Text = "意识形态";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(349, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 28;
            this.label4.Text = "解散日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 27;
            this.label1.Text = "建立日期";
            // 
            // textBoxEndDate
            // 
            this.textBoxEndDate.Location = new System.Drawing.Point(349, 98);
            this.textBoxEndDate.Name = "textBoxEndDate";
            this.textBoxEndDate.ReadOnly = true;
            this.textBoxEndDate.Size = new System.Drawing.Size(240, 28);
            this.textBoxEndDate.TabIndex = 26;
            // 
            // textBoxStartDate
            // 
            this.textBoxStartDate.Location = new System.Drawing.Point(349, 36);
            this.textBoxStartDate.Name = "textBoxStartDate";
            this.textBoxStartDate.ReadOnly = true;
            this.textBoxStartDate.Size = new System.Drawing.Size(240, 28);
            this.textBoxStartDate.TabIndex = 25;
            // 
            // buttonNextStep
            // 
            this.buttonNextStep.Location = new System.Drawing.Point(190, 435);
            this.buttonNextStep.Name = "buttonNextStep";
            this.buttonNextStep.Size = new System.Drawing.Size(133, 51);
            this.buttonNextStep.TabIndex = 41;
            this.buttonNextStep.Text = "下一步";
            this.buttonNextStep.UseVisualStyleBackColor = true;
            this.buttonNextStep.Click += new System.EventHandler(this.buttonNextStep_Click);
            // 
            // buttonPreviousStep
            // 
            this.buttonPreviousStep.Location = new System.Drawing.Point(9, 435);
            this.buttonPreviousStep.Name = "buttonPreviousStep";
            this.buttonPreviousStep.Size = new System.Drawing.Size(133, 51);
            this.buttonPreviousStep.TabIndex = 42;
            this.buttonPreviousStep.Text = "上一步";
            this.buttonPreviousStep.UseVisualStyleBackColor = true;
            this.buttonPreviousStep.Click += new System.EventHandler(this.buttonPreviousStep_Click);
            // 
            // NewCountryParty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 511);
            this.ControlBox = false;
            this.Controls.Add(this.buttonPreviousStep);
            this.Controls.Add(this.buttonNextStep);
            this.Controls.Add(this.comboBoxWarPolicy);
            this.Controls.Add(this.comboBoxCitizenshipPolicy);
            this.Controls.Add(this.comboBoxReligiousPolicy);
            this.Controls.Add(this.comboBoxTradePolicy);
            this.Controls.Add(this.comboBoxEconomicPolicy);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxIdeologies);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEndDate);
            this.Controls.Add(this.textBoxStartDate);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoxParties);
            this.Name = "NewCountryParty";
            this.Text = "NewCountryParty";
            this.Load += new System.EventHandler(this.NewCountryParty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxParties;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ComboBox comboBoxWarPolicy;
        private System.Windows.Forms.ComboBox comboBoxCitizenshipPolicy;
        private System.Windows.Forms.ComboBox comboBoxReligiousPolicy;
        private System.Windows.Forms.ComboBox comboBoxTradePolicy;
        private System.Windows.Forms.ComboBox comboBoxEconomicPolicy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxIdeologies;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEndDate;
        private System.Windows.Forms.TextBox textBoxStartDate;
        private System.Windows.Forms.Button buttonNextStep;
        private System.Windows.Forms.Button buttonPreviousStep;

    }
}