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
using System.Net;


namespace openLibrary_2._0
{
    public partial class frmViewMusic : Form
    {

        public string connectionString;
        public OleDbConnection mDB;
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        string path = null, path2 = null;


        public frmViewMusic()
        {
            InitializeComponent();
        }

        private void frmViewMusic_Load(object sender, EventArgs e)
        {
            try
            {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select * from cd order by cd_id;";

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

        private void button1_Click(object sender, EventArgs e)
        {
            string asin = textBox1.Text;
            path = Directory.GetCurrentDirectory() + "/tempMP3.mp3";
            path2 = Directory.GetCurrentDirectory() + "/temp2MP3.mp3";
            string url = "http://www.amazon.com/gp/dmusic/get_sample_url.html?ASIN=" + asin;

            WebClient client = new WebClient();

            try
            {
                client.DownloadFile(url, path);
                player(path);
            }
            catch (Exception x)
            {
                client.DownloadFile(url, path2);
                player(path2);
            }    

        }

        public void player(string loc) 
        {

            mPlayer.URL = loc;
        
        }

        public void stopper(string loc)
        {
            wplayer.controls.stop();
            wplayer.close();
        }

     

        private void wplayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mPlayer.close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.CurrentRow.Index;

            string cdid = dataGridView1[0, selectedRow].Value.ToString();
            databaseHandler d = new databaseHandler();

            if (cdid != "0")
            {

                string sql = "select * from track where cd_id = '" + cdid + "' order by track_number;";

                try
                {
                    d.openDatabaseConnection();
                    mDB.Open();
                    OleDbCommand cmd;
                    OleDbDataReader rdr;
                    cmd = new OleDbCommand(sql, mDB);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        lstCurrentTracks.Items.Add(rdr[0]);
                    }

                }
                catch(Exception s)
                {
                    MessageBox.Show("Error." + s.Message + s.ToString());
                }
            }
        }
        
        

        //private void lookup()
        //{
        //    string track = dataGridView1.SelectedRows[1].ToString(), artist = txtTitle.Text, album = txtAuthor.Text;

        //    itemID = txtISBN.Text;

          
        //    else if (itemID == "False") ;  //intentionally empty.
        //    else
        //    {
        //        //Format url for the get request
        //        requestUrl = Lookup.lookup(track, album, artist);

        //        string result = Lookup.Fetch(requestUrl);

        //        //Submit Get request, extract info from pulled form
        //        string asin = result;

        //        //Push title and author data back into the form
        //        txtPublisher.Text = asin;
        //    }
        //}
    }
}
