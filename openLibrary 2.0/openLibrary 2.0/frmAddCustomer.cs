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
    public partial class frmAddCustomer : Form {

        databaseHandler d = new databaseHandler();

        public frmAddCustomer()
        {
            InitializeComponent();
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearFields() {
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

        private void btnAdd_Click(object sender, EventArgs e) {
            string first, last, address, phone, city, state, zip, email, card_code, birthdate, joindate, sqlstatement;

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

            sqlstatement = "INSERT INTO CUSTOMER (CUSTOMER_ID, FIRST_NAME, LAST_NAME, ADDRESS, PHONE, BIRTH_DATE, JOIN_DATE, EMAIL_ADDR, STATE, CITY, ZIP )" +
                "VALUES ('"
                + card_code + "','"
                + first + "','"
                + last + "','"
                + address + "','"
                + phone + "','"
                + birthdate + "','"
                + joindate + "','"
                + email + "','"
                + city + "','"
                + state + "','"
                + zip + "');";

            d.loadDatabaseTable(sqlstatement);

            clearFields();

        }
    }
}
