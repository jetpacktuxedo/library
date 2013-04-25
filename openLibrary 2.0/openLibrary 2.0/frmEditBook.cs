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

        public string bookID;

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


                int bookid;

                bookid = d.findBookCount("SELECT max(cint(book_id)) FROM book;");
                bookid++;

                isbn = escapeHandling(txtISBN.Text);
                title = escapeHandling(txtTitle.Text);
                author = escapeHandling(txtAuthor.Text);
                publisher = escapeHandling(txtPublisher.Text);
                format = escapeHandling(txtBinding.Text);
                pages = escapeHandling(txtPages.Text);
                price = escapeHandling(txtPrice.Text);
                date = escapeHandling(txtDate.Text);

                sqlstatement = "INSERT INTO BOOK (BOOK_ID, ISBN, TITLE, BINDING, PUBLISHER, AUTHOR, PUB_DATE, PRICE, PAGES)" +
                                          "VALUES ('" + bookid + "','" + isbn + "','" + title + "','" + format + "','" + publisher + "','" + author + "','" + date + "','" + price + "','" + pages + "');";

                d.loadDatabaseTable(sqlstatement);

                clearFields();
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
            txtBookID.Clear();
            txtISBN.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtPublisher.Clear();
            txtBinding.Clear();
            txtDate.Clear();
            txtPrice.Clear();
            txtPages.Clear();
        }
    }
}
