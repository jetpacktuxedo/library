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
        public string connectionString;
        string[] listLine = new string[2];
        string userID;
        ArrayList toBeCheckedOut = new ArrayList();
        ArrayList toBeCheckedIn = new ArrayList();
        ArrayList toBePrinted = new ArrayList();
        ArrayList CheckedOut = new ArrayList();

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
            userID = txtID.Text;
            goStuff(userID);
        }

        public void goStuff(string userID)
        {
            lstCurrentlyCheckedOut.Visible = false;
            txtCheckout.Visible = false;
            btnSubmitCheckOut.Visible = false;

            lblCurrentUser.Visible = true;
            lblCustomerName.Visible = true;
            grpUser.Visible = true;
            lstCurrentlyCheckedOut.Visible = true;
            btnEnd.Enabled = true;

            
            string sql = "SELECT first_name & \" \" & last_name FROM customer WHERE customer_id = '" + userID + "'";
            lblCustomerName.Text = d.loadCustomerName(sql);

            loadCheckouts(userID);

            btnCheckout.Enabled = true;
            btnCheckIn.Enabled = true;
        }

        private void loadCheckouts(string userID)
        {   
            lstCurrentlyCheckedOut.Items.Clear();

            CheckedOut.Clear();
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
                string employeeName = d.getEmpName(x);
                ToolStripMenuItem temp = new ToolStripMenuItem();
                temp.Name = "toolstripmenuitem." + x;
                temp.Text = employeeName;
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

        private void frmLogoutClosed(object sender, EventArgs e){
            refresher();
        }
            

        private void clockInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //User clocks in. Multiple users can be clocked in at once.

            frmClockIn frm = new frmClockIn();
            frm.FormClosed += frmLoginClosed;
            frm.Show(); 
        }

        private void clockOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Clocking out.

            frmClockOut frm = new frmClockOut();
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
            lstCurrentlyCheckedOut.Visible = false;
            adminMenu.Enabled = false;
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
            adminMenu.Enabled = true;
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
        string item_ID = d.codeFromTitle(listLine[2]);

        string sqlCheckout = "update " + table + "_checkout set due_date = '" + System.DateTime.Now.AddDays(14).ToShortDateString() + "' where  " + table + "_id = '" + item_ID + "';";

        d.renewDue(sqlCheckout);

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
            btnSubmitCheckOut.Visible = true;
            lstCheckout.Visible = true;
            txtCheckout.Visible = true;
            btnCompleteCheckOut.Visible = true;
            btnFindItem.Enabled = true;
            btnCheckIn.Enabled = false;
            txtCheckout.Focus();
        }

        private void btnSubmitCheckOut_Click(object sender, EventArgs e)
        {
            string scannedItem = txtCheckout.Text;
            lstCheckout.Items.Add(scannedItem);
            toBeCheckedOut.Add(scannedItem);
            txtCheckout.Text = "";
            btnCompleteCheckOut.Enabled = true;
        }

        private void btnCompleteCheckOut_Click(object sender, EventArgs e)
        {
            lstCheckout.Items.Clear();
            lstCurrentlyCheckedOut.Visible = true;
            btnCheckout.Enabled = true;
            btnSubmitCheckOut.Visible = false;
            lstCheckout.Visible = false;
            txtCheckout.Visible = false;
            btnCompleteCheckOut.Visible = false;
            btnFindItem.Enabled = false;
            btnCompleteCheckOut.Enabled = false;

            foreach (string scannedItem in toBeCheckedOut) 
            {
                d.checkoutBook(userID, lblCurrentEmp.Text, scannedItem);
            }

            loadCheckouts(userID);
            toBeCheckedOut.Clear();

            goStuff(userID);
        }

        private void overdueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOverdueItems frm = new frmOverdueItems();
            frm.Show();
        }

        private void txtCheckout_TextChanged(object sender, EventArgs e)
        {
            if (txtCheckout.Text.Length > 0)
                btnSubmitCheckOut.Enabled = true;
            else
                btnSubmitCheckOut.Enabled = false;

        }

        private void btnCheckIn_Click(object sender, EventArgs e) 
        {
            lstCurrentlyCheckedOut.Visible = false;
            btnCheckout.Enabled = false;
            btnCheckIn.Enabled = false;
            btnSubmitCheckIn.Visible = true;
            btnCompleteCheckIn.Visible = true;
            lstCheckIn.Visible = true;
            txtCheckIn.Visible = true;
            btnFindItem.Enabled = true;
            txtCheckIn.Focus();
        }

        private void btnCompleteCheckIn_Click(object sender, EventArgs e)
        {
            lstCheckIn.Items.Clear();
            lstCurrentlyCheckedOut.Visible = true;
            btnCheckout.Enabled = true;
            btnCheckIn.Enabled = true;
            btnSubmitCheckIn.Visible = false;
            btnCompleteCheckIn.Visible = false;
            lstCheckIn.Visible = false;
            txtCheckIn.Visible = false;
            btnFindItem.Enabled = false;
            btnCompleteCheckIn.Enabled = false;

            foreach (string item in toBeCheckedIn)
                d.checkinBook(item);

            loadCheckouts(userID);
            toBeCheckedIn.Clear();
            goStuff(userID);
            
        }

        private void btnSubmitCheckIn_Click(object sender, EventArgs e)
        {
            string checkInItem = txtCheckIn.Text;
            lstCheckIn.Items.Add(checkInItem);
            toBeCheckedIn.Add(checkInItem);
            txtCheckIn.Text = "";
            btnCompleteCheckIn.Enabled = true;
        }

        private void aPIKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAmazonKeys frm = new frmAmazonKeys();
            frm.Show();
        }

        private void btnFindUser_Click(object sender, EventArgs e)
        {
            frmViewCustomers frm = new frmViewCustomers();
            frm.Show();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {

            toBePrinted.Clear();
            toBePrinted.Add("============================================================================");
            toBePrinted.Add("                                                                         YOUR LOCAL LIBRARY    ");
            toBePrinted.Add("                                                                          121 FIRST STREET     ");
            toBePrinted.Add("                                                                         WEST LAFAYETTE, IN    ");
            toBePrinted.Add("                                                                          (765) 555 - 5555     ");
            toBePrinted.Add("============================================================================");
            toBePrinted.Add("");
            toBePrinted.Add("");
            toBePrinted.Add("");
            toBePrinted.Add("TIME OF SALE:   " + System.DateTime.Now.ToString());
            toBePrinted.Add("");
            toBePrinted.Add("");
            toBePrinted.Add("CURRENT EMPLOYEE:   " + lblCurrentEmp.Text);
            toBePrinted.Add("");
            toBePrinted.Add("CURRENT CUSTOMER:   " + lblCustomerName.Text);
            toBePrinted.Add("");
            toBePrinted.Add("");
            toBePrinted.Add("This is an updated list of the items that you currently have checked out:");
            toBePrinted.Add("");
      
            foreach (string print in CheckedOut)
            {
                toBePrinted.Add(print);
            }

            frmPrint frm = new frmPrint();
            frm.getArrayList = toBePrinted;
            frm.Show();

            txtID.Text = "";
            lstCurrentlyCheckedOut.Items.Clear();
            lblCustomerName.Text = "";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.Show();
        }

        private void btnFindItem_Click(object sender, EventArgs e)
        {
            frmFindMedia frm = new frmFindMedia();
            frm.FormClosed += new FormClosedEventHandler(frmFindMedia_FormClosed);
            frm.Show();
        }

        private void frmFindMedia_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        
        }

        private void frmHomeScreen_Load(object sender, EventArgs e)
        {

        }

        private void txtCheckIn_TextChanged(object sender, EventArgs e)
        {
            if (txtCheckIn.Text.Length > 0)
                btnSubmitCheckIn.Enabled = true;
            else
                btnSubmitCheckIn.Enabled = false;
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text.Length > 0)
                btnGO.Enabled = true;
            else
                btnGO.Enabled = false;
        }



    }
}
