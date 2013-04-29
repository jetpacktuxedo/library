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
using System.Collections;

namespace openLibrary_2._0
{
    public partial class frmAddMovie : Form
    {
        String requestUrl, title, author, binding, publisher, date, price, pages, itemID;
        databaseHandler d = new databaseHandler();
        ArrayList actors = new ArrayList();

        public string sqlstatement;

        public frmAddMovie()
        {
            InitializeComponent();
        }

        private void btnPopulate_Click(object sender, EventArgs e)
        {
            lstActors.Items.Clear();

            //Convert ISBN-13 to ISBN-10
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

                ArrayList result = new ArrayList();
                result = otherLookup.otherFetch(requestUrl);

                //Submit Get request, extract info from pulled form
                if (result != null)
                {
                    title = result[0].ToString();
                    author = result[1].ToString();
                    binding = result[2].ToString();
                    publisher = result[3].ToString();
                    date = result[4].ToString();
                    price = result[5].ToString();
                    pages = result[6].ToString();
                    actors = (ArrayList)result[7];
                }

                //Push title and author data back into the form
                txtTitle.Text = title;
                txtAuthor.Text = author;
                txtBinding.Text = binding;
                txtPublisher.Text = publisher;
                txtDate.Text = date;
                txtPrice.Text = price;
                txtPages.Text = pages;

                //Throw tracks and shit into the listbox
                //int i = 0;
                //while(i < tracks.Count){
                //    listBox1.Items.Add(tracks[i] + "-" + tracks[i+1] + " - " + tracks[i+2]);
                //    i+=3;
                //}
                //Movies

                int i = 0;
                while (i < actors.Count)
                {
                    lstActors.Items.Add(actors[i]);
                    i++;
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


                int bookid = 0; 
                int actorid = 0;

                try
                {
                    bookid = d.findBookCount("SELECT max(cint(movie_id)) FROM movie;");
                    bookid++;

                    actorid = d.findBookCount("SELECT max(cint(ACTOR_ID)) FROM ACTOR;");
                    actorid++;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString() + e.Message);
                }

                isbn = escapeHandling(txtISBN.Text);
                title = escapeHandling(txtTitle.Text);
                author = escapeHandling(txtAuthor.Text);
                publisher = escapeHandling(txtPublisher.Text);
                format = escapeHandling(txtBinding.Text);
                price = escapeHandling(txtPrice.Text);
                date = escapeHandling(txtDate.Text);

                sqlstatement = "INSERT INTO movie (movie_id, UPC, TITLE, DIRECTOR, TYPE, STUDIO, RELEASE_DATE, PRICE, RUNNING_TIME, available)" +
                                          "VALUES ('" + bookid + "','" + isbn + "','" + title + "','" + author + "','" + format + "','" + publisher + "','" + date + "','" + price + "','" + pages + "', true);";

                d.loadDatabaseTable(sqlstatement);

                int i = 0;
                while (i < actors.Count) {
                    sqlstatement = "INSERT INTO ACTOR (MOVIE_ID, ACTOR_ID, ACTOR_NAME)" +
                                              "VALUES ('" + bookid + "','" + (actorid + i).ToString() +"','" + escapeHandling(actors[i].ToString()) + "');";

                    d.inserter(sqlstatement);
                    i++;
                }

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
            txtPages.Clear();
            lstActors.Items.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            addToDB();
            txtISBN.Focus();
        }

        private void frmAddMovie_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
            txtISBN.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    
    }
}
