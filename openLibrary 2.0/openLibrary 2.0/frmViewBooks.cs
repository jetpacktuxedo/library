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
    public partial class frmViewBooks : Form
    {
        public string connectionString;
        public OleDbConnection mDB;

        public frmViewBooks()
        {
            InitializeComponent();
        }

        private void frmBookView_Load(object sender, EventArgs e)
        {
            try
            {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select ISBN,Title,Author,Publisher,Binding,pub_date as Publication_Date, Price,Pages from book order by book_id;";

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
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void tabPage4_Click(object sender, EventArgs e)
        {
            clears();
        }

        private void clears()
        {
            textBox4.Text = "Enter all or part of an ISBN here...";
            textBox3.Text = "Enter all or part of a publisher here...";
            textBox2.Text = "Enter all or part of an author here...";
            textBox1.Text = "Enter all or part of a title here...";

            try
            {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select ISBN,Title,Author,Publisher,Binding,pub_date as Publication_Date, Price,Pages from book order by book_id;";

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

        private void searcher(string field, string column)
        {
            try
            {
                
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select ISBN,Title,Author,Publisher,Binding,pub_date as Publication_Date, Price,Pages from book where " + column + " like '%" + field + "%' order by book_id;";

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

        private void tabPage1_Click(object sender, EventArgs e)
        {
            clears();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            clears();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            clears();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 0)
            {
                searcher(textBox1.Text, "title");
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length >= 0)
            {
                searcher(textBox2.Text, "author");
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length >= 0)
            {
                searcher(textBox3.Text, "publisher");
            }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length >= 0)
            {
                searcher(textBox4.Text, "isbn");
            }
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clears();
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
    }
}
