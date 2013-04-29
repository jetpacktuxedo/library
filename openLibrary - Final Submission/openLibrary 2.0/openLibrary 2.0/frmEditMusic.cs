/*
 * This code copyright 2013 by openLibrary
 * Developed by Tai Gunter and Ethan Madden.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace openLibrary_2._0 {
    public partial class frmEditMusic : Form {

        public string cdID;
        string[] cdinfo = new string[8];
        databaseHandler d = new databaseHandler();
        public string sqlstatement;

        public frmEditMusic(string cd) {
            cdID = cd;
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            try {
                string title;
                string publisher;
                string format;
                string author;
                string price;
                string date;

                title = escapeHandling(txtTitle.Text);
                author = escapeHandling(txtAuthor.Text);
                publisher = escapeHandling(txtPublisher.Text);
                format = escapeHandling(txtBinding.Text);
                price = escapeHandling(txtPrice.Text);
                date = escapeHandling(txtDate.Text);

                sqlstatement = "UPDATE CD " +
                                    "SET ALBUM = '" + title + "', " +
                                    "ARTIST = '" + author + "', " +
                                    "PUBLISHER = '" + publisher + "', " +
                                    "TYPE = '" + format + "', " +
                                    "RELEASE_DATE = '" + date + "', " +
                                    "PRICE = '" + price + "' " +
                                    "WHERE UPC = '" + cdID + "';";

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

        private void frmEditMusic_Load(object sender, EventArgs e) {
            cdinfo = d.CDResults(cdID);

            txtISBN.Text = cdID;
            txtTitle.Text = cdinfo[0];
            txtAuthor.Text = cdinfo[1];
            txtBinding.Text = cdinfo[2];
            txtPublisher.Text = cdinfo[3];
            txtDate.Text = cdinfo[4];
            txtPrice.Text = cdinfo[5];
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

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
