using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace openLibrary_2._0
{
    

    public partial class frmAddBook : Form
    {
        databaseHandler d = new databaseHandler();
        public string sqlstatement;
        private OleDbConnection mDB;

        public frmAddBook()
        {
            InitializeComponent();
        }

        [STAThread]

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

            string isbn;
            string title;
            string language;
            string format;
            string author;
            int bookid;

            bookid = d.findBookCount("SELECT Count(*) FROM book;");
            bookid++;

            isbn = txtISBN.Text;
            title = txtTitle.Text;
            author = txtAuthor.Text;
            language = txtLanguage.Text;
            format = txtFormat.Text;

            sqlstatement = "INSERT INTO BOOK (BOOK_ID, ISBN, TITLE, FORMAT, LANGUAGE, AUTHOR)" +
                                      "VALUES ('" + bookid + "','" + isbn + "','" + title + "','" + format + "','" + language + "','" + author + "')";

            d.loadDatabaseTable(sqlstatement);

            txtISBN.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtLanguage.Clear();
            txtFormat.Clear();

            txtISBN.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtISBN.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtLanguage.Clear();
            txtFormat.Clear();
        }

        
    }
}
