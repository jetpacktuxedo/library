using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace AmazonProductAdvtApi
{
    class ItemLookupSample
    {
        private const string MY_AWS_ACCESS_KEY_ID = "AKIAIJBCB63BMUXIE4MQ";
        private const string MY_AWS_SECRET_KEY = "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";
        private const string DESTINATION          = "ecs.amazonaws.com";

        private const string NAMESPACE = "http://webservices.amazon.com/AWSECommerceService/2011-08-01";
        private const string ITEM_ID = "1250035953";

        public static void Main()
        {
            SignedRequestHelper helper = new SignedRequestHelper(MY_AWS_ACCESS_KEY_ID, MY_AWS_SECRET_KEY, DESTINATION);
            String requestUrl;
            String title, author;

            IDictionary<string, string> r1 = new Dictionary<string, String>();
            r1["Service"] = "AWSECommerceService";
            r1["Version"] = "2011-08-01";
            r1["Operation"] = "ItemLookup";
            r1["ItemId"] = ITEM_ID;
            r1["ResponseGroup"] = "Large";
            r1["AssociateTag"] = "AssociateTag=openlibrary07-20";

            requestUrl = helper.Sign(r1);
            title = Fetch("title", requestUrl);
            author = Fetch("author", requestUrl);

            System.Console.WriteLine("Title is \"" + title + "\"");
            System.Console.WriteLine("Author is \"" + author + "\"");
            System.Console.WriteLine();

            System.Console.WriteLine("Hit Enter to end");
            System.Console.ReadLine();
        }

        private static string Fetch(string type, string url){
            try{
                WebRequest request = HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();
                XmlDocument doc = new XmlDocument();
                doc.Load(response.GetResponseStream());

                XmlNodeList errorMessageNodes = doc.GetElementsByTagName("Message", NAMESPACE);
                if (errorMessageNodes != null && errorMessageNodes.Count > 0){
                    String message = errorMessageNodes.Item(0).InnerText;
                    return "Error: " + message + " (but signature worked)";
                }

                XmlNode titleNode = doc.GetElementsByTagName("Title", NAMESPACE).Item(0);
                string title = titleNode.InnerText;

                XmlNode authorNode = doc.GetElementsByTagName("Title", NAMESPACE).Item(0);
                string author = authorNode.InnerText;

                switch (type) {
                    case ("title"): return title;
                    case ("author"): return author;
                }
            }
            catch (Exception e){
                System.Console.WriteLine("Caught Exception: " + e.Message);
                System.Console.WriteLine("Stack Trace: " + e.StackTrace);
            }

            return null;
        }
    }
}