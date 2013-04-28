namespace openLibrary_2._0
{
    partial class frmOverdueItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOverdueItems));
            this.dgvOverdueGames = new System.Windows.Forms.DataGridView();
            this.dgvOverdueBooks = new System.Windows.Forms.DataGridView();
            this.dgvOverdueMovies = new System.Windows.Forms.DataGridView();
            this.dgvOverdueMusic = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSendReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueMovies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueMusic)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOverdueGames
            // 
            this.dgvOverdueGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverdueGames.Location = new System.Drawing.Point(12, 378);
            this.dgvOverdueGames.Name = "dgvOverdueGames";
            this.dgvOverdueGames.Size = new System.Drawing.Size(447, 91);
            this.dgvOverdueGames.TabIndex = 4;
            // 
            // dgvOverdueBooks
            // 
            this.dgvOverdueBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverdueBooks.Location = new System.Drawing.Point(12, 24);
            this.dgvOverdueBooks.Name = "dgvOverdueBooks";
            this.dgvOverdueBooks.Size = new System.Drawing.Size(447, 91);
            this.dgvOverdueBooks.TabIndex = 0;
            // 
            // dgvOverdueMovies
            // 
            this.dgvOverdueMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverdueMovies.Location = new System.Drawing.Point(12, 142);
            this.dgvOverdueMovies.Name = "dgvOverdueMovies";
            this.dgvOverdueMovies.Size = new System.Drawing.Size(447, 91);
            this.dgvOverdueMovies.TabIndex = 1;
            // 
            // dgvOverdueMusic
            // 
            this.dgvOverdueMusic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverdueMusic.Location = new System.Drawing.Point(12, 260);
            this.dgvOverdueMusic.Name = "dgvOverdueMusic";
            this.dgvOverdueMusic.Size = new System.Drawing.Size(447, 91);
            this.dgvOverdueMusic.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Overdue Books";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Overdue Movies";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Overdue Music";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 362);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Overdue Games";
            // 
            // btnSendReport
            // 
            this.btnSendReport.Location = new System.Drawing.Point(105, 497);
            this.btnSendReport.Name = "btnSendReport";
            this.btnSendReport.Size = new System.Drawing.Size(125, 30);
            this.btnSendReport.TabIndex = 9;
            this.btnSendReport.Text = "Send Reports";
            this.btnSendReport.UseVisualStyleBackColor = true;
            this.btnSendReport.Click += new System.EventHandler(this.btnSendReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(236, 497);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 30);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmOverdueItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 552);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSendReport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOverdueGames);
            this.Controls.Add(this.dgvOverdueMusic);
            this.Controls.Add(this.dgvOverdueMovies);
            this.Controls.Add(this.dgvOverdueBooks);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmOverdueItems";
            this.Text = "Overdue Items Report";
            this.Load += new System.EventHandler(this.frmOverdueItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueMovies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueMusic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOverdueGames;
        private System.Windows.Forms.DataGridView dgvOverdueBooks;
        private System.Windows.Forms.DataGridView dgvOverdueMovies;
        private System.Windows.Forms.DataGridView dgvOverdueMusic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSendReport;
        private System.Windows.Forms.Button btnClose;

    }
}