using System;
using System.Windows.Forms;

public partial class frmMain : Form
{
    public static void Main()
    {
        frmMain main = new frmMain();
        Application.Run(main);
    }
    public frmMain()
    {
        InitializeComponent();
    }
    private void Exit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void OK_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Happy New Year!");
    }
}