using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace openLibrary_2._0
{
    public partial class frmViewBook : Form
    {
        
        public frmViewBook()
        {
            InitializeComponent();
        }

        public void frmViewBook_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindGrid();
            filler();
        }

        private void bindGrid()
        {
            BindingSource bs = (BindingSource)dataGridView1.DataSource;
            bs.ResetBindings(false);

            bs.DataSource = this.accDB.BOOK;
        }

        public void filler()
        {
  
            this.bOOKTableAdapter.Fill(this.accDB.BOOK);
        }

  
    }
}
