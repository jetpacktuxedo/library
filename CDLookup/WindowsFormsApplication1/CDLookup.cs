using System;
using System.Windows.Forms;
using System.Collections;

namespace AmazonProductAdvtApi {

    public partial class ISBNSample : Form {
        //Variables!
        String requestUrl, title, author, binding, publisher, date, price, pages, itemID;
        ArrayList tracks = new ArrayList();

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
            listBox1.Items.Clear();

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
                requestUrl = Lookup.lookup(itemID);

                ArrayList result = new ArrayList();
                result = Lookup.Fetch(requestUrl);

                //Submit Get request, extract info from pulled form
                if (result != null) {
                    title = result[0].ToString();
                    author = result[1].ToString();
                    binding = result[2].ToString();
                    publisher = result[3].ToString();
                    date = result[4].ToString();
                    price = result[5].ToString();
                    pages = result[6].ToString();
                    tracks = (ArrayList)result[7];
                }

                //Push title and author data back into the form
                txtTitle.Text = title;
                txtAuthor.Text = author;
                txtBinding.Text = binding;
                txtPublisher.Text = publisher;
                txtDate.Text = date;
                txtPrice.Text = price;
                txtPages.Text = pages;

                //Throw tracks and shit into the listbox
                int i = 0;
                while(i < tracks.Count){
                    listBox1.Items.Add(tracks[i] + "-" + tracks[i+1] + " - " + tracks[i+2]);
                    i+=3;
                }
                //Movies
                /*while (i < tracks.Count) {
                    listBox1.Items.Add(tracks[i]);
                    i++;
                }*/
            }
        }
    }
}
