/*
 * This code copyright 2013 by openLibrary
 * Developed by Tai Gunter and Ethan Madden.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections;


namespace openLibrary_2._0
{
    public partial class frmPrint : Form
    {

        public System.Drawing.Printing.PrintDocument docToPrint = new PrintDocument();
        public System.Windows.Forms.PrintPreviewDialog previewDialog = new PrintPreviewDialog();
        public System.Windows.Forms.PrintDialog printDialog = new PrintDialog();
        public System.Windows.Forms.PageSetupDialog pageSetupDialog = new PageSetupDialog();
        public string[] lines;
        public string rtbText;
        public int linesPrinted = 0;

    
        public frmPrint()
        {
            InitializeComponent();
            lines = new string[50];
            printDialog.Document = docToPrint;
            docToPrint.BeginPrint += new PrintEventHandler(OnBeginPrint);
            docToPrint.PrintPage += new PrintPageEventHandler(OnPrintPage);
            pageSetupDialog.Document = docToPrint;
            previewDialog.Document = docToPrint;
            Margins mar = new Margins(50, 50, 50, 50);
            docToPrint.DefaultPageSettings.Margins = mar;


        }

        public ArrayList toBePrinted = new ArrayList();

        public ArrayList getArrayList
        {
            get
            {
                return toBePrinted;
            }
            set
            {
                toBePrinted = value;
            }
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {

        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            pageSetupDialog.ShowDialog();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            previewDialog.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            docToPrint.Print();
        }

        public void OnBeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void OnPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            Font drawingFont = new Font("Cambria", 12);
            SolidBrush drawingBrush = new SolidBrush(Color.Black);

                
            foreach(string toPrint in toBePrinted){
                e.Graphics.DrawString (toPrint,
					 drawingFont, drawingBrush, x, y);

                y += 19;

                if (y >= e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                linesPrinted++;
            }

            e.HasMorePages = false;

            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
