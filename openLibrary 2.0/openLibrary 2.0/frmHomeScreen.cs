﻿using System;
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
using System.Configuration;

namespace openLibrary_2._0
{
    public partial class frmHomeScreen : Form
    {
        public static string mUserFile = "";
        databaseHandler d = new databaseHandler();
        public string loggedin;
        ToolStripMenuItem MI = new ToolStripMenuItem();
        public string connectionString;
        string[] listLine = new string[2];
        string userID;
        ArrayList toBeCheckedOut = new ArrayList();


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
            lstCurrentlyCheckedOut.Visible = false;
            txtCheckout.Visible = false;
            btnSubmit.Visible = false;

            lblCurrentUser.Visible = true;
            lblCustomerName.Visible = true;
            grpUser.Visible = true;
            lstCurrentlyCheckedOut.Visible = true;

            userID = txtID.Text;
            string sql = "SELECT first_name & \" \" & last_name FROM customer WHERE customer_id = '" + userID + "'";
            lblCustomerName.Text = d.loadCustomerName(sql);

            loadCheckouts(userID);

            btnCheckout.Enabled = true;
            
        }

        private void loadCheckouts(string userID)
        {   
            lstCurrentlyCheckedOut.Items.Clear();

            ArrayList CheckedOut = new ArrayList();
            CheckedOut = d.loadCustomerCheckouts(userID);

            if (CheckedOut.Count == 0)
                lstCurrentlyCheckedOut.Items.Add("The customer does not currently have any items checked out.");

            foreach (string x in CheckedOut)
            {
                lstCurrentlyCheckedOut.Items.Add(x);
            }    
        
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
            lblCurrentEmp.Visible = false;
            logOutToolStripMenuItem.Enabled = false;
            logInToolStripMenuItem.Enabled = true;
            pixLogo.Visible = true;
            addToolStripMenuItem.Enabled = false;
            viewToolStripMenuItem.Enabled = false;
            editItemToolStripMenuItem.Enabled = false;
            lstCurrentlyCheckedOut.Visible = false;
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
            lstCurrentlyCheckedOut.Visible = true;
            lblCurrentEmp.Visible = true;
            logOutToolStripMenuItem.Enabled = true;
            logInToolStripMenuItem.Enabled = false;
            pixLogo.Visible = false;
            lblCurrentEmp.Text = clickedItem.ToString();
            addToolStripMenuItem.Enabled = true;
            viewToolStripMenuItem.Enabled = true;
            editItemToolStripMenuItem.Enabled = true;


        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void btnRenewItem_Click(object sender, EventArgs e)
        {
        string table = "";
        string column = "";

        if (listLine[0] == "Book:")
        {
            table = "book";
            column = "title";
        }
        else if (listLine[0] == "Music:")
        {
            table = "cd";
            column = "album";
        }
        else if (listLine[0] == "Game:")
        {
            table = "game";
            column = "title";
        }
        else
        {
            table = "movie";
            column = "title";
        }


        DateTime due = DateTime.Parse(listLine[1]);



        string sql2 = "update " + table + " set due_date = '" + System.DateTime.Now.AddDays(14).ToShortDateString() + "' where  " + column + " = '" + listLine[2] + "' and due_date = #" + due.ToShortDateString() + "# and customer_id = '" + userID + "';";

        d.renewDue(sql2);

        loadCheckouts(userID);
        
        }

        private void lstCurrentlyCheckedOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mediaType = "", title = "", dueDate = "";
        

            if (lstCurrentlyCheckedOut.SelectedIndex > 1)
            {
                if (lstCurrentlyCheckedOut.SelectedItem.ToString() != "")
                {
                    btnRenewItem.Enabled = true;
                    listLine = d.Deserialize(lstCurrentlyCheckedOut.SelectedItem.ToString());

                    try
                    {
                        mediaType = listLine[0];
                        dueDate = listLine[1];
                        title = listLine[2];

                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }
                }
                else
                    btnRenewItem.Enabled = false;
            }
            else
                btnRenewItem.Enabled = false;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            lstCurrentlyCheckedOut.Visible = false;
            btnCheckout.Enabled = false;
            btnSubmit.Visible = true;
            lstCheckout.Visible = true;
            txtCheckout.Visible = true;
            btnComplete.Visible = true;
            btnComplete.Focus();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {

            string scannedItem = txtCheckout.Text;
            lstCheckout.Items.Add(scannedItem);
            toBeCheckedOut.Add(scannedItem);
            txtCheckout.Text = "";
        }

        private void btnComplete_Click_1(object sender, EventArgs e)
        {
            lstCheckout.Items.Clear();
            lstCurrentlyCheckedOut.Visible = true;
            btnCheckout.Enabled = true;
            btnSubmit.Visible = false;
            lstCheckout.Visible = false;
            txtCheckout.Visible = false;
            btnComplete.Visible = false;

            
            MessageBox.Show(toBeCheckedOut[0].ToString());

            foreach(string scannedItem in toBeCheckedOut)
                d.checkoutBook(userID, scannedItem);

            loadCheckouts(userID);
            toBeCheckedOut.Clear();

        }
        
      
    }
}
