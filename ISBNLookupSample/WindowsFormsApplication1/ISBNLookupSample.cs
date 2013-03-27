using System;
using System.Windows.Forms;

namespace AmazonProductAdvtApi {

    public partial class ISBNSample : Form {
        //Variables!
        String requestUrl, title, author, itemID;

        //Create and launch form
        public static void Main() {
            ISBNSample main = new ISBNSample();
            Application.Run(main);
        }

        public ISBNSample() {
            InitializeComponent();
        }

        //On Submit click
        private void btnSubmit_Click(object sender, EventArgs e) {

            //Convert ISBN-13 to ISBN-10
            itemID = Lookup.ConvertTo10(txtISBN.Text);

            //Format url for the get request
            requestUrl = Lookup.lookup(itemID);
            //Submit Get request, extract title from pulled form
            title = Lookup.Fetch("title", requestUrl);
            //Submit Get request, extract author from pulled form
            author = Lookup.Fetch("author", requestUrl);

            //Push title and author data back into the form
            txtTitle.Text = title;
            txtAuthor.Text = author;
        }
    }
}
