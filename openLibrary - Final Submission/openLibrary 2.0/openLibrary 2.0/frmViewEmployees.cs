﻿/*
 * This code copyright 2013 by openLibrary
 * Developed by Tai Gunter and Ethan Madden.
*/

using System;
using System.Collections;
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
    public partial class frmViewEmployees : Form
    {
        public string connectionString;
        public OleDbConnection mDB; 
        databaseHandler d = new databaseHandler();

        public frmViewEmployees()
        {
            InitializeComponent();
        }

        private void frmViewEmployees_Load(object sender, EventArgs e)
        {
            refreshList();
            dgvEmployees.ClearSelection();
        }

        private void txtUPCsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtNameSearch.Text.Length >= 0)
            {
                try
                {
                    connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                    string query = "select * from employee where first_name like '%" + txtNameSearch.Text + "%' or last_name like '%" + txtNameSearch.Text + "%' order by last_name;";

                    OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                    OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    BindingSource bs = new BindingSource();
                    bs.DataSource = dt;

                    dgvEmployees.DataSource = bs;

                    da.Update(dt);

                    d.closeDatabaseConnection();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            
            }
        }

        private void txtTitleSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtECSearch.Text.Length >= 0)
            {
                try
                {
                    connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                    string query = "select * from employee where employee_id like '%" + txtECSearch.Text + "%' order by last_name;";

                    OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                    OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    BindingSource bs = new BindingSource();
                    bs.DataSource = dt;

                    dgvEmployees.DataSource = bs;

                    da.Update(dt);

                    d.closeDatabaseConnection();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }

            }
        }

        private void clears()
        {
            txtNameSearch.Text = "Enter all or part of a name here...";
            txtECSearch.Text = "Scan an employee card here...";

            refreshList();
        }

        private void txtECSearch_Enter(object sender, EventArgs e)
        {
            txtECSearch.Text = "";
        }

        private void txtNameSearch_Enter(object sender, EventArgs e)
        {
            txtNameSearch.Text = "";
        }

        private string escapeHandling(string line)
        {
            return line.Replace("'", "''");
        }

        private void searcher(string field, string column)
        {
            try
            {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select * from employee where " + column + " like '%" + escapeHandling(field) + "%' order by last_name;";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvEmployees.DataSource = bs;

                da.Update(dt);

                d.closeDatabaseConnection();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void tabSet1_TabIndexChanged(object sender, EventArgs e)
        {
            clears();
        }

        private void tabSet1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clears();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            string row = dgvEmployees[0, dgvEmployees.CurrentRow.Index].Value.ToString();
            frmEditEmployee form = new frmEditEmployee(row);
            form.FormClosed += new FormClosedEventHandler(frmEditEmployees_FormClosed);
            form.Show();
        }

        private void frmEditEmployees_FormClosed(object sender, FormClosedEventArgs e) {
            refreshList();
            dgvEmployees.ClearSelection();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            
            string row = dgvEmployees[0, dgvEmployees.CurrentRow.Index].Value.ToString();

            if (MessageBox.Show("Are you sure?", "Confirm Deletion", MessageBoxButtons.YesNo) == DialogResult.No) {
                MessageBox.Show("Request ignored");
                dgvEmployees.ClearSelection();
                return;
            }

            try {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "delete from employee where employee_ID = '" + row + "';";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvEmployees.DataSource = bs;

                da.Update(dt);

            }
            catch (Exception ex) {
                MessageBox.Show("Unexpected error: " + ex);
            }
            finally {
                d.closeDatabaseConnection();
            }

            refreshList();
            dgvEmployees.ClearSelection();
        }

        private void dgvEmployees_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex >= 0) {
                ArrayList clockedIn = new ArrayList();
                dgvEmployees.ClearSelection();
                dgvEmployees.CurrentCell = dgvEmployees.Rows[e.RowIndex].Cells[1];
                dgvEmployees.Rows[e.RowIndex].Selected = true;

                string row = dgvEmployees[0, dgvEmployees.CurrentRow.Index].Value.ToString();
                clockedIn = d.whoIsClockedIn();
                if (clockedIn.Contains(row)) {
                    editToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;
                }
                else {
                    editToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;
                }

                if (e.Button == MouseButtons.Right) {
                    dgvClick.Show(Cursor.Position);
                }
            }
        }

        private void refreshList() {
            try {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select * from employee order by last_name;";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvEmployees.DataSource = bs;

                da.Update(dt);
            }
            catch (Exception ex) {
                MessageBox.Show("There was a problem loading the employee list.\n" + ex);
            }
            finally {
                d.closeDatabaseConnection();
            }
        }
    }
}
