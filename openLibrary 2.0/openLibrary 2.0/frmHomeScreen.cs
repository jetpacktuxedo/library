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

namespace openLibrary_2._0
{
    public partial class frmHomeScreen : Form
    {
        public static string mUserFile = "";
        databaseHandler d = new databaseHandler();
        public string loggedin;

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
         
            addToolStripMenuItem.Enabled = true;
            viewToolStripMenuItem.Enabled = true;
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


        }

        private void frmHomeScreen_Load(object sender, EventArgs e)
        {

        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();    
        }
        

        public void checklog() 
        {
            loggedin = frmLogin.ID;
            label1.Text = "Current Employee: " + loggedin;
            
            if (loggedin != null)
            {
                grpTasks.Visible = true;
                grpUser.Visible = true;
                lblCurrentUser.Visible = true;
                dgvCheckedOut.Visible = true;
                label1.Visible = true;
            }

        }
    }
}
