using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Collections;

namespace openLibrary_2._0
{
    public partial class frmHomeScreen : Form
    {
        public static string mUserFile = "";
        databaseHandler d = new databaseHandler();
        public string loggedin;
        ToolStripMenuItem MI = new ToolStripMenuItem();


        public frmHomeScreen()
        {
            InitializeComponent();
        }

        public void openDatabaseConnection()
        {
            d.openDatabaseConnection();
        }

        private void closeDatabaseConnection()
        {
            d.closeDatabaseConnection();
        }

        private void loadDatabaseTable(string sql)
        {
            d.loadDatabaseTable(sql);
        }

        //CLOSE
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        //OPEN
        private void openToolStripMenuItem_Click(object sender, EventArgs e){
            d.openNew();
         
   
            timeClockToolStripMenuItem.Enabled = true;
            logInToolStripMenuItem.Enabled = true;
            refresher();
            
        }

        //ADD MENU ITEMS
        private void AddBookToolStripMenuItem_Click(object sender, EventArgs e) {
            frmAddBook form = new frmAddBook();
            form.Show();
        }

        private void AddMovieToolStripMenuItem_Click(object sender, EventArgs e) {
            frmAddMovie form = new frmAddMovie();
            form.Show();
        }

        private void AddMusicToolStripMenuItem_Click(object sender, EventArgs e) {
            frmAddMusic form = new frmAddMusic();
            form.Show();
        }

        private void AddGameToolStripMenuItem_Click(object sender, EventArgs e) {
            frmAddGame form = new frmAddGame();
            form.Show();
        }

        private void AddCustomerToolStripMenuItem_Click(object sender, EventArgs e) {
            frmAddCustomer form = new frmAddCustomer();
            form.Show();
        }

        private void AddEmployeeToolStripMenuItem_Click(object sender, EventArgs e) {
            frmAddEmployee form = new frmAddEmployee();
            form.Show();
        }

        //VIEW MENU ITEMS
        private void ViewBookToolStripMenuItem_Click(object sender, EventArgs e) {
            frmViewBooks form = new frmViewBooks();
            form.Show();
        }

        private void ViewMoviesToolStripMenuItem_Click(object sender, EventArgs e) {
            frmViewMovies form = new frmViewMovies();
            form.Show();
        }

        private void ViewMusicToolStripMenuItem_Click(object sender, EventArgs e) {
            frmViewMusic form = new frmViewMusic();
            form.Show();
        }

        private void ViewGamesToolStripMenuItem_Click(object sender, EventArgs e) {
            frmViewGames form = new frmViewGames();
            form.Show();
        }

        private void ViewCustomersToolStripMenuItem_Click(object sender, EventArgs e) {
            frmViewCustomers form = new frmViewCustomers();
            form.Show();
        }

        private void ViewEmployeesToolStripMenuItem_Click(object sender, EventArgs e) {
            frmViewEmployees form = new frmViewEmployees();
            form.Show();
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            string userID = txtID.Text;
            string sql = "SELECT first_name & \" \" & last_name FROM customer WHERE customer_id = '" + userID + "'";
            lblCustomerName.Text = d.loadCustomerName(sql);


        }


        private void frmLoginClosed(object sender, EventArgs e)
        {
            refresher();
       }

        private void refresher()
        {
            ArrayList clocked = d.whoIsClockedIn();
            logInToolStripMenuItem.DropDownItems.Clear();
            string userslogged = " (No users)";

            foreach(string x in clocked)
            {
                ToolStripMenuItem temp = new ToolStripMenuItem();
                temp.Name = "toolstripmenuitem." + x;
                temp.Text = x;
                logInToolStripMenuItem.DropDownItems.Insert(logInToolStripMenuItem.DropDownItems.Count, temp);
                temp.Click += new EventHandler(MenuItemClickHandler);
            
            }

            if (clocked.Count == 0)
            {
                logInToolStripMenuItem.Enabled = false;
                clockOutToolStripMenuItem1.Enabled = false;
                whosClockedInToolStripMenuItem.Enabled = false;
                whosClockedInToolStripMenuItem.Text = "Who's Clocked In? (None)";
                clockOutToolStripMenuItem1.Text += userslogged;
            }
            else
            {
                logInToolStripMenuItem.Enabled = true;
                clockOutToolStripMenuItem1.Enabled = true;
                whosClockedInToolStripMenuItem.Enabled = true;
                whosClockedInToolStripMenuItem.Text = "Who's Clocked in? (" + clocked.Count + ")";
                clockOutToolStripMenuItem1.Text = "Clock Out";
            }

        }

        private void logInToolStripMenuItem_ (object sender, ToolStripItemClickedEventArgs e)
        {
        }


        private void frmLogoutClosed(object sender, EventArgs e)
        {
            refresher();
        }
            

        private void clockInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //User clocks in. Multiple users can be clocked in at once.


            frmLogin frm = new frmLogin();
            frm.FormClosed += frmLoginClosed;
            frm.Show(); 
        }

        private void clockOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Clocking out.

            frmLogout frm = new frmLogout();
            frm.FormClosed += frmLogoutClosed;
            frm.Show();
        }



        private void clockOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Code where user logs out. 

            grpTasks.Visible = false;
            grpUser.Visible = false;
            lblCurrentUser.Visible = false;
            dgvCheckedOut.Visible = false;
            lblCurrentEmp.Visible = false;
            logOutToolStripMenuItem.Enabled = false;
            logInToolStripMenuItem.Enabled = true;
            pixLogo.Visible = true;
            addToolStripMenuItem.Enabled = false;
            viewToolStripMenuItem.Enabled = false;
            editItemToolStripMenuItem.Enabled = false;
        }

        private void whosClockedInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Who is clocked in?
            frmCurrentlyClocked frm = new frmCurrentlyClocked();
            frm.FormClosed += frmCurrentlyClockedClosed;
            frm.Show();
        }

        private void frmCurrentlyClockedClosed(object sender, EventArgs e)
        {
            refresher();
        }

        private void frmHomeScreen_Load(object sender, EventArgs e)
        {
        }


        private void MenuItemClickHandler(object sender, EventArgs e)
        {

            //Code when a user logs in.

            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            grpTasks.Visible = true;
            grpUser.Visible = true;
            lblCurrentUser.Visible = true;
            dgvCheckedOut.Visible = true;
            lblCurrentEmp.Visible = true;
            logOutToolStripMenuItem.Enabled = true;
            logInToolStripMenuItem.Enabled = false;
            pixLogo.Visible = false;
            lblCurrentEmp.Text = clickedItem.ToString();
            addToolStripMenuItem.Enabled = true;
            viewToolStripMenuItem.Enabled = true;
            editItemToolStripMenuItem.Enabled = true;


        }
        
      
    }
}
