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
    public partial class frmViewMovies : Form
    {

        public string connectionString;
        public OleDbConnection mDB;

        public frmViewMovies()
        {
            InitializeComponent();
        }

        private void frmViewMovies_Load(object sender, EventArgs e)
        {
            try
            {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select * from movie order by cint(movie_id);";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dataGridView1.DataSource = bs;

                da.Update(dt);

                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void clears() {
            txtUPCsearch.Text = "Enter all or part of a UPC here...";
            txtPublisherSearch.Text = "Enter all or part of a publisher here...";
            txtDirectorSearch.Text = "Enter all or part of a director's name here...";
            txtTitleSearch.Text = "Enter all or part of a title here...";

            try {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select * from Movie order by cint(Movie_id);";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dataGridView1.DataSource = bs;

                da.Update(dt);

                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();
            }
            catch (Exception ee) {
                MessageBox.Show(ee.Message);
            }
        }

        private void txtUPCsearch_Enter(object sender, EventArgs e) {
            txtUPCsearch.Text = "";
        }

        private void txtTitleSearch_Enter(object sender, EventArgs e) {
            txtTitleSearch.Text = "";
        }

        private void txtDirectorSearch_Enter(object sender, EventArgs e) {
            txtDirectorSearch.Text = "";
        }

        private void txtPublisherSearch_Enter(object sender, EventArgs e) {
            txtPublisherSearch.Text = "";
        }

        private void tabSet1_SelectedIndexChanged(object sender, EventArgs e) {
            clears();
        }

        private string escapeHandling(string line) {
            return line.Replace("'", "''");
        }

        private void searcher(string field, string column) {
            try {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select * from Movie where " + column + " like '%" + escapeHandling(field) + "%' order by cint(movie_id);";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dataGridView1.DataSource = bs;

                da.Update(dt);

                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();
            }
            catch (Exception ee) {
                MessageBox.Show(ee.Message);
            }
        }

        private void txtUPCsearch_TextChanged(object sender, EventArgs e) {
            if (txtUPCsearch.Text.Length >= 0) {
                searcher(txtUPCsearch.Text, "UPC");
            }
        }

        private void txtTitleSearch_TextChanged(object sender, EventArgs e) {
            if (txtTitleSearch.Text.Length >= 0) {
                searcher(txtTitleSearch.Text, "title");
            }
        }

        private void txtDirectorSearch_TextChanged(object sender, EventArgs e) {
            if (txtDirectorSearch.Text.Length >= 0) {
                searcher(txtDirectorSearch.Text, "director");
            }
        }

        private void txtPublisherSearch_TextChanged(object sender, EventArgs e) {
            if (txtPublisherSearch.Text.Length >= 0) {
                searcher(txtPublisherSearch.Text, "studio");
            }
        }

    }
}
