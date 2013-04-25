using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace openLibrary_2._0 {
    public partial class frmEditBook : Form {


        frmViewBooks view = new frmViewBooks();
        public string bookID;
        string[] bookinfo = new string[8];

        public frmEditBook(string book) {
            bookID = book;
            InitializeComponent();
        }

        databaseHandler d = new databaseHandler();
        public string sqlstatement;

        private void btnUpdate_Click(object sender, EventArgs e) {
            try {
                string isbn;
                string title;
                string publisher;
                string format;
                string author;
                string pages;
                string price;
                string date;

                isbn = escapeHandling(txtISBN.Text);
                title = escapeHandling(txtTitle.Text);
                author = escapeHandling(txtAuthor.Text);
                publisher = escapeHandling(txtPublisher.Text);
                format = escapeHandling(txtBinding.Text);
                pages = escapeHandling(txtPages.Text);
                price = escapeHandling(txtPrice.Text);
                date = escapeHandling(txtDate.Text);

                sqlstatement = "UPDATE Book " +
                                    "SET TITLE = '" + title + "', " +
                                    "AUTHOR = '" + author + "', " +
                                    "PUBLISHER = '" + publisher + "', " +
                                    "BINDING = '" + format + "', " +
                                    "PUB_DATE = '" + date + "', " +
                                    "PRICE = '" + price + "', " +
                                    "PAGES = '" + pages + "' " +
                                    "WHERE ISBN = '" + isbn + "';";

                d.loadDatabaseTable(sqlstatement);

                clearFields();
                Close();
            }
            catch {
                MessageBox.Show("The book could not be added. A common cause of this error is not having a database open.");
            }
            finally {
                d.closeDatabaseConnection();
            }
        }

        private void btnClear_Click(object sender, EventArgs e) {
            clearFields();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private string escapeHandling(string line) {
            return line.Replace("'", "''");
        }

        private void clearFields() {
            txtISBN.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtPublisher.Clear();
            txtBinding.Clear();
            txtDate.Clear();
            txtPrice.Clear();
            txtPages.Clear();
        }

        private void frmEditBook_Load(object sender, EventArgs e) {
            bookinfo = d.BookResults(bookID);

            txtISBN.Text = bookID;
            txtTitle.Text = bookinfo[0];
            txtAuthor.Text = bookinfo[1];
            txtBinding.Text = bookinfo[2];
            txtPublisher.Text = bookinfo[3];
            txtDate.Text = bookinfo[4];
            txtPrice.Text = bookinfo[5];
            txtPages.Text = bookinfo[6];
        }
    }
}
