﻿using System;
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
using System.Collections;
using System.Text.RegularExpressions;

namespace openLibrary_2._0
{
    public partial class frmViewMusic : Form
    {

        public string connectionString;
        public OleDbConnection mDB;
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        string path = null, path2 = null;
        string cdid, albumname, artistname;


        public frmViewMusic()
        {
            InitializeComponent();
        }

        private void frmViewMusic_Load(object sender, EventArgs e)
        {
            try
            {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select CD_ID, Album, Artist, Type, publisher, Release_Date, Price from cd order by cd_id;";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvMusic.DataSource = bs;

                da.Update(dt);

                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

       

        private void beginPlay(string asin)
        {
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

            if (dgvMusic.CurrentRow.Index >= 0)
            {
                int selectedRow = dgvMusic.CurrentRow.Index;
                cdid = dgvMusic[0, selectedRow].Value.ToString();
                albumname = dgvMusic[1, selectedRow].Value.ToString();
                artistname = dgvMusic[2, selectedRow].Value.ToString();
                databaseHandler d = new databaseHandler();
                lstCurrentTracks.Items.Clear();



                string sql = "select * from track where cd_id = '" + cdid + "' order by track_number;";
                ArrayList adder = d.populateTracks(sql);

                lstCurrentTracks.Items.Add("DISC \t NO. \t TITLE");
                lstCurrentTracks.Items.Add("");
                foreach (string x in adder)
                {
                    lstCurrentTracks.Items.Add(x);
                }

            }
        }

        private void lstCurrentTracks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = lstCurrentTracks.SelectedItem.ToString();
            value = RemoveDigits(value);

            lookup(value, albumname, artistname);
            

        }

        public static string RemoveDigits(string key)
        {
            return Regex.Replace(key, @"\d", "");
        }
        
        

        private void lookup(string track, string album, string artist)
        {
            
                //Format url for the get request
                string requestUrl = TrackLookup.lookup(track, album, artist);

                string result = TrackLookup.Fetch(requestUrl);

                //Submit Get request, extract info from pulled form
                string asin = result;

                beginPlay(asin);

        }

        private void dgvMusic_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtISBNsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtISBNsearch.Text.Length >= 0)
            {
                searcher(txtISBNsearch.Text, "upc");
            }
        }

        private void txtTitleSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtTitleSearch.Text.Length >= 0)
            {
                searcher(txtTitleSearch.Text, "album");
            }
        }

        private void txtAuthorSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtAuthorSearch.Text.Length >= 0)
            {
                searcher(txtAuthorSearch.Text, "artist");
            }
        }

        private void txtPublisherSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtPublisherSearch.Text.Length >= 0)
            {
                searcher(txtPublisherSearch.Text, "publisher");
            }
        }

        private void txtPublisherSearch_Enter(object sender, EventArgs e)
        {
            txtPublisherSearch.Text = "";

        }

        private void txtAuthorSearch_Enter(object sender, EventArgs e)
        {
            txtAuthorSearch.Text = "";
        }

        private void txtTitleSearch_Enter(object sender, EventArgs e)
        {
            txtTitleSearch.Text = "";
        }

        private void txtISBNsearch_Enter(object sender, EventArgs e)
        {
            txtISBNsearch.Text = "";
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

        private void searcher(string field, string column)
        {
            try
            {

                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select CD_ID, Album, Artist, Type, publisher, Release_Date, Price from cd where " + column + " like '%" + field + "%' order by cd_id;";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvMusic.DataSource = bs;

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
                string query = "select CD_ID, Album, Artist, Type, publisher, Release_Date, Price from cd order by cd_id;";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvMusic.DataSource = bs;

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
        
    }
}
