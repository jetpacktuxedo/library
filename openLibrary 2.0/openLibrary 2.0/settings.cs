using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace openLibrary_2._0 {
    public class APIsettings{
        string myFile = "settings.txt";
        public string accessKey, secretKey, emailAddress;

        public void write(string access, string secret, string email) {
            // Delete the file if it exists. 
            if (System.IO.File.Exists(myFile)) {
                System.IO.File.Delete(myFile);
            }

            // Create the file. 
            using (System.IO.FileStream fs = System.IO.File.Create(myFile, 1024)) {
                // Add some information to the file. 
                byte[] settings = new System.Text.UTF8Encoding(true).GetBytes("Amazon Advertizing API \n" +
                                                                              "----------------------\n" +
                                                                              "Access Key: " + access + "\n" +
                                                                              "Secret Key: " + secret + "\n" +
                                                                              "Email address: " + email + "\n");
                fs.Write(settings, 0, settings.Length);

                accessKey = access;
                secretKey = secret;
                emailAddress = email;
            }
        }

        public ArrayList read() {
            ArrayList output = new ArrayList();
            using (System.IO.StreamReader sr = System.IO.File.OpenText(myFile)) {
                string s = "";
                while ((s = sr.ReadLine()) != null) {
                    output.Add(s);
                }
            }
            return output;
        }

        public ArrayList parse() {
            ArrayList output = new ArrayList();
            ArrayList realout = new ArrayList();
            try
            {
                using (System.IO.StreamReader sr = System.IO.File.OpenText(myFile))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        output.Add(s);
                    }
                }
                for (int i = 2; i < 5; i++)
                {
                    char[] delimiters = new char[] { ':', ' ' };
                    string[] parse = (output[i].ToString()).Split(delimiters);
                    realout.Add(parse[3]);
                }
                accessKey = realout[0].ToString();
                secretKey = realout[1].ToString();
                emailAddress = realout[2].ToString();
                return realout;
            }

            catch { }

            return realout;
            
        }
    }
}
