using System;
using System.Windows.Forms;

namespace AmazonProductAdvtApi {

    public partial class ISBNSample : Form {
        //Variables!
        String requestUrl, title, author, binding, publisher, date, price, pages, itemID;

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
            lookup();
        }

        private void lookup() {
            string track = txtISBN.Text, artist = txtTitle.Text, album = txtAuthor.Text;

            //Convert ISBN-13 to ISBN-10
            itemID = txtISBN.Text;

            if (txtISBN.Text == "")
            {
                MessageBox.Show("Please enter an ISBN.");
            }
            else if (itemID == "False") ;  //intentionally empty.
            else
            {
                //Format url for the get request
                requestUrl = Lookup.lookup(track, album, artist);

                string result = Lookup.Fetch(requestUrl);

                //Submit Get request, extract info from pulled form
                string asin = result;

                //Push title and author data back into the form
                txtPublisher.Text = asin;
            }
        }
    }
}
