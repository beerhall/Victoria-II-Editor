namespace Victoria2.Main
{
    partial class NewGovernment
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
            this.buttonSaveGovernments = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.comboBoxFlagType = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.numericUpDownDuration = new System.Windows.Forms.NumericUpDown();
            this.checkBoxAppointRulingParty = new System.Windows.Forms.CheckBox();
            this.checkBoxElection = new System.Windows.Forms.CheckBox();
            this.checkedListBoxIdeologies = new System.Windows.Forms.CheckedListBox();
            this.buttonCancelGovernment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGovernmentName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSaveGovernments
            // 
            this.buttonSaveGovernments.Location = new System.Drawing.Point(276, 422);
            this.buttonSaveGovernments.Name = "buttonSaveGovernments";
            this.buttonSaveGovernments.Size = new System.Drawing.Size(86, 36);
            this.buttonSaveGovernments.TabIndex = 20;
            this.buttonSaveGovernments.Text = "保存";
            this.buttonSaveGovernments.UseVisualStyleBackColor = true;
            this.buttonSaveGovernments.Click += new System.EventHandler(this.buttonSaveGovernments_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(12, 18);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(134, 18);
            this.label30.TabIndex = 19;
            this.label30.Text = "允许的意识形态";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(276, 322);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(80, 18);
            this.label28.TabIndex = 18;
            this.label28.Text = "旗帜风格";
            // 
            // comboBoxFlagType
            // 
            this.comboBoxFlagType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFlagType.FormattingEnabled = true;
            this.comboBoxFlagType.Items.AddRange(new object[] {
            "默认",
            "communist",
            "republic",
            "fascist",
            "monarchy"});
            this.comboBoxFlagType.Location = new System.Drawing.Point(276, 368);
            this.comboBoxFlagType.Name = "comboBoxFlagType";
            this.comboBoxFlagType.Size = new System.Drawing.Size(203, 26);
            this.comboBoxFlagType.TabIndex = 17;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(276, 220);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(80, 18);
            this.label29.TabIndex = 16;
            this.label29.Text = "选举间隔";
            // 
            // numericUpDownDuration
            // 
            this.numericUpDownDuration.Enabled = false;
            this.numericUpDownDuration.Location = new System.Drawing.Point(276, 266);
            this.numericUpDownDuration.Name = "numericUpDownDuration";
            this.numericUpDownDuration.Size = new System.Drawing.Size(203, 28);
            this.numericUpDownDuration.TabIndex = 15;
            // 
            // checkBoxAppointRulingParty
            // 
            this.checkBoxAppointRulingParty.AutoSize = true;
            this.checkBoxAppointRulingParty.Location = new System.Drawing.Point(276, 170);
            this.checkBoxAppointRulingParty.Name = "checkBoxAppointRulingParty";
            this.checkBoxAppointRulingParty.Size = new System.Drawing.Size(124, 22);
            this.checkBoxAppointRulingParty.TabIndex = 14;
            this.checkBoxAppointRulingParty.Text = "指定执政党";
            this.checkBoxAppointRulingParty.UseVisualStyleBackColor = true;
            // 
            // checkBoxElection
            // 
            this.checkBoxElection.AutoSize = true;
            this.checkBoxElection.Location = new System.Drawing.Point(276, 120);
            this.checkBoxElection.Name = "checkBoxElection";
            this.checkBoxElection.Size = new System.Drawing.Size(70, 22);
            this.checkBoxElection.TabIndex = 13;
            this.checkBoxElection.Text = "选举";
            this.checkBoxElection.UseVisualStyleBackColor = true;
            this.checkBoxElection.CheckedChanged += new System.EventHandler(this.checkBoxElection_CheckedChanged);
            // 
            // checkedListBoxIdeologies
            // 
            this.checkedListBoxIdeologies.CheckOnClick = true;
            this.checkedListBoxIdeologies.FormattingEnabled = true;
            this.checkedListBoxIdeologies.Location = new System.Drawing.Point(3, 48);
            this.checkedListBoxIdeologies.Name = "checkedListBoxIdeologies";
            this.checkedListBoxIdeologies.Size = new System.Drawing.Size(252, 418);
            this.checkedListBoxIdeologies.TabIndex = 12;
            // 
            // buttonCancelGovernment
            // 
            this.buttonCancelGovernment.Location = new System.Drawing.Point(393, 422);
            this.buttonCancelGovernment.Name = "buttonCancelGovernment";
            this.buttonCancelGovernment.Size = new System.Drawing.Size(86, 36);
            this.buttonCancelGovernment.TabIndex = 21;
            this.buttonCancelGovernment.Text = "取消";
            this.buttonCancelGovernment.UseVisualStyleBackColor = true;
            this.buttonCancelGovernment.Click += new System.EventHandler(this.buttonCancelGovernment_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "政体名";
            // 
            // textBoxGovernmentName
            // 
            this.textBoxGovernmentName.Location = new System.Drawing.Point(276, 64);
            this.textBoxGovernmentName.Name = "textBoxGovernmentName";
            this.textBoxGovernmentName.Size = new System.Drawing.Size(203, 28);
            this.textBoxGovernmentName.TabIndex = 23;
            // 
            // NewGovernment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 479);
            this.Controls.Add(this.textBoxGovernmentName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancelGovernment);
            this.Controls.Add(this.buttonSaveGovernments);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.comboBoxFlagType);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.numericUpDownDuration);
            this.Controls.Add(this.checkBoxAppointRulingParty);
            this.Controls.Add(this.checkBoxElection);
            this.Controls.Add(this.checkedListBoxIdeologies);
            this.Name = "NewGovernment";
            this.Text = "NewGovernment";
            this.Load += new System.EventHandler(this.NewGovernment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveGovernments;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox comboBoxFlagType;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.NumericUpDown numericUpDownDuration;
        private System.Windows.Forms.CheckBox checkBoxAppointRulingParty;
        private System.Windows.Forms.CheckBox checkBoxElection;
        private System.Windows.Forms.CheckedListBox checkedListBoxIdeologies;
        private System.Windows.Forms.Button buttonCancelGovernment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxGovernmentName;
    }
}