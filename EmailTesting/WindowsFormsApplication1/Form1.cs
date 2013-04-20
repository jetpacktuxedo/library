using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e) {
            string email = txtEmail.Text, subject = txtSubject.Text, msg = txtBody.Text;
            mail myMail = new mail();
            myMail.send(email, subject, msg);
/*
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add(email);
            message.Subject = subject;
            message.From = new System.Net.Mail.MailAddress("crazeh.monkeh@gmail.com");
            message.Body = msg;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.google.com");
            smtp.Send(message); 
*/
        }
    }
}
