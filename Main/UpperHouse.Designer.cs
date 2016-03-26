namespace Victoria2.Main
{
    partial class UpperHouse
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
            this.listBoxIdeologies = new System.Windows.Forms.ListBox();
            this.numericUpDownValue = new System.Windows.Forms.NumericUpDown();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValue)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxIdeologies
            // 
            this.listBoxIdeologies.FormattingEnabled = true;
            this.listBoxIdeologies.ItemHeight = 18;
            this.listBoxIdeologies.Location = new System.Drawing.Point(12, 6);
            this.listBoxIdeologies.Name = "listBoxIdeologies";
            this.listBoxIdeologies.Size = new System.Drawing.Size(270, 292);
            this.listBoxIdeologies.TabIndex = 0;
            this.listBoxIdeologies.SelectedIndexChanged += new System.EventHandler(this.listBoxIdeologies_SelectedIndexChanged);
            // 
            // numericUpDownValue
            // 
            this.numericUpDownValue.Location = new System.Drawing.Point(12, 312);
            this.numericUpDownValue.Name = "numericUpDownValue";
            this.numericUpDownValue.Size = new System.Drawing.Size(269, 28);
            this.numericUpDownValue.TabIndex = 1;
            this.numericUpDownValue.ValueChanged += new System.EventHandler(this.numericUpDownValue_ValueChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(91, 354);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(87, 37);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "确定";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // UpperHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 401);
            this.ControlBox = false;
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.numericUpDownValue);
            this.Controls.Add(this.listBoxIdeologies);
            this.Name = "UpperHouse";
            this.Text = "UpperHouse";
            this.Load += new System.EventHandler(this.UpperHouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxIdeologies;
        private System.Windows.Forms.NumericUpDown numericUpDownValue;
        private System.Windows.Forms.Button buttonSave;

    }
}