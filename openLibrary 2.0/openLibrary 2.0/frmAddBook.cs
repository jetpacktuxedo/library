using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace openLibrary_2._0
{
    

    public partial class frmAddBook : Form
    {
        string requestUrl, title, author, binding, publisher, date, price, pages, itemID;

        databaseHandler d = new databaseHandler();
        public string sqlstatement;

        public frmAddBook()
        {
            InitializeComponent();
        }

        [STAThread]

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {

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
                string pages;
                string price;
                string date;


                int bookid;

                bookid = d.findBookCount("SELECT max(book_id) FROM book;");
                bookid++;

                isbn = txtISBN.Text;
                title = escapeHandling(txtTitle.Text);
                author = txtAuthor.Text;
                publisher = txtPublisher.Text;
                format = txtBinding.Text;
                pages = txtPages.Text;
                price = txtPrice.Text;
                date = txtDate.Text;

                sqlstatement = "INSERT INTO BOOK (BOOK_ID, ISBN, TITLE, BINDING, PUBLISHER, AUTHOR, PUB_DATE, PRICE, PAGES)" +
                                          "VALUES ('" + bookid + "','" + isbn + "','" + title + "','" + format + "','" + publisher + "','" + author + "','" + date + "','" + price + "','" + pages + "');";

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

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            addToDB();
            txtISBN.Focus();
        }

        private string escapeHandling(string line)
        {
            return line.Replace("'", "''");

        }

        private void booklookup()
        {


            //Convert ISBN-13 to ISBN-10
            itemID = bookLookup.ConvertTo10(txtISBN.Text);

            if (txtISBN.Text == "")
            {
                MessageBox.Show("Please enter an ISBN.");
            }
            else if (itemID == "False") ; //intentionally empty.
            else
            {
                //Format url for the get request
                requestUrl = bookLookup.lookup(itemID);

                string[] result = bookLookup.Fetch(requestUrl);

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
                txtAuthor.Text = author;
                txtBinding.Text = binding;
                txtPublisher.Text = publisher;
                txtDate.Text = date;
                txtPrice.Text = price;
                txtPages.Text = pages;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();   
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
            txtPages.Clear(); 
        
        }

        private void frmAddBook_Load(object sender, EventArgs e)
        {
        
        }

        private void btnPopulate_Click(object sender, EventArgs e)
        {
            booklookup();        

            btnAdd.Focus();
        }

        private void chkAdd_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
