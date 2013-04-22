using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Xml;
using System.Windows.Forms;
using System.Collections;

namespace openLibrary_2._0 {
    class bookLookup {

        /*Declare constants
        private const string MY_AWS_ACCESS_KEY_ID = "AKIAIJBCB63BMUXIE4MQ";
        private const string MY_AWS_SECRET_KEY = "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";*/
        private const string DESTINATION = "ecs.amazonaws.com";
        private const string NAMESPACE = "http://webservices.amazon.com/AWSECommerceService/2011-08-01";

        //Method to do an ISBN-based lookup and return the signed URL
        public static string lookup(string ISBN) {

            APIsettings set = new APIsettings();
            ArrayList parsed = new ArrayList();
            parsed = set.parse();

            string MY_AWS_ACCESS_KEY_ID = parsed[0].ToString(), MY_AWS_SECRET_KEY = parsed[1].ToString();
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
        
        //Method to convert ISBN-13 to ISBN-10
        public static string ConvertTo10(string isbn) {
            string isbn10 = string.Empty;
            long temp;

            if (!string.IsNullOrEmpty(isbn) && isbn.Length == 13 && Int64.TryParse(isbn, out temp)) {
                isbn10 = isbn.Substring(3, 9);
                int sum = 0;
                for (int i = 0; i < 9; i++)
                    sum += Int32.Parse(isbn10[i].ToString()) * (i + 1);

                int result = sum % 11;
                char checkDigit = (result > 9) ? 'X' : result.ToString()[0];
                isbn10 += checkDigit;
            }

            else if (!string.IsNullOrEmpty(isbn) && isbn.Length == 10) isbn10 = isbn;

            else {
                MessageBox.Show("Not a valid ISBN format. Please verify that the ISBN is correct.");
                isbn10 = "False";
            }

            return isbn10;
        }



        //Method to take a signed URL and return information contained in the get response
        public static string[] Fetch(string url) {
            string[] output = new string[7];
            string title = "", author = "", binding = "", publisher = "", date = "", price = "", pages = "";
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
                    string[] error = new string[7];

                    MessageBox.Show("Can't find ISBN information. Please verify that the ISBN is correct and that you have an active internet connection.");
                    //MessageBox.Show("Error: " + message + " (but signature worked)");

                    for (int i = 0; i < 7; i++) error[i] = "";
                    return error;
                }

                //Pull title from Title node
                XmlNode titleNode = doc.GetElementsByTagName("Title", NAMESPACE).Item(0);
                //      name      =                          "TAGNAME"           item[index]
                //                                                               For pulling multiple items, like in a search
                if(titleNode != null) title = titleNode.InnerText;

                //Pull Author from Author node
                XmlNode authorNode = doc.GetElementsByTagName("Author", NAMESPACE).Item(0);
                if(authorNode != null) author = authorNode.InnerText;

                //Pull binding type from Binding node
                XmlNode bindingNode = doc.GetElementsByTagName("Binding", NAMESPACE).Item(0);
                if(bindingNode != null) binding = bindingNode.InnerText;

                //Pull Publisher from Publisher node
                XmlNode publisherNode = doc.GetElementsByTagName("Publisher", NAMESPACE).Item(0);
                if(publisherNode != null) publisher = publisherNode.InnerText;

                //Pull Publisher from PublicationDate node
                XmlNode dateNode = doc.GetElementsByTagName("PublicationDate", NAMESPACE).Item(0);
                if(dateNode != null) date = dateNode.InnerText;

                //Pull formatted price from FormattedPrice node
                XmlNode priceNode = doc.GetElementsByTagName("FormattedPrice", NAMESPACE).Item(0);
                if(priceNode != null) price = priceNode.InnerText;

                //Pull number of pages from NumberOfPages node
                XmlNode pagesNode = doc.GetElementsByTagName("NumberOfPages", NAMESPACE).Item(0);
                if(pagesNode != null) pages = pagesNode.InnerText;

                output[0] = title;
                output[1] = author;
                output[2] = binding;
                output[3] = publisher;
                output[4] = date;
                output[5] = price;
                output[6] = pages;

                return output;
            }
            catch (Exception e) {
                System.Console.WriteLine("Caught Exception: " + e.Message);
                System.Console.WriteLine("Stack Trace: " + e.StackTrace);
            }

            return null;
        }
    
    }
}
