namespace openLibrary_2._0
{
    partial class frmViewCustomers
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewCustomers));
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabSet1 = new System.Windows.Forms.TabControl();
            this.tabPageName = new System.Windows.Forms.TabPage();
            this.txtNameSearch = new System.Windows.Forms.TextBox();
            this.tabPageCCode = new System.Windows.Forms.TabPage();
            this.txtCCSearch = new System.Windows.Forms.TextBox();
            this.dgvClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tabSet1.SuspendLayout();
            this.tabPageName.SuspendLayout();
            this.tabPageCCode.SuspendLayout();
            this.dgvClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(12, 131);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(866, 274);
            this.dgvCustomers.TabIndex = 2;
            this.dgvCustomers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvCustomers.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCustomers_CellMouseDown);
            this.dgvCustomers.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 408);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(887, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // tabSet1
            // 
            this.tabSet1.Controls.Add(this.tabPageName);
            this.tabSet1.Controls.Add(this.tabPageCCode);
            this.tabSet1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSet1.Location = new System.Drawing.Point(12, 12);
            this.tabSet1.Name = "tabSet1";
            this.tabSet1.SelectedIndex = 0;
            this.tabSet1.Size = new System.Drawing.Size(866, 113);
            this.tabSet1.TabIndex = 11;
            this.tabSet1.SelectedIndexChanged += new System.EventHandler(this.tabSet1_SelectedIndexChanged);
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
            this.txtNameSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameSearch.Location = new System.Drawing.Point(18, 23);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(820, 40);
            this.txtNameSearch.TabIndex = 1;
            this.txtNameSearch.Text = "Enter all or part of a name here...";
            this.txtNameSearch.TextChanged += new System.EventHandler(this.txtNameSearch_TextChanged);
            this.txtNameSearch.Enter += new System.EventHandler(this.txtNameSearch_Enter);
            // 
            // tabPageCCode
            // 
            this.tabPageCCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tabPageCCode.Controls.Add(this.txtCCSearch);
            this.tabPageCCode.Location = new System.Drawing.Point(4, 25);
            this.tabPageCCode.Name = "tabPageCCode";
            this.tabPageCCode.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCCode.Size = new System.Drawing.Size(858, 84);
            this.tabPageCCode.TabIndex = 0;
            this.tabPageCCode.Text = "Customer Code";
            // 
            // txtCCSearch
            // 
            this.txtCCSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCCSearch.Location = new System.Drawing.Point(18, 23);
            this.txtCCSearch.Name = "txtCCSearch";
            this.txtCCSearch.Size = new System.Drawing.Size(821, 40);
            this.txtCCSearch.TabIndex = 0;
            this.txtCCSearch.Text = "Scan a customer card here...";
            this.txtCCSearch.TextChanged += new System.EventHandler(this.txtCCSearch_TextChanged);
            this.txtCCSearch.Enter += new System.EventHandler(this.txtCCSearch_Enter);
            // 
            // dgvClick
            // 
            this.dgvClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.dgvClick.Name = "contextMenuStrip1";
            this.dgvClick.Size = new System.Drawing.Size(153, 70);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // frmViewCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 430);
            this.Controls.Add(this.tabSet1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvCustomers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmViewCustomers";
            this.Text = "View Customers";
            this.Load += new System.EventHandler(this.frmViewCustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabSet1.ResumeLayout(false);
            this.tabPageName.ResumeLayout(false);
            this.tabPageName.PerformLayout();
            this.tabPageCCode.ResumeLayout(false);
            this.tabPageCCode.PerformLayout();
            this.dgvClick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabSet1;
        private System.Windows.Forms.TabPage tabPageName;
        private System.Windows.Forms.TextBox txtNameSearch;
        private System.Windows.Forms.TabPage tabPageCCode;
        private System.Windows.Forms.TextBox txtCCSearch;
        private System.Windows.Forms.ContextMenuStrip dgvClick;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}