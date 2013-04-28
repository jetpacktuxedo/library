using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace openLibrary_2._0 {
    public partial class frmEditEmployee : Form {

        public string employeeID;
        string[] employeeinfo = new string[10];
        databaseHandler d = new databaseHandler();
        public string sqlstatement;

        public frmEditEmployee(string employee) {
            employeeID = employee;
            InitializeComponent();
        }

        private void frmEditEmployee_Load(object sender, EventArgs e) {
            employeeinfo = d.employeeResults(employeeID);

            txtCardCode.Text = employeeID;
            txtFirstName.Text = employeeinfo[0];
            txtLastName.Text = employeeinfo[1];
            txtPhone.Text = employeeinfo[2];
            txtAddress.Text = employeeinfo[3];
            txtCity.Text = employeeinfo[4];
            txtState.Text = employeeinfo[5];
            txtZipCode.Text = employeeinfo[6];
            txtEmail.Text = employeeinfo[7];
            dtpBirthDate.Value = Convert.ToDateTime(employeeinfo[8]);
            dtpHireDate.Value = Convert.ToDateTime(employeeinfo[9]);
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            try {
                string FirstName, LastName, Phone, Address, City, State, Zip, Email;
                DateTime Birthdate, hiredate;

                FirstName = escapeHandling(txtFirstName.Text);
                LastName = escapeHandling(txtLastName.Text);
                Phone = escapeHandling(txtPhone.Text);
                Address = escapeHandling(txtAddress.Text);
                City = escapeHandling(txtCity.Text);
                State = escapeHandling(txtState.Text);
                Zip = escapeHandling(txtZipCode.Text);
                Email = escapeHandling(txtEmail.Text);
                Birthdate = dtpBirthDate.Value;
                hiredate = dtpHireDate.Value;

                sqlstatement = "UPDATE EMPLOYEE " +
                                    "SET First_Name = '" + FirstName + "', " +
                                    "Last_Name = '" + LastName + "', " +
                                    "Phone = '" + Phone + "', " +
                                    "Address = '" + Address + "', " +
                                    "City = '" + City + "', " +
                                    "State = '" + State + "', " +
                                    "Zip = '" + Zip + "', " +
                                    "Birth_Date = '" + Birthdate.ToString() + "', " +
                                    "Hire_Date = '" + hiredate.ToString() + "', " +
                                    "Email_Addr = '" + Email + "' " +
                                    "WHERE EMPLOYEE_ID = '" + employeeID + "';";

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
            dtpHireDate.Value = DateTime.Today;
        }
    }
}
