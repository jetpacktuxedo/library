namespace openLibrary_2._0
{
    partial class frmCurrentlyClocked
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
            this.lstClockedIN = new System.Windows.Forms.ListBox();
            this.btnClockThemOut = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstClockedIN
            // 
            this.lstClockedIN.FormattingEnabled = true;
            this.lstClockedIN.Location = new System.Drawing.Point(12, 12);
            this.lstClockedIN.Name = "lstClockedIN";
            this.lstClockedIN.Size = new System.Drawing.Size(213, 147);
            this.lstClockedIN.TabIndex = 0;
            this.lstClockedIN.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnClockThemOut
            // 
            this.btnClockThemOut.Enabled = false;
            this.btnClockThemOut.Location = new System.Drawing.Point(40, 177);
            this.btnClockThemOut.Name = "btnClockThemOut";
            this.btnClockThemOut.Size = new System.Drawing.Size(152, 23);
            this.btnClockThemOut.TabIndex = 1;
            this.btnClockThemOut.Text = "Clock out this employee";
            this.btnClockThemOut.UseVisualStyleBackColor = true;
            this.btnClockThemOut.Click += new System.EventHandler(this.btnClockThemOut_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(79, 216);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmCurrentlyClocked
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 253);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClockThemOut);
            this.Controls.Add(this.lstClockedIN);
            this.Name = "frmCurrentlyClocked";
            this.Text = "frmCurrentlyClocked";
            this.Load += new System.EventHandler(this.frmCurrentlyClocked_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstClockedIN;
        private System.Windows.Forms.Button btnClockThemOut;
        private System.Windows.Forms.Button btnClose;
    }
}