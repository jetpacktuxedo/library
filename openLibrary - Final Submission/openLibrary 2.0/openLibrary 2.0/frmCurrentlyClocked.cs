/*
 * This code copyright 2013 by openLibrary
 * Developed by Tai Gunter and Ethan Madden.
*/

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
    public partial class frmCurrentlyClocked : Form
    {
        databaseHandler d = new databaseHandler();

        public frmCurrentlyClocked()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstClockedIN.SelectedIndex >= 0)
            {
                btnClockThemOut.Enabled = true;
            }
        }

        private void frmCurrentlyClocked_Load(object sender, EventArgs e)
        {
            loadList();
        }

        private void loadList()
        {
            lstClockedIN.Items.Clear();
            ArrayList clocked = new ArrayList();

            clocked = d.whoIsClockedIn();

            foreach (string x in clocked)
            {
                lstClockedIN.Items.Add(x);
            }
        }

        private void btnClockThemOut_Click(object sender, EventArgs e)
        {
            if (lstClockedIN.SelectedIndex >= 0)
            {
                d.clockOUT(lstClockedIN.SelectedItem.ToString());
                loadList();
            }
        }
    }
}
