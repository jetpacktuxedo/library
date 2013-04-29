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

namespace openLibrary_2._0
{
    public partial class frmAddEmployee : Form {

        databaseHandler d = new databaseHandler();

        public frmAddEmployee()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string first, last, address, phone, city, state, zip, email, card_code, birthdate, hiredate, sqlstatement;
            

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
            hiredate = dtpHireDate.Value.ToShortDateString();

            sqlstatement = "INSERT INTO EMPLOYEE (EMPLOYEE_ID, FIRST_NAME, LAST_NAME, ADDRESS, PHONE, BIRTH_DATE, HIRE_DATE, EMAIL_ADDR, STATE, CITY, ZIP )" +
                "VALUES ('"
                + card_code + "','"
                + first + "','"
                + last + "','"
                + address + "','"
                + phone + "','"
                + birthdate + "','"
                + hiredate + "','"
                + email + "','"
                + city + "','"
                + state + "','"
                + zip + "');";

            d.loadDatabaseTable(sqlstatement);

            clearFields();
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
            dtpHireDate.Value = DateTime.Today;

            txtFirstName.Focus();
        }
    }
}
