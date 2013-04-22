using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;


namespace openLibrary_2._0
{
    public partial class frmOverdueItems : Form
    {
        public string connectionString;
        public int numberSent = 0;
        public int numberTotal = 0;
        public frmOverdueItems()
        {
            InitializeComponent();
        }

        private void frmOverdueItems_Load(object sender, EventArgs e)
       { 
            try
            {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string bookQuery = "SELECT book.TITLE, book_CHECKOUT.DUE_DATE, customer.first_name &' '&customer.last_name as CUSTOMER_NAME, customer.email_addr AS EMAIL_ADDRESS FROM (((book inner join book_checkout on book.book_id = book_checkout.book_id) inner join checkout on book_checkout.checkout_id = checkout.checkout_id) inner join customer on checkout.customer_id = customer.customer_id) WHERE (((book_CHECKOUT.DUE_DATE)<#" + System.DateTime.Now + "#));";
                string movieQuery = "SELECT movie.TITLE, movie_CHECKOUT.DUE_DATE, customer.first_name &' '&customer.last_name as CUSTOMER_NAME, customer.email_addr AS EMAIL_ADDRESS  FROM (((movie inner join movie_checkout on movie.movie_id = movie_checkout.movie_id) inner join checkout on movie_checkout.checkout_id = checkout.checkout_id) inner join customer on checkout.customer_id = customer.customer_id) WHERE (((movie_CHECKOUT.DUE_DATE)<#" + System.DateTime.Now + "#));";
                string musicQuery = "SELECT cd.album as TITLE, cd_CHECKOUT.DUE_DATE, customer.first_name &' '&customer.last_name as CUSTOMER_NAME, customer.email_addr AS EMAIL_ADDRESS FROM (((cd inner join cd_checkout on cd.cd_id = cd_checkout.cd_id) inner join checkout on cd_checkout.checkout_id = checkout.checkout_id) inner join customer on checkout.customer_id = customer.customer_id) WHERE (((cd_CHECKOUT.DUE_DATE)<#" + System.DateTime.Now + "#));";
                string gameQuery = "SELECT game.TITLE, game_CHECKOUT.DUE_DATE, customer.first_name &' '&customer.last_name as CUSTOMER_NAME, customer.email_addr  AS EMAIL_ADDRESS FROM (((game inner join game_checkout on game.game_id = game_checkout.game_id) inner join checkout on game_checkout.checkout_id = checkout.checkout_id) inner join customer on checkout.customer_id = customer.customer_id) WHERE (((game_CHECKOUT.DUE_DATE)<#" + System.DateTime.Now + "#));";

                //BEGIN BOOK OVERDUE CHECK
                OleDbDataAdapter bookDA = new OleDbDataAdapter(bookQuery, connectionString);
                OleDbCommandBuilder bookCB = new OleDbCommandBuilder(bookDA);
                DataTable bookDT = new DataTable();
                bookDA.Fill(bookDT);
                BindingSource bookBS = new BindingSource();
                bookBS.DataSource = bookDT;
                dgvOverdueBooks.DataSource = bookBS;
                bookDA.Update(bookDT);
                //END BOOK OVERDUE CHECK

                //BEGIN MOVIE OVERDUE CHECK
                OleDbDataAdapter movieDA = new OleDbDataAdapter(movieQuery, connectionString);
                OleDbCommandBuilder movieCB = new OleDbCommandBuilder(movieDA);
                DataTable movieDT = new DataTable();
                movieDA.Fill(movieDT);
                BindingSource movieBS = new BindingSource();
                movieBS.DataSource = movieDT;
                dgvOverdueMovies.DataSource = movieBS;
                movieDA.Update(movieDT);
                //END MVOIE OVERDUE CHECK

                //BEGIN MUSIC OVERDUE CHECK
                OleDbDataAdapter musicDA = new OleDbDataAdapter(musicQuery, connectionString);
                OleDbCommandBuilder musicCB = new OleDbCommandBuilder(musicDA);
                DataTable musicDT = new DataTable();
                musicDA.Fill(musicDT);
                BindingSource musicBS = new BindingSource();
                musicBS.DataSource = musicDT;
                dgvOverdueMusic.DataSource = musicBS;
                musicDA.Update(musicDT);
                //END MUSIC OVERDUE CHECK

                //BEGIN GAME OVERDUE CHECK
                OleDbDataAdapter gameDA = new OleDbDataAdapter(gameQuery, connectionString);
                OleDbCommandBuilder gameCB = new OleDbCommandBuilder(gameDA);
                DataTable gameDT = new DataTable();
                gameDA.Fill(gameDT);
                BindingSource gameBS = new BindingSource();
                gameBS.DataSource = gameDT;
                dgvOverdueGames.DataSource = gameBS;
                gameDA.Update(gameDT);
                //END GAME OVERDUE CHECK


                databaseHandler d = new databaseHandler();
                d.closeDatabaseConnection();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSendReport_Click(object sender, EventArgs e)
        {
            
            int bookcount = dgvOverdueBooks.RowCount;
            int musicCount = dgvOverdueMusic.RowCount;
            int moviecount = dgvOverdueMovies.RowCount;
            int gamecount = dgvOverdueGames.RowCount;
            
            btnSendReport.Text = "Working...";
            btnClose.Text = "Please Wait.";
            btnSendReport.Enabled = false;
            btnClose.Enabled = false;

            //OVERDUE BOOKS
            
            bookcount = bookcount - 2;
            for (int i = 0; i <= bookcount; i++)
            {
                string emailAddr = dgvOverdueBooks[3, i].Value.ToString();
                string title = dgvOverdueBooks[0, i].Value.ToString();
                DateTime duedate = Convert.ToDateTime(dgvOverdueBooks[1, i].Value.ToString());
                string due = duedate.ToShortDateString(); 
                string customer = dgvOverdueBooks[2, i].Value.ToString();
                string subject = "Notice from your Local Library Regarding Overdue Book";
                string message = "Dear " + customer + ": \n\nThis is an automated message from your local library. Please do not reply to it. According to our records, "
                               + "\n\n'" + title + "' was due on " + due + ". \n\nPlease come to the library as soon as possible "
                               + "and return the book. As of today, you are subject to a charge of $0.05 per day, per item, until you return "
                               + "the book. If you need to renew the book, you can do this over the phone. Please call our front desk at "
                               + "555-555-5555 to do so. \n\n\n Thank you for your business. If you have any further questions, please feel free "
                               + "to contact us. \n\n\n\n ----\nLocal Library Name \nLibrary Address \nLibrary Phone \n\nPowered by openLibrary.";
                send(emailAddr, subject, message, customer);
            }

            //OVERDUE MUSIC
            musicCount = musicCount - 2;
            for (int i = 0; i <= musicCount; i++)
            {
                string emailAddr = dgvOverdueMusic[3, i].Value.ToString();
                string title = dgvOverdueMusic[0, i].Value.ToString();
                DateTime duedate = Convert.ToDateTime(dgvOverdueMusic[1, i].Value.ToString());
                string due = duedate.ToShortDateString();
                string customer = dgvOverdueMusic[2, i].Value.ToString();
                string subject = "Notice from your Local Library Regarding Overdue Music";
                string message = "Dear " + customer + ": \n\nThis is an automated message from your local library. Please do not reply to it. According to our records, "
                               + "\n\n'" + title + "' was due on " + due + ". \n\nPlease come to the library as soon as possible "
                               + "and return the music. As of today, you are subject to a charge of $0.05 per day, per item, until you return "
                               + "the music. If you need to renew the music, you can do this over the phone. Please call our front desk at "
                               + "555-555-5555 to do so. \n\n\n Thank you for your business. If you have any further questions, please feel free "
                               + "to contact us. \n\n\n\n ----\nLocal Library Name \nLibrary Address \nLibrary Phone \n\nPowered by openLibrary.";
                send(emailAddr, subject, message, customer);
            }

            //OVERDUE MOVIES
            moviecount = moviecount - 2;
            for (int i = 0; i <= moviecount; i++)
            {
                string emailAddr = dgvOverdueMovies[3, i].Value.ToString();
                string title = dgvOverdueMovies[0, i].Value.ToString();
                DateTime duedate = Convert.ToDateTime(dgvOverdueMovies[1, i].Value.ToString());
                string due = duedate.ToShortDateString();
                string customer = dgvOverdueMovies[2, i].Value.ToString();
                string subject = "Notice from your Local Library Regarding Overdue movie";
                string message = "Dear " + customer + ": \n\nThis is an automated message from your local library. Please do not reply to it. According to our records, "
                               + "\n\n'" + title + "' was due on " + due + ". \n\nPlease come to the library as soon as possible "
                               + "and return the movie. As of today, you are subject to a charge of $0.05 per day, per item, until you return "
                               + "the movie. If you need to renew the movie, you can do this over the phone. Please call our front desk at "
                               + "555-555-5555 to do so. \n\n\n Thank you for your business. If you have any further questions, please feel free "
                               + "to contact us. \n\n\n\n ----\nLocal Library Name \nLibrary Address \nLibrary Phone \n\nPowered by openLibrary.";
                send(emailAddr, subject, message, customer);
            }

            //OVERDUE GAMES
            gamecount = gamecount - 2;
            for (int i = 0; i <= gamecount; i++)
            {
                string emailAddr = dgvOverdueGames[3, i].Value.ToString();
                string title = dgvOverdueGames[0, i].Value.ToString();
                DateTime duedate = Convert.ToDateTime(dgvOverdueGames[1, i].Value.ToString());
                string due = duedate.ToShortDateString();
                string customer = dgvOverdueGames[2, i].Value.ToString();
                string subject = "Notice from your Local Library Regarding Overdue Game";
                string message = "Dear " + customer + ": \n\nThis is an automated message from your local library. Please do not reply to it. According to our records, "
                               + "\n\n'" + title + "' was due on " + due + ". \n\nPlease come to the library as soon as possible "
                               + "and return the game. As of today, you are subject to a charge of $0.05 per day, per item, until you return "
                               + "the game. If you need to renew the game, you can do this over the phone. Please call our front desk at "
                               + "555-555-5555 to do so. \n\n\n Thank you for your business. If you have any further questions, please feel free "
                               + "to contact us. \n\n\n\n ----\nLocal Library Name \nLibrary Address \nLibrary Phone \n\nPowered by openLibrary.";
                send(emailAddr, subject, message, customer);
            }


            btnSendReport.Text = "Send Reports";
            btnClose.Text = "Close";
            btnSendReport.Enabled = true;
            btnClose.Enabled = true;

            MessageBox.Show("Successfully sent " + numberSent + " overdue notices.");
        }




        public void send(string to, string subject, string body, string customer)
        {

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("noreply.openLibrary@gmail.com", "b0uldering"),
                EnableSsl = true
            };
            client.Send("noreply.openlibrary@gmail.com", to, subject, body);
            numberSent++;   
        }
    }
}
