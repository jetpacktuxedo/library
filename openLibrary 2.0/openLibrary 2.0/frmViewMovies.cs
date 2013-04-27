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
                string query = "select UPC, Title, Release_Date, Director, Type, Studio, Running_Time, Available from movie order by Title, Release_Date;";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvMovies.DataSource = bs;

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
                string query = "select UPC, Title, Release_Date, Director, Type, Studio, Running_Time from movie order by Title, Release_Date;";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvMovies.DataSource = bs;

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
                string query = "select UPC, Title, Release_Date, Director, Type, Studio, Running_Time from movie where " + column + " like '%" + escapeHandling(field) + "%' order by Title, Release_Date;";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvMovies.DataSource = bs;

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

        private void dgvMovies_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex >= 0) {
                dgvMovies.ClearSelection();
                dgvMovies.CurrentCell = dgvMovies.Rows[e.RowIndex].Cells[1];
                dgvMovies.Rows[e.RowIndex].Selected = true;

                if (e.Button == MouseButtons.Right) {
                    dgvClick.Show(Cursor.Position);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            string row = dgvMovies[0, dgvMovies.CurrentRow.Index].Value.ToString();
            frmEditMovies form = new frmEditMovies(row);
            form.FormClosed += new FormClosedEventHandler(frmEditMovies_FormClosed);
            form.Show();
        }

        private void frmEditMovies_FormClosed(object sender, FormClosedEventArgs e) {
            searcher("", "UPC");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            string row = dgvMovies[0, dgvMovies.CurrentRow.Index].Value.ToString();

            if (MessageBox.Show("Are you sure?", "Confirm Deletion", MessageBoxButtons.YesNo) == DialogResult.No) {
                MessageBox.Show("Request ignored");
                dgvMovies.ClearSelection();
                return;
            }

            try {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "delete from Movie where movie_ID = '" + row + "';";
                string query2 = "delete from Actor where movie_ID = '" + row + "';";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbDataAdapter da2 = new OleDbDataAdapter(query2, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                OleDbCommandBuilder cb2 = new OleDbCommandBuilder(da2);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvMovies.DataSource = bs;

                da.Update(dt);

            }
            catch (Exception ex) {
                MessageBox.Show("Unexpected error: " + ex);
            }
            finally {
                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();
            }

            try {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select UPC, Title, Release_Date, Director, Type, Studio, Running_Time from movie order by Title, Release_Date;";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvMovies.DataSource = bs;

                da.Update(dt);
            }
            catch (Exception ex) {
                MessageBox.Show("Unexpected error: " + ex);
            }
            finally {
                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();
            }

            dgvMovies.ClearSelection();
        }
    }
}