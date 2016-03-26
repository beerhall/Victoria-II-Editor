namespace Victoria2.Main
{
    partial class PoliticalReforms
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
            this.listBoxPoliticalReforms = new System.Windows.Forms.ListBox();
            this.listBoxPoliticalReformsValues = new System.Windows.Forms.ListBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxPoliticalReforms
            // 
            this.listBoxPoliticalReforms.FormattingEnabled = true;
            this.listBoxPoliticalReforms.ItemHeight = 18;
            this.listBoxPoliticalReforms.Location = new System.Drawing.Point(9, 11);
            this.listBoxPoliticalReforms.Name = "listBoxPoliticalReforms";
            this.listBoxPoliticalReforms.Size = new System.Drawing.Size(258, 436);
            this.listBoxPoliticalReforms.TabIndex = 0;
            this.listBoxPoliticalReforms.SelectedIndexChanged += new System.EventHandler(this.listBoxPoliticalReforms_SelectedIndexChanged);
            // 
            // listBoxPoliticalReformsValues
            // 
            this.listBoxPoliticalReformsValues.FormattingEnabled = true;
            this.listBoxPoliticalReformsValues.ItemHeight = 18;
            this.listBoxPoliticalReformsValues.Location = new System.Drawing.Point(273, 11);
            this.listBoxPoliticalReformsValues.Name = "listBoxPoliticalReformsValues";
            this.listBoxPoliticalReformsValues.Size = new System.Drawing.Size(258, 436);
            this.listBoxPoliticalReformsValues.TabIndex = 1;
            this.listBoxPoliticalReformsValues.SelectedIndexChanged += new System.EventHandler(this.listBoxPoliticalReformsValues_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(224, 453);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(97, 31);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "确认";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // PoliticalReforms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 498);
            this.ControlBox = false;
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.listBoxPoliticalReformsValues);
            this.Controls.Add(this.listBoxPoliticalReforms);
            this.Name = "PoliticalReforms";
            this.Text = "PoliticalReforms";
            this.Load += new System.EventHandler(this.PoliticalReforms_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPoliticalReforms;
        private System.Windows.Forms.ListBox listBoxPoliticalReformsValues;
        private System.Windows.Forms.Button buttonSave;
    }
}