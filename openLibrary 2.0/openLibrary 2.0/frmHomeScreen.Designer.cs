namespace openLibrary_2._0
{
    partial class frmHomeScreen
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.editUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patronToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMovieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMusicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.AddCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMoviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMusicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.dgvCheckedOut = new System.Windows.Forms.DataGridView();
            this.grpUser = new System.Windows.Forms.GroupBox();
            this.grpTasks = new System.Windows.Forms.GroupBox();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnEditInfo = new System.Windows.Forms.Button();
            this.btnFindUser = new System.Windows.Forms.Button();
            this.btnFindItem = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnGO = new System.Windows.Forms.Button();
            this.logInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckedOut)).BeginInit();
            this.grpUser.SuspendLayout();
            this.grpTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.addToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(670, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.logInToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.editItemToolStripMenuItem,
            this.editUserToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // editItemToolStripMenuItem
            // 
            this.editItemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookToolStripMenuItem1,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10});
            this.editItemToolStripMenuItem.Name = "editItemToolStripMenuItem";
            this.editItemToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.editItemToolStripMenuItem.Text = "Edit Item";
            // 
            // bookToolStripMenuItem1
            // 
            this.bookToolStripMenuItem1.Name = "bookToolStripMenuItem1";
            this.bookToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.bookToolStripMenuItem1.Text = "Book...";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem9.Text = "Movie...";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem10.Text = "Music...";
            // 
            // editUserToolStripMenuItem
            // 
            this.editUserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patronToolStripMenuItem1,
            this.toolStripMenuItem11});
            this.editUserToolStripMenuItem.Name = "editUserToolStripMenuItem";
            this.editUserToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.editUserToolStripMenuItem.Text = "Edit User";
            // 
            // patronToolStripMenuItem1
            // 
            this.patronToolStripMenuItem1.Name = "patronToolStripMenuItem1";
            this.patronToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.patronToolStripMenuItem1.Text = "Patron...";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem11.Text = "Employee...";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBookToolStripMenuItem,
            this.AddMovieToolStripMenuItem,
            this.AddMusicToolStripMenuItem,
            this.AddGameToolStripMenuItem,
            this.toolStripMenuItem16,
            this.AddCustomerToolStripMenuItem,
            this.AddEmployeeToolStripMenuItem});
            this.addToolStripMenuItem.Enabled = false;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // AddBookToolStripMenuItem
            // 
            this.AddBookToolStripMenuItem.Name = "AddBookToolStripMenuItem";
            this.AddBookToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.AddBookToolStripMenuItem.Text = "Book...";
            this.AddBookToolStripMenuItem.Click += new System.EventHandler(this.AddBookToolStripMenuItem_Click);
            // 
            // AddMovieToolStripMenuItem
            // 
            this.AddMovieToolStripMenuItem.Name = "AddMovieToolStripMenuItem";
            this.AddMovieToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.AddMovieToolStripMenuItem.Text = "Movie...";
            this.AddMovieToolStripMenuItem.Click += new System.EventHandler(this.AddMovieToolStripMenuItem_Click);
            // 
            // AddMusicToolStripMenuItem
            // 
            this.AddMusicToolStripMenuItem.Name = "AddMusicToolStripMenuItem";
            this.AddMusicToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.AddMusicToolStripMenuItem.Text = "Music...";
            this.AddMusicToolStripMenuItem.Click += new System.EventHandler(this.AddMusicToolStripMenuItem_Click);
            // 
            // AddGameToolStripMenuItem
            // 
            this.AddGameToolStripMenuItem.Name = "AddGameToolStripMenuItem";
            this.AddGameToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.AddGameToolStripMenuItem.Text = "Game...";
            this.AddGameToolStripMenuItem.Click += new System.EventHandler(this.AddGameToolStripMenuItem_Click);
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Enabled = false;
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem16.Text = "-------";
            // 
            // AddCustomerToolStripMenuItem
            // 
            this.AddCustomerToolStripMenuItem.Name = "AddCustomerToolStripMenuItem";
            this.AddCustomerToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.AddCustomerToolStripMenuItem.Text = "Customer...";
            this.AddCustomerToolStripMenuItem.Click += new System.EventHandler(this.AddCustomerToolStripMenuItem_Click);
            // 
            // AddEmployeeToolStripMenuItem
            // 
            this.AddEmployeeToolStripMenuItem.Name = "AddEmployeeToolStripMenuItem";
            this.AddEmployeeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.AddEmployeeToolStripMenuItem.Text = "Employee...";
            this.AddEmployeeToolStripMenuItem.Click += new System.EventHandler(this.AddEmployeeToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewBookToolStripMenuItem,
            this.ViewMoviesToolStripMenuItem,
            this.ViewMusicToolStripMenuItem,
            this.ViewGamesToolStripMenuItem,
            this.toolStripMenuItem4,
            this.ViewCustomersToolStripMenuItem,
            this.ViewEmployeesToolStripMenuItem});
            this.viewToolStripMenuItem.Enabled = false;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // ViewBookToolStripMenuItem
            // 
            this.ViewBookToolStripMenuItem.Name = "ViewBookToolStripMenuItem";
            this.ViewBookToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.ViewBookToolStripMenuItem.Text = "Books...";
            this.ViewBookToolStripMenuItem.Click += new System.EventHandler(this.ViewBookToolStripMenuItem_Click);
            // 
            // ViewMoviesToolStripMenuItem
            // 
            this.ViewMoviesToolStripMenuItem.Name = "ViewMoviesToolStripMenuItem";
            this.ViewMoviesToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.ViewMoviesToolStripMenuItem.Text = "Movies...";
            this.ViewMoviesToolStripMenuItem.Click += new System.EventHandler(this.ViewMoviesToolStripMenuItem_Click);
            // 
            // ViewMusicToolStripMenuItem
            // 
            this.ViewMusicToolStripMenuItem.Name = "ViewMusicToolStripMenuItem";
            this.ViewMusicToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.ViewMusicToolStripMenuItem.Text = "Music...";
            this.ViewMusicToolStripMenuItem.Click += new System.EventHandler(this.ViewMusicToolStripMenuItem_Click);
            // 
            // ViewGamesToolStripMenuItem
            // 
            this.ViewGamesToolStripMenuItem.Name = "ViewGamesToolStripMenuItem";
            this.ViewGamesToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.ViewGamesToolStripMenuItem.Text = "Games...";
            this.ViewGamesToolStripMenuItem.Click += new System.EventHandler(this.ViewGamesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Enabled = false;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(140, 22);
            this.toolStripMenuItem4.Text = "------";
            // 
            // ViewCustomersToolStripMenuItem
            // 
            this.ViewCustomersToolStripMenuItem.Name = "ViewCustomersToolStripMenuItem";
            this.ViewCustomersToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.ViewCustomersToolStripMenuItem.Text = "Customers...";
            this.ViewCustomersToolStripMenuItem.Click += new System.EventHandler(this.ViewCustomersToolStripMenuItem_Click);
            // 
            // ViewEmployeesToolStripMenuItem
            // 
            this.ViewEmployeesToolStripMenuItem.Name = "ViewEmployeesToolStripMenuItem";
            this.ViewEmployeesToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.ViewEmployeesToolStripMenuItem.Text = "Employees...";
            this.ViewEmployeesToolStripMenuItem.Click += new System.EventHandler(this.ViewEmployeesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpFilesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpFilesToolStripMenuItem
            // 
            this.helpFilesToolStripMenuItem.Name = "helpFilesToolStripMenuItem";
            this.helpFilesToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.helpFilesToolStripMenuItem.Text = "Help Files";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(18, 32);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(297, 35);
            this.txtID.TabIndex = 1;
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Location = new System.Drawing.Point(19, 143);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(99, 13);
            this.lblCurrentUser.TabIndex = 3;
            this.lblCurrentUser.Text = "CURRENT USER: ";
            this.lblCurrentUser.Visible = false;
            // 
            // dgvCheckedOut
            // 
            this.dgvCheckedOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckedOut.Location = new System.Drawing.Point(22, 174);
            this.dgvCheckedOut.Name = "dgvCheckedOut";
            this.dgvCheckedOut.Size = new System.Drawing.Size(380, 224);
            this.dgvCheckedOut.TabIndex = 4;
            this.dgvCheckedOut.Visible = false;
            // 
            // grpUser
            // 
            this.grpUser.Controls.Add(this.btnGO);
            this.grpUser.Controls.Add(this.txtID);
            this.grpUser.Location = new System.Drawing.Point(22, 42);
            this.grpUser.Name = "grpUser";
            this.grpUser.Size = new System.Drawing.Size(380, 83);
            this.grpUser.TabIndex = 5;
            this.grpUser.TabStop = false;
            this.grpUser.Text = "User ID:";
            this.grpUser.Visible = false;
            // 
            // grpTasks
            // 
            this.grpTasks.Controls.Add(this.btnEnd);
            this.grpTasks.Controls.Add(this.btnFindItem);
            this.grpTasks.Controls.Add(this.btnFindUser);
            this.grpTasks.Controls.Add(this.btnEditInfo);
            this.grpTasks.Controls.Add(this.btnCheckIn);
            this.grpTasks.Controls.Add(this.btnCheckOut);
            this.grpTasks.Location = new System.Drawing.Point(436, 42);
            this.grpTasks.Name = "grpTasks";
            this.grpTasks.Size = new System.Drawing.Size(222, 356);
            this.grpTasks.TabIndex = 6;
            this.grpTasks.TabStop = false;
            this.grpTasks.Text = "Common Tasks";
            this.grpTasks.Visible = false;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.Location = new System.Drawing.Point(21, 36);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(178, 47);
            this.btnCheckOut.TabIndex = 7;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckIn.Location = new System.Drawing.Point(21, 89);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(178, 47);
            this.btnCheckIn.TabIndex = 8;
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            // 
            // btnEditInfo
            // 
            this.btnEditInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditInfo.Location = new System.Drawing.Point(21, 142);
            this.btnEditInfo.Name = "btnEditInfo";
            this.btnEditInfo.Size = new System.Drawing.Size(178, 47);
            this.btnEditInfo.TabIndex = 9;
            this.btnEditInfo.Text = "Edit User Information";
            this.btnEditInfo.UseVisualStyleBackColor = true;
            // 
            // btnFindUser
            // 
            this.btnFindUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindUser.Location = new System.Drawing.Point(21, 195);
            this.btnFindUser.Name = "btnFindUser";
            this.btnFindUser.Size = new System.Drawing.Size(178, 47);
            this.btnFindUser.TabIndex = 7;
            this.btnFindUser.Text = "Find User";
            this.btnFindUser.UseVisualStyleBackColor = true;
            // 
            // btnFindItem
            // 
            this.btnFindItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindItem.Location = new System.Drawing.Point(21, 248);
            this.btnFindItem.Name = "btnFindItem";
            this.btnFindItem.Size = new System.Drawing.Size(178, 47);
            this.btnFindItem.TabIndex = 10;
            this.btnFindItem.Text = "Find Item";
            this.btnFindItem.UseVisualStyleBackColor = true;
            // 
            // btnEnd
            // 
            this.btnEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnd.Location = new System.Drawing.Point(21, 301);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(178, 47);
            this.btnEnd.TabIndex = 11;
            this.btnEnd.Text = "End Transaction";
            this.btnEnd.UseVisualStyleBackColor = true;
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(321, 32);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(44, 35);
            this.btnGO.TabIndex = 2;
            this.btnGO.Text = "Go";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // logInToolStripMenuItem
            // 
            this.logInToolStripMenuItem.Name = "logInToolStripMenuItem";
            this.logInToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logInToolStripMenuItem.Text = "Log In";
            this.logInToolStripMenuItem.Click += new System.EventHandler(this.logInToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(623, 11);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Visible = false;
            // 
            // frmHomeScreen
            // 
            this.AcceptButton = this.btnGO;
            this.ClientSize = new System.Drawing.Size(670, 430);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpTasks);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.grpUser);
            this.Controls.Add(this.dgvCheckedOut);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "frmHomeScreen";
            this.Load += new System.EventHandler(this.frmHomeScreen_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckedOut)).EndInit();
            this.grpUser.ResumeLayout(false);
            this.grpUser.PerformLayout();
            this.grpTasks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem editUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patronToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewMoviesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewMusicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddMovieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddMusicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem AddCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem ViewCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewEmployeesToolStripMenuItem;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.DataGridView dgvCheckedOut;
        private System.Windows.Forms.GroupBox grpUser;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.GroupBox grpTasks;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnFindItem;
        private System.Windows.Forms.Button btnFindUser;
        private System.Windows.Forms.Button btnEditInfo;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

