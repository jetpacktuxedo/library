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
    public partial class frmAddCustomer : Form
    {
        public frmAddCustomer()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string first, last, address, phone, city, state, zip, email, card_code, birthdate, joindate;


            first = txtFirstName.Text;
            last = txtLastName.Text;
            address = txtAddress.Text;
            phone = txtPhone.Text;
            city = txtCity.Text;
            state = txtState.Text;
            zip = txtZipCode.Text;
            email = txtEmail.Text;
            card_code = txtCardCode.Text;
            birthdate = dtpBirthDate.Value.ToShortDateString();
            joindate = dtpJoinDate.Value.ToShortDateString();


            //TODO: Add code to insert this data into the database.
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZipCode.Text = "";
            txtEmail.Text = "";
            txtCardCode.Text = "";
            dtpBirthDate.Value = DateTime.Today;
            dtpJoinDate.Value = DateTime.Today;

            txtFirstName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
