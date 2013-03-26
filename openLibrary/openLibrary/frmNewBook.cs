using System;
using System.Windows.Forms;
using System.Collections;
using System.Configuration;
using System.Threading;
using System.IO;
using System.Data.OleDb;


public partial class frmNewBook : Form
{
    [STAThread]
    public static void Main()
    {
        frmNewBook main = new frmNewBook();
        Application.Run(main);
    }

    private string mUserFile;
    public string sqlstatement;
    private OleDbConnection mDB;



    public frmNewBook()
    {
        InitializeComponent();
    }


    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }


    private void openDatabaseConnection()
    {
        string connectionString = ConfigurationManager.AppSettings["DBConnectionString"] + mUserFile;
        mDB = new OleDbConnection(connectionString);
    }

    private void closeDatabaseConnection()
    {
        if (mDB != null) mDB.Close();
    }

    private void loadDatabaseTable(string sql)
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
        catch (Exception ee) { MessageBox.Show("Something Went Wrong: " + ee.Message); }
    }

    private int findBookCount(string sql)
    {
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
                return (int)rdr[0];
            }

        }

        catch (Exception ee)
        {
            MessageBox.Show("Something went wrong: " + ee.Message);
            return (int)-1;
        }

        return -1;
    }


    private void btnAdd_Click(object sender, EventArgs e)
    {
        string isbn;
        string title;
        string year;
        string genre;
        string author;
        int bookid;

        bookid = findBookCount("SELECT Count(*) FROM book;");
        bookid++;

        isbn = txtISBN.Text;
        title = txtTitle.Text;
        year = txtReleaseYear.Text;
        genre = txtGenre.Text;
        author = txtAuthor.Text;


        sqlstatement = "INSERT INTO BOOK (BOOK_ID, ISBN, TITLE, RELEASE_YEAR, GENRE, AUTHOR)" +
                                  "VALUES ('" + bookid + "','" + isbn + "','" + title + "','" + year + "','" + genre + "','" + author + "')";

        loadDatabaseTable(sqlstatement);

        txtISBN.Clear();
        txtTitle.Clear();
        txtReleaseYear.Clear();
        txtGenre.Clear();
        txtAuthor.Clear();

        txtISBN.Focus();
    }

    private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
        OpenFileDialog ofd;
        try
        {
            ofd = new OpenFileDialog();
            ofd.Title = "Select the database file to open";
            ofd.Filter = "Database Files(*.mdb)|*.mdb|All files(*.*)|*.*";
            ofd.InitialDirectory = Path.Combine(Application.StartupPath, "@/Databases");

            if (ofd.ShowDialog() == DialogResult.OK) mUserFile = ofd.FileName;
        }
        catch (Exception ee) { MessageBox.Show("There was an error: " + ee.Message); }

        txtISBN.Enabled = true;
        txtTitle.Enabled = true;
        txtAuthor.Enabled = true;
        txtGenre.Enabled = true;
        txtReleaseYear.Enabled = true;
        btnAdd.Enabled = true;
        txtISBN.Focus();
    }
}