﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace openLibrary_2._0
{
    public partial class frmAddGame : Form
    {
        string requestUrl, title, author, binding, publisher, date, price, pages, itemID;

        databaseHandler d = new databaseHandler();
        public string sqlstatement;

        public frmAddGame()
        {
            InitializeComponent();
        }

        private void btnPopulate_Click(object sender, EventArgs e)
        {
            itemID = txtISBN.Text;

            if (txtISBN.Text == "")
            {
                MessageBox.Show("Please enter an ISBN.");
            }
            else if (itemID == "False") ;  //intentionally empty.
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
                txtPublisher.Text = publisher;
                txtDate.Text = date;
                txtPrice.Text = price;
                txtPages.Text = pages;
            }

            btnAdd.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addToDB();
            txtISBN.Focus();
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

                bookid = d.findBookCount("SELECT max(game_id) FROM game;");
                bookid++;

                isbn = txtISBN.Text;
                title = escapeHandling(txtTitle.Text);
                publisher = txtPublisher.Text;
                format = txtBinding.Text;
                pages = txtPages.Text;
                price = txtPrice.Text;
                date = txtDate.Text;

                sqlstatement = "INSERT INTO GAME (GAME_ID, UPC, TITLE, DISC_TYPE, STUDIO, RELEASE_DATE, PRICE, PLATFORM)" +
                                          "VALUES ('" + bookid + "','" + isbn + "','" + title + "','" + format + "','" + publisher + "','" + date + "','" + price + "','" + pages + "');";

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
            txtPublisher.Clear();
            txtBinding.Clear();
            txtDate.Clear();
            txtPrice.Clear();
            txtPages.Clear();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}