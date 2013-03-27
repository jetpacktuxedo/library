using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace AmazonProductAdvtApi {

    public partial class ISBNSample : Form {

        private const string MY_AWS_ACCESS_KEY_ID = "AKIAIJBCB63BMUXIE4MQ";
        private const string MY_AWS_SECRET_KEY = "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";
        private const string DESTINATION = "ecs.amazonaws.com";
        private const string NAMESPACE = "http://webservices.amazon.com/AWSECommerceService/2011-08-01";

        public static void Main() {
            ISBNSample main = new ISBNSample();
            Application.Run(main);
        }

        SignedRequestHelper helper = new SignedRequestHelper(MY_AWS_ACCESS_KEY_ID, MY_AWS_SECRET_KEY, DESTINATION);
        String requestUrl;
        String title, author, itemID;

        public ISBNSample() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void btnSubmit_Click(object sender, EventArgs e) {

            itemID = ConvertTo10(txtISBN.Text);

            requestUrl = helper.Sign(lookup(itemID));
            title = Fetch("title", requestUrl);
            author = Fetch("author", requestUrl);

            txtTitle.Text = title;
            txtAuthor.Text = author;
        }

        public static string ConvertTo10(string isbn13){
        string isbn10 = string.Empty;
        long temp;
 
        // *************************************************
        // Validation of isbn13 code can be done by        *
        // using this snippet found here:                  *
        // http://www.dreamincode.net/code/snippet5385.htm *
        // *************************************************
 
        if (!string.IsNullOrEmpty(isbn13) && isbn13.Length == 13 && Int64.TryParse(isbn13, out temp)){
            isbn10 = isbn13.Substring(3, 9);
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += Int32.Parse(isbn10[i].ToString()) * (i + 1);
 
            int result = sum % 11;
            char checkDigit = (result > 9) ? 'X' : result.ToString()[0];
            isbn10 += checkDigit;
            }
 
        return isbn10;
        }

        public static IDictionary<string, string> lookup(string ISBN) {
            IDictionary<string, string> url = new Dictionary<string, String>();
            url["Service"] = "AWSECommerceService";
            url["Version"] = "2011-08-01";
            url["Operation"] = "ItemLookup";
            url["ItemId"] = ISBN;
            url["ResponseGroup"] = "Large";
            url["AssociateTag"] = "AssociateTag=openlibrary07-20";
            return url;
        }

        public static string Fetch(string type, string url) {
            try {
                WebRequest request = HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();
                XmlDocument doc = new XmlDocument();
                doc.Load(response.GetResponseStream());

                XmlNodeList errorMessageNodes = doc.GetElementsByTagName("Message", NAMESPACE);
                if (errorMessageNodes != null && errorMessageNodes.Count > 0) {
                    String message = errorMessageNodes.Item(0).InnerText;
                    return "Error: " + message + " (but signature worked)";
                }

                XmlNode titleNode = doc.GetElementsByTagName("Title", NAMESPACE).Item(0);
                string title = titleNode.InnerText;

                XmlNode authorNode = doc.GetElementsByTagName("Author", NAMESPACE).Item(0);
                string author = authorNode.InnerText;

                switch (type) {
                    case ("title"): return title;
                    case ("author"): return author;
                }
            }
            catch (Exception e) {
                System.Console.WriteLine("Caught Exception: " + e.Message);
                System.Console.WriteLine("Stack Trace: " + e.StackTrace);
            }

            return null;
        }
    }
}
