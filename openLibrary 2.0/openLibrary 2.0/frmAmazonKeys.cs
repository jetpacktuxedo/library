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
    public partial class frmAmazonKeys : Form
    {
        ArrayList info = new ArrayList();
        APIsettings s = new APIsettings();

        public frmAmazonKeys()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPrivate.UseSystemPasswordChar = true;
                txtPublic.UseSystemPasswordChar = true;
            }
            if (checkBox1.Checked == false)
            {
                txtPrivate.UseSystemPasswordChar = false;
                txtPublic.UseSystemPasswordChar = false;
            }
        }

        private void frmAmazonKeys_Load(object sender, EventArgs e)
        {
            s.create();
            info = s.parse();

            txtPublic.Text = info[0].ToString();
            txtPrivate.Text = info[1].ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            s.write(txtPublic.Text, txtPrivate.Text, "");
            Close();
        }
    }
}
