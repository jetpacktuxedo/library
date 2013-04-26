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

        public frmViewCustomers()
        {
            InitializeComponent();
        }

        private void frmViewCustomers_Load(object sender, EventArgs e)
        {
            try
            {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select * from customer order by customer_id;";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index >= 0)
            {
                int selectedRow = dataGridView1.CurrentRow.Index;
                string customerID = dataGridView1[0, selectedRow].Value.ToString();

                Clipboard.SetText(customerID);

                toolStripStatusLabel1.Text = "The customer ID for " + dataGridView1[1, selectedRow].Value.ToString() + " " + dataGridView1[2, selectedRow].Value.ToString() + " has been copied to the clipboard.";
            }
        }


    }
}
