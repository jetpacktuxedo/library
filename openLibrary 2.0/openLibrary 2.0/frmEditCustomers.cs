using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace openLibrary_2._0 {
    public partial class frmEditCustomers : Form {

        public string customerID;
        string[] customerinfo = new string[10];
        databaseHandler d = new databaseHandler();
        public string sqlstatement;

        public frmEditCustomers(string customer) {
            customerID = customer;
            InitializeComponent();
        }

        private void frmEditCustomers_Load(object sender, EventArgs e) {
            customerinfo = d.customerResults(customerID);

            txtCardCode.Text = customerID;
            txtFirstName.Text = customerinfo[0];
            txtLastName.Text = customerinfo[1];
            txtPhone.Text = customerinfo[2];
            txtAddress.Text = customerinfo[3];
            txtCity.Text = customerinfo[4];
            txtState.Text = customerinfo[5];
            txtZipCode.Text = customerinfo[6];
            txtEmail.Text = customerinfo[7];
            dtpBirthDate.Value = Convert.ToDateTime(customerinfo[8]);
            dtpJoinDate.Value = Convert.ToDateTime(customerinfo[9]);
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            try {
                string FirstName, LastName, Phone, Address, City, State, Zip, Email;
                DateTime Birthdate, joindate;

                FirstName = escapeHandling(txtFirstName.Text);
                LastName = escapeHandling(txtLastName.Text);
                Phone = escapeHandling(txtPhone.Text);
                Address = escapeHandling(txtAddress.Text);
                City = escapeHandling(txtCity.Text);
                State = escapeHandling(txtState.Text);
                Zip = escapeHandling(txtZipCode.Text);
                Email = escapeHandling(txtEmail.Text);
                Birthdate = dtpBirthDate.Value;
                joindate = dtpJoinDate.Value;

                sqlstatement = "UPDATE Customer " +
                                    "SET First_Name = '" + FirstName + "', " +
                                    "Last_Name = '" + LastName + "', " +
                                    "Phone = '" + Phone + "', " +
                                    "Address = '" + Address + "', " +
                                    "City = '" + City + "', " +
                                    "State = '" + State + "', " +
                                    "Zip = '" + Zip + "', " +
                                    "Birth_Date = '" + Birthdate.ToString() + "', " +
                                    "Join_Date = '" + joindate.ToString() + "', " +
                                    "Email_Addr = '" + Email + "' " +
                                    "WHERE Customer_ID = '" + customerID + "';";

                d.loadDatabaseTable(sqlstatement);

                clearFields();
                Close();
            }
            catch {
                MessageBox.Show("The book could not be added. A common cause of this error is not having a database open.");
            }
            finally {
                d.closeDatabaseConnection();
            }
        }

        private void btnClear_Click(object sender, EventArgs e) {
            clearFields();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private string escapeHandling(string line) {
            return line.Replace("'", "''");
        }

        private void clearFields() {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtZipCode.Clear();
            txtEmail.Clear();
            txtCardCode.Clear();
            dtpBirthDate.Value = DateTime.Today;
            dtpJoinDate.Value = DateTime.Today;
        }
    }
}
