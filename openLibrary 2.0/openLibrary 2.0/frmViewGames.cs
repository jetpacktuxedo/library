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
    public partial class frmViewGames : Form
    {
        public string connectionString;
        public OleDbConnection mDB;

        public frmViewGames()
        {
            InitializeComponent();
        }

        private void frmViewGames_Load(object sender, EventArgs e)
        {
            try
            {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select * from game order by cint(game_id);";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvGames.DataSource = bs;

                da.Update(dt);

                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private string escapeHandling(string line) {
            return line.Replace("'", "''");
        }

        private void searcher(string field, string column)
        {
            try
            {

                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select * from game where " + column + " like '%" + escapeHandling(field) + "%' order by cint(game_id);";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvGames.DataSource = bs;

                da.Update(dt);

                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void clears()
        {
            txtISBNsearch.Text = "Enter all or part of an ISBN here...";
            txtPublisherSearch.Text = "Enter all or part of a publisher here...";
            txtAuthorSearch.Text = "Enter all or part of an author here...";
            txtTitleSearch.Text = "Enter all or part of a title here...";

            try
            {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select * from game order by game_id;";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvGames.DataSource = bs;

                da.Update(dt);

                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void tabSet1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clears();
        }

        private void tabPageISBN_Click(object sender, EventArgs e)
        {
            clears();
        }

        private void tabPageTitle_Click(object sender, EventArgs e)
        {
            clears();
        }

        private void tabPageAuthor_Click(object sender, EventArgs e)
        {
            clears();
        }

        private void tabPagePublisher_Click(object sender, EventArgs e)
        {
            clears();
        }

        private void txtPublisherSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtPublisherSearch.Text.Length >= 0)
            {
                searcher(txtPublisherSearch.Text, "platform");
            }
        }

        private void txtAuthorSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtAuthorSearch.Text.Length >= 0)
            {
                searcher(txtAuthorSearch.Text, "studio");
            }
        }

        private void txtTitleSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtTitleSearch.Text.Length >= 0)
            {
                searcher(txtTitleSearch.Text, "title");
            }
        }

        private void txtISBNsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtISBNsearch.Text.Length >= 0)
            {
                searcher(txtISBNsearch.Text, "upc");
            }
        }

        private void txtISBNsearch_Enter(object sender, EventArgs e)
        {
            txtISBNsearch.Text = "";

        }

        private void txtTitleSearch_Enter(object sender, EventArgs e)
        {
            txtTitleSearch.Text = "";

        }

        private void txtAuthorSearch_Enter(object sender, EventArgs e)
        {
            txtAuthorSearch.Text = "";

        }

        private void txtPublisherSearch_Enter(object sender, EventArgs e)
        {
            txtPublisherSearch.Text = "";

        }

        private void dgvGames_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex >= 0) {
                dgvGames.ClearSelection();
                dgvGames.CurrentCell = dgvGames.Rows[e.RowIndex].Cells[1];
                dgvGames.Rows[e.RowIndex].Selected = true;

                if (e.Button == MouseButtons.Right) {
                    dgvClick.Show(Cursor.Position);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            string row = dgvGames[0, dgvGames.CurrentRow.Index].Value.ToString();

            if (MessageBox.Show("Are you sure?", "Confirm Deletion", MessageBoxButtons.YesNo) == DialogResult.No) {
                MessageBox.Show("Request ignored");
                dgvGames.ClearSelection();
                return;
            }

            try {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "delete from game where game_ID = '" + row + "';";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvGames.DataSource = bs;

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
                string query = "select * from game order by game_id;";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvGames.DataSource = bs;

                da.Update(dt);
            }
            catch (Exception ex) {
                MessageBox.Show("Unexpected error: " + ex);
            }
            finally {
                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();
            }
            dgvGames.ClearSelection();
        }     
    }
}
