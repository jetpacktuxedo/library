namespace openLibrary_2._0
{
    partial class frmViewEmployees
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
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.tabSet1 = new System.Windows.Forms.TabControl();
            this.tabPageName = new System.Windows.Forms.TabPage();
            this.txtNameSearch = new System.Windows.Forms.TextBox();
            this.tabPageECode = new System.Windows.Forms.TabPage();
            this.txtECSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.tabSet1.SuspendLayout();
            this.tabPageName.SuspendLayout();
            this.tabPageECode.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(12, 131);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(865, 274);
            this.dgvEmployees.TabIndex = 2;
            this.dgvEmployees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tabSet1
            // 
            this.tabSet1.Controls.Add(this.tabPageName);
            this.tabSet1.Controls.Add(this.tabPageECode);
            this.tabSet1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSet1.Location = new System.Drawing.Point(12, 12);
            this.tabSet1.Name = "tabSet1";
            this.tabSet1.SelectedIndex = 0;
            this.tabSet1.Size = new System.Drawing.Size(866, 113);
            this.tabSet1.TabIndex = 10;
            this.tabSet1.SelectedIndexChanged += new System.EventHandler(this.tabSet1_SelectedIndexChanged);
            this.tabSet1.TabIndexChanged += new System.EventHandler(this.tabSet1_TabIndexChanged);
            // 
            // tabPageName
            // 
            this.tabPageName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabPageName.Controls.Add(this.txtNameSearch);
            this.tabPageName.Location = new System.Drawing.Point(4, 25);
            this.tabPageName.Name = "tabPageName";
            this.tabPageName.Size = new System.Drawing.Size(858, 84);
            this.tabPageName.TabIndex = 3;
            this.tabPageName.Text = "Name";
            // 
            // txtNameSearch
            // 
            this.txtNameSearch.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameSearch.Location = new System.Drawing.Point(18, 23);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(820, 42);
            this.txtNameSearch.TabIndex = 1;
            this.txtNameSearch.Text = "Enter all or part of a name here...";
            this.txtNameSearch.TextChanged += new System.EventHandler(this.txtUPCsearch_TextChanged);
            this.txtNameSearch.Enter += new System.EventHandler(this.txtNameSearch_Enter);
            // 
            // tabPageECode
            // 
            this.tabPageECode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tabPageECode.Controls.Add(this.txtECSearch);
            this.tabPageECode.Location = new System.Drawing.Point(4, 25);
            this.tabPageECode.Name = "tabPageECode";
            this.tabPageECode.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageECode.Size = new System.Drawing.Size(858, 84);
            this.tabPageECode.TabIndex = 0;
            this.tabPageECode.Text = "Employee Code";
            // 
            // txtECSearch
            // 
            this.txtECSearch.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtECSearch.Location = new System.Drawing.Point(18, 23);
            this.txtECSearch.Name = "txtECSearch";
            this.txtECSearch.Size = new System.Drawing.Size(821, 42);
            this.txtECSearch.TabIndex = 0;
            this.txtECSearch.Text = "Scan an employee card here...";
            this.txtECSearch.TextChanged += new System.EventHandler(this.txtTitleSearch_TextChanged);
            this.txtECSearch.Enter += new System.EventHandler(this.txtECSearch_Enter);
            // 
            // frmViewEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 418);
            this.Controls.Add(this.tabSet1);
            this.Controls.Add(this.dgvEmployees);
            this.Name = "frmViewEmployees";
            this.Text = "frmViewEmployees";
            this.Load += new System.EventHandler(this.frmViewEmployees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.tabSet1.ResumeLayout(false);
            this.tabPageName.ResumeLayout(false);
            this.tabPageName.PerformLayout();
            this.tabPageECode.ResumeLayout(false);
            this.tabPageECode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.TabControl tabSet1;
        private System.Windows.Forms.TabPage tabPageName;
        private System.Windows.Forms.TextBox txtNameSearch;
        private System.Windows.Forms.TabPage tabPageECode;
        private System.Windows.Forms.TextBox txtECSearch;
    }
}