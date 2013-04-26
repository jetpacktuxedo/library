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
    public partial class frmClockIn : Form
    {
        public static string ID;

        public frmClockIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ID = textBox1.Text;
            databaseHandler d = new databaseHandler();
            d.clockIN(ID);

            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 13)
                button1.Focus();
        }
    }
}
