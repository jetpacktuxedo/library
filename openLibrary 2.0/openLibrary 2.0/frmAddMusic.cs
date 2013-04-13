using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;

namespace openLibrary_2._0
{
    public partial class frmAddMusic : Form
    {
        String requestUrl, title, author, binding, publisher, date, price, pages, itemID;
        ArrayList tracks = new ArrayList();


        databaseHandler d = new databaseHandler();
        public string sqlstatement;
        

        public frmAddMusic()
        {
            InitializeComponent();
        }

        private void btnPopulate_Click(object sender, EventArgs e)
        {
            lookupMusic();
            btnAdd.Focus();
        }

        private void lookupMusic()
        {
            lstTracks.Items.Clear();
            itemID = txtISBN.Text;



            if (txtISBN.Text == "") {
                MessageBox.Show("Please enter an ISBN.");
            }
            else if (itemID == "False"); //intentionally empty.
            else
            {
                //Format url for the get request
                requestUrl = otherLookup.otherlookup(itemID);
                ArrayList result = new ArrayList();

                result = otherLookup.otherFetch(requestUrl);

                //Submit Get request, extract info from pulled form
                if (result != null) {
                    title = result[0].ToString();
                    author = result[1].ToString();
                    binding = result[2].ToString();
                    publisher = result[3].ToString();
                    date = result[4].ToString();
                    price = result[5].ToString();
                    pages = result[6].ToString();
                    tracks = (ArrayList)result[7];
                }

                //Push title and author data back into the form
                txtTitle.Text = title;
                txtBinding.Text = binding;
                txtAuthor.Text = author;
                txtPublisher.Text = publisher;
                txtDate.Text = date;
                txtPrice.Text = price;

                int i = 0;
                lstTracks.Items.Add("DISC \t NO. \t TRACK TITLE");
                lstTracks.Items.Add("");
                while (i < tracks.Count)
                {
                    lstTracks.Items.Add(tracks[i] + "\t" + tracks[i + 1] + " \t " + tracks[i + 2]);
                    i += 3;
                }
            }
                
        
        }

        private void addToDB()
        {
            try
            {
                string isbn;
                string title;
                string publisher;
                string format;
                string author;
                string price;
                string date;

                int bookid;
                int trackid;

                bookid = d.findBookCount("SELECT max(cd_id) FROM cd;");
                bookid++;

                trackid = d.findBookCount("SELECT max(track_id) from track;");
                trackid++;

                isbn = txtISBN.Text;
                title = escapeHandling(txtTitle.Text);
                author = txtAuthor.Text;
                publisher = txtPublisher.Text;
                format = txtBinding.Text;
                price = txtPrice.Text;
                date = txtDate.Text;

                sqlstatement = "INSERT INTO CD (CD_ID, UPC, ALBUM, TYPE, PUBLISHER, RELEASE_DATE, PRICE, ARTIST)" +
                                          "VALUES ('" + bookid + "','" + isbn + "','" + title + "','" + format + "','" + publisher + "','" + date + "','" + price + "','" + author + "');";

                           
                d.loadDatabaseTable(sqlstatement);

                int i = 0;
                int j = 0;
                while(i < tracks.Count)
                {
                    sqlstatement = "INSERT INTO TRACK (CD_ID, TRACK_ID, DISC_NUMBER, TRACK_NUMBER, TRACK_NAME)" +
                                              "VALUES ('" + bookid + "','" + (trackid + j) + "','" + tracks[i] + "','" + tracks[i + 1] + "','" + tracks[i + 2] + "');";

                    d.inserter(sqlstatement);
                    i += 3;
                    j++;
                }

                clearFields();
            }
            catch (Exception p)
            {
                MessageBox.Show("The book could not be added. A common cause of this error is not having a database open." + p.Message);
            }
            finally
            {
                d.closeDatabaseConnection();
            }

        }

        private string escapeHandling(string line)
        {
            return line.Replace("'", "''");

        }

        private void clearFields()
        {
            txtISBN.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtPublisher.Clear();
            txtBinding.Clear();
            txtDate.Clear();
            txtPrice.Clear();
            lstTracks.Items.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addToDB();
            txtISBN.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
            txtISBN.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void frmAddMusic_Load(object sender, EventArgs e)
        {

        }
    }
}
