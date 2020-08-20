namespace GUIConvertor
{
    partial class Form1
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
            this.BUTTON_XTSF_FILE = new System.Windows.Forms.Button();
            this.BUTTOON_CALP_FILE = new System.Windows.Forms.Button();
            this.button_ADD_CAPL = new System.Windows.Forms.Button();
            this.button_GEN_XTSF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BUTTON_XTSF_FILE
            // 
            this.BUTTON_XTSF_FILE.Location = new System.Drawing.Point(70, 43);
            this.BUTTON_XTSF_FILE.Name = "BUTTON_XTSF_FILE";
            this.BUTTON_XTSF_FILE.Size = new System.Drawing.Size(179, 62);
            this.BUTTON_XTSF_FILE.TabIndex = 0;
            this.BUTTON_XTSF_FILE.Text = "Add XTSF FILE";
            this.BUTTON_XTSF_FILE.UseVisualStyleBackColor = true;
            this.BUTTON_XTSF_FILE.Click += new System.EventHandler(this.BUTTON_XTSF_FILE_Click);
            // 
            // BUTTOON_CALP_FILE
            // 
            this.BUTTOON_CALP_FILE.Location = new System.Drawing.Point(70, 144);
            this.BUTTOON_CALP_FILE.Name = "BUTTOON_CALP_FILE";
            this.BUTTOON_CALP_FILE.Size = new System.Drawing.Size(179, 62);
            this.BUTTOON_CALP_FILE.TabIndex = 1;
            this.BUTTOON_CALP_FILE.Text = "GENERATE CALP FILE";
            this.BUTTOON_CALP_FILE.UseVisualStyleBackColor = true;
            this.BUTTOON_CALP_FILE.Click += new System.EventHandler(this.BUTTOON_CALP_FILE_Click);
            // 
            // button_ADD_CAPL
            // 
            this.button_ADD_CAPL.Location = new System.Drawing.Point(486, 43);
            this.button_ADD_CAPL.Name = "button_ADD_CAPL";
            this.button_ADD_CAPL.Size = new System.Drawing.Size(185, 62);
            this.button_ADD_CAPL.TabIndex = 2;
            this.button_ADD_CAPL.Text = "Add Capl script";
            this.button_ADD_CAPL.UseVisualStyleBackColor = true;
            this.button_ADD_CAPL.Click += new System.EventHandler(this.button_ADD_CAPL_Click);
            // 
            // button_GEN_XTSF
            // 
            this.button_GEN_XTSF.Location = new System.Drawing.Point(486, 144);
            this.button_GEN_XTSF.Name = "button_GEN_XTSF";
            this.button_GEN_XTSF.Size = new System.Drawing.Size(185, 62);
            this.button_GEN_XTSF.TabIndex = 3;
            this.button_GEN_XTSF.Text = "Generate Xtsf File";
            this.button_GEN_XTSF.UseVisualStyleBackColor = true;
            this.button_GEN_XTSF.Click += new System.EventHandler(this.button_GEN_XTSF_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 478);
            this.Controls.Add(this.button_GEN_XTSF);
            this.Controls.Add(this.button_ADD_CAPL);
            this.Controls.Add(this.BUTTOON_CALP_FILE);
            this.Controls.Add(this.BUTTON_XTSF_FILE);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BUTTON_XTSF_FILE;
        private System.Windows.Forms.Button BUTTOON_CALP_FILE;
        private System.Windows.Forms.Button button_ADD_CAPL;
        private System.Windows.Forms.Button button_GEN_XTSF;
    }
}

