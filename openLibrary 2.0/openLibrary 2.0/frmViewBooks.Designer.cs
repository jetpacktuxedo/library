﻿namespace openLibrary_2._0
{
    partial class frmViewBooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewBooks));
            this.dgvMusic = new System.Windows.Forms.DataGridView();
            this.tabSet1 = new System.Windows.Forms.TabControl();
            this.tabPageISBN = new System.Windows.Forms.TabPage();
            this.txtISBNsearch = new System.Windows.Forms.TextBox();
            this.tabPageTitle = new System.Windows.Forms.TabPage();
            this.txtTitleSearch = new System.Windows.Forms.TextBox();
            this.tabPageAuthor = new System.Windows.Forms.TabPage();
            this.txtAuthorSearch = new System.Windows.Forms.TextBox();
            this.tabPagePublisher = new System.Windows.Forms.TabPage();
            this.txtPublisherSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusic)).BeginInit();
            this.tabSet1.SuspendLayout();
            this.tabPageISBN.SuspendLayout();
            this.tabPageTitle.SuspendLayout();
            this.tabPageAuthor.SuspendLayout();
            this.tabPagePublisher.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMusic
            // 
            this.dgvMusic.AllowUserToAddRows = false;
            this.dgvMusic.AllowUserToDeleteRows = false;
            this.dgvMusic.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvMusic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMusic.GridColor = System.Drawing.SystemColors.Menu;
            this.dgvMusic.Location = new System.Drawing.Point(12, 131);
            this.dgvMusic.Name = "dgvMusic";
            this.dgvMusic.ReadOnly = true;
            this.dgvMusic.Size = new System.Drawing.Size(864, 250);
            this.dgvMusic.TabIndex = 1;
            this.dgvMusic.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tabSet1
            // 
            this.tabSet1.Controls.Add(this.tabPageISBN);
            this.tabSet1.Controls.Add(this.tabPageTitle);
            this.tabSet1.Controls.Add(this.tabPageAuthor);
            this.tabSet1.Controls.Add(this.tabPagePublisher);
            this.tabSet1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSet1.Location = new System.Drawing.Point(12, 12);
            this.tabSet1.Name = "tabSet1";
            this.tabSet1.SelectedIndex = 0;
            this.tabSet1.Size = new System.Drawing.Size(865, 113);
            this.tabSet1.TabIndex = 2;
            this.tabSet1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageISBN
            // 
            this.tabPageISBN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabPageISBN.Controls.Add(this.txtISBNsearch);
            this.tabPageISBN.Location = new System.Drawing.Point(4, 25);
            this.tabPageISBN.Name = "tabPageISBN";
            this.tabPageISBN.Size = new System.Drawing.Size(857, 84);
            this.tabPageISBN.TabIndex = 3;
            this.tabPageISBN.Text = "ISBN";
            this.tabPageISBN.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // txtISBNsearch
            // 
            this.txtISBNsearch.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtISBNsearch.Location = new System.Drawing.Point(18, 23);
            this.txtISBNsearch.Name = "txtISBNsearch";
            this.txtISBNsearch.Size = new System.Drawing.Size(821, 42);
            this.txtISBNsearch.TabIndex = 1;
            this.txtISBNsearch.Text = "Enter all or part of an ISBN here...";
            this.txtISBNsearch.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.txtISBNsearch.Enter += new System.EventHandler(this.textBox4_Enter);
            // 
            // tabPageTitle
            // 
            this.tabPageTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tabPageTitle.Controls.Add(this.txtTitleSearch);
            this.tabPageTitle.Location = new System.Drawing.Point(4, 25);
            this.tabPageTitle.Name = "tabPageTitle";
            this.tabPageTitle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTitle.Size = new System.Drawing.Size(860, 84);
            this.tabPageTitle.TabIndex = 0;
            this.tabPageTitle.Text = "Title";
            this.tabPageTitle.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // txtTitleSearch
            // 
            this.txtTitleSearch.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitleSearch.Location = new System.Drawing.Point(18, 23);
            this.txtTitleSearch.Name = "txtTitleSearch";
            this.txtTitleSearch.Size = new System.Drawing.Size(821, 42);
            this.txtTitleSearch.TabIndex = 0;
            this.txtTitleSearch.Text = "Enter all or part of a title here...";
            this.txtTitleSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtTitleSearch.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // tabPageAuthor
            // 
            this.tabPageAuthor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPageAuthor.Controls.Add(this.txtAuthorSearch);
            this.tabPageAuthor.Location = new System.Drawing.Point(4, 25);
            this.tabPageAuthor.Name = "tabPageAuthor";
            this.tabPageAuthor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAuthor.Size = new System.Drawing.Size(860, 84);
            this.tabPageAuthor.TabIndex = 1;
            this.tabPageAuthor.Text = "Author";
            this.tabPageAuthor.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // txtAuthorSearch
            // 
            this.txtAuthorSearch.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthorSearch.Location = new System.Drawing.Point(18, 23);
            this.txtAuthorSearch.Name = "txtAuthorSearch";
            this.txtAuthorSearch.Size = new System.Drawing.Size(821, 42);
            this.txtAuthorSearch.TabIndex = 1;
            this.txtAuthorSearch.Text = "Enter all or part of an author here...";
            this.txtAuthorSearch.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txtAuthorSearch.Enter += new System.EventHandler(this.textBox2_Enter);
            // 
            // tabPagePublisher
            // 
            this.tabPagePublisher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabPagePublisher.Controls.Add(this.txtPublisherSearch);
            this.tabPagePublisher.Location = new System.Drawing.Point(4, 25);
            this.tabPagePublisher.Name = "tabPagePublisher";
            this.tabPagePublisher.Size = new System.Drawing.Size(860, 84);
            this.tabPagePublisher.TabIndex = 2;
            this.tabPagePublisher.Text = "Publisher";
            this.tabPagePublisher.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // txtPublisherSearch
            // 
            this.txtPublisherSearch.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublisherSearch.Location = new System.Drawing.Point(18, 23);
            this.txtPublisherSearch.Name = "txtPublisherSearch";
            this.txtPublisherSearch.Size = new System.Drawing.Size(821, 42);
            this.txtPublisherSearch.TabIndex = 1;
            this.txtPublisherSearch.Text = "Enter all or part of a publisher here...";
            this.txtPublisherSearch.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.txtPublisherSearch.Enter += new System.EventHandler(this.textBox3_Enter);
            // 
            // frmViewBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 393);
            this.Controls.Add(this.tabSet1);
            this.Controls.Add(this.dgvMusic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewBooks";
            this.Text = "View Books";
            this.Load += new System.EventHandler(this.frmBookView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusic)).EndInit();
            this.tabSet1.ResumeLayout(false);
            this.tabPageISBN.ResumeLayout(false);
            this.tabPageISBN.PerformLayout();
            this.tabPageTitle.ResumeLayout(false);
            this.tabPageTitle.PerformLayout();
            this.tabPageAuthor.ResumeLayout(false);
            this.tabPageAuthor.PerformLayout();
            this.tabPagePublisher.ResumeLayout(false);
            this.tabPagePublisher.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMusic;
        private System.Windows.Forms.TabControl tabSet1;
        private System.Windows.Forms.TabPage tabPageISBN;
        private System.Windows.Forms.TextBox txtISBNsearch;
        private System.Windows.Forms.TabPage tabPageTitle;
        private System.Windows.Forms.TextBox txtTitleSearch;
        private System.Windows.Forms.TabPage tabPageAuthor;
        private System.Windows.Forms.TextBox txtAuthorSearch;
        private System.Windows.Forms.TabPage tabPagePublisher;
        private System.Windows.Forms.TextBox txtPublisherSearch;
    }
}