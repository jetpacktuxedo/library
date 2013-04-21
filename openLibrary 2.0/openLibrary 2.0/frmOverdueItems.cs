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


namespace openLibrary_2._0
{
    public partial class frmOverdueItems : Form
    {
        public string connectionString;

        public frmOverdueItems()
        {
            InitializeComponent();
        }

        private void frmOverdueItems_Load(object sender, EventArgs e)
        {
            try
            {
                connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + frmHomeScreen.mUserFile;
                string bookQuery = "select title, due_date, customer.first_name &'  '&customer.last_name  as Customer_Name from book inner join customer on book.customer_id = customer.customer_id where due_date < #"+ System.DateTime.Now.ToShortDateString() +"#;";
                string movieQuery = "select title, due_date, customer.first_name &'  '&customer.last_name  as Customer_Name from movie inner join customer on movie.customer_id = customer.customer_id where due_date < #" + System.DateTime.Now.ToShortDateString() + "#;";
                string musicQuery = "select album, due_date, customer.first_name &'  '&customer.last_name  as Customer_Name from cd inner join customer on cd.customer_id = customer.customer_id where due_date < #" + System.DateTime.Now.ToShortDateString() + "#;";
                string gameQuery = "select title, due_date, customer.first_name &'  '&customer.last_name  as Customer_Name from game inner join customer on game.customer_id = customer.customer_id where due_date < #" + System.DateTime.Now.ToShortDateString() + "#;";

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
                BindingSource bs = new BindingSource();
                bs.DataSource = movieDT;
                dgvOverdueMovies.DataSource = bs;
                movieDA.Update(movieDT);
                //END MVOIE OVERDUE CHECK

                //BEGIN MUSIC OVERDUE CHECK
                OleDbDataAdapter musicDA = new OleDbDataAdapter(musicQuery, connectionString);
                OleDbCommandBuilder musicCB = new OleDbCommandBuilder(musicDA);
                DataTable musicDT = new DataTable();
                musicDA.Fill(musicDT);
                BindingSource musicBS = new BindingSource();
                bs.DataSource = musicDT;
                dgvOverdueMusic.DataSource = musicBS;
                musicDA.Update(musicDT);
                //END MUSIC OVERDUE CHECK

                //BEGIN GAME OVERDUE CHECK
                OleDbDataAdapter gameDA = new OleDbDataAdapter(gameQuery, connectionString);
                OleDbCommandBuilder gameCB = new OleDbCommandBuilder(gameDA);
                DataTable gameDT = new DataTable();
                gameDA.Fill(gameDT);
                BindingSource gameBS = new BindingSource();
                bs.DataSource = gameDT;
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
    }
}
