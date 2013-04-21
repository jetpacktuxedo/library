﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Collections;


namespace openLibrary_2._0
{

    class databaseHandler
    {
        public OleDbConnection mDB;
        public string connectionString;

        public void openNew()
        {
            OpenFileDialog ofd;
            try
            {
                ofd = new OpenFileDialog();
                ofd.Title = "Select the database file to open";
                ofd.Filter = "Database Files(*.mdb)|*.mdb|All files(*.*)|*.*";
                ofd.InitialDirectory = Path.Combine(Application.StartupPath, "@/Databases");

                if (ofd.ShowDialog() == DialogResult.OK) frmHomeScreen.mUserFile = ofd.FileName;

            }
            catch (Exception ee) { MessageBox.Show("There was an error: " + ee.Message); }
        }

        public void inserter(string sql)
        {
            try
            {
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error: Nothing was added.");
            }
        }

        public void loadDatabaseTable(string sql)
        {

            try
            {

                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                OleDbDataReader rdr;
                cmd = new OleDbCommand(sql, mDB);
                rdr = cmd.ExecuteReader();

                rdr.Close();
            }
            catch (Exception ee) { MessageBox.Show("Something Went Wrong: " + ee.Message + ee.ToString()); }
        }

        public ArrayList populateTracks(string sql)
        {

            ArrayList tracker = new ArrayList();
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                OleDbDataReader rdr;
                cmd = new OleDbCommand(sql, mDB);
                rdr = cmd.ExecuteReader();



                while (rdr.Read())
                {
                    tracker.Add((string)rdr["Disc_Number"] + "\t" + (string)rdr["Track_Number"] + "\t" + (string)rdr["Track_name"]);
                }

            }
            catch (Exception s)
            {
                MessageBox.Show("Error." + s.Message + s.ToString());
            }

            return tracker;
        }

        public void closeDatabaseConnection()
        {
            if (mDB != null) mDB.Close();
        }

        public void openDatabaseConnection()
        {
            connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
            mDB = new OleDbConnection(connectionString);
        }

        public void clockIN(string id)
        {
            try
            {
                string sql = "insert into timeclock(employee_id, time_in, time_out) values ('" + id + "','" + DateTime.Now + "','" + "Currently Clocked In" + "');";

                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Succesfully clocked in at: " + DateTime.Now.ToShortTimeString());
            }
            catch (Exception e)
            {
                MessageBox.Show("Unfortunantely, there was an error." + e.ToString());
            }
        }

        public void clockOUT(string id)
        {
            try
            {
                string sql = "update timeclock set time_out = '" + DateTime.Now + "' where employee_id = '" + id + "' and time_out = 'Currently Clocked In';";

                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Succesfully clocked out at: " + DateTime.Now.ToShortTimeString());
            }
            catch (Exception e)
            {
                MessageBox.Show("Unfortunantely, there was an error." + e.ToString());
            }
        }

        public void renewDue(string sql)
        {
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                cmd.ExecuteNonQuery();

                MessageBox.Show("The book has been renewed successfully. It is now due " + System.DateTime.Now.AddDays(14).ToShortDateString());
            }
            catch (Exception e)
            {
                MessageBox.Show("Unfortunantely, there was an error." + e.ToString());
            }
        }

        public Tuple<string, string> whatKindOfItem(string code)
        {
            try
            {
                string sql = "select 'book', cstr(book_id) as 'ID' from book where isbn = '"+code+"' union select 'movie', cstr(movie_id) as 'ID' from movie where upc = '"+code+"' union select 'cd', cstr(cd_id) as 'ID' from cd where upc = '"+code+"' union select 'game', cstr(game_id) as 'ID' from game where upc = '"+code+"'";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                OleDbDataReader readdr;
                cmd = new OleDbCommand(sql, mDB);
                readdr = cmd.ExecuteReader();
                while (readdr.Read())
                {
                    return new Tuple<string, string>((string)readdr[0], (string)readdr[1]);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Something went wrong." + e.Message + e.ToString());
            }

            return new Tuple<string, string>("Not found", "Not Found");

        }

        public void checkoutBook(string userID, string empID, string scanned)
        {
            //find out what the checkout id should be for this transaction
            int checkoutID = findBookCount("select max(checkout_id) from checkout");
            checkoutID++;

            //make a new record in the checkout table.
            string sql = "insert into checkout (checkout_id, checkout_date, employee_id, customer_id) values ('" + checkoutID + "',#" + System.DateTime.Now + "#, '" + empID + "','" + userID + "');";
            openDatabaseConnection();
            mDB.Open();
            OleDbCommand cmd;

            try
            {
                cmd = new OleDbCommand(sql, mDB);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("There was an error adding the checkout.");
            }


            //find out if the scanned item
            string itemType;
            string itemID;
            itemType = whatKindOfItem(scanned).Item1;
            itemID = whatKindOfItem(scanned).Item2;

            if (itemType == "game")
            {
                string newSQL = "insert into game_checkout values('" + scanned + "', '" + checkoutID + "', #" + System.DateTime.Now.ToShortDateString() + "#);";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand newCMD;
                try
                {
                    newCMD = new OleDbCommand(newSQL, mDB);
                    newCMD.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("There was an error adding the game_checkout.");
                }
            }

            if (itemType == "cd")
            {
                string newSQL = "insert into cd_checkout values('" + scanned + "', '" + checkoutID + "', #" + System.DateTime.Now.ToShortDateString() + "#);";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand newCMD;
                try
                {
                    newCMD = new OleDbCommand(newSQL, mDB);
                    newCMD.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("There was an error adding the cd_checkout.");
                }
            }

            if (itemType == "movie")
            {
                string newSQL = "insert into movie_checkout values('" + scanned + "', '" + checkoutID + "', #" + System.DateTime.Now.ToShortDateString() + "#);";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand newCMD;
                try
                {
                    newCMD = new OleDbCommand(newSQL, mDB);
                    newCMD.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("There was an error adding the movie_checkout.");
                }
            }

            if (itemType == "book")
            {
                string newSQL = "insert into book_checkout values('" + scanned + "', '" + checkoutID + "', #" + System.DateTime.Now.ToShortDateString() + "#);";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand newCMD;
                try
                {
                    newCMD = new OleDbCommand(newSQL, mDB);
                    newCMD.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("There was an error adding the book_checkout.");
                }
            }

            closeDatabaseConnection();
        }

        public ArrayList whoIsClockedIn()
        {
            ArrayList clocked = new ArrayList();
            try
            {
                string sql = "select employee_id from timeclock where time_out = 'Currently Clocked In';";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                OleDbDataReader rdr;
                cmd = new OleDbCommand(sql, mDB);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    clocked.Add((string)rdr["employee_id"]);
                }

            }
            catch
            {
                MessageBox.Show("Sorry, an error occured.");
            }
            return clocked;

        }

        public int findBookCount(string sql)
        {


            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                OleDbDataReader readdr;
                cmd = new OleDbCommand(sql, mDB);
                readdr = cmd.ExecuteReader();

                while (readdr.Read())
                {
                    return (int)readdr[0];
                }

            }

            catch (Exception ee)
            {
                MessageBox.Show("Something went wrong: " + ee.Message + ee.ToString());
                return (int)-1;
            }

            closeDatabaseConnection();
            return -1;
        }

        public string loadCustomerName(string sql)
        {
            string cname = "";
            openDatabaseConnection();
            mDB.Open();
            OleDbCommand cmd;
            OleDbDataReader rdr;
            cmd = new OleDbCommand(sql, mDB);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
                cname = (string)rdr[0];

            if (cname == "")
            {
                MessageBox.Show("This customer is not in the database.");
                return "Customer is not in the database.";
            }
            else
                return cname;
        }

        public ArrayList loadCustomerCheckouts(string customerID)
        {
            ArrayList CurrentlyCheckedOut = new ArrayList();
            try
            {

                string booksql = "select title, due_date from book where checked_out = yes and customer_id = '" + customerID + "';";
                string moviesql = "select title, due_date from movie where checked_out = yes and customer_id ='" + customerID + "';";
                string gamesql = "select title, due_date from game where checked_out = yes and customer_id ='" + customerID + "';";
                string musicsql = "select album, due_date from cd where checked_out = yes and customer_id ='" + customerID + "';";

                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                OleDbDataReader rdr;
                bool added = false;

                CurrentlyCheckedOut.Add("TYPE \t DUE DATE \t TITLE");
                CurrentlyCheckedOut.Add("============================================================================");

                //Add the customer's books to the ArrayList
                cmd = new OleDbCommand(booksql, mDB);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CurrentlyCheckedOut.Add("Book:\t" + Convert.ToDateTime(rdr["due_date"]).ToString("MM/dd/yyyy") + "\t" + (string)rdr["title"]);
                    added = true;
                }
                if (added == true)
                    CurrentlyCheckedOut.Add("");

                //Add the customer's movies to the ArrayList
                cmd = new OleDbCommand(moviesql, mDB);
                rdr = cmd.ExecuteReader();
                added = false;
                while (rdr.Read())
                {
                    CurrentlyCheckedOut.Add("Movie\t" + Convert.ToDateTime(rdr["due_date"]).ToString("MM/dd/yyyy") + "\t" + (string)rdr["title"]);
                    added = true;
                }

                if (added == true)
                    CurrentlyCheckedOut.Add("");

                //Add the customer's games to the ArrayList
                cmd = new OleDbCommand(gamesql, mDB);
                rdr = cmd.ExecuteReader();
                added = false;
                while (rdr.Read())
                {
                    CurrentlyCheckedOut.Add("Game:\t" + Convert.ToDateTime(rdr["due_date"]).ToString("MM/dd/yyyy") + "\t" + (string)rdr["title"]);
                    added = true;
                }

                if (added == true)
                    CurrentlyCheckedOut.Add("");

                //Add the customer's music to the ArrayList
                cmd = new OleDbCommand(musicsql, mDB);
                rdr = cmd.ExecuteReader();
                added = false;

                while (rdr.Read())
                {
                    CurrentlyCheckedOut.Add("Music:\t" + Convert.ToDateTime(rdr["due_date"]).ToString("MM/dd/yyyy") + "\t" + (string)rdr["album"]);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message + x.ToString());
            }

            return CurrentlyCheckedOut;
        }

        public string[] Deserialize(string serializedRecord)
        {
            string[] values = serializedRecord.Split('\t');

            return values;
        }


    }
}

