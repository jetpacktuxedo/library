using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace openLibrary_2._0
{
    public partial class frmBugReport : Form
    {
        public frmBugReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;

            send("tg6392@gmail.com", "Feedback from " + txtEmail.Text, txtMessage.Text);

            button1.Enabled = true;
            button2.Enabled = true;
        }

        public void send(string to, string subject, string body)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("noreply.openLibrary@gmail.com", "b0uldering"),
                    EnableSsl = true
                };
                client.Send("noreply.openlibrary@gmail.com", to, subject, body);
                MessageBox.Show("Message sent. Thank you!");
                Close();
            }
            catch
            {
                MessageBox.Show("Message did not send sucessfully.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
