/*
 * This code copyright 2013 by openLibrary
 * Developed by Tai Gunter and Ethan Madden.
*/

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
    public partial class frmViewCustomers : Form
    {
        public string connectionString;
        public OleDbConnection mDB;
        private frmHomeScreen frm = new frmHomeScreen();
        databaseHandler d = new databaseHandler();

        public frmViewCustomers()
        {
            InitializeComponent();
        }

        private void frmViewCustomers_Load(object sender, EventArgs e)
        {
            refresh();
            dgvCustomers.ClearSelection();
        }

        public void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCCSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtCCSearch.Text.Length >= 0)
            {
                try
                {
                    connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                    string query = "select * from customer where customer_id like '%" + txtCCSearch.Text + "%' order by last_name;";

                    OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                    OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    BindingSource bs = new BindingSource();
                    bs.DataSource = dt;

                    dgvCustomers.DataSource = bs;

                    da.Update(dt);

                    databaseHandler d = new databaseHandler();
                    d.closeDatabaseConnection();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }

            }
        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtNameSearch.Text.Length >= 0)
            {
                try
                {
                    connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                    string query = "select * from customer where first_name like '%" + txtNameSearch.Text + "%' or last_name like '%" + txtNameSearch.Text + "%' order by last_name;";

                    OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                    OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    BindingSource bs = new BindingSource();
                    bs.DataSource = dt;

                    dgvCustomers.DataSource = bs;

                    da.Update(dt);

                    databaseHandler d = new databaseHandler();
                    d.closeDatabaseConnection();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }

            }
        }

        private void tabSet1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clears();
        }

        private void txtNameSearch_Enter(object sender, EventArgs e)
        {
            txtNameSearch.Text = "";
        }

        private void txtCCSearch_Enter(object sender, EventArgs e)
        {
            txtCCSearch.Text = "";
        }

        private string escapeHandling(string line)
        {
            return line.Replace("'", "''");
        }

        private void clears()
        {
            txtNameSearch.Text = "Enter all or part of a name here...";
            txtCCSearch.Text = "Scan a customer card here...";

            try
            {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select * from customer order by last_name;";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvCustomers.DataSource = bs;

                da.Update(dt);

                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void searcher(string field, string column) {
            try {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select * from Customer where " + column + " like '%" + escapeHandling(field) + "%' order by last_name;";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvCustomers.DataSource = bs;

                da.Update(dt);

                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();
            }
            catch (Exception ee) {
                MessageBox.Show(ee.Message);
            }
        }

        private void dgvCustomers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex >= 0) {
                dgvCustomers.ClearSelection();
                dgvCustomers.CurrentCell = dgvCustomers.Rows[e.RowIndex].Cells[1];
                dgvCustomers.Rows[e.RowIndex].Selected = true;

                if (e.Button == MouseButtons.Right)
                {
                    dgvClick.Show(Cursor.Position);
                }
                else if (e.Button == MouseButtons.Left)
                {
                    if (dgvCustomers.CurrentRow.Index >= 0)
                    {
                        int selectedRow = dgvCustomers.CurrentRow.Index;
                        string customerID = dgvCustomers[0, selectedRow].Value.ToString();

                        Clipboard.SetText(customerID);

                        toolStripStatusLabel1.Text = "The customer ID for " + dgvCustomers[1, selectedRow].Value.ToString() + " " + dgvCustomers[2, selectedRow].Value.ToString() + " has been copied to the clipboard.";
                    }
                
                }
               
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            string row = dgvCustomers[0, dgvCustomers.CurrentRow.Index].Value.ToString();
            frmEditCustomers form = new frmEditCustomers(row);
            form.FormClosed += new FormClosedEventHandler(frmEditEmployees_FormClosed);
            form.Show();
        }

        private void frmEditEmployees_FormClosed(object sender, FormClosedEventArgs e) {
            refresh();
            dgvCustomers.ClearSelection();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            string row = dgvCustomers[0, dgvCustomers.CurrentRow.Index].Value.ToString();

            if (MessageBox.Show("Are you sure?", "Confirm Deletion", MessageBoxButtons.YesNo) == DialogResult.No) {
                MessageBox.Show("Request ignored");
                dgvCustomers.ClearSelection();
                return;
            }

            try {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "delete from Customer where customer_ID = '" + row + "';";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvCustomers.DataSource = bs;

                da.Update(dt);

            }
            catch (Exception ex) {
                MessageBox.Show("Unexpected error: " + ex);
            }
            finally {
                d.closeDatabaseConnection();
            }

            refresh();
            dgvCustomers.ClearSelection();
        }

        private void refresh() {
            try {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select * from customer order by last_name;";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvCustomers.DataSource = bs;

                da.Update(dt);

                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();
            }
            catch (Exception ee) {
                MessageBox.Show("There was a problem loading the customer list.\n" + ee.Message);
            }
        }
    }
}
