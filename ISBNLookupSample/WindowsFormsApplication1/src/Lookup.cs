using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Xml;

namespace AmazonProductAdvtApi {
    class Lookup {

        //Declare constants
        private const string MY_AWS_ACCESS_KEY_ID = "AKIAIJBCB63BMUXIE4MQ";
        private const string MY_AWS_SECRET_KEY = "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";
        private const string DESTINATION = "ecs.amazonaws.com";
        private const string NAMESPACE = "http://webservices.amazon.com/AWSECommerceService/2011-08-01";

        //Method to convert ISBN-13 to ISBN-10
        public static string ConvertTo10(string isbn13) {
            string isbn10 = string.Empty;
            long temp;

            if (!string.IsNullOrEmpty(isbn13) && isbn13.Length == 13 && Int64.TryParse(isbn13, out temp)) {
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

        //Method to do an ISBN-based lookup and return the signed URL
        public static string lookup(string ISBN) {
            //Helper signs the requests
            SignedRequestHelper helper = new SignedRequestHelper(MY_AWS_ACCESS_KEY_ID, MY_AWS_SECRET_KEY, DESTINATION);

            //Helper looks for a dictionary containing all of the bits of the URL
            IDictionary<string, string> url = new Dictionary<string, String>();
            url["Service"] = "AWSECommerceService";
            url["Version"] = "2011-08-01";
            url["Operation"] = "ItemLookup";
            url["ItemId"] = ISBN;
            url["ResponseGroup"] = "Large";
            url["AssociateTag"] = "AssociateTag=openlibrary07-20";

            //Pass dictionary to helper, get the signed URL back out as a string
            string signedUrl = helper.Sign(url);

            return signedUrl;
        }

        //Method to take a signed URL and return information contained in the get response
        public static string Fetch(string type, string url) {
            try {
                //Makes a request, and exports the response into an XML file
                WebRequest request = HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();
                XmlDocument doc = new XmlDocument();
                doc.Load(response.GetResponseStream());

                //Parse XML document for errors
                XmlNodeList errorMessageNodes = doc.GetElementsByTagName("Message", NAMESPACE);
                if (errorMessageNodes != null && errorMessageNodes.Count > 0) {
                    String message = errorMessageNodes.Item(0).InnerText;
                    return "Error: " + message + " (but signature worked)";
                }

                //Pull title from title node
                XmlNode titleNode = doc.GetElementsByTagName("Title", NAMESPACE).Item(0);
                string title = titleNode.InnerText;

                //Pull Author from Author node
                XmlNode authorNode = doc.GetElementsByTagName("Author", NAMESPACE).Item(0);
                string author = authorNode.InnerText;

                //Switch case to return requested bits.
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
