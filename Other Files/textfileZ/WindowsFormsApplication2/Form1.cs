using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

/*
        private const string MY_AWS_ACCESS_KEY_ID = "AKIAIJBCB63BMUXIE4MQ";
        private const string MY_AWS_SECRET_KEY = "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";
*/

namespace WindowsFormsApplication2 {
    public partial class Form1 : Form {
        public files settings = new files();

        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            string access = txtAccess.Text, secret = txtSecret.Text, email = txtEmail.Text;
            settings.write(access, secret, email);
            
        }

        private void btnRead_Click(object sender, EventArgs e) {
            ArrayList read = new ArrayList();
            read = settings.parse();

            foreach (object line in read) {
                shitBox.Items.Add(line);
            }
        }
    }
}
