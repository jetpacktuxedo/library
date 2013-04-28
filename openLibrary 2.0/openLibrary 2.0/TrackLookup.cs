using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Xml;
using System.Windows.Forms;
using System.Collections;

namespace openLibrary_2._0{
    class TrackLookup {

        /*Declare constants
        private const string MY_AWS_ACCESS_KEY_ID = "AKIAIJBCB63BMUXIE4MQ";
        private const string MY_AWS_SECRET_KEY = "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";*/
        private const string DESTINATION = "ecs.amazonaws.com";
        private const string NAMESPACE = "http://webservices.amazon.com/AWSECommerceService/2011-08-01";

        //Method to do an ISBN-based lookup and return the signed URL
        public static string lookup(string track, string album, string artist) {

            string signedUrl = "";

            try
            {
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
                url["Operation"] = "ItemSearch";
                url["Keywords"] = track + ", " + album + ", " + artist;
                url["SearchIndex"] = "MP3Downloads";
                url["ResponseGroup"] = "Large";
                url["AssociateTag"] = "AssociateTag=openlibrary07-20";

                //Pass dictionary to helper, get the signed URL back out as a string
                signedUrl = helper.Sign(url);
                return signedUrl;

            }
            catch
            {
                MessageBox.Show("Unfortunately, music preview isn't available for this track.");
            }
            return signedUrl;


        }

        //Method to take a signed URL and return information contained in the get response
        public static string Fetch(string url) {
            string asin = "";
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
                    string error;

                    MessageBox.Show("Unfortunately, music preview isn't available for this track.");
                    //MessageBox.Show("Error: " + message + " (but signature worked)");

                    return null;
                }

                XmlNode asinNode = doc.GetElementsByTagName("ASIN", NAMESPACE).Item(0);
                if (asinNode != null) asin = asinNode.InnerText;

                return asin;
            }
            catch (Exception e) {
                System.Console.WriteLine("Caught Exception: " + e.Message);
                System.Console.WriteLine("Stack Trace: " + e.StackTrace);
            }

            return null;
        }
    
    }
}
