using System;
using System.Windows.Forms;

namespace AmazonProductAdvtApi {

    public partial class ISBNSample : Form {
        String requestUrl;
        String title, author, itemID;

        public static void Main() {
            ISBNSample main = new ISBNSample();
            Application.Run(main);
        }

        public ISBNSample() {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e) {

            itemID = Lookup.ConvertTo10(txtISBN.Text);

            requestUrl = Lookup.lookup(itemID);
            title = Lookup.Fetch("title", requestUrl);
            author = Lookup.Fetch("author", requestUrl);

            txtTitle.Text = title;
            txtAuthor.Text = author;
        }
    }
}
