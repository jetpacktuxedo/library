﻿namespace openLibrary_2._0
{
    partial class frmViewMusic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewMusic));
            this.dgvMusic = new System.Windows.Forms.DataGridView();
            this.mPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.lstCurrentTracks = new System.Windows.Forms.ListBox();
            this.tabSet1 = new System.Windows.Forms.TabControl();
            this.tabPageISBN = new System.Windows.Forms.TabPage();
            this.txtUPCsearch = new System.Windows.Forms.TextBox();
            this.tabPageTitle = new System.Windows.Forms.TabPage();
            this.txtAlbumSearch = new System.Windows.Forms.TextBox();
            this.tabPageAuthor = new System.Windows.Forms.TabPage();
            this.txtArtistSearch = new System.Windows.Forms.TextBox();
            this.tabPagePublisher = new System.Windows.Forms.TabPage();
            this.txtPublisherSearch = new System.Windows.Forms.TextBox();
            this.dgvClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mPlayer)).BeginInit();
            this.tabSet1.SuspendLayout();
            this.tabPageISBN.SuspendLayout();
            this.tabPageTitle.SuspendLayout();
            this.tabPageAuthor.SuspendLayout();
            this.tabPagePublisher.SuspendLayout();
            this.dgvClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMusic
            // 
            this.dgvMusic.AllowUserToAddRows = false;
            this.dgvMusic.AllowUserToDeleteRows = false;
            this.dgvMusic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMusic.Location = new System.Drawing.Point(12, 131);
            this.dgvMusic.Name = "dgvMusic";
            this.dgvMusic.ReadOnly = true;
            this.dgvMusic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMusic.Size = new System.Drawing.Size(768, 248);
            this.dgvMusic.TabIndex = 2;
            this.dgvMusic.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMusic_CellMouseDown);
            // 
            // mPlayer
            // 
            this.mPlayer.Enabled = true;
            this.mPlayer.Location = new System.Drawing.Point(794, 37);
            this.mPlayer.Name = "mPlayer";
            this.mPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mPlayer.OcxState")));
            this.mPlayer.Size = new System.Drawing.Size(223, 45);
            this.mPlayer.TabIndex = 6;
            // 
            // lstCurrentTracks
            // 
            this.lstCurrentTracks.FormattingEnabled = true;
            this.lstCurrentTracks.Location = new System.Drawing.Point(794, 88);
            this.lstCurrentTracks.Name = "lstCurrentTracks";
            this.lstCurrentTracks.Size = new System.Drawing.Size(223, 290);
            this.lstCurrentTracks.TabIndex = 7;
            this.lstCurrentTracks.SelectedIndexChanged += new System.EventHandler(this.lstCurrentTracks_SelectedIndexChanged);
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
            this.tabSet1.Size = new System.Drawing.Size(768, 113);
            this.tabSet1.TabIndex = 8;
            this.tabSet1.SelectedIndexChanged += new System.EventHandler(this.tabSet1_SelectedIndexChanged);
            // 
            // tabPageISBN
            // 
            this.tabPageISBN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabPageISBN.Controls.Add(this.txtUPCsearch);
            this.tabPageISBN.Location = new System.Drawing.Point(4, 25);
            this.tabPageISBN.Name = "tabPageISBN";
            this.tabPageISBN.Size = new System.Drawing.Size(760, 84);
            this.tabPageISBN.TabIndex = 3;
            this.tabPageISBN.Text = "UPC";
            this.tabPageISBN.Click += new System.EventHandler(this.tabPageISBN_Click);
            // 
            // txtUPCsearch
            // 
            this.txtUPCsearch.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUPCsearch.Location = new System.Drawing.Point(18, 23);
            this.txtUPCsearch.Name = "txtUPCsearch";
            this.txtUPCsearch.Size = new System.Drawing.Size(725, 42);
            this.txtUPCsearch.TabIndex = 1;
            this.txtUPCsearch.Text = "Enter all or part of a UPC here...";
            this.txtUPCsearch.TextChanged += new System.EventHandler(this.txtISBNsearch_TextChanged);
            this.txtUPCsearch.Enter += new System.EventHandler(this.txtISBNsearch_Enter);
            // 
            // tabPageTitle
            // 
            this.tabPageTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tabPageTitle.Controls.Add(this.txtAlbumSearch);
            this.tabPageTitle.Location = new System.Drawing.Point(4, 25);
            this.tabPageTitle.Name = "tabPageTitle";
            this.tabPageTitle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTitle.Size = new System.Drawing.Size(760, 84);
            this.tabPageTitle.TabIndex = 0;
            this.tabPageTitle.Text = "Album ";
            this.tabPageTitle.Click += new System.EventHandler(this.tabPageTitle_Click);
            // 
            // txtAlbumSearch
            // 
            this.txtAlbumSearch.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlbumSearch.Location = new System.Drawing.Point(18, 23);
            this.txtAlbumSearch.Name = "txtAlbumSearch";
            this.txtAlbumSearch.Size = new System.Drawing.Size(725, 42);
            this.txtAlbumSearch.TabIndex = 0;
            this.txtAlbumSearch.Text = "Enter all or part of an album title here...";
            this.txtAlbumSearch.TextChanged += new System.EventHandler(this.txtTitleSearch_TextChanged);
            this.txtAlbumSearch.Enter += new System.EventHandler(this.txtTitleSearch_Enter);
            // 
            // tabPageAuthor
            // 
            this.tabPageAuthor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPageAuthor.Controls.Add(this.txtArtistSearch);
            this.tabPageAuthor.Location = new System.Drawing.Point(4, 25);
            this.tabPageAuthor.Name = "tabPageAuthor";
            this.tabPageAuthor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAuthor.Size = new System.Drawing.Size(760, 84);
            this.tabPageAuthor.TabIndex = 1;
            this.tabPageAuthor.Text = "Artist";
            this.tabPageAuthor.Click += new System.EventHandler(this.tabPageAuthor_Click);
            // 
            // txtArtistSearch
            // 
            this.txtArtistSearch.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArtistSearch.Location = new System.Drawing.Point(18, 23);
            this.txtArtistSearch.Name = "txtArtistSearch";
            this.txtArtistSearch.Size = new System.Drawing.Size(725, 42);
            this.txtArtistSearch.TabIndex = 1;
            this.txtArtistSearch.Text = "Enter all or part of an artist here...";
            this.txtArtistSearch.TextChanged += new System.EventHandler(this.txtAuthorSearch_TextChanged);
            this.txtArtistSearch.Enter += new System.EventHandler(this.txtAuthorSearch_Enter);
            // 
            // tabPagePublisher
            // 
            this.tabPagePublisher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabPagePublisher.Controls.Add(this.txtPublisherSearch);
            this.tabPagePublisher.Location = new System.Drawing.Point(4, 25);
            this.tabPagePublisher.Name = "tabPagePublisher";
            this.tabPagePublisher.Size = new System.Drawing.Size(760, 84);
            this.tabPagePublisher.TabIndex = 2;
            this.tabPagePublisher.Text = "Publisher";
            this.tabPagePublisher.Click += new System.EventHandler(this.tabPagePublisher_Click);
            // 
            // txtPublisherSearch
            // 
            this.txtPublisherSearch.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublisherSearch.Location = new System.Drawing.Point(18, 23);
            this.txtPublisherSearch.Name = "txtPublisherSearch";
            this.txtPublisherSearch.Size = new System.Drawing.Size(725, 42);
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
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // frmViewMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 394);
            this.Controls.Add(this.tabSet1);
            this.Controls.Add(this.lstCurrentTracks);
            this.Controls.Add(this.mPlayer);
            this.Controls.Add(this.dgvMusic);
            this.Name = "frmViewMusic";
            this.Text = "frmViewMusic";
            this.Load += new System.EventHandler(this.frmViewMusic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mPlayer)).EndInit();
            this.tabSet1.ResumeLayout(false);
            this.tabPageISBN.ResumeLayout(false);
            this.tabPageISBN.PerformLayout();
            this.tabPageTitle.ResumeLayout(false);
            this.tabPageTitle.PerformLayout();
            this.tabPageAuthor.ResumeLayout(false);
            this.tabPageAuthor.PerformLayout();
            this.tabPagePublisher.ResumeLayout(false);
            this.tabPagePublisher.PerformLayout();
            this.dgvClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMusic;
        private AxWMPLib.AxWindowsMediaPlayer mPlayer;
        private System.Windows.Forms.ListBox lstCurrentTracks;
        private System.Windows.Forms.TabControl tabSet1;
        private System.Windows.Forms.TabPage tabPageISBN;
        private System.Windows.Forms.TextBox txtUPCsearch;
        private System.Windows.Forms.TabPage tabPageTitle;
        private System.Windows.Forms.TextBox txtAlbumSearch;
        private System.Windows.Forms.TabPage tabPageAuthor;
        private System.Windows.Forms.TextBox txtArtistSearch;
        private System.Windows.Forms.TabPage tabPagePublisher;
        private System.Windows.Forms.TextBox txtPublisherSearch;
        private System.Windows.Forms.ContextMenuStrip dgvClick;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}