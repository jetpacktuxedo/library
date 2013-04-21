using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace openLibrary_2._0
{
    class mail {
        public void send(string to, string subject, string body) {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add(to);
            message.Subject = subject;
            message.From = new System.Net.Mail.MailAddress("crazeh.monkeh@gmail.com");
            message.Body = body;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.google.com");
            smtp.Send(message);
        }
    }
}
