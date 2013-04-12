using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace openLibrary_2._0
{
    public partial class frmLogin : Form
    {
        public static string ID;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ID = textBox1.Text;

            frmHomeScreen fmr = new frmHomeScreen();
            Close();

        }
    }
}
