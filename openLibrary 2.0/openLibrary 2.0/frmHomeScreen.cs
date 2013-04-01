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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

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

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddBook form = new frmAddBook();
            form.Show();
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.openNew();
        }

     
    }
}
