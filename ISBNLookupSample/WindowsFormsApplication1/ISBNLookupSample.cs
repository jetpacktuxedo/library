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
            //Convert ISBN-13 to ISBN-10
            itemID = Lookup.ConvertTo10(txtISBN.Text);

            if (txtISBN.Text == "") {
                MessageBox.Show("Please enter an ISBN.");
            }
            else if (itemID == "False"); //intentionally empty.
            else {
                //Format url for the get request
                requestUrl = Lookup.lookup(itemID);

                string[] result = Lookup.Fetch(requestUrl);

                //Submit Get request, extract info from pulled form
                title = result[0];
                author = result[1];
                binding = result[2];
                publisher = result[3];
                date = result[4];
                price = result[5];
                pages = result[6];

                //Push title and author data back into the form
                txtTitle.Text = title;
                txtAuthor.Text = author;
                txtBinding.Text = binding;
                txtPublisher.Text = publisher;
                txtDate.Text = date;
                txtPrice.Text = price;
                txtPages.Text = pages;
            }
        }
    }
}
