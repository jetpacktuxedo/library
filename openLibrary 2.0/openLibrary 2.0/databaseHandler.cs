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

    class databaseHandler
    {
        public string sqlstatement;
        public OleDbConnection mDB;


        public void openNew()
        {                  
            OpenFileDialog ofd;
            try
            {
                ofd = new OpenFileDialog();
                ofd.Title = "Select the database file to open";
                ofd.Filter = "Database Files(*.mdb)|*.mdb|All files(*.*)|*.*";
                ofd.InitialDirectory = Path.Combine(Application.StartupPath, "@/Databases");

                if (ofd.ShowDialog() == DialogResult.OK) frmHomeScreen.mUserFile = ofd.FileName;

            }
            catch (Exception ee) { MessageBox.Show("There was an error: " + ee.Message); }
        }

        public void loadDatabaseTable(string sql) {

            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                OleDbDataReader rdr;
                cmd = new OleDbCommand(sql, mDB);
                rdr = cmd.ExecuteReader();

                rdr.Close();
            }
            catch (Exception ee) { MessageBox.Show("Something Went Wrong: " + ee.Message + ee.ToString()); }
        }

        public void closeDatabaseConnection() {
            if (mDB != null) mDB.Close();
        }

        public void openDatabaseConnection() {
            string connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
            mDB = new OleDbConnection(connectionString);
        }

        public int findBookCount(string sql)
        {


            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                OleDbDataReader rdr;
                cmd = new OleDbCommand(sql, mDB);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    return (int)rdr[0];
                }

            }

            catch (Exception ee)
            {
                MessageBox.Show("Something went wrong: " + ee.Message + ee.ToString());
                return (int)-1;
            }

            return -1;
        }
    }
}
