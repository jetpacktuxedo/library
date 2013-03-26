using System;
using System.Windows.Forms;
using System.Collections;
using System.Configuration;
using System.Threading;
using System.IO;
using System.Data.OleDb;


public partial class frmMain : Form
{
    [STAThread]
    public static void Main()
    {
        frmMain main = new frmMain();
        Application.Run(main);
    }

    private string mUserFile;
    private OleDbConnection mDB;
    private ArrayList mContacts = new ArrayList();

    public frmMain()
    {
        InitializeComponent();
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
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

        loadDatabaseTable("SELECT * FROM CONTACTS");
        showArrayInList();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }

    // The btnExit_Click method terminates the program when the EXIT button is clicked.
    private void btnExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    // The btnOK_Click method XXXX.
    private void btnOK_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Happy New Year!");
    }



    // The ShowMessage helper method displays an error message with a standard title and an OK button.
    private void ShowMessage(string msg)
    {
        MessageBox.Show(msg, "Problem found", MessageBoxButtons.OK);
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
            mContacts.Clear();
            openDatabaseConnection();
            mDB.Open();
            OleDbCommand cmd;
            OleDbDataReader rdr;
            cmd = new OleDbCommand(sql, mDB);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                clsFileHandler tempRecord = new clsFileHandler(
                    (int)rdr["contactID"],
                    (string)rdr["firstName"],
                    (string)rdr["lastName"],
                    (string)rdr["phone1"],
                    (string)rdr["phone2"],
                    (DateTime)rdr["birthDate"]);
                mContacts.Add(tempRecord);
            }
            rdr.Close();
        }
        catch (Exception ee) { MessageBox.Show("Something Went Wrong: " + ee.Message); }
    }

    private void showArrayInList()
    {
        string output;
        listBox1.Items.Clear();
        listBox1.Items.Add("CONTACT ID \t FIRST NAME \t LAST NAME \t PHONE 1 \t PHONE 2 \t BIRTH DATE");
        listBox1.Items.Add("".PadRight(60, '~'));

        foreach (clsFileHandler tempContract in mContacts)
        {
            listBox1.Items.Add(tempContract.serialize());
        }
    }
}