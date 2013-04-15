namespace openLibrary_2._0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewMusic));
            this.dgvMusic = new System.Windows.Forms.DataGridView();
            this.mPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.lstCurrentTracks = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMusic
            // 
            this.dgvMusic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMusic.Location = new System.Drawing.Point(14, 240);
            this.dgvMusic.Name = "dgvMusic";
            this.dgvMusic.Size = new System.Drawing.Size(1011, 542);
            this.dgvMusic.TabIndex = 2;
            this.dgvMusic.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // mPlayer
            // 
            this.mPlayer.Enabled = true;
            this.mPlayer.Location = new System.Drawing.Point(353, 23);
            this.mPlayer.Name = "mPlayer";
            this.mPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mPlayer.OcxState")));
            this.mPlayer.Size = new System.Drawing.Size(217, 45);
            this.mPlayer.TabIndex = 6;
            // 
            // lstCurrentTracks
            // 
            this.lstCurrentTracks.FormattingEnabled = true;
            this.lstCurrentTracks.Location = new System.Drawing.Point(14, 23);
            this.lstCurrentTracks.Name = "lstCurrentTracks";
            this.lstCurrentTracks.Size = new System.Drawing.Size(323, 199);
            this.lstCurrentTracks.TabIndex = 7;
            this.lstCurrentTracks.SelectedIndexChanged += new System.EventHandler(this.lstCurrentTracks_SelectedIndexChanged);
            // 
            // frmViewMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 741);
            this.Controls.Add(this.lstCurrentTracks);
            this.Controls.Add(this.mPlayer);
            this.Controls.Add(this.dgvMusic);
            this.Name = "frmViewMusic";
            this.Text = "frmViewMusic";
            this.Load += new System.EventHandler(this.frmViewMusic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMusic;
        private AxWMPLib.AxWindowsMediaPlayer mPlayer;
        private System.Windows.Forms.ListBox lstCurrentTracks;
    }
}