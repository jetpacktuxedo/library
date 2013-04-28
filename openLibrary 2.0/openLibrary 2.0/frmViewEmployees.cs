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
    public partial class frmViewEmployees : Form
    {
        public string connectionString;
        public OleDbConnection mDB;

        public frmViewEmployees()
        {
            InitializeComponent();
        }

        private void frmViewEmployees_Load(object sender, EventArgs e)
        {

            try
            {
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

                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

                    databaseHandler d = new databaseHandler();
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

                    databaseHandler d = new databaseHandler();
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

            try
            {
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

                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
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
                string query = "select UPC, Title, Release_Date, Director, Type, Studio, Running_Time from movie where " + column + " like '%" + escapeHandling(field) + "%' order by Title, Release_Date;";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvEmployees.DataSource = bs;

                da.Update(dt);

                databaseHandler d = new databaseHandler();
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
    }
}
