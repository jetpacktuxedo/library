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
using System.Collections;
using System.Text.RegularExpressions;

namespace openLibrary_2._0
{
    public partial class frmViewMusic : Form {

        public string connectionString;
        public OleDbConnection mDB;
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        string path = null, path2 = null, path3 = null;
        string cdid, albumname, artistname;

        public frmViewMusic() {
            InitializeComponent();
        }

        private void frmViewMusic_Load(object sender, EventArgs e) {
            refresh();
            dgvMusic.ClearSelection();
        }

        protected virtual bool IsFileLocked(FileInfo file) {
            FileStream stream = null;

            try {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException) {
                return true;
            }
            finally {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

        private void beginPlay(string asin) {
            mPlayer.close();

            path = Directory.GetCurrentDirectory() + "/tempMP3.mp3";
            path2 = Directory.GetCurrentDirectory() + "/temp2MP3.mp3";
            path3 = Directory.GetCurrentDirectory() + "/temp3MP3.mp3";
            string url = "http://www.amazon.com/gp/dmusic/get_sample_url.html?ASIN=" + asin;

            WebClient client = new WebClient();
            FileInfo file = new FileInfo(path);
            FileInfo file2 = new FileInfo(path2);
            FileInfo file3 = new FileInfo(path3);

            try {
                if (!IsFileLocked(file)) {
                    client.DownloadFile(url, path);
                    if (client.ResponseHeaders.AllKeys[0] == "x-amz-id-1") {
                        MessageBox.Show("Track unavailable");
                    }
                    else player(path);
                }
                else if (!IsFileLocked(file2)) {
                    client.DownloadFile(url, path2);
                    if (client.ResponseHeaders.AllKeys[0] == "x-amz-id-1") {
                        MessageBox.Show("Track unavailable");
                    }
                    else player(path2);
                }
                else if (!IsFileLocked(file3)) {
                    client.DownloadFile(url, path2);
                    if (client.ResponseHeaders.AllKeys[0] == "x-amz-id-1") {
                        MessageBox.Show("Track unavailable");
                    }
                    else player(path3);
                }
            }
            catch (Exception x) {
                MessageBox.Show("Busy. Please try again in a moment.");
            }
        }

        public void player(string loc) {
            mPlayer.URL = loc;
        }

        public void stopper(string loc) {
            wplayer.controls.stop();
            wplayer.close();
        }

        private void button2_Click(object sender, EventArgs e) {
            mPlayer.close();
        }

        public static string RemoveDigits(string key) {
            return Regex.Replace(key, @"\d", "");
        }

        private void lookup(string track, string album, string artist) {

            //Format url for the get request
            string requestUrl = TrackLookup.lookup(track, album, artist);

            string result = TrackLookup.Fetch(requestUrl);

            //Submit Get request, extract info from pulled form
            string asin = result;

            beginPlay(asin);
        }

        private void txtISBNsearch_TextChanged(object sender, EventArgs e) {
            if (txtUPCsearch.Text.Length >= 0) {
                searcher(txtUPCsearch.Text, "upc");
            }
        }

        private void txtTitleSearch_TextChanged(object sender, EventArgs e) {
            if (txtAlbumSearch.Text.Length >= 0) {
                searcher(txtAlbumSearch.Text, "album");
            }
        }

        private void txtAuthorSearch_TextChanged(object sender, EventArgs e) {
            if (txtArtistSearch.Text.Length >= 0) {
                searcher(txtArtistSearch.Text, "artist");
            }
        }

        private void txtPublisherSearch_TextChanged(object sender, EventArgs e) {
            if (txtPublisherSearch.Text.Length >= 0) {
                searcher(txtPublisherSearch.Text, "publisher");
            }
        }

        private void txtPublisherSearch_Enter(object sender, EventArgs e) {
            txtPublisherSearch.Text = "";
        }

        private void txtAuthorSearch_Enter(object sender, EventArgs e) {
            txtArtistSearch.Text = "";
        }

        private void txtTitleSearch_Enter(object sender, EventArgs e) {
            txtAlbumSearch.Text = "";
        }

        private void txtISBNsearch_Enter(object sender, EventArgs e) {
            txtUPCsearch.Text = "";
        }

        private void tabPageISBN_Click(object sender, EventArgs e) {
            clears();
        }

        private void tabPageTitle_Click(object sender, EventArgs e) {
            clears();
        }

        private void tabPageAuthor_Click(object sender, EventArgs e) {
            clears();
        }

        private void tabPagePublisher_Click(object sender, EventArgs e) {
            clears();
        }

        private void searcher(string field, string column) {
            try {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select UPC, Artist, Album, Type, Publisher, Release_Date, Available from cd where " + column + " like '%" + field + "%' order by Artist, Album;";

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
            catch (Exception ee) {
                MessageBox.Show(ee.Message);
            }
        }

        private void clears() {
            txtUPCsearch.Text = "Enter all or part of a UPC here...";
            txtPublisherSearch.Text = "Enter all or part of a publisher here...";
            txtArtistSearch.Text = "Enter all or part of an author here...";
            txtAlbumSearch.Text = "Enter all or part of a title here...";

            refresh();
            dgvMusic.ClearSelection();
        }

        private void tabSet1_SelectedIndexChanged(object sender, EventArgs e) {
            clears();
        }

        private void lstCurrentTracks_SelectedIndexChanged(object sender, EventArgs e) {
            try
            {
                string value = lstCurrentTracks.SelectedItem.ToString();
                value = RemoveDigits(value.Replace("\t", ""));

                lookup(value, albumname, artistname);
            }
            catch
            {
                MessageBox.Show("Unfortunately, music preview isn't available for this track.");
            }
        }

        private void dgvMusic_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex >= 0) {
                dgvMusic.ClearSelection();
                dgvMusic.CurrentCell = dgvMusic.Rows[e.RowIndex].Cells[1];
                dgvMusic.Rows[e.RowIndex].Selected = true;

                int selectedRow = dgvMusic.CurrentRow.Index;
                cdid = dgvMusic[0, selectedRow].Value.ToString();
                albumname = dgvMusic[1, selectedRow].Value.ToString();
                artistname = dgvMusic[2, selectedRow].Value.ToString();
                databaseHandler d = new databaseHandler();
                lstCurrentTracks.Items.Clear();

                cdid = (d.CDResults(cdid))[6];

                string sql = "select * from track where cd_id = " + cdid + " order by disc_number, track_number;";
                ArrayList adder = d.populateTracks(sql);

                lstCurrentTracks.Items.Add("DISC \t NO. \t TITLE");
                lstCurrentTracks.Items.Add("");
                foreach (string x in adder) {
                    lstCurrentTracks.Items.Add(x);
                }

                if (e.Button == MouseButtons.Right) {
                    dgvClick.Show(Cursor.Position);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            string row = dgvMusic[0, dgvMusic.CurrentRow.Index].Value.ToString();
            frmEditMusic form = new frmEditMusic(row);
            form.FormClosed += new FormClosedEventHandler(frmEditMusic_FormClosed);
            form.Show();
        }

        private void frmEditMusic_FormClosed(object sender, FormClosedEventArgs e) {
            refresh();
            dgvMusic.ClearSelection();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            string row = dgvMusic[0, dgvMusic.CurrentRow.Index].Value.ToString();

            if (MessageBox.Show("Are you sure?", "Confirm Deletion", MessageBoxButtons.YesNo) == DialogResult.No) {
                MessageBox.Show("Request ignored");
                dgvMusic.ClearSelection();
                return;
            }

            try {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "delete from cd where UPC = '" + row + "';";
                string query2 = "delete from track where UPC = '" + row + "';";

                OleDbDataAdapter da = new OleDbDataAdapter(query, connectionString);
                OleDbDataAdapter da2 = new OleDbDataAdapter(query2, connectionString);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
                OleDbCommandBuilder cb2 = new OleDbCommandBuilder(da2);
                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvMusic.DataSource = bs;

                da.Update(dt);

            }
            catch (Exception ex) {
                MessageBox.Show("Unexpected error: " + ex);
            }
            finally {
                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();
            }

            refresh();
            dgvMusic.ClearSelection();
        }
        private void refresh() 
        {
            try {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string query = "select UPC, Artist, Album, Type, Publisher, Release_Date, Available from cd order by Artist, Album;";

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
            catch (Exception ee) {
                MessageBox.Show("There was a problem loading the CD list.\n" + ee.Message);
            }
        }
    }
}