using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace openLibrary_2._0
{
    public partial class frmAddMusic : Form
    {
        String requestUrl, title, author, binding, publisher, date, price, pages, itemID;

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
        itemID = txtISBN.Text;

            if (txtISBN.Text == "") {
                MessageBox.Show("Please enter an ISBN.");
            }
            else if (itemID == "False") ; //intentionally empty.
            else
            {
                //Format url for the get request
                requestUrl = otherLookup.otherlookup(itemID);

                string[] result = otherLookup.otherFetch(requestUrl);

                //Submit Get request, extract info from pulled form
                title = result[0];
                author = result[1];
                binding = result[2];
                publisher = result[3];
                date = result[4];
                price = result[5];
                pages = result[6];

                //Push title and author data back into the form
                txtTitle.Text = title;
                txtBinding.Text = binding;
                txtAuthor.Text = author;
                txtPublisher.Text = publisher;
                txtDate.Text = date;
                txtPrice.Text = price;
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

                bookid = d.findBookCount("SELECT max(cd_id) FROM cd;");
                bookid++;

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

                clearFields();
            }
            catch
            {
                MessageBox.Show("The book could not be added. A common cause of this error is not having a database open.");
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
    }
}
