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
    public partial class frmFindMedia : Form
    {
        public frmFindMedia()
        {
            InitializeComponent();
        }

        

        private void frmWhatMedia_Load(object sender, EventArgs e)
        {
            
            try
            {
                string connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select Title, isbn as Checkout_Code from (select title, isbn from book union select title, upc from movie union select title,upc from game union select album,upc from cd) order by title;";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvMedia.DataSource = bs;

                da.Update(dt);

                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();

                DataGridViewColumn c = dgvMedia.Columns[0];
                c.Width = 155;
                dgvMedia.ClearSelection();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void dgvMedia_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMedia.CurrentRow.Index >= 0)
            {
                int selectedRow = dgvMedia.CurrentRow.Index;
                string itemID = dgvMedia[1, selectedRow].Value.ToString();

                Clipboard.SetText(itemID);

                string mediaName = dgvMedia[0, selectedRow].Value.ToString();

                if (mediaName.Length > 22)
                {
                    mediaName = mediaName.Substring(0, 22);
                    mediaName += "...";
                }

                label2.Text = "The ISBN/UPC for \"" + mediaName + "\" has been copied.";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = "";

            if(textBox1.Text.Length >= 0)
                searchText = textBox1.Text;

            try
            {
                string connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select Title, isbn as Checkout_Code from (select title, isbn from book union select title, upc from movie union select title,upc from game union select album,upc from cd) where title like '%" + searchText + "%' order by title;";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvMedia.DataSource = bs;

                da.Update(dt);

                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();

                DataGridViewColumn c = dgvMedia.Columns[0];
                c.Width = 155;
                dgvMedia.ClearSelection();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

       
    }
}


