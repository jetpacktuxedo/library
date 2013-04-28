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
    public partial class frmEditGames : Form {

        public string gameID;
        string[] gameinfo = new string[8];
        databaseHandler d = new databaseHandler();
        public string sqlstatement;

        public frmEditGames(string game) {
            gameID = game;
            InitializeComponent();
        }

        private void frmEditGames_Load(object sender, EventArgs e) {
            gameinfo = d.gameResults(gameID);

            txtISBN.Text = gameID;
            txtTitle.Text = gameinfo[0];
            txtBinding.Text = gameinfo[1];
            txtPublisher.Text = gameinfo[2];
            txtDate.Text = gameinfo[3];
            txtPrice.Text = gameinfo[4];
            txtPages.Text = gameinfo[5];
        }

        private string escapeHandling(string line) {
            return line.Replace("'", "''");
        }

        private void clearFields() {
            txtISBN.Clear();
            txtTitle.Clear();
            txtPages.Clear();
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
                publisher = escapeHandling(txtPublisher.Text);
                format = escapeHandling(txtBinding.Text);
                price = escapeHandling(txtPrice.Text);
                date = escapeHandling(txtDate.Text);
                time = escapeHandling(txtPages.Text);

                sqlstatement = "UPDATE GAME " +
                                    "SET TITLE = '" + title + "', " +
                                    "STUDIO = '" + publisher + "', " +
                                    "DISC_TYPE = '" + format + "', " +
                                    "RELEASE_DATE = '" + date + "', " +
                                    "PLATFORM = '" + time + "', " +
                                    "PRICE = '" + price + "' " +
                                    "WHERE UPC = '" + gameID + "';";

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
