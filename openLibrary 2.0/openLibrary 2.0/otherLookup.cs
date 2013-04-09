using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Xml;
using System.Windows.Forms;

namespace openLibrary_2._0 {
    class otherLookup
    {

        //Declare constants
        private const string MY_AWS_ACCESS_KEY_ID = "AKIAIJBCB63BMUXIE4MQ";
        private const string MY_AWS_SECRET_KEY = "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";
        private const string DESTINATION = "ecs.amazonaws.com";
        private const string NAMESPACE = "http://webservices.amazon.com/AWSECommerceService/2011-08-01";

        //Method to do an ISBN-based lookup and return the signed URL
        public static string otherlookup(string UPC)
        {
            //Helper signs the requests
            SignedRequestHelper helper = new SignedRequestHelper(MY_AWS_ACCESS_KEY_ID, MY_AWS_SECRET_KEY, DESTINATION);

            //Helper looks for a dictionary containing all of the bits of the URL
            IDictionary<string, string> url = new Dictionary<string, String>();
            url["Service"] = "AWSECommerceService";
            url["Version"] = "2011-08-01";
            url["Operation"] = "ItemLookup";
            url["IdType"] = "UPC";
            url["SearchIndex"] = "All";
            url["ItemId"] = UPC;
            url["ResponseGroup"] = "Large";
            url["AssociateTag"] = "AssociateTag=openlibrary07-20";

            //Pass dictionary to helper, get the signed URL back out as a string
            string signedUrl = helper.Sign(url);

            return signedUrl;
        }

        //Method to take a signed URL and return information contained in the get response
        public static string[] otherFetch(string url)
        {
            string[] output = new string[7];
            string type = "", title = "", artist = "", binding = "", publisher = "", date = "", price = "", length = "";
            try
            {
                //Makes a request, and exports the response into an XML file
                WebRequest request = HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();
                XmlDocument doc = new XmlDocument();
                doc.Load(response.GetResponseStream());

                //Parse XML document for errors
                XmlNodeList errorMessageNodes = doc.GetElementsByTagName("Message", NAMESPACE);
                if (errorMessageNodes != null && errorMessageNodes.Count > 0)
                {
                    String message = errorMessageNodes.Item(0).InnerText;
                    string[] error = new string[7];

                    MessageBox.Show("Can't find ISBN information. Please verify that the ISBN is correct and that you have an active internet connection.");
                    //MessageBox.Show("Error: " + message + " (but signature worked)");

                    for (int i = 0; i < 7; i++) error[i] = "";
                    return error;
                }

                XmlNode typeNode = doc.GetElementsByTagName("ProductGroup", NAMESPACE).Item(0);
                if (typeNode != null) type = typeNode.InnerText;

                //Pull title from Title node
                XmlNode titleNode = doc.GetElementsByTagName("Title", NAMESPACE).Item(0);
                //      name      =                          "TAGNAME"           item[index]
                //                                                               For pulling multiple items, like in a search
                if (titleNode != null) title = titleNode.InnerText;

                //If a CD was scanned, pull "Artist" and "Disc Count"
                if (type == "Music")
                {
                    XmlNode artistNode = doc.GetElementsByTagName("Artist", NAMESPACE).Item(0);
                    if (artistNode != null) artist = artistNode.InnerText;

                    XmlNode lengthNode = doc.GetElementsByTagName("NumberOfDiscs", NAMESPACE).Item(0);
                    if (lengthNode != null) length = lengthNode.InnerText;
                }
                //If a Movie is scanned, pull "Director" and "Running time in minutes"
                else if (type == "DVD")
                {
                    XmlNode artistNode = doc.GetElementsByTagName("Director", NAMESPACE).Item(0);
                    if (artistNode != null) artist = artistNode.InnerText;

                    XmlNode lengthNode = doc.GetElementsByTagName("RunningTime", NAMESPACE).Item(0);
                    if (lengthNode != null) length = lengthNode.InnerText;
                }
                //If a Movie is scanned, pull "Director" and "Running time in minutes"
                else if (type == "Video Games")
                {
                    XmlNode artistNode = doc.GetElementsByTagName("Brand", NAMESPACE).Item(0);
                    if (artistNode != null) artist = artistNode.InnerText;

                    XmlNode platformNode = doc.GetElementsByTagName("Platform", NAMESPACE).Item(0);
                    XmlNode hwPlatformNode = doc.GetElementsByTagName("HardwarePlatform", NAMESPACE).Item(0);
                    if (platformNode != null) length = platformNode.InnerText;
                    if (hwPlatformNode != null) length = hwPlatformNode.InnerText;
                }
                //Pull binding type from Binding node
                //For CDs it will pull "CD" or "Vinyl" or similar
                //For Movies it will pull "DVD" or "Blu-Ray" or similar
                XmlNode bindingNode = doc.GetElementsByTagName("Binding", NAMESPACE).Item(0);
                if (bindingNode != null) binding = bindingNode.InnerText;

                //Pull Publisher from Publisher node
                XmlNode publisherNode = doc.GetElementsByTagName("Publisher", NAMESPACE).Item(0);
                if (publisherNode != null) publisher = publisherNode.InnerText;

                //Pull Publish date from PublicationDate node and Release Date from ReleaseDate node.
                //If both exist, use release date. Otherwise use whichever is available.
                //If neither are available, leave blank.
                //Will often be null, as there are many CDs and Movies that Amazon doesn't list a publication date for.
                XmlNode pubDateNode = doc.GetElementsByTagName("PublicationDate", NAMESPACE).Item(0);
                XmlNode relDateNode = doc.GetElementsByTagName("ReleaseDate", NAMESPACE).Item(0);
                if (pubDateNode != null) date = pubDateNode.InnerText;
                if (relDateNode != null) date = relDateNode.InnerText;

                //Pull formatted price from FormattedPrice node
                XmlNode priceNode = doc.GetElementsByTagName("FormattedPrice", NAMESPACE).Item(0);
                if (priceNode != null) price = priceNode.InnerText;

                output[0] = title;
                output[1] = artist;
                output[2] = binding;
                output[3] = publisher;
                output[4] = date;
                output[5] = price;
                output[6] = length;

                return output;
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Caught Exception: " + e.Message);
                System.Console.WriteLine("Stack Trace: " + e.StackTrace);
            }

            return null;
        }

    }
}
