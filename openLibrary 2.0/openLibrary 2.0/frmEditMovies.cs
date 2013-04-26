using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace openLibrary_2._0 {
    public partial class frmEditMovies : Form {

        public string movieID;
        string[] movieinfo = new string[8];
        databaseHandler d = new databaseHandler();
        public string sqlstatement;

        public frmEditMovies(string movie) {
            movieID = movie;
            InitializeComponent();
        }

        private void frmEditMovies_Load(object sender, EventArgs e) {
            movieinfo = d.movieResults(movieID);

            txtISBN.Text = movieID;
            txtTitle.Text = movieinfo[0];
            txtAuthor.Text = movieinfo[1];
            txtBinding.Text = movieinfo[2];
            txtPublisher.Text = movieinfo[3];
            txtDate.Text = movieinfo[4];
            txtPrice.Text = movieinfo[5];
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
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            try {
                string title;
                string publisher;
                string format;
                string author;
                string price;
                string date;
                string time;

                title = escapeHandling(txtTitle.Text);
                author = escapeHandling(txtAuthor.Text);
                publisher = escapeHandling(txtPublisher.Text);
                format = escapeHandling(txtBinding.Text);
                price = escapeHandling(txtPrice.Text);
                date = escapeHandling(txtDate.Text);
                time = escapeHandling(txtPages.Text);

                sqlstatement = "UPDATE MOVIE " +
                                    "SET TITLE = '" + title + "', " +
                                    "DIRECTOR = '" + author + "', " +
                                    "STUDIO = '" + publisher + "', " +
                                    "TYPE = '" + format + "', " +
                                    "RELEASE_DATE = '" + date + "', " +
                                    "RUNNING_TIME = '" + date + "', " +
                                    "PRICE = '" + price + "' " +
                                    "WHERE UPC = '" + movieID + "';";

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
    }
}
