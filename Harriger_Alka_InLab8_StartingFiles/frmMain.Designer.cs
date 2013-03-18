partial class frmMain
{
    #region Windows Form Designer Generated code

    private void InitializeComponent()
    {
            this.lstStudents = new System.Windows.Forms.ListBox();
            this.btnSearchName = new System.Windows.Forms.Button();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearchScore = new System.Windows.Forms.TextBox();
            this.btnSearchScore = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSortFirst = new System.Windows.Forms.Button();
            this.btnSortLast = new System.Windows.Forms.Button();
            this.btnGradeUp = new System.Windows.Forms.Button();
            this.btnGradeDown = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstStudents
            // 
            this.lstStudents.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstStudents.FormattingEnabled = true;
            this.lstStudents.ItemHeight = 15;
            this.lstStudents.Location = new System.Drawing.Point(2, 33);
            this.lstStudents.Name = "lstStudents";
            this.lstStudents.Size = new System.Drawing.Size(558, 199);
            this.lstStudents.TabIndex = 11;
            // 
            // btnSearchName
            // 
            this.btnSearchName.Location = new System.Drawing.Point(163, 21);
            this.btnSearchName.Name = "btnSearchName";
            this.btnSearchName.Size = new System.Drawing.Size(94, 23);
            this.btnSearchName.TabIndex = 2;
            this.btnSearchName.Text = "Search Name";
            this.btnSearchName.UseVisualStyleBackColor = true;
            this.btnSearchName.Click += new System.EventHandler(this.btnSearchName_Click);
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(81, 23);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(78, 20);
            this.txtSearchName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Search Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Search Score";
            // 
            // txtSearchScore
            // 
            this.txtSearchScore.Location = new System.Drawing.Point(84, 19);
            this.txtSearchScore.Name = "txtSearchScore";
            this.txtSearchScore.Size = new System.Drawing.Size(100, 20);
            this.txtSearchScore.TabIndex = 5;
            // 
            // btnSearchScore
            // 
            this.btnSearchScore.Location = new System.Drawing.Point(179, 59);
            this.btnSearchScore.Name = "btnSearchScore";
            this.btnSearchScore.Size = new System.Drawing.Size(94, 23);
            this.btnSearchScore.TabIndex = 6;
            this.btnSearchScore.Text = "Search Score";
            this.btnSearchScore.UseVisualStyleBackColor = true;
            this.btnSearchScore.Click += new System.EventHandler(this.btnSearchScore_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(568, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileSave,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.Size = new System.Drawing.Size(103, 22);
            this.mnuFileOpen.Text = "&Open";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.Size = new System.Drawing.Size(103, 22);
            this.mnuFileSave.Text = "&Save";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(103, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // btnSortFirst
            // 
            this.btnSortFirst.Location = new System.Drawing.Point(39, 99);
            this.btnSortFirst.Name = "btnSortFirst";
            this.btnSortFirst.Size = new System.Drawing.Size(75, 23);
            this.btnSortFirst.TabIndex = 3;
            this.btnSortFirst.Text = "Sort First";
            this.btnSortFirst.UseVisualStyleBackColor = true;
            this.btnSortFirst.Click += new System.EventHandler(this.btnSortFirst_Click);
            // 
            // btnSortLast
            // 
            this.btnSortLast.Location = new System.Drawing.Point(146, 98);
            this.btnSortLast.Name = "btnSortLast";
            this.btnSortLast.Size = new System.Drawing.Size(75, 23);
            this.btnSortLast.TabIndex = 4;
            this.btnSortLast.Text = "Sort Last";
            this.btnSortLast.UseVisualStyleBackColor = true;
            this.btnSortLast.Click += new System.EventHandler(this.btnSortLast_Click);
            // 
            // btnGradeUp
            // 
            this.btnGradeUp.Location = new System.Drawing.Point(39, 100);
            this.btnGradeUp.Name = "btnGradeUp";
            this.btnGradeUp.Size = new System.Drawing.Size(75, 23);
            this.btnGradeUp.TabIndex = 7;
            this.btnGradeUp.Text = "GradeUp";
            this.btnGradeUp.UseVisualStyleBackColor = true;
            this.btnGradeUp.Click += new System.EventHandler(this.btnGradeUp_Click);
            // 
            // btnGradeDown
            // 
            this.btnGradeDown.Location = new System.Drawing.Point(144, 98);
            this.btnGradeDown.Name = "btnGradeDown";
            this.btnGradeDown.Size = new System.Drawing.Size(75, 23);
            this.btnGradeDown.TabIndex = 8;
            this.btnGradeDown.Text = "GradeDown";
            this.btnGradeDown.UseVisualStyleBackColor = true;
            this.btnGradeDown.Click += new System.EventHandler(this.btnGradeDown_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSearchScore);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnGradeDown);
            this.groupBox1.Controls.Add(this.btnGradeUp);
            this.groupBox1.Controls.Add(this.btnSearchScore);
            this.groupBox1.Location = new System.Drawing.Point(2, 238);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 129);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtSearchName);
            this.groupBox2.Controls.Add(this.btnSearchName);
            this.groupBox2.Controls.Add(this.btnSortLast);
            this.groupBox2.Controls.Add(this.btnSortFirst);
            this.groupBox2.Location = new System.Drawing.Point(297, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 129);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(568, 374);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstStudents);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In Lab 08 by Ethan Madden";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    #endregion

    private System.Windows.Forms.ListBox lstStudents;
    private System.Windows.Forms.Button btnSearchName;
    private System.Windows.Forms.TextBox txtSearchName;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtSearchScore;
    private System.Windows.Forms.Button btnSearchScore;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem mnuFile;
    private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
    private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
    private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
    private System.Windows.Forms.Button btnSortFirst;
    private System.Windows.Forms.Button btnSortLast;
    private System.Windows.Forms.Button btnGradeUp;
    private System.Windows.Forms.Button btnGradeDown;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
}