namespace openLibrary_2._0
{
    partial class frmViewMovies
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
            this.dgvMovies = new System.Windows.Forms.DataGridView();
            this.tabSet1 = new System.Windows.Forms.TabControl();
            this.tabPageUPC = new System.Windows.Forms.TabPage();
            this.txtUPCsearch = new System.Windows.Forms.TextBox();
            this.tabPageTitle = new System.Windows.Forms.TabPage();
            this.txtTitleSearch = new System.Windows.Forms.TextBox();
            this.tabPageDirector = new System.Windows.Forms.TabPage();
            this.txtDirectorSearch = new System.Windows.Forms.TextBox();
            this.tabPagePublisher = new System.Windows.Forms.TabPage();
            this.txtPublisherSearch = new System.Windows.Forms.TextBox();
            this.dgvClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovies)).BeginInit();
            this.tabSet1.SuspendLayout();
            this.tabPageUPC.SuspendLayout();
            this.tabPageTitle.SuspendLayout();
            this.tabPageDirector.SuspendLayout();
            this.tabPagePublisher.SuspendLayout();
            this.dgvClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMovies
            // 
            this.dgvMovies.AllowUserToAddRows = false;
            this.dgvMovies.AllowUserToDeleteRows = false;
            this.dgvMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovies.Location = new System.Drawing.Point(12, 131);
            this.dgvMovies.Name = "dgvMovies";
            this.dgvMovies.ReadOnly = true;
            this.dgvMovies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovies.Size = new System.Drawing.Size(866, 250);
            this.dgvMovies.TabIndex = 2;
            this.dgvMovies.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMovies_CellMouseDown);
            // 
            // tabSet1
            // 
            this.tabSet1.Controls.Add(this.tabPageUPC);
            this.tabSet1.Controls.Add(this.tabPageTitle);
            this.tabSet1.Controls.Add(this.tabPageDirector);
            this.tabSet1.Controls.Add(this.tabPagePublisher);
            this.tabSet1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSet1.Location = new System.Drawing.Point(12, 12);
            this.tabSet1.Name = "tabSet1";
            this.tabSet1.SelectedIndex = 0;
            this.tabSet1.Size = new System.Drawing.Size(866, 113);
            this.tabSet1.TabIndex = 9;
            this.tabSet1.SelectedIndexChanged += new System.EventHandler(this.tabSet1_SelectedIndexChanged);
            // 
            // tabPageUPC
            // 
            this.tabPageUPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabPageUPC.Controls.Add(this.txtUPCsearch);
            this.tabPageUPC.Location = new System.Drawing.Point(4, 25);
            this.tabPageUPC.Name = "tabPageUPC";
            this.tabPageUPC.Size = new System.Drawing.Size(858, 84);
            this.tabPageUPC.TabIndex = 3;
            this.tabPageUPC.Text = "UPC";
            // 
            // txtUPCsearch
            // 
            this.txtUPCsearch.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUPCsearch.Location = new System.Drawing.Point(18, 23);
            this.txtUPCsearch.Name = "txtUPCsearch";
            this.txtUPCsearch.Size = new System.Drawing.Size(820, 42);
            this.txtUPCsearch.TabIndex = 1;
            this.txtUPCsearch.Text = "Enter all or part of a UPC here...";
            this.txtUPCsearch.TextChanged += new System.EventHandler(this.txtUPCsearch_TextChanged);
            this.txtUPCsearch.Enter += new System.EventHandler(this.txtUPCsearch_Enter);
            // 
            // tabPageTitle
            // 
            this.tabPageTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tabPageTitle.Controls.Add(this.txtTitleSearch);
            this.tabPageTitle.Location = new System.Drawing.Point(4, 25);
            this.tabPageTitle.Name = "tabPageTitle";
            this.tabPageTitle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTitle.Size = new System.Drawing.Size(858, 84);
            this.tabPageTitle.TabIndex = 0;
            this.tabPageTitle.Text = "Title";
            // 
            // txtTitleSearch
            // 
            this.txtTitleSearch.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitleSearch.Location = new System.Drawing.Point(18, 23);
            this.txtTitleSearch.Name = "txtTitleSearch";
            this.txtTitleSearch.Size = new System.Drawing.Size(821, 42);
            this.txtTitleSearch.TabIndex = 0;
            this.txtTitleSearch.Text = "Enter all or part of a movie title here...";
            this.txtTitleSearch.TextChanged += new System.EventHandler(this.txtTitleSearch_TextChanged);
            this.txtTitleSearch.Enter += new System.EventHandler(this.txtTitleSearch_Enter);
            // 
            // tabPageDirector
            // 
            this.tabPageDirector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPageDirector.Controls.Add(this.txtDirectorSearch);
            this.tabPageDirector.Location = new System.Drawing.Point(4, 25);
            this.tabPageDirector.Name = "tabPageDirector";
            this.tabPageDirector.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDirector.Size = new System.Drawing.Size(858, 84);
            this.tabPageDirector.TabIndex = 1;
            this.tabPageDirector.Text = "Director";
            // 
            // txtDirectorSearch
            // 
            this.txtDirectorSearch.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirectorSearch.Location = new System.Drawing.Point(18, 23);
            this.txtDirectorSearch.Name = "txtDirectorSearch";
            this.txtDirectorSearch.Size = new System.Drawing.Size(820, 42);
            this.txtDirectorSearch.TabIndex = 1;
            this.txtDirectorSearch.Text = "Enter all or part of a director\'s name here...";
            this.txtDirectorSearch.TextChanged += new System.EventHandler(this.txtDirectorSearch_TextChanged);
            this.txtDirectorSearch.Enter += new System.EventHandler(this.txtDirectorSearch_Enter);
            // 
            // tabPagePublisher
            // 
            this.tabPagePublisher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabPagePublisher.Controls.Add(this.txtPublisherSearch);
            this.tabPagePublisher.Location = new System.Drawing.Point(4, 25);
            this.tabPagePublisher.Name = "tabPagePublisher";
            this.tabPagePublisher.Size = new System.Drawing.Size(858, 84);
            this.tabPagePublisher.TabIndex = 2;
            this.tabPagePublisher.Text = "Publisher";
            // 
            // txtPublisherSearch
            // 
            this.txtPublisherSearch.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublisherSearch.Location = new System.Drawing.Point(18, 23);
            this.txtPublisherSearch.Name = "txtPublisherSearch";
            this.txtPublisherSearch.Size = new System.Drawing.Size(820, 42);
            this.txtPublisherSearch.TabIndex = 1;
            this.txtPublisherSearch.Text = "Enter all or part of a publisher here...";
            this.txtPublisherSearch.TextChanged += new System.EventHandler(this.txtPublisherSearch_TextChanged);
            this.txtPublisherSearch.Enter += new System.EventHandler(this.txtPublisherSearch_Enter);
            // 
            // dgvClick
            // 
            this.dgvClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.dgvClick.Name = "dgvClick";
            this.dgvClick.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // frmViewMovies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 393);
            this.Controls.Add(this.tabSet1);
            this.Controls.Add(this.dgvMovies);
            this.Name = "frmViewMovies";
            this.Text = "frmMovieView";
            this.Load += new System.EventHandler(this.frmViewMovies_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovies)).EndInit();
            this.tabSet1.ResumeLayout(false);
            this.tabPageUPC.ResumeLayout(false);
            this.tabPageUPC.PerformLayout();
            this.tabPageTitle.ResumeLayout(false);
            this.tabPageTitle.PerformLayout();
            this.tabPageDirector.ResumeLayout(false);
            this.tabPageDirector.PerformLayout();
            this.tabPagePublisher.ResumeLayout(false);
            this.tabPagePublisher.PerformLayout();
            this.dgvClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMovies;
        private System.Windows.Forms.TabControl tabSet1;
        private System.Windows.Forms.TabPage tabPageUPC;
        private System.Windows.Forms.TextBox txtUPCsearch;
        private System.Windows.Forms.TabPage tabPageTitle;
        private System.Windows.Forms.TextBox txtTitleSearch;
        private System.Windows.Forms.TabPage tabPageDirector;
        private System.Windows.Forms.TextBox txtDirectorSearch;
        private System.Windows.Forms.TabPage tabPagePublisher;
        private System.Windows.Forms.TextBox txtPublisherSearch;
        private System.Windows.Forms.ContextMenuStrip dgvClick;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}