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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.openNew();
            pictureBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = true;
            label3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mUserFile = "C:\\Users\\taiiiiiiiiiiiiii\\Documents\\GitHub\\library\\Library.mdb";         
        }
 
        private void bookToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmViewBooks form = new frmViewBooks();
            form.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            frmViewMovies form = new frmViewMovies();
            form.Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            frmViewMusic form = new frmViewMusic();
            form.Show();
        }

        private void gameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmViewGames form = new frmViewGames();
            form.Show();
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

        }
    }
}
